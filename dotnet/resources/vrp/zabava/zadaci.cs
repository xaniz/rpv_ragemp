using GTANetworkAPI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using MySql.Data.MySqlClient;

public class zadaci : Script
{

    [RemoteEvent("StartZadatak")]
    public void StartZadatak(Player Client)
    {
         
        if (Client.GetData<dynamic>("zadatakd") == 1) return;
        Random rnd = new Random();
        int rzadatak = rnd.Next(0, 8);
        Main.CreateMySqlCommand("UPDATE characters SET zadatak=1 WHERE id='" + AccountManage.GetPlayerSQLID(Client) + "'");
        Client.SetData("zadatakd", 1);
        switch (rzadatak)
        {
            case 0:
                {
                    Client.SendChatMessage("~g~ZADATAK~w~: Upecaj jednog sarana.");
                    Client.SetData("zadatak1", true);
                    break;
                }
            case 1:
                {
                    Client.SendChatMessage("~g~ZADATAK~w~: Idi do teretane i treniraj.");
                    Client.SetData("zadatak2", true);
                    break;
                }
            case 2:
                {
                    Client.SendChatMessage("~g~ZADATAK~w~: Operi auto u Perionici.");
                    Client.SetData("zadatak3", true);
                    break;
                }
            case 3:
                {
                    Client.SendChatMessage("~g~ZADATAK~w~: Odigraj 1 igru u kazinu.");
                    Client.SetData("zadatak4", true);
                    break;
                }
            case 4:
                {
                    Client.SendChatMessage("~g~ZADATAK~w~: Uplati Lotto tiket.");
                    Client.SetData("zadatak5", true);
                    break;
                }
            case 5:
                {
                    Client.SendChatMessage("~g~ZADATAK~w~: Uspesno zavrsi Route68 challenge.");
                    Client.SetData("zadatak6", true);
                    break;
                }
            case 6:
                {
                    Client.SendChatMessage("~g~ZADATAK~w~: Kupi 1 konjak u kaficu.");
                    Client.SetData("zadatak7", true);
                    break;
                }
            case 7:
                {
                    Client.SendChatMessage("~g~ZADATAK~w~: Uberi 1 pecurku.");
                    Client.SetData("zadatak8", true);
                    break;
                }
            case 8:
                {
                    Client.SendChatMessage("~g~ZADATAK~w~: Uberi 1 pecurku.");
                    Client.SetData("zadatak8", true);
                    break;
                }
            default:
                break;
        }
    }
}