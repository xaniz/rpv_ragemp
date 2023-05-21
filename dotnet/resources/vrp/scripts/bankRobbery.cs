using System;
using System.Text;
using GTANetworkAPI;
using System.Collections.Generic;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;

class bankRobbery : Script
{
    //
    //
    //

    public static int SETTINGS_COPS_NEEDED = 0;
    public static int SETTINGS_MEMBERS_NEEDED = 0;

    public static int SETTINGS_CRATE_MONEY_MIN = 90000;
    public static int SETTINGS_CRATE_MONEY_MAX = 100000;


    public static int SETTINGS_TABLE_MONEY_MIN = 30;
    public static int SETTINGS_TABLE_MONEY_MAX = 35;

    public static int GOLD_BARS = 4;

    public static int SETTINGS_TO_OPEN_BANK_AFTER_ROBBERY = 150000; // 150000 = 150 segundos
    public static int SETTINGS_EXPLODE_TIME_C4 = 30; // 15 = 15 seconds

    //
    public static Entity drill = null;
    public static TextLabel drill_label = null;
    public static int drill_timer = 0;
    public static int drill_stage = 0;

    public static int drill_timer2 = 0;
    public static int drill_stage2 = 0;

    public static Entity vault_door = null;
    public static TextLabel vault_label = null;
    public static int vault_timer = 0;
    public static int vault_stage = 0;
    public static Entity[] mines { get; set; } = new Entity[4];

    public static Entity cash_prop = null;
    public static int cash_prop_stage = 0;
    public static TextLabel cash_prop_label = null;
    public static int cash_prop_money = 0;

    public static Entity sdoor = null;
    public static Entity poluga1 = null;
    public static Entity poluga2 = null;
    public static Entity poluga3 = null;
    public static Entity poluga4 = null;

    //
    // Door Pacific Standard
    //
    public static bool drill_door_lock_status = true;
    public static bool bank_door_lock = false;

    public static bool eledoor = false;


    public static int main_robbery_bank_stage = 0;
    public static TimerEx timeout_bank_robbery = null;

    //mp_heists@keypad@   idle_a

    public bankRobbery()
    {
        Random rnd = new Random();

        // Remove Door
        API.Shared.DeleteWorldProp(961976194, new Vector3(254.0934, 225.13, 101.875), 40f);
        API.Shared.DeleteWorldProp(-1508355822, new Vector3(261.25, 214.50, 101.81), 40f);

        // Money Crate (empty: -1823263496)

        // Prop cash (empty: 769923921)
        cash_prop = API.Shared.CreateObject(-1363719163, new Vector3(255.8385f, 219.0404f, 101.02f), new Vector3(0f, 0f, 159.9991f));
        

        // Maleta (empty: 359105829)
        poluga1 = API.Shared.CreateObject(-263787977, new Vector3(264.3554f, 213.5008f, 101.55f), new Vector3(0f, 0f, 5.999181f));
        poluga2 = API.Shared.CreateObject(-263787977, new Vector3(264.4554f, 213.4008f, 101.55f), new Vector3(0f, 0f, 19.999181f));
        poluga3 = API.Shared.CreateObject(-263787977, new Vector3(264.5054f, 213.7308f, 101.55f), new Vector3(0f, 0f, -96.999181f));
        poluga4 = API.Shared.CreateObject(-263787977, new Vector3(264.2154f, 213.9008f, 101.55f), new Vector3(0f, 0f, 111.999181f));
        // vrata trezora dole
        sdoor = API.Shared.CreateObject(-1508355822, new Vector3(261.30f, 214.50f, 101.81f), new Vector3(0f, 0f, -110.0f));


        //
        vault_door = API.Shared.CreateObject(961976194, new Vector3(255.23f, 224.01f, 102.4008f), new Vector3(0f, 0f, 160f));


    
        cash_prop_money = rnd.Next(SETTINGS_TABLE_MONEY_MIN, SETTINGS_TABLE_MONEY_MAX);
        cash_prop_label = NAPI.TextLabel.CreateTextLabel("~s~Zlato~n~~c~(~s~"+ cash_prop_money.ToString("N0") + "~c~)~n~~w~~y~Y~w~", new Vector3(cash_prop.Position.X, cash_prop.Position.Y, cash_prop.Position.Z + 0.8), 10, 0.30f, 4, new Color(7, 163, 30, 190));

        drill_label = NAPI.TextLabel.CreateTextLabel("[~g~Y~c~ da probusite bravu~g~]", new Vector3(257.4, 219.99, 106.75), 10, 0.30f, 4, new Color(7, 163, 30, 190));

        vault_label = NAPI.TextLabel.CreateTextLabel("[~g~Y~c~ da stavite C4~g~]", new Vector3(253.9785, 225.0538, 101.8757), 10, 0.30f, 4, new Color(7, 163, 30, 190));

        //
        OnRobberyTimer();
    }

