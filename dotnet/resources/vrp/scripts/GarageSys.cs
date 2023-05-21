using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

class GarageSys : Script
{
    public class GarageEnum : IEquatable<GarageEnum>
    {
        public int id { get; set; }

        public Vector3 position { get; set; }
        public float position_a { get; set; }

        public TextLabel label { get; set; }
        public Marker marker { get; set; }
        public Blip blip { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            GarageEnum objAsPart = obj as GarageEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(GarageEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<GarageEnum> garage_array = new List<GarageEnum>();

    public static int MAX_GARAGEM = 0;

    public static void GarageSystemInit()
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `garagem`;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                var index = 0;
                while (reader.Read())
                {
                    garage_array.Add(new GarageEnum()
                    {
                        id = reader.GetInt32("id"),
                        position = new Vector3(reader.GetFloat("position_x"), reader.GetFloat("position_y"), reader.GetFloat("position_z")),
                        position_a = reader.GetFloat("position_a"),
                    });

                    garage_array[index].label = NAPI.TextLabel.CreateTextLabel("~b~[ Parking Garaza ~y~#" + index + "~b~ ]~n~~n~~w~Koristite[ ~b~E~w~ ] da pristupite garazi.", garage_array[index].position + new Vector3(0, 0, 0.6), 8.0f, 0.6f, 4, new Color(221, 255, 0, 255), false, 0);
                    garage_array[index].marker = API.Shared.CreateMarker(25, garage_array[index].position - new Vector3(0, 0, 0.8), new Vector3(), new Vector3(), 3.0f, new Color(221, 255, 0, 200), false, 0);


                    garage_array[index].blip = NAPI.Blip.CreateBlip(garage_array[index].label.Position);
                    NAPI.Blip.SetBlipName(garage_array[index].blip, "Garaza");
                    NAPI.Blip.SetBlipSprite(garage_array[index].blip, 357);
                    NAPI.Blip.SetBlipScale(garage_array[index].blip, 0.7f);
                    NAPI.Blip.SetBlipColor(garage_array[index].blip, 30);
                    NAPI.Blip.SetBlipShortRange(garage_array[index].blip, true);

                    if (garage_array[index].position.X == 0)
                    {
                        NAPI.Blip.SetBlipTransparency(garage_array[index].blip, 0);
                    }

                    //369
                    index++;
                    MAX_GARAGEM++;
                }
            }
            Mainpipeline.Close();
        }
    }




    public static void SaveGaragem(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                string query = "UPDATE `garagem` SET `position_x` = @position_x, `position_y` = @position_y, `position_z` = @position_z, `position_a` = @position_a WHERE `id` = '" + garage_array[index].id + "'";

                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                myCommand.Parameters.AddWithValue("@position_x", garage_array[index].position.X);
                myCommand.Parameters.AddWithValue("@position_y", garage_array[index].position.Y);
                myCommand.Parameters.AddWithValue("@position_z", garage_array[index].position.Z);
                myCommand.Parameters.AddWithValue("@position_a", garage_array[index].position_a);
                myCommand.ExecuteNonQuery();
                Mainpipeline.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }


