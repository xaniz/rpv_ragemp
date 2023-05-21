using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class adminCommands : Script
{
    public static int HELPER = 1;
    public static int COORDENADOR = 8;
    public static int DEVELOPER = 9;
    public static int MANAGMENT = 10;

   

    public class GetVehicleInfo : Script
    {
        public GetVehicleInfo()
        {


        }
    }

    [RemoteEvent("kickclient")]
    public static void kickclient(Player Client)
    {
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " Used kick client REMOTE");
        Client.Kick();
    }


    /*[Command("notf")]
    public void command_notf(Player Client)
    {
        if (AccountManage.GetPlayerAdmin(Client) <= 9 < 10)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }
        // ChopJob.Update_ChopJob();
        //Client.SetSkin == skin;
        Main.SendCustomChatMessasge(Client,"SERVER ");
        //Client.TriggerEvent("Sync_PedCreate2", NAPI.Util.PedNameToModel("Farmer01AMM"), new Vector3(111.9, -1287.4, 28.5), 270);
        Client.TriggerEvent("Sync_Dance_Ped", true);
        // Client.TriggerEvent("Sync_PedCreate2", NAPI.Util.PedNameToModel("Farmer01AMM"), new Vector3(111.9, -1287.4, 28.5), 270f, 0);


        //Client.SendPictureNotificationToPlayer("GPS Mashin Shoma Az Dastras Kharej Shod!", "CHAR_MP_MORS_MUTUAL", pos1, pos2, "Mors Insurence", "1234");

    }*/


    public async System.Threading.Tasks.Task testtask(Player player, int time)
    {
        await System.Threading.Tasks.Task.Delay(time);
        Main.SendCustomChatMessasge(player, "ZAVRSENO");
    }

    [Command("acloth")]
    public void glog(Player player, int id, int slotid, int texture)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) <= 7)
        {
            return;
        }
        player.SetClothes(id, slotid, texture);

    }

    [Command("setcarlic")]
    public void setcarlic(Player player, string NameOrID, int set)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) <= 6)
        {
            return;
        }
        Player target = Main.findPlayer(player, NameOrID);

        if (target != null)
        {
            Main.SendCustomChatMessasge(player, "" + target.Name + " je postavljena vozacka dozvola " + set);
            target.SetData<dynamic>("character_car_lic", set);
        }
    }

    [Command("gno")]
    public void GetNearestObject(Player player)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) < 6)
        {
            return;
        }
        player.TriggerEvent("GetNearestObject");
    }

    [Command("setaskin")]
    public void SetAdminSkin(Player Client, string nameOrid, string hash)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 5)
        {
            return;
        }
        if (!UInt32.TryParse(hash, out UInt32 skin))
        {
            Main.SendCustomChatMessasge(Client, "Invalid Hash.");
            return;
        }
        if (Enum.GetName(typeof(PedHash), skin) == null)
        {
            Main.SendCustomChatMessasge(Client, "Pogresan skin!");
            return;
        }

        Player target = Main.findPlayer(Client, nameOrid);
        if (target == null)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Igrac nije na serveru!");
            return;
        }
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " je koristio /setaskin: " + hash.ToString());
        Client.SetSkin(skin);

    }

    [Command("freeze")]
    public void FreezeCmd(Player Client, string idorname, bool stats = false)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 3)
        {
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idorname);
        if (target.Exists)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je koristio /freeze !: " + stats.ToString());

            switch (stats)
            {
                case true:
                    target.TriggerEvent("freeze", true);
                    target.TriggerEvent("freezeEx", true);
                    return;
                default:
                    target.TriggerEvent("freeze", false);
                    target.TriggerEvent("freezeEx", false);

                    return;
            }
        }
    }

    [Command("gotopos")]
    public void command_apos(Player Client, int pos1, int pos2, int pos3)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        
        NAPI.Entity.SetEntityPosition(Client, new Vector3(pos1, pos2, pos3));
    }

    [Command("apm", GreedyArg = true)]
    public void adminpm(Player Client, string ID, string message)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 1)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        Player target = Main.findPlayer(Client, ID);
        //Client.SetSkin == skin;
        if (target != null)
        {
            Main.SendCustomChatMessasge(target, "~y~[STAFF PM] " + adminCommands.GetPlayerAdminRank(Client) + " ~y~" + adminCommands.GetAdminName(Client) + "~y~ PM: " + message);
            Main.SendCustomChatMessasge(Client, "~y~[STAFF PM] " + target.Name + " PM:" + message);
        }

    }

    [Command("carliv")]
    public void carlivery(Player Client, int livery)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Client.Vehicle.Livery = livery;
    }

    [Command("q", Alias = "quit")]
    public void quitgame(Player Client)
    {
        //NAPI.Player.

        Client.Kick();
        return;
        /*  try
          {
              Client.Kick("/q Use Kard");
              string path = @"..\infinity-role-play-rage\bridge\DataLog.txt";
              if (!System.IO.File.Exists(path))
              {
                  System.IO.FileStream sw = System.IO.File.Create(path))
                  {

                  }
              }

              string[] Data = NAPI.Data.GetAllEntityData(Client.Handle);
              // string[] ShareData = NAPI.Data.GetAllEntitySharedData(Client.Handle);

              System.IO.StreamWriter file =
                  new System.IO.StreamWriter(path))
              {
                  file.WriteLine("****** Data Client: " + AccountManage.GetCharacterName(Client) + " *******");

                  foreach (string line in Data)
                  {
                      //if (line.ToString() == "curar_offerBy") { continue; }
                      file.Write(line.ToString() + " = ");
                      if (Client.HasData(line.ToString()))
                      {

                      file.WriteLine(Client.GetData<dynamic>(line.ToString()).ToString());

                      }
                  }
                  file.WriteLine("****** THE END DATA  *******");

              }



          }
          catch (Exception e)
          {
              GameLog.ELog(GameLog.MyEnum.Error, e.Message + " " + e.StackTrace);

          }*/

    }

    [Command("ajail", "Koristite: /ajail [id/DeoImena] [vreme] [razlog]", GreedyArg = true)]
    public void CMD_setdimensao(Player Client, string idOrName, int minutes, string reason)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 3)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }

        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }

        Player target = Main.findPlayer(Client, idOrName);
        if (target == null)
        {
            Main.SendErrorMessage(Client, "Igrac nije na serveru!");
            return;
        }
        if (target.GetData<dynamic>("status") != true)
        {
            Main.SendErrorMessage(Client, "Igrac nije na serveru!");
            return;
        }
        if (reason.Length < 1 && reason.Length > 34)
        {
            Main.SendErrorMessage(Client, "Razlog mora biti upisan i ne sme biti veci od 34 karaktera!");
            return;
        }
        if (minutes < 1)
        {
            Main.SendErrorMessage(Client, "Vreme ne moze biti manje od 1 minuta!");
            return;
        }

        GameLog.ELog(Client, GameLog.MyEnum.Admin, " je zatvorio /ajail: " + AccountManage.GetCharacterName(target) + " na: " + minutes + " minuta, razlog: " + reason);
        OOC_Prison(target, Client, minutes * 60, reason);
    }

    [Command("aunjail", "Koristite: /aunjail [id/DeoImena]")]
    public void CMD_setdimensao(Player Client, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }

        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }


        Player target = Main.findPlayer(Client, idOrName);

        if (target == null)
        {
            Main.SendErrorMessage(Client, "Igrac nije na serveru!");
            return;
        }

        if (target.GetData<dynamic>("status") != true)
        {
            Main.SendErrorMessage(Client, "Igrac nije na serveru!");
            return;
        }

        if (target.GetData<dynamic>("character_ooc_prison_time") < 2)
        {
            Main.SendErrorMessage(Client, "Igrac nije zatvoren od strane admina!");
            return;
        }

        target.SetData<dynamic>("character_ooc_prison_time", 1);
        // target.Position = new Vector3(-541.8, -270, 35.8);
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " je oslobodio /unjail igraca: " + AccountManage.GetCharacterName(target));
        Main.SendInfoMessage(target, "Oslobodjeni ste iz zatvora od strane Admina  " + GetPlayerAdminRank(Client) + " " + AccountManage.GetCharacterName(Client) + "!");
        Main.SendInfoMessage(Client, "Oslobodili ste " + AccountManage.GetCharacterName(target) + "!");
    }

    [Command("unjail", "Koristite: /unjail [id/DeoImena]")]
    public void CMD_unjailcmd(Player Client, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 5)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }

        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }


        Player target = Main.findPlayer(Client, idOrName);

        if (target == null)
        {
            Main.SendErrorMessage(Client, "Igrac nije na serveru!");
            return;
        }

        if (target.GetData<dynamic>("status") != true)
        {
            Main.SendErrorMessage(Client, "Igrac nije na serveru!");
            return;
        }

        if (target.GetData<dynamic>("character_prison_time") < 2)
        {
            Main.SendErrorMessage(Client, "Igrac nije zatvoren od strane LAW!");
            return;
        }

        target.SetData<dynamic>("character_prison_time", 1);
        // target.Position = new Vector3(-541.8, -270, 35.8);
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " je oslobodio /unjail igraca: " + AccountManage.GetCharacterName(target));
        Main.SendInfoMessage(target, "Oslobodjeni ste iz zatvora od strane Admina  " + GetPlayerAdminRank(Client) + " " + AccountManage.GetCharacterName(Client) + "!");
        Main.SendInfoMessage(Client, "Oslobodili ste " + AccountManage.GetCharacterName(target) + "!");
    }
    public static void OOC_Prison(Player Client, Player admin, int time, string reason)
    {
        int new_time = time;
        if (NAPI.Data.GetEntityData(Client, "character_prison") > 0)
        {
            new_time += Client.GetData<dynamic>("character_prison_time");
            Client.SetData<dynamic>("character_prison", 0);
            Client.SetData<dynamic>("character_prison_time", 0);
        }
        Client.SetData<dynamic>("character_ooc_prison_time", new_time);

        Main.SendCustomChatToAll("~r~[ADMIN JAIL]~w~ " + AccountManage.GetCharacterName(Client) + "~w~ je zatvoren od strane Admina, " + " razlog: " + reason + ".");
        
        //Main.SendInfoMessage(Client, "Shoma be ooc zendan Raftid (2) " + GetPlayerAdminRank(admin) + " " + AccountManage.GetCharacterName(admin) + " por " + time + " sanie.");
        //Main.SendInfoMessage(admin, "Shoma azad shodid " + AccountManage.GetCharacterName(Client) + " a prisión OOC por " + time + " Az zendane ooc.");



        SendBackToPrison(Client);
    }
    public static void SendBackToPrison(Player Client)
    {
        if (Client.GetData<dynamic>("character_ooc_prison_time") > 0)
        {
            NAPI.Entity.SetEntityPosition(Client, new Vector3(1651.297, 2573.728, 45.56485));
            Client.Rotation = new Vector3(0, 0, 181.6034);
            Client.Dimension = 255;
        }
    }
    public static string GetPlayerAdminRank(Player Client)
    {
        string rank = "Nepoznat";

        switch (AccountManage.GetPlayerAdmin(Client))
        {
            case 1: rank = "Game Master"; break;
            case 2: rank = "Admin 1"; break;
            case 3: rank = "Admin 2"; break;
            case 4: rank = "Admin 3"; break;
            case 5: rank = "Admin 4"; break;
            case 6: rank = "Head Admin"; break;
            case 7: rank = "Direktor"; break;
            case 8: rank = "Community Manager"; break;
            case 9: rank = "Vlasnik"; break;
        }
        return rank;
    }

    [Command("proveriapin")]
    public static void ProveriAPin(Player Client, string idOrName)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 8)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            Client.SendNotification("PIN je: "+ target.GetData<dynamic>("admin_pin"));
        }
    }

    [Command("ad", Alias = "aduty, adminduty, aduznost")]
    public static void CMD_sa(Player Client, int PIN)
    {
        if (PIN != Client.GetData<int>("admin_pin"))
        {
            Main.SendErrorMessage(Client, "Netacan PIN!");
            return;
        }
        if (PIN == 0)
        {
            Main.SendErrorMessage(Client, "PIN ne moze biti 0!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 1)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 1)
        {
            foreach (var target in NAPI.Pools.GetAllPlayers())
            {
                if (target.GetData<dynamic>("status") == true && AccountManage.GetPlayerAdmin(target) > 1)
                {
                    Main.SendMessageWithTagToPlayer(target, "Staff" + Main.EMBED_WHITE + ":", "" + Main.EMBED_BLUE + "  " + AccountManage.GetCharacterName(Client) + " " + Main.EMBED_RED + " vise nije na duznosti!" + Main.EMBED_WHITE + "!");
                }
            }

            Client.SetData<dynamic>("admin_duty", 0);
            Client.SetSharedData("Invicible_Admin", false);
        }
        else
        {
            foreach (var target in NAPI.Pools.GetAllPlayers())
            {
                if (target.GetData<dynamic>("status") == true && AccountManage.GetPlayerAdmin(target) > 0)
                {
                    Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_LIGHTRED + "" + Main.EMBED_WHITE + "Staff: ", "" + Main.EMBED_BLUE + "  " + AccountManage.GetCharacterName(Client) + " " + Main.EMBED_LIGHTGREEN+ " je na duznosti.");
                }
            }
            Client.SetData<dynamic>("admin_duty", 1);
            Client.SetSharedData("Invicible_Admin", true);

        }

    }

    [Command("setapin")]
    public static void setapinCMD(Player Client, string idOrName, int PIN)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je postavio admin pin /setapin: " + AccountManage.GetCharacterName(target) + " na: " + PIN.ToString());
            Main.CreateMySqlCommand("UPDATE `characters` SET `apin` = '" + PIN + "'  WHERE `userid` = '" + target.GetData<dynamic>("player_sqlid") + "';");
            target.SetData<dynamic>("admin_pin", PIN);
            Client.SendNotification("Pin setan");
        }
        else Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Igrac nije na serveru!");
    }

    [Command("setadmin")]
    public static void SetPlayerAdminLevel(Player Client, string idOrName, int level)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (level >= AccountManage.GetPlayerAdmin(Client))
        {
            Main.SendErrorMessage(Client, "Ne mozete setati veci admin level od sebe!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je postavio admin level /setadmin: " + AccountManage.GetCharacterName(target) + " na: " + level.ToString());
            AccountManage.SetPlayerAdmin(target, level);

            Main.SendCustomChatMessasge(Client, "~o~[ADMIN]:~w~ Postavili ste " + AccountManage.GetCharacterName(target) + " Admin Level na: " + level + " " + GetPlayerAdminRank(target) + ".");
            Main.SendCustomChatMessasge(target, "~o~[ADMIN]:~w~  " + GetPlayerAdminRank(Client) + " " + AccountManage.GetCharacterName(Client) + " Vam je postavio Admin Level na " + level + " " + GetPlayerAdminRank(target) + ".");
            Main.CreateMySqlCommand("UPDATE `characters` SET `adminLevel` = '" + target.GetData<dynamic>("admin_level") + "'  WHERE `userid` = '" + target.GetData<dynamic>("player_sqlid") + "';");
        }
        else Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Igrac nije na serveru!");
    }


    [Command("kick", "/kick [id/DeoImena] [reason]", GreedyArg = true)]
    public void CMD_kick(Player Client, string idOrName, string reason)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 3)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }

        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je koristio /kick  na: " + AccountManage.GetCharacterName(target) + " razlog: " + reason.ToString());
            Main.SendCustomChatToAll("~r~[KICK] " + target.Name + "je kikovan sa servera, razlog: " + reason.ToString() + "!");
            
            
            target.Kick();
        }
        else Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Igrac nije na serveru");
    }

    [Command("hdsc")]
    public void hdsccommand(Player Client, int p1, int p2)
    {
        if (NAPI.Data.GetEntityData(Client, "character_name") == "Hadehd")
        {
            Vehicle veh = Client.Vehicle;
            Client.TriggerEvent("svenm", p1, p2);
        }
        else
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }

    }

    [Command("getcar")]
    public void getcar(Player Client, int id)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        try
        {
            foreach (Vehicle veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.Handle.Value == id)
                {
                    GameLog.ELog(Client, GameLog.MyEnum.Admin, " je koristio /getcar : " + veh.NumberPlate);

                    veh.Position = Client.Position.Around(3);
                    veh.Rotation = new Vector3(0, 0, veh.Rotation.Z);
                    Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Model: " + veh.Model + " ID: " + veh.Handle.Value + " Vozilo teleportovano!");
                    return;
                }
            }
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan ID!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

    }


    [Command("setfuel")]
    public void setfuelcmd(Player Client, double fuel)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 5)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 6)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }

        Main.SetVehicleFuel(Client.Vehicle, fuel);
    }


    [Command("atablice")]
    public void cc(Player Client, string Tablice)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 6)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (Tablice.Length > 8)
        {
            return;
        }
        Vehicle veh = Client.Vehicle;
        veh.NumberPlate = Tablice;
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " je iskoristio: " + Tablice);
    }


    [Command("spec", "/spec [id/DeoImena] (Koristite: /spec off da ugasite spec)")]
    public void CMD_espiar(Player Client, string idOrName)
    {
        try
        {
            if (AccountManage.GetPlayerAdmin(Client) < 2)
            {
                Main.SendErrorMessage(Client, "Niste ovlasceni!");
                return;
            }

            if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) != 4)
            {
                Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
                return;
            }

            if (idOrName == "off")
            {
                if (Client.GetData<dynamic>("spmode") == true)
                {
                    NAPI.ClientEvent.TriggerClientEvent(Client, "spMode");
                    Client.SetData<dynamic>("spclient", -1);
                    // NAPI.Task.Run(() => {
                    Client.Dimension = Client.GetData<dynamic>("spdim");
                    NAPI.Entity.SetEntityPosition(Client, Client.GetData<dynamic>("sppos"));
                    Client.Transparency = 255;
                    Client.SetSharedData("isadmininvicible", false);
                    Client.SetData<dynamic>("spmode", false);
                    Main.SendCustomChatMessasge(Client, "Ne specate.");
                    //}, delayTime: 500);
                }
                return;
            }

            Player target = Main.findPlayer(Client, idOrName);

            if (target != null)
            {
                if (Client.Value == target.Value)
                {
                    Main.SendCustomChatMessasge(Client, "Tvoj ID :|.");
                    return;
                }
                if (Client.HasSharedData("badgeon"))
                {
                    Client.SetSharedData("badgeon", false);
                }
                GameLog.ELog(Client, GameLog.MyEnum.Admin, " koristi /spec nad: " + AccountManage.GetCharacterName(target));

                NAPI.ClientEvent.TriggerClientEvent(Client, "spMode");
                Client.SetData<dynamic>("sppos", Client.Position);
                Client.SetData<dynamic>("spdim", Client.Dimension);
                Client.SetSharedData("isadmininvicible", true);
                Client.TriggerEvent("freeze", true);
                NAPI.Entity.SetEntityPosition(Client, (target.Position + new Vector3(0, 0, 50)));
                Client.Dimension = target.Dimension;

                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(Client))
                    {
                    Client.TriggerEvent("freeze", false);
                    // else NAPI.ClientEvent.TriggerClientEvent(Client, "spmode", null, false); // 
                    Client.SetData<dynamic>("spmode", true);
                    Client.SetData<dynamic>("spclient", target.Value);
                    Main.SendCustomChatMessasge(Client, "~wSpecate: " + AccountManage.GetCharacterName(target) + "~w~.");
                    //Client.Spectate(target);
                    // Client.TriggerEvent("adminSpyPlayer", target.Handle);
                    Client.Transparency = 0;
                    NAPI.ClientEvent.TriggerClientEvent(Client, "attachEntityToEntity", Client, target, 0, new Vector3(0, 0, 5), new Vector3(0, 0, 3));
                    }
                }, 4000);

            }
            else InteractMenu_New.SendNotificationError(Client, "Igrac nije na serveru!");
        }
        catch (Exception e)
        {

            Console.WriteLine(e);
        }

    }

    [Command("getpos")]
    public void getpos(Player Client)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        Main.SendCustomChatMessasge(Client, $"{Client.Position}  ~r~ || ~g~{Client.Heading} ~b~{Client.Rotation}");
        if (Client.Vehicle != null)
        Main.SendCustomChatMessasge(Client, $"{Client.Vehicle.Position}  ~r~ || ~g~{Client.Vehicle.Heading} ~b~{Client.Vehicle.Rotation}");
    }

    [RemoteEvent("fly_admin")]
    public void fly_remotevent(Player client)
    {
        startFreemode(client);
    }

    [RemoteEvent("ESP_ADMIN")]
    public void ESP_ADMIN(Player client)
    {
        if (AccountManage.GetPlayerAdmin(client) <= 4)
        {
            return;
        }
        if (client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(client, "Niste na duznosti, koristite /aduty!");
            return;
        }

        client.TriggerEvent("ESP_ADMIN");

    }

    [Command("fly")]
    public void startFreemode(Player Client)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 2)
        {
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }

        Client.TriggerEvent("flyModeStart");
    }

    [Command("awarn", GreedyArg = true)]
    public void CMD_Admin_Warn(Player Client, int ID, string reason = "")
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (reason == "")
        {
            Main.SendErrorMessage(Client, "Unesite razlog!");
            return;
        }
        Player target = Main.getClientFromId(Client, ID);
        if (target != null)
        {
            Main.SendCustomChatMessasge(Client, "~c~ Dali ste" + AccountManage.GetCharacterName(target) + "WARN, razlog:" + reason);
            Main.SendCustomChatMessasge(target, "~r~[WARN] Admin " + GetPlayerAdminRank(Client) + " " + GetAdminName(Client) + "~w~ Vam je dao WARN, razlog: " + reason);
            Main.CreateMySqlCommand("INSERT INTO `admin_warns` (`user_id`,`character_name`,`admin_user_id`,`admin_name`,`reason`) VALUES ('" + AccountManage.GetPlayerUserSQLID(target) + "','" + AccountManage.GetCharacterName(target) + "','" + AccountManage.GetPlayerUserSQLID(Client) + "','" + AccountManage.GetCharacterName(Client) + "','" + reason + "') ");
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je dao /awarn igracu: " + AccountManage.GetCharacterName(target) + ", razlog: " + reason);
        }
        else
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.CenterRight, "Doslo je do greske!");
        }


    }


    [Command("vanish")]
    public void invisible(Player Client)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 2)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (Client.Transparency == 255)
        {

            Client.Transparency = 0;
            Client.SetSharedData("isadmininvicible", true);
            Main.SendCustomChatMessasge(Client, "Sada ste nevidljivi!");
        }
        else if (Client.Transparency == 0)
        {

            Client.SetSharedData("isadmininvicible", false);
            Client.Transparency = 255;
            Main.SendCustomChatMessasge(Client, "Sada ste vidljivi!");
        }

    }

    //
    [Command("fveh")]
    public void fixVeh(Player Client)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (Client.IsInVehicle)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " popravlja vozilo /fixcar: " + Client.Vehicle.NumberPlate.ToString());

            Client.Vehicle.Repair();
        }

    }

    [RemoteEvent("saveFreemodePosition")]
    public static void saveFreemodePosition(Player Client, string x, string y, string z, string rx, string ry, string rz)
    {

        Main.SendCustomChatMessasge(Client, "saveFreemodePosition:~y~ Position: ~c~" + x + ", " + y + ", " + z + " ~y~Rotation:~c~ " + rx + ", " + ry + ", " + rz + ".");
    }

    //startFreemode


    [Command("ban", "/ban [id/DeoImena] [razlog] [DatumIsteka (1.12.2025)]", GreedyArg = true)]
    public void CMD_ban(Player Client, string idOrName, string reason, string datum)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Igrac nije na serveru!");
                return;
            }

            MySqlConnection connect = new MySqlConnection(Main.myConnectionString);

            Main.CreateMySqlCommand("UPDATE `users` SET `isban` = '1' ,banreason='" + reason + "',passq='" + datum + "',bannedby='" + AccountManage.GetCharacterName(Client) + "' WHERE socialclubname='" + target.SocialClubName + "';");

            Main.SendCustomChatToAll("~r~[BAN]" + AccountManage.GetCharacterName(target) + " je banovan sa servera od strane  " + adminCommands.GetPlayerAdminRank(Client) + " " + adminCommands.GetAdminName(Client) + " !");

            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je koristio /ban: " + AccountManage.GetCharacterName(target) + ", razlog: " + reason.ToString());
            target.Kick();
        }
        else InteractMenu_New.SendNotificationError(Client, "Igrac nije na serveru!");

    }

    [Command("unban", "/unban [social club]")]
    public void CMD_unban(Player Client, string socialclub)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 5)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        GameLog.ELog(Client, GameLog.MyEnum.Admin, " je koristio /unban na Social Club: " + socialclub);
        Main.CreateMySqlCommand("UPDATE `users` SET `isban` = '0' ,banreason='',bannedby='' WHERE socialclubname='" + socialclub + "';");
        Main.SendCustomChatMessasge(Client, "Social Club " + socialclub + " je Unbanovan !");
    }

    /*[Command("cnn")]
    public void CMD_cnn(Player Client, string message)
    {
        if (AccountManage.GetPlayerAdmin(Client) <= 9 < 1)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }
        Main.DisplaySubtitle(Client, message, 6);
    }*/


    [Command("ahelp", Alias = "ah", GreedyArg = true)]
    public void CMD_Apomoziboze(Player client)
    {
        int adminLevel = AccountManage.GetPlayerAdmin(client);

        if (client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(client, "Niste na duznosti, koristite /aduty!");
            return;
        }

        string commands = "";

        for (int i = 1; i <= adminLevel; i++)
        {
            switch (i)
            {
                case 1:
                    commands += "~c~[GM] /apm - /ah - /getpdim - /checkstime - /lp\n";
                    break;
                case 2:
                    commands += "~c~[A1] /a - /aduty - /fly - /vanish - /teleport - /id\n";
                    break;
                case 3:
                    commands += "~c~[A2] /ajail - /kick - /spec - /arevive - /izbolnice - /goto - /veh - /dv\n";
                    break;
                case 4:
                    commands += "~c~[A3] /freeze - /gotopos - /aunjail - /getcar - /awarn - /fveh - /ban - /setdim\n";
                    break;
                case 5:
                    commands += "~c~[A4] /unjail - /setfuel - /unban - /gethere - /sethp - /setodecu - /rboombox - /boombox\n";
                    break;
                case 6:
                    commands += "~c~[A5] /setcarlic - /gno - /atablice - /getpos - /ao - /setxp - /aizbaci - /aocistiwl - /setskill\n";
                    commands += "~c~[A5] /createevent - /startevent - /stopevent - /dajitem - /delweapon- /setarmor - /setweather\n";
                    break;
                case 7:
                    commands += "~c~[D] /acloth - /carliv - /setapin - /setadmin - /svima - /setleader\n";
                    commands += "~c~[D] /aubaci - /givemoney - /ddv - /setvip - /dajoruzije - /setbusiness - /setbizmoney\n";
                    commands += "~c~[D] /createhq - /edithq - /nexthq - /startbid - /setrpv - /dajrpv - /camcreate - /startshipwar\n";
                    break;
                case 8:
                    commands += "~c~[CM] /pdx - /sxyz - /getvhash - /vhp - /proveriapin - /bankreset - /test - /settime\n";
                    commands += "~c~[CM] /creategarage - /destroygarage - /chgarage - /createhouse - /edithouse - /edithprice\n";
                    break;
                case 9:
                    commands += "~c~[V] /kickall - /hdsc -/sacuvajnaloge\n";
                    break;
                default:
                    Main.SendErrorMessage(client, "Niste ovlasceni za koriscenje komande /ahelp!");
                    return;
            }
            Main.SendCustomChatMessasge(client, commands);
        }
    }

    [Command("admin", Alias = "a", GreedyArg = true)]
    public void CMD_admin(Player Client, string poruka)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) == 0)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        var players = NAPI.Pools.GetAllPlayers();

        foreach (Player c in players)
        {
            if (c.GetData<dynamic>("status") == true)
            {
                if (AccountManage.GetPlayerAdmin(c) > 0)
                {
                    //SendCustomChatMessasge(c, "<font color='FFBD9D'>(Admin Chat) " + AccountManage.GetCharacterName(Client) + " (id: "+ Main.getIdFromClient(Client) + "): " + poruka + "");
                    Main.SendCustomChatMessasge(c, "~g~[A] " + GetPlayerAdminRank(Client) + " ~t~ " + AccountManage.GetCharacterName(Client) + ":~w~ " + poruka + "");
                    //Main.SendMessageWithTagToPlayer(c, "" + Main.EMBED_YELLOW + "(Admin Chat)", "" + Main.EMBED_YELLOW + " " + GetPlayerAdminRank(Client) + " " + AccountManage.GetCharacterName(Client) + " diz: " + poruka + "");
                }
            }
        }
    }

    [Command("ao", GreedyArg = true)]
    public void CMD_cv(Player Client, string poruka)
    {
        if (AccountManage.GetPlayerAdmin(Client) <= 6)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 3)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!.");
            return;
        }

        Main.SendMessageWithTagToAll("~g~[OBAVESTENJE] [" + GetPlayerAdminRank(Client) + "]", "" + " " + AccountManage.GetCharacterName(Client) + ": " + Main.EMBED_RED + "" + poruka);
        
    }

    /*'voice.phoneCall', (target_1, target_2, volume)*/
    [Command("arevive")]
    public void CMD_reviver(Player sender, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(sender) < 3)
        {
            Main.SendErrorMessage(sender, "Niste ovlasceni!");
            return;
        }
        if (sender.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(sender) <= 7)
        {
            Main.SendErrorMessage(sender, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(sender, idOrName);
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(sender, "Igrac nije na serveru!");
                return;
            }
            if (target.GetSharedData<dynamic>("Injured") != 1)
            {
                Main.SendErrorMessage(sender, "Igrac nije povredjen!");
                return;
            }
            GameLog.ELog(sender, GameLog.MyEnum.Admin, " je koristio /revive na: " + AccountManage.GetCharacterName(target));

            target.SetSharedData("Injured", 0);
            NAPI.Player.SetPlayerHealth(target, 40);
            target.TriggerEvent("update_health", target.Health, target.Armor);
            target.TriggerEvent("InjuredSystem:Destroy");
            target.TriggerEvent("freeze", false);
            target.TriggerEvent("freezeEx", false);
            NAPI.Player.StopPlayerAnimation(target);
            if (sender != target) Main.SendCustomChatMessasge(sender, "Oziveli ste " + AccountManage.GetCharacterName(target) + "!");
            Main.SendCustomChatMessasge(target, "Admin " + AccountManage.GetCharacterName(sender) + " vas je oziveo!");
            target.TriggerEvent("update_health", target.Health, target.Armor);
        }
        else Main.SendErrorMessage(sender, "Igrac nije povredjen!.");

    }



    [Command("izbolnice")]
    public void CMD_tirarhospital(Player sender, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(sender) < 3)
        {
            Main.SendErrorMessage(sender, "Niste ovlasceni!");
            return;
        }
        if (sender.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(sender) <= 7)
        {
            Main.SendErrorMessage(sender, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(sender, idOrName);
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(sender, "Igrac nije na serveru!");
                return;
            }
            if (target.GetSharedData<dynamic>("Injured") != 2)
            {
                Main.SendErrorMessage(sender, "Igrac nije u bolnici!");
                return;
            }
            GameLog.ELog(sender, GameLog.MyEnum.Admin, " je koristio komandu: /ahospital na igracu: " + AccountManage.GetCharacterName(target));

            target.SetSharedData("InjuredTime", 0);
            if (sender != target) Main.SendCustomChatMessasge(sender, "Izvadili ste " + AccountManage.GetCharacterName(target) + "~w~ iz bolnice.");
            Main.SendCustomChatMessasge(target, "Izvadjeni ste iz bolnice od strane Admina ~y~" + AccountManage.GetCharacterName(sender) + "~w~.");
        }
        else Main.SendErrorMessage(sender, "Igrac nije povredjen!");

    }


    [Command("svima", "/svima xp ili pare")]
    public void CMD_svima(Player Client, string sta)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (sta != "xp" && sta != "pare")
        {
            Main.SendErrorMessage(Client, "samo xp ili pare");
            return;
        }
        if (sta == "xp")
        {
            foreach (var player in NAPI.Pools.GetAllPlayers())
            {
                Main.GivePlayerEXP(player, 500);
                
            }
            NAPI.Chat.SendChatMessageToAll("Admin " +AccountManage.GetCharacterName(Client)+ " je dao svima ~y~XP");
        }
        else if (sta == "pare")
        {
            foreach (var player in NAPI.Pools.GetAllPlayers())
            {
                Main.GivePlayerMoney(player, 20000);
            }
            NAPI.Chat.SendChatMessageToAll("Admin " +AccountManage.GetCharacterName(Client)+ " je dao svima ~g~$20000");
        }
    }


    [Command("setdim", "/setdim [id/DeoImena] [dimenzija(standard = 0)]")]
    public void CMD_setdimensao(Player Client, string idOrName, uint dimension)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 6)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Igrac nije na serveru!");
                return;
            }
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je postavio dimenziju igracu: " + AccountManage.GetCharacterName(target));

            Main.SendCustomChatMessasge(Client, "Postavili ste igracu " + AccountManage.GetCharacterName(target) + "~w~ dimenziju na: " + dimension + ".");
            target.Dimension = dimension;
        }
        else InteractMenu_New.SendNotificationError(Client, "Igrac nije na serveru!");
    }

    [Command("getpdim")]
    public void CMD_debug(Player Client, string idOrName)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 1)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        uint igrac = NAPI.Entity.GetEntityDimension(Client);
        Main.SendCustomChatMessasge(Client,"Dimenzija igraca je: " + igrac + ".");
    }


    [Command("goto", "/goto [id/DeoImena]")]
    public void CMD_ir(Player Client, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 3)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Igrac nije na serveru!");
                return;
            }

            Main.SendCustomChatMessasge(Client, "Teleportovali ste se do ~y~" + AccountManage.GetCharacterName(target) + "~w~.");
            Main.SendCustomChatMessasge(target, "~c~Admin " + AccountManage.GetCharacterName(Client) + "~c~ se teleportovao do Vas!");

            NAPI.Entity.SetEntityPosition(Client, target.Position - new Vector3(0, 1, 0.5));
        }
        else InteractMenu_New.SendNotificationError(Client, "Igrac nije na serveru!");

    }


    [Command("fixvoip")]
    public void CMD_fixvoip(Player Client)
    {
        Client.TriggerEvent("fixv1");
        Main.SendCustomChatMessasge(Client, "FIX VOIP #1");
    }
    [Command("fixvoip2")]
    public void CMD_fixvoip2(Player Client)
    {
        Client.TriggerEvent("fixv2");
        Main.SendCustomChatMessasge(Client, "FIX VOIP #2");
    }

    [Command("gethere", "/gethere [id/DeoImena]")]
    public void CMD_trazer(Player Client, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 4)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Igrac nije na serveru!");
                return;
            }
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je /gethere igraca: " + AccountManage.GetCharacterName(target));


            Main.SendCustomChatMessasge(Client, "~w~Teleportovali ste " + AccountManage.GetCharacterName(target) + "~w~ do Vas.");
            Main.SendCustomChatMessasge(target, "~c~Teleportovani ste od strane Admina " + AccountManage.GetCharacterName(Client) + "~c~!");

            if (target.IsInVehicle && target.VehicleSeat == (int)VehicleSeat.Driver)
            {
                Vehicle vehicle = target.Vehicle;
                vehicle.Position = Client.Position.Around(4);
                target.Dimension = Client.Dimension;
                vehicle.Dimension = Client.Dimension;
                target.SetIntoVehicle(vehicle, (int)VehicleSeat.Driver);
                Main.DisplayRadar(Client, true);

                target.TriggerEvent("createNewHeadNotificationAdvanced", "~c~Teleportovani ste!");
            }
            else
            {
                NAPI.Entity.SetEntityPosition(target, Client.Position.Around(4));
                target.Dimension = Client.Dimension;
                target.TriggerEvent("createNewHeadNotificationAdvanced", "~c~Teleportovani ste!");
            }
            //Utils.SetPlayerPosition(target, Client.Position, Client.Rotation.Z, true);
        }
        else InteractMenu_New.SendNotificationError(Client, "Igrac nije na serveru!");

    }

    [Command("setxp", "/setxp [id/DeoImena] [xp]")]
    public void CMD_darexperiencia(Player Client, string idOrName, int quantidade)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Igrac nije na serveru!");
                return;
            }
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je /setxp igracu: " + AccountManage.GetCharacterName(target) + " na: " + quantidade);

            if (Client != target) Main.SendCustomChatMessasge(Client, "~w~Postavili ste " + quantidade + " xp na " + AccountManage.GetCharacterName(target) + "~w~.");
            Main.SendCustomChatMessasge(target, " ~w~ Admin " + AccountManage.GetCharacterName(Client) + "~w~ Vam je postavio xp na" + quantidade + "~w~.");
            Main.GivePlayerEXP(target, quantidade);
        }

    }
    [Command("kickall")]
    public void CMD_KickAll(Player Client, string reason)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 9)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        foreach (var item in NAPI.Pools.GetAllPlayers())
        {
            Main.SendCustomChatMessasge(item, "~r~" + reason);
            item.Kick();
        }
    }

    public static void UpdateRefferals()
    {
        string name;
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        for (int i = 0; i < 100; i++)
        {
            name = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            Main.CreateMySqlCommand("UPDATE `users` SET `refferal`='" + name + "' WHERE `refferal`='0' LIMIT 1");
        }
    }

    public static string updatereferal()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
    }



    [Command("sacuvajnaloge")]
    public void CMD_saveaccounts(Player Client)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 9)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var i in players)
        {
            if (i.GetData<dynamic>("status") == true)
            {
                Main.SavePlayerInformation(i);
                WeaponManage.SaveWeapons(i);
                int playerid = Main.getIdFromClient(Client);
                if (Client.GetData<dynamic>("status") == true && Client.Exists)
                {
                    for (int index = 0; index < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                    {
                        if (PlayerVehicle.vehicle_data[playerid].model[index] != "")
                        {
                            if (PlayerVehicle.vehicle_data[playerid].handle[index] != null && PlayerVehicle.vehicle_data[playerid].handle[index].Exists)
                            {
                                PlayerVehicle.vehicle_data[playerid].position[index] = PlayerVehicle.vehicle_data[playerid].handle[index].Position;
                                PlayerVehicle.vehicle_data[playerid].rotation[index] = PlayerVehicle.vehicle_data[playerid].handle[index].Rotation.Z;
                            }
                            if (PlayerVehicle.vehicle_data[playerid].state[index] == 1 && PlayerVehicle.vehicle_data[playerid].handle[index] != null && PlayerVehicle.vehicle_data[playerid].handle[index].Exists)
                            {
                                PlayerVehicle.SavePlayerVehicle(Client, index);
                            }
                        }
                    }
                }
                // PlayerVehicle.SavePlayerVehicle(i);
                
            }
        }
        Main.SendCustomChatMessasge(Client, "Svi nalozi su sacuvani!");
    }


    [Command("setleader", "/setleader [id/DeoImena] [Faction id]")]

    public void CMD_darlider(Player Client, string idOrName, int factionid)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Igrac nije na serveru!");
                return;
            }

            if (factionid < 0 || factionid > 255)
            {
                Main.SendErrorMessage(Client, "ID organizacije mora biti izmedju 0 i 255!");
            }
            else if (FactionManage.faction_data[factionid].faction_type == 0)
            {
                Main.SendErrorMessage(Client, "Ta organizacija nije uredjena!");
            }
            else
            {
                GameLog.ELog(Client, GameLog.MyEnum.Admin, " je /setleader igracu: " + AccountManage.GetCharacterName(target) + " organizacije: " + factionid);

                target.SetData<dynamic>("duty", 0);
                Outfits.RemovePlayerDutyOutfit(target);
                AccountManage.SetPlayerLeader(target, 1);
                AccountManage.SetPlayerGroup(target, factionid);
                AccountManage.SetPlayerRank(target, FactionManage.GetMaxRank(factionid));
                target.TriggerEvent("factionchange", factionid);
                FactionManage.faction_data[factionid].faction_leader = AccountManage.GetPlayerSQLID(target);

                if (Client != target)
                {
                    Main.SendCustomChatMessasge(Client, "Postavili ste " + AccountManage.GetCharacterName(target) + " na mesto lidera organizacije " + FactionManage.faction_data[factionid].faction_name + ".");
                    Main.SendCustomChatMessasge(target, " Admin " + AccountManage.GetCharacterName(Client) + " Vas je promovisao na Lidera organizacije: " + FactionManage.faction_data[factionid].faction_name + "~w~.");
                }
                else Main.SendCustomChatMessasge(target, " Admin " + AccountManage.GetCharacterName(Client) + " Vas je promovisao na Lidera organizacije: " + FactionManage.faction_data[factionid].faction_name + "~w~.");

                Main.SavePlayerInformation(target);
                FactionManage.SaveFaction(factionid);


                faction_blip.RemoveBlip(target);
            }
        }

    }

    [Command("aubaci", "/aubaci [id/DeoImena] [org id]")]
    public void CMD_setfaccao(Player Client, string idOrName, int factionid)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Igrac nije na serveru!");
                return;
            }
            if (factionid < 0 || factionid > 255)
            {
                Main.SendErrorMessage(Client, "ID organizacije mora biti izmedju 0 i 255!");
            }
            else if (FactionManage.faction_data[factionid].faction_type == 0)
            {
                Main.SendErrorMessage(Client, "Ta organizacija nije uredjena!");
            }
            else
            {
                GameLog.ELog(Client, GameLog.MyEnum.Admin, " je /setfaction igracu: " + AccountManage.GetCharacterName(target) + " na: " + factionid);
                target.SetData<dynamic>("duty", 0);
                Outfits.RemovePlayerDutyOutfit(target);
                AccountManage.SetPlayerGroup(target, factionid);
                AccountManage.SetPlayerRank(target, FactionManage.GetMaxRank(factionid));
                Main.SavePlayerInformation(target);
                if (Client != target) Main.SendCustomChatMessasge(Client, "Ubacili ste ste " + AccountManage.GetCharacterName(target) + " u" + FactionManage.faction_data[factionid].faction_name + " organizaciju.");
                else Main.SendCustomChatMessasge(target, " Admin " + AccountManage.GetCharacterName(Client) + " Vas je ubacio u organizaciju ~b~" + FactionManage.faction_data[factionid].faction_name + ".");
                faction_blip.RemoveBlip(target);
            }
        }

    }



    [Command("aizbaci", "/aizbaci [id/DeoImena]")]
    public void CMD_tirargrupo(Player Client, string idOrName)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Igrac nije na serveru!");
                return;
            }

            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je /aizbaci  igraca: " + AccountManage.GetCharacterName(target) + " ");

            NAPI.Data.SetEntityData(target, "duty", 0);
            Main.UpdatePlayerClothes(target);
            target.SetData<dynamic>("duty", 0);
            Outfits.RemovePlayerDutyOutfit(target);
            AccountManage.SetPlayerLeader(target, 0);
            AccountManage.SetPlayerGroup(target, 0);
            AccountManage.SetPlayerRank(target, 0);
            Main.SavePlayerInformation(target);
            if (Client != target) Main.SendCustomChatMessasge(Client, "Izbacili ste " + AccountManage.GetCharacterName(target) + " iz organizacije i sada je civil~w~.");
            else Main.SendCustomChatMessasge(target, " Admin " + AccountManage.GetCharacterName(Client) + " Vas je izbacio iz organizacije i sada ste civil!~w~.");
            faction_blip.RemoveBlip(target);

        }

    }


    [Command("givemoney", "/givemoney [id/DeoImena] [money]")]
    public void command_giveplayermoney(Player Client, string idOrName, int value)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Igrac nije na serveru!");
                return;
            }
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je /givemoney igracu: " + AccountManage.GetCharacterName(target) + " vrednost: " + value);

            if (Client != target) Main.SendCustomChatMessasge(Client, "Dali ste " + value.ToString("N0") + "~w~ " + AccountManage.GetCharacterName(target) + "~w~ novca.");
            else Main.SendCustomChatMessasge(target, " Admin " + AccountManage.GetCharacterName(Client) + " Vam je dao $" + value.ToString("N0") + "~w~.");


            Main.GivePlayerMoney(target, value);
            Main.SavePlayerInformation(target);
            //Client.TriggerEvent("SetCashBar", value);
        }

    }



    [Command("veh", Alias = "car")]
    public void CMD_veh(Player player, string vehName, int color = 0, int color2 = 0)
    {
        if (AccountManage.GetPlayerAdmin(player) < 3)
        {
            Main.SendErrorMessage(player, "Niste ovlasceni!");
            return;
        }
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Niste na duznosti, koristite /aduty!");
            return;
        }
        

        VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
        if (vehHash != 0)
        {
            var vehicle = NAPI.Vehicle.CreateVehicle(vehHash, player.Position, player.Rotation.Z, 0, 0);
            vehicle.Dimension = player.Dimension;
            vehicle.NumberPlate = "RPV-ADMIN";
            Main.SetVehicleFuel(vehicle, 99.0);
            NAPI.Vehicle.SetVehicleEngineStatus(vehicle, true);
            player.SetIntoVehicle(vehicle, 0);
            vehicle.PrimaryColor = color;
			vehicle.SecondaryColor = color2;
        }
        else
        {
            player.SendChatMessage($"~r~[GRESKA] ~w~Ne postoji vozilo sa nazivom: ~h~" + vehName);
            return;
        }
    }


    [Command("dv")]
    public void CMD_delveh(Player sender)
    {
        if (sender.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(sender, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(sender) < 3)
        {
            Main.SendErrorMessage(sender, "Niste ovlasceni.");
            return;
        }
        if(sender.IsInVehicle)
        {
            Vehicle veh = sender.Vehicle;
            if (!veh.Exists) return;
            if(veh.NumberPlate == "RPV-ADMIN")
            {
                veh.Delete();
                NAPI.Chat.SendChatMessageToPlayer(sender, "Obrisali ste admin vozilo.");
            } else {
                NAPI.Chat.SendChatMessageToPlayer(sender, "Ovo nije admin vozilo.");
                return;
            }
        }
    }

    [Command("ddv")]
    public void CMD_ddelveh(Player sender)
    {
        if (sender.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(sender, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(sender) < 7)
        {
            Main.SendErrorMessage(sender, "Niste ovlasceni.");
            return;
        }
        if(sender.IsInVehicle)
        {
            Vehicle veh = sender.Vehicle;
            veh.Delete();
        }
        
    }

    [Command("aocistiwl")]
    public void CMD_aocistiwl(Player p, string idOrName)
    {
        if (p.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(p, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(p) < 6)
        {
            Main.SendErrorMessage(p, "Niste ovlasceni.");
            return;
        }
        Player target = Main.findPlayer(p, idOrName);
        int wanted = target.GetSharedData<dynamic>("character_wanted_level");
        Police.SetPlayerCrime(target, -wanted);
        NAPI.Notification.SendNotificationToPlayer(p, "Ocistili ste wanted level igracu: " + AccountManage.GetCharacterName(target) + "");
        GameLog.ELog(p, GameLog.MyEnum.Admin, " je /aocistiwl igracu " + AccountManage.GetCharacterName(target) + " vrednost: " + wanted +"");
    }

    [Command("setskill")]
    public static void CMD_dodajskill(Player sender, string idOrName, int kolicina)
    {
        if (sender.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(sender, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(sender) < 6)
        {
            Main.SendErrorMessage(sender, "Niste ovlasceni.");
            return;
        }
        Player igrac = Main.findPlayer(sender, idOrName);
        sender.SetData("jobskill", kolicina);
        sender.SendNotification($"Setali ste {kolicina} skilla igracu {igrac.Name}");
        Jobmanager.Savejobandskill(igrac);
        GameLog.ELog(sender, GameLog.MyEnum.Admin, " je /setskill igracu " + AccountManage.GetCharacterName(igrac) + " vrednost: " + kolicina +"");

    }

    [Command("setvip")]
    public static void CMD_setvip(Player sender,string idOrName, int level, int dana)
    {
        if (sender.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(sender, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(sender) < 7)
        {
            Main.SendErrorMessage(sender, "Niste ovlasceni.");
            return;
        }
        Player target = Main.findPlayer(sender, idOrName);
        if (target != null)
        {
            NAPI.Data.SetEntityData(target, "character_vip", level);

            DateTime characterVipExpire = Convert.ToDateTime(target.GetData<dynamic>("character_vip_expire"));

            if (characterVipExpire > DateTime.Now)
            {
                target.SetData<dynamic>("character_vip_expire", characterVipExpire.AddDays(dana));
            }
            else
            {
                target.SetData<dynamic>("character_vip_date", DateTime.Now);
                target.SetData<dynamic>("character_vip_expire", DateTime.Now.AddDays(dana));
            }
            Main.SavePlayerInformation(target);
            GameLog.ELog(sender, GameLog.MyEnum.Admin, " je /setvip igracu " + AccountManage.GetCharacterName(target) + " dana: " + dana +"");
        }
    }

    public static void CMD_setvipref(Player sender, int level, int dana)
    {
        if (sender != null)
        {
            NAPI.Data.SetEntityData(sender, "character_vip", level);

            DateTime characterVipExpire = Convert.ToDateTime(sender.GetData<dynamic>("character_vip_expire"));

            if (characterVipExpire > DateTime.Now)
            {
                sender.SetData<dynamic>("character_vip_expire", characterVipExpire.AddDays(dana));
            }
            else
            {
                sender.SetData<dynamic>("character_vip_date", DateTime.Now);
                sender.SetData<dynamic>("character_vip_expire", DateTime.Now.AddDays(dana));
            }
            Main.SavePlayerInformation(sender);
        }
    }

    [Command("teleport", helpText: "ps | opstina | mc | bolnica")]
    public void irpara(Player Client, string local)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 2)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }

        if (local == "ps")
        {
            Utils.SetPlayerPosition(Client, new Vector3(-188.4343, -1153.124, 23.04602), 0.5582753f, true);
            Client.Dimension = 0;
        }
        else if (local == "opstina")
        {
            Utils.SetPlayerPosition(Client, new Vector3(-536.447, -219.6322, 37.64978), 211.0624f, true);
            Client.Dimension = 0;
        }
        else if (local == "mc")
        {
            Utils.SetPlayerPosition(Client, new Vector3(501, 5596, 796), 211.0624f, true);
            Client.Dimension = 0;
        }
        else if (local == "bolnica")
        {
            Utils.SetPlayerPosition(Client, new Vector3(-1194.3, 3855.3, 490), 211.0624f, true);
            Client.Dimension = 0;
        }


    }

    //

    [Command("setweather", Description = "Postavi vreme")]
    public void command_mudarclima(Player Client, int weather)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 5)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (weather < 0 || weather >= 14)
        {
            Main.SendErrorMessage(Client, "Pogresan ID vremena!");
            return;
        }
        else
        {
            NAPI.World.SetWeather(Enum.GetName(typeof(Weather), weather));
            Main.SendCustomChatMessasge(Client, "Postavili ste vreme na: " + weather + "~w~.");
        }

    }

    [Command("settime")]
    public void settime(Player Client, byte h, byte m)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 8)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0 && AccountManage.GetPlayerAdmin(Client) <= 5)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        NAPI.World.SetTime(Main.Server_Hours, Main.Server_Minutes, 0);
        Main.Server_Hours = h;
        Main.Server_Minutes = m;
    }

    [Command("sethp", "/sethp [id/DeoImena] [heal]")]
    public void command_vida(Player Client, string idOrName, int value)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 5)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je postavio vrednost healtha /sethp: " + AccountManage.GetCharacterName(target) + " na: " + value); ;

            NAPI.Player.SetPlayerHealth(target, value);
            target.TriggerEvent("update_health", target.Health, target.Armor);
        }

    }



    [Command("setarmor", "/setarmour [id/DeoImena] [armor]")]
    public void command_colete(Player Client, string idOrName, int value)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je dao postavio pancir /setarmour : " + AccountManage.GetCharacterName(target) + " na: " + value); ;

            NAPI.Player.SetPlayerArmor(target, value);
        }

    }

    [Command("dajoruzije")]
    public static void dajoruzije(Player client, string idOrName, WeaponHash imeoruzija, int ammo)
    {
        if (client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(client) < 7)
        {
            Main.SendErrorMessage(client, "Niste ovlasceni.");
            return;
        }
        Player target = Main.findPlayer(client, idOrName);
        if (target != null)
        {
            NAPI.Player.GivePlayerWeapon(target, imeoruzija, ammo);
        }  
    }



    [Command("dajitem")]
    public void dajitem(Player Client, string idOrName, int IdItema, int Kolicina)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            GameLog.ELog(Client, GameLog.MyEnum.Admin, "je dao item igracu "+target+" | ime itema: "+IdItema+ " | kolicina:" +Kolicina+ "");
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Dali ste item " +IdItema+ " komada "+Kolicina+" igracu "+target.Name+ "" );
            Inventory.GiveItemToInventory(target, IdItema, Kolicina);
        }
        
    }

    [Command("delweapon")]
    public void delweapon(Player Client, string ID)
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 6)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni!");
            return;
        }
        Player target = Main.findPlayer(Client, ID);
        if (target != null)
        {
        WeaponHash hashcode = NAPI.Player.GetPlayerCurrentWeapon(target);

        NAPI.Player.RemovePlayerWeapon(target, hashcode);
        }
    }

    [Command("checkstime")]
    public static void checkstimeCMD(Player client)
    {
        if (client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(client) < 1)
        {
            Main.SendErrorMessage(client, "Niste ovlasceni!");
            return;
        }
        DateTime serverTime = DateTime.Now;
        client.SendChatMessage($"Trenutno lokalno vreme na serveru je : {serverTime}");
    }

    [Command("bankreset")]
    public static void bresettest(Player client)
    {
        if (client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(client) < 8)
        {
            Main.SendErrorMessage(client, "Niste ovlasceni!");
            return;
        }
        bankRobbery.ResetBankRobbery();
    }

    public enum MessageType
    {
        Admin

    }

    public static string GetAdminName(Player client)
    {
        return AccountManage.GetCharacterName(client);
    }

    public static void MessageWithTag(Player Client, MessageType type, string message)
    {
        string Text = "~r~Doslo je do greske, pozovite skriptera!";
        switch (type)
        {
            case MessageType.Admin:
                Text = "~r~[Admin CMD] " + message;
                break;
            default:
                break;
        }
        Main.SendCustomChatMessasge(Client, Text);
    }

}

