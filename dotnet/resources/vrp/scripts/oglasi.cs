using GTANetworkAPI;
using System;
using System.Collections.Generic;

class oglasi : Script
{
    [RemoteEvent("wnewsSubmitPost")]
    public static void wnewsSubmitPost(Player Client, string content, int phonenumber)
    {
        if (Main.GetPlayerMoney(Client) < 1000)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
            return;

        }
        if (Client.GetData<dynamic>("oglas") == true)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Vec ste postavili oglas, sacekajte 1 minut");
            return;
        }
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(Client))
            {
                Client.SetData("oglas", false);
            }
            
        }, 60000);
        Main.GivePlayerMoney(Client, -1000);
        NAPI.Chat.SendChatMessageToAll("~g~[OGLAS] ~b~ "+content);
        NAPI.Chat.SendChatMessageToAll("~b~"+AccountManage.GetCharacterName(Client)+" ~g~Telefon~b~: " + phonenumber);
        Main.GiveCompanyMoney(0, 100);
        Client.SetData("oglas", true);
    }
}