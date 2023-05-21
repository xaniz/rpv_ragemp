using System;
using GTANetworkAPI;
using System.Collections.Generic;

class rulet : Script
{
    public rulet()
    {
    NAPI.TextLabel.CreateTextLabel("Tocak~n~~w~[~y~ Y ~w~]", new Vector3(1111.04, 229.07, -49.63), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
    NAPI.Marker.CreateMarker(1, new Vector3(1111.04, 229.07, -50.80), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

    NAPI.TextLabel.CreateTextLabel("BlackJack~n~~w~[~y~ Y ~w~]", new Vector3(1143.20, 264.40, -50.64), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
    NAPI.Marker.CreateMarker(1, new Vector3(1143.20, 264.40, -53.80), new Vector3(), new Vector3(), 2.0f, new Color(221, 255, 0, 155));

    NAPI.TextLabel.CreateTextLabel("BlackJack~n~~w~[~y~ Y ~w~]", new Vector3(1146.13, 261.42, -50.64), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
    NAPI.Marker.CreateMarker(1, new Vector3(1146.13, 261.42, -53.80), new Vector3(), new Vector3(), 2.0f, new Color(221, 255, 0, 155));
    NAPI.Marker.CreateMarker(1, new Vector3(1108.24, 208.60, -50.44), new Vector3(), new Vector3(), 2.0f, new Color(221, 255, 0, 155));


    

    }
    [RemoteEvent("ruletpob")]
    public static void ruletpob(Player Client, int index)
    {
        try
        {
            if (Main.GetPlayerMoney(Client) < 100)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Niste dobili nista, igrali ste iz zabave");
                return;
            }
            Main.GivePlayerMoney(Client, index);
            Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Dobili ste "+index+" dolara");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    [RemoteEvent("zavrtirulet")]
    public static void zavrtirulet(Player Client, int index)
    {
        try
        {
            if (Main.GetPlayerMoney(Client) < index)
            {
                return;
            }
            Main.GivePlayerMoney(Client, -index);
            Client.TriggerEvent("createNewHeadNotificationAdvanced", "~r~- ~g~"+index+ "");
            if (Client.GetData<dynamic>("zadatak4") == true)
            {
                Client.SetData("zadatak4", false);
                Main.GivePlayerEXP(Client, 300);
                Main.GivePlayerMoney(Client, 3000);
                Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste dnevni zadatak");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}