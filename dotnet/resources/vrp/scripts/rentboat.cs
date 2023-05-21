using GTANetworkAPI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using MySql.Data.MySqlClient;

    public class bRent : Script
    {
        public static List<Vector3> rentpos = new List<Vector3>()
        {
            new Vector3(-712.58, -1298.56, 5.10),
        };

        public bRent()
        {
            foreach (var pos in rentpos)
            {
                NAPI.TextLabel.CreateTextLabel("Rent~n~~w~[~y~ Y ~w~]", pos, 12, 0.3500f, 4, new Color(221, 255, 0, 255));
                NAPI.Marker.CreateMarker(25, pos - new Vector3(0, 0, 0.9f), new Vector3(), new Vector3(), 1.5f, new Color(221, 255, 0, 255), false);

                
                Entity temp_blip;
                temp_blip = NAPI.Blip.CreateBlip(pos);
                NAPI.Blip.SetBlipName(temp_blip, "Rent Plovila");
                NAPI.Blip.SetBlipSprite(temp_blip, 404);
                NAPI.Blip.SetBlipColor(temp_blip, 9);
                NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
                NAPI.Blip.SetBlipShortRange(temp_blip, true);
            }

        }

        [RemoteEvent("bRentveh")]
        public static void bRentveh(Player Client, int index)
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
                                    string vehName = "dinghy";
                                    VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
                                    Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(-725.84, -1327.87, 0.00), new Vector3(0.00, 0.00, -133.63), 92, 111, "rt"+playername, 255, false, true, 0);
                                    Main.SetVehicleFuel(vehicle, 100.0);
                                    Client.SetData("rented", true);
                                    bRentCost(Client);
                                    Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Rentali ste vozilo, cena renta je $100 svaki minut. /unrent");
                                
                            
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
                                    string vehName = "seashark";
                                    VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
                                    Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(-725.84, -1327.87, 0.00), new Vector3(0.00, 0.00, -133.63), 92, 111, "rt"+playername, 255, false, true, 0);
                                    Main.SetVehicleFuel(vehicle, 100.0);
                                    Client.SetData("rented", true);
                                    bRentCost(Client);
                                    Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Rentali ste vozilo, cena renta je $100 svaki minut. /unrent");
                                
                            
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void bRentCost(Player c)
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
                        c.TriggerEvent("createNewHeadNotificationAdvanced", "~g~-100$ ~y~Rent");
                        bRentCost(c);
                    }
                    
                }, delayTime: 60000);
            }
        }

    }
