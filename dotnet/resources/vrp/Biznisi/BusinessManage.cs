using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BusinessManage : Script
{
    public static int MAX_BUSINESS = 50;

    public class BusinessEnum : IEquatable<BusinessEnum>
    {
        public int business_ID { get; set; }
        public string business_Name { get; set; }
        public int business_OwnerID { get; set; }
        public string business_OwnerName { get; set; }
        public int business_Type { get; set; }
        public int business_Price { get; set; }
        public string business_posX { get; set; }
        public string business_posY { get; set; }
        public string business_posZ { get; set; }

        public bool business_Lock { get; set; }
        public int business_Safe { get; set; }
        public int business_Inventory { get; set; }
        public int business_InventoryCapacity { get; set; }

        public int business_OrderState { get; set; }
        public int business_OrderAmount { get; set; }
        public Entity business_objects_blip { get; set; }
        public Entity business_object_MarkerID { get; set; }
        public TextLabel business_object_TextLabel { get; set; }
        public TextLabel business_second_label { get; set; }
        public ColShape business_object_Area { get; set; }

        public ColShape business_marker_area { get; set; }

        public int business_gas_refilling { get; set; }

        /// <summary>
        ///  Business Clothes Store Type Objects
        /// </summary>
        /// 

        public Vector3 business_clothes_shirt { get; set; }
        public float business_clothes_shirt_rotation { get; set; }
        public Entity business_clothes_shirt_marker { get; set; }
        public Entity business_clothes_shirt_label { get; set; }


        public Vector3 business_barber { get; set; }
        public float business_barber_rotation { get; set; }
        public Entity business_barber_marker { get; set; }
        public Entity business_barber_label { get; set; }

        /////Business Mavad Shimiae

        public int[] business_Chemical_price { get; set; } = new int[12];

        //   public int business_Chemical_priceLengh { get; set; } = 0;


        public Vector3 Chemical_position { get; set; }

        public Entity Chemical_label { get; set; }
        public Entity Chemical_marker { get; set; }


        /// <summary>
        /// Business Car Dealership Type Objects
        /// </summary>
        /// 
        public Vector3 business_dealership_buy { get; set; }
        public float business_dealership_buy_a { get; set; }

        public Entity business_dealership_buy_marker { get; set; }
        public Entity business_dealership_buy_label { get; set; }

        public Vector3 business_dealership_preview { get; set; }
        public float business_dealership_preview_a { get; set; }

        public Vector3 business_dealership_vehicle { get; set; }
        public float business_dealership_vehicle_a { get; set; }

        public float business_store_buy_x { get; set; }
        public float business_store_buy_y { get; set; }
        public float business_store_buy_z { get; set; }
        public float business_store_buy_a { get; set; }

        public Entity business_store_buy_marker { get; set; }
        public Entity business_store_buy_label { get; set; }

        public float business_gasstation_1_x { get; set; }
        public float business_gasstation_1_y { get; set; }
        public float business_gasstation_1_z { get; set; }

        public float business_gasstation_2_x { get; set; }
        public float business_gasstation_2_y { get; set; }
        public float business_gasstation_2_z { get; set; }

        public float business_gasstation_3_x { get; set; }
        public float business_gasstation_3_y { get; set; }
        public float business_gasstation_3_z { get; set; }

        public float business_gasstation_4_x { get; set; }
        public float business_gasstation_4_y { get; set; }
        public float business_gasstation_4_z { get; set; }

        public TextLabel business_manage_label { get; set; }
        public Marker business_manage_marker { get; set; }

        public float business_restock_manage_x { get; set; }
        public float business_restock_manage_y { get; set; }
        public float business_restock_manage_z { get; set; }


        public TextLabel business_restock_manage_label { get; set; }

        /// <summary>
        /// Bomba de Gasolina
        /// </summary>
        public int business_fuel_price { get; set; }

        public float[] business_pump_sale_price { get; set; } = new float[9];
        public float[] business_pump_sale_galons { get; set; } = new float[9];

        public float[] business_pump_capacity { get; set; } = new float[9];
        public float[] business_pump_galons { get; set; } = new float[9];

        public bool[] business_pump_using { get; set; } = new bool[9];

        public Vector3[] business_pump_position { get; set; } = new Vector3[9];
        public TextLabel[] business_pump_textlabel { get; set; } = new TextLabel[9];
        // public TextLabel[] business_pump_textlabel_secundary { get; set; } = new TextLabel[9];
        public TimerEx[] business_pump_timer { get; set; } = new TimerEx[9];
        public Vehicle[] business_pump_vehicle { get; set; } = new Vehicle[9];

        public Entity ammunation_label { get; set; }
        public Entity ammunation_marker { get; set; }




        public override string ToString()
        {
            return "ID: " + business_ID + "   Name: " + business_Name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            BusinessEnum objAsPart = obj as BusinessEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return business_ID;
        }
        public bool Equals(BusinessEnum other)
        {
            if (other == null) return false;
            return (this.business_ID.Equals(other.business_ID));
        }
    }

    public static List<BusinessEnum> business_list = new List<BusinessEnum>();

    public static void BusinessInit()
    {

        try
        {
            using (var Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM `business` LIMIT " + MAX_BUSINESS + ";", Mainpipeline);

                var index = 0;

                using (MySqlDataReader reader = query.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        business_list.Add(new BusinessEnum()
                        {
                            business_ID = reader.GetInt32("id"),
                            business_Name = reader.GetString("name"),
                            business_OwnerID = reader.GetInt32("owner_id"),
                            business_OwnerName = reader.GetString("owner_name"),
                            business_Type = reader.GetInt32("type"),
                            business_Price = reader.GetInt32("price"),
                            business_posX = reader.GetString("pos_x"),
                            business_posY = reader.GetString("pos_y"),
                            business_posZ = reader.GetString("pos_z"),
                            business_Lock = Convert.ToBoolean(reader.GetInt32("lock_status")),
                            business_Safe = reader.GetInt32("safe"),
                            business_Inventory = reader.GetInt32("inventory"),
                            business_InventoryCapacity = reader.GetInt32("inventory_capacity"),
                        });

                        string[] X = reader.GetString("chemical_xyz").Split(",");

                        business_list[index].Chemical_position = new Vector3(float.Parse(X[0]), float.Parse(X[1]), float.Parse(X[2]));

                        business_list[index].Chemical_marker = NAPI.Marker.CreateMarker(1, new Vector3(float.Parse(X[0]), float.Parse(X[1]), float.Parse(X[2]) - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));
                        business_list[index].Chemical_label = NAPI.TextLabel.CreateTextLabel("~g~Prodavnica hemije ~n~ ~w~[ ~g~Y~w~ ]", new Vector3(float.Parse(X[0]), float.Parse(X[1]), float.Parse(X[2]) + 0.3), 11, 0.600f, 0, new Color(221, 255, 0, 255));

                        business_list[index].business_objects_blip = NAPI.Blip.CreateBlip(new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ)), 0);
                        business_list[index].business_object_MarkerID = NAPI.Marker.CreateMarker(1, new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ) - 4.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));
                        //business_list[index].business_object_TextLabel = NAPI.TextLabel.CreateTextLabel("Undefined", new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ) + 0.65), 8, 0.400f, 4, new Color(221, 255, 0, 255));
                        business_list[index].business_second_label = NAPI.TextLabel.CreateTextLabel("", new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ) - 0.09), 3, 0.380f, 4, new Color(221, 255, 0, 255));
                        business_list[index].business_object_Area = NAPI.ColShape.CreateSphereColShape(new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ)), 55.0f);


                        string[] gg = reader.GetString("chemical_price").Split(",");
                        for (int ammu = 0; ammu < gg.Length; ammu++)
                        {
                            business_list[index].business_Chemical_price[ammu] = int.Parse(gg[ammu]);

                        }

                        business_list[index].business_store_buy_x = float.Parse(reader.GetString("business_store_buy_x"));
                        business_list[index].business_store_buy_y = float.Parse(reader.GetString("business_store_buy_y"));
                        business_list[index].business_store_buy_z = float.Parse(reader.GetString("business_store_buy_z"));

                        business_list[index].business_restock_manage_x = float.Parse(reader.GetString("business_restock_x"));
                        business_list[index].business_restock_manage_y = float.Parse(reader.GetString("business_restock_y"));
                        business_list[index].business_restock_manage_z = float.Parse(reader.GetString("business_restock_z"));

                        business_list[index].business_restock_manage_label = NAPI.TextLabel.CreateTextLabel("", new Vector3(business_list[index].business_restock_manage_x, business_list[index].business_restock_manage_y, business_list[index].business_restock_manage_z + 0.3), 16, 0.600f, 0, new Color(221, 255, 0, 50));


                        business_list[index].business_store_buy_label = NAPI.TextLabel.CreateTextLabel("~g~" + business_list[index].business_Name + "~w~  ~n~~w~[~g~ Y~w~ ]", new Vector3(business_list[index].business_store_buy_x, business_list[index].business_store_buy_y, business_list[index].business_store_buy_z + 0.5), 16, 0.800f, 0, new Color(221, 255, 0, 255));
                        business_list[index].business_store_buy_marker = NAPI.Marker.CreateMarker(1, new Vector3(business_list[index].business_store_buy_x, business_list[index].business_store_buy_y, business_list[index].business_store_buy_z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 80));


                        string[] temp_mysql_data = reader.GetString("clothes_store_position").ToString().Split('|');
                        business_list[index].business_clothes_shirt = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                        business_list[index].business_clothes_shirt_rotation = Convert.ToSingle(temp_mysql_data[3]);

                        business_list[index].business_clothes_shirt_marker = NAPI.Marker.CreateMarker(25, business_list[index].business_clothes_shirt - new Vector3(0, 0, 0.8), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));
                        business_list[index].business_clothes_shirt_label = NAPI.TextLabel.CreateTextLabel("~g~" + business_list[index].business_Name + "~y~~w~ ~y~~w~~n~~w~[~g~ Y~w~ ]", business_list[index].business_clothes_shirt + new Vector3(0, 0, 0.3), 11, 1.0f, 0, new Color(221, 255, 0, 255));


                        temp_mysql_data = reader.GetString("barber_store_position").ToString().Split('|');
                        business_list[index].business_barber = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                        business_list[index].business_barber_rotation = Convert.ToSingle(temp_mysql_data[3]);

                        business_list[index].business_barber_marker = NAPI.Marker.CreateMarker(25, business_list[index].business_barber - new Vector3(0, 0, 0.8), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));
                        business_list[index].business_barber_label = NAPI.TextLabel.CreateTextLabel("~g~" + business_list[index].business_Name + "~y~~w~ ~y~~w~~n~~w~[~g~ Y~w~ ]", business_list[index].business_barber + new Vector3(0, 0, 0.3), 11, 1.0f, 0, new Color(221, 255, 0, 255));


                        UpdateBusinessBlip(index);
                        index++;
                    }
                }
                Mainpipeline.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

    }

    public static void LoadBusinesDealership(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `business_type_dealership_points` WHERE `id` = " + index + " LIMIT 1;", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    string[] temp_mysql_data = reader.GetString("buy").ToString().Split('|');
                    business_list[index].business_dealership_buy = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                    business_list[index].business_dealership_buy_a = Convert.ToSingle(temp_mysql_data[3]);

                    temp_mysql_data = reader.GetString("preview").ToString().Split('|');
                    business_list[index].business_dealership_preview = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                    business_list[index].business_dealership_preview_a = Convert.ToSingle(temp_mysql_data[3]);

                    temp_mysql_data = reader.GetString("vehicle").ToString().Split('|');
                    business_list[index].business_dealership_vehicle = new Vector3(Convert.ToSingle(temp_mysql_data[0]), Convert.ToSingle(temp_mysql_data[1]), Convert.ToSingle(temp_mysql_data[2]));
                    business_list[index].business_dealership_vehicle_a = Convert.ToSingle(temp_mysql_data[3]);

                    business_list[index].business_dealership_buy_label = NAPI.TextLabel.CreateTextLabel("~g~~h~[ " + business_list[index].business_Name + " ]~h~~w~~n~~c~[~y~ Y~c~ ]", business_list[index].business_dealership_buy + new Vector3(0, 0, 0.3), 16, 0.600f, 0, new Color(221, 255, 0, 255));
                    business_list[index].business_dealership_buy_marker = NAPI.Marker.CreateMarker(1, business_list[index].business_dealership_buy - new Vector3(0, 0, 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));
                }
            }
            Mainpipeline.Close();
        }
    }

    public static void SaveBusiness(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            try
            {
                string query = "UPDATE business SET name = @name, owner_id = @owner_id, owner_name = @owner_name, type = @type, price = @price, pos_x = @pos_x, pos_y = @pos_y, pos_z = @pos_z, safe = @safe, inventory = @inventory, inventory_capacity = @inventory_capacity, lock_status = @lock_status,";
                query = query + "clothes_store_position = @clothes_store_position, barber_store_position = @barber_store_position, ";
                query = query + "chemical_price = @chemical_price,chemical_xyz=@chemical_xyz,business_store_buy_x = @business_store_buy_x, business_store_buy_y = @business_store_buy_y, business_store_buy_z = @business_store_buy_z, business_restock_x = @business_restock_x, business_restock_y = @business_restock_y, business_restock_z = @business_restock_z, ";
                query = query + " WHERE `id` = '" + business_list[index].business_ID + "'";
                

                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);


                string chemical_price = "";
                for (int weapon = 0; weapon < business_list[index].business_Chemical_price.Length - 1; weapon++)
                {
                    chemical_price = string.Concat(chemical_price, business_list[index].business_Chemical_price[weapon]);
                }

                myCommand.Parameters.AddWithValue("@chemical_price", chemical_price);
                myCommand.Parameters.AddWithValue("@chemical_xyz", "" + business_list[index].Chemical_position.X + "," + business_list[index].Chemical_position.Y + "," + business_list[index].Chemical_position.Z);

                myCommand.Parameters.AddWithValue("@name", business_list[index].business_Name);
                myCommand.Parameters.AddWithValue("@owner_id", business_list[index].business_OwnerID);
                myCommand.Parameters.AddWithValue("@owner_name", business_list[index].business_OwnerName);
                myCommand.Parameters.AddWithValue("@type", business_list[index].business_Type);
                myCommand.Parameters.AddWithValue("@price", business_list[index].business_Price);
                myCommand.Parameters.AddWithValue("@pos_x", "" + business_list[index].business_posX);
                myCommand.Parameters.AddWithValue("@pos_y", "" + business_list[index].business_posY);
                myCommand.Parameters.AddWithValue("@pos_z", "" + business_list[index].business_posZ);

                myCommand.Parameters.AddWithValue("@safe", business_list[index].business_Safe);
                myCommand.Parameters.AddWithValue("@inventory", business_list[index].business_Inventory);
                myCommand.Parameters.AddWithValue("@inventory_capacity", business_list[index].business_InventoryCapacity);
                myCommand.Parameters.AddWithValue("@lock_status", business_list[index].business_Lock);

                myCommand.Parameters.AddWithValue("@business_store_buy_x", "" + business_list[index].business_store_buy_x + "");
                myCommand.Parameters.AddWithValue("@business_store_buy_y", "" + business_list[index].business_store_buy_y + "");
                myCommand.Parameters.AddWithValue("@business_store_buy_z", "" + business_list[index].business_store_buy_z + "");

                myCommand.Parameters.AddWithValue("@business_restock_x", "" + business_list[index].business_restock_manage_x + "");
                myCommand.Parameters.AddWithValue("@business_restock_y", "" + business_list[index].business_restock_manage_y + "");
                myCommand.Parameters.AddWithValue("@business_restock_z", "" + business_list[index].business_restock_manage_z + "");


                string shirt = business_list[index].business_clothes_shirt.X + "|" + business_list[index].business_clothes_shirt.Y + "|" + business_list[index].business_clothes_shirt.Z + "|" + business_list[index].business_clothes_shirt_rotation;
                myCommand.Parameters.AddWithValue("@clothes_store_position", "" + shirt + "");



                string barber = business_list[index].business_barber.X + "|" + business_list[index].business_barber.Y + "|" + business_list[index].business_barber.Z + "|" + business_list[index].business_barber_rotation;
                myCommand.Parameters.AddWithValue("@barber_store_position", "" + barber + "");


                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            Mainpipeline.Close();
        }
    }

    public static void SaveBusinessDealership(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            try
            {
                string query = "UPDATE business_type_dealership_points SET buy = @buy, preview = @preview, vehicle = @vehicle WHERE `id` = '" + business_list[index].business_ID + "'";
                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                string buy = business_list[index].business_dealership_buy.X + "|" + business_list[index].business_dealership_buy.Y + "|" + business_list[index].business_dealership_buy.Z + "|" + business_list[index].business_dealership_buy_a;
                string preview = business_list[index].business_dealership_preview.X + "|" + business_list[index].business_dealership_preview.Y + "|" + business_list[index].business_dealership_preview.Z + "|" + business_list[index].business_dealership_preview_a;
                string vehicle = business_list[index].business_dealership_vehicle.X + "|" + business_list[index].business_dealership_vehicle.Y + "|" + business_list[index].business_dealership_vehicle.Z + "|" + business_list[index].business_dealership_vehicle_a;

                myCommand.Parameters.AddWithValue("@buy", "" + buy + "");
                myCommand.Parameters.AddWithValue("@preview", "" + preview + "");
                myCommand.Parameters.AddWithValue("@vehicle", "" + vehicle + "");

                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            Mainpipeline.Close();
        }
    }

    public static void UpdateBusinessBlip(int business_id)
    {
        if (business_list[business_id].business_Type == 1)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Prodavnica odece");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 73);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.7f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 46);
        }
        else if (business_list[business_id].business_Type == 2)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Prodavnica 24/7");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 628);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.7f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 2);
        }
        else if (business_list[business_id].business_Type == 8)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Salon letelica");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 43);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.7f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 38);
        }
        else if (business_list[business_id].business_Type == 9)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Salon kamiona");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 477);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.7f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 38);
        }
        else if (business_list[business_id].business_Type == 10)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Frizerski salon");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 71);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.7f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 51);
        }
        else if (business_list[business_id].business_Type == 11)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Prodavnica alata");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 566);// 648
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.7f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 6);
        }
        else if (business_list[business_id].business_Type == 12)
        {
            NAPI.Blip.SetBlipName(business_list[business_id].business_objects_blip, "Salon tetovaze");
            NAPI.Blip.SetBlipSprite(business_list[business_id].business_objects_blip, 75);
            NAPI.Blip.SetBlipShortRange(business_list[business_id].business_objects_blip, true);
            NAPI.Blip.SetBlipScale(business_list[business_id].business_objects_blip, 0.7f);
            NAPI.Blip.SetBlipColor(business_list[business_id].business_objects_blip, 38);
        }
        else
        {
            NAPI.Blip.SetBlipTransparency(business_list[business_id].business_objects_blip, 0);
        }
    }

    public static int GetPlayerInBusiness(Player Client)
    {
        return NAPI.Data.GetEntityData(Client, "player_in_business");
    }

    public static int GetPlayerInBusinessEx(Player Client)
    {
        int index = 0;
        float range = 50f;
        foreach (var business in business_list)
        {
            Vector3 target = new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ));


            switch (business.business_Type)
            {
                case 1: range = 30f; break;
                case 2: range = 30f; break;
                case 3: range = 30f; break;
                case 4: range = 75f; break;
                case 5: range = 80f; break;
            }

            if (Main.IsInRangeOfPoint(Client.Position, target, range))
            {
                return index;
            }
            index++;
        }
        return -1;
    }

    public static int GetPlayerInBusinessInType(Player Client, int type)
    {
        int index = 0;
        float range = 750f;
        foreach (var business in business_list)
        {
            Vector3 target = new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ));


            switch (business.business_Type)
            {
                case 1: range = 50f; break;
                case 2: range = 50f; break;
                case 3: range = 50f; break;
                case 4: range = 75f; break;
                case 5: range = 80f; break;
            }

            if (Main.IsInRangeOfPoint(Client.Position, target, range) && business.business_Type == type)
            {
                //NAPI.Util.ConsoleOutput(index.ToString());
                return index;
            }
            index++;
        }
        return -1;
    }

    public static int GetPlayerInBusinessInDealership(Player Client)
    {
        int index = 0;
        foreach (var business in business_list)
        {
            Vector3 target = new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ));


            if (Main.IsInRangeOfPoint(Client.Position, target, 75f) && (business.business_Type == 4 || business.business_Type == 6 || business.business_Type == 7 || business.business_Type == 8 || business.business_Type == 9))
            {
                return index;
            }
            index++;
        }
        return -1;
    }

    public static int GetPlayerInBusinessOwnerEx(Player Client, int type)
    {
        int index = 0;
        float range = 750f;
        foreach (var business in business_list)
        {
            Vector3 target = new Vector3(float.Parse(business_list[index].business_posX), float.Parse(business_list[index].business_posY), float.Parse(business_list[index].business_posZ));


            switch (business.business_Type)
            {
                case 1: range = 50f; break;
                case 2: range = 50f; break;
                case 3: range = 50f; break;
                case 4: range = 75f; break;
                case 5: range = 80f; break;
            }

            if (Main.IsInRangeOfPoint(Client.Position, target, range) && business.business_Type == type)
            {
                if (business.business_OwnerID == AccountManage.GetPlayerSQLID(Client))
                {
                    return index;
                }
            }
            index++;
        }
        return -1;
    }

    public static int GetPlayerInBusinessOwner(Player Client)
    {
        int index = 0;
        foreach (var business in business_list)
        {
            if (Main.IsInRangeOfPoint(Client.Position, business.business_object_MarkerID.Position, 20.0f))
            {
                if (business.business_OwnerID == AccountManage.GetPlayerSQLID(Client))
                {
                    return index;
                }
            }
            index++;
        }
        return -1;
    }

    public static void DestroyDynamicPump(int index, int pump)
    {
        business_list[index].business_pump_textlabel[pump].Delete();

    }

    public static string Business_Type(int business_type)
    {
        string type = "Unknown";
        switch (business_type)
        {
            case 1:
                {
                    type = "Clothing Store";
                    break;
                }
            case 2:
                {
                    type = "24/7";
                    break;
                }
            case 3:
                {
                    type = "Gun Shop";
                    break;
                }
            case 4:
                {
                    type = "Car Dealershop";
                    break;
                }
            case 5:
                {
                    type = "Gas station";
                    break;
                }
            case 6:
                {
                    type = "Motorcycle Dealershop";
                    break;
                }
            case 7:
                {
                    type = "Boat Dealership";
                    break;
                }
            case 8:
                {
                    type = "Aircraft Dealership";
                    break;
                }
            case 9:
                {
                    type = "Truck Dealership";
                    break;
                }
            case 10:
                {
                    type = "Barber Shop";
                    break;
                }
            case 11:
                {
                    type = "Tools Shop";
                    break;
                }
            case 12:
                {
                    type = "Tattoo Store";
                    break;
                }
            default:
                {
                    type = "Undefined";
                    break;
                }
        }
        return type;
    }

    public static int GetPlayerBusinessKey(Player Client)
    {
        return Client.GetData<dynamic>("character_business_key");
    }

}

