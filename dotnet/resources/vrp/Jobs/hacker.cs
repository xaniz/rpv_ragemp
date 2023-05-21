using GTANetworkAPI;
using System;
using System.Collections.Generic;

public class hacker : Script 
{
    public hacker()
    {
        NAPI.TextLabel.CreateTextLabel("Haker~n~~w~[~y~ Y ~w~]", new Vector3(-1083.314, -245.69662, 38.763233), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
        Entity temp_blip;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1083.314, -245.69662, 38.763233));
        NAPI.Blip.SetBlipName(temp_blip, "*Haker");
        NAPI.Blip.SetBlipSprite(temp_blip, 775);
        NAPI.Blip.SetBlipColor(temp_blip, 5);
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

    private static List<Checkpoint> Checkpoints = new List<Checkpoint>()
    {
        new Checkpoint(new Vector3(-1688.3253, -1073.6224, 12.152174)),
        new Checkpoint(new Vector3(-579.02, -219.82, 38.21)),
        new Checkpoint(new Vector3(247.9837, 209.7864, 105.28679)),
        new Checkpoint(new Vector3(146.86989, -1046.0608, 28.368242)),
        new Checkpoint(new Vector3(-1182.745, -603.66864, 25.661732)),
        new Checkpoint(new Vector3(-2956.4783, 481.7275, 14.697094)),
        new Checkpoint(new Vector3(1164.6388, -322.05176, 68.20508)),
        new Checkpoint(new Vector3(-30.212215, -1106.9044, 25.422333)),
        new Checkpoint(new Vector3(-226.03935, -1999.7263, 23.685373)),
        new Checkpoint(new Vector3(-1221.8527, -908.3121, 11.32636)),
    };


    [ServerEvent(Event.PlayerDisconnected)]
    public static void onPlayerDissconnectedHandler(Player player, DisconnectionType type, string reason)
    {
        try
        {
            string playername = AccountManage.GetCharacterName(player);
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "hk"+playername)
                {
                    veh.Delete();
                }
            }
        }
        catch (Exception e) {Console.Write(e); }
    }

    public static void respawnhackercar(Player client)
    {
        try
        {
            string playername = AccountManage.GetCharacterName(client);
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "hk"+playername)
                {
                    veh.Delete();
                }
            }

        }
        catch (Exception e) { Console.Write(e);}
    }

    [RemoteEvent("hackerjobs")]
    public static void hackerjobs(Player client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        if (client.GetData<dynamic>("hackerjob") == true)
                        {
                            Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec ste zapoceli posao, morate ga zavrsiti!");
                            return;
                        }
                        var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(-1083.314, -245.69662, 37.763233), 1, 2, 0);
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
                    
                        Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Zapoceli ste posao, auto vam je ispred garaze odmah pored ulaza!");
                        string vehName = "asbo";
                        VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
                        Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(-1098.40, -256.53, 37.60), new Vector3(0, 0, 145), 27, 111, "hk"+playername, 255, false, true, 0);
                        Main.SetVehicleFuel(vehicle, 100.0);
                        client.SetData("hackerjob", true);
                        Random rnd = new Random();
                        var check = rnd.Next(0, Checkpoints.Count - 1);
                        client.SetData("WORKCHECK", check);
                        Trigger.ClientEvent(client, "createCheckpoint", 15, 1, Checkpoints[check].Position, 1, 0, 221, 255, 0);
                        Trigger.ClientEvent(client, "createWorkBlip", Checkpoints[check].Position);
                        break;
                    }
                case 1:
                    {
                        if (client.HasData("hackerjob"))
                        {
                            string playername = AccountManage.GetCharacterName(client);
                            Main.DisplayErrorMessage(client, NotifyType.Info, NotifyPosition.BottomCenter, "Zavrsili ste posao!");
                            foreach (var veh in NAPI.Pools.GetAllVehicles())
                            {
                                if (veh.NumberPlate == "hk"+playername)
                                {
                                    veh.Delete();
                                    client.SetData<dynamic>("hackerjob", false);
                                    Trigger.ClientEvent(client, "deleteCheckpoint", 15);
                                    Trigger.ClientEvent(client, "deleteWorkBlip");
                                }
                            }
                        }
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static void PressKeyE(Player client)
    {
        if (!client.IsInVehicle) return;
        string playername = AccountManage.GetCharacterName(client);
        Vehicle veh = client.Vehicle;
        if(client.GetData<dynamic>("uzeoopremu") == true){
            return;
        }
        if(veh.NumberPlate == "hk"+playername)
        {
            client.SetData("uzeoopremu", true);
            client.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+ ~y~Oprema");
        }
        else
        {
            Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Ovo nije vozilo Hakera!");
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
            if (player.GetData<dynamic>("uzeoopremu") == true && player.GetData<dynamic>("hackerjob") == true)
            {
                Random rnd = new Random();
                int rndnumber = rnd.Next(0, 2);
                Random crnd = new Random();
                int crndnumber = crnd.Next(1, 3);
                NAPI.Task.Run(() => {
                    try
                    {
                        if (NAPI.Player.IsPlayerConnected(player))
                        {
                            player.TriggerEvent("CircuitBreakerStart", 10, rndnumber, crndnumber);
                            player.SetData("WORKCHECK", -1);
                            player.SetData("uzeoopremu", false);
                            Random rnd2 = new Random();
                            var nextCheck = rnd2.Next(0, Checkpoints.Count - 1);
                            while (nextCheck == shape.GetData<int>("NUMBER")) nextCheck = rnd2.Next(0, Checkpoints.Count - 1);
                            player.SetData("WORKCHECK", nextCheck);
                            Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints[nextCheck].Position, 1, 0, 221, 255, 0);
                            Trigger.ClientEvent(player, "createWorkBlip", Checkpoints[nextCheck].Position);
                        }
                    }
                    catch { }
                }, 500);
            }
            else {
                Main.DisplayErrorMessage(player, NotifyType.Info, NotifyPosition.BottomCenter, "Sedite u vozilo i uzmite opremu [E]");
            }
            

            

        } catch (Exception e) { Console.WriteLine(e); }
    }
    [RemoteEvent("CircuitBreakerWIN")]
    public static void CircuitBreakerWIN(Player player)
    {
        if (player.GetData<dynamic>("hackerjob") == true)
        {
            Main.GivePlayerSalary(player, 1044);
            Jobmanager.addskill(player);
            player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+ ~y~skill");
        }
        if (player.GetData<dynamic>("ihackerjob") == true)
        {
            ihacker.illegalhackerwin(player);
        }
    }

    
    
}