using GTANetworkAPI;
using System;
using System.Collections.Generic;

class Koks:Script
{


    //text na kokainu se ne vraca kada se respawna biljka
    public class CocaineEnum : IEquatable<CocaineEnum>

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
            CocaineEnum objAsPart = obj as CocaineEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(CocaineEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static int Cocaine_Timer = 2700;
    public static List<CocaineEnum> KoksList = new List<CocaineEnum>();

    public static void KoksInit()
    {

        API.Shared.DeleteWorldProp(-596943609, new Vector3(3391.689, 5504.36, 23.9412), 40f); // tenda
        API.Shared.DeleteWorldProp(-1572018818, new Vector3(3391.689, 5504.36, 23.9412), 40f); // table

        KoksList.Add(new CocaineEnum { position = new Vector3(3473.93, 2580.318, 15.2327), stage = 0 }); // 0, 0, 266.1345
        KoksList.Add(new CocaineEnum { position = new Vector3(3465.63, 2579.278, 15.7327), stage = 0 }); // 0, 0, 248.2544
        KoksList.Add(new CocaineEnum { position = new Vector3(3468.14, 2573.458, 15.4427), stage = 0 }); // 0, 0, 323.119
        KoksList.Add(new CocaineEnum { position = new Vector3(3464.20, 2571.008, 15.1927), stage = 0 }); // 0, 0, 36.05629
        KoksList.Add(new CocaineEnum { position = new Vector3(3467.05, 2566.068, 15.0127), stage = 0 }); // 0, 0, 70.98997
        KoksList.Add(new CocaineEnum { position = new Vector3(3474.54, 2565.82, 14.8527), stage = 0 }); // 0, 0, 10.06372
        KoksList.Add(new CocaineEnum { position = new Vector3(3480.38, 2566.05, 14.1527), stage = 0 }); // 0, 0, 279.5106
        KoksList.Add(new CocaineEnum { position = new Vector3(3485.99, 2568.018, 13.2927), stage = 0 }); // 0, 0, 264.478
        KoksList.Add(new CocaineEnum { position = new Vector3(3485.99, 2568.018, 13.2927), stage = 0 }); // 0, 0, 264.478
        KoksList.Add(new CocaineEnum { position = new Vector3(3489.04, 2572.848, 13.0027), stage = 0 }); // 0, 0, 264.478
        KoksList.Add(new CocaineEnum { position = new Vector3(3492.26, 2578.048, 12.9927), stage = 0 }); // 0, 0, 264.478
        

        API.Shared.CreateObject(-1814952641, new Vector3(3391.689, 5504.36, 23.9412 - 1.2), new Vector3(0, 0, 0), 255, 0);

        foreach (var weed in KoksList)
        {
            weed.downtime = 10 * 60;
            weed.timer = null;
            weed.objectHandle = API.Shared.CreateObject(-2093428068, new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.2f), new Vector3(), 255, 0);
            weed.textLabel = API.Shared.CreateTextLabel("~y~List Kokaina ~n~~g~ [ Y ]~w", new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 0.4f), 11.0f, 0.3f, 4, new Color(221, 255, 0), false, 0);
        }
    }



    public static void PressKeyY(Player Client)
    {
        int index = 0;
        foreach (var weed in KoksList)
        {
            if (Main.IsInRangeOfPoint(Client.Position, weed.position, 1.0f) && weed.stage == 0)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 15, 1, Inventory.Max_Inventory_Weight(Client)))
                {
                    return;
                }
                
                int t = Cocaine_Timer / (int)Math.Ceiling(((decimal)NAPI.Pools.GetAllPlayers().Count / 10) + (decimal)0.01);

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
                    Inventory.GiveItemToInventory(Client, 15, 1);
                    Client.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+ ~y~List Kokaina");
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
                        weed.textLabel = API.Shared.CreateTextLabel("~y~List Kokaina ~n~~g~ [ Y ]~w", new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 0.4f), 11.0f, 0.3f, 4, new Color(221, 255, 0, 255), false, 0);
                        weed.timer.Kill();
                    }

                }, 1000, 0);
                return;
            }
            index++;

        }
    }


}

