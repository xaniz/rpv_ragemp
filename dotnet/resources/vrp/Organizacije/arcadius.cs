using GTANetworkAPI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using MySql.Data.MySqlClient;

public class arcadius : Script
{

    [ServerEvent(Event.ResourceStart)]
    public static void OnRentStart()
    {
        NAPI.Marker.CreateMarker(30, new Vector3(-117.26, -604.52, 36.28), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));
        NAPI.Marker.CreateMarker(30, new Vector3(-140.38, -621.02, 168.82), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155), false, 0);
        NAPI.Marker.CreateMarker(29, new Vector3(-128.13, -641.90, 168.32), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155), false, 0);
        NAPI.TextLabel.CreateTextLabel(" KOMPANIJA ~n~podigni novac~n~ ~g~", new Vector3(-128.13, -641.90, 168.72 + 0.3), 12, 0.1200f, 0, new Color(221, 255, 0, 255), false, 0);
    }

    public static void keypressE(Player client)
    {
        if(Main.IsInRangeOfPoint(client.Position, new Vector3(-117.26, -604.52, 36.28), 3.0f))
        {
            client.Position = new Vector3(-140.38, -621.02, 168.82);
            return;
        }
        if(Main.IsInRangeOfPoint(client.Position, new Vector3(-140.38, -621.02, 168.82), 3.0f) && client.Dimension == 0)
        {
            client.Position = new Vector3(-117.26, -604.52, 36.28);
            return;
        }
    }

    public static void keypressY(Player client)
    {
        if (client.Dimension != 0) return;
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandText = ("SELECT `money` FROM `companies` WHERE `owner` = '" + client.GetData<dynamic>("character_sqlid") + "';");
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                if (reader.Read())
                {
                    int money = reader.GetInt32("money");
                    client.SetData("bizmoney", money);
                }
                else
                {
                    Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate biznis");
                    return;
                }
            }
            Mainpipeline.Close();
        }
        int totmoney = client.GetData<dynamic>("bizmoney");
        //client.TriggerEvent("UpdateBusinessBalance", totmoney);
        client.TriggerEvent("Display_newbbank", totmoney);
        
        return;
    }

    [RemoteEvent("bBankWithdrawMoney")]
    public static void bBankWithdrawMoney(Player Client, int amount)
    {
        int value = Convert.ToInt32(amount);

        if (value < 1 || value > 1000000)
        {
            Client.SendNotification("~r~Greska~n~~w~Iznos mora biti izmedju 1 i 1,000,000.");
            return;
        }
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandText = ("SELECT `money` FROM `companies` WHERE `owner` = '" + Client.GetData<dynamic>("character_sqlid") + "';");
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                if (reader.Read())
                {
                    int money = reader.GetInt32("money");
                    Client.SetData("bizmoney", money);
                }
                else
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate biznis");
                    return;
                }
            }
            Mainpipeline.Close();
        }
        int totmoney = Client.GetData<dynamic>("bizmoney");
        if (Client.GetData<dynamic>("bizmoney") < value)
        {
            Client.SendNotification("~r~Greska~n~~w~Nemate toliko novca!");
            return;
        }
        
        double totalmoney = value * 0.20;
        int rounded = (int)Math.Round(totalmoney, 0);
        Main.GivePlayerMoneyBank(Client, value - rounded);
        int remain = totmoney - value;
        setbizmoney(Client, remain);
        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Prebacili ste "+ value.ToString("N0") + " sa racuna kompanije na sopstveni racuni i platili porez " + rounded + "");
    }

    [Command("setbusiness")]
    public static void CMD_setbusiness(Player sender, string playerID, int businessID)
    {
        if (sender.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(sender, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(sender) < 7)
        {
            Main.SendErrorMessage(sender, "Niste ovlasceni");
            return;
        }
        Player igrac = Main.findPlayer(sender, playerID);
        int sqid = igrac.GetData<dynamic>("character_sqlid");

        if (igrac != null)
        {
            Main.CreateMySqlCommand("UPDATE `companies` SET `owner_name` = '" + AccountManage.GetCharacterName(igrac) + "', `owner` = " + sqid + " WHERE `id` = " + businessID + ";");
            sender.SendNotification($"Setali ste biznis ID {businessID} igracu {playerID}");
            GameLog.ELog(sender, GameLog.MyEnum.Admin, " je /setbusiness igracu " + AccountManage.GetCharacterName(igrac) + " biznis: " + businessID +"");
        }

    }

    [Command("setbizmoney")]
    public static void CMD_setbizmoney(Player sender, int businessID)
    {
        if (sender.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(sender, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(sender) < 7)
        {
            Main.SendErrorMessage(sender, "Niste ovlasceni");
            return;
        }

            Main.CreateMySqlCommand("UPDATE `companies` SET `money` = 0 WHERE `id` = '" + businessID + "';");
            sender.SendNotification($"Setali ste novac biznisa {businessID} na 0");
            GameLog.ELog(sender, GameLog.MyEnum.Admin, " je /setbizmoney na 0 biz ID: " + businessID + "");

    }

    public static void setbizmoney(Player sender, int amount)
    {
        Main.CreateMySqlCommand("UPDATE `companies` SET `money` = '" + amount + "' WHERE `owner` = '" + sender.GetData<dynamic>("character_sqlid") + "';");
    }

    

}