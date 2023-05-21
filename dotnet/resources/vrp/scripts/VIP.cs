using GTANetworkAPI;
using System;
using System.Collections.Generic;

class VIP : Script
{
    public static List<dynamic> Credit_Store = new List<dynamic>();
    public static List<dynamic> Credits = new List<dynamic>();
    public VIP()
    {
        Credit_Store.Add(new { type = 0, name = "VIP", description = "1 mesec", credits = 300, img = "https://media.discordapp.net/attachments/689565472236240902/731780713736699904/12.png" });
        Credit_Store.Add(new { type = 1, name = "VIP", description = "3 meseca", credits = 800, img = "https://media.discordapp.net/attachments/689565472236240902/731780713736699904/12.png" });
        Credit_Store.Add(new { type = 2, name = "VIP", description = "6 meseci", credits = 1500, img = "https://media.discordapp.net/attachments/689565472236240902/731780713736699904/12.png" });
        Credit_Store.Add(new { type = 3, name = "Zauvek Walking Style", description = "Style: Brave", credits = 1000, img = "https://cdn.discordapp.com/attachments/689565472236240902/732112750917976154/134.png" });
        Credit_Store.Add(new { type = 4, name = "Zauvek Walking Style", description = "Style: Fat", credits = 1000, img = "https://cdn.discordapp.com/attachments/689565472236240902/732112750917976154/134.png" });
        Credit_Store.Add(new { type = 5, name = "Zauvek Walking Style", description = "Style: Hurry", credits = 1000, img = "https://cdn.discordapp.com/attachments/689565472236240902/732112750917976154/134.png" });
        Credit_Store.Add(new { type = 6, name = "Zauvek Walking Style", description = "Style: Intimidation", credits = 1000, img = "https://cdn.discordapp.com/attachments/689565472236240902/732112750917976154/134.png" });
        Credit_Store.Add(new { type = 7, name = "Zauvek Walking Style", description = "Style: Sad", credits = 1000, img = "https://cdn.discordapp.com/attachments/689565472236240902/732112750917976154/134.png" });
        Credit_Store.Add(new { type = 8, name = "Zauvek Walking Style", description = "Style: Gangster", credits = 1000, img = "https://cdn.discordapp.com/attachments/689565472236240902/732112750917976154/134.png" });
        Credit_Store.Add(new { type = 9, name = "Zauvek Walking Style", description = "Style: Tough", credits = 1000, img = "https://cdn.discordapp.com/attachments/689565472236240902/732112750917976154/134.png" });
       
        Credit_Store.Add(new { type = 10, name = "50K Money Up", description = "Mozete kupiti Money Up paket", credits = 50, img = "https://cdn.discordapp.com/attachments/632516635432976397/780915623844118628/money-5.png" });
        Credit_Store.Add(new { type = 11, name = "100K Money Up", description = "Mozete kupiti Money Up paket", credits = 100, img = "https://cdn.discordapp.com/attachments/632516635432976397/780915623844118628/money-5.png" });
        Credit_Store.Add(new { type = 12, name = "150K Money Up", description = "Mozete kupiti Money Up paket", credits = 150, img = "https://cdn.discordapp.com/attachments/632516635432976397/780915623844118628/money-5.png" });
        Credit_Store.Add(new { type = 13, name = "300K Money Up", description = "Mozete kupiti Money Up paket", credits = 300, img = "https://cdn.discordapp.com/attachments/632516635432976397/780915623844118628/money-5.png" });
        Credit_Store.Add(new { type = 14, name = "500K Money Up", description = "Mozete kupiti Money Up paket", credits = 500, img = "https://cdn.discordapp.com/attachments/632516635432976397/780915623844118628/money-5.png" });
        Credit_Store.Add(new { type = 15, name = "750K Money Up", description = "Mozete kupiti Money Up paket", credits = 750, img = "https://cdn.discordapp.com/attachments/632516635432976397/780915623844118628/money-5.png" });
        Credit_Store.Add(new { type = 16, name = "1 Milion Money Up", description = "Mozete kupiti Money Up paket", credits = 1000, img = "https://cdn.discordapp.com/attachments/632516635432976397/780915623844118628/money-5.png" });

        Credits.Add(new { type = 0, name = "50 Credit", description = "50 RR", credits = 50, img = "https://cdn.discordapp.com/attachments/632516635432976397/780609976736677888/Coins-512.png" });
        Credits.Add(new { type = 1, name = "100 Credit", description = "100 RR", credits = 100, img = "https://cdn.discordapp.com/attachments/632516635432976397/780609976736677888/Coins-512.png" });
        Credits.Add(new { type = 2, name = "150 Credit", description = "150 RR", credits = 150, img = "https://cdn.discordapp.com/attachments/632516635432976397/780609976736677888/Coins-512.png" });
        Credits.Add(new { type = 3, name = "300 Credit", description = "300 RR", credits = 300, img = "https://cdn.discordapp.com/attachments/632516635432976397/780609976736677888/Coins-512.png" });
        Credits.Add(new { type = 4, name = "500 Credit", description = "500 RR", credits = 500, img = "https://cdn.discordapp.com/attachments/632516635432976397/780609976736677888/Coins-512.png" });
        Credits.Add(new { type = 5, name = "750 Credit", description = "750 RR", credits = 750, img = "https://cdn.discordapp.com/attachments/632516635432976397/780609976736677888/Coins-512.png" });
        Credits.Add(new { type = 6, name = "1000 Credit", description = "1000 RR", credits = 1000, img = "https://cdn.discordapp.com/attachments/632516635432976397/780609976736677888/Coins-512.png" });

    }