    public static void PressKeyE(Player Client)
    {
        foreach (var entrace in garage_array)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.position, 4.0f))
            {
                int playerid = Main.getIdFromClient(Client);

                if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
                {
                    for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                    {
                        if (PlayerVehicle.vehicle_data[playerid].state[index] == 1)
                        {
                            if (PlayerVehicle.vehicle_data[playerid].handle[index].Exists && PlayerVehicle.vehicle_data[playerid].handle[index] == Client.Vehicle)
                            {
                                PlayerVehicle.vehicle_data[playerid].fuel[index] = Convert.ToInt32(Main.GetVehicleFuel(Client.Vehicle));
                                PlayerVehicle.vehicle_data[playerid].state[index] = 5;
                                PlayerVehicle.SavePlayerVehicle(Client, index);

                                NAPI.Task.Run(() =>
                                {
                                    PlayerVehicle.vehicle_data[playerid].handle[index].Delete();
                                }, delayTime: 200);

                                Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Parkirali ste "+ PlayerVehicle.vehicle_data[playerid].model[index] + " u garazu");
                                return;
                            }
                        }
                    }
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste vlasnik ovog vozila");
                }
                else
                {

                    List<dynamic> menu_item_list = new List<dynamic>();
                    int count = 0;
                    for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                    {
                        if (PlayerVehicle.vehicle_data[playerid].state[index] == 5)
                        {
                            menu_item_list.Add(new { Type = 1, Name = PlayerVehicle.vehicle_data[playerid].model[index], Description = "", RightLabel = "" });


                            Client.SetData<dynamic>("ListTrack_" + count, index);
                            count++;
                        }
                    }

                    if (count == 0)
                    {
                        InteractMenu_New.SendNotificationError(Client, "Nemate parkiranih vozila u garazi.");
                        return;
                    }


                    InteractMenu.CreateMenu(Client, "GARAGE_SYSTEM_RESPONSE", "RPV", "~g~Garaza", true, JsonConvert.SerializeObject(menu_item_list), false, BackgroundColor: "LightSlateGray");


                }
            }
        }
    }

    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "GARAGE_SYSTEM_RESPONSE")
        {
            int index = Client.GetData<dynamic>("ListTrack_" + selectedIndex);
            int playerid = Main.getIdFromClient(Client);


            if (PlayerVehicle.vehicle_data[playerid].state[index] == 5)
            {
                PlayerVehicle.vehicle_data[playerid].state[index] = 1;
                PlayerVehicle.SpawnPlayerVehicle(Client, index);

                PlayerVehicle.vehicle_data[playerid].handle[index].Position = Client.Position;
                PlayerVehicle.vehicle_data[playerid].handle[index].Rotation = Client.Rotation;



                try
                {
                  //  Client.SetIntoVehicle(PlayerVehicle.vehicle_data[playerid].handle[index], (int)VehicleSeat.Driver);
                    Main.DisplayRadar(Client, true);

                }
                catch
                {

                }

                PlayerVehicle.SavePlayerVehicle(Client, index);

                VehicleInventory.LoadVehicleInventoryItens(Client, PlayerVehicle.vehicle_data[playerid].handle[index], PlayerVehicle.vehicle_data[playerid].index[index]);
                Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Vozilo " + PlayerVehicle.vehicle_data[playerid].model[index] + " je izvadjeno sa parkinga");
            }
        }
    }


    [Command("creategarage")]
    public static void CMD_creategarage(Player Client)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }
        int count = 0;
        foreach (var garage in garage_array)
        {
            if (garage.position.X == 0 && garage.position.Y == 0)
            {
                
                Client.SendNotification("Kreirali ste garazu" + count);

                garage.position = Client.Position;
                garage.label.Position = Client.Position + new Vector3(0, 0, 0.5);
                garage.marker.Position = Client.Position - new Vector3(0, 0, 0.0);

                garage.blip.Position = garage.label.Position;

                garage.blip.Transparency = 255;
                NAPI.Blip.SetBlipTransparency(garage.blip, 255);

                SaveGaragem(count);
                return;
            }
            count++;
        }
    }

    [Command("destroygarage")]
    public static void CMD_destroygarage(Player Client)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) <= 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }
        int count = 0;
        foreach (var garage in garage_array)
        {
            if (Main.IsInRangeOfPoint(Client.Position, garage.position, 4.0f))
            {
               
                Client.SendNotification("Obrisali ste garazu" + count);

                garage.position = new Vector3(0, 0, 0);
                garage.label.Position = Client.Position;
                garage.marker.Position = Client.Position;

                garage.blip.Position = garage.label.Position;
                garage.blip.Transparency = 0;

                SaveGaragem(count);
                return;
            }
            count++;
        }
    }

}

