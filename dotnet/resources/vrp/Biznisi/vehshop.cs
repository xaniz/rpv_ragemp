using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

class carshop : Script
{

    public carshop()
    {
            NAPI.TextLabel.CreateTextLabel("Autosalon~n~~w~[~y~ E ~w~]", new Vector3(-57.31, -1096.82, 26.42), 12, 0.3500f, 4, new Color(221, 255, 0, 255));      
            Entity temp_blip;
            temp_blip = NAPI.Blip.CreateBlip(new Vector3(-57.31, -1096.82, 26.42));
            NAPI.Blip.SetBlipName(temp_blip, "Autosalon");
            NAPI.Blip.SetBlipSprite(temp_blip, 810);
            NAPI.Blip.SetBlipColor(temp_blip, 25);
            NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);

            NAPI.TextLabel.CreateTextLabel("/prodajvozilo ~n~ (60% cene)", new Vector3(-8.23, -1082.93, 26.85), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
            NAPI.Marker.CreateMarker(25, new Vector3(-8.23, -1082.93, 26.85) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(221, 255, 0, 255), false);  

    }

    public class VehicleData
    {
        public int Price { get; set; }
        public uint Hash { get; set; }
    }
    private Dictionary<string, VehicleData> Vehicles = new Dictionary<string, VehicleData>()
    {
        { "primo", new VehicleData { Price = 27500, Hash = 3144368207} },
        { "journey", new VehicleData { Price = 30000, Hash = 4174679674} },
        { "glendale", new VehicleData { Price = 30000, Hash = 75131841} },
        { "surfer", new VehicleData { Price = 32500, Hash = 699456151} },
        { "issi2", new VehicleData { Price = 35000, Hash = 3117103977} },
        { "moonbeam", new VehicleData { Price = 35000, Hash = 525509695} },
        { "asbo", new VehicleData { Price = 35500, Hash = 1118611807} },
        { "ingot", new VehicleData { Price = 37500, Hash = 3005245074} },
        { "stratum", new VehicleData { Price = 43500, Hash = 1723137093} },
        { "minivan", new VehicleData { Price = 45000, Hash = 3984502180} },
        { "bobcatxl", new VehicleData { Price = 48000, Hash = 1069929536} },
        { "club", new VehicleData { Price = 50000, Hash = 2196012677} },
        { "habanero", new VehicleData { Price = 50000, Hash = 884422927} },
        { "vigero", new VehicleData { Price = 51000, Hash = 3469130167} },
        { "kanjo", new VehicleData { Price = 52500, Hash = 409049982} },
        { "everon", new VehicleData { Price = 52500, Hash = 2538945576} },
        { "caracara2", new VehicleData { Price = 60000, Hash = 2945871676} },
        { "speedo", new VehicleData { Price = 70000, Hash = 3484649228} },
        { "omnis", new VehicleData { Price = 75000, Hash = 3517794615} },
        { "bison", new VehicleData { Price = 75000, Hash = 4278019151} },
        { "zion2", new VehicleData { Price = 85000, Hash = 3101863448} },
        { "windsor", new VehicleData { Price = 92500, Hash = 1581459400} },
        { "buffalo2", new VehicleData { Price = 115000, Hash = 736902334} },
        { "tailgater", new VehicleData { Price = 125000, Hash = 3286105550} },
        { "kuruma", new VehicleData { Price = 125000, Hash = 2922118804} },
        { "dominator3", new VehicleData { Price = 135000, Hash = 3308022675} },
        { "jester3", new VehicleData { Price = 150000, Hash = 4080061290} },
        { "stretch", new VehicleData { Price = 175000, Hash = 2333339779} },
        { "infernus2", new VehicleData { Price = 175000, Hash = 2889029532} },
        { "specter", new VehicleData { Price = 180000, Hash = 1886268224} },
        { "locust", new VehicleData { Price = 200000, Hash = 3353694737} },
        { "komoda", new VehicleData { Price = 215000, Hash = 3460613305} },
        { "jugular", new VehicleData { Price = 225000, Hash = 4086055493} },
        { "italigto", new VehicleData { Price = 230000, Hash = 3963499524} },
        { "schafter3", new VehicleData { Price = 300000, Hash = 2809443750} },
        { "visione", new VehicleData { Price = 375000, Hash = 3296789504} },
        { "vagner", new VehicleData { Price = 430000, Hash = 1939284556} },
        { "dubsta2", new VehicleData { Price = 600000, Hash = 3900892662} },
        { "rebla", new VehicleData { Price = 600000, Hash = 83136452} },
        { "coquette4", new VehicleData { Price = 600000, Hash = 2566281822} },
        { "baller4", new VehicleData { Price = 700000, Hash = 634118882} },
        { "toros", new VehicleData { Price = 750000, Hash = 3126015148} },
        { "dubsta3", new VehicleData { Price = 800000, Hash = 3057713523} },
        { "superd", new VehicleData { Price = 1000000, Hash = 1123216662} },
        { "tyrant", new VehicleData { Price = 1150000, Hash = 3918533058} },
        { "entityxf", new VehicleData { Price = 1500000, Hash = 3003014393} },
        { "nero", new VehicleData { Price = 1800000, Hash = 1034187331} },
        { "thrax", new VehicleData { Price = 1850000, Hash = 1044193113} },
        { "nero2", new VehicleData { Price = 1900000, Hash = 1093792632} },
        { "entity2", new VehicleData { Price = 2300000, Hash = 2174267100} },
        { "deveste", new VehicleData { Price = 2500000, Hash = 1591739866} }
        
    };

