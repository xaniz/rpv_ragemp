using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

//telefonn
class cellphoneSystem : Script
{

    public class ContactEnum : IEquatable<ContactEnum>
    {
        public int id { get; set; }

        public string[] contact_name { get; set; } = new string[60];
        public int[] contact_number { get; set; } = new int[60];


        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ContactEnum objAsPart = obj as ContactEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(ContactEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }
    public static List<ContactEnum> contacts_data = new List<ContactEnum>();


    public class CallEnum : IEquatable<CallEnum>
    {
        public int id { get; set; }

        public Player player_one { get; set; }
        public Player player_two { get; set; }

        public int active { get; set; }
        public int time { get; set; }


        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            CallEnum objAsPart = obj as CallEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(CallEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<CallEnum> call_data = new List<CallEnum>();
    public static List<TimerEx> ringtone_time = new List<TimerEx>();



    public static async void LoadContacts(Player Client)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            await Mainpipeline.OpenAsync();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `contacts` WHERE `owner` = '" + AccountManage.GetPlayerSQLID(Client) + "' LIMIT 60;", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                int count = 0;
                while (await reader.ReadAsync())
                {
                    contacts_data[Main.getIdFromClient(Client)].contact_name[count] = reader.GetString("name");
                    contacts_data[Main.getIdFromClient(Client)].contact_number[count] = reader.GetInt32("number");
                    count++;
                }
            }
        }
    }


    public cellphoneSystem()
    {
        for (int i = 0; i < 100; i++)
        {
            call_data.Add(new CallEnum { id = i, active = 0, time = 0, player_one = null, player_two = null });
        }
    }

    public static void NewNumber(Player Client)
    {
        Random rnd = new Random();
        int random_number = rnd.Next(100000, 999999);

        Client.SetData<dynamic>("character_cellphone", random_number);

        Main.SendCustomChatMessasge(Client,"Vas broj telefona : ~b~" + String.Format("{0:###-###}", random_number) + "~w~.");

        if (cellphoneSystem.GetPlayerNumber(Client) != 0)
        {
            Client.TriggerEvent("initPhone");
            Client.TriggerEvent("setPhoneNumber", cellphoneSystem.GetPlayerNumber(Client));
        }
    }

    public static int GetPlayerNumber(Player Client)
    {
        if (Client.HasData("character_cellphone"))
        {
            return Client.GetData<dynamic>("character_cellphone");
        }
        return 0;
    }

