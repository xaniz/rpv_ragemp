using GTANetworkAPI;
using System;
using System.Collections.Generic;

class mushrooms:Script
{


    public class MushroomsEnum : IEquatable<MushroomsEnum>

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
            MushroomsEnum objAsPart = obj as MushroomsEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(MushroomsEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static int Mushrooms_Timer = 2700;
    public static List<MushroomsEnum> MushList = new List<MushroomsEnum>();

    public static void MushInit()
    {


        MushList.Add(new MushroomsEnum { position = new Vector3(-1608.9034, 4741.0464, 53.81472), stage = 0 }); // 0, 0, 266.1345
        MushList.Add(new MushroomsEnum { position = new Vector3(-1582.9154, 4709.7026, 48.67147), stage = 0 }); // 0, 0, 248.2544
        MushList.Add(new MushroomsEnum { position = new Vector3(-1603.1212, 4687.2197, 40.30332), stage = 0 }); // 0, 0, 323.119
        MushList.Add(new MushroomsEnum { position = new Vector3(-1593.8457, 4645.056, 48.70034), stage = 0 }); // 0, 0, 36.05629
        MushList.Add(new MushroomsEnum { position = new Vector3(-1600.4586, 4614.038, 40.46443), stage = 0 }); // 0, 0, 70.98997
        MushList.Add(new MushroomsEnum { position = new Vector3(-1600.5171, 4581.637, 37.99025), stage = 0 }); // 0, 0, 10.06372
        MushList.Add(new MushroomsEnum { position = new Vector3(-1643.5214, 4547.4756, 42.51319), stage = 0 }); // 0, 0, 279.5106
        MushList.Add(new MushroomsEnum { position = new Vector3(-1679.4718, 4542.9443, 35.181877), stage = 0 }); // 0, 0, 264.478
        MushList.Add(new MushroomsEnum { position = new Vector3(-1458.5334, 4613.0435, 51.688953), stage = 0 }); // 0, 0, 264.478
        MushList.Add(new MushroomsEnum { position = new Vector3(-1502.2854, 4417.367, 17.60038), stage = 0 }); // 0, 0, 264.478
        MushList.Add(new MushroomsEnum { position = new Vector3(-1473.2009, 4425.769, 24.80261), stage = 0 }); // 0, 0, 264.478
        MushList.Add(new MushroomsEnum { position = new Vector3(-1516.7852, 4521.8237, 46.12168), stage = 0 }); // 0, 0, 264.478
        MushList.Add(new MushroomsEnum { position = new Vector3(-1472.2148, 4632.6665, 49.99247), stage = 0 }); // 0, 0, 264.478
        MushList.Add(new MushroomsEnum { position = new Vector3(-1691.4491, 4709.5312, 33.90981), stage = 0 }); // 0, 0, 264.478
        


        foreach (var weed in MushList)
        {
            weed.downtime = 10 * 60;
            weed.timer = null;
            weed.objectHandle = API.Shared.CreateObject(-1027805354, new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.1f), new Vector3(), 255, 0);
            weed.textLabel = API.Shared.CreateTextLabel("~y~Pecurka ~n~~g~ [ Y ]~w", new Vector3(weed.position.X, weed.position.Y, weed.position.Z + 0.1f), 11.0f, 0.3f, 4, new Color(221, 255, 0), false, 0);
        }
    }



    public static void PressKeyY(Player Client)
    {
        int index = 0;
        foreach (var weed in MushList)
        {
            if (Main.IsInRangeOfPoint(Client.Position, weed.position, 1.5f) && weed.stage == 0)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 66, 1, Inventory.Max_Inventory_Weight(Client)))
                {
                    return;
                }
                
                int t = Mushrooms_Timer / (int)Math.Ceiling(((decimal)NAPI.Pools.GetAllPlayers().Count / 10) + (decimal)0.01);

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
                    Inventory.GiveItemToInventory(Client, 81, 1);
                    Client.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+ ~y~Pecurka");
                    weed.textLabel.Delete();
                    if (Client.GetData<dynamic>("zadatak7") == true)
                    {
                        Client.SetData("zadatak7", false);
                        Main.GivePlayerEXP(Client, 300);
                        Main.GivePlayerMoney(Client, 3000);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste dnevni zadatak");
                    }
                }, delayTime: 3000);


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
                        weed.textLabel = API.Shared.CreateTextLabel("~y~Pecurka ~n~~g~ [ Y ]~w", new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 0.4f), 11.0f, 0.3f, 4, new Color(221, 255, 0, 255), false, 0);
                        weed.timer.Kill();
                    }

                }, 1000, 0);
                return;
            }
            index++;

        }
    }

        public static void sellmush(Player c)
        {
            if (Inventory.GetPlayerItemFromInventory(c, 81) > 0)
            {
                int totfish = Inventory.GetPlayerItemFromInventory(c, 81);
                Inventory.RemoveItemByType(c, 81, totfish);
                Main.GivePlayerMoney(c, 400 * totfish);
                Main.DisplayErrorMessage(c, NotifyType.Success, NotifyPosition.BottomCenter, "Prodali ste Pecurke");
            }
        
        }


}

