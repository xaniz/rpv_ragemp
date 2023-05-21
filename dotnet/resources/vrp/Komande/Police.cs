using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

class policeCommands : Script
{

    [Command("pokaziznacku")]
    public void show_badge(Player client, string ID)
    {
        if (AccountManage.GetPlayerGroup(client) != 1)
        {
            Main.SendCustomChatMessasge(client,"~r~" + Translation.message_error + " Nemate znacku!");
            return;
        }
        UsefullyRP.SendRoleplayAction(client, "vadi sluzbenu legitimaciju i pokazuje je osobi.");
        /* List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiKoriscenjefPlayer(15, client);
         foreach (Player target in proxPlayers)
         {
             //target.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + poruka + " ((" + UsefullyRP.GetPlayerNameToTarget(Client, target) + "))");
             Main.SendCustomChatMessasge(Client,"<font color ='#C2A2DA'>* " + "Esm Kamel: " + AccountManage.GetCharacterName(client) + " Daraje: " + FactionManage.faction_data[AccountManage.GetPlayerGroup(client)].faction_rank[AccountManage.GetPlayerRank(client)] + " Shomare Neshan: " + AccountManage.GetPlayerSQLID(client) + " ((" + UsefullyRP.GetPlayerNameToTarget(client, target) + "))");
         }*/
        Player target = Main.findPlayer(client, ID);
        if (!target.Exists)
        {
            return;
        }
        target.TriggerEvent("Display_Badge", AccountManage.GetCharacterName(client), FactionManage.faction_data[AccountManage.GetPlayerGroup(client)].faction_rank[AccountManage.GetPlayerRank(client)], AccountManage.GetPlayerSQLID(client));

    }

    [Command("znacka")]
    public void ToggleBadge(Player player)
    {
        if (!Main.IsInRangeOfPoint(player.Position, new Vector3(469.00632, -988.65173, 25.729673), 2.0f)) return;
        if (AccountManage.GetPlayerGroup(player) != 1)
        {
            Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Niste policajac!");
            return;
        }
        Police.ChangeBadgeStatus(player);
        if (player.GetSharedData<dynamic>("badgeon"))
        {
            NAPI.Notification.SendNotificationToPlayer(player, Translation.notification_11);
            player.SetData<dynamic>("duty", 1);
            Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Stavili ste znacku.");
        }
        else
        {
                NAPI.Notification.SendNotificationToPlayer(player, Translation.notification_12);
                Outfits.RemovePlayerDutyOutfit(player);
                Main.UpdatePlayerClothes(player);
                NAPI.Player.SetPlayerArmor(player, 0);
            Main.DisplayErrorMessage(player, NotifyType.Warning, NotifyPosition.BottomCenter, "Skinuli ste znacku.");
            
        }
    }

