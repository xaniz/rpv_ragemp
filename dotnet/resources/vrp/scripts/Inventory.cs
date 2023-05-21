using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

class Inventory : Script
{
    public static int MAX_INVENTORY_ITENS = 32;

    public static int ITEM_TYPE_NONE = 0;
    public static int ITEM_TYPE_CONSUMIBLE = 1;
    public static int ITEM_TYPE_Ammunation = 2;
    public static int ITEM_TYPE_WORK = 3;
    public static int ITEM_TYPE_MISCELLANEOUS = 4;
    public static int ITEM_TYPE_WEAPON = 5;
    public static int ITEM_TYPE_FISH = 6;

    public class itemEnum : IEquatable<itemEnum>
    {
        public int id { get; set; }
        public string picture { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float weight { get; set; }
        public int guest { get; set; }
        public uint hash { get; set; }
        public float position { get; set; }
        public bool Useable { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            itemEnum objAsPart = obj as itemEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(itemEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }
    public static List<itemEnum> itens_available = new List<itemEnum>();
    public static List<dynamic> inventory_objects = new List<dynamic>();
    /*  Inventory.itens_available.Add(new { name = "Nenhum", description = "" });
        Inventory.itens_available.Add(new { name = "Agua", height = 0.6, description = "Usado para matar a sede do seu personagem em ~y~40%~w~.", icon = "drink_water", object_hash = 582043502, position_z = 0.9f, guest = false });
        Inventory.itens_available.Add(new { name = "Hamburguer", height = 0.4, description = "Usado para matar a sua fome em ~y~40%~w~.", icon = "food_beefburger", object_hash = 386283738, position_z = 0.96f, guest = false });
        Inventory.itens_available.Add(new { name = "Munição 7.62 (Sniper Rifles)", height = 0.4, description = "Usada para adicionar munições a armas de tipo ~y~Sniper Rifles~w~.", icon = "ammo_308", object_hash = 1843823183, position_z = 1.0f, guest = false });
        Inventory.itens_available.Add(new { name = "Munição 7.62 (Assault Rifles)", height = 0.2, description = "Usada para adicionar munições a armas de tipo ~y~Assault Rifles~w~.", icon = "ammo_556", object_hash = 669213687, position_z = 0.95f, guest = false });
        Inventory.itens_available.Add(new { name = "Munição de 12 (Shotguns)", height = 0.3, description = "Usada para adicionar munições a armas de tipo ~y~Shotguns~w~.", icon = "ammo_12gauge", object_hash = 1560006187, position_z = 0.95f, guest = false });
        Inventory.itens_available.Add(new { name = "Munição 9mm (Pistolas)", height = 0.1, description = "Usada para adicionar munições a armas de tipo ~y~Pistolas~w~.", icon = "ammo_9mm", object_hash = 190687980, position_z = 0.95f, guest = false });
        Inventory.itens_available.Add(new { name = "Munição de .45 (Micro-SMG)", height = 0.1, description = "Usada para adicionar munições a armas de tipo ~y~Micro SMG~w~.", icon = "ammo_45acp", object_hash = 1093460780, position_z = 0.95f, guest = false });
        Inventory.itens_available.Add(new { name = "Peças", height = 1.2, description = "Usada pelos mecânicos para reparar e personalizar veículos.", icon = "ammo_9mm", object_hash = 1877891248, position_z = 0.80f, guest = false });
        Inventory.itens_available.Add(new { name = "Mochila Pequena", height = 7.6, description = "Usado para almenta 50 KG", icon = "small_backpack", object_hash = 1277738372, position_z = 0.75f, guest = false });
        Inventory.itens_available.Add(new { name = "Mochila Grande", height = 14.5, description = "Usado para almenta 100 KG", icon = "big_backpack", object_hash = -679192147, position_z = 0.95f, guest = false });
        Inventory.itens_available.Add(new { name = "Maconha não-processada", height = 0.5, description = "Esta é uma erva que precisa ser processado para uso ou venda.", icon = "weed_seeds", object_hash = -1688127, position_z = 0.95f, guest = true });
        Inventory.itens_available.Add(new { name = "Porção de Maconha", height = 0.3, description = "Maconha processada", icon = "marijuana", object_hash = -54433116, position_z = 0.95f, guest = false });
        Inventory.itens_available.Add(new { name = "Sal", height = 0.4, description = "Sal", icon = "salt", object_hash = 936464539, position_z = 0.93f, guest = true });
        Inventory.itens_available.Add(new { name = "Sal Refinado", height = 0.3, description = "Sal refinado", icon = "salt_refined", object_hash = 936464539, position_z = 0.93f, guest = true });
        Inventory.itens_available.Add(new { name = "Opium", height = 0.8, description = "Opium", icon = "opium", object_hash = 2093428068, position_z = 2f, guest = true });
        Inventory.itens_available.Add(new { name = "Heroina", height = 0.4, description = "Heroina", icon = "heroin", object_hash = 16180688, position_z = 1, guest = false });
        Inventory.itens_available.Add(new { name = "Grao", height = 0.6, description = "...", icon = "grain", object_hash = -1734625067, position_z = 1.0, guest = true });
        Inventory.itens_available.Add(new { name = "Dinheiro Sujo", height = 0.000, description = "...", icon = "money-bag", object_hash = -1734625067, position_z = 1.0, guest = true });
        Inventory.itens_available.Add(new { name = "C4", height = 1.304, description = "...", icon = "c4", object_hash = -1266278729, position_z = 1.0, guest = true });
        Inventory.itens_available.Add(new { name = "Drill", height = 3.284, description = "...", icon = "c4", object_hash = -443429795, position_z = 1.0, guest = true });
    */

    public class InventoryEnum : IEquatable<InventoryEnum>
    {
        public int id { get; set; }
        public int[] sql_id { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] type { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] amount { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] inuse { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] dropable { get; set; } = new int[MAX_INVENTORY_ITENS];
        public int[] slotid { get; set; } = new int[MAX_INVENTORY_ITENS];

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            InventoryEnum objAsPart = obj as InventoryEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(InventoryEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<InventoryEnum> player_inventory = new List<InventoryEnum>();



    public Inventory()
    {

        /*
        Sardinha
        Bagre
        Olho de Cão
        Peixe Espada
        Cavala
        Peixe Agulha
        Badejo
        Bacalhau
        Atum
        Tubarão
        Dourado do Mar
        Peixe do Silvio Santos
        */

        for (int i = 0; i < Main.MAX_PLAYERS; i++)
        {
            player_inventory.Add(new InventoryEnum { id = i });
        }


    }


    public static void OnPlayerConnected(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            player_inventory[playerid].sql_id[i] = -1;
            player_inventory[playerid].type[i] = 0;
            player_inventory[playerid].amount[i] = 0;
            player_inventory[playerid].inuse[i] = 0;
            player_inventory[playerid].dropable[i] = 1;
            player_inventory[playerid].slotid[i] = -1;

        }
    }

    public static void OnPlayerDisconnect(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            player_inventory[playerid].sql_id[i] = -1;
            player_inventory[playerid].type[i] = 0;
            player_inventory[playerid].amount[i] = 0;
            player_inventory[playerid].inuse[i] = 0;
            player_inventory[playerid].dropable[i] = 1;
            player_inventory[playerid].slotid[i] = -1;
        }
    }

    public static async System.Threading.Tasks.Task LoadPlayerInventoryItens(Player Client)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            await Mainpipeline.OpenAsync();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `inventory` WHERE `owner` = '" + AccountManage.GetPlayerSQLID(Client) + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                string data2txt = string.Empty;
                string datatxt = string.Empty;
                int playerid = Main.getIdFromClient(Client);
                while (await reader.ReadAsync())
                {
                    if (reader.GetInt32("amount") == 0)
                    {
                        Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `id` = '" + reader.GetInt32("id") + "';");
                        continue;
                    }

                    SendItemFromSQLtoInventory(Client, reader.GetInt32("id"), reader.GetInt32("type"), reader.GetInt32("amount"), reader.GetByte("dropable"), reader.GetByte("inuse"), reader.GetInt32("slotid"));
                }
            }
        }

    }