    public static void ResetBankRobbery2()
    {
        Random rnd = new Random();

        cash_prop.Delete();

        vault_door.Position = new Vector3(255.23f, 224.01f, 102.4008f);
        vault_door.Rotation = new Vector3(0f, 0f, 160f);


        cash_prop_money = 0;

        main_robbery_bank_stage = 0;
    }
    
    public static void ResetBankRobbery()
    {
        NAPI.Task.Run(() =>
        {
        cash_prop.Delete();
        vault_door.Delete();
        Random rnd = new Random();
        cash_prop = API.Shared.CreateObject(-1363719163, new Vector3(255.8385f, 219.0404f, 101.02f), new Vector3(0f, 0f, 159.9991f));
        

        // Maleta (empty: 359105829)
        poluga1 = API.Shared.CreateObject(-263787977, new Vector3(264.3554f, 213.5008f, 101.55f), new Vector3(0f, 0f, 5.999181f));
        poluga2 = API.Shared.CreateObject(-263787977, new Vector3(264.4554f, 213.4008f, 101.55f), new Vector3(0f, 0f, 19.999181f));
        poluga3 = API.Shared.CreateObject(-263787977, new Vector3(264.5054f, 213.7308f, 101.55f), new Vector3(0f, 0f, -96.999181f));
        poluga4 = API.Shared.CreateObject(-263787977, new Vector3(264.2154f, 213.9008f, 101.55f), new Vector3(0f, 0f, 111.999181f));
        // vrata trezora dole
        sdoor = API.Shared.CreateObject(-1508355822, new Vector3(261.30f, 214.50f, 101.81f), new Vector3(0f, 0f, -110.0f));


        //
        vault_door = API.Shared.CreateObject(961976194, new Vector3(255.23f, 224.01f, 102.4008f), new Vector3(0f, 0f, 160f));

        eledoor = false;
        drill_door_lock_status = true;
        main_robbery_bank_stage = 0;
        vault_stage = 0;
        drill_timer = 0;
        drill_stage = 0;
        GOLD_BARS = 4;

        cash_prop_money = rnd.Next(SETTINGS_TABLE_MONEY_MIN, SETTINGS_TABLE_MONEY_MAX);
        cash_prop_label = NAPI.TextLabel.CreateTextLabel("~s~Zlato~n~~c~(~s~"+ cash_prop_money.ToString("N0") + "~c~)~n~~w~~y~Y~w~", new Vector3(cash_prop.Position.X, cash_prop.Position.Y, cash_prop.Position.Z + 0.8), 10, 0.30f, 4, new Color(7, 163, 30, 190));
        vault_label = NAPI.TextLabel.CreateTextLabel("[~g~Y~c~ da stavite C4~g~]", new Vector3(253.9785, 225.0538, 101.8757), 10, 0.30f, 4, new Color(7, 163, 30, 190));
        });
    }


