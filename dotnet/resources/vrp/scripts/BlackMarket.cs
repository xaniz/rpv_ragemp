using GTANetworkAPI;
using System;
using System.Collections.Generic;

class blackmarket : Script
{

    [RemoteEvent("blackmarketss")]
    public static void blackmarketss(Player Client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        if (Inventory.GetPlayerItemFromInventory(Client, 64) < 8)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno RPV coina");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 48, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        

                        Inventory.RemoveItemByType(Client, 64, 8);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Knjigu");
                        Inventory.GiveItemToInventory(Client, 48, 1);
                        break;
                    }
                case 1:
                    {
                        if (Inventory.GetPlayerItemFromInventory(Client, 64) < 2)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno RPV coina");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 51, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        

                        Inventory.RemoveItemByType(Client, 64, 2);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Chip");
                        Inventory.GiveItemToInventory(Client, 51, 1);
                        break;
                    }
                case 2:
                    {
                        if (Inventory.GetPlayerItemFromInventory(Client, 64) < 3)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno RPV coina");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 20, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        

                        Inventory.RemoveItemByType(Client, 64, 3);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Busilicu");
                        Inventory.GiveItemToInventory(Client, 20, 1);
                        break;
                    }
                case 3:
                    {
                        if (Inventory.GetPlayerItemFromInventory(Client, 64) < 2)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno RPV coina");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 59, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        

                        Inventory.RemoveItemByType(Client, 64, 2);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Maticnu Plocu");
                        Inventory.GiveItemToInventory(Client, 59, 1);
                        break;
                    }
                case 4:
                    {
                        if (Main.GetPlayerMoney(Client) < 50)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 67, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }
                        
                        Main.GivePlayerMoney(Client, -50);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Morfin");
                        Inventory.GiveItemToInventory(Client, 67, 1);
                        break;
                    }
                case 5:
                    {
                        if (Main.GetPlayerMoney(Client) < 150)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 58, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }
                        
                        Main.GivePlayerMoney(Client, -150);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste USB");
                        Inventory.GiveItemToInventory(Client, 58, 1);
                        break;
                    }
                case 6:
                    {
                        if (Inventory.GetPlayerItemFromInventory(Client, 64) < 1)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno RPV coina");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 28, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        

                        Inventory.RemoveItemByType(Client, 64, 1);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste Kalauz");
                        Inventory.GiveItemToInventory(Client, 28, 1);
                        break;
                    }
                case 7:
                    {
                        if (Inventory.GetPlayerItemFromInventory(Client, 64) < 4)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno RPV coina");
                            return;
                        }

                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 19, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            return;
                        }

                        

                        Inventory.RemoveItemByType(Client, 64, 4);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kupili ste C4");
                        Inventory.GiveItemToInventory(Client, 19, 1);
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