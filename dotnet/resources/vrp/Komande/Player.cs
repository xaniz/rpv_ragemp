using GTANetworkAPI;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
class playerCommands : Script
{
    [Flags]
    public enum AnimationFlags
    {
        Loop = 1 << 0,
        StopOnLastFrame = 1 << 1,
        OnlyAnimateUpperBody = 1 << 4,
        AllowPlayerControl = 1 << 5,
        Cancellable = 1 << 7
    }

    [Command("dozvole",Alias ="showlicenses")]
    public static void ShowLicenses(Player player, string nameorid="")
    {
        if (nameorid == "")
        {
            nameorid = player.Value.ToString();
        }
        Player target = Main.findPlayer(player, nameorid);
        if (target != null)
        {
            if (player.Position.DistanceTo(target.Position) >= 5f)
            {
                Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Osoba nije dovoljno blizu!");
                return;
            }

            Main.SendCustomChatMessasge(target, "~y~--------------~g~ "+AccountManage.GetCharacterName(player)+" ~y~ Dozvole -----------------");
            if (player.GetData<dynamic>("character_car_lic") > 0)
            {
                Main.SendCustomChatMessasge(target, "~b~Dozvola za auto: ~g~IMA | Istice za: " + player.GetData<dynamic>("character_car_lic") + "");
            }
            else
            {
                Main.SendCustomChatMessasge(target, "~b~Dozvola za auto: ~r~ NEMA");
            }
            if (player.GetData<dynamic>("character_moto_lic") > 0)
            {
                Main.SendCustomChatMessasge(target, "~b~Dozvola za motor: ~g~IMA | Istice za: " + player.GetData<dynamic>("character_moto_lic") + "");

            }
            else
            {
                Main.SendCustomChatMessasge(target, "~b~Dozvola za motor: ~r~ NEMA");
            }

            if (player.GetData<dynamic>("character_fly_lic") > 0)
            {
                Main.SendCustomChatMessasge(target, "~b~Dozvola za letenje: ~g~IMA | Istice za: " + player.GetData<dynamic>("character_fly_lic") + "");

            }
            else
            {
                Main.SendCustomChatMessasge(target, "~b~Dozvola za letenje: ~r~ NEMA");
            }

            if (player.GetData<dynamic>("character_gun_lic") > 0)
            {
                Main.SendCustomChatMessasge(target, "~b~Dozvola za oruzije: ~g~IMA | Istice za: " + player.GetData<dynamic>("character_gun_lic") + "");

            }
            else
            {
                Main.SendCustomChatMessasge(target, "~b~Dozvola za oruzje: ~r~ NEMA");
            }
            if (player.GetData<dynamic>("character_fish_lic") > 0)
            {
                Main.SendCustomChatMessasge(target, "~b~Dozvola za pecanje: ~g~IMA | Istice za: " + player.GetData<dynamic>("character_fish_lic") + "");

            }
            else
            {
                Main.SendCustomChatMessasge(target, "~b~Dozvola za pecanje: ~r~ NEMA");
            }

            /*if (player.GetData<dynamic>("character_taxi_lic") > 0)
            {
                Main.SendCustomChatMessasge(target, "~b~Dozvola za prevoz putnika: ~g~ DA");
            }
            else
            {
                Main.SendCustomChatMessasge(target, "~b~Dozvola za prevoz putnika: ~r~ NE");

            }
            Main.SendCustomChatMessasge(target, "~y~-------------------------------");*/

        }
    }

