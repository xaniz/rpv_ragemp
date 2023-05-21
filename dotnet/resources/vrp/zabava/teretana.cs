using System;
using GTANetworkAPI;
using System.Collections.Generic;


class teretana : Script
{
    private static List<bool> states = new List<bool>() //todo Licences Names
    {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
    };
    public static Vector3[] seatmusculebench = new Vector3[]
    {
        new Vector3(-1200.55, -1562.15, 5.00),
        new Vector3(1635.75, 2526.75, 45.06),
        new Vector3(1638.15, 2529.75, 45.06),
        new Vector3(1640.75, 2532.75, 45.06),
        new Vector3(1640.75, 2532.75, 45.06),
        new Vector3(1643.05, 2535.35, 45.06),
    };
    public static Vector3[] CHINUP = new Vector3[]
    {
        new Vector3(1643.39, 2527.75, 45.56),
        new Vector3(1649.16, 2529.57, 45.56),
    };


    public static void CallBackShape(Player player)
    {
        try 
        {

            if (Main.IsInRangeOfPoint(player.Position, new Vector3(-1204.67, -1564.44, 4.60), 2))
            {
                if (player.HasData("CHINUP") && player.GetData<bool>("CHINUP") == true) return;
                player.SetData("CHINUP", true);
                NAPI.Entity.SetEntityPosition(player, new Vector3(-1204.77, -1564.31, 4.60));
                NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, 29.15));
                player.PlayAnimation("amb@prop_human_muscle_chin_ups@male@base", "base", 1);
                Trigger.ClientEvent(player, "freeze", true);
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(player))
                    {
                    player.StopAnimation();
                    Trigger.ClientEvent(player, "freeze", false);
                    player.SetData("CHINUP", false);
                    if (player.GetData<dynamic>("zadatak2") == true)
                    {
                        player.SetData("zadatak2", false);
                        Main.GivePlayerEXP(player, 300);
                        Main.GivePlayerMoney(player, 3000);
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste dnevni zadatak");
                    }
                    }
                }, 10000);
            }
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(-1200.06, -1571.11, 4.60), 2))
            {
                if (player.HasData("CHINUP") && player.GetData<bool>("CHINUP") == true) return;
                player.SetData("CHINUP", true);
                NAPI.Entity.SetEntityPosition(player, new Vector3(-1200.06, -1571.11, 4.60));
                NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, -148.95));
                player.PlayAnimation("amb@prop_human_muscle_chin_ups@male@base", "base", 1);
                Trigger.ClientEvent(player, "freeze", true);
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(player))
                    {
                    player.StopAnimation();
                    Trigger.ClientEvent(player, "freeze", false);
                    player.SetData("CHINUP", false);
                    if (player.GetData<dynamic>("zadatak2") == true)
                    {
                        player.SetData("zadatak2", false);
                        Main.GivePlayerEXP(player, 300);
                        Main.GivePlayerMoney(player, 3000);
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste dnevni zadatak");
                    }
                    }
                }, 10000);
            }
        
        
        }
        catch (Exception e)
        {

            Console.WriteLine(e);

        }
    }
    public static void CallBackShapeBench(Player player)
    {
        try
        {

            if (Main.IsInRangeOfPoint(player.Position, new Vector3(-1200.55, -1562.15, 5.00), 2))
            {
                if (player.HasData("CHINUP") && player.GetData<bool>("CHINUP") == true) return;
                player.SetData("CHINUP", true);
                NAPI.Entity.SetEntityPosition(player, new Vector3(-1200.70, -1562.13, 4.05));
                NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, 121.52));
                Trigger.ClientEvent(player, "freeze", true);
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_barbell_20kg"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                player.PlayAnimation("amb@prop_human_seat_muscle_bench_press@idle_a", "idle_a", 1);
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(player))
                    {
                    player.StopAnimation();
                    BasicSync.DetachObject(player);
                    Trigger.ClientEvent(player, "freeze", false);
                    player.SetData("CHINUP", false);
                    if (player.GetData<dynamic>("zadatak2") == true)
                    {
                        player.SetData("zadatak2", false);
                        Main.GivePlayerEXP(player, 300);
                        Main.GivePlayerMoney(player, 3000);
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste dnevni zadatak");
                    }
                    }
                }, 10000);
            }
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(-1207.07, -1560.90, 5.00), 2))
            {
                if (player.HasData("CHINUP") && player.GetData<bool>("CHINUP") == true) return;
                player.SetData("CHINUP", true);
                NAPI.Entity.SetEntityPosition(player, new Vector3(-1207.07, -1560.90, 4.05));
                NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, -140.76));
                Trigger.ClientEvent(player, "freeze", true);
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_barbell_20kg"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                player.PlayAnimation("amb@prop_human_seat_muscle_bench_press@idle_a", "idle_a", 1);
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(player))
                    {
                    player.StopAnimation();
                    BasicSync.DetachObject(player);
                    Trigger.ClientEvent(player, "freeze", false);
                    player.SetData("CHINUP", false);
                    if (player.GetData<dynamic>("zadatak2") == true)
                    {
                        player.SetData("zadatak2", false);
                        Main.GivePlayerEXP(player, 300);
                        Main.GivePlayerMoney(player, 3000);
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste dnevni zadatak");
                    }
                    }
                }, 10000);
            }
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(-1197.99, -1568.25, 5.00), 2))
            {
                if (player.HasData("CHINUP") && player.GetData<bool>("CHINUP") == true) return;
                player.SetData("CHINUP", true);
                NAPI.Entity.SetEntityPosition(player, new Vector3(-1197.99, -1568.25, 4.05));
                NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, -51.10));
                Trigger.ClientEvent(player, "freeze", true);
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_barbell_20kg"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                player.PlayAnimation("amb@prop_human_seat_muscle_bench_press@idle_a", "idle_a", 1);
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(player))
                    {
                    player.StopAnimation();
                    BasicSync.DetachObject(player);
                    Trigger.ClientEvent(player, "freeze", false);
                    player.SetData("CHINUP", false);
                    if (player.GetData<dynamic>("zadatak2") == true)
                    {
                        player.SetData("zadatak2", false);
                        Main.GivePlayerEXP(player, 300);
                        Main.GivePlayerMoney(player, 3000);
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste dnevni zadatak");
                    }
                    }
                }, 10000);
            }
            if (Main.IsInRangeOfPoint(player.Position, new Vector3(-1201.28, -1574.95, 5.00), 2))
            {
                if (player.HasData("CHINUP") && player.GetData<bool>("CHINUP") == true) return;
                player.SetData("CHINUP", true);
                NAPI.Entity.SetEntityPosition(player, new Vector3(-1201.28, -1575.06, 4.05));
                NAPI.Entity.SetEntityRotation(player, new Vector3(0, 0, -149.19));
                Trigger.ClientEvent(player, "freeze", true);
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_barbell_20kg"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                player.PlayAnimation("amb@prop_human_seat_muscle_bench_press@idle_a", "idle_a", 1);
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(player))
                    {
                    player.StopAnimation();
                    BasicSync.DetachObject(player);
                    Trigger.ClientEvent(player, "freeze", false);
                    if (player.GetData<dynamic>("zadatak2") == true)
                    {
                        player.SetData("zadatak2", false);
                        Main.GivePlayerEXP(player, 300);
                        Main.GivePlayerMoney(player, 3000);
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste dnevni zadatak");
                    }
                    player.SetData("CHINUP", false);
                    }
                }, 10000);
            }
        }
        catch (Exception e)
        {

            Console.WriteLine(e);

        }
    }
}

