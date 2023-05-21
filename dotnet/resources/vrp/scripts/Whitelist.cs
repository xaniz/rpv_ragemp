using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

class WhitelistManage:Script
{
    public WhitelistManage()
    {

    }

    /*[Command("whitelist")]
    public static void WhiteList(Player Client)
    {
        LoadWhiteList(Client);
    }*/

    public static void LoadWhiteList(Player Client)
    {
        List<dynamic> menu_item_list = new List<dynamic>();

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `users` WHERE `betaAcess` = 0 LIMIT 150;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                while (reader.Read())
                {

                    if (reader.GetString("socialclubname").Length != 0) menu_item_list.Add(new { Index = reader.GetInt32("id"), Name = reader.GetString("socialclubname"),  Email = reader.GetString("email") });

                }
            }
            Mainpipeline.Close();
        }

        Client.TriggerEvent("LoadWhiteList", API.Shared.ToJson(menu_item_list));
    }


    [RemoteEvent("Player_Whitelist_Aprove")]
    public static void Service_Track_Server(Player Client, int id)
    {
        
        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Stavljen na WL");
        Main.CreateMySqlCommand("UPDATE users SET betaAcess = 1 WHERE `id` = " + id + ";");
        LoadWhiteList(Client);
    }

    [RemoteEvent("Player_Whitelist_Remove")]
    public static void Service_Remove_Server(Player Client, int id)
    {
        
        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Sklonjen sa WL");
        Main.CreateMySqlCommand("DELETE FROM users WHERE `id` = " + id + ";");
        LoadWhiteList(Client);
    }
}