    [RemoteEvent("BuyItemFromCreditStore")]
    public static void BuyItemFromCreditStore(Player Client, int type)
    {
        switch (type)
        {
            case 0: // Vip
                {
                    if (GetPlayerCredits(Client) < 300)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 300);
                    SetPlayerVIP(Client, 1, 30);

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste VIP paket na mesec dana, hvala Vam sto donirate <3!");
                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "[OOC Store]", "Sve pomoci oko VIPa mozete pogledati na F4!");
                    vipdate(Client);
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 1: // Slot Adicional de Veículo
                {
                    if (GetPlayerCredits(Client) < 800)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 800);
                    SetPlayerVIP(Client, 1, 90);

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste VIP paket na 3 meseca , hvala Vam sto donirate <33!");
                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "[OOC Store]", "Sve pomoci oko VIPa mozete pogledati na F4");
                    vipdate(Client);
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 2: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 1500)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 1500);
                    SetPlayerVIP(Client, 1, 180);

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste VIP paket na 6 meseci , hvala Vam sto donirate <333!");
                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "[OOC Store]", "Sve pomoci oko VIPa mozete pogledati na F4");
                    vipdate(Client);
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 3: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 1000)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                    WalkingStyle.SetWalkStyle(Client, WalkingStyle.Brave, false);

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style!");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 4: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 1000)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                    WalkingStyle.SetWalkStyle(Client, WalkingStyle.Fat, false);

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style!");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 5: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 1000)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                    WalkingStyle.SetWalkStyle(Client, WalkingStyle.Hurry, false);

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style!");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 6: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 1000)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                    WalkingStyle.SetWalkStyle(Client, WalkingStyle.Intimidated, false);


                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style!");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 7: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 1000)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                    WalkingStyle.SetWalkStyle(Client, WalkingStyle.Sad, false);

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style!");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 8: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 1000)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                    WalkingStyle.SetWalkStyle(Client, WalkingStyle.Gangster, false);

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 9: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 1000)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                    WalkingStyle.SetWalkStyle(Client, WalkingStyle.Tough, false);

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 10: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 50)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 50);
                    

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 11: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 100)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 100);
                    


                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 12: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 150)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 150);
                    


                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 13: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 300)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 300);
                    

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 14: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 500)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 500);
                    


                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 15: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 750)
                    {
                        Client.SendNotification("Greska!~n~This Item Cost 750 But You Have Only " + GetPlayerCredits(Client) + " Credit.");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 750);
                    

                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
            case 16: // Slot Adicional de Casa
                {
                    if (GetPlayerCredits(Client) < 1000)
                    {
                        Client.SendNotification("Greska!~n~Nemate dovoljno Credita!");
                        return;
                    }
                    SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);
                    


                    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                    Client.TriggerEvent("Destroy_Character_Menu");
                    break;
                }
        }
    }



    public static void ModalConfirm(Player Client, string response)
    {

        if (response == "BUY_ITEM_FROM_CREDIT_STORE")
        {
            int type = Client.GetData<dynamic>("credit_store_item_type");
            switch (type)
            {
                case 0: // Vip
                    {
                        if (GetPlayerCredits(Client) < 600)
                        {
                            Client.SendNotification("Greska!~n~Nemate dovoljno Credita.");
                            return;
                        }
                        SetPlayerCredits(Client, GetPlayerCredits(Client) - 600);
                        SetPlayerVIP(Client, 1, 30);

                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste VIP 1 za 600 kredita. Hvala Vam sto donirate!");
                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "[OOC Store]", "Koristite F4 za pomoc oko donacije!");
                        vipdate(Client);
                        break;
                    }
                case 1: // Slot Adicional de Veículo
                    {
                        if (GetPlayerCredits(Client) < 1800)
                        {
                            Client.SendNotification("Greska!~n~Nemate dovoljno Credita.");
                            return;
                        }
                        SetPlayerCredits(Client, GetPlayerCredits(Client) - 1800);
                        SetPlayerVIP(Client, 1, 90);

                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste VIP 3 za 600 kredita. Hvala Vam sto donirate!");
                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "[OOC Store]", "Koristite F4 za pomoc oko donacije!");
                        vipdate(Client);
                        break;

                    }
                case 2: // Slot Adicional de Casa
                    {
                        if (GetPlayerCredits(Client) < 3500)
                        {
                            Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                            return;
                        }
                        SetPlayerCredits(Client, GetPlayerCredits(Client) - 3500);
                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste VIP 6 za 600 kredita. Hvala Vam sto donirate!");
                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "[OOC Store]", "Koristite F4 za pomoc oko donacije!");
                        break;
                    }
                case 3: // Slot Adicional de Casa
                    {
                        if (GetPlayerCredits(Client) < 1000)
                        {
                            Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                            return;
                        }
                        SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                        WalkingStyle.SetWalkStyle(Client, WalkingStyle.Brave, false);

                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                        break;
                    }
                case 4: // Slot Adicional de Casa
                    {
                        if (GetPlayerCredits(Client) < 1000)
                        {
                            Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                            return;
                        }
                        SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                        WalkingStyle.SetWalkStyle(Client, WalkingStyle.Fat, false);

                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                        break;
                    }
                case 5: // Slot Adicional de Casa
                    {
                        if (GetPlayerCredits(Client) < 1000)
                        {
                            Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                            return;
                        }
                        SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                        WalkingStyle.SetWalkStyle(Client, WalkingStyle.Hurry, false);

                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                        break;
                    }
                case 6: // Slot Adicional de Casa
                    {
                        if (GetPlayerCredits(Client) < 1000)
                        {
                            Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                            return;
                        }
                        SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                        WalkingStyle.SetWalkStyle(Client, WalkingStyle.Intimidated, false);


                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                        break;
                    }
                case 7: // Slot Adicional de Casa
                    {
                        if (GetPlayerCredits(Client) <= 1000)
                        {
                            Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                            return;
                        }
                        SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                        WalkingStyle.SetWalkStyle(Client, WalkingStyle.Sad, false);

                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                        break;
                    }
                case 8: // Slot Adicional de Casa
                    {
                        if (GetPlayerCredits(Client) <= 1000)
                        {
                            Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                            return;
                        }
                        SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                        WalkingStyle.SetWalkStyle(Client, WalkingStyle.Gangster, false);

                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                        break;
                    }
                case 9: // Slot Adicional de Casa
                    {
                        if (GetPlayerCredits(Client) <= 1000)
                        {
                            Client.SendNotification("Greska!~n~Nemate dovoljno kredita!");
                            return;
                        }
                        SetPlayerCredits(Client, GetPlayerCredits(Client) - 1000);

                        WalkingStyle.SetWalkStyle(Client, WalkingStyle.Tough, false);

                        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_CYAN + "[OOC Store]", "Kupili ste Walking Style.");
                        break;
                    }

            }
        }
    }


    public static void ModalCancel(Player Client, string response)
    {


    }
    public static int GetPlayerDonator(Player Client)
    {
        return NAPI.Data.GetEntityData(Client, "character_donator");
    }

    public static int GetPlayerVIP(Player Client)
    {
        return NAPI.Data.GetEntityData(Client, "character_vip");
    }

    public static int GetPlayerCredits(Player Client)
    {
        return NAPI.Data.GetEntityData(Client, "character_credits");
    }

    public static void SetPlayerDonator(Player Client, int value)
    {
        NAPI.Data.SetEntityData(Client, "character_donator", value);
        return;
    }


    public static void SetPlayerVIP(Player Client, int value, int days)
    {
        NAPI.Data.SetEntityData(Client, "character_vip", value);

        DateTime characterVipExpire = Convert.ToDateTime(Client.GetData<dynamic>("character_vip_expire"));

        if (characterVipExpire > DateTime.Now)
        {
            Client.SetData<dynamic>("character_vip_expire", characterVipExpire.AddDays(days));
        }
        else
        {
            Client.SetData<dynamic>("character_vip_date", DateTime.Now);
            Client.SetData<dynamic>("character_vip_expire", DateTime.Now.AddDays(days));
        }
        Main.SavePlayerInformation(Client);
        return;
    }

    public static void GivePlayerCredits(Player Client,int value)
    {
        NAPI.Data.SetEntityData(Client, "character_credits", GetPlayerCredits(Client) + value);
    }

    public static void SetPlayerCredits(Player Client, int value)
    {
        NAPI.Data.SetEntityData(Client, "character_credits", value);
        Main.SavePlayerInformation(Client);
      // Client.TriggerEvent("update_credits", GetPlayerCredits(Client));
        return;
    }

    [Command("vip", GreedyArg = true)]
    public static void vipdate(Player Client)
    {
        if (GetPlayerVIP(Client) == 0)
        {
            Main.SendInfoMessage(Client, "Niste VIP!");
            return;
        }

        DateTime vip_expire = Client.GetData<dynamic>("character_vip_expire");
        if (vip_expire < DateTime.Now)
        {
            Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[VIP]", "Vas VIP je istekao!");
            NAPI.Data.SetEntityData(Client, "character_vip", 0);
            NAPI.Data.SetEntityData(Client, "character_vip_expire", 0);

        }
        else
        {
            Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "[VIP]", "Vas VIP istice " + vip_expire.ToString("dd/MM/yyyy HH:mm:ss") + "" + Main.EMBED_WHITE + " !");
        }

    }

    /*[Command("dnn", "/dnn [Tablighat]", GreedyArg = true)]
    public static void AnuncioDoador(Player Client, string anuncio)
    {
        if (GetPlayerVIP(Client) == 0)
        {
            Main.SendErrorMessage(Client, "Tanha Ozv Donator/VIP mitavanad az in dastor estefade konad.");
            return;
        }
        Main.SendMessageWithTagToAll("" + Main.EMBED_GROVE + "[Tablighat Donator]", Main.EMBED_GROVE + anuncio);
    }

    [Command("vnn", "/vnn [Tablighat]", GreedyArg = true)]
    public static void AnuncioVIP(Player Client, string anuncio)
    {
        if (GetPlayerVIP(Client) == 0)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }
        Main.SendMessageWithTagToAll("" + Main.EMBED_VIP + "[Tablighat VIP]", Main.EMBED_VIP + anuncio);
    }*/

