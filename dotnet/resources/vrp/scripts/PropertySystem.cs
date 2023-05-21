using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
class PropertySystem : Script
{
    public class EntraceEnum : IEquatable<EntraceEnum>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int blip_id { get; set; }
        public Blip blip { get; set; }
        public int blip_color { get; set; }
        public Vector3 blip_pos { get; set; }
        public int owner_id { get; set; }
        public sbyte Lock { get; set; }

        public int price { get; set; }
        public int isforsell { get; set; }

        public Vector3 exterior { get; set; }
        public Vector3 interior { get; set; }
        public float exterior_a { get; set; }
        public float interior_a { get; set; }
        public uint exterior_dimension { get; set; }
        public uint interior_dimension { get; set; }

        public TextLabel label { get; set; }
        public Marker marker { get; set; }

        public TextLabel label_interior { get; set; }
        public Marker marker_interior { get; set; }
        public ColShape ExColShape { get; set; }
        public ColShape InColShape { get; set; }

        public ColShape Sellpoint_colshape { get; set; }
        public TextLabel sellpoint_label { get; set; }
        public int sellproperty { get; set; }
        public int safemoney { get; set; }
        public business_type business_type { get; set; }


        public ColShape manage_colshape { get; set; }
        public TextLabel manage_label { get; set; }


        public List<Product> Products = new List<Product>();

