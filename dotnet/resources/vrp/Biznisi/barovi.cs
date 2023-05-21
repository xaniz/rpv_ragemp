using GTANetworkAPI;
using System;
using System.Collections.Generic;

class barstoress : Script
{

    [RemoteEvent("barstores")]
    public static void barstores(Player Client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        if (Main.GetPlayerMoney(Client) < 30)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 1, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        

                        Main.GivePlayerMoney(Client, -30);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Vodu");
                        Inventory.GiveItemToInventory(Client, 1, 1);
                        break;
                    }
                case 1:
                    {
                        if (Main.GetPlayerMoney(Client) < 50)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;

                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 68, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }


                        Main.GivePlayerMoney(Client, -50);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Pivo");
                        Inventory.GiveItemToInventory(Client, 68, 1);
                        break;
                    }
                case 2:
                    {
                        if (Main.GetPlayerMoney(Client) < 80)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 69, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }
                        
                        
                        Main.GivePlayerMoney(Client, -80);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Konjak");
                        Inventory.GiveItemToInventory(Client, 69, 1);
                        if (Client.GetData<dynamic>("zadatak7") == true)
                        {
                            Client.SetData("zadatak7", false);
                            Main.GivePlayerEXP(Client, 300);
                            Main.GivePlayerMoney(Client, 3000);
                            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste dnevni zadatak");
                        }
                        break;
                    }
                case 3:
                    {
                        if (Main.GetPlayerMoney(Client) < 100)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 70, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }
                        
                        Main.GivePlayerMoney(Client, -100);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Viski");
                        Inventory.GiveItemToInventory(Client, 70, 1);
                        break;
                    }
                case 4:
                    {
                        if (Main.GetPlayerMoney(Client) < 100)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 71, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }
                        
                        Main.GivePlayerMoney(Client, -100);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Votku");
                        Inventory.GiveItemToInventory(Client, 71, 1);
                        break;
                    }
                case 5:
                    {
                        if (Main.GetPlayerMoney(Client) < 300)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 72, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }
                        
                        Main.GivePlayerMoney(Client, -300);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Sampanjac");
                        Inventory.GiveItemToInventory(Client, 72, 1);
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