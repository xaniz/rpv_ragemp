using GTANetworkAPI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using MySql.Data.MySqlClient;

    public class aRent : Script
    {
        public static List<Vector3> rentpos = new List<Vector3>()
        {
            new Vector3(-990.02, -2969.23, 13.94),
            new Vector3(1737.96, 3281.11, 41.11),
        };

        public aRent()
        {
            foreach (var pos in rentpos)
            {
                NAPI.TextLabel.CreateTextLabel("Rent~n~~w~[~y~ Y ~w~]", pos, 12, 0.3500f, 4, new Color(221, 255, 0, 255));
                NAPI.Marker.CreateMarker(25, pos - new Vector3(0, 0, 0.9f), new Vector3(), new Vector3(), 1.5f, new Color(221, 255, 0, 255), false);

                
                Entity temp_blip;
                temp_blip = NAPI.Blip.CreateBlip(pos);
                NAPI.Blip.SetBlipName(temp_blip, "Avio Rent");
                NAPI.Blip.SetBlipSprite(temp_blip, 753);
                NAPI.Blip.SetBlipColor(temp_blip, 19);
                NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
                NAPI.Blip.SetBlipShortRange(temp_blip, true);
            }

        }

        public static void atriggerrent(Player client)
        {
            if(client.IsInVehicle)
            {
                return;
            }
            foreach (var v in rentpos)
            {
                if (Main.IsInRangeOfPoint(client.Position, v, 5))
                {
                    client.TriggerEvent("Display_arent");
                }
            }
        }

        [RemoteEvent("arentveh")]
        public static void arentveh(Player Client, int index)
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
                                    string vehName = "cuban800";
                                    VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
                                    Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(Client.Position.X + 2f, Client.Position.Y +2f, Client.Position.Z), Client.Rotation, 92, 111, "rt"+playername, 255, false, true, 0);
                                    Main.SetVehicleFuel(vehicle, 100.0);
                                    Client.SetData("rented", true);
                                    aRentCost(Client);
                                    Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Rentali ste vozilo, cena renta je $500 svaki minut. /unrent");
                                
                            
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
                                    string vehName = "maverick";
                                    VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
                                    Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(Client.Position.X + 2f, Client.Position.Y+2f, Client.Position.Z), Client.Rotation, 92, 111, "rt"+playername, 255, false, true, 0);
                                    Main.SetVehicleFuel(vehicle, 100.0);
                                    Client.SetData("rented", true);
                                    aRentCost(Client);
                                    Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Rentali ste vozilo, cena renta je $500 svaki minut. /unrent");
                                
                            
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void aRentCost(Player c)
        {
            if(c.GetData<dynamic>("rented") == false)
            {
                return;
            }
            if(c.GetData<dynamic>("rented") == true)
            {
                int price = 500;
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(c))
                    {
                    
                        if(Main.GetPlayerMoney(c) < price)
                        {
                            Main.DisplayErrorMessage(c, NotifyType.Info, NotifyPosition.BottomCenter, "Nemate dovoljno novca da nastavite sa rentom");
                            Rent.CMDunrent(c);
                            return;
                        }
                        Main.GivePlayerMoney(c, - price);
                        c.TriggerEvent("createNewHeadNotificationAdvanced", "~g~-500$ ~y~Rent");
                        aRentCost(c);
                    }
                    
                }, delayTime: 60000);
            }
        }

    }
