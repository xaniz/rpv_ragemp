using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

public class HouseSystem : Script
{
    public static int HOUSES_CREATED = 0;
    public static int MAX_INVENTORY_ITENS = 48;
    public static int MAX_INVENTORY_WIGHT = 150;

    public class HouseEnum : IEquatable<HouseEnum>
    {
        public int id { get; set; }

        public string name { get; set; }
        public string owner_name { get; set; }

        public int owner { get; set; }
        public int price { get; set; }
        public int vip { get; set; }
        public int locked { get; set; }
        public int sell_house { get; set; }

        public int safe { get; set; }

        public Vector3 exterior { get; set; }
        public Vector3 interior { get; set; }
        public Vector3 exterior_garage { get; set; }
        public float exterior_garage_a { get; set; }
        public float exterior_a { get; set; }
        public float interior_a { get; set; }
        public float in_garage { get; set; }
        public byte garage_slot { get; set; }


        public TextLabel label { get; set; }
        public Marker marker { get; set; }
        public Marker g_marker { get; set; }
        public Blip blip { get; set; }
        public ColShape ext_shape { get; set; }
        public ColShape int_shape { get; set; }


        public TextLabel label_interior { get; set; }
        //  public Marker marker_interior { get; set; }

        public string[] key_acess { get; set; } = new string[10];

        // furniture
        public GTANetworkAPI.Object[] furniture_handle { get; set; } = new GTANetworkAPI.Object[60];
        public int[] furniture_id { get; set; } = new int[60];
        public string[] furniture_name { get; set; } = new string[60];
        public string[] furniture_model_name { get; set; } = new string[60];
        public int[] furniture_model { get; set; } = new int[60];
        public int[] furniture_price { get; set; } = new int[60];
        public int[] furniture_status { get; set; } = new int[60];

        public int[] inventory_sqlid { get; set; } = new int[MAX_INVENTORY_ITENS];

        public int[] inventory_index { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] inventory_type { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] inventory_amount { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] inventory_slotid { get; set; } = new int[MAX_INVENTORY_ITENS];


        public Vector3[] furniture_position { get; set; } = new Vector3[60];
        public Vector3[] furniture_rotation { get; set; } = new Vector3[60];

