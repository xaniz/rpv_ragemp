using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;


class AccountManage : Script
{

    public static async Task<DataTable> ReadQueryAsync(string query)
    {
        using (MySqlConnection MidbConexion = new MySqlConnection(Main.myConnectionString))
        {
            MidbConexion.OpenAsync();
            MySqlCommand miComando = new MySqlCommand()
            {
                Connection = MidbConexion,
                CommandText = String.Format(query)

            };
            DbDataReader reader = await miComando.ExecuteReaderAsync();
            DataTable result = new DataTable();
            result.Load(reader);
            return result;
        }
    }

    public static void SaveCharacter(Player Client)
    {

        if (GetPlayerConnected(Client))
        {

            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                try
                {
                    Mainpipeline.Open();
                    string query = "UPDATE characters SET age=@age,name = @name, money = @money, bank = @bank, salary = @salary, char_position_x = @char_position_x, char_position_y = @char_position_y, char_position_z = @char_position_z, char_rotation_z = @char_rotation_z, char_torso = @char_torso, char_undershirt = @char_undershirt, char_undershirt_texture = @char_undershirt_texture, char_leg = @char_leg, char_leg_texture = @char_leg_texture, char_feet = @char_feet, char_feet_texture = @char_feet_texture, char_shirt = @char_shirt, char_shirt_texture = @char_shirt_texture, char_mask = @char_mask, char_mask_texture = @char_mask_texture, ";
                    query = query + " `business_key` = @business_key, `group` = @group, `group_rank` = @group_rank, `job` = @job, `thirsty` = @thirsty, `hunger` = @hunger, `wanted` = @wanted, `prison` = @prison, `prison_cell` = @prison_cell, `prison_time` = @prison_time, `hospital` = @hospital, `death` = @death, `death_seconds` = death_seconds, `leader` = @leader, `level` = @level, `exp` = @exp, ";
                    query = query + "char_outfit = @char_outfit, char_outfit_duty = @char_outfit_duty, char_dimension = @char_dimension, inside_house = @inside_house, peixe_0 = @peixe_0, peixe_1 = @peixe_1, peixe_2 = @peixe_2, peixe_3 = @peixe_3, peixe_4 = @peixe_4, peixe_5 = @peixe_5, peixe_6 = @peixe_6, peixe_7 = @peixe_7, peixe_8 = @peixe_8, peixe_9 = @peixe_9, `ooc_prison_time` = @ooc_prison_time, `ooc_warning` = @ooc_warning, `exp_time` = @exp_time,";
                    query = query + "`char_armor` = @char_armor, `char_armor_texture` = @char_armor_texture, `car_lic` = @car_lic, `truck_lic` = @truck_lic, `moto_lic` = @moto_lic, `fly_lic` = @fly_lic, `fish_lic` = @fish_lic, `taxi_lic` = @taxi_lic, `gun_lic` = @gun_lic, ";
                    query = query + "`character_hats` = @character_hats, `character_hats_texture` = @character_hats_texture, `character_glasses` = @character_glasses, `character_glasses_texture` = @character_glasses_texture, `character_ears` = @character_ears, `character_ears_texture` = @character_ears_texture, `character_cellphone` = @character_cellphone, `helmet` = @helmet, `helmet_texture` = @helmet_texture, `character_rppoints`= @character_rppoints,salaryvalue=@salaryvalue ,character_WalkStyle=@character_WalkStyle, ";
                    query = query + "`character_watches` = @character_watches, `character_watches_texture` = @character_watches_texture, `character_bracelets` = @character_bracelets, `character_accessories` = @character_accessories, `character_accessories_texture` = @character_accessories_texture, `backpack` = @backpack, `character_vip` = @character_vip, `character_vip_expire` = @character_vip_expire, `character_vip_date` = @character_vip_date, `character_donator` = @character_donator, `character_credits` = @character_credits, `health` = @health, `colete` = @armor, `LastLogin` = @LastLogin, `character_vehicle_slots` = @character_vehicle_slots, `character_house_slots` = @character_house_slots, `character_cat` = @character_cat ";
                    query = query + ", `radio_freq` = @radio_freq";
                    query = query + " WHERE id = '" + Client.GetData<dynamic>("character_sqlid") + "'";
                    MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                    myCommand.Parameters.AddWithValue("@name", Client.GetData<dynamic>("character_name"));
                    myCommand.Parameters.AddWithValue("@money", Client.GetData<dynamic>("character_money"));
                    myCommand.Parameters.AddWithValue("@bank", Client.GetData<dynamic>("character_bank"));
                    myCommand.Parameters.AddWithValue("@salary", Client.GetData<dynamic>("PaydayTime"));

                    myCommand.Parameters.AddWithValue("@radio_freq", Client.GetSharedData<dynamic>("RadioFreq"));

                    myCommand.Parameters.AddWithValue("@salaryvalue", Client.GetData<dynamic>("character_SalaryValue"));

                    myCommand.Parameters.AddWithValue("@level", Client.GetData<dynamic>("character_level"));
                    myCommand.Parameters.AddWithValue("@exp", Client.GetData<dynamic>("character_exp"));
                    myCommand.Parameters.AddWithValue("@leader", Client.GetData<dynamic>("character_leader"));
                    myCommand.Parameters.AddWithValue("@group", Client.GetData<dynamic>("character_group"));
                    myCommand.Parameters.AddWithValue("@group_rank", Client.GetData<dynamic>("character_group_rank"));
                    myCommand.Parameters.AddWithValue("@job", Client.GetData<dynamic>("job"));
                    myCommand.Parameters.AddWithValue("@wanted", Client.GetSharedData<dynamic>("character_wanted_level"));
                    myCommand.Parameters.AddWithValue("@business_key", Client.GetData<dynamic>("character_business_key"));
                    myCommand.Parameters.AddWithValue("@hunger", "" + Client.GetData<dynamic>("Hunger") + "");
                    myCommand.Parameters.AddWithValue("@thirsty", "" + Client.GetData<dynamic>("Thirsty") + "");
                    myCommand.Parameters.AddWithValue("@hospital", Client.GetSharedData<dynamic>("character_hospital"));
                    myCommand.Parameters.AddWithValue("@death", Client.GetSharedData<dynamic>("Injured"));
                    myCommand.Parameters.AddWithValue("@death_seconds", Client.GetSharedData<dynamic>("InjuredTime"));
                    myCommand.Parameters.AddWithValue("@health", Client.Health);
                    myCommand.Parameters.AddWithValue("@armor", Client.Armor);
                    myCommand.Parameters.AddWithValue("@LastLogin", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@age", Client.GetData<dynamic>("character_age"));

                    myCommand.Parameters.AddWithValue("@prison", Client.GetData<dynamic>("character_prison"));
                    myCommand.Parameters.AddWithValue("@prison_cell", Client.GetData<dynamic>("character_prison_cell"));
                    myCommand.Parameters.AddWithValue("@prison_time", Client.GetData<dynamic>("character_prison_time"));
                    myCommand.Parameters.AddWithValue("@ooc_prison_time", Client.GetData<dynamic>("character_ooc_prison_time"));
                    myCommand.Parameters.AddWithValue("@ooc_warning", Client.GetData<dynamic>("character_ooc_warning"));
                    myCommand.Parameters.AddWithValue("@exp_time", Client.GetData<dynamic>("exp_time"));

                    myCommand.Parameters.AddWithValue("@character_vip", Client.GetData<dynamic>("character_vip"));
                    myCommand.Parameters.AddWithValue("@character_vip_expire", Client.GetData<dynamic>("character_vip_expire"));
                    myCommand.Parameters.AddWithValue("@character_vip_date", Client.GetData<dynamic>("character_vip_date"));
                    myCommand.Parameters.AddWithValue("@character_donator", Client.GetData<dynamic>("character_donator"));
                    myCommand.Parameters.AddWithValue("@character_credits", Client.GetData<dynamic>("character_credits"));
                    myCommand.Parameters.AddWithValue("@character_vehicle_slots", Client.GetData<dynamic>("character_vehicle_slots"));
                    myCommand.Parameters.AddWithValue("@character_house_slots", Client.GetData<dynamic>("character_house_slots"));
                    myCommand.Parameters.AddWithValue("@character_cat", Client.GetData<dynamic>("character_cat"));

                    if (Client.GetData<dynamic>("character_WalkStyle") == WalkingStyle.Normal) { myCommand.Parameters.AddWithValue("@character_WalkStyle", "Normal"); }
                    else { myCommand.Parameters.AddWithValue("@character_WalkStyle", Client.GetData<dynamic>("character_WalkStyle")); }

                    myCommand.Parameters.AddWithValue("@car_lic", Client.GetData<dynamic>("character_car_lic"));
                    myCommand.Parameters.AddWithValue("@truck_lic", Client.GetData<dynamic>("character_truck_lic"));
                    myCommand.Parameters.AddWithValue("@fly_lic", Client.GetData<dynamic>("character_fly_lic"));
                    myCommand.Parameters.AddWithValue("@fish_lic", Client.GetData<dynamic>("character_fish_lic"));
                    myCommand.Parameters.AddWithValue("@moto_lic", Client.GetData<dynamic>("character_moto_lic"));
                    myCommand.Parameters.AddWithValue("@taxi_lic", Client.GetData<dynamic>("character_taxi_lic"));
                    myCommand.Parameters.AddWithValue("@gun_lic", Client.GetData<dynamic>("character_gun_lic"));


                    for (int i = 0; i < 10; i++)
                    {
                        if (Client.GetData<dynamic>("peixe_" + i) == 255) myCommand.Parameters.AddWithValue("@peixe_" + i, -1);
                        else myCommand.Parameters.AddWithValue("@peixe_" + i, Client.GetData<dynamic>("peixe_" + i));
                    }

                    myCommand.Parameters.AddWithValue("@backpack", Client.GetData<dynamic>("character_backpack"));
                    myCommand.Parameters.AddWithValue("@character_rppoints", Client.GetData<dynamic>("character_rppoints"));


                    myCommand.Parameters.AddWithValue("@char_position_x", Client.Position.X.ToString());
                    myCommand.Parameters.AddWithValue("@char_position_y", Client.Position.Y.ToString());
                    myCommand.Parameters.AddWithValue("@char_position_z", Client.Position.Z.ToString());
                    myCommand.Parameters.AddWithValue("@char_rotation_z", Client.Rotation.Z.ToString());

                    myCommand.Parameters.AddWithValue("@char_torso", NAPI.Data.GetEntitySharedData(Client, "character_torso"));
                    myCommand.Parameters.AddWithValue("@char_undershirt", NAPI.Data.GetEntitySharedData(Client, "character_undershirt"));
                    myCommand.Parameters.AddWithValue("@char_undershirt_texture", NAPI.Data.GetEntitySharedData(Client, "character_undershirt_texture"));
                    myCommand.Parameters.AddWithValue("@char_leg", NAPI.Data.GetEntitySharedData(Client, "character_leg"));
                    myCommand.Parameters.AddWithValue("@char_leg_texture", NAPI.Data.GetEntitySharedData(Client, "character_leg_texture"));
                    myCommand.Parameters.AddWithValue("@char_feet", NAPI.Data.GetEntitySharedData(Client, "character_feet"));
                    myCommand.Parameters.AddWithValue("@char_feet_texture", NAPI.Data.GetEntitySharedData(Client, "character_feet_texture"));
                    myCommand.Parameters.AddWithValue("@char_shirt", NAPI.Data.GetEntitySharedData(Client, "character_shirt"));
                    myCommand.Parameters.AddWithValue("@char_shirt_texture", NAPI.Data.GetEntitySharedData(Client, "character_shirt_texture"));
                    myCommand.Parameters.AddWithValue("@char_mask", NAPI.Data.GetEntitySharedData(Client, "character_mask"));
                    myCommand.Parameters.AddWithValue("@char_mask_texture", NAPI.Data.GetEntitySharedData(Client, "character_mask_texture"));
                    myCommand.Parameters.AddWithValue("@char_armor", NAPI.Data.GetEntitySharedData(Client, "character_armor"));
                    myCommand.Parameters.AddWithValue("@char_armor_texture", NAPI.Data.GetEntitySharedData(Client, "character_armor_texture"));

                    myCommand.Parameters.AddWithValue("@character_hats", NAPI.Data.GetEntitySharedData(Client, "character_hats"));
                    myCommand.Parameters.AddWithValue("@character_hats_texture", NAPI.Data.GetEntitySharedData(Client, "character_hats_texture"));
                    myCommand.Parameters.AddWithValue("@character_glasses", NAPI.Data.GetEntitySharedData(Client, "character_glasses"));
                    myCommand.Parameters.AddWithValue("@character_glasses_texture", NAPI.Data.GetEntitySharedData(Client, "character_glasses_texture"));
                    myCommand.Parameters.AddWithValue("@character_ears", NAPI.Data.GetEntitySharedData(Client, "character_ears"));
                    myCommand.Parameters.AddWithValue("@character_ears_texture", NAPI.Data.GetEntitySharedData(Client, "character_ears_texture"));
                    myCommand.Parameters.AddWithValue("@character_watches", NAPI.Data.GetEntitySharedData(Client, "character_watches"));
                    myCommand.Parameters.AddWithValue("@character_watches_texture", NAPI.Data.GetEntitySharedData(Client, "character_watches_texture"));
                    myCommand.Parameters.AddWithValue("@character_bracelets", NAPI.Data.GetEntitySharedData(Client, "character_bracelets"));
                    myCommand.Parameters.AddWithValue("@character_bracelets_texutre", NAPI.Data.GetEntitySharedData(Client, "character_bracelets_texutre"));
                    myCommand.Parameters.AddWithValue("@character_accessories", NAPI.Data.GetEntitySharedData(Client, "character_accessories"));
                    myCommand.Parameters.AddWithValue("@character_accessories_texture", NAPI.Data.GetEntitySharedData(Client, "character_accessories_texture"));
                    myCommand.Parameters.AddWithValue("@helmet", NAPI.Data.GetEntitySharedData(Client, "character_helmet"));
                    myCommand.Parameters.AddWithValue("@helmet_texture", NAPI.Data.GetEntitySharedData(Client, "character_helmet_texture"));

                    myCommand.Parameters.AddWithValue("@char_outfit", Client.GetData<dynamic>("character_outfit"));
                    myCommand.Parameters.AddWithValue("@char_outfit_duty", Client.GetData<dynamic>("character_duty_outfit"));
                    myCommand.Parameters.AddWithValue("@char_dimension", Client.Dimension);
                    myCommand.Parameters.AddWithValue("@connected_seconds", Client.GetData<dynamic>("connected_seconds"));
                    myCommand.Parameters.AddWithValue("@character_cellphone", cellphoneSystem.GetPlayerNumber(Client));

                    if (Client.HasData("InsideHouse_ID"))
                    {
                        myCommand.Parameters.AddWithValue("@inside_house", Client.GetData<dynamic>("InsideHouse_ID"));
                    }
                    else myCommand.Parameters.AddWithValue("@inside_house", "null");

                    myCommand.ExecuteNonQuery();

                    Mainpipeline.Close();
                   
                }
                catch (Exception ex)
                {
                    NAPI.Util.ConsoleOutput("[EXCEPTION SaveAccount] " + ex.Message);
                }
            }

        }

    }