    public static void privdance(Player player)
    {
        NAPI.Player.PlayPlayerAnimation(player, 1, "anim@mp_player_intcelebrationfemale@raining_cash", "raining_cash");
        NAPI.Particle.CreateLoopedParticleEffectOnEntity("ent_brk_banknotes","ent_brk_banknotes", player, new Vector3(0.0, 0.0, 1.0), new Vector3(0.0, 0.0, 0.0), 1, 60309, 0);
        player.TriggerEvent("privatedances");
        BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_cash_pile_01"), 60309, new Vector3(0.0, 0.0, 0), new Vector3(0, 0, 0));
        Main.GivePlayerMoney(player, -80);
        player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~- ~y~$80");
        
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(player))
            {
            NAPI.Player.StopPlayerAnimation(player);
            BasicSync.DetachObject(player);
            }
        }, delayTime: 4500);

    }


    [Command("showpass")]
    public void showpassport(Player player, string nameorid)
    {
        Player Target = Main.findPlayer(player, nameorid);

        if (Target.Exists)
        {
            InteractMenu_New.pSelected(player, Target, "showpas");
        }
        else
        {
            Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Osoba nije dovoljno blizu!");
        }
        return;
    }

    [Command("wanted")]
    public void showpassport(Player player)
    {
        player.SendChatMessage("Vas trenutni Wanted level je:~r~ "+ player.GetSharedData<dynamic>("character_wanted_level"));
    }

    [Command("vrata")]
    public void carcontrolcmd(Player player)
    {
        player.TriggerEvent("Display_cartool");
    }

    [Command("radio2")]
    public void ToggleRadio(Player Client)
    {
        if (Inventory.GetPlayerItemFromInventory(Client, 23) < 1)
        {
            Main.SendCustomChatMessasge(Client, "Greska: ~r~У Ne posedujete radio!");
            return;
        }
        Client.TriggerEvent("Toggle_Radio");
    }

    [RemoteEvent("setfreq")]
    public void Remote_Setfreq(Player Client, int freq)
    {
        if (Client.HasSharedData("Radio_Status") && Client.GetData<dynamic>("Radio_Status") != false)
        {
            command_Radio(Client, (ushort)freq);
        }
        else
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vas radio je isključen");
            return;
        }
    }

    [Command("setfreq")]
    public void command_Radio(Player Client, ushort freq)
    {
        if (freq <= 1 || freq >= 65535)
        {
            Main.SendCustomChatMessasge(Client, "Greska: ~y~Radio frekvencija mora biti u opsegu od 1 do 65535. ");
            return;
        }
        //int index = Inventory.GetInventoryIndexFromName(Client, "Radio");
        if (Inventory.GetPlayerItemFromInventory(Client, 23) < 1)
        {
            Main.SendCustomChatMessasge(Client,"Greska: ~r~Nemate radio.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE && freq >= 911 && freq <= 915)
        {
            InteractMenu_New.SendNotificationError(Client, "Ta frekvencija je zasticena.");
            return;
        }

        if (Client.HasSharedData("Radio_Status"))
        {
            if (Client.GetSharedData<dynamic>("Radio_Status") == true)
            {
                if (Client.GetData<dynamic>("status") == true)
                {
                    // Client.SetSharedData("RadioFreq", freq);
                    Radio.RadioSystem.Radio_Call(Client, freq);
                    Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.CenterRight, " Povezali ste se na frekvenciju" + freq + "");
                }
            }
        }

    }



    /*[Command("stats")]
    public static void command_stats(Player Client)
    {
        int new_level = (50 * (Client.GetData<dynamic>("character_level")) * (Client.GetData<dynamic>("character_level")) * (Client.GetData<dynamic>("character_level")) - 150 * (Client.GetData<dynamic>("character_level")) * (Client.GetData<dynamic>("character_level")) + 600 * (Client.GetData<dynamic>("character_level"))) / 5;

        Translation.ShowPlayerStats(Client, Client);

        Client.TriggerEvent("updateRankBar", Client.GetData<dynamic>("character_level"), new_level, Client.GetData<dynamic>("character_exp"), Client.GetData<dynamic>("character_exp"), Client.GetData<dynamic>("character_level"));
        Client.TriggerEvent("Display_playerstats");

    }*/

    [Command("stats")]
    public void PlayerStatsEvent(Player client) 
    {
        int level = client.GetData<dynamic>("character_level");
        int exp = client.GetData<dynamic>("character_exp");
        int rpvpoints = client.GetData<dynamic>("character_credits");
        string posao = Job_Controler.PlayerJobName(client);
        int skill = client.GetData<dynamic>("jobskill");
        string referral = client.GetData<dynamic>("refferal");
        int carlic = client.GetData<dynamic>("character_car_lic");
        int motolic = client.GetData<dynamic>("character_moto_lic");
        int flylic = client.GetData<dynamic>("character_fly_lic");
        int gunlic = client.GetData<dynamic>("character_gun_lic");
        int fishlic = client.GetData<dynamic>("character_fish_lic");
        string organisation = FactionManage.faction_data[AccountManage.GetPlayerGroup(client)].faction_name;
        string orgrank = FactionManage.faction_data[AccountManage.GetPlayerGroup(client)].faction_rank[AccountManage.GetPlayerRank(client)];

        client.TriggerEvent("Display_playerstats", level, exp, rpvpoints, posao, skill, referral, carlic, motolic, flylic, gunlic, fishlic, organisation, orgrank);
    }

    [Command("r", GreedyArg = true, Alias = "radio")]
    public void ChatRadio(Player Client, string chat)
    {
        if (Inventory.GetPlayerItemFromInventory(Client, 23) <= 0)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate radio!");
            return;
        }
        if (Client.HasSharedData("Radio_Status") == false || Client.GetSharedData<dynamic>("Radio_Status") == false)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vas radio je ugasen!");
            return;
        }
        if (Client.HasSharedData("RadioFreq") && Client.GetSharedData<dynamic>("RadioFreq") == 0)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Prvo podesite frekvenciju (/setfreq)!");
            return;
        }

        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (Client.GetSharedData<dynamic>("RadioFreq") == target.GetSharedData<dynamic>("RadioFreq") && target.GetSharedData<dynamic>("Radio_Status") == true)
            {
                Main.SendCustomChatMessasge(target,"~y~[RADIO] " + UsefullyRP.GetPlayerNameToTarget(Client, target) + " : ~y~" + chat);
            }

            if (Client.Position.DistanceTo(target.Position) < 15f && Client.Handle != target.Handle)
            {
                // NAPI.ClientEvent.TriggerClientEvent(Client, "Send_ToServer", "[Radio] Mige: " + chat);
                Main.SendCustomChatMessasge(target,UsefullyRP.GetPlayerNameToTarget(Client, target) + " ~w~(Radio): ~w~" + chat);
            }
        }
    }


    [Command("help", Alias = "pomoc", GreedyArg = true)]
    public void CMD_help(Player Client)
    {
        NAPI.ClientEvent.TriggerClientEvent(Client, "Display_Player_Help", AccountManage.GetPlayerJob(Client), AccountManage.GetPlayerLeader(Client), FactionManage.GetPlayerGroupID(Client), AccountManage.GetPlayerRank(Client));

        NAPI.Task.Run(() =>
        {
            if (!Client.Exists) return;

            Client.TriggerEvent("Show_Cursor");
        }, delayTime: 500);
    }


    [Command("id", "Koristite:/id [id/DeoImena]")]
    public void GetPlayerId(Player sender, string idOrName)
    {
        if (sender.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(sender, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(sender) < 2)
        {
            return;
        }

        Player target = Main.findPlayer(sender, idOrName);
        if (target != null)
        {
            Main.SendCustomChatMessasge(sender, string.Format("~w~{0} ~w~(ID:~y~ {1}~w~) (Ping:~y~ {2}~w~)", AccountManage.GetCharacterName(target), Main.getIdFromClient(target), NAPI.Player.GetPlayerPing(target)));
        }

    }

    [Command("members", Alias = "clanovi")]
    public void CMD_membros(Player Client)
    {
        if (FactionManage.GetPlayerGroupID(Client) == 0)
        {
            return;
        }
        int faction = AccountManage.GetPlayerGroup(Client);

        Main.SendCustomChatMessasge(Client,"<font color='#418756'>(( [" + FactionManage.faction_data[faction].faction_name + "] Lista clanova ))");
        var players = NAPI.Pools.GetAllPlayers();
        foreach (var target in players)
        {
            if (target.GetData<dynamic>("status") == true)
            {
                if (AccountManage.GetPlayerGroup(target) == faction)
                {
                    int rank = AccountManage.GetPlayerRank(target);
                    if (FactionManage.GetPlayerGroupType(Client) != 4)
                    {
                        if (target.HasData("duty") && target.GetData<dynamic>("duty") == 1)
                        {
                            Main.SendCustomChatMessasge(Client, "<font color='#57b573'> " + AccountManage.GetCharacterName(target) + " (id: " + Main.getIdFromClient(target) + ") - Rank: " + FactionManage.faction_data[faction].faction_rank[rank] + " (" + rank + ")  ~g~Na duznosti ");
                        }
                        else
                        {
                            Main.SendCustomChatMessasge(Client, "<font color='#57b573'> " + AccountManage.GetCharacterName(target) + " (id: " + Main.getIdFromClient(target) + ") - Rank: " + FactionManage.faction_data[faction].faction_rank[rank] + " (" + rank + ")  ~r~Van duznosti");
                        }
                    }
                    else
                    {
                        Main.SendCustomChatMessasge(Client, "<font color='#57b573'> " + AccountManage.GetCharacterName(target) + " (id: " + Main.getIdFromClient(target) + ") - Rank: " + FactionManage.faction_data[faction].faction_rank[rank] + " (" + rank + ")");
                    }
                }
            }
        }
    }


    [Command("steal", Alias = "ukradi, pokradi, stealmoney")]
    public void CMD_mug(Player Client, string idOrName)
    {
        Player target = Main.findPlayer(Client, idOrName);

        if (target == null)
        {
            return;
        }

        if (FactionManage.GetPlayerGroupID(Client) != 4)
        {
            Main.SendErrorMessage(Client, "Ne mozete to!");
            return;
        }


        if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 2.0f))
        {
            Main.SendErrorMessage(Client, "Niste pored igraca.");
            return;
        }

        if (target.HasData("mug_timeout") && target.GetData<dynamic>("mug_timeout") < DateTime.Now)
        {
            Main.SendErrorMessage(Client, "Neko je vec opljackao ovog igraca.");
            return;
        }

        if (target.GetData<dynamic>("handsup") == false)
        {
            Main.SendErrorMessage(Client, "Igrac nije podigao ruke.");
            return;
        }

        if (Main.GetPlayerMoney(target) < 2)
        {
            Main.SendErrorMessage(Client, "Igrac nema novac.");
            return;
        }

        int money = Main.GetPlayerMoney(target) / 2;

        Main.GivePlayerMoney(Client, money);
        Main.GivePlayerMoney(target, -money);


        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
        foreach (Player alvo in proxPlayers)
        {
            alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " gura ruku u " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + " dzep i krade $" + money + ".");
        }

        target.SetData<dynamic>("mug_timeout", DateTime.Now.AddMinutes(15));

    }

    // Chat commands
    [Command("me", Alias = "rpme", GreedyArg = true)]
    public void ME_Command(Player Client, string poruka)
    {
        UsefullyRP.SendRoleplayAction(Client, poruka);
    }

    [Command("do", GreedyArg = true)] // do command 
    public void DO_Command(Player Client, string poruka)
    {

        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
        foreach (Player target in proxPlayers)
        {
            Main.SendCustomChatMessasge(target, "<font color ='#C2A2DA'>* " + poruka + " ((" + UsefullyRP.GetPlayerNameToTarget(Client, target) + "))");
            //target.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + poruka + " ((" + UsefullyRP.GetPlayerNameToTarget(Client, target) + "))");
        }

        //Main.EmoteMessage(Client, "(( " + poruka + " ))");

    }

    [Command("s", Alias = "shout", GreedyArg = true)]
    public void S_Command(Player Client, string poruka)
    {
        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(30, Client);
        foreach (Player target in proxPlayers)
        {

            if (target.Dimension == Client.Dimension)
            {
                Main.SendCustomChatMessasge(target, UsefullyRP.GetPlayerNameToTarget(Client, target) + " " + "se dere: " + Main.EMBED_WHITE + " " + poruka + " !!");
            }

        }

    }

    [Command("skiniwl")]
    public void Skiniwl_Command(Player Client, int wanted)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(791.54, 2176.50, 52.64), 3f))
            {

            
            int tw = Client.GetSharedData<dynamic>("character_wanted_level");
            int price = wanted * 3000;
            if (wanted > tw)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate toliko WantedLevela");
                return;
            }
            if (Main.GetPlayerMoney(Client) < price)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                return;
            }
            Main.GivePlayerMoney(Client, -price);
            Police.wantedlevelminus(Client, -wanted);
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Uspesno ste skinuli "+wanted+" WL za $"+price+"");
        }
    }

    [Command("w", GreedyArg = true)]
    public void W_Command(Player Client, string poruka)
    {
        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(3f, Client);
        foreach (Player target in proxPlayers)
        {
            if (target.Dimension == Client.Dimension)
            {
                Main.SendCustomChatMessasge(target, Main.EMBED_GREY + UsefullyRP.GetPlayerNameToTarget(Client, target) + " " + Main.EMBED_GREY + "tiho: " + " " + poruka);
            }
            //target.TriggerEvent("Send_ToChat", "", UsefullyRP.GetPlayerNameToTarget(Client, target) + " " + Main.EMBED_GREY + "sussurra: " + Main.EMBED_WHITE + " " + poruka);
        }
    }

    [Command("b", GreedyArg = true, Alias = "ooc")]
    public void B_Command(Player Client, string poruka)
    {
        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(20f, Client);

        foreach (Player target in proxPlayers)
        {
            if (target.Dimension == Client.Dimension)
            {
                Main.SendCustomChatMessasge(target, "" + "~b~(( " + Main.EMBED_WHITE + "" + UsefullyRP.GetPlayerNameToTarget(Client, target) + ": " + poruka + " " + "~b~))");
            }
            //target.TriggerEvent("Send_ToChat", "", "" + Main.EMBED_SERVER + "(( " + Main.EMBED_WHITE + "[OOC Local] " + UsefullyRP.GetPlayerNameToTarget(Client, target) + ": " + poruka + " " + Main.EMBED_SERVER + "))");
        }
    }




    [Command("f", Alias = "faction", GreedyArg = true)]
    public void CMD_faction(Player Client, string poruka)
    {
        if (FactionManage.GetPlayerGroupType(Client) == 4 || AccountManage.GetPlayerRank(Client) == -1)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }

        int faction = AccountManage.GetPlayerGroup(Client);
        int rank = AccountManage.GetPlayerRank(Client);

        var players = NAPI.Pools.GetAllPlayers();

        foreach (Player c in players)
        {
            if (c.GetData<dynamic>("status") == true)
            {
                if (AccountManage.GetPlayerGroup(c) == faction)
                {
                    Main.SendMessageWithTagToPlayer(c, "" + Main.EMBED_CYAN + "** (( ", "" + Main.EMBED_CYAN + "" + " " + AccountManage.GetCharacterName(Client) + " " + poruka + "" + " )) **");
                    //Main.EmoteMessage(Client, "(Faction) " + poruka + "");
                }
            }
        }
    }


    [Command("accept")]
    public void CMD_aceitar(Player Client, string nome)
    {
       
        if (nome == "heal")
        {
            if (Client.GetData<dynamic>("curar_offerPrice") != 0)
            {
                if (!AccountManage.GetPlayerConnected(Client.GetData<dynamic>("curar_offerBy")))
                {
                    Client.SetData<dynamic>("curar_offerBy", null);
                    Client.SetData<dynamic>("curar_offerPrice", 0);

                    Main.SendErrorMessage(Client, "Niko Vam nije ponudio lecenje ili je doktor napustio server.");
                    return;
                }
                if (Main.GetPlayerMoney(Client) < Client.GetData<dynamic>("curar_offerPrice"))
                {
                    Client.SetData<dynamic>("curar_offerBy", null);
                    Client.SetData<dynamic>("curar_offerPrice", 0);
                    Main.SendErrorMessage(Client, "Nemate dovoljno novca.");
                    return;
                }

                if (!Main.IsInRangeOfPoint(Client.Position, NAPI.Entity.GetEntityPosition(Client.GetData<dynamic>("curar_offerBy")), 30))
                {
                    Client.SetData<dynamic>("curar_offerBy", null);
                    Client.SetData<dynamic>("curar_offerPrice", 0);
                    Main.SendErrorMessage(Client, "Niste pored doktora.");
                    return;
                }

                NAPI.Player.SetPlayerHealth(Client, 100);

                Main.SendSuccessMessage(Client, "" + AccountManage.GetCharacterName(Client.GetData<dynamic>("curar_offerBy")) + "~w~ Vas je izlecio za ~g~$" + Client.GetData<dynamic>("curar_offerPrice").ToString("N0") + "~w~.");
                Main.SendCustomChatMessasge(Client.GetData<dynamic>("curar_offerBy"), "Doktor je izlecio igraca ~y~" + AccountManage.GetCharacterName(Client) + "~w~ za ~g~$" + Client.GetData<dynamic>("curar_offerPrice").ToString("N0") + "~w~.");

                Main.GivePlayerMoney(Client, -Client.GetData<dynamic>("curar_offerPrice"));
                Main.GivePlayerMoney(Client.GetData<dynamic>("curar_offerBy"), Client.GetData<dynamic>("curar_offerPrice"));

                Client.SetData<dynamic>("curar_offerBy", null);
                Client.SetData<dynamic>("curar_offerPrice", 0);
            }
        }
        else if (nome == "invite")
        {
            if (Client.GetData<dynamic>("group_invite") != -1)
            {
                if (FactionManage.GetPlayerGroupID(Client) == 1)
                {
                    return;
                }
                int group_id = Client.GetData<dynamic>("group_invite");
                Player inviteBy = Client.GetData<dynamic>("group_inviteBy");

                if (Main.IsPlayerLogged(inviteBy) == true)
                {
                    FactionManage.SendFactionMessage(inviteBy, "~w~ Pozvali ste ~g~" + UsefullyRP.GetPlayerNameToTarget(Client, inviteBy) + ".");
                    FactionManage.SendFactionMessage(Client, "~w~ Prihvatili ste poziv ~g~" + UsefullyRP.GetPlayerNameToTarget(inviteBy, Client) + "~w~ i pridruzili se organizaciji.");

                    AccountManage.SetPlayerLeader(Client, 0);
                    AccountManage.SetPlayerGroup(Client, group_id);
                    AccountManage.SetPlayerRank(Client, 0);
                    Client.TriggerEvent("factionchange", group_id);

                    FactionManage.SaveFaction(group_id);
                    Client.SetData<dynamic>("group_invite", -1);
                    Client.SetData<dynamic>("group_inviteBy", -1);
                }
                else
                {
                    Client.SetData<dynamic>("group_invite", -1);
                    Client.SetData<dynamic>("group_inviteBy", -1);

                    InteractMenu_New.SendNotificationError(Client, "Igrac koji Vas je pozvao vise nije dostupan.");
                }
            }
            else InteractMenu_New.SendNotificationError(Client, "Igrac koji Vas je pozvao vise nije dostupan.");

        }

    }

    [Command("invite", "Koristite: /invite [id/DeoImena]")]
    public void CMD_convidar(Player Client, string idOrName)
    {

        Player target = Main.findPlayer(Client, idOrName);
        if (AccountManage.GetPlayerLeader(Client) < 1 && AccountManage.GetPlayerLeader(Client) > FactionManage.MAX_FACTIONS)
        {
            Main.SendErrorMessage(Client, "Niste lider!");
            return;
        }
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Pogresan ID!");
                return;
            }
            if (target.GetData<dynamic>("character_level") < 3)
            {
                Main.SendErrorMessage(Client, "Igrac nije level 3.");
                return;
            }
            if (AccountManage.GetPlayerGroup(target) != 0)
            {
                Main.SendErrorMessage(Client, "Igrac je vec u nekoj organizaciji.");
                return;
            }

            if (target.GetData<dynamic>("group_invite") != -1)
            {
                Main.SendErrorMessage(Client, "Neko je vec pozvao ovog igraca.");
                return;
            }
            if (target.Position.DistanceTo(Client.Position) > 4)
            {
                Main.SendErrorMessage(Client, "Morate biti pored igraca koga pozivate u organizaciju.");
                return;
            }

            int group_id = AccountManage.GetPlayerGroup(Client);
            target.SetData<dynamic>("group_invite", AccountManage.GetPlayerGroup(Client));
            target.SetData<dynamic>("group_inviteBy", Client);

            FactionManage.SendFactionMessage(target," ~g~"+ UsefullyRP.GetPlayerNameToTarget(Client, target)+ "~w~ Vas poziva da se pridruzite ~b~" + FactionManage.faction_data[group_id].faction_name + "~w~.");

            FactionManage.SendFactionMessage(Client, "Pozvali ste ~g~" + UsefullyRP.GetPlayerNameToTarget(target, Client) + "~w~ da se pridruzi Vasoj organizaciji.");

            faction_blip.RemoveBlip(target);

            NAPI.Task.Run(() =>
            {
                if (NAPI.Player.IsPlayerConnected(target))
                {
                target.SetData<dynamic>("group_inviteBy", -1);
                target.SetData<dynamic>("group_invite", -1);
                }
            }, delayTime: 30 * 1000);

        }

    }


    [Command("uninvite ", "Koristite: /uninvite  [id/DeoImena]")]
    public void CMD_expulsar(Player Client, string idOrName)
    {

        Player target = Main.findPlayer(Client, idOrName);

        if (AccountManage.GetPlayerLeader(Client) < 1 && AccountManage.GetPlayerLeader(Client) > FactionManage.MAX_FACTIONS)
        {
            Main.SendErrorMessage(Client, "Niste lider.");
            return;
        }
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Pogresan ID.");
                return;
            }

            int group_id = AccountManage.GetPlayerGroup(Client);

            if (AccountManage.GetPlayerGroup(target) != group_id)
            {
                Main.SendErrorMessage(Client, "Igrac nije clan Vase organizacije.");
            }

            Main.SendCustomChatMessasge(target, " ~b~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(Client)] + " " + AccountManage.GetPlayerGroup(Client) + "~w~ Vas je izbacio iz ~g~" + FactionManage.faction_data[group_id].faction_name + "~w~.");

            Main.SendCustomChatMessasge(Client, "Izbacili ste " + AccountManage.GetCharacterName(target) + " iz " + FactionManage.faction_data[group_id].faction_name + ".");

            NAPI.Data.SetEntityData(target, "duty", 0);
            Main.UpdatePlayerClothes(target);
            target.SetData<dynamic>("duty", 0);
            Outfits.RemovePlayerDutyOutfit(target);
            AccountManage.SetPlayerLeader(target, 0);
            AccountManage.SetPlayerGroup(target, 0);
            AccountManage.SetPlayerRank(target, 0);
            Main.SavePlayerInformation(target);
            faction_blip.RemoveBlip(target);

        }

    }

    [Command("promote", "Koristite: /promote [id/DeoImena]")]
    public void CMD_promover(Player Client, string idOrName)
    {

        Player target = Main.findPlayer(Client, idOrName);

        if (AccountManage.GetPlayerLeader(Client) < 1 && AccountManage.GetPlayerLeader(Client) > FactionManage.MAX_FACTIONS)
        {
            Main.SendErrorMessage(Client, "Niste lider.");
            return;
        }
        if (target != null)
        {
            if (target == Client)
            {
                Main.SendErrorMessage(Client, "Zasto pokusavas sebi da das rank");
                return;
            }
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Igrac nije clan Vase organizacije.");
                return;
            }
            int group_id = AccountManage.GetPlayerGroup(Client);

            if (AccountManage.GetPlayerGroup(target) != group_id)
            {
                Main.SendErrorMessage(Client, "Igrac nije clan Vase organizacije.");
            }

            if (AccountManage.GetPlayerRank(target) == FactionManage.GetMaxRank(group_id) - 1)
            {
                Main.SendErrorMessage(Client, "Ne mozete unaprediti ovog igraca zato sto on ima najvisi rank.");
                return;
            }

            Main.SendCustomChatMessasge(target, " ~b~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(Client)] + " " + AccountManage.GetPlayerGroup(Client) + "~w~ Vas je promovisao na rank ~g~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(target) + 1] + "~w~.");

            Main.SendCustomChatMessasge(Client, "Postavili ste " + AccountManage.GetCharacterName(target) + " rank na " + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(target) + 1] + ".");

            AccountManage.SetPlayerRank(target, AccountManage.GetPlayerRank(target) + 1);
        }
    }



    [Command("demote", "Koristite: /demote [id/DeoImena]")]
    public void CMD_rebaixar(Player Client, string idOrName)
    {

        Player target = Main.findPlayer(Client, idOrName);
        if (AccountManage.GetPlayerLeader(Client) < 1 && AccountManage.GetPlayerLeader(Client) > FactionManage.MAX_FACTIONS)
        {
            Main.SendErrorMessage(Client, "Niste lider.");
            return;
        }
        if (target != null)
        {
            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Pogresan ID.");
                return;
            }
            int group_id = AccountManage.GetPlayerGroup(Client);

            if (AccountManage.GetPlayerGroup(target) != group_id)
            {
                Main.SendErrorMessage(Client, "Igrac nije clan Vase organizacije.");
            }

            if (AccountManage.GetPlayerRank(target) == 0)
            {
                Main.SendErrorMessage(Client, "Igrac je vec najnizi rank.");
                return;
            }

            Main.SendCustomChatMessasge(target, " ~b~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(Client)] + " " + AccountManage.GetPlayerGroup(Client) + "~w~ Vam je dao rank  ~g~" + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(target) - 1] + "~w~.");

            Main.SendCustomChatMessasge(Client, "Postavili ste " + AccountManage.GetCharacterName(target) + " rank na " + FactionManage.faction_data[group_id].faction_rank[AccountManage.GetPlayerRank(target) - 1] + ".");

            AccountManage.SetPlayerRank(target, AccountManage.GetPlayerRank(target) - 1);
        }

    }
}