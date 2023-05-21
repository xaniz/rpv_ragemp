using GTANetworkAPI;
using System;
using System.Collections.Generic;

class opium:Script
{


    public class OpiumEnum : IEquatable<OpiumEnum>

    {
        public int id { get; set; }

        public Entity objectHandle { get; set; }
        public TextLabel textLabel { get; set; }
        public Vector3 position { get; set; }
        public TimerEx timer { get; set; }
        public int stage { get; set; }
        public int downtime { get; set; }
        public override int GetHashCode()
        {
            return id;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            OpiumEnum objAsPart = obj as OpiumEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(OpiumEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static int Opium_Timer = 2700;
    public static List<OpiumEnum> OpimList = new List<OpiumEnum>();

    public static void OpimInit()
    {


        OpimList.Add(new OpiumEnum { position = new Vector3(1891.7834, 5006.52, 47.956657), stage = 0 }); // 0, 0, 266.1345
        OpimList.Add(new OpiumEnum { position = new Vector3(1894.1367, 5008.5815, 47.610023), stage = 0 }); // 0, 0, 248.2544
        OpimList.Add(new OpiumEnum { position = new Vector3(1896.4082, 5010.474, 47.330383), stage = 0 }); // 0, 0, 323.119
        OpimList.Add(new OpiumEnum { position = new Vector3(1899.0808, 5012.6714, 47.04387), stage = 0 }); // 0, 0, 36.05629
        OpimList.Add(new OpiumEnum { position = new Vector3(1902.1322, 5015.2705, 46.844505), stage = 0 }); // 0, 0, 70.98997
        OpimList.Add(new OpiumEnum { position = new Vector3(1904.6023, 5017.529, 46.773834), stage = 0 }); // 0, 0, 10.06372
        OpimList.Add(new OpiumEnum { position = new Vector3(1907.5513, 5019.9844, 46.628754), stage = 0 }); // 0, 0, 279.5106
        OpimList.Add(new OpiumEnum { position = new Vector3(1910.1454, 5022.235, 46.43923), stage = 0 }); // 0, 0, 264.478
        OpimList.Add(new OpiumEnum { position = new Vector3(1913.2346, 5024.926, 46.20199), stage = 0 }); // 0, 0, 264.478
        OpimList.Add(new OpiumEnum { position = new Vector3(1915.9288, 5027.268, 45.983284), stage = 0 }); // 0, 0, 264.478
        OpimList.Add(new OpiumEnum { position = new Vector3(1919.3557, 5030.218, 45.550438), stage = 0 }); // 0, 0, 264.478
        OpimList.Add(new OpiumEnum { position = new Vector3(1922.9688, 5033.2817, 44.894073), stage = 0 }); // 0, 0, 264.478
        OpimList.Add(new OpiumEnum { position = new Vector3(1925.7637, 5035.646, 44.38627), stage = 0 }); // 0, 0, 264.478
        OpimList.Add(new OpiumEnum { position = new Vector3(1928.8893, 5038.3, 43.815594), stage = 0 }); // 0, 0, 264.478
        


        foreach (var weed in OpimList)
        {
            weed.downtime = 10 * 60;
            weed.timer = null;
            weed.objectHandle = API.Shared.CreateObject(-950054773, new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 0.4f), new Vector3(), 255, 0);
            weed.textLabel = API.Shared.CreateTextLabel("~y~Opium ~n~~g~ [ Y ]~w", new Vector3(weed.position.X, weed.position.Y, weed.position.Z + 0.1f), 11.0f, 0.3f, 4, new Color(221, 255, 0), false, 0);
        }
    }



    public static void PressKeyY(Player Client)
    {
        int index = 0;
        foreach (var weed in OpimList)
        {
            if (Main.IsInRangeOfPoint(Client.Position, weed.position, 1.5f) && weed.stage == 0)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 66, 1, Inventory.Max_Inventory_Weight(Client)))
                {
                    return;
                }
                
                int t = Opium_Timer / (int)Math.Ceiling(((decimal)NAPI.Pools.GetAllPlayers().Count / 10) + (decimal)0.01);

                if (t < 1300)
                {
                    t = 1200;
                }
                weed.downtime = t;

                weed.stage = 1;

                
                Client.TriggerEvent("FreezeEx", true);
                //  Client.PlayScenario("WORLD_HUMAN_GARDENER_PLANT");
                NAPI.Player.PlayPlayerAnimation(Client, 1, "anim@amb@business@weed@weed_inspecting_lo_med_hi@", "weed_spraybottle_crouch_spraying_02_inspector");

                Client.SetData<dynamic>("ForceAnim", true);
                // NAPI.Player.PlayPlayerAnimation(Client, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
                NAPI.Task.Run(() =>
                {
                    if (!Client.Exists)
                    {
                        return;
                    }
                    Client.SetData<dynamic>("ForceAnim", false);
                    Client.TriggerEvent("FreezeEx", false);
                    Client.StopAnimation();
                    weed.objectHandle.Position = new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.8f);
                    Inventory.GiveItemToInventory(Client, 66, 1);
                    Client.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+ ~y~Opium");
                    weed.textLabel.Delete();
                }, delayTime: 9000);


                weed.timer = TimerEx.SetTimer(() =>
                {
                    weed.downtime--;

                    switch (weed.downtime)
                    {
                        case 590: weed.objectHandle.Position= (new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.5f)); break;
                        case 250: weed.objectHandle.Position= (new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.8f)); break;
                        case 0: weed.objectHandle.Position= (new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.0f)); break;
                    }

                    if (weed.downtime == 0)
                    {
                        weed.downtime = 10 * 60;
                        weed.stage = 0;
                        weed.textLabel = API.Shared.CreateTextLabel("~y~Opium ~n~~g~ [ Y ]~w", new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 0.4f), 11.0f, 0.3f, 4, new Color(221, 255, 0, 255), false, 0);
                        weed.timer.Kill();
                    }

                }, 1000, 0);
                return;
            }
            index++;

        }
    }


}