    [RemoteEvent("GetVehPreview")]
    public static void GetVehPreview(Player player, string vehname, int color)
    {
        if (player.IsInVehicle)
        {
            player.Vehicle.Delete();
        }

        Random rnd = new Random();
        int dimen = rnd.Next(100, 999);
        player.Position = new Vector3(3.94, -1102.87, 38.15);
        uint pdim = Convert.ToUInt32(dimen);
        player.Dimension = pdim;
        Vehicle veh = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(vehname), new Vector3(6.14, -1097.17, 38.15), 110.36f, color, color, "", dimension: pdim, engine: false);
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(player))
            {
                player.SetIntoVehicle(veh, 0);
            }
        }, 250);
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(player))
            {
                player.TriggerEvent("ForeachFreezeVeh", veh, true);
                player.TriggerEvent("freezeEx", true);
            }
        }, 1000);
    }

    [RemoteEvent("VehPreviewExit")]
    public static void VehPreviewExit(Player player)
    {
        if (player.IsInVehicle)
        {
            player.Vehicle.Delete();
        }
        player.Dimension = 0;
        player.Position = new Vector3(-57.31, -1096.82, 26.42);
        player.TriggerEvent("freezeEx", false);
    }

    [RemoteEvent("TestDriveRemote")]
    public void TestDriveRemote(Player player, string vehname)
    {
        Vehicle veh2 = player.Vehicle;
        if(!veh2.Exists) return;
        veh2.Delete();
        string playername = AccountManage.GetCharacterName(player);
        NAPI.Task.Run(() =>
        {
            player.TriggerEvent("freezeEx", false);
            if (!NAPI.Player.IsPlayerConnected(player)) return;
            player.Position = new Vector3(-964.01, -3166.66, 13.96);
            uint vehicleDimension = player.Dimension;
            Vehicle veh = NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(vehname), new Vector3(-961.01, -3165.66, 13.96), -2f, 0, 0, "", dimension: vehicleDimension, engine: true);
            veh.NumberPlate = "VD"+playername;
            Main.SetVehicleFuel(veh, 99.0);
            player.TriggerEvent("HideCarShop");

            NAPI.Task.Run(() =>
            {
                
                    foreach (var car in NAPI.Pools.GetAllVehicles())
                    {
                        if (car.NumberPlate == "VD"+playername)
                        {
                            car.Delete();
                        }
                    }
                    if (NAPI.Player.IsPlayerConnected(player))
                    {
                        player.Dimension = 0;
                        player.Position = new Vector3(-57.31, -1096.82, 26.42);
                        Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Test voznja je istekla");
                    }
                
            }, 30000);

        }, 500);


    }

    [RemoteEvent("VehBuy")]
    public void VehBuy(Player player, string vehname, int color)
    {
        try {
        int index = PlayerVehicle.GetPlayerVehicleFreeSlotIndex(player);
        if (index == -1)
        {
            player.SendNotification("Greska!~n~Ne mozete imati vise od " + PlayerVehicle.MAX_PLAYER_VEHICLES + " vozila.");
            return;
        } 
        
        VehicleData vehicleData;
        if (Vehicles.TryGetValue(vehname, out vehicleData))
        {
            int vehiclePrice = vehicleData.Price;
            int playerMoney = Main.GetPlayerBank(player);
            if (playerMoney >= vehiclePrice)
            {

                uint vehicleHash = NAPI.Util.GetHashKey(vehname);
                Vector3 vehiclePosition = new Vector3(0, 0, 0);
                PlayerVehicle.CreatePlayerVehicle(player, index, vehname, -46, -1081, 26 , 0, 0, 70 , color, color, 0);
                PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].state[index] = 5; 
                PlayerVehicle.vehicle_data[Main.getIdFromClient(player)].json_vehicle_mods[index] = "";
                Main.GivePlayerMoneyBank(player, -vehiclePrice);

                NAPI.Task.Run(() => 
                {
                    if (NAPI.Player.IsPlayerConnected(player))
                    {
                        player.TriggerEvent("ForeachFreezeVeh", player.Vehicle, false);
                        Main.SendCustomChatMessasge(player, "~w~[Auto salon]:~g~ Cestitamo, ~w~kupili ste vozilo, mozete ga izvaditi iz garaze!");
                        player.Vehicle.Delete();
                        player.Dimension = 0;
                        player.Position = new Vector3(-57.31, -1096.82, 26.42);
                        player.TriggerEvent("freezeEx", false);
                        player.TriggerEvent("HideCarShop");
                    }
                }, 800);

                return;
            }
            else
            {
                Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na racunu");
            }
        }
        else
        {
            player.SendChatMessage($"Vozilo {vehname} nije dostupno u shopu.");
        }
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput("[GRESKA] " + ex.Message);
        }

    }

    [Command("prodajvozilo")]
    public void prodajvoziloCMD(Player player)
    {
        try
        {
            if (player.GetData<dynamic>("status") == true)
            {
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(-8.23, -1082.93, 26.05), 5.0f))
                {
                    if (!player.IsInVehicle) return;
                    if (player.VehicleSeat != 0)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Morate biti na mestu vozaca", 3000);
                        return;
                    }
                    Vehicle veh = player.Vehicle;
                    uint vehicleHash = veh.Model;
                    int playerid = Main.getIdFromClient(player);

                    if (player.Vehicle.GetData<dynamic>("Mashin_Owner") == AccountManage.GetPlayerSQLID(player))
                    {
                        string checkQuery = "SELECT COUNT(*) FROM `vehicles` WHERE `vehicle_plate`=@plate AND `vehicle_owner_id`=@owner";
                        bool vehicleExists = false;

                        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                        {
                            Mainpipeline.Open();
                            using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, Mainpipeline))
                            {
                                checkCommand.Parameters.AddWithValue("@plate", NAPI.Vehicle.GetVehicleNumberPlate(veh));
                                checkCommand.Parameters.AddWithValue("@owner", player.Vehicle.GetData<dynamic>("Mashin_Owner"));

                                int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                                vehicleExists = count > 0;
                            }
                            Mainpipeline.Close();
                        }

                        if (!vehicleExists)
                        {
                            Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Vozilo ne postoji u bazi podataka.", 3000);
                            return;
                        }

                        string deleteQuery = "DELETE FROM `vehicles` WHERE `vehicle_plate`=@plate AND `vehicle_owner_id`=@owner";
                        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                        {
                            Mainpipeline.Open();
                            using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, Mainpipeline))
                            {
                                deleteCommand.Parameters.AddWithValue("@plate", NAPI.Vehicle.GetVehicleNumberPlate(veh));
                                deleteCommand.Parameters.AddWithValue("@owner", player.Vehicle.GetData<dynamic>("Mashin_Owner"));
                                deleteCommand.ExecuteNonQuery();
                            }
                            Mainpipeline.Close();
                        }

                        int price = 0;
                        foreach (KeyValuePair<string, VehicleData> kvp in Vehicles)
                        {
                            if (kvp.Value.Hash == vehicleHash)
                            {
                                price = kvp.Value.Price;
                                break;
                            }
                        }
                        if (price > 0)
                        {
                            int sellPrice = (int)(price * 0.6);
                            Main.GivePlayerMoneyBank(player, sellPrice);
                            player.SendChatMessage("Prodali ste vozilo za ~g~$" + sellPrice);
                            veh.Delete();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

}