using GTANetworkAPI;
using System;
using System.Collections.Generic;

class GeneralStore : Script
{

    public static List<dynamic> genstore = new List<dynamic>();

    public GeneralStore()
    {

        genstore.Add(new { MarkerType = 1, position = new Vector3(26.420563, -1347.0519, 29.497025)});
        genstore.Add(new { MarkerType = 1, position = new Vector3(-48.55561, -1757.1757, 29.421017)});
        genstore.Add(new { MarkerType = 1, position = new Vector3(1136.3129, -982.0838, 46.415848) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(1162.8124, -323.28806, 69.20513) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(374.5595, 326.85794, 103.56638) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-1223.4705, -906.55646, 12.326346) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-1821.3231, 792.39044, 138.12675) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(1961.7357, 3741.7756, 32.343746) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(1698.8347, 4925.0225, 42.06367) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(1729.6604, 6414.641, 35.03723) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(1392.1151, 3603.983, 34.980927) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-1487.665, -379.17163, 40.16343) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-2968.4546, 390.9022, 15.043314) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-3040.2012, 586.15967, 7.9089293) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(-3242.5671, 1001.9007, 12.830707) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(2678.9248, 3281.3389, 55.24113) });
        genstore.Add(new { MarkerType = 1, position = new Vector3(2556.5107, 382.7558, 108.62295) });
        foreach (var atm in genstore)
        {
            NAPI.TextLabel.CreateTextLabel("24/7 ~w~[ ~g~Y~w~ ]", atm.position, 16, 0.600f, 0, new Color(221, 255, 0, 150));
            //NAPI.Marker.CreateMarker(29, new Vector3(atm.position.X, atm.position.Y, atm.position.Z - -0.5), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

            Entity temp_blip;
            temp_blip = NAPI.Blip.CreateBlip(atm.position);
            NAPI.Blip.SetBlipName(temp_blip, "Prodavnica 24/7");
            NAPI.Blip.SetBlipSprite(temp_blip, 628);
            NAPI.Blip.SetBlipColor(temp_blip, 25);
            NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);

        }
    }

    public static void GenSShow(Player Client)
    {
        foreach (var gsm in genstore)
        {
            if (Main.IsInRangeOfPoint(Client.Position, gsm.position, 3.0f))
            {
                Client.TriggerEvent("Display_sevenstore");
            }
        }
    }

    [RemoteEvent("fourseven")]
    public static void fourseven(Player Client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        if (Main.GetPlayerMoney(Client) < 25)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 1, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        

                        Main.GivePlayerMoney(Client, -25);
                        Main.GiveCompanyMoney(7, 2);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Vodu");
                        Inventory.GiveItemToInventory(Client, 1, 1);
                        break;
                    }
                case 1:
                    {
                        if (Main.GetPlayerMoney(Client) < 30)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;

                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 2, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }


                        Main.GivePlayerMoney(Client, -30);
                        Main.GiveCompanyMoney(7, 3);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Burger");
                        Inventory.GiveItemToInventory(Client, 2, 1);
                        break;
                    }
                case 2:
                    {
                        if (Main.GetPlayerMoney(Client) < 1000)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (cellphoneSystem.GetPlayerNumber(Client) != 0)
                        {
                            Main.SendErrorMessage(Client, "Vec imate mobilni telefon.");
                            break;
                        }
                        
                        Main.GivePlayerMoney(Client, -1000);
                        Main.GiveCompanyMoney(7, 100);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Telefon");
                        cellphoneSystem.NewNumber(Client);
                        break;
                    }
                case 3:
                    {
                        if (Main.GetPlayerMoney(Client) < 100)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 21, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }
                        
                        Main.GivePlayerMoney(Client, -100);
                        Main.GiveCompanyMoney(7, 10);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Kanister");
                        Inventory.GiveItemToInventory(Client, 21, 1);
                        break;
                    }
                case 4:
                    {
                        if (Main.GetPlayerMoney(Client) < 150)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 23, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }
                        
                        Main.GivePlayerMoney(Client, -150);
                        Main.GiveCompanyMoney(7, 15);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Radio");
                        Inventory.GiveItemToInventory(Client, 23, 1);
                        break;
                    }
                case 5:
                    {
                        if (Main.GetPlayerMoney(Client) < 50)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 25, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }
                        
                        Main.GivePlayerMoney(Client, -50);
                        Main.GiveCompanyMoney(7, 5);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Vezicu");
                        Inventory.GiveItemToInventory(Client, 25, 1);
                        break;
                    }
                case 6:
                    {
                    if (Main.GetPlayerMoney(Client) < 150)
                        {
                            InteractMenu_New.SendNotificationError(Client, "Nemate dovoljno novca.");
                            return;
                        }
                        int lotto_id = -1;


                        for (int i = 0; i < 1; i++)
                        {
                            if (Client.GetData<dynamic>($"character_lotto_{i}") == 0)
                            {
                                lotto_id = i;
                                break;
                            }
                        }

                        if(lotto_id == -1)
                        {
                            Main.SendErrorMessage(Client, "Ne mozete kupiti vise listica.");
                            return;
                        }
                        Client.TriggerEvent("Hide_Crafting_System");
                        Client.SetData("lotto_index", index);
                        //lottoo
                        InteractMenu.User_Input(Client, "BUY_LOTTO_TICKET", "Kupi lotto listic", "150", "izaberite broj izmedju 0 i 150.", "number");
                        break;
                    }
                case 7:
                    {
                        if (Main.GetPlayerMoney(Client) < 500)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 73, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }
                        
                        Main.GivePlayerMoney(Client, -500);
                        Main.GiveCompanyMoney(7, 50);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Pajser");
                        Inventory.GiveItemToInventory(Client, 77, 1);
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

}