    public static void DisplayNewContact(Player Client)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Ime", Description = "", RightLabel = "" + Client.GetData<dynamic>("contact_name") + "" });
        menu_item_list.Add(new { Type = 1, Name = "Broj", Description = "", RightLabel = "" + Client.GetData<dynamic>("contact_number") + "" });
        menu_item_list.Add(new { Type = 1, Name = "~g~Home", Description = "", RightLabel = "" });
        InteractMenu.CreateMenu(Client, "CELLPHONE_ADD_CONTACT", "Telefon", "~b~Dodaj - ~g~kontakt", false, NAPI.Util.ToJson(menu_item_list), false);
    }

    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "CELLPHONE_RESPONSE")
        {
            int playerid = Main.getIdFromClient(Client);
            switch (selectedIndex)
            {
                case 0:
                    {
                        InteractMenu.User_Input(Client, "CALL_NUMBER", "Telefon :", "0", "", "number");
                        break;
                    }
                case 1:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        menu_item_list.Add(new { Type = 1, Name = "Nepoznato", Description = "", RightLabel = "", BackgroundColor = new Color(38, 38, 38), FrontColor = new Color(221, 255, 0) });

                        int count = 0;
                        for (int i = 0; i < 60; i++)
                        {
                            if (cellphoneSystem.contacts_data[playerid].contact_number[i] != 0)
                            {
                                menu_item_list.Add(new { Type = 1, Name = "~s~" + i + ".~c~ " + cellphoneSystem.contacts_data[playerid].contact_name[i] + "", Description = "Kontakt: ~y~" + cellphoneSystem.contacts_data[playerid].contact_number[i] + "", RightLabel = "~s~>>", BackgroundColor = new Color(38, 38, 38), FrontColor = new Color(221, 255, 0) });

                                Client.SetData<dynamic>("ListTrack_" + count + "", i);

                            }
                            count++;
                        }
                        InteractMenu.CreateMenu(Client, "CELLPHONE_CONTACTS", "mobile", "~b~Telefonski broj ~y~#" + String.Format("{0:###-###}", GetPlayerNumber(Client)) + "~b~", false, NAPI.Util.ToJson(menu_item_list), false);
                        break;
                    }
                case 2:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        menu_item_list.Add(new { Type = 1, Name = "Medic", Description = "" });
                        menu_item_list.Add(new { Type = 1, Name = "Police", Description = "" });
                        menu_item_list.Add(new { Type = 1, Name = "Mecanic", Description = "" });
                        menu_item_list.Add(new { Type = 1, Name = "Taxi", Description = "" });
                        InteractMenu.CreateMenu(Client, "CALL_SYSTEM_RESPONSE", "Mobile", "~b~Telefonski broj ~y~#" + String.Format("{0:###-###}", GetPlayerNumber(Client)) + "~b~", false, NAPI.Util.ToJson(menu_item_list), false);
                        break;
                    }
                case 3:
                    {
                        InteractMenu.User_Input(Client, "PUT_ANNOUNCE", "Oglas", "0");
                        break;
                    }

            }
        }
        else if (callbackId == "CELLPHONE_CONTACTS")
        {
            if (selectedIndex == 0)
            {
                Client.SetData<dynamic>("contact_name", "");
                Client.SetData<dynamic>("contact_number", 999999999);
                DisplayNewContact(Client);
            }
            else
            {

                int i = Client.GetData<dynamic>("ListTrack_" + (selectedIndex - 1) + "");
                int playerid = Main.getIdFromClient(Client);

                Client.SetData<dynamic>("contact_id", i);

                if (contacts_data[playerid].contact_number[i] == 0)
                {
                    return;
                }

                List<dynamic> menu_item_list = new List<dynamic>();
                menu_item_list.Add(new { Type = 1, Name = "Kontakti", Description = "", RightLabel = "", BackgroundColor = new Color(38, 38, 38), FrontColor = new Color(221, 255, 0) });
                menu_item_list.Add(new { Type = 1, Name = "Kontakti", Description = "", RightLabel = "" });
                menu_item_list.Add(new { Type = 1, Name = "~r~Obrisi kontakt", Description = "", RightLabel = "" });
                InteractMenu.CreateMenu(Client, "CELLPHONE_CONTACT_RESPONSE", "Mobile", "~b~" + contacts_data[playerid].contact_name[i] + " - ~y~#" + String.Format("{0:###-###}", contacts_data[playerid].contact_number[i]) + "~b~:", false, NAPI.Util.ToJson(menu_item_list), false);

            }
        }
        else if (callbackId == "CELLPHONE_CONTACT_RESPONSE")
        {
            int i = Client.GetData<dynamic>("contact_id");
            int playerid = Main.getIdFromClient(Client);

            if (contacts_data[playerid].contact_number[i] == 0)
            {

                return;
            }
            if (selectedIndex == 0)
            {
                Call_Number(Client, contacts_data[playerid].contact_number[i]);
            }
            else if (selectedIndex == 1)
            {
                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if (target.GetData<dynamic>("status") == true)
                    {
                        if (contacts_data[playerid].contact_number[i] == GetPlayerNumber(target))
                        {
                            InteractMenu.User_Input(Client, "SEND_SMS", "Posalji poruku", "...");
                            Client.SetData<dynamic>("handle_sms", target);
                            return;
                        }
                    }
                }
                Main.SendErrorMessage(Client, "Mreza je slaba.");
            }
            else if (selectedIndex == 2)
            {
                Main.SendCustomChatMessasge(Client,"* Obrisali ste ~b~" + cellphoneSystem.contacts_data[playerid].contact_name[i] + " ~c~(Number #" + cellphoneSystem.contacts_data[playerid].contact_number[i] + "~w~ iz liste kontakata.");

                Main.CreateMySqlCommand("DELETE FROM `contacts` WHERE `number` = '" + cellphoneSystem.contacts_data[playerid].contact_number[i] + "';");

                cellphoneSystem.contacts_data[playerid].contact_name[i] = null;
                cellphoneSystem.contacts_data[playerid].contact_number[i] = 0;
            }
        }
        else if (callbackId == "CELLPHONE_ADD_CONTACT")
        {
            int playerid = Main.getIdFromClient(Client);
            switch (selectedIndex)
            {
                case 0:
                    {
                        InteractMenu.User_Input(Client, "ADD_NAME", "Naziv kontakta", Client.GetData<dynamic>("contact_name").ToString());
                        break;
                    }
                case 1:
                    {
                        InteractMenu.User_Input(Client, "ADD_NUMBER", "Broj", Client.GetData<dynamic>("contact_number").ToString());
                        break;
                    }
                case 2:
                    {
                        if (Client.GetData<dynamic>("contact_name") == "")
                        {
                            Main.SendErrorMessage(Client, "Pogresan unos.");
                            DisplayNewContact(Client);
                            return;
                        }

                        if (Client.GetData<dynamic>("contact_number") == 999999999 || Client.GetData<dynamic>("contact_number") == 0)
                        {
                            Main.SendErrorMessage(Client, "Pogresan unos.");
                            DisplayNewContact(Client);
                            return;
                        }

                        for (int i = 0; i < 60; i++)
                        {
                            if (cellphoneSystem.contacts_data[playerid].contact_number[i] == Client.GetData<dynamic>("contact_number"))
                            {
                                Main.SendErrorMessage(Client, "Pogresan broj.");
                                return;
                            }
                        }

                        for (int i = 0; i < 60; i++)
                        {
                            if (cellphoneSystem.contacts_data[playerid].contact_number[i] == 0)
                            {
                                cellphoneSystem.contacts_data[playerid].contact_name[i] = Client.GetData<dynamic>("contact_name");
                                cellphoneSystem.contacts_data[playerid].contact_number[i] = Client.GetData<dynamic>("contact_number");

                                Main.SendCustomChatMessasge(Client, "* Dodali ste ~b~" + Client.GetData<dynamic>("contact_name") + " ~c~(Number #" + Client.GetData<dynamic>("contact_number") + ")~w~ na listu kontakata.");

                                string query = "INSERT INTO `contacts` (owner, name, number) VALUES (" + AccountManage.GetPlayerSQLID(Client) + ", '" + Client.GetData<dynamic>("contact_name") + "', " + Client.GetData<dynamic>("contact_number") + ");";
                                Main.CreateMySqlCommand(query);
                                return;
                            }
                        }
                        Main.SendErrorMessage(Client, "Mreza je slaba.");
                        break;
                    }
            }
        }
    }

    public static void OnInputResponse(Player Client, String response, String inputtext)
    {
        if (response == "CALL_NUMBER")
        {
            if (!Main.IsNumeric(inputtext))
            {
                Main.SendErrorMessage(Client, "Koristite brojeve, a ne slova.");
                return;
            }

            int target_number = Convert.ToInt32(inputtext.Replace("-", ""));
            Call_Number(Client, target_number);
        }
        else if (response == "SEND_SMS")
        {

            string sms_text = inputtext;

            if (sms_text.Length < 2 || sms_text.Length > 120)
            {
                Main.SendErrorMessage(Client, "Broj karaktera ne moze biti manji od 2 ili veci od 120.");
                return;
            }

            Player sms_handle = Client.GetData<dynamic>("handle_sms");

            if (!NAPI.Player.IsPlayerConnected(sms_handle))
            {
                Main.SendErrorMessage(Client, "Mreza je slaba.");
                return;
            }

            if (sms_handle.GetData<dynamic>("status") == false)
            {
                Main.SendErrorMessage(Client, "Mreza je slaba.");
                return;
            }


            //"BN_ShowWithPicture", title, sender, message, notifPic, icon, flashing, textColor, bgColor, flashColor
            sms_handle.TriggerEvent("BN_ShowWithPicture", "Primili ste novu poruku", "Posiljalac: N# " + String.Format("{0:###-###}", GetPlayerNumber(Client)) + "", inputtext, "CHAR_LIFEINVADER");
            //Main.sendme
            Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "*", "Poruka uspesno poslata na broj: " + String.Format("{0:###-###}", GetPlayerNumber(Client)) + ".");
            Main.SendMessageWithTagToPlayer(sms_handle, "" + Main.EMBED_YELLOW + "[Primili ste SMS sa broja N# " + String.Format("{0:###-###}", GetPlayerNumber(Client)) + "]", "" + Main.EMBED_YELLOW + "" + inputtext + "");
        }
        else if (response == "ADD_NAME")
        {

            string name = inputtext;

            if (name.Length < 3 || name.Length > 24)
            {
                Main.SendErrorMessage(Client, "Unos ne sme biti manji od 3 ili veci od 24 karaktera.");
                DisplayNewContact(Client);
                return;
            }

            Client.SetData<dynamic>("contact_name", name);
            DisplayNewContact(Client);
        }
        else if (response == "ADD_NUMBER")
        {

            if (!Main.IsNumeric(inputtext))
            {
                Main.SendErrorMessage(Client, "Unesite broj telefona.");
                DisplayNewContact(Client);
                return;
            }

            if (inputtext.Length < 3 || inputtext.Length > 24)
            {
                Main.SendErrorMessage(Client, "Unos ne sme biti manji od 3 ili veci od 24 karaktera.");
                DisplayNewContact(Client);
                return;
            }

            int number = Convert.ToInt32(inputtext);

            Client.SetData<dynamic>("contact_number", number);
            DisplayNewContact(Client);
        }
        else if (response == "PUT_ANNOUNCE")
        {
            return;
        }
        else if (response == "ADD_UI_NAME")
        {

            string name = inputtext;
            int playerid = Main.getIdFromClient(Client);

            if (name.Length < 3 || name.Length > 24)
            {
                Main.SendErrorMessage(Client, "Unos ne sme biti manji od 3 ili veci od 24 karaktera.");
                DisplayNewContact(Client);
                return;
            }

            if (name == "")
            {
                Main.SendErrorMessage(Client, "Pogresan unos.");
                DisplayNewContact(Client);
                return;
            }

            if (Client.GetData<dynamic>("contact_number") == 999999999 || Client.GetData<dynamic>("contact_number") == 0)
            {
                Main.SendErrorMessage(Client, "Pogresan unos.");
                DisplayNewContact(Client);
                return;
            }

            for (int i = 0; i < 60; i++)
            {
                if (cellphoneSystem.contacts_data[playerid].contact_number[i] == Client.GetData<dynamic>("contact_number"))
                {
                    Main.SendErrorMessage(Client, "Pogresan unos.");
                    return;
                }
            }

            for (int i = 0; i < 60; i++)
            {
                if (cellphoneSystem.contacts_data[playerid].contact_number[i] == 0)
                {
                    cellphoneSystem.contacts_data[playerid].contact_name[i] = name;
                    cellphoneSystem.contacts_data[playerid].contact_number[i] = Client.GetData<dynamic>("contact_number");

                    Main.SendCustomChatMessasge(Client,"* Nov kontakt ~b~" + name + " ~c~(Number #" + Client.GetData<dynamic>("contact_number") + ")~w~ sacuvan.");

                    string query = "INSERT INTO `contacts` (owner, name, number) VALUES (" + AccountManage.GetPlayerSQLID(Client) + ", '" + name + "', " + Client.GetData<dynamic>("contact_number") + ");";
                    Main.CreateMySqlCommand(query);
                    Update_Contacts(Client);
                    return;
                }
            }
            Main.SendErrorMessage(Client, "Mreza je slaba.");
        }

    }

    public static void Call_Number(Player Client, int target_number)
    {


        if (target_number == 0)
        {
            Client.SendNotification("Odabrali ste nepostojeci broj.");
            Client.TriggerEvent("denyCall");
            return;
        }

      /*  foreach (var service in Services.service_system)
        {
            if (service.active == 1 && service.caller == Client)
            {
                Client.SendNotification("Greska: Shoamre eshgahl mibashad.");
                Client.TriggerEvent("denyCall");
                return;
            }
        }*/

        if (target_number == 911)
        {
            Services.Call_Service(Client, 911);
            return;
        }
        else if (target_number == 912)
        {
            Services.Call_Service(Client, 912);
            return;
        }
        else if (target_number == 913)
        {
            Services.Call_Service(Client, 913);
            return;
        }
        else if (target_number == 914)
        {
            Services.Call_Service(Client, 914);
            return;
        }

        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (target.GetData<dynamic>("status") == true)
            {
                if (GetPlayerNumber(target) == target_number && Client != target)
                {
                    foreach (var call in call_data)
                    {
                        if (call.active == 0)
                        {
                            call.active = 1;
                            call.player_one = Client;
                            call.player_two = target;

                            Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Telefon]", "" + Main.EMBED_YELLOW + "Pozvali ste: " + String.Format("{0:###-###}", target.GetData<dynamic>("character_cellphone")) + ", koristite (/h) da prekinete poziv.");
                            Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_YELLOW + "[Telefon]", "" + Main.EMBED_YELLOW + "Vas telefon zvoni, zove Vas " + String.Format("{0:###-###}", Client.GetData<dynamic>("character_cellphone")) + ", koristite (/answer) da se javite.");


                            List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
                            foreach (Player alvo in proxPlayers)
                            {
                                // alvo.Trigger Chat", "", "<font color ='#C2A2DA'>* The cell phone from " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " it's playing.");
                                alvo.TriggerEvent("playRingtone", Main.getIdFromClient(target));
                            }
                            Main.EmoteMessage(target, "~y~** Telefon zvoni .. * *");

                            int targetid = Main.getIdFromClient(target);
                            ringtone_time[targetid] = TimerEx.SetTimer(() =>
                            {

                                foreach (Player alvo in proxPlayers)
                                {
                                    // alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* Mobile " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " Darad Zang Mikhorad.");
                                    //alvo.TriggerEvent("incomingCallFor", Main.getIdFromClient(target));
                                    //alvo.TriggerEvent("playRingtone", Main.getIdFromClient(target));
                                }
                                Main.StopAudioClientSide(call.player_one);
                                Main.StopAudioClientSide(call.player_two);

                                Main.PlaySoundClientSide(call.player_one, "chamando", 0.4f);
                                Main.PlaySoundClientSide(call.player_two, "ring", 0.4f);

                                // call.player_one.TriggerEvent("playClientSound", "chamando", 0.2f);


                                Main.EmoteMessage(target, "~y~**Telefon zvoni. * *");

                            }, 4000, 30);

                            //TogglePhone(target, true);//RaminTest


                            //Client.TriggerEvent("Calling_Type", 1, AccountManage.GetCharacterName(target), GetPlayerNumber(target));
                            //target.TriggerEvent("Calling_Type", 4, AccountManage.GetCharacterName(Client), GetPlayerNumber(Client));

                            target.TriggerEvent("incomingCall", Client, GetPlayerNumber(Client));
                            //Client.TriggerEvent("incomingCall", target, GetPlayerNumber(target));
                            return;
                        }
                    }
                }
            }
        }
        //Client.TriggerEvent("incomingCall", null, target_number);
        Client.TriggerEvent("denyCall");
    }

    public static void FinishCall(Player Client)
    {
        foreach (var call in cellphoneSystem.call_data)
        {
            if ((call.player_one != null && NAPI.Player.IsPlayerConnected(call.player_one)) || (call.player_one != null && NAPI.Player.IsPlayerConnected(call.player_two)))
            {
                if ((call.player_one.GetData<dynamic>("status") == true && call.player_one == Client) || (call.player_two.GetData<dynamic>("status") == true && call.player_two == Client))
                {

                    if (call.player_one == Client)
                    {
                        Main.SendMessageWithTagToPlayer(call.player_two, "" + Main.EMBED_YELLOW + "", "[Telefon]" + Main.EMBED_WHITE + " Poziv je prekinut.");
                    }
                    else if (call.player_two == Client)
                    {
                        Main.SendMessageWithTagToPlayer(call.player_one, "" + Main.EMBED_YELLOW + "[Telefon]", "" + Main.EMBED_WHITE + " Poziv je zavrsen.");
                    }

                    if (cellphoneSystem.ringtone_time[Main.getIdFromClient(call.player_one)] != null)
                    {
                        cellphoneSystem.ringtone_time[Main.getIdFromClient(call.player_one)].Kill();
                        cellphoneSystem.ringtone_time[Main.getIdFromClient(call.player_one)] = null;
                    }

                    if (cellphoneSystem.ringtone_time[Main.getIdFromClient(call.player_two)] != null)
                    {
                        cellphoneSystem.ringtone_time[Main.getIdFromClient(call.player_two)].Kill();
                        cellphoneSystem.ringtone_time[Main.getIdFromClient(call.player_two)] = null;
                    }

                    Main.EmoteMessage(Client, "");



                    call.player_one.TriggerEvent("voice.phoneStop");
                    call.player_one.TriggerEvent("v_reload");

                    call.player_two.TriggerEvent("voice.phoneStop");
                    call.player_two.TriggerEvent("v_reload");


                    call.active = 0;
                    call.time = 0;
                    call.player_two = null;
                    call.player_one = null;
                }
            }
        }
    }

    [Command("an", Alias = "answer")]
    public static void CMD_atender(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }

        if (Client.GetSharedData<dynamic>("Injured") != 0)
        {
            Client.SendNotification("Greska:~n~Ne mozete to dok ste povredjeni!");
            return;
        }

        if (Client.GetData<dynamic>("playerCuffed") != 0)
        {
            Client.SendNotification("Greska:~n~Ne mozete to dok ste vezani!");
            return;
        }

        if (Client.GetData<dynamic>("character_prison") != 0)
        {
            Client.SendNotification("Greska:~n~Telefon Vam je oduzet dok ste u zatvoru!");
            return;
        }


        foreach (var call in call_data)
        {
            if (call.active != 0)
            {
                if (call.player_one != null && NAPI.Player.IsPlayerConnected(call.player_one))
                {
                    if (Client.GetData<dynamic>("status") == true && call.player_two == Client)
                    {
                        call.active = 2;

                        Main.SendMessageWithTagToPlayer(call.player_two, "" + Main.EMBED_YELLOW + "[Telefon]", "" + Main.EMBED_YELLOW + "Javili ste se");
                        Main.SendMessageWithTagToPlayer(call.player_one, "" + Main.EMBED_YELLOW + "[Telefon]", "" + Main.EMBED_YELLOW + "" + String.Format("{0:###-###}", call.player_two.GetData<dynamic>("character_cellphone")) + " se javio na telefon.");

                        Main.SendMessageWithTagToPlayer(call.player_one, "" + Main.EMBED_YELLOW + "[Telefon]", "" + Main.EMBED_WHITE + "Podsetnik: Koristite " + Main.EMBED_LIGHTGREEN + "N" + Main.EMBED_WHITE + " da razgovarate preko telefona, ili " + Main.EMBED_LIGHTGREEN + "(/h)" + Main.EMBED_WHITE + " da prekinete poziv.");
                        Main.SendMessageWithTagToPlayer(call.player_two, "" + Main.EMBED_YELLOW + "[Telefon]", "" + Main.EMBED_WHITE + "Podsetnik: Koristite " + Main.EMBED_LIGHTGREEN + "N" + Main.EMBED_WHITE + " da razgovarate preko telefona, ili " + Main.EMBED_LIGHTGREEN + "(/h)" + Main.EMBED_WHITE + " da prekinete poziv.");

                        //Client.TriggerEvent("changeCallStatus", 1, "Mike Bishop");

                        Main.EmoteMessage(Client, "");

                        call.player_two.TriggerEvent("callAccepted", call.player_one, GetPlayerNumber(call.player_one));
                        call.player_one.TriggerEvent("callAccepted", call.player_two, GetPlayerNumber(call.player_two));

                        Main.StopAudioClientSide(call.player_one);
                        Main.StopAudioClientSide(call.player_two);

                        call.player_one.TriggerEvent("voice.phoneCall", call.player_two);
                        call.player_two.TriggerEvent("voice.phoneCall", call.player_one);

                        call.player_two.TriggerEvent("v_reload");
                        call.player_one.TriggerEvent("v_reload");

                        if (ringtone_time[Main.getIdFromClient(Client)] != null)
                        {
                            ringtone_time[Main.getIdFromClient(Client)].Kill();
                            ringtone_time[Main.getIdFromClient(Client)] = null;
                        }

                    }
                }
            }
        }
    }

    public static void CMD_RV(Player Client)
    {
        Client.TriggerEvent("v_reload");
        Client.TriggerEvent("v_checklisten", Client);
    }

    public static void CMD_desligasr(Player Client)
    {
        Client.TriggerEvent("showr");
    }

    public static void showg(Player Client)
    {
        Client.TriggerEvent("showg");
    }

    public static void CMD_desligar(Player Client)
    {
        // Services.Remove_Service(Client);

        // =====
        foreach (var call in call_data)
        {
            if (call.active != 0)
            {
                if (NAPI.Player.IsPlayerConnected(call.player_one) || NAPI.Player.IsPlayerConnected(call.player_two))
                {
                    if ((call.player_one.GetData<dynamic>("status") == true && call.player_one == Client) || (call.player_two.GetData<dynamic>("status") == true && call.player_two == Client))
                    {

                        if (call.player_one == Client)
                        {
                            Main.SendMessageWithTagToPlayer(call.player_one, "" + Main.EMBED_YELLOW + "[Telefon]", "" + Main.EMBED_WHITE + "Imate propusten poziv.");
                            Main.SendMessageWithTagToPlayer(call.player_two, "" + Main.EMBED_YELLOW + "[Telefon]", "" + Main.EMBED_WHITE + "Vas poziv je prekinut.");
                        }
                        else if (call.player_two == Client)
                        {
                            Main.SendMessageWithTagToPlayer(call.player_two, "" + Main.EMBED_YELLOW + "[Telefon]", "" + Main.EMBED_WHITE + "Imate propusten poziv.");
                            Main.SendMessageWithTagToPlayer(call.player_one, "" + Main.EMBED_YELLOW + "[Telefon]", "" + Main.EMBED_WHITE + "Vas poziv je prekinut.");
                        }

                        if (ringtone_time[Main.getIdFromClient(call.player_one)] != null)
                        {
                            ringtone_time[Main.getIdFromClient(call.player_one)].Kill();
                            ringtone_time[Main.getIdFromClient(call.player_one)] = null;
                        }

                        if (ringtone_time[Main.getIdFromClient(call.player_two)] != null)
                        {
                            ringtone_time[Main.getIdFromClient(call.player_two)].Kill();
                            ringtone_time[Main.getIdFromClient(call.player_two)] = null;
                        }

                        Main.StopAudioClientSide(call.player_one);
                        Main.StopAudioClientSide(call.player_two);

                        call.player_two.TriggerEvent("callEnded");
                        call.player_one.TriggerEvent("callEnded");

                        call.player_one.TriggerEvent("voice.phoneStop");
                        call.player_two.TriggerEvent("voice.phoneStop");

                        call.player_two.TriggerEvent("v_reload");
                        call.player_one.TriggerEvent("v_reload");

                        call.active = 0;
                        call.time = 0;
                        call.player_two = null;
                        call.player_one = null;
                        return;
                    }
                }
            }
        }
    }

    [RemoteEvent("keypress:ARROW_UP")]
    public static void DisplayPhone(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            
            return;
        }

        if (GetPlayerNumber(Client) == 0)
        {
            return;
        }

        if (Client.GetData<dynamic>("startFurnitureEditing") == true || Client.GetData<dynamic>("startEditing") == true)
        {
            
            return;
        }

        if (Client.GetData<dynamic>("General_CEF") == true)
        {
            
            return;
        }

        if (Client.GetData<dynamic>("playerCuffed") != 0)
        {
            Main.SendErrorMessage(Client, "Ne mozete to dok ste vezani.");
            return;
        }

        if (Client.GetData<dynamic>("character_prison") != 0)
        {
            Main.SendErrorMessage(Client, "Telefon Vam je oduzet dok ste u zatvoru.");
            return;
        }

        if (Client.HasData("ls_customs"))
        {
            
            return;
        }

        if (Client.GetData<dynamic>("phone_enable") == true)
        {
            
            TogglePhone(Client, false);
        }
        else
        {
            
            TogglePhone(Client, true);
        }

    }


    public static void TogglePhone(Player Client, bool enable)
    {
        if (enable == true)
        {

            Client.SetData<dynamic>("phone_enable", true);
            Client.TriggerEvent("openPhone", false);

            Update_Contacts(Client);
        }
        else
        {
            Client.SetData<dynamic>("phone_enable", false);
            Client.TriggerEvent("closePhone");
        }
    }

    public static void Update_Contacts(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);
        List<dynamic> menu_item_list = new List<dynamic>();

        for (int i = 0; i < 60; i++)
        {
            if (cellphoneSystem.contacts_data[playerid].contact_number[i] != 0)
            {
                menu_item_list.Add(new { index = i, name = cellphoneSystem.contacts_data[playerid].contact_name[i], number = cellphoneSystem.contacts_data[playerid].contact_number[i] });

            }
        }
        Client.TriggerEvent("Update_Contacts", NAPI.Util.ToJson(menu_item_list));
    }


    [RemoteEvent("Show_SMS")]
    public static void Show_SMS(Player Client)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `sms` WHERE `send_from_id` = '" + GetPlayerNumber(Client) + "' OR `send_to_id` = '" + GetPlayerNumber(Client) + "' ORDER BY id DESC LIMIT 60;", Mainpipeline);


            List<dynamic> menu_item_list = new List<dynamic>();
            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                int count = 0;
                while (reader.Read())
                {
                    int can_pass = 0;
                    foreach (var data in menu_item_list)
                    {
                        if (data.number == reader.GetInt32("send_from_id") || data.number == reader.GetInt32("send_to_id"))
                        {
                            can_pass = 1;
                        }
                    }

                    // 

                    if (can_pass == 0)
                    {

                        if (GetPlayerNumber(Client) != reader.GetInt32("send_to_id"))
                        {
                            menu_item_list.Add(new { number = reader.GetInt32("send_to_id"), name = reader.GetString("send_to_name"), text = reader.GetString("message") });
                        }
                        else if (GetPlayerNumber(Client) != reader.GetInt32("send_from_id"))
                        {
                            menu_item_list.Add(new { number = reader.GetInt32("send_from_id"), name = reader.GetString("send_from_name"), text = reader.GetString("message") });
                        }
                    }

                    count++;
                }
            }
            Mainpipeline.Close();

            Client.TriggerEvent("Update_SMS_List", NAPI.Util.ToJson(menu_item_list));

            
        }
    }

    [RemoteEvent("req_info")]
    public static void req_info(Player Client)
    {
        Main.SendSuccessMessage(Client, "WWW.WEBSITE.GG");
        Main.SendSuccessMessage(Client, "discord.gg/discord");
    }

    [RemoteEvent("Update_SMS")]
    public static void Update_SMS(Player Client, int number)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {

            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `sms` WHERE `send_from_id` = '" + number + "' AND `send_to_id` = '" + GetPlayerNumber(Client) + "' OR `send_from_id` = '" + GetPlayerNumber(Client) + "' AND `send_to_id` = '" + number + "'  LIMIT 60;", Mainpipeline);


            List<dynamic> menu_item_list = new List<dynamic>();
            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                int count = 0;
                while (reader.Read())
                {

                    if (reader.GetInt32("send_from_id") == GetPlayerNumber(Client)) // you
                    {
                        menu_item_list.Add(new { text = reader.GetString("message"), by = "Vi" });
                    }
                    else if (reader.GetInt32("send_to_id") == GetPlayerNumber(Client)) // him
                    {
                        menu_item_list.Add(new { text = reader.GetString("message"), by = reader.GetString("send_from_name") });
                    }

                    count++;
                }
            }


            Client.TriggerEvent("Update_SMS_Web", NAPI.Util.ToJson(menu_item_list));
            Mainpipeline.Close();

        }
    }

    [RemoteEvent("Send_SMS_SERVER")]
    public static void Send_SMS(Player Client, string number, string texto)
    {
        string sms_text = texto;

        if (sms_text.Length < 5 || sms_text.Length > 128)
        {
            Client.SendNotification("Greska:~n~Unos ne moze biti manji od 5 ili veci od 128 karaktera.");
            return;
        }

        if (!Main.IsNumeric(number))
        {
            Client.SendNotification("Odabrali ste nepostojeci broj.");
            return;
        }

        int numero = Convert.ToInt32(number);


        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (target.GetData<dynamic>("status") == true)
            {
                if (GetPlayerNumber(target) == numero)
                {
                    if (!NAPI.Player.IsPlayerConnected(target))
                    {
                        Main.SendErrorMessage(Client, "Pozvani korisnik trenutno nije dostupan.");
                        return;
                    }

                    if (target.GetData<dynamic>("status") == false)
                    {
                        Main.SendErrorMessage(Client, "Mreza je slaba.");
                        return;
                    }

                    if (Client == target)
                    {
                        Main.SendErrorMessage(Client, "Mreza je slaba.");
                        return;
                    }

                    string query = "INSERT INTO `sms` (send_from_id, send_from_name, send_to_id, send_to_name, message) VALUES (" + GetPlayerNumber(Client) + ", '" + UsefullyRP.GetPlayerNameToTarget(Client, target) + "', " + GetPlayerNumber(target) + ", '" + UsefullyRP.GetPlayerNameToTarget(target, Client) + "', '" + texto + "');";
                    Main.CreateMySqlCommand(query);


                    Main.PlaySoundClientSide(target, "sms", 0.2f);
                    //"BN_ShowWithPicture", title, sender, message, notifPic, icon, flashing, textColor, bgColor, flashColor
                    target.TriggerEvent("BN_ShowWithPicture", "Primili ste novu poruku", "" + UsefullyRP.GetPlayerNameToTarget(Client, target) + " N# " + String.Format("{0:###-###}", GetPlayerNumber(Client)) + "", texto, "CHAR_LIFEINVADER");
                    //Main.sendme
                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "*", "Primili ste novu poruku sa broja: " + String.Format("{0:###-###}", GetPlayerNumber(target)) + ".");
                    Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_YELLOW + "Poslali ste poruku na broj: # " + String.Format("{0:###-###}", GetPlayerNumber(Client)) + "", "" + Main.EMBED_YELLOW + " sa tekstom: " + texto + "");
                    Update_SMS(Client, GetPlayerNumber(target));
                    Update_SMS(target, GetPlayerNumber(Client));
                    return;
                }
            }
        }

        Client.SendNotification("Mreza je slaba.");
    }



    [RemoteEvent("Add_Contact")]
    public static void Add_Contact(Player Client, int number, string name)
    {
        int playerid = Main.getIdFromClient(Client);

        if (name.Length < 3 || name.Length > 24)
        {
            Client.SendNotification("Greska:~n~Unos ne moze biti manji od 3 ili veci od 24.");
            return;
        }

        if (name == "")
        {
            Client.SendNotification("Greska:~n~Pogresan unos.");
            return;
        }

        if (number == 999999999 || number == 0)
        {

            Client.SendNotification("Greska:~n~Pogresan unos.");
            return;
        }

        for (int i = 0; i < 60; i++)
        {
            if (cellphoneSystem.contacts_data[playerid].contact_number[i] == number)
            {
                Client.SendNotification("Greska:~n~Pogresan broj.");
                return;
            }
        }

        for (int i = 0; i < 60; i++)
        {
            if (cellphoneSystem.contacts_data[playerid].contact_number[i] == 0)
            {
                cellphoneSystem.contacts_data[playerid].contact_name[i] = name;
                cellphoneSystem.contacts_data[playerid].contact_number[i] = number;

                Main.SendCustomChatMessasge(Client, "* Dodali ste ~b~" + name + " ~c~(telefon: #" + number + ")~w~ na listu kontakata.");

                string query = "INSERT INTO `contacts` (owner, name, number) VALUES (" + AccountManage.GetPlayerSQLID(Client) + ", '" + name + "', " + number + ");";
                Main.CreateMySqlCommand(query);
                Update_Contacts(Client);
                Client.TriggerEvent("startApp", "contacts");
                return;
            }
        }
        Client.SendNotification("Greska:~n~Pogresan broj.");
    }
    [RemoteEvent("onClientRequestContactList")]
    public static void onClientRequestContactList(Player Client)
    {
        Main.SendCustomChatToAll("onClientRequestContactList");
        Update_Contacts(Client);

    }

    [RemoteEvent("onClientRequestCallPlayer")]
    public static void onClientRequestCallPlayer(Player Client, int number)
    {
        Main.SendCustomChatToAll("onClientRequestCallPlayer: " + number + "");
        Call_Number(Client, number);

    }

    [RemoteEvent("onClientRequestRemovePlayerContact")]
    public static void onClientRequestRemovePlayerContact(Player Client, int number)
    {
        int playerid = Main.getIdFromClient(Client);
        for (int i = 0; i < 60; i++)
        {
            if (contacts_data[playerid].contact_number[i] == number)
            {

                Main.SendCustomChatMessasge(Client, "* Obrisali ste ~b~" + cellphoneSystem.contacts_data[playerid].contact_name[i] + " ~c~(Номер #" + cellphoneSystem.contacts_data[playerid].contact_number[i] + ")~w~ sa liste kontakata.");

                Main.CreateMySqlCommand("DELETE FROM `contacts` WHERE `number` = '" + cellphoneSystem.contacts_data[playerid].contact_number[i] + "';");

                cellphoneSystem.contacts_data[playerid].contact_name[i] = null;
                cellphoneSystem.contacts_data[playerid].contact_number[i] = 0;

                Update_Contacts(Client);
                return;
            }
        }
    }

    // New Phone
    [RemoteEvent("cancelCallingNumber")]
    public static void requestPlayerPhoneCalls(Player Client)
    {
        CMD_desligar(Client);
    }

    [RemoteEvent("acceptCall")]
    public static void acceptCall(Player Client, int number)
    {
        CMD_atender(Client);
    }


    [RemoteEvent("callNumber")]
    public static void callNumber(Player Client, int number)
    {
    }



    [RemoteEvent("dialingNumber")]
    public static void dialingNumber(Player Client, int number)
    {
        Call_Number(Client, number);
    }
}