    [Command("spust")]
    public void rapple(Player Client)
    {
        if (!Client.IsInVehicle)
        {
            return;
        }
        if (Client.Vehicle.DisplayName.ToLower() != "polmav")
        {
            return;
        }
        if (AccountManage.GetPlayerGroup(Client) != 1)
        {
            Main.SendCustomChatMessasge(Client,"~r~" + Translation.message_error + "Niste obuceni za ovo!");
            return;
        }
        if (NAPI.Player.GetPlayerVehicleSeat(Client) == (int)VehicleSeat.RightRear || NAPI.Player.GetPlayerVehicleSeat(Client) == (int)VehicleSeat.LeftRear)
        {
            foreach (var item in NAPI.Player.GetPlayersInRadiusOfPlayer(500, Client))
            {
                item.TriggerEvent("rappel", Client);
            }
            Main.SendCustomChatMessasge(Client,"Spustate se.");
            Main.EmoteMessage(Client, "se spusta.");
        }


    }
    [Command("lociraj")]
    public void find_phone(Player client, string idOrname)
    {
        if (client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (AccountManage.GetPlayerGroup(client) != 1)
        {
            Main.SendCustomChatMessasge(client, Translation.message_error + "Nemate mogucnosti da koristite ovu opciju!");
            return;
        }
        if (client.HasData("lc_Timeout") && client.GetData<dynamic>("lc_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
        {
            Main.DisplaySubtitle(client, "~y~[Ovu komandu mozete koristiti svakih 30 sec]", 2);
            return;
        }
        client.SetData<dynamic>("lc_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 30000);
        Player target = Main.findPlayer(client, idOrname);
        if (target != null)
        {
            Random random = new Random();

            float xOffset = (float)random.Next(-250, 251);
            float yOffset = (float)random.Next(-250, 251);
            float zOffset = (float)random.Next(-250, 251);
        Vector3 position = target.Position + new Vector3(xOffset, yOffset, zOffset);
        Main.SendCustomChatMessasge(client, "Lociran u radijusu od +-250 metara od tacke na radaru");
        Trigger.ClientEvent(client, "createWLBlip", position);
        NAPI.Task.Run(() =>
        {
            if (!NAPI.Player.IsPlayerConnected(client)) return;
            Trigger.ClientEvent(client, "deleteWLBlip");
        }, delayTime: 30000);
        }
        else
        {
            Main.SendCustomChatMessasge(client, Translation.message_error + "Igrac nije online!");
            return;
        }

    }

    [RemoteEvent("locateplayer")]
    public void find_phone2(Player client, string idOrname)
    {
        if (client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (AccountManage.GetPlayerGroup(client) != 1)
        {
            Main.SendCustomChatMessasge(client, Translation.message_error + "Nemate mogucnosti da koristite ovu opciju!");
            return;
        }
        if (client.HasData("lc_Timeout") && client.GetData<dynamic>("lc_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
        {
            Main.DisplaySubtitle(client, "~y~[Ovu komandu mozete koristiti svakih 30 sec]", 2);
            return;
        }
        client.SetData<dynamic>("lc_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 30000);
        Player target = Main.findPlayer(client, idOrname);
        if (target != null)
        {
            Random random = new Random();

            float xOffset = (float)random.Next(-250, 251);
            float yOffset = (float)random.Next(-250, 251);
            float zOffset = (float)random.Next(-250, 251);
        Vector3 position = target.Position + new Vector3(xOffset, yOffset, zOffset);
        Main.SendCustomChatMessasge(client, "Lociran u radijusu od +-250 metara od tacke na radaru");
        Trigger.ClientEvent(client, "createWLBlip", position);
        NAPI.Task.Run(() =>
        {
            if (!NAPI.Player.IsPlayerConnected(client)) return;
            Trigger.ClientEvent(client, "deleteWLBlip");
        }, delayTime: 30000);
        }
        else
        {
            Main.SendCustomChatMessasge(client, Translation.message_error + "Igrac nije online!");
            return;
        }

    }

    [Command("pojacanje", Alias = "sos")]
    public void command_panic(Player Client)
    {
        if (FactionManage.GetPlayerGroupID(Client) != 1) { Main.SendCustomChatMessasge(Client,"~r~Niste ovlasceni!"); return; }
        if (Client.GetData<dynamic>("duty") == 0) { Main.SendCustomChatMessasge(Client,"~r~ Niste na duznosti!"); return; }
        if (Client.GetData<dynamic>("playerCuffed") == 1) { Main.SendCustomChatMessasge(Client,"~r~ Ne mozete to!"); return; }
        if (Client.GetData<dynamic>("PD_Panic") == 0)
        {
            Client.SetData<dynamic>("PD_Panic", 1);
            Client.TriggerEvent("createNewHeadNotificationAdvanced", "~r~Panic ~g~ taster je upaljen!");
            Main.EmoteMessage(Client, "Upalili ste panic alarm.");
            foreach (Player pl in NAPI.Pools.GetAllPlayers())
            {
                if (FactionManage.GetPlayerGroupID(pl) == FactionManage.FACTION_TYPE_POLICE && pl.GetData<dynamic>("duty") == 1 && Client != pl)
                {
                    Main.SendCustomChatMessasge(pl, "[~y~PANIC ALARM~w~] <font color='#E86153'> Oglasio se panic alarm!");
                }
            }
        }
        else 
        {
            Client.SetData<dynamic>("PD_Panic", 0);
            Client.TriggerEvent("createNewHeadNotificationAdvanced", "~r~Panic ~g~ taster je ugasen!");
        }
        
    }


    [Command("dep", "Koristite: /dep(artment) [tekst]", Alias = "d", GreedyArg = true)]
    public void CMD_departamento(Player Client, string poruka)
    {

        if (AccountManage.GetPlayerGroup(Client) == 0)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }
        if (AccountManage.GetPlayerRank(Client) == -1)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE && FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_MEDIC)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }
        int faction = AccountManage.GetPlayerGroup(Client);
        int rank = AccountManage.GetPlayerRank(Client);

        var players = NAPI.Pools.GetAllPlayers();
        
        if (faction == 1)
        {
            Client.SetData<string>("f1", "Policija");
        }
        if (faction == 2)
        {
            Client.SetData<string>("f1", "EMS");
        }
        foreach (Player c in players)
        {
            if (c.GetData<dynamic>("status") == true)
            {
                if (FactionManage.GetPlayerGroupID(c) == FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupID(c) == FactionManage.FACTION_TYPE_MEDIC)
                {
                    Main.SendCustomChatMessasge(c, "<font color='#FF6347'> **"+ Client.GetData<string>("f1") +" "+ UsefullyRP.GetPlayerNameToTarget(Client, c) + " : " + poruka + " **");
                }
            }
        }

    }

    [Command("m", "Koristite: /m(egaphone) [tekst]", Alias = "megaphone", GreedyArg = true)]
    public void CMD_megafone(Player Client, string poruka)
    {
        if (AccountManage.GetPlayerGroup(Client) == 0)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }
        if (Client.GetData<dynamic>("duty") == 0)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste na duznosti.");
            return;
        }

            int faction = AccountManage.GetPlayerGroup(Client);
            int rank = AccountManage.GetPlayerRank(Client);

            List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(45, Client);
            foreach (Player target in proxPlayers)
            {
                target.TriggerEvent("Send_ToChat", "", " <font color='#fbff00'>" + UsefullyRP.GetPlayerNameToTarget(Client, target) + " <font color='#fbff00'>(MEGAPHONE): <font color='#fbff00'>" + poruka.ToUpper());
            }

    }
    [Command("arrest", "Koristite: /arrest [ID/DeoImena]")]
    public void CMD_prender(Player Client, string idOrname)
    {
        if (AccountManage.GetPlayerGroup(Client) == 0)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }
        if (AccountManage.GetPlayerRank(Client) == -1)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(458.63, -985.65, 34.20), 3.0f) || Main.IsInRangeOfPoint(Client.Position, new Vector3(458.34, -1008.04, 28.27), 3.0f))
        {
            Player target = Main.findPlayer(Client, idOrname);
            if (target != null)
            {
            if (Main.IsInRangeOfPoint(target.Position, Client.Position, 3) && Client != target)
            {
                int wl = target.GetSharedData<dynamic>("character_wanted_level");
                if (target.GetData<dynamic>("BeingDragged") == true)
                {
                    InteractMenu_New.SendNotificationError(Client, "Morate prvo pustiti igraca.");
                    return;
                }

                int minutes = 0;
                if (wl == 0)
                {
                    Client.SendNotification("Ne mozete uhapsiti igraca koji nema WL.");
                    return;
                }
                else if (wl > 0)
                {
                    minutes = wl * 5 * 60;
                }

                int tkazna = wl * 2000;
                int preward = wl * 1000;
                Main.GivePlayerMoney(target, tkazna);
                Main.GivePlayerMoney(Client, preward);

                NAPI.Notification.SendNotificationToPlayer(target, "~w~" + AccountManage.GetCharacterName(Client) + " Vas je uhapsio na " + minutes + "~w~ sekundi.");
                NAPI.Notification.SendNotificationToPlayer(Client, "Uhapsili ste " + AccountManage.GetCharacterName(target) + " na " + minutes + "~w~ sekundi.");


                Client.TriggerEvent("createNewHeadNotificationAdvanced", "Uhapsili ste " + AccountManage.GetCharacterName(target) + "~w~ na " + minutes + "~w~ sekundi.");

                int count = 0;
                foreach (var teste in Main.prison_spawns)
                {
                    count++;
                }
                Random rnd = new Random();
                int index = rnd.Next(0, count);

                NAPI.Entity.SetEntityPosition(target, Main.prison_spawns[index].position);
                target.Rotation = Main.prison_spawns[index].rotation;

                NAPI.Player.SetPlayerClothes(target, 1, 0, 0);
                NAPI.Player.SetPlayerClothes(target, 5, 0, 0);
                NAPI.Player.SetPlayerClothes(target, 1, 0, 0);
                NAPI.Player.SetPlayerClothes(target, 7, 0, 0);
                NAPI.Player.SetPlayerClothes(target, 9, 0, 0);
                NAPI.Player.SetPlayerClothes(target, 10, 0, 0);

                NAPI.Player.ClearPlayerAccessory(target, 0);
                NAPI.Player.ClearPlayerAccessory(target, 1);
                NAPI.Player.ClearPlayerAccessory(target, 2);
                NAPI.Player.ClearPlayerAccessory(target, 6);
                NAPI.Player.ClearPlayerAccessory(target, 7);

                NAPI.Player.SetPlayerClothes(target, 4, 3, 7);
                NAPI.Player.SetPlayerClothes(target, 11, 5, 0);
                NAPI.Player.SetPlayerClothes(target, 3, 5, 0);
                NAPI.Player.SetPlayerClothes(target, 8, 0, 18);
                NAPI.Player.SetPlayerClothes(target, 6, 8, 0);

                target.SetData<dynamic>("character_prison", 1);
                target.SetData<dynamic>("character_prison_cell", index);
                target.SetData<dynamic>("character_prison_time", minutes);
                target.SetSharedData("character_wanted_level", 0);

                target.SetData<dynamic>("playerCuffed", 0);
                target.StopAnimation();

                target.TriggerEvent("freezeEx", false);
                target.TriggerEvent("setFollow", false, Client);

                cellphoneSystem.FinishCall(target);
                return;
            }
            } else {
                Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Niste na mestu za hapsenje!");
            }
        }
        
        InteractMenu_New.SendNotificationError(Client, "Igrac nije pored Vas.");
    }