    [RemoteEvent("ClientPreviewCharacterID")]
    public static void ClientPreviewCharacterID(Player Client, int user)
    {
        
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `characters` WHERE `id` = '" + user + "' LIMIT 1;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                while (reader.Read())
                {
                    Client.SetData<dynamic>("character_sqlid", reader.GetInt32("id"));
                    Client.SetData<dynamic>("character_name", reader.GetString("name"));

                    Client.SetData<dynamic>("character_duty_outfit", reader.GetInt32("char_outfit_duty"));
                    Client.SetData<dynamic>("character_outfit", reader.GetInt32("char_outfit"));

                    Client.SetData<dynamic>("character_customization", reader.GetString("char"));


                    Client.TriggerEvent("csharp_UpdateName", Client.GetData<dynamic>("character_name"));

                    Client.TriggerEvent("csharp_LoadingCharacter");


                    //Client.SetSharedData(WalkingStyle.SharedData_Walkstyle, WalkingStyle.Normal);
                    Client.SetSharedData("character_torso", reader.GetInt32("char_torso"));
                    Client.SetSharedData("character_torso_texture", 0);
                    Client.SetSharedData("character_undershirt", reader.GetInt32("char_undershirt"));
                    Client.SetSharedData("character_undershirt_texture", reader.GetInt32("char_undershirt_texture"));
                    Client.SetSharedData("character_leg", reader.GetInt32("char_leg"));
                    Client.SetSharedData("character_leg_texture", reader.GetInt32("char_leg_texture"));
                    Client.SetSharedData("character_feet", reader.GetInt32("char_feet"));
                    Client.SetSharedData("character_feet_texture", reader.GetInt32("char_feet_texture"));
                    Client.SetSharedData("character_shirt", reader.GetInt32("char_shirt"));
                    Client.SetSharedData("character_shirt_texture", reader.GetInt32("char_shirt_texture"));
                    Client.SetSharedData("character_mask", reader.GetInt32("char_mask"));
                    Client.SetSharedData("character_mask_texture", reader.GetInt32("char_mask_texture"));
                    Client.SetSharedData("character_armor", reader.GetInt32("char_armor"));
                    Client.SetSharedData("character_armor_texture", reader.GetInt32("char_armor_texture"));

                    Client.SetSharedData("character_hats", reader.GetInt32("character_hats"));
                    Client.SetSharedData("character_hats_texture", reader.GetInt32("character_hats_texture"));
                    Client.SetSharedData("character_glasses", reader.GetInt32("character_glasses"));
                    Client.SetSharedData("character_glasses_texture", reader.GetInt32("character_glasses_texture"));
                    Client.SetSharedData("character_ears", reader.GetInt32("character_ears"));
                    Client.SetSharedData("character_ears_texture", reader.GetInt32("character_ears_texture"));
                    Client.SetSharedData("character_watches", reader.GetInt32("character_watches"));
                    Client.SetSharedData("character_watches_texture", reader.GetInt32("character_watches_texture"));
                    Client.SetSharedData("character_bracelets", reader.GetInt32("character_bracelets"));
                    Client.SetSharedData("character_bracelets_texutre", reader.GetInt32("character_bracelets_texutre"));
                    Client.SetSharedData("character_accessories", reader.GetInt32("character_accessories"));
                    Client.SetSharedData("character_accessories_texture", reader.GetInt32("character_accessories_texture"));

                    CharCreator.CharCreator.LoadCharacter(Client, Client.GetData<dynamic>("character_name"));
                    Main.UpdatePlayerClothes(Client);
                }
            }
            Mainpipeline.Close();
        }
    }

    public static async Task LoadCharacter(Player Client, int user)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `characters` WHERE `id` = '" + user + "' LIMIT 1;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                while (reader.Read())
                {
                    

                    Client.SetData<dynamic>("character_SalaryValue", reader.GetInt32("salaryvalue"));

                    Client.SetData<dynamic>("loggedin", reader.GetInt16("loggedin"));

                    Client.TriggerEvent("factionchange", reader.GetInt32("group"));

                    Client.SetSharedData("RadioFreq", reader.GetInt32("radio_freq"));
                    Client.SetSharedData("Radio_Status", false);

                    Client.SetData<dynamic>("character_sqlid", reader.GetInt32("id"));
                    Client.SetData<dynamic>("admin_pin", reader.GetInt32("apin"));
                    Client.SetSharedData("unknow_sqlid", reader.GetInt32("id"));
                    Client.SetData<dynamic>("character_name", reader.GetString("name"));
                    Client.SetData<dynamic>("character_money", reader.GetInt32("money"));
                    Client.SetData<dynamic>("character_bank", reader.GetInt32("bank"));
                    Client.SetData<dynamic>("PaydayTime", reader.GetInt32("salary"));
                    Client.SetData<dynamic>("character_level", reader.GetInt32("level"));
                    Client.SetData<dynamic>("character_exp", reader.GetInt32("exp"));
                    Client.SetData<dynamic>("character_leader", reader.GetInt32("leader"));
                    Client.SetData<dynamic>("character_group", reader.GetInt32("group"));
                    Client.SetData<dynamic>("character_group_rank", reader.GetInt32("group_rank"));
                    Client.SetData<dynamic>("job", reader.GetInt32("job"));
                    Client.SetSharedData("character_wanted_level", reader.GetInt32("wanted"));
                    Client.SetData<dynamic>("character_prison", reader.GetInt32("prison"));
                    Client.SetData<dynamic>("character_prison_cell", reader.GetInt32("prison_cell"));
                    Client.SetData<dynamic>("character_prison_time", reader.GetInt32("prison_time"));
                    Client.SetSharedData("character_hospital", reader.GetInt32("hospital"));
                    Client.SetSharedData("Injured", reader.GetInt32("death"));
                    Client.SetSharedData("InjuredTime", reader.GetInt32("death_seconds"));
                    Client.SetData<dynamic>("character_position_x", float.Parse(reader.GetString("char_position_x")));
                    Client.SetData<dynamic>("character_position_y", float.Parse(reader.GetString("char_position_y")));
                    Client.SetData<dynamic>("character_position_z", float.Parse(reader.GetString("char_position_z")));
                    Client.SetData<dynamic>("character_rotation_z", float.Parse(reader.GetString("char_rotation_z")));
                    Client.SetData<dynamic>("character_business_key", reader.GetInt32("business_key"));
                    Client.SetData<dynamic>("character_duty_outfit", reader.GetInt32("char_outfit_duty"));
                    Client.SetData<dynamic>("character_outfit", reader.GetInt32("char_outfit"));
                    Client.SetData<dynamic>("character_dimension", reader.GetInt32("char_dimension"));
                    Client.SetData<dynamic>("character_vip", reader.GetInt32("character_vip"));
                    Client.SetData<dynamic>("character_vip", reader.GetInt32("character_vip"));
                    Client.SetData<dynamic>("zadatakd", reader.GetInt32("zadatak"));

                    Client.SetData<dynamic>("character_credits", reader.GetInt32("character_credits"));
                    Client.SetData<dynamic>("jobskill", reader.GetInt32("pizzajob"));
                    NAPI.Data.SetEntityData(Client, "admin_level", reader.GetInt32("adminLevel"));
                    NAPI.Data.SetEntitySharedData(Client, "admin_level", reader.GetInt32("adminLevel"));
                    Client.SetData<dynamic>("character_vip_expire", reader.GetDateTime("character_vip_expire"));

                    Client.SetData<dynamic>("character_vip_date", reader.GetDateTime("character_vip_date"));

                    Client.SetData<dynamic>("character_last_login", reader.GetDateTime("LastLogin"));

                    Client.SetData<dynamic>("character_vehicle_slots", reader.GetInt32("character_vehicle_slots"));
                    Client.SetData<dynamic>("character_age", reader.GetInt32("age"));

                    Client.SetData<dynamic>("character_house_slots", reader.GetInt32("character_house_slots"));

                    Client.SetData<dynamic>("character_cat", reader.GetInt32("character_cat"));

                    Client.SetData<dynamic>("character_WalkStyle", reader.GetString("character_WalkStyle"));
                    Client.SetSharedData("character_WalkStyle", reader.GetString("character_WalkStyle"));
                    if (reader.GetString("character_WalkStyle") == "Normal")
                    {
                        Client.SetSharedData("character_WalkStyle", WalkingStyle.Normal);
                        Client.SetData<dynamic>("character_WalkStyle", WalkingStyle.Normal);
                    }
                    else
                    {
                        WalkingStyle.SetWalkStyle(Client, reader.GetString("character_WalkStyle"), true);
                    }

                    Client.SetData<dynamic>("character_createrchar", reader.GetDateTime("CreateCharacter"));


                    //"@timenow", DateTime.Now

                    Client.SetData<dynamic>("character_car_lic", reader.GetInt32("car_lic"));
                    Client.SetData<dynamic>("character_truck_lic", reader.GetInt32("truck_lic"));
                    Client.SetData<dynamic>("character_fly_lic", reader.GetInt32("fly_lic"));
                    Client.SetData<dynamic>("character_fish_lic", reader.GetInt32("fish_lic"));
                    Client.SetData<dynamic>("character_moto_lic", reader.GetInt32("moto_lic"));
                    Client.SetData<dynamic>("character_taxi_lic", reader.GetInt32("taxi_lic"));
                    Client.SetData<dynamic>("character_gun_lic", reader.GetInt32("gun_lic"));
                    Client.SetData<dynamic>("character_rppoints", reader.GetInt32("character_rppoints"));
                    Client.SetData("oglas", false);




                    Client.TriggerEvent("csharp_UpdateName", Client.GetData<dynamic>("character_name"));

                    for (int i = 0; i < 10; i++)
                    {
                        if (reader.GetInt32("peixe_" + i) == 255) Client.SetData<dynamic>("peixe_" + i, -1);
                        else Client.SetData<dynamic>("peixe_" + i, reader.GetInt32("peixe_" + i));
                    }


                    Client.SetData<dynamic>("character_backpack", reader.GetInt32("backpack"));

                    Client.SetData<dynamic>("inside_house", reader.GetString("inside_house"));

                    Client.SetData<dynamic>("character_ooc_prison_time", reader.GetInt32("ooc_prison_time"));
                    Client.SetData<dynamic>("character_ooc_warning", reader.GetInt32("ooc_warning"));
                    Client.SetData<dynamic>("exp_time", reader.GetInt32("exp_time"));

                    //
                    // Character
                    //
                    Client.SetData<dynamic>("character_customization", reader.GetString("char"));

                    Client.TriggerEvent("csharp_LoadingCharacter");

                    Client.SetSharedData("character_torso", reader.GetInt32("char_torso"));
                    Client.SetSharedData("character_torso_texture", 0);
                    Client.SetSharedData("character_undershirt", reader.GetInt32("char_undershirt"));
                    Client.SetSharedData("character_undershirt_texture", reader.GetInt32("char_undershirt_texture"));
                    Client.SetSharedData("character_leg", reader.GetInt32("char_leg"));
                    Client.SetSharedData("character_leg_texture", reader.GetInt32("char_leg_texture"));
                    Client.SetSharedData("character_feet", reader.GetInt32("char_feet"));
                    Client.SetSharedData("character_feet_texture", reader.GetInt32("char_feet_texture"));
                    Client.SetSharedData("character_shirt", reader.GetInt32("char_shirt"));
                    Client.SetSharedData("character_shirt_texture", reader.GetInt32("char_shirt_texture"));
                    Client.SetSharedData("character_mask", reader.GetInt32("char_mask"));
                    Client.SetSharedData("character_mask_texture", reader.GetInt32("char_mask_texture"));
                    Client.SetSharedData("character_armor", reader.GetInt32("char_armor"));
                    Client.SetSharedData("character_armor_texture", reader.GetInt32("char_armor_texture"));

                    Client.SetSharedData("character_hats", reader.GetInt32("character_hats"));
                    Client.SetSharedData("character_hats_texture", reader.GetInt32("character_hats_texture"));
                    Client.SetSharedData("character_glasses", reader.GetInt32("character_glasses"));
                    Client.SetSharedData("character_glasses_texture", reader.GetInt32("character_glasses_texture"));
                    Client.SetSharedData("character_ears", reader.GetInt32("character_ears"));
                    Client.SetSharedData("character_ears_texture", reader.GetInt32("character_ears_texture"));
                    Client.SetSharedData("character_watches", reader.GetInt32("character_watches"));
                    Client.SetSharedData("character_watches_texture", reader.GetInt32("character_watches_texture"));
                    Client.SetSharedData("character_bracelets", reader.GetInt32("character_bracelets"));
                    Client.SetSharedData("character_bracelets_texutre", reader.GetInt32("character_bracelets_texutre"));
                    Client.SetSharedData("character_helmet", reader.GetInt32("helmet"));
                    Client.SetSharedData("character_helmet_texture", reader.GetInt32("helmet_texture"));
                    Client.SetSharedData("character_accessories", reader.GetInt32("character_accessories"));
                    Client.SetSharedData("character_accessories_texture", reader.GetInt32("character_accessories_texture"));

                    Client.SetData<dynamic>("character_cellphone", reader.GetInt32("character_cellphone"));

                    Client.SetData<dynamic>("connected_seconds", reader.GetInt32("connected_seconds"));
                    
                    // Default Player data
                    Client.SetData<dynamic>("Hunger", float.Parse(reader.GetString("hunger")));
                    Client.SetData<dynamic>("Thirsty", float.Parse(reader.GetString("thirsty")));

                    NAPI.Player.SetPlayerHealth(Client, reader.GetInt32("health"));
                    Client.SetData<dynamic>("character_health", reader.GetInt32("health"));


                    Client.SetData<dynamic>("ThirstyTimer", 0);
                    Client.SetData<dynamic>("HungerTimer", 0);

                    Client.SetData<dynamic>("InColshape", null);

                    Client.SetData<dynamic>("LowHealthEffect", false);
                    for (int i = 0; i < 10; i++)
                    {
                        string[] temp_mysql_data = reader.GetString("shortcut_" + i).ToString().Split('|');

                        Client.SetData<dynamic>("animation_shortcut_dict_" + i, Convert.ToString(temp_mysql_data[0]));
                        Client.SetData<dynamic>("animation_shortcut_state_" + i, Convert.ToString(temp_mysql_data[1]));
                        Client.SetData<dynamic>("animation_shortcut_flag_" + i, Convert.ToInt32(temp_mysql_data[2]));
                    }
                    Client.SetSharedData("using_mask", false);
                    Client.SetSharedData("isadmininvicible", false);
                    Client.SetSharedData("character_level", Client.GetData<dynamic>("character_level"));
                    
                    ///Custom Data
                    SetItemInHandType(Client, InHandItemType.EmptyHand);
                    ///

                    NAPI.Data.SetEntityData(Client, "ON_WORK", false);
                    API.Shared.SetPlayerArmor(Client, reader.GetInt32("colete"));

                }
            }
            Mainpipeline.Close();
        }


        cellphoneSystem.LoadContacts(Client);

        CharCreator.CharCreator.LoadCharacter(Client, Client.GetData<dynamic>("character_name"));

        WeaponManage.LoadPlayerWeapons(Client);

        OnLoadCharacterData(Client);


    }

    public static void SetPlayerLeader(Player Client, int factionid)
    {
        NAPI.Data.SetEntityData(Client, "character_leader", factionid);
        return;
    }

    public static void SetPlayerGroup(Player Client, int factionid)
    {
        NAPI.Data.SetEntityData(Client, "character_group", factionid);
        return;
    }

    public static void SetPlayerRank(Player Client, int rankid)
    {
        NAPI.Data.SetEntityData(Client, "character_group_rank", rankid);
        return;
    }

    public static void SetPlayerJob(Player Client, int jobid)
    {
        NAPI.Data.SetEntityData(Client, "character_job", jobid);
        return;
    }
    public static int GetPlayerJob(Player Client)
    {
        return Client.GetData<dynamic>("character_job");
    }

    public static int GetPlayerLeader(Player Client)
    {
        return Client.GetData<dynamic>("character_leader");
    }

    public static int GetPlayerGroup(Player Client)
    {
        return Client.GetData<dynamic>("character_group");
    }

    public static int GetPlayerRank(Player Client)
    {
        return Client.GetData<dynamic>("character_group_rank");
    }

    public static string GetCharacterName(Player Client)
    {
        dynamic characterNameData = Client.GetData<dynamic>("character_name");
        if (characterNameData == null)
        {
            return string.Empty;
        }
        else
        {
            return characterNameData.Replace('_', ' ');
        }
    }

    public static string Format_Name(string name)
    {
        return name.Replace('_', ' ');
    }

    public static bool GetPlayerConnected(Player Client)
    {
        if (Client.HasData("status"))
        {
            return Client.GetData<dynamic>("status");
        }
        return false;
    }

    public static void OnLoadCharacterData(Player Client)
    {
        long time = 0;
        time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        
        Client.StopAnimation();
        Client.TriggerEvent("logged");
        Client.SetData<dynamic>("status", true);
        Client.SetSharedData("status", true);
        Client.SetData<dynamic>("ValidToTeleport", false);

        //Client.TriggerEvent("Version_Logo",true); 
        PlayerVehicle.LoadPlayerVehicles(Client);

        Client.TriggerEvent("ps_DestroyCamera");

        TurfWar.CreatezoneForPlayer(Client);
        Inventory.LoadPlayerInventoryItens(Client);
        Main.UpdateMoneyDisplay(Client);
        Main.UpdatePlayerClothes(Client);
        

        Client.TriggerEvent("freezeEx", true);
        Client.TriggerEvent("freeze", true);
        NAPI.Player.SetPlayerName(Client, Client.GetData<dynamic>("character_name") + " (" + Main.getIdFromClient(Client) + ")");


        bool show_menu = false;
        if (Client.GetData<dynamic>("firstJoinned") == true)
        {
            // cellphoneSystem.NewNumber(Client);
            Translation.FirstAccount_Logged(Client);
        }
        else
        {
            Client.TriggerEvent("freezeEx", true);
            Client.TriggerEvent("freeze", true);
            DateTime last_login = Client.GetData<dynamic>("character_last_login");

            NAPI.Entity.SetEntityPosition(Client, new Vector3(Client.GetData<dynamic>("character_position_x"), Client.GetData<dynamic>("character_position_y"), Client.GetData<dynamic>("character_position_z")));
            NAPI.Entity.SetEntityRotation(Client, new Vector3(0, 0, Client.GetData<dynamic>("character_rotation_z")));
            NAPI.Entity.SetEntityDimension(Client, (uint)Client.GetData<dynamic>("character_dimension"));

            Translation.Account_Logged(Client);

            if ((int)NAPI.Data.GetEntitySharedData(Client, "character_hospital") > 0)
            {
                
                Main.sendToHospital(Client, Client.GetSharedData<dynamic>("InjuredTime"), false);
            }
            else if (NAPI.Data.GetEntityData(Client, "character_prison") > 0)
            {
                Main.sendBackToPrison(Client);
            }
            else if (Client.GetData<dynamic>("character_ooc_prison_time") > 0)
            {
                adminCommands.SendBackToPrison(Client);
            }
            else
            {
                show_menu = true;
            }

        }

        if (GetPlayerAdmin(Client) >= 1)
        {
        //    Main.SendCustomChatMessasge(Client, "Shoma Ba Rank ~b~" + adminCommands.GetPlayerAdminRank(Client) + "~w~ Vared Shodid!");
            var players = NAPI.Pools.GetAllPlayers();
            foreach (var i in players)
            {
                if (i.GetData<dynamic>("status") == true && GetPlayerAdmin(i) > GetPlayerAdmin(Client) && Client != i)
                {
                    Main.SendCustomChatMessasge(i, "~r~" + adminCommands.GetPlayerAdminRank(Client) + " ~b~" + GetCharacterName(Client) + "~w~ se ulogovao na server.");
                }
            }
        }

        Client.TriggerEvent("loadCaptureBlips");
        TurfWar.UpdateZoneBlipForAll();
        UpdateBackpack(Client);

        Client.TriggerEvent("ps_DestroyCamera");
        NAPI.ClientEvent.TriggerClientEvent(Client, "update_hunger_display", (int)Client.GetData<dynamic>("Hunger"), (int)Client.GetData<dynamic>("Thirsty"));

        Client.TriggerEvent("moveSkyCamera", Client, "down");

        XMR.LoadRadiosXMR(Client);

        

        NAPI.Task.Run(() =>
        {
            time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            if (Client.Exists == false)
            {
                return;
            }
            TurfWar.UpdateZoneBlipForPlayer(Client);
            InteractMenu_New.Check_Player_ClientSide(Client);


            Client.TriggerEvent("freeze", false);
            Client.TriggerEvent("freezeEx", false);

            if (Client.GetSharedData<dynamic>("Injured") == 1)
            {
                NAPI.Player.PlayPlayerAnimation(Client, (int)(Main.AnimationFlags.Loop), "dead", "dead_d");

                Client.TriggerEvent("freeze", true);
                NAPI.Task.Run(() =>
                {
                    Client.TriggerEvent("freeze", true);
                    Client.TriggerEvent("freezeEx", true);
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(Main.AnimationFlags.Loop), "dead", "dead_d");

                }, delayTime: 1500);
                Client.SetSharedData("InjuredTime", 0);
                Client.TriggerEvent("InjuredSystem", 240 * 1000);
            }

            Client.TriggerEvent("showChat");

            Client.TriggerEvent("show_player_hud", true);
            //Client.TriggerEvent("show_radar");

            // Client.TriggerEvent("update_armor", Client.Armor);
            //  Client.TriggerEvent("update_credits", VIP.GetPlayerCredits(Client));

            if (cellphoneSystem.GetPlayerNumber(Client) != 0)
            {

                Client.TriggerEvent("initPhone");
                Client.TriggerEvent("setPhoneNumber", cellphoneSystem.GetPlayerNumber(Client));
            }

            Police.OnPlayerConnectLoadUnit(Client);
            Main.DisplayRadar(Client, true);
            Client.SetData<dynamic>("DisplayRadar", true);
            Jobmanager.getjobskillfromsql(Client);
            Main.CreateMySqlCommand("UPDATE characters SET loggedin=1 WHERE id='" + GetPlayerSQLID(Client) + "'");

            

            foreach (var item in HouseSystem.HouseInfo)
            {
                if (item.owner == AccountManage.GetPlayerSQLID(Client))
                {
                    int index = HouseSystem.HouseInfo.IndexOf(item);
                    Client.TriggerEvent("blip_create_ext", "myhouse_" + index + "", item.exterior, 5, 1f, 40, true, "My House");
                }
            }
            //NPC.SpawnNewPed(Client);
            NAPI.Player.SetPlayerHealth(Client, Client.GetData<dynamic>("character_health"));
        }, delayTime: 8500);
        Client.TriggerEvent("setResistStage", 0);


    }

    [RemoteEvent("NewMenuSelected")]
    public void NewMenuSelected(Player Client, int id, string name)
    {
        Client.TriggerEvent("freeze", true);
        Client.TriggerEvent("moveSkyCamera", Client, "up", 1, false);
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(Client))
            {
            Client.TriggerEvent("freeze", false);
          //  NAPI.Entity.SetEntityPosition(Client, Teleport_List[id].position);

            Client.TriggerEvent("moveSkyCamera", Client, "down");
            }
        }, delayTime: 4000);

    }

    public static void UpdateBackpack(Player Client)
    {
        if (Client.GetData<dynamic>("character_backpack") == 1)
        {
            // NAPI.Player.SetPlayerClothes(Client, 5, 1, 0);
            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_tool_jackham"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
        }
        else if (Client.GetData<dynamic>("character_backpack") == 2)
        {
            // NAPI.Player.SetPlayerClothes(Client, 5, 39, 0);
            NAPI.Player.SetPlayerClothes(Client, 5, 81, 0);
        }
        else if (Client.GetData<dynamic>("character_backpack") == 3)
        {
            NAPI.Player.SetPlayerClothes(Client, 5, 41, 0);
        }
        else NAPI.Player.SetPlayerClothes(Client, 5, 0, 0);

    }
    
    public static string BcryptPasswordHash(string data)
    {
        return BCrypt.Net.BCrypt.HashPassword(data);
    }
    public static async Task CreateAccount(Player Client, string password, string email,string invitedrefferal)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandType = CommandType.Text;
            query.CommandText = "SELECT * FROM `users` WHERE `socialclubname` = '" + Client.SocialClubName + "'";
            query.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query))
            {
                da.Fill(dt);
                int i = 0;
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    string query2 = "INSERT INTO users ( socialclubname, password, email, `FirstLogin`,serial,`invitedrefferal`,`refferal`) VALUES ( @socialclubname, @password, @email, @FirstLogin,@serial,@invitedrefferal,@refferal)";

                    MySqlCommand CreatNewAccount = new MySqlCommand(query2, Mainpipeline);


                    CreatNewAccount.Parameters.AddWithValue("@socialclubname", "" + Client.SocialClubName + "");
                    CreatNewAccount.Parameters.AddWithValue("@password", "" + BcryptPasswordHash(password));
                    CreatNewAccount.Parameters.AddWithValue("@email", "" + email + "");
                    CreatNewAccount.Parameters.AddWithValue("@FirstLogin", DateTime.Now);
                    CreatNewAccount.Parameters.AddWithValue("@serial", Client.Serial);
                    CreatNewAccount.Parameters.AddWithValue("@invitedrefferal", invitedrefferal);
                    CreatNewAccount.Parameters.AddWithValue("@refferal", adminCommands.updatereferal());

                    CreatNewAccount.ExecuteNonQuery();
                    //NAPI.ClientEvent.TriggerClientEvent(Client, "destroyLogin");
                    LoadAccount(Client, Client.SocialClubName);
                    NAPI.ClientEvent.TriggerClientEvent(Client, "clearLoginWindow");
                }
                else
                {
                    Client.SendNotification("Greska!~n~Doslo je do greske prilikom registracije.");
                }
            }
            Mainpipeline.Close();
        }

    }

    public static async Task LoadAccount(Player Client, string user)
    {

        Utils.ClearChat(Client);
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT isban,betaAcess,id,email,socialclubname,banreason,bannedby,logged,refferal FROM `users` WHERE `socialclubname` = '" + Client.SocialClubName + "' ", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;

                while (reader.Read())
                {
                    if (reader.GetInt32("betaAcess") == 2)
                    {
                        Client.TriggerEvent("destroyBrowser");
                        //InteractMenu.ShowModal(Client, "WHITE_LIST_RESPONSE", "Whitelist", "Server je u Closed Beta Testu i zahteva whitelist<br><br>Mozete aplicirati", "Apliciraj", "Ne, hvala ; /"); //wlovde

                        Client.TriggerEvent("Display_Whitelist_Screen");
                        Client.Kick();
                        return;
                    }
                    if (reader.GetByte("logged") == 1)
                    {
                        //InteractMenu.ShowModal(Client, "WHITE_LIST_RESPONSE", "Whitelist", "Vas nalog nije whitelistovan za Closed Beta Test", "Dodjite na open :)", "Posetite nas Diskord");//wlovde

                        Client.TriggerEvent("displayerror", 6);

                        Main.SendCustomChatMessasge(Client, "Ulogovani ste.");
                        Client.SendNotification("Uzivajte u igri.");
                        //Client.TriggerEvent("Display_Whitelist_Screen");
                        // Client.Kick();
                        return;
                    }

                    if (reader.GetInt32("isban") == 1) { Main.SendCustomChatMessasge(Client, "[!{#F44747}BANOVANI STE~w~] " + "Account: " + reader.GetString("socialclubname") + "\n Razlog: " + reader.GetString("banreason") + " \n Admin: " + reader.GetString("bannedby") + ""); Client.Kick(); return; }


                    NAPI.Data.SetEntityData(Client, "player_sqlid", reader.GetInt32("id"));
                    //NAPI.Data.SetEntityData(Client.Handle, "player_username", reader.GetString("username"));
                    NAPI.Data.SetEntityData(Client, "player_email", reader.GetString("email"));
                    NAPI.Data.SetEntityData(Client, "refferal", reader.GetString("refferal"));


                    CharacterSelection(Client);
                    //LoadCharacter(Client, "Mike_Bishop");
                }
                // Main.CreateMySqlCommand("UPDATE `users` SET `logged`=1 WHERE socialclubname=" + Client.SocialClubName + ";");
                Main.CreateMySqlCommand("UPDATE `users` SET `logged` = '1' WHERE socialclubname = '" + Client.SocialClubName + "';");


            }
            Mainpipeline.Close();

        }
    }

    public static async Task CharacterSelection(Player Client)
    {
        Client.TriggerEvent("freeze", true);
        Client.TriggerEvent("freezeEx", true);
        Random rnd = new Random();
        uint random_world = Convert.ToUInt32(rnd.Next(5, 500));

        NAPI.Entity.SetEntityDimension(Client, random_world);

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT level,id,name,money,bank,exp FROM `characters` WHERE `userid` = '" + NAPI.Data.GetEntityData(Client, "player_sqlid") + "'", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                ArrayList chars = new ArrayList();
                List<dynamic> menu_item_list = new List<dynamic>();
                int characters = 0;

                while (reader.Read())
                {
                    if (characters == 0)
                    {
                        ClientPreviewCharacterID(Client, reader.GetInt32("id"));
                    }
                    int new_level = (50 * (reader.GetInt32("level")) * (reader.GetInt32("level")) * (reader.GetInt32("level")) - 150 * (reader.GetInt32("level")) * (reader.GetInt32("level")) + 600 * (reader.GetInt32("level"))) / 5;

                    menu_item_list.Add(new { ID = reader.GetInt32("id"), Name = reader.GetString("name"), Money = reader.GetInt32("money"), Bank = reader.GetInt32("bank"), Level = reader.GetInt32("level"), Exp = reader.GetInt32("exp"), Exp_Max = new_level });

                    characters += 1;
                }

                Client.TriggerEvent("Display_Characters", NAPI.Util.ToJson(menu_item_list));
                Client.Dimension = random_world;

                NAPI.Entity.SetEntityPosition(Client, new Vector3(711.27, 1197.76, 348.53));
                Client.Rotation = new Vector3(0, 0, -29.00);

                NAPI.Task.Run(() =>
                {
                    Client.TriggerEvent("Show_Cursor");
                }, delayTime: 500);
            }
            Mainpipeline.Close();
        }

    }

    [RemoteEvent("SelectCharacter")]
    public static async Task SelectCharacter(Player Client, int character_id)
    {

        if (Client.HasData("waitLogando"))
        {
            Client.SendNotification("Odabir karaktera.");
            return;
        }
        /* if (Main.g_mysql_get_VIP_status(Client) == false && Main.g_mysql_get_characters_created(Client) >= 2 && Main.g_mysql_get_Last_Character_id(Client) == character_id)
        {
            Client.SendNotification("Error! ~n~~g~VIP ~w~ Niste VIP.");
            return;
        }
         if (QSystem.IsQuestPasssed(Client) == false)
          {
              Client.TriggerEvent("Destroy_Character_Menu");
              Client.TriggerEvent("freezeEx", true);
              Client.TriggerEvent("freeze", true);
              QSystem.ShowQuestMenu(Client);
              Client.SendNotification("You Must Passed The Exam to Be Able Play On this Server");
              return;
          }*/
        Client.SetData<dynamic>("waitLogando", true);

        Client.TriggerEvent("Destroy_Character_Menu");
        //Client.TriggerEvent("screenFadeOut", 2000);

        Client.TriggerEvent("moveSkyCamera", Client, "up", 1, false);
        Client.TriggerEvent("freeze", true);
        Client.TriggerEvent("freezeEx", true);
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(Client))
            {
            Client.TriggerEvent("freezeEx", true);
            Client.TriggerEvent("freeze", true);
            LoadCharacter(Client, character_id);
            Client.ResetData("waitLogando");
            }
        }, delayTime: 5000);

    }


    [RemoteEvent("CreateCharacter")]
    public static void CreateCharacter(Player Client)
    {
        if (Main.g_mysql_get_characters_created(Client) >= 2 && Main.g_mysql_get_VIP_status(Client) == true)
        {
            Client.SendNotification("Greska! ~n~Ne mozete imati vise od 2 karaktera.");
            return;
        }
        if (Main.g_mysql_get_characters_created(Client) >= 1 && Main.g_mysql_get_VIP_status(Client) == false)
        {
            Client.SendNotification("Greska! ~n~Ne mozete imati vise od 1 karaktera (VIP moze imati 2 karaktera).");
            return;
            //CharacterSelection(Client);
        }
        else
        {
            Client.TriggerEvent("freezeEx", true);
            Client.TriggerEvent("freeze", true);
            Client.TriggerEvent("Destroy_Character_Menu");
            Client.TriggerEvent("ps_BodyCamera");
            CharCreator.CharCreator.SendToCreator(Client);
        }
    }


    public static int GetPlayerUserSQLID(Player Client)
    {
        return Client.GetData<dynamic>("player_sqlid");
    }
    public static int GetPlayerSQLID(Player Client)
    {
        return Client.GetData<dynamic>("character_sqlid");
    }


    public static string GetPlayerNameFromSQL(int sqlid)
    {

        var players = NAPI.Pools.GetAllPlayers();
        foreach (var pl in players)
        {
            if (pl.GetData<dynamic>("status") == true)
            {
                if (NAPI.Data.GetEntityData(pl, "character_sqlid") == sqlid)
                {
                    return NAPI.Data.GetEntityData(pl, "character_name");
                }
            }
        }
        return null;
    }

    public static int GetPlayerAdmin(Player Client)
    {
        if (Client.HasData("admin_level"))
        {
            return NAPI.Data.GetEntityData(Client, "admin_level");
        }
        return 0;
    }

    public static int IsAdminOnDuty(Player Client)
    {
        if (Client.HasData("admin_duty"))
        {
            return NAPI.Data.GetEntityData(Client, "admin_duty");
        }
        return 0;
    }

    public static void SetPlayerAdmin(Player Client, int level)
    {
        NAPI.Data.SetEntityData(Client, "admin_level", level);
        NAPI.Data.SetEntitySharedData(Client, "admin_level", level);

    }

    public static void SetPlayerHunger(Player Client, float hunger)
    {
        Client.SetData<dynamic>("Hunger", Client.GetData<dynamic>("Hunger") + hunger);
        if (Client.GetData<dynamic>("Hunger") > 100)
        {
            Client.SetData<dynamic>("Hunger", 100);
        }
        NAPI.ClientEvent.TriggerClientEvent(Client, "update_hunger_display", (int)Client.GetData<dynamic>("Hunger"), (int)Client.GetData<dynamic>("Thirsty"));
    }

    public static float GetPlayerHunger(Player Client)
    {
        return Client.GetData<dynamic>("Hunger");
    }

    public static float GetPlayerThirsty(Player Client)
    {
        return Client.GetData<dynamic>("Thirsty");
    }

    public static void SetPlayerThirsty(Player Client, float thirsty)
    {
        Client.SetData<dynamic>("Thirsty", Client.GetData<dynamic>("Thirsty") + thirsty);
        if (Client.GetData<dynamic>("Thirsty") > 100)
        {
            Client.SetData<dynamic>("Thirsty", 100);
        }
        NAPI.ClientEvent.TriggerClientEvent(Client, "update_hunger_display", (int)Client.GetData<dynamic>("Hunger"), (int)Client.GetData<dynamic>("Thirsty"));
    }
    
    public static bool CheckRefferal(string refferal)
    {
        var index = 0;
        int Refferalerguymoney = 20000;
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT `refferal` FROM `users` WHERE `refferal` = '" + refferal + "'", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    index++;
                    foreach (var item in NAPI.Pools.GetAllPlayers())
                    {
                        if (AccountManage.GetPlayerConnected(item))
                        {
                            if (item.GetData<string>("refferal") == refferal)
                            {
                                Main.SendMessageToPlayer(item, "[~g~Refferal~w~]Dobili ste ~g~$"+ Refferalerguymoney + "~w~ i VIP status +2 dana posto se neko registrovao sa Vasim Refferal kodom!");
                                Main.GivePlayerMoneyBank(item, Refferalerguymoney);
                                adminCommands.CMD_setvipref(item, 1, 2);
                                return true;
                            }
                        }
                    }
                    Main.CreateMySqlCommand("UPDATE `characters` SET `bank`=`bank`+"+ Refferalerguymoney + " WHERE `userid`=(SELECT ‍‍`id`,refferal FROM `users` WHERE refferal='"+refferal+"') LIMIT 1");
                    return true;
                }
            }
            Mainpipeline.Close();
        }
        if (index == 0)
        {
            return true;
        }
        else return false;
    }

    public enum InHandItemType
    {
        EmptyHand = 0,
        Farm_WheatBox = 1,
    }

    public static InHandItemType GetItemInHandType(Player Client)
    {
        return Client.GetData<InHandItemType>("ItemInHandType");
    }

    public static void SetItemInHandType(Player Client, InHandItemType bol)
    {
        Client.SetData<InHandItemType>("ItemInHandType", bol);
    }

    public static void CarryItem(Player Client, bool bol)
    {
        Client.GiveWeapon(WeaponHash.Unarmed, 0);
        Client.TriggerEvent("CarryItem", bol);
    }

    public static bool CheckIfinvitedrefferal(Player player)
    {

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT `invitedrefferal` FROM `users` WHERE `socialclubname` = '" + player.SocialClubName + "'", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetString("invitedrefferal") == "0")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            Mainpipeline.Close();
        }
        return false;
    }

    public static bool CheckEmailExist(string email)
    {
        var index = 0;

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT `email` FROM `users` WHERE `email` = '" + email + "'", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    index++;
                }
            }
            Mainpipeline.Close();
        }
        if (index == 0)
        {
            return true;
        }
        else return false;
    }


    //
    //
    //


    //1 - Tester // 2 - Game helper // 3 - Game Admin I // 4 - Game Admin II // 5 - Game Admin III // 6 - Lead Admin // 7 - Diretor // 8 - Coordenador // 9 - Developer // 10 - Management


}