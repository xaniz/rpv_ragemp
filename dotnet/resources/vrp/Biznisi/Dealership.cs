using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

public class Dealership : Script
{
    public static List<dynamic> CarDealershipVehicles = new List<dynamic>();

    public static void CarDealershipInit()
    {

        // Basic cars 
        CarDealershipVehicles.Add(new { car_dealership_model_name = "bmwm7", car_dealership_class = Translation.DEALERSHIP_TYPE_CAR, car_dealership_stock_price = "36000" });


    }

    public static void ShowDealershipManage(Player Client)
    {
        int business_id = BusinessManage.GetPlayerInBusinessInDealership(Client);

        if (business_id == -1)
        {
            return;
        }

        if (BusinessManage.business_list[business_id].business_OwnerID != AccountManage.GetPlayerSQLID(Client))
        {
            return;
        }

        // Vehicles From Stock
        List<dynamic> client_vehicle_stock = new List<dynamic>();
        foreach (var veh_stock in CarDealershipVehicles)
        {//   Compact Cars, Coupes, Muscle, SUV, Sedans, Sports, Sport Classics, Motorcycles, Bicycles, Pickup Trucks, Vans
            if (BusinessManage.business_list[business_id].business_Type == 4)
            {
                if (veh_stock.car_dealership_class == Translation.DEALERSHIP_TYPE_CAR)
                {

                    client_vehicle_stock.Add(new { Model = veh_stock.car_dealership_model_name, Classe = veh_stock.car_dealership_class, Price = veh_stock.car_dealership_stock_price });
                }
            }
            else if (BusinessManage.business_list[business_id].business_Type == 6)
            {
                if (veh_stock.car_dealership_class == Translation.DEALERSHIP_TYPE_BIKE)
                {

                    client_vehicle_stock.Add(new { Model = veh_stock.car_dealership_model_name, Classe = veh_stock.car_dealership_class, Price = veh_stock.car_dealership_stock_price });
                }
            }
            else if (BusinessManage.business_list[business_id].business_Type == 7)
            {
                if (veh_stock.car_dealership_class == Translation.DEALERSHIP_TYPE_BOAT)
                {

                    client_vehicle_stock.Add(new { Model = veh_stock.car_dealership_model_name, Classe = veh_stock.car_dealership_class, Price = veh_stock.car_dealership_stock_price });
                }
            }
            else if (BusinessManage.business_list[business_id].business_Type == 8)
            {
                if (veh_stock.car_dealership_class == Translation.DEALERSHIP_TYPE_HELLI)
                {

                    client_vehicle_stock.Add(new { Model = veh_stock.car_dealership_model_name, Classe = veh_stock.car_dealership_class, Price = veh_stock.car_dealership_stock_price });
                }
            }
            else if (BusinessManage.business_list[business_id].business_Type == 9)
            {
                if (veh_stock.car_dealership_class == Translation.DEALERSHIP_TYPE_TRUCK)
                {

                    client_vehicle_stock.Add(new { Model = veh_stock.car_dealership_model_name, Classe = veh_stock.car_dealership_class, Price = veh_stock.car_dealership_stock_price });
                }
            }

        }

        List<dynamic> vehicle_list = new List<dynamic>();
        // Vehicles From Business
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `business_vehicles` WHERE `vehicle_stock` > 0 AND `business_id` = '" + business_id + "';", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    vehicle_list.Add(new { Model = reader.GetString("vehicle_model"), Price = reader.GetInt32("vehicle_price"), Status = Convert.ToBoolean(reader.GetInt32("vehicle_status")), Stock = reader.GetInt32("vehicle_stock") });
                }
            }
            Mainpipeline.Close();
        }
        //

        Client.TriggerEvent("Display_DealerShip_Manage", BusinessManage.business_list[business_id].business_Name, BusinessManage.Business_Type(BusinessManage.business_list[business_id].business_Type), BusinessManage.business_list[business_id].business_Safe, NAPI.Util.ToJson(client_vehicle_stock), NAPI.Util.ToJson(vehicle_list));
    }

    public static void ShowDealerShipVehicles(Player Client)
    {
        int business_id = -1, count = 0;
        foreach (var business in BusinessManage.business_list)
        {
            if (Main.IsInRangeOfPoint(Client.Position, business.business_dealership_buy, 30) && (business.business_Type == 4 || business.business_Type == 6 || business.business_Type == 7 || business.business_Type == 8 || business.business_Type == 9))
            {
                business_id = count;
            }
            count++;
        }


        List<dynamic> vehicle_list = new List<dynamic>();


        foreach (var item in CarDealershipVehicles)
        {
            switch (BusinessManage.business_list[business_id].business_Type)
            {
                case 4:
                    {
                        if (item.car_dealership_class == Translation.DEALERSHIP_TYPE_CAR)
                        {
                            vehicle_list.Add(new { model = item.car_dealership_model_name, price = item.car_dealership_stock_price });
                        }
                        break;
                    }
                case 6:
                    {
                        if (item.car_dealership_class == Translation.DEALERSHIP_TYPE_BIKE)
                        {
                            vehicle_list.Add(new { model = item.car_dealership_model_name, price = item.car_dealership_stock_price });
                        }
                        break;
                    }
                case 7:
                    {
                        if (item.car_dealership_class == Translation.DEALERSHIP_TYPE_BOAT)
                        {
                            vehicle_list.Add(new { model = item.car_dealership_model_name, price = item.car_dealership_stock_price });
                        }
                        break;
                    }
                case 8:
                    {
                        if (item.car_dealership_class == Translation.DEALERSHIP_TYPE_HELLI)
                        {
                            vehicle_list.Add(new { model = item.car_dealership_model_name, price = item.car_dealership_stock_price });
                        }
                        break;
                    }
                case 9:
                    {
                        if (item.car_dealership_class == Translation.DEALERSHIP_TYPE_TRUCK)
                        {
                            vehicle_list.Add(new { model = item.car_dealership_model_name, price = item.car_dealership_stock_price });
                        }
                        break;
                    }
                default:
                    break;
            }
        }
        Client.SetData<Vector3>("dealership_lastpos", Client.Position);
        Client.SetData<int>("dealership_index", business_id);
        Client.TriggerEvent("Display_Vehicle_Dealership_Player", BusinessManage.business_list[business_id].business_Name, NAPI.Util.ToJson(vehicle_list));
    }

    public class DealershipShow_Structer
    {
        public int sqlid;
        public uint dimenision;
    }

    public static List<DealershipShow_Structer> dealershipdimen = new List<DealershipShow_Structer>();

    [RemoteEvent("PreviewVehicleDealership")]
    public static void PreviewVehicleDealership(Player player, string vehname)
    {
        if (player.IsInVehicle)
        {
            player.Vehicle.Delete();
        }

        Random rnd = new Random();
        uint dimen = (uint)rnd.Next(5, 1000);

        for (int i = 0; i < 10; i++)
        {
            if (dealershipdimen.Find(x => x.dimenision == dimen) != null && dealershipdimen.Find(x => x.dimenision == dimen).dimenision == dimen)
            {
                dimen = (uint)rnd.Next(5, 1000);
            }
            else
            {
                break;
            }
        }
        if (dealershipdimen.Find(x => x.sqlid == AccountManage.GetPlayerSQLID(player)) != null)
        {
            dealershipdimen.Find(x => x.sqlid == AccountManage.GetPlayerSQLID(player)).dimenision = dimen;
        }
        else
        {
            dealershipdimen.Add(new DealershipShow_Structer { dimenision = dimen, sqlid = AccountManage.GetPlayerSQLID(player) });
        }
        player.Position = new Vector3(-45.51, -1101.62, 26.42);
        player.Dimension = dimen;
        Vehicle veh = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(vehname), new Vector3(526.76, -3247.73, 46.31), -2f, 0, 0, "", dimension: dimen, engine: false);
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(player))
            {
            player.SetIntoVehicle(veh, 0);
            }
        }, 200);
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(player))
            {
            player.TriggerEvent("ForeachFreezeVeh", veh, true);
            }
        }, 1000);

        player.TriggerEvent("UpdateVehicleInfo", veh.DisplayName);
    }

    [RemoteEvent("DealershipExitMenu")]
    public static void DealershipExitMenu(Player player)
    {
        if (player.IsInVehicle)
        {
            player.Vehicle.Delete();
        }
        if (dealershipdimen.Find(x => x.sqlid == AccountManage.GetPlayerSQLID(player)) != null)
        {
            dealershipdimen.Remove(dealershipdimen.Find(x => x.sqlid == AccountManage.GetPlayerSQLID(player)));
        }
        player.Position = player.GetData<Vector3>("dealership_lastpos");
        player.ResetData("dealership_lastpos");
        player.ResetData("dealership_index");
        player.Dimension = 0;
        Main.KeyPressF9(player);
        


    }

    [RemoteEvent("BuyVehicle_FromDealership")]
    public static void BuyVehicle(Player Client, string model)
    {

        int index = PlayerVehicle.GetPlayerVehicleFreeSlotIndex(Client);
        int business_id = Client.GetData<int>("dealership_index");

        if (business_id == -1)
        {
            return;
        }

        if (index == -1)
        {
            Client.SendNotification("Greska!~n~Ne mozete imati vise od " + PlayerVehicle.MAX_PLAYER_VEHICLES + " vozila.");
            return;
        }
        else
        {
            if (Main.GetPlayerMoney(Client) < Convert.ToInt32(CarDealershipVehicles.Find(x => x.car_dealership_model_name == model).car_dealership_stock_price))
            {
                Client.SendNotification("Nemate dovoljno novca.");
                return;
            }
            Main.GivePlayerMoney(Client, -Convert.ToInt32(CarDealershipVehicles.Find(x => x.car_dealership_model_name == model).car_dealership_stock_price));

            if (BusinessManage.business_list[business_id].business_OwnerID != -1)
            {
                BusinessManage.business_list[business_id].business_Safe = BusinessManage.business_list[business_id].business_Safe + Convert.ToInt32(CarDealershipVehicles.Find(x => x.car_dealership_model_name == model).car_dealership_stock_price);
            }
            Client.Dimension = 0;
            if (Client.IsInVehicle)
            {
                Client.Vehicle.Delete();
            }
            Client.Position = BusinessManage.business_list[business_id].business_dealership_vehicle;
            PlayerVehicle.CreatePlayerVehicle(Client, index, model, BusinessManage.business_list[business_id].business_dealership_vehicle.X, BusinessManage.business_list[business_id].business_dealership_vehicle.Y, BusinessManage.business_list[business_id].business_dealership_vehicle.Z, 0.0f, 0.0f, BusinessManage.business_list[business_id].business_dealership_vehicle_a, 0, 0);

        
            Main.SendCustomChatMessasge(Client, "~w~[Auto salon]:~g~ Cestitamo, ~w~kupili ste ~y~" + model + "~w~.");

            PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].state[index] = 1;

            PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].json_vehicle_mods[index] = "";

            PlayerVehicle.SpawnPlayerVehicle(Client, index);
            NAPI.Task.Run(() =>
            {
                if (NAPI.Player.IsPlayerConnected(Client))
                {
                NAPI.Player.SetPlayerIntoVehicle(Client, PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].handle[index], (int)VehicleSeat.Driver);
                Client.TriggerEvent("freezeEx", false);
                Client.TriggerEvent("ForeachFreezeVeh", Client.Vehicle, false);
                }
            }, 1000);

            // VehicleStreaming.SetEngineState(PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].handle[index], false);
            // VehicleStreaming.SetLockStatus(PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].handle[index], true);
            VehicleStreaming.SetLockStatus(PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].handle[index], false);
            VehicleStreaming.SetEngineState(PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].handle[index], false);
            Client.ResetData("dealership_lastpos");
            Client.ResetData("dealership_index");

            PlayerVehicle.SavePlayerVehicle(Client, index);
            Client.TriggerEvent("Destroy_Character_Menu");
            Client.TriggerEvent("freezeEx", false);

            return;
        }
    }

    [RemoteEvent("vehicle_to_business")]
    public void AddVehicleToBusiness(Player Client, string name, int stock, int price)
    {
        string dealership_vehicle_name = name;
        int dealership_vehicle_stock = stock;
        int dealership_vehicle_price = price;

        int business_id = BusinessManage.GetPlayerInBusinessInDealership(Client);

        if (business_id == -1)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste vlasnik biznisa.");
            Client.TriggerEvent("Destroy_Character_Menu");
            return;
        }

        if (BusinessManage.business_list[business_id].business_OwnerID != AccountManage.GetPlayerSQLID(Client))
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste vlasnik biznisa.");
            Client.TriggerEvent("Destroy_Character_Menu");
            return;
        }


        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT * FROM `business_vehicles` WHERE `vehicle_model` = '" + dealership_vehicle_name + "' AND `business_id` = '" + business_id + "'";
            
            query.ExecuteNonQuery();
            DataTable dt = new DataTable();

            int i = 0;
            using (MySqlDataAdapter da = new MySqlDataAdapter(query))
            {
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
            }

            int foreach_index = 0, index = -1;
            foreach (var vehicle_dealership in CarDealershipVehicles)
            {
                if (vehicle_dealership.car_dealership_model_name == dealership_vehicle_name)
                {
                    index = foreach_index;
                }
                foreach_index++;
            }

            if (index == -1)
            {
                Main.SendErrorMessage(Client, "Doslo je do greske: ~y~" + dealership_vehicle_name + "~w~. ~r~[CODE #000010]");
                Client.TriggerEvent("Destroy_Character_Menu");
                return;
            }

            if (i == 0)
            {
                if (BusinessManage.business_list[business_id].business_Safe < dealership_vehicle_price)
                {
                    Client.SendNotification("~r~Greska:~w~ Nemate dovoljno novca u sefu biznisa.", true);
                    return;
                }

                BusinessManage.business_list[business_id].business_Safe = BusinessManage.business_list[business_id].business_Safe - dealership_vehicle_price;
                BusinessManage.SaveBusiness(business_id);

            

                Main.SendCustomChatMessasge(Client, ":~w~ Kupili ste ~c~" + dealership_vehicle_stock + "~w~ produkata ~y~" + dealership_vehicle_name + "~w~ za ~y~$~g~" + dealership_vehicle_price.ToString("N0") + "~w~. Koristite meni biznisa da biste ga narucili.");
                Client.SendNotification("Kupili ste ~c~" + dealership_vehicle_stock + "~w~ produkata ~y~" + dealership_vehicle_name + "~w~.~n~~n~~y~Sada imate: ~g~$" + BusinessManage.business_list[business_id].business_Safe.ToString("N0") + "");
                ShowDealershipManage(Client);
            }
            else
            {
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    string data2txt = string.Empty;
                    string datatxt = string.Empty;
                    int old_stock = 0;


                    while (reader.Read())
                    {
                        old_stock = reader.GetInt32("vehicle_stock");
                    }

                    if (BusinessManage.business_list[business_id].business_Safe < dealership_vehicle_price)
                    {
                        Client.SendNotification("~r~Greska:~w~ Nemate dovoljno novca.", true);
                        return;
                    }

                    BusinessManage.business_list[business_id].business_Safe = BusinessManage.business_list[business_id].business_Safe - dealership_vehicle_price;
                    BusinessManage.SaveBusiness(business_id);

                    int new_stock = old_stock + dealership_vehicle_stock;
                

                    Main.SendCustomChatMessasge(Client, "~w~ Kupili ste ~c~" + dealership_vehicle_stock + "~w~ produkata ~y~" + dealership_vehicle_name + "~w~ za ~y~$~g~" + dealership_vehicle_price.ToString("N0") + "~w~, Koristite meni biznisa da biste ga narucili.");
                    Client.SendNotification("Kupili ste ~c~" + dealership_vehicle_stock + "~w~ produkata ~y~" + dealership_vehicle_name + "~w~.~n~~n~~y~Sada imate: ~g~$" + BusinessManage.business_list[business_id].business_Safe.ToString("N0") + "");
                    ShowDealershipManage(Client);
                }
            }
            Mainpipeline.Close();
        }
    }
    [RemoteEvent("vehicle_save_business")]
    public void SaveVehicleToBusiness(Player Client, string name, int price, int new_state)
    {
        int business_id = BusinessManage.GetPlayerInBusinessInDealership(Client);

        if (business_id == -1)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste vlasnik biznisa.");
            Client.TriggerEvent("Destroy_Character_Menu");
            return;
        }

        if (BusinessManage.business_list[business_id].business_OwnerID != AccountManage.GetPlayerSQLID(Client))
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste vlasnik biznisa.");
            Client.TriggerEvent("Destroy_Character_Menu");
            return;
        }

        string EditingModel = name;

        int amount = 0;

        if (!int.TryParse(price.ToString(), out amount))
        {
            Client.SendNotification("~r~Greska:~w~ Pogresna vrednost.");
            return;
        }

        if (amount < 1) return;


        string response = "";
        if (new_state == 1)
        {
            response = "~g~Yes";
        }
        else
        {
            response = "~r~No";
        }

        Client.SendNotification("~g~Vozilo ~b~" + name + "~g~ Azurirano. Nova cena: ~g~$" + price.ToString("N0") + "~n~~n~~w~Skladiste: " + response + "");

        //Main.SendCustomChatMessasge(Client,"~y~[EMPRESA]:~w~ Você editou com sucesso o veículo ~y~" + EditingModel + "~w~.");

        ShowDealershipManage(Client);

    }
}
