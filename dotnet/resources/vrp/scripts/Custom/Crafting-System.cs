using GTANetworkAPI;
using System.Collections.Generic;

class Crafting_System:Script
{
    public static List<Crafting_Structer> Craft_Data = new List<Crafting_Structer>();
    public static List<Craft_Table> Table_Data = new List<Craft_Table>();


    public class Craft_Table
    {
        public Vector3 position;
        public TextLabel TextLabel;
        public List<string> CraftableItem;


    }

    public class NeededItem_Structer
    {
        public string name;
        public int itemid;
        public int ammount;
        public string iconName;

    }
    public class Crafting_Structer
    {
        public string craftname;
        public int finalitemammount;
        public int finalitemid;
        public int crafttime;
        public List<NeededItem_Structer> neededitemid;
    }


    public Crafting_System()
    {
       
        Craft_Data.Add(new Crafting_Structer
        {
            craftname = "SMG",
            finalitemid = 43,
            crafttime = 10000,
            finalitemammount = 1,
            neededitemid = new List<NeededItem_Structer>() {
            new NeededItem_Structer(){iconName="barrel.png",name="Barrel",itemid=29,ammount=1 },
            new NeededItem_Structer(){iconName="Crosspointdpmoutn.png",name="Crosspointdpmoutn",itemid=30,ammount=1 },
            new NeededItem_Structer(){iconName="handkeep.png",name="OMRG",itemid=31,ammount=1 },
            new NeededItem_Structer(){iconName="Mpxdc.png",name="Mpxdc",itemid=31,ammount=1 },
            new NeededItem_Structer(){iconName="Mpxdoublelatchimg.png",name="Mpxdoublelatchimg",itemid=31,ammount=1 },
            new NeededItem_Structer(){iconName="Uad.png",name="Stock",itemid=31,ammount=1 },
            },

        });

    }


    [RemoteEvent("CloseCrafting")]
    public void CloseCrafting(Player Client)
    {
        Client.SetData<dynamic>("IsCrafting", false);
    }

    [RemoteEvent("CraftCompleted")]
    public void CraftCompleted(Player Client, string rawid)
    {
        if (Client.GetData<dynamic>("status"))
        {
            int id = int.Parse(rawid);
            if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Craft_Data[id].finalitemid, Craft_Data[id].finalitemammount, Inventory.Max_Inventory_Weight(Client)))
            {
                return;
            }
            foreach (var item in Craft_Data[id].neededitemid)
            {
                if (Inventory.GetPlayerItemFromInventory(Client, item.itemid) < item.ammount)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno resursa. ");
                    return;
                }
            }
            if (!Client.HasData("IsCrafting") && !Client.GetData<dynamic>("IsCrafting"))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Doslo je do greske, kontaktirajte skriptera! ");
                return;
            }
            foreach (var item in Craft_Data[id].neededitemid)
            {
                Inventory.RemoveItemByType(Client, item.itemid, item.ammount);
            }
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, Craft_Data[id].craftname+" Nemate dovoljno resursa!");
            Inventory.GiveItemToInventory(Client, Craft_Data[id].finalitemid, Craft_Data[id].finalitemammount);
            Client.SetData<dynamic>("IsCrafting", false);
        }

    }

    [RemoteEvent("CheckCraft")]
    public void CheckCraft(Player Client, int id)
    {
        if (Client.GetData<dynamic>("status"))
        {

            if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, Craft_Data[id].finalitemid, Craft_Data[id].finalitemammount, Inventory.Max_Inventory_Weight(Client)))
            {
                return;
            }
            foreach (var item in Craft_Data[id].neededitemid)
            {
                if (Inventory.GetPlayerItemFromInventory(Client, item.itemid) < item.ammount)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno resursa! ");
                    return;
                }
            }
            if (Client.HasData("IsCrafting") && Client.GetData<dynamic>("IsCrafting"))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno resursa! ");
                return;
            }
            /*  foreach (var item in Craft_Data[id].neededitemid)
              {
                  Inventory.RemoveItemFromInventory(Client, item.itemid, item.ammount);
              }*/
            Client.SetData<dynamic>("IsCrafting", true);
            Client.TriggerEvent("StartCrafting", id);
            //Inventory.GiveItemToInventory(Client, Craft_Data[id].finalitemid,Craft_Data[id].finalitemammount);
        }
    }

}
