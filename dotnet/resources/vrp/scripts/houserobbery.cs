using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Timers;

class houserobbery : Script
{
    public static List<dynamic> robhouses = new List<dynamic>();

    public class House
    {
        public int MarkerType { get; set; }
        public Vector3 Position { get; set; }
        public bool IsRobbed { get; set; }
    }

    public houserobbery()
    {
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(970.94, -701.14, 58.48), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(906.66, -490.21, 59.44), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(1341.82, -597.57, 74.70), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(1302.78, -528.43, 71.46), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(1221.30, -668.82, 63.49), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(114.11, -1960.80, 21.33), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(23.42, -1896.34, 22.97), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(323.89, -1937.67, 25.02), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(443.33, -1707.24, 29.71), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(16.48, -1444.25, 30.94), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(495.79, -1822.81, 28.87), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(1289.32, -1711.05, 55.47), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-1084.96, -1558.39, 4.50), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-1347.39, -1145.93, 4.34), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-1913.80, -574.38, 11.44), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-1754.60, -708.67, 10.40), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-1061.29, -943.37, 2.19), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-1537.06, 130.39, 57.37), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-1733.42, 379.66, 89.73), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-1337.67, 606.15, 134.38), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-1174.92, 440.22, 86.85), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-1090.57, 548.20, 103.63), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-658.68, 887.10, 229.25), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-580.57, 492.06, 108.90), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-339.86, 625.76, 171.36), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-328.21, 370.05, 110.01), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-113.51, 985.77, 235.75), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(45.58, 556.37, 180.08), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(331.11, 465.96, 151.18), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-896.43, -4.94, 43.80), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-987.20, 487.77, 82.27), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-775.03, 312.40, 85.70), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-48.04, -585.62, 37.96), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(288.70, -1094.95, 29.42), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-3088.97, 221.55, 14.07), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-3017.46, 746.58, 27.59), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-3250.50, 1027.26, 11.76), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-2587.94, 1911.16, 167.50), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(1936.85, 3891.24, 32.53), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(1436.01, 3657.35, 34.30), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(1674.31, 4658.23, 43.37), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-130.55, 6551.68, 29.68), IsRobbed = false });
        robhouses.Add(new House { MarkerType = 1, Position = new Vector3(-346.99, 6224.72, 31.66), IsRobbed = false });

    }


    public static void ResetHousesRob()
    {
        foreach (var hrob in robhouses)
        {
            hrob.IsRobbed = false;
        }
    }

    public static void hrobRob(Player Client)
    {
        foreach (var hrob in robhouses)
        {
            if (Main.IsInRangeOfPoint(Client.Position, hrob.Position, 3.0f))
            {
                if (hrob.IsRobbed == true)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Ova kuca je vec opljackana.");
                    return;
                }
            
                if (Inventory.GetPlayerItemFromInventory(Client, 20) > 0)
                {
                    // anim hrob
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 1, "amb@world_human_welding@male@base", "base");
                    BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_tool_drill"), 60309, new Vector3(0.060, 0.060, 0.020), new Vector3(-90.0000,-90.0000, 0.0000));
                    NAPI.Task.Run(() =>
                    {
                        if (NAPI.Player.IsPlayerConnected(Client))
                        {
                            Client.StopAnimation();
                            BasicSync.DetachObject(Client);
                            if (Main.IsInRangeOfPoint(Client.Position, hrob.Position, 3.0f) && (Inventory.GetPlayerItemFromInventory(Client, 20) > 0))
                            {   
                                Police.SetPlayerCrime(Client, 1);
                                Client.SetData<dynamic>("hrobber", true);
                                Client.SetData<dynamic>("hrposb", Client.Position);
                                Client.Dimension = 1001;
                                Client.Position = new Vector3(346.57, -1012.68, -99.20);
                                hrob.IsRobbed = true;
                                return;
                            }
                            else 
                            {
                                Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Otisli ste daleko od vrata");
                                return;
                            }
                        }
                    }, delayTime: 30000);
                }
            }
        }
    }

    public static void HouseExit(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(346.57, -1012.68, -99.20), 3.0f) && Client.GetData<dynamic>("hrobber") == true)
        {
            Client.Dimension = 0;
            Client.Position = Client.GetData<dynamic>("hrposb");
            for (int i = 1; i <= 6; i++)
            {
                Client.ResetData($"houserobp{i}");
            }
            
        }
        return;
    }

    public static void SellItems(Player Client)
    {
        if (Inventory.GetPlayerItemFromInventory(Client, 78) > 0)
        {
            int totalnakit = Inventory.GetPlayerItemFromInventory(Client, 78);
            Inventory.RemoveItemByType(Client, 78, totalnakit);
            Main.GivePlayerMoney(Client, 1000 * totalnakit);
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Prodali ste nakit i zaradili $" + totalnakit * 1000 + " ");
        }
    }

    public static void GetHouseItem(Player client)
    {
        if (client.GetData<bool>("hrobber"))
        {
            Vector3[] points = {
                new Vector3(351.29, -999.21, -99.20),
                new Vector3(350.74, -993.70, -99.20),
                new Vector3(345, -995.44, -99.20),
                new Vector3(338.11, -995.02, -99.20),
                new Vector3(339.30, -1003.21, -99.20),
                new Vector3(351.14, -993.54, -99.19),
            };

            for (int i = 0; i < points.Length; i++)
            {
                if (Main.IsInRangeOfPoint(client.Position, points[i], 2.0f) && !client.GetData<bool>($"houserobp{i + 1}"))
                {
                    client.SetData($"houserobp{i + 1}", true);
                    if (Inventory.Check_InventoryWeight_With_ItemAmount(client, 78, 3, Inventory.Max_Inventory_Weight(client)))
                    {
                        return;
                    }
                    NAPI.Player.PlayPlayerAnimation(client, 1, "anim@heists@money_grab@duffel", "loop");
                    Random rnd = new Random();
                    int xitem = rnd.Next(1, 3);
                    NAPI.Task.Run(() =>
                    {
                        if (NAPI.Player.IsPlayerConnected(client))
                        {
                            client.StopAnimation();
                            Inventory.GiveItemToInventory(client, 78, xitem);
                        }
                    }, delayTime: 5000);

                    if (i == 5)
                    {
                        if (Inventory.GetPlayerItemFromInventory(client, 28) > 0)
                        {
                            Random ksd = new Random();
                            int randomksd = ksd.Next(1, 6);
                            if (randomksd == 2)
                            {
                                Inventory.RemoveItemFromInventory(client, 28, 1);
                                Main.DisplayErrorMessage(client, NotifyType.Info, NotifyPosition.BottomCenter, "Kalauz je pukao i deo je ostao u bravi...");
                                return;
                            }
                            NAPI.Task.Run(() =>
                            {
                                if (NAPI.Player.IsPlayerConnected(client))
                                {
                                    client.StopAnimation();
                                    Inventory.GiveItemToInventory(client, 64, 1);
                                }
                            }, delayTime: 5000);
                        }
                        else
                        {
                            Main.DisplayErrorMessage(client, NotifyType.Info, NotifyPosition.BottomCenter, "Nemate Kalauz");
                            return;
                        }
                    }
                    break;
                }
            }
        }
    }

}