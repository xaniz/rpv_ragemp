using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

class VehicleInventory : Script
{

    public static int MAX_VEHICLE_INVENTORY_SLOT = 24;
    public static void AddInventoryToVehicle(Vehicle vehicle, VehicleHash vehicle_hash)
    {
        int vehicleClass = NAPI.Vehicle.GetVehicleClass(vehicle_hash);

        float MAX_VEHICLE_SLOT = 0f;

        switch (vehicleClass)
        {
            case 0: MAX_VEHICLE_SLOT = 20f; break;
            case 1: MAX_VEHICLE_SLOT = 35f; break;
            case 2: MAX_VEHICLE_SLOT = 50f; break;
            case 3: MAX_VEHICLE_SLOT = 35f; break;
            case 4: MAX_VEHICLE_SLOT = 30f; break;
            case 5: MAX_VEHICLE_SLOT = 20f; break;
            case 6: MAX_VEHICLE_SLOT = 25f; break;
            case 7: MAX_VEHICLE_SLOT = 15f; break;
            case 8: MAX_VEHICLE_SLOT = 10f; break;
            case 9: MAX_VEHICLE_SLOT = 40f; break;
            case 10: MAX_VEHICLE_SLOT = 100f; break;
            case 11: MAX_VEHICLE_SLOT = 65f; break;
            case 12: MAX_VEHICLE_SLOT = 70f; break;
            case 14: MAX_VEHICLE_SLOT = 65f; break;
            case 15: MAX_VEHICLE_SLOT = 100f; break;
            case 17: MAX_VEHICLE_SLOT = 50f; break;
            case 18: MAX_VEHICLE_SLOT = 40f; break;
            case 19: MAX_VEHICLE_SLOT = 100f; break;
            case 20: MAX_VEHICLE_SLOT = 1000f; break;
        }

        switch (vehicle.DisplayName)
        {
            case "Caracara2":
                MAX_VEHICLE_SLOT = 40f;
                break;
            case "Tulip":
                MAX_VEHICLE_SLOT = 30f;
                break;
            default:
                break;
        }

        if (MAX_VEHICLE_SLOT != 0f)
        {

            NAPI.Data.SetEntityData(vehicle, "MAX_VEHICLE_SLOT", MAX_VEHICLE_SLOT);

            for (int i = 0; i < MAX_VEHICLE_INVENTORY_SLOT; i++)
            {
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_index", i);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_sqlid", -1);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_type", 0);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_slotid", -1);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_amount", 0);
            }
        }
    }

    public static void LoadVehicleInventoryItens(Player Client, Vehicle vehicle, int vehicleSQLID)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `vehicle_inventory` WHERE `vehicle` = '" + vehicleSQLID + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                var index = 0;
                while (reader.Read())
                {

                    NAPI.Data.SetEntityData(vehicle, "trunk_item_" + index + "_index", index);
                    NAPI.Data.SetEntityData(vehicle, "trunk_item_" + index + "_sqlid", reader.GetInt32("id"));
                    NAPI.Data.SetEntityData(vehicle, "trunk_item_" + index + "_type", reader.GetInt32("type"));
                    NAPI.Data.SetEntityData(vehicle, "trunk_item_" + index + "_slotid", reader.GetInt32("slotid"));
                    NAPI.Data.SetEntityData(vehicle, "trunk_item_" + index + "_amount", reader.GetInt32("amount"));

                    index++;
                }

            }
            Mainpipeline.Close();
        }

    }

    public static bool Check_VehicleInventoryWeight_With_ItemAmount(Player Client, Vehicle vehicle, int type, int amount, float MAX_HEIGHT)
    {
        //Main.SendErrorMessage(Client, "O inventário do veículo não tem espaço suficiente para carregar este item.");

        float height = 0.00f;
        for (int i = 0; i < MAX_VEHICLE_INVENTORY_SLOT; i++)
        {
            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0 && NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
            {
                height += Inventory.itens_available[NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type")].weight;
            }
        }

        float free_space = MAX_HEIGHT - height;

        height += amount * Inventory.itens_available[type].weight;

        if (height > MAX_HEIGHT)
        {
            Main.SendErrorMessage(Client, "Nemate dovoljno mesta!");
            return true;
        }
        return false;
    }


    public static void RemoveVehicleInventory(Vehicle vehicle)
    {
        if (NAPI.Data.HasEntityData(vehicle, "MAX_VEHICLE_SLOT")) NAPI.Data.ResetEntityData(vehicle, "MAX_VEHICLE_SLOT");

        if (vehicle.HasData("veh_sql"))
        {
            Main.CreateMySqlCommand("DELETE FROM `vehicle_inventory` WHERE `vehicle` = '" + vehicle.GetData<dynamic>("veh_sql") + "';");
            for (int i = 0; i < MAX_VEHICLE_INVENTORY_SLOT; i++)
            {
                if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_index")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_index");
                if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_sqlid")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_sqlid");
                if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_type")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_type");
                if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_slotid")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_slotid");
                if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_amount")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_amount");
            }
            return;
        }

        for (int i = 0; i < MAX_VEHICLE_INVENTORY_SLOT; i++)
        {
            if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_index")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_index");
            if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_sqlid")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_sqlid");
            if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_type")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_type");
            if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_slotid")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_slotid");
            if (NAPI.Data.HasEntityData(vehicle, "trunk_item_" + i + "_amount")) NAPI.Data.ResetEntityData(vehicle, "trunk_item_" + i + "_amount");
        }
    }

    public static void AddItemToVehicleInventory(Vehicle vehicle, int slotid, int item_type, int item_amount)
    {

        if (vehicle.HasData("veh_sql"))
        {

            for (int i = 0; i < MAX_VEHICLE_INVENTORY_SLOT; i++)
            {
                if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") == 0)
                {
                    using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                    {
                        try
                        {
                            

                            Mainpipeline.Open();
                            string query = "INSERT INTO vehicle_inventory (`vehicle`, `type`, `amount`,`slotid`)" + " VALUES ('" + vehicle.GetData<dynamic>("veh_sql") + "', '" + item_type + "', '" + item_amount + "','" + slotid + "')";
                            MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                            myCommand.ExecuteNonQuery();
                            long last_inventory_id = myCommand.LastInsertedId;

                            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_index", i);
                            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_sqlid", last_inventory_id);
                            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_type", item_type);
                            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_slotid", slotid);
                            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_amount", item_amount);
                            Mainpipeline.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);

                        }
                    }
                    return;
                }
            }
            return;
        }

        for (int i = 0; i < MAX_VEHICLE_INVENTORY_SLOT; i++)
        {
            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") == 0)
            {
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_index", i);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_type", item_type);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_slotid", slotid);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + i + "_amount", item_amount);
                return;
            }
        }

    }

    public static void RemoveItemFromVehicleInventory(Vehicle vehicle, int id, int amount = 0)
    {
        if (vehicle.HasData("veh_sql"))
        {
            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") >= 2)
            {

                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_amount", NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") - amount);
                Main.CreateMySqlCommand("UPDATE vehicle_inventory SET `amount` = " + NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") + " WHERE `vehicle` = " + vehicle.GetData<dynamic>("veh_sql") + " AND `id` = " + vehicle.GetData<dynamic>("trunk_item_" + id + "_sqlid") + ";");

                if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") < 1)
                {
                    NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_type", 0);
                    NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_amount", 0);
                    NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_slotid", -1);
                    Main.CreateMySqlCommand("DELETE FROM vehicle_inventory WHERE `id` = " + vehicle.GetData<dynamic>("trunk_item_" + id + "_sqlid") + ";");
                }
            }
            else
            {

                Main.CreateMySqlCommand("DELETE FROM vehicle_inventory WHERE `vehicle` = " + vehicle.GetData<dynamic>("veh_sql") + " AND `id` = " + vehicle.GetData<dynamic>("trunk_item_" + id + "_sqlid") + ";");
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_type", 0);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_amount", 0);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_slotid", -1);
            }
            return;
        }

        if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") >= 2)
        {
            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_amount", NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") - amount);

            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + id + "_amount") < 1)
            {

                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_type", 0);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_amount", 0);
                NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_slotid", -1);

            }
        }
        else
        {
            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_type", 0);
            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_amount", 0);
            NAPI.Data.SetEntityData(vehicle, "trunk_item_" + id + "_slotid", -1);

        }

    }

    public static Vehicle HasVehicleInventory(Vehicle handle)
    {
        if (handle != null && handle.Exists)
        {
            if (NAPI.Data.HasEntityData(handle, "MAX_VEHICLE_SLOT"))
            {
                if (NAPI.Data.GetEntityData(handle, "MAX_VEHICLE_SLOT") > 0)
                {
                    if (NAPI.Vehicle.GetVehicleHealth(handle) > 0)
                    {
                        return handle;
                    }
                }
            }
        }
        return null;
    }

    public static Vehicle HasVehicleInventory(Player handle)
    {

        if (!handle.IsInVehicle)
        {

            /*foreach (var vehicle in NAPI.Pools.GetAllVehicles())
            {

                if (NAPI.Data.HasEntityData(vehicle, "MAX_VEHICLE_SLOT") && Main.IsInRangeOfPoint(handle.Position, vehicle.Position, 5.0f))
                {
                    if (NAPI.Data.GetEntityData(vehicle, "MAX_VEHICLE_SLOT") > 0)
                    {
                        if (NAPI.Vehicle.GetVehicleHealth(vehicle) > 0)
                        {

                            bool can_acess = false;


                            if (vehicle.HasData("Mashin_Owner"))
                            {
                                can_acess = true;
                            }

                            if (vehicle.Class == 18)
                            {
                                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                                {
                                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(handle)].faction_vehicle_entity[i] == vehicle)
                                    {
                                        //handle.SendChatMessage("sucess_1");
                                        return vehicle;
                                    }
                                }

                            }

                            for (int b = 0; b < RentVehicle.MAX_RENT_VEHICLES; b++)
                            {
                                if (RentVehicle.vehicle_rent_list[b].vehicle_free == true && RentVehicle.vehicle_rent_list[b].vehicle_entity == vehicle)
                                {
                                    can_acess = true;
                                }
                            }

                            if (can_acess == false)
                            {
                                return null;
                            }

                            return vehicle;
                        }
                    }
                }
            }*/
        }

        if (handle.IsInVehicle)
        {
            if (NAPI.Data.HasEntityData(handle.Vehicle, "MAX_VEHICLE_SLOT"))
            {
                if (NAPI.Data.GetEntityData(handle.Vehicle, "MAX_VEHICLE_SLOT") > 0)
                {
                    if (NAPI.Vehicle.GetVehicleHealth(handle.Vehicle) > 0)
                    {
                        return handle.Vehicle;
                    }
                }
                /*if (NAPI.Data.GetEntityData(handle.Vehicle, "MAX_VEHICLE_SLOT") > 0)
                {
                    if (NAPI.Vehicle.GetVehicleHealth(handle.Vehicle) > 0)
                    {
                        bool can_acess = false;
                        foreach (var Player in NAPI.Pools.GetAllPlayers())
                        {
                            if (Client.GetData<dynamic>("status") == true)
                            {
                                for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                                {
                                    if (PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].state[index] == 1)
                                    {
                                        if (PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].handle[index].Exists && PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].handle[index] == handle.Vehicle)
                                        {
                                            can_acess = true;
                                        }
                                    }
                                }
                            }
                        }

                        if (handle.Vehicle.Class == 18)
                        {
                            for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                            {
                                if (FactionManage.faction_data[AccountManage.GetPlayerGroup(handle)].faction_vehicle_entity[i] == handle.Vehicle)
                                {
                                    //handle.SendChatMessage("sucess_1");
                                    return handle.Vehicle;
                                }
                            }
                        }

                        for (int b = 0; b < RentVehicle.MAX_RENT_VEHICLES; b++)
                        {
                            if (RentVehicle.vehicle_rent_list[b].vehicle_free == true && RentVehicle.vehicle_rent_list[b].vehicle_entity == handle.Vehicle)
                            {
                                can_acess = true;
                            }
                        }

                        if (can_acess == false)
                        {
                            return null;
                        }

                        return handle.Vehicle;
                    }
                }*/
            }
        }
        return null;
    }



    public static void ShowToPlayerVehicleInventory(Player handle)
    {

        if (HasVehicleInventory(handle) == null)
        {
            //handle.SendChatMessage("siktir");
            return;
        }

        Vehicle vehicle = HasVehicleInventory(handle);

        if (vehicle == null || VehicleStreaming.GetLockState(vehicle) == true)
        {
            return;
        }
        handle.SetData<dynamic>("vehicle_handle_inv", vehicle);

        int playerid = Main.getIdFromClient(handle);
        List<dynamic> temp_inventory = new List<dynamic>();
        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
        {
            if (Inventory.player_inventory[playerid].sql_id[index] != -1)
            {

                int type = Inventory.player_inventory[playerid].type[index];

                if (type > Inventory.itens_available.Count)
                {
                    continue;
                }


                temp_inventory.Add(new { slotid = Inventory.player_inventory[playerid].slotid[index], sqlid = Inventory.player_inventory[playerid].sql_id[index], name = Inventory.itens_available[type].name, type = type, amount = Inventory.player_inventory[playerid].amount[index], weight = Inventory.itens_available[type].weight, Useable = Inventory.itens_available[type].Useable, inuse = Inventory.player_inventory[playerid].inuse[index], dropable = Inventory.player_inventory[playerid].dropable[index], picture = "./img/" + Inventory.itens_available[type].picture + ".png" });
            }
        }

        int itens = 0;
        List<dynamic> temp_vehicle_inventory = new List<dynamic>();
        for (int i = 0; i < MAX_VEHICLE_INVENTORY_SLOT; i++)
        {
            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0)
            {
                if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
                {
                    int type = NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type");

                    temp_vehicle_inventory.Add(new { sqlid = vehicle.GetData<dynamic>("trunk_item_" + i + "_index"), slotid = vehicle.GetData<dynamic>("trunk_item_" + i + "_slotid"), name = Inventory.itens_available[type].name, type = type, amount = NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount"), Useable = Inventory.itens_available[NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type")].Useable, inuse = 0, dropable = 1, weight = Inventory.itens_available[type].weight, picture = "./img/" + Inventory.itens_available[type].picture + ".png" });
                }
                itens++;
            }
        }

        
        handle.TriggerEvent("Display_Player_Storage", NAPI.Util.ToJson(temp_inventory), NAPI.Util.ToJson(temp_vehicle_inventory), Inventory.GetInventoryMaxHeight(handle), vehicle.GetData<dynamic>("MAX_VEHICLE_SLOT"));
        handle.SetData<dynamic>("inVehicleInventory", true);
        handle.SetData<dynamic>("vehicle_handle_inv", vehicle);
    }


    public static void ShowToPlayerVehicleInventory(Player handle, Vehicle vehicle)
    {

        if (vehicle == null)
        {
            return;
        }
        //  Vehicle vehicle = HasVehicleInventory(handle);
        if (vehicle == null || VehicleStreaming.GetLockState(vehicle) == true)
        {
            return;
        }
        handle.SetData<dynamic>("vehicle_handle_inv", vehicle);

        int playerid = Main.getIdFromClient(handle);
        List<dynamic> temp_inventory = new List<dynamic>();

        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
        {
            if (Inventory.player_inventory[playerid].sql_id[index] != -1)
            {

                int type = Inventory.player_inventory[playerid].type[index];

                if (type > Inventory.itens_available.Count)
                {
                    continue;
                }

                temp_inventory.Add(new { slotid = Inventory.player_inventory[playerid].slotid[index], sqlid = Inventory.player_inventory[playerid].sql_id[index], name = Inventory.itens_available[type].name, type = type, amount = Inventory.player_inventory[playerid].amount[index], weight = Inventory.itens_available[type].weight, Useable = Inventory.itens_available[type].Useable, inuse = Inventory.player_inventory[playerid].inuse[index], dropable = Inventory.player_inventory[playerid].dropable[index], picture = "./img/" + Inventory.itens_available[type].picture + ".png" });
            }
        }

        int itens = 0;
        List<dynamic> temp_vehicle_inventory = new List<dynamic>();
        for (int i = 0; i < MAX_VEHICLE_INVENTORY_SLOT; i++)
        {
            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0)
            {
                if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
                {
                    int type = NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type");

                    temp_vehicle_inventory.Add(new { sqlid = vehicle.GetData<dynamic>("trunk_item_" + i + "_index"), slotid = vehicle.GetData<dynamic>("trunk_item_" + i + "_slotid"), name = Inventory.itens_available[type].name, type = type, amount = NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount"), weight = Inventory.itens_available[type].weight, Useable = Inventory.itens_available[type].Useable, inuse = 0, dropable = 1, picture = "./img/" + Inventory.itens_available[type].picture + ".png" });
                }
                itens++;
            }
        }

        handle.TriggerEvent("Display_Player_Storage", NAPI.Util.ToJson(temp_inventory), NAPI.Util.ToJson(temp_vehicle_inventory), Inventory.GetInventoryMaxHeight(handle), vehicle.GetData<dynamic>("MAX_VEHICLE_SLOT"));
        handle.SetData<dynamic>("inVehicleInventory", true);
        handle.SetData<dynamic>("vehicle_handle_inv", vehicle);
    }

    public static void HidePlayerVehicleInventory(Player Client)
    {
        //NAPI.ClientEvent.TriggerClientEvent(Client, "HidePlayerVehicleInventory");
        Client.SetData<dynamic>("inVehicleInventory", false);
    }

    public static int GetInventoryIndexFromType(Player Client, int type)
    {
        Vehicle vehicle = Client.GetData<dynamic>("vehicle_handle_inv");
        int slot = -1;
        for (int index = 0; index < NAPI.Data.GetEntityData(vehicle, "MAX_VEHICLE_SLOT"); index++)
        {
            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + index + "_type") == type)
            {
                slot = index;
            }
        }
        return slot;
    }
    [RemoteEvent("Veh_InventoryChangeSlot")]
    public void Veh_InventoryChangeSlot(Player client, int index, int dataslot)
    {
        Vehicle vehicle = client.GetData<dynamic>("vehicle_handle_inv");
        vehicle.SetData<dynamic>("trunk_item_" + index + "_slotid", dataslot);
        if (vehicle.HasData("veh_sql"))
        {
            Main.CreateMySqlCommand("UPDATE `vehicle_inventory` SET `slotid` = " + dataslot + " WHERE `id` = " + vehicle.GetData<dynamic>("trunk_item_" + index + "_sqlid") + "");
        }

    }

    [RemoteEvent("Veh_InventoryStack")]
    public void InventoryStack(Player Client, int sqlnew, int sqlold)
    {
        if (AccountManage.GetPlayerConnected(Client))
        {
            int playerid = Main.getIdFromClient(Client);

            Vehicle vehicle = Client.GetData<dynamic>("vehicle_handle_inv");

            if (vehicle != null && vehicle.Exists && Main.IsInRangeOfPoint(Client.Position, vehicle.Position, 5.0f))
            {
                if (vehicle.GetData<dynamic>("trunk_item_" + sqlold + "_amount") >= 1 && vehicle.GetData<dynamic>("trunk_item_" + sqlnew + "_amount") >= 1)
                {

                    if (vehicle.Exists && Main.IsInRangeOfPoint(Client.Position, vehicle.Position, 5.0f))
                    {
                        if (Check_VehicleInventoryWeight_With_ItemAmount(Client, vehicle, vehicle.GetData<dynamic>("trunk_item_" + sqlold + "_type"), vehicle.GetData<dynamic>("trunk_item_" + sqlold + "_amount"), Inventory.Max_Inventory_Weight(Client)))
                        {
                            VehicleInventory.ShowToPlayerVehicleInventory(Client);
                            return;
                        }

                        if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + sqlnew + "_type") != NAPI.Data.GetEntityData(vehicle, "trunk_item_" + sqlold + "_type") || NAPI.Data.GetEntityData(vehicle, "trunk_item_" + sqlnew + "_index") == NAPI.Data.GetEntityData(vehicle, "trunk_item_" + sqlold + "_index"))
                        {
                            VehicleInventory.ShowToPlayerVehicleInventory(Client);
                            return;
                        }

                        NAPI.Data.SetEntityData(vehicle, "trunk_item_" + sqlnew + "_amount", NAPI.Data.GetEntityData(vehicle, "trunk_item_" + sqlnew + "_amount") + NAPI.Data.GetEntityData(vehicle, "trunk_item_" + sqlold + "_amount"));
                        RemoveItemFromVehicleInventory(vehicle, sqlold, 999);

                        if (vehicle.HasData("veh_sql"))
                        {
                            Main.CreateMySqlCommand("UPDATE vehicle_inventory SET `amount` = " + vehicle.GetData<dynamic>("trunk_item_" + sqlnew + "_amount") + " WHERE `id` = " + vehicle.GetData<dynamic>("trunk_item_" + sqlnew + "_sqlid") + "");
                        }

                        VehicleInventory.ShowToPlayerVehicleInventory(Client);
                        return;
                    }
                }
                else
                {
                    VehicleInventory.ShowToPlayerVehicleInventory(Client);
                }
            }

        }
    }

    public static bool DoesHaveFreeSlot(Vehicle vehicle)
    {
        for (int i = 0; i < MAX_VEHICLE_INVENTORY_SLOT; i++)
        {
            if (vehicle.GetData<dynamic>("trunk_item_" + i + "_amount") == 0 && vehicle.GetData<dynamic>("trunk_item_" + i + "_sqlid") == -1)
            {
                return true;
            }
        }
        return false;
    }

    [RemoteEvent("veh_split")]
    public void veh_split(Player client, int sqlid)
    {
        Inventory.SplitItemGlobal(client, sqlid);
        VehicleInventory.ShowToPlayerVehicleInventory(client);
    }

    [RemoteEvent("veh_sideinventorysplit")]
    public void veh_sideinventorysplit(Player client, int index)
    {
        Vehicle vehicle = client.GetData<dynamic>("vehicle_handle_inv");
        if (index == -1)
        {
            return;
        }
        if (!DoesHaveFreeSlot(vehicle))
        {
            Main.DisplayErrorMessage(client, NotifyType.Warning, NotifyPosition.BottomCenter, "In Khodro Slot Ezafi Nadarad,");
            return;
        }

        if (vehicle != null && vehicle.Exists && Main.IsInRangeOfPoint(vehicle.Position, client.Position, 5f))
        {
            if (vehicle.GetData<dynamic>("trunk_item_" + index + "_amount") >= 2)
            {
                if ((vehicle.GetData<dynamic>("trunk_item_" + index + "_amount") % 2) == 0)
                {
                    AddItemToVehicleInventory(vehicle, -1, vehicle.GetData<dynamic>("trunk_item_" + index + "_type"), (vehicle.GetData<dynamic>("trunk_item_" + index + "_amount") / 2));
                    vehicle.SetData<dynamic>("trunk_item_" + index + "_amount", vehicle.GetData<dynamic>("trunk_item_" + index + "_amount") / 2);
                    Main.CreateMySqlCommand("UPDATE `vehicle_inventory` SET `amount`=" + vehicle.GetData<dynamic>("trunk_item_" + index + "_amount") + " WHERE `id`=" + vehicle.GetData<dynamic>("trunk_item_" + index + "_sqlid") + "");
                    ShowToPlayerVehicleInventory(client);
                }
                else
                {
                    decimal ammount = decimal.Parse(vehicle.GetData<dynamic>("trunk_item_" + index + "_amount").ToString()) / 2m;
                    AddItemToVehicleInventory(vehicle, -1, vehicle.GetData<dynamic>("trunk_item_" + index + "_type"), (int)Math.Ceiling(ammount));
                    vehicle.SetData<dynamic>("trunk_item_" + index + "_amount", (int)Math.Floor(ammount));
                    ShowToPlayerVehicleInventory(client);

                    Main.CreateMySqlCommand("UPDATE `vehicle_inventory` SET `amount`=" + (int)Math.Floor(ammount) + " WHERE `id`=" + vehicle.GetData<dynamic>("trunk_item_" + index + "_sqlid") + "");
                }
            }
        }



    }

    [RemoteEvent("Veh_Client_ItemAction")]
    public static void Veh_Client_ItemAction(Player Client, int index, int amount)
    {
        Vehicle vehicle = Client.GetData<dynamic>("vehicle_handle_inv");

        if (index == -1)
        {
            return;
        }
        try
        {

            if (vehicle != null && vehicle.Exists && Main.IsInRangeOfPoint(vehicle.Position, Client.Position, 5f))
            {
                if (index == -1)
                {
                    Main.SendErrorMessage(Client, "Ne mozete to!");
                    return;
                }
                
                if (vehicle.GetData<dynamic>("trunk_item_" + index + "_amount") < 1)
                {
                    return;
                }
                if (Inventory.itens_available[vehicle.GetData<dynamic>("trunk_item_" + index + "_type")].guest != Inventory.ITEM_TYPE_Ammunation)
                {
                    amount = 1;
                }

                Inventory.UseItemFromInventory(Client, index, amount, 2);
            }
            return;


        }
        catch
        {

        }
    }

}