/*
    [Command("pm", "/pm [id / part of name] [poruka]", GreedyArg = true)]
    public static void MessagePrivada(Player Client, string idOrName, string poruka)
    {
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_YELLOW + "PM poslat " + UsefullyRP.GetPlayerNameToTarget(Client, target) + " " +Client.Value+"", Main.EMBED_WHITE + poruka);
            Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + " " + UsefullyRP.GetPlayerNameToTarget(target, Client) + " PM: " + target.Value + "", Main.EMBED_WHITE + poruka);
        }
        else Main.SendErrorMessage(Client, "Pogresan ID.");
    }

    [Command("vpm", "/vpm [id / parte do nome] [poruka]", GreedyArg = true)]
    public static void MessageVIP(Player Client, string idOrName, string poruka)
    {
        if (GetPlayerVIP(Client) == 0)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);
        if (target != null)
        {
            Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_VIP + "PM poslat ~w~" + UsefullyRP.GetPlayerNameToTarget(Client, target) + ": ", Main.EMBED_VIP + poruka);
            Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "" + UsefullyRP.GetPlayerNameToTarget(target, Client) + " PM: ", Main.EMBED_VIP + poruka);
        }
        else Main.SendErrorMessage(Client, "Pogresan ID.");
    }
*/
    [Command("setrpv", "/setrpv [id/DeoImena] [Kolicina]")]
    public static void CMD_SetCredits(Player Client, string idOrName, int amount)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
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

            SetPlayerCredits(target, amount);
            Main.SendCustomChatMessasge(Client, "Postavili ste ~b~" + AccountManage.GetCharacterName(target) + "~w~ rpv na: ~g~" + amount.ToString("N0") + "~w~.");
            Main.SendCustomChatMessasge(target, "Admin" + AccountManage.GetCharacterName(Client) + "Vam je postavio setrpv na: ~g~" + amount.ToString("N0") + "~w~ .");
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je koristio /setrpv  na: " + AccountManage.GetCharacterName(target) + " kolicina: " + amount);
        }
        else Main.SendErrorMessage(Client, "Pogresan ID.");
    }

    [Command("atp")]
    public static void atpcmd(Player client)
    {
        if (GetPlayerVIP(client) < 1)
        {
            Main.SendInfoMessage(client, "Niste VIP!");
            return;
        }
        if (!client.IsInVehicle) return;
        client.TriggerEvent("autopilotvip");
        
    }

    [Command("dajrpv", "/dajrpv [id/DeoImena] [Kolicina]")]
    public static void CMD_giveCredit(Player Client, string idOrName, int amount)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
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

            SetPlayerCredits(target, GetPlayerCredits(target) + amount);
            Main.SendCustomChatMessasge(Client, "Dali ste ~b~" + AccountManage.GetCharacterName(target) + "~g~ " + amount.ToString("N0") + "~w~ Credita.");
            Main.SendCustomChatMessasge(target, "Admin" + AccountManage.GetCharacterName(Client) + " Vam je dao ~g~" + amount.ToString("N0") + "~w~Credita.");
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " je koristio /dajrpv  na: " + AccountManage.GetCharacterName(target) + " kolicina: " + amount);
        }
        else Main.SendErrorMessage(Client, "Pogresan ID.");
    }
}
