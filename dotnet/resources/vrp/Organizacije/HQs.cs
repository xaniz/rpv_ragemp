using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

class WerehouseManage : Script
{
    public static int HQ_TYPE_GANG = 1;
    public static int HQ_TYPE_MAFIA = 2;
    public static int MAX_INVENTORY_WIGHT = 150;    
    public static int MAX_INVENTORY_ITENS = 100;

    public class WerehouseEnum : IEquatable<WerehouseEnum>
    {
        public int id { get; set; }

        public string name { get; set; }
        public int ownerid { get; set; }
        public int safe { get; set; }
        public int price { get; set; }
        public int type { get; set; }

        public float exterior_x { get; set; }
        public float exterior_y { get; set; }
        public float exterior_z { get; set; }
        public float exterior_a { get; set; }

        public float interior_x { get; set; }
        public float interior_y { get; set; }
        public float interior_z { get; set; }
        public float interior_a { get; set; }

        public float menu_x { get; set; }
        public float menu_y { get; set; }
        public float menu_z { get; set; }

        public ColShape menuArea { get; set; }

        public Entity exteriorLabel { get; set; }
        public Entity exteriorMarker { get; set; }

        public TextLabel menuLabel { get; set; }
        public TextLabel interiorLabel { get; set; }
        public Marker interiorMarker { get; set; }

        public bool lockStatus { get; set; }

        public bool using_inventory { get; set; }

        public string[] gun { get; set; } = new string[20];
        public int[] gun_units { get; set; } = new int[20];
        public int[] gun_perm { get; set; } = new int[20];

        public int[] inventory_index { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] inventory_type { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] inventory_amount { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] inventory_slotid { get; set; } = new int[MAX_INVENTORY_ITENS];

