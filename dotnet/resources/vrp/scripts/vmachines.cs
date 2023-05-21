using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System.Threading;


    class VShops : Script
    {
        public static List<Vector3> sprunkmasine = new List<Vector3>
        {
            //sprunk
            new Vector3(822.28, -2149.81, 29.62),
            new Vector3(2560.66, 379.65, 108.62),
            new Vector3(2753.36, 3478.39, 55.67),
            new Vector3(913.32, 3643.77, 32.66),
            new Vector3(549.27, 2674.8, 42.20),
            new Vector3(1193.22, -2701.72, 38.16),
            new Vector3(1699.61, 4791.38, 41.92),
            new Vector3(1587.63, 6449.8, 25.32),
            new Vector3(1486.87, 1134.89, 114.33),
            new Vector3(1084.94, -775.7, 58.23),
            new Vector3(644.27, 265.74, 103.22),
            new Vector3(284.45, 80.8, 94.36),
            new Vector3(282.74, 66.0, 94.37),
            new Vector3(438.94, -602.58, 28.71),
            new Vector3(451.86, -633.23, 28.53),
            new Vector3(449.85, -656.47, 28.43),
            new Vector3(171.38, -1724.55, 29.32),
            new Vector3(-341.61, -1481.16, 30.68),
            new Vector3(8.08, -1110.07, 29.8),
            new Vector3(-333.29, -783.52, 33.96),
            new Vector3(-692.17, -730.64, 29.35),
            new Vector3(-692.29, -730.62, 33.68),
            new Vector3(-708.34, -909.97, 19.22),
            new Vector3(-1655.78, -1097.21, 13.13),
            new Vector3(-1695.84, -1127.19, 13.15),
            new Vector3(-1711.11, -1133.33, 13.13),
            new Vector3(-1475.27, -671.98, 29.04),
            new Vector3(-2549.41, 2316.6, 33.22),
            new Vector3(-1269.97, -1427.1, 4.35),
            new Vector3(-1231.44, -1448.38, 4.27),
            new Vector3(-269.81, -2022.76, 30.15),
            new Vector3(-692.28, -749.71, 25.05),
            new Vector3(-694.39, -763.44, 33.68),
            new Vector3(-1546.39, -442.68, 35.88),
            new Vector3(-2282.70, 362.59, 174.60),
            new Vector3(309.85, -585.616, 43.28),
            new Vector3(324.85, -599.143, 43.28),
            new Vector3(353.24, -580.486, 43.28),


            //ecola
        };
        public static List<Vector3> ecolamasine = new List<Vector3>
        {

            new Vector3(821.91,	-2988.64, 6.02),
			new Vector3(809.82,	-2150.0, 29.62),
			new Vector3(2560.57, 380.13, 108.62),
			new Vector3(2558.81, 2601.82, 38.09),
			new Vector3(2344.35, 3127.13, 48.21),
			new Vector3(1702.89, 4923.42, 42.06),
			new Vector3(1485.8,	1134.97, 114.33),
			new Vector3(1160.96, -319.77, 69.21),
			new Vector3(286.14,	195.21, 104.37),
			new Vector3(309.33,	186.95, 103.9),
			new Vector3(285.59,	80.36, 94.36),
			new Vector3(281.68,	66.38, 94.37),
			new Vector3(-59.84,	-1749.34, 29.32),
			new Vector3(-46.78,	-1753.18, 29.42),
			new Vector3(19.83, -1114.28, 29.8),
			new Vector3(-325.56, -738.59, 33.96),
			new Vector3(-310.1,	-739.47, 33.96),
			new Vector3(-334.82, -785.04, 38.78),
			new Vector3(-325.51, -738.58, 43.6),
			new Vector3(-334.9,	-784.87, 48.42),
			new Vector3(-694.37, -793.32, 33.68),
			new Vector3(-709.31, -910.05, 19.22),
			new Vector3(-1654.96, -1096.42, 13.12),
			new Vector3(-1695.27, -1126.33, 13.15),
			new Vector3(-1710.02, -1133.83, 13.14),
			new Vector3(-1692.37, -1087.75, 13.15),
			new Vector3(-1063.66, -244.41, 39.73),
			new Vector3(-1824.94, 794.77, 138.16),
			new Vector3(-2550.63, 2316.61, 33.22),
			new Vector3(-1269.34, -1427.98, 4.35),
			new Vector3(-1251.39, -1450.37, 4.35),
			new Vector3(-1230.58, -1447.75, 4.27),
			new Vector3(-1170.79, -1574.44, 4.66),
			new Vector3(-1148.0, -1601.07, 4.39),
			new Vector3(-1140.06, -1623.16, 4.41),
			new Vector3(-1123.07, -1643.82, 4.66),
			new Vector3(-246.52, -2002.96, 30.15),
			new Vector3(-275.87, -2041.86, 30.15),
            new Vector3(-1547.24, -441.96, 35.88),
            new Vector3(-2283.16, 363.62, 174.60),
            new Vector3(308.65, -585.199, 43.28),
            new Vector3(324.67, -597.986, 43.28),
            new Vector3(353.24, -579.416, 43.28),
            new Vector3(461.03, -705.497, 27.38),
            new Vector3(446.83, -981.05, 30.68),
            new Vector3(470.75, -993.32, 30.68),
            new Vector3(471.47, -996.21, 34.21),
            new Vector3(476.01, -1003.08, 25.72),

        };

        public static List<Vector3> ecafa = new List<Vector3>
        {

            new Vector3(439.37,	-978.77, 30.68),
            new Vector3(814.05, -2974.24, 6.02),
            new Vector3(315.0514, -587.334, 43.28),
            new Vector3(323.8214, -601.869, 43.28),
            new Vector3(322.2214, -579.301, 43.28),
            new Vector3(333.1914, -583.344, 43.28),
            new Vector3(352.5914, -581.354, 43.28),
            new Vector3(2552.1814, 380.987, 108.62),
            new Vector3(1957.6814, 3744.187, 32.34),
            new Vector3(437.29, -987.57, 30.68),
            new Vector3(444.66, -997.58, 30.68),
            new Vector3(446.54, -979.26, 30.68),
            new Vector3(468.96, -990.80, 30.68),
            new Vector3(474.51, -984.97, 34.21),
            new Vector3(444.27, -988.44, 34.21),

        };
        public static List<Vector3> evoda = new List<Vector3>
        {

            new Vector3(-1548.15, -441.38, 35.88),
            new Vector3(-1694.90, -1125.13, 13.15),
            new Vector3(-1708.77, -1134.28, 13.14),
            new Vector3(814.10, -2973.20, 6.02),
            new Vector3(-2280.98, 358.85, 174.60),
            new Vector3(-1694.96, -1125.126, 13.15),
            new Vector3(-1694.96, -1125.126, 13.15),
            new Vector3(2005.33, 3789.781, 32.18),
            new Vector3(2005.33, 3789.781, 32.18),

			
        };

        

        public static void keypressE(Player player)
        {
            
                Vector3 smas = sprunkmasine[0];
                foreach (var v in sprunkmasine)
                {

                    if (player.Position.DistanceTo(v) < 1)
                    {
                        if (Main.GetPlayerMoney(player) < 50)
                        {
                            player.SendNotification("Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 61, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }
                        if (player.GetData<dynamic>("kupujecolu") == true)
                        {
                            return;
                        } 
                        player.SetData<dynamic>("kupujecolu", true);
                        NAPI.Player.PlayPlayerAnimation(player, 1, "mini@sprunk", "plyr_buy_drink_pt1");
                        Main.GivePlayerMoney(player, -50);
                        Main.GiveCompanyMoney(6, 10);
                        Main.PlaySoundClientSide(player, "Dropped", 0.2f);
                        NAPI.Task.Run(() =>
                        {
                            if (NAPI.Player.IsPlayerConnected(player))
                            {
                            NAPI.Player.StopPlayerAnimation(player);
                            Inventory.GiveItemToInventory(player, 61);
                            player.SendNotification("Kupili ste ~g~spunk ~w~za $35");
                            player.SetData<dynamic>("kupujecolu", false);
                            }
                        }, delayTime: 5000);
                        
                    }

                }
                Vector3 najblizipc = ecolamasine[0];
                foreach (var v in ecolamasine)
                {
                    if (player.Position.DistanceTo(v) < 1)
                    {
                        if (Main.GetPlayerMoney(player) < 50)
                        {
                            player.SendNotification("Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 62, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }
                        if (player.GetData<dynamic>("kupujecolu") == true)
                        {
                            return;
                        } 
                        player.SetData<dynamic>("kupujecolu", true);
                        NAPI.Player.PlayPlayerAnimation(player, 1, "mini@sprunk", "plyr_buy_drink_pt1");
                        Main.GivePlayerMoney(player, -50);
                        Main.GiveCompanyMoney(6, 10);
                        Main.PlaySoundClientSide(player, "Dropped", 0.2f);
                        NAPI.Task.Run(() =>
                        {
                            if (NAPI.Player.IsPlayerConnected(player))
                            {
                            NAPI.Player.StopPlayerAnimation(player);
                            Inventory.GiveItemToInventory(player, 62);
                            player.SendNotification("Kupili ste ~r~ecolu ~w~za $35");
                            player.SetData<dynamic>("kupujecolu", false);
                            }
                        }, delayTime: 5000);
                    }

                }
                Vector3 ekafablizina = ecafa[0];
                foreach (var v in ecafa)
                {
                    if (player.Position.DistanceTo(v) < 1)
                    {
                        if (Main.GetPlayerMoney(player) < 50)
                        {
                            player.SendNotification("Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 63, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }
                        if (player.GetData<dynamic>("kupujecolu") == true)
                        {
                            return;
                        } 
                        player.SetData<dynamic>("kupujecolu", true);
                        NAPI.Player.PlayPlayerAnimation(player, 1, "mini@sprunk", "plyr_buy_drink_pt1");
                        Main.PlaySoundClientSide(player, "Dropped", 0.2f);
                        Main.GivePlayerMoney(player, -50);
                        Main.GiveCompanyMoney(6, 10);
                        NAPI.Task.Run(() =>
                        {
                            if (NAPI.Player.IsPlayerConnected(player))
                            {
                            NAPI.Player.StopPlayerAnimation(player);
                            Inventory.GiveItemToInventory(player, 63, 1);
                            player.SendNotification("Kupili ste ~o~Coffee ToGo ~w~za $10");
                            player.SetData<dynamic>("kupujecolu", false);
                            }
                        }, delayTime: 5000);
                        
                    }

                }
                Vector3 evodas = evoda[0];
                foreach (var v in evoda)
                {
                    if (player.Position.DistanceTo(v) < 1)
                    {
                        if (Main.GetPlayerMoney(player) < 50)
                        {
                            player.SendNotification("Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 63, 1, Inventory.Max_Inventory_Weight(player)))
                        {
                            return;
                        }
                        if (player.GetData<dynamic>("kupujecolu") == true)
                        {
                            return;
                        } 
                        player.SetData<dynamic>("kupujecolu", true);
                        NAPI.Player.PlayPlayerAnimation(player, 1, "mini@sprunk", "plyr_buy_drink_pt1");
                        Main.PlaySoundClientSide(player, "Dropped", 0.2f);
                        Main.GivePlayerMoney(player, -50);
                        Main.GiveCompanyMoney(6, 10);
                        NAPI.Task.Run(() =>
                        {
                            if (NAPI.Player.IsPlayerConnected(player))
                            {
                            NAPI.Player.StopPlayerAnimation(player);
                            Inventory.GiveItemToInventory(player, 1, 1);
                            player.SendNotification("Kupili ste ~b~Raine ~w~za $35");
                            player.SetData<dynamic>("kupujecolu", false);
                            }
                        }, delayTime: 5000);
                        
                    }

                }
        }

    }
