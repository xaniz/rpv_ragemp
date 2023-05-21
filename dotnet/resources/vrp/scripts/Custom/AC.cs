using GTANetworkAPI;

class AntiCheat : Script
{

    public AntiCheat()
    {
      //  AntiTeleportHack();
    }

    //Anti God Mod Seems Passed 
    //Anti No Reload Seems Good 

    [RemoteEvent("server:CheatDetection")]
    public void AntiCheatLog(Player player, string log)
    {
        if (AccountManage.GetPlayerConnected(player))
        {
            foreach (var item in NAPI.Pools.GetAllPlayers())
            {
                if (AccountManage.GetPlayerAdmin(item) >= 6)
                {
                    Main.SendCustomChatMessasge(item, "~r~[-ANTI CHEAT-] ~c~" + player.Name + "" + "~w~ detektovan da koristi ~y~" + log + ".");
                    GameLog.ELog(player, GameLog.MyEnum.Anti_Cheat, player.Name + "(" + player.SocialClubName + ")" + " Koristi " + log + " Cheat.");
                }
            }
        }
    }

   /* [RemoteEvent("SetSafePosition")]
    public static void SetSafePosition(Player player, Vector3 pos)
    {
        player.TriggerEvent("setexception", true, 2);
        player.Position = pos;
    }

    public static void NAPI.Player.SetPlayerHealth(Player player, int heal)
    {
        player.TriggerEvent("setexception", true, 1);
        player.Health = heal;

    }

    public static void SetSafeVehPos(Player player, Vector3 pos)
    {
        player.TriggerEvent("setexception", true, 3);
        player.Vehicle.Position = pos;

    }

    public void AntiTeleportHack()
    {
        TimerEx.SetTimer(() =>
        {
            foreach (Player Player in NAPI.Pools.GetAllPlayers())
            {
                if (Client.HasData("status") && Client.GetData<dynamic>("status") && !Client.IsInVehicle ) || Client.HasData("admin_level")  && AccountManage.GetPlayerAdmin(Client) <= 3)
                {
                    if (Client.HasData("TeleportCheckPos") && !Main.IsInRangeOfPoint((Vector3)Client.GetData<dynamic>("TeleportCheckPos"), Client.Position, 40f) && Client.HasData("ValidToTeleport")  && !Client.GetData<dynamic>("ValidToTeleport"))
                    {
                        Client.SetData<dynamic>("TeleportHack",);
                        Vector3 Pos = (Vector3)Client.GetData<dynamic>("TeleportCheckPos");
                        CheatWarnToAdmin(Client, "Teleport Hack", Pos.ToString(), Client.Position.ToString());
                    }
                    Client.SetData<dynamic>("ValidToTeleport", false);
                    Client.SetData<dynamic>("TeleportCheckPos", Client.Position);
                }

            }
        }, 1000, 0);
    }

     public static void SetPlayerPositionEx(Player Client, Vector3 pos, uint diminasion = 0)
     {
         Client.SetData<dynamic>("ValidToTeleport", true);
         Client.Position = pos;
         Client.Dimension = diminasion;
     }

     public static void CheatWarnToAdmin(Player Client, string cheatName, string extended = null, string extended_2 = null)
     {
         
         foreach (Player admin in NAPI.Pools.GetAllPlayers())
         {
             if (AccountManage.GetPlayerAdmin(admin) >= 3) { admin.SendChatMessage("~r~[ANTI - CHEAT] ~w~Client: ~y~" + AccountManage.GetCharacterName(Client) + $"[{ Client.Value}] ({ AccountManage.GetPlayerSQLID(Client)}) ~r~{cheatName},~w~ " + extended + " | " + extended_2); }
         }
     }*/



}
