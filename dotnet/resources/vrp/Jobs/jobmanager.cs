using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Threading;
using MySql.Data.MySqlClient;

public class Jobmanager:Script
{
    public Jobmanager()
    {
    NAPI.TextLabel.CreateTextLabel("Poslovi~w~~n~[~g~ Y ~w~] ", new Vector3(-553.95, -191.49, 38.21), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
    NAPI.TextLabel.CreateTextLabel("Dozvola za pecanje~w~~n~[~g~ Y ~w~] ", new Vector3(-551.11, -189.87, 38.21), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
    
    Entity temp_blip;
    temp_blip = NAPI.Blip.CreateBlip(new Vector3(-553.13, -188.82, 38.21));
    NAPI.Blip.SetBlipName(temp_blip, "Opstina");
    NAPI.Blip.SetBlipSprite(temp_blip, 525);
    NAPI.Blip.SetBlipColor(temp_blip, 38);
    NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
    NAPI.Blip.SetBlipShortRange(temp_blip, true);
    }

    [RemoteEvent("opstinajobs")]
    public static void opstinajobs(Player player, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Dali ste otkaz");
                        setjob(player, 0);
                        Trigger.ClientEvent(player, "deleteCheckpoint", 15);
                        Trigger.ClientEvent(player, "deleteWorkBlip");
                        break;
                    }
                case 1:
                    {
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zaposlili ste se kao Dostavljas Hrane");
                        setjob(player, 1);
                        break;
                    }
                case 2:
                    {
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zaposlili ste se kao Rudar");
                        setjob(player, 2);
                        break;
                    }
                case 3:
                    {
                        
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zaposlili ste se kao Bus Vozac");
                        setjob(player, 3);
                        break;
                    }
                case 4:
                    {
                        
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zaposlili ste se kao Haker");
                        setjob(player, 4);
                        break;
                    }
                case 5:
                    {
                        
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zaposlili ste se kao Pilicar");
                        setjob(player, 5);
                        break;
                    }
                case 6:
                    {
                        
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zaposlili ste se kao Elektricar");
                        setjob(player, 6);
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static void Savejobandskill(Player c)
    {
        int tskill = c.GetData<int>("jobskill");
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            
            MySqlCommand query = new MySqlCommand("UPDATE `characters` SET `pizzajob`='" + tskill + "' WHERE `id`='" + AccountManage.GetPlayerSQLID(c) + "'", Mainpipeline);
            query.ExecuteNonQuery();
            Mainpipeline.Close();
        }
    }
    public static void setjob(Player c, int jobid)
    {
        int tskill = 0;
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            
            MySqlCommand query = new MySqlCommand("UPDATE `characters` SET `pizzajob`='" + tskill + "', `job`='" + jobid + "' WHERE `id`='" + AccountManage.GetPlayerSQLID(c) + "'", Mainpipeline);
            query.ExecuteNonQuery();
            c.SetData<dynamic>("job", jobid);
            Mainpipeline.Close();
        }
    }

    public static void addskill(Player c)
    {
        if (c.GetData<int>("jobskill") >= 150)
        {
            return;
        }
        c.SetData("jobskill", c.GetData<int>("jobskill") + 1);
    }


    public static void getjobskillfromsql(Player c)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandText = "SELECT pizzajob, job FROM `characters` WHERE `userid` = '" + AccountManage.GetPlayerSQLID(c) + "'";
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    c.SetData("jobskill", reader.GetInt32("pizzajob"));
                    c.SetData("playerjob", reader.GetInt32("job"));

                }
            }
            Mainpipeline.Close();
        }        
    }


    
}