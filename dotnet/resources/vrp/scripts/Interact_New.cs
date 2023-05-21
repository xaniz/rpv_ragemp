using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


class InteractMenu_New : Script
{
    //
    // Interact With Vehicle
    //23

    [RemoteEvent("pSelected")]
    public static void pSelected(Player Client, params object[] args)
    {
        if (args.Length == 1) return;
        if (!(args[0] is Player)) return;
        Player target = (Player)args[0];
        // Player target = (Client)args[0];
        if (target == null || Client.Position.DistanceTo(target.Position) > 3)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Predaleko ste!");
            return;
        }
        var action = args[1].ToString();
        switch (action)
        {
            case "give money":
                Client.SetData<dynamic>("UserMenuToTarget_handle", target);
                Client.SetData<dynamic>("UserMenuToTarget_name", AccountManage.GetCharacterName(target));
                InteractMenu.User_Input(Client, "responser_money_user", "Dajete novac igracu " + target.Name + "", "0", "", "number");
                return;

            case "cufuncuff":
                {
                    
                    if (AccountManage.GetPlayerGroup(Client) == -1)
                    {
                        NAPI.Notification.SendNotificationToPlayer(Client, "~r~Greska:~w~ Niste ovlasceni.");
                        return;
                    }
                    if (target.GetData<dynamic>("playerCuffed") == 0)
                    {
                        if (target != null)
                        {
                            if (Main.IsInRangeOfPoint(target.Position, Client.Position, 3) && target != Client)
                            {

                                if (target.GetData<dynamic>("playerCuffed") == 1)
                                {
                                    NAPI.Notification.SendNotificationToPlayer(Client, "~r~Greska:~w~ Igrac vec ima lisice.");
                                    return;
                                }

                                if (target.GetData<dynamic>("handsup") == false)
                                {
                                    NAPI.Notification.SendNotificationToPlayer(Client, "~r~Greska:~w~ Igrac nije podigao ruke.");
                                    return;
                                }

                                if (target.IsInVehicle)
                                {
                                    NAPI.Notification.SendNotificationToPlayer(Client, "~r~Greska:~w~ Igrac je u vozilu.");
                                    return;
                                }

                                target.SetData<dynamic>("handsup", false);
                                NAPI.Notification.SendNotificationToPlayer(Client, "~y~INFO:~w~ Stavili ste lisice ~b~" + AccountManage.GetCharacterName(target) + "~w~.");
                                NAPI.Notification.SendNotificationToPlayer(target, "~y~INFO:~w~ ~b~" + AccountManage.GetCharacterName(Client) + "~w~ Vam je stavio lisice.");

                                target.SetData<dynamic>("playerCuffed", 1);
                                target.StopAnimation();
                                Inventory.oruzijeinuse(target);//ovde 
                                cellphoneSystem.FinishCall(target);
                                Police.CuffPlayer(target);;

                                return;
                            }
                        }
                    }
                    else
                    {
                        
                        Police.UnCuffPlayer(target);
                    }

                    return;
                }
            case "showpas":
                {
                    string Gender = " X ";
                    string fac = " Unknown ";

                    int faction = AccountManage.GetPlayerGroup(Client);

                    switch (faction)
                    {
                        case 1:
                            fac = "LS-PD";
                            break;
                        case 2:
                            fac = "LS-MD";
                            break;
                        case 3:
                            fac = "LS-NR";
                            break;
                        case 4:
                            fac = "LS-DCC";
                            break;
                        case 5:
                            fac = "LS-MC";
                            break;
                        default:
                            break;
                    }

                    switch (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE"))
                    {
                        case 1:
                            Gender = "Female";
                            break;
                        case 0:
                            Gender = "Male";
                            break;
                        default:
                            break;
                    }

                    if (Client.IsInVehicle) return;

                    List<object> data = new List<object>
                    {
                         AccountManage.GetPlayerSQLID(Client),
                         AccountManage.GetCharacterName(Client).Split(" ")[0],
                         AccountManage.GetCharacterName(Client).Split(" ")[1],
                         Client.GetData<dynamic>("character_age"),
                         Gender,
                         fac
                    };

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                    target.TriggerEvent("passport", json);
                    return;
                }

            case "dragdrop":
                {
                    if (target.GetData<dynamic>("BeingDragged") == true)
                    {
                        Police.UnDragPlayer(target);

                    }
                    else if (target.GetData<dynamic>("BeingDragged") == false)
                    {
                        Police.DragPlayerToTarget(target, Client);

                    }


                    return;
                }
            case "mrevive":
                {
                    if (Client.HasData("duty") && Client.GetData<dynamic>("duty") == 1)
                    {
                        MedicSystem.CMD_medicrevive(Client, target);

                    }
                    return;
                }
            case "treatment":
                {
                    if (Client.HasData("duty") && Client.GetData<dynamic>("duty") == 1)
                    {
                        MedicSystem.CMD_Izleci(Client, target.Value.ToString(), 100);
                    }
                    return;
                }
            case "Search":
                {
                    if (target.GetData<dynamic>("playerCuffed") == 1 || target.GetData<dynamic>("handsup") == true || target.GetSharedData<dynamic>("Injured") == 1)
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();

                    }
                    else
                    {
                        SendNotificationError(Client, "Igrac nije podigao ruke ili nije u lisicama.");
                    }
                    return;
                }
            case "AC":
                {
                    List<dynamic> menu_item_list = new List<dynamic>();
                    int index = 0;
                    foreach (var crime in Main.crime_list)
                    {
                        menu_item_list.Add(new { Type = 1, Name = crime.crime_name, Description = "", RightLabel = "~c~" + crime.crime_points + " trazeni nivo" });

                        index++;
                    }
                    InteractMenu.CreateMenu(Client, "CRIME_LIST_RESPONSE", "Lista trazenih", "~g~Proveri listu trazenih" + UsefullyRP.GetPlayerNameToTarget(target, Client), false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Green");

                    Client.SetData<dynamic>("CMDMandatoTarget", target);
                    return;
                }
            case "shake":
                {

                    return;
                }
            case "Rob":
                {
                    if (Main.GetPlayerMoney(target) < 2)
                    {
                        SendNotificationError(Client, "Igrac nema dovoljno novca.");
                        return;
                    }

                    if (target.GetData<dynamic>("playerCuffed") == 1 || target.GetData<dynamic>("handsup") == true || target.GetSharedData<dynamic>("Injured") == 1)
                    {

                        int money = Main.GetPlayerMoney(target);

                        Main.GivePlayerMoney(Client, money);
                        Main.GivePlayerMoney(target, -money);


                        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
                        foreach (Player alvo in proxPlayers)
                        {
                            alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " gura ruku u dzep " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + " i krade novac. ");
                        }
                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "~g~$" + money + " ukradeno");
                        target.TriggerEvent("createNewHeadNotificationAdvanced", "~r~-$" + money);

                        target.SetData<dynamic>("mug_timeout", DateTime.Now.AddMinutes(15));
                        return;

                    }
                    SendNotificationError(Client, "Igrac nije podigao ruke.");
                    return;
                }
            default:
                break;
        }
    }

    [RemoteEvent("toolselected")]
    public void toolselected(Player Client, params object[] args)
    {
        if (args.Length == 1) return;
        if (!(args[0] is Vehicle)) return;
        Vehicle veh = (Vehicle)args[0];
        // Player target = (Client)args[0];
        if (veh == null || Client.Position.DistanceTo(veh.Position) > 3)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Predaleko ste!");
            return;
        }
        var action = args[1].ToString();
        switch (action)
        {
            case "carrep":
                {
                    if (Inventory.GetPlayerItemFromInventory(Client, 8) > 0)
                    {
                        if (!veh.Exists)
                        {
                            SendNotificationError(Client, "Nema vozila pored Vas.");
                            return;
                        }
                        if (!Main.IsInRangeOfPoint(Client.Position, veh.Position, 5.0f))
                        {
                            SendNotificationError(Client, "Nema vozila pored Vas.");
                            return;
                        }

                        if (NAPI.Entity.DoesEntityExist(veh))
                        {

                            if (NAPI.Data.HasEntityData(veh, "vehicle_repairing"))
                            {
                                if (NAPI.Data.GetEntityData(veh, "vehicle_repairing") == true)
                                {
                                    SendNotificationError(Client, "Vozilo se vec popravlja.");
                                    return;
                                }
                            }

                            int pecas = 1;
                            if (NAPI.Vehicle.GetVehicleHealth(veh) >= 900)
                            {
                                pecas = 1;
                            }
                            else if (NAPI.Vehicle.GetVehicleHealth(veh) >= 500 && NAPI.Vehicle.GetVehicleHealth(veh) <= 899)
                            {
                                pecas = 2;
                            }
                            else
                            {
                                pecas = 3;
                            }

                            if (Inventory.GetPlayerItemFromInventory(Client, 8) < pecas)
                            {
                                SendNotificationError(Client, "~c~Treba Vam " + pecas + "~w~ delova kako biste popravili ovo vozilo.");
                                return;
                            }


                            if (!Client.IsInVehicle)
                            {
                                try
                                {



                                    if (NAPI.Entity.DoesEntityExist(veh))
                                    {
                                        int time = 60;
                                        Main.DisplaySubtitle(Client, "~y~Popravka u toku, sacekajte ~r~" + time + " sekundi ~y~ ...", 1);

                                        Client.StopAnimation();
                                        NAPI.Player.PlayPlayerAnimation(Client, 33, "mini@repair", "fixing_a_ped");

                                        NAPI.Data.SetEntityData(veh, "vehicle_repairing", true);
                                        TimerEx repairTimer = null;
                                        repairTimer = TimerEx.SetTimer(() =>
                                        {

                                            time--;
                                            Main.DisplaySubtitle(Client, "~y~Popravka u toku, sacekajte ~r~" + time + " sekundi ~y~ ...", 1);

                                            if (!Main.IsInRangeOfPoint(Client.Position, NAPI.Entity.GetEntityPosition(veh), 3.0f))
                                            {
                                                repairTimer.Kill();
                                                Client.StopAnimation();
                                                Main.DisplaySubtitle(Client, "~y~Udaljili ste se od vozila i otkazali popravku.", 1);
                                                NAPI.Data.SetEntityData(veh, "vehicle_repairing", false);
                                                return;
                                            }

                                            if (Inventory.GetPlayerItemFromInventory(Client, 8) < pecas)
                                            {
                                                repairTimer.Kill();
                                                Client.StopAnimation();
                                                Main.DisplaySubtitle(Client, "~y~Nemate vise delova, ~r~ popravka je otkazana.", 1);
                                                NAPI.Data.SetEntityData(veh, "vehicle_repairing", false);
                                                return;
                                            }

                                            if (time == 0)
                                            {
                                                NAPI.Data.SetEntityData(veh, "vehicle_repairing", false);
                                                Inventory.RemoveItemByType(Client, 8, pecas);

                                                // NAPI.Vehicle.SetVehicleDoorState(vehicle, 4, false);
                                                //            //       VehicleStreaming.SetDoorState(veh, DoorID.DoorHood, DoorState.DoorClosed);
                                                repairTimer.Kill();
                                                NAPI.Vehicle.RepairVehicle(veh);
                                                Client.StopAnimation();
                                                Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Vozilo je uspesno popravljeno");
                                            }
                                        }, 1000, 0);


                                    }
                                    else SendNotificationError(Client, "Niste pored vozila.");

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);

                                }
                            }

                        }
                        else SendNotificationError(Client, "Niste pored vozila.");
                    }
                    else
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate alat za popravku!");
                    }
                    return;
                }
            case "refuel":
                {
                    if (!veh.Exists)
                    {
                        SendNotificationError(Client, "Vise nema vozila!");
                        return;
                    }
                    if (!Main.IsInRangeOfPoint(Client.Position, veh.Position, 4.0f))
                    {
                        SendNotificationError(Client, "Previse ste se udaljili od vozila!");
                        return;
                    }


                    if (NAPI.Entity.DoesEntityExist(veh))
                    {
                        if (Main.GetVehicleFuel(veh) > 79)
                        {
                            SendNotificationError(Client, "Vozilo je vec puno !");
                            return;
                        }
                        if (Inventory.GetPlayerItemFromInventory(Client, 21) < 1)
                        {
                            SendNotificationError(Client, "Ne mozete napuniti manje od 1 litra.");
                            return;
                        }

                        if (!Client.IsInVehicle)
                        {
                            if (NAPI.Entity.DoesEntityExist(veh))
                            {
                                Inventory.RemoveItemByType(Client, 21, 1);
                                Main.SetVehicleFuel(veh, Main.GetVehicleFuel(veh) + 20.0);
                                Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Natocili ste 20L goriva u Vase vozilo");

                            }
                            else SendNotificationError(Client, "Niste pored vozila.");
                        }
                    }
                    else SendNotificationError(Client, "Niste pored vozila.");
                    return;
                }
            default:
                break;
        }
    }

    [RemoteEvent("fselected")]
    public static void fselected(Player Client, params object[] args)
    {
        try
        {
            if (!(args[0] is Vehicle)) return;
            Vehicle target = (Vehicle)args[0];
            // Player target = (Client)args[0];
            if (target == null || Client.Position.DistanceTo(target.Position) > 3)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Predaleko ste!");
                return;
            }
            if (args.Length == 1) return;
            var action = args[1].ToString();
            switch (action)
            {
                case "Impound_Car":
                    Vehicle veh = (Vehicle)args[0];
                    // Vehicle vehicle = Client.GetData<dynamic>("InteractMenu_vehicle_handle");
                    if (!veh.Exists)
                    {
                        SendNotificationError(Client, "Vozilo vise ne postoji.");
                        return;
                    }
                    if (!Main.IsInRangeOfPoint(Client.Position, veh.Position, 5.0f))
                    {
                        SendNotificationError(Client, "Previse ste se udaljili od vozila.");
                        return;
                    }

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
                                        Main.SendCustomChatMessasge(Client, "Zaplenili ste vozilo");
                                        Main.SendCustomChatMessasge(pl, "Vase vozilo je zaplenjeno.");
                                        if (PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index3].Exists) NAPI.Entity.DeleteEntity(PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index3]);

                                        PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index3] = null;
                                        PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].state[index3] = 0;

                                        PlayerVehicle.SavePlayerVehicle(pl, index3);
                                        //Client.SendNotification("You Impound this vehicle.");
                                        //pl.SendNotification("Khodro Shoma Impound Shod.");
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
//cclose
                    MySqlConnection connection = new MySqlConnection(Main.myConnectionString);
                    MySqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT vehicle_state FROM vehicles WHERE id=" + veh.GetData<dynamic>("veh_sql") + "";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetInt32("vehicle_state") == 1)
                        {
                            command.CommandText = "UPDATE vehicles SET vehicle_state=0 where id =" + veh.GetData<dynamic>("veh_sql") + "";
                            command.ExecuteNonQuery();
                            if (veh.Exists)
                            {
                                veh.Delete();
                            }
                            return;
                        }
                        else
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Ne mozete zapleniti ovo vozilo.");
                            return;
                        }
                    }
                    connection.Close();

                    return;

                case "Write Ticket":
                    {


                        //   Main.CreateMySqlCommand("UPDATE vehicles SET vehicle_ticket= where id=" + vehicle.GetData<dynamic>("veh_sql") + "");
                        return;
                    }

                default:
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


    }
    [RemoteEvent("CarControl")]
    public static void CarControl(Player Client, int index)
    {
        Vehicle veh = Client.Vehicle;
        int playerid = Main.getIdFromClient(Client);
        if (Client.IsInVehicle)
        {
            switch (index)
            {

                case 0:

                    
                    if (NAPI.Entity.DoesEntityExist(veh))
                    {

                        for (int index2 = 0; index2 < PlayerVehicle.MAX_PLAYER_VEHICLES; index2++)
                        {
                            if (PlayerVehicle.vehicle_data[playerid].state[index2] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index2].Exists && veh == PlayerVehicle.vehicle_data[playerid].handle[index2])
                            {
                                if (VehicleStreaming.GetLockState(veh) == false)
                                {
                                    VehicleStreaming.SetLockStatus(veh, true);
                                    Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.CenterRight, Translation.head_notification_2);
                                }
                                else
                                {
                                    VehicleStreaming.SetLockStatus(veh, false);
                                    Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.CenterRight, Translation.head_notification_1);
                                }
                                return;
                            }
                        }
                    }
                    return;

                case 1:
                    if (!veh.HasData("Door_4") || veh.GetData<bool>("Door_4") == false)
                    {
                        if (VehicleStreaming.GetLockState(veh))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vozilo je zakljucano!");
                            return;
                        }
                        UsefullyRP.SendRoleplayAction(Client, "otvara haubu.");
                        // NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_OPEN, veh, 4, false);
                        Client.TriggerEvent("SetDoorStat", "OPEN", veh, 4);
                        veh.SetData<bool>("Door_4", true);
                    }
                    else
                    {
                        UsefullyRP.SendRoleplayAction(Client, "zatvara haubu.");
                        // NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_SHUT, veh, 4, false);
                        Client.TriggerEvent("SetDoorStat", "CLOSE", veh, 4);
                        veh.SetData<bool>("Door_4", false);

                    }

                    return;
                case 2:
                    if (!veh.HasData("Door_5") || veh.GetData<bool>("Door_5") == false)
                    {
                        UsefullyRP.SendRoleplayAction(Client, "otvara gepek.");

                        //  NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_OPEN, veh, 5, true, false);
                        Client.TriggerEvent("SetDoorStat", "OPEN", veh, 5);
                        veh.SetData<bool>("Door_5", true);


                    }
                    else
                    {
                        UsefullyRP.SendRoleplayAction(Client, "zatvara gepek.");
                        //  NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_SHUT, veh, 5, false);
                        Client.TriggerEvent("SetDoorStat", "CLOSE", veh, 5);
                        veh.SetData<bool>("Door_5", false);


                    }
                    return;
                case 3:
                    if (!veh.HasData("Door_0") || veh.GetData<bool>("Door_0") == false)
                    {
                        UsefullyRP.SendRoleplayAction(Client, "otvara vrata.");

                        Client.TriggerEvent("SetDoorStat", "OPEN", veh, 0);
                        veh.SetData<bool>("Door_0", true);

                        // NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_OPEN, veh, 0, true, false);
                    }
                    else
                    {
                        UsefullyRP.SendRoleplayAction(Client, "zatvara vrata.");
                        Client.TriggerEvent("SetDoorStat", "CLOSE", veh, 0);
                        veh.SetData<bool>("Door_0", false);

                        //  NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_SHUT, veh, 0, false);
                    }
                    return;
                case 4:
                    if (!veh.HasData("Door_1") || veh.GetData<bool>("Door_1") == false)
                    {
                        UsefullyRP.SendRoleplayAction(Client, "otvara vrata.");

                        veh.SetData<bool>("Door_1", true);

                        Client.TriggerEvent("SetDoorStat", "OPEN", veh, 1);
                        //NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_OPEN, veh, 1, true, false);
                    }
                    else
                    {
                        UsefullyRP.SendRoleplayAction(Client, "zatvara vrata.");

                        Client.TriggerEvent("SetDoorStat", "CLOSE", veh, 1);

                        veh.SetData<bool>("Door_1", false);
                        //  NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_SHUT, veh, 1, false);

                    }
                    return;
                case 5:
                    if (!veh.HasData("Door_2") || veh.GetData<bool>("Door_2") == false)
                    {
                        UsefullyRP.SendRoleplayAction(Client, "otvara vrata.");

                        veh.SetData<bool>("Door_2", true);

                        Client.TriggerEvent("SetDoorStat", "OPEN", veh, 2);

                        //   NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_OPEN, veh, 2, true, false);
                    }
                    else
                    {
                        Client.TriggerEvent("SetDoorStat", "CLOSE", veh, 2);

                        veh.SetData<bool>("Door_2", false);

                        UsefullyRP.SendRoleplayAction(Client, "zatvara vrata.");
                        // NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_SHUT, veh, 2, false);
                    }
                    return;
                case 6:
                    if (!veh.HasData("Door_3") || veh.GetData<bool>("Door_3") == false)
                    {
                        UsefullyRP.SendRoleplayAction(Client, "otvara vrata.");
                        Client.TriggerEvent("SetDoorStat", "OPEN", veh, 3);

                        veh.SetData<bool>("Door_3", true);

                        // NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_OPEN, veh, 3, true, false);
                    }
                    else
                    {
                        UsefullyRP.SendRoleplayAction(Client, "zatvara vrata.");
                        Client.TriggerEvent("SetDoorStat", "CLOSE", veh, 3);
                        veh.SetData<bool>("Door_3", false);

                        // NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_SHUT, veh, 3, false);
                    }
                    return;
                case 7:
                    NAPI.Task.Run(() =>
                    {
                        if (!Client.Exists) return;

                        if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
                        {
                            if (Client.Vehicle.Health < 300)
                            {
                                Main.DisplaySuccess(Client, NotifyType.Warning, NotifyPosition.CenterRight, Translation.head_notification_6);
                                return;
                            }

                            if (NAPI.Data.HasEntityData(Client.Vehicle, "vehicle_colision"))
                            {

                                Main.DisplaySuccess(Client, NotifyType.Warning, NotifyPosition.CenterRight, Translation.head_notification_7);
                                return;
                            }

                            if (Main.GetVehicleFuel(Client.Vehicle) <= 2)
                            {

                                Main.DisplaySuccess(Client, NotifyType.Warning, NotifyPosition.CenterRight, Translation.head_notification_8);
                                return;
                            }
                            if (Client.Vehicle.HasData("IsInHighEnd") && Client.Vehicle.GetData<dynamic>("IsInHighEnd") == true)
                            {

                                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate kljuc");
                                return;
                            }
                            if (Client.Vehicle.GetData<bool>("racveh") || Client.Vehicle.GetData<bool>("shipwar"))
                            {
                                return;
                            }
                            if (VehicleStreaming.GetEngineState(Client.Vehicle) == false)
                            {
                                VehicleStreaming.SetEngineState(Client.Vehicle, true);

                                Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.CenterRight, Translation.head_notification_9);
                            }
                            else
                            {
                                VehicleStreaming.SetEngineState(Client.Vehicle, false);
                            }

                            
                        }
                    }, delayTime: 1500);
                    return;
                case 8:
                    Client.TriggerEvent("CarBlinkers");
                    return;
                case 9:
                    string[] temp_mysql_data = PlayerVehicle.vehicle_data[playerid].json_vehicle_mods[index].ToString().Split('|');
                    if (PlayerVehicle.vehicle_data[playerid].json_vehicle_mods[index] != "")
                    {

                        for (int i = 0; i < 68; i++)
                        {
                            if (i == 66) continue;
                            if (i == 67) continue;
                            PlayerVehicle.vehicle_data[playerid].handle[index].SetMod(i, Convert.ToInt32(temp_mysql_data[i]));
                        }
                        NAPI.Task.Run(() =>
                        {

                            PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor = new Color(Convert.ToInt32(temp_mysql_data[68]), Convert.ToInt32(temp_mysql_data[69]), Convert.ToInt32(temp_mysql_data[70]));

                            if ((PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor.Red == 0 && PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor.Green == 0 && PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor.Blue == 0) || (PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor.Red == 255 && PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor.Green == 255 && PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor.Blue == 255))
                            {
                                API.Shared.SetVehicleNeonState(PlayerVehicle.vehicle_data[playerid].handle[index], false);
                            }
                            else
                            {
                                API.Shared.SetVehicleNeonState(PlayerVehicle.vehicle_data[playerid].handle[index], true);
                            }


                        }, delayTime: 2000);
                    }
                    
                    return;
            }
        }
    }


    [RemoteEvent("vehicleSelected")]
    public static void vehicleSelected(Player Client, params object[] arguments)
    {
        try
        {
            if (!(arguments[0] is Vehicle)) return;
            Vehicle veh = (Vehicle)arguments[0];
            int index = (int)arguments[1];
            if (veh == null || Client.Position.DistanceTo(veh.Position) > 5)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nema vozila pored Vas!");
                return;
            }
            switch (index)
            {

                case 0:

                    int playerid = Main.getIdFromClient(Client);
                    if (NAPI.Entity.DoesEntityExist(veh))
                    {

                        for (int index2 = 0; index2 < PlayerVehicle.MAX_PLAYER_VEHICLES; index2++)
                        {
                            if (PlayerVehicle.vehicle_data[playerid].state[index2] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index2].Exists && veh == PlayerVehicle.vehicle_data[playerid].handle[index2])
                            {
                                if (VehicleStreaming.GetLockState(veh) == false)
                                {
                                    VehicleStreaming.SetLockStatus(veh, true);
                                    Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.CenterRight, Translation.head_notification_2);
                                }
                                else
                                {
                                    VehicleStreaming.SetLockStatus(veh, false);
                                    Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.CenterRight, Translation.head_notification_1);
                                }
                                return;
                            }
                        }

                        for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                        {

                            if (FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_owned[i] != "Nobody" && FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_entity[i] == veh)
                            {
                                if (VehicleStreaming.GetLockState(veh) == false)
                                {
                                    VehicleStreaming.SetLockStatus(veh, true);

                                    Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.CenterRight, Translation.head_notification_2);
                                }
                                else
                                {
                                    VehicleStreaming.SetLockStatus(veh, false);

                                    Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.CenterRight, Translation.head_notification_1);
                                }
                                return;
                            }
                        }

                        
                    }
                    return;

                case 1:
                    if (!veh.HasData("Door_4") || veh.GetData<bool>("Door_4") == false)
                    {
                        if (VehicleStreaming.GetLockState(veh))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vozilo je zakljucano!");
                            return;
                        }
                        UsefullyRP.SendRoleplayAction(Client, "otvara haubu.");
                        // NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_OPEN, veh, 4, false);
                        Client.TriggerEvent("SetDoorStat", "OPEN", veh, 4);
                        veh.SetData<bool>("Door_4", true);
                    }
                    else
                    {
                        UsefullyRP.SendRoleplayAction(Client, "zatvara haubu.");
                        // NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_SHUT, veh, 4, false);
                        Client.TriggerEvent("SetDoorStat", "CLOSE", veh, 4);
                        veh.SetData<bool>("Door_4", false);

                    }

                    return;
                case 2:
                    if (!veh.HasData("Door_5") || veh.GetData<bool>("Door_5") == false)
                    {
                        UsefullyRP.SendRoleplayAction(Client, "otvara gepek.");

                        //  NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_OPEN, veh, 5, true, false);
                        Client.TriggerEvent("SetDoorStat", "OPEN", veh, 5);
                        veh.SetData<bool>("Door_5", true);


                    }
                    else
                    {
                        UsefullyRP.SendRoleplayAction(Client, "zatvara gepek.");
                        //  NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_SHUT, veh, 5, false);
                        Client.TriggerEvent("SetDoorStat", "CLOSE", veh, 5);
                        veh.SetData<bool>("Door_5", false);


                    }
                    return;
                case 3:
                    if (!veh.HasData("Door_0") || veh.GetData<bool>("Door_0") == false)
                    {
                        UsefullyRP.SendRoleplayAction(Client, "otvara vrata.");

                        Client.TriggerEvent("SetDoorStat", "OPEN", veh, 0);
                        veh.SetData<bool>("Door_0", true);

                        // NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_OPEN, veh, 0, true, false);
                    }
                    else
                    {
                        UsefullyRP.SendRoleplayAction(Client, "zatvara vrata.");
                        Client.TriggerEvent("SetDoorStat", "CLOSE", veh, 0);
                        veh.SetData<bool>("Door_0", false);

                        //  NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_SHUT, veh, 0, false);
                    }
                    return;
                case 4:
                    if (!veh.HasData("Door_1") || veh.GetData<bool>("Door_1") == false)
                    {
                        UsefullyRP.SendRoleplayAction(Client, "otvara vrata.");

                        veh.SetData<bool>("Door_1", true);

                        Client.TriggerEvent("SetDoorStat", "OPEN", veh, 1);
                        //NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_OPEN, veh, 1, true, false);
                    }
                    else
                    {
                        UsefullyRP.SendRoleplayAction(Client, "zatvara vrata.");

                        Client.TriggerEvent("SetDoorStat", "CLOSE", veh, 1);

                        veh.SetData<bool>("Door_1", false);
                        //  NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_SHUT, veh, 1, false);

                    }
                    return;
                case 5:
                    if (!veh.HasData("Door_2") || veh.GetData<bool>("Door_2") == false)
                    {
                        UsefullyRP.SendRoleplayAction(Client, "otvara vrata.");

                        veh.SetData<bool>("Door_2", true);

                        Client.TriggerEvent("SetDoorStat", "OPEN", veh, 2);

                        //   NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_OPEN, veh, 2, true, false);
                    }
                    else
                    {
                        Client.TriggerEvent("SetDoorStat", "CLOSE", veh, 2);

                        veh.SetData<bool>("Door_2", false);

                        UsefullyRP.SendRoleplayAction(Client, "zatvara vrata.");
                        // NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_SHUT, veh, 2, false);
                    }
                    return;
                case 6:
                    if (!veh.HasData("Door_3") || veh.GetData<bool>("Door_3") == false)
                    {
                        UsefullyRP.SendRoleplayAction(Client, "otvara vrata.");
                        Client.TriggerEvent("SetDoorStat", "OPEN", veh, 3);

                        veh.SetData<bool>("Door_3", true);

                        // NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_OPEN, veh, 3, true, false);
                    }
                    else
                    {
                        UsefullyRP.SendRoleplayAction(Client, "zatvara vrata.");
                        Client.TriggerEvent("SetDoorStat", "CLOSE", veh, 3);
                        veh.SetData<bool>("Door_3", false);

                        // NAPI.Native.SendNativeToPlayer(Client, Hash.SET_VEHICLE_DOOR_SHUT, veh, 3, false);
                    }
                    return;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }

    }


    [RemoteEvent("takeoutselected")]
    public void takeoutselected(Player Client, params object[] args)
    {
        try
        {
            
            Entity entity = (Entity)args[0];
            if (args.Length == 1) return;
            int seat2 = Convert.ToInt32(args[1]);
            switch (entity.Type)
            {
                case EntityType.Player:

                    if (seat2 == 1 || seat2 == 2)
                    {
                       

                        Player target = (Player)args[0];

                        if (AccountManage.GetPlayerGroup(Client) == 2)
                        {
                            goto next;
                        }
                        if (target.GetData<dynamic>("playerCuffed") == 0)
                        {
                            SendNotificationError(Client, "Igrac nema lisice.");
                            return;
                        }
                    next:
                        if (target.IsInVehicle)
                        {
                            SendNotificationError(Client, "Igrac je vec u vozilu.");
                            return;
                        }

                        Vehicle veh = Utils.GetClosestVehicle(target, 6.0f);

                        if (veh == null)
                        {
                            SendNotificationError(Client, "Niste pored vozila.");
                            return;
                        }

                        var p = NAPI.Pools.GetAllPlayers();
                        foreach (var i in p)
                        {
                            if (i.GetData<dynamic>("status") == true && NAPI.Player.IsPlayerInAnyVehicle(i) && veh.Handle == i.Vehicle.Handle && NAPI.Player.GetPlayerVehicleSeat(i) == seat2)
                            {
                                SendNotificationError(Client, "Sediste " + seat2 + " je zauzeto.");
                                return;
                            }
                        }

                        // If Player is drag
                        target.TriggerEvent("setFollow", false, Client);
                        target.SetData<dynamic>("BeingDragged", false);
                        target.TriggerEvent("freezeEx", false);
                        //

                        SendNotificationInfo(Client, "Stavili ste ~b~" + UsefullyRP.GetPlayerNameToTarget(target, Client) + "~w~ u vozilo.");
                        NAPI.Player.SetPlayerIntoVehicle(target, veh, seat2);
                        //   NAPI.Player.PlayPlayerAnimation(target, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "sit");
                        target.TriggerEvent("freezeEx", true);
                    }
                    else
                    {
                        SendNotificationError(Client, "Sediste moze biti samo 1 ili 2.");
                    }
                    break;
                case EntityType.Vehicle:
                    if (args.Length == 1) return;
                    Vehicle vehicle = (Vehicle)args[0];
                    int seat = Convert.ToInt32(args[1]);
                    if (!vehicle.Exists)
                    {
                        SendNotificationError(Client, "Nema vozila.");
                        return;
                    }
                    if (!Main.IsInRangeOfPoint(Client.Position, vehicle.Position, 5.0f))
                    {
                        SendNotificationError(Client, "Udaljili ste se od vozila.");
                        return;
                    }

                    foreach (var target in API.Shared.GetAllPlayers())
                    {
                        if (target.GetData<dynamic>("status") == true && target.GetData<dynamic>("status") == true)
                        {
                            if (target.IsInVehicle && vehicle == target.Vehicle)
                            {
                                if (target.VehicleSeat == seat)
                                {
                                    if (target.GetData<dynamic>("playerCuffed") == 1)
                                    {
                                        NAPI.Player.PlayPlayerAnimation(target, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.AllowPlayerControl | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "idle");
                                        target.TriggerEvent("freezeEx", true);
                                    }
                                    target.WarpOutOfVehicle();
                                    Police.DragPlayerToTarget(target, Client);
                                    SendNotificationInfo(target, "Policajac Vas je izbacio iz vozila.");
                                    SendNotificationInfo(target, "Izbacili ste igraca iz vozila.");
                                    return;
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

    }

    [RemoteEvent("fineselected")]
    public void fineselected(Player Client, params object[] args)
    {
        try
        {
            Entity entity = (Entity)args[0];
            switch (entity.Type)
            {
                case EntityType.Player:
                    if (args.Length == 1) return;
                    Player target = (Player)args[0];
                    int fine2 = Convert.ToInt32(args[1]);
                    
                    //Vehicle vehicle = Client.GetData<dynamic>("InteractMenu_vehicle_handle");
                    if (!target.Exists)
                    {
                        SendNotificationError(Client, "Pogresan ID.");
                        return;
                    }
                    if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 3.0f))
                    {
                        SendNotificationError(Client, "Predaleko ste.");
                        return;
                    }

                    target.SetData<dynamic>("ticketOffer", true);
                    target.SetData<dynamic>("ticketOfferBy", Client);
                    target.SetData<dynamic>("ticketOfferPrice", fine2);

                    Main.SendCustomChatMessasge(Client, "Kaznili ste " + AccountManage.GetCharacterName(target) + "~w~ u iznosu od $" + fine2.ToString("N0") + ".");
                    Main.SendInfoMessage(target, "" + FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_rank[AccountManage.GetPlayerRank(Client)] + " " + AccountManage.GetCharacterName(Client) + " Vam je izdao kaznu ~g~$" + fine2.ToString("N0") + "~w~.");
                    Main.SendInfoMessage(target, "Koristite ~g~O ~w~ kako biste platili kaznu.");

                    NAPI.Task.Run(() =>
                    {
                        if (!Client.Exists) return;
                        Client.ResetData("ticketOffer");
                        Client.ResetData("ticketOfferBy");
                        Client.ResetData("ticketOfferPrice");
                    }, delayTime: 60000);
                    break;
                case EntityType.Vehicle:
                    if (args.Length == 1) return;
                    Vehicle veh2 = (Vehicle)args[0];
                    int fine = Convert.ToInt32(args[1]);
                    
                    //Vehicle vehicle = Client.GetData<dynamic>("InteractMenu_vehicle_handle");
                    if (!veh2.Exists)
                    {
                        SendNotificationError(Client, "Ovo vozilo nije registrovano.");
                        return;
                    }
                    if (!Main.IsInRangeOfPoint(Client.Position, veh2.Position, 5.0f))
                    {
                        SendNotificationError(Client, "Predaleko ste.");
                        return;
                    }

                    var players = NAPI.Pools.GetAllPlayers();
                    foreach (var pl in players)
                    {
                        if (pl.GetData<dynamic>("status") == true)
                        {
                            for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                            {
                                if (PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].state[index] == 1 && PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index].Exists && PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index] == veh2)
                                {
                                    //int preco = (Client.GetData<dynamic>("new_interact_menu_ticket") + 1) * 500;
                                    Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Izdali ste kaznu u iznosu od ~g~$" + fine.ToString("N0") + "~w~ za vozilo " + PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].handle[index].DisplayName + " ,tablice: ~b~" + PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].plate[index] + "~w~.");
                                    Main.SendCustomChatMessasge(pl, "Na Vasem vozilu ~c~(" + PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].model[index] + ")~w~, tablice: ~y~" + Convert.ToString(PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].plate[index]) + "~w~ nalazi se kazna u iznosu od ~g~$" + fine.ToString("N0") + "~w~ koju je izdao ~b~Policijski sluzbenik " + AccountManage.GetCharacterName(Client) + "~w~.");

                                    if (VIP.GetPlayerVIP(pl) == 1)
                                    {
                                        int new_preco = fine - (int)(0.25 * fine);
                                        fine = new_preco;
                                        Main.SendMessageWithTagToPlayer(pl, "" + Main.EMBED_VIP + "[VIP]", "Posto ste VIP placate %20 manje ($" + new_preco + "): " + fine + "");
                                    }

                                    if (NAPI.Player.IsPlayerConnected(pl))
                                    {
                                        Main.GivePlayerMoneyBank(pl, -fine);
                                    }

                                    return;
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

        }
        catch (Exception e)
        {

            Console.WriteLine(e);

        }

    }





    //
    // Single Client
    //
    [RemoteEvent("keypress:O")]
    public void KeyPressO(Player Client)
    {
        if (AccountManage.GetPlayerConnected(Client))
        {
            if (Client.GetData<dynamic>("fishing") == true)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Ne mozete koristiti inventory dok pecate!");
                return;
            }
            ShowPlayerInteractMenu(Client);
        }
    }


    public static void ShowPlayerInteractMenu(Player Client)
    {

        int playerid = Main.getIdFromClient(Client);
        List<dynamic> menu_item_list = new List<dynamic>();


        if (Client.GetSharedData<dynamic>("Injured") == 1)
        {
            menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_35, Description = "~Y~Hitna pomoc:~w~ Pozovite 912.", RightBadge = "Alert" });
            if (Client.GetSharedData<dynamic>("InjuredTime") == 0)
            {
                menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_34, Description = "Prihvati smrt.", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
            }
            else
            {
                menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_34, Description = "Mozete prihvatiti smrt za " + Client.GetSharedData<dynamic>("InjuredTime") + ".", RightBadge = "Lock", Color = "Firebrick", HighlightColor = "White" });
            }
        }

        else
        {
            if (Client.GetData<dynamic>("character_backpack") == 1 || Client.GetData<dynamic>("character_backpack") == 2)
            {
                float weight = 0f;
                for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
                {
                    if (Inventory.player_inventory[playerid].sql_id[index] != -1)
                    {

                        int type = Inventory.player_inventory[playerid].type[index];

                        if (type > Inventory.itens_available.Count)
                        {
                            continue;
                        }

                        weight += Inventory.player_inventory[playerid].amount[index] * Inventory.itens_available[type].weight;
                    }
                }

                if (weight <= 15)
                {
                    menu_item_list.Add(new { Type = 1, Name = "Baci ranac", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
                    //Client.SetData<dynamic>("character_backpack", 0);
                    // AccountManage.UpdateBackpack(Client);
                }
                else
                {
                    menu_item_list.Add(new { Type = 1, Name = "Baci ranac ", Description = "", RightBadge = "Lock", Color = "Firebrick", HighlightColor = "White" });

                }

            }

            if (Client.CurrentWeapon != WeaponHash.Unarmed)
            {
                menu_item_list.Add(new { Type = 1, Name = "Vrati oruzije", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });

            }
            if (Client.HasData("Gloves_Box") && Client.GetData<dynamic>("Gloves_Box") == true)
            {
                menu_item_list.Add(new { Type = 1, Name = "Baci rukavice", Description = "", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
            }


            if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver && Client.Vehicle.Class != 13)
            {
                menu_item_list.Add(new { Type = 1, Name = "Radio stanica", Description = "", RightBadge = "" });
            }

            // Variables
            if (!Client.HasData("new_interact_menu_speedlimit"))
            {
                Client.SetData<dynamic>("new_interact_menu_speedlimit", 1);
            }
            if (!Client.HasData("new_interact_menu_badge"))
            {
                Client.SetData<dynamic>("new_interact_menu_badge", 0);
            }



            if (!Client.HasData("new_interact_menu_taximetro"))
            {
                Client.SetData<dynamic>("new_interact_menu_taximetro", 4);
            }

            int house_index = 0;
            foreach (var entrace in HouseSystem.HouseInfo)
            {
                if (Main.IsInRangeOfPoint(Client.Position, entrace.exterior, 2.0f) && Client.Dimension == 0)
                {
                    if (entrace.sell_house == 1)
                    {
                        menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_5, Description = "Kuca na prodaju: $" + entrace.price.ToString("N0") + "", RightLabel = "$" + entrace.price.ToString("N0"), Color = "Green", HighlightColor = "White" });
                        break;

                    }

                }

                house_index++;
            }



            // Invites
            if (Client.GetData<dynamic>("group_invite") != -1)
            {
                menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_10, Description = "", RightBadge = "Alert", Color = "Gold", HighlightColor = "Goldenrod" });
            }

            if (Client.HasData("ticketOffer") && Client.GetData<dynamic>("ticketOffer") == true)
            {
                if (AccountManage.GetPlayerConnected(Client.GetData<dynamic>("ticketOfferBy")))
                {
                    menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_12, Description = "", RightBadge = "Alert", Color = "Gold", HighlightColor = "Goldenrod" });
                    menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_13, Description = "", RightBadge = "Alert", Color = "Gold", HighlightColor = "Goldenrod" });
                }
            }

            if (Client.GetData<dynamic>("curar_offerPrice") != 0)
            {
                menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_14, Description = "", RightBadge = "Alert", Color = "Gold", HighlightColor = "Goldenrod" });
                menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_15, Description = "", RightBadge = "Alert", Color = "Gold", HighlightColor = "Goldenrod" });
            }

            if (AccountManage.GetPlayerGroup(Client) == 1)
            {

                List<string> list = new List<string>();

                foreach (var item in Police.Badge_List)
                {
                    if (item.ownersql == AccountManage.GetPlayerSQLID(Client))
                    {
                        foreach (var bg in item.bnumbers)
                        {
                            if (Client.GetSharedData<dynamic>("badgenumber") == bg)
                            {
                                list.Add("~b~#" + bg.ToString());
                            }
                            else
                            {
                                list.Add("#" + bg.ToString());
                            }

                        }
                        break;
                    }
                }
                if (list.Count > 0)
                {
                    menu_item_list.Add(new { Type = 2, Name = "Police Badge", Description = "", List = list, StartIndex = Client.GetData<dynamic>("new_interact_menu_badge") });

                }
            }
            // Vehicle
            if (Client.IsInVehicle)
            {

                if (Client.Vehicle.Class == 8)
                {
                    menu_item_list.Add(new { Type = 5, Name = Translation.INTERACT_PLAYER_MENU_17, Description = "", IsTicked = UsefullyRP.seatbelt[playerid] });
                }
                else
                {
                    menu_item_list.Add(new { Type = 5, Name = Translation.INTERACT_PLAYER_MENU_18, Description = "", IsTicked = UsefullyRP.seatbelt[playerid] });
                }
                if (Client.HasData("Hooker_Active") == false && Client.VehicleSeat == (int)VehicleSeat.RightFront && (PedHash)Client.Model == PedHash.FreemodeFemale01)
                {
                    if (Client.Vehicle.EngineStatus == false) { Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Morate ugasiti motor vozila"); }
                    foreach (var pl in NAPI.Player.GetPlayersInRadiusOfPlayer(3, Client))
                    {
                        if (pl.Exists && pl.Vehicle == Client.Vehicle && pl.VehicleSeat == (int)VehicleSeat.Driver)
                        {
                            menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_45, Description = "", RightBadge = "" });
                            Client.SetData<dynamic>("Hooker_Partner", pl);
                            pl.SetData<dynamic>("Hooker_Partner", Client);
                        }
                    }

                }
                else if (Client.GetData<dynamic>("Hooker_Active") == true)
                {
                    menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_46, Description = "", RightBadge = "" });
                }
                if (Client.VehicleSeat == (int)VehicleSeat.Driver)
                {



                    if (NAPI.Data.HasEntityData(Client.Vehicle, "MAX_VEHICLE_SLOT"))
                    {
                        if (NAPI.Data.GetEntityData(Client.Vehicle, "MAX_VEHICLE_SLOT") > 0)
                        {
                            if (NAPI.Vehicle.GetVehicleHealth(Client.Vehicle) > 0)
                            {

                                if (Client.Vehicle.Locked == false)
                                {
                                    menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_22, Description = "", RightBadge = "Car" });
                                }
                                else
                                {
                                    menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_22, Description = "", RightBadge = "Lock" });
                                }
                            }
                        }
                    }

                    List<string> list = new List<string>();

                    list.Add("Disable");

                    list.Add("20 KM/H");
                    list.Add("40 KM/H");
                    list.Add("60 KM/H");
                    list.Add("80 KM/H");
                    list.Add("100 KM/H");
                    list.Add("120 KM/H");
                    list.Add("140 KM/H");

                    menu_item_list.Add(new { Type = 2, Name = Translation.INTERACT_PLAYER_MENU_23, Description = "", List = list, StartIndex = Client.GetData<dynamic>("new_interact_menu_speedlimit") });

                }

                if (FactionManage.GetPlayerGroupID(Client) == 5)
                {
                    if (Client.VehicleSeat == (int)VehicleSeat.Driver && (NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)NAPI.Util.VehicleNameToModel("Taxi") || NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)NAPI.Util.VehicleNameToModel("Rentalbus")))
                    {
                        if (Client.Vehicle.HasData("TransportDuty"))
                        {
                            menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_24, Description = "" });
                        }
                        else
                        {
                            List<string> list = new List<string>();
                            for (int i = 1; i <= 200; i++) list.Add("$" + i + " /10 s");
                            menu_item_list.Add(new { Type = 2, Name = Translation.INTERACT_PLAYER_MENU_25, Description = "", List = list, StartIndex = Client.GetData<dynamic>("new_interact_menu_taximetro") });
                        }
                    }
                    else
                    {
                        menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_25, Description = "Morate biti u TAXI vozilu ili Rentalbusu kako biste koristili taksimetar.", RightBadge = "Lock" });
                    }
                }
            }
            // Client
            menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_26, Description = "", RightBadge = "Michael" });
            menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_27, Description = "", RightBadge = "Michael" });
            menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_28, Description = "", RightBadge = "Michael" });

            // Facção / Emprego
            /*  if (AccountManage.GetPlayerGroup(Client) == 0)
              {
                юю  menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_29, Description = "", RightBadge = "Lock", Color = "RoyalBlue", HighlightColor = "SteelBlue" });
              }
              else menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_29, Description = "", RightLabel = ">>", Color = "RoyalBlue", HighlightColor = "SteelBlue" }); */

            // Client
            if ((int)NAPI.Data.GetEntitySharedData(Client, "character_mask") != 0)
            {
                menu_item_list.Add(new { Type = 5, Name = Translation.INTERACT_PLAYER_MENU_31, Description = "", /*LeftBadge = "Clothes",*/ IsTicked = Client.GetSharedData<dynamic>("using_mask") });
            }

            var hats = NAPI.Data.GetEntitySharedData(Client, "character_hats");
            var hats_texture = NAPI.Data.GetEntitySharedData(Client, "character_hats_texture");
            var glasses = NAPI.Data.GetEntitySharedData(Client, "character_glasses");
            var glasses_texture = NAPI.Data.GetEntitySharedData(Client, "character_glasses_texture");

            var armor = NAPI.Data.GetEntitySharedData(Client, "character_armor");

            if ((int)armor != -1 && (int)armor != 0)
            {
                menu_item_list.Add(new { Type = 5, Name = Translation.INTERACT_PLAYER_MENU_49, Description = "", IsTicked = Client.GetData<dynamic>("armor_enable") });
            }


        }
        InteractMenu.CreateMenu(Client, "NEW_MENU_RESPONSE", "", Translation.INTERACT_PLAYER_MENU, false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundSprite: "shopui_title_darts");

    }

    public static void Responder_Menu(Player Client, int selectedIndex, String objectName, String valueList)
    {

        if (objectName == "Drop Gloves")
        {
            if (Client.HasData("Gloves_Box") && Client.GetData<dynamic>("Gloves_Box") == true)
            {
                BasicSync.DetachObject(Client);
                Client.SetData<dynamic>("Gloves_Box", false);
                for (int i = 0; i < Inventory.MAX_INVENTORY_ITENS; i++)
                {
                    if (Inventory.player_inventory[Client.Value].type[i] == 43 && Inventory.player_inventory[Client.Value].inuse[i] == 1)
                    {
                        Inventory.player_inventory[Client.Value].inuse[i] = 0;
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "skinuli ste rukavice.");
                        return;
                    }
                }
            }
        }
        if (objectName == "Drop Gun")
        {
            foreach (var w in Main.weapon_list)
            {
                if (Client.CurrentWeapon == WeaponHash.Unarmed) { return; }
                if (Client.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                {
                    if (FactionManage.GetPlayerGroupID(Client) == 1)
                    {
                        // Inventory.GiveItemToInventory(Client, Inventory.Item_Name_To_Type(w.model), 1, 0);
                    }
                    else
                    {
                        //Inventory.GiveItemToInventory(Client, Inventory.Item_Name_To_Type(w.model), 1);
                    }

                    //NAPI.Player.RemovePlayerWeapon(Client, NAPI.Util.WeaponNameToModel(w.model));
                    int AmmoCount = 0;
                    int model = 0;

                    if (w.classe == "Melee")
                    {
                        Inventory.ChangeInUseWeapon2(Client, Client.GetData<dynamic>("weapon_meele"), 0);

                        Client.SetData<dynamic>("weapon_meele", 0);
                    }
                    else if (w.classe == "Secundary")
                    {
                        Inventory.ChangeInUseWeapon2(Client, Client.GetData<dynamic>("secundary_weapon"), 0);

                        if (Client.GetData<dynamic>("secundary_ammunation") > 0)
                        {
                            if (w.type == "Machine Guns")
                            {
                                AmmoCount = Client.GetData<dynamic>("secundary_ammunation");
                                model = 7;
                                //  Inventory.GiveItemToInventory(Client, 7, Client.GetData<dynamic>("secundary_ammunation"));
                            }
                            else if (w.type == "Shotguns")
                            {
                                AmmoCount = Client.GetData<dynamic>("secundary_ammunation");
                                model = 5;

                                // Inventory.GiveItemToInventory(Client, 5, Client.GetData<dynamic>("secundary_ammunation"));
                            }
                        }

                        Client.SetData<dynamic>("secundary_weapon", 0);
                        Client.SetData<dynamic>("secundary_ammunation", 0);
                    }
                    else if (w.classe == "Primary")
                    {
                        Inventory.ChangeInUseWeapon2(Client, Client.GetData<dynamic>("primary_weapon"), 0);

                        if (Client.GetData<dynamic>("primary_ammunation") > 0)
                        {
                            if (w.type == "Assault Rifles")
                            {
                                // Inventory.GiveItemToInventory(Client, 4, Client.GetData<dynamic>("primary_ammunation"));
                                model = 4;

                                AmmoCount = Client.GetData<dynamic>("primary_ammunation");

                            }
                            else if (w.type == "Sniper Rifles")
                            {
                                model = 3;
                                // Inventory.GiveItemToInventory(Client, 3, Client.GetData<dynamic>("primary_ammunation"));
                                AmmoCount = Client.GetData<dynamic>("primary_ammunation");

                            }
                        }

                        Client.SetData<dynamic>("primary_weapon", 0);
                        Client.SetData<dynamic>("primary_ammunation", 0);
                    }
                    else if (w.classe == "pistol")
                    {
                        Inventory.ChangeInUseWeapon2(Client, Client.GetData<dynamic>("pistol_weapon"), 0);
                        if (Client.GetData<dynamic>("pistol_ammunation") > 0)
                        {
                            if (w.type == "Handguns")
                            {
                                //  Inventory.GiveItemToInventory(Client, 6, Client.GetData<dynamic>("pistol_ammunation"));
                                model = 6;
                                AmmoCount = Client.GetData<dynamic>("pistol_ammunation");

                            }
                        }
                        Client.SetData<dynamic>("pistol_weapon", 0);
                        Client.SetData<dynamic>("pistol_ammunation", 0);
                    }
                    else if (w.classe == "Tazer")
                    {
                        Inventory.ChangeInUseWeapon2(Client, Client.GetData<dynamic>("tazer_weapon"), 0);
                        Client.SetData<dynamic>("tazer_weapon", 0);
                    }
                    if (AmmoCount != 0)
                    {
                        if (AccountManage.GetPlayerGroup(Client) == 1)
                        {
                            Inventory.GiveItemToInventory(Client, model, AmmoCount, 0, 0);
                        }
                        else
                        {
                            Inventory.GiveItemToInventory(Client, model, AmmoCount, 1, 0);
                        }
                    }

                    //Client.TriggerEvent("removeAllWeapons");
                    //NAPI.Player.RemoveAllPlayerWeapons(Client);
                    WeaponManage.RemovePlayerWeaponAndAttachment(Client, NAPI.Util.WeaponNameToModel(w.model));
                    WeaponManage.SaveWeapons(Client);
                    //NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Unarmed, 1);
                   
                }
            }
        }
        else if (objectName == "Drop BackPack")
        {
            if (Client.GetData<dynamic>("character_backpack") == 1)
            {
                Inventory.GiveItemToInventory(Client, 9, 1);
            }
            else if (Client.GetData<dynamic>("character_backpack") == 2)
            {
                Inventory.GiveItemToInventory(Client, 10, 1);
            }
            Client.SetData<dynamic>("character_backpack", 0);
            BasicSync.DetachObject(Client);
            AccountManage.UpdateBackpack(Client);
        }
        else if (objectName == "Drop BackPack ")
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Bacili ste ranac.");
        }
        else if (objectName == "Radio station")
        {
            XMR.CMD_setstation(Client);
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_5)
        {
            int index = 0;
            foreach (var entrace in HouseSystem.HouseInfo)
            {
                if (Main.IsInRangeOfPoint(Client.Position, entrace.exterior, 2.0f) && Client.Dimension == 0)
                {
                    if (entrace.owner == AccountManage.GetPlayerSQLID(Client))
                    {
                        entrace.sell_house = 0;
                        HouseSystem.UpdateHouseLabel(index);
                        HouseSystem.SaveEntrace(index);
                        return;
                    }
                    if (entrace.sell_house != 1)
                    {
                        SendNotificationError(Client, "Ova kuca nije na prodaju.");
                        return;
                    }

                    if (HouseSystem.GetPlayerHouses(Client) > HouseSystem.GetPlayerHousesLimit(Client))
                    {
                        SendNotificationError(Client, "Ne mozete imati vise od " + HouseSystem.GetPlayerHousesLimit(Client) + " kuce.");
                        return;
                    }

                    if (entrace.vip == 1)
                    {
                        if (VIP.GetPlayerCredits(Client) < entrace.price)
                        {
                            SendNotificationError(Client, "Nemate dovoljno VIP poena za kupovinu kuce.");
                            return;
                        }
                        VIP.SetPlayerCredits(Client, VIP.GetPlayerCredits(Client) - entrace.price);
                    }
                    else
                    {
                        if (Main.GetPlayerMoney(Client) < entrace.price)
                        {
                            SendNotificationError(Client, "Nemate dovoljno novca za kupovinu kuce.");
                            return;
                        }

                        Main.GivePlayerMoney(Client, -entrace.price);

                        if (entrace.owner != -1)
                        {
                            Player Target = Main.FindPlayerFromSqlid(entrace.owner);

                            if (Target != null)
                            {
                                Main.SendCustomChatMessasge(Target, "[~g~KUCA~w~]~w~ Vasa kuca je prodata po ceni od: ~g~" + entrace.price + " ~w~.");
                                Main.GivePlayerMoney(Target, entrace.price);
                            }
                            else
                            {
                                Main.CreateMySqlCommand("UPDATE `characters` SET `bank`=`bank`+" + entrace.price + "");
                            }
                        }
                    }



                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_GROVE + "Property", "" + Main.EMBED_WHITE + "Kupili ste nekretninu, koristite " + Main.EMBED_LIGHTGREEN + "O" + Main.EMBED_WHITE + " za upravljanje.");
                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_GROVE + "Property", "" + Main.EMBED_WHITE + "Koristite " + Main.EMBED_LIGHTRED + " /help" + Main.EMBED_WHITE + " za vise informacija.");




                    // Entrce Name
                    entrace.owner = AccountManage.GetPlayerSQLID(Client);
                    entrace.owner_name = NAPI.Data.GetEntityData(Client, "character_name");
                    entrace.sell_house = 0;

                    HouseSystem.UpdateHouseLabel(index);
                    //

                    // teleport
                    Client.TriggerEvent("screenFadeOut", 500);
                    NAPI.Task.Run(() =>
                    {
                        if (!Client.Exists) return;

                        NAPI.Entity.SetEntityPosition(Client, entrace.interior);
                        Client.Rotation = new Vector3(0, 0, entrace.interior_a);
                        Client.Dimension = 500 + (uint)index;

                        Client.TriggerEvent("screenFadeIn", 1000);

                    }, delayTime: 500);
                    HouseSystem.SaveEntrace(index);
                    return;
                }
                index++;
            }
        }
        

        else if (objectName == Translation.INTERACT_PLAYER_MENU_6)
        {
            int index = 0;
            foreach (var entrace in HouseSystem.HouseInfo)
            {
                if (Main.IsInRangeOfPoint(Client.Position, entrace.exterior, 2.0f) && Client.Dimension == 0)
                {
                    if (entrace.owner != AccountManage.GetPlayerSQLID(Client))
                    {
                        SendNotificationError(Client, "Ne mozete to!.");
                        return;
                    }

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_GROVE + "Kuca", "" + Main.EMBED_WHITE + "Prodaliste kucu po ceni od $" + entrace.price.ToString("N0") + ". " + Main.EMBED_LIGHTRED + "Sav namestaj, ukljucujuci i sef i sadrzinu sefa vise nema.");

                    Main.GivePlayerMoney(Client, entrace.price);

                    // Entrce Name
                    entrace.owner = -1;
                    entrace.owner_name = "";
                    entrace.locked = 1;
                    entrace.safe = 0;

                    for (int i = 0; i < 9; i++)
                    {
                        entrace.key_acess[i] = "0";
                    }



                    for (int id = 0; id < 60; id++)
                    {
                        if (entrace.furniture_position[id].X != 0 && entrace.furniture_position[id].Y != 0)
                        {
                            Main.CreateMySqlCommand("DELETE FROM `furnitures` WHERE `id` = " + entrace.furniture_id[id] + ";");

                            entrace.furniture_id[id] = -1;
                            entrace.furniture_name[id] = "";
                            entrace.furniture_model_name[id] = "";
                            entrace.furniture_model[id] = 0;
                            entrace.furniture_price[id] = 0;
                            entrace.furniture_status[id] = 0;

                            entrace.furniture_position[id] = new Vector3(0, 0, 0);
                            entrace.furniture_rotation[id] = new Vector3(0, 0, 0);
                            entrace.furniture_handle[id].Delete();

                            HouseSystem.UpdateFurniture(index);
                        }
                    }

                    HouseSystem.UpdateHouseLabel(index);
                    //
                    HouseSystem.SaveEntrace(index);

                    return;
                }
                index++;
            }
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_8)
        {
            if (FactionManage.GetPlayerGroupID(Client) == 4)
            {
                int index = 0;
                foreach (var armazem in WerehouseManage.WereHouseData)
                {
                    if (Main.IsInRangeOfPoint(Client.Position, new Vector3(armazem.exterior_x, armazem.exterior_y, armazem.exterior_z), 3))
                    {
                        foreach (var pl in WerehouseManage.WereHouseData)
                        {
                            if (pl.ownerid == AccountManage.GetPlayerGroup(Client))
                            {
                                SendNotificationError(Client, "Vasa banda ne moze imati vise od 1 skladista!");
                                return;
                            }
                        }

                        if (armazem.ownerid != -1)
                        {
                            SendNotificationError(Client, "Ovo skladiste nije na prodaju.");
                            return;
                        }

                        if (Main.GetPlayerMoney(Client) > armazem.price)
                        {
                            armazem.ownerid = AccountManage.GetPlayerGroup(Client);
                            Main.SendCustomChatMessasge(Client, "Kupili ste skladiste " + armazem.name + " po ceni od ~g~$" + armazem.price.ToString("N0") + ".");
                            Main.SendCustomChatMessasge(Client, "Vasa organizacija sada ima pristup skladistu.");
                            WerehouseManage.UpdateWerehousePickup(index);
                            WerehouseManage.SaveWerehouse(index);
                            return;
                        }
                        else SendNotificationError(Client, "Nemate dovoljno novca za kupovinu ovog skladista.");
                    }
                    index++;
                }
            }
            else SendNotificationError(Client, "Niste lider.");
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_9)
        {

            int index = 0;
            foreach (var armazem in WerehouseManage.WereHouseData)
            {
                if (Main.IsInRangeOfPoint(Client.Position, new Vector3(armazem.exterior_x, armazem.exterior_y, armazem.exterior_z), 3))
                {
                    if (AccountManage.GetPlayerLeader(Client) == armazem.ownerid)
                    {

                        Main.SendCustomChatMessasge(Client, "Prodali ste skladiste i dobili 1/3 novca: ~g~$" + armazem.price / 3 + "~w~.");
                        armazem.safe = 0;
                        armazem.ownerid = -1;

                        for (int i = 0; i < 20; i++)
                        {
                            armazem.gun[i] = "Unknown";
                            armazem.gun_units[i] = 0;
                            armazem.gun_perm[i] = 0;
                            armazem.safe_gun[i] = "Unknown";
                        }
                        WerehouseManage.UpdateWerehousePickup(index);
                        WerehouseManage.SaveWerehouse(index);
                    }
                    else SendNotificationError(Client, "Niste vlasnik skladista.");
                    return;
                }
                index++;
            }
            SendNotificationError(Client, "Morate stajati na ulaznom markeru.");
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_26)
        {
            Translation.ShowPlayerStats(Client, Client);
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_27)
        {
            // ShowPlayerLicenses(Client, Client);
            pSelected(Client, Client, "showpas");
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_28)
        {
            ShowPlayerLicenses(Client, Client);
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_34)
        {
            if (Client.GetSharedData<dynamic>("Injured") != 1)
            {
                SendNotificationError(Client, "Povredjeni ste.");
                return;
            }

            if (Client.GetSharedData<dynamic>("Injured") == 1)
            {
                if (Client.GetSharedData<dynamic>("InjuredTime") > 0)
                {
                    SendNotificationError(Client, "Povredjeni ste, sacekajte ~b~" + Client.GetSharedData<dynamic>("InjuredTime") + "~w~ sekundi.");
                    return;
                }
                Main.sendToHospital(Client);
            }
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_35)
        {
            SendNotificationInfo(Client, "Povredjeni ste, pozovite Hitnu Pomoc na ~b~912~w~.");
            return;
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_10)
        {
            if (Client.GetData<dynamic>("group_invite") == -1)
            {
                SendNotificationError(Client, "Niste pozvani da se pridruzite organizaciji ili je poziv istekao.");
                return;
            }
            int group_id = Client.GetData<dynamic>("group_invite");
            Player inviteBy = Client.GetData<dynamic>("group_inviteBy");

            if (Main.IsPlayerLogged(inviteBy) == true)
            {
                FactionManage.SendFactionMessage(inviteBy, " ~g~" + UsefullyRP.GetPlayerNameToTarget(Client, inviteBy) + "~w~ je pozvan da se pridruzi Vasoj organizaciji.");
                FactionManage.SendFactionMessage(Client, " Pozvali ste ~g~" + UsefullyRP.GetPlayerNameToTarget(inviteBy, Client) + "~w~ da se pridruzi Vasoj organizaciji .");

                AccountManage.SetPlayerLeader(Client, 0);
                AccountManage.SetPlayerGroup(Client, group_id);
                AccountManage.SetPlayerRank(Client, 0);

                Main.SavePlayerInformation(Client);
                Client.SetData<dynamic>("group_invite", -1);
                Client.SetData<dynamic>("group_inviteBy", -1);
            }
            else
            {
                Client.SetData<dynamic>("group_invite", -1);
                Client.SetData<dynamic>("group_inviteBy", -1);

                SendNotificationError(Client, "Igrac koga ste pozvali vise nije dostupan.");
            }

            return;
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_11)
        {
            if (Client.GetData<dynamic>("group_invite") != -1)
            {
                SendNotificationError(Client, "Niste pozvani u organizaciju ili je poziv vec istekao.");
                return;
            }

            int group_id = Client.GetData<dynamic>("group_invite");
            Player inviteBy = Client.GetData<dynamic>("group_inviteBy");

            if (Main.IsPlayerLogged(inviteBy) == true)
            {
                Main.SendCustomChatMessasge(Client, "Odbili ste poziv Lidera " + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(inviteBy)] + " " + AccountManage.GetCharacterName(inviteBy) + ", da se pridruzite " + FactionManage.faction_data[group_id].faction_name + ".");
                Main.SendCustomChatMessasge(inviteBy, "~y~[INFO]:~w~ " + AccountManage.GetCharacterName(Client) + " je odbio da se pridruzi Vasoj organizaciji.");

                AccountManage.SetPlayerLeader(Client, 0);
                AccountManage.SetPlayerGroup(Client, group_id);
                AccountManage.SetPlayerRank(Client, 0);

                Client.SetData<dynamic>("group_invite", -1);
                Client.SetData<dynamic>("group_inviteBy", -1);
            }
            else
            {
                Client.SetData<dynamic>("group_invite", -1);
                Client.SetData<dynamic>("group_inviteBy", -1);
                Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Otkazali ste ponudu pridruzivanja organizaciji.");
                
            }
            return;
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_12)
        {
            if (Client.HasData("ticketOffer") && Client.GetData<dynamic>("ticketOffer") == true)
            {
                if (AccountManage.GetPlayerConnected(Client.GetData<dynamic>("ticketOfferBy")))
                {
                    if (Main.GetPlayerMoney(Client) < Client.GetData<dynamic>("ticketOfferPrice"))
                    {
                        SendNotificationError(Client, "Nemate $" + Client.GetData<dynamic>("ticketOfferPrice") + " da platite kaznu.");
                        return;
                    }
                    Player target = Client.GetData<dynamic>("ticketOfferBy");
                    Main.SendInfoMessage(target, "" + AccountManage.GetCharacterName(Client) + " je platio kaznu u iznosu od $" + Client.GetData<dynamic>("ticketOfferPrice") + ".");
                    Main.SendSuccessMessage(Client, "Prihvatili ste kaznu od " + AccountManage.GetCharacterName(target) + " u iznosu od $" + Client.GetData<dynamic>("ticketOfferPrice") + ".");

                    if (VIP.GetPlayerVIP(target) == 1)
                    {
                        int new_prison_time = Client.GetData<dynamic>("ticketOfferPrice") - (int)(0.25 * Client.GetData<dynamic>("ticketOfferPrice"));
                        Client.SetData<dynamic>("ticketOfferPrice", new_prison_time);
                        Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_VIP + "[VIP]", "Posto ste VIP, Vasa kazna je umanjena.");
                    }


                    Main.GivePlayerMoney(Client, -Client.GetData<dynamic>("ticketOfferPrice"));
                    Client.ResetData("ticketOffer");
                    Client.ResetData("ticketOfferBy");
                    Client.ResetData("ticketOfferPrice");
                    return;
                }
                else SendNotificationError(Client, "Igrac nije na serveru.");
            }
            else SendNotificationError(Client, "Nemate kazne.");
            Client.ResetData("ticketOffer");
            Client.ResetData("ticketOfferBy");
            Client.ResetData("ticketOfferPrice");
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_13)
        {
            if (Client.HasData("ticketOffer") && Client.GetData<dynamic>("ticketOffer") == true)
            {
                if (AccountManage.GetPlayerConnected(Client.GetData<dynamic>("ticketOfferBy")))
                {
                    Player target = Client.GetData<dynamic>("ticketOfferBy");
                    Main.SendInfoMessage(target, "~y~" + AccountManage.GetCharacterName(Client) + " je ~r~odbio da plati~w~ Vasu kaznu u iznosu od: ~g~$" + Client.GetData<dynamic>("ticketOfferPrice") + "~w~.");
                    Main.SendSuccessMessage(Client, "~r~ Odbili ste ~w~ da platite kaznu od ~y~" + AccountManage.GetCharacterName(target) + "~w~ u iznosu od: ~g~$" + Client.GetData<dynamic>("ticketOfferPrice") + ".");

                    Client.ResetData("ticketOffer");
                    Client.ResetData("ticketOfferBy");
                    Client.ResetData("ticketOfferPrice");
                    return;
                }
                else SendNotificationError(Client, "Igrac nije na serveru.");
            }
            else SendNotificationError(Client, "Nemate kazne.");
            Client.ResetData("ticketOffer");
            Client.ResetData("ticketOfferBy");
            Client.ResetData("ticketOfferPrice");
            return;
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_14)
        {
            if (Client.GetData<dynamic>("curar_offerPrice") != 0)
            {

                if (!API.Shared.IsPlayerConnected(Client.GetData<dynamic>("curar_offerBy")))
                {
                    Client.SetData<dynamic>("curar_offerBy", null);
                    Client.SetData<dynamic>("curar_offerPrice", 0);

                    SendNotificationError(Client, "Doktor koji Vam je ponudio lecenje vise nije na serveru ili Vam niko nije ponudio lecenje.");
                    return;
                }
                if (Main.GetPlayerMoney(Client) < Client.GetData<dynamic>("curar_offerPrice"))
                {
                    Client.SetData<dynamic>("curar_offerBy", null);
                    Client.SetData<dynamic>("curar_offerPrice", 0);
                    SendNotificationError(Client, "Nemate dovoljno novca.");
                    return;
                }

                if (!Main.IsInRangeOfPoint(Client.Position, NAPI.Entity.GetEntityPosition(Client.GetData<dynamic>("curar_offerBy")), 30))
                {
                    Client.SetData<dynamic>("curar_offerBy", null);
                    Client.SetData<dynamic>("curar_offerPrice", 0);
                    SendNotificationError(Client, "Niste pored doktora.");
                    return;
                }

                NAPI.Player.SetPlayerHealth(Client, 100);

                Main.SendSuccessMessage(Client, "Prihvatili ste medicinsku pomoc od ~y~" + AccountManage.GetCharacterName(Client.GetData<dynamic>("curar_offerBy")) + "~w~ by ~g~$" + Client.GetData<dynamic>("curar_offerPrice").ToString("N0") + "~w~.");
                Main.SendCustomChatMessasge(Client.GetData<dynamic>("curar_offerBy"), "Pacijent ~y~" + AccountManage.GetCharacterName(Client) + "~w~ je prihvatio lecenje po ceni od ~g~$" + Client.GetData<dynamic>("curar_offerPrice").ToString("N0") + "~w~.");

                Main.GivePlayerMoney(Client, -Client.GetData<dynamic>("curar_offerPrice"));
                Main.GivePlayerMoney(Client.GetData<dynamic>("curar_offerBy"), Client.GetData<dynamic>("curar_offerPrice"));

                Client.SetData<dynamic>("curar_offerBy", null);
                Client.SetData<dynamic>("curar_offerPrice", 0);
            }
            return;
        }
        else if (objectName == "Vrati oruzije")
        {
            Inventory.oruzijeinuse(Client);//ovde
            return;
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_15)
        {
            if (Client.GetData<dynamic>("curar_offerPrice") != 0)
            {
                Client.SetData<dynamic>("curar_offerBy", null);
                Client.SetData<dynamic>("curar_offerPrice", 0);
                SendNotification(Client, "Odbili ste medicinsku pomoc.");
            }
            return;
        }
        else if (objectName == "Police Badge")
        {
            int value = Client.GetData<dynamic>("new_interact_menu_badge");

            Police.SetCurrentBadge(Client, value);



        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_19)
        {
            PlayerVehicle.CMD_estacionar(Client);
            return;
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_45)
        {
            if (Client.IsInVehicle && Client.Vehicle.Class != 8 && Client.Vehicle.Class != 11 && Client.Vehicle.Class != 10 && Client.Vehicle.Class != 13 && Client.Vehicle.Class != 14 && Client.Vehicle.Class != 15 && Client.Vehicle.Class != 16 && Client.Vehicle.Class != 17 && Client.Vehicle.Class != 20)
            {
                List<dynamic> menu_item_list = new List<dynamic>();

                menu_item_list.Add(new { Type = 1, Name = "Oralni seks", Description = "", RightBadge = "", Color = "", HighlightColor = "Goldenrod" });
                menu_item_list.Add(new { Type = 1, Name = "Seks od pozadi", Description = "", RightBadge = "", Color = "", HighlightColor = "Goldenrod" });

                InteractMenu.CreateMenu(Client, "PLAYER_HOOKER_OFFER", objectName, "", false, NAPI.Util.ToJson(menu_item_list), false);

            }
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_46)
        {
            Player pl = Client.GetData<dynamic>("Hooker_Partner");
            if (pl.Exists)
            {
                pl.SetData<dynamic>("ForceAnim", false);
                pl.SetData<dynamic>("Hooker_Active", false);
                pl.SetData<dynamic>("Hooker_Partner", false);
                pl.StopAnimation();
            }
            if (Client.Exists)
            {
                Client.SetData<dynamic>("ForceAnim", false);
                Client.SetData<dynamic>("Hooker_Active", false);

                Client.SetData<dynamic>("Hooker_Partner", false);
                Client.StopAnimation();
            }

        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_21)
        {
            if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
            {
                Vehicle vehicle = Client.Vehicle;
                int playerid = Main.getIdFromClient(Client);


                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                {
                    if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
                    {
                        if (VehicleStreaming.GetLockState(vehicle) == false)
                        {
                            // VehicleStreaming.SetLockStatus(vehicle, true);
                            VehicleStreaming.SetLockStatus(vehicle, true);
                            Client.TriggerEvent("createNewHeadNotificationAdvanced", "Vozilo ~r~zakljucano~w~");
                        }
                        return;
                    }
                }

                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                {

                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_owned[i] != "Nobody" && FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_entity[i] == vehicle)
                    {
                        if (VehicleStreaming.GetLockState(vehicle) == false)
                        {

                            //  VehicleStreaming.SetLockStatus(vehicle, true);
                            VehicleStreaming.SetLockStatus(vehicle, true);

                            Client.TriggerEvent("createNewHeadNotificationAdvanced", "Vozilo ~r~zakljucano");
                        }
                        return;
                    }
                }

                

                return;

            }
            return;
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_20)
        {

            if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
            {
                Vehicle vehicle = Client.Vehicle;
                int playerid = Main.getIdFromClient(Client);

                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                {
                    if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index].Exists && vehicle == PlayerVehicle.vehicle_data[playerid].handle[index])
                    {
                        if (VehicleStreaming.GetLockState(vehicle) == true)
                        {
                            //VehicleStreaming.SetLockStatus(vehicle, false);
                            VehicleStreaming.SetLockStatus(vehicle, false);

                            Client.TriggerEvent("createNewHeadNotificationAdvanced", "Vozilo ~g~otkljucano");
                        }

                        return;
                    }
                }

                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                {

                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_owned[i] != "Nobody" && FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_entity[i] == vehicle)
                    {
                        if (VehicleStreaming.GetLockState(vehicle) == true)
                        {
                            //VehicleStreaming.SetLockStatus(vehicle, false);
                            VehicleStreaming.SetLockStatus(vehicle, false);

                            Client.TriggerEvent("createNewHeadNotificationAdvanced", "Vozilo ~g~otkljucano");
                        }

                        return;
                    }
                }

                

                return;

            }

            return;
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_22)
        {
            if (VehicleStreaming.GetLockState(Client.Vehicle) == true)
            {
                SendNotificationError(Client, "~c~Gepek vozila je zatvoren!");
                return;
            }
            VehicleInventory.ShowToPlayerVehicleInventory(Client);

            return;
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_23)
        {
            int value = Client.GetData<dynamic>("new_interact_menu_speedlimit");
            if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
            {
                if (value == 0)
                {
                    Client.SetData<dynamic>("SpeedLimit", false);
                    Client.TriggerEvent("speed_limiter_command", "off");
                    return;
                }

                value = value * 20;

                Client.TriggerEvent("speed_limiter_command", value);


            }
            return;
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_30)
        {
            int index = AccountManage.GetPlayerJob(Client);

            if (index == 0)
            {
                SendNotificationError(Client, "Nemate posao.");
                ShowPlayerInteractMenu(Client);
                return;
            }

            List<dynamic> menu_item_list = new List<dynamic>();

            if (index == 2)
            {
                // menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_36, Description = "Set a GPS to where you need to go to get started." });
                // menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_37, Description = "Ends your service, fading all blips, vehicles and markers related to your service." });
                menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_38, Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(Client, "PLAYER_JOB_MENU", objectName, "~g~Mehanicar", false, NAPI.Util.ToJson(menu_item_list), false, BackgroundColor: "");
            }
            else if (index == 3)
            {


                if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver && NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)NAPI.Util.VehicleNameToModel("Taxi"))
                {
                    if (Client.Vehicle.HasData("TransportDuty"))
                    {
                        menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_24, Description = "" });
                    }
                    else
                    {
                        List<string> list = new List<string>();
                        for (int i = 1; i <= 200; i++) list.Add("$" + i + " /10 s");
                        menu_item_list.Add(new { Type = 2, Name = Translation.INTERACT_PLAYER_MENU_25, Description = "", List = list, StartIndex = Client.GetData<dynamic>("new_interact_menu_taximetro") });
                    }
                }
                else
                {
                    menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_25, Description = "Niste u vozilu za prevoz putnika.", RightBadge = "Lock" });
                }
                //    menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_36, Description = "Set a GPS to where you need to go to get started." });
                //  menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_37, Description = "Ends your service, fading all blips, vehicles and markers related to your service." });
                menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_38, Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(Client, "PLAYER_JOB_MENU", objectName, "~g~Taksi", false, NAPI.Util.ToJson(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 4)
            {
                //   menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_36, Description = "Set a GPS to where you need to go to get started." });
                //  menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_37, Description = "Ends your service, fading all blips, vehicles and markers related to your service." });
                menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_38, Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(Client, "PLAYER_JOB_MENU", objectName, "~g~Komunalac", false, NAPI.Util.ToJson(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 6)
            {
                //    menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_36, Description = "Set a GPS to where you need to go to get started." });
                menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_39, Description = "GPS do mesta prodaje zita." });
                //    menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_37, Description = "Ends your service, fading all blips, vehicles and markers related to your service." });
                menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_38, Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(Client, "PLAYER_JOB_MENU", objectName, "~g~Farmer", false, NAPI.Util.ToJson(menu_item_list), false, BackgroundColor: "SeaGreen");
            }
            else if (index == 7)
            {

                //  menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_36, Description = "Set a GPS to where you need to go to get started." });
                //   menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_37, Description = "Ends your service, fading all blips, vehicles and markers related to your service." });
                menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_38, Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });
                InteractMenu.CreateMenu(Client, "PLAYER_JOB_MENU", objectName, "~g~Dostavljac produkata", false, NAPI.Util.ToJson(menu_item_list), false, BackgroundColor: "SeaGreen");
            }

        }
        // else if (objectName == Translation.INTERACT_PLAYER_MENU_37)
        //   {
        //       FoodDelivery.FinishallServices(Client);
        //      SendNotificationInfo(Client, "You have finished your file.");
        //   }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_25)
        {
            if (FactionManage.GetPlayerGroupID(Client) != 5)
            {
                InteractMenu_New.SendNotificationError(Client, "Niste u organizaciji!");
                return;
            }

            if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver && NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)NAPI.Util.VehicleNameToModel("Taxi"))
            {
                if (!Client.Vehicle.HasData("TransportDuty"))
                {
                    int price = Client.GetData<dynamic>("new_interact_menu_taximetro") + 1;

                    if (price < 1 || price > 200)
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Cena voznje ne moze biti manja od $1 ili veca od $200.");
                        return;
                    }

                    Client.Vehicle.SetData<dynamic>("TransportDuty", true);
                    Client.Vehicle.SetData<dynamic>("TransportPrice", price);
                    Client.Vehicle.SetData<dynamic>("TransportFee", 0);
                    Client.Vehicle.SetData<dynamic>("TransportTime", 0);
                    Client.Vehicle.SetData<dynamic>("TransportDriver", Client);

                    Main.SendCustomChatMessasge(Client, "Sada ste na duznosti i primacete pozive, cena voznje: ~y~$" + price.ToString("N0") + "~w~.");

                    if (!Client.HasData("announceTaxi"))
                    {
                        Client.SetData<dynamic>("announceTaxi", true);
                        NAPI.Task.Run(() =>
                        {
                            if (!Client.Exists) return;
                            Client.ResetData("announceTaxi");
                        }, delayTime: 10000);

                        Main.SendCustomChatToAll("~y~* Taxi vozac " + AccountManage.GetCharacterName(Client) + "~y~ je na duznosti, pozovite 914 da biste nazvali taksi. Cena: $" + price.ToString("N0") + " .");

                    }
                    SendNotificationInfo(Client, "Ugasili ste taksimetar.");
                }
            }
        }
        /*   else if (objectName == Translation.INTERACT_PLAYER_MENU_36)
           {
               int index = AccountManage.GetPlayerJob(Client);

               if (index == 0)
               {
                   Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Вы не во фракции...");
                   ShowPlayerInteractMenu(Client);
                   return;
               }

               if (index == 2)
               {
                   SendNotificationInfo(Client, "GPS Defined for Workplace: ~y~mechanical~w~");
                   Client.TriggerEvent("gps_set_loc", 1381.848f, -2078.385f);
               }
               else if (index == 3)
               {
                   SendNotificationInfo(Client, "GPS Defined for Workplace: ~y~Taxi~w~");
                   Client.TriggerEvent("gps_set_loc", 903.7703f, -173.278f);
               }
               else if (index == 4)
               {
                   SendNotificationInfo(Client, "GPS Defined for Workplace: ~y~Light~w~");
                   Client.TriggerEvent("gps_set_loc", 1381.848f, -2078.385f);
               }
               else if (index == 6)
               {
                   SendNotificationInfo(Client, "GPS Defined for Workplace: ~y~Farmer~w~");
                   Client.TriggerEvent("gps_set_loc", 2832.978f, 4571.757f);
               }
               else if (index == 7)
               {
                   SendNotificationInfo(Client, "GPS Defined for Workplace: ~y~Truck driver~w~");
                   Client.TriggerEvent("gps_set_loc", -355.8116f, -127.8554f);
               }
           } */

        else if (objectName == Translation.INTERACT_PLAYER_MENU_39)
        {
            SendNotificationInfo(Client, "GPS je postavljen do mesta za prodaju zita");
            Client.TriggerEvent("gps_set_loc", 2886.25f, 4386.166f);
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_24)
        {

            if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver && NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)NAPI.Util.VehicleNameToModel("Taxi"))
            {
                Client.TriggerEvent("update_taxi_fare", false, 0, 0, false);

                var players_in_vehicle = NAPI.Pools.GetAllPlayers();
                foreach (var i in players_in_vehicle)
                {
                    if (i.GetData<dynamic>("status") == true && Client.Vehicle == i.Vehicle && i.VehicleSeat != -1 && i.GetData<dynamic>("TaxiFee") > 0)
                    {
                        Main.GivePlayerMoney(i, -i.GetData<dynamic>("TaxiFee"));
                        i.SetData<dynamic>("TaxiFee", 0);
                        Main.SendCustomChatMessasge(i, "~y~*~w~ Taxi vozac je napustio vozilo, cena Vase voznje iznosi: ~g~$" + i.GetData<dynamic>("TaxiFee").ToString("N0") + ".");
                        i.TriggerEvent("update_taxi_fare", false, 0, 0, false);
                    }
                }

                Client.Vehicle.SetData<dynamic>("TransportDuty", false);
                Client.Vehicle.SetData<dynamic>("TransportPrice", 0);
                Client.Vehicle.SetData<dynamic>("TransportFee", 0);
                Client.Vehicle.SetData<dynamic>("TransportTime", 0);
                Client.Vehicle.ResetData("TransportDuty");

                SendNotificationInfo(Client, "~r~ Ugasili ste ~w~ taksimetar.");
            }
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_38)
        {
            if (AccountManage.GetPlayerJob(Client) != 0)
            {
                
                Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Nemate posao");
                AccountManage.SetPlayerJob(Client, 0);
            }
        }
        /*  else if (objectName == Translation.INTERACT_PLAYER_MENU_29)
          {
              int index = AccountManage.GetPlayerGroup(Client);

              if (index == 0)
              {
                  SendNotificationError(Client, "Вы не во фракции...");
                  ShowPlayerInteractMenu(Client);
                  return;
              } 

              List<dynamic> menu_item_list = new List<dynamic>();


              if (AccountManage.GetPlayerLeader(Client) == 1 || AccountManage.GetPlayerRank(Client) >= 8)
              {
                  menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_40, Description = FactionManage.faction_data[index].faction_motd, RightBadge = "Crown" });
                  menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_41, Description = "", RightBadge = "Crown" });
                  menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_42, Description = "", RightBadge = "Crown" });
                  menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_43, Description = "" });
                  if (FactionManage.GetPlayerGroupType(Client) == 4)
                  {
                      menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_47, Description = "" });
                      menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_48, Description = "" });

                  }
              }

              menu_item_list.Add(new { Type = 1, Name = Translation.INTERACT_PLAYER_MENU_44, Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });

              InteractMenu.CreateMenu(Client, "PLAYER_FACTION_MENU", objectName, "~b~" + FactionManage.faction_data[index].faction_name + "", false, NAPI.Util.ToJson(menu_item_list), false);
          } */
        else if (objectName == Translation.INTERACT_PLAYER_MENU_40)
        {
            int index = AccountManage.GetPlayerGroup(Client);

            InteractMenu.User_Input(Client, "interact_faction_motd", "Obavestenje", FactionManage.faction_data[index].faction_motd);

        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_41)
        {
            int index = AccountManage.GetPlayerGroup(Client);

            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {

                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `name`, `leader`, `group`, `group_rank` FROM characters WHERE `group` = " + index + " ORDER BY `group_rank` DESC;", Mainpipeline);
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    var count = 0;

                    List<dynamic> menu_item_list = new List<dynamic>();
                    while (reader.Read())
                    {
                        string name = reader.GetString("name");
                        int leader = reader.GetInt32("leader");
                        int group = reader.GetInt32("group");
                        int group_rank = reader.GetInt32("group_rank");



                        if (leader != 0)
                        {
                            menu_item_list.Add(new { Type = 1, Name = "~c~" + count + ".~s~ " + name.Replace("_", " ") + "", Description = "", RightBadge = "Crown", Color = "Gold", HighlightColor = "Goldenrod" });
                        }
                        else
                        {
                            menu_item_list.Add(new { Type = 1, Name = "~c~" + count + ".~s~ " + name.Replace("_", " ") + "", Description = "", RightLabel = "~c~" + FactionManage.faction_data[index].faction_rank[group_rank] + "" });
                        }


                        Client.SetData<dynamic>("ListTrack_" + count, name);
                        count++;
                    }
                    if (count == 0) return;
                    InteractMenu.CreateMenu(Client, "PLAYER_FACTION_MENU_MEMBER", objectName, "~b~" + FactionManage.faction_data[index].faction_name + "", false, NAPI.Util.ToJson(menu_item_list), false);

                }
                Mainpipeline.Close();
            }
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_42)
        {
            int index = AccountManage.GetPlayerGroup(Client);

            List<dynamic> menu_item_list = new List<dynamic>();
            for (int i = 0; i < FactionManage.MAX_FACTION_RANK; i++)
            {
                if (FactionManage.faction_data[index].faction_rank[i] == "Unknown")
                {
                    menu_item_list.Add(new { Type = 4, Name = "Rank " + i + ".", Description = "", RightLabel = "~c~Unknown" });
                }
                else
                {
                    menu_item_list.Add(new { Type = 4, Name = "Rank " + i + ".", Description = "", RightLabel = "~s~" + FactionManage.faction_data[index].faction_rank[i] + "" });
                }

            }
            InteractMenu.CreateMenu(Client, "PLAYER_FACTION_MENU_HIERARQUIA", objectName, "~b~" + FactionManage.faction_data[index].faction_name + " - Upravljaj rankom ", false, NAPI.Util.ToJson(menu_item_list), false);
        }

        else if (objectName == Translation.INTERACT_PLAYER_MENU_43)
        {
            int index = AccountManage.GetPlayerGroup(Client);

            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `name`, `leader`, `group`, `group_rank` FROM characters WHERE `group` = " + index + " ORDER BY `group_rank` DESC; ", Mainpipeline);
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    var count = 0;

                    List<dynamic> menu_item_list = new List<dynamic>();
                    while (reader.Read())
                    {
                        string name = reader.GetString("name");
                        int leader = reader.GetInt32("leader");
                        int group = reader.GetInt32("group");
                        int group_rank = reader.GetInt32("group_rank");

                        if (leader != 0)
                        {
                            menu_item_list.Add(new { Type = 1, Name = "~c~" + count + ".~s~ " + name.Replace("_", " ") + "", Description = "", RightBadge = "Crown", Color = "Gold", HighlightColor = "Goldenrod" });
                        }
                        else
                        {
                            menu_item_list.Add(new { Type = 1, Name = "~c~" + count + ".~s~ " + name.Replace("_", " ") + "", Description = "", RightLabel = "~c~" + FactionManage.faction_data[index].faction_rank[group_rank] + "" });

                        }
                        Client.SetData<dynamic>("ListTrack_" + count, name);
                        count++;
                    }
                    if (count == 0) return;
                    InteractMenu.CreateMenu(Client, "NULL", objectName, "~b~" + FactionManage.faction_data[index].faction_name + "", false, NAPI.Util.ToJson(menu_item_list), false);
                }
                Mainpipeline.Close();

            }
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_44)
        {
            NAPI.Data.SetEntityData(Client, "duty", 0);
            Main.UpdatePlayerClothes(Client);
            Client.SetData<dynamic>("duty", 0);
            Outfits.RemovePlayerDutyOutfit(Client);
            if (AccountManage.GetPlayerLeader(Client) == 1 && FactionManage.GetPlayerGroupType(Client) == 4)
            {
                FactionManage.DisbandTheFaction(FactionManage.GetPlayerGroupID(Client));
            }
            AccountManage.SetPlayerLeader(Client, 0);
            AccountManage.SetPlayerGroup(Client, 0);
            AccountManage.SetPlayerRank(Client, 0);
            Main.SavePlayerInformation(Client);
            Main.SendCustomChatMessasge(Client, "Napustili ste organizaciju i sada ste civil~w~.");
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_47)
        {
            InteractMenu.User_Input(Client, "change_faction_abbrev", "Skraceni naziv organizacije, npr: GSF", FactionManage.faction_data[FactionManage.GetPlayerGroupID(Client)].faction_abbrev);
        }
        else if (objectName == Translation.INTERACT_PLAYER_MENU_48)
        {
            InteractMenu.User_Input(Client, "change_faction_color", "Boja organizacije u HEX kodu, Ex: FFFF00", FactionManage.faction_data[FactionManage.GetPlayerGroupID(Client)].faction_color);
        }

    }

    [RemoteEvent("Cruise_Control_Set")]
    public void Cruise_Control_Remote(Player Client, bool state, int speed)
    {
        try
        {
            if (state)
            {
                if (int.TryParse(speed.ToString(), out int sp))
                {
                    Client.SetData<dynamic>("SpeedLimit", true);
                    Client.SetData<dynamic>("SpeedLimitValue", (int)(sp * 0.65));
                    Main.SendInfoMessage(Client, "Tempomat ukljucen. Koristite ~y~L~c~ da ukljucite ogranicenje.).");

                }
            }
            else
            {
                Main.SendErrorMessage(Client, "Nije moguce ukljuciti cruise control.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }


    }

    public static void ListItemMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        if (callbackId == "NEW_MENU_RESPONSE")
        {
            if (objectName == Translation.INTERACT_PLAYER_MENU_25)
            {
                Client.SetData<dynamic>("new_interact_menu_taximetro", valueIndex);
            }
            else if (objectName == Translation.INTERACT_PLAYER_MENU_23)
            {
                Client.SetData<dynamic>("new_interact_menu_speedlimit", valueIndex);
            }
            else if (objectName == "Police Badge")
            {
                Client.SetData<dynamic>("new_interact_menu_badge", valueIndex);
            }
        }
        else if (callbackId == "PLAYER_JOB_MENU")
        {
            Client.SetData<dynamic>("new_interact_menu_taximetro", valueIndex);
        }
        else if (callbackId == "NEW_MENU_VEHICLE_RESPONSE")
        {
            if (objectName == Translation.INTERACT_VEHICLE_MENU_8)
            {
                Client.SetData<dynamic>("new_interact_menu_ticket", valueIndex);
            }
            else if (objectName == Translation.INTERACT_VEHICLE_MENU_6)
            {
                Client.SetData<dynamic>("new_interact_vehicle_assento", valueIndex);
            }

        }
        else if (callbackId == "TARGET_MENU_RESPONSE")
        {
            if (objectName == Translation.INTERACT_PLAYER_TARGET_MENU_11)
            {
                Client.SetData<dynamic>("new_interact_menu_ticket_player", valueIndex);
            }
            else if (objectName == Translation.INTERACT_PLAYER_TARGET_MENU_13)
            {
                Client.SetData<dynamic>("new_interact_menu_arrest", valueIndex);
            }
            else if (objectName == Translation.INTERACT_PLAYER_TARGET_MENU_16)
            {
                Client.SetData<dynamic>("new_interact_menu_healing", valueIndex);
            }
            else if (objectName == Translation.INTERACT_PLAYER_TARGET_MENU_14)
            {
                Client.SetData<dynamic>("new_interact_menu_seat", valueIndex);
            }
        }

    }


    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "NEW_MENU_RESPONSE")
        {
            Responder_Menu(Client, selectedIndex, objectName, valueList);
        }
        else if (callbackId == "PLAYER_FACTION_MENU")
        {
            Responder_Menu(Client, selectedIndex, objectName, valueList);
        }
        else if (callbackId == "PLAYER_JOB_MENU")
        {
            Responder_Menu(Client, selectedIndex, objectName, valueList);
        }
        else if (callbackId == "NEW_MENU_VEHICLE_RESPONSE")
        {
            //Responder_Vehicle_Menu(Client, selectedIndex, objectName, valueList);
        }
        else if (callbackId == "TARGET_MENU_RESPONSE")
        {
            //Responder_Target_Menu(Client, selectedIndex, objectName, valueList);
        }
        else if (callbackId == "SEARCH_WHOLE_INVENTORY")
        {
            Player target = Client.GetData<dynamic>("interact_target");
            

            if (!API.Shared.IsPlayerConnected(target))
            {
                SendNotificationError(Client, "Pogresan ID.");
                return;
            }
            if (target.GetData<dynamic>("status") == false)
            {
                SendNotificationError(Client, "Pogresan ID.");
                return;
            }
            if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 5.0f))
            {
                SendNotificationError(Client, "Predaleko ste od osobe.");
                return;
            }
            try
            {
                string item = objectName;
                

                foreach (var w in Main.weapon_list)
                {

                    if (target.GetData<dynamic>("secundary_weapon") != 0)
                    {
                        if (w.classe == "Secundary" && w.model == item)
                        {
                            if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Inventory.Item_Name_To_Type(item), 1, Inventory.Max_Inventory_Weight(Client)))
                            {
                                return;
                            }
                            if (target.GetData<dynamic>("secundary_ammunation") > 0)
                            {

                                if (w.type == "Handguns")
                                {
                                    Inventory.GiveItemToInventory(Client, 6, target.GetData<dynamic>("secundary_ammunation"));
                                }
                                else if (w.type == "Machine Guns")
                                {
                                    Inventory.GiveItemToInventory(Client, 7, target.GetData<dynamic>("secundary_ammunation"));
                                }
                                else if (w.type == "Shotguns")
                                {
                                    Inventory.GiveItemToInventory(Client, 5, target.GetData<dynamic>("secundary_ammunation"));
                                }
                            }

                            Inventory.GiveItemToInventory(Client, Inventory.Item_Name_To_Type(w.model));
                            Inventory.RemoveItemByType(target, Inventory.Item_Name_To_Type(w.model), 1);


                            WeaponManage.RemovePlayerWeaponAndAttachment(target, target.GetData<dynamic>("secundary_weapon"));

                            target.SetData<dynamic>("secundary_weapon", 0);
                            target.SetData<dynamic>("secundary_ammunation", 0);
                            pSelected(Client, target, "Search");
                            return;
                        }
                    }
                    if (target.GetData<dynamic>("weapon_meele") != 0)
                    {
                        if (w.classe == "Melee" && w.model == item)
                        {
                            if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Inventory.Item_Name_To_Type(item), 1, Inventory.Max_Inventory_Weight(Client)))
                            {
                                return;
                            }
                            Inventory.RemoveItemByType(target, Inventory.Item_Name_To_Type(w.model), 1);
                            // Inventory.GiveItemToInventoryFromName(Client, item, 1);
                            Inventory.GiveItemToInventory(Client, Inventory.Item_Name_To_Type(w.model));
                            WeaponManage.RemovePlayerWeaponAndAttachment(target, target.GetData<dynamic>("weapon_meele"));

                            target.SetData<dynamic>("weapon_meele", 0);
                            pSelected(Client, target, "Search");
                            return;
                        }
                    }
                    if (target.GetData<dynamic>("primary_weapon") != 0)
                    {

                        if (w.classe == "Primary" && w.model == item)
                        {
                            if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Inventory.Item_Name_To_Type(item), 1, Inventory.Max_Inventory_Weight(Client)))
                            {
                                return;
                            }
                            if (target.GetData<dynamic>("primary_ammunation") > 0)
                            {

                                if (w.type == "Assault Rifles")
                                {
                                    Inventory.GiveItemToInventory(Client, 4, target.GetData<dynamic>("primary_ammunation"));
                                }
                                else if (w.type == "Sniper Rifles")
                                {
                                    Inventory.GiveItemToInventory(Client, 3, target.GetData<dynamic>("primary_ammunation"));
                                }
                            }
                            //Inventory.GiveItemToInventoryFromName(Client, item, 1);
                            Inventory.RemoveItemByType(target, Inventory.Item_Name_To_Type(w.model), 1);

                            Inventory.GiveItemToInventory(Client, Inventory.Item_Name_To_Type(w.model));
                            WeaponManage.RemovePlayerWeaponAndAttachment(target, target.GetData<dynamic>("primary_weapon"));
                            target.SetData<dynamic>("primary_weapon", 0);
                            target.SetData<dynamic>("primary_ammunation", 0);
                            pSelected(Client, target, "Search");
                            return;
                        }
                    }
                    if (target.GetData<dynamic>("pistol_weapon") != 0)
                    {
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Inventory.Item_Name_To_Type(item), 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }
                        if (w.classe == "pistol" && w.model == item)
                        {

                            if (target.GetData<dynamic>("pistol_ammunation") > 0)
                            {

                                if (w.type == "Handguns")
                                {
                                    Inventory.GiveItemToInventory(Client, 6, target.GetData<dynamic>("pistol_ammunation"));
                                }
                            }
                            Inventory.RemoveItemByType(target, Inventory.Item_Name_To_Type(w.model), 1);
                            //Inventory.GiveItemToInventoryFromName(Client, item, 1);
                            Inventory.GiveItemToInventory(Client, Inventory.Item_Name_To_Type(w.model));

                            WeaponManage.RemovePlayerWeaponAndAttachment(target, target.GetData<dynamic>("pistol_weapon"));
                            target.SetData<dynamic>("pistol_weapon", 0);
                            target.SetData<dynamic>("pistol_ammunation", 0);
                            pSelected(Client, target, "Search");
                            return;
                        }
                    }
                }


                int amount = Inventory.GetPlayerItemFromInventory(target, Inventory.Item_Name_To_Type(item));

                if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Inventory.Item_Name_To_Type(item), amount, Inventory.Max_Inventory_Weight(Client)))
                {
                    return;
                }

                

                if (amount < 1)
                {
                    SendNotificationError(Client, "Igrac vise nema tu stvar.");
                    return;
                }
                if (Inventory.GetInventoryIndexFromName(Client, "Radio") >= 1 && item == "Radio" && (Inventory.GetInventoryIndexFromName(Client, "Radio") - amount) <= 0)
                {
                    foreach (Player pl in NAPI.Pools.GetAllPlayers())
                    {
                        if (pl.GetData<dynamic>("status") == true)
                        {
                            if (pl.GetSharedData<dynamic>("RadioFreq") == Client.GetSharedData<dynamic>("RadioFreq") && pl != Client)
                            {
                                Client.TriggerEvent("v_disconnect", pl);
                                pl.TriggerEvent("v_disconnect", Client);
                            }
                        }
                    }
                    Client.SetSharedData("Radio_Status", false);
                    Client.SetSharedData("RadioFreq", 0);
                }

                Inventory.RemoveItem(target, item, amount);
                Inventory.GiveItemToInventoryFromName(Client, item, amount);
                UsefullyRP.SendRoleplayAction(Client, "kupuje " + item + ".");

               
                pSelected(Client, target, "Search");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }
        else if (callbackId == "TARGET_MENU_WEAPON")
        {
            Player target = Client.GetData<dynamic>("interact_target");
            if (!API.Shared.IsPlayerConnected(target))
            {
                SendNotificationError(Client, "Igrac vise nije na serveru.");
                return;
            }
            if (target.GetData<dynamic>("status") == false)
            {
                SendNotificationError(Client, "Igrac vise nije na serveru.");
                return;
            }
            if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 5.0f))
            {
                SendNotificationError(Client, "Predaleko ste.");
                return;
            }
            try
            {
                string item = objectName;
                
                foreach (var w in Main.weapon_list)
                {
                    if ((Int64)target.GetData<dynamic>("secundary_weapon") == Convert.ToInt64(item))
                    {
                        if (w.classe == "Secundary")
                        {

                            if (target.GetData<dynamic>("secundary_ammunation") > 0)
                            {

                                if (w.type == "Handguns")
                                {
                                    Inventory.GiveItemToInventory(Client, 6, target.GetData<dynamic>("secundary_ammunation"));
                                }
                                else if (w.type == "Machine Guns")
                                {
                                    Inventory.GiveItemToInventory(Client, 7, target.GetData<dynamic>("secundary_ammunation"));
                                }
                                else if (w.type == "Shotguns")
                                {
                                    Inventory.GiveItemToInventory(Client, 5, target.GetData<dynamic>("secundary_ammunation"));
                                }
                            }
                            Inventory.GiveItemToInventory(Client, Inventory.Item_Name_To_Type(w.model), 1);
                            NAPI.Player.RemovePlayerWeapon(target, target.GetData<dynamic>("secundary_weapon"));
                            target.SetData<dynamic>("secundary_weapon", 0);
                            target.SetData<dynamic>("secundary_ammunation", 0);
                            return;
                        }
                    }

                    if ((Int64)target.GetData<dynamic>("weapon_meele") == Convert.ToInt64(item))
                    {
                        if (w.classe == "Melee")
                        {
                            // Inventory.GiveItemToInventoryFromName(Client, item, 1);
                            Inventory.GiveItemToInventory(Client, Inventory.Item_Name_To_Type(w.model), 1);
                            NAPI.Player.RemovePlayerWeapon(target, target.GetData<dynamic>("weapon_meele"));
                            target.SetData<dynamic>("weapon_meele", 0);
                        }
                        return;
                    }

                    if ((Int64)target.GetData<dynamic>("primary_weapon") == Convert.ToInt64((item)))
                    {

                        if (w.classe == "Primary")
                        {

                            if (target.GetData<dynamic>("primary_ammunation") > 0)
                            {


                                if (w.type == "Handguns")
                                {
                                    Inventory.GiveItemToInventory(Client, 4, target.GetData<dynamic>("pistol_ammunation"));
                                }
                            }
                            //Inventory.GiveItemToInventoryFromName(Client, item, 1);
                            Inventory.GiveItemToInventory(Client, Inventory.Item_Name_To_Type(w.model), 1);
                            NAPI.Player.RemovePlayerWeapon(target, target.GetData<dynamic>("primary_weapon"));
                            target.SetData<dynamic>("primary_weapon", 0);
                            target.SetData<dynamic>("primary_ammunation", 0);
                            return;
                        }
                    }
                    if ((Int64)target.GetData<dynamic>("pistol_weapon") == Convert.ToInt64((item)))
                    {

                        if (w.classe == "pistol")
                        {

                            if (target.GetData<dynamic>("pistol_ammunation") > 0)
                            {

                                if (w.type == "Assault Rifles")
                                {
                                    Inventory.GiveItemToInventory(Client, 4, target.GetData<dynamic>("pistol_ammunation"));
                                }
                                else if (w.type == "Sniper Rifles")
                                {
                                    Inventory.GiveItemToInventory(Client, 3, target.GetData<dynamic>("pistol_ammunation"));
                                }
                            }
                            //Inventory.GiveItemToInventoryFromName(Client, item, 1);
                            Inventory.GiveItemToInventory(Client, Inventory.Item_Name_To_Type(w.model), 1);
                            NAPI.Player.RemovePlayerWeapon(target, target.GetData<dynamic>("pistol_weapon"));
                            target.SetData<dynamic>("pistol_weapon", 0);
                            target.SetData<dynamic>("pistol_ammunation", 0);
                            return;
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }


        }
        else if (callbackId == "TARGET_MENU_REMOVE_ITEM")
        {
            Player target = Client.GetData<dynamic>("interact_target");
            if (!API.Shared.IsPlayerConnected(target))
            {
                SendNotificationError(Client, "Igrac vise nije na serveru.");
                return;
            }
            if (target.GetData<dynamic>("status") == false)
            {
                SendNotificationError(Client, "Igrac vise nije na serveru.");
                return;
            }
            if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 5.0f))
            {
                SendNotificationError(Client, "Predaleko ste.");
                return;
            }

            string item = objectName;
            int amount = Inventory.GetPlayerItemFromInventory(target, Inventory.Item_Name_To_Type(item));


            if (amount < 1)
            {
                SendNotificationError(Client, "Igrac vise nema tu stvar.");
                return;
            }

            Inventory.RemoveItem(target, item, amount);
            Inventory.GiveItemToInventoryFromName(Client, item, amount);
            Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Oduzeli ste " + item + " od " + UsefullyRP.GetPlayerNameToTarget(target, Client) + ".");
            Main.DisplayErrorMessage(target, NotifyType.Info, NotifyPosition.BottomCenter, "Sluzbenik " + UsefullyRP.GetPlayerNameToTarget(Client, target) + " vam je oduzeo " + item + ".");

        }

    }

    public static void CheckBoxItemMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList, bool _checked)
    {
        try
        {
            if (callbackId == "NEW_MENU_RESPONSE")
            {
                if (objectName == Translation.INTERACT_PLAYER_MENU_18)
                {
                    UsefullyRP.CMD_seatbelt(Client);
                    return;
                }
                else if (objectName == Translation.INTERACT_PLAYER_MENU_17)
                {
                    UsefullyRP.CMD_capacete(Client);
                    return;
                }
                else if (objectName == Translation.INTERACT_PLAYER_MENU_32)
                {
                    var hats = NAPI.Data.GetEntitySharedData(Client, "character_hats");
                    var hats_texture = NAPI.Data.GetEntitySharedData(Client, "character_hats_texture");

                    if (Client.GetData<dynamic>("hats_enable") == true) // false
                    {
                        
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Skinuli ste kapu");
                        Client.SetAccessories(0, -1, 0);
                        Client.ClearAccessory(0);
                        Client.SetData<dynamic>("hats_enable", false);

                    }
                    else
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Stavili ste kapu");
                        
                        Client.SetAccessories(0, (int)hats, (int)hats_texture);
                        Client.SetData<dynamic>("hats_enable", true);
                    }

                    return;
                }
                else if (objectName == Translation.INTERACT_PLAYER_MENU_33)
                {
                    var glasses = NAPI.Data.GetEntitySharedData(Client, "character_glasses");
                    var glasses_texture = NAPI.Data.GetEntitySharedData(Client, "character_glasses_texture");


                    if (Client.GetData<dynamic>("glasses_enable") == true)
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Skinuli ste naocare");
                        
                        Client.SetAccessories(1, 0, 0);
                        Client.ClearAccessory(1);
                        Client.SetData<dynamic>("glasses_enable", false);
                    }
                    else
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Stavili ste naocare");
                        
                        Client.SetAccessories(1, (int)glasses, (int)glasses_texture);
                        Client.SetData<dynamic>("glasses_enable", true);
                    }

                    return;
                }
                else if (objectName == "Majica")
                {
                    if (Client.GetData<dynamic>("shirt_enable") == false)
                    {
                        Client.SetData<dynamic>("shirt_enable", true);
                        Main.UpdatePlayerClothes(Client);
                    }
                    else
                    {
                        Client.SetData<dynamic>("shirt_enable", false);
                        Main.UpdatePlayerClothes(Client);
                    }

                    return;
                }
                else if (objectName == "Pantalone")
                {
                    if (Client.GetData<dynamic>("legs_enable") == false)
                    {
                        Client.SetData<dynamic>("legs_enable", true);
                        Main.UpdatePlayerClothes(Client);
                    }
                    else
                    {
                        Client.SetData<dynamic>("legs_enable", false);
                        Main.UpdatePlayerClothes(Client);
                    }

                    return;
                }

                else if (objectName == "Obuca")
                {
                    if (Client.GetData<dynamic>("shoes_enable") == false)
                    {
                        Client.SetData<dynamic>("shoes_enable", true);
                        Main.UpdatePlayerClothes(Client);
                    }
                    else
                    {
                        Client.SetData<dynamic>("shoes_enable", false);
                        Main.UpdatePlayerClothes(Client);
                    }

                    return;
                }


                else if (objectName == Translation.INTERACT_PLAYER_MENU_31)
                {
                    UsefullyRP.CMD_Mascara(Client);
                    return;
                }
            }

        }
        catch (Exception e)
        {
            
            Console.WriteLine(e);

        }

        if (callbackId == "NEW_MENU_VEHICLE_RESPONSE")
        {

        }

    }

    public static void OnInputResponse(Player Client, String response, String inputtext)
    {
        if (response == "responser_money_user")
        {
            Player target = Client.GetData<dynamic>("UserMenuToTarget_handle");
            string name = Client.GetData<dynamic>("UserMenuToTarget_name");

            if (!API.Shared.IsPlayerConnected(target))
            {
                SendNotificationError(Client, "Igrac vise nije na serveru..");
                return;
            }

            if (target.GetData<dynamic>("status") == false)
            {
                SendNotificationError(Client, "Igrac vise nije na serveru..");
                return;
            }

            if (AccountManage.GetCharacterName(target) != name)
            {
                SendNotificationError(Client, "Igrac vise nije na serveru..");
                return;
            }

            if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 4.0f))
            {
                SendNotificationError(Client, "Predaleko ste.");
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                SendNotificationError(Client, "Mozete koristiti samo brojeve.");
                return;
            }

            int money = Convert.ToInt32(inputtext);

            if (money < 1 && money > 200000)
            {
                SendNotificationError(Client, "Vrednost ne sme biti manja od $1 ili veca od $200,000.");
                return;
            }


            if (inputtext.Contains("-"))
            {
                SendNotificationError(Client, "Vrednost ne sme biti manja od $1 ili veca od $200,000.");
                return;
            }


            if (Main.GetPlayerMoney(Client) > money)
            {
                Main.GivePlayerMoney(Client, -money);
                Main.GivePlayerMoney(target, money);

                List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
                foreach (Player alvo in proxPlayers)
                {
                    alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " vadi novcanik i daje novac " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + ".");
                }
            }
            else
            {
                SendNotificationError(Client, "Nemate toliko novca.");
                return;
            }
        }
    }
    public static void IndexChangeMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {

    }
    public static void SendNotification(Player Client, string Message)
    {
        
        Main.SendCustomChatMessasge(Client, Message);

    }
    public static void SendNotificationError(Player Client, string errorMessage)
    {
       
        Main.SendCustomChatMessasge(Client, "GRESKA: " + errorMessage);
    }
    public static void SendNotificationInfo(Player Client, string infoMessage)
    {
        
        Main.SendCustomChatMessasge(Client, "INFO: " + infoMessage);

    }


    /*public static void SendNotificationSuccess(Player Client, string successMessage)
    {
        Client.TriggerEvent("Notify", "~w~ " + successMessage);
    }*/


    //
    // ID Cards and License Shows
    //
    public static void ShowPlayerIDCard(Player Client, Player target)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Ime", Description = "", RightLabel = AccountManage.GetCharacterName(Client) });
        menu_item_list.Add(new { Type = 1, Name = "Godine", Description = "", RightLabel = Client.GetData<dynamic>("character_createrchar") });
        menu_item_list.Add(new { Type = 1, Name = "Prebivaliste", Description = "", RightLabel = "Los Santos" });
        InteractMenu.CreateMenu(target, "NOTHING_HAPPEND", AccountManage.GetCharacterName(Client), "~y~Identitet: " + AccountManage.GetCharacterName(Client) + "", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Gold");
    }


    //
    public static void ShowPlayerDistintivo(Player Client, Player target)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        if (AccountManage.GetPlayerGroup(Client) != 0)
        {
            menu_item_list.Add(new { Type = 1, Name = "Firma", Description = "", RightLabel = FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_name });
            menu_item_list.Add(new { Type = 1, Name = "Pozicija", Description = "", RightLabel = FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_rank[AccountManage.GetPlayerRank(Client)] });
        }
        InteractMenu.CreateMenu(target, "NOTHING_HAPPEND", AccountManage.GetCharacterName(Client), "~y~Identitet: " + AccountManage.GetCharacterName(Client) + "", false, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "Gold");
    }


    public static void ShowPlayerLicenses(Player Client, Player target)
    {
        playerCommands.ShowLicenses(Client, Client.Value.ToString());

    }


    [RemoteEvent("client_side_enable")]
    public static void client_side_enable(Player Client)
    {
        Client.SetData<dynamic>("client_side_enable", true);
    }

    public static async System.Threading.Tasks.Task Check_Player_ClientSide(Player Client)
    {

        if (!Client.HasData("client_side_enable"))
        {
            Client.TriggerEvent("Display_FilesMissing_Screen");
            Client.Kick();
            return;
        }
    }

    public static void Reset_ClientSide_Variable(Player Client)
    {
        Client.ResetData("client_side_enable");
    }
}

