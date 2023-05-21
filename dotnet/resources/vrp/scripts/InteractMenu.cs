using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

class InteractMenu : Script
{
    public static List<dynamic> animation_list = new List<dynamic>();

    [RemoteEvent("keypress:I")]
    public void KeyPressI(Player Client)
    {
        if (AccountManage.GetPlayerConnected(Client))
        {
            Vehicle veh = Utils.GetClosestVehicle(Client, 3f);
            Player target = Utils.GetClosestPlayer(Client, 3f);
            if (Client.GetData<dynamic>("fishing") == true)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Ne mozete koristiti inventory dok pecate.");
                return;
            }
            if (veh != null && VehicleStreaming.GetLockState(veh) == false &&  VehicleInventory.HasVehicleInventory(veh) != null )
            {
                VehicleInventory.ShowToPlayerVehicleInventory(Client, veh);
            }
            else if (target == null || target.GetData<dynamic>("playerCuffed") == 0 && target.GetData<dynamic>("handsup") == false && target.GetSharedData<dynamic>("Injured") == 0)
            {
                Inventory.ShowPlayerInventory(Client);
            }
            else if (target != null && target.GetData<dynamic>("playerCuffed") == 1 || target.GetData<dynamic>("handsup") == true || target.GetSharedData<dynamic>("Injured") == 1)
            {
                Inventory.ShowTargetSearchMenu(Client, target);
            }
        }
    }

    public static void ShowPlayerInteractMenu(Player Client)
    {

        InteractMenu_New.ShowPlayerInteractMenu(Client);

    }

    public static void CreateMenu(Player Client, string callback, string title, string description, bool freezePlayer, string json, bool resetBack, string BackgroundSprite = "none", string BackgroundColor = "none", int CurrentSelect = 0, bool MouseControl = false)
    {

        Client.TriggerEvent("menu_handler_create_menu_generic", callback, title, description, freezePlayer, json, resetBack, BackgroundSprite, BackgroundColor, CurrentSelect, MouseControl);
    }

    public static void ShowPlayerFactionMenu(Player Client)
    {
        int index = AccountManage.GetPlayerGroup(Client);

        if (index == 0)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste clan organizacije.");
            ShowPlayerInteractMenu(Client);
            return;
        }
        if (index == 0)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste clan organizacije.");
            ShowPlayerInteractMenu(Client);
            return;
        }
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Obavestenje", Description = FactionManage.faction_data[index].faction_motd, RightBadge = "Crown" });
        menu_item_list.Add(new { Type = 1, Name = "Upravljanje clanovima", Description = "", RightBadge = "Crown" });
        menu_item_list.Add(new { Type = 1, Name = "Upravljanje rankovima", Description = "", RightBadge = "Crown" });
        menu_item_list.Add(new { Type = 1, Name = "Lista clanova", Description = "" });
        menu_item_list.Add(new { Type = 1, Name = "Napusti organizaciju", Description = "", RightBadge = "Alert", Color = "OrangeRed", HighlightColor = "Tomato" });

        InteractMenu.CreateMenu(Client, "PLAYER_FACTION_MENU", "Faction", "~b~" + FactionManage.faction_data[index].faction_name + "", false, NAPI.Util.ToJson(menu_item_list), false);
    }

    [RemoteEvent("menu_handler_select_item_generic")]
    public void menu_handler_select_item_generic(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {

        try
        {

            if (callbackId == "PLAYER_FACTION_MENU_MEMBER")
            {
                //string name = Client.GetData<dynamic>("ListTrack_" + selectedIndex);
                Client.SetData<dynamic>("LisTrack_ID", selectedIndex);

                int index = AccountManage.GetPlayerGroup(Client);

                if (index == 0)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste clan organizacije..");
                    ShowPlayerInteractMenu(Client);
                    return;
                }

                List<dynamic> menu_item_list = new List<dynamic>();
                if (AccountManage.GetPlayerRank(Client) >= 8 || AccountManage.GetPlayerLeader(Client) == 1)
                {
                    menu_item_list.Add(new { Type = 1, Name = "Upravljanje rankom", Description = "" });
                    menu_item_list.Add(new { Type = 1, Name = "~r~Izbaci iz organizacije", Description = "" });
                }
                else
                {
                    ShowPlayerFactionMenu(Client);
                }
                

                InteractMenu.CreateMenu(Client, "PLAYER_FACTION_INFO", "Faction", "~b~" + FactionManage.faction_data[index].faction_name + "", false, NAPI.Util.ToJson(menu_item_list), false);
            }
            else if (callbackId == "PLAYER_HOOKER_OFFER")
            {

                if (Client.VehicleSeat == (int)VehicleSeat.RightFront && (PedHash)Client.Model == PedHash.FreemodeFemale01)
                {
                    Player pl = Client.GetData<dynamic>("Hooker_Partner");

                    if (pl.Exists && pl.Vehicle == Client.Vehicle && pl.VehicleSeat == (int)VehicleSeat.Driver)
                    {
                        switch (selectedIndex)
                        {
                            case 0:
                                pl.SetData<dynamic>("Hooker_Offer", 0);
                                InteractMenu.ShowModal(pl, "Hooker_System", "", "Seks " + AccountManage.GetCharacterName(Client) + " Vam nudi seks,", "Prihvati.", "Odbij.");

                                break;
                            case 1:
                                InteractMenu.ShowModal(pl, "Hooker_System", "", "Seks " + AccountManage.GetCharacterName(Client) + " ponudili ste seks", "Prihvati.", "Odbij.");
                                pl.SetData<dynamic>("Hooker_Offer", 1);
                                break;
                            default:
                                break;
                        }

                    }

                }
            }
            else if (callbackId == "PLAYER_FACTION_INFO")
            {
                
                int index = AccountManage.GetPlayerGroup(Client);

                if (index == 0)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste clan organizacije..");
                    ShowPlayerInteractMenu(Client);
                    return;
                }

                if (AccountManage.GetPlayerRank(Client) <= 8 && AccountManage.GetPlayerLeader(Client) == 0)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste lider.");
                    return;
                }

                string name = Client.GetData<dynamic>("ListTrack_" + Client.GetData<dynamic>("LisTrack_ID"));
                int leader = 0;
                int group = 0;
                int group_rank = 0;

                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                {

                    Mainpipeline.Open();
                    MySqlCommand query = new MySqlCommand("SELECT `name`, `leader`, `group`, `group_rank` FROM characters WHERE `name` = '" + name + "' LIMIT 1;", Mainpipeline);
                    using (MySqlDataReader reader = query.ExecuteReader())
                    {

                        List<dynamic> menu_item_list = new List<dynamic>();
                        while (reader.Read())
                        {
                            leader = reader.GetInt32("leader");
                            group = reader.GetInt32("group");
                            group_rank = reader.GetInt32("group_rank");
                        }
                    }
                    Mainpipeline.Close();
                }

                if (group == 0)
                {
                    return;
                }
                if (selectedIndex == 0)
                {
                    List<dynamic> menu_item_list = new List<dynamic>();
                    for (int i = 0; i < FactionManage.MAX_FACTION_RANK; i++)
                    {
                        if (FactionManage.faction_data[group].faction_rank[i] == "Unknown")
                        {
                            menu_item_list.Add(new { Type = 4, Name = "Rank " + i + ".", Description = "", RightLabel = "~c~Unknown" });
                        }
                        else
                        {
                            menu_item_list.Add(new { Type = 4, Name = "Rank " + i + ".", Description = "", RightLabel = "~s~" + FactionManage.faction_data[group].faction_rank[i] + "" });
                        }

                    }
                    InteractMenu.CreateMenu(Client, "PLAYER_FACTION_GIVERANK", "Organizacija", "~b~" + FactionManage.faction_data[index].faction_name + " - Promeni rank", false, NAPI.Util.ToJson(menu_item_list), false);

                }
                else if (selectedIndex == 1)
                {
                    string name2 = Client.GetData<dynamic>("ListTrack_" + Client.GetData<dynamic>("LisTrack_ID"));
                    var players = NAPI.Pools.GetAllPlayers();
                    if (leader == 1)
                    {
                        Main.SendCustomChatMessasge(Client, "~r~ Lider ne moze biti izbacen iz organizacije.");
                        return;
                    }
                    foreach (var member in players)
                    {
                        if (member.GetData<dynamic>("status") == true)
                        {
                            if (AccountManage.GetCharacterName(member) == name2.Replace("_", " "))
                            {
                                Main.SendCustomChatMessasge(Client, "~y~INFO:~w~ izbacili ste ~y~" + name2 + "~w~ iz ~y~" + FactionManage.faction_data[index].faction_name + ".");
                                Main.SendCustomChatMessasge(member, "~y~INFO:~w~ Izbaceni ste iz ~y~" + FactionManage.faction_data[index].faction_name + ".");


                                NAPI.Data.SetEntityData(member, "duty", 0);
                                Main.UpdatePlayerClothes(member);
                                AccountManage.SetPlayerRank(member, 0);
                                AccountManage.SetPlayerGroup(member, 0);
                                Main.SavePlayerInformation(member);
                                return;
                            }
                        }
                    }

                    // AccountManage.SetPlayerRank(member, 0);
                    //  AccountManage.SetPlayerGroup(member, 0);
                    Main.SendCustomChatMessasge(Client, "~y~INFO:~w~ izbacili ste ~y~" + name2 + "~w~ iz organizacije .");

                    Main.CreateMySqlCommand("UPDATE `characters` SET `leader` =0,`group_rank` =0,`group` =0 WHERE `name` = '" + name2 + "'");

                }
            }
            else if (callbackId == "PLAYER_FACTION_MENU_HIERARQUIA")
            {
                int index = AccountManage.GetPlayerGroup(Client);

                if (index == 0)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste clan organizacije..");
                    ShowPlayerInteractMenu(Client);
                    return;
                }

                if (AccountManage.GetPlayerRank(Client) <= 8 && AccountManage.GetPlayerLeader(Client) == 0)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste lider.");
                    return;
                }

                Client.SetData<dynamic>("faction_editing_rank", selectedIndex);
                User_Input(Client, "input_player_faction_rank", "Nome do Rank", FactionManage.faction_data[index].faction_rank[selectedIndex]);
            }
            else if (callbackId == "PLAYER_FACTION_GIVERANK")
            {
                int index = AccountManage.GetPlayerGroup(Client);

                if (index == 0)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste clan organizacije..");
                    ShowPlayerInteractMenu(Client);
                    return;
                }

                if (AccountManage.GetPlayerRank(Client) <= 8 && AccountManage.GetPlayerLeader(Client) == 0)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste lider.");
                    return;
                }

                string name = Client.GetData<dynamic>("ListTrack_" + Client.GetData<dynamic>("LisTrack_ID"));
                int leader = 0;
                int group = 0;
                int group_rank = 0;

                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                {

                    Mainpipeline.Open();
                    MySqlCommand query = new MySqlCommand("SELECT `name`, `leader`, `group`, `group_rank` FROM characters WHERE `name` = '" + name + "' LIMIT 1;", Mainpipeline);
                    using (MySqlDataReader reader = query.ExecuteReader())
                    {

                        List<dynamic> menu_item_list = new List<dynamic>();
                        while (reader.Read())
                        {
                            leader = reader.GetInt32("leader");
                            group = reader.GetInt32("group");
                            group_rank = reader.GetInt32("group_rank");
                        }
                    }
                    Mainpipeline.Close();
                }


                var players = NAPI.Pools.GetAllPlayers();
                foreach (var member in players)
                {
                    if (member.GetData<dynamic>("status") == true)
                    {
                        if (AccountManage.GetCharacterName(member) == name.Replace("_", " "))
                        {
                            Main.SendCustomChatMessasge(Client, "~y~INFO:~w~ Postavili ste " + name + " rank " + FactionManage.faction_data[index].faction_rank[selectedIndex] + ".");
                            Main.SendCustomChatMessasge(member, "~y~INFO:~w~ " + AccountManage.GetCharacterName(Client) + "Vam je dodelio rank " + FactionManage.faction_data[index].faction_rank[selectedIndex] + ".");

                            AccountManage.SetPlayerRank(member, selectedIndex);
                            Main.SavePlayerInformation(member);
                            return;
                        }
                    }
                }

                Main.SendCustomChatMessasge(Client, "~y~INFO:~w~ Postavili ste " + name + " rank " + FactionManage.faction_data[index].faction_rank[selectedIndex] + ".");
                Main.CreateMySqlCommand("UPDATE `characters` SET `leader` =" + 0 + ",`group_rank` = " + selectedIndex + " WHERE `name` = '" + name + "'");
            }

            if (callbackId == "interaction_menu")
            {
                switch (selectedIndex)
                {
                    case 0: break;
                    case 1:
                        {
                            List<dynamic> menu_item_list = new List<dynamic>();
                            menu_item_list.Add(new { Type = 1, Name = "Uzmi / parkiraj vozilo", Description = "" });
                            menu_item_list.Add(new { Type = 1, Name = "Lociraj vozilo", Description = "" });

                            InteractMenu.CreateMenu(Client, "interecation_vehicle_response", "Player Menu", "~b~INTERACTION MENU:", false, NAPI.Util.ToJson(menu_item_list), false);
                            break;
                        }
                    case 2:
                        // Client.SendNotification("~r~Greska~n~~w~Menu em construcao.");
                        ShowPlayerFactionMenu(Client);
                        break;
                    case 3:
                        Translation.ShowPlayerStats(Client, Client);

                        break;
                    case 4:
                        {

                            var players = NAPI.Pools.GetAllPlayers();
                            foreach (var target in players)
                            {
                                if (target.GetData<dynamic>("status") == true && Main.IsInRangeOfPoint(Client.Position, target.Position, 5f) && Client != target)
                                {
                                    Translation.ShowPlayerStats(Client, target);
                                    return;
                                }
                            }
                            Client.SendNotification("~r~Greska~n~~w~Nema igraca u blizini.");

                            break;
                        }
                    case 5:
                        {
                            var players = NAPI.Pools.GetAllPlayers();
                            foreach (var target in players)
                            {
                                if (target.GetData<dynamic>("status") == true)
                                {
                                    if (Main.IsInRangeOfPoint(Client.Position, target.Position, 5f) && Client != target)
                                    {
                                        //Main.ShowPlayerStats(Client, target);
                                        Client.SetData<dynamic>("interact_target", target);
                                        User_Input(Client, "interactMenu_giveMoney", "Daj novac " + AccountManage.GetCharacterName(target) + "", "100", "", "number");
                                        return;
                                    }
                                }
                            }
                            Client.SendNotification("~r~Greska~n~~w~Nema igraca u blizini.");
                            break;
                        }
                    case 6:
                        {

                            break;
                        }
                }
                return;
            }
            else if (callbackId == "interecation_vehicle_response")
            {
                if (selectedIndex == 0)
                {
                    PlayerVehicle.ShowPlayerVehicles(Client);
                }
                else if (selectedIndex == 1)
                {
                    //PlayerVehicle.ShowPlayerVehiclesToTrack(Client);
                }
                return;
            }
            
            else if (callbackId == "PLAYER_TELEPORT")
            {
                int i = selectedIndex;
                if (i == 0)
                {
                    return;
                }
                Client.TriggerEvent("freeze", true);
                Client.TriggerEvent("freezeEx", true);
                Client.TriggerEvent("moveSkyCamera", Client, "up", 1, false);
                NAPI.Task.Run(() =>
                {
                    if (!Client.Exists)
                    {
                        return;
                    }

                    Client.TriggerEvent("moveSkyCamera", Client, "down");
                //    NAPI.Entity.SetEntityPosition(Client, AccountManage.Teleport_List[i].position);
                    NAPI.Task.Run(() =>
                    {
                        if (!Client.Exists)
                        {
                            return;
                        }
                        Client.TriggerEvent("freezeEx", false);
                        Client.TriggerEvent("freeze", false);
                    },2000);
                }, delayTime: 4000);
            }
            else
            {
                InteractMenu_New.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                FactionManage.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                Police.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                MedicSystem.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                WerehouseManage.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                GangueManage.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                XMR.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                Weed.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                cellphoneSystem.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                DriverLicense.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                HouseSystem.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                GarageSys.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                Barber.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                animationCommands.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);

                Security_Camera.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                TattoBusiness.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
                UsefullyRP.SelectMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }
    }

    [RemoteEvent("menu_handler_index_change_generic")]
    public void IndexChangeMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        InteractMenu_New.IndexChangeMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
        // Police.IndexChangeMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
        Barber.IndexChangeMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
        animationCommands.IndexChangeMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);

        TattoBusiness.IndexChangeMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);

    }

    [RemoteEvent("menu_handler_listchanged_item_generic")]
    public void ListItemMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        WerehouseManage.ListItemMenuResponse(Client, callbackId, selectedIndex, objectName, valueList, valueIndex);
        InteractMenu_New.ListItemMenuResponse(Client, callbackId, selectedIndex, objectName, valueList, valueIndex);
        FactionManage.ListItemMenuResponse(Client, callbackId, selectedIndex, objectName, valueList, valueIndex);
        // CanineSystem.ListItemMenuResponse(Client, callbackId, selectedIndex, objectName, valueList, valueIndex);
        Barber.ListItemMenuResponse(Client, callbackId, selectedIndex, objectName, valueList, valueIndex);
        UsefullyRP.IndexChangeMenuResponse(Client, callbackId, selectedIndex, objectName, valueList, valueIndex);
        TattoBusiness.ListItemMenuResponse(Client, callbackId, selectedIndex, objectName, valueList, valueIndex);
        //Police.ListItemMenuResponse(Client, callbackId, selectedIndex, objectName, valueList, valueIndex);
    }


    [RemoteEvent("menu_handler_checked_item_generic")]
    public void CheckBoxItemMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList, bool _checked)
    {
        InteractMenu_New.CheckBoxItemMenuResponse(Client, callbackId, selectedIndex, objectName, valueList, _checked);
        HouseSystem.CheckBoxItemMenuResponse(Client, callbackId, selectedIndex, objectName, valueList, _checked);
    }

    [RemoteEvent("menu_handler_on_close")]
    public void OnMenuReturnClose(Player Client, String callbackId)
    {
        NAPI.Task.Run(() =>
        {
            // InteractMenu_New..OnMenuReturnClose(Client, callbackId);
            FactionManage.OnMenuReturnClose(Client, callbackId);
            WerehouseManage.OnMenuReturnClose(Client, callbackId);
            GangueManage.OnMenuReturnClose(Client, callbackId);
            LSCUSTOM_NEW.OnMenuReturnClose(Client, callbackId);
            UsefullyRP.OnMenuReturnClose(Client, callbackId);
            HouseSystem.OnMenuReturnClose(Client, callbackId);
            Barber.OnMenuReturnClose(Client, callbackId);
            TattoBusiness.OnMenuReturnClose(Client, callbackId);

        }, delayTime: 500);
    }





    // Input Text By Mike
    [RemoteEvent("uiInput_response")]
    public void OnInputResponse(Player Client, String response, String inputtext)
    {
        if (response == "interactMenu_giveMoney")
        {
            Player target = Client.GetData<dynamic>("interact_target");
            if (!NAPI.Player.IsPlayerConnected(target))
            {
                Client.SendNotification("~r~Greska~n~~w~Pogresan ID.");
                return;
            }
            if (target.GetData<dynamic>("status") == false)
            {
                Client.SendNotification("~r~Greska~n~~w~Pogresan ID.");
                return;
            }
            if (!Main.IsInRangeOfPoint(Client.Position, target.Position, 5f))
            {
                Client.SendNotification("~r~Greska~n~~w~Igrac mora biti pored Vas.");
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                Client.SendNotification("~r~Greska~n~~w~Pogresan unos.");
                return;
            }

            if (inputtext.Length == 0)
            {
                Client.SendNotification("~r~Greska~n~~w~Vrednost ne moze biti manja od 1.");
                return;
            }
            NAPI.Util.ConsoleOutput("Crash #9");

            int value = Convert.ToInt32(inputtext);

            if (value < 1)
            {
                Client.SendNotification("~r~Greska~n~~w~Iznos ne moze biti manji od $1 ili veci od  $100,000.");
                return;
            }

            if (value > 100000)
            {
                Client.SendNotification("~r~Greska~n~~w~Iznos ne moze biti manji od $1 ili veci od  $100,000.");
                return;
            }


            if (Main.GetPlayerMoney(Client) < value)
            {
                Client.SendNotification("~r~Greska~n~~w~Nemas dovoljno novca.");
                return;
            }

            Main.GivePlayerMoney(Client, -value);
            Main.GivePlayerMoney(target, value);
            Client.SendNotification("~g~Success~n~~w~Dali ste ~g~$" + value.ToString("N0") + "~w~ igracu ~y~" + AccountManage.GetCharacterName(target) + " ~w~novac.");
            target.SendNotification("~g~Success~n~~w~Dobili ste ~g~$" + value.ToString("N0") + "~w~ od ~y~" + AccountManage.GetCharacterName(Client) + "~w~.");
        }
        else if (response == "interact_faction_motd")
        {
            if (inputtext.Length > 128)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Unos ne sme biti manji od 5 ili veci od 128 karaktera.");
                return;
            }
            if (inputtext.Length < 5)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Unos ne sme biti manji od 5 ili veci od 128 karaktera.");
                return;
            }
            string pattern = "^[a-zA-Z]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(inputtext, pattern))
            {
                Main.SendCustomChatMessasge(Client, "~w~Dozvoljeni su samo karakteri A-Z.");
                return;
            }
            int index = AccountManage.GetPlayerGroup(Client);

            if (index == 0)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste clan organizacije..");
                return;
            }

            FactionManage.faction_data[index].faction_motd = inputtext;

            FactionManage.SendFactionMessage(index, "~y~--------------------------------------------------");
            FactionManage.SendFactionMessage(index, "~y~Novo obavestenje:~w~ ");
            FactionManage.SendFactionMessage(index, "~y~•~w~ " + inputtext);
            FactionManage.SendFactionMessage(index, "~y~--------------------------------------------------");
        }
        else if (response == "input_admin_give_money")
        {
            string name = Client.GetData<dynamic>("ListTrack_" + Client.GetData<dynamic>("ListTrack_ID") + "").Replace(" ", "_"); ;

            Player target = Main.findPlayer(Client, name);

            if (target == null)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan ID.");
                return;
            }

            if (!Main.IsNumeric(inputtext))
            {
                Client.SendNotification("~r~Greska~n~~w~Pogresan unos.");
                return;
            }

            if (inputtext.Length == 0)
            {
                Client.SendNotification("~r~Greska~n~~w~Unos ne moze biti manji od  1.");
                return;
            }
            NAPI.Util.ConsoleOutput("Crash #10");

            int value = Convert.ToInt32(inputtext);

            Main.GivePlayerMoney(target, value);
            Main.SavePlayerInformation(target);

            if (Client != target) Main.SendCustomChatMessasge(Client, "Postavili ste ~g~$~y~" + value.ToString("N0") + "~w~ za ~y~" + AccountManage.GetCharacterName(target) + ".");
            else Main.SendInfoMessage(Client, "Admin " + AccountManage.GetCharacterName(Client) + " Vam je postavio ~g~$~y~" + value.ToString("N0") + "~.");
        }
        WerehouseManage.OnInputResponse(Client, response, inputtext);
        FactionManage.OnInputResponse(Client, response, inputtext);
        GangueManage.OnInputResponse(Client, response, inputtext);
        LottoSystem.OnInputResponse(Client, response, inputtext);
        //   GangueManage.OnInputResponse(Client, response, inputtext);
        TurfWar.OnInputResponse(Client, response, inputtext);
        //   Inventory.OnInputResponse(Client, response, inputtext);
        //ATMSystem.OnInputResponse(Client, response, inputtext);
        PropertySystem.OnInputResponse(Client, response, inputtext);
        Weed.OnInputResponse(Client, response, inputtext);
        cellphoneSystem.OnInputResponse(Client, response, inputtext);
       
     //   Inventory.OnInputResponse(Client, response, inputtext);
        HouseSystem.OnInputResponse(Client, response, inputtext);
        InteractMenu_New.OnInputResponse(Client, response, inputtext);
        //Business.ListItemMenuResponse(Client, callbackId, selectedIndex, objectName, valueList);
    }

    public static void User_Input(Player Client, string callback, string title, string placeholder, string description = "", string type = "text")
    {
        Client.TriggerEvent("uiGeneralInput", callback, title, placeholder, description, type);

    }
    // End Input Text

    [RemoteEvent("Destroy_Menu")]
    public static void CloseDynamicMenu(Player Client)
    {
        Client.TriggerEvent("menu_dynamic_close");
    }


   
    

    public static void ShowModal(Player Client, string callback_id, string title, string text, string bottom_confirm, string bottom_cancel)
    {
        Client.TriggerEvent("ShowModal", callback_id, title, text, bottom_confirm, bottom_cancel);
    }

    [RemoteEvent("modalConfirm")]
    public static void modalConfirm(Player Client, string response)
    {
       
        if (response == "WHITE_LIST_RESPONSE")
        {

        }
        VIP.ModalConfirm(Client, response);
        Weed.ModalConfirm(Client, response);
        UsefullyRP.ModalConfirm(Client, response);
        PlayerVehicle.ModalConfirm(Client, response);
    }

    

    [RemoteEvent("modalCancel")]
    public static void ModalCancel(Player Client, string response)
    {
        VIP.ModalCancel(Client, response);
        Weed.ModalCancel(Client, response);
    }

}

