using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Linq;


class GangueManage : Script
{
     
    public static void DisplayCreateGangueMenu(Player Client, bool firstTime = false)
    {
        if (firstTime == true)
        {
            Client.SetData<dynamic>("gangue_name", "Unknown");
            Client.SetData<dynamic>("gangue_abreviacao", "Unknown");
            Client.SetData<dynamic>("gangue_color", "FFFFFF");

            Client.SetData<dynamic>("gangue_hierarquia_0", "Novajlija");
            Client.SetData<dynamic>("gangue_hierarquia_1", "Gangster");
            Client.SetData<dynamic>("gangue_hierarquia_2", "Saradnik");
            Client.SetData<dynamic>("gangue_hierarquia_3", "Covek od poverenja");
            Client.SetData<dynamic>("gangue_hierarquia_4", "Zamenik Sefa");
            Client.SetData<dynamic>("gangue_hierarquia_5", "Sef");
        }

        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Naziv organizacije", Description = "", RightLabel = "~c~" + Client.GetData<dynamic>("gangue_name") });
        menu_item_list.Add(new { Type = 1, Name = "Skraceni naziv", Description = "", RightLabel = "~c~" + Client.GetData<dynamic>("gangue_abreviacao") });
        menu_item_list.Add(new { Type = 1, Name = "Boja organizacije", Description = "", RightLabel = "~c~" + Client.GetData<dynamic>("gangue_color") });
        menu_item_list.Add(new { Type = 1, Name = "Rankovi", Description = "", RightLabel = ">>" });
        menu_item_list.Add(new { Type = 1, Name = "Kreiraj organizaciju", Description = "", RightLabel = "" });

        InteractMenu.CreateMenu(Client, "PLAYER_FACTION_CREATE", "Faction", "~b~Kreiraj organizaciju", false, NAPI.Util.ToJson(menu_item_list), false);
    }

    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "PLAYER_FACTION_CREATE")
        {
            switch (selectedIndex)
            {
                case 0:
                    {
                        InteractMenu.User_Input(Client, "input_player_faction_create", "Organizacija", Client.GetData<dynamic>("gangue_name"));
                        InteractMenu.CloseDynamicMenu(Client);
                        break;
                    }
                case 1:
                    {
                        InteractMenu.User_Input(Client, "input_player_faction_abbrev", "Skraceni naziv, npr: RM", Client.GetData<dynamic>("gangue_abreviacao"));
                        InteractMenu.CloseDynamicMenu(Client);
                        break;
                    }
                case 2:
                    {
                        InteractMenu.User_Input(Client, "input_player_faction_color", "Boja, npr: FFFF00", Client.GetData<dynamic>("gangue_color"));
                        InteractMenu.CloseDynamicMenu(Client);
                        break;
                    }
                case 3:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        for (int i = 0; i < 6; i++)
                        {
                            menu_item_list.Add(new { Type = 1, Name = "Rank " + i + ".", Description = "", RightLabel = "~w~" + Client.GetData<dynamic>("gangue_hierarquia_" + i) });
                        }
                        InteractMenu.CreateMenu(Client, "PLAYER_FACTION_HIERARQUIA", "Organizacija", "~b~Rankovi", false, NAPI.Util.ToJson(menu_item_list), false);
                        break;
                    }
                case 4:
                    {
                        if (Client.GetData<dynamic>("gangue_name") == "Unknown")
                        {
                            Main.SendErrorMessage(Client, "Morate uneti naziv organizacije.");
                            return;
                        }
                        if (Client.GetData<dynamic>("gangue_abreviacao") == "Unknown")
                        {
                            Main.SendErrorMessage(Client, "Morate uneti skraceni naziv organizacije.");
                            return;
                        }
                        if (Client.GetData<dynamic>("gangue_color") == "FFFFFF")
                        {
                            Main.SendErrorMessage(Client, "Morate uneti boju organizacije. Posetite: ~y ~www.Colorpicker.com ~w ~, tu mozete proneci razne boje. Primer: ~b~CCFF00~w~.");
                            return;
                        }

                        for (int i = 20; i < FactionManage.MAX_FACTIONS; i++)
                        {
                            if (FactionManage.faction_data[i].faction_name == "Unknown")
                            {
                                FactionManage.faction_data[i].faction_name = Convert.ToString(Client.GetData<dynamic>("gangue_name"));
                                FactionManage.faction_data[i].faction_abbrev = Client.GetData<dynamic>("gangue_abreviacao");
                                FactionManage.faction_data[i].faction_color = Client.GetData<dynamic>("gangue_color");

                                FactionManage.faction_data[i].faction_type = 4;

                                FactionManage.faction_data[i].faction_rank[0] = Client.GetData<dynamic>("gangue_hierarquia_0");
                                FactionManage.faction_data[i].faction_rank[1] = Client.GetData<dynamic>("gangue_hierarquia_1");
                                FactionManage.faction_data[i].faction_rank[2] = Client.GetData<dynamic>("gangue_hierarquia_2");
                                FactionManage.faction_data[i].faction_rank[3] = Client.GetData<dynamic>("gangue_hierarquia_3");
                                FactionManage.faction_data[i].faction_rank[4] = Client.GetData<dynamic>("gangue_hierarquia_4");
                                FactionManage.faction_data[i].faction_rank[5] = Client.GetData<dynamic>("gangue_hierarquia_5");

                                NAPI.Data.SetEntityData(Client, "character_leader", i);
                                NAPI.Data.SetEntityData(Client, "character_group", i);
                                NAPI.Data.SetEntityData(Client, "character_group_rank", 5);

                                Main.SendCustomChatMessasge(Client, "Kreirali ste organizaciju  ~g~" + Client.GetData<dynamic>("gangue_name") + "~w~.");
                                Main.SendCustomChatMessasge(Client, "Koristite ~y~/help gang~w~ da vidite listu komandi.");
                                FactionManage.SaveFaction(i);
                                FactionManage.SaveFactionRanks(i);
                                return;
                            }
                        }
                        Main.SendErrorMessage(Client, "Trenutno nije moguce kreirati organizaciju!");
                        break;
                    }
            }
        }
        else if (callbackId == "PLAYER_FACTION_HIERARQUIA")
        {
            Client.SetData<dynamic>("customListItem", selectedIndex);
            InteractMenu.User_Input(Client, "input_player_faction_hierarquia", "Naziv ranka", Client.GetData<dynamic>("gangue_hierarquia_" + selectedIndex));
            InteractMenu.CloseDynamicMenu(Client);
        }

    }

    public static void OnInputResponse(Player Client, String response, String inputtext)
    {
        switch (response)
        {
            case "input_player_faction_create":
                Client.SetData<dynamic>("gangue_name", inputtext);
                DisplayCreateGangueMenu(Client);
                break;
            case "input_player_faction_abbrev":
                Client.SetData<dynamic>("gangue_abreviacao", inputtext);
                DisplayCreateGangueMenu(Client);
                break;
            case "input_player_faction_color":
                Client.SetData<dynamic>("gangue_color", inputtext);
                DisplayCreateGangueMenu(Client);
                break;
            case "input_player_faction_hierarquia":

                int index = Client.GetData<dynamic>("customListItem");
                if (inputtext.Count() < 4)
                {
                    Main.SendErrorMessage(Client, "Naziv organizacije mora sadrzati minimum 3 karaktera.");
                    DisplayCreateGangueMenu(Client);
                    return;
                }
                Client.SetData<dynamic>("gangue_hierarquia_" + index, inputtext);

                // show menu again
                List<dynamic> menu_item_list = new List<dynamic>();
                for (int i = 0; i < 6; i++)
                {
                    menu_item_list.Add(new { Type = 1, Name = "Rank " + i + ".", Description = "", RightLabel = "~w~" + Client.GetData<dynamic>("gangue_hierarquia_" + i) });
                }
                InteractMenu.CreateMenu(Client, "PLAYER_FACTION_HIERARQUIA", "Faction", "~b~Hierarchy", false, NAPI.Util.ToJson(menu_item_list), false);
                break;
        }
    }
    public static void OnMenuReturnClose(Player Client, String callbackId)
    {
        if (callbackId == "PLAYER_FACTION_HIERARQUIA")
        {
            DisplayCreateGangueMenu(Client);
        }
    }
}