        public string[] safe_gun { get; set; } = new string[20];

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            WerehouseEnum objAsPart = obj as WerehouseEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(WerehouseEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<WerehouseEnum> WereHouseData = new List<WerehouseEnum>();
    public static List<dynamic> weapon_order_list = new List<dynamic>();
    public static void WerehouseManageInit()
    {



        // Blips



        /*Entity temp_blip;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-216.6387, -1674.162, 34.46332));
        NAPI.Blip.SetBlipName(temp_blip, "Grove Street Families HQ");
        NAPI.Blip.SetBlipSprite(temp_blip, 437);
        NAPI.Blip.SetBlipColor(temp_blip, 52);
        NAPI.Blip.SetBlipScale(temp_blip, 1.0f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(85.91128, -1959.444, 21.12169));
        NAPI.Blip.SetBlipName(temp_blip, "Front Yard Ballas HQ");
        NAPI.Blip.SetBlipSprite(temp_blip, 437);
        NAPI.Blip.SetBlipColor(temp_blip, 27);
        NAPI.Blip.SetBlipScale(temp_blip, 1.0f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1549.285, -90.86725, 54.92913));
        NAPI.Blip.SetBlipName(temp_blip, "Yakuza HQ");
        NAPI.Blip.SetBlipSprite(temp_blip, 437);
        NAPI.Blip.SetBlipColor(temp_blip, 6);
        NAPI.Blip.SetBlipScale(temp_blip, 1.0f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-113.489, 985.6472, 235.7542));
        NAPI.Blip.SetBlipName(temp_blip, "Russian HQ");
        NAPI.Blip.SetBlipSprite(temp_blip, 437);
        NAPI.Blip.SetBlipColor(temp_blip, 39);
        NAPI.Blip.SetBlipScale(temp_blip, 1.0f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);*/
        //



        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `faction_werehouse`;", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                var index = 0;
                while (reader.Read())
                {
                    WereHouseData.Add(new WerehouseEnum()
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        ownerid = reader.GetInt32("ownerid"),
                        price = reader.GetInt32("price"),
                        safe = reader.GetInt32("safe"),
                        type = reader.GetInt32("type"),

                        lockStatus = true,

                        exterior_x = reader.GetFloat("exterior_x"),
                        exterior_y = reader.GetFloat("exterior_y"),
                        exterior_z = reader.GetFloat("exterior_z"),
                        exterior_a = reader.GetFloat("exterior_a"),

                        interior_x = reader.GetFloat("interior_x"),
                        interior_y = reader.GetFloat("interior_y"),
                        interior_z = reader.GetFloat("interior_z"),
                        interior_a = reader.GetFloat("interior_a"),

                        menu_x = reader.GetFloat("menu_x"),
                        menu_y = reader.GetFloat("menu_y"),
                        menu_z = reader.GetFloat("menu_z"),

                        using_inventory = false,

                    });


                    for (int i = 0; i < 20; i++)
                    {
                        WereHouseData[index].gun[i] = reader.GetString("gun_" + i);
                        WereHouseData[index].gun_units[i] = reader.GetInt32("gun_units_" + i);
                        WereHouseData[index].gun_perm[i] = reader.GetInt32("gun_perm_" + i);
                        WereHouseData[index].safe_gun[i] = reader.GetString("safe_gun_" + i);
                    }


                    WereHouseData[index].exteriorLabel = NAPI.TextLabel.CreateTextLabel(" ", new Vector3(WereHouseData[index].exterior_x, WereHouseData[index].exterior_y, WereHouseData[index].exterior_z + 0.6), 14, 0.600f, 0, new Color(221, 255, 0, 255));
                    WereHouseData[index].exteriorMarker = NAPI.Marker.CreateMarker(30, new Vector3(WereHouseData[index].exterior_x, WereHouseData[index].exterior_y, WereHouseData[index].exterior_z - 0.3), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 255));

                    UpdateWerehousePickup(index);

                    WereHouseData[index].menuArea = NAPI.ColShape.CreateSphereColShape(new Vector3(WereHouseData[index].menu_x, WereHouseData[index].menu_y, WereHouseData[index].menu_z), 1.0f);

                    WereHouseData[index].menuArea.OnEntityEnterColShape += (s, ent) =>
                    {
                        Player Client;

                        if ((Client = NAPI.Player.GetPlayerFromHandle(ent)) != null)
                        {
                            if (Client.GetData<dynamic>("status") == false) return;
                            Main.DisplaySubtitle(Client, "Koristite <C>[ ~b~Y~w~ ]</C> da pristupite meniju", 3);
                        }
                    };


                    WereHouseData[index].menuLabel = API.Shared.CreateTextLabel("~g~~y~ Skladiste~g~", new Vector3(WereHouseData[index].menu_x, WereHouseData[index].menu_y, WereHouseData[index].menu_z - 0.2f), 8.0f, 0.8f, 4, new Color(221, 255, 0, 255));


                    // MELEE
                    weapon_order_list.Add(new { order_model = "Bat", order_price = 300, permission = 0 });
                    weapon_order_list.Add(new { order_model = "SwitchBlade", order_price = 550, permission = 0, });
                    weapon_order_list.Add(new { order_model = "PoolCue", order_price = 550, permission = 0, });
                    weapon_order_list.Add(new { order_model = "KnuckleDuster", order_price = 450, permission = 0, });
                    // pistolAS


                    for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
                    {
                        WereHouseData[index].inventory_index[i] = -1;
                        WereHouseData[index].inventory_type[i] = 0;
                        WereHouseData[index].inventory_amount[i] = 0;
                    }

                    LoadInventoryItens(index);

                    index++;
                }

            }
            Mainpipeline.Close();
        }

        //   NAPI.TextLabel.CreateTextLabel("- ~c~Sair da HQ~w~ -", new Vector3(-3183.432, -39.16352, 89.57901), 8.0f, 0.6f, 0, new Color(221, 255, 0, 255), false);
        //   NAPI.Marker.CreateMarker(25, new Vector3(-3183.432, -39.16352, 89.57901) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(221, 255, 0, 150), false);

        //  NAPI.TextLabel.CreateTextLabel("- ~c~Sair da HQ~w~ -", new Vector3(997.0402, -3194.924, -36.39373), 8.0f, 0.6f, 0, new Color(221, 255, 0, 255), false);
        //  NAPI.Marker.CreateMarker(25, new Vector3(997.0402, -3194.924, -36.39373) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(221, 255, 0, 150), false);

        //  NAPI.TextLabel.CreateTextLabel("- ~c~Sair da HQ~w~ -", new Vector3(1088.689, -3187.844, -38.99347), 8.0f, 0.6f, 0, new Color(221, 255, 0, 255), false);
        // NAPI.Marker.CreateMarker(25, new Vector3(1088.689, -3187.844, -38.99347) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(221, 255, 0, 150), false);
        //
        //   NAPI.TextLabel.CreateTextLabel("- ~c~Sair da HQ~w~ -", new Vector3(981.3119, -102.4228, 74.84509), 8.0f, 0.6f, 0, new Color(221, 255, 0, 255), false);
        //  NAPI.Marker.CreateMarker(25, new Vector3(981.3119, -102.4228, 74.84509) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 1.5f, new Color(221, 255, 0, 150), false);


       /* NAPI.Marker.CreateMarker(25, new Vector3(1035.855, -3204.715, -38.17416) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 2.5f, new Color(221, 255, 0, 110));
        API.Shared.CreateTextLabel("~g~-~y~ Prerada Marihuane~g~ -~w~~n~~n~Koristite ~y~Y~w~ da zapocnete preradu", new Vector3(1035.855, -3204.715, -38.17416 - 0.2f), 8.0f, 0.8f, 4, new Color(221, 255, 0, 255));

        NAPI.Marker.CreateMarker(25, new Vector3(1101.75, -3194.092, -38.99347) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 2.5f, new Color(221, 255, 0, 110));
        API.Shared.CreateTextLabel("~g~-~y~ Prerada Kokaina~g~ -~w~~n~~n~Koristite ~y~Y~w~ da zapocnete preradu", new Vector3(1101.75, -3194.092, -38.99347 - 0.2f), 8.0f, 0.8f, 4, new Color(221, 255, 0, 255));

        NAPI.Marker.CreateMarker(25, new Vector3(1010.86, -3200.156, -38.99313) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 2.5f, new Color(221, 255, 0, 110));
        API.Shared.CreateTextLabel("~g~-~y~ Prerada Opiuma~g~ -~w~~n~~n~Koristite ~y~Y~w~ da zapocnete preradu", new Vector3(1010.86, -3200.156, -38.99313 - 0.2f), 8.0f, 0.8f, 4, new Color(221, 255, 0, 255)); */

        NAPI.Marker.CreateMarker(25, new Vector3(463.67, -1017.206, 27.88313) - new Vector3(0, 0, 0.8f), new Vector3(), new Vector3(), 5.0f, new Color(221, 255, 0, 110));
        API.Shared.CreateTextLabel("~g~-~b~ Vracanje vozila~g~ -~w~~n~~n~Koristite ~y~Y~w~ da vratite vozilo", new Vector3(463.67, -1017.206, 27.88313 - 0.2f), 8.0f, 0.8f, 4, new Color(221, 255, 0, 255));

    }


    public static void SaveWerehouse(int index)
    {
        string query = "UPDATE `faction_werehouse` SET `name` = @name, `ownerid` = @ownerid, `price` = @price, `type` = @type, `safe` = @safe, `exterior_x` = @exterior_x, `exterior_y` = @exterior_y, `exterior_z` = @exterior_z, `exterior_a` = @exterior_a, `interior_x` = @interior_x, `interior_y` = @interior_y, `interior_z` = @interior_z, `interior_a` = @interior_a, `menu_x` = @menu_x, `menu_y` = @menu_y, `menu_z` = @menu_z ";

        for (int i = 0; i < 20; i++)
        {
            query = query + ", `gun_" + i + "` = '" + WereHouseData[index].gun[i] + "', `gun_units_" + i + "` = '" + WereHouseData[index].gun_units[i] + "', `safe_gun_" + i + "` = '" + WereHouseData[index].safe_gun[i] + "' ";
        }

        query = query + " WHERE `id` = '" + index + "'";


        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                myCommand.Parameters.AddWithValue("@id", WereHouseData[index].id);
                myCommand.Parameters.AddWithValue("@name", WereHouseData[index].name);
                myCommand.Parameters.AddWithValue("@ownerid", WereHouseData[index].ownerid);
                myCommand.Parameters.AddWithValue("@safe", WereHouseData[index].safe);
                myCommand.Parameters.AddWithValue("@price", WereHouseData[index].price);
                myCommand.Parameters.AddWithValue("@type", WereHouseData[index].type);
                myCommand.Parameters.AddWithValue("@exterior_x", WereHouseData[index].exterior_x);
                myCommand.Parameters.AddWithValue("@exterior_y", WereHouseData[index].exterior_y);
                myCommand.Parameters.AddWithValue("@exterior_z", WereHouseData[index].exterior_z);
                myCommand.Parameters.AddWithValue("@exterior_a", WereHouseData[index].exterior_a);
                myCommand.Parameters.AddWithValue("@interior_x", WereHouseData[index].interior_x);
                myCommand.Parameters.AddWithValue("@interior_y", WereHouseData[index].interior_y);
                myCommand.Parameters.AddWithValue("@interior_z", WereHouseData[index].interior_z);
                myCommand.Parameters.AddWithValue("@interior_a", WereHouseData[index].interior_a);
                myCommand.Parameters.AddWithValue("@menu_x", WereHouseData[index].menu_x);
                myCommand.Parameters.AddWithValue("@menu_y", WereHouseData[index].menu_y);
                myCommand.Parameters.AddWithValue("@menu_z", WereHouseData[index].menu_z);
                myCommand.ExecuteNonQuery();
                Mainpipeline.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }

    public static void UpdateWerehousePickup(int index)
    {
        NAPI.Entity.DeleteEntity(WereHouseData[index].exteriorLabel);
        NAPI.Entity.DeleteEntity(WereHouseData[index].exteriorMarker);

        if (WereHouseData[index].ownerid == -1)
        {
            WereHouseData[index].exteriorLabel = NAPI.TextLabel.CreateTextLabel("Undefined HQ " + index + "", new Vector3(WereHouseData[index].exterior_x, WereHouseData[index].exterior_y, WereHouseData[index].exterior_z + 0.6), 14, 0.600f, 0, new Color(221, 255, 0, 255));
        }
        else WereHouseData[index].exteriorLabel = NAPI.TextLabel.CreateTextLabel("~w~[ ~c~" + WereHouseData[index].name + "~w~ ]", new Vector3(WereHouseData[index].exterior_x, WereHouseData[index].exterior_y, WereHouseData[index].exterior_z + 0.6), 14, 0.600f, 0, new Color(221, 255, 0, 255));
        WereHouseData[index].exteriorMarker = NAPI.Marker.CreateMarker(0, new Vector3(WereHouseData[index].exterior_x, WereHouseData[index].exterior_y, WereHouseData[index].exterior_z - 0.3), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 255));
    }


    public static void ShowWarehouseMenu(Player Client)
    {
        int count = 0;
        foreach (var werehouse in WereHouseData)
        {

            if (Main.IsInRangeOfPoint(Client.Position, new Vector3(werehouse.menu_x, werehouse.menu_y, werehouse.menu_z), 1))// && NAPI.Entity.GetEntityDimension(Client) == count + 500
            {

                Client.SetData<dynamic>("EditingArmazemID", count);
                Client.SetData<dynamic>("EditingArmazemGroupID", AccountManage.GetPlayerGroup(Client));


                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 1, Name = "Novac", Description = "" });
                //menu_item_list.Add(new { Type = 1, Name = "Uzmi / Naruci Oruzije", Description = "" });
                //menu_item_list.Add(new { Type = 1, Name = "Guardar / Equipar Armamentos", Description = "" });

                InteractMenu.CreateMenu(Client, "WEREHOSE_MENU", "Organizacija", "~b~Sef", false, NAPI.Util.ToJson(menu_item_list), false);

                return;
            }
            count++;
        }
        count = 0;
    }

    public static bool DoesHaveFreeSlot(int houseid)
    {
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            if (WereHouseData[houseid].inventory_amount[i] == 0 && WereHouseData[houseid].inventory_index[i] == -1)
            {
                return true;
            }
        }
        return false;
    }

    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "WEREHOSE_MENU")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            switch (selectedIndex)
            {
                case 0:
                    {
                        int index = Client.GetData<dynamic>("EditingArmazemID");
                        menu_item_list.Add(new { Type = 1, Name = "Ostavi novac", Description = "Ostavljanje novca u sef." });
                        menu_item_list.Add(new { Type = 1, Name = "Uzmi novac", Description = "Uzimanje novca iz sefa. " });

                        InteractMenu.CreateMenu(Client, "WEREHOSE_MENU_SAFE", "Organizacija", "~b~Sef ~g~($" + WereHouseData[index].safe.ToString("N0") + ")", false, NAPI.Util.ToJson(menu_item_list), false);
                        break;
                    }
                case 1:
                    {
                        int index = Client.GetData<dynamic>("EditingArmazemID");
                        int gangid = Client.GetData<dynamic>("EditingArmazemGroupID");
                        for (int i = 0; i < 20; i++)
                        {
                            if (WereHouseData[index].gun_units[i] > 0)
                            {
                                menu_item_list.Add(new { Type = 1, Name = i + ". " + WereHouseData[index].gun[i] + " (ovl. ~c~" + WereHouseData[index].gun_perm[i] + " +~w~)", Description = "", RightLabel = WereHouseData[index].gun_units[i] + " stvari" });
                            }
                            else
                            {
                                menu_item_list.Add(new { Type = 1, Name = i + ". Livre", Description = "" });
                            }
                        }
                        InteractMenu.CreateMenu(Client, "WEREHOSE_MENU_ORDER_EQUIPMENT", "Skladiste", "~b~Opcije:", false, NAPI.Util.ToJson(menu_item_list), false);
                        break;
                    }
                case 2:
                    {
                        int index = Client.GetData<dynamic>("EditingArmazemID");
                        int gangid = Client.GetData<dynamic>("EditingArmazemGroupID");
                        for (int i = 0; i < 20; i++)
                        {
                            if (WereHouseData[index].safe_gun[i] != "Unknown")
                            {
                                menu_item_list.Add(new { Type = 1, Name = i + ". ~g~" + WereHouseData[index].safe_gun[i] + "~w~", Description = "" });
                            }
                            else
                            {
                                menu_item_list.Add(new { Type = 1, Name = i + ". Sacuvaj", Description = "" });
                            }
                        }
                        InteractMenu.CreateMenu(Client, "WEREHOSE_MENU_SAFE_EQUIPMENT", "Skladiste", "~b~Opcije:", false, NAPI.Util.ToJson(menu_item_list), false);
                        break;
                    }

            }
        }
        else if (callbackId == "WEREHOSE_MENU_SAFE")
        {
            if (selectedIndex == 0)
            {
                InteractMenu.User_Input(Client, "input_werehouse_deposit", "Ostavljanje novca", "0", "", "number");
                InteractMenu.CloseDynamicMenu(Client);
            }
            else
            {
                InteractMenu.User_Input(Client, "input_werehouse_withdraw", "Uzimanje novca", "0", "", "number");
                InteractMenu.CloseDynamicMenu(Client);
            }
        }
        else if (callbackId == "WEREHOSE_MENU_ORDER_EQUIPMENT")
        {
            Client.SetData<dynamic>("EditingArmazemSlotID", selectedIndex);

            int index = Client.GetData<dynamic>("EditingArmazemID");
            int gangid = Client.GetData<dynamic>("EditingArmazemGroupID");
            int slotid = Client.GetData<dynamic>("EditingArmazemSlotID");

            if (WereHouseData[index].gun_units[slotid] >= 1)
            {
                if (AccountManage.GetPlayerRank(Client) >= WereHouseData[index].gun_perm[slotid])
                {


                    WeaponHash modelo = NAPI.Util.WeaponNameToModel(WereHouseData[index].gun[slotid]);
                    //NAPI.Player.GivePlayerWeapon(Client, modelo, 9999);
                    WeaponManage.SetPlayerWeaponEx(Client, WereHouseData[index].gun[slotid], 250);
                    NAPI.Player.SetPlayerCurrentWeaponAmmo(Client, 250);

                    WereHouseData[index].gun_units[slotid] -= 1;
                    if (WereHouseData[index].gun_units[slotid] == 0)
                    {
                        Main.SendCustomChatMessasge(Client, "Uzeli ste ~g~" + WereHouseData[index].gun[slotid] + "~w~ iz skladista.");

                        WereHouseData[index].gun[slotid] = "Unknown";
                        WereHouseData[index].gun_units[slotid] = 0;
                        WereHouseData[index].gun_perm[slotid] = 0;
                    }
                    else Main.SendCustomChatMessasge(Client, "Imate ~g~" + WereHouseData[index].gun[slotid] + "~w~ u skladistu.");
                    SaveWerehouse(index);
                    ShowWarehouseMenu(Client);
                }
                else
                {
                    Main.SendErrorMessage(Client, "Niste ovlasceni, samo rank ~c~" + FactionManage.faction_data[gangid].faction_rank[WereHouseData[index].gun_perm[slotid]] + " (" + WereHouseData[index].gun_perm[slotid] + ")~w~ ili vise.");
                    ShowWarehouseMenu(Client);
                }
            }
            else
            {
                List<string> model_list = new List<string>();
                List<string> price_list = new List<string>();
                List<string> permi_list = new List<string>();

                int countIndex = 0;
                foreach (var order in weapon_order_list)
                {
                    if (order.permission == 0)
                    {
                        model_list.Add(Convert.ToString(order.order_model));
                        price_list.Add(Convert.ToString(order.order_price));
                    }

                    if (WereHouseData[index].type == HQ_TYPE_MAFIA && order.permission == 1)
                    {
                        model_list.Add(Convert.ToString(order.order_model));
                        price_list.Add(Convert.ToString(order.order_price));
                    }

                    countIndex++;
                }

                for (int i = 0; i < 6; i++)
                {
                    permi_list.Add(FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_rank[i]);
                }

                List<string> list = new List<string>();
                list.Add("+5");
                list.Add("+10");
                list.Add("+15");
                list.Add("+20 ");

                //NAPI.ClientEvent.TriggerClientEvent(Client, "CountWeaponOrder", countIndex);
                //NAPI.ClientEvent.TriggerClientEvent(Client, "AddModelToOrder", model_list.ToArray());
                //NAPI.ClientEvent.TriggerClientEvent(Client, "AddPriceToOrder", price_list.ToArray());
                //NAPI.ClientEvent.TriggerClientEvent(Client, "AddPermToOrder", permi_list.ToArray());
                //NAPI.ClientEvent.TriggerClientEvent(Client, "WarehouseDisplayPrice");

                Client.SetData<dynamic>("werehouse_order_weapon", 0);
                Client.SetData<dynamic>("werehouse_order_units", 0);
                Client.SetData<dynamic>("werehouse_order_perm", 0);

                UpdateOrderPrice(Client);

                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 6, Name = "Oruzije", Description = "Odabir oruzija.", List = model_list, StartIndex = 0 });
                menu_item_list.Add(new { Type = 6, Name = "Kolicina", Description = "Upravljanje kolicinom.", List = list, StartIndex = 0 });
                menu_item_list.Add(new { Type = 6, Name = "Ovlascenja", Description = "Ovlascenja clanova.", List = permi_list, StartIndex = 0 });
                menu_item_list.Add(new { Type = 1, Name = "Naruci opremu", Description = "Narucivanje opreme." });

                InteractMenu.CreateMenu(Client, "WEREHOSE_MENU_ORDER_PURCHASE", "Organizacija", "~b~Oruzije", false, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_gr_gunmod");
            }
        }
        else if (callbackId == "WEREHOSE_MENU_ORDER_PURCHASE")
        {

            Main.DisplaySubtitle(Client, " ", 1);
            int index = Client.GetData<dynamic>("EditingArmazemID");
            int gangid = Client.GetData<dynamic>("EditingArmazemGroupID");
            int slotid = Client.GetData<dynamic>("EditingArmazemSlotID");

            int send_price = 999999999, send_units = 5, current_weapon = Client.GetData<dynamic>("werehouse_order_weapon");
            switch (Client.GetData<dynamic>("werehouse_order_units"))
            {
                case 0: { send_units = 5; send_price = 5 * weapon_order_list[current_weapon].order_price; break; }
                case 1: { send_units = 10; send_price = 10 * weapon_order_list[current_weapon].order_price; break; }
                case 2: { send_units = 15; send_price = 15 * weapon_order_list[current_weapon].order_price; break; }
                case 3: { send_units = 20; send_price = 20 * weapon_order_list[current_weapon].order_price; break; }
            }

            string modelo = weapon_order_list[current_weapon].order_model;
            int preco = send_price;
            int unidades = send_units;
            int permissao = Client.GetData<dynamic>("werehouse_order_perm");

            if (WereHouseData[index].safe > preco)
            {
                WereHouseData[index].gun[slotid] = modelo;
                WereHouseData[index].gun_units[slotid] = unidades;
                WereHouseData[index].gun_perm[slotid] = permissao;

                WereHouseData[index].safe -= preco;

                SaveWerehouse(index);

                Main.SendCustomChatMessasge(Client, "Narucili ste ~g~" + unidades + "~w~ oruzija ~b~" + modelo + "~w~ za ~g~$" + preco.ToString("N0") + "~w~.");
                Main.SendCustomChatMessasge(Client, "Materijal je sada dostupan u skladistu.");
                //Main.SendCustomChatMessasge(Client, "Há encomendá chegará as ~g~15:00~w~ horas nos conteiner de All.");
            }
            else
            {
                Main.SendErrorMessage(Client, "Nemate dovoljno novca u sefu organizacije!");
            }
        }
        else if (callbackId == "WEREHOSE_MENU_SAFE_EQUIPMENT")
        {
            int slotid = selectedIndex;
            int index = Client.GetData<dynamic>("EditingArmazemID");

            if (WereHouseData[index].safe_gun[slotid] == "Unknown")
            {
                WeaponHash model = NAPI.Player.GetPlayerCurrentWeapon(Client);
                if (model != NAPI.Util.WeaponNameToModel("Unarmed"))
                {
                    WereHouseData[index].safe_gun[slotid] = "" + model + "";
                    NAPI.Player.RemovePlayerWeapon(Client, model);
                    Main.SendCustomChatMessasge(Client, "Stavili ste ~g~" + model + "~w~ u sef.");
                    SaveWerehouse(index);
                    ShowWarehouseMenu(Client);
                }
                else
                {
                    ShowWarehouseMenu(Client);
                    Main.SendErrorMessage(Client, "Morate držati oružje u ruci kako biste ga ostavili u sef.");
                }
            }
            else
            {
                WeaponHash model = NAPI.Util.WeaponNameToModel(WereHouseData[index].safe_gun[slotid]);
                WeaponManage.SetPlayerWeaponEx(Client, WereHouseData[index].safe_gun[slotid], 250);
                NAPI.Player.SetPlayerCurrentWeaponAmmo(Client, 250);
                WereHouseData[index].safe_gun[slotid] = "Unknown";
                Main.SendCustomChatMessasge(Client, "Uzeli ste ~g~" + model + "~w~ iz sefa.");
                SaveWerehouse(index);
                ShowWarehouseMenu(Client);
            }
        }
    }

    public static void UpdateOrderPrice(Player Client)
    {
        int send_price = 999999999, current_weapon = Client.GetData<dynamic>("werehouse_order_weapon");
        switch (Client.GetData<dynamic>("werehouse_order_units"))
        {
            case 0: { send_price = 5 * weapon_order_list[current_weapon].order_price; break; }
            case 1: { send_price = 10 * weapon_order_list[current_weapon].order_price; break; }
            case 2: { send_price = 15 * weapon_order_list[current_weapon].order_price; break; }
            case 3: { send_price = 20 * weapon_order_list[current_weapon].order_price; break; }
        }
        Main.DisplaySubtitle(Client, "Cena porudzbine iznosi ~c~" + weapon_order_list[current_weapon].order_model + "~w~: ~g~$~w~" + send_price + "", 60);
    }

    public static void ListItemMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        if (callbackId == "WEREHOSE_MENU_ORDER_PURCHASE")
        {
            switch (objectName)
            {
                case "Equipment":
                    {
                        int index = 0;
                        foreach (var perm in weapon_order_list)
                        {
                            if (perm.order_model == valueList)
                            {
                                Client.SetData<dynamic>("werehouse_order_weapon", index);
                                UpdateOrderPrice(Client);
                                return;
                            }
                            index++;
                        }

                        break;
                    }
                case "Amount":
                    {
                        Client.SetData<dynamic>("werehouse_order_units", valueIndex);
                        UpdateOrderPrice(Client);
                        break;
                    }
                case "Permission of Equipment":
                    {
                        Client.SetData<dynamic>("werehouse_order_perm", valueIndex);
                        UpdateOrderPrice(Client);
                        break;
                    }
            }
        }
    }

    public static void OnInputResponse(Player Client, String response, String inputtext)
    {
        if (response == "input_werehouse_deposit")
        {
            int value = Convert.ToInt32(inputtext);

            int gangid = Client.GetData<dynamic>("EditingArmazemID");
            if (value < 1 && value > 1000000)
            {
                Main.SendErrorMessage(Client, "Vrednost ne moze biti manja od 1 i veca od 1.000.000!");
                ShowWarehouseMenu(Client);
            }
            else
            {
                if (Main.GetPlayerMoney(Client) > value)
                {
                    Main.SendCustomChatMessasge(Client, "Ostavili ste ~g~$" + value.ToString("N0") + "~w~ u sef!");
                    Main.GivePlayerMoney(Client, -value);
                    WereHouseData[gangid].safe += value;
                    SaveWerehouse(gangid);
                    ShowWarehouseMenu(Client);
                }
                else
                {
                    Main.SendErrorMessage(Client, "Nemate dovoljno novca.");
                    ShowWarehouseMenu(Client);
                }

            }
        }
        else if (response == "input_werehouse_withdraw")
        {
            int value = Convert.ToInt32(inputtext);

            int gangid = Client.GetData<dynamic>("EditingArmazemID");


            if (value < 1 && value > 1000000)
            {
                Main.SendErrorMessage(Client, "Vrednost ne moze biti manja od 1 i veca od 1.000.000!");
                ShowWarehouseMenu(Client);
            }
            else
            {
                if (WereHouseData[gangid].safe > value)
                {
                    Main.SendCustomChatMessasge(Client, "Uzeli ste ~g~$" + value.ToString("N0") + "~w~ iz sefa.");
                    Main.GivePlayerMoney(Client, +value);
                    WereHouseData[gangid].safe -= value;
                    SaveWerehouse(gangid);
                    ShowWarehouseMenu(Client);
                }
                else
                {
                    Main.SendErrorMessage(Client, "Nemate dovoljno novca.");
                    ShowWarehouseMenu(Client);
                }
            }
        }
    }

    public static void OnMenuReturnClose(Player Client, String callbackId)
    {
        if (callbackId == "WEREHOSE_MENU_ORDER_PURCHASE" || callbackId == "WEREHOSE_MENU_ORDER_EQUIPMENT" || callbackId == "WEREHOSE_MENU_SAFE" || callbackId == "WEREHOSE_MENU_SAFE_EQUIPMENT")
        {
            ShowWarehouseMenu(Client);
        }
    }

    public static int GetArmazemFreeSlotID()
    {
        int index = 0;
        foreach (var armazem in WereHouseData)
        {
            if (armazem.name == "Unknown")
            {
                return index;
            }
            index++;
        }
        return -1;
    }


    [Command("createhq", "/createhq [orgID] [gang/mafia]")]
    public void CMD_criararmazem(Player Client, int factionid, string type)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }
        int i = GetArmazemFreeSlotID();

        if (i == -1) { Main.SendErrorMessage(Client, "Pogresan unos."); return; }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 7)
        {
            Main.SendErrorMessage(Client, "Niste na Admin Duznosti, koristite /ad.");
            return;
        }
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " je koristio /createhq: " + factionid.ToString());

        WereHouseData[i].price = 0;
        WereHouseData[i].exterior_x = Client.Position.X;
        WereHouseData[i].exterior_y = Client.Position.Y;
        WereHouseData[i].exterior_z = Client.Position.Z;
        WereHouseData[i].exterior_a = Client.Rotation.Z;
        WereHouseData[i].ownerid = factionid;
        WereHouseData[i].safe = 0;

        if (type == "gang")
        {
            WereHouseData[i].name = "Gang";
            WereHouseData[i].type = HQ_TYPE_GANG;
        }
        else if (type == "mafia")
        {
            WereHouseData[i].name = "Mafija";
            WereHouseData[i].type = HQ_TYPE_MAFIA;
        }

        //API.Shared.CreateTextLabel("~g~-~y~ Computador~g~ -~w~~n~~n~Koristiteione [ ~y~Y~w~ ] para acessar o computador", new Vector3(WereHouseData[i].menu_x, WereHouseData[i].menu_y, WereHouseData[i].menu_z - 0.2f), 8.0f, 0.8f, 4, new Color(221, 255, 0, 255));

        UpdateWerehousePickup(i);
        SaveWerehouse(i);
    }

    [Command("edithq", "/edithq [HQid] [(name/price/outdoor/interior/odfe/menu/delete)] [Value(ako treba)] (da vidite prvi slobodan ID HQa /nexthq)")]
    public void CMD_editararmazem(Player Client, int index, string nome, string value = "null")
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 7)
        {
            Main.SendErrorMessage(Client, "Niste na Admin Duznosti, koristite /ad.");
            return;
        }
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " je koristio /edithq ");
        if (nome == "outdoor")
        {
            Main.SendCustomChatMessasge(Client, "Podesili ste exterijer " + index + ".");
            WereHouseData[index].exterior_x = Client.Position.X;
            WereHouseData[index].exterior_y = Client.Position.Y;
            WereHouseData[index].exterior_z = Client.Position.Z;
            WereHouseData[index].exterior_a = Client.Rotation.Z;

            UpdateWerehousePickup(index);
            SaveWerehouse(index);
        }
        if (nome == "menu")
        {
            Main.SendCustomChatMessasge(Client, "Podesili ste ID menija " + index + ".");
            WereHouseData[index].menu_x = Client.Position.X;
            WereHouseData[index].menu_y = Client.Position.Y;
            WereHouseData[index].menu_z = Client.Position.Z;

            WereHouseData[index].menuLabel.Position = new Vector3(WereHouseData[index].menu_x, WereHouseData[index].menu_y, WereHouseData[index].menu_z - 0.2f);
            WereHouseData[index].menuArea.Position = new Vector3(WereHouseData[index].menu_x, WereHouseData[index].menu_y, WereHouseData[index].menu_z);
            SaveWerehouse(index);
        }
        else if (nome == "interior")
        {
            Main.SendCustomChatMessasge(Client, "Promenili ste enterijer na " + index + ".");
            WereHouseData[index].interior_x = Client.Position.X;
            WereHouseData[index].interior_y = Client.Position.Y;
            WereHouseData[index].interior_z = Client.Position.Z;
            WereHouseData[index].interior_a = Client.Rotation.Z;
            UpdateWerehousePickup(index);
            SaveWerehouse(index);
        }
        else if (nome == "name")
        {
            if (value == "null")
            {
                Main.SendErrorMessage(Client, "Ne mozete to!");
                return;
            }
            Main.SendCustomChatMessasge(Client, "Promenili ste ime skladista " + index + " na " + value + ".");
            WereHouseData[index].name = value;
            UpdateWerehousePickup(index);
            SaveWerehouse(index);
        }
        else if (nome == "price")
        {
            Main.SendCustomChatMessasge(Client, "Promenili ste cenu HQ " + index + " na $" + Convert.ToInt32(value).ToString("N0") + ".");
            WereHouseData[index].price = Convert.ToInt32(value);
            UpdateWerehousePickup(index);
            SaveWerehouse(index);
        }
        else if (nome == "safe")
        {
            Main.SendCustomChatMessasge(Client, "Promenili ste cenu HQ " + index + " na " + Convert.ToInt32(value).ToString("N0") + ".");
            WereHouseData[index].safe = Convert.ToInt32(value);
            UpdateWerehousePickup(index);
            SaveWerehouse(index);
        }
        else if (nome == "delete")
        {
            Main.SendCustomChatMessasge(Client, "Obrisali ste HQ ID: " + index + ".");
            WereHouseData[index].name = "Unknown";

            WereHouseData[index].ownerid = -1;
            WereHouseData[index].safe = 0;

            WereHouseData[index].exterior_x = 0;
            WereHouseData[index].exterior_y = 0;
            WereHouseData[index].exterior_z = 0;
            WereHouseData[index].exterior_a = 0;

            WereHouseData[index].interior_x = 0;
            WereHouseData[index].interior_y = 0;
            WereHouseData[index].interior_z = 0;
            WereHouseData[index].interior_a = 0;

            for (int i = 0; i < 20; i++)
            {
                WereHouseData[index].gun[i] = "Unknown";
                WereHouseData[index].gun_units[i] = 0;
                WereHouseData[index].gun_perm[i] = 0;
                WereHouseData[index].safe_gun[i] = "Unknown";
            }

            UpdateWerehousePickup(index);
            SaveWerehouse(index);
        }
    }

    [Command("nexthq")]
    public void CMD_warehouse(Player Client)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 7)
        {
            Main.SendErrorMessage(Client, "Niste na Admin Duznosti, koristite /ad.");
            return;
        }
        Main.SendCustomChatMessasge(Client, "Prvi slobodan ID HQ je: ~y~" + GetArmazemFreeSlotID() + "~w~.");
    }

    [Command("lockhq")]
    public void CMD_trancar(Player Client)
    {
        foreach (var armazem in WereHouseData)
        {
            if (Main.IsInRangeOfPoint(Client.Position, new Vector3(armazem.exterior_x, armazem.exterior_y, armazem.exterior_z), 3) || Main.IsInRangeOfPoint(Client.Position, new Vector3(armazem.interior_x, armazem.interior_y, armazem.interior_z), 3))
            {
                if (armazem.ownerid == AccountManage.GetPlayerGroup(Client))
                {
                    if (armazem.lockStatus == true)
                    {
                        armazem.lockStatus = false;
                        Main.SendCustomChatMessasge(Client, "~w~Baza ~g~otkljucana ");
                    }
                    else
                    {
                        armazem.lockStatus = true;
                        Main.SendCustomChatMessasge(Client, "~w~Baza ~r~zakljucana ");
                    }
                    return;
                }
            }
        }

    }

    //
    // Inventory
    //
    public static void LoadInventoryItens(int house_id)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `inventory_hq` WHERE `owner` = '" + WereHouseData[house_id].id + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                while ( reader.Read())
                {
                    if (reader.GetInt32("amount") == 0)
                    {
                        Main.CreateMySqlCommand("DELETE FROM `inventory_hq` WHERE `id` = '" + reader.GetInt32("id") + "';");
                        continue;
                    }

                    SendItemFromSQLtoInventory(house_id, reader.GetInt32("owner"), reader.GetInt32("type"), reader.GetInt32("amount"), reader.GetInt32("slotid"));
                }
            }
            Mainpipeline.Close();
        }
    }

    public static void SendItemFromSQLtoInventory(int house_id, int owner, int type, int amount = 1, int slotid = -1)
    {
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (WereHouseData[house_id].inventory_type[index] == type)
            {
                WereHouseData[house_id].inventory_amount[index] = amount;
                return;
            }
        }

        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (WereHouseData[house_id].inventory_index[index] == -1)
            {
                WereHouseData[house_id].inventory_index[index] = owner;
                WereHouseData[house_id].inventory_type[index] = type;
                WereHouseData[house_id].inventory_amount[index] = amount;
                WereHouseData[house_id].inventory_slotid[index] = slotid;
                return;
            }
        }
    }

    [RemoteEvent("HQ_Storage_Give_Item")]
    public static void UI_GiveItem(Player Client, int slot, int type, int amount, int sqlid)
    {

        int house_index = 0, house_id = -1;
        foreach (var entrace in WereHouseData)
        {
            if (Main.IsInRangeOfPoint(Client.Position, new Vector3(entrace.interior_x, entrace.interior_y, entrace.interior_z), 70.0f) && Client.Dimension == 500 + (uint)house_index)
            {
                if (entrace.ownerid == AccountManage.GetPlayerGroup(Client))
                {
                    house_id = house_index;
                }
            }
            house_index++;
        }

        if (house_id == -1)
        {
            return;
        }

        int playerid = Main.getIdFromClient(Client);
        int index = Inventory.GetInventoryIndexFromSQLID(Client, sqlid);
        if (index == -1)
        {
            return;
        }
        if (Inventory.player_inventory[playerid].sql_id[index] == -1 || Inventory.player_inventory[playerid].inuse[index] == 1 || Inventory.player_inventory[playerid].dropable[index] == 0)
        {
            Main.SendErrorMessage(Client, "Greska. (" + Inventory.player_inventory[playerid].sql_id[index] + " - " + index + " - " + Inventory.player_inventory[playerid].type[index] + ")");
            return;
        }



        if (Inventory.player_inventory[playerid].amount[index] > 1)
        {

            if (Inventory.player_inventory[playerid].sql_id[index] == -1)
            {
                return;
            }

            if (Inventory.player_inventory[playerid].amount[index] < 1)
            {
                return;
            }

            if (Inventory.player_inventory[playerid].amount[index] < amount)
            {
                Main.SendErrorMessage(Client, "Nemate mesta.");
                return;
            }

            Inventory.RemoveItemFromInventory(Client, index, amount);
            GiveItemToHQInventory(house_id, type, slot, amount);

            ShowHQInventory(Client);

            UsefullyRP.SendRoleplayAction(Client, "uzima " + Inventory.itens_available[type].name + "iz kucnog sefa.");



        }
    }
        
    public static void GiveItemToHQInventory(int house_id, int type, int slotid, int amount = 1)
    {

        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {

            if (WereHouseData[house_id].inventory_index[index] == -1)
            {

                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                {
                    try
                    {

                        Mainpipeline.Open();
                        string query = "INSERT INTO inventory_hq (`owner`, `type`, `amount`)" + " VALUES ('" + house_id + "', '" + type + "', '" + amount + "')";
                        MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                        myCommand.ExecuteNonQuery();
                        long last_inventory_id = myCommand.LastInsertedId;

                        WereHouseData[house_id].inventory_index[index] = Convert.ToInt32(last_inventory_id);
                        WereHouseData[house_id].inventory_type[index] = type;
                        WereHouseData[house_id].inventory_amount[index] = amount;
                        WereHouseData[house_id].inventory_slotid[index] = slotid;
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
    }

    public static void RemoveItemFromInventory(int house_id, int index, int amount = 0)
    {
        if (WereHouseData[house_id].inventory_amount[index] >= 2)
        {
            WereHouseData[house_id].inventory_amount[index] -= amount;
            Main.CreateMySqlCommand("UPDATE inventory_hq SET `amount` = " + WereHouseData[house_id].inventory_amount[index] + " WHERE `id` = " + WereHouseData[house_id].inventory_index[index] + "");

            if (WereHouseData[house_id].inventory_amount[index] < 1)
            {
                Main.CreateMySqlCommand("DELETE FROM `inventory_hq` WHERE `id` = '" + WereHouseData[house_id].inventory_index[index] + "';");


                WereHouseData[house_id].inventory_index[index] = -1;
                WereHouseData[house_id].inventory_type[index] = 0;
                WereHouseData[house_id].inventory_amount[index] = 0;
            }
        }
        else
        {
            Main.CreateMySqlCommand("DELETE FROM `inventory_hq` WHERE `id` = '" + WereHouseData[house_id].inventory_index[index] + "';");

            WereHouseData[house_id].inventory_index[index] = -1;
            WereHouseData[house_id].inventory_type[index] = 0;
            WereHouseData[house_id].inventory_amount[index] = 0;
        }
    }

    public static void ClearInventory(int house_id)
    {
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            WereHouseData[house_id].inventory_index[i] = -1;
            WereHouseData[house_id].inventory_type[i] = 0;
            WereHouseData[house_id].inventory_amount[i] = 0;
        }

        Main.CreateMySqlCommand("DELETE FROM `inventory_hq` WHERE `owner` = '" + house_id + "';");
    }

    public static void ResetInventoryVariables(int house_id)
    {
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            WereHouseData[house_id].inventory_index[i] = -1;
            WereHouseData[house_id].inventory_type[i] = 0;
            WereHouseData[house_id].inventory_amount[i] = 0;
        }
    }

    public static int GetInventoryIndexFromSQLID(int house_id, int sqlid)
    {
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (WereHouseData[house_id].inventory_index[index] == sqlid)
            {
                return index;
            }
        }
        return -1;
    }

    public static int GetInventoryIndexFromType(int house_id, int type)
    {
        int slot = -1;
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (WereHouseData[house_id].inventory_type[index] == type)
            {
                slot = index;
            }
        }
        return slot;
    }

    public static int GetPlayerItemFromInventory(int house_id, int type)
    {
        int amount = 0;
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (WereHouseData[house_id].inventory_type[index] == type)
            {
                amount = WereHouseData[house_id].inventory_amount[index];
            }
        }
        return amount;
    }


    public static int GetInventoryIndexFromName(int house_id, string name)
    {

        int index = 0, slot = -1;
        foreach (var item in Inventory.itens_available)
        {
            if (item.name == name)
            {
                slot = GetInventoryIndexFromType(house_id, index);
            }
            index++;
        }
        return slot;
    }

    public static void RemoveItem(int house_id, string itemName, int amount)
    {
        int index = 0;
        foreach (var item in Inventory.itens_available)
        {
            if (item.name == itemName)
            {
                RemoveItemFromInventory(house_id, GetInventoryIndexFromType(house_id, index), amount);
                return;
            }
            index++;
        }
    }


    [Command("hqinventory")]
    public static void ShowHQInventory(Player Client)
    {

        int house_index = 0;
        foreach (var entrace in WereHouseData)
        {
            if (Main.IsInRangeOfPoint(Client.Position, new Vector3(entrace.interior_x, entrace.interior_y, entrace.interior_z), 70.0f))
            {

                if (entrace.ownerid != AccountManage.GetPlayerGroup(Client))
                {
                    Main.SendErrorMessage(Client, "Niste clan organizacije.");
                    return;
                }

                if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-1577.88, -565.75, 108.52), 2.0f) || Main.IsInRangeOfPoint(Client.Position, new Vector3(259.8143, -1003.954, -99.00856), 2.0f) || Main.IsInRangeOfPoint(Client.Position, new Vector3(350.7189, -993.5916, -99.19617), 2.0f) || Main.IsInRangeOfPoint(Client.Position, new Vector3(-680.7666, 589.0926, 137.7698), 2.0f))
                {
                    int playerid = Main.getIdFromClient(Client);

                    System.Threading.Tasks.Task.Run(() =>
                    {

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

                        //
                        List<dynamic> temp_storage_inventory = new List<dynamic>();
                        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
                        {
                            if (WereHouseData[house_index].inventory_index[index] != -1)
                            {

                                int type = WereHouseData[house_index].inventory_type[index];

                                if (type > Inventory.itens_available.Count)
                                {
                                    continue;
                                }


                                temp_storage_inventory.Add(new
                                {
                                    name = Inventory.itens_available[type].name,
                                    type = type,
                                    amount = WereHouseData[house_index].inventory_amount[index],
                                    sqlid = WereHouseData[house_index].inventory_index[index],
                                    slotid = WereHouseData[house_index].inventory_slotid[index],
                                    Useable = Inventory.itens_available[WereHouseData[house_index].inventory_type[index]].Useable,
                                    inuse = 0,
                                    dropable = 1,
                                    weight = Inventory.itens_available[type].weight,
                                    picture = "./img/" + Inventory.itens_available[type].picture + ".png"
                                });
                            }
                        }
                        NAPI.Task.Run(() =>
                        {
                            Client.TriggerEvent("Display_HQ_Storage", NAPI.Util.ToJson(temp_inventory), NAPI.Util.ToJson(temp_storage_inventory), Inventory.GetInventoryMaxHeight(Client), MAX_INVENTORY_WIGHT);
                        });

                    });

                }
                return;
            }
            house_index++;
        }
    }

    [RemoteEvent("HQ_Storage_Take_Item")]
    public static void UI_TakeItem(Player Client, int type, string inputtext)
    {
        try
        {
            int house_index = 0, house_id = -1;
            foreach (var entrace in WereHouseData)
            {
                if (Main.IsInRangeOfPoint(Client.Position, new Vector3(entrace.interior_x, entrace.interior_y, entrace.interior_z), 70.0f))
                {
                    if (entrace.ownerid == AccountManage.GetPlayerGroup(Client))
                    {
                        house_id = house_index;
                    }
                }
                house_index++;
            }

            if (house_id == -1)
            {
                return;
            }

            int playerid = Main.getIdFromClient(Client);
            int index = GetInventoryIndexFromSQLID(house_id, type);

            if (WereHouseData[house_id].inventory_amount[index] > 1)
            {
                if (!Main.IsNumeric(inputtext))
                {
                    return;
                }

                int amount = Convert.ToInt32(inputtext);

                if (WereHouseData[house_id].inventory_amount[index] < 1)
                {
                    return;
                }

                if (WereHouseData[house_id].inventory_amount[index] < amount)
                {
                    Main.SendErrorMessage(Client, "Nema sredstava.");
                    return;
                }

                if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, type, amount, Inventory.Max_Inventory_Weight(Client)))
                {
                    return;
                }


                Inventory.GiveItemToInventory(Client, type, amount);
                RemoveItemFromInventory(house_id, index, amount);

                ShowHQInventory(Client);

                List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
                foreach (Player alvo in proxPlayers)
                {
                    alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " uzima " + amount + "x " + Inventory.itens_available[type].name + " iz sefa.");
                }

            }
            else if (WereHouseData[house_id].inventory_amount[index] == 1)
            {
                if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, type, 1, Inventory.Max_Inventory_Weight(Client)))
                {
                    return;
                }

                Inventory.GiveItemToInventory(Client, type, 1);
                RemoveItemFromInventory(house_id, index, 1);

                ShowHQInventory(Client);

                List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
                foreach (Player alvo in proxPlayers)
                {
                    alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " uzima " + Inventory.itens_available[type].name + " iz sefa.");
                }
                return;
            }
        }
        catch
        {

        }
    }

    [RemoteEvent("HQ_SideInventoryStack")]
    public void HQ_SideInventoryStack(Player Client, int sqlnew, int sqlold)
    {
        if (AccountManage.GetPlayerConnected(Client))
        {


            int house_index = 0, house_id = -1;
            foreach (var entrace in WereHouseData)
            {
                if (Main.IsInRangeOfPoint(Client.Position, new Vector3(entrace.interior_x, entrace.interior_y, entrace.interior_z), 70.0f))
                {
                    if (entrace.ownerid == AccountManage.GetPlayerGroup(Client))
                    {
                        if (house_id == -1)
                        {
                            return;
                        }
                        house_id = house_index;
                        break;
                    }
                }
                house_index++;
            }

            if (house_id == -1)
            {
                return;
            }
            int oldindex = GetInventoryIndexFromSQLID(house_id, sqlold);
            int newindex = GetInventoryIndexFromSQLID(house_id, sqlnew);
            if (oldindex == -1 || newindex == -1)
            {
                ShowHQInventory(Client);
                return;
            }
            if (WereHouseData[house_id].inventory_amount[oldindex] >= 1 && WereHouseData[house_id].inventory_amount[newindex] >= 1)
            {

                if (WereHouseData[house_id].inventory_type[newindex] != WereHouseData[house_id].inventory_type[oldindex] || WereHouseData[house_id].inventory_index[newindex] == WereHouseData[house_id].inventory_index[oldindex])
                {
                    ShowHQInventory(Client);
                    return;
                }
                WereHouseData[house_id].inventory_amount[newindex] += WereHouseData[house_id].inventory_amount[oldindex];
                // NAPI.Data.SetEntityData(vehicle, "trunk_item_" + sqlnew + "_amount", NAPI.Data.GetEntityData(vehicle, "trunk_item_" + sqlnew + "_amount") + NAPI.Data.GetEntityData(vehicle, "trunk_item_" + sqlold + "_amount"));
                RemoveItemFromInventory(house_id, oldindex, 999);
                Main.CreateMySqlCommand("UPDATE `inventory_hq` SET `amount` = " + WereHouseData[house_id].inventory_amount[newindex] + " WHERE `id` = " + WereHouseData[house_id].inventory_index[newindex] + "");
                ShowHQInventory(Client);
                return;
            }
            else
            {
                ShowHQInventory(Client);

            }
        }
    }

    [RemoteEvent("HQ_InventoryChangeSlot")]
    public void UI_InventoryChangeSlot(Player Client, int sqlid, int dataslot)
    {
        int house_index = 0, house_id = -1;

        foreach (var entrace in WereHouseData)
        {
           if (Main.IsInRangeOfPoint(Client.Position, new Vector3(entrace.interior_x, entrace.interior_y, entrace.interior_z), 70.0f))
            {
                if (entrace.ownerid == AccountManage.GetPlayerGroup(Client))
                {
                    if (house_id == -1)
                    {
                        return;
                    }
                    int index = GetInventoryIndexFromSQLID(house_id, sqlid);
                    if (index == -1)
                    {
                        return;
                    }
                    
                    entrace.inventory_slotid[index] = dataslot;
                    Main.CreateMySqlCommand("UPDATE `inventory_hq` SET `slotid` = " + dataslot + " WHERE `id` = " + entrace.inventory_index[index] + "");
                    return;
                }
            }
            house_index++;

        }

    }

    [RemoteEvent("HQ_SideInventorySplit")]
    public void HQ_SideInventorySplit(Player Client, int sqlid)
    {
        int house_index = 0, house_id = -1;
        foreach (var entrace in WereHouseData)
        {
            if (Main.IsInRangeOfPoint(Client.Position, new Vector3(entrace.interior_x, entrace.interior_y, entrace.interior_z), 70.0f))
            {
                if (entrace.ownerid == AccountManage.GetPlayerGroup(Client))
                {
                    house_id = house_index;
                    break;
                }
            }
            house_index++;
        }
        int index = GetInventoryIndexFromSQLID(house_id, sqlid);
        if (index == -1)
        {
            return;
        }
        if (!DoesHaveFreeSlot(house_id))
        {
            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate slobodnih mesta za kucu.");
            return;
        }

        if (WereHouseData[house_id].inventory_amount[index] >= 2)
        {
            if ((WereHouseData[house_id].inventory_amount[index] % 2) == 0)
            {
                GiveItemToHQInventory(house_id, WereHouseData[house_id].inventory_type[index], -1, WereHouseData[house_id].inventory_amount[index] / 2);
                WereHouseData[house_id].inventory_amount[index] = WereHouseData[house_id].inventory_amount[index] / 2;
                Main.CreateMySqlCommand("UPDATE `inventory_hq` SET `amount`=" + WereHouseData[house_id].inventory_amount[index] + " WHERE `id`=" + WereHouseData[house_id].inventory_index[index] + "");
                ShowHQInventory(Client);
            }
            else
            {
                decimal ammount = decimal.Parse(WereHouseData[house_id].inventory_amount[index].ToString()) / 2m;
                GiveItemToHQInventory(house_id, WereHouseData[house_id].inventory_type[index], -1, (int)Math.Ceiling(ammount));
                WereHouseData[house_id].inventory_amount[index] = (int)Math.Floor(ammount);
                ShowHQInventory(Client);

                Main.CreateMySqlCommand("UPDATE `inventory_house` SET `amount`=" + (int)Math.Floor(ammount) + " WHERE `id`=" + WereHouseData[house_id].inventory_index[index] + "");
            }
        }
    }

    [RemoteEvent("HQ_InventorySplit")]
    public void SplitItem_Main(Player client, int sqlid)
    {
        Inventory.SplitItemGlobal(client, sqlid);
        ShowHQInventory(client);
    }

    [RemoteEvent("HQ_InventoryStack")]
    public void HQ_InventoryStack(Player Client, int sqlold, int sqlnew)
    {
        int playerid = Main.getIdFromClient(Client);

        int oldindex = Inventory.GetInventoryIndexFromSQLID(Client, sqlold);
        int newindex = Inventory.GetInventoryIndexFromSQLID(Client, sqlnew);
        if (oldindex == -1 || newindex == -1)
        {
            return;
        }
        if (Inventory.player_inventory[playerid].type[oldindex] != Inventory.player_inventory[playerid].type[newindex] || Inventory.player_inventory[playerid].sql_id[oldindex] == Inventory.player_inventory[playerid].sql_id[newindex])
        {
            ShowHQInventory(Client);
            return;
        }
        if (AccountManage.GetPlayerConnected(Client))
        {
            if (Inventory.player_inventory[playerid].sql_id[oldindex] == -1 || Inventory.player_inventory[playerid].inuse[oldindex] == 1 || Inventory.player_inventory[playerid].dropable[oldindex] == 0)
            {
                ShowHQInventory(Client);
                Main.SendErrorMessage(Client, "Greska. (" + Inventory.player_inventory[playerid].sql_id[oldindex] + " - " + oldindex + " - " + Inventory.player_inventory[playerid].type[oldindex] + ")");
                return;
            }
            if (Inventory.player_inventory[playerid].sql_id[newindex] == -1 || Inventory.player_inventory[playerid].inuse[newindex] == 1 || Inventory.player_inventory[playerid].dropable[newindex] == 0)
            {
                ShowHQInventory(Client);
                Main.SendErrorMessage(Client, "Greska. (" + Inventory.player_inventory[playerid].sql_id[newindex] + " - " + newindex + " - " + Inventory.player_inventory[playerid].type[newindex] + ")");
                return;
            }

            if (Inventory.player_inventory[playerid].amount[oldindex] >= 1 && Inventory.player_inventory[playerid].amount[newindex] >= 1)
            {
                Inventory.player_inventory[playerid].amount[newindex] += Inventory.player_inventory[playerid].amount[oldindex];
                Inventory.player_inventory[playerid].slotid[newindex] = Inventory.player_inventory[playerid].slotid[oldindex];

                Inventory.player_inventory[playerid].amount[oldindex] = 0;

                Main.CreateMySqlCommand("UPDATE `inventory` SET `slotid` = " + Inventory.player_inventory[playerid].slotid[newindex] + " WHERE `id` = " + sqlnew + "");
                Main.CreateMySqlCommand("UPDATE inventory SET `amount` = " + Inventory.player_inventory[playerid].amount[newindex] + " WHERE `id` = " + sqlnew + "");
                Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `id` = '" + sqlold + "';");

                Inventory.player_inventory[playerid].sql_id[oldindex] = -1;
                Inventory.player_inventory[playerid].type[oldindex] = 0;
                Inventory.player_inventory[playerid].amount[oldindex] = 0;
                Inventory.player_inventory[playerid].inuse[oldindex] = 0;
                Inventory.player_inventory[playerid].dropable[oldindex] = 1;
                Inventory.player_inventory[playerid].slotid[oldindex] = -1;
                ShowHQInventory(Client);

            }

        }
    }

    [RemoteEvent("Inventory_Close")]
    public static void Inventory_Close(Player Client)
    {
        VehicleInventory.HidePlayerVehicleInventory(Client);
        int house_index = 0;
        foreach (var entrace in WereHouseData)
        {
            if (Main.IsInRangeOfPoint(Client.Position, new Vector3(entrace.interior_x, entrace.interior_y, entrace.interior_z), 70.0f))
            {
                if (entrace.ownerid == AccountManage.GetPlayerGroup(Client))
                {
                    WereHouseData[house_index].using_inventory = false;
                }
            }
            house_index++;
        }
    }

}

