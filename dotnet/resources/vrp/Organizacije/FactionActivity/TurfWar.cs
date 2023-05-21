using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


class TurfWar : Script
{
    public static int TURF_DEFAULT_VULNERABLE = 1800;
    public static int TURF_NEED_PLAYERS_START = Economy.PLAYER_TO_START_WAR;

    public class TurfEnum : IEquatable<TurfEnum>
    {
        public int id { get; set; }

        public string name { get; set; }

        public int ownerid { get; set; }
        public int vulnerable { get; set; }

        public int payment { get; set; }

        public string capturedBy { get; set; }
        public string capturingBy { get; set; }

        public int active_war { get; set; }
        public int attemptid { get; set; }
        public int attack_points { get; set; }
        public int defend_point { get; set; }
        public int attack_kills { get; set; }
        public int defend_kills { get; set; }
        public int time_left { get; set; }
        public int time_left_start { get; set; }

        public float area_range { get; set; }

        public Vector3 Position { get; set; }
        public Vector3 Position_pickup { get; set; }

        public ColShape areaid { get; set; }
        public Entity pickupid { get; set; }
        public Entity labelid { get; set; }
        public Entity blipid { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            TurfEnum objAsPart = obj as TurfEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(TurfEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }
    public static List<TurfEnum> turf_war = new List<TurfEnum>();

    public static void TurfWarInit()
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `turfs`;", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                var index = 0;
                while (reader.Read())
                {
                    turf_war.Add(new TurfEnum()
                    {
                        id = reader.GetInt32("id"),
                        name = reader.GetString("name"),
                        ownerid = reader.GetInt32("ownerid"),
                        vulnerable = reader.GetInt32("vulnerable"),
                        capturedBy = reader.GetString("capturedBy"),

                        payment = reader.GetInt32("payment"),

                        Position = new Vector3(float.Parse(reader.GetString("position_x")), float.Parse(reader.GetString("position_y")), float.Parse(reader.GetString("position_z"))),
                        area_range = float.Parse(reader.GetString("range")),

                        time_left = 0,
                        time_left_start = 30,
                        attack_points = 0,
                        defend_point = 0,
                        attack_kills = 0,
                        defend_kills = 0,
                        active_war = 0,
                        attemptid = -1

                    });


                    turf_war[index].areaid = NAPI.ColShape.CreateSphereColShape(turf_war[index].Position, turf_war[index].area_range);
                    //turf_war[index].blipid = NAPI.Blip.CreateBlip(turf_war[index].Position);
                    //NAPI.Blip.SetBlipScale(turf_war[index].blipid, 0.92f);

                    if (float.Parse(reader.GetString("position_x")) == 0 && float.Parse(reader.GetString("position_y")) == 0)
                    {
                       // NAPI.Blip.SetBlipTransparency(turf_war[index].blipid, 0);
                    }//
                    else
                    {
                        UpdateTurfProps(index);
                    }
                    index++;
                }

            }
            Mainpipeline.Close();
        }
    }

    public static void SaveTurfWar(int index)
    {
        Main.CreateMySqlCommand("UPDATE `turfs` SET `name`= '" + turf_war[index].name + "',`ownerid`='" + turf_war[index].ownerid + "',`vulnerable`='" + turf_war[index].vulnerable + "',`capturedBy`='" + turf_war[index].capturedBy + "',`position_x`='" + turf_war[index].Position.X + "',`position_y`='" + turf_war[index].Position.Y + "',`position_z`='" + turf_war[index].Position.Z + "',`range`='" + turf_war[index].area_range + "',`payment`='" + turf_war[index].payment + "' WHERE `id`='" + index + "'");
        Console.WriteLine(turf_war[index].ownerid);

    }

    public static void UpdateTurfProps(int index)
    {
        
        /*NAPI.Blip.SetBlipScale(turf_war[index].blipid, 0.6f);
        NAPI.Blip.SetBlipColor(turf_war[index].blipid, 1);

        if (turf_war[index].active_war == 1)
        {
            NAPI.Blip.SetBlipColor(turf_war[index].blipid, 1);
        }
        else if (turf_war[index].ownerid != -1)
        {
            NAPI.Blip.SetBlipColor(turf_war[index].blipid, 28);
        }
        else
        {
            NAPI.Blip.SetBlipColor(turf_war[index].blipid, 25);
        }*/
    }

    [Command("turfinfo", Alias = "territorio, tinfo")]
    public void CMD_turfinfo(Player Client)
    {
        
        int index = Client.GetData<dynamic>("player_in_turf");

        if (index == -1)
        {
            Main.SendErrorMessage(Client, "Niste u organizaciji.");
        }
        else
        {
            Main.SendCustomChatMessasge(Client, "~g~-------------------------------------------------------------");
            Main.SendCustomChatMessasge(Client, "~g~[ZONA]:~w~ ~y~" + turf_war[index].name + " (" + index + ")");

            if (turf_war[index].ownerid == -1)
            {
                Main.SendCustomChatMessasge(Client, "~g~[ZONA]:~w~ Niko nije zauzeo ovu zonu!");
            }
            else
            {
                Main.SendCustomChatMessasge(Client, "~g~[ZONA]:~w~ Zauzeto od strane: ~c~" + FactionManage.faction_data[turf_war[index].ownerid].faction_name + "");
            }

            TimeSpan time = TimeSpan.FromSeconds(turf_war[index].vulnerable);
            string string_vulnerable = time.ToString(@"hh\:mm\:ss");

            TimeSpan timeleft = TimeSpan.FromSeconds(turf_war[index].time_left);
            string string_time_left = timeleft.ToString(@"hh\:mm\:ss");

            if (turf_war[index].active_war == 0)
            {
                Main.SendCustomChatMessasge(Client, "~g~[ZONA]:~w~ ~g~Niko ne zauzima ovu zonu!");

                if (turf_war[index].vulnerable > 0) Main.SendCustomChatMessasge(Client, "~g~[ZONA]:~w~ Dostuipno za: " + string_vulnerable + "min");
                else Main.SendCustomChatMessasge(Client, "~g~[ZONA]:~w~ Spremna za zauzimanje!");
            }
            else
            {
                Main.SendCustomChatMessasge(Client, "~g~[ZONA]:~w~ Trenutno se zauzima!");
                Main.SendCustomChatMessasge(Client, "~g~[ZONA]:~w~ Preostalo vreme: " + string_time_left + "");
                Main.SendCustomChatMessasge(Client, "~g~[ZONA]:~w~ Smrti: " + (turf_war[index].attack_kills + turf_war[index].defend_kills) + "");
            }
        }

    }

    public static void OnInputResponse(Player Client, String response, String inputtext)
    {
        if (response == "input_create_turfwar")
        {
            int index = 0;
            foreach (var turf in turf_war)
            {
                if (turf.name == "Unknown")
                {
                    turf.name = inputtext;
                    turf.ownerid = -1;
                    turf.vulnerable = 0;

                    turf.Position = Client.Position;
                    turf.area_range = Client.GetData<dynamic>("editingTurfRange");

                    NAPI.ColShape.DeleteColShape(turf_war[index].areaid);
                    turf_war[index].areaid = NAPI.ColShape.CreateSphereColShape(TurfWar.turf_war[index].Position, TurfWar.turf_war[index].area_range);

                    UpdateTurfProps(index);
                    SaveTurfWar(index);
                    Main.SendCustomChatMessasge(Client, "Osnovali ste Gang (ID " + index + ") Name: " + inputtext + ".");
                    return;
                }
                index++;
            }
        }
        else if (response == "input_edit_turfwar")
        {
            TurfWar.turf_war[Client.GetData<dynamic>("EditingTurfID")].name = inputtext;
            Main.SendCustomChatMessasge(Client, "Promenili ste naziv zone " + Client.GetData<dynamic>("EditingTurfID") + " To " + inputtext + " ");
            TurfWar.SaveTurfWar(Client.GetData<dynamic>("EditingTurfID"));
        }
    }

    public static void TakeoverTurfWarsZone(int gangid, int zone)
    {
        if (turf_war[zone].ownerid == -1)
        {
            FactionManage.SendFactionMessage(gangid, "** Vasa Organizacija je zauzela zonu!");


            turf_war[zone].ownerid = gangid;

            turf_war[zone].vulnerable = 0;

            turf_war[zone].active_war = 0;
            turf_war[zone].time_left = 0;
            turf_war[zone].time_left_start = 30;
            turf_war[zone].attemptid = -1;
            SaveTurfWar(zone);
            UpdateTurfProps(zone);
            return;
        }

        turf_war[zone].active_war = 1;
        turf_war[zone].attemptid = gangid;

        turf_war[zone].time_left = 350;
        turf_war[zone].time_left_start = 15;

        turf_war[zone].vulnerable = 0;

        turf_war[zone].attack_kills = 0;
        turf_war[zone].defend_kills = 0;
        turf_war[zone].attack_points = 0;
        turf_war[zone].defend_point = 50;
        UpdateTurfProps(zone);
        UpdateZoneBlipForAll();

    }

    public static void CaptureTurfWarsZone(int zone, int attack_gang, int defend_gang)
    {
        int winner = -1;

        if (turf_war[zone].attack_points == turf_war[zone].defend_point)
        {
            if (GetPlayersInTurf(zone, attack_gang) <= GetPlayersInTurf(zone, defend_gang))
            {
                winner = attack_gang;
            }
            else if (GetPlayersInTurf(zone, attack_gang) > GetPlayersInTurf(zone, defend_gang))
            {
                winner = attack_gang;
            }
        }
        else if (turf_war[zone].attack_points < turf_war[zone].defend_point)
        {
            winner = defend_gang;
        }
        else if (turf_war[zone].attack_points > turf_war[zone].defend_point)
        {
            winner = attack_gang;
        }

        string attack_name = FactionManage.faction_data[attack_gang].faction_name;
        string defend_name = FactionManage.faction_data[defend_gang].faction_name;

        if (winner == defend_gang)
        {
            FactionManage.SendFactionMessage(defend_gang, "* Izgubili ste kontrolu nad " + turf_war[zone].name + " zonom.");
            FactionManage.SendFactionMessage(attack_gang, "* Uspesno ste zauzeli zonu " + turf_war[zone].name + ".");

            turf_war[zone].ownerid = defend_gang;
            turf_war[zone].vulnerable = TURF_DEFAULT_VULNERABLE;

            turf_war[zone].active_war = 0;
            turf_war[zone].time_left = 0;
            turf_war[zone].time_left_start = 30;
            turf_war[zone].attemptid = -1;

            UpdateTurfProps(zone);
            SaveTurfWar(zone);
            UpdateZoneBlipForAll();
        }
        else if (winner == attack_gang)
        {
            FactionManage.SendFactionMessage(attack_gang, "* Izgubili ste kontrolu nad " + turf_war[zone].name + " zonom " + defend_name + ".");
            FactionManage.SendFactionMessage(defend_gang, "* Uspesno ste zauzeli zonu " + turf_war[zone].name + ".");

            turf_war[zone].ownerid = attack_gang;
            turf_war[zone].vulnerable = TURF_DEFAULT_VULNERABLE;

            turf_war[zone].active_war = 0;
            turf_war[zone].time_left = 0;
            turf_war[zone].time_left_start = 30;
            turf_war[zone].attemptid = -1;

            UpdateTurfProps(zone);
            SaveTurfWar(zone);
            UpdateZoneBlipForAll();
        }
    }

    public static int GetPlayersInTurf(int zoneid, int gangid)
    {
        int count = 0;
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var i in players)
        {
            if (i.GetData<dynamic>("status") == true && i.GetData<dynamic>("player_in_turf") == zoneid && AccountManage.GetPlayerGroup(i) == gangid && !i.IsInVehicle) count++;
        }
        return count;
    }

    public static void CreatezoneForPlayer(Player Client)
    {
        foreach (var turf in turf_war)
        {
            Client.TriggerEvent("CreateZone", turf.Position.X, turf.Position.Y, turf.Position.Z, 45, turf.area_range, 70);
        }
        Client.TriggerEvent("loadCapturezones");
    }

    public static async System.Threading.Tasks.Task UpdateZoneBlipForPlayer(Player Client)
    {
        int zone = 0;
        foreach (var turf in turf_war)
        {
            if (turf.Position.X != 0 && turf.Position.Y != 0)
            {
                Client.TriggerEvent("setZoneAlpha", zone, 175);

                if (turf.ownerid != -1)
                {
                    Client.TriggerEvent("setZoneColor", zone, FactionManage.faction_data[turf.ownerid].faction_turf_color);
                }
                else Client.TriggerEvent("setZoneColor", zone, 45);

                if (turf.active_war == 1)
                {
                    Client.TriggerEvent("setZoneFlash", zone, true);
                }
                else Client.TriggerEvent("setZoneFlash", zone, false);
            }
            else Client.TriggerEvent("setZoneAlpha", zone, 0);
            zone++;
        }
    }
    public static async System.Threading.Tasks.Task UpdateZoneBlipForAll()
    {
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var Player in players)
        {
            if (Player.GetData<dynamic>("status") == true) UpdateZoneBlipForPlayer(Player);
        }

    }

}