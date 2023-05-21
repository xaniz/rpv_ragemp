using System;
using System.Collections.Generic;
using GTANetworkAPI;


class shipwar : Script
{

    public static bool shipwarstarted = false;
    public static int maxitems = 0;


    [Command("startshipwar")]
    public static void startshipwar(Player player)
    {
        if (player.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(player, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(player) < 7)
        {
            Main.SendErrorMessage(player, "Niste ovlasceni!");
            return;
        }
        NAPI.Chat.SendChatMessageToAll("~r~---------------------------***------------------------------");
        NAPI.Chat.SendChatMessageToAll("Brod sa materijalima pristize u luku Los Santos za 10 minuta!");
        NAPI.Chat.SendChatMessageToAll("~r~---------------------------***------------------------------");
        TimerEx.SetTimer(() =>
        {

            startedbattle(player);

        }, 600000, 1);
    }


    public static void startedbattle(Player player)
    {
        
        string vehName = "tug";
        VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(vehName);
        if (vehHash != 0)
        {
            var vehicle = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(30.53, -2774.82, 0.50), new Vector3(0, 0, 0), 0, 0);
            vehicle.SetData<dynamic>("shipwar", true);
            vehicle.Dimension = 0;
            Main.SetVehicleFuel(vehicle, 0.0);
            vehicle.NumberPlate = "RPV-ADMIN";
            NAPI.Vehicle.SetVehicleEngineStatus(vehicle, false); 
            shipwarstarted = true;
            var label = NAPI.TextLabel.CreateTextLabel("~w~[ ~g~Y~w~ ]", new Vector3(30.933, -2771.02, 5.20), 16, 0.600f, 0, new Color(221, 255, 0, 150));
            TimerEx.SetTimer(() =>
            {
                label.Delete();
                vehicle.Delete();
                shipwarstarted = false;
                maxitems = 0;

            }, 600000, 1);
        }
    }
    [RemoteEvent("stealship")]
    public static void stealship(Player player)
    {  
        
        if (player.GetData<dynamic>("pljackas") == true)
        {
            return;
        } 
        player.SetData<dynamic>("pljackas", true);

        if (shipwarstarted == true)
        {
            
            Main.PlayAnimation(player, "amb@world_human_gardener_plant@male@idle_a", "idle_b", 49, 0);
            TimerEx.SetTimer(() =>
            {
                player.StopAnimation();
                ShipReward(player);
                player.SetData<dynamic>("pljackas", false);
            }, 10000, 1);
        }
    }

    public static void ShipReward(Player player)
    {
        if (maxitems > 20)
        {
            Main.DisplayErrorMessage(player, NotifyType.Alert, NotifyPosition.BottomCenter, "U brodu nema vise itema!");
            return;
        }
        
        var items = new Dictionary<int, int>
        {
            { 0, 49 },
            { 1, 50 },
            { 2, 53 },
            { 3, 54 },
            { 4, 55 },
            { 5, 56 },
            { 6, 1 }
        };

        var rnd = new Random();
        var item = rnd.Next(1, 3);
        var random_value = rnd.Next(0, 7);
        var inventoryId = items[random_value];
        Inventory.GiveItemToInventory(player, inventoryId, item);
        maxitems += item;
        Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "+ item");
    }
}