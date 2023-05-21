using GTANetworkAPI;
using System;
using System.Collections.Generic;

class RobberyNPC : Script
{

    public static TimerEx[] player_robbery_timer { get; set; } = new TimerEx[Main.MAX_PLAYERS];


    public static int MAX_ROBBERY_NPC = 0;
    public class RobberyNPCEnum : IEquatable<RobberyNPCEnum>
    {
        public int id { get; set; }

        public string name { get; set; }
        public string model { get; set; }
        public Vector3 position { get; set; }
        public Vector3 caixa_1 { get; set; }
        public Vector3 caixa_2 { get; set; }
        public TextLabel textlabel { get; set; }

        public float heading { get; set; }
        public int robbery_state { get; set; }
        public bool robbery_reported { get; set; } = false;
        public int money { get; set; }
        //public Player owned { get; set; }
        public int time_remaining { get; set; }
        public DateTime time_vulnerable { get; set; }
        public int players_aiming { get; set; }

        public int cash_amount { get; set; }


        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            RobberyNPCEnum objAsPart = obj as RobberyNPCEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(RobberyNPCEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }
    public static List<RobberyNPCEnum> robbery_npc = new List<RobberyNPCEnum>();
    public static List<dynamic> Robbery_Blip = new List<dynamic>();

    public static void CreateRobberyNPC(string name, string model, Vector3 position, float heading, Vector3 caixa_1, Vector3 caixa_2)
    {
        robbery_npc.Add(new RobberyNPCEnum { id = MAX_ROBBERY_NPC, name = name, model = model, position = position, heading = heading, robbery_state = 0, players_aiming = 0, caixa_1 = caixa_1, caixa_2 = caixa_2, textlabel = API.Shared.CreateTextLabel("" + name + "", position + new Vector3(0, 0, 1.15), 5.0f, 0.3f, 4, new Color(221, 255, 0, 255), false, 0) });

        MAX_ROBBERY_NPC++;
    }

