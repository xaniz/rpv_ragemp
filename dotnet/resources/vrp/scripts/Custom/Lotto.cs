using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System.Timers;


class LottoSystem : Script
{

    public static int MAX_LOTTO_NUMBER = 150;

    public static int Jackpot = 50000;
    public static int TicketsSold = 0;
    public static int LastJackpot = 0;

    public LottoSystem()
    {

    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Player player)
    {
        for (int i = 0; i < 3; i++)
        {
            player.SetData($"character_lotto_{i}", 0);
        }
    }



    public static void Lotto(int number)
    {
        LastJackpot = number;
        int JackpotFallen = 0, TotalWinners = 0;

        Main.SendMessageToAll($"~b~Narodna lutrija: Izvucena je dobitna kombinacija, a to je broj: {number}!.");

        foreach (var player in API.Shared.GetAllPlayers())
        {
            if (player.GetData<dynamic>("status") == false) continue;
            int selected = 0;
            for (int i = 0; i < 5; i++)
            {
                if (player.GetData<dynamic>($"character_lotto_{i}") > 0)
                {
                    if (player.GetData<dynamic>($"character_lotto_{i}") == number)
                    {
                        player.SetData("Winner", 1);
                        TotalWinners++;
                    }
                    selected++;

                }
            }

            if (selected > 0 && !player.HasData("Winner"))
            {
                Main.SendInfoMessage(player, "~b~[LUTRIJA] Nazalost, Vas Lotto listic nije osvojio nagradu.");

            }

            if (selected == 0)
            {
                Main.SendInfoMessage(player, "~b~[LUTRIJA] Niste kupili Lotto listic.");
            }

            for (int i = 0; i < 5; i++)
            {
                player.SetData($"character_lotto_{i}", 0);
            }

        }
        if (TotalWinners == 1)
        {
            foreach (var player in API.Shared.GetAllPlayers())
            {
                if (player.GetData<dynamic>("status") == false) continue;

                if (player.HasData("Победитель"))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        player.SetData($"character_lotto_{i}", 0);
                    }


                    JackpotFallen = 1;
                    Main.SendMessageToAll($"~b~[LUTRIJA]: {AccountManage.GetCharacterName(player)} je imao dobitni LOTTO listic i osvojio je ${Jackpot}.");

                    Main.SendMessageToPlayer(player, $"~b~[LUTRIJA]: Cestitamo, svojili ste Jackpot u iznosu od: ${Jackpot}!");

                    Main.GivePlayerMoneyBank(player, Jackpot);
                    player.ResetData("Победитель");
                }
            }
        }
        else if (TotalWinners > 1)
        {
            foreach (var player in API.Shared.GetAllPlayers())
            {
                if (player.GetData<dynamic>("status") == false) continue;

                if (player.HasData("Победитель"))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        player.SetData($"character_lotto_{i}", 0);
                    }

                    JackpotFallen = 1;
                    Main.SendMessageToAll($"~b~[LUTRIJA]: {AccountManage.GetCharacterName(player)} je imao dobitni LOTTO listic i osvojio je ${Jackpot}.");
                    Main.SendMessageToPlayer(player, $"~b~[LUTRIJA]: Cestitamo, svojili ste Jackpot u iznosu od: ${Jackpot}!");

                    Main.GivePlayerMoneyBank(player, Jackpot / TotalWinners);
                    player.ResetData("Победитель");
                }
            }
        }

        TicketsSold = 0;
        if (JackpotFallen == 0)
        {

            Random rnd = new Random();
            int random_value = rnd.Next(5000, 15000);
            Jackpot += random_value;
            Main.SendMessageToAll($"~b~[LUTRIJA]: Nagradni fond je povecan i sada iznosi: ${Jackpot}.");

        }
        else
        {
            Jackpot = 30000;
            Main.SendMessageToAll($"~b~[LUTRIJA]: Nagradni fond je povecan i sada iznosi: ${Jackpot}.");
        }

    }
    public static void PrepareLotto()
    {
        int stage = 5;
        TimerEx.SetTimer(() => {

            if (stage > 0)
            {
                Main.SendMessageToAll($"~b~[LUTRIJA]: Izvlacenje pocinje za {stage}. Lotto listic mozete kupiti u svim 24/7 prodavnicama!");
                stage--;
            }
            else if (stage == 0)
            {
                EndLotto();
                stage = -1;
            }

        }, 1200 * 1000, 7);
    }


    public static void EndLotto()
    {
        int second = 3;

        TimerEx.SetTimer(() => {

            if (second > 0)
            {
                Main.SendMessageToAll($"~b~[LUTRIJA]: Izvlacenje pocinje za {second}.");
                second--;
            }
            else if (second == 0)
            {
                Main.SendMessageToAll($"~b~[LUTRIJA]: Izvlacenje je u toku.");

                Random rnd = new Random();
                int random_lotto = rnd.Next(0, MAX_LOTTO_NUMBER);
                Lotto(random_lotto);
                second = -1;
                PrepareLotto();
            }

        }, 1000, 6);
    }

    public static void OnInputResponse(Player player, String response, String inputtext)
    {
        if (response == "BUY_LOTTO_TICKET")
        {

            int index = player.GetData<dynamic>("lotto_index");
            if (Main.GetPlayerMoney(player) < 150)
            {
                InteractMenu_New.SendNotificationError(player, "Nemate dovoljno novca.");
                return;
            }
            int lotto_id = -1;


            for (int i = 0; i < 5; i++)
            {
                if (player.GetData<dynamic>($"character_lotto_{i}") == 0)
                {
                    lotto_id = i;
                    break;
                }
            }

            if (lotto_id == -1)
            {
                Main.SendErrorMessage(player, "Vec ste uplatili lotto.");
                return;
            }


            if (!Main.IsNumeric(inputtext))
            {
                Main.SendErrorMessage(player, "Pogresan broj.");
                return;
            }

            int lotto_number = Convert.ToInt32(inputtext);

            if (lotto_number < 1 && lotto_number > 150)
            {
                Main.SendErrorMessage(player, "Broj moze biti od 1 do 150.");
                return;
            }


            for (int i = 0; i < 5; i++)
            {
                if (player.GetData<dynamic>($"character_lotto_{i}") == lotto_number)
                {
                    Main.SendErrorMessage(player, "Ne mozete to!");
                    return;
                }
            }


            

            Main.GivePlayerMoney(player, 150);

            player.SetData($"character_lotto_{lotto_id}", lotto_number);

            NAPI.Chat.SendChatMessageToPlayer(player, "~g~[24-7]:~w~ Uplatili ste Lotto broj: " + lotto_number + ".");
            if (player.GetData<dynamic>("zadatak5") == true)
            {
                player.SetData("zadatak5", false);
                Main.GivePlayerEXP(player, 300);
                Main.GivePlayerMoney(player, 3000);
                Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste dnevni zadatak");
            }


        }
    }

    [Command("lotto")]
    public static void CMD_lotto(Player player)
    {
        int lotto_count = 0;
        if (LastJackpot == 0) Main.SendMessageToPlayer(player, $"{Main.EMBED_GREEN}=============== Lotto listic (Jackpot: ${Jackpot.ToString("N0")}) ===============");
        else Main.SendMessageToPlayer(player, $"{Main.EMBED_GREEN}=============== Lotto listic (Jackpot: ${Jackpot.ToString("N0")} - Prethodni jackpot: {LastJackpot}) ===============");
        for (int i = 0; i < 5; i++)
        {
            if (player.GetData<dynamic>($"character_lotto_{i}") > 0)
            {
                Main.SendMessageToPlayer(player, $"* Vas Lotto broj je: {player.GetData<dynamic>($"character_lotto_{i}")}");
                lotto_count++;
            }
        }
        if (lotto_count == 0)
        {
            Main.SendMessageToPlayer(player, $"* Niste kupili Lotto listic.");

        }
    }
}