using GTANetworkAPI;
using System;
using System.Collections.Generic;
//autoskolaa
public class autoskola : Script
{

    private static List<Vector3> Checkpoints = new List<Vector3>()
        {
            new Vector3(-610.79865, -2271.0083, 5.9482813),
            new Vector3(-506.638, -2149.9526, 8.982431),
            new Vector3(-278.1685, -2188.5344, 10.309659),
            new Vector3(7.103925, -2081.7866, 10.261352),
            new Vector3(-240.62085, -1844.7511, 29.12345),
            new Vector3(-359.2044, -1820.4208, 22.795097),
            new Vector3(-781.7449, -2199.168, 16.45727),
            new Vector3(-1078.8828, -2622.8972, 13.817429),
            new Vector3(-846.8897, -2584.8281, 13.815342),
            new Vector3(-613.73425, -2280.5994, 5.936411),


        };

    [RemoteEvent("askola")]
    public void askola(Player Client, int index)
    {
        try
        {
            switch (index)
            {
                case 0:
                    {
                        Client.TriggerEvent("Hide_Crafting_System");
                        NAPI.Task.Run(() =>
                        {
                            if (NAPI.Player.IsPlayerConnected(Client))
                            {
                            Client.TriggerEvent("as2");
                            }

                        }, 300);
                        
                        break;
                    }
                case 1:
                    {
                        
                        Client.TriggerEvent("Hide_Crafting_System");
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pali ste test");
                        break;
                    }
                case 2:
                    {

                        Client.TriggerEvent("Hide_Crafting_System");
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pali ste test");

                        
                        break;
                    }
                case 3:
                    {

                        Client.TriggerEvent("Hide_Crafting_System");
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pali ste test");

                        
                        break;
                    }
                case 4:
                    {
                        Client.TriggerEvent("Hide_Crafting_System");
                        NAPI.Task.Run(() =>
                        {
                            if (NAPI.Player.IsPlayerConnected(Client))
                            {
                            Client.TriggerEvent("as3");
                            }
                        }, 300);
                        
                        break;
                    }
                case 5:
                    {

                        Client.TriggerEvent("Hide_Crafting_System");
                        NAPI.Task.Run(() =>
                        {
                            if (NAPI.Player.IsPlayerConnected(Client))
                            {
                            Client.TriggerEvent("as4");
                            }
                        }, 300);
                        break;
                    }
                case 6:
                    {
                        Client.TriggerEvent("Hide_Crafting_System");
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pali ste test");
                        
                        break;
                    }
                case 7:
                    {
                        Client.TriggerEvent("Hide_Crafting_System");
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pali ste test");
                        
                        break;
                    }
                case 8:
                    {
                        Client.TriggerEvent("Hide_Crafting_System");
                        NAPI.Task.Run(() =>
                        {
                            if (NAPI.Player.IsPlayerConnected(Client))
                            {
                            Client.TriggerEvent("as5");
                            }
                        }, 300);
                        
                        break;
                    }
                case 9:
                    {

                        Client.TriggerEvent("Hide_Crafting_System");
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pali ste test");
                        break;
                    }
                case 10:
                    {

                        Client.TriggerEvent("Hide_Crafting_System");
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pali ste test");
                        break;
                    }
                case 11:
                    {
                        Client.TriggerEvent("Hide_Crafting_System");
                        NAPI.Task.Run(() =>
                        {
                            if (NAPI.Player.IsPlayerConnected(Client))
                            {
                            Client.TriggerEvent("as6");
                            Client.SetData<dynamic>("school_tutorial", true);
                            Client.SetData<dynamic>("drivingtest", true);
                            }

                        }, 300);
                        
                        break;
                    }
                case 12:
                    {

                        
                        break;
                    }
                case 13:
                    {
                        Client.TriggerEvent("Hide_Crafting_System");
                        getpracticeexam(Client);
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Pratite waypoint na minimapi");
                        break;
                    }
                case 14:
                    {

                        
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void getpracticeexam(Player c)
    {
        if (c.GetData<dynamic>("school_tutorial") == true )
        {
            var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(132.24, -1462.01, 28.35), 1, 2, 0);
            col.OnEntityEnterColShape += (shape, c) => {
                try
                {
                    c.SetData("INTERACTIONCHECK", 8);
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            };
            col.OnEntityExitColShape += (shape, c) => {
                try
                {
                    c.SetData("INTERACTIONCHECK", 0);
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            };

            string playername = AccountManage.GetCharacterName(c);
            string vehName = "premier";
            VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
            Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(-628.31, -2270.97, 5.95), new Vector3(0, 0, -140), 27, 111, "as"+playername, 255, false, true, 0);
            Main.SetVehicleFuel(vehicle, 100.0);
            for (int i = 0; i < Checkpoints.Count; i++)
            {
                var colshape = NAPI.ColShape.CreateCylinderColShape(Checkpoints[i], 4, 5, 0);
                colshape.OnEntityEnterColShape += PlayerEnterCheckpoint;
                colshape.SetData("LMNUMBER", i);
            }
            c.TriggerEvent("createCheckpoint", 12, 1, Checkpoints[0]  - new Vector3(0, 0, 2), 4, 0, 221, 255, 0);
            c.TriggerEvent("createWaypoint", Checkpoints[0].X, Checkpoints[0].Y);
            c.SetData("lmpoint", 0);
            
        }
    }


    private static void PlayerEnterCheckpoint(ColShape shape, Player c)
        {
            try
            {

                if (shape.GetData<int>("LMNUMBER") != c.GetData<int>("lmpoint")) return;
                    var lmpoint = c.GetData<int>("lmpoint");
                    if (lmpoint == Checkpoints.Count - 1)
                    {
                        Vehicle veh = c.Vehicle;
                        string playername = AccountManage.GetCharacterName(c);
                        if (c.IsInVehicle && veh.NumberPlate == "as"+playername)
                        {
                            NAPI.Entity.DeleteEntity(c.Vehicle);
                            c.TriggerEvent("deleteCheckpoint", 12, 0);
                            c.SetData<dynamic>("character_car_lic", 720);
                            Main.SendMessageWithTagToPlayer(c, "" + Main.EMBED_WHITE + "[Auto-skola]", "Dobili ste vozacku dozvolu!");
                            Main.SavePlayerInformation(c);
                            Main.GivePlayerMoney(c, -2000);
                            return;
                        }
                        else{
                            return;
                        }
                        
                    }
                    c.SetData("lmpoint", lmpoint + 1);
                     

                        if (lmpoint + 2 < Checkpoints.Count)
                            c.TriggerEvent("createCheckpoint", 12, 1, Checkpoints[lmpoint + 1] - new Vector3(0, 0, 2), 4, 0, 255, 255, 255, Checkpoints[lmpoint + 2] - new Vector3(0, 0, 1.12));
                        else
                            c.TriggerEvent("createCheckpoint", 12, 1, Checkpoints[lmpoint + 1] - new Vector3(0, 0, 2), 4, 0, 221, 255, 0);
                        c.TriggerEvent("createWaypoint", Checkpoints[lmpoint + 1].X, Checkpoints[lmpoint + 1].Y);

            } catch (Exception e) { Console.WriteLine(e); }
        }

    [ServerEvent(Event.PlayerDisconnected)]
    public static void onPlayerDissconnectedHandler(Player player, DisconnectionType type, string reason)
    {
        try
        {
            string playername = AccountManage.GetCharacterName(player);
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "as"+playername)
                {
                    veh.Delete();
                }
            }
        }
        catch (Exception e) { Console.Write(e);}
    }
    
}