    [Command("su", "Koristite: /su [ID/DeoImena] [Zvezdica]")]
    public void CMD_mandato(Player p, string idOrName, int Zvezdica)
    {
        Player target = Main.findPlayer(p, idOrName);
        if (Zvezdica < 1)
        {
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, "Niste uneli validan wanted level");
            return;
        }
        if (Zvezdica > 10)
        {
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, "Maksimalan wanted level je 10");
            return;
        }
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, " Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, " Niste ovlasceni.");
            return;
        }
        Police.SetPlayerCrime(target, Zvezdica);
        NAPI.Notification.SendNotificationToPlayer(p, "Setovali ste wanted level igracu: " + AccountManage.GetCharacterName(target) + "");
    }

    [Command("ocistiwl")]
    public void CMD_ocistiwl(Player p, string idOrName)
    {
        if (AccountManage.GetPlayerLeader(p) < 1 && FactionManage.GetPlayerGroupID(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(p, "Niste lider!");
            return;
        }
        Player target = Main.findPlayer(p, idOrName);
        int wanted = target.GetSharedData<dynamic>("character_wanted_level");
        Police.SetPlayerCrime(target, -wanted);
        NAPI.Notification.SendNotificationToPlayer(p, "Ocistili ste wanted level igracu: " + AccountManage.GetCharacterName(target) + "");
    }

    [Command("frisk", "Koriscenje: /frisk [ID/DeoImena]")]
    public void CMD_revistar(Player p, string idOrName)
    {

        
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, " Koristiti dugme I dok suspect ima podignute ruke.");
            return;

    }

    [Command("frisktrunk")]
    public void CMD_revistarveiculo(Player p)
    {
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, " Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, " Niste ovlasceni.");
            return;
        }

        Vehicle vehicle = Utils.GetClosestVehicle(p, 5.0f);

        if (NAPI.Entity.DoesEntityExist(vehicle))
        {
            if (NAPI.Data.HasEntityData(vehicle, "MAX_VEHICLE_SLOT"))
            {
                if (NAPI.Data.GetEntityData(vehicle, "MAX_VEHICLE_SLOT") > 0)
                {
                    Main.SendCustomChatMessasge(p,"~w~-----------------------------");
                    Main.SendCustomChatMessasge(p,"~g~Gepek");
                    List<dynamic> menu_item_list = new List<dynamic>();
                    for (int i = 0; i < 30; i++)
                    {
                        if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0)
                        {
                            if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
                            {
                                Main.SendCustomChatMessasge(p, "(Stvari) ~c~" + Inventory.itens_available[NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type")].name + " ~w~(" + NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") + ")");
                            }
                        }
                    }
                    Main.SendCustomChatMessasge(p,"~w~-----------------------------");
                    return;
                }
            }
        }
        Main.SendErrorMessage(p, "* Ne mozete to!");
    }


    [Command("takeitem", "Koristite: /takeitem [ID/DeoImena] [Item]")]
    public void CMD_confiscaritem(Player p, string idOrName, string itemName)
    {

        Player target = Main.findPlayer(p, idOrName);
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, " Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, " Niste ovlasceni.");
            return;
        }

        if (target == null)
        {
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, " Pogresan ID!");
            return;
        }

        int playerid = Main.getIdFromClient(target);

        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
        {
            if (Inventory.player_inventory[playerid].type[index] != 0 && Inventory.player_inventory[playerid].type[index] < Inventory.itens_available.Count)
            {
                if (Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name == itemName)
                {
                    if (Inventory.player_inventory[playerid].amount[index] > 0)
                    {

                        Main.SendSuccessMessage(p, "Oduzeli ste " + Inventory.player_inventory[playerid].amount[index] + " " + Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name + " od " + AccountManage.GetCharacterName(target) + ".");
                        Main.SendSuccessMessage(target, " " + AccountManage.GetCharacterName(p) + " Vam je oduzeo " + Inventory.player_inventory[playerid].amount[index] + " " + Inventory.itens_available[Inventory.player_inventory[playerid].type[index]].name + ".");
                        Inventory.RemoveItem(target, itemName, Inventory.player_inventory[playerid].amount[index]);
                        return;
                    }
                }

            }
        }
        Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan item.");
    }

    [Command("takeguns", "Koristite: /takeguns [ID/DeoImena]")]
    public void CMD_confiscararmas(Player p, string idOrName)
    {
        Player target = Main.findPlayer(p, idOrName);
        if (AccountManage.GetPlayerGroup(p) == -1)
        {
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, " Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(p) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, " Niste ovlasceni.");
            return;
        }
        if (target == null)
        {
            Main.DisplayErrorMessage(p, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan ID.");
            return;
        }

        WeaponManage.RemoveAllWeaponEx(target);

        Main.SendSuccessMessage(p, "Oduzeli ste oruzje od " + AccountManage.GetCharacterName(target) + " .");
        Main.SendSuccessMessage(target, "" + AccountManage.GetCharacterName(p) + " Vam je oduzeo svo oruzje.");


    }

    /*[Command("ticket", "Koriscenje: /ticket [id/DeoImena] [Cena] [Razlog]", GreedyArg = true )]
    public void CMD_fine(Player Client, string idOrName, int kazna, string razlog)
    {

        Player target = Main.findPlayer(Client, idOrName);
        if (AccountManage.GetPlayerGroup(Client) == 0)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }
        if (AccountManage.GetPlayerRank(Client) == -1)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }

        if (target == null)
        {
            InteractMenu_New.SendNotificationError(Client, "Pogresan ID.");
            return;
        }
        if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 3.0f))
        {
            InteractMenu_New.SendNotificationError(Client, "Morate biti pored igraca!");
            return;
        }
        if (kazna < 1 || kazna > 20000)
        {
            InteractMenu_New.SendNotificationError(Client, "Iznos ne moze biti manji od 1 ili veci od $20.000.");
            return;
        }

        Main.SendCustomChatMessasge(Client, " ~w~ Dali ste kaznu u iznosu od $$" + kazna.ToString("N0") + " igracu ~w~ " + UsefullyRP.GetPlayerNameToTarget(target,Client) + ".");
        Main.SendInfoMessage(target, "" + FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_rank[AccountManage.GetPlayerRank(Client)] + " " + UsefullyRP.GetPlayerNameToTarget(Client, target) + " vam je napisao kaznu u iznosu od ~g~$" + kazna.ToString("N0") + "~w~ Razlog: " + razlog + " .");
        Main.GivePlayerMoney(target, -kazna);


    }*/




    [Command("ticketveh", "Koriscenje: /ticketveh [Tablica] [Iznos]")]
    public void CMD_finevehicle(Player Client, string placa, int preco)
    {
        if (AccountManage.GetPlayerGroup(Client) == 0)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }
        if (AccountManage.GetPlayerRank(Client) == -1)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(Client) != FactionManage.FACTION_TYPE_POLICE)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste ovlasceni.");
            return;
        }

        if (preco < 1 || preco > 20000)
        {
            InteractMenu_New.SendNotificationError(Client, "Iznos ne moze biti manji od 1 ili veci od $20.000.");
            return;
        }

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `vehicles` WHERE `vehicle_plate` = '" + placa + "' or `vehicle_plate` = '" + placa.Replace(" ", "-") + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                //var index = 0;
                while (reader.Read())
                {
                    string vehicle_plate = reader.GetString("vehicle_plate");
                    if (vehicle_plate == placa)
                    {
                        var players = NAPI.Pools.GetAllPlayers();
                        foreach (var pl in players)
                        {
                            if (pl.GetData<dynamic>("status") == true)
                            {
                                if (NAPI.Data.GetEntityData(pl, "character_sqlid") == reader.GetInt32("vehicle_owner_id"))
                                {
                                    for (int index = 0; 0 < PlayerVehicle.MAX_PLAYER_VEHICLES; index++)
                                    {
                                        if (placa == Convert.ToString(PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].plate[index]))
                                        {
                                            Main.SendCustomChatMessasge(pl, "Kazna napisana ~c~(" + PlayerVehicle.vehicle_data[Main.getIdFromClient(Client)].model[index] + ")~w~ Tablice: ~y~" + Convert.ToString(PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].plate[index]) + "~w~ Iznos: ~g~$" + preco.ToString("N0") + "~w~ Vlasnik: " + AccountManage.GetCharacterName(Client) + "~w~.");


                                            if (VIP.GetPlayerVIP(pl) == 1)
                                            {
                                                int new_preco = preco - (int)(0.25 * preco);
                                                preco = new_preco;
                                                Main.SendMessageWithTagToPlayer(pl, "" + Main.EMBED_VIP + "[VIP]", "Posto ste donator, placate 20% manje kaznu ($" + new_preco + ") Vasa kazna: " + preco + "");
                                            }


                                            PlayerVehicle.vehicle_data[Main.getIdFromClient(pl)].ticket[index] = preco;
                                            PlayerVehicle.SavePlayerVehicle(pl, index);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Mainpipeline.Close();
        }
        InteractMenu_New.SendNotificationError(Client, "Ne postoji vozilo sa tim tablicama.");
    }

    [Command("wantedlist")]
    public void ListaTrazenih(Player player)
    {
        List<dynamic> data = new List<dynamic>();

        foreach(Player suspect in NAPI.Pools.GetAllPlayers())
        {
            if (suspect.GetSharedData<dynamic>("character_wanted_level") > 7)
            {
                if(API.Shared.IsPlayerConnected(suspect) && suspect.GetData<dynamic>("status") == true)
                {
                    data.Add(new { Suspect = AccountManage.GetCharacterName(suspect), Wanted = suspect.GetSharedData<dynamic>("character_wanted_level") });
                }
            }
            
        }
        player.TriggerEvent("Display_Wanted_List", NAPI.Util.ToJson(data));
    }

    /*[Command("wl")]
    public void cmdwantedlista(Player handle)
    {
        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni!");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni.");
            return;
        }
        handle.SendChatMessage("***WANTED***");
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = Mainpipeline.CreateCommand();
            query.CommandText = ("SELECT name, wanted FROM `characters` WHERE wanted > 6 AND loggedin = 1");
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    string suspect = reader.GetString("name");
                    int wanted = reader.GetInt32("wanted");
                    handle.SendChatMessage(" " + suspect +" "+ wanted +" ⭐ ");
                }
            }
        } 
        handle.SendChatMessage("***WANTED***");
    }*/

    [Command("pwl")]
    public void cmdpwantedlista(Player handle, Player target)
    {
        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni!");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni.");
            return;
        }
        handle.SendChatMessage("Gradjanin"+ AccountManage.GetCharacterName(target) +" ima wanted level: " + target.GetSharedData<dynamic>("character_wanted_level"));
    }


    [Command("cuff", "Koriscenje: /cuff [ID/DeoImena]")]
    public void CMD_algemar(Player handle, string idOrName)
    {
        
        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni!");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni.");
            return;
        }
        if (handle.GetSharedData<dynamic>("Injured") == 1)
        {
            Main.SendErrorMessage(handle, "Povredjeni ste!");
            return;
        }
        Player target = Main.findPlayer(handle, idOrName);
        if (target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {

                if (target.GetData<dynamic>("playerCuffed") == 1)
                {
                    NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Igrac vec ima lisice.");
                    return;
                }

                if (target.IsInVehicle)
                {
                    NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Igrac se nalazi u vozilu.");
                    return;
                }

                target.SetData<dynamic>("handsup", false);
                NAPI.Notification.SendNotificationToPlayer(handle, "~y~INFO:~w~ Stavili ste ~b~" + AccountManage.GetCharacterName(target) + "~w~ u lisice.");
                NAPI.Notification.SendNotificationToPlayer(target, "~y~INFO:~w~ Policajac ~b~" + AccountManage.GetCharacterName(handle) + "~w~ vam je stavio lisice.");

                target.SetData<dynamic>("playerCuffed", 1);
                target.StopAnimation();
                Inventory.oruzijeinuse(target);
                cellphoneSystem.FinishCall(target);
                Police.CuffPlayer(target);


                return;
            }
        }
        NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Pogresan ID!");
    }

    [Command("uncuff", "Koriscenje: /uncuff", Alias = "lisice")]
    public void CMD_desalgemar(Player handle, string idOrName)
    {
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(handle, "Niste ovlasceni.");
            return;
        }
        Player target = Main.findPlayer(handle, idOrName);
        if (target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {

                if (target.GetData<dynamic>("playerCuffed") == 1)
                {
                    Police.UnCuffPlayer(target);
                }
                return;
            }
        }
        Main.SendErrorMessage(handle, "Igrac nije pored Vas.");
    }

    [Command("skinimasku", "Koristite: /skinimasku [ID/DeoImena]")]
    public void CMD_tirarmascara(Player handle, string idOrName)
    {
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE)
        {
            Main.SendErrorMessage(handle, "Niste ovlasceni.");
            return;
        }
        Player target = Main.findPlayer(handle, idOrName);
        if (target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {

                if (target.GetData<dynamic>("playerCuffed") == 0)
                {
                    Main.SendErrorMessage(handle, "Igrac nema lisice.");
                    return;
                }

                if (!handle.GetSharedData<dynamic>("using_mask"))
                {
                    Main.SendErrorMessage(handle, "Igrac ne nosi masku.");
                    return;
                }

                NAPI.Notification.SendNotificationToPlayer(handle, "~y~INFO:~w~ Skinuli ste masku ~b~" + AccountManage.GetCharacterName(target) + "~y~.");
                NAPI.Notification.SendNotificationToPlayer(target, "~y~INFO:~w~ Policajac ~b~" + AccountManage.GetCharacterName(handle) + "~y~ Vam je skinuo masku.");

                UsefullyRP.RemoveMaskFromPlayer(target);


                return;
            }
        }
        Main.SendErrorMessage(handle, "Pogresan ID.");
    }

    [Command("pu", "Koriscenje: /pu [ID] [Sediste(1 - 2)]")]
    public void CMD_deter(Player handle, string idOrName, int assento)
    {

        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni.");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_MEDIC)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni.");
            return;
        }
        if (handle.IsInVehicle)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste u vozilu.");
            return;
        }

        Player target = Main.findPlayer(handle, idOrName);
        if (target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {
                if (assento != 1 && assento != 2)
                {
                    Main.SendErrorMessage(handle, "Osumnjicenog mozete ubaciti samo na 1 i 2 sediste.");
                    return;
                }

                if (target.GetData<dynamic>("playerCuffed") == 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Igrac nema lisice.");
                    return;
                }

                if (target.IsInVehicle)
                {
                    NAPI.Notification.SendNotificationToPlayer(target, "~r~Greska:~w~ Igrac je vec u vozilu.");
                    return;
                }
                NetHandle vehicle = Utils.GetClosestVehicle(target, 5.0f);

                if (!NAPI.Entity.DoesEntityExist(vehicle))
                {
                    NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Nema vozila pored Vas.");
                    return;
                }

                var p = NAPI.Pools.GetAllPlayers();
                foreach (var i in p)
                {
                    if (i.GetData<dynamic>("status") == true && NAPI.Player.IsPlayerInAnyVehicle(i) && NAPI.Player.GetPlayerVehicleSeat(i) == assento)
                    {
                        NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Sandali Shagerd " + assento + " Poor ast.");
                        return;
                    }
                }
                NAPI.Notification.SendNotificationToPlayer(handle, "~y~INFO:~w~ Stavili ste ~b~" + AccountManage.GetCharacterName(target) + "~w~ u vozilo.");
                NAPI.Player.SetPlayerIntoVehicle(target, vehicle, assento);
                //NAPI.Player.PlayPlayerAnimation(target, 1, "mp_arresting", "sit");
                NAPI.Player.PlayPlayerAnimation(target, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "sit");

                target.TriggerEvent("freezeEx", true);


                //target.StopAnimation();

                return;

            }
        }
        NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Ne mozete to.");

    }


    [Command("vuci", "Koriscenje: /vuci [Client]")]
    public static void CMD_arrastar(Player handle, string idOrName)
    {

        if (AccountManage.GetPlayerGroup(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni.");
            return;
        }
        if (AccountManage.GetPlayerRank(handle) == -1)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni.");
            return;
        }
        if (FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupID(handle) != FactionManage.FACTION_TYPE_MEDIC)
        {
            NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Niste ovlasceni.");
            return;
        }

        Player target = Main.findPlayer(handle, idOrName);
        if (target != null)
        {
            if (Main.IsInRangeOfPoint(handle.Position, target.Position, 3) && handle != target)
            {
                if (target.GetData<dynamic>("BeingDragged") == false)
                {
                    if (target.GetData<dynamic>("playerCuffed") == 0)
                    {
                        NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Igrac nema lisice.");
                        return;
                    }

                    if (target.IsInVehicle)
                    {
                        NAPI.Player.WarpPlayerOutOfVehicle(target);
                    }

                    NAPI.Player.PlayPlayerAnimation(target, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.AllowPlayerControl | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "idle");


                    target.TriggerEvent("setFollow", true, handle);
                    target.TriggerEvent("freezeEx", true);
                    target.SetData<dynamic>("BeingDragged", true);

                    target.SetSharedData("DisableExitVehicle", false);
                    Main.DisplaySubtitle(handle, "Vucete " + AccountManage.GetCharacterName(target) + " sa sobom.");
                }
                else
                {
                    Main.DisplaySubtitle(handle, "Prestali ste da vucete " + AccountManage.GetCharacterName(target) + " sa sobom.");
                    target.TriggerEvent("setFollow", false, handle);
                    target.SetData<dynamic>("BeingDragged", false);
                    target.TriggerEvent("freezeEx", true);
                }
                return;
            }
        }
        NAPI.Notification.SendNotificationToPlayer(handle, "~r~Greska:~w~ Ne mozete to.");

    }

    [RemoteEvent("buygunlic")]
    public void BuyGunLicense(Player player)
    {
        if (AccountManage.GetPlayerConnected(player))
        {
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(441.28094, -981.8585, 30.6896), 3))
            {
                if (Main.GetPlayerMoney(player) < 20000)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca.");
                    return;
                }
                if (player.GetData<dynamic>("character_gun_lic") > 0)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete dozvolu za oruzje.");
                    return;
                }
                Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Cestitamo, dobili ste dozvolu.");
                player.SetData<dynamic>("character_gun_lic", 720);
                Main.GivePlayerMoney(player, -20000);
                Main.SavePlayerInformation(player);
            }
        }
    }

}

