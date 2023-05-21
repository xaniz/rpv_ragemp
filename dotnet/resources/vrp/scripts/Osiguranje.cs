using GTANetworkAPI;
using System;
using MySql.Data.MySqlClient;

class Osiguranje : Script
{
    [ServerEvent(Event.ResourceStart)]
    public static void OnResourceStart()
    {
        NAPI.Marker.CreateMarker(25, new Vector3(-83.47, 80.86, 70.65), new Vector3(), new Vector3(), 2.5f, new Color(221, 255, 0, 110));
        API.Shared.CreateTextLabel("~g~-~y~ Osiguranje~g~ -~w~~n~~n~ ~y~E~w~", new Vector3(-83.47, 80.86, 71.55), 8.0f, 0.8f, 4, new Color(221, 255, 0, 255));
    }

    [RemoteEvent("InsuranceBuys")]
    public static void InsuranceBuys(Player player, int index)
    {
        try
        {
            if (player.GetData<dynamic>("status") == true)
            {
            if (player.VehicleSeat != 0)
            {
                Notify.Send(player, NotifyType.Error, NotifyPosition.BottomCenter, $"Morate biti na mestu vozaca", 3000);
                return;
            }
            if (player.Vehicle.GetData<dynamic>("Mashin_Owner") == AccountManage.GetPlayerSQLID(player))
            {
                switch (index)
                {
                    case 0:
                        {
                            if (Main.GetPlayerMoney(player) < 3000)
                            {
                                Main.DisplayErrorMessage(player, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                                return;
                            }
                            Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste osiguranje za 100 sati!");
                            Main.GivePlayerMoney(player, -3000);
                            Main.CreateMySqlCommand("UPDATE `vehicles` SET `veh_osiguranje` = 100 WHERE `id` = '" + player.Vehicle.GetData<int>("veh_sql") + "'");
                            break;
                        }
                    case 1:
                        {
                            if (Main.GetPlayerMoney(player) < 7000)
                            {
                                Main.DisplayErrorMessage(player, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                                return;
                            }
                            Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste osiguranje za 300 sati!");
                            Main.GivePlayerMoney(player, -7000);
                            Main.CreateMySqlCommand("UPDATE `vehicles` SET `veh_osiguranje` = 300 WHERE `id` = '" + player.Vehicle.GetData<int>("veh_sql") + "'");
                            break;
                        }
                    case 2:
                        {
                            if (Main.GetPlayerMoney(player) < 15000)
                            {
                                Main.DisplayErrorMessage(player, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                                return;
                            }
                            Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste osiguranje za 720 sati!");
                            Main.GivePlayerMoney(player, -15000);
                            Main.CreateMySqlCommand("UPDATE `vehicles` SET `veh_osiguranje` = 720 WHERE `id` = '" + player.Vehicle.GetData<int>("veh_sql") + "'");
                            break;
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