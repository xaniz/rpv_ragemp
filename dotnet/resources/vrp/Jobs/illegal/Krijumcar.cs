using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public class Krijumcar : Script
{
    public Krijumcar()
    {
    NAPI.TextLabel.CreateTextLabel("Krijumcar~n~~w~[~y~ Y ~w~]", new Vector3(-107.56066, -2706.5156, 6.507262), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
    }

    [ServerEvent(Event.PlayerDisconnected)]
    public static void onPlayerDissconnectedHandler(Player player, DisconnectionType type, string reason)
    {
        try
        {
            string playername = AccountManage.GetCharacterName(player);
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "kr"+playername)
                {
                    veh.Delete();
                }
            }
        }
        catch (Exception e) { Console.Write(e);}
    }

    public static void respawnkrijumcarcar(Player client)
    {
        try
        {
            string playername = AccountManage.GetCharacterName(client);
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.NumberPlate == "kr"+playername)
                {
                    veh.Delete();
                }
            }

        }
        catch (Exception e) { Console.Write(e);}
    }

    public static void PressKeyE(Player client)
    {
        client.SetData("KRIJUMCAR_TIMER", TimerEx.SetTimer(() => OnBoatLoaded(client), 10000, 1));
        Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Sacekajte da se kombi napuni robom!");
    }

    public static void OnBoatLoaded(Player client)
    {
        if (Main.IsInRangeOfPoint(client.Position, new Vector3(985.48, -138.34, 73.09), 10))
        {
            NAPI.Task.Run(() =>
            {
                try
                    {
                        if (NAPI.Player.IsPlayerConnected(client))
                        {
                        Trigger.ClientEvent(client, "deleteCheckpoint", 15, 0);
                        Trigger.ClientEvent(client, "deleteWorkBlip");
                        client.GetData<dynamic>("KRIJUMCAR_TIMER").Kill();
                        Vehicle veh = client.Vehicle;
                        string playername = AccountManage.GetCharacterName(client);
                        if (veh.NumberPlate == "kr"+playername)
                        {
                            Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Kombi je pun, odvezite kombi na dogovoreno mesto!");
                            veh.SetData("punbrod", true);
                            Trigger.ClientEvent(client, "createCheckpoint", 15, 1, new Vector3(-97.60, -2710, 4.9), 6, 0, 221, 255, 0);
                            Trigger.ClientEvent(client, "createWorkBlip", new Vector3(-97.60, -2710, 4.9));
                        }
                        else{
                            Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Ovo nije kombi koji ste preuzeli!");
                            return;
                        }
                        }
                        
                    }
                    catch(Exception e)
                    {
                        Console.Write(e);
                    }
                    client.ResetData("KRIJUMCAR_TIMER");
            });
        }
        else{
            Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste na mestu na kome se kombi puni. Vratite se nazad!");
        }
        
    }

    public static void finishes(Player client)
    {
        if (Main.IsInRangeOfPoint(client.Position, new Vector3(-97.60, -2710, 5.9), 10))
        {
            Vehicle veh = client.Vehicle;
            if(client.IsInVehicle && veh.HasData("punbrod"))
            {
                veh.ResetData("punbrod");
                respawnkrijumcarcar(client);
                Trigger.ClientEvent(client, "deleteCheckpoint", 15, 0);
                Trigger.ClientEvent(client, "deleteWorkBlip");
                Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste posao i dobili 1RPV coin");
                Inventory.GiveItemToInventory(client, 64, 1);
                client.ResetData("krijumcarenje");
            }
            else{
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Ovaj kombi nema robu!");
                return;
            }
            
        }
    }

    [RemoteEvent("krijumcarjobs")]
    public static void krijumcarjobs(Player client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        if (client.GetData<dynamic>("krijumcarenje") == true)
                        {
                            Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec ste zapoceli posao, morate ga zavrsiti!");
                            return;
                        }
                        string playername = AccountManage.GetCharacterName(client);
                    
                        Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Zapoceli ste posao!");
                        string vehName = "burrito";
                        VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
                        Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(-116.34, -2706.77, 6.1), new Vector3(0, 0, -6.0), 27, 111, "kr"+playername, 255, false, true, 0);
                        Main.SetVehicleFuel(vehicle, 100.0);
                        client.SetData("krijumcarenje", true);
                        Trigger.ClientEvent(client, "createCheckpoint", 15, 1, new Vector3(985.48, -138.34, 72.09), 6, 0, 221, 255, 0);
                        Trigger.ClientEvent(client, "createWorkBlip", new Vector3(985.48, -138.34, 72.09));
                        Random rnd = new Random();
                        int randsansa = rnd.Next(1, 10);
                        if (randsansa == 5)
                        {
                            foreach (var target in NAPI.Pools.GetAllPlayers())
                            {
                                if (target.GetData<dynamic>("status") == true && AccountManage.GetPlayerGroup(target) == 1)
                                {
                                    Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "Tajne sluzbe otkrile su da je osoba upravo usla u vozilo burrito");
                                    Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "Vozilo se krece sa LS Doka prema biker klubu u blizini uber sluzbe.");
                                }
                            }
                        }
                        
                        break;
                    }
                case 1:
                    {
                        client.SetData("krijumcarenje", false);
                        respawnkrijumcarcar(client);
                        Trigger.ClientEvent(client, "deleteCheckpoint", 15, 0);
                        Trigger.ClientEvent(client, "deleteWorkBlip");
                        Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste posao!");
                        break;
                    }
            }
        } catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}