    public static async System.Threading.Tasks.Task SendItemFromSQLtoInventory(Player Client, int sql_id, int type, int amount, byte dropable, int inuse, int slotid)
    {
        int playerid = Main.getIdFromClient(Client);

        LoadItemFromSQLExteraSetup(Client, sql_id, type, amount, dropable, inuse, slotid);
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (player_inventory[playerid].sql_id[index] == -1)
            {
                player_inventory[playerid].sql_id[index] = sql_id;
                player_inventory[playerid].type[index] = type;
                player_inventory[playerid].amount[index] = amount;
                player_inventory[playerid].inuse[index] = inuse;
                player_inventory[playerid].dropable[index] = dropable;
                player_inventory[playerid].slotid[index] = slotid;
                return;
            }
        }
    }

    public static void LoadItemFromSQLExteraSetup(Player client, int sqlid, int type, int amount, byte dropable, int inuse, int slotid)
    {
        switch (type)
        {
            case 43:
                {
                    /* if (inuse == 1)
                     {
                         client.SetData<dynamic>("Gloves_Box", true);

                     }*/
                    break;
                }
            default:
                break;
        }
    }


    public static void GiveItemToInventoryFromName(Player Client, string item_name, int item_amount = 1, int dropable = 1, int Inuse = 0)
    {
        if (item_amount < 1)
        {
            return;
        }

        if (Item_Name_To_Type(item_name) == 255)
        {
            return;
        }
        GiveItemToInventory(Client, Item_Name_To_Type(item_name), item_amount, dropable, Inuse);
    }

    public static void GiveItemToInventoryFromName(Player Client, string item_name, int item_amount = 1)
    {
        if (item_amount < 1)
        {
            return;
        }

        if (Item_Name_To_Type(item_name) == 255)
        {
            return;
        }
        GiveItemToInventory(Client, Item_Name_To_Type(item_name), item_amount);
    }

    public static List<int> NumberOfInventorySlot = new List<int>();
    public static int GetFreeSlotID(Player client)
    {
        int playerid = Main.getIdFromClient(client);
        List<int> nums = NumberOfInventorySlot;
        for (int i = 0; i < NumberOfInventorySlot.Count; i++)
        {
            if (player_inventory[playerid].slotid[i] != -1)
            {
                nums.Remove(i);
            }
        }
        return nums.First();
    }

    [RemoteEvent("InventoryChangeSlot")]
    public void ChangeItemSlot(Player client, int sqlid, int dataslot)
    {
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            if (player_inventory[Main.getIdFromClient(client)].sql_id[i] == sqlid)
            {
                player_inventory[Main.getIdFromClient(client)].slotid[i] = dataslot;
                Main.CreateMySqlCommand("UPDATE `inventory` SET `slotid` = " + dataslot + " WHERE `id` = " + sqlid + "");
                return;
            }
        }
    }

    public static void GiveItemToInventory(Player Client, int type, int amount = 1, int dropable = 1, int inuse = 0, int slotid = -1)
    {
        
        int playerid = Main.getIdFromClient(Client);

        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (player_inventory[playerid].sql_id[index] == -1)
            {
                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                {
                    try
                    {

                        Mainpipeline.Open();
                        string query = "INSERT INTO inventory (`owner`, `type`, `amount`,`dropable`,`inuse`)" + " VALUES ('" + AccountManage.GetPlayerSQLID(Client) + "', '" + type + "', '" + amount + "','" + dropable + "','" + inuse + "')";
                        MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);
                        myCommand.ExecuteNonQuery();
                        long last_inventory_id = myCommand.LastInsertedId;

                        player_inventory[playerid].sql_id[index] = Convert.ToInt32(last_inventory_id);
                        player_inventory[playerid].type[index] = type;
                        player_inventory[playerid].amount[index] = amount;
                        player_inventory[playerid].inuse[index] = inuse;
                        player_inventory[playerid].dropable[index] = dropable;
                        player_inventory[playerid].slotid[index] = slotid;
                        Mainpipeline.Close();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);

                    }
                }
                BackPack_OverLoad(Client);
                return;
            }
        }

    }

    public static void RemoveItemFromInventory(Player Client, int index, int amount = 0)
    {
        int playerid = Main.getIdFromClient(Client);
        DeleteCustomItemOptions(Client, index);
        if (player_inventory[playerid].amount[index] >= 2)
        {
            player_inventory[playerid].amount[index] -= amount;
            Main.CreateMySqlCommand("UPDATE inventory SET `amount` = " + player_inventory[playerid].amount[index] + " WHERE `id` = " + player_inventory[playerid].sql_id[index] + "");

            if (player_inventory[playerid].amount[index] < 1)
            {
                Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `id` = '" + player_inventory[playerid].sql_id[index] + "';");

                player_inventory[playerid].sql_id[index] = -1;
                player_inventory[playerid].type[index] = 0;
                player_inventory[playerid].amount[index] = 0;
                player_inventory[playerid].inuse[index] = 0;
                player_inventory[playerid].dropable[index] = 1;
                player_inventory[playerid].slotid[index] = -1;
            }
        }
        else
        {
            Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `id` = '" + player_inventory[playerid].sql_id[index] + "';");

            player_inventory[playerid].sql_id[index] = -1;
            player_inventory[playerid].type[index] = 0;
            player_inventory[playerid].amount[index] = 0;
            player_inventory[playerid].inuse[index] = 0;
            player_inventory[playerid].dropable[index] = 1;
            player_inventory[playerid].slotid[index] = -1;

        }
    }


    public static void ClearInventory(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            DeleteCustomItemOptions(Client, i);
            player_inventory[playerid].sql_id[i] = -1;
            player_inventory[playerid].type[i] = 0;
            player_inventory[playerid].amount[i] = 0;
            player_inventory[playerid].inuse[i] = 0;
            player_inventory[playerid].dropable[i] = 1;
            player_inventory[playerid].slotid[i] = -1;
        }

        Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `owner` = '" + AccountManage.GetPlayerSQLID(Client) + "';");
    }

    public static void ResetInventoryVariables(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            DeleteCustomItemOptions(Client, i);

            player_inventory[playerid].sql_id[i] = -1;
            player_inventory[playerid].type[i] = 0;
            player_inventory[playerid].amount[i] = 0;
            player_inventory[playerid].inuse[i] = 0;
            player_inventory[playerid].dropable[i] = 1;
            player_inventory[playerid].slotid[i] = -1;

        }
    }

    public static int GetItemCategoryid(string name)
    {
        foreach (var item in itens_available)
        {
            if (item.name == name)
            {
                return item.guest;
            }
        }
        return 255;
    }

    public static int Item_Name_To_Type(string name)
    {
        foreach (var item in itens_available)
        {
            if (item.name == name)
            {
                return item.id;
            }
        }
        return 255;
    }

    public static string Item_Name_To_Type(int name)
    {
        foreach (var item in itens_available)
        {
            if (item.id == name)
            {
                return item.name;
            }
        }
        return "";
    }


    public static int InventoryTypeToID(int type)
    {
        int index = -1;
        foreach (var item in itens_available)
        {
            if (item.id == type)
            {
                return item.id;
            }
        }
        return index;
    }

    [RemoteEvent("SetGroundPos")]
    public void SetGroundPos(Player client, float z)
    {
        client.SetData<dynamic>("ToGround", z);

    }
    // 
    public static void DropAllInventory(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);

        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            if (player_inventory[playerid].amount[i] >= 1)
            {
                //   Main.SendCustomChatMessasge(Client,player_inventory[playerid].dropable + " " + player_inventory[playerid].type[i]);

                DropItemFromInventory(Client, i, Item_Name_To_Type(player_inventory[playerid].type[i]), player_inventory[playerid].amount[i]);
            }
            /* else if (player_inventory[playerid].amount[i] >= 1 && player_inventory[playerid].dropable == 0)
             {
                 Main.SendCustomChatMessasge(Client,player_inventory[playerid].dropable + " " + player_inventory[playerid].type[i]);
                 RemoveItemFromInventory(Client, i, player_inventory[playerid].amount[i]);

             }*/
        }

        //  Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `owner` = '" + AccountManage.GetPlayerSQLID(Client) + "';");
    }
    public static void ChangeInUseWeapon(Player player, WeaponHash weapon)
    {
        int playerid = Main.getIdFromClient(player);
        foreach (var item in Inventory.player_inventory)
        {
            if (item.id == playerid)
            {
                for (int i = 0; i < Inventory.MAX_INVENTORY_ITENS; i++)
                {
                    if (Inventory.player_inventory[playerid].amount[i] >= 1)
                    {
                        if (Inventory.itens_available[Inventory.player_inventory[playerid].type[i]].guest == Inventory.ITEM_TYPE_WEAPON && Inventory.itens_available[Inventory.player_inventory[playerid].type[i]].name == Enum.GetName(typeof(WeaponHash), weapon) && Inventory.player_inventory[playerid].inuse[i] == 1)
                        {
                            Inventory.player_inventory[playerid].inuse[i] = 0;
                            Main.CreateMySqlCommand("UPDATE inventory SET `inuse` = " + 0 + " WHERE `id` = " + player_inventory[playerid].sql_id[i] + "");
                            break;
                        }
                    }
                }
                break;
            }
        }
    }
    public static void ChangeInUseWeapon2(Player player, WeaponHash weapon, int Inuse)
    {
        int playerid = Main.getIdFromClient(player);
        foreach (var item in Inventory.player_inventory)
        {
            if (item.id == playerid)
            {
                for (int i = 0; i < Inventory.MAX_INVENTORY_ITENS; i++)
                {
                    if (Inventory.player_inventory[playerid].amount[i] >= 1)
                    {
                        if (Inventory.itens_available[Inventory.player_inventory[playerid].type[i]].guest == Inventory.ITEM_TYPE_WEAPON && Inventory.itens_available[Inventory.player_inventory[playerid].type[i]].name == Enum.GetName(typeof(WeaponHash), weapon))
                        {
                            Inventory.player_inventory[playerid].inuse[i] = Inuse;
                            Main.CreateMySqlCommand("UPDATE inventory SET `inuse` = " + player_inventory[playerid].inuse[i] + " WHERE `id` = " + player_inventory[playerid].sql_id[i] + "");
                            break;
                        }
                    }

                }

                break;
            }
        }
    }

    public static void oruzijeinuse(Player player)
    {
        int playerid = Main.getIdFromClient(player);
        WeaponHash weapon = NAPI.Player.GetPlayerCurrentWeapon(player);
        foreach (var item in Inventory.player_inventory)
        {
            if (item.id == playerid)
            {
                for (int i = 0; i < Inventory.MAX_INVENTORY_ITENS; i++)
                {
                    if (Inventory.player_inventory[playerid].amount[i] >= 1)
                    {
                        if (Inventory.itens_available[Inventory.player_inventory[playerid].type[i]].guest == Inventory.ITEM_TYPE_WEAPON && Inventory.itens_available[Inventory.player_inventory[playerid].type[i]].name == Enum.GetName(typeof(WeaponHash), weapon))
                        {
                            Inventory.player_inventory[playerid].inuse[i] = 0;
                            Main.CreateMySqlCommand("UPDATE inventory SET `inuse` = " + player_inventory[playerid].inuse[i] + " WHERE `id` = " + player_inventory[playerid].sql_id[i] + "");
                            WeaponManage.RemovePlayerWeaponAndAttachment(player, weapon);
                            break;
                        }
                    }

                }

                break;
            }
        }
    }

    public static void DeleteCustomItemOptions(Player player, int index)
    {
        if (player_inventory[player.Value].amount[index] > 0 && player_inventory[player.Value].type[index] == 18)// Pancir
        {
            player_inventory[player.Value].inuse[index] = 0;
            player.SetClothes(9, 0, 0);
            NAPI.Data.SetEntitySharedData(player, "character_armor", 0);
            NAPI.Data.SetEntitySharedData(player, "character_armor_texture", 0);
            player.SetData("armor_enable", false);
        }
    }

    public static void ChangeInUseItem(Player player, int itemsql, int inuse = 1)
    {
        int playerid = Main.getIdFromClient(player);
        foreach (var item in Inventory.player_inventory)
        {
            if (item.id == playerid)
            {
                for (int i = 0; i < Inventory.MAX_INVENTORY_ITENS; i++)
                {
                    if (Inventory.player_inventory[playerid].amount[i] >= 1 && player_inventory[playerid].sql_id[i] == itemsql)
                    {
                        if (player_inventory[playerid].inuse[i] == 1)
                        {
                            DeleteCustomItemOptions(player, i);
                        }
                        Inventory.player_inventory[playerid].inuse[i] = inuse;
                        Main.CreateMySqlCommand("UPDATE inventory SET `inuse` = " + inuse + " WHERE `id` = " + player_inventory[playerid].sql_id[i] + "");
                        break;
                    }
                }
                break;
            }
        }
    }
    public void checkwep(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);

        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            /* if (player_inventory[playerid].amount[i] >= 1 && player_inventory[playerid].dropable == 1)
             {
                 Main.SendCustomChatMessasge(Client,player_inventory[playerid].type[i] + " Dropable ");
             }
             else if (player_inventory[playerid].amount[i] >= 1 && player_inventory[playerid].dropable == 0)
             {
                 Main.SendCustomChatMessasge(Client,player_inventory[playerid].type[i] + " Not Dropable ");
             }*/
        }
    }
    public static void DropItemFromInventory(Player Client, int index, string itemName, int amount, int OpenwhichInventory = 1)
    {
        int i = 0;
        foreach (var item in itens_available)
        {
            if (item.name == itemName)
            {
                int playerid = Main.getIdFromClient(Client);
                if (OpenwhichInventory != -1 && player_inventory[playerid].inuse[index] == 1 || player_inventory[playerid].dropable[index] == 0)
                {
                    return;
                }
                string unidade;
                if (amount == 1) unidade = "x";
                else unidade = "x";
                var rnd = new Random();
                if (item.id == 23)
                {
                    if (GetInventoryIndexFromName(Client, "Radio") <= 1)
                    {
                        Radio.RadioSystem.ToggleRadio(Client, false);
                    }
                }
                var xrnd = rnd.NextDouble();
                var yrnd = rnd.NextDouble();
                inventory_objects.Add(new
                {
                    item_type = player_inventory[Main.getIdFromClient(Client)].type[index],
                    item_pos_x = Client.Position.X + xrnd,
                    item_pos_y = Client.Position.Y + yrnd,
                    item_pos_z = Client.Position.Z,
                    dimension = Client.Dimension,

                    item_amount = amount,

                    item_object_handle = NAPI.Object.CreateObject(item.hash, new Vector3(Client.Position.X + xrnd, Client.Position.Y + yrnd, Client.Position.Z - 0.5f), new Vector3(0, 0, 0), dimension: Client.Dimension),
                    item_label_handle = NAPI.TextLabel.CreateTextLabel("" + item.name + " ~g~(" + amount + " " + unidade + ")~w~~n~ [ ~c~E~w~ ]", new Vector3(Client.Position.X + xrnd, Client.Position.Y + yrnd, Client.Position.Z - 0.4), 7, 0.15f, 4, new Color(221, 255, 0, 255), dimension: Client.Dimension)
                });

                RemoveItemFromInventory(Client, index, amount);
                BackPack_OverLoad(Client);
                if (OpenwhichInventory == 2)
                {
                    VehicleInventory.ShowToPlayerVehicleInventory(Client);
                }
                else if (OpenwhichInventory == 1)
                {
                    Inventory.ShowPlayerInventory(Client);
                }
                else if (OpenwhichInventory == 3)
                {
                    HouseSystem.ShowHouseInventory(Client);
                }
                else if (OpenwhichInventory == 4)
                {
                    WerehouseManage.ShowHQInventory(Client);
                }
                // Client.PlayAnimation("mp_weapon_drop", "drop_lh", 0);

                /*NAPI.Player.PlayPlayerAnimation(Client, (int)(Main.AnimationFlags.Cancellable), "mp_weapon_drop", "drop_lh");
                NAPI.Task.Run(() =>
                {
                    NAPI.Player.StopPlayerAnimation(Client);
                }, delayTime: 1500);*/

                return;
            }

            i++;
        }
    }

    [RemoteEvent("OnClientItemAction")]
    public static void OnClientItemAction(Player Client, int sqlid, int amount, int openwhichinventory)
    {
        int playerid = Main.getIdFromClient(Client);
        int index = GetInventoryIndexFromSQLID(Client, sqlid);

        if (index == -1)
        {
            return;
        }
        try
        {
            if (player_inventory[playerid].sql_id[index] == -1)
            {
                Main.SendErrorMessage(Client, "Greska. (" + player_inventory[playerid].sql_id[index] + " - " + index + " - " + player_inventory[playerid].type[index] + ")");
                return;
            }
            if (player_inventory[playerid].amount[index] < 1)
            {
                return;
            }
            if (itens_available[player_inventory[playerid].type[index]].guest != ITEM_TYPE_Ammunation)
            {
                amount = 1;
            }

            UseItemFromInventory(Client, index, amount, openwhichinventory);
            return;

            if (false)
            {
                foreach (var target in API.Shared.GetAllPlayers())
                {
                    if (target.GetData<dynamic>("status") == true)
                    {
                        if (Main.IsInRangeOfPoint(Client.Position, target.Position, 2.0f))
                        {
                            Client.SetData<dynamic>("target_item_handle", target);
                            Client.SetData<dynamic>("target_item_name", itens_available[player_inventory[playerid].type[index]].name);


                            Client.TriggerEvent("Destroy_Character_Menu");
                            InteractMenu.User_Input(Client, "give_item_to_other_play", "Dar " + itens_available[player_inventory[playerid].type[index]].name + " for: " + AccountManage.GetCharacterName(target) + "", 50.ToString(), "", "number");
                        }
                    }
                }
            }
        }
        catch
        {

        }
    }

    public static void UseItemFromInventory(Player Client, int item, int amount, int ShowVehicleInventory = 1)
    {
        try
        {

            int playerid = Main.getIdFromClient(Client);
            int index = item;
            int type = player_inventory[playerid].type[index];
            Client.SetData<dynamic>("inventory_item_selected", itens_available[type].name);

           
            if (player_inventory[playerid].inuse[index] == 1)
            {
                return;
            }
            if (itens_available[type].guest == ITEM_TYPE_WEAPON)
            {
                var i = 0;
                int weapon_id = -1;
                foreach (var gun in Main.weapon_list)
                {
                    if (gun.model.Contains(itens_available[type].name) == true)
                    {
                        weapon_id = i;
                        break;
                    }
                    i++;
                }
                if (Main.weapon_list[weapon_id].classe == "Primary")
                {
                    if (Client.GetData<dynamic>("primary_weapon") != 0)
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate primarno oruzje!");
                        return;
                    }
                }
                else if (Main.weapon_list[weapon_id].classe == "Secundary")
                {
                    if (Client.GetData<dynamic>("secundary_weapon") != 0)
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate sekundarno oruzje!");
                        return;
                    }
                }
                else if (Main.weapon_list[weapon_id].classe == "Melee")
                {
                    if (Client.GetData<dynamic>("weapon_meele") != 0)
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate hladno oruzje!");
                        return;
                    }
                }
                else if (Main.weapon_list[weapon_id].classe == "pistol")
                {
                    if (Client.GetData<dynamic>("pistol_weapon") != 0)
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate pistolj!");
                        return;
                    }
                }
                else if (Main.weapon_list[weapon_id].classe == "Tazer")
                {
                    if (Client.GetData<dynamic>("tazer_weapon") != 0)
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate tazer!");
                        return;
                    }
                }






                Client.SendNotification("+ ~y~" + itens_available[type].name + "");

                WeaponManage.SetPlayerWeaponEx(Client, itens_available[type].name, 0);
                player_inventory[playerid].inuse[index] = 1;
                Main.CreateMySqlCommand("UPDATE inventory SET `inuse` = " + 1 + " WHERE `id` = " + player_inventory[playerid].sql_id[index] + "");
                WeaponManage.SaveWeapons(Client);
                if (ShowVehicleInventory == 2)
                {
                    VehicleInventory.ShowToPlayerVehicleInventory(Client);
                }
                else if (ShowVehicleInventory == 1)
                {
                    Inventory.ShowPlayerInventory(Client);
                }
                else if (ShowVehicleInventory == 3)
                {
                    HouseSystem.ShowHouseInventory(Client);
                }
                else if (ShowVehicleInventory == 4)
                {
                    WerehouseManage.ShowHQInventory(Client);
                }
                return;
            }

            if (Client.GetData<dynamic>("INV_Busy") > DateTimeOffset.Now.ToUnixTimeSeconds())
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "[ANTI-SPAM] Sacekajte malo!");
                return;
            }
            Client.SetData<dynamic>("INV_Busy", DateTimeOffset.Now.ToUnixTimeSeconds() + 1);

            switch (type)
            {
                case 1:
                    {
                        // message

                        // remove item and hide inventory

                        // attributes
                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "[ANTI-SPAM] Sacekajte malo!");
                            break;
                        }
                        RemoveItemFromInventory(Client, index, 1);
                        AccountManage.SetPlayerThirsty(Client, 48.0f);

                        if (!Client.IsInVehicle)
                        {
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_ld_flow_bottle"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_intdrink", "loop_bottle");
                            Client.SetData<dynamic>("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    BasicSync.DetachObject(Client);
                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_intdrink", "outro_bottle");
                                    Client.SetData<dynamic>("EatColDown", false);

                                }

                            }, delayTime: 5000);
                        }
                        break;
                    }

                case 2:
                    {
                        // message

                        // remove item and hide inventory

                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "[ANTI-SPAM] Sacekajte malo!");
                            break;
                        }
                        RemoveItemFromInventory(Client, index, 1);
                        AccountManage.SetPlayerHunger(Client, 49.0f);
                        if (!Client.IsInVehicle)
                        {
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_cs_burger_01"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            Client.SetData<dynamic>("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    Client.SetData<dynamic>("EatColDown", false);
                                    BasicSync.DetachObject(Client);
                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_inteat@burger", "mp_player_int_eat_exit_burger");
                                    if (Client.Health + 5 >= 100)
                                    {
                                        NAPI.Player.SetPlayerHealth(Client, 100);
                                    }
                                    else
                                    {
                                        NAPI.Player.SetPlayerHealth(Client, Client.Health + 5);
                                    }
                                }
                            }, delayTime: 5000);
                        }
                        break;
                    }
                case 3:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (Client.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Sniper Rifles")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Client.SendNotification("Greska!~n~Morate uzeti oruzje kako biste koristili municiju.");
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Client.SendNotification("Greska!~n~Nemate municiju.");
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Client.SendNotification("Greska!~n~Nemate municiju.");
                            return;
                        }

                        //
                        //Client.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(Client, index, value);

                        //
                        Client.SetData<dynamic>("primary_ammunation", Client.GetData<dynamic>("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(Client, Client.CurrentWeapon, Client.GetData<dynamic>("primary_ammunation"));
                        // NAPI.Player.SetPlayerCurrentWeaponAmmo(Client, Client.GetData<dynamic>("primary_ammunation"));

                        //
                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "Uzeli ste " + value + " ~g~" + itens_available[type].name + "");
                        break;
                    }
                case 4:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (Client.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Assault Rifles")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Client.SendNotification("Greska!~n~Morate uzeti oruzje kako biste koristili municiju.");
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];


                        int value = amount;

                        if (value < 1)
                        {
                            Client.SendNotification("Greska!~n~Nemate municiju.");
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Client.SendNotification("Greska!~n~Nemate municiju.");
                            return;
                        }

                        //
                        //Client.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(Client, index, value);
                        //
                        Client.SetData<dynamic>("primary_ammunation", Client.GetData<dynamic>("primary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(Client, Client.CurrentWeapon, Client.GetData<dynamic>("primary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(Client, Client.GetData<dynamic>("primary_ammunation"));
                        //
                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "Uzeli ste " + value + " ~g~" + itens_available[type].name + "~w~ .");

                        break;
                    }
                case 5:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (Client.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Shotguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Client.SendNotification("Greska!~n~Morate uzeti oruzje kako biste koristili municiju.");
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Client.SendNotification("Greska!~n~Nemate municiju.");
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Client.SendNotification("Greska!~n~Nemate municiju.");
                            return;
                        }
                        //
                        // Client.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(Client, index, value);
                        //
                        Client.SetData<dynamic>("secundary_ammunation", Client.GetData<dynamic>("secundary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(Client, Client.CurrentWeapon, Client.GetData<dynamic>("secundary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(Client, Client.GetData<dynamic>("secundary_ammunation"));
                        //
                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "Uzeli ste " + value + " ~g~" + itens_available[type].name + "~w~ .");

                        //InteractMenu.User_Input(Client, "weapon_reload_secundary", "Recarregar Arma Primaria (Limite: 250)", 50.ToString(), "", "number");
                        break;
                    }
                case 6:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (Client.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Handguns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Client.SendNotification("Greska!~n~Morate uzeti oruzje kako biste koristili municiju.");
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Client.SendNotification("Greska!~n~Nemate municiju.");
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Client.SendNotification("Greska!~n~Nemate municiju.");
                            return;
                        }

                        //
                        // Client.TriggerEvent("Destroy_Character_Menu");
                        RemoveItemFromInventory(Client, index, value);

                        //
                        Client.SetData<dynamic>("pistol_ammunation", Client.GetData<dynamic>("pistol_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(Client, Client.CurrentWeapon, Client.GetData<dynamic>("pistol_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(Client, Client.GetData<dynamic>("pistol_ammunation"));

                        //
                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "Uzeli ste " + value + " ~g~" + itens_available[type].name + "~w~ .");



                        break;
                    }
                case 7:
                    {
                        bool can_pass = false;
                        foreach (var w in Main.weapon_list)
                        {
                            if (Client.CurrentWeapon == NAPI.Util.WeaponNameToModel(w.model))
                            {
                                if (w.type == "Machine Guns")
                                {
                                    can_pass = true;
                                }
                            }
                        }

                        if (can_pass == false)
                        {
                            Client.SendNotification("Greska!~n~Morate uzeti oruzje kako biste koristili municiju.");
                            return;
                        }

                        int ammo_actual = player_inventory[playerid].amount[index];

                        int value = amount;

                        if (value < 1)
                        {
                            Client.SendNotification("Greska!~n~Nemate municiju.");
                            return;
                        }

                        if (ammo_actual < value)
                        {
                            Client.SendNotification("Greska!~n~Nemate municiju.");
                            return;
                        }

                        //
                        //Client.TriggerEvent("Destroy_Character_Menu");

                        RemoveItemFromInventory(Client, index, value);

                        //
                        Client.SetData<dynamic>("secundary_ammunation", Client.GetData<dynamic>("secundary_ammunation") + value);
                        API.Shared.SetPlayerWeaponAmmo(Client, Client.CurrentWeapon, Client.GetData<dynamic>("secundary_ammunation"));
                        NAPI.Player.SetPlayerCurrentWeaponAmmo(Client, Client.GetData<dynamic>("secundary_ammunation"));

                        //
                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "Uzeli ste " + value + " ~g~" + itens_available[type].name + "~w~ .");



                        break;
                    }
                case 9:
                    {
                        if (Client.GetData<dynamic>("character_backpack") == 0)
                        {
                            Client.SetData<dynamic>("character_backpack", 1);

                            RemoveItemFromInventory(Client, index, 1);
                            Main.SendSuccessMessage(Client, "Uzeli ste " + Main.EMBED_ORANGE + "mali ranac" + Main.EMBED_WHITE + " sada mozete imati " + Main.EMBED_LIGHTGREEN + "" + GetInventoryMaxHeight(Client) + " kg" + Main.EMBED_WHITE + " kod sebe.");
                            Client.TriggerEvent("ShowDialogAutoClose", "success", "Stavili ste mali ranac", "", 1400);
                        }
                        else
                        {
                            Client.SendNotification("Greska!~n~Nemate ranac.");
                        }
                        break;
                    }
                case 10:
                    {
                        if (Client.GetData<dynamic>("character_backpack") == 0)
                        {
                            Client.SetData<dynamic>("character_backpack", 2);


                            AccountManage.UpdateBackpack(Client);
                            RemoveItemFromInventory(Client, index, 1);
                            Main.SendSuccessMessage(Client, "Uzeli ste " + Main.EMBED_ORANGE + "Veliki ranac" + Main.EMBED_WHITE + " sada mozete nositi " + Main.EMBED_LIGHTGREEN + " " + GetInventoryMaxHeight(Client) + " kg" + Main.EMBED_WHITE + " kod sebe.");

                            Client.TriggerEvent("ShowDialogAutoClose", "success", "Stavili ste veliki ranac! ", "", 1400);
                        }
                        else
                        {
                            Client.SendNotification("Greska!~n~Nemate ranac.");
                        }
                        break;
                    }
                case 12:
                    {
                        Client.TriggerEvent("screen_weed");
                        NAPI.Player.PlayPlayerAnimation(Client, 49, "amb@world_human_smoking@male@male_a@idle_a", "idle_c");
                        NAPI.Task.Run(() =>
                        {
                            if (!NAPI.Player.IsPlayerConnected(Client)) return;
                            Client.StopAnimation();
                        }, delayTime: 5000);
                        RemoveItemFromInventory(Client, index, 1);

                        /*if (Client.Armor <= 50)
                        {
                            Client.Armor = Client.Armor + 10;
                        }*/

                        if (Client.GetData<dynamic>("inEffect_weed") == -1)
                        {
                            Client.SetData<dynamic>("inEffect_weed", 30);
                        }
                        else Client.SetData<dynamic>("inEffect_weed", Client.GetData<dynamic>("inEffect_weed") + 30);

                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "Naduvani ste");
                        //Client.TriggerEvent("update_armor", Client.Armor);
                        break;
                    }
                case 16:
                    {
                        Client.TriggerEvent("setResistStage", 3);
                        Client.TriggerEvent("screen_cocaine");
                        NAPI.Player.PlayPlayerAnimation(Client, 49, "amb@world_human_smoking@male@male_a@idle_a", "idle_c");
                        NAPI.Task.Run(() =>
                        {
                            if (!NAPI.Player.IsPlayerConnected(Client)) return;
                            Client.StopAnimation();
                        }, delayTime: 5000);
                        RemoveItemFromInventory(Client, index, 1);

                        /*if (Client.Armor <= 99)
                        {
                            if (Client.Armor + 35 >= 100) Client.Armor = 50;
                            else Client.Armor = Client.Armor + 35;
                        }*/

                        if (Client.GetData<dynamic>("inEffect_heroin") == -1)
                        {
                            Client.SetData<dynamic>("inEffect_heroin", 40);
                        }
                        else Client.SetData<dynamic>("inEffect_heroin", Client.GetData<dynamic>("inEffect_heroin") + 40);

                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "Nasmrkani ste");
                        //Client.TriggerEvent("update_armor", Client.Armor);
                        break;
                    }
                case 18:
                    {
                        if (Client.HasSharedData("character_armor") && Client.GetSharedData<dynamic>("character_armor") != 0)
                        {
                            Main.SendCustomChatMessasge(Client, "Vec imate pancir!");
                            return;
                        }
                        Client.SetSharedData("character_armor", 12);
                        Client.SetSharedData("character_armor_texture", 1);
                        Client.SetSharedData("armor_enable", false);
                        ToggleClothing(Client, 15);
                        ChangeInUseItem(Client, player_inventory[Client.Value].sql_id[index], 1);
                        Inventory.RemoveItemByType(Client, 18, 1);
                        Client.Armor = 30;
                       
                        break;
                    }
                case 26:
                    {
                        if (Client.HasSharedData("character_armor") && Client.GetSharedData<dynamic>("character_armor") != 0)
                        {
                            Main.SendCustomChatMessasge(Client, "Stavili ste pancir!");
                            return;
                        }
                        Client.SetSharedData("character_armor", 2);
                        Client.SetSharedData("character_armor_texture", 1);
                        Client.SetSharedData("armor_enable", false);
                        ToggleClothing(Client, 15);

                        ChangeInUseItem(Client, player_inventory[Client.Value].sql_id[index], 1);

                        break;
                    }
                case 22:
                    {
                        if (Client.GetData<dynamic>("isbandaging") == 1) { Main.SendCustomChatMessasge(Client, "~r~Vec koristite zavoje, sacekajte!"); return; }
                        if ((Client.Health) >= 75) { Main.SendCustomChatMessasge(Client, "~r~Ne mozete se vise zaleciti zavojima!"); return; }

                        Random Rnd = new Random();

                        int Time = Rnd.Next(2500, 6000);
                        Client.SetData<dynamic>("isbandaging", 1);
                        Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.CenterRight, "Zavijate rane...", Time);
                        Client.TriggerEvent("freezeEx", true);
                        RemoveItemFromInventory(Client, index, 1);

                        NAPI.Task.Run(() =>
                        {
                            if (NAPI.Player.IsPlayerConnected(Client))
                            {
                            Client.SetData<dynamic>("isbandaging", 0);
                            int Value = Rnd.Next(19, 35);
                            Client.TriggerEvent("freezeEx", false);
                            if ((Client.Health + Value) > 75) { Client.Health = 75; return; }
                            NAPI.Player.SetPlayerHealth(Client, Client.Health + Value);
                            }

                        }, delayTime: Time);


                        break;
                    }
                case 23:
                    {
                        Radio.RadioSystem.ToggleRadio(Client);
                        break;
                    }
                case 24:
                    {
                        if (Client.IsInVehicle == true) { Main.SendCustomChatMessasge(Client, "Greska! ~r~U vozilu ste."); return; }
                        foreach (Vehicle veh in NAPI.Pools.GetAllVehicles())
                        {
                            if (Client.Position.DistanceTo(veh.Position) < 3f)
                            {
                                if (Client.GetSharedData<dynamic>("Injured") == 0)
                                {
                                    if (VehicleStreaming.GetLockState(veh) == false) { Main.SendCustomChatMessasge(Client, "Greska! ~r~ Vozilo je zakljucano!"); return; }
                                    if (Client.GetData<dynamic>("IsBobypining") == true) { Main.SendCustomChatMessasge(Client, "Greska!~r~ Obijate vozilo"); return; }

                                    Random Rnd = new Random();
                                    //int Rand = Rnd.Next(100);
                                    //  int time = Rnd.Next(10000, 19000);
                                    Client.TriggerEvent("Destroy_Character_Menu");
                                    RemoveItemFromInventory(Client, index, 1);
                                    animationCommands.OnPlayAnimationFromMenu(Client, "missheistfbisetup1", "unlock_loop_janitor", 39);
                                    Client.TriggerEvent("Lockpick");
                                    // Client.TriggerEvent("createNewHeadNotificationAdvanced", "Darhale Baz Kardan Ghofl...");
                                    Client.SetData<dynamic>("IsBobypining", true);
                                    Client.TriggerEvent("FreezeEx", true);
                                    Client.SetData<dynamic>("VehicleTarget", veh);

                                    /** NAPI.Task.Run(() =>
                                     {
                                         if (Rand < 20)
                                         {
                                             VehicleStreaming.SetLockStatus(veh, false);
                                             Client.TriggerEvent("createNewHeadNotificationAdvanced", "Ghofl Khodro ~g~Baz Shod");
                                             animationCommands.StopAnimationFromMenu(Client);
                                             Client.SetData<dynamic>("IsBobypining", false);
                                         }
                                         else
                                         {
                                             Client.TriggerEvent("createNewHeadNotificationAdvanced", "Ops Boby-Pin ~r~ Shekast");
                                             animationCommands.StopAnimationFromMenu(Client);
                                             Client.SetData<dynamic>("IsBobypining", false);
                                         }
                                     }, delayTime: time);*/
                                    return;
                                }
                            }

                        }
                        Main.SendCustomChatMessasge(Client, "Greska!~r~ Niste u blizini ni jednog vozila!");
                        break;
                    }
                case 27:
                    {
                        if (Client.GetData<dynamic>("isbandaging") == 1) { Main.SendCustomChatMessasge(Client, "~r~Vec pijete tabletu!"); return; }
                        if ((Client.Health) < 75) { Main.SendCustomChatMessasge(Client, "~r~Helti su ispod potrebnog za tablete!"); return; }

                        Random Rnd = new Random();

                        int Time = Rnd.Next(2500, 6000);
                        Client.SetData<dynamic>("isbandaging", 1);
                        Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.CenterRight, "Pijete tabletu...", Time);
                        Client.TriggerEvent("freezeEx", true);
                        RemoveItemFromInventory(Client, index, 1);

                        NAPI.Task.Run(() =>
                        {
                            if (NAPI.Player.IsPlayerConnected(Client))
                            {
                            Client.SetData<dynamic>("isbandaging", 0);
                            int Value = Rnd.Next(19, 35);
                            Client.TriggerEvent("freezeEx", false);
                            NAPI.Player.SetPlayerHealth(Client, 100);
                            }

                        }, delayTime: Time);


                        break;
                    }
                case 33:
                    {

                        break;
                    }
                case 35:
                    {

                        break;
                    }
                case 43:
                    {
                        if (Client.HasData("Gloves_Box"))
                        {
                            if (Client.GetData<dynamic>("Gloves_Box") == false)
                            {
                                Client.SetData<dynamic>("Gloves_Box", true);
                                player_inventory[Client.Value].inuse[index] = 1;
                            }
                            else
                            {
                                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Ne mozete to!");
                                return;
                            }
                        }
                        else
                        {
                            player_inventory[Client.Value].inuse[index] = 1;
                            Client.SetData<dynamic>("Gloves_Box", true);
                        }
                        break;
                    }
                case 44:
                    {
                        // message

                        // remove item and hide inventory

                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Sacekajte malo!");
                            break;
                        }
                        RemoveItemFromInventory(Client, index, 1);
                        Client.SendNotification("Pojeli ste ~g~HotDog~w~.");
                        AccountManage.SetPlayerHunger(Client, 24.0f);
                        if (!Client.IsInVehicle)
                        {
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_cs_hotdog_01"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            Client.SetData("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    Client.SetData("EatColDown", false);
                                    BasicSync.DetachObject(Client);
                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_inteat@burger", "mp_player_int_eat_exit_burger");
                                    if (Client.Health + 5 >= 100)
                                    {
                                        NAPI.Player.SetPlayerHealth(Client, 100);
                                    }
                                    else
                                    {
                                        NAPI.Player.SetPlayerHealth(Client, Client.Health + 5);
                                    }
                                }
                            }, delayTime: 5000);
                        }
                        break;
                    }
                case 45:
                    {
                        // message

                        // remove item and hide inventory

                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Sacekajte malo!");
                            break;
                        }
                        RemoveItemFromInventory(Client, index, 1);
                        Client.SendNotification("Pojeli ste ~g~Sendvic~w~.");
                        AccountManage.SetPlayerHunger(Client, 29.0f);
                        if (!Client.IsInVehicle)
                        {
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_sandwich_01"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_inteat@burger", "mp_player_int_eat_burger");
                            Client.SetData("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    Client.SetData("EatColDown", false);
                                    BasicSync.DetachObject(Client);
                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_inteat@burger", "mp_player_int_eat_exit_burger");
                                    if (Client.Health + 5 >= 100)
                                    {
                                        NAPI.Player.SetPlayerHealth(Client, 100);
                                    }
                                    else
                                    {
                                        NAPI.Player.SetPlayerHealth(Client, Client.Health + 5);
                                    }
                                }
                            }, delayTime: 5000);
                        }
                        break;
                    }
                case 46:
                    {
                        // message

                        // remove item and hide inventory

                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Sacekajte malo!");
                            break;
                        }
                        RemoveItemFromInventory(Client, index, 1);
                        Client.SendNotification("Popili ste a ~g~Coca Colu~w~.");
                        AccountManage.SetPlayerHunger(Client, 12.0f);
                        AccountManage.SetPlayerThirsty(Client, 21.0f);
                        if (!Client.IsInVehicle)
                        {
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_ecola_can"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_intdrink", "loop_bottle");

                            Client.SetData("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    Client.SetData("EatColDown", false);
                                    BasicSync.DetachObject(Client);

                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_intdrink", "outro_bottle");
                                    if (Client.Health + 5 >= 100)
                                    {
                                        NAPI.Player.SetPlayerHealth(Client, 100);
                                    }
                                    else
                                    {
                                        NAPI.Player.SetPlayerHealth(Client, Client.Health + 5);
                                    }
                                }
                            }, delayTime: 9000);
                        }
                        break;
                    }
                case 47:
                    {
                        // message

                        // remove item and hide inventory

                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Sacekajte malo!");
                            break;
                        }
                        RemoveItemFromInventory(Client, index, 1);
                        Client.SendNotification("Popili ste malo ~g~Crnog Vina~w~.");
                        AccountManage.SetPlayerHunger(Client, 5.0f);
                        AccountManage.SetPlayerThirsty(Client, 9.0f);
                        if (!Client.IsInVehicle)
                        {
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_wine_red"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_intdrink", "loop_bottle");

                            Client.SetData("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    Client.SetData("EatColDown", false);
                                    BasicSync.DetachObject(Client);

                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_intdrink", "outro_bottle");
                                    if (Client.Health + 5 >= 100)
                                    {
                                        NAPI.Player.SetPlayerHealth(Client, 100);
                                    }
                                    else
                                    {
                                        NAPI.Player.SetPlayerHealth(Client, Client.Health + 5);
                                    }
                                }
                            }, delayTime: 9000);
                        }
                        break;
                    }
                case 48:
                {
                    
                    
                    Client.TriggerEvent("knjiga_recepata");
                    break;
                }
                case 61:
                    {
                        // message

                        // remove item and hide inventory

                        // attributes
                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "[ANTI-SPAM] Sacekajte malo!");
                            break;
                        }
                        RemoveItemFromInventory(Client, index, 1);
                        AccountManage.SetPlayerThirsty(Client, 28.0f);

                        if (!Client.IsInVehicle)
                        {
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_orang_can_01"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_intdrink", "loop_bottle");
                            Client.SetData<dynamic>("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    BasicSync.DetachObject(Client);
                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_intdrink", "outro_bottle");
                                    Client.SetData<dynamic>("EatColDown", false);

                                }

                            }, delayTime: 5000);
                        }
                        break;
                    }
                    case 62:
                    {
                        // message

                        // remove item and hide inventory

                        // attributes
                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "[ANTI-SPAM] Sacekajte malo!");
                            break;
                        }
                        RemoveItemFromInventory(Client, index, 1);
                        AccountManage.SetPlayerThirsty(Client, 28.0f);

                        if (!Client.IsInVehicle)
                        {
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_ecola_can"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_intdrink", "loop_bottle");
                            Client.SetData<dynamic>("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    BasicSync.DetachObject(Client);
                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_intdrink", "outro_bottle");
                                    Client.SetData<dynamic>("EatColDown", false);

                                }

                            }, delayTime: 5000);
                        }
                        break;
                    }
                    case 63:
                    {
                        // message

                        // remove item and hide inventory

                        // attributes
                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "[ANTI-SPAM] Sacekajte malo!");
                            break;
                        }
                        RemoveItemFromInventory(Client, index, 1);
                        AccountManage.SetPlayerThirsty(Client, 28.0f);

                        if (!Client.IsInVehicle)
                        {
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("ng_proc_coffee_01a"), 60309, new Vector3(-0.04, 0, -0.02), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_intdrink", "loop_bottle");
                            Client.SetData<dynamic>("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    BasicSync.DetachObject(Client);
                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_intdrink", "outro_bottle");
                                    Client.SetData<dynamic>("EatColDown", false);

                                }

                            }, delayTime: 5000);
                        }
                        break;
                    }
                    case 65:
                    {
                        Client.TriggerEvent("setResistStage", 3);
                        Client.TriggerEvent("screen_cocaine");
                        NAPI.Player.PlayPlayerAnimation(Client, 49, "amb@world_human_smoking@male@male_a@idle_a", "idle_c");
                        NAPI.Task.Run(() =>
                        {
                            if (!NAPI.Player.IsPlayerConnected(Client)) return;
                            Client.StopAnimation();
                        }, delayTime: 5000);
                        RemoveItemFromInventory(Client, index, 1);

                        /*if (Client.Armor <= 99)
                        {
                            if (Client.Armor + 35 >= 100) Client.Armor = 50;
                            else Client.Armor = Client.Armor + 35;
                        }*/

                        if (Client.GetData<dynamic>("inEffect_heroin") == -1)
                        {
                            Client.SetData<dynamic>("inEffect_heroin", 40);
                        }
                        else Client.SetData<dynamic>("inEffect_heroin", Client.GetData<dynamic>("inEffect_heroin") + 40);

                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "Nabrizgani ste");
                         NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    Client.StopAnimation();
                                }

                            }, delayTime: 5000);
                        //Client.TriggerEvent("update_armor", Client.Armor);
                        break;
                    }
                    case 68:
                    {
                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "[ANTI-SPAM] Sacekajte malo!");
                            break;
                        }
                        
                        
                        

                       if (!Client.IsInVehicle)
                        {
                            RemoveItemFromInventory(Client, index, 1);
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_beer_blr"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_intdrink", "loop_bottle");
                            Client.SetData<dynamic>("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    Client.TriggerEvent("screen_drunk");
                                    BasicSync.DetachObject(Client);
                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_intdrink", "outro_bottle");
                                    Client.SetData<dynamic>("EatColDown", false);

                                }

                            }, delayTime: 5000);
                        }
                        
                        break;
                    }
                    case 69:
                    {
                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "[ANTI-SPAM] Sacekajte malo!");
                            break;
                        }
                        
                        
                        

                       if (!Client.IsInVehicle)
                        {
                            RemoveItemFromInventory(Client, index, 1);
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_drink_whisky"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_intdrink", "loop_bottle");
                            Client.SetData<dynamic>("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    Client.TriggerEvent("screen_drunk");
                                    BasicSync.DetachObject(Client);
                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_intdrink", "outro_bottle");
                                    Client.SetData<dynamic>("EatColDown", false);

                                }

                            }, delayTime: 5000);
                        }


                        
                        break;
                    }
                    case 70:
                    {
                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "[ANTI-SPAM] Sacekajte malo!");
                            break;
                        }
                        
                        
                        

                       if (!Client.IsInVehicle)
                        {
                            RemoveItemFromInventory(Client, index, 1);
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_drink_whisky"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_intdrink", "loop_bottle");
                            Client.SetData<dynamic>("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    Client.TriggerEvent("screen_drunk");
                                    BasicSync.DetachObject(Client);
                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_intdrink", "outro_bottle");
                                    Client.SetData<dynamic>("EatColDown", false);

                                }

                            }, delayTime: 5000);
                        }

                        
                        break;
                    }
                    case 71:
                    {
                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "[ANTI-SPAM] Sacekajte malo!");
                            break;
                        }
                        
                        
                        

                       if (!Client.IsInVehicle)
                        {
                            RemoveItemFromInventory(Client, index, 1);
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("p_whiskey_notop"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_intdrink", "loop_bottle");
                            Client.SetData<dynamic>("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    Client.TriggerEvent("screen_drunk");
                                    BasicSync.DetachObject(Client);
                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_intdrink", "outro_bottle");
                                    Client.SetData<dynamic>("EatColDown", false);

                                }

                            }, delayTime: 5000);
                        }

                        
                        break;
                    }
                    case 72:
                    {
                        if (Client.HasData("EatColDown") && Client.GetData<dynamic>("EatColDown"))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "[ANTI-SPAM] Sacekajte malo!");
                            break;
                        }
                        
                        
                        

                       if (!Client.IsInVehicle)
                        {
                            RemoveItemFromInventory(Client, index, 1);
                            BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_drink_champ"), 60309, new Vector3(0.0, 0.0, 0.0), new Vector3(0, 0, 0));
                            NAPI.Player.PlayPlayerAnimation(Client, 49, "mp_player_intdrink", "loop_bottle");
                            Client.SetData<dynamic>("EatColDown", true);
                            NAPI.Task.Run(() =>
                            {
                                if (Client.Exists)
                                {
                                    Client.TriggerEvent("screen_drunk");
                                    BasicSync.DetachObject(Client);
                                    NAPI.Player.PlayPlayerAnimation(Client, 120, "mp_player_intdrink", "outro_bottle");
                                    Client.SetData<dynamic>("EatColDown", false);

                                }

                            }, delayTime: 5000);
                        }

                        break;
                    }
            }

            if (ShowVehicleInventory == 2)
            {
                VehicleInventory.ShowToPlayerVehicleInventory(Client);
            }
            else if (ShowVehicleInventory == 1)
            {
                Inventory.ShowPlayerInventory(Client);
            }
            else if (ShowVehicleInventory == 3)
            {
                HouseSystem.ShowHouseInventory(Client);
            }
            else if (ShowVehicleInventory == 4)
            {
                WerehouseManage.ShowHQInventory(Client);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }
        if (ShowVehicleInventory == 2)
        {
            VehicleInventory.ShowToPlayerVehicleInventory(Client);
        }
        else if (ShowVehicleInventory == 1)
        {
            Inventory.ShowPlayerInventory(Client);
        }
        else if (ShowVehicleInventory == 3)
        {
            HouseSystem.ShowHouseInventory(Client);
        }
        else if (ShowVehicleInventory == 4)
        {
            WerehouseManage.ShowHQInventory(Client);
        }

    }

    

    public static bool DoesHaveFreeSlot(Player client)
    {
        for (int i = 0; i < MAX_INVENTORY_ITENS; i++)
        {
            if (player_inventory[client.Value].amount[i] == 0 && player_inventory[client.Value].sql_id[i] == -1)
            {
                return true;
            }
        }
        return false;
    }

    public static void PlayerPressKeyE(Player Client)
    {

            int index = 0;
            foreach (var inventory in inventory_objects)
            {
                if (Main.IsInRangeOfPoint(Client.Position, new Vector3(inventory.item_pos_x, inventory.item_pos_y, inventory.item_pos_z), 1) && Client.Dimension == inventory.dimension)
                {

                    if (Client.HasData("Y_Timeout") && Client.GetData<dynamic>("Y_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
                    {
                        Main.DisplaySubtitle(Client, "~y~[ANTI-SPAM]", 2);
                        return;
                    }
                    Client.SetData<dynamic>("Y_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 500);
                    if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, inventory.item_type, inventory.item_amount, Inventory.Max_Inventory_Weight(Client)))
                    {
                        return;
                    }
                    if (!DoesHaveFreeSlot(Client))
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno mesta!");
                        return;
                    }

                    Main.PlaySoundFrontend(Client, "PICK_UP", "HUD_FRONTEND_DEFAULT_SOUNDSET");

                    GiveItemToInventory(Client, inventory.item_type, inventory.item_amount);

                    if (inventory.item_amount == 1)
                    {
                        //NAPI.Notification.SendNotificationToPlayer(Client, "Voce pegou um ~y~" + item_list[inventory.item_type].name + "~w~.");
                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "Uzeli ste ~y~" + itens_available[inventory.item_type].name + "~w~.");
                    }
                    else
                    {
                        //NAPI.Notification.SendNotificationToPlayer(Client, "Voce pegou "+ inventory.item_amount + " unidades de ~y~" + item_list[inventory.item_type].name + "~w~.");
                        Client.TriggerEvent("createNewHeadNotificationAdvanced", "Uzeli ste " + inventory.item_amount + " ~y~" + itens_available[inventory.item_type].name + "~w~.");
                    }

                    BackPack_OverLoad(Client);

                    NAPI.Task.Run(() =>
                    {
                        NAPI.Entity.DeleteEntity(inventory.item_object_handle);
                        NAPI.Entity.DeleteEntity(inventory.item_label_handle);
                    });
                    inventory_objects.RemoveAt(index);

                    return; ;
                }
                index++;
            }

    }

    public static float Max_Inventory_Weight(Player Client)
    {
        float carry = 15.0f;
        return carry;
    }

    public static float GetInventoryHeight(Player Client)
    {
        int playerid = Main.getIdFromClient(Client);
        float height = 0.00f;

        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (player_inventory[playerid].sql_id[index] != -1 && player_inventory[playerid].amount[index] > 0)
            {
                height += player_inventory[playerid].amount[index] * itens_available[player_inventory[playerid].type[index]].weight;

            }
        }
        return height;

    }

    public static bool Check_InventoryWeight_With_ItemAmount(Player Client, int type, int amount, float MAX_HEIGHT)
    {
        int playerid = Main.getIdFromClient(Client);
        float height = 0.00f;

        if (!DoesHaveFreeSlot(Client))
        {
            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno slotova.");
            return true;
        }
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (player_inventory[playerid].sql_id[index] != -1 && player_inventory[playerid].amount[index] > 0)
            {
                height += player_inventory[playerid].amount[index] * itens_available[player_inventory[playerid].type[index]].weight;

            }
        }

        if (type < itens_available.Count && type != -1)
        {

            float free_space = MAX_HEIGHT - height;

            height += amount * itens_available[type].weight;

            if (height > MAX_HEIGHT)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate mesta u torbi");
                //  Main.SendErrorMessage(Client, "Shoma Hajm Kafi Baraye Haml in Item Nadarid " + Main.EMBED_LIGHTRED + "" + (amount * itens_available[type].weight).ToString("#.##").Replace(",", ".") + "kg" + Main.EMBED_WHITE + ", Shoma Fghat Mitavanid " + Main.EMBED_LIGHTGREEN + "" + free_space.ToString("#.##").Replace(",", ".") + "kg" + Main.EMBED_WHITE + "Digar Haml Konid");
                return true;
            }
            return false;
        }
        else
        {
            return true;
        }

    }

    public static int GetInventoryIndexFromSQLID(Player Client, int sqlid)
    {
        int playerid = Main.getIdFromClient(Client);
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (player_inventory[playerid].sql_id[index] == sqlid)
            {
                return index;
            }
        }
        return -1;


    }
    public static int GetInventoryIndexFromType(Player Client, int type)
    {
        int playerid = Main.getIdFromClient(Client);
        int slot = -1;
        for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
        {
            if (player_inventory[playerid].type[index] == type)
            {
                slot = index;
            }
        }
        return slot;


    }

    public static int GetPlayerItemFromInventory(Player Client, int type)
    {
        int playerid = Main.getIdFromClient(Client);
        int amount = 0;
        try
        {
            for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
            {
                if (player_inventory[playerid].type[index] == type)
                {
                    amount = player_inventory[playerid].amount[index];
                }
            }
        }
        catch
        {

        }
        return amount;
    }

    public static int GetInventoryIndexFromName(Player Client, string name)
    {

        int index = 0, slot = -1;
        foreach (var item in itens_available)
        {
            if (item.name == name)
            {
                slot = GetInventoryIndexFromType(Client, index);
            }
            index++;
        }
        return slot;
    }

    public static void RemoveItem(Player Client, string itemName, int amount)
    {
        int index = 0;
        foreach (var item in itens_available)
        {
            if (item.name == itemName)
            {
                RemoveItemFromInventory(Client, GetInventoryIndexFromType(Client, index), amount);
                return;
            }
            index++;
        }
    }

    public static void RemoveItemByType(Player Client, int type, int amount)
    {
        int index = 0;
        foreach (var item in itens_available)
        {
            if (item.id == type)
            {
                RemoveItemFromInventory(Client, GetInventoryIndexFromType(Client, index), amount);
                return;
            }
            index++;
        }
    }


    [RemoteEvent("JogarItem")]
    public void UI_JogarItem(Player Client, int sqlid, int type, int value, int openwhichinventory)
    {

        int playerid = Main.getIdFromClient(Client);
        int index = GetInventoryIndexFromSQLID(Client, sqlid);

        if (index == -1)
        {
            return;
        }
        if (player_inventory[playerid].sql_id[index] == -1)
        {
            Main.SendErrorMessage(Client, "Greska. (" + player_inventory[playerid].sql_id[index] + " - " + index + " - " + player_inventory[playerid].type[index] + ")");
            return;
        }

        if (player_inventory[playerid].amount[index] < 1 || player_inventory[playerid].inuse[index] == 1 || player_inventory[playerid].dropable[index] == 0)
        {
            //Client()
            return;
        }
        Client.SetData<dynamic>("inventory_item_selected", itens_available[type].name);

        //Client.TriggerEvent("Destroy_Character_Menu");
        if (player_inventory[playerid].amount[index] == 1)
        {
            DropItemFromInventory(Client, index, itens_available[type].name, 1, openwhichinventory);

            if (GetPlayerItemFromInventory(Client, 23) <= 0)
            {
                foreach (Player pl in NAPI.Pools.GetAllPlayers())
                {
                    if (pl.GetData<dynamic>("status") == true)
                    {
                        if (pl.GetSharedData<dynamic>("RadioFreq") == Client.GetSharedData<dynamic>("RadioFreq") && pl != Client)
                        {
                            Client.TriggerEvent("v_disconnect", pl);
                            pl.TriggerEvent("v_disconnect", Client);
                        }
                    }
                }
                Client.SetSharedData("Radio_Status", false);
                Client.SetSharedData("RadioFreq", 0);
            }
            List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
            foreach (Player alvo in proxPlayers)
            {
                alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " je bacio 1x " + itens_available[type].name + " na pod.");
            }
            return;
        }
        else
        {

            if (value == 0)
            {
                Client.SendNotification("Greska!~n~Vrednost ne moze biti manja od 1.");
                return;
            }

            if (value < 1)
            {
                Client.SendNotification("Greska!~n~Vrednost ne moze biti manja od 1.");
                return;
            }


            if (player_inventory[playerid].amount[index] < value)
            {
                Client.SendNotification("Greska!~n~Ne mozete to!");
                return;
            }
            DropItemFromInventory(Client, index, itens_available[type].name, value, openwhichinventory);
            if (GetPlayerItemFromInventory(Client, 23) <= 0)
            {
                foreach (Player pl in NAPI.Pools.GetAllPlayers())
                {
                    if (pl.GetData<dynamic>("status") == true)
                    {
                        if (pl.GetSharedData<dynamic>("RadioFreq") == Client.GetSharedData<dynamic>("RadioFreq") && pl != Client)
                        {
                            Client.TriggerEvent("v_disconnect", pl);
                            pl.TriggerEvent("v_disconnect", Client);
                        }
                    }
                }
                Client.SetSharedData("Radio_Status", false);
                Client.SetSharedData("RadioFreq", 0);
            }
            return;
        }
    }

    [RemoteEvent("Main_InventoryStack")]
    public void Main_InventoryStack(Player Client, int sqlold, int sqlnew)
    {
        int playerid = Main.getIdFromClient(Client);

            int oldindex = GetInventoryIndexFromSQLID(Client, sqlold);
            int newindex = GetInventoryIndexFromSQLID(Client, sqlnew);
            if (oldindex == -1 || newindex == -1)
            {
                return;
            }

            if (player_inventory[playerid].type[oldindex] != player_inventory[playerid].type[newindex] || player_inventory[playerid].sql_id[oldindex] == player_inventory[playerid].sql_id[newindex])
            {
                ShowPlayerInventory(Client);
                return;
            }
            if (AccountManage.GetPlayerConnected(Client))
            {
                if (player_inventory[playerid].sql_id[oldindex] == -1 || player_inventory[playerid].inuse[oldindex] == 1 || player_inventory[playerid].dropable[oldindex] == 0)
                {
                    ShowPlayerInventory(Client);
                    Main.SendErrorMessage(Client, "Greska. (" + player_inventory[playerid].sql_id[oldindex] + " - " + oldindex + " - " + player_inventory[playerid].type[oldindex] + ")");
                    return;
                }
                if (player_inventory[playerid].sql_id[newindex] == -1 || player_inventory[playerid].inuse[newindex] == 1 || player_inventory[playerid].dropable[newindex] == 0)
                {
                    ShowPlayerInventory(Client);
                    Main.SendErrorMessage(Client, "Greska. (" + player_inventory[playerid].sql_id[newindex] + " - " + newindex + " - " + player_inventory[playerid].type[newindex] + ")");
                    return;
                }

                if (player_inventory[playerid].amount[oldindex] >= 1 && player_inventory[playerid].amount[newindex] >= 1)
                {
                    player_inventory[playerid].amount[newindex] += player_inventory[playerid].amount[oldindex];
                    player_inventory[playerid].slotid[newindex] = player_inventory[playerid].slotid[oldindex];
                    player_inventory[playerid].amount[oldindex] = 0;

                    Main.CreateMySqlCommand("UPDATE `inventory` SET `slotid` = " + player_inventory[playerid].slotid[newindex] + " WHERE `id` = " + sqlnew + "");
                    Main.CreateMySqlCommand("UPDATE inventory SET `amount` = " + player_inventory[playerid].amount[newindex] + " WHERE `id` = " + sqlnew + "");
                    Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `id` = '" + player_inventory[playerid].sql_id[oldindex] + "';");

                    player_inventory[playerid].sql_id[oldindex] = -1;
                    player_inventory[playerid].type[oldindex] = 0;
                    player_inventory[playerid].amount[oldindex] = 0;
                    player_inventory[playerid].inuse[oldindex] = 0;
                    player_inventory[playerid].dropable[oldindex] = 1;
                    player_inventory[playerid].slotid[oldindex] = -1;
                    ShowPlayerInventory(Client);

                }

            }

    }

    [RemoteEvent("InventoryStack")]
    public void InventoryStack(Player Client, int sqlold, int sqlnew)
    {
        int playerid = Main.getIdFromClient(Client);

            int oldindex = GetInventoryIndexFromSQLID(Client, sqlold);
            int newindex = GetInventoryIndexFromSQLID(Client, sqlnew);
            if (oldindex == -1 || newindex == -1)
            {
                return;
            }
            if (player_inventory[playerid].type[oldindex] != player_inventory[playerid].type[newindex] || player_inventory[playerid].sql_id[oldindex] == player_inventory[playerid].sql_id[newindex])
            {
                VehicleInventory.ShowToPlayerVehicleInventory(Client);
                return;
            }
            if (AccountManage.GetPlayerConnected(Client))
            {
                if (player_inventory[playerid].sql_id[oldindex] == -1 || player_inventory[playerid].inuse[oldindex] == 1 || player_inventory[playerid].dropable[oldindex] == 0)
                {
                    VehicleInventory.ShowToPlayerVehicleInventory(Client);
                    Main.SendErrorMessage(Client, "Greska. (" + player_inventory[playerid].sql_id[oldindex] + " - " + oldindex + " - " + player_inventory[playerid].type[oldindex] + ")");
                    return;
                }
                if (player_inventory[playerid].sql_id[newindex] == -1 || player_inventory[playerid].inuse[newindex] == 1 || player_inventory[playerid].dropable[newindex] == 0)
                {
                    VehicleInventory.ShowToPlayerVehicleInventory(Client);
                    Main.SendErrorMessage(Client, "Greska. (" + player_inventory[playerid].sql_id[newindex] + " - " + newindex + " - " + player_inventory[playerid].type[newindex] + ")");
                    return;
                }

                if (player_inventory[playerid].amount[oldindex] >= 1 && player_inventory[playerid].amount[newindex] >= 1)
                {
                    player_inventory[playerid].amount[newindex] += player_inventory[playerid].amount[oldindex];
                    player_inventory[playerid].slotid[newindex] = player_inventory[playerid].slotid[oldindex];

                    player_inventory[playerid].amount[oldindex] = 0;

                    Main.CreateMySqlCommand("UPDATE `inventory` SET `slotid` = " + player_inventory[playerid].slotid[newindex] + " WHERE `id` = " + sqlnew + "");
                    Main.CreateMySqlCommand("UPDATE inventory SET `amount` = " + player_inventory[playerid].amount[newindex] + " WHERE `id` = " + sqlnew + "");
                    Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `id` = '" + sqlold + "';");

                    player_inventory[playerid].sql_id[oldindex] = -1;
                    player_inventory[playerid].type[oldindex] = 0;
                    player_inventory[playerid].amount[oldindex] = 0;
                    player_inventory[playerid].inuse[oldindex] = 0;
                    player_inventory[playerid].dropable[oldindex] = 1;
                    player_inventory[playerid].slotid[oldindex] = -1;
                    VehicleInventory.ShowToPlayerVehicleInventory(Client);

                }

            }
    }

    [RemoteEvent("drop_gun")]
    public void Drop_Gun(Player client, int sqlid)
    {
        if (AccountManage.GetPlayerConnected(client))
        {
            int index = GetInventoryIndexFromSQLID(client, sqlid);
            int playerid = Main.getIdFromClient(client);
            if (index == -1)
            {
                return;
            }
            if (player_inventory[playerid].amount[index] > 0 && player_inventory[playerid].inuse[index] == 1)
            {
                player_inventory[playerid].inuse[index] = 0;
                ShowPlayerInventory(client);
                Main.CreateMySqlCommand("UPDATE `inventory` SET `inuse`='0' WHERE `id`=" + player_inventory[playerid].sql_id[index] + "");
            }
        }
    }



    [RemoteEvent("Split_Main")]
    public void SplitItem_Main(Player client, int sqlid)
    {
        SplitItemGlobal(client, sqlid);
        ShowPlayerInventory(client);
    }

    public static void SplitItemGlobal(Player client, int sqlid)
    {
        if (AccountManage.GetPlayerConnected(client))
        {
            int index = GetInventoryIndexFromSQLID(client, sqlid);
            int playerid = Main.getIdFromClient(client);
            if (index == -1)
            {
                return;
            }

            if (!DoesHaveFreeSlot(client))
            {
                Main.DisplayErrorMessage(client, NotifyType.Warning, NotifyPosition.BottomCenter, "Ne mozete to!");
                return;
            }
            if (player_inventory[playerid].amount[index] >= 2 && player_inventory[playerid].dropable[index] == 1 && player_inventory[playerid].inuse[index] == 0)
            {
                if ((player_inventory[playerid].amount[index] % 2) == 0)
                {
                    GiveItemToInventory(client, player_inventory[playerid].type[index], (player_inventory[playerid].amount[index] / 2));
                    player_inventory[playerid].amount[index] = player_inventory[playerid].amount[index] / 2;
                    Main.CreateMySqlCommand("UPDATE `inventory` SET `amount`=" + player_inventory[playerid].amount[index] + " WHERE `id`=" + player_inventory[playerid].sql_id[index] + "");

                }
                else
                {
                    decimal ammount = decimal.Parse(player_inventory[playerid].amount[index].ToString()) / 2m;
                    GiveItemToInventory(client, player_inventory[playerid].type[index], (int)Math.Ceiling(ammount));
                    player_inventory[playerid].amount[index] = (int)Math.Floor(ammount);

                    Main.CreateMySqlCommand("UPDATE `inventory` SET `amount`=" + (int)Math.Floor(ammount) + " WHERE `id`=" + player_inventory[playerid].sql_id[index] + "");
                }

            }

        }
    }

    [RemoteEvent("Storage_Give_Item")]
    public static void UI_GiveItem(Player Client, int slot, int type, int amount, int sqlid)
    {
        int playerid = Main.getIdFromClient(Client);
        int index = GetInventoryIndexFromSQLID(Client, sqlid);

        if (index == -1)
        {
            return;
        }
        if (player_inventory[playerid].sql_id[index] == -1 || player_inventory[playerid].inuse[index] == 1 || player_inventory[playerid].dropable[index] == 0)
        {
            VehicleInventory.ShowToPlayerVehicleInventory(Client);
            Main.SendErrorMessage(Client, "Greska. (" + player_inventory[playerid].sql_id[index] + " - " + index + " - " + player_inventory[playerid].type[index] + ")");
            return;
        }

        Vehicle vehicle = Client.GetData<dynamic>("vehicle_handle_inv");

        if (vehicle.Exists && Main.IsInRangeOfPoint(Client.Position, vehicle.Position, 5.0f))
        {
            if (player_inventory[playerid].amount[index] > 1)
            {

                if (player_inventory[playerid].sql_id[index] == -1)
                {
                    VehicleInventory.ShowToPlayerVehicleInventory(Client);
                    return;
                }

                if (vehicle.Exists && Main.IsInRangeOfPoint(Client.Position, vehicle.Position, 5.0f))
                {
                    if (player_inventory[playerid].amount[index] < 1)
                    {
                        VehicleInventory.ShowToPlayerVehicleInventory(Client);
                        return;
                    }

                    if (player_inventory[playerid].amount[index] < amount)
                    {
                        VehicleInventory.ShowToPlayerVehicleInventory(Client);
                        Main.SendErrorMessage(Client, "Nemate toliko!");
                        return;
                    }
                    float height = 0.0f;
                    for (int i = 0; i < 30; i++)
                    {
                        if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0 && NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
                        {
                            height += NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") * itens_available[NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type")].weight;
                        }
                    }

                    height += amount * itens_available[type].weight;


                    if (height > vehicle.GetData<dynamic>("MAX_VEHICLE_SLOT"))
                    {
                        VehicleInventory.ShowToPlayerVehicleInventory(Client);
                        InteractMenu_New.SendNotificationError(Client, "Nema vie mesta u gepeku.");
                        return;
                    }

                    Client.SetData<dynamic>("vehicle_handle_inv", vehicle);
                    RemoveItemFromInventory(Client, index, amount);
                    VehicleInventory.AddItemToVehicleInventory(vehicle, slot, type, amount);

                    VehicleInventory.ShowToPlayerVehicleInventory(Client);

                    List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
                    foreach (Player alvo in proxPlayers)
                    {
                        alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " stavlja " + itens_available[type].name + " u gepek.");
                    }
                }

            }
            else if (player_inventory[playerid].amount[index] == 1)
            {
                float height = 0.0f;
                for (int i = 0; i < 30; i++)
                {
                    if (NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type") != 0 && NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") > 0)
                    {
                        height += NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_amount") * itens_available[NAPI.Data.GetEntityData(vehicle, "trunk_item_" + i + "_type")].weight;
                    }
                }

                height += 1 * itens_available[type].weight;

                if (height > vehicle.GetData<dynamic>("MAX_VEHICLE_SLOT"))
                {
                    VehicleInventory.ShowToPlayerVehicleInventory(Client);
                    InteractMenu_New.SendNotificationError(Client, "U vozilu vise nema mesta.");
                    return;
                }


                Client.SetData<dynamic>("vehicle_handle_inv", vehicle);
                RemoveItemFromInventory(Client, index, 1);
                VehicleInventory.AddItemToVehicleInventory(vehicle, slot, type, 1);

                VehicleInventory.ShowToPlayerVehicleInventory(Client);

                List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
                foreach (Player alvo in proxPlayers)
                {
                    alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " stavlja " + itens_available[type].name + " u vozilo.");
                }

            }
        }
    }



    [RemoteEvent("Storage_Take_Item")]
    public static void UI_TakeItem(Player Client, int slot, int type, int amount, int index)
    {

        Vehicle vehicle = Client.GetData<dynamic>("vehicle_handle_inv");

        // int playerid = Main.getIdFromClient(Client);

        if (vehicle != null && vehicle.Exists && Main.IsInRangeOfPoint(Client.Position, vehicle.Position, 5.0f))
        {
            if (vehicle.GetData<dynamic>("trunk_item_" + index + "_amount") > 1)
            {

                if (vehicle.Exists && Main.IsInRangeOfPoint(Client.Position, vehicle.Position, 5.0f))
                {
                    if (vehicle.GetData<dynamic>("trunk_item_" + index + "_amount") < 1)
                    {
                        VehicleInventory.ShowToPlayerVehicleInventory(Client);
                        return;
                    }

                    if (vehicle.GetData<dynamic>("trunk_item_" + index + "_amount") < amount)
                    {
                        VehicleInventory.ShowToPlayerVehicleInventory(Client);
                        Main.SendErrorMessage(Client, "Nema toliko!");
                        return;
                    }

                    if (Check_InventoryWeight_With_ItemAmount(Client, type, amount, Max_Inventory_Weight(Client)))
                    {
                        VehicleInventory.ShowToPlayerVehicleInventory(Client);
                        return;
                    }

                    Client.SetData<dynamic>("vehicle_handle_inv", vehicle);
                    GiveItemToInventory(Client, type, amount, slotid: slot);
                    VehicleInventory.RemoveItemFromVehicleInventory(vehicle, index, amount);

                    VehicleInventory.ShowToPlayerVehicleInventory(Client);

                    List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
                    foreach (Player alvo in proxPlayers)
                    {
                        alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " uzima " + itens_available[type].name + " iz gepeka.");
                    }
                }

            }
            else if (vehicle.GetData<dynamic>("trunk_item_" + index + "_amount") == 1)
            {
                if (Check_InventoryWeight_With_ItemAmount(Client, type, 1, Max_Inventory_Weight(Client)))
                {
                    VehicleInventory.ShowToPlayerVehicleInventory(Client);
                    return;
                }


                Client.SetData<dynamic>("vehicle_handle_inv", vehicle);
                GiveItemToInventory(Client, type, 1, slotid: slot);
                VehicleInventory.RemoveItemFromVehicleInventory(vehicle, index, 1);

                VehicleInventory.ShowToPlayerVehicleInventory(Client);

                List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
                foreach (Player alvo in proxPlayers)
                {
                    alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " uzima " + itens_available[type].name + " iz gepeka.");
                }
            }


        }
    }

    [Command("inventory", Alias = "inv")]
    public static void ShowPlayerInventory(Player Client)
    {
        if (Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetSharedData<dynamic>("Injured") >= 1)
        {
            Main.SendErrorMessage(Client, "Ne mozete koristiti inventory dok ste povredjeni.");
            return;
        }
        int playerid = Main.getIdFromClient(Client);

            List<dynamic> item_list = new List<dynamic>();
            // List inventory_data = new List<dynamic>();
            float weight = 0f;
            for (int index = 0; index < MAX_INVENTORY_ITENS; index++)
            {
                if (player_inventory[playerid].sql_id[index] != -1)
                {

                    int type = player_inventory[playerid].type[index];

                    if (type > itens_available.Count)
                    {
                        continue;
                    }

                    item_list.Add(new { sqlid = player_inventory[playerid].sql_id[index], slotid = player_inventory[playerid].slotid[index], picture = "./img/" + itens_available[type].picture + ".png", name = itens_available[type].name, type = type, amount = player_inventory[playerid].amount[index], weight = itens_available[type].weight, Useable = itens_available[type].Useable, inuse = player_inventory[playerid].inuse[index], dropable = player_inventory[playerid].dropable[index] });

                    weight += player_inventory[playerid].amount[index] * itens_available[type].weight;
                }
            }
           
            //inventory_data.Add(new { Money = Main.GetPlayerMoney(Client), InventoryId = 1, ActualWeight = weight , MaxWeight  = GetInventoryMaxHeight(Client), Name  = "Meu Inventario", Items = NAPI.Util.ToJson(item_list) });
            Client.TriggerEvent("Display_Player_Inventory", NAPI.Util.ToJson(item_list), GetInventoryMaxHeight(Client), weight);

    }

    public static float GetInventoryMaxHeight(Player Client)
    {
        float carry = 15.0f;
        if (Client.GetData<dynamic>("character_backpack") == 1)
        {
            carry = 20.0f;
        }
        else if (Client.GetData<dynamic>("character_backpack") == 2)
        {
            carry = 30.0f;
        }
        else if (Client.GetData<dynamic>("character_backpack") == 3)
        {
            carry = 60.0f;
        }
        else
        {
            carry = 15.0f;
        }
        return carry;
    }




    [RemoteEvent("LockPickResult")]
    public void LockPickResult(Player Client, int result)
    {
        if (Client.HasData("VehicleTarget"))
        {
            Vehicle veh = Client.GetData<dynamic>("VehicleTarget");
            if (veh != null && veh.Exists)
            {
                if (result == 0)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Alert, NotifyPosition.BottomCenter, "Niste uspeli da obijete vozilo!");
                    Client.SetData<dynamic>("VehicleTarget", null);
                    Client.SetData<dynamic>("IsBobypining", false);
                    Client.TriggerEvent("FreezeEx", false);

                    Client.StopAnimation();
                }
                else if (result == 1)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uspeli ste da obijete vozilo!");
                    VehicleStreaming.SetLockStatus(veh, false);

                    Client.SetData<dynamic>("VehicleTarget", null);
                    Client.SetData<dynamic>("IsBobypining", false);
                    Client.TriggerEvent("FreezeEx", false);
                    Client.StopAnimation();

                }
            }

        }

    }


    public static void BackPack_OverLoad(Player Client)
    {
        if (Client.HasData("character_backpack") && Client.GetData<dynamic>("character_backpack") == 2)
        {
            if (GetInventoryMaxHeight(Client) / GetInventoryHeight(Client) < 1.7 && Client.GetData<dynamic>("character_backpack") == 2 && !Client.HasData("BackPack3_OverLoad") || Client.GetData<dynamic>("BackPack3_OverLoad") == false)
            {
                Client.SetClothes(5, 82, 0);
                Client.SetData<dynamic>("BackPack3_OverLoad", true);
            }
            else if (GetInventoryMaxHeight(Client) / GetInventoryHeight(Client) >= 1.7 && Client.GetData<dynamic>("character_backpack") == 2 && Client.HasData("BackPack3_OverLoad") && Client.GetData<dynamic>("BackPack3_OverLoad") == true)
            {
                Client.SetClothes(5, 81, 0);
                Client.SetData<dynamic>("BackPack3_OverLoad", false);
            }
        }

    }

    [RemoteEvent("InventoryService:ToggleClothing")]
    public static void ToggleClothing(Player Client, int type)
    {
        switch (type)
        {
            case 13:
                {
                    var hats = NAPI.Data.GetEntitySharedData(Client, "character_hats");
                    var hats_texture = NAPI.Data.GetEntitySharedData(Client, "character_hats_texture");

                    if (Client.GetData<dynamic>("hats_enable") == true) // false
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Skinuli ste kapu.");
                        
                        Client.SetAccessories(0, -1, 0);
                        Client.ClearAccessory(0);
                        Client.SetData<dynamic>("hats_enable", false);

                    }
                    else
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Stavili ste kapu.");
                        
                        Client.SetAccessories(0, (int)hats, (int)hats_texture);
                        Client.SetData<dynamic>("hats_enable", true);
                    }
                    break;
                }
            case 15:
                {
                    var armor = NAPI.Data.GetEntitySharedData(Client, "character_armor");
                    var armor_texture = NAPI.Data.GetEntitySharedData(Client, "character_armor_texture");

                    if (Client.GetData<dynamic>("armor_enable") == true) // false
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Skinuli ste pancir.");
                        
                        Client.SetClothes(9, 0, 0);
                        Client.SetData<dynamic>("armor_enable", false);

                    }
                    else
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Stavili ste pancir.");
                        
                        Client.SetClothes(9, (int)armor, (int)armor_texture);
                        Client.SetData<dynamic>("armor_enable", true);
                    }

                    break;
                }
            case 14:
                {
                    var glasses = NAPI.Data.GetEntitySharedData(Client, "character_glasses");
                    var glasses_texture = NAPI.Data.GetEntitySharedData(Client, "character_glasses_texture");

                    if (Client.GetData<dynamic>("glasses_enable") == true)
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Skinuli ste naocare.");
                        
                        Client.SetAccessories(1, 0, 0);
                        Client.ClearAccessory(1);
                        Client.SetData<dynamic>("glasses_enable", false);
                    }
                    else
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Stavili ste naocare.");
                        
                        Client.SetAccessories(1, (int)glasses, (int)glasses_texture);
                        Client.SetData<dynamic>("glasses_enable", true);
                    }
                    break;
                }
            case 0:
                {
                    UsefullyRP.CMD_Mascara(Client);
                    break;
                }
            case 9:
                {
                    UsefullyRP.CMD_TOP_off(Client);
                    break;
                }
            case 5:
                {
                    UsefullyRP.CMD_Acc_off(Client);
                    break;
                }
            case 2:
                {   
                    UsefullyRP.CMD_Pants_off(Client);
                    break;
                }
            case 4:
                {
                    UsefullyRP.CMD_shoes_off(Client);
                    break;
                }


        }
    }

    public static void ShowTargetSearchMenu(Player Client, Player target)
    {
        if (target.GetData<dynamic>("playerCuffed") == 1 || target.GetData<dynamic>("handsup") == true || target.GetSharedData<dynamic>("Injured") == 1)
        {
            List<dynamic> menu_item_list = new List<dynamic>();

            int targetid = Main.getIdFromClient(target);
            int playerid = Client.Value;
            if (target.Position.DistanceTo(Client.Position) > 3f)
            {
                return;
            }
            System.Threading.Tasks.Task.Run(() =>
            {

                List<dynamic> temp_inventory = new List<dynamic>();
                for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
                {
                    if (Inventory.player_inventory[playerid].sql_id[index] != -1)
                    {

                        int type = Inventory.player_inventory[playerid].type[index];

                        if (type > Inventory.itens_available.Count)
                        {
                            continue;
                        }
                        temp_inventory.Add(new { slotid = Inventory.player_inventory[playerid].slotid[index], sqlid = Inventory.player_inventory[playerid].sql_id[index], name = Inventory.itens_available[type].name, type = type, amount = Inventory.player_inventory[playerid].amount[index], weight = Inventory.itens_available[type].weight, Useable = Inventory.itens_available[type].Useable, inuse = Inventory.player_inventory[playerid].inuse[index], dropable = Inventory.player_inventory[playerid].dropable[index], picture = "./img/" + Inventory.itens_available[type].picture + ".png" });
                    }
                }

                List<dynamic> temp_inventory_second = new List<dynamic>();
                for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
                {
                    if (Inventory.player_inventory[targetid].sql_id[index] != -1)
                    {

                        int type = Inventory.player_inventory[targetid].type[index];

                        if (type > Inventory.itens_available.Count)
                        {
                            continue;
                        }
                        temp_inventory_second.Add(new { slotid = Inventory.player_inventory[targetid].slotid[index], sqlid = Inventory.player_inventory[targetid].sql_id[index], name = Inventory.itens_available[type].name, type = type, amount = Inventory.player_inventory[targetid].amount[index], weight = Inventory.itens_available[type].weight, Useable = Inventory.itens_available[type].Useable, inuse = Inventory.player_inventory[targetid].inuse[index], dropable = Inventory.player_inventory[targetid].dropable[index], picture = "./img/" + Inventory.itens_available[type].picture + ".png" });
                    }
                }

                NAPI.Task.Run(() =>
                {
                    
                    Client.TriggerEvent("Display_Search_inventory", NAPI.Util.ToJson(temp_inventory), NAPI.Util.ToJson(temp_inventory_second), Inventory.GetInventoryMaxHeight(Client), Inventory.GetInventoryMaxHeight(target));
                    Client.SetData<Player>("Searching_Player", target);
                });

            });


        }
        else
        {
            InteractMenu_New.SendNotificationError(Client, "Osoba ne drzi ruke u vis, nije u lisicama ili nije povredjena.");
        }
    }


    ///search inventory Stuff
    ///
    [RemoteEvent("Search_Give_Item")]
    public static void Search_GiveItem(Player Client, int slot, int type, int amount, int sqlid)
    {
        Player target = Client.GetData<Player>("Searching_Player");

        int playerid = Main.getIdFromClient(Client);
        int targetid = Main.getIdFromClient(target);
        int index = Inventory.GetInventoryIndexFromSQLID(Client, sqlid);


        if (target == null || !target.Exists)
        {
            return;
        }
        if (index == -1)
        {
            return;
        }
        if (Inventory.player_inventory[playerid].sql_id[index] == -1 || Inventory.player_inventory[playerid].inuse[index] == 1 || Inventory.player_inventory[playerid].dropable[index] == 0)
        {
            Main.SendErrorMessage(Client, "Greska. (" + Inventory.player_inventory[playerid].sql_id[index] + " - " + index + " - " + Inventory.player_inventory[playerid].type[index] + ")");
            return;
        }
        if (target.Position.DistanceTo(Client.Position) > 3f)
        {
            return;
        }
        if (Inventory.player_inventory[playerid].amount[index] > 1)
        {

            if (Inventory.player_inventory[playerid].sql_id[index] == -1)
            {
                return;
            }

            if (Inventory.player_inventory[playerid].amount[index] < 1)
            {
                return;
            }

            if (Inventory.player_inventory[playerid].amount[index] < amount)
            {
                Main.SendErrorMessage(Client, "Nemate toliko!");
                return;
            }

            if (Check_InventoryWeight_With_ItemAmount(target, type, amount, Inventory.Max_Inventory_Weight(target)))
            {
                return;
            }

            Inventory.RemoveItemFromInventory(Client, index, amount);
            GiveItemToInventory(target, type, amount, slotid: slot);

            ShowTargetSearchMenu(Client, target);

            UsefullyRP.SendRoleplayAction(Client, amount + "x " + Inventory.itens_available[type].name + "uzima item iz torbe.");

            /*List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
            foreach (Player alvo in proxPlayers)
            {
                alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " placed " + amount + "x " + Inventory.itens_available[type].name + " in the house inventory.");

            }*/

        }
        else if (Inventory.player_inventory[playerid].amount[index] == 1)
        {
            /*if (VehicleInventory.Check_VehicleInventoryWeight_With_ItemAmount(Client, vehicle, type, 1, vehicle.GetData<dynamic>("MAX_VEHICLE_SLOTw")))
            {
                return;
            }*/

            Inventory.RemoveItemFromInventory(Client, index, 1);
            GiveItemToInventory(target, type, 1, slotid: slot);

            ShowTargetSearchMenu(Client, target);

            UsefullyRP.SendRoleplayAction(Client, "1x" + Inventory.itens_available[type].name + "Uzima item iz torbe.");


            return;
        }

    }

    [RemoteEvent("Search_Take_Item")]
    public static void Search_TakeItem(Player Client, int slot, int type, int amount, int sqlid)
    {
        Player target = Client.GetData<Player>("Searching_Player");

        int playerid = Main.getIdFromClient(Client);
        int targetid = Main.getIdFromClient(target);
        int index = Inventory.GetInventoryIndexFromSQLID(target, sqlid);


        if (target == null || !target.Exists)
        {
            return;
        }

        if (index == -1)
        {
            return;
        }
        if (target.Position.DistanceTo(Client.Position) > 3f)
        {
            return;
        }
        if (Inventory.player_inventory[targetid].amount[index] > 1)
        {

            if (Inventory.player_inventory[targetid].sql_id[index] == -1)
            {
                return;
            }

            if (Inventory.player_inventory[targetid].amount[index] < 1)
            {
                return;
            }

            if (Inventory.player_inventory[targetid].amount[index] < amount)
            {
                Main.SendErrorMessage(Client, "Ne mozete to!");
                return;
            }

            if (Check_InventoryWeight_With_ItemAmount(Client, type, amount, Inventory.Max_Inventory_Weight(Client)))
            {
                return;
            }

            Inventory.RemoveItemFromInventory(target, index, amount);
            GiveItemToInventory(Client, type, amount, slotid: slot);

            ShowTargetSearchMenu(Client, target);


            UsefullyRP.SendRoleplayAction(Client, "pretresa i oduzima " + Inventory.itens_available[type].name + " od osobe.");

            /*List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
            foreach (Player alvo in proxPlayers)
            {
                alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " placed " + amount + "x " + Inventory.itens_available[type].name + " in the house inventory.");

            }*/

        }
        else if (Inventory.player_inventory[targetid].amount[index] == 1)
        {
            /*if (VehicleInventory.Check_VehicleInventoryWeight_With_ItemAmount(Client, vehicle, type, 1, vehicle.GetData<dynamic>("MAX_VEHICLE_SLOTw")))
            {
                return;
            }*/
            GameLog.ELog(Client, GameLog.MyEnum.Item, "House_Storage_Give_Item Type: " + type.ToString() + " Ammount: 1");

            Inventory.RemoveItemFromInventory(target, index, 1);
            GiveItemToInventory(Client, type, 1, slotid: slot);

            ShowTargetSearchMenu(Client, target);

            UsefullyRP.SendRoleplayAction(Client, "pretresa i oduzima" + Inventory.itens_available[type].name + " od osobe.");


            return;
        }

    }
    [RemoteEvent("Search_InventorySplit")]
    public void Search_SplitItem_Main(Player client, int sqlid)
    {
        if (client.GetData<Player>("Searching_Player").Position.DistanceTo(client.Position) > 3f)
        {
            return;
        }
        Inventory.SplitItemGlobal(client, sqlid);
        ShowTargetSearchMenu(client, client.GetData<Player>("Searching_Player"));
    }


    [RemoteEvent("Search_SideInventorySplit")]
    public void House_SideInventorySplit(Player Client, int sqlid)
    {
        if (Client.GetData<Player>("Searching_Player").Position.DistanceTo(Client.Position) > 3f)
        {
            return;
        }
        Inventory.SplitItemGlobal(Client.GetData<Player>("Searching_Player"), sqlid);
        ShowTargetSearchMenu(Client, Client.GetData<Player>("Searching_Player"));
    }


    [RemoteEvent("Search_InventoryChangeSlot")]
    public void House_InventoryChangeSlot(Player Client, int sqlid, int dataslot)
    {
        Player target = Client.GetData<Player>("Searching_Player");

        int playerid = Main.getIdFromClient(Client);
        int targetid = Main.getIdFromClient(target);
        int index = Inventory.GetInventoryIndexFromSQLID(target, sqlid);

        if (target.Position.DistanceTo(Client.Position) > 3f)
        {
            return;
        }
        if (target == null || !target.Exists)
        {
            return;
        }
        ChangeItemSlot(target, sqlid, dataslot);

    }

    [RemoteEvent("Search_InventoryStack")]
    public void House_InventoryStack(Player Client, int sqlold, int sqlnew)
    {
        Player target = Client.GetData<Player>("Searching_Player");

        int playerid = Main.getIdFromClient(Client);
        int targetid = Main.getIdFromClient(target);

        int oldindex = Inventory.GetInventoryIndexFromSQLID(Client, sqlold);
        int newindex = Inventory.GetInventoryIndexFromSQLID(Client, sqlnew);

        if (oldindex == -1 || newindex == -1)
        {
            return;
        }
        if (target.Position.DistanceTo(Client.Position) > 3f)
        {
            return;
        }
        if (Inventory.player_inventory[playerid].type[oldindex] != Inventory.player_inventory[playerid].type[newindex] || Inventory.player_inventory[playerid].sql_id[oldindex] == Inventory.player_inventory[playerid].sql_id[newindex])
        {
            ShowTargetSearchMenu(Client, target);
            return;
        }

        if (AccountManage.GetPlayerConnected(Client))
        {
            if (Inventory.player_inventory[playerid].sql_id[oldindex] == -1 || Inventory.player_inventory[playerid].inuse[oldindex] == 1 || Inventory.player_inventory[playerid].dropable[oldindex] == 0)
            {
                ShowTargetSearchMenu(Client, target);
                Main.SendErrorMessage(Client, "Greska. (" + Inventory.player_inventory[playerid].sql_id[oldindex] + " - " + oldindex + " - " + Inventory.player_inventory[playerid].type[oldindex] + ")");
                return;
            }
            if (Inventory.player_inventory[playerid].sql_id[newindex] == -1 || Inventory.player_inventory[playerid].inuse[newindex] == 1 || Inventory.player_inventory[playerid].dropable[newindex] == 0)
            {
                ShowTargetSearchMenu(Client, target);
                Main.SendErrorMessage(Client, "Greska. (" + Inventory.player_inventory[playerid].sql_id[newindex] + " - " + newindex + " - " + Inventory.player_inventory[playerid].type[newindex] + ")");
                return;
            }

            if (Inventory.player_inventory[playerid].amount[oldindex] >= 1 && Inventory.player_inventory[playerid].amount[newindex] >= 1)
            {
                Inventory.player_inventory[playerid].amount[newindex] += Inventory.player_inventory[playerid].amount[oldindex];
                Inventory.player_inventory[playerid].slotid[newindex] = Inventory.player_inventory[playerid].slotid[oldindex];

                Inventory.player_inventory[playerid].amount[oldindex] = 0;

                Main.CreateMySqlCommand("UPDATE `inventory` SET `slotid` = " + Inventory.player_inventory[playerid].slotid[newindex] + " WHERE `id` = " + sqlnew + "");
                Main.CreateMySqlCommand("UPDATE inventory SET `amount` = " + Inventory.player_inventory[playerid].amount[newindex] + " WHERE `id` = " + sqlnew + "");
                Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `id` = '" + sqlold + "';");

                Inventory.player_inventory[playerid].sql_id[oldindex] = -1;
                Inventory.player_inventory[playerid].type[oldindex] = 0;
                Inventory.player_inventory[playerid].amount[oldindex] = 0;
                Inventory.player_inventory[playerid].inuse[oldindex] = 0;
                Inventory.player_inventory[playerid].dropable[oldindex] = 1;
                Inventory.player_inventory[playerid].slotid[oldindex] = -1;
                ShowTargetSearchMenu(Client, target);

            }

        }
    }

    [RemoteEvent("Search_SideInventoryStack")]
    public void House_SideInventoryStack(Player Client, int sqlnew, int sqlold)
    {
        Player target = Client.GetData<Player>("Searching_Player");

        int playerid = Main.getIdFromClient(Client);
        int targetid = Main.getIdFromClient(target);

        int oldindex = Inventory.GetInventoryIndexFromSQLID(Client, sqlold);
        int newindex = Inventory.GetInventoryIndexFromSQLID(Client, sqlnew);

        if (oldindex == -1 || newindex == -1)
        {
            return;
        }
        if (Inventory.player_inventory[targetid].type[oldindex] != Inventory.player_inventory[targetid].type[newindex] || Inventory.player_inventory[targetid].sql_id[oldindex] == Inventory.player_inventory[targetid].sql_id[newindex])
        {
            ShowTargetSearchMenu(Client, target);
            return;
        }
        if (target.Position.DistanceTo(Client.Position) > 3f)
        {
            return;
        }
        if (AccountManage.GetPlayerConnected(Client))
        {
            if (Inventory.player_inventory[targetid].sql_id[oldindex] == -1 || Inventory.player_inventory[targetid].inuse[oldindex] == 1 || Inventory.player_inventory[targetid].dropable[oldindex] == 0)
            {
                ShowTargetSearchMenu(Client, target);
                Main.SendErrorMessage(Client, "Greska. (" + Inventory.player_inventory[targetid].sql_id[oldindex] + " - " + oldindex + " - " + Inventory.player_inventory[targetid].type[oldindex] + ")");
                return;
            }
            if (Inventory.player_inventory[targetid].sql_id[newindex] == -1 || Inventory.player_inventory[targetid].inuse[newindex] == 1 || Inventory.player_inventory[targetid].dropable[newindex] == 0)
            {
                ShowTargetSearchMenu(Client, target);
                Main.SendErrorMessage(Client, "Greska. (" + Inventory.player_inventory[targetid].sql_id[newindex] + " - " + newindex + " - " + Inventory.player_inventory[targetid].type[newindex] + ")");
                return;
            }

            if (Inventory.player_inventory[targetid].amount[oldindex] >= 1 && Inventory.player_inventory[targetid].amount[newindex] >= 1)
            {
                Inventory.player_inventory[targetid].amount[newindex] += Inventory.player_inventory[targetid].amount[oldindex];
                Inventory.player_inventory[targetid].slotid[newindex] = Inventory.player_inventory[targetid].slotid[oldindex];

                Inventory.player_inventory[targetid].amount[oldindex] = 0;

                Main.CreateMySqlCommand("UPDATE `inventory` SET `slotid` = " + Inventory.player_inventory[targetid].slotid[newindex] + " WHERE `id` = " + sqlnew + "");
                Main.CreateMySqlCommand("UPDATE inventory SET `amount` = " + Inventory.player_inventory[targetid].amount[newindex] + " WHERE `id` = " + sqlnew + "");
                Main.CreateMySqlCommand("DELETE FROM `inventory` WHERE `id` = '" + sqlold + "';");

                Inventory.player_inventory[targetid].sql_id[oldindex] = -1;
                Inventory.player_inventory[targetid].type[oldindex] = 0;
                Inventory.player_inventory[targetid].amount[oldindex] = 0;
                Inventory.player_inventory[targetid].inuse[oldindex] = 0;
                Inventory.player_inventory[targetid].dropable[oldindex] = 1;
                Inventory.player_inventory[targetid].slotid[oldindex] = -1;
                ShowTargetSearchMenu(Client, target);

            }

        }
    }

    [RemoteEvent("Search_ItemAction")]
    public static void Veh_Client_ItemAction(Player Client, int sqlid, int amount)
    {
        Player target = Client.GetData<Player>("Searching_Player");

        int playerid = Main.getIdFromClient(Client);
        int targetid = Main.getIdFromClient(target);

        int index = GetInventoryIndexFromSQLID(Client, sqlid);

        if (index == -1)
        {
            return;
        }
        if (target.Position.DistanceTo(Client.Position) > 3f)
        {
            return;
        }
        try
        {
            if (player_inventory[targetid].sql_id[index] == -1)
            {
                Main.SendErrorMessage(Client, "Greska. (" + player_inventory[targetid].sql_id[index] + " - " + index + " - " + player_inventory[targetid].type[index] + ")");
                return;
            }
            if (player_inventory[targetid].amount[index] < 1)
            {
                return;
            }
            if (itens_available[player_inventory[targetid].type[index]].guest != ITEM_TYPE_Ammunation)
            {
                amount = 1;
            }

            UseItemFromInventory(Client, index, amount, 4);
            return;
        }
        catch
        {

        }
    }

}
