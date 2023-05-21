using GTANetworkAPI;
using System;
using System.Collections.Generic;
//autoskolaa
public class avioskola : Script
{

    private static List<Vector3> Checkpoints = new List<Vector3>()
    {
        new Vector3(-786.60, -2364.06, 14.57),
        new Vector3(-1176.61, -2379.69, 13.92),
        new Vector3(-590.49, -2328.97, 13.82),
    };

    [RemoteEvent("avskola")]
    public void avskola(Player Client, int index)
    {
        try
        {
            switch (index)
            {
                case 0:
                    {
                        Client.TriggerEvent("Hide_Crafting_System");
                        getpracticeexam(Client);
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Pratite waypoint na minimapi");
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
            string vehName = "maverick";
            VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
            Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(-623.42, -2331.28, 13.82), new Vector3(0, 0, 51), 27, 111, "as"+playername, 255, false, true, 0);
            Main.SetVehicleFuel(vehicle, 100.0);
            c.SetIntoVehicle(vehicle, 0);
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
                        c.SetData<dynamic>("character_fly_lic", 720);
                        Main.SendMessageWithTagToPlayer(c, "" + Main.EMBED_WHITE + "[Auto-skola]", "Dobili ste dozvolu za let!");
                        Main.SavePlayerInformation(c);
                        Main.GivePlayerMoney(c, -5000);
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