        public override string ToString()
        {
            return "ID: " + id + "   Name: " + name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            HouseEnum objAsPart = obj as HouseEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(HouseEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }



    public static List<HouseEnum> HouseInfo = new List<HouseEnum>();
    public static List<furniture> furniture_data = new List<furniture>();

    public static int MAX_ENTRACE = 1000;

    public class furniture
    {
        public string name;
        public string model;
        public string classe;
        public int price;
        public int hash;
        public string picture = "box";
    }

    public static void HouseSystemInit()
    {
        //Lavazem Khane, Encanamento, Conforto, Tazinat, Sargarmi, Roshanaei, Zakhire-Sazi, Sakhtemani, Miscelânea

        furniture_data.Add(new furniture { name = "Neon Sefid Tak", model = "xm_prop_base_tripod_lampc", classe = "Roshanaei", price = 280, hash = 113622690 });
        furniture_data.Add(new furniture { name = "Lamp Zamini", model = "xm_base_cia_lamp_floor_01a", classe = "Roshanaei", price = 280, hash = 1190620071 });
        furniture_data.Add(new furniture { name = "Mahtabi Divari", model = "xm_prop_lab_lamp_wall_b", classe = "Roshanaei", price = 280, hash = 1561304841 });


        furniture_data.Add(new furniture { name = "Gitar Acoustic", model = "prop_acc_guitar_01_d1", classe = "Gheyre", price = 280, hash = -121802573 });
        furniture_data.Add(new furniture { name = "Cheap Bed", model = "p_lestersbed_s", classe = "Rahati", price = 250, hash = 1937985747 });// || Preço: $250
        furniture_data.Add(new furniture { name = "Crazy Life Bed", model = "p_v_res_tt_bed_s", classe = "Rahati", price = 350, hash = -1211387925 });// || Preço: $350
        furniture_data.Add(new furniture { name = "Cama Alto Rahati", model = "v_res_msonbed_s", classe = "Rahati", price = 550, hash = -980185685 });// || Preço: $550
        furniture_data.Add(new furniture { name = "Pure Luxury Malt Bed", model = "p_mbbed_s", classe = "Rahati", price = 1020, hash = -1284191201 });//  || Preço: $1020
        furniture_data.Add(new furniture { name = "Tramp Sofa", model = "v_tre_sofa_mess_c_s", classe = "Rahati", price = 50, hash = 417935208 });// || Preço: $50
        furniture_data.Add(new furniture { name = "Detonated Sofa", model = "v_tre_sofa_mess_b_s", classe = "Rahati", price = 80, hash = -1726933877 });// || Preço: $80
        furniture_data.Add(new furniture { name = "Restored Sofa", model = "v_res_tre_sofa_s", classe = "Rahati", price = 250, hash = 2109741755 });//  || Preço: $250
        furniture_data.Add(new furniture { name = "Large sofa", model = "p_v_med_p_sofa_s", classe = "Rahati", price = 250, hash = 1593135630 });// || Preço: $250
        furniture_data.Add(new furniture { name = "Cama Fit", model = "p_res_sofa_l_s", classe = "Rahati", price = 350, hash = -406716247 });//  || Preço: $350
        furniture_data.Add(new furniture { name = "High Strength Sofa", model = "prop_t_sofa", classe = "Rahati", price = 450, hash = -1964110779 });// || Preço: $450
        furniture_data.Add(new furniture { name = "Sofa L", model = "p_lev_sofa_s", classe = "Rahati", price = 760, hash = 1526269963 });// || Preço: $760
        furniture_data.Add(new furniture { name = "Desk Chair I", model = "prop_off_chair_04_s", classe = "Rahati", price = 120, hash = 475561894 });// || Preço: $120
        furniture_data.Add(new furniture { name = "Desk Chair V", model = "hei_prop_heist_off_chair", classe = "Rahati", price = 360, hash = -1198343923 });// || Preço: $360
        furniture_data.Add(new furniture { name = "VX Desk Chair", model = "p_clb_officechair_s", classe = "Rahati", price = 460, hash = -1173315865 });// || Preço: $460
        furniture_data.Add(new furniture { name = "Standardized Chair", model = "v_ilev_chair02_ped", classe = "Rahati", price = 100, hash = -784954167 });// || Preço: $100
        furniture_data.Add(new furniture { name = "Pure Malt Chair", model = "prop_cs_office_chair", classe = "Rahati", price = 180, hash = -1118419705 });// || Preço: $180
        furniture_data.Add(new furniture { name = "Rocking chair", model = "prop_rock_chair_01", classe = "Rahati", price = 120, hash = 854385596 });// || Preço: $120
        furniture_data.Add(new furniture { name = "Boteco Plus Chair", model = "prop_chair_pile_01", classe = "Rahati", price = 120, hash = -296249014 });// || Preço: $120
        furniture_data.Add(new furniture { name = "Bar chair", model = "prop_chair_08", classe = "Rahati", price = 120, hash = 1281480215 });// || Preço: $120
        furniture_data.Add(new furniture { name = "Tramps Armchair", model = "prop_ld_farm_chair01", classe = "Rahati", price = 120, hash = 1281480215 });// || Preço: $120
        furniture_data.Add(new furniture { name = "Grandfathers Armchair", model = "p_armchair_01_s", classe = "Rahati", price = 250, hash = -2065455377 });// || Preço: $250
        furniture_data.Add(new furniture { name = "Luxury Armchair", model = "p_ilev_p_easychair_s", classe = "Rahati", price = 340, hash = 736919402 });// || Preço: $340
        furniture_data.Add(new furniture { name = "Beach Armchair", model = "p_yacht_chair_01_s", classe = "Rahati", price = 210, hash = 604553643 });//  || Preço: $210
        furniture_data.Add(new furniture { name = "Old Television", model = "prop_tv_test", classe = "Sargarmi", price = 100, hash = 1553931317 });// || Preço: $100
        furniture_data.Add(new furniture { name = "Tube Television", model = "prop_tv_03", classe = "Sargarmi", price = 150, hash = -897601557 });// || Preço: $150
        furniture_data.Add(new furniture { name = "Rack TV", model = "prop_cs_tv_stand", classe = "Sargarmi", price = 350, hash = 122877578 });// || Preço: $350
        furniture_data.Add(new furniture { name = "Simple Television", model = "prop_trev_tv_01", classe = "Sargarmi", price = 370, hash = 1434219911 });//  || Preço: $370
        furniture_data.Add(new furniture { name = "Medium Television", model = "prop_tv_flat_02", classe = "Sargarmi", price = 640, hash = 1340914825 });//  || Preço: $640
        furniture_data.Add(new furniture { name = "Good Quality Television", model = "prop_tv_flat_01", classe = "Sargarmi", price = 820, hash = 1036195894 });// || Preço: $820
        furniture_data.Add(new furniture { name = "Giant television", model = "prop_michaels_credit_tv", classe = "Sargarmi", price = 1120, hash = 566576618 });// || Preço: $1120
        furniture_data.Add(new furniture { name = "Ultra Giant Television", model = "hei_heist_str_avunitl_03", classe = "Sargarmi", price = 2200, hash = 777010715 });// || Preço: $2200
        furniture_data.Add(new furniture { name = "Simple computer", model = "prop_dyn_pc", classe = "Sargarmi", price = 850, hash = -1830645735 });// || Preço: $850
        furniture_data.Add(new furniture { name = "Good computer", model = "prop_pc_02a", classe = "Sargarmi", price = 1000, hash = 1654151435 });//  || Preço: $1000
        furniture_data.Add(new furniture { name = "Laptop Lenovo", model = "p_cs_laptop_02", classe = "Sargarmi", price = 1300, hash = 2109346928 });//  || Preço: $1300
        furniture_data.Add(new furniture { name = "Macbook", model = "prop_laptop_jimmy", classe = "Sargarmi", price = 2000, hash = 363555755 });// || Preço: $2000
        furniture_data.Add(new furniture { name = "Macbook X", model = "prop_laptop_lester", classe = "Sargarmi", price = 2200, hash = 881450200 });// || Preço: $2200
        furniture_data.Add(new furniture { name = "Pussy Beat ", model = "prop_speaker_05", classe = "Sargarmi", price = 550, hash = -1885111468 });// || Preço: $550
        furniture_data.Add(new furniture { name = "Simple Beat", model = "prop_speaker_08", classe = "Sargarmi", price = 550, hash = 648227157 });//  || Preço: $550
        furniture_data.Add(new furniture { name = "Black Beat", model = "v_res_mm_audio", classe = "Sargarmi", price = 850, hash = 2079380440 });// || Preço: $850
        furniture_data.Add(new furniture { name = "Black Beat JBL", model = "prop_speaker_01", classe = "Sargarmi", price = 950, hash = -968169310 });// || Preço: $950
        furniture_data.Add(new furniture { name = "Simple Watch", model = "prop_game_clock_01", classe = "Gheyre", price = 20, hash = -1004588353 });// || Preço: $20
        furniture_data.Add(new furniture { name = "Basic Watch", model = "prop_big_clock_01", classe = "Gheyre", price = 35, hash = -346427197 });// || Preço: $35
        furniture_data.Add(new furniture { name = "Executive Watch", model = "prop_hotel_clock_01", classe = "Gheyre", price = 50, hash = 495599970 });//  || Preço: $50
        furniture_data.Add(new furniture { name = "USA Watch", model = "prop_v_15_cars_clock", classe = "Gheyre", price = 40, hash = 763497189 });// || Preço: $40
        furniture_data.Add(new furniture { name = "DVD Bluray", model = "prop_cs_dvd_player", classe = "Sargarmi", price = 350, hash = 159474821 });//  || Preço: $350
        furniture_data.Add(new furniture { name = "Camera 360°", model = "hei_prop_bank_cctv_02", classe = "Gheyre", price = 250, hash = -1842407088 });//  || Preço: $250
        furniture_data.Add(new furniture { name = "Camera This", model = "p_cctv_s", classe = "Gheyre", price = 350, hash = 289451089 });// || Preço: $350
        furniture_data.Add(new furniture { name = "Spy camera", model = "prop_spycam", classe = "Gheyre", price = 200, hash = -203475463 });//  || Preço: $200
        furniture_data.Add(new furniture { name = "Bong", model = "hei_heist_sh_bong_01", classe = "Gheyre", price = 200, hash = 1874679314 });//   || Preço: $200
        furniture_data.Add(new furniture { name = "Tablet Multilaser", model = "prop_cs_tablet", classe = "Sargarmi", price = 500, hash = -1585232418 });// || Preço: $500
        furniture_data.Add(new furniture { name = "Ipad", model = "prop_cs_tablet_02", classe = "Sargarmi", price = 1000, hash = 921401054 });//  || Preço: $1000
        furniture_data.Add(new furniture { name = "Snooker", model = "prop_pooltable_02", classe = "Sargarmi", price = 800, hash = 322248450 });//  || Preço: $800
        furniture_data.Add(new furniture { name = "Ping Pong", model = "prop_table_tennis", classe = "Sargarmi", price = 800, hash = -692384911 });//  || Preço: $800  
        furniture_data.Add(new furniture { name = "Beverage bottles", model = "beerrow_local", classe = "Gheyre", price = 40, hash = -1574447115 });// || Preço: $40
        furniture_data.Add(new furniture { name = "Arsenal BioTip", model = "hei_bio_heist_gear", classe = "Gheyre", price = 10000, hash = -912160221 });// || Preço: $10000
        furniture_data.Add(new furniture { name = "Mobile Arsenal", model = "hei_p_generic_heist_guns", classe = "Gheyre", price = 7500, hash = -1585232418 });// || Preço: $7500
        furniture_data.Add(new furniture { name = "Security camera", model = "hei_prop_bank_cctv_01", classe = "Gheyre", price = 340, hash = -1007354661 });// || Preço: $340
        furniture_data.Add(new furniture { name = "Mapa All", model = "hei_prop_dlc_heist_map", classe = "Gheyre", price = 50, hash = 1609935604 });// || Preço: $50
        furniture_data.Add(new furniture { name = "Real Statue Super Hero", model = "hei_prop_drug_statue_01", classe = "Gheyre", price = 500, hash = 155105927 });// || Preço: $500
        furniture_data.Add(new furniture { name = "GOLD", model = "hei_prop_gold_trolly_half_full", classe = "Gheyre", price = 10000, hash = -636408770 });//  || Preço: $10000
        furniture_data.Add(new furniture { name = "Money", model = "hei_prop_hei_cash_trolly_01", classe = "Gheyre", price = 7000, hash = 269934519 });//  || Preço: $7000
        furniture_data.Add(new furniture { name = "Drug suitcase", model = "hei_prop_hei_drug_case", classe = "Gheyre", price = 3500, hash = 1049338225 });//  || Preço: $3500
        furniture_data.Add(new furniture { name = "Gold bar", model = "hei_prop_heist_gold_bar", classe = "Gheyre", price = 2000, hash = -599546004 });//  || Preço: $2000
        furniture_data.Add(new furniture { name = "Cup of coffee", model = "ng_proc_coffee_01a", classe = "Gheyre", price = 20, hash = -163314598 });//  || Preço: $20
        furniture_data.Add(new furniture { name = "Worth a lot of money", model = "p_large_gold_s", classe = "Gheyre", price = 50000, hash = -1585232418 });// || Preço: $50000
        furniture_data.Add(new furniture { name = "Planning Board", model = "p_planning_board_04", classe = "Gheyre", price = 500, hash = -2117059320 });//  || Preço: $500



        NAPI.TextLabel.CreateTextLabel("~c~Sef~w~ ", new Vector3(259.8143, -1003.954, -99.00856), 8.0f, 0.6f, 0, new Color(221, 255, 0, 255), false);

        NAPI.TextLabel.CreateTextLabel("~c~Sef~w~", new Vector3(350.7189, -993.5916, -99.19617), 8.0f, 0.6f, 0, new Color(221, 255, 0, 255), false);

        NAPI.TextLabel.CreateTextLabel("~c~Sef~w~", new Vector3(-680.7666, 589.0926, 137.7698), 8.0f, 0.6f, 0, new Color(221, 255, 0, 255), false);

        NAPI.TextLabel.CreateTextLabel("~c~Sef~w~", new Vector3(151.69978, -1001.4084, -98.99999), 8.0f, 0.6f, 0, new Color(221, 255, 0, 255), false);

        NAPI.TextLabel.CreateTextLabel("~c~Sef~w~", new Vector3(-1287.5038, 455.8964, 90.29471), 8.0f, 0.6f, 0, new Color(221, 255, 0, 255), false);

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `houses`;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                var index = 0;
                while (reader.Read())
                {
                    if (index > MAX_ENTRACE) break;
                    HouseInfo.Add(new HouseEnum()
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        owner = reader.GetInt32("owner"),
                        owner_name = reader.GetString("owner_name"),
                        price = reader.GetInt32("price"),
                        vip = reader.GetInt32("vip"),
                        locked = reader.GetInt32("lock_status"),
                        sell_house = reader.GetInt32("sell_house"),
                        exterior = new Vector3(float.Parse(reader.GetString("exterior_x")), float.Parse(reader.GetString("exterior_y")), float.Parse(reader.GetString("exterior_z"))),
                        interior = new Vector3(float.Parse(reader.GetString("interior_x")), float.Parse(reader.GetString("interior_y")), float.Parse(reader.GetString("interior_z"))),
                        exterior_a = float.Parse(reader.GetString("exterior_a")),
                        interior_a = float.Parse(reader.GetString("interior_a")),
                        exterior_garage = new Vector3(reader.GetFloat("exterior_garage_x"), reader.GetFloat("exterior_garage_y"), reader.GetFloat("exterior_garage_z")),
                        exterior_garage_a = reader.GetFloat("exterior_garage_a"),
                        in_garage = reader.GetByte("in_garage"),
                        garage_slot = reader.GetByte("garage_slot"),
                    });

                    HouseInfo[index].ext_shape = NAPI.ColShape.CreateCylinderColShape(HouseInfo[index].exterior, 2, 2, 0);
                    HouseInfo[index].int_shape = NAPI.ColShape.CreateCylinderColShape(HouseInfo[index].interior, 2, 2, (uint)(500 + index));

                    HouseInfo[index].ext_shape.SetData<dynamic>("index", index);
                    HouseInfo[index].int_shape.SetData<dynamic>("index", index);

                    HouseInfo[index].int_shape.SetData<dynamic>("ColName", "int_House");
                    HouseInfo[index].ext_shape.SetData<dynamic>("ColName", "ext_House");


                    NAPI.TextLabel.CreateTextLabel("Garage", new Vector3(reader.GetFloat("exterior_garage_x"), reader.GetFloat("exterior_garage_y"), reader.GetFloat("exterior_garage_z")), 10, 0.600f, 0, new Color(221, 255, 0, 65));

                    for (int i = 0; i < 9; i++)
                    {
                        HouseInfo[index].key_acess[i] = reader.GetString("house_key_" + i);
                    }

                    if (HouseInfo[index].sell_house == 1)
                    {
                        HouseInfo[index].blip = NAPI.Blip.CreateBlip(HouseInfo[index].exterior);
                        NAPI.Blip.SetBlipName(HouseInfo[index].blip, "Kuca");
                        NAPI.Blip.SetBlipSprite(HouseInfo[index].blip, 411);
                        NAPI.Blip.SetBlipColor(HouseInfo[index].blip, 2);
                        NAPI.Blip.SetBlipScale(HouseInfo[index].blip, 0.7f);
                        NAPI.Blip.SetBlipShortRange(HouseInfo[index].blip, true);

                    }
                    else if (HouseInfo[index].sell_house == 0)
                    {
                        HouseInfo[index].blip = NAPI.Blip.CreateBlip(new Vector3(0, 0, 0));
                        NAPI.Blip.SetBlipTransparency(HouseInfo[index].blip, 0);

                    }
                    if (HouseInfo[index].exterior.X == 0 && HouseInfo[index].exterior.Y == 0)
                    {
                        NAPI.Blip.SetBlipTransparency(HouseInfo[index].blip, 0);
                    }

                    UpdateHouseLabel(index, false);

                    for (int i = 0; i < 60; i++)
                    {
                        HouseInfo[index].furniture_id[i] = -1;
                        HouseInfo[index].furniture_name[i] = "";
                        HouseInfo[index].furniture_model_name[i] = "";
                        HouseInfo[index].furniture_model[i] = 0;
                        HouseInfo[index].furniture_price[i] = 0;
                        HouseInfo[index].furniture_status[i] = 0;

                        HouseInfo[index].furniture_position[i] = new Vector3(0, 0, 0);
                        HouseInfo[index].furniture_rotation[i] = new Vector3(0, 0, 0);
                    }

                    for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
                    {
                        HouseInfo[index].inventory_index[i] = -1;
                        HouseInfo[index].inventory_type[i] = 0;
                        HouseInfo[index].inventory_amount[i] = 0;
                        HouseInfo[index].inventory_slotid[i] = -1;
                    }

                    LoadFurniture(index);
                    LoadInventoryItens(index);
                    index++;
                }
                HOUSES_CREATED = index;
            }
            Mainpipeline.Close();
        }
    }

    public static void SaveEntrace(int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();
                string query = "UPDATE `houses` SET `name` = @name, `owner` = @owner, `owner_name` = @owner_name,  `sell_house` = @sell_house, `lock_status` = @lock_status, `price` = @price, `vip` = @vip, `exterior_x` = @exterior_x, `exterior_y` = @exterior_y, `exterior_z` = @exterior_z, `exterior_a` = @exterior_a, `interior_x` = @interior_x, `interior_y` = @interior_y, `interior_z` = @interior_z, `interior_a` = @interior_a, `exterior_garage_x` = @exterior_garage_x, `exterior_garage_y` = @exterior_garage_y , `exterior_garage_z` = @exterior_garage_z ,`exterior_garage_a` = @exterior_garage_a, `in_garage` = @in_garage , `garage_slot` = @garage_slot  ";

                for (int i = 0; i < 9; i++)
                {
                    query = query + ", `house_key_" + i + "` = @house_key_" + i + " ";
                }

                query = query + " WHERE `id` = '" + HouseInfo[index].id + "'";


                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);


                myCommand.Parameters.AddWithValue("@name", "" + HouseInfo[index].name + "");
                myCommand.Parameters.AddWithValue("@owner", HouseInfo[index].owner);
                myCommand.Parameters.AddWithValue("@owner_name", HouseInfo[index].owner_name);
                myCommand.Parameters.AddWithValue("@lock_status", HouseInfo[index].locked);
                myCommand.Parameters.AddWithValue("@price", HouseInfo[index].price);
                myCommand.Parameters.AddWithValue("@sell_house", HouseInfo[index].sell_house);

                myCommand.Parameters.AddWithValue("@vip", HouseInfo[index].vip);

                for (int i = 0; i < 9; i++)
                {
                    myCommand.Parameters.AddWithValue("@house_key_" + i, "" + HouseInfo[index].key_acess[i] + "");
                }

                myCommand.Parameters.AddWithValue("@exterior_x", HouseInfo[index].exterior.X.ToString());
                myCommand.Parameters.AddWithValue("@exterior_y", HouseInfo[index].exterior.Y.ToString());
                myCommand.Parameters.AddWithValue("@exterior_z", HouseInfo[index].exterior.Z.ToString());
                myCommand.Parameters.AddWithValue("@exterior_a", HouseInfo[index].exterior_a.ToString());
                myCommand.Parameters.AddWithValue("@interior_x", HouseInfo[index].interior.X.ToString());
                myCommand.Parameters.AddWithValue("@interior_y", HouseInfo[index].interior.Y.ToString());
                myCommand.Parameters.AddWithValue("@interior_z", HouseInfo[index].interior.Z.ToString());
                myCommand.Parameters.AddWithValue("@interior_a", HouseInfo[index].interior_a.ToString());

                myCommand.Parameters.AddWithValue("@exterior_garage_x", HouseInfo[index].exterior_garage.X.ToString());
                myCommand.Parameters.AddWithValue("@exterior_garage_y", HouseInfo[index].exterior_garage.Y.ToString());
                myCommand.Parameters.AddWithValue("@exterior_garage_z", HouseInfo[index].exterior_garage.Z.ToString());

                myCommand.Parameters.AddWithValue("@exterior_garage_a", HouseInfo[index].exterior_garage_a.ToString());

                myCommand.Parameters.AddWithValue("@in_garage", HouseInfo[index].in_garage.ToString());
                myCommand.Parameters.AddWithValue("@garage_slot", HouseInfo[index].garage_slot);

                myCommand.ExecuteNonQuery();
                Mainpipeline.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }

    public static void LoadFurniture(int house_id)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `furnitures` WHERE `house` = " + house_id + ";", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                var index = 0;
                while (reader.Read())
                {
                    HouseInfo[house_id].furniture_id[index] = reader.GetInt32("id");
                    HouseInfo[house_id].furniture_name[index] = reader.GetString("name");
                    HouseInfo[house_id].furniture_model_name[index] = reader.GetString("model_name");
                    HouseInfo[house_id].furniture_model[index] = reader.GetInt32("model");
                    HouseInfo[house_id].furniture_price[index] = reader.GetInt32("price");
                    HouseInfo[house_id].furniture_status[index] = reader.GetInt32("status");
                    HouseInfo[house_id].furniture_position[index] = new Vector3(float.Parse(reader.GetString("position_x")), float.Parse(reader.GetString("position_y")), float.Parse(reader.GetString("position_z")));
                    HouseInfo[house_id].furniture_rotation[index] = new Vector3(float.Parse(reader.GetString("rotation_x")), float.Parse(reader.GetString("rotation_y")), float.Parse(reader.GetString("rotation_z")));

        
                    HouseInfo[house_id].furniture_handle[index] = NAPI.Object.CreateObject(HouseInfo[house_id].furniture_model[index], HouseInfo[house_id].furniture_position[index], new Vector3(HouseInfo[house_id].furniture_rotation[index].X, HouseInfo[house_id].furniture_rotation[index].Y, HouseInfo[house_id].furniture_rotation[index].Z), 255, 500 + (uint)house_id);
                    index++;
                }
            }
            Mainpipeline.Close();
        }
    }

    public static void UpdateFurniture(int house_id)
    {
        for (int index = 0; index < 60; index++)
        {
            if (HouseInfo[house_id].furniture_position[index] != new Vector3(0, 0, 0))
            {

                if (HouseInfo[house_id].furniture_handle[index].Exists)
                {
                    HouseInfo[house_id].furniture_handle[index].Delete();
                }

                if (HouseInfo[house_id].furniture_status[index] == 0)
                {
                    HouseInfo[house_id].furniture_handle[index] = NAPI.Object.CreateObject(HouseInfo[house_id].furniture_model[index], HouseInfo[house_id].furniture_position[index], new Vector3(HouseInfo[house_id].furniture_rotation[index].X, HouseInfo[house_id].furniture_rotation[index].Y, HouseInfo[house_id].furniture_rotation[index].Z), 255, 500 + (uint)house_id);
                }
            }
        }
    }


    public static void UpdateFurnitureIndex(int house_id, int index)
    {

        if (HouseInfo[house_id].furniture_position[index] != new Vector3(0, 0, 0))
        {

            if (HouseInfo[house_id].furniture_handle[index].Exists)
            {
                HouseInfo[house_id].furniture_handle[index].Delete();
            }

            if (HouseInfo[house_id].furniture_status[index] == 0)
            {
                HouseInfo[house_id].furniture_handle[index] = NAPI.Object.CreateObject(HouseInfo[house_id].furniture_model[index], HouseInfo[house_id].furniture_position[index], new Vector3(HouseInfo[house_id].furniture_rotation[index].X, HouseInfo[house_id].furniture_rotation[index].Y, HouseInfo[house_id].furniture_rotation[index].Z), 255, 500 + (uint)house_id);
            }

            
        }

    }


    public static void SaveFurniture(int house_id, int index)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            try
            {
                Mainpipeline.Open();

                string query = "UPDATE `furnitures` SET `name` = @name,  `model` = @model,  `model_name` = @model_name,  `price` = @price,  `status` = @status,  `position_x` = @position_x,  `position_y` = @position_y,  `position_z` = @position_z,  `rotation_x` = @rotation_x,   `rotation_y` = @rotation_y,   `rotation_z` = @rotation_z  ";
                query = query + " WHERE `id` = '" + HouseInfo[house_id].furniture_id[index] + "'";


                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                myCommand.Parameters.AddWithValue("@name", "" + HouseInfo[house_id].furniture_name[index] + "");
                myCommand.Parameters.AddWithValue("@model_name", "" + HouseInfo[house_id].furniture_model_name[index] + "");
                myCommand.Parameters.AddWithValue("@model", HouseInfo[house_id].furniture_model[index]);
                myCommand.Parameters.AddWithValue("@price", HouseInfo[house_id].furniture_price[index]);
                myCommand.Parameters.AddWithValue("@status", HouseInfo[house_id].furniture_status[index]);
                myCommand.Parameters.AddWithValue("@position_x", HouseInfo[house_id].furniture_position[index].X.ToString());
                myCommand.Parameters.AddWithValue("@position_y", HouseInfo[house_id].furniture_position[index].Y.ToString());
                myCommand.Parameters.AddWithValue("@position_z", HouseInfo[house_id].furniture_position[index].Z.ToString());
                myCommand.Parameters.AddWithValue("@rotation_x", HouseInfo[house_id].furniture_rotation[index].X.ToString());
                myCommand.Parameters.AddWithValue("@rotation_y", HouseInfo[house_id].furniture_rotation[index].Y.ToString());
                myCommand.Parameters.AddWithValue("@rotation_z", HouseInfo[house_id].furniture_rotation[index].Z.ToString());

                myCommand.ExecuteNonQuery();
                Mainpipeline.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }

    }

    public static void UpdateHouseLabel(int index, bool first = true)
    {
        if (first)
        {
            HouseInfo[index].label.Delete();
            HouseInfo[index].label_interior.Delete();
        }

        if (HouseInfo[index].sell_house == 1)
        {
            HouseInfo[index].blip.Sprite = 411;
            HouseInfo[index].blip.Color = 3;
            HouseInfo[index].blip.Transparency = 255;

            if (HouseInfo[index].vip == 1)
            {
                HouseInfo[index].label = NAPI.TextLabel.CreateTextLabel("~n~~y~ ", HouseInfo[index].exterior, 8.0f, 0.6f, 4, new Color(221, 255, 0, 255), false, 0);
            }
            else
            {
                HouseInfo[index].label = NAPI.TextLabel.CreateTextLabel("~n~~y~", HouseInfo[index].exterior, 8.0f, 0.6f, 4, new Color(221, 255, 0, 255), false, 0);
            }
        }
        else
        {
            HouseInfo[index].blip.Sprite = 411;
            HouseInfo[index].blip.Color = 1;
            HouseInfo[index].blip.Transparency = 0;
            string lock_string = "~r~Trancada";
            if (HouseInfo[index].locked == 0)
            {
                lock_string = "~g~Baz";
            }
            else if (HouseInfo[index].locked == 1)
            {
                lock_string = "~r~Ghofl";
            }

            HouseInfo[index].label = NAPI.TextLabel.CreateTextLabel(" ~y~Kuca~w~ -~n~~n~~y~~w~", HouseInfo[index].exterior, 8.0f, 0.6f, 4, new Color(221, 255, 0, 255), false);


        }

        HouseInfo[index].label_interior = NAPI.TextLabel.CreateTextLabel(" ", HouseInfo[index].interior, 8.0f, 0.6f, 0, new Color(221, 255, 0, 255), false, 500 + (uint)index);
        HouseInfo[index].marker = NAPI.Marker.CreateMarker(30, HouseInfo[index].exterior - new Vector3(0, 0, 0.1f), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 150), false, 0);
        HouseInfo[index].g_marker = NAPI.Marker.CreateMarker(30, HouseInfo[index].exterior_garage - new Vector3(0, 0, 0.1f), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 150), false, 0);

    }


    public static int GetPlayerInHouse(Player Client)
    {
        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.interior, 70.0f) && Client.Dimension == 500 + (uint)index)
            {
                return index;
            }
            index++;
        }
        return -1;
    }

    public static bool GetPlayerHouseOwner(Player Client, int house_id)
    {
        if (house_id == -1) return false;
        if (HouseInfo[house_id].owner == AccountManage.GetPlayerSQLID(Client))
        {
            return true;

        }
        return false;
    }

    public static void DisplayManageHouseMenu(Player Client)
    {
        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.interior, 70.0f) && Client.Dimension == 500 + (uint)index)
            {
                if (entrace.owner != AccountManage.GetPlayerSQLID(Client))
                {
                    Main.SendErrorMessage(Client, "Niste ovlasceni.");
                    return;
                }

                try
                {
                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 5, Name = "Zakljucaj", IsTicked = Convert.ToBoolean(entrace.locked), Description = "Zakljucavanje i otkljucavanje vrata." });
                menu_item_list.Add(new { Type = 1, Name = "~g~Prodaj kucu drzavi", Description = "Prodaja kuce drzavi po nizoj ceni od kupljene." });
                menu_item_list.Add(new { Type = 1, Name = "Narezivanje kljuceva", Description = "Narezite kljuc drugoj osobi." });


                InteractMenu.CreateMenu(Client, "HOUSE_MENU", "Kuca", "~g~Kuca od ~b~" + entrace.owner_name + "", false, NAPI.Util.ToJson(menu_item_list), false);
                //
                }
                catch (Exception ex) 
                {
                    NAPI.Util.ConsoleOutput("DisplayManageHouseMenu." + ex.Message);
                }
            }
            index++;
        }
    }

    public static void DisplayHouseMenu(Player Client, int menu_id, string objectName = "", int selectIndex = 0)
    {
        try {

        
        int house_id = GetPlayerInHouse(Client);

        if (house_id == -1)
        {
            Main.SendErrorMessage(Client, "Doslo je do greske. (Code: " + house_id + ")");
            return;
        }

        switch (menu_id)
        {

            case 5:
                {
                    List<dynamic> menu_item_list = new List<dynamic>();
                    int count = 0;
                    for (int i = 0; i < 9; i++)
                    {
                        if (HouseInfo[house_id].key_acess[i] != "0")
                        {
                            menu_item_list.Add(new { Type = 1, Name = HouseInfo[house_id].key_acess[i], Description = "Narezivanje kljuceva " + HouseInfo[house_id].key_acess[i] + ".", RightLabel = "" });
                            Client.SetData<dynamic>("ListTrack_" + count, i);
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        DisplayManageHouseMenu(Client);
                        return;
                    }
                    InteractMenu.CreateMenu(Client, "HOUSE_MENU_KEYS_MANAGE", "Kuca", "~g~Narezivanje kljuceva", false, NAPI.Util.ToJson(menu_item_list), false);

                    break;
                }
        }
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput("[DisplayHouseMenu] " + ex.Message);
        }
    }

    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        try{
        if (callbackId == "HOUSE_MENU")
        {

            if (selectedIndex == 1)
            {
                int house_id = GetPlayerInHouse(Client);

                if (house_id == -1)
                {
                    return;
                }
                if (Main.IsInRangeOfPoint(Client.Position, HouseInfo[house_id].interior, 20.0f))
                {
                    if (HouseInfo[house_id].owner != AccountManage.GetPlayerSQLID(Client))
                    {
                        return;
                    }

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_GROVE + "House", "Prodali ste kucu drzavi.");

                    Main.GivePlayerMoneyBank(Client, HouseInfo[house_id].price);


                    // Entrce Name
                    Client.TriggerEvent("blip_remove", "myhouse_" + house_id + "");

                    HouseInfo[house_id].owner = -1;
                    HouseInfo[house_id].owner_name = "";
                    HouseInfo[house_id].locked = 0;
                    HouseInfo[house_id].safe = 0;
                    HouseInfo[house_id].sell_house = 1;

                    Client.Position = HouseInfo[house_id].exterior;
                    Client.Dimension = 0;

                    for (int i = 0; i < 9; i++)
                    {
                        HouseInfo[house_id].key_acess[i] = "0";
                    }

                    for (int id = 0; id < 60; id++)
                    {
                        if (HouseInfo[house_id].furniture_position[id].X != 0 && HouseInfo[house_id].furniture_position[id].Y != 0)
                        {
                            Main.CreateMySqlCommand("DELETE FROM `furnitures` WHERE `id` = " + HouseInfo[house_id].furniture_id[id] + ";");

                            HouseInfo[house_id].furniture_id[id] = -1;
                            HouseInfo[house_id].furniture_name[id] = "";
                            HouseInfo[house_id].furniture_model_name[id] = "";
                            HouseInfo[house_id].furniture_model[id] = 0;
                            HouseInfo[house_id].furniture_price[id] = 0;
                            HouseInfo[house_id].furniture_status[id] = 0;

                            HouseInfo[house_id].furniture_position[id] = new Vector3(0, 0, 0);
                            HouseInfo[house_id].furniture_rotation[id] = new Vector3(0, 0, 0);
                            HouseInfo[house_id].furniture_handle[id].Delete();

                            HouseSystem.UpdateFurniture(house_id);
                        }
                    }

                    HouseSystem.UpdateHouseLabel(house_id);
                    //
                    HouseSystem.SaveEntrace(house_id);

                }

            }
            if (selectedIndex == 2)
            {
                DisplayHouseMenu(Client, 6);
            }
            else if (selectedIndex == 4)
            {
                DisplayHouseMenu(Client, 2);
            }
            else if (selectedIndex == 5)
            {
                DisplayHouseMenu(Client, 4);
            }

        }
        else if (callbackId == "HOUSE_MENU_FURNITURE_CATEGORY")
        {
            DisplayHouseMenu(Client, 3, objectName);
        }
        else if (callbackId == "HOUSE_MENU_FURNITURE_PREVIEW")
        {
            int house_id = GetPlayerInHouse(Client);
            if (house_id == -1)
            {
                Main.SendErrorMessage(Client, "Nemate kljuc!");
                return;
            }

            int index = Client.GetData<dynamic>("ListTrack_" + selectedIndex);

            //  BuyFurniture(Client, furniture_data[index].name, furniture_data[index].model, Convert.ToString(furniture_data[index].hash), furniture_data[index].price);
        }
        else if (callbackId == "HOUSE_MENU_MANAGE_FURNITURE")
        {
            DisplayHouseMenu(Client, 5, objectName, selectedIndex);
        }
        else if (callbackId == "HOUSE_MENU_MANAGE_SELECT")
        {
            int house_id = GetPlayerInHouse(Client);
            if (house_id == -1)
            {
                Main.SendErrorMessage(Client, "Nemate kljuc!");
                return;
            }

            int i = Client.GetData<dynamic>("select_mobilia");

            if (selectedIndex == 0)
            {
                AtivarMobilia(Client, i);
            }
            else if (selectedIndex == 1)
            {
                EditarMobilia(Client, i);
            }
            else if (selectedIndex == 2)
            {
                VenderMobilia(Client, i);
            }
        }
        else if (callbackId == "HOUSE_MENU_KEYS_MANAGE")
        {
            int house_id = GetPlayerInHouse(Client);
            if (house_id == -1)
            {
                Main.SendErrorMessage(Client, "Nemate kljuc!");
                return;
            }
            int index = Client.GetData<dynamic>("ListTrack_" + selectedIndex);
            RetirarChaveCasa(Client, index, HouseInfo[house_id].key_acess[index]);
        }
        else if (callbackId == "HOUSE_MENU_SAFE")
        {
            int house_id = GetPlayerInHouse(Client);
            if (house_id == -1)
            {
                Main.SendErrorMessage(Client, "Nemate kljuc!");
                return;
            }
            if (selectedIndex == 0) InteractMenu.User_Input(Client, "HOUSE_MENU_DEPOSIT", "Ostavljanje novca", Main.GetPlayerMoney(Client).ToString(), "Unesite koliko novca ostavljate u sef", "number");
            else InteractMenu.User_Input(Client, "HOUSE_MENU_WITHDRAW", "Podizanje novca", HouseInfo[house_id].safe.ToString(), "Unesite koliko novca podizete iz sefa", "number");
        }
        else if (callbackId == "HOUSE_MENU_Garage_MANAGE")
        {
            int playerid = Main.getIdFromClient(Client);
            for (int i = 0; i < PlayerVehicle.MAX_PLAYER_VEHICLES; i++)
            {
                if (PlayerVehicle.vehicle_data[playerid].owner_sql[i] == AccountManage.GetPlayerSQLID(Client) && PlayerVehicle.vehicle_data[playerid].model[i] == objectName && PlayerVehicle.vehicle_data[playerid].state[i] == 4)
                {
                    Vector3 pos = new Vector3(0, 0, 0);
                    float rot = 0;
                    foreach (HouseEnum item in HouseInfo)
                    {
                        if (Main.IsInRangeOfPoint(item.exterior_garage, Client.Position, 4) && Main.IsInRangeOfPoint(PlayerVehicle.vehicle_data[playerid].position[i], Client.Position, 10) && item.owner == AccountManage.GetPlayerSQLID(Client))
                        {
                            item.in_garage--;
                            pos = PlayerVehicle.vehicle_data[playerid].position[i];
                            rot = PlayerVehicle.vehicle_data[playerid].rotation[i];
                            PlayerVehicle.vehicle_data[playerid].state[i] = 1;
                            TakeOutFromGarage(Client, i, pos, rot);
                            break;
                        }
                    }

                }
            }


        }
        }
        catch (Exception ex) 
        {
            NAPI.Util.ConsoleOutput("SelectMenuResponse." + ex.Message);
        }

    }

    public static void TakeOutFromGarage(Player Client, int index, Vector3 position, float rot)
    {
        int playerid = Main.getIdFromClient(Client);

        PlayerVehicle.vehicle_data[playerid].handle[index] = API.Shared.CreateVehicle(NAPI.Util.GetHashKey(PlayerVehicle.vehicle_data[playerid].model[index]), position, rot, PlayerVehicle.vehicle_data[playerid].cor_1[index], PlayerVehicle.vehicle_data[playerid].cor_2[index], dimension: (uint)PlayerVehicle.vehicle_data[playerid].dimension[index]);
        PlayerVehicle.vehicle_data[playerid].handle[index].EngineStatus = false;
        PlayerVehicle.vehicle_data[playerid].handle[index].SetData<dynamic>("Mashin_Owner", AccountManage.GetPlayerSQLID(Client));
        PlayerVehicle.vehicle_data[playerid].handle[index].SetData<dynamic>("Owner_set", true);
        PlayerVehicle.vehicle_data[playerid].handle[index].SetData<dynamic>("index_Mashin", index);
        PlayerVehicle.vehicle_data[playerid].handle[index].SetData<dynamic>("veh_sql", PlayerVehicle.vehicle_data[playerid].index[index]);

        VehicleInventory.AddInventoryToVehicle(PlayerVehicle.vehicle_data[playerid].handle[index], NAPI.Util.VehicleNameToModel(PlayerVehicle.vehicle_data[playerid].model[index]));


        VehicleStreaming.SetLockStatus(PlayerVehicle.vehicle_data[playerid].handle[index], true);
        VehicleStreaming.SetEngineState(PlayerVehicle.vehicle_data[playerid].handle[index], true);
        Main.SetVehicleFuel(PlayerVehicle.vehicle_data[playerid].handle[index], Convert.ToDouble(PlayerVehicle.vehicle_data[playerid].fuel[index]));

        NAPI.Vehicle.SetVehicleNumberPlate(PlayerVehicle.vehicle_data[playerid].handle[index], PlayerVehicle.vehicle_data[playerid].plate[index]);

        PlayerVehicle.vehicle_data[playerid].handle[index].SetSharedData("INTERACT", PlayerVehicle.vehicle_data[playerid].handle[index].Type);

        string[] temp_mysql_data = PlayerVehicle.vehicle_data[playerid].json_vehicle_mods[index].ToString().Split('|');
        VehicleInventory.LoadVehicleInventoryItens(Client, PlayerVehicle.vehicle_data[playerid].handle[index], PlayerVehicle.vehicle_data[playerid].index[index]);

        if (PlayerVehicle.vehicle_data[playerid].json_vehicle_mods[index] != "")
        {

            for (int i = 0; i < 68; i++)
            {
                if (i == 66) continue;
                if (i == 67) continue;
                PlayerVehicle.vehicle_data[playerid].handle[index].SetMod(i, Convert.ToInt32(temp_mysql_data[i]));
            }
            NAPI.Task.Run(() =>
            {

                PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor = new Color(Convert.ToInt32(temp_mysql_data[68]), Convert.ToInt32(temp_mysql_data[69]), Convert.ToInt32(temp_mysql_data[70]));

                if ((PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor.Red == 0 && PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor.Green == 0 && PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor.Blue == 0) || (PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor.Red == 255 && PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor.Green == 255 && PlayerVehicle.vehicle_data[playerid].handle[index].NeonColor.Blue == 255))
                {
                    API.Shared.SetVehicleNeonState(PlayerVehicle.vehicle_data[playerid].handle[index], false);
                }
                else
                {
                    API.Shared.SetVehicleNeonState(PlayerVehicle.vehicle_data[playerid].handle[index], true);
                }


            }, delayTime: 2000);
        }

        NAPI.Vehicle.SetVehiclePrimaryColor(PlayerVehicle.vehicle_data[playerid].handle[index], PlayerVehicle.vehicle_data[playerid].cor_1[index]);
        NAPI.Vehicle.SetVehicleSecondaryColor(PlayerVehicle.vehicle_data[playerid].handle[index], PlayerVehicle.vehicle_data[playerid].cor_2[index]);


        try
        {
            NAPI.Task.Run(() =>
            {

                PlayerVehicle.vehicle_data[playerid].handle[index].PrimaryColor = PlayerVehicle.vehicle_data[playerid].cor_1[index];
                PlayerVehicle.vehicle_data[playerid].handle[index].SecondaryColor = PlayerVehicle.vehicle_data[playerid].cor_2[index];

            }, delayTime: 2000);
        }
        catch
        {

        }

        PlayerVehicle.vehicle_data[playerid].handle[index].Health = PlayerVehicle.vehicle_data[playerid].health[index];
        PlayerVehicle.SavePlayerVehicle(Client, index);
    }

    public static void IndexChangeMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
    }

    public static void ListItemMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
    }

    public static void CheckBoxItemMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList, bool _checked)
    {
        if (callbackId == "HOUSE_MENU")
        {
            if (selectedIndex == 0)
            {
                int house_id = GetPlayerInHouse(Client);

                if (house_id == -1)
                {
                    Main.SendErrorMessage(Client, "Nemate kucu.");
                    return;
                }

                if (_checked)
                {
                    Client.SendNotification("~r~Zakljucali ste~w~ kucu.");
                    HouseInfo[house_id].locked = 1;
                }
                else
                {
                    Client.SendNotification("~g~Otkljucali ste~w~ kucu.");
                    HouseInfo[house_id].locked = 0;
                }

                UpdateHouseLabel(house_id);
            }
        }
    }


    public static void OnInputResponse(Player Client, String response, String inputtext)
    {
        if (response == "HOUSE_MENU_DEPOSIT")
        {
            int house_id = GetPlayerInHouse(Client);

            if (house_id == -1)
            {
                Main.SendErrorMessage(Client, "Samo vlasnik kuce.");
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                Main.SendErrorMessage(Client, "Pogresan unos.");
                return;
            }

            int money = Convert.ToInt32(inputtext);

            if (Main.GetPlayerMoney(Client) < money)
            {
                Main.SendErrorMessage(Client, "Nemate toliko novca!");
                return;
            }

            HouseInfo[house_id].safe += money;
            Main.GivePlayerMoney(Client, -money);
            Main.SendSuccessMessage(Client, "Ostavili ste $" + money.ToString("N0") + " u kucni sef.");

        }
        else if (response == "HOUSE_MENU_WITHDRAW")
        {
            int house_id = GetPlayerInHouse(Client);

            if (house_id == -1)
            {
                Main.SendErrorMessage(Client, "Niste vlasnik ove kuce!");
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                Main.SendErrorMessage(Client, "Pogresan unos!.");
                return;
            }

            int money = Convert.ToInt32(inputtext);

            if (HouseInfo[house_id].safe < money)
            {
                Main.SendErrorMessage(Client, "Nemate toliko novca!");
                return;
            }

            HouseInfo[house_id].safe -= money;
            Main.GivePlayerMoney(Client, money);
            Main.SendSuccessMessage(Client, "Uzeli ste $" + money.ToString("N0") + " iz kucnog sefa.");
        }
        else if (response == "house_sell_price")
        {
            if (!Main.IsNumeric(inputtext))
            {
                Main.SendErrorMessage(Client, "Pogresan unos!");
                return;
            }
            CMD_vendercasa(Client, int.Parse(inputtext));
        }
    }

    public static void OnMenuReturnClose(Player Client, String callbackId)
    {

    }

    [Command("givekey", "/givekey [Client/name]")]
    public static void CMD_darchaves(Player Client, string idOrName)
    {
        Player target = Main.findPlayer(Client, idOrName);

        if (target == null)
        {
            Main.SendErrorMessage(Client, "Pogresan ID!");
            return;
        }

        if (!API.Shared.IsPlayerConnected(target))
        {
            Main.SendErrorMessage(Client, "Pogresan ID!");
            return;
        }

        if (target.GetData<dynamic>("status") == false)
        {
            Main.SendErrorMessage(Client, "Ne mozete njemu dati kljuc.");
            return;
        }

        if (target == Client)
        {
            Main.SendErrorMessage(Client, "Ne mozete sami sebi dati kljuc.");
            return;
        }

        DarAcessoCasa(Client, target.GetData<dynamic>("character_name"));
    }

    //
    //
    //


    [RemoteEvent("BuyFurniture")]
    public static void BuyFurniture(Player Client, string selectedname, int Selected)
    {

        if (furniture_data.ElementAtOrDefault(Selected) == null)
        {
            return;
        }
        if (furniture_data[Selected].name != selectedname)
        {
            return;
        }

        Client.TriggerEvent("Hide_Browser");

        Client.TriggerEvent("startBuy", furniture_data[Selected].model);

        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "[FURNITURE]", "Kupili ste namestaj.");
        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "[FURNITURE]", " Postavite ga na zeljeno mesto i koristite Y da potvrdite mesto.");

        Client.SetData<dynamic>("startEditing", true);
        Client.SetData<dynamic>("startEditing_name", furniture_data[Selected].name);
        Client.TriggerEvent("hidePoliceCivilMenu");
    }

    [RemoteEvent("acceptEdit")]
    public static void BuyFurniture(Player Client, uint modelo, float x, float y, float z, float rx, float ry, float rz)
    {
        // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "[Mobilia]", "Você está agora no modo editor de objeto.");
        // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "[Mobilia]", "Coloque-o na posição que você deseja e pressione Y para confirmar a comprar por $"+ price + ".");



        if (Client.GetData<dynamic>("startFurnitureEditing") == true)
        {
            Client.SetData<dynamic>("startFurnitureEditing", false);
            if (Client.Dimension < 500)
            {
                Main.SendErrorMessage(Client, "Ne mozete uredjivati namestaj ovde.");
                return;
            }

            int i = Client.GetData<dynamic>("startFurnitureEditing_id");

            int house_id = (int)Client.Dimension - 500;

            HouseInfo[house_id].furniture_position[i] = new Vector3(x, y, z);
            HouseInfo[house_id].furniture_rotation[i] = new Vector3(rx, ry, rz);
            HouseInfo[house_id].furniture_handle[i].Position = new Vector3(x, y, z);
            HouseInfo[house_id].furniture_handle[i].Rotation = new Vector3(rx, ry, rz);

            Main.DisplaySubtitle(Client, "Kuca ~b~" + HouseInfo[house_id].name[i] + "~w~ je uspesno uredjena.");

            UpdateFurniture(house_id);
            SaveFurniture(house_id, i);

        }

        else if (Client.GetData<dynamic>("startEditing") == true)
        {
            Client.SetData<dynamic>("startEditing", false);
            if (Client.Dimension < 500)
            {
                Main.SendErrorMessage(Client, "Ne mozete uredjivati namestaj ovde.");
                return;
            }

            

            int house_id = (int)Client.Dimension - 500;
            for (int i = 0; i < 60; i++)
            {

                if (HouseInfo[house_id].furniture_position[i] == new Vector3(0, 0, 0))
                {
                    foreach (var furniture in furniture_data)
                    {
                        if (furniture.name == Client.GetData<dynamic>("startEditing_name"))
                        {
                            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                            {
                                try
                                {
                                    Mainpipeline.Open();
                                    string query = "INSERT INTO furnitures (`house`)" + " VALUES ('" + house_id + "')";
                                    MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                                    myCommand.ExecuteNonQuery();
                                    HouseInfo[house_id].furniture_id[i] = (int)myCommand.LastInsertedId;

                                    Main.SendSuccessMessage(Client, "Kupili ste " + Main.EMBED_BLUE + "" + furniture.name + "" + Main.EMBED_WHITE + " za " + Main.EMBED_LIGHTGREEN + "$" + furniture.price + "" + Main.EMBED_WHITE + ".");


                                    HouseInfo[house_id].furniture_name[i] = furniture.name;
                                    HouseInfo[house_id].furniture_model_name[i] = furniture.model;
                                    HouseInfo[house_id].furniture_price[i] = furniture.price;
                                    HouseInfo[house_id].furniture_model[i] = furniture.hash;
                                    HouseInfo[house_id].furniture_position[i] = new Vector3(x, y, z);
                                    HouseInfo[house_id].furniture_rotation[i] = new Vector3(rx, ry, rz);
                                    HouseInfo[house_id].furniture_handle[i] = NAPI.Object.CreateObject(furniture.hash, HouseInfo[house_id].furniture_position[i], new Vector3(HouseInfo[house_id].furniture_rotation[i].X, HouseInfo[house_id].furniture_rotation[i].Y, HouseInfo[house_id].furniture_rotation[i].Z), 255, Client.Dimension);
                                    SaveFurniture(house_id, i);
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
            }
            Main.SendErrorMessage(Client, "Ne mozete uredjivati namestaj ovde.");
        }
    }

    [RemoteEvent("cancelEdit")]
    public static void cancelEdit(Player Client)
    {
        if (Client.GetData<dynamic>("startFurnitureEditing") == true)
        {
            UpdateFurniture(Client.GetData<dynamic>("startFurnitureEditing_house"));
            Client.SetData<dynamic>("startFurnitureEditing", false);
        }
        else if (Client.GetData<dynamic>("startEditing") == true)
        {
            Client.SetData<dynamic>("startEditing", false);
        }
    }

    [RemoteEvent("EditarMobilia")]
    public static void EditarMobilia(Player Client, int id)
    {
        if (Client.Dimension < 500)
        {
            Main.SendErrorMessage(Client, "Ne mozete uredjivati namestaj ovde.");
            return;
        }


        int house_id = (int)Client.Dimension - 500;

        Client.TriggerEvent("Hide_Browser");
        Client.SetData<dynamic>("General_CEF", false);

        Client.TriggerEvent("startEditing", HouseInfo[house_id].furniture_model_name[id], HouseInfo[house_id].furniture_position[id], HouseInfo[house_id].furniture_rotation[id]);
        Client.SetData<dynamic>("startFurnitureEditing", true);
        Client.SetData<dynamic>("startFurnitureEditing_id", id);
        Client.SetData<dynamic>("startFurnitureEditing_house", house_id);
        HouseInfo[house_id].furniture_handle[id].Delete();

    }

    [RemoteEvent("AtivarMobilia")]
    public static void AtivarMobilia(Player Client, int id)
    {
        if (Client.Dimension < 500)
        {
            Main.SendErrorMessage(Client, "Ne mozete uredjivati namestaj ovde.");
            return;
        }
        int house_id = (int)Client.Dimension - 500;

        if (HouseInfo[house_id].furniture_status[id] == 0) HouseInfo[house_id].furniture_status[id] = 1;
        else HouseInfo[house_id].furniture_status[id] = 0;
        UpdateFurnitureIndex(house_id, id);

    }

    [RemoteEvent("VenderMobilia")]
    public static void VenderMobilia(Player Client, int id)
    {
        if (Client.Dimension < 500)
        {
            Main.SendErrorMessage(Client, "Ne mozete uredjivati namestaj ovde.");
            return;
        }
        int house_id = (int)Client.Dimension - 500;


        if (HouseInfo[house_id].furniture_price[id] > 2)
        {
            int price = HouseInfo[house_id].furniture_price[id] / 2;
            Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "[FURNITURE]", "Prodali ste namestaj za $" + price.ToString("N0") + ".");
            Main.GivePlayerMoney(Client, price);
        }


        Main.CreateMySqlCommand("DELETE FROM `furnitures` WHERE `id` = " + HouseInfo[house_id].furniture_id[id] + ";");

        HouseInfo[house_id].furniture_id[id] = -1;
        HouseInfo[house_id].furniture_name[id] = "";
        HouseInfo[house_id].furniture_model_name[id] = "";
        HouseInfo[house_id].furniture_model[id] = 0;
        HouseInfo[house_id].furniture_price[id] = 0;
        HouseInfo[house_id].furniture_status[id] = 0;

        HouseInfo[house_id].furniture_position[id] = new Vector3(0, 0, 0);
        HouseInfo[house_id].furniture_rotation[id] = new Vector3(0, 0, 0);
        HouseInfo[house_id].furniture_handle[id].Delete();

        UpdateFurniture(house_id);

    }


    [RemoteEvent("DepoistarDinheiroCasa")]
    public static void DepoistarDinheiroCasa(Player Client, int money)
    {

        if (Client.Dimension < 500)
        {
            Main.SendErrorMessage(Client, "Ne mozete uredjivati namestaj ovde.");
            return;
        }
        int house_id = (int)Client.Dimension - 500;

        if (Main.GetPlayerMoney(Client) < money)
        {
            Main.SendNotificationBrowser(Client, "GRESKA:", "Nemate dovoljno novca.", "danger", "top", "center");
            return;
        }

        HouseInfo[house_id].safe += money;
        Main.GivePlayerMoney(Client, -money);
        Main.SendSuccessMessage(Client, "Ostavili ste $" + money.ToString("N0") + " u kucni sef.");
        Main.SendNotificationBrowser(Client, "", "Ostavili ste $" + money.ToString("N0") + " u kucni sef.", "success", "top", "center");

    }

    [RemoteEvent("RetirarDinheiroCasa")]
    public static void RetirarDinheiroCasa(Player Client, int money)
    {

        if (Client.Dimension < 500)
        {
            Main.SendErrorMessage(Client, "Ne mozete uredjivati namestaj ovde.");
            return;
        }
        int house_id = (int)Client.Dimension - 500;

        if (HouseInfo[house_id].safe < money)
        {
            Main.SendNotificationBrowser(Client, "GRESKA:", "Nemate dovoljno novca.", "danger", "top", "center");
            return;
        }

        HouseInfo[house_id].safe -= money;
        Main.GivePlayerMoney(Client, money);
        Main.SendSuccessMessage(Client, "Uzeli ste $" + money.ToString("N0") + " iz kucnog sefa.");
        Main.SendNotificationBrowser(Client, "", "Uzeli ste $" + money.ToString("N0") + " iz kucnog sefa.", "success", "top", "center");

    }

    [RemoteEvent("DarAcessoCasa")]
    public static void DarAcessoCasa(Player Client, string name)
    {
        if (Client.Dimension < 500)
        {
            Main.SendErrorMessage(Client, "Ne mozete uredjivati namestaj ovde.");
            return;
        }
        int house_id = (int)Client.Dimension - 500;

        for (int i = 0; i < 9; i++)
        {
            if (HouseInfo[house_id].key_acess[i] == name)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Alert, NotifyPosition.BottomCenter, "Nemate kljuc.");
                return;
            }
        }

        for (int i = 0; i < 9; i++)
        {
            if (HouseInfo[house_id].key_acess[i] == "0")
            {
                HouseInfo[house_id].key_acess[i] = name;
                Main.SendSuccessMessage(Client, "Dali ste " + name + " kljuc.");
                SaveEntrace(house_id);
                return;
            }
        }

        Main.SendNotificationBrowser(Client, "GRESKA:", "Nemate pristup ovoj kuci.", "danger", "top", "right");
    }


    [RemoteEvent("RetirarChaveCasa")]
    public static void RetirarChaveCasa(Player Client, int i, string name)
    {
        if (Client.Dimension < 500)
        {
            Main.SendErrorMessage(Client, "Nemate pristup ovoj kuci.");
            return;
        }
        int house_id = (int)Client.Dimension - 500;

        HouseInfo[house_id].key_acess[i] = "0";

        Main.SendNotificationBrowser(Client, "", "Uzeli ste kljuc od " + name + ".", "success", "top", "right");

    }


    //DarAcessoCasa

    public static void PressKeyY(Player Client)
    {
        int index = 0;
        foreach (HouseEnum entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.exterior, 2.0f) && Client.Dimension == 0)
            {
                if (entrace.locked == 1)
                {
                    Main.SendErrorMessage(Client, "Vrata su zakljucana.");
                    return;
                }

                Client.TriggerEvent("screenFadeOut", 250);
                Client.TriggerEvent("freeze", true);
                Client.TriggerEvent("screenFadeIn", 2000);

                NAPI.Entity.SetEntityPosition(Client, entrace.interior);
                Client.Rotation = new Vector3(0, 0, entrace.interior_a);

                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(Client))
                    {

                    Client.TriggerEvent("freeze", false);
                    Client.Dimension = 500 + (uint)index;
                    }

                }, delayTime: 1500);
                return;
            }
            else if (Main.IsInRangeOfPoint(Client.Position, entrace.interior, 2.0f) && Client.Dimension == 500 + (uint)index)
            {
                if (entrace.locked == 1 && entrace.sell_house == 0)
                {
                    Main.SendErrorMessage(Client, "Vrata su zakljucana.");
                    return;
                }
                Client.TriggerEvent("screenFadeOut", 100);
                Client.TriggerEvent("screenFadeIn", 2000);

                Client.TriggerEvent("freeze", true);
                NAPI.Entity.SetEntityPosition(Client, entrace.exterior);
                Client.Rotation = new Vector3(0, 0, entrace.exterior_a);
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(Client))
                    {

                    Client.Dimension = 0;
                    Client.TriggerEvent("freeze", false);
                    }

                }, delayTime: 1500);
                return;
            }
            else if (Main.IsInRangeOfPoint(Client.Position, entrace.exterior_garage, 4))
            {
                if (entrace.owner != AccountManage.GetPlayerSQLID(Client))
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Ovo nije Vasa kuca.");
                    return;
                }
                int playerid = Main.getIdFromClient(Client);
                List<dynamic> menu_item = new List<dynamic>();
                for (int i = 0; i < PlayerVehicle.MAX_PLAYER_VEHICLES; i++)
                {
                    if (PlayerVehicle.vehicle_data[playerid].state[i] == 4 && Main.IsInRangeOfPoint(PlayerVehicle.vehicle_data[playerid].position[i], Client.Position, 10))
                    {
                        menu_item.Add(new { Type = 1, Name = PlayerVehicle.vehicle_data[playerid].model[i], Description = "" });
                        

                    }
                }
                InteractMenu.CreateMenu(Client, "HOUSE_MENU_Garage_MANAGE", "Kuca", "~g~Garaza", false, NAPI.Util.ToJson(menu_item), false);
            }
            index++;
        }
    }

    public static void KeyPressM(Player Client)
    {
        if (Client.GetData<dynamic>("startEditing") == true || Client.GetData<dynamic>("startFurnitureEditing") == true)
        {
            Main.SendErrorMessage(Client, " Ne mozete koristiti meni kuce dok uredjujete namestaj.");
            return;
        }
        DisplayManageHouseMenu(Client);
    }

    public static int GetPlayerHouses(Player Client)
    {
        int houses = 0;
        foreach (var entrace in HouseInfo)
        {
            if (entrace.owner == AccountManage.GetPlayerSQLID(Client))
            {
                houses++;
            }
        }
        return houses;
    }

    public static int GetPlayerHousesLimit(Player Client)
    {
        int houses = 1;
        if (Client.GetData<dynamic>("character_house_slots") > 0)
        {
            houses += Client.GetData<dynamic>("character_house_slots");
        }
        return houses;
    }

    [RemoteEvent("BuyHouse")]
    public void CMD_comprarcasa(Player Client, int index)
    {
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.exterior, 2.0f) && Client.Dimension == 0)
            {
                index = HouseInfo.IndexOf(entrace);
                if (entrace.sell_house != 1)
                {
                    Main.SendErrorMessage(Client, "Ova kuca nije na prodaju.");
                    return;
                }
                if (entrace.owner == AccountManage.GetPlayerSQLID(Client))
                {
                    entrace.sell_house = 0;
                    HouseSystem.UpdateHouseLabel(index);
                    HouseSystem.SaveEntrace(index);
                    return;
                }
                if (GetPlayerHouses(Client) >= GetPlayerHousesLimit(Client))
                {
                    Main.SendErrorMessage(Client, "Ne mozete imati vise od " + GetPlayerHousesLimit(Client) + " kuce.");
                    return;
                }

                if (entrace.vip == 1)
                {
                    if (VIP.GetPlayerVIP(Client) == 0)
                    {
                        Main.SendErrorMessage(Client, "Niste VIP !");
                        return;
                    }
                    if (VIP.GetPlayerCredits(Client) < entrace.price)
                    {
                        Main.SendErrorMessage(Client, "Nemate dovoljno VIP kredita za kupovinu ove kuce.");
                        return;
                    }
                    VIP.SetPlayerCredits(Client, VIP.GetPlayerCredits(Client) - entrace.price);
                }
                else
                {
                    if (Main.GetPlayerBank(Client) < entrace.price)
                    {
                        Main.SendErrorMessage(Client, "Nemate dovoljno novca za kupovinu ove kuce.");
                        return;
                    }

                    Main.GivePlayerMoneyBank(Client, -entrace.price);
                }

                if (entrace.owner != -1)
                {
                    Player Target = Main.FindPlayerFromSqlid(entrace.owner);

                    if (Target != null)
                    {
                        Main.SendCustomChatMessasge(Target, "[~g~KUCA~w~]~w~ ~g~Cestitamo, ~w~kupili ste kucu za ~g~$" + entrace.price + " ~w~.");
                        Main.GivePlayerMoneyBank(Target, entrace.price);
                    }
                    else
                    {
                        Main.CreateMySqlCommand("UPDATE `characters` SET `bank`=`bank`+" + entrace.price + "");
                    }
                }

                Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_BLUE + "Kuca:", "" + Main.EMBED_WHITE + "Koristite " + Main.EMBED_BLUE + "M" + Main.EMBED_WHITE + " da otvorite meni kuce."); ;
                //  Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_GROVE + "Propriedade", "" + Main.EMBED_WHITE + "Baraye didan dastorat az " + Main.EMBED_LIGHTRED + "/help" + Main.EMBED_WHITE + " Estefade konid.");


                // Entrce Name
                entrace.owner = AccountManage.GetPlayerSQLID(Client);
                entrace.owner_name = NAPI.Data.GetEntityData(Client, "character_name");
                entrace.sell_house = 0;
                UpdateHouseLabel(index);

                // teleport
                Client.TriggerEvent("screenFadeOut", 100);
                Client.TriggerEvent("screenFadeIn", 2000);
                Client.TriggerEvent("freeze", true);

                NAPI.Entity.SetEntityPosition(Client, entrace.interior);
                Client.Rotation = new Vector3(0, 0, entrace.interior_a);
                Client.Dimension = (500 + (uint)index);

                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(Client))
                    {
                    Client.TriggerEvent("freeze", false);
                    Client.Dimension = (500 + (uint)index);

                    }
                }, delayTime: 1500);
                SaveEntrace(index);
                return;
            }
            index++;
        }
    }

    [Command("sellhouse")]
    public static void CMD_vendercasa(Player Client, int Price)
    {
        if (Price <= 0)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Ne mozete to!");
            return;
        }
        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.exterior, 2.0f) && Client.Dimension == 0)
            {
                if (entrace.owner != AccountManage.GetPlayerSQLID(Client))
                {
                    Main.SendErrorMessage(Client, "Niste pored kuce.");
                    return;
                }

                Main.SendMessageWithTagToPlayer(Client, "" +Main.EMBED_GROVE + "Prodali ste kucu." , "");
                entrace.sell_house = 1;
                entrace.price = Price;
                entrace.blip.Position = entrace.exterior;
                NAPI.Blip.SetBlipName(entrace.blip, "Kuca");
                NAPI.Blip.SetBlipSprite(entrace.blip, 40);
                NAPI.Blip.SetBlipColor(entrace.blip, 3);
                NAPI.Blip.SetBlipScale(entrace.blip, 0.7f);
                NAPI.Blip.SetBlipShortRange(entrace.blip, true);

                UpdateHouseLabel(index);
                SaveEntrace(index);
                return;
            }
            index++;
        }
    }

    [Command("mojakuca")]
    public void MyHome(Player player)
    {
        if (!AccountManage.GetPlayerConnected(player))
        {
            return;
        }
        foreach (var item in HouseInfo)
        {
            if (item.owner == AccountManage.GetPlayerSQLID(player))
            {
                int index = HouseInfo.IndexOf(item);
                player.TriggerEvent("blip_create_ext", "myhouse_" + index + "", item.exterior, 59, 1f, 40, true, "Moja Kuca");
                NAPI.Task.Run(() =>
                {
                    if (player.Exists && AccountManage.GetPlayerConnected(player))
                    {
                        player.TriggerEvent("blip_remove", "myhouse_" + index + "");
                    }
                }, 60000);
            }
        }
    }


    public void fasdwasdwa(Player Client)
    {
        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.exterior, 2.0f) && Client.Dimension == 0)
            {
                if (entrace.owner != AccountManage.GetPlayerSQLID(Client))
                {
                    Main.SendErrorMessage(Client, "Pogresan ID.");
                    return;
                }

                Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_GROVE + "Kuca", "" + Main.EMBED_WHITE + "cena ulaza: $" + entrace.price.ToString("N0") + ". " + Main.EMBED_LIGHTRED + "postavljena.");

                Main.GivePlayerMoney(Client, entrace.price);

                // Entrce Name
                entrace.owner = -1;
                entrace.owner_name = "";
                entrace.locked = 1;
                entrace.safe = 0;

                for (int i = 0; i < 9; i++)
                {
                    entrace.key_acess[i] = "0";
                }



                

                UpdateHouseLabel(index);
                //
                SaveEntrace(index);

                return;
            }
            index++;
        }
    }


    [Command("zvoni")]
    public void CMD_campainha(Player Client)
    {
        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.exterior, 2.0f) && Client.Dimension == 0)
            {
                List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
                foreach (Player alvo in proxPlayers)
                {
                    alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " zvoni na vrata.");
                }

                foreach (Player alvo in NAPI.Pools.GetAllPlayers())
                {
                    if (alvo.GetData<dynamic>("status") == true && GetPlayerInHouse(alvo) == index)
                    {
                        alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " zvoni na vrata.");
                    }
                }
                return;
            }
            index++;
        }
        Main.SendErrorMessage(Client, "Morate biti tacno na ikonici kuce.");
    }

    [Command("parkiraj")]
    public void house_park(Player Client)
    {
        int index = 0;
        foreach (HouseEnum entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.exterior_garage, 4.0f) && Client.Dimension == 0)
            {

                if (entrace.owner != AccountManage.GetPlayerSQLID(Client))
                {
                    Main.SendErrorMessage(Client, "Niste kod garaze.");
                    return;
                }
                if (entrace.in_garage + 1 > entrace.garage_slot)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate mesta!");
                    return;
                }
                if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
                {
                    int playerid = Main.getIdFromClient(Client);
                    for (int i = 0; i < PlayerVehicle.MAX_PLAYER_VEHICLES; i++)
                    {
                        if (PlayerVehicle.vehicle_data[playerid].handle[i] == Client.Vehicle && PlayerVehicle.vehicle_data[playerid].state[i] == 1)
                        {

                            PlayerVehicle.vehicle_data[playerid].position[i] = Client.Vehicle.Position;
                            PlayerVehicle.vehicle_data[playerid].rotation[i] = Client.Vehicle.Heading;
                            PlayerVehicle.vehicle_data[playerid].state[i] = 4;
                            PlayerVehicle.vehicle_data[playerid].fuel[i] = Convert.ToInt32(Main.GetVehicleFuel(Client.Vehicle));
                            entrace.in_garage = entrace.in_garage++;
                            PlayerVehicle.SavePlayerVehicle(Client, i);
                            PlayerVehicle.vehicle_data[playerid].handle[i].Delete();
                            PlayerVehicle.vehicle_data[playerid].handle[i] = null;

                            return;
                        }
                    }
                }



                return;
            }
            index++;
        }
    }

    [Command("chgarage", "/chgarage [ID] [Slot Garage]")]
    public void CMD_chgarage(Player Client, int house_id, byte slot = 1)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 8)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }

        if (house_id >= HOUSES_CREATED)
        {
            Main.SendErrorMessage(Client, "Pogresan ID kuce.");
            return;
        }
        try
        {
            HouseInfo[house_id].exterior_garage = Client.Vehicle.Position;
            HouseInfo[house_id].exterior_garage_a = Client.Vehicle.Heading;
            HouseInfo[house_id].garage_slot = slot;
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Garaza ID: " + house_id + " | " + slot + "");
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " Garaza kreirana ID: " + house_id + " Slot: " + slot);
            SaveEntrace(house_id);
        }
        catch (Exception e)
        {
            NAPI.Util.ConsoleOutput("CreateGARAGE Err");
            Console.Write(e);

        }
    }

    public void CMD_ircasainterior(Player Client, int house_id)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) <= 4)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }

        if (house_id >= HOUSES_CREATED)
        {
            Main.SendErrorMessage(Client, "Taj ID kuce ne postoji!");
            return;
        }
        NAPI.Entity.SetEntityPosition(Client, HouseInfo[house_id].interior);
        Client.Rotation = new Vector3(0, 0, HouseInfo[house_id].interior_a);
        Client.SendNotification("Teleportovani ste u kucu ID: ~b~" + house_id + "~w~.");
    }

    [Command("createhouse", " /createhouse [0 = low class, 1 = middle class, 2 = class vip] (to add more types looks at the script in the command 'createhouse')")]
    public void CMD_criarcasa(Player Client, int type)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 8)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni ..");
            return;
        }

        int index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (entrace.exterior.X == 0 && entrace.exterior.Y == 0 && entrace.interior.X == 0 && entrace.interior.Y == 0)
            {
                Random rnd = new Random();
                if (type == 0)
                {
                    entrace.exterior = Client.Position;
                    entrace.exterior_a = Client.Rotation.Z;
                    entrace.interior = new Vector3(266.05, -1007.088, -100.9857);
                    entrace.interior_a = 357.678f;
                    entrace.sell_house = 1;

                    entrace.name = "Mala";
                    int random_price = rnd.Next(70000, 140000);
                    entrace.price = random_price;
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].garage_slot = 1;
                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }
                else if (type == 1)
                {
                    entrace.exterior = Client.Position;
                    entrace.exterior_a = Client.Rotation.Z;
                    entrace.interior = new Vector3(346.5961, -1002.541, -99.19624);
                    entrace.interior_a = 357.6783f;

                    int random_price = rnd.Next(150000, 200000);
                    entrace.price = random_price;
                    entrace.sell_house = 1;

                    HouseInfo[index].garage_slot = 2;
                    entrace.name = "Normal";
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }
                else if (type == 2)
                {
                    entrace.exterior = Client.Position;
                    entrace.exterior_a = Client.Rotation.Z;
                    entrace.interior = new Vector3(346.5961, -1002.541, -99.19624);
                    entrace.interior_a = 357.6783f;
                    entrace.sell_house = 1;

                    int random_price = rnd.Next(120000, 1500000);
                    entrace.price = random_price;
                    HouseInfo[index].garage_slot = 4;

                    entrace.name = "Srednja";
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }
                else if (type == 3)
                {
                    entrace.exterior = Client.Position;
                    entrace.exterior_a = Client.Rotation.Z;
                    entrace.interior = new Vector3(-890.54, -436.79, 121.60);
                    entrace.interior_a = 26.39f;
                    entrace.sell_house = 1;

                    int random_price = rnd.Next(120000, 1500000);
                    entrace.price = random_price;
                    HouseInfo[index].garage_slot = 6;

                    entrace.name = "Stan";
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }
                else if (type == 4)
                {
                    entrace.exterior = Client.Position;
                    entrace.exterior_a = Client.Rotation.Z;
                    entrace.interior = new Vector3(-682.2648, 592.4819, 145.3918);
                    entrace.interior_a = 218.7982f;
                    entrace.sell_house = 1;

                    int random_price = rnd.Next(1500000, 4500000);
                    entrace.price = random_price;
                    HouseInfo[index].garage_slot = 10;

                    entrace.name = "Kuca VIP";
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }
                else if (type == 5)
                {
                    entrace.exterior = Client.Position;
                    entrace.exterior_a = Client.Rotation.Z;
                    entrace.interior = new Vector3(151.34476, -1007.31714, -98.99999);
                    entrace.interior_a = 218.7982f;
                    entrace.sell_house = 1;

                    int random_price = rnd.Next(30000, 60000);
                    entrace.price = random_price;
                    HouseInfo[index].garage_slot = 0;

                    entrace.name = "Hotel";
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }
                else if (type == 6)
                {
                    entrace.exterior = Client.Position;
                    entrace.exterior_a = Client.Rotation.Z;
                    entrace.interior = new Vector3(-1289.8616, 449.28165, 97.90253);
                    entrace.interior_a = 218.7982f;
                    entrace.sell_house = 1;

                    int random_price = rnd.Next(3500000, 8500000);
                    entrace.price = random_price;
                    HouseInfo[index].garage_slot = 10;

                    entrace.name = "Lux";
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }
                else if (type == 7)
                {
                    entrace.exterior = Client.Position;
                    entrace.exterior_a = Client.Rotation.Z;
                    entrace.interior = new Vector3(366.185, 2573.594, 39.00456);
                    entrace.interior_a = -65.94129f;
                    entrace.sell_house = 1;

                    int random_price = rnd.Next(12500, 23000);
                    entrace.price = random_price;
                    HouseInfo[index].garage_slot = 0;

                    entrace.name = "Prikolica";
                    UpdateHouseLabel(index);
                    SaveEntrace(index);

                    HouseInfo[index].blip.Position = entrace.exterior;
                    HouseInfo[index].blip.Transparency = 255;
                }

                else Main.SendErrorMessage(Client, "Pogresna klasa !");

                return;

            }
            index++;
        }
    }


    [Command("edithouse")]
    public void CMD_editarcasa(Player Client, int entrace_id, string type)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) <= 6)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni ..");
            return;
        }

        if (entrace_id < 1 && entrace_id > MAX_ENTRACE)
        {
            Main.SendErrorMessage(Client, "Pogresan ID.");
            return;
        }
        GameLog.ELog(Client, GameLog.MyEnum.Admin, "/edithouse House_ID: " + entrace_id.ToString() + " Type: " + type.ToString());

        if (type == "name")
        {
            InteractMenu.User_Input(Client, "input_entrace_name", "Naziv ulaza", HouseInfo[entrace_id].name);
            Client.SetData<dynamic>("entrace_id", entrace_id);
        }
        else if (type == "exterior")
        {

            Main.SendCustomChatMessasge(Client, "Postavili ste izlaz iz kuce id " + entrace_id + " na Vasu trenutnu poziciju.");
            HouseInfo[entrace_id].exterior = Client.Position;
            HouseInfo[entrace_id].exterior_a = Client.Rotation.Z;
            HouseInfo[entrace_id].label.Position = Client.Position;

            UpdateHouseLabel(entrace_id);

            HouseInfo[entrace_id].blip.Position = HouseInfo[entrace_id].exterior;

            NAPI.Blip.SetBlipTransparency(HouseInfo[entrace_id].blip, 255);
            SaveEntrace(entrace_id);
        }
        else if (type == "interior")
        {
            Main.SendCustomChatMessasge(Client, "Promenili ste enterijer kuce " + entrace_id + " na Vasu trenutnu poziciju.");

            HouseInfo[entrace_id].interior = Client.Position;
            HouseInfo[entrace_id].interior_a = Client.Rotation.Z;
            HouseInfo[entrace_id].label_interior.Position = Client.Position;

            UpdateHouseLabel(entrace_id);
            SaveEntrace(entrace_id);
        }
        else if (type == "delete")
        {
            Main.SendCustomChatMessasge(Client, "Obrisali ste kucu ID " + entrace_id + ".");

            HouseInfo[entrace_id].blip.Transparency = 0;

            HouseInfo[entrace_id].name = "";
            HouseInfo[entrace_id].exterior = new Vector3(0, 0, 0);
            HouseInfo[entrace_id].interior = new Vector3(0, 0, 0);
            HouseInfo[entrace_id].exterior_a = 0;
            HouseInfo[entrace_id].interior_a = 0;
            HouseInfo[entrace_id].exterior_garage = new Vector3(0, 0, 0);
            HouseInfo[entrace_id].exterior_a = 0;
            HouseInfo[entrace_id].label.Position = new Vector3(0, 0, 0);
            HouseInfo[entrace_id].label_interior.Position = new Vector3(0, 0, 0);
            SaveEntrace(entrace_id);
        }
    }

    [Command("edithprice")]
    public void CMD_edithouseprice(Player Client, int entrace_id, int price)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) <= 6)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }

        if (entrace_id < 1 && entrace_id > MAX_ENTRACE)
        {
            Main.SendErrorMessage(Client, "Pogresan ID.");
            return;
        }
        GameLog.ELog(Client, GameLog.MyEnum.Admin, "/edithprice House_ID: " + entrace_id.ToString() + " Type: " + price.ToString());


        Main.SendCustomChatMessasge(Client, "Cena kuce je promenjena. Stara cena: ~g~" + price + "~w~ | Nova cena: ~g~" + price);
        HouseInfo[entrace_id].price = price;

        SaveEntrace(entrace_id);
        UpdateHouseLabel(entrace_id);

    }

    //
    // Inventory
    //
    public static void LoadInventoryItens(int house_id)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `inventory_house` WHERE `owner` = '" + HouseInfo[house_id].id + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                while (reader.Read())
                {
                    if (reader.GetInt32("amount") <= 0)
                    {
                        Main.CreateMySqlCommand("DELETE FROM `inventory_house` WHERE `id` = '" + reader.GetInt32("id") + "';");
                        continue;
                    }

                    SendItemFromSQLtoInventory(house_id, reader.GetInt32("id"), reader.GetInt32("type"), reader.GetInt32("amount"), reader.GetInt32("slotid"));
                }
            }
            Mainpipeline.Close();
        }
    }

    public static void SendItemFromSQLtoInventory(int house_id, int sql_id, int type, int amount = 1, int slotid = -1)
    {

        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (HouseInfo[house_id].inventory_index[index] == -1)
            {
                HouseInfo[house_id].inventory_index[index] = sql_id;
                HouseInfo[house_id].inventory_type[index] = type;
                HouseInfo[house_id].inventory_amount[index] = amount;
                HouseInfo[house_id].inventory_slotid[index] = slotid;

                return;
            }
        }
    }

    public static void GiveItemToInventory(int house_id, int type, int slotid, int amount = 1)
    {
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (HouseInfo[house_id].inventory_index[index] == -1)
            {
                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                {
                    try
                    {
                        Mainpipeline.Open();
                        string query = "INSERT INTO inventory_house (`owner`, `type`, `amount`)" + " VALUES ('" + house_id + "', '" + type + "', '" + amount + "')";
                        MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                        myCommand.ExecuteNonQuery();
                        long last_inventory_id = myCommand.LastInsertedId;

                        HouseInfo[house_id].inventory_index[index] = Convert.ToInt32(last_inventory_id);
                        HouseInfo[house_id].inventory_type[index] = type;
                        HouseInfo[house_id].inventory_amount[index] = amount;
                        HouseInfo[house_id].inventory_slotid[index] = slotid;
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
        if (HouseInfo[house_id].inventory_amount[index] >= 2)
        {
            GameLog.ELog(GameLog.MyEnum.Item, "RemoveItemFromInventory Type: " + index.ToString() + " Ammount: " + amount.ToString());

            HouseInfo[house_id].inventory_amount[index] -= amount;
            Main.CreateMySqlCommand("UPDATE inventory_house SET `amount` = " + HouseInfo[house_id].inventory_amount[index] + " WHERE `id` = " + HouseInfo[house_id].inventory_index[index] + "");

            if (HouseInfo[house_id].inventory_amount[index] < 1)
            {
                Main.CreateMySqlCommand("DELETE FROM `inventory_house` WHERE `id` = '" + HouseInfo[house_id].inventory_index[index] + "';");


                HouseInfo[house_id].inventory_index[index] = -1;
                HouseInfo[house_id].inventory_type[index] = 0;
                HouseInfo[house_id].inventory_amount[index] = 0;
                HouseInfo[house_id].inventory_slotid[index] = -1;
            }
        }
        else
        {
            Main.CreateMySqlCommand("DELETE FROM `inventory_house` WHERE `id` = '" + HouseInfo[house_id].inventory_index[index] + "';");

            HouseInfo[house_id].inventory_index[index] = -1;
            HouseInfo[house_id].inventory_type[index] = 0;
            HouseInfo[house_id].inventory_amount[index] = 0;
            HouseInfo[house_id].inventory_slotid[index] = -1;

        }
    }

    public static void ClearInventory(int house_id)
    {
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            HouseInfo[house_id].inventory_index[i] = -1;
            HouseInfo[house_id].inventory_type[i] = 0;
            HouseInfo[house_id].inventory_amount[i] = 0;
            HouseInfo[house_id].inventory_slotid[i] = -1;

        }

        Main.CreateMySqlCommand("DELETE FROM `inventory_house` WHERE `owner` = '" + house_id + "';");
    }

    public static void ResetInventoryVariables(int house_id)
    {
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            HouseInfo[house_id].inventory_index[i] = -1;
            HouseInfo[house_id].inventory_type[i] = 0;
            HouseInfo[house_id].inventory_amount[i] = 0;
            HouseInfo[house_id].inventory_slotid[i] = -1;

        }
    }


    public static int GetInventoryIndexFromSQLID(int house_id, int sqlid)
    {
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (HouseInfo[house_id].inventory_index[index] == sqlid)
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
            if (HouseInfo[house_id].inventory_type[index] == type)
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
            if (HouseInfo[house_id].inventory_type[index] == type)
            {
                amount = HouseInfo[house_id].inventory_amount[index];
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

    [Command("ram")]
    public void CMD_arrombarporta(Player Client)
    {
        if (AccountManage.GetPlayerGroup(Client) == 1)
        {

            int index = 0;
            foreach (var entrace in HouseInfo)
            {
                if (Main.IsInRangeOfPoint(Client.Position, entrace.exterior, 2.0f) && Client.Dimension == 0)
                {
                    UsefullyRP.SendRoleplayAction(Client, "razvaljuje vrata od kuce.");
                    entrace.locked = 0;
                    return;
                }
                index++;
            }
        }
    }

    [Command("safebox")]
    public static void ShowHouseInventory(Player Client)
    {

        int house_index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.interior, 70.0f) && Client.Dimension == 500 + (uint)house_index)
            {

                if (entrace.owner != AccountManage.GetPlayerSQLID(Client))
                {
                    Main.SendErrorMessage(Client, "Niste vlasnik kuce.");
                    return;
                }

                if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-1287.53, 456.084, 90.29856), 2.0f) || Main.IsInRangeOfPoint(Client.Position, new Vector3(259.8143, -1003.954, -99.00856), 2.0f) || Main.IsInRangeOfPoint(Client.Position, new Vector3(350.7189, -993.5916, -99.19617), 2.0f) || Main.IsInRangeOfPoint(Client.Position, new Vector3(-680.7666, 589.0926, 137.7698), 2.0f)|| Main.IsInRangeOfPoint(Client.Position, new Vector3(-898.49, -440.07, 121.61), 2.0f))
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
                            if (HouseInfo[house_index].inventory_index[index] != -1)
                            {

                                int type = HouseInfo[house_index].inventory_type[index];

                                if (type > Inventory.itens_available.Count)
                                {
                                    continue;
                                }


                                temp_storage_inventory.Add(new
                                {
                                    name = Inventory.itens_available[type].name,
                                    type = type,
                                    amount = HouseInfo[house_index].inventory_amount[index],
                                    sqlid = HouseInfo[house_index].inventory_index[index],
                                    slotid = HouseInfo[house_index].inventory_slotid[index],
                                    Useable = Inventory.itens_available[HouseInfo[house_index].inventory_type[index]].Useable,
                                    inuse = 0,
                                    dropable = 1,
                                    weight = Inventory.itens_available[type].weight,
                                    picture = "./img/" + Inventory.itens_available[type].picture + ".png"
                                });
                            }
                        }
                        NAPI.Task.Run(() =>
                        {
                            Client.TriggerEvent("Display_House_Storage", NAPI.Util.ToJson(temp_inventory), NAPI.Util.ToJson(temp_storage_inventory), Inventory.GetInventoryMaxHeight(Client), MAX_INVENTORY_WIGHT);
                        });

                    });

                }
                return;
            }
            house_index++;
        }
    }

    /*[Command("orgsafe")]
    public static void ShowOrgsafeInventory(Player Client)
    {

        int house_index = 0;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.interior, 30.0f))
            {

                if (entrace.owner != AccountManage.GetPlayerGroup(Client))
                {
                    Main.SendErrorMessage(Client, "Niste clan organizacije.");
                    return;
                }

                if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-18.45, -1438.63, 31.10), 2.0f) || Main.IsInRangeOfPoint(Client.Position, new Vector3(259.8143, -1003.954, -99.00856), 2.0f))
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
                            if (HouseInfo[house_index].inventory_index[index] != -1)
                            {

                                int type = HouseInfo[house_index].inventory_type[index];

                                if (type > Inventory.itens_available.Count)
                                {
                                    continue;
                                }


                                temp_storage_inventory.Add(new
                                {
                                    name = Inventory.itens_available[type].name,
                                    type = type,
                                    amount = HouseInfo[house_index].inventory_amount[index],
                                    sqlid = HouseInfo[house_index].inventory_index[index],
                                    slotid = HouseInfo[house_index].inventory_slotid[index],
                                    Useable = Inventory.itens_available[HouseInfo[house_index].inventory_type[index]].Useable,
                                    inuse = 0,
                                    dropable = 1,
                                    weight = Inventory.itens_available[type].weight,
                                    picture = "./img/" + Inventory.itens_available[type].picture + ".png"
                                });
                            }
                        }
                        NAPI.Task.Run(() =>
                        {
                            Client.TriggerEvent("Display_House_Storage", NAPI.Util.ToJson(temp_inventory), NAPI.Util.ToJson(temp_storage_inventory), Inventory.GetInventoryMaxHeight(Client), MAX_INVENTORY_WIGHT);
                        });

                    });

                }
                return;
            }
            house_index++;
        }
    }*/

    [RemoteEvent("House_Storage_Give_Item")]
    public static void UI_GiveItem(Player Client, int slot, int type, int amount, int sqlid)
    {

        int house_index = 0, house_id = -1;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.interior, 70.0f) && Client.Dimension == 500 + (uint)house_index)
            {
                if (entrace.owner == AccountManage.GetPlayerSQLID(Client))
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

            if (Check_InventoryWeight_With_ItemAmount(Client, house_id, type, amount))
            {
                return;
            }

            Inventory.RemoveItemFromInventory(Client, index, amount);
            GiveItemToInventory(house_id, type, slot, amount);

            ShowHouseInventory(Client);

            UsefullyRP.SendRoleplayAction(Client, "uzima " + Inventory.itens_available[type].name + "iz kucnog sefa.");



        }
        else if (Inventory.player_inventory[playerid].amount[index] == 1)
        {


            Inventory.RemoveItemFromInventory(Client, index, 1);
            GiveItemToInventory(house_id, type, slot, 1);

            ShowHouseInventory(Client);

            UsefullyRP.SendRoleplayAction(Client, "uzima " + Inventory.itens_available[type].name + "iz kucnog sefa.");


            return;
        }

    }

    [RemoteEvent("House_Storage_Take_Item")]
    public static void UI_TakeItem(Player Client, int slot, int type, int amount, int sqlid)
    {
        int house_index = 0, house_id = -1;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.interior, 70.0f) && Client.Dimension == 500 + (uint)house_index)
            {
                if (entrace.owner == AccountManage.GetPlayerSQLID(Client))
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

        int index = GetInventoryIndexFromSQLID(house_id, sqlid);

        int playerid = Main.getIdFromClient(Client);
        if (index == -1)
        {
            return;
        }
        if (HouseInfo[house_id].inventory_amount[index] > 1)
        {

            if (HouseInfo[house_id].inventory_amount[index] < 1)
            {
                return;
            }

            if (HouseInfo[house_id].inventory_amount[index] < amount)
            {
                Main.SendErrorMessage(Client, "Nemate toliko!");
                return;
            }

            if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, type, amount, Inventory.Max_Inventory_Weight(Client)))
            {
                return;
            }

            Inventory.GiveItemToInventory(Client, type, amount, slotid: slot);
            RemoveItemFromInventory(house_id, index, amount);

            ShowHouseInventory(Client);

            List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
            foreach (Player alvo in proxPlayers)
            {
                alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " uzima " + Inventory.itens_available[type].name + " iz kucnog sefa.");
            }

        }
        else if (HouseInfo[house_id].inventory_amount[index] == 1)
        {
            if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, type, 1, Inventory.Max_Inventory_Weight(Client)))
            {
                return;
            }


            Inventory.GiveItemToInventory(Client, type, 1, slotid: slot);

            RemoveItemFromInventory(house_id, index, 1);

            ShowHouseInventory(Client);

            List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
            foreach (Player alvo in proxPlayers)
            {
                alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " uzima " + Inventory.itens_available[type].name + " iz kucnog sefa.");
            }
            return;
        }

    }
    public static bool Check_InventoryWeight_With_ItemAmount(Player client, int houseid, int type, int amount)
    {
        float height = 0.00f;

        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (HouseInfo[houseid].inventory_index[index] != -1 && HouseInfo[houseid].inventory_amount[index] > 0)
            {
                height += HouseInfo[houseid].inventory_amount[index] * Inventory.itens_available[HouseInfo[houseid].inventory_type[index]].weight;

            }
        }

        if (type < Inventory.itens_available.Count && type != -1)
        {

            float free_space = MAX_INVENTORY_WIGHT - height;

            height += amount * Inventory.itens_available[type].weight;

            if (height > MAX_INVENTORY_WIGHT)
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate mesta!");
                //  Main.SendErrorMessage(Client, "Shoma Hajm Kafi Baraye Haml in Item Nadarid " + Main.EMBED_LIGHTRED + "" + (amount * itens_available[type].weight).ToString("#.##").Replace(",", ".") + "kg" + Main.EMBED_WHITE + ", Shoma Fghat Mitavanid " + Main.EMBED_LIGHTGREEN + "" + free_space.ToString("#.##").Replace(",", ".") + "kg" + Main.EMBED_WHITE + "Digar Haml Konid");
                return true;
            }
            return false;
        }
        else
        {
            return true;
        }

    }

    [RemoteEvent("House_InventorySplit")]
    public void SplitItem_Main(Player client, int sqlid)
    {
        Inventory.SplitItemGlobal(client, sqlid);
        ShowHouseInventory(client);
    }

    public static bool DoesHaveFreeSlot(int houseid)
    {
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            if (HouseInfo[houseid].inventory_amount[i] == 0 && HouseInfo[houseid].inventory_index[i] == -1)
            {
                return true;
            }
        }
        return false;
    }

    [RemoteEvent("House_SideInventorySplit")]
    public void House_SideInventorySplit(Player Client, int sqlid)
    {
        int house_index = 0, house_id = -1;
        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.interior, 70.0f) && Client.Dimension == 500 + (uint)house_index)
            {
                if (entrace.owner == AccountManage.GetPlayerSQLID(Client))
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

        if (HouseInfo[house_id].inventory_amount[index] >= 2)
        {
            if ((HouseInfo[house_id].inventory_amount[index] % 2) == 0)
            {
                GiveItemToInventory(house_id, HouseInfo[house_id].inventory_type[index], -1, HouseInfo[house_id].inventory_amount[index] / 2);
                HouseInfo[house_id].inventory_amount[index] = HouseInfo[house_id].inventory_amount[index] / 2;
                Main.CreateMySqlCommand("UPDATE `inventory_house` SET `amount`=" + HouseInfo[house_id].inventory_amount[index] + " WHERE `id`=" + HouseInfo[house_id].inventory_index[index] + "");
                ShowHouseInventory(Client);
            }
            else
            {
                decimal ammount = decimal.Parse(HouseInfo[house_id].inventory_amount[index].ToString()) / 2m;
                GiveItemToInventory(house_id, HouseInfo[house_id].inventory_type[index], -1, (int)Math.Ceiling(ammount));
                HouseInfo[house_id].inventory_amount[index] = (int)Math.Floor(ammount);
                ShowHouseInventory(Client);

                Main.CreateMySqlCommand("UPDATE `inventory_house` SET `amount`=" + (int)Math.Floor(ammount) + " WHERE `id`=" + HouseInfo[house_id].inventory_index[index] + "");
            }
        }
    }


    [RemoteEvent("House_InventoryChangeSlot")]
    public void House_InventoryChangeSlot(Player Client, int sqlid, int dataslot)
    {
        int house_index = 0;

        foreach (var entrace in HouseInfo)
        {
            if (Main.IsInRangeOfPoint(Client.Position, entrace.interior, 70.0f) && Client.Dimension == 500 + (uint)house_index)
            {
                if (entrace.owner == AccountManage.GetPlayerSQLID(Client))
                {
                    int index = GetInventoryIndexFromSQLID(house_index, sqlid);
                    if (index == -1)
                    {
                        return;
                    }
                    entrace.inventory_slotid[index] = dataslot;
                    Main.CreateMySqlCommand("UPDATE `inventory_house` SET `slotid` = " + dataslot + " WHERE `id` = " + entrace.inventory_index[index] + "");
                    return;
                }
            }
            house_index++;

        }

    }

    [RemoteEvent("House_InventoryStack")]
    public void House_InventoryStack(Player Client, int sqlold, int sqlnew)
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
            ShowHouseInventory(Client);
            return;
        }
        if (AccountManage.GetPlayerConnected(Client))
        {
            if (Inventory.player_inventory[playerid].sql_id[oldindex] == -1 || Inventory.player_inventory[playerid].inuse[oldindex] == 1 || Inventory.player_inventory[playerid].dropable[oldindex] == 0)
            {
                ShowHouseInventory(Client);
                Main.SendErrorMessage(Client, "Greska. (" + Inventory.player_inventory[playerid].sql_id[oldindex] + " - " + oldindex + " - " + Inventory.player_inventory[playerid].type[oldindex] + ")");
                return;
            }
            if (Inventory.player_inventory[playerid].sql_id[newindex] == -1 || Inventory.player_inventory[playerid].inuse[newindex] == 1 || Inventory.player_inventory[playerid].dropable[newindex] == 0)
            {
                ShowHouseInventory(Client);
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
                ShowHouseInventory(Client);

            }

        }
    }

    [RemoteEvent("House_SideInventoryStack")]
    public void House_SideInventoryStack(Player Client, int sqlnew, int sqlold)
    {
        if (AccountManage.GetPlayerConnected(Client))
        {


            int house_index = 0, house_id = -1;
            foreach (var entrace in HouseInfo)
            {
                if (Main.IsInRangeOfPoint(Client.Position, entrace.interior, 70.0f) && Client.Dimension == 500 + (uint)house_index)
                {
                    if (entrace.owner == AccountManage.GetPlayerSQLID(Client))
                    {
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
                ShowHouseInventory(Client);
                return;
            }
            if (HouseInfo[house_id].inventory_amount[oldindex] >= 1 && HouseInfo[house_id].inventory_amount[newindex] >= 1)
            {

                if (HouseInfo[house_id].inventory_type[newindex] != HouseInfo[house_id].inventory_type[oldindex] || HouseInfo[house_id].inventory_index[newindex] == HouseInfo[house_id].inventory_index[oldindex])
                {
                    ShowHouseInventory(Client);
                    return;
                }
                HouseInfo[house_id].inventory_amount[newindex] += HouseInfo[house_id].inventory_amount[oldindex];
                // NAPI.Data.SetEntityData(vehicle, "trunk_item_" + sqlnew + "_amount", NAPI.Data.GetEntityData(vehicle, "trunk_item_" + sqlnew + "_amount") + NAPI.Data.GetEntityData(vehicle, "trunk_item_" + sqlold + "_amount"));
                RemoveItemFromInventory(house_id, oldindex, 999);
                Main.CreateMySqlCommand("UPDATE `inventory_house` SET `amount` = " + HouseInfo[house_id].inventory_amount[newindex] + " WHERE `id` = " + HouseInfo[house_id].inventory_index[newindex] + "");
                ShowHouseInventory(Client);
                return;
            }
            else
            {
                ShowHouseInventory(Client);

            }
        }
    }

    [RemoteEvent("House_Client_ItemAction")]
    public static void Veh_Client_ItemAction(Player Client, int index, int amount)
    {
        try
        {
            if (index == -1)
            {
                Main.SendErrorMessage(Client, "Greska. (" + index + " - " + index + " -)");
                return;
            }
            int house_index = 0, house_id = -1;
            foreach (var entrace in HouseInfo)
            {
                if (Main.IsInRangeOfPoint(Client.Position, entrace.interior, 70.0f) && Client.Dimension == 500 + (uint)house_index)
                {
                    if (entrace.owner == AccountManage.GetPlayerSQLID(Client))
                    {
                        house_id = house_index;



                        if (entrace.inventory_amount[index] < 1)
                        {
                            return;
                        }
                        if (Inventory.itens_available[entrace.inventory_type[index]].guest != Inventory.ITEM_TYPE_Ammunation)
                        {
                            amount = 1;
                        }

                        Inventory.UseItemFromInventory(Client, index, amount, 3);
                        break;
                    }
                }
                house_index++;
            }

            return;


        }
        catch
        {

        }
    }
    [RemoteEvent("ExitFromHouse")]
    public void ExitFromHouse(Player player, int index)
    {
        player.Position = HouseInfo[index].exterior;
        player.Rotation.Z = HouseInfo[index].exterior_a;
        player.Dimension = 0;
    }
    [RemoteEvent("InspectHouse")]
    public void InspectHouse(Player player, int index)
    {
        player.Position = HouseInfo[index].interior;
        player.Rotation.Z = HouseInfo[index].interior_a;
        player.Dimension = (uint)(500 + index);
    }
    public static void OnExitColshapeHandler(Player player, ColShape shape)
    {
        if (player.HasData("HouseExitMenu") && player.GetData<dynamic>("HouseExitMenu") == true)
        {
            player.ResetData("HouseExitMenu");
            player.TriggerEvent("hidePoliceCivilMenu");
        }
        if (player.HasData("HouseBuyMenu") && player.GetData<dynamic>("HouseBuyMenu") == true)
        {
            player.ResetData("HouseBuyMenu");
            player.TriggerEvent("hidePoliceCivilMenu");

        }
    }

    public static void OnEnterColshapeHandler(Player player, ColShape shape)
    {
        int index = shape.GetData<dynamic>("index");
        switch (shape.GetData<string>("ColName"))
        {
            case "ext_House":
                {
                    if (HouseInfo[index].sell_house == 1)
                    {
                        player.TriggerEvent("ShowHouseBuyMenu", index, HouseInfo[index].price, HouseInfo[index].garage_slot);
                        player.SetData<dynamic>("HouseExitMenu", true);
                    }
                    break;
                }
            case "int_House":
                {
                    player.TriggerEvent("ShowHouseExitMenu", index, HouseInfo[index].owner_name, HouseInfo[index].garage_slot);
                    player.SetData<dynamic>("HouseBuyMenu", true);

                    break;
                }
            default:
                break;
        }
    }

    [RemoteEvent("house_KeyM")]
    public void house_KeyM(Player player)
    {
        if (!AccountManage.GetPlayerConnected(player))
        {
            return;
        }
        if (player.HasData("M_Timeout") && player.GetData<dynamic>("M_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
        {
            Main.DisplaySubtitle(player, "~y~[Antispam]", 2);
            return;
        }
        player.SetData<dynamic>("M_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 1000);
        foreach (var item in HouseInfo)
        {
            if (item.owner == AccountManage.GetPlayerSQLID(player))
            {
                if (item.exterior.DistanceTo(player.Position) < 6 || (item.interior.DistanceTo(player.Position) < 30 && player.Dimension == (HouseInfo.IndexOf(item) + 500)))
                {
                    player.TriggerEvent("HouseControlPanel", HouseInfo.IndexOf(item));
                    break;
                }
            }
        }
    }

    [RemoteEvent("house_lockhouse")]
    public void house_lockhouse(Player player, int index)
    {
        if (HouseInfo.ElementAtOrDefault(index) == null)
        {
            return;
        }
        if (HouseInfo[index].owner == AccountManage.GetPlayerSQLID(player))
        {
            if (HouseInfo[index].exterior.DistanceTo(player.Position) > 6 && (HouseInfo[index].interior.DistanceTo(player.Position) > 30))
            {
                player.TriggerEvent("hidePoliceCivilMenu");
                return;
            }
            if (HouseInfo[index].locked == 1)
            {
                HouseInfo[index].locked = 0;
                Main.SendMessageToPlayer(player, "~g~ Kuca otkljucana");
            }
            else
            {
                HouseInfo[index].locked = 1;
                Main.SendMessageToPlayer(player, "~r~ Kuca zakljucana");
            }
        }
    }

    [RemoteEvent("house_fastsale")]
    public void house_fastsale(Player player, int house_id)
    {
        if (HouseInfo.ElementAtOrDefault(house_id) == null)
        {
            return;
        }
        if (HouseInfo[house_id].owner == AccountManage.GetPlayerSQLID(player))
        {
            if (HouseInfo[house_id].exterior.DistanceTo(player.Position) > 6 && (HouseInfo[house_id].interior.DistanceTo(player.Position) > 30))
            {
                player.TriggerEvent("hidePoliceCivilMenu");
                return;
            }
            Main.SendMessageWithTagToPlayer(player, "" + Main.EMBED_GROVE + "Kuca", "Prodali ste kucu drzavi.");

            Main.GivePlayerMoneyBank(player, HouseInfo[house_id].price);

            // Entrce Name
            player.TriggerEvent("blip_remove", "myhouse_" + house_id + "");

            HouseInfo[house_id].owner = -1;
            HouseInfo[house_id].owner_name = "";
            HouseInfo[house_id].locked = 0;
            HouseInfo[house_id].safe = 0;
            HouseInfo[house_id].sell_house = 1;

            player.Position = HouseInfo[house_id].exterior;
            player.Dimension = 0;

            for (int i = 0; i < 9; i++)
            {
                HouseInfo[house_id].key_acess[i] = "0";
            }

            for (int id = 0; id < 60; id++)
            {
                if (HouseInfo[house_id].furniture_position[id].X != 0 && HouseInfo[house_id].furniture_position[id].Y != 0)
                {
                    Main.CreateMySqlCommand("DELETE FROM `furnitures` WHERE `id` = " + HouseInfo[house_id].furniture_id[id] + ";");

                    HouseInfo[house_id].furniture_id[id] = -1;
                    HouseInfo[house_id].furniture_name[id] = "";
                    HouseInfo[house_id].furniture_model_name[id] = "";
                    HouseInfo[house_id].furniture_model[id] = 0;
                    HouseInfo[house_id].furniture_price[id] = 0;
                    HouseInfo[house_id].furniture_status[id] = 0;

                    HouseInfo[house_id].furniture_position[id] = new Vector3(0, 0, 0);
                    HouseInfo[house_id].furniture_rotation[id] = new Vector3(0, 0, 0);
                    HouseInfo[house_id].furniture_handle[id].Delete();

                    HouseSystem.UpdateFurniture(house_id);
                }
            }

            HouseSystem.UpdateHouseLabel(house_id);
            //
            HouseSystem.SaveEntrace(house_id);
        }
    }

    [RemoteEvent("house_selltoplayer")]
    public void house_selltoplayer(Player player, int index)
    {
        if (HouseInfo.ElementAtOrDefault(index) == null)
        {
            return;
        }
        if (HouseInfo[index].owner == AccountManage.GetPlayerSQLID(player))
        {
            if (HouseInfo[index].exterior.DistanceTo(player.Position) > 6 && (HouseInfo[index].interior.DistanceTo(player.Position) > 30))
            {
                player.TriggerEvent("hidePoliceCivilMenu");
                return;
            }
            InteractMenu.User_Input(player, "house_sell_price", "Price", "", "", "number");

        }
    }

    [RemoteEvent("house_furniture")]
    public void house_furniture(Player player)
    {
        List<dynamic> furniture = new List<dynamic>();
        foreach (var item in furniture_data)
        {
            furniture.Add(new { price = item.price, name = item.name, picture = item.picture });
        }
        
        player.TriggerEvent("showfurnitureshop", NAPI.Util.ToJson(furniture), "BuyFurniture");

    }


    public static void DropItemFromHouse(Player Client, int index, string itemName, int amount)
    {
        int i = 0;
        if (index == -1)
        {
            Main.SendErrorMessage(Client, "Greska. (" + index + " - " + index + " -)");
            return;
        }
        foreach (var item in Inventory.itens_available)
        {
            if (item.name == itemName)
            {
                int house_index = 0, house_id = -1;
                foreach (var entrace in HouseInfo)
                {
                    if (Main.IsInRangeOfPoint(Client.Position, entrace.interior, 70.0f) && Client.Dimension == 500 + (uint)house_index)
                    {
                        if (entrace.owner == AccountManage.GetPlayerSQLID(Client))
                        {
                            house_id = house_index;
                            int playerid = Main.getIdFromClient(Client);
                            string unidade;
                            if (amount == 1) unidade = "x";
                            else unidade = "x";
                            var rnd = new Random();
                            if (item.id == 23)
                            {
                                if (entrace.inventory_amount[index] <= 1)
                                {
                                    Radio.RadioSystem.ToggleRadio(Client, false);
                                }
                            }

                            var xrnd = rnd.NextDouble();
                            var yrnd = rnd.NextDouble();
                            Inventory.inventory_objects.Add(new
                            {
                                item_type = entrace.inventory_type[index],
                                item_pos_x = Client.Position.X + xrnd,
                                item_pos_y = Client.Position.Y + yrnd,
                                item_pos_z = Client.Position.Z,

                                item_amount = amount,

                                item_object_handle = NAPI.Object.CreateObject(item.hash, new Vector3(Client.Position.X + xrnd, Client.Position.Y + yrnd, Client.Position.Z - Client.GetData<dynamic>("ToGround")), new Vector3(0, 0, 0), 0),
                                item_label_handle = NAPI.TextLabel.CreateTextLabel("" + item.name + " ~g~(" + amount + " " + unidade + ")~w~~n~ [ ~c~E~w~ ]", new Vector3(Client.Position.X + xrnd, Client.Position.Y + yrnd, Client.Position.Z - Client.GetData<dynamic>("ToGround") + yrnd), 7, 0.15f, 4, new Color(221, 255, 0, 255))
                            });

                            RemoveItemFromInventory(house_id, index, amount);
                            ShowHouseInventory(Client);
                            break;
                        }
                    }
                    house_index++;
                }



                return;
            }

            i++;
        }
    }

}

