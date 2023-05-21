using GTANetworkAPI;
using System;
using System.Collections.Generic;
public class Fish : Script
{
    public static List<Vector3> fishspots = new List<Vector3>
    {

        new Vector3(881.1518, 3702.4138, 31.36826),
        new Vector3(-1849.9484, -1250.6912, 8.615777),
        new Vector3(2835.1443, -665.963, 1.0333756),
        new Vector3(-1260.9232, 2693.2432, 0.88456273),
        new Vector3(50.068104, 7250.5625, 1.4618434),

        
    };

    private Vector3[] fishSpots = 
    {
        new Vector3(881.1518, 3702.4138, 31.36826),
        new Vector3(-1849.9484, -1250.6912, 8.615777),
        new Vector3(2835.1443, -665.963, 1.0333756),
        new Vector3(-1260.9232, 2693.2432, 0.88456273),
        new Vector3(50.068104, 7250.5625, 1.4618434)
    };

    public Fish()
    {
        foreach (var pos in fishspots)
        {             
            Entity temp_blip;
            temp_blip = NAPI.Blip.CreateBlip(pos);
            NAPI.Blip.SetBlipName(temp_blip, "Pecanje");
            NAPI.Blip.SetBlipSprite(temp_blip, 68);
            NAPI.Blip.SetBlipColor(temp_blip, 3);
            NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);
        }
            Entity tblip2;
            tblip2 = NAPI.Blip.CreateBlip(new Vector3(1332.72, 4325.29, 38.5));
            NAPI.Blip.SetBlipName(tblip2, "Prodaja Ribe");
            NAPI.Blip.SetBlipSprite(tblip2, 68);
            NAPI.Blip.SetBlipColor(tblip2, 4);
            NAPI.Blip.SetBlipScale(tblip2, 0.7f);
            NAPI.Blip.SetBlipShortRange(tblip2, true);
            NAPI.TextLabel.CreateTextLabel("Prodaja Ribe~n~~w~[~y~ Y ~w~]", new Vector3(1332.72, 4325.29, 38.3), 12, 0.3500f, 4, new Color(11, 93, 156, 255));

    }

    private static bool IsPlayerFishing(Player player)
    {
        return player.GetData<bool>("fishing");
    }

    public static void keypressE(Player player)
    {
            
        Vector3 smas = fishspots[0];
        foreach (var v in fishspots)
        {

            if (Main.IsInRangeOfPoint(player.Position, v, 20f))
            
            {
                if (IsPlayerFishing(player))
                {
                    return;
                }
                player.SetData("fishing", true);
                BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_fishing_rod_01"), 60309, new Vector3(0.03, 0, 0.02), new Vector3(0, 0, 50));
                NAPI.Player.PlayPlayerAnimation(player, (int)(Main.AnimationFlags.Loop), "amb@world_human_stand_fishing@idle_a", "idle_c");
                Random ftim = new Random();
                int fishtimer = ftim.Next(10000, 20000);
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(player))
                    {
                    player.SetData("fishing", false);
                    fishbaited(player);
                    }
                }, delayTime: fishtimer);
            }
        }
    }
    public static void fishbaited(Player c)
    {
        c.SetData("fishbaited", true);
        Main.DisplayErrorMessage(c, NotifyType.Info, NotifyPosition.BottomCenter, "Riba je zagrizla! Pritisnite K");
        Random rnd = new Random();
        int randomsec = rnd.Next(1000, 2500);
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(c))
            {
            if (c.GetData<bool>("fishbaited") == true)
            {
                c.SetData("fishbaited", false);
                Main.DisplayErrorMessage(c, NotifyType.Info, NotifyPosition.BottomCenter, "Riba je pobegla...");
                c.StopAnimation();
                BasicSync.DetachObject(c);
            }
            }

        }, delayTime: randomsec);
    }

    public static void getfishre(Player c)
    {
        if (c.GetData<bool>("fishing") == false && c.GetData<bool>("fishbaited") == true)
        {
            c.SetData("fishbaited", false);
            fishgot(c);
            return;
        }

    }

    public static void fishgot(Player c)
    {
        Random fish = new Random();
        int newfish = fish.Next(0, 3);
        c.StopAnimation();
        BasicSync.DetachObject(c);
        switch (newfish)
        {
            case 0:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(c, 74, 1, Inventory.Max_Inventory_Weight(c)))
                {
                    Main.DisplayErrorMessage(c, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate mesta u inventary");
                    return;
                }
                Main.DisplayErrorMessage(c, NotifyType.Info, NotifyPosition.BottomCenter, "+ Babuska");
                Inventory.GiveItemToInventory(c, 74, 1);
                break;
            case 1:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(c, 75, 1, Inventory.Max_Inventory_Weight(c)))
                {
                    Main.DisplayErrorMessage(c, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate mesta u inventary");
                    return;
                }
                Main.DisplayErrorMessage(c, NotifyType.Info, NotifyPosition.BottomCenter, "+ Saran");
                Inventory.GiveItemToInventory(c, 75, 1);
                if (c.GetData<dynamic>("zadatak1") == true)
                {
                    c.SetData("zadatak1", false);
                    Main.GivePlayerEXP(c, 300);
                    Main.GivePlayerMoney(c, 3000);
                    Main.DisplayErrorMessage(c, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste dnevni zadatak");
                }
                break;
            case 2:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(c, 76, 1, Inventory.Max_Inventory_Weight(c)))
                {
                    Main.DisplayErrorMessage(c, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate mesta u inventary");
                    return;
                }
                Main.DisplayErrorMessage(c, NotifyType.Info, NotifyPosition.BottomCenter, "+ Som");
                Inventory.GiveItemToInventory(c, 76, 1);
                break;
        }
    }

    public static void sellfishre(Player c)
    {
        if (Inventory.GetPlayerItemFromInventory(c, 74) > 0)
        {
            int totfish = Inventory.GetPlayerItemFromInventory(c, 74);
            Inventory.RemoveItemByType(c, 74, totfish);
            Main.GivePlayerMoney(c, 100 * totfish);
            Main.DisplayErrorMessage(c, NotifyType.Success, NotifyPosition.BottomCenter, "Prodali ste Babuske");
        }
        if (Inventory.GetPlayerItemFromInventory(c, 75) > 0)
        {
            int totfish2 = Inventory.GetPlayerItemFromInventory(c, 75);
            Inventory.RemoveItemByType(c, 75, totfish2);
            Main.GivePlayerMoney(c, 125*totfish2);
            Main.DisplayErrorMessage(c, NotifyType.Success, NotifyPosition.BottomCenter, "Prodali ste Sarane");
        }
        if (Inventory.GetPlayerItemFromInventory(c, 76) > 0)
        {
            int totfish3 = Inventory.GetPlayerItemFromInventory(c, 76);
            Inventory.RemoveItemByType(c, 76, totfish3);
            Main.GivePlayerMoney(c, 150*totfish3);
            Main.DisplayErrorMessage(c, NotifyType.Info, NotifyPosition.BottomCenter, "Pordali ste Somove");
        }
    }

    private bool IsPlayerInRangeOfFishingSpot(Player player)
    {
        for (int i = 0; i < fishSpots.Length; i++)
        {
            if (Main.IsInRangeOfPoint(player.Position, fishspots[i], 20f))
            {
                return true;
            }
        }
        return false;
    }

    
}