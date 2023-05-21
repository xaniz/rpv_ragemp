using GTANetworkAPI;
using System;
using System.Collections.Generic;

public class Elektricar : Script
{
    public  Elektricar()
    {
    NAPI.TextLabel.CreateTextLabel("Elektricar~n~~w~[~y~ Y ~w~]", new Vector3(733.34, 133.63, 80.75), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
    NAPI.Marker.CreateMarker(1, new Vector3(132.24, -1462.01, 28.35), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

    Entity temp_blip;
    temp_blip = NAPI.Blip.CreateBlip(new Vector3(733.34, 133.63, 80.75));
    NAPI.Blip.SetBlipName(temp_blip, "*Elektricar");
    NAPI.Blip.SetBlipSprite(temp_blip, 769);
    NAPI.Blip.SetBlipColor(temp_blip, 5);
    NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
    NAPI.Blip.SetBlipShortRange(temp_blip, true);
    }

    public enum AnimationFlags
    {
        Loop = 1 << 0,
        StopOnLastFrame = 1 << 1,
        OnlyAnimateUpperBody = 1 << 4,
        AllowPlayerControl = 1 << 5,
        Cancellable = 1 << 7
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
                if (veh.NumberPlate == "el"+playername)
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
                if (veh.NumberPlate == "el"+playername)
                {
                    veh.Delete();
                }
            }

        }
        catch (Exception e) { Console.Write(e);}
    }

    
    private static List<Checkpoint> Checkpoints = new List<Checkpoint>()
        {
            new Checkpoint(new Vector3(390.54816, 318.87686, 102.15424)),
            new Checkpoint(new Vector3(-440.03705, 292.40454, 82.3265)),
            new Checkpoint(new Vector3(-1469.9121, -389.55475, 37.75863)),
            new Checkpoint(new Vector3(-982.6318, -287.31323, 37.07259)),
            new Checkpoint(new Vector3(-755.7173, -234.86101, 36.283688)),
            new Checkpoint(new Vector3(-715.646, -857.8558, 22.020224)),
            new Checkpoint(new Vector3(4.3036942, -1028.6029, 28.090776)),
            new Checkpoint(new Vector3(721.43036, -912.08154, 24.204859)),
            new Checkpoint(new Vector3(438.402, -1904.7239, 24.927717)),
            new Checkpoint(new Vector3(-10.72428, -1310.7559, 28.275932)),
            new Checkpoint(new Vector3(379.70047, -908.3684, 28.42344)),
            new Checkpoint(new Vector3(25.443218, -730.4684, 30.71916)),
            new Checkpoint(new Vector3(-1062.7902, -1139.5381, 1.158597)),
        };

    [RemoteEvent("electricjobs")]
    public static void electricjobs(Player Client, int index)
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
        
        if (client.GetData<dynamic>("electricjob") == true)
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
        string vehName = "boxville";
        VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
        Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(743.64, 134.64, 80.24), new Vector3(0, 0, -121), 27, 111, "el"+playername, 255, false, true, 0);
        Main.SetVehicleFuel(vehicle, 100.0);
        client.SetData("electricjob", true);
        Random rnd = new Random();
        var check = rnd.Next(0, Checkpoints.Count - 1);
        client.SetData("WORKCHECK", check);
        Trigger.ClientEvent(client, "createCheckpoint", 15, 1, Checkpoints[check].Position, 1, 0, 221, 255, 0);
        Trigger.ClientEvent(client, "createWorkBlip", Checkpoints[check].Position);

    }

    public static void zavrsiposao(Player client)
    {
        
        if (client.HasData("electricjob"))
        {
            string playername = AccountManage.GetCharacterName(client);
            Main.DisplayErrorMessage(client, NotifyType.Info, NotifyPosition.BottomCenter, "Zavrsili ste posao!");
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "el"+playername)
                {
                    veh.Delete();
                    client.ResetData("electricjob");
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
        if(client.GetData<dynamic>("uzeoalat") == true){
            return;
        }
        if(veh.NumberPlate == "el"+playername)
        {
            client.SetData("uzeoalat", true);
            client.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+ ~y~Alat");
        }
        else
        {
            Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Ovo nije vozilo elektricara!");
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
                if (player.GetData<dynamic>("uzeoalat") == true)
                {
                    Jobmanager.addskill(player);
                    player.SetData("WORKCHECK", -1);
                    player.SetData("uzeoalat", false);
                    NAPI.Player.PlayPlayerAnimation(player, (int)(AnimationFlags.Loop), "mini@repair", "fixing_a_ped");
                    NAPI.Task.Run(() => {
                        try
                        {   
                            if (NAPI.Player.IsPlayerConnected(player))
                            {
                                if(player.GetData<dynamic>("jobskill") >= 149)
                                {
                                    Main.GivePlayerSalary(player, 30);
                                }
                                Main.GivePlayerSalary(player, 407);
                                Main.GiveCompanyMoney(2, 10);
                                player.StopAnimation();
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
                    Main.DisplayErrorMessage(player, NotifyType.Info, NotifyPosition.BottomCenter, "Sedite u auto i uzmite alat [E]");
                }
                

                

            } catch (Exception e) { Console.WriteLine(e); }
        }
    
}