    [RemoteEvent("bankrob")]
    public static void KeyPressY(Player player)
    {
        
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(257.4, 219.65, 106.4), 2.0f) && main_robbery_bank_stage == 0)
        {
            if(main_robbery_bank_stage != 0)
            {
                player.SendNotification("Banka je vec opljackana.");
                return;
            }
            int cops_online = 0;
            foreach(var target in NAPI.Pools.GetAllPlayers())
            {
                if (FactionManage.GetPlayerGroupID(target) == 1 && target.GetData<dynamic>("duty") == 1)
                {
                    cops_online++;
                }
            }

            if (cops_online < SETTINGS_COPS_NEEDED)
            {
                Main.DisplayErrorMessage(player, NotifyType.Info, NotifyPosition.BottomCenter, "Nema dovoljno policajaca na serveru, potrebno minimum 8");
                return;
            }
            if (Inventory.GetPlayerItemFromInventory(player, 20) < 1)
            {
                Main.SendErrorMessage(player, "Nemate busilicu.");
                return;
            }
            NAPI.Chat.SendChatMessageToAll("~r~PLJACKA ~g~LOS SANTOS BANKE~r~!!! NE PRILAZITE ZONI!!!");
            NAPI.Chat.SendChatMessageToAll("~r~PLJACKA ~g~LOS SANTOS BANKE~r~!!! NE PRILAZITE ZONI!!!");

            foreach (var target in NAPI.Pools.GetAllPlayers())
            {
                if (target.GetData<dynamic>("status") == true && AccountManage.GetPlayerGroup(target) == 1)
                {
                    Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "U toku je pljacka BANKE !");
                    Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "U toku je pljacka BANKE !");
                    Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "U toku je pljacka BANKE !");
                }
            }
            
            

            player.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(player, 1, "amb@world_human_welding@male@base", "base");
            BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_tool_drill"), 60309, new Vector3(0.060, 0.060, 0.020), new Vector3(-90.0000,-90.0000, 0.0000));
            bool drilling = true;
            NAPI.Task.Run(async () =>
            {
                while (drilling)
                {
                    if (!NAPI.Player.IsPlayerConnected(player)) return;
                    if (!Main.IsInRangeOfPoint(player.Position, new Vector3(257.4, 219.65, 106.4), 2.0f))
                    {
                        drilling = false;
                        Main.DisplayErrorMessage(player, NotifyType.Info, NotifyPosition.BottomCenter, "Prekinuli ste busenje");
                        BasicSync.DetachObject(player);
                        return;
                    }

                    await Task.Delay(1000);
                }
            });

            NAPI.Task.Run(() =>
            {
                if (!NAPI.Player.IsPlayerConnected(player)) return;
                if (Main.IsInRangeOfPoint(player.Position, new Vector3(257.4, 219.65, 106.4), 2.0f))
                {
                    drilling = false;
                    main_robbery_bank_stage = 1;
                    drill_timer = 2;
                    drill_stage = 1;
                    BasicSync.DetachObject(player);
                    player.StopAnimation();
                    main_robbery_bank_stage = 2;
                    Police.SetPlayerCrime(player, 9);
                    Inventory.RemoveItemByType(player, 20, 1);
                }
                
            }, delayTime: 120000);
            
        }

        if (Main.IsInRangeOfPoint(player.Position, new Vector3(253.9785, 225.0538, 101.8757), 1.0f) && vault_stage == 0 && main_robbery_bank_stage == 2)
        {
            if (Inventory.GetPlayerItemFromInventory(player, 19) < 1)
            {
                Main.SendErrorMessage(player, "Potreban vam je 1 eksploziv C4 da raznesete vrata.");
                return;
            }

            Inventory.RemoveItemByType(player, 19, 1);

            mines[0] = API.Shared.CreateObject(-1266278729, new Vector3(254.6958f, 224.2552f, 102.2034f), new Vector3(0f, 0f, 162.9988f));

            vault_timer = SETTINGS_EXPLODE_TIME_C4;
            vault_stage = 1;

            main_robbery_bank_stage = 3;
            player.PlayAnimation("weapons@first_person@aim_rng@generic@projectile@sticky_bomb@", "plant_vertical", 49);
            TimerEx.SetTimer(() =>
            {
                player.StopAnimation();
            }, 1800, 1);

            NAPI.Task.Run(() =>
            {
                mines[0].Delete();


                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if (Main.IsInRangeOfPoint(target.Position, new Vector3(254.6958, 224.2552, 102.2034), 100f))
                    {
                        target.TriggerEvent("explode", new Vector3(254.6958, 224.2552, 102.2034), ExplosionType.StickyBomb, 3.0f, true, false, 7.0f);
                    }
                }

                vault_door.Position = new Vector3(255.1254f, 224.3181f, 100.92f);
                vault_door.Rotation = new Vector3(-89.23032f, 1.514521f, 154.2677f);


            }, delayTime: SETTINGS_EXPLODE_TIME_C4 * 1000);
        }
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(255.7437, 218.4138, 101.6834), 0.8f) && cash_prop_stage == 0 && main_robbery_bank_stage == 3)
            {
                if (player.GetData<bool>("cash_prop") == true)
                {
                    player.SetData("cash_prop", false);
                    player.StopAnimation();
                }
                else
                {
                    player.SetData("cash_prop", true);
                    player.PlayAnimation("oddjobs@shop_robbery@rob_till", "loop", 49);
                }
                
            }
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(261.1837, 215.2438, 101.6834), 2.0f) && main_robbery_bank_stage == 3)
        {
            if (Job_Controler.GetPlayerJob(player) == 6 && player.GetData<dynamic>("jobskill") >= 149)
            {
                player.PlayAnimation("missheistdocks2bleadinoutlsdh_2b_int", "leg_massage_b_floyd", 1);
                NAPI.Task.Run(() =>
                {
                    if(NAPI.Player.IsPlayerConnected(player))
                    {
                    player.StopAnimation();
                    sdoor.Delete();
                    eledoor = true;
                    }
                }, delayTime: 5000);
                
            }
            else
            {
                return;
            }
            
        }
        if (Main.IsInRangeOfPoint(player.Position, new Vector3(263.5937, 214.0038, 101.6834), 2.0f) && eledoor == true && GOLD_BARS > 0)
        {
            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 80, 1, Inventory.Max_Inventory_Weight(player)))
            {
                player.StopAnimation();
                return;
            }
            GOLD_BARS = 0; 
            player.PlayAnimation("oddjobs@shop_robbery@rob_till", "loop", 49);
            
            NAPI.Task.Run(() =>
                {
                    if(NAPI.Player.IsPlayerConnected(player))
                    {
                        
                        Inventory.GiveItemToInventory(player, 80, 4);
                        player.StopAnimation();
                        poluga1.Delete();
                        poluga2.Delete();
                        poluga3.Delete();
                        poluga4.Delete();
                    }
                }, delayTime: 4000);
            
            
                       
        }
    }

    public static void OnPlayerConnect(Player player)
    {
    }


    public void OnRobberyTimer()
    {
        TimerEx.SetTimer(() =>
        {
            if(drill_stage == 1)
            {
                drill_timer--;

                if (drill_timer == 0)
                {
                    drill_door_lock_status = false;
                    drill_stage = 4;
                }
            }

            if(vault_stage == 1)
            {
                vault_timer = vault_timer-2;
                vault_label.Text = "~y~C4 stavljen ~g~uspesno~w~ !~n~~n~~o~**~w~"+ vault_timer + "~o~ sec **";
                if (vault_timer == 0)
                {
                    vault_label.Text = " ";
                    vault_stage = 2;
                }
                
            }

            foreach (var player in NAPI.Pools.GetAllPlayers())
            {
                    if(Main.IsInRangeOfPoint(player.Position, new Vector3(256.31, 220.66, 106.43), 300.0f))
                    {
                        player.TriggerEvent("doorLock", -222270721, new Vector3(256.31, 220.66, 106.43), drill_door_lock_status, 0);
                        player.TriggerEvent("doorLock", 110411286, new Vector3(232.6054, 214.1584, 106.4049), bank_door_lock, 0);
                        player.TriggerEvent("doorLock", 110411286, new Vector3(231.5123, 216.5177, 106.4049), bank_door_lock, 0);
                        player.TriggerEvent("doorLock", 110411286, new Vector3(260.6432, 203.2052, 106.4049), bank_door_lock, 0);
                        player.TriggerEvent("doorLock", 110411286, new Vector3(258.2022, 204.1005, 106.4049), bank_door_lock, 0);
                    }
                


                    //
                    // Must have returns ;
                    //
                    if (player.GetData<bool>("cash_prop") == true && Main.IsInRangeOfPoint(player.Position, new Vector3(255.7437, 218.4138, 101.6834), 0.8f) && cash_prop_stage == 0 && player.GetSharedData<dynamic>("Injured") == 0)
                    {
                        int money = 0;
                        if (cash_prop_money > 1)
                        {
                            if (Inventory.Check_InventoryWeight_With_ItemAmount(player, 80, 1, Inventory.Max_Inventory_Weight(player)))
                            {
                                return;
                            }
                            Random rnd = new Random();
                            money = rnd.Next(1, 2);
                            cash_prop_money -= money;
                            Inventory.GiveItemToInventory(player, 80, money);
                            cash_prop_label.Text = "~g~Zlato~n~~c~(~s~" + cash_prop_money.ToString("N0") + "~c~)~n~~w~ ~y~Y~w~";
                        }
                        else // random@atmrobberygen pickup_low
                        {
                            if (money > 0)
                            {
                                money = cash_prop_money;
                                Inventory.GiveItemToInventory(player, 80, cash_prop_money);
                            }
                            Vector3 position = cash_prop.Position;
                            Vector3 rotation = cash_prop.Rotation;
                            cash_prop.Delete();
                            cash_prop = API.Shared.CreateObject(-1326042488, position, rotation);
                            cash_prop_label.Text = "~s~Zlato~n~~c~(prazno)~n~~w~";
                            cash_prop_stage = 1;
                            player.SetData("cash_prop", false);
                            player.StopAnimation();
                        }

                    }
                    else
                    {
                        if (player.GetData<bool>("cash_prop") == true) player.SetData("cash_prop", false);
                    }
            }
        }, 2000, 0);
    }
    //main_robbery_bank_stage
    [Command("zatvoribanku")]
    public static void polzbvrata(Player player)
    {
        if (FactionManage.GetPlayerGroupType(player) != 1)
        {
            return;
        }

        if (player.Position.DistanceTo2D(new Vector3(253.95, 225.1646, 101.87167)) < 3) // /tpc 1529.89 1727.68 109.94
        {
            ResetBankRobbery2();
        }
    }

    public static void SellGoldBars(Player Client)
    {
        if (Inventory.GetPlayerItemFromInventory(Client, 80) > 0)
        {
            int totalnakit = Inventory.GetPlayerItemFromInventory(Client, 80);
            Inventory.RemoveItemByType(Client, 80, totalnakit);
            Main.GivePlayerMoney(Client, 5000 * totalnakit);
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Prodali ste zlatne poluge i zaradili $" + totalnakit * 5000 + " ");
        }
    }
}


