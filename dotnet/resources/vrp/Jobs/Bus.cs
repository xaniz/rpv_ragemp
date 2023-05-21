using GTANetworkAPI;
using System;
using System.Collections.Generic;
public class BusDriver : Script
{
    public BusDriver()
    {
    NAPI.Blip.CreateBlip(513, new Vector3(452.50, -622.09, 28.55), 0.7f, 30, "*Bus Vozac", 255, 0, true, 0, 0);
    NAPI.TextLabel.CreateTextLabel("*Bus Vozac~n~~w~[~g~ Y ~w~]", new Vector3(452.50, -622.09, 28.55), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
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
                if (!string.IsNullOrEmpty(playername) && veh.Exists && veh.NumberPlate == "LT" + playername )
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
                if (veh.NumberPlate == "LT"+playername)
                {
                    veh.Delete();
                }
            }

        }
        catch (Exception e) { Console.Write(e);}
    }

    
    private static List<Checkpoint> Checkpoints = new List<Checkpoint>()
        {
            new Checkpoint(new Vector3(307.10736, -765.8731, 28.225773)),
            new Checkpoint(new Vector3(-108.38894, -1687.7843, 28.219982)),
            new Checkpoint(new Vector3(-1031.51, -2724.0205, 12.688876)),
            new Checkpoint(new Vector3(276.56702, -1553.3938, 28.052517)),
            new Checkpoint(new Vector3(461.15927, -651.0653, 27.052435)),
        };

    [RemoteEvent("busjobs")]
    public static void busjobs(Player Client, int index)
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
        if (client.GetData<dynamic>("busjob") == true)
        {
            Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec ste zapoceli posao, morate ga zavrsiti!");
            return;
        }
        var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(452.50, -622.09, 28.55), 1, 2, 0);
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
            col = NAPI.ColShape.CreateCylinderColShape(Check.Position, 4, 2, 0);
            col.SetData("NUMBER", i);
            col.OnEntityEnterColShape += PlayerEnterCheckpoint;
            i++;
        }
        string playername = AccountManage.GetCharacterName(client);

        Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Zapoceli ste posao!");
        string vehName = "bus";
        VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
        Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(466.71, -616.07, 28.49), new Vector3(0, 0, -9), 55, 111, "LT"+playername, 255, false, true, 0);
        Main.SetVehicleFuel(vehicle, 100.0);
        client.SetData("busjob", true);
        client.SetData("WORKCHECK", 0);
        client.SetIntoVehicle(vehicle, 0);
        Trigger.ClientEvent(client, "createCheckpoint", 15, 1, Checkpoints[0].Position, 4, 0, 221, 255, 0);
        Trigger.ClientEvent(client, "createWorkBlip", Checkpoints[0].Position);
    }


    public static void zavrsiposao(Player client)
    {
        
        if (client.HasData("busjob"))
        {
            string playername = AccountManage.GetCharacterName(client);
            Main.DisplayErrorMessage(client, NotifyType.Info, NotifyPosition.BottomCenter, "Zavrsili ste posao!");
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "LT"+playername)
                {
                    veh.Delete();
                    client.ResetData("busjob");
                    Trigger.ClientEvent(client, "deleteCheckpoint", 15);
                    Trigger.ClientEvent(client, "deleteWorkBlip");
                }
            }
        }
        
    }

    private static void PlayerEnterCheckpoint(ColShape shape, Player player)
    {
        try
        {
            if (shape.GetData<int>("NUMBER") != player.GetData<int>("WORKCHECK")) return;
            if (player.IsInVehicle)
            {
                Vehicle veh = player.Vehicle;
                string playername = AccountManage.GetCharacterName(player);
                if (veh.NumberPlate != "LT"+playername) return;
                Jobmanager.addskill(player);
                player.SetData("WORKCHECK", -1);
                NAPI.Task.Run(() => {
                try
                {   
                    if (NAPI.Player.IsPlayerConnected(player))
                    {
                        if(player.GetData<dynamic>("jobskill") >= 149)
                        {
                            Main.GivePlayerSalary(player, 52);
                        }
                        Main.GivePlayerSalary(player, 261);
                        Main.GiveCompanyMoney(1, 10);
                        player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+ ~y~skill");

                        int nextCheck = (int)shape.GetData<int>("NUMBER") + 1;
                        if (nextCheck >= Checkpoints.Count)
                        {
                            zavrsiposao(player);
                        }
                        else
                        {
                            player.SetData("WORKCHECK", nextCheck);
                            Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints[nextCheck].Position, 4, 0, 221, 255, 0);
                            Trigger.ClientEvent(player, "createWorkBlip", Checkpoints[nextCheck].Position);
                        }
                    }
                }
                catch { }
            }, 4000);
            }
        } catch (Exception e) { Console.WriteLine(e); }
    }
}