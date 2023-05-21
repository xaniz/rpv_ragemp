using GTANetworkAPI;


class faction_blip : Script
{
    public faction_blip()
    {

    }

    public static void OnPlayerConnect(Player Client)
    {
        for (int i = 0; i < Main.MAX_PLAYERS; i++)
        {
            Client.SetData<dynamic>("player_blip_" + i + "", false);

            Client.SetData<dynamic>("player_turf_blip_" + i + "", false);
        }
    }

    public static void OnPlayerDisconect(Player Client)
    {
        Blip_Remove(Client);
    }


    public static void RemoveBlip(Player Client)
    {
        foreach (Player target in API.Shared.GetAllPlayers())
        {
            if (Client.GetData<dynamic>("player_blip_" + Main.getIdFromClient(target) + "") == true)
            {
                Client.TriggerEvent("blip_remove", "player_" + Main.getIdFromClient(target));
                Client.SetData<dynamic>("player_blip_" + Main.getIdFromClient(target) + "", false);
            }
        }
    }


    public static void Update_Blip_Enemy_For_player(Player Client)
    {
        int tw = Client.GetData<dynamic>("player_in_turf");
        int iGroupID = AccountManage.GetPlayerGroup(Client);

        if (tw == -1) return;

        if (TurfWar.turf_war[tw].active_war == 1)
        {
            if (iGroupID == TurfWar.turf_war[tw].ownerid)
            {
                foreach (Player target in API.Shared.GetAllPlayers())
                {
                    if (target.GetData<dynamic>("status") == true && target.GetData<dynamic>("player_in_turf") == tw && AccountManage.GetPlayerGroup(target) == TurfWar.turf_war[tw].attemptid)
                    {
                        if (Client.GetData<dynamic>("player_turf_blip_" + Main.getIdFromClient(target) + "") == false)
                        {
                            Client.TriggerEvent("blip_create_ext", "player_turf_" + Main.getIdFromClient(target), target.Position, FactionManage.faction_data[TurfWar.turf_war[tw].attemptid].faction_turf_color, 0.70f, 0);
                            Client.SetData<dynamic>("player_turf_blip_" + Main.getIdFromClient(target) + "", true);
                        }
                        else
                        {
                            Client.TriggerEvent("blip_move", "player_turf_" + Main.getIdFromClient(target), target.Position);
                        }
                    }
                }
            }
            else if (iGroupID == TurfWar.turf_war[tw].attemptid)
            {
                foreach (Player target in API.Shared.GetAllPlayers())
                {
                    if (target.GetData<dynamic>("status") == true && target.GetData<dynamic>("player_in_turf") == tw && AccountManage.GetPlayerGroup(target) == TurfWar.turf_war[tw].ownerid)
                    {
                        if (Client.GetData<dynamic>("player_turf_blip_" + Main.getIdFromClient(target) + "") == false)
                        {
                            Client.TriggerEvent("blip_create_ext", "player_turf_" + Main.getIdFromClient(target), target.Position, FactionManage.faction_data[TurfWar.turf_war[tw].ownerid].faction_turf_color, 0.70f, 0);
                            Client.SetData<dynamic>("player_turf_blip_" + Main.getIdFromClient(target) + "", true);
                        }
                        else
                        {
                            Client.TriggerEvent("blip_move", "player_turf_" + Main.getIdFromClient(target), target.Position);
                        }
                    }
                }
            }
        }
    }

    public static void Update_Blip_Find(Player Client, Player target)
    {
        if (Client.GetData<dynamic>("status") == true && FactionManage.GetPlayerGroupID(Client) == 1 && target != Client)
        {
            if (Client.GetData<dynamic>("player_find" + Main.getIdFromClient(Client) + "") == false || Client.HasData("player_find" + Main.getIdFromClient(Client) + "") == false)
            {
                Client.TriggerEvent("blip_create_ext", "Phone_" + AccountManage.GetCharacterName(target), target.Position, 1, 0.80f, 0);
                Client.SetData<dynamic>("player_find" + Main.getIdFromClient(Client) + "", true);
            }
            else
            {
                target.TriggerEvent("blip_move", "player_" + Main.getIdFromClient(Client), Client.Position);
            }

        }
    }


    public static void Update_Blip_For_Player(Player Client)
    {
        foreach (Player target in API.Shared.GetAllPlayers())
        {
            if (target.GetData<dynamic>("status") == true && FactionManage.GetPlayerGroupID(target) == 1 && target != Client)
            {
                if (target.GetData<dynamic>("player_blip_" + Main.getIdFromClient(Client) + "") == false || target.HasData("player_blip_" + Main.getIdFromClient(Client) + "") == false)
                {
                    target.TriggerEvent("blip_create_ext", "player_" + Main.getIdFromClient(Client), Client.Position, 1, 0.80f, 0);
                    target.SetData<dynamic>("player_blip_" + Main.getIdFromClient(Client) + "", true);
                }
                else
                {
                    target.TriggerEvent("blip_move", "player_" + Main.getIdFromClient(Client), Client.Position);
                }

            }
        }
    }

    public static void Blip_Remove(Player Client)
    {
        foreach (Player target in API.Shared.GetAllPlayers())
        {
            if (target.GetData<dynamic>("status") == true)
            {
                if (target.GetData<dynamic>("player_blip_" + Main.getIdFromClient(Client) + "") == true)
                {
                    target.TriggerEvent("blip_remove", "player_" + Main.getIdFromClient(Client));
                    target.SetData<dynamic>("player_blip_" + Main.getIdFromClient(Client) + "", false);
                }


                if (target.GetData<dynamic>("player_turf_blip_" + Main.getIdFromClient(Client) + "") == true)
                {
                    target.TriggerEvent("blip_remove", "player_turf_" + Main.getIdFromClient(Client));
                    target.SetData<dynamic>("player_turf_blip_" + Main.getIdFromClient(Client) + "", false);
                }
            }
        }
    }

}

