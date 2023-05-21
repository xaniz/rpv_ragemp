using System;
using System.Collections.Generic;
using GTANetworkAPI;


class rpvcoin : Script
{
    public rpvcoin()
    {
        NAPI.Marker.CreateMarker(30, new Vector3(-693.46, -582.22, 31.55), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));
        NAPI.Marker.CreateMarker(30, new Vector3(-140.38, -621.02, 168.82), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155), false, 1);
        NAPI.Marker.CreateMarker(29, new Vector3(-128.13, -641.90, 168.32), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155), false, 1);
        NAPI.TextLabel.CreateTextLabel(" LomBank ~n~zameni novac~n~ ~g~", new Vector3(-128.13, -641.90, 168.32 + 0.3), 12, 0.1200f, 0, new Color(221, 255, 0, 255), false, 1);
    }

    public static void keypressE(Player client)
    {
        if(Main.IsInRangeOfPoint(client.Position, new Vector3(-693.46, -582.22, 31.55), 3.0f))
        {
            client.Position = new Vector3(-140.38, -621.02, 168.82);
            client.Dimension = 1;
            return;
        }
        if(Main.IsInRangeOfPoint(client.Position, new Vector3(-140.38, -621.02, 168.82), 3.0f) && client.Dimension == 1)
        {
            client.Position = new Vector3(-693.46, -582.22, 31.55);
            client.Dimension = 0;
            return;
        }
    }

    [RemoteEvent("ExchangeRPVs")]
    public static void ExchangeRPVs(Player Client, int index)
    {
        if (index != null && index == 0) return;
        if (Inventory.GetPlayerItemFromInventory(Client, 64) >= index)
        {
            int totalnakit = index;
            Inventory.RemoveItemByType(Client, 64, totalnakit);
            Main.GivePlayerMoney(Client, 1500 * totalnakit);
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Zamenili ste " +totalnakit+" RPV Coina i dobili $" + totalnakit * 1500 + " ");
        }
        else
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate toliko RPV Coina");
        }
    }
}