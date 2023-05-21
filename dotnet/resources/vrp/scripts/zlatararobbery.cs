using System;
using System.Collections.Generic;
using GTANetworkAPI;


    class jeweleryrobbery : Script
    {
        public enum AnimationFlags
        {
            Loop = 1 << 0,
            StopOnLastFrame = 1 << 1,
            OnlyAnimateUpperBody = 1 << 4,
            AllowPlayerControl = 1 << 5,
            Cancellable = 1 << 7
        }

        public static int SETTINGS_COPS_NEEDED = 0;
        public static bool PLJACKA_POKRENUTA = false;
        public static int VZRS = 1;

        public static List<Vector3> Blps = new List<Vector3>()
        {
            new Vector3(-629.852, -236.4616, 38.057)
        };

        [ServerEvent(Event.ResourceStart)]
        public static void jrResursStart()
        {

            NAPI.TextLabel.CreateTextLabel("~y~Y ~w~ da zapocnete", new Vector3(-629.852, -236.4616, 38.057), 5.0f, 0.5f, 4, new Color(221, 255, 0, 255));
      

            foreach (var pos in Blps)
            {
                Entity temp_blip;
                temp_blip = NAPI.Blip.CreateBlip(pos);
                NAPI.Blip.SetBlipName(temp_blip, "Zlatara");
                NAPI.Blip.SetBlipSprite(temp_blip, 439);
                NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
                NAPI.Blip.SetBlipShortRange(temp_blip, true);
                NAPI.Blip.SetBlipColor(temp_blip, 5);
            }

        }

        public static void KeyPressY(Player player)
        {
            if (player.Position.DistanceTo2D(new Vector3(-629.852, -236.4616, 38.057)) < 2)
            {
                if(FactionManage.GetPlayerGroupType(player) != 5)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Warning, NotifyPosition.BottomCenter, "Samo mafije mogu pljackati zlataru");
                    return;
                }
                if (DateTime.Now.Hour < 13 || DateTime.Now.Hour > 22)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Warning, NotifyPosition.BottomCenter, "Zlataru je moguce pljackati samo u intervalu od 13 do 22 casa");
                    return;
                }
                int cops_online = 0;
                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if (FactionManage.GetPlayerGroupID(target) == 1 && target.GetData<dynamic>("duty") == 1)
                    {
                        cops_online++;
                    }
                }
                if (PLJACKA_POKRENUTA == true)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Warning, NotifyPosition.BottomCenter, "Zlatara je vec opljackana");
                    return;
                }

                if (cops_online < SETTINGS_COPS_NEEDED)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Warning, NotifyPosition.BottomCenter, "Potrebno je najmanje 8 policajaca da bi pljacka bila zapoceta");
                    return;
                }
                PLJACKA_POKRENUTA = true;
                player.SetData("pljackas2", true);
                Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zapoceli ste pljacku!");
                Police.SetPlayerCrime(player, 8);
                if (Job_Controler.GetPlayerJob(player) == 4 && player.GetData<dynamic>("jobskill") >= 149)
                {
                    NAPI.Task.Run(() =>
                    {
                        foreach (var target in NAPI.Pools.GetAllPlayers())
                        {
                            if (target.GetData<dynamic>("status") == true && AccountManage.GetPlayerGroup(target) == 1)
                            {
                                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "U toku je pljacka ZLATARE !");
                                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "U toku je pljacka ZLATARE !");
                                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "U toku je pljacka ZLATARE !");
                            }
                        }
                    }, delayTime: 15000);
                    
                }
                else 
                {
                    foreach (var target in NAPI.Pools.GetAllPlayers())
                    {
                        if (target.GetData<dynamic>("status") == true && AccountManage.GetPlayerGroup(target) == 1)
                        {
                            Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "U toku je pljacka ZLATARE !");
                            Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "U toku je pljacka ZLATARE !");
                            Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "U toku je pljacka ZLATARE !");
                        }
                    }
                }
            }


        }

        [RemoteEvent("zlataraobijanje")]
        public static void tackajedan(Player player)
        {
        if (player.HasData("pljackas2"))
        {
            Vector3[] positions = {
            new Vector3(-627.96967, -233.9292, 38.057053),
            new Vector3(-626.70355, -232.88509, 38.057053),
            new Vector3(-625.6678, -234.48392, 38.057053),
            new Vector3(-626.93494, -235.48169, 38.057053),
            new Vector3(-626.87946, -238.61194, 38.057053),
            new Vector3(-625.4509, -237.68596, 38.057053),
            new Vector3(-623.0479, -233.10973, 38.057053),
            new Vector3(-624.6622, -230.88536, 38.057053),
            new Vector3(-625.1664, -228.07988, 38.057053),
            new Vector3(-623.61707, -226.96078, 38.057053),
            new Vector3(-623.9559, -228.04425, 38.057053),
            new Vector3(-621.19867, -228.24716, 38.057053),
            new Vector3(-619.52045, -230.5488, 38.057053),
            new Vector3(-620.23157, -233.50253, 38.057053),
            new Vector3(-619.10693, -233.54024, 38.057053),
            new Vector3(-620.512, -234.5686, 38.057053),
            new Vector3(-617.4284, -230.79973, 38.057026),
            new Vector3(-618.4398, -229.28003, 38.057026),
            new Vector3(-619.63727, -227.69443, 38.05698),
            new Vector3(-620.60767, -226.31519, 38.05698),
            new Vector3(-616.3996, -234.96143, 38.057056),
            new Vector3(-616.5265, -236.24924, 38.057056),
            new Vector3(-617.31744, -237.30936, 38.057056),
            new Vector3(-618.5803, -237.73257, 38.057056),
            new Vector3(-619.8942, -237.32695, 38.057056),
            new Vector3(-627.63104, -226.70767, 38.057056),
            new Vector3(-627.6048, -225.3238, 38.057056),
            new Vector3(-626.7744, -224.24104, 38.057056),
            new Vector3(-625.5361, -223.77556, 38.057056),
            new Vector3(-624.36865, -224.16116, 38.057056),
            };
            for (int i = 0; i < positions.Length; i++)
            {
                if (player.Position.DistanceTo2D(positions[i]) < 0.5)
                {
                    string dataKey = $"tackajedan{i+1}";
                    if (player.HasData(dataKey))
                    {
                        player.SendNotification("Vec razvaljeno!");
                        return;
                    }
                    player.SetData(dataKey, true);
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "missheist_jewel", "smash_case");
                    Trigger.ClientEvent(player, "PucanjeStakla");
                    NAPI.Task.Run(() =>
                    {
                        if (NAPI.Player.IsPlayerConnected(player))
                        {
                        player.StopAnimation();
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 78, 3, Inventory.Max_Inventory_Weight(player)))
                        {
                            Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate mesta u inventary");
                            return;
                        }
                        Inventory.GiveItemToInventory(player, 78, 3);
                        player.SendNotification($"+ Nakit");
                        }
                    }, delayTime: VZRS * 4600);
                }
            }
        }
    }
}