        public override string ToString()
        {
            return "ID: " + id + "   Name: " + name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            EntraceEnum objAsPart = obj as EntraceEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(EntraceEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public class Product
    {
        public string name;
        public int type;
        public string picture;
        public int amount;
        public int price;
        public byte isforsell;
        public business_type biz_type;
        public string custom_data = "";

    }

    public class avaialble_products
    {
        public int type;
        public business_type biz_type;
        public string name;
        public int price;
        public string picture;
        public string custom_data = "";
    }

    public enum business_type
    {
        Market = 0,
        Ammounation = 1,
    }

    public static List<avaialble_products> productslist = new List<avaialble_products>();

    public PropertySystem()
    {
        productslist.Add(new avaialble_products { biz_type = business_type.Market, picture = "burger", name = "Burger", type = 1, price = 100 });
        productslist.Add(new avaialble_products { biz_type = business_type.Market, picture = "water", name = "Voda", type = 2, price = 50 });
        productslist.Add(new avaialble_products { biz_type = business_type.Market, picture = "hotdog", name = "Hot_Dog", type = 44, price = 50 });
        productslist.Add(new avaialble_products { biz_type = business_type.Market, picture = "sandwich", name = "Sandwich", type = 45, price = 50 });
        productslist.Add(new avaialble_products { biz_type = business_type.Market, picture = "cola", name = "Coca_Cola", type = 46, price = 50 });
        productslist.Add(new avaialble_products { biz_type = business_type.Market, picture = "redwine", name = "Red_Wine", type = 47, price = 50 });

        productslist.Add(new avaialble_products { biz_type = business_type.Ammounation, picture = "bat", name = "Bat", type = 0, price = 50, custom_data = "melee" });
        productslist.Add(new avaialble_products { biz_type = business_type.Ammounation, picture = "knuckleduster", name = "Knuckle", type = 0, price = 50, custom_data = "melee" });
        productslist.Add(new avaialble_products { biz_type = business_type.Ammounation, picture = "knife", name = "Knife", type = 0, price = 50, custom_data = "melee" });
        productslist.Add(new avaialble_products { biz_type = business_type.Ammounation, picture = "switchblade", name = "SwitchBlade", type = 0, price = 50, custom_data = "melee" });
        productslist.Add(new avaialble_products { biz_type = business_type.Ammounation, picture = "Pistol-Case", name = "SNSPistol", type = 0, price = 50, custom_data = "pistol" });
        productslist.Add(new avaialble_products { biz_type = business_type.Ammounation, picture = "Pistol-Case", name = "HeavyPistol", type = 0, price = 50, custom_data = "pistol" });
        productslist.Add(new avaialble_products { biz_type = business_type.Ammounation, picture = "Pistol-Case", name = "VintagePistol", type = 0, price = 50, custom_data = "pistol" });


    }

    public static List<EntraceEnum> entrace_data = new List<EntraceEnum>();

    public static int MAX_ENTRACE = 0;

    public static void EntraceSystemInit()
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `entraces`;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                List<Product> mamd = new List<Product>();


                var index = 0;
                while (reader.Read())
                {
                    entrace_data.Add(new EntraceEnum()
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        description = reader.GetString("description"),
                        blip_id = reader.GetInt32("blip_id"),
                        blip_color = reader.GetInt32("blip_color"),
                        owner_id = reader.GetInt32("owner_id"),
                        price = reader.GetInt32("price"),
                        Lock = reader.GetSByte("lock"),
                        exterior = new Vector3(reader.GetFloat("exterior_x"), reader.GetFloat("exterior_y"), reader.GetFloat("exterior_z")),
                        interior = new Vector3(reader.GetFloat("interior_x"), reader.GetFloat("interior_y"), reader.GetFloat("interior_z")),
                        blip_pos = new Vector3(float.Parse(reader.GetString("blip_pos").Split(",")[0]), float.Parse(reader.GetString("blip_pos").Split(",")[1]), float.Parse(reader.GetString("blip_pos").Split(",")[2])),
                        exterior_a = reader.GetFloat("exterior_a"),
                        interior_a = reader.GetFloat("interior_a"),
                        exterior_dimension = reader.GetUInt32("exterior_dimension"),
                        interior_dimension = reader.GetUInt32("interior_dimension"),
                        Products = NAPI.Util.FromJson<List<Product>>(reader.GetString("products")),

                        business_type = (business_type)reader.GetInt32("business_type"),
                        isforsell = reader.GetInt32("isforsell"),
                        safemoney = reader.GetInt32("safemoney"),
                        sellproperty = reader.GetInt32("sellproperty")
                    });


                    for (int i = 0; i < entrace_data[index].Products.Count; i++)
                    {
                        foreach (var item in productslist)
                        {
                            if (entrace_data[index].Products[i].type == item.type)
                            {
                                entrace_data[index].Products[i].biz_type = item.biz_type;
                                entrace_data[index].Products[i].custom_data = item.custom_data;
                            }
                        }
                    }


                    if (entrace_data[index].owner_id == -1)
                    {
                        entrace_data[index].Lock = 0;
                    }
                    if (entrace_data[index].sellproperty == 1)
                    {
                        entrace_data[index].label = NAPI.TextLabel.CreateTextLabel("~y~ This Property Is For Sell \n ~g~ $" + entrace_data[index].price + "\n ~y~/buyproperty", entrace_data[index].exterior, 5.0f, 0.6f, 4, new Color(221, 255, 0, 255), false, entrace_data[index].exterior_dimension);
                    }
                    else
                    {
                        if (entrace_data[index].description != "32")
                        {
                            entrace_data[index].label = NAPI.TextLabel.CreateTextLabel("~y~" + entrace_data[index].name + "~w~~n~~n~" + entrace_data[index].description, entrace_data[index].exterior, 5.0f, 0.6f, 4, new Color(221, 255, 0, 255), false, entrace_data[index].exterior_dimension);
                        }
                        else
                        {
                            entrace_data[index].label = NAPI.TextLabel.CreateTextLabel("~y~" + entrace_data[index].name + "~w~~n~~n~", entrace_data[index].exterior, 5.0f, 0.6f, 4, new Color(221, 255, 0, 255), false, entrace_data[index].exterior_dimension);
                        }
                    }

                    entrace_data[index].label_interior = NAPI.TextLabel.CreateTextLabel("- ~y~Exit~w~ -", entrace_data[index].interior, 5.0f, 0.6f, 4, new Color(221, 255, 0, 255), false, entrace_data[index].exterior_dimension);

                    if (entrace_data[index].blip_id != -1)
                    {
                        entrace_data[index].blip = NAPI.Blip.CreateBlip(uint.Parse(entrace_data[index].blip_id.ToString()), new Vector3(float.Parse(reader.GetString("blip_pos").Split(",")[0]), float.Parse(reader.GetString("blip_pos").Split(",")[1]), float.Parse(reader.GetString("blip_pos").Split(",")[2])), 0.8f, byte.Parse(entrace_data[index].blip_color.ToString()), entrace_data[index].name, shortRange: true, dimension: entrace_data[index].exterior_dimension);
                    }

                    /*if (float.Parse(reader.GetString("sellpoint").Split(",")[0]) != 0)
                    {
                        entrace_data[index].Sellpoint_colshape = NAPI.ColShape.CreateCylinderColShape(new Vector3(float.Parse(reader.GetString("sellpoint").Split(",")[0]), float.Parse(reader.GetString("sellpoint").Split(",")[1]), float.Parse(reader.GetString("sellpoint").Split(",")[2])), 2f, 2, entrace_data[index].interior_dimension);
                        entrace_data[index].Sellpoint_colshape.SetData("PB_index", index);

                        entrace_data[index].sellpoint_label = NAPI.TextLabel.CreateTextLabel("~w~[ ~y~E ~w~]", new Vector3(float.Parse(reader.GetString("sellpoint").Split(",")[0]), float.Parse(reader.GetString("sellpoint").Split(",")[1]), float.Parse(reader.GetString("sellpoint").Split(",")[2])), 5.0f, 0.6f, 4, new Color(221, 255, 0, 255), false, entrace_data[index].interior_dimension);

                    }*/

                    Vector3 manage = new Vector3(float.Parse(reader.GetString("manage").Split(",")[0]), float.Parse(reader.GetString("manage").Split(",")[1]), float.Parse(reader.GetString("manage").Split(",")[2]));

                    entrace_data[index].manage_colshape = NAPI.ColShape.CreateCylinderColShape(manage, 2f, 2, entrace_data[index].interior_dimension);
                    entrace_data[index].manage_colshape.SetData("PB_index", index);

                    if (entrace_data[index].isforsell == 1)
                    {
                        entrace_data[index].manage_label = NAPI.TextLabel.CreateTextLabel("Property~n~~n~~y~Type: ~g~" + entrace_data[index].business_type.ToString() + "~n~~y~/buyproperties ~n~~y~Price: ~g~$" + entrace_data[index].price, manage, 5, 0.6f, 4, new Color(221, 255, 0, 255), false, entrace_data[index].interior_dimension);
                    }
                    else
                    {
                        entrace_data[index].manage_label = NAPI.TextLabel.CreateTextLabel("", manage, 5, 0.6f, 4, new Color(221, 255, 0, 255), false, entrace_data[index].interior_dimension);
                    }

                    entrace_data[index].InColShape = NAPI.ColShape.CreateCylinderColShape(entrace_data[index].interior, 2f, 2, entrace_data[index].interior_dimension);
                    entrace_data[index].InColShape.SetData("PB_index", index);

                    entrace_data[index].ExColShape = NAPI.ColShape.CreateCylinderColShape(entrace_data[index].exterior, 2f, 2, entrace_data[index].exterior_dimension);
                    entrace_data[index].ExColShape.SetData("PB_index", index);


                    // entrace_data[index].marker = NAPI.Marker.CreateMarker(25, entrace_data[index].exterior - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(244, 217, 66, 150), false, entrace_data[index].exterior_dimension);
                    // entrace_data[index].marker_interior = NAPI.Marker.CreateMarker(25, entrace_data[index].interior - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(244, 217, 66, 150), false, entrace_data[index].interior_dimension);

                    index++;
                    MAX_ENTRACE++;
                }
            }
            Mainpipeline.Close();
        }
        foreach (var item in entrace_data)
        {
            foreach (var product in item.Products)
            {
                if (product.biz_type == business_type.Ammounation)
                {
                    product.type = Inventory.itens_available.FindIndex(x => x.name.ToLower() == product.name.ToLower());
                }
            }
        }
        foreach (var item in productslist)
        {
            if (item.biz_type == business_type.Ammounation)
            {
                item.type = Inventory.itens_available.FindIndex(x => x.name.ToLower() == item.name.ToLower());
            }
        }
    }


    public static void OnPlayerEnterColshape(Player client, ColShape shape)
    {
        client.SetData("PB_index", shape.GetData<dynamic>("PB_index"));
    }

    public static void OnPlayerExitColshape(Player client, ColShape shape)
    {
        client.ResetData("PB_index");

    }


    public static void SaveEntrace(int index)
    {

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                string query = "UPDATE `entraces` SET `business_type` = @business_type,`isforsell` = @isforsell,`name` = @name,`blip_pos` = @blip_pos,`manage` = @manage,`safemoney` = @safemoney,`sellpoint` = @sellpoint,`sellproperty` = @sellproperty,`products` = @products,`description` = @description,`price` = @price,`blip_id` = @blip_id,`blip_color` = @blip_color,`owner_id` = @owner_id,`lock` = @lock, `exterior_x` = @exterior_x, `exterior_y` = @exterior_y, `exterior_z` = @exterior_z, `exterior_a` = @exterior_a, `interior_x` = @interior_x, `interior_y` = @interior_y, `interior_z` = @interior_z, `interior_a` = @interior_a, `interior_dimension` = @interior_dimension, `exterior_dimension` = @exterior_dimension WHERE `id` = '" + entrace_data[index].id + "'";

                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                myCommand.Parameters.AddWithValue("@name", "" + entrace_data[index].name + "");
                myCommand.Parameters.AddWithValue("@description", "" + entrace_data[index].description + "");
                myCommand.Parameters.AddWithValue("@blip_id", "" + entrace_data[index].blip_id + "");
                myCommand.Parameters.AddWithValue("@blip_color", "" + entrace_data[index].blip_color + "");
                myCommand.Parameters.AddWithValue("@owner_id", "" + entrace_data[index].owner_id + "");
                myCommand.Parameters.AddWithValue("@lock", "" + entrace_data[index].Lock + "");
                myCommand.Parameters.AddWithValue("@price", "" + entrace_data[index].price + "");
                myCommand.Parameters.AddWithValue("@isforsell", "" + entrace_data[index].isforsell + "");
                myCommand.Parameters.AddWithValue("@business_type", "" + (int)entrace_data[index].business_type + "");
                myCommand.Parameters.AddWithValue("@blip_pos", "" + entrace_data[index].blip_pos.X + "," + entrace_data[index].blip_pos.Y + "," + entrace_data[index].blip_pos.Z + "");

                myCommand.Parameters.AddWithValue("@sellpoint", "" + entrace_data[index].sellpoint_label.Position.X + "," + entrace_data[index].sellpoint_label.Position.Y + "," + entrace_data[index].sellpoint_label.Position.Z + "");
                myCommand.Parameters.AddWithValue("@sellproperty", "" + entrace_data[index].sellproperty + "");
                myCommand.Parameters.AddWithValue("@products", "" + NAPI.Util.ToJson(entrace_data[index].Products) + "");

                myCommand.Parameters.AddWithValue("@manage", "" + entrace_data[index].manage_label.Position.X + "," + entrace_data[index].manage_label.Position.Y + "," + entrace_data[index].manage_label.Position.Z);
                myCommand.Parameters.AddWithValue("@safemoney", "" + entrace_data[index].safemoney);


                myCommand.Parameters.AddWithValue("@exterior_x", entrace_data[index].exterior.X);
                myCommand.Parameters.AddWithValue("@exterior_y", entrace_data[index].exterior.Y);
                myCommand.Parameters.AddWithValue("@exterior_z", entrace_data[index].exterior.Z);
                myCommand.Parameters.AddWithValue("@exterior_a", entrace_data[index].exterior_a);
                myCommand.Parameters.AddWithValue("@interior_x", entrace_data[index].interior.X);
                myCommand.Parameters.AddWithValue("@interior_y", entrace_data[index].interior.Y);
                myCommand.Parameters.AddWithValue("@interior_z", entrace_data[index].interior.Z);
                myCommand.Parameters.AddWithValue("@interior_a", entrace_data[index].interior_a);
                myCommand.Parameters.AddWithValue("@interior_dimension", entrace_data[index].interior_dimension);
                myCommand.Parameters.AddWithValue("@exterior_dimension", entrace_data[index].exterior_dimension);
                myCommand.ExecuteNonQuery();
                Mainpipeline.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }

    }


    public static void PressKeyY(Player Client)
    {
        if (Client.HasData("PB_index"))
        {

            int propid = Client.GetData<dynamic>("PB_index");

            if (Main.IsInRangeOfPoint(Client.Position, entrace_data[propid].exterior, 2.0f) && Client.Dimension == entrace_data[propid].exterior_dimension)
            {
                if (entrace_data[propid].Lock == 1)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Alert, NotifyPosition.BottomCenter, "Dar Ghofl Ast.");
                    return;
                }
                Client.TriggerEvent("freeze", true);
                Client.TriggerEvent("screenFadeOut", 100);
                Client.TriggerEvent("screenFadeIn", 3000);
                NAPI.Entity.SetEntityPosition(Client, entrace_data[propid].interior);
                Client.Rotation = new Vector3(0, 0, entrace_data[propid].interior_a);
                Client.Dimension = entrace_data[propid].interior_dimension;
                NAPI.Task.Run(() =>
                {
                    if (!Client.Exists)
                    {
                        return;
                    }
                    Client.TriggerEvent("freeze", false);

                }, delayTime: 1500);
                return;
            }
            else if (Main.IsInRangeOfPoint(Client.Position, entrace_data[propid].interior, 2.0f) && Client.Dimension == entrace_data[propid].interior_dimension)
            {
                if (entrace_data[propid].Lock == 1)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Alert, NotifyPosition.BottomCenter, "Dar Ghofl Ast.");
                    return;
                }
                Client.TriggerEvent("screenFadeOut", 100);
                Client.TriggerEvent("screenFadeIn", 3000);

                NAPI.Entity.SetEntityPosition(Client, entrace_data[propid].exterior);
                Client.Rotation = new Vector3(0, 0, entrace_data[propid].exterior_a);
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(Client))
                    {

                    Client.TriggerEvent("freeze", false);
                    Client.Dimension = entrace_data[propid].exterior_dimension;
                    }

                }, delayTime: 1500);
                return;
            }
        }
    }


    public void PropertySearchID(Player player, int id)
    {
        if (AccountManage.GetPlayerAdmin(player) < 7)
        {
            return;
        }
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (entrace_data.ElementAtOrDefault(id) == null)
        {
            Main.DisplayErrorMessage(player, NotifyType.Alert, NotifyPosition.BottomCenter, "Pogresan ID!");
            return;
        }
        Main.SendCustomChatMessasge(player, "~y~[~g~Property~y~] ~y~Owner: ~w~" + AccountManage.GetPlayerNameFromSQL(entrace_data[id].owner_id) + " ~y~Enter Pos: ~w~" + entrace_data[id].exterior.X + "," + entrace_data[id].exterior.Y + "," + entrace_data[id].exterior.Z);
    }

    
    public void AdminEditPrvateProperty(Player client, int PBID, string type, string value = "0")
    {
        if (AccountManage.GetPlayerConnected(client))
        {
            if (entrace_data.ElementAtOrDefault(PBID) == null)
            {
                Main.DisplayErrorMessage(client, NotifyType.Alert, NotifyPosition.BottomCenter, "Pogresan ID!");
                return;
            }
            if (client.GetData<dynamic>("admin_duty") == 0)
            {
                Main.SendErrorMessage(client, "Niste na duznosti, koristite /aduty!");
                return;
            }
            if (AccountManage.GetPlayerAdmin(client) > 6)
            {

                switch (type)
                {
                    case "name":
                        {
                            if (value.Length < 2 || value.Length > 31)
                            {
                                Main.DisplayErrorMessage(client, NotifyType.Alert, NotifyPosition.BottomCenter, "Naziv mora biti u formatu od 3 do 31 karaktera");
                                return;
                            }
                            entrace_data[PBID].name = value;
                            entrace_data[PBID].label.Text = "~y~" + entrace_data[PBID].name + "~w~~n~~n~" + entrace_data[PBID].description;
                            SaveEntrace(PBID);
                            break;
                        }
                    case "price":
                        {
                            if (!int.TryParse(value, out int j))
                            {
                                return;
                            }
                            else
                            {
                                entrace_data[PBID].price = j;
                                entrace_data[PBID].manage_label.Text = "Property~n~~n~~y~Type: ~g~" + entrace_data[PBID].business_type.ToString() + "~n~~y~/buyproperties ~n~~y~Price: ~g~$" + entrace_data[PBID].price;
                                SaveEntrace(PBID);
                            }

                            break;
                        }
                    case "type":
                        {
                            if (!int.TryParse(value, out int j))
                            {
                                return;
                            }
                            else
                            {
                                try
                                {
                                    entrace_data[PBID].business_type = (business_type)j;
                                    SaveEntrace(PBID);
                                }
                                catch (Exception)
                                {

                                }
                            }

                            break;
                        }
                    case "management":
                        {
                            if (entrace_data[PBID].manage_label.Exists)
                            {
                                entrace_data[PBID].manage_colshape.Position = client.Position;
                                entrace_data[PBID].manage_colshape.SetData("PB_index", PBID);
                                entrace_data[PBID].manage_label.Position = client.Position;

                            }
                            else
                            {
                                entrace_data[PBID].manage_colshape = NAPI.ColShape.CreateCylinderColShape(client.Position, 2f, 2, client.Dimension);
                                entrace_data[PBID].manage_colshape.SetData("PB_index", PBID);
                                entrace_data[PBID].manage_label = NAPI.TextLabel.CreateTextLabel("Koristite [ ~y~E ~w~] ~n~~w~za upravljanje nekretninom", client.Position, 5.0f, 0.6f, 4, new Color(221, 255, 0, 255), false, entrace_data[PBID].interior_dimension);
                            }
                            SaveEntrace(PBID);

                            break;
                        }
                    case "sellpoint":
                        {
                            if (entrace_data[PBID].sellpoint_label == null)
                            {
                                entrace_data[PBID].sellpoint_label = NAPI.TextLabel.CreateTextLabel("[ ~y~E ~w~]", client.Position, 5, 0.6f, 4, new Color(221, 255, 0, 255));
                                entrace_data[PBID].Sellpoint_colshape = NAPI.ColShape.CreateCylinderColShape(client.Position, 2, 2);
                                entrace_data[PBID].Sellpoint_colshape.SetData("PB_index", PBID);

                                SaveEntrace(PBID);
                            }
                            else
                            {
                                entrace_data[PBID].sellpoint_label.Position = client.Position;
                                entrace_data[PBID].Sellpoint_colshape.Position = client.Position;

                                SaveEntrace(PBID);
                            }

                            break;
                        }
                    case "enter":
                        {
                            entrace_data[PBID].exterior = client.Position;
                            entrace_data[PBID].exterior_a = client.Rotation.Z;
                            entrace_data[PBID].exterior_dimension = client.Dimension;
                            entrace_data[PBID].ExColShape.Position = client.Position;

                            entrace_data[PBID].blip.Position = client.Position;

                            SaveEntrace(PBID);
                            break;
                        }
                    case "blipid":
                        {

                            entrace_data[PBID].blip.Sprite = uint.Parse(value);
                            entrace_data[PBID].blip_id = int.Parse(value);
                            SaveEntrace(PBID);
                            break;
                        }
                    case "blipcolor":
                        {

                            entrace_data[PBID].blip.Color = int.Parse(value);
                            entrace_data[PBID].blip_color = int.Parse(value);
                            SaveEntrace(PBID);
                            break;
                        }
                    case "cblip":
                        {
                            if (entrace_data[PBID].blip == null)
                            {
                                entrace_data[PBID].blip = NAPI.Blip.CreateBlip(int.Parse(value), client.Position, 0.8f, 1, entrace_data[PBID].name, shortRange: true, dimension: 0);
                                entrace_data[PBID].blip_id = int.Parse(value);
                                entrace_data[PBID].blip_pos = client.Position;
                            }
                            else
                            {
                                entrace_data[PBID].blip.Position = client.Position;
                                entrace_data[PBID].blip_pos = client.Position;
                            }

                            SaveEntrace(PBID);
                            break;
                        }
                    case "exit":
                        {
                            entrace_data[PBID].interior = client.Position;
                            entrace_data[PBID].interior_a = client.Rotation.Z;
                            entrace_data[PBID].interior_dimension = client.Dimension;
                            entrace_data[PBID].label_interior.Position = client.Position;
                            entrace_data[PBID].marker_interior.Position = client.Position;
                            entrace_data[PBID].InColShape.Position = client.Position;

                            SaveEntrace(PBID);
                            break;
                        }
                    case "description":
                        {
                            if (value.Length < 2 || value.Length > 127)
                            {
                                Main.DisplayErrorMessage(client, NotifyType.Alert, NotifyPosition.BottomCenter, "Opis mora biti u opsegu od 2-127 karaktera");
                                return;
                            }
                            entrace_data[PBID].description = value;
                            entrace_data[PBID].label.Text = "~y~" + entrace_data[PBID].name + "~w~~n~~n~" + entrace_data[PBID].description;
                            SaveEntrace(PBID);

                            break;
                        }
                    default:
                        break;
                }
            }

        }
    }


    public void BuyProperties(Player player)
    {
        int PBID = player.GetData<dynamic>("PB_index");
        if (entrace_data.ElementAtOrDefault(PBID) == null)
        {
            Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Niste pored biznisa!");
            return;
        }
        if (Main.GetPlayerBank(player) < entrace_data[PBID].price)
        {
            Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca!");
            return;
        }
        if (entrace_data[PBID].isforsell == 0)
        {
            return;
        }

        entrace_data[PBID].manage_label.Text = "Koristite [ ~y~E ~w~] za upravljanje nekretninom";
        entrace_data[PBID].owner_id = AccountManage.GetPlayerSQLID(player);
        entrace_data[PBID].isforsell = 0;
        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste nekretninu!");
        SaveEntrace(PBID);


    }

    public void sellproperty(Player player, int price)
    {
        int PBID = player.GetData<dynamic>("PB_index");
        if (entrace_data.ElementAtOrDefault(PBID) == null)
        {
            Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate biznis!");
            return;
        }
        if (entrace_data[PBID].owner_id != AccountManage.GetPlayerSQLID(player))
        {
            Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Niste vlasnik ove nekretnine!");
            return;
        }
        if (price == 0)
        {
            Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Prodali ste nekretninu!");
            entrace_data[PBID].manage_label.Text = "Koristite [ ~y~E ~w~] za upravljanje nekretninom";
            entrace_data[PBID].isforsell = 0;
            SaveEntrace(PBID);

            return;
        }
        if (price < 1)
        {
            return;
        }

        entrace_data[PBID].manage_label.Text = "Biznis~n~~n~~y~Vrsta: ~g~" + entrace_data[PBID].business_type.ToString() + "~n~~y~/buyproperties ~n~~y~Cena: ~g~$" + entrace_data[PBID].price;
        entrace_data[PBID].isforsell = 1;
        entrace_data[PBID].price = price;
        SaveEntrace(PBID);
        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Property Baraye Forosh Gozashte Shod");
        Main.SendMessageToPlayer(player, "[~y~Biznis~w~] Cestitamo, prodali ste biznis za ~g~0$~w~.");

    }


    public void CreateProperty(Player player)
    {
        if (AccountManage.GetPlayerAdmin(player) <= 7)
        {
            Main.SendErrorMessage(player, "Niste ovlasceni!!");
            return;
        }
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Niste na duznosti, koristite /aduty!");
            return;
        }
        System.Threading.Tasks.Task.Run(() =>
        {
            for (int i = 0; i < entrace_data.Count; i++)
            {
                SaveEntrace(i);
            }

            entrace_data.Clear();
            EntraceSystemInit();

        });

    }

   
    public void EditPrivateBusiness(Player client, string type, string value = "0")
    {
        if (AccountManage.GetPlayerConnected(client))
        {
            int PBID = client.GetData<dynamic>("PB_index");
            if (entrace_data.ElementAtOrDefault(PBID) == null)
            {
                Main.DisplayErrorMessage(client, NotifyType.Alert, NotifyPosition.BottomCenter, "Nemate biznis.");
                return;
            }
            if (entrace_data[PBID].owner_id == AccountManage.GetPlayerSQLID(client))
            {

                switch (type)
                {
                    case "name":
                        {
                            if (client.HasData("PB_index"))
                            {
                                if (value.Length < 2 || value.Length > 31)
                                {
                                    Main.DisplayErrorMessage(client, NotifyType.Alert, NotifyPosition.BottomCenter, "Ime mora biti u opsegu od 2 do 31 karaktera!");
                                    return;
                                }
                                entrace_data[PBID].name = value;
                                entrace_data[PBID].label.Text = "~y~" + entrace_data[PBID].name + "~w~~n~~n~" + entrace_data[PBID].description;
                                SaveEntrace(PBID);
                            }
                            break;
                        }
                    case "description":
                        {
                            if (client.HasData("PB_index"))
                            {
                                if (value.Length < 2 || value.Length > 127)
                                {
                                    Main.DisplayErrorMessage(client, NotifyType.Alert, NotifyPosition.BottomCenter, "Opis mora biti u opsegu od 2 do 127 karaktera.");
                                    return;
                                }
                                entrace_data[PBID].description = value;
                                entrace_data[PBID].label.Text = "~y~" + entrace_data[PBID].name + "~w~~n~~n~" + entrace_data[PBID].description;
                                SaveEntrace(PBID);

                            }
                            break;
                        }
                    default:
                        break;
                }
            }

        }
    }

    [RemoteEvent("property_deposit_fund")]
    public static void property_deposit_fund(Player player, int value)
    {
        int PBID = player.GetData<dynamic>("PB_index");
        if (entrace_data.ElementAtOrDefault(PBID) == null)
        {
            Main.DisplayErrorMessage(player, NotifyType.Alert, NotifyPosition.BottomCenter, "Nemate biznis.");
            return;
        }
        if (entrace_data[PBID].owner_id != AccountManage.GetPlayerSQLID(player))
        {
            return;
        }
        if (Main.GetPlayerMoney(player) < value)
        {
            Main.SendCustomChatMessasge(player, "~w~[~g~Property~w~] Nemate dovoljno novca!");
            return;
        }
        entrace_data[PBID].safemoney += value;
        Main.GivePlayerMoney(player, -value);
        SaveEntrace(PBID);
    }

    [RemoteEvent("property_withdraw_fund")]
    public static void property_withdraw_fund(Player player, int value)
    {
        int PBID = player.GetData<dynamic>("PB_index");
        if (entrace_data.ElementAtOrDefault(PBID) == null)
        {
            Main.DisplayErrorMessage(player, NotifyType.Alert, NotifyPosition.BottomCenter, "Nemate biznis.");
            return;
        }
        if (entrace_data[PBID].owner_id != AccountManage.GetPlayerSQLID(player))
        {
            return;
        }
        if (entrace_data[PBID].safemoney < value)
        {
            Main.SendCustomChatMessasge(player, "~w~[~g~Property~w~] U sefu biznisa nema dovoljno novca!");
            return;
        }
        entrace_data[PBID].safemoney -= value;
        Main.GivePlayerMoney(player, value);
        SaveEntrace(PBID);

    }

    [RemoteEvent("property_change_name")]
    public static void property_change_name(Player player, string name)
    {
        int PBID = player.GetData<dynamic>("PB_index");
        if (entrace_data.ElementAtOrDefault(PBID) == null)
        {
            Main.DisplayErrorMessage(player, NotifyType.Alert, NotifyPosition.BottomCenter, "Nemate biznis.");
            return;
        }
        if (entrace_data[PBID].owner_id != AccountManage.GetPlayerSQLID(player))
        {
            return;
        }
        if (name.Length < 4 || name.Length > 50)
        {
            Main.SendCustomChatMessasge(player, "~w~[~g~Property~w~] Ime biznisa mora imati najmanje 4 i najvise 50 karaktera.");
            return;
        }
        entrace_data[PBID].name = name;
        SaveEntrace(PBID);

    }

    [RemoteEvent("property_Save")]
    public static void property_Save(Player player, string name, int price, byte visibility)
    {
        int PBID = player.GetData<dynamic>("PB_index");
        if (entrace_data.ElementAtOrDefault(PBID) == null)
        {
            Main.DisplayErrorMessage(player, NotifyType.Alert, NotifyPosition.BottomCenter, "Nemate biznis.");
            return;
        }
        if (entrace_data[PBID].owner_id != AccountManage.GetPlayerSQLID(player))
        {
            return;
        }
        int index = 0;
        foreach (var item in entrace_data[PBID].Products)
        {
            if (item.name == name)
            {
                entrace_data[PBID].Products[index].isforsell = visibility;
                entrace_data[PBID].Products[index].price = price;
                SaveEntrace(PBID);
                return;
            }
            index++;
        }
        SaveEntrace(PBID);

    }

    [RemoteEvent("Buypropertie_Stock")]
    public static void Buypropertie_Stock(Player player, int type, string picture, string name, int stock, int price)
    {
        int PBID = player.GetData<dynamic>("PB_index");
        if (entrace_data.ElementAtOrDefault(PBID) == null)
        {
            Main.DisplayErrorMessage(player, NotifyType.Alert, NotifyPosition.BottomCenter, "Nemate biznis.");
            return;
        }
        if (entrace_data[PBID].owner_id != AccountManage.GetPlayerSQLID(player))
        {
            return;
        }
        if (entrace_data[PBID].safemoney < (stock * price))
        {
            Main.SendCustomChatMessasge(player, "~w~[~g~Property~w~] Nemate dovoljno novca u sefu biznisa.");
            return;
        }
        int index = 0;
        foreach (var item in entrace_data[PBID].Products)
        {
            if (item.name == name)
            {
                entrace_data[PBID].Products[index].amount += stock;
                entrace_data[PBID].safemoney -= (stock * price);
                SaveEntrace(PBID);
                return;
            }
            index++;
        }


        entrace_data[PBID].Products.Add(new Product { isforsell = 0, amount = stock, name = name, price = price, picture = picture, type = type, custom_data = productslist.Find(x => x.name == name).custom_data, biz_type = productslist.Find(x => x.name == name).biz_type });
        entrace_data[PBID].safemoney -= (stock * price);
        SaveEntrace(PBID);

    }


    public static void ShowPropertyManagement(Player Client)
    {
        int PBID = Client.GetData<dynamic>("PB_index");
        if (entrace_data.ElementAtOrDefault(PBID) == null)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Alert, NotifyPosition.BottomCenter, "Nemate biznis.");
            return;
        }
        if (entrace_data[PBID].owner_id != AccountManage.GetPlayerSQLID(Client))
        {
            return;
        }

        List<avaialble_products> product_shop = new List<avaialble_products>();
        foreach (var prod in productslist)
        {
            if (prod.biz_type == entrace_data[PBID].business_type)
            {
                product_shop.Add(new avaialble_products { picture = prod.picture, name = prod.name, price = prod.price, type = prod.type });
            }
        }

        List<Product> product_forsell = new List<Product>();
        foreach (var item in entrace_data[PBID].Products)
        {
            product_forsell.Add(new Product { isforsell = item.isforsell, amount = item.amount, name = item.name, picture = item.picture, price = item.price, type = item.type });
        }

        Client.TriggerEvent("Display_property_Manage", entrace_data[PBID].name, "Property Management", entrace_data[PBID].safemoney, NAPI.Util.ToJson(product_shop), NAPI.Util.ToJson(product_forsell));
    }


    [RemoteEvent("customshop")]
    public static void CustomShopRespone(Player player, int selected, string selectedname, int purchasedAmount)
    {
        int PBID = player.GetData<dynamic>("PB_index");
        if (entrace_data.ElementAtOrDefault(PBID) == null)
        {
            return;
        }
        if (purchasedAmount < 1)
        {
            return;
        }
        switch (entrace_data[PBID].Products[selected].biz_type)
        {
            case business_type.Market:
                break;
            case business_type.Ammounation:
                switch (entrace_data[PBID].Products[selected].custom_data)
                {

                    case "bullet":
                        {
                            switch (entrace_data[PBID].Products[selected].type)
                            {
                                case 3:
                                    //Inventory.GiveItemToInventory(player, 3, 15);
                                    break;
                                case 4:
                                    //  Inventory.GiveItemToInventory(player, 3, 15);
                                    break;
                                case 5:
                                    //   Inventory.GiveItemToInventory(player, 3, 15);
                                    break;
                                case 6:
                                    purchasedAmount = 50;
                                    break;
                                case 7:
                                    //  Inventory.GiveItemToInventory(player, 3, 15);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        if (entrace_data[PBID].Products[selected].name == selectedname)
        {
            if ((entrace_data[PBID].Products[selected].price * purchasedAmount) > Main.GetPlayerMoney(player))
            {
                Main.SendCustomChatMessasge(player, "[~g~Property~w~] Kupili ste nesto.");
                return;
            }
            if (entrace_data[PBID].Products[selected].amount < purchasedAmount)
            {
                Main.SendCustomChatMessasge(player, "[~g~Property~w~] Prodali ste nesto..");
                return;
            }
            Main.GivePlayerMoney(player, -(purchasedAmount * entrace_data[PBID].Products[selected].price));
            entrace_data[PBID].Products[selected].amount -= 1;
            Inventory.GiveItemToInventory(player, entrace_data[PBID].Products[selected].type, purchasedAmount);
            SaveEntrace(PBID);
        }
    }

    public static void CallShopMenu(Player player, string JsonList, string business_name, string return_name, float profit_percent = 1)
    {
        player.TriggerEvent("LoadShopMenu", JsonList, business_name, return_name, profit_percent);
    }

    public static void PressKeyE(Player player)
    {
        if (player.HasData("PB_index"))
        {
            int propid = player.GetData<dynamic>("PB_index");
            if (entrace_data[propid].sellpoint_label.Position.DistanceTo(player.Position) <= 2 && entrace_data[propid].interior_dimension == player.Dimension)
            {
                List<dynamic> menu_item_list = new List<dynamic>();
                switch (entrace_data[propid].business_type)
                {
                    case business_type.Market:

                        foreach (var store in entrace_data[propid].Products)
                        {
                            if (store.isforsell == 1 && store.amount != 0)
                            {
                                menu_item_list.Add(new { index = entrace_data[propid].Products.IndexOf(store), type = store.type, name = store.name, price = store.price, picture = store.picture });
                            }
                        }

                        player.TriggerEvent("LoadShopMenu", NAPI.Util.ToJson(menu_item_list), entrace_data[propid].name, "customshop", 1);
                        break;
                }


                //CallShopMenu(player, NAPI.Util.ToJson(menu_item_list), entrace_data[propid].name, "customshop");
            }
            else if (entrace_data[propid].manage_label.Position.DistanceTo(player.Position) <= 2 && player.Dimension == entrace_data[propid].interior_dimension && entrace_data[propid].owner_id == AccountManage.GetPlayerSQLID(player))
            {
                ShowPropertyManagement(player);
                return;
            }
        }
    }

    public static void PressKeyK(Player Client)
    {
        if (Client.HasData("PB_index"))
        {

            int propid = Client.GetData<dynamic>("PB_index");
            if ((Main.IsInRangeOfPoint(Client.Position, entrace_data[propid].exterior, 2.0f) || Main.IsInRangeOfPoint(Client.Position, entrace_data[propid].interior, 2.0f)) && Client.Dimension == entrace_data[propid].exterior_dimension && entrace_data[propid].owner_id == AccountManage.GetPlayerSQLID(Client) && entrace_data[propid].Lock == 1)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "~g~Otkljucali ste ~w~biznis.");
                entrace_data[propid].Lock = 0;
                SaveEntrace(propid);

                return;
            }
            else if ((Main.IsInRangeOfPoint(Client.Position, entrace_data[propid].interior, 2.0f) || Main.IsInRangeOfPoint(Client.Position, entrace_data[propid].exterior, 2.0f)) && Client.Dimension == entrace_data[propid].interior_dimension && entrace_data[propid].owner_id == AccountManage.GetPlayerSQLID(Client) && entrace_data[propid].Lock == 0)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "~r~Zakljucali ste ~w~biznis..");
                entrace_data[propid].Lock = 1;
                SaveEntrace(propid);

                return;
            }

        }
    }

    public void CMD_editentrance(Player Client, int entrace_id, string type, string data)
    {
        if (AccountManage.GetPlayerAdmin(Client) <= 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }

        if (entrace_id < 1 && entrace_id > MAX_ENTRACE)
        {
            Main.SendErrorMessage(Client, "Vrednost ne moze biti manja od 1 ili veca od " + MAX_ENTRACE + ".");
            return;
        }

        if (type == "name")
        {
            InteractMenu.User_Input(Client, "input_entrace_name", "Edit Entry Name", entrace_data[entrace_id].name);
            Client.SetData("entrace_id", entrace_id);
        }
        else if (type == "owner")
        {

            Main.SendCustomChatMessasge(Client, "Cena " + entrace_id + " je postavljena na: " + data);
            entrace_data[entrace_id].owner_id = int.Parse(data);


            SaveEntrace(entrace_id);
        }
        else if (type == "price")
        {

            Main.SendCustomChatMessasge(Client, "Cena " + entrace_id + " je postavljena na: " + data);
            entrace_data[entrace_id].price = int.Parse(data);


            SaveEntrace(entrace_id);
        }
        else if (type == "exterior")
        {

            Main.SendCustomChatMessasge(Client, "Mesto izlaza biznisa " + entrace_id + " je postavljeno na Vasu trenutnu poziciju.");
            entrace_data[entrace_id].exterior = Client.Position;
            entrace_data[entrace_id].exterior_a = Client.Rotation.Z;
            entrace_data[entrace_id].exterior_dimension = Client.Dimension;
            entrace_data[entrace_id].label.Position = Client.Position;
            // entrace_data[entrace_id].marker.Position = Client.Position - new Vector3(0, 0, 0.8f);

            entrace_data[entrace_id].label.Delete();
            entrace_data[entrace_id].label = NAPI.TextLabel.CreateTextLabel("~y~" + entrace_data[entrace_id].name + "~w~~n~~n~" + entrace_data[entrace_id].description, entrace_data[entrace_id].exterior, 5.0f, 0.6f, 4, new Color(221, 255, 0, 255), false, entrace_data[entrace_id].exterior_dimension);


            SaveEntrace(entrace_id);
        }
        else if (type == "interior")
        {
            Main.SendCustomChatMessasge(Client, "Mesto enterijera biznisa " + entrace_id + " je postavljeno na Vasu trenutnu poziciju.");



            entrace_data[entrace_id].interior = Client.Position;
            entrace_data[entrace_id].interior_a = Client.Rotation.Z;
            entrace_data[entrace_id].interior_dimension = Client.Dimension;
            entrace_data[entrace_id].label_interior.Position = Client.Position;
            //   entrace_data[entrace_id].marker_interior.Position = Client.Position - new Vector3(0, 0, 0.8f);

            entrace_data[entrace_id].label_interior.Delete();
            entrace_data[entrace_id].label_interior = NAPI.TextLabel.CreateTextLabel("- ~y~Izlaz~w~ -", entrace_data[entrace_id].interior, 5.0f, 0.6f, 4, new Color(221, 255, 0, 255), false, entrace_data[entrace_id].exterior_dimension);

            SaveEntrace(entrace_id);
        }
        else if (type == "delete")
        {
            Main.SendCustomChatMessasge(Client, "Obrisali ste biznis: " + entrace_id + ".");

            entrace_data[entrace_id].name = "";
            entrace_data[entrace_id].exterior = new Vector3(0, 0, 0);
            entrace_data[entrace_id].interior = new Vector3(0, 0, 0);
            entrace_data[entrace_id].exterior_dimension = 0;
            entrace_data[entrace_id].interior_dimension = 0;
            entrace_data[entrace_id].exterior_a = 0;
            entrace_data[entrace_id].interior_a = 0;
            entrace_data[entrace_id].label.Position = new Vector3(0, 0, 0);
            entrace_data[entrace_id].label_interior.Position = new Vector3(0, 0, 0);

            // entrace_data[entrace_id].marker.Position = new Vector3(0, 0, 0);
            //  entrace_data[entrace_id].marker_interior.Position = new Vector3(0, 0, 0);
            SaveEntrace(entrace_id);
        }
    }

    public static void OnInputResponse(Player Client, String response, String inputtext)
    {
        if (response == "input_entrace_name")
        {
            entrace_data[Client.GetData<dynamic>("entrace_id")].name = inputtext;
            Main.SendCustomChatMessasge(Client, "Postavili ste naziv biznisa " + Client.GetData<dynamic>("entrace_id") + " na ~b~" + inputtext + "~w~.");
            SaveEntrace(Client.GetData<dynamic>("entrace_id"));
            entrace_data[Client.GetData<dynamic>("entrace_id")].label_interior.Text = "- Saida -";
            entrace_data[Client.GetData<dynamic>("entrace_id")].label.Text = "" + entrace_data[Client.GetData<dynamic>("entrace_id")].name + "~n~~n~Koristite ~y~Y~w~ ";
            Client.ResetData("entrace_id");
        }
    }

}

