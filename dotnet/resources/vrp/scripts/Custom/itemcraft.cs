using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Linq;

class itemcraft : Script
{
    public static List<dynamic> gnstors = new List<dynamic>();
    public itemcraft()
    {

        gnstors.Add(new { MarkerType = 1, position = new Vector3(21.673754, -1106.8872, 29.79703)});
        gnstors.Add(new { MarkerType = 1, position = new Vector3(810.36646, -2156.876, 29.619015)});
        gnstors.Add(new { MarkerType = 1, position = new Vector3(251.90987, -49.716873, 69.941055) });
        gnstors.Add(new { MarkerType = 1, position = new Vector3(842.7783, -1033.4158, 28.194862) });
        gnstors.Add(new { MarkerType = 1, position = new Vector3(-662.41565, -935.65607, 21.829226) });
        gnstors.Add(new { MarkerType = 1, position = new Vector3(-1306.0776, -393.90637, 36.69577) });
        gnstors.Add(new { MarkerType = 1, position = new Vector3(2568.1682, 294.91653, 108.73487) });
        gnstors.Add(new { MarkerType = 1, position = new Vector3(1693.5725, 3759.4382, 34.705315) });
        gnstors.Add(new { MarkerType = 1, position = new Vector3(-330.30396, 6082.9517, 31.454767) });
        gnstors.Add(new { MarkerType = 1, position = new Vector3(-1117.7506, 2697.9763, 18.55415) });
        gnstors.Add(new { MarkerType = 1, position = new Vector3(-3171.7493, 1087.2, 20.83875) });
        foreach (var atm in gnstors)
        {
            NAPI.TextLabel.CreateTextLabel("GunShop ~w~[ ~g~Y~w~ ]", atm.position, 16, 0.600f, 0, new Color(221, 255, 0, 150));
            //NAPI.Marker.CreateMarker(29, new Vector3(atm.position.X, atm.position.Y, atm.position.Z - -0.5), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

            Entity temp_blip;
            temp_blip = NAPI.Blip.CreateBlip(atm.position);
            NAPI.Blip.SetBlipName(temp_blip, "GunShop");
            NAPI.Blip.SetBlipSprite(temp_blip, 110);
            NAPI.Blip.SetBlipColor(temp_blip, 1);
            NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);

        }
    }


    [RemoteEvent("Craftgun")]
    public static void Craftgun(Player player, int index)
    {
        try {
            switch (index)
            {
            case 0:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 8, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    
                    return;
                    
                }
                if (Inventory.GetPlayerItemFromInventory(player, 48) <= 0)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate Knjigu Recepata");
                    return;
                }
                if (Inventory.GetPlayerItemFromInventory(player, 49) >= 1 && Inventory.GetPlayerItemFromInventory(player, 55) >= 1 && Inventory.GetPlayerItemFromInventory(player, 54) >= 1) {
                    Inventory.GiveItemToInventoryFromName(player, "Heavypistol", 1);
                    Inventory.RemoveItemByType(player, 49, 1);
                    Inventory.RemoveItemByType(player, 55, 1);
                    Inventory.RemoveItemByType(player, 54, 1);
                    Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Napravili ste Heavypistol");
                } 
                else {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno materijala");
                }
                
                
                return;
            case 1:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 8, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    
                    return;
                    
                }
                if (Inventory.GetPlayerItemFromInventory(player, 48) <= 0)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate Knjigu Recepata");
                    return;

                } 
                if (Inventory.GetPlayerItemFromInventory(player, 49) >= 2 && Inventory.GetPlayerItemFromInventory(player, 55) >= 1 && Inventory.GetPlayerItemFromInventory(player, 53) >= 1 && Inventory.GetPlayerItemFromInventory(player, 54) >= 2) {
                    Inventory.GiveItemToInventoryFromName(player, "Minismg", 1);
                    Inventory.RemoveItemByType(player, 49, 2);
                    Inventory.RemoveItemByType(player, 55, 1);
                    Inventory.RemoveItemByType(player, 53, 1);
                    Inventory.RemoveItemByType(player, 54, 2);
                    Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Napravili ste Minismg");
                }
                else {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno materijala");

                }
                
                
                return;
            case 2:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 8, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    
                    return;
                    
                }
                if (Inventory.GetPlayerItemFromInventory(player, 48) <= 0)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate Knjigu Recepata");
                    return;

                } 
                if (Inventory.GetPlayerItemFromInventory(player, 49) >= 2 && Inventory.GetPlayerItemFromInventory(player, 55) >= 1 && Inventory.GetPlayerItemFromInventory(player, 53) >= 1 && Inventory.GetPlayerItemFromInventory(player, 50) >= 1) {
                    Inventory.GiveItemToInventoryFromName(player, "Compactrifle", 1);
                    Inventory.RemoveItemByType(player, 49, 2);
                    Inventory.RemoveItemByType(player, 55, 1);
                    Inventory.RemoveItemByType(player, 53, 1);
                    Inventory.RemoveItemByType(player, 50, 1);
                    Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Napravili ste Compactrifle");
                }
                else {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno materijala");

                }
                
                
                return;
            case 3:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 18, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    
                    return;
                    
                }
                if (Inventory.GetPlayerItemFromInventory(player, 48) <= 0)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate Knjigu Recepata");
                    return;

                } 
                if (Inventory.GetPlayerItemFromInventory(player, 49) >= 3 && Inventory.GetPlayerItemFromInventory(player, 56) >= 2 && Inventory.GetPlayerItemFromInventory(player, 53) >= 2 && Inventory.GetPlayerItemFromInventory(player, 50) >= 2) {
                    Inventory.GiveItemToInventoryFromName(player, "Assaultrifle", 1);
                    Inventory.RemoveItemByType(player, 49, 3);
                    Inventory.RemoveItemByType(player, 56, 2);
                    Inventory.RemoveItemByType(player, 53, 2);
                    Inventory.RemoveItemByType(player, 50, 2);
                    Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Napravili ste Assaultrifle");
                }
                else {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno materijala");

                }
                
                
                return;
            case 4:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 18, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    
                    return;
                    
                }
                if (Inventory.GetPlayerItemFromInventory(player, 48) <= 0)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate Knjigu Recepata");
                    return;

                } 
                if (Inventory.GetPlayerItemFromInventory(player, 49) >= 2 && Inventory.GetPlayerItemFromInventory(player, 53) >= 1 && Inventory.GetPlayerItemFromInventory(player, 50) >= 2) {
                    Inventory.GiveItemToInventoryFromName(player, "Pumpshotgun", 1);
                    Inventory.RemoveItemByType(player, 49, 2);
                    Inventory.RemoveItemByType(player, 53, 1);
                    Inventory.RemoveItemByType(player, 50, 2);
                    Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Napravili ste Pumpshotgun");
                }
                else {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno materijala");

                }
                
                
                return;
            case 5:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 18, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    
                    return;
                    
                }
                if (Inventory.GetPlayerItemFromInventory(player, 48) <= 0)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate Knjigu Recepata");
                    return;
                }
                if (Inventory.GetPlayerItemFromInventory(player, 52) >= 2) {
                    Inventory.GiveItemToInventory(player, 18, 1);
                    Inventory.RemoveItemByType(player, 52, 2);
                    Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Napravili ste Pancir");
                }
                else {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno materijala");

                }
                
                
                return;
            case 6:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 60, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    return;
                }
                if (Inventory.GetPlayerItemFromInventory(player, 48) <= 0)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate Knjigu Recepata");
                    return;
                } 
                if (Inventory.GetPlayerItemFromInventory(player, 51) >= 16 && Inventory.GetPlayerItemFromInventory(player, 59) >= 3 && Inventory.GetPlayerItemFromInventory(player, 58) >= 1) {
                    Inventory.GiveItemToInventory(player, 60, 1);
                    Inventory.RemoveItemByType(player, 51, 16);
                    Inventory.RemoveItemByType(player, 59, 3);
                    Inventory.RemoveItemByType(player, 58, 1);
                    Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Napravili ste Hack One");
                }
                else {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno materijala");

                }
                
                
                return;
            }
            
            
        }
        catch (Exception e) { Console.Write(e); }    
    }

    public static void gunshotstore(Player Client)
    {
        foreach (var guns in gnstors)
        {
            if (Main.IsInRangeOfPoint(Client.Position, guns.position, 3.0f))
            {
                Client.TriggerEvent("Display_gunsstore");
            }
        }
    }

    [RemoteEvent("bweaponshop")]
    public static void bweaponshop(Player player, int index)
    {
        try {
            switch (index)
            {
            case 0:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 18, 1, Inventory.Max_Inventory_Weight(player)))
                {      
                    return;
                }
                if (Main.GetPlayerMoney(player) < 500)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                    return;
                }
                if (player.GetData<dynamic>("character_gun_lic") == 0)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dozvolu za oruzije");
                    return;
                }
                Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Pistol");
                Main.GivePlayerMoney(player, -500);
                Main.GiveCompanyMoney(9, 50);
                Inventory.GiveItemToInventoryFromName(player, "Pistol", 1);
                
                return;
            case 1:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 18, 1, Inventory.Max_Inventory_Weight(player)))
                {      
                    return;
                }
                if (Main.GetPlayerMoney(player) < 700)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                    return;
                }
                if (player.GetData<dynamic>("character_gun_lic") == 0)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dozvolu za oruzije");
                    return;
                }
                Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Combatpistol");
                Main.GivePlayerMoney(player, -700);
                Main.GiveCompanyMoney(9, 70);
                Inventory.GiveItemToInventoryFromName(player, "Combatpistol", 1);
                return;
            case 2:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 18, 1, Inventory.Max_Inventory_Weight(player)))
                {      
                    return;
                }
                if (Main.GetPlayerMoney(player) < 400)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                    return;
                }
                if (player.GetData<dynamic>("character_gun_lic") == 0)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dozvolu za oruzije");
                    return;
                }
                Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Marksmanpistol");
                Main.GivePlayerMoney(player, -400);
                Main.GiveCompanyMoney(9, 40);
                Inventory.GiveItemToInventoryFromName(player, "Marksmanpistol", 1);
                return;
            case 3:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 6, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    
                    return;
                    
                }
                if (Main.GetPlayerMoney(player) < 200)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                    return;
                }
                Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste 28 metaka za Pistolj");
                Main.GivePlayerMoney(player, -200);
                Main.GiveCompanyMoney(9, 20);
                Inventory.GiveItemToInventory(player, 6, 28);
                return;
            case 4:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 7, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    
                    return;
                    
                }
                if (Main.GetPlayerMoney(player) < 300)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                    return;
                }
                Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste 120 metaka za SMG");
                Main.GivePlayerMoney(player, -300);
                Main.GiveCompanyMoney(9, 30);
                Inventory.GiveItemToInventory(player, 7, 120);
                return;
            case 5:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 4, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    
                    return;
                    
                }
                if (Main.GetPlayerMoney(player) < 400)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                    return;
                }
                Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste 120 metaka za Automatsku Pusku");
                Main.GivePlayerMoney(player, -400);
                Main.GiveCompanyMoney(9, 40);
                Inventory.GiveItemToInventory(player, 4, 120);
                return;
            case 6:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 5, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    
                    return;
                    
                }
                if (Main.GetPlayerMoney(player) < 500)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                    return;
                }
                Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste 25 metaka za Pumparicu");
                Main.GivePlayerMoney(player, -500);
                Main.GiveCompanyMoney(9, 50);
                Inventory.GiveItemToInventory(player, 5, 25);
                return;
            case 7:
                if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 3, 1, Inventory.Max_Inventory_Weight(player)))
                {
                    
                    return;
                    
                }
                if (Main.GetPlayerMoney(player) < 600)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                    return;
                }
                Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste 21 metak za Snajper");
                Main.GivePlayerMoney(player, -600);
                Main.GiveCompanyMoney(9, 60);
                Inventory.GiveItemToInventory(player, 3, 21);
                return;
            }
            
            
        }
        catch (Exception e) { Console.Write(e); }    
    }
}