    public RobberyNPC()  // ig_mrk   //ig_manuel  // ig_taocheng
    {
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(24.47675, -1347.312, 29.49702), 266.0985f, new Vector3(24.47675, -1347.312, 29.49702), new Vector3(24.47675, -1347.312, 29.49702));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(-706.0944, -913.6349, 19.21561), 90.28362f, new Vector3(-706.0944, -913.6349, 19.21561), new Vector3(-706.0944, -913.6349, 19.21561));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(-1819.664, 793.7935, 138.0857), 131.3555f, new Vector3(-1819.664, 793.7935, 138.0857), new Vector3(-1819.664, 793.7935, 138.0857));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(-47.00174, -1758.323, 29.421), 64.01025f, new Vector3(-47.00174, -1758.323, 29.421), new Vector3(-47.00174, -1758.323, 29.421));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(-1486.48, -377.7018, 40.16343), 136.0111f, new Vector3(-1486.48, -377.7018, 40.16343), new Vector3(-1486.48, -377.7018, 40.16343));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(372.734, 327.3333, 103.5664), 248.5667f, new Vector3(372.734, 327.3333, 103.5664), new Vector3(372.734, 327.3333, 103.5664));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(1164.873, -323.3881, 69.20515), 98.66148f, new Vector3(1164.873, -323.3881, 69.20515), new Vector3(1164.873, -323.3881, 69.20515));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(-3242.331, 999.9945, 12.83071), 357.289f, new Vector3(-3242.331, 999.9945, 12.83071), new Vector3(-3242.331, 999.9945, 12.83071));
        CreateRobberyNPC("Prodavac", "g_m_y_lost_03", new Vector3(-3173.577, 1088.357, 20.83873), 244.3044f, new Vector3(-3173.577, 1088.357, 20.83873), new Vector3(-3173.577, 1088.357, 20.83873));
    
        
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(1727.791, 6415.229, 35.03723), 235.9682f, new Vector3(1727.791, 6415.229, 35.03723), new Vector3(1727.791, 6415.229, 35.03723));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(2678.062, 3279.332, 55.24113), 328.373f, new Vector3(2678.062, 3279.332, 55.24113), new Vector3(2678.062, 3279.332, 55.24113));
    
        
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(1134.17, -982.61, 46.41), -82.483f, new Vector3(1134.17, -982.61, 46.41), new Vector3(1134.17, -982.61, 46.41));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(-1221.99, -908.40, 12.32), 28.493f, new Vector3(-1221.99, -908.40, 12.32), new Vector3(-1221.99, -908.40, 12.32));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(1959.99, 3740.05, 32.34), -64.493f, new Vector3(1959.99, 3740.05, 32.34), new Vector3(1959.99, 3740.05, 32.34));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(1697.70, 4923.12, 42.06), -37.493f, new Vector3(1697.70, 4923.12, 42.06), new Vector3(1697.70, 4923.12, 42.06));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(1391.90, 3606.14, 34.98), -164.493f, new Vector3(1391.90, 3606.14, 34.98), new Vector3(1391.90, 3606.14, 34.98));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(-2966.34, 390.95,15.04), 86.493f, new Vector3(-2966.34, 390.95,15.04), new Vector3(-2966.34, 390.95,15.04));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(-3038.89, 584.48, 7.90), 14.253f, new Vector3(-3038.89, 584.48, 7.90), new Vector3(-3038.89, 584.48, 7.90));
        CreateRobberyNPC("Prodavac", "ig_popov", new Vector3(2557.23, 380.74, 108.62), -8.253f, new Vector3(2557.23, 380.74, 108.62), new Vector3(2557.23, 380.74, 108.62));

        OnRobberyTimer();
    }

    public static void OnPlayerConnect(Player Client)
    {
        Client.ResetData("store_rob");
        Client.SetSharedData("Player_Aiming_To", -1);
        int index = 0;
        foreach (var robbery in robbery_npc)
        {
            Client.TriggerEvent("CreateRobberyNPC", "robbery_npc_" + index, robbery.model, robbery.position, robbery.heading, index);
            index++;
        }
    }

    public void OnRobberyTimer()
    {
        TimerEx.SetTimer(() =>
        {
            int index = 0;
            foreach (var robbery in robbery_npc)
            {

                if (robbery.robbery_state == 1)
                {
                    if (robbery.time_remaining > 0)
                    {
                        robbery.time_remaining--;
                    }
                    if (true)
                    {

                    }
                    if (robbery.time_remaining == 0)
                    {
                        robbery.robbery_state = 0;
                        robbery.time_remaining = 0;
                        robbery.robbery_reported = false;
                        robbery.time_vulnerable = DateTime.Now.AddMinutes(30);
                        robbery.textlabel.Text = "[ ~b~Prodavac~w~ ]~n~~n~~y~((~w~ " + robbery.name + " ~y~))";
                    }

                    int count = 0;
                    foreach (var Player in NAPI.Pools.GetAllPlayers())
                    {
                        if (Player.GetData<dynamic>("status") == true && Main.IsInRangeOfPoint(Player.Position, robbery.position, 30.0f) && Player.GetSharedData<dynamic>("Player_Aiming_To") == index)
                        {
                            count++;
                        }
                    }

                    if (count == 0)
                    {
                        UpdateRobberyState(index, 0);
                        robbery.players_aiming = 0;
                        robbery.textlabel.Text = "[ ~b~PAZNJA~w~ ]~n~~n~~y~((~w~ " + robbery.name + " ~y~))";
                    }
                    else
                    {
                        UpdateRobberyState(index, 1);
                        robbery.players_aiming = 1;
                        robbery.textlabel.Text = "~r~** Prodavnica **~w~~n~~n~[ ~b~PAZNJA~w~ ]~n~~n~~y~((~w~ " + robbery.name + " ~y~))";
                    }
                }
                index++;
            }
        }, 1000, 0);
    }

    public static void UpdateRobberyState(int index, int state)
    {
        foreach (var Player in NAPI.Pools.GetAllPlayers())
        {
            if (Player.GetData<dynamic>("status") == true && Main.IsInRangeOfPoint(Player.Position, robbery_npc[index].position, 30.0f))
            {
                Player.TriggerEvent("SetRobberyState", "robbery_npc_" + index, state);
            }
        }
    }

    public static void keyPressE(Player Client)
    {
        foreach (var robbery in robbery_npc)
        {
            if (Main.IsInRangeOfPoint(Client.Position, robbery.position, 3.0f) && robbery.robbery_state == 1)
            {
                
                if (Client.HasData("store_rob"))
                {
                    Client.TriggerEvent("freezeEx", false);
                    Client.StopAnimation();
                    Client.ResetData("store_rob");
                    try
                    {
                        player_robbery_timer[Main.getIdFromClient(Client)].Kill();
                    }
                    catch
                    {

                    }
                    return;
                }
                if (robbery.players_aiming == 0)
                {
                    Main.SendCustomChatMessasge(Client, "~r~ Morate celo vreme drzati pistolj uperen u prodavca!");
                    return;
                }
                 
                Client.TriggerEvent("freezeEx", true);
                Client.PlayAnimation("oddjobs@shop_robbery@rob_till", "loop", 49);


                Client.SetData<dynamic>("store_rob", true);

                player_robbery_timer[Main.getIdFromClient(Client)] = TimerEx.SetTimer(() =>
                {
                    if (robbery.players_aiming == 0)
                    {
                        Main.SendCustomChatMessasge(Client, "~r~ Prodavac nema podignute ruke!");
                        Client.StopAnimation();
                        Client.TriggerEvent("freezeEx", false);
                        Client.SetData<dynamic>("store_rob", false);
                        return;
                    }

                    if (robbery.cash_amount > 500)
                    {
                        int money = 0;
                        Random rnd = new Random();
                        money = rnd.Next(40, 100);
                        robbery.cash_amount -= money;
                        //Inventory.GiveItemToInventory(Client, 18, money);
                        Main.GivePlayerMoney(Client, money);

                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "~g~$"+money+"~w~!");
                    }
                    else
                    {
                        if (robbery.cash_amount > 0)
                        {
                            // Inventory.GiveItemToInventory(Client, 18, robbery.cash_amount);
                            Main.GivePlayerMoney(Client, robbery.cash_amount);
                            Client.TriggerEvent("createNewHeadNotificationAdvanced", "~g~Opljackali ste. ~b~$" + robbery.cash_amount + "~g~!");
                            robbery.cash_amount = 0;
                        }

                        robbery.time_vulnerable = DateTime.Now.AddMinutes(30);

                        int index = robbery_npc.IndexOf(robbery);

                        Client.StopAnimation();
                        InteractMenu_New.SendNotificationInfo(Client, "Uzeli ste novac!");

                        Client.TriggerEvent("freezeEx", false);

                        UpdateRobberyState(robbery.id, 0);
                        robbery.players_aiming = 0;
                        robbery.robbery_state = 0;
                        robbery.robbery_reported = false;
                        robbery.time_remaining = 0;

                        robbery.textlabel.Text = "[ ~g~Prodavac 24-7~w~ ]~n~~n~~y~((~w~ Uplasen ~y~))";
                    }

                    Client.TriggerEvent("freezeEx", false);
                    Client.StopAnimation();
                    Client.ResetData("store_rob");
                    try
                    {
                        player_robbery_timer[Main.getIdFromClient(Client)].Kill();
                    }
                    catch
                    {

                    }

                }, 2300, 1);


                return;
            }
        }
    }



    [RemoteEvent("Players_Aiming_To")]
    public static void startRobbery(Player Client, int index)
    {
        if (index != -1)
        {
            if (Main.IsInRangeOfPoint(Client.Position, robbery_npc[index].position, 10.0f))
            {
                if (robbery_npc[index].robbery_state == 0)
                {
                    if (DateTime.Now < robbery_npc[index].time_vulnerable)
                    {
                        if (!Client.HasData("temp_message"))
                        {
                            Client.SetData<dynamic>("temp_message", true);
                            var time_left = robbery_npc[index].time_vulnerable.Subtract(DateTime.Now);
                            var res = String.Format($"{time_left.Minutes} minuta i {time_left.Seconds} sekundi");
                            Main.SendErrorMessage(Client, "Neko je vec opljackao ovu prodavnicu! ~c~~n~~n~ Prodavnica ce biti dostupna za " + res + ".");
                        }

                        TimerEx.SetTimer(() =>
                        {
                            Client.ResetData("temp_message");
                        }, 8000, 1);
                        return;
                    }

                    if (Client.GetData<dynamic>("primary_weapon") == 0 && Client.GetData<dynamic>("secundary_weapon") == 0 && Client.GetData<dynamic>("pistol_weapon") == 0)
                    {
                        Main.DisplaySubtitle(Client, "Nemate vatreno oruzje.");
                        return;
                    }

                    int can_pass = 0;

                    if (NAPI.Player.GetPlayerCurrentWeapon(Client) != WeaponHash.Unarmed)
                    {
                        can_pass = 1;
                    }
                    else if (NAPI.Player.GetPlayerCurrentWeapon(Client) != WeaponHash.Unarmed)
                    {
                        can_pass = 1;
                    }

                    if (can_pass == 0)
                    {
                        Main.DisplaySubtitle(Client, "Nemate vatreno oruzje.");
                        return;
                    }


                    int count = 0;
                    foreach (Player target in NAPI.Pools.GetAllPlayers())
                    {
                        if (target.GetData<dynamic>("status") == true && AccountManage.GetPlayerGroup(target) == 1 && target.GetData<dynamic>("duty") == 1)
                        {
                            count++;
                        }
                    }

                      

                    /*if (count <= 2)
                    {
                        Main.DisplaySubtitle(Client, "Na serveru nema 2 policajca.");
                        return;
                    }*/


                    int faction_id = AccountManage.GetPlayerGroup(Client);

                    //Main.SendMessageToAll(Main.EMBED_LIGHTRED + "[Rob]: ~w~ A ~b~ SuperMarket ~w~ is being Robbed by the faction" + Main.EMBED_LIGHTRED + "" + FactionManage.faction_data[faction_id].faction_name + "" + Main.EMBED_WHITE + ".");
                    Main.SendCustomChatMessasge(Client,Main.EMBED_GREY + "Ciljajte u prodavca dok Vas prijatelj vadi novac.");



                    robbery_npc[index].time_remaining = 200;
                    robbery_npc[index].cash_amount = 4000;
                    robbery_npc[index].robbery_state = 1;
                    robbery_npc[index].players_aiming = 1;
                    UpdateRobberyState(index, 1);
                }
            }
        }
        else if (Client.GetSharedData<dynamic>("Player_Aiming_To") != -1 && index == -1)
        {
            int indexid = Client.GetSharedData<dynamic>("Player_Aiming_To");
            robbery_npc[indexid].players_aiming = 0;
            if (Main.IsInRangeOfPoint(Client.Position, robbery_npc[indexid].position, 10.0f))
            {
                if (robbery_npc[indexid].robbery_state == 1 && robbery_npc[indexid].robbery_reported == false)
                {
                    foreach (Player target in NAPI.Pools.GetAllPlayers())
                    {
                        if (target.GetData<dynamic>("status") == true && AccountManage.GetPlayerGroup(target) == 1)
                        {
                            Main.PlaySoundClientSide(target, "arobbery", 0.2f);
                            Main.SendCustomChatMessasge(target,Main.EMBED_BLUE + "[CENTRALA]" + Main.EMBED_COP_Message + "Paznja svim jedinicama, u toku je pljacka prodavnice !");
                            //     Main.PlaySoundClientSide(target,);
                            Set_Robbery_Blip(indexid);
                            robbery_npc[indexid].robbery_reported = true;
                            TimerEx.SetTimer(() =>
                            {
                                foreach (Player pl in NAPI.Pools.GetAllPlayers())
                                {
                                    if (pl.GetData<dynamic>("status") == true && AccountManage.GetPlayerGroup(pl) == 1)
                                    {
                                        Remove_Robbery_Blip(indexid);
                                    }
                                }
                            }, 80000, 1);

                        }
                    }
                }
            }

        }
        Client.SetSharedData("Player_Aiming_To", index);
    }

    public void police_report(Player Client, string name)
    {
        Client.TriggerEvent("PlayPoliceReport", name);
    }

    public static void Set_Robbery_Blip(int index)
    {
        foreach (Player target in API.Shared.GetAllPlayers())
        {
            if (target.GetData<dynamic>("status") == true && FactionManage.GetPlayerGroupID(target) == 1)
            {
                if (target.GetData<dynamic>("Rob_ID_" + index + "") == false || target.HasData("Rob_ID_" + index + "") == false)
                {
                    target.TriggerEvent("blip_create_ext", "Situation_" + index, robbery_npc[index].position, 49, 2f, 8);
                    target.SetData<dynamic>("Rob_ID_" + index + "", true);
                    Robbery_Blip.Add(new { id = index });
                }
            }
        }
    }

    public static void Remove_Robbery_Blip(int index)
    {
        try
        {

            foreach (Player target in API.Shared.GetAllPlayers())
            {
                if (target.GetData<dynamic>("status") == true)
                {
                    if (target.HasData("Rob_ID_" + index + "") && target.GetData<dynamic>("Rob_ID_" + index + "") == true)
                    {
                        target.TriggerEvent("blip_remove", "Situation_" + index);
                        target.SetData<dynamic>("Rob_ID_" + index + "", false);
                        foreach (var item in Robbery_Blip)
                        {
                            if (item.id == index)
                            {
                                Robbery_Blip.Remove(item);
                                return;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }
    }
}
