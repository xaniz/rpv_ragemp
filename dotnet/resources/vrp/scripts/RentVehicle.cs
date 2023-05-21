using GTANetworkAPI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using MySql.Data.MySqlClient;

    public class Rent : Script
    {
        public static List<Vector3> rentpos = new List<Vector3>()
        {
            new Vector3(-200.74, 6226.99, 31.49),
            new Vector3(1980.26, 3780.17, 32.18),
            new Vector3(1810.20, 4591.45, 36.96),
            new Vector3(-1016.0152, -2695.0583, 13.977075),
            new Vector3(-0.3819425, -1718.8488, 29.296698),
            new Vector3(-693.74854, -1102.0911, 14.5253105),
            new Vector3(216.60117, -809.9229, 30.715343),
            new Vector3(-341.12708, 269.4189, 85.583565),
            new Vector3(-1531.7198, -429.00357, 35.4422),
            new Vector3(-3249.5876, 987.63904, 12.4858265),
        };

        public Rent()
        {
            foreach (var pos in rentpos)
            {
                NAPI.TextLabel.CreateTextLabel("Rent~n~~w~[~y~ Y ~w~]", pos, 12, 0.3500f, 4, new Color(221, 255, 0, 255));
                NAPI.Marker.CreateMarker(25, pos - new Vector3(0, 0, 0.9f), new Vector3(), new Vector3(), 1.5f, new Color(221, 255, 0, 255), false);

                
                Entity temp_blip;
                temp_blip = NAPI.Blip.CreateBlip(pos);
                NAPI.Blip.SetBlipName(temp_blip, "Rent");
                NAPI.Blip.SetBlipSprite(temp_blip, 739);
                NAPI.Blip.SetBlipColor(temp_blip, 24);
                NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
                NAPI.Blip.SetBlipShortRange(temp_blip, true);
            }

        }

        public static void triggerrent(Player client)
        {
            if(client.IsInVehicle)
            {
                return;
            }
            foreach (var v in rentpos)
            {
                if (Main.IsInRangeOfPoint(client.Position, v, 5))
                {
                    client.TriggerEvent("Display_rent");
                }
            }
        }

        [RemoteEvent("rentveh")]
        public static void rentveh(Player Client, int index)
        {
            try
            {

                switch (index)
                {
                    case 0:
                        {
                            
                                
                                    if (Client.GetData<dynamic>("rented") == true)
                                    {
                                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec imate rentano vozilo, /unrent");
                                        return;
                                    }
                                    string playername = AccountManage.GetCharacterName(Client);
                                    string vehName = "faggio";
                                    VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
                                    Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(Client.Position.X + 2f, Client.Position.Y, Client.Position.Z), Client.Rotation, 92, 111, "rt"+playername, 255, false, true, 0);
                                    Main.SetVehicleFuel(vehicle, 100.0);
                                    Client.SetData("rented", true);
                                    RentCost(Client);
                                    Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Rentali ste vozilo, cena renta je $30 svaki minut. /unrent");
                                
                            
                            break;
                        }
                    case 1:
                        {
                            
                                
                                    if (Client.GetData<dynamic>("rented") == true)
                                    {
                                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec imate rentano vozilo, /unrent");
                                        return;
                                    }
                                    string playername = AccountManage.GetCharacterName(Client);
                                    string vehName = "dilettante";
                                    VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
                                    Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(Client.Position.X + 2f, Client.Position.Y, Client.Position.Z), Client.Rotation, 92, 111, "rt"+playername, 255, false, true, 0);
                                    Main.SetVehicleFuel(vehicle, 100.0);
                                    Client.SetData("rented", true);
                                    RentCost(Client);
                                    Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Rentali ste vozilo, cena renta je $30 svaki minut. /unrent");
                                
                            
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void RentCost(Player c)
        {
            if(c.GetData<dynamic>("rented") == false)
            {
                return;
            }
            if(c.GetData<dynamic>("rented") == true)
            {
                int price = 30;
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(c))
                    {
                    
                        if(Main.GetPlayerMoney(c) < price)
                        {
                            Main.DisplayErrorMessage(c, NotifyType.Info, NotifyPosition.BottomCenter, "Nemate dovoljno novca da nastavite sa rentom");
                            CMDunrent(c);
                            return;
                        }
                        Main.GivePlayerMoney(c, - price);
                        c.TriggerEvent("createNewHeadNotificationAdvanced", "~g~-30$ ~y~Rent");
                        RentCost(c);
                    }
                }, delayTime: 60000);
            }
        }

        [Command("unrent")]
        public static void CMDunrent(Player client)
        {
            
            if (client.GetData<dynamic>("rented") == true)
            {
                client.SetData<dynamic>("rented", false);
                string playername = AccountManage.GetCharacterName(client);
                Main.DisplayErrorMessage(client, NotifyType.Info, NotifyPosition.BottomCenter, "Zavrsili ste sa rentanjem!");
                Main.GiveCompanyMoney(5, 30);
                foreach (var veh in NAPI.Pools.GetAllVehicles())
                {
                    if (veh.NumberPlate == "rt"+playername)
                    {
                        veh.Delete();
                        
                    }
                }
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
                    if (veh.NumberPlate == "rt"+playername)
                    {
                        veh.Delete();
                        player.SetData<dynamic>("rented", false);
                    }
                }
            }
            catch (Exception e) {Console.Write(e); }
        }
    }
