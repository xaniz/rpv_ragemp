using GTANetworkAPI;
using System;
using System.Collections.Generic;
public class pizza : Script
{
    public  pizza()
    {
    NAPI.TextLabel.CreateTextLabel("Dostavljac Hrane~n~~w~[~y~ Y ~w~]", new Vector3(132.24, -1462.01, 29.35), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
    NAPI.Marker.CreateMarker(1, new Vector3(132.24, -1462.01, 28.35), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

    Entity temp_blip;
    temp_blip = NAPI.Blip.CreateBlip(new Vector3(132.24, -1462.01, 29.35));
    NAPI.Blip.SetBlipName(temp_blip, "*Dostavljac Hrane");
    NAPI.Blip.SetBlipSprite(temp_blip, 616);
    NAPI.Blip.SetBlipColor(temp_blip, 65);
    NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
    NAPI.Blip.SetBlipShortRange(temp_blip, true);
    }

    internal class Checkpoint
    {
        public Vector3 Position { get; }
        public double Heading { get; }

        public Checkpoint(Vector3 pos)
        {
            Position = pos;
        }
    }


    [ServerEvent(Event.PlayerDisconnected)]
    public static void onPlayerDissconnectedHandler(Player player, DisconnectionType type, string reason)
    {
        try
        {
            string playername = AccountManage.GetCharacterName(player);
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "pj"+playername)
                {
                    veh.Delete();
                }
            }
        }
        catch (Exception e) {Console.Write(e); }
    }

    public static void respawndeliverycar(Player client)
    {
        try
        {
            string playername = AccountManage.GetCharacterName(client);
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "pj"+playername)
                {
                    veh.Delete();
                }
            }

        }
        catch (Exception e) { Console.Write(e);}
    }

    
    private static List<Checkpoint> Checkpoints = new List<Checkpoint>()
        {
            new Checkpoint(new Vector3(-842.3179, -25.065311, 39.397427)),
            new Checkpoint(new Vector3(-1004.1011, -1090.0264, 1.1503093)),
            new Checkpoint(new Vector3(-1793.6423, -663.7421, 9.60474)),
            new Checkpoint(new Vector3(-1084.5138, -1559.4264, 3.7685094)),
            new Checkpoint(new Vector3(192.08273, -1883.167, 24.05636)),
            new Checkpoint(new Vector3(1229.6295, -725.72614, 59.95671)),
            new Checkpoint(new Vector3(1328.4445, -536.32996, 71.44085)),
            new Checkpoint(new Vector3(149.34422, 474.51785, 141.51071)),
            new Checkpoint(new Vector3(46.14334, 555.9613, 179.0822)),
            new Checkpoint(new Vector3(-230.51572, 487.89, 127.76721)),
            new Checkpoint(new Vector3(-476.62546, 647.5501, 143.38684)),
            new Checkpoint(new Vector3(-699.5271, 705.8505, 157.20361)),
            new Checkpoint(new Vector3(-747.2907, 808.2661, 214.0303)),
            new Checkpoint(new Vector3(-1118.0813, 761.3337, 163.28873)),
            new Checkpoint(new Vector3(-1453.9673, 512.29987, 116.79627)),
            new Checkpoint(new Vector3(-1805.0482, 436.42996, 127.8347)),
            new Checkpoint(new Vector3(-2014.8921, 499.78366, 106.171684)),
            new Checkpoint(new Vector3(-1899.2449, 132.5881, 80.98464)),
            new Checkpoint(new Vector3(-1522.447, 143.40385, 54.652683)),
            new Checkpoint(new Vector3(-1203.9982, -943.0012, 7.114808)),
            new Checkpoint(new Vector3(-109.6217, 501.8395, 142.47758)),
            new Checkpoint(new Vector3(-1590.639, -413.1363, 42.0693)),
            new Checkpoint(new Vector3(-1335.5632, -1146.9343, 5.731418)),
        };

    [RemoteEvent("pizzajobs")]
    public static void pizzajobs(Player Client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        zapocetiposao(Client);
                        break;
                    }
                case 1:
                    {
                        zavrsiposao(Client);
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static void zapocetiposao(Player client)
    {
        
        if (client.GetData<dynamic>("pizzajob") == true)
        {
            Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec ste zapoceli posao, morate ga zavrsiti!");
            return;
        }
        var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(132.24, -1462.01, 28.35), 1, 2, 0);
        col.OnEntityEnterColShape += (shape, player) => {
            try
            {
                player.SetData("INTERACTIONCHECK", 8);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        };
        col.OnEntityExitColShape += (shape, player) => {
            try
            {
                player.SetData("INTERACTIONCHECK", 0);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        };
        int i = 0;
        foreach (var Check in Checkpoints)
        {
            col = NAPI.ColShape.CreateCylinderColShape(Check.Position, 1, 2, 0);
            col.SetData("NUMBER", i);
            col.OnEntityEnterColShape += PlayerEnterCheckpoint;
            i++;
        }
        string playername = AccountManage.GetCharacterName(client);
    
        Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Zapoceli ste posao!");
        string vehName = "faggio";
        VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
        Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(124.55, -1472.20, 29.20), new Vector3(0, 0, -40), 27, 111, "pj"+playername, 255, false, true, 0);
        Main.SetVehicleFuel(vehicle, 100.0);
        client.SetData("pizzajob", true);
        Random rnd = new Random();
        var check = rnd.Next(0, Checkpoints.Count - 1);
        client.SetData("WORKCHECK", check);
        Trigger.ClientEvent(client, "createCheckpoint", 15, 1, Checkpoints[check].Position, 1, 0, 221, 255, 0);
        Trigger.ClientEvent(client, "createWorkBlip", Checkpoints[check].Position);

    }

    public static void zavrsiposao(Player client)
    {
        
        if (client.HasData("pizzajob"))
        {
            string playername = AccountManage.GetCharacterName(client);
            Main.DisplayErrorMessage(client, NotifyType.Info, NotifyPosition.BottomCenter, "Zavrsili ste posao!");
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "pj"+playername)
                {
                    veh.Delete();
                    client.ResetData("pizzajob");
                    Trigger.ClientEvent(client, "deleteCheckpoint", 15);
                    Trigger.ClientEvent(client, "deleteWorkBlip");
                }
            }
        }
        
    }

    public static void PressKeyE(Player client)
    {
        if (!client.IsInVehicle) return;
        string playername = AccountManage.GetCharacterName(client);
        Vehicle veh = client.Vehicle;
        if(client.GetData<dynamic>("uzeopicu") == true){
            return;
        }
        if(veh.NumberPlate == "pj"+playername)
        {
            client.SetData("uzeopicu", true);
            client.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+ ~y~Hrana");
        }
        else
        {
            Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Ovo nije vozilo dostavljaca hrane!");
        }
    }

    private static void PlayerEnterCheckpoint(ColShape shape, Player player)
        {
            try
            {
                if (shape.GetData<int>("NUMBER") != player.GetData<int>("WORKCHECK")) return;

                if (Checkpoints[(int)shape.GetData<int>("NUMBER")].Position.DistanceTo(player.Position) > 3) return;
                if (player.IsInVehicle)
                {
                    return;
                }
                if (player.GetData<dynamic>("uzeopicu") == true)
                {
                    Jobmanager.addskill(player);
                    player.SetData("WORKCHECK", -1);
                    player.SetData("uzeopicu", false);
                    NAPI.Task.Run(() => {
                        try
                        {   
                            if (NAPI.Player.IsPlayerConnected(player))
                            {
                                if(player.GetData<dynamic>("jobskill") >= 149)
                                {
                                    Main.GivePlayerSalary(player, 104);
                                }
                                Main.GivePlayerSalary(player, 523);
                                player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+ ~y~skill");
                                Random rnd2 = new Random();
                                var nextCheck = rnd2.Next(0, Checkpoints.Count - 1);
                                while (nextCheck == shape.GetData<int>("NUMBER")) nextCheck = rnd2.Next(0, Checkpoints.Count - 1);
                                player.SetData("WORKCHECK", nextCheck);
                                Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints[nextCheck].Position, 1, 0, 221, 255, 0);
                                Trigger.ClientEvent(player, "createWorkBlip", Checkpoints[nextCheck].Position);
                            }
                        }
                        catch { }
                    }, 4000);
                }
                else {
                    Main.DisplayErrorMessage(player, NotifyType.Info, NotifyPosition.BottomCenter, "Sedite na motor i uzmite hranu [E]");
                }
                

                

            } catch (Exception e) { Console.WriteLine(e); }
        }
    
}