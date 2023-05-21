using GTANetworkAPI;
using System;
using MySql.Data.MySqlClient;
    class VehChangeNumber : Script
    {


        private static ColShape shapeChangeNum;

        private static Vector3 PositionChangeNumber = new Vector3(-294.11, -422.01, 29.50);

        public static int Price = 5; //donate
        public static int Price1 = 1000;
        public static int Price2 = 3000;
        public static int Price3 = 5000;

        [ServerEvent(Event.ResourceStart)]
        public static void OnResourceStart()
        {
            try
            {
                NAPI.Marker.CreateMarker(25, PositionChangeNumber, new Vector3(), new Vector3(), 2.5f, new Color(221, 255, 0, 110));
                API.Shared.CreateTextLabel("~g~-~y~ Promena Tablica~g~ -~w~~n~~n~ ~y~E~w~", PositionChangeNumber, 8.0f, 0.8f, 4, new Color(221, 255, 0, 255));

                shapeChangeNum = NAPI.ColShape.CreateCylinderColShape(PositionChangeNumber, 4, 4, 0);
                shapeChangeNum.OnEntityEnterColShape += (s, ent) =>
                {
                    try
                    {
                        NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 901);
                    }
                    catch (Exception ex) { Console.WriteLine("shape.OnEntityEnterColShape: " + ex.Message); }
                };
                shapeChangeNum.OnEntityExitColShape += (s, ent) =>
                {
                    try
                    {
                        NAPI.Data.SetEntityData(ent, "INTERACTIONCHECK", 0);
                    }
                    catch (Exception ex) { Console.WriteLine("shape.OnEntityExitColShape: " + ex.Message); }
                };

            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        [RemoteEvent("changeNumber")]
        public void Event_changeNumber(Player player, string number, int type)
        {
            try
            {
                if (player.GetData<dynamic>("status") == true)
                {
                
                if (player.VehicleSeat != 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Morate biti na mestu vozaca", 3000);
                    return;
                }
                if (player.Vehicle.GetData<dynamic>("Mashin_Owner") == AccountManage.GetPlayerSQLID(player))
                {
                if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number) || number == "0")
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Unesite ispravne podatke", 3000);
                    return;
                }
                if (number.Length < 3)
                {
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, "Broj karaktera ne moze biti manji od 3", 3000);
                    return;
                }
                if (number.Length > 9)
                {
                    Notify.Send(player, NotifyType.Warning, NotifyPosition.BottomCenter, "Broj karaktera ne moze biti veci od 8.", 3000);
                    return;
                }

                number = number.ToUpper();
                if (number.Contains("ADMIN"))
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Ne mozete imati tablice ADMIN", 3000);
                    return;
                }

                var oldNum = player.Vehicle.NumberPlate;

                if (type == 0)
                {
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Odaberite uslugu", 3000);
                    return;
                }
                if (type == 1)  //5000
                {
                    if (Main.GetPlayerMoney(player) < Price1)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca", 3000);
                        return;
                    }

                    Main.GivePlayerMoney(player, -Price1);

                    Vehicle veh = player.Vehicle;

                    veh.NumberPlate = number;
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Promenili ste tablice na vozilu", 3000);
                    
                    Main.CreateMySqlCommand("UPDATE `vehicles` SET `vehicle_plate` = '" + number + "' WHERE `id` = '" + player.Vehicle.GetData<int>("veh_sql") + "'");
                    PlayerVehicle.SavePlayerVehicle(player, player.Vehicle.GetData<int>("veh_sql"));
                    
                    return;
                }
                else if (type == 3)   //10000
                {
                    if (Main.GetPlayerMoney(player) < Price2)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca", 3000);
                        return;
                    }

                    Main.GivePlayerMoney(player, -Price2);
                    
                    Vehicle veh = player.Vehicle;

                    veh.NumberPlate = number;
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Promenili ste tablice na vozilu", 3000);
                    
                    Main.CreateMySqlCommand("UPDATE `vehicles` SET `vehicle_plate` = '" + number + "' WHERE `id` = '" + player.Vehicle.GetData<int>("veh_sql") + "'");
                    PlayerVehicle.SavePlayerVehicle(player, player.Vehicle.GetData<int>("veh_sql"));
                    
                    return;
                }
                else if (type == 4)       //15000
                {
                    if (Main.GetPlayerMoney(player) < Price3)
                    {
                        Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca", 3000);
                        return;
                    }

                    Main.GivePlayerMoney(player, -Price3);
                    

                    Vehicle veh = player.Vehicle;

                    veh.NumberPlate = number;
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Promenili ste tablice na vozilu", 3000);

                    Main.CreateMySqlCommand("UPDATE `vehicles` SET `vehicle_plate` = '" + number + "' WHERE `id` = '" + player.Vehicle.GetData<int>("veh_sql") + "'");
                    PlayerVehicle.SavePlayerVehicle(player, player.Vehicle.GetData<int>("veh_sql"));
                    
                    
                    return;
                }
                else if (type == 2)              //donat
                {
                    if (VIP.GetPlayerCredits(player) < 250)
                    {
                        player.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    VIP.SetPlayerCredits(player, VIP.GetPlayerCredits(player) - 250);
                

                    Vehicle veh = player.Vehicle;

                    veh.NumberPlate = number;
                    Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, "Promenili ste tablice na vozilu", 3000);

                    Main.CreateMySqlCommand("UPDATE `vehicles` SET `vehicle_plate` = '" + number + "' WHERE `id` = '" + player.Vehicle.GetData<int>("veh_sql") + "'");
                    PlayerVehicle.SavePlayerVehicle(player, player.Vehicle.GetData<int>("veh_sql"));
                    return;
                }
                }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
