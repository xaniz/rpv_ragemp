using GTANetworkAPI;
using System;
using System.Collections.Generic;

//-2093428068 

class Weed : Script
{
    public class WeedEnum : IEquatable<WeedEnum>
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
            WeedEnum objAsPart = obj as WeedEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(WeedEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }
    public static int Deafult_Reset_Mining_Job_Timer = 2400;

    public static List<WeedEnum> WeedList = new List<WeedEnum>();

    public static void WeedInit()
    {
        API.Shared.DeleteWorldProp(-305885281, new Vector3(2209.981, 5577.867, 53.93683), 40f);
        API.Shared.DeleteWorldProp(452618762, new Vector3(2209.981, 5577.867, 53.93683), 40f);

        WeedList.Add(new WeedEnum { position = new Vector3(3933.811, 4389.556, 16.61062), stage = 0 }); // SavedRotation: 0, 0, 263.3716
        WeedList.Add(new WeedEnum { position = new Vector3(3930.507, 4388.731, 16.72111), stage = 0 }); // SavedRotation: 0, 0, 268.5566
        WeedList.Add(new WeedEnum { position = new Vector3(3929.174, 4385.134, 16.83203), stage = 0 }); // SavedRotation: 0, 0, 270.1692
        WeedList.Add(new WeedEnum { position = new Vector3(3926.748, 4387.077, 16.83957), stage = 0 }); // SavedRotation: 0, 0, 269.441
        WeedList.Add(new WeedEnum { position = new Vector3(3925.985, 4390.904, 16.55909), stage = 0 }); // SavedRotation: 0, 0, 268.7005
        WeedList.Add(new WeedEnum { position = new Vector3(3928.032, 4393.481, 16.55564), stage = 0 }); // SavedRotation: 0, 0, 268.3207
        WeedList.Add(new WeedEnum { position = new Vector3(3931.638, 4394.437, 16.38172), stage = 0 }); // SavedRotation: 0, 0, 269.0052
        WeedList.Add(new WeedEnum { position = new Vector3(3931.805, 4398.021, 16.45309), stage = 0 }); // SavedRotation: 0, 0, 263.5453
        WeedList.Add(new WeedEnum { position = new Vector3(3927.755, 4398.738, 16.45387), stage = 0 }); // SavedRotation: 0, 0, 270.2586
        WeedList.Add(new WeedEnum { position = new Vector3(3924.366, 4395.85, 16.33415), stage = 0 }); // SavedRotation: 0, 0, 267.059
        WeedList.Add(new WeedEnum { position = new Vector3(3921.597, 4393.028, 16.3351), stage = 0 }); // SavedRotation: 0, 0, 356.2679
        WeedList.Add(new WeedEnum { position = new Vector3(3919.545, 4389.418, 16.51625), stage = 0 }); // SavedRotation: 0, 0, 267.3956
        WeedList.Add(new WeedEnum { position = new Vector3(3922.629, 4387.647, 16.56079), stage = 0 }); // SavedRotation: 0, 0, 270.0922
        WeedList.Add(new WeedEnum { position = new Vector3(3926.913, 4389.28, 16.66704), stage = 0 }); // SavedRotation: 0, 0, 269.5212
        WeedList.Add(new WeedEnum { position = new Vector3(3930.289, 4391.285, 16.70475), stage = 0 }); // SavedRotation: 0, 0, 89.70883
        WeedList.Add(new WeedEnum { position = new Vector3(3933.558, 4394.283, 16.18506), stage = 0 }); // SavedRotation: 0, 0, 90.36221
        WeedList.Add(new WeedEnum { position = new Vector3(3931.113, 4401.434, 16.68574), stage = 0 }); // SavedRotation: 0, 0, 86.38636
        WeedList.Add(new WeedEnum { position = new Vector3(3932.548, 4399.84, 16.49159), stage = 0 }); // SavedRotation: 0, 0, 88.11132
        WeedList.Add(new WeedEnum { position = new Vector3(3933.772, 4397.288, 16.30149), stage = 0 }); // SavedRotation: 0, 0, 88.41028
        WeedList.Add(new WeedEnum { position = new Vector3(3932.455, 4396.243, 16.34658), stage = 0 }); // SavedRotation: 0, 0, 89.13777
        WeedList.Add(new WeedEnum { position = new Vector3(3929.566, 4396.326, 16.55122), stage = 0 }); // SavedRotation: 0, 0, 87.80364
        WeedList.Add(new WeedEnum { position = new Vector3(3926.798, 4396.881, 16.41454), stage = 0 }); // SavedRotation: 0, 0, 87.00317
        WeedList.Add(new WeedEnum { position = new Vector3(3926.339, 4395.024, 16.40675), stage = 0 }); // SavedRotation: 0, 0, 89.27118
        WeedList.Add(new WeedEnum { position = new Vector3(3926.818, 4392.564, 16.51725), stage = 0 }); // SavedRotation: 0, 0, 85.86916
        WeedList.Add(new WeedEnum { position = new Vector3(3928.281, 4391.054, 16.64088), stage = 0 }); // SavedRotation: 0, 0, 85.86916
        WeedList.Add(new WeedEnum { position = new Vector3(3932.15, 4387.7, 16.69057), stage = 0 }); // SavedRotation: 0, 0, 85.86916
        WeedList.Add(new WeedEnum { position = new Vector3(3931.471, 4385.422, 16.61613), stage = 0 }); // SavedRotation: 0, 0, 269.1892
        WeedList.Add(new WeedEnum { position = new Vector3(3933.194, 4391.641, 16.42956), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(3923.838, 4391.66, 16.44037), stage = 0 }); // SavedRotation: 0, 0, 269.1225

        WeedList.Add(new WeedEnum { position = new Vector3(2215.615, 5579.768, 53.95348), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2219.407, 5579.426, 53.9551), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2221.491, 5579.264, 53.92793), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2223.325, 5579.109, 53.90919), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2226.078, 5578.92, 53.91958), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2228.776, 5578.739, 53.94855), stage = 0 }); // SavedRotation: 0, 0, 269.1225
        WeedList.Add(new WeedEnum { position = new Vector3(2231.441, 5578.559, 54.0471), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2233.871, 5578.417, 54.11332), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2234.425, 5576.448, 54.05649), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2230.299, 5576.692, 53.95242), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2227.143, 5576.88, 53.86525), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2224.43, 5577.044, 53.84996), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2221.069, 5577.246, 53.84805), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2216.892, 5577.596, 53.84252), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2214.53, 5577.602, 53.82127), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2215.841, 5575.146, 53.69764), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2218.854, 5575.077, 53.72162), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2223.189, 5574.835, 53.73179), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2227.416, 5574.531, 53.82043), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2231.151, 5574.299, 53.95538), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2234.625, 5574.041, 53.97034), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2232.554, 5576.522, 54.0294), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2232.824, 5574.258, 53.97596), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2229.23, 5574.337, 53.86808), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2225.403, 5574.759, 53.77193), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2221.176, 5574.94, 53.72314), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2219.194, 5577.36, 53.85454), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2213.975, 5575.313, 53.67958), stage = 0 }); // SavedRotation: 0, 0, 261.7181
        WeedList.Add(new WeedEnum { position = new Vector3(2217.454, 5579.642, 53.97069), stage = 0 }); // SavedRotation: 0, 0, 261.7181


        
        NAPI.Marker.CreateMarker(31, new Vector3(2433.2,4968.7, 42.8) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 0.5f, new Color(221, 255, 0, 110));

        API.Shared.CreateTextLabel("~g~-Prerada - ~n~~n~~c~ ~g~[~y~ Y ~g~]", new Vector3(2433.2,4968.7,42.9), 8.0f, 0.8f, 4, new Color(221, 255, 0, 255));


        foreach (var weed in WeedList)
        {
            weed.downtime = 10 * 60;
            weed.timer = null;
            weed.objectHandle = API.Shared.CreateObject(452618762, new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.2f), new Vector3(), 255, 0);
            weed.textLabel = API.Shared.CreateTextLabel("~h~~g~-~y~ Marihuana~g~ -~w~~n~~n~~b~[~y~ Y ~b~] ", new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 0.4f), 4.0f, 0.3f, 4, new Color(221, 255, 0, 255), true, 0);
        }

    }

    public static void PressKeyY(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(149.68, -1698.50, 29.29), 2.0f) && FactionManage.GetPlayerGroupID(Client) >=4 && FactionManage.GetPlayerGroupID(Client) <= 7 && FactionManage.GetGraffiti(Client) > 8)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "Marihuana", Description = "Prodaja Marihuane", RightLabel = "" });
            menu_item_list.Add(new { Type = 1, Name = "Kokain", Description = "Prodaja Kokaina", RightLabel = "" });
            menu_item_list.Add(new { Type = 1, Name = "Heroin", Description = "Prodaja Heroina", RightLabel = "" });
            InteractMenu.CreateMenu(Client, "SELL_DRUGS", "Prodaja droge", "~b~Sve", true, NAPI.Util.ToJson(menu_item_list), false);
        }
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(2433.2, 4968.7, 42.9), 2f) && FactionManage.GetPlayerGroupID(Client) >=8 && FactionManage.GetPlayerGroupID(Client) <= 50 && TurfWar.turf_war[0].ownerid == AccountManage.GetPlayerGroup(Client))
        {
            
            if (Client.GetData<dynamic>("Sal") > 0 && Client.GetData<dynamic>("Refinando") == false)
            {
                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 1, Name = "Marihuana", Description = "Prerada Marihuana", RightLabel = "" });
                menu_item_list.Add(new { Type = 1, Name = "Kokain", Description = "Prerada Kokaina", RightLabel = "" });
                menu_item_list.Add(new { Type = 1, Name = "Heroin", Description = "Prerada Heroina", RightLabel = "" });
                InteractMenu.CreateMenu(Client, "REFINAR_DROGAS", "Laboratorija", "~b~Prerada droge", true, NAPI.Util.ToJson(menu_item_list), false);
            }
            else if (Client.GetData<dynamic>("Refinando") == true)
            {
                InteractMenu.CloseDynamicMenu(Client);
                if (Salt.sal_timer[Main.getIdFromClient(Client)] != null)
                {
                    Salt.sal_timer[Main.getIdFromClient(Client)].Kill();
                    Main.DestroyProgressBar(Client);
                    Salt.sal_timer[Main.getIdFromClient(Client)] = null;
                }
                Client.StopAnimation();
                Client.SetData<dynamic>("Refinando", false);
                Client.TriggerEvent("freezeEx", false);
            }

        }
        else
        {
            /* if (Main.IsInRangeOfPoint(Client.Position, new Vector3(79.7464, -1964.313, -27.29238), 1.0f) || Main.IsInRangeOfPoint(Client.Position, new Vector3(-202.4977, -1615.433, -33.57374), 1.0f)) // Maconha
             {
                 StartProcess(Client, 1);
             }
             else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-202.4458, -1613.161, -33.57357), 1.0f) || Main.IsInRangeOfPoint(Client.Position, new Vector3(81.62601, -1964.365, -27.29238), 1.0f)) // Maconha
             {
                 StartProcess(Client, 2);
             }
             else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(1010.86, -3200.156, -38.99313), 3.0f)) // Meta
             {
                 Main.SendInfoMessage(Client, "system dar hale tosae ...");
             }*/
            foreach (var weed in WeedList)
            {
                if (Main.IsInRangeOfPoint(Client.Position, weed.position, 1.0f) && weed.stage == 0)
                {
                    if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 11, 1, Inventory.Max_Inventory_Weight(Client)))
                    {
                        return;
                    }

                    weed.stage = 1;
                    int t = Deafult_Reset_Mining_Job_Timer / (int)Math.Ceiling(((decimal)NAPI.Pools.GetAllPlayers().Count / 10) + (decimal)0.01);

                    if (t < 1000)
                    {
                        t = 900;
                    }

                    weed.downtime = t;
                    Main.SendNotificationBrowser(Client, "", "<string>+ 1</strong> Marihuana!", "success");
                    Client.TriggerEvent("FreezeEx", true);
                    Client.SetData<dynamic>("ForceAnim", true);
                    // NAPI.Player.PlayPlayerAnimation(Client, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
                    //Client.PlayScenario("WORLD_HUMAN_GARDENER_PLANT");
                    NAPI.Player.PlayPlayerAnimation(Client, 1, "anim@amb@business@weed@weed_inspecting_lo_med_hi@", "weed_spraybottle_crouch_spraying_02_inspector");


                    NAPI.Task.Run(() =>
                    {
                        if (!Client.Exists)
                        {
                            return;
                        }
                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~1x~y~ Marihuana~w~!");

                        Client.SetData<dynamic>("ForceAnim", false);
                        Client.TriggerEvent("FreezeEx", false);
                        Inventory.GiveItemToInventory(Client, 11, 1);
                        Client.StopAnimation();
                        weed.objectHandle.Position = new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.8f);
                        weed.textLabel.Delete();
                    }, delayTime: 10000);

                    weed.timer = TimerEx.SetTimer(() =>
                    {
                        weed.downtime -= 5;

                        switch (weed.downtime)
                        {
                            case 590: weed.objectHandle.Position = (new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.7f)); break;
                            case 300: weed.objectHandle.Position = (new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 2.1f)); break;
                            case 0: weed.objectHandle.Position = (new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 1.2f)); break;
                        }

                        if (weed.downtime == 0)
                        {

                            weed.downtime = 10 * 60;
                            weed.stage = 0;
                            weed.textLabel = API.Shared.CreateTextLabel("~h~~g~-~y~ Marihuana~g~ -~w~~n~~n~~b~[~y~ Y ~b~] ", new Vector3(weed.position.X, weed.position.Y, weed.position.Z - 0.4f), 4.0f, 0.3f, 4, new Color(221, 255, 0, 255), true, 0);
                            weed.timer.Kill();
                        }

                    }, 5000, 0);
                    return;
                }

            }
        }
    }

    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "REFINAR_DROGAS")
        {
            if (selectedIndex == 0)
            {
                StartProcess(Client, 1);
            }
            else if (selectedIndex == 1)
            {
                StartProcess(Client, 2);
            }
            else if (selectedIndex == 2)
            {
                StartProcess(Client, 3);
            }

        }
        else if (callbackId == "SELL_DRUGS")
        {
            if (selectedIndex == 0)
            {
                if (Inventory.GetPlayerItemFromInventory(Client, 12) > 0)
                {
                    InteractMenu.User_Input(Client, "input_sell_weed", "Prodaj marihuanu", Inventory.GetPlayerItemFromInventory(Client, 12).ToString(), "Kolicina koju imate " + Inventory.GetPlayerItemFromInventory(Client, 12) + "", "number");
                }
            }
            else if (selectedIndex == 1)
            {
                if (Inventory.GetPlayerItemFromInventory(Client, 16) > 0)
                {
                    InteractMenu.User_Input(Client, "input_sell_kokain", "Prodaj kokain ", Inventory.GetPlayerItemFromInventory(Client, 16).ToString(), "Kolicina koju imate " + Inventory.GetPlayerItemFromInventory(Client, 16) + "", "number");
                }
            }
            else if (selectedIndex == 2)
            {
                if (Inventory.GetPlayerItemFromInventory(Client, 65) > 0)
                {
                    InteractMenu.User_Input(Client, "input_sell_heroin", "Prodaj heroin ", Inventory.GetPlayerItemFromInventory(Client, 65).ToString(), "Kolicina koju imate " + Inventory.GetPlayerItemFromInventory(Client, 65) + "", "number");
                }
            }
        }
    }
    public static void OnInputResponse(Player Client, String response, String inputtext)
    {
        if (response == "input_sell_weed")
        {
            if (Inventory.GetPlayerItemFromInventory(Client, 12) > 0)
            {

                if (!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan unos.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vrednost ne moze biti manja od 1.");
                    return;
                }

                if (Inventory.GetPlayerItemFromInventory(Client, 12) < valor)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno!");
                    return;
                }
                Random rnd = new Random();

                int price = valor * rnd.Next(95, 115);

                Main.GivePlayerMoney(Client, price);
                GameLog.ELog(Client, GameLog.MyEnum.Job, " Prodata Marihuana za: "+price +" kolicina "+inputtext);
                Main.SendSuccessMessage(Client, "Prodali ste " + Main.EMBED_BLUE + "" + valor + "" + Main.EMBED_WHITE + "g marihuane za" + Main.EMBED_LIGHTGREEN + "$" + price.ToString("N0") + "" + Main.EMBED_WHITE + ".");
                Inventory.RemoveItemByType(Client, 12, valor);
            }
        }
        else if (response == "input_sell_kokain")
        {
            if (Inventory.GetPlayerItemFromInventory(Client, 16) > 0)
            {

                if (!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan unos.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vrednost ne moze biti manja od 1.");
                    return;
                }

                if (Inventory.GetPlayerItemFromInventory(Client, 16) < valor)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno!");
                    return;
                }
                Random rnd = new Random();

                int price = valor * rnd.Next(200, 260);

                GameLog.ELog(Client, GameLog.MyEnum.Job, " Kokain prodat za: " + price + " kolicina " + inputtext);

                Main.GivePlayerMoney(Client, price);
                Main.SendSuccessMessage(Client, "Prodali ste " + Main.EMBED_BLUE + "" + valor + "" + Main.EMBED_WHITE + "g kokaina za " + Main.EMBED_LIGHTGREEN + "$" + price.ToString("N0") + "" + Main.EMBED_WHITE + ".");
                Inventory.RemoveItemByType(Client, 16, valor);
            }
        }
        else if (response == "input_sell_heroin")
        {
            if (Inventory.GetPlayerItemFromInventory(Client, 65) > 0)
            {

                if (!Main.IsNumeric(inputtext))
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan unos.");
                    return;
                }

                int valor = Convert.ToInt32(inputtext);

                if (valor < 1)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vrednost ne moze biti manja od 1.");
                    return;
                }

                if (Inventory.GetPlayerItemFromInventory(Client, 65) < valor)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno!");
                    return;
                }
                Random rnd = new Random();

                int price = valor * rnd.Next(290, 350);

                GameLog.ELog(Client, GameLog.MyEnum.Job, " Heroin prodat za: " + price + " kolicina " + inputtext);

                Main.GivePlayerMoney(Client, price);
                Main.SendSuccessMessage(Client, "Prodali ste " + Main.EMBED_BLUE + "" + valor + "" + Main.EMBED_WHITE + "g heroina za " + Main.EMBED_LIGHTGREEN + "$" + price.ToString("N0") + "" + Main.EMBED_WHITE + ".");
                Inventory.RemoveItemByType(Client, 65, valor);
            }
        }
    }

    public static void StartProcess(Player Client, int type)
    {
        if (type == 1)
        {
            if (Inventory.GetPlayerItemFromInventory(Client, 11) >= 1 && Client.GetData<dynamic>("Refinando") == false)
            {
                //
                int sals = Inventory.GetPlayerItemFromInventory(Client, 11);
                // int sals_a_ser_refinados = 0;

                //
                Client.SetData<dynamic>("Refinando", true);
                Client.SetData<dynamic>("RefinandoTime", 0);

                //
                Client.TriggerEvent("freezeEx", true);
                Client.PlayScenario("WORLD_HUMAN_GUARD_STAND");
                Client.SetData<dynamic>("ForceAnim", true);
                //
                //Client.TriggerEvent("SetProgressBar", Client.GetData<dynamic>("RefinandoTime"), "Processando Maconha não-processada - " + sals_a_ser_refinados + " de " + sals + "");
                if (Inventory.GetPlayerItemFromInventory(Client, 11) > 0)
                {
                    Main.StartProgressBar(Client, 15, "marijuana");
                }
                //

                Salt.sal_timer[Main.getIdFromClient(Client)] = TimerEx.SetTimer(() =>
                {

                    //
                    if (Inventory.GetPlayerItemFromInventory(Client, 11) >= 1)
                    {
                        // 
                        Client.SetData<dynamic>("RefinandoTime", Client.GetData<dynamic>("RefinandoTime") + 1);
                        //Client.TriggerEvent("SetProgressBar", Client.GetData<dynamic>("RefinandoTime"), "Processando Maconha não-processada - " + sals_a_ser_refinados + " de " + sals + "");
                        if (Client.GetData<dynamic>("RefinandoTime") > 15)
                        {
                            Client.SetData<dynamic>("ForceAnim", true);
                            if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 12, 2, Inventory.Max_Inventory_Weight(Client)) == true)
                            {
                                return;
                            }
                            //
                            //    sals_a_ser_refinados += 2;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItemByType(Client, 11, 1);
                            Inventory.GiveItemToInventory(Client, 12, 1);
                            if (Inventory.GetPlayerItemFromInventory(Client, 11) > 0)
                            {
                                Main.StartProgressBar(Client,  15, "marijuana");
                            }

                            //
                            Client.SetData<dynamic>("RefinandoTime", 0);
                            //Client.TriggerEvent("SetProgressBar", Client.GetData<dynamic>("RefinandoTime"), "Processando Maconha não-processada - " + sals_a_ser_refinados + " de " + sals + "");

                            //

                            //
                            if (Inventory.GetPlayerItemFromInventory(Client, 11) == 0)
                            {
                                if (Salt.sal_timer[Main.getIdFromClient(Client)] != null)
                                {

                                    Salt.sal_timer[Main.getIdFromClient(Client)].Kill();
                                    Salt.sal_timer[Main.getIdFromClient(Client)] = null;
                                }
                                Main.DestroyProgressBar(Client);
                                Client.StopAnimation();
                                Client.SetData<dynamic>("ForceAnim", false);
                                Client.SetData<dynamic>("Refinando", false);
                                Client.TriggerEvent("freezeEx", false);
                            }
                        }
                    }
                    else
                    {
                        //
                        if (Salt.sal_timer[Main.getIdFromClient(Client)] != null)
                        {
                            Salt.sal_timer[Main.getIdFromClient(Client)].Kill();
                            Salt.sal_timer[Main.getIdFromClient(Client)] = null;
                        }
                        Client.SetData<dynamic>("ForceAnim", false);
                        Client.StopAnimation();
                        Client.SetData<dynamic>("Refinando", false);
                        Client.TriggerEvent("freezeEx", false);
                    }

                    if (Client.GetData<dynamic>("status") == false)
                    {
                        try
                        {
                            Salt.sal_timer[Main.getIdFromClient(Client)].Kill();
                            Salt.sal_timer[Main.getIdFromClient(Client)] = null;

                        }
                        catch (Exception)
                        {

                        }
                    }
                }, 1000, 0);
            }
        }
        else if (type == 2)
        {
            //
            int sals = Inventory.GetPlayerItemFromInventory(Client, 15);
            //   int sals_a_ser_refinados = 0;

            //
            Client.SetData<dynamic>("Refinando", true);
            Client.SetData<dynamic>("RefinandoTime", 0);
            Client.SetData<dynamic>("ForceAnim", true);

            //
            Client.TriggerEvent("freezeEx", true);
            Client.PlayScenario("WORLD_HUMAN_GUARD_STAND");
            if (Inventory.GetPlayerItemFromInventory(Client, 15) > 0)
            {
                Main.StartProgressBar(Client, 20, "cocaine");
            }
            //
            //Client.TriggerEvent("SetProgressBar", Client.GetData<dynamic>("RefinandoTime"), "Processando Opium - " + sals_a_ser_refinados + " de " + sals + "");
            //
            Salt.sal_timer[Main.getIdFromClient(Client)] = TimerEx.SetTimer(() =>
            {
                //
                if (Inventory.GetPlayerItemFromInventory(Client, 15) >= 1)
                {
                    // 
                    Client.SetData<dynamic>("RefinandoTime", Client.GetData<dynamic>("RefinandoTime") + 1);
                    //Client.TriggerEvent("SetProgressBar", Client.GetData<dynamic>("RefinandoTime"), "Processando Opium - " + sals_a_ser_refinados + " de " + sals + "");

                    if (Client.GetData<dynamic>("RefinandoTime") > 20)
                    {
                        Client.SetData<dynamic>("ForceAnim", true);

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 16, 1, Inventory.Max_Inventory_Weight(Client)) == true)
                        {
                            return;
                        }
                        //
                        //   sals_a_ser_refinados += 1;

                        // Remove o Sal e conta tudo novamente.
                        Inventory.RemoveItemByType(Client, 15, 1);
                        Inventory.GiveItemToInventory(Client, 16, 1);

                        if (Inventory.GetPlayerItemFromInventory(Client, 15) > 0)
                        {
                            Main.StartProgressBar(Client,  20, "cocaine");
                        }

                        //
                        Client.SetData<dynamic>("RefinandoTime", 0);
                        //Client.TriggerEvent("SetProgressBar", Client.GetData<dynamic>("RefinandoTime"), "Processando Opium - " + sals_a_ser_refinados + " de " + sals + "");

                        //

                        //
                        if (Inventory.GetPlayerItemFromInventory(Client, 15) == 0)
                        {
                            if (Salt.sal_timer[Main.getIdFromClient(Client)] != null)
                            {
                                Salt.sal_timer[Main.getIdFromClient(Client)].Kill();
                                Salt.sal_timer[Main.getIdFromClient(Client)] = null;
                            }
                            Client.SetData<dynamic>("ForceAnim", false);
                            Client.StopAnimation();
                            Client.SetData<dynamic>("Refinando", false);
                            Client.TriggerEvent("freezeEx", false);
                        }
                    }
                }
                else
                {
                    //
                    if (Salt.sal_timer[Main.getIdFromClient(Client)] != null)
                    {
                        Salt.sal_timer[Main.getIdFromClient(Client)].Kill();
                        Salt.sal_timer[Main.getIdFromClient(Client)] = null;
                    }
                    Client.SetData<dynamic>("ForceAnim", false);
                    Client.StopAnimation();
                    Client.SetData<dynamic>("Refinando", false);
                    Client.TriggerEvent("freezeEx", false);
                }
                if (Client.GetData<dynamic>("status") == false)
                {
                    try
                    {
                        Salt.sal_timer[Main.getIdFromClient(Client)].Kill();
                        Salt.sal_timer[Main.getIdFromClient(Client)] = null;
                    }
                    catch (Exception)
                    {

                    }
                }
            }, 1000, 0);
        }
        else if (type == 3)
        {
            //
            int sals = Inventory.GetPlayerItemFromInventory(Client, 66);
            //   int sals_a_ser_refinados = 0;

            //
            Client.SetData<dynamic>("Refinando", true);
            Client.SetData<dynamic>("RefinandoTime", 0);
            Client.SetData<dynamic>("ForceAnim", true);

            //
            Client.TriggerEvent("freezeEx", true);
            Client.PlayScenario("WORLD_HUMAN_GUARD_STAND");
            if (Inventory.GetPlayerItemFromInventory(Client, 66) > 0 && Inventory.GetPlayerItemFromInventory(Client, 67) > 0)
            {
                Main.StartProgressBar(Client, 20, "heroine");
            }
            //
            //Client.TriggerEvent("SetProgressBar", Client.GetData<dynamic>("RefinandoTime"), "Processando Opium - " + sals_a_ser_refinados + " de " + sals + "");
            //
            Salt.sal_timer[Main.getIdFromClient(Client)] = TimerEx.SetTimer(() =>
            {
                //
                if (Inventory.GetPlayerItemFromInventory(Client, 66) >= 1 && Inventory.GetPlayerItemFromInventory(Client, 67) >= 1)
                {
                    // 
                    Client.SetData<dynamic>("RefinandoTime", Client.GetData<dynamic>("RefinandoTime") + 1);
                    //Client.TriggerEvent("SetProgressBar", Client.GetData<dynamic>("RefinandoTime"), "Processando Opium - " + sals_a_ser_refinados + " de " + sals + "");

                    if (Client.GetData<dynamic>("RefinandoTime") > 20)
                    {
                        Client.SetData<dynamic>("ForceAnim", true);

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 65, 1, Inventory.Max_Inventory_Weight(Client)) == true)
                        {
                            return;
                        }
                        //
                        //   sals_a_ser_refinados += 1;

                        // Remove o Sal e conta tudo novamente.
                        Inventory.RemoveItemByType(Client, 66, 1);
                        Inventory.RemoveItemByType(Client, 67, 1);
                        Inventory.GiveItemToInventory(Client, 65, 1);

                        if (Inventory.GetPlayerItemFromInventory(Client, 66) > 0 && Inventory.GetPlayerItemFromInventory(Client, 67) > 0)
                        {
                            Main.StartProgressBar(Client,  20, "heroine");
                        }

                        //
                        Client.SetData<dynamic>("RefinandoTime", 0);
                        //Client.TriggerEvent("SetProgressBar", Client.GetData<dynamic>("RefinandoTime"), "Processando Opium - " + sals_a_ser_refinados + " de " + sals + "");

                        //

                        //
                        if (Inventory.GetPlayerItemFromInventory(Client, 66) == 0 || Inventory.GetPlayerItemFromInventory(Client, 67) == 0)
                        {
                            if (Salt.sal_timer[Main.getIdFromClient(Client)] != null)
                            {
                                Salt.sal_timer[Main.getIdFromClient(Client)].Kill();
                                Salt.sal_timer[Main.getIdFromClient(Client)] = null;
                            }
                            Client.SetData<dynamic>("ForceAnim", false);
                            Client.StopAnimation();
                            Client.SetData<dynamic>("Refinando", false);
                            Client.TriggerEvent("freezeEx", false);
                        }
                    }
                }
                else
                {
                    //
                    if (Salt.sal_timer[Main.getIdFromClient(Client)] != null)
                    {
                        Salt.sal_timer[Main.getIdFromClient(Client)].Kill();
                        Salt.sal_timer[Main.getIdFromClient(Client)] = null;
                    }
                    Client.SetData<dynamic>("ForceAnim", false);
                    Client.StopAnimation();
                    Client.SetData<dynamic>("Refinando", false);
                    Client.TriggerEvent("freezeEx", false);
                }
                if (Client.GetData<dynamic>("status") == false)
                {
                    try
                    {
                        Salt.sal_timer[Main.getIdFromClient(Client)].Kill();
                        Salt.sal_timer[Main.getIdFromClient(Client)] = null;
                    }
                    catch (Exception)
                    {

                    }
                }
            }, 1000, 0);
        }
    }

    public static void ModalConfirm(Player Client, string response)
    {
        if (response == "WEED_OFFER")
        {
            Player selling = Client.GetData<dynamic>("offer_seller");
            if (Main.IsPlayerLogged(selling) && selling.GetData<dynamic>("status") == true)
            {
                int index = Inventory.GetInventoryIndexFromName(selling, "Baseado");

                if (selling.GetData<dynamic>("inventory_item_" + index + "_amount") >= Client.GetData<dynamic>("offer_amount"))
                {
                    if (Main.GetPlayerMoney(Client) < Client.GetData<dynamic>("offer_price"))
                    {
                        Main.SendErrorMessage(Client, "Nemate dovoljno novca.");
                        return;
                    }

                    Inventory.RemoveItemByType(selling, 12, Client.GetData<dynamic>("offer_amount"));
                    Inventory.GiveItemToInventory(Client, 12, Client.GetData<dynamic>("offer_amount"));

                    Main.SendSuccessMessage(Client, "Kupili ste " + Client.GetData<dynamic>("offer_amount") + " g marihuane po ceni od $" + Client.GetData<dynamic>("offer_price") + " od " + AccountManage.GetCharacterName(selling) + ".");
                    Main.SendSuccessMessage(selling, "Prodali ste " + Client.GetData<dynamic>("offer_amount") + " g marihuane za $" + Client.GetData<dynamic>("offer_price") + " kupcu " + AccountManage.GetCharacterName(Client) + ".");

                    Main.GivePlayerMoney(Client, -Client.GetData<dynamic>("offer_price"));
                    Main.GivePlayerMoney(selling, Client.GetData<dynamic>("offer_price"));

                }
            }
            else
            {
                Main.SendErrorMessage(Client, "Odustali ste od kupovine.");
            }
            Client.SetData<dynamic>("offer_price", 0);
            Client.SetData<dynamic>("offer_amount", 0);
            Client.SetData<dynamic>("offer", false);
        }
        else if (response == "HEROIN_OFFER")
        {
            Player selling = Client.GetData<dynamic>("offer_seller");
            if (Main.IsPlayerLogged(selling) && selling.GetData<dynamic>("status") == true)
            {
                int index = Inventory.GetInventoryIndexFromName(selling, "Cocaina");

                if (selling.GetData<dynamic>("inventory_item_" + index + "_amount") >= Client.GetData<dynamic>("offer_amount"))
                {
                    if (Main.GetPlayerMoney(Client) < Client.GetData<dynamic>("offer_price"))
                    {
                        Main.SendErrorMessage(Client, "Nemate dovoljno novca!");
                        return;
                    }

                    Inventory.RemoveItemByType(selling, 16, Client.GetData<dynamic>("offer_amount"));
                    Inventory.GiveItemToInventory(Client, 16, Client.GetData<dynamic>("offer_amount"));

                    Main.SendSuccessMessage(Client, "Kupili ste " + Client.GetData<dynamic>("offer_amount") + "g heroina po ceni od $" + Client.GetData<dynamic>("offer_price") + " od " + AccountManage.GetCharacterName(selling) + ".");
                    Main.SendSuccessMessage(selling, "Prodali ste " + Client.GetData<dynamic>("offer_amount") + "g heroina za $" + Client.GetData<dynamic>("offer_price") + " kupcu " + AccountManage.GetCharacterName(Client) + ".");

                    Main.GivePlayerMoney(Client, -Client.GetData<dynamic>("offer_price"));
                    Main.GivePlayerMoney(selling, Client.GetData<dynamic>("offer_price"));

                }
            }
            else
            {
                Main.SendErrorMessage(Client, "Nemate dovoljno robe.");
            }
            Client.SetData<dynamic>("offer_price", 0);
            Client.SetData<dynamic>("offer_amount", 0);
            Client.SetData<dynamic>("offer", false);
        }
    }

    public static void ModalCancel(Player Client, string response)
    {
        if (response == "WEED_OFFER")
        {
            Client.SetData<dynamic>("offer_price", 0);
            Client.SetData<dynamic>("offer_amount", 0);
            Client.SetData<dynamic>("offer", false);
        }
    }

}

