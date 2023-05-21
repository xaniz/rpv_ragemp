using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Threading;
using MySql.Data.MySqlClient;

class ChopJob : Script
{
    public ChopJob()
    {
        NAPI.TextLabel.CreateTextLabel("Auto Delovi ~w~[ ~g~E~w~ ]", new Vector3(1260.08, -2566.23, 42.71), 16, 0.600f, 0, new Color(221, 255, 0, 150));

        Entity temp_blip;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1260.08, -2566.23, 42.71));
        NAPI.Blip.SetBlipName(temp_blip, "Auto Delovi");
        NAPI.Blip.SetBlipSprite(temp_blip, 779);
        NAPI.Blip.SetBlipColor(temp_blip, 25);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
    }

    [RemoteEvent("vdismant")]
    public static void vdismant(Player Client)
    {
        if (Client.GetData<dynamic>("status") == true && Client.IsInVehicle)
        {
            if (Client.Vehicle.HasData("Mashin_Owner") == false)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Ne mozete prodati u delove ovaj automobil!");
                return;
            }
            if (Client.Vehicle.GetData<dynamic>("Mashin_Owner") == AccountManage.GetPlayerSQLID(Client))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Zasto biste rastavljali svoje vozilo u delove?");
                return;
            }
            if (Main.IsInRangeOfPoint(Client.Position, new Vector3(1260.08, -2566.23, 42.71), 3f))
            {
                
                Vehicle veh = Client.Vehicle;
                // Vehicle vehicle = Client.GetData<dynamic>("InteractMenu_vehicle_handle");
                if (!veh.Exists)
                {
                    Client.SendNotification("Vozilo vise ne postoji.");
                    return;
                }
                NAPI.Task.Run(() =>
                {
                if (NAPI.Player.IsPlayerConnected(Client))
                {
                Client.TriggerEvent("Hide_Crafting_System");
                foreach (var pl in API.Shared.GetAllPlayers())
                {
                    if (pl.GetData<dynamic>("status") == true)
                    {
                        for (int index3 = 0; index3 < PlayerVehicle.MAX_PLAYER_VEHICLES; index3++)
                        {
                            if (PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].state[index3] == 1 && PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index3].Exists && PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index3] == veh)
                            {

                                if (PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].state[index3] == 1)
                                {
                                    
                                        Random rnd = new Random();
                                        int randommoney = rnd.Next(3500, 4000);
                                        Main.SendCustomChatMessasge(Client, "Rastavili ste vozilo");
                                        Main.SendCustomChatMessasge(pl, "Vase vozilo je rastavljeno u delove od strane lopova");
                                        Police.SetPlayerCrime(Client, 1);
                                        Main.GivePlayerMoney(Client, randommoney);
                                        if (PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index3].Exists) NAPI.Entity.DeleteEntity(PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index3]);

                                        PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index3] = null;
                                        PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].state[index3] = 0;

                                        PlayerVehicle.SavePlayerVehicle(pl, index3);

                                        return;
                                    
                                }
                            }
                        }
                    }
                }
                if (veh.HasData("veh_sql") != true)
                {
                    Main.SendCustomChatMessasge(Client, "Ne mozete zapleniti ovo vozilo.");
                    return;
                }
                    Main.CreateMySqlCommand("UPDATE `vehicles` SET `vehicle_state` = 0 WHERE `id` = '" + veh.GetData<dynamic>("veh_sql") + "';");
                }
                }, 6000);
            return;
            }
            
        }
    }

}

