
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;

public class WeaponManage : Script
{
    public static int MAX_PLAYER_WEAPONS = 10;

    public static void OnPlayerConnect(Player Client)
    {
        Client.SetData<dynamic>("primary_weapon", 0);
        Client.SetData<dynamic>("primary_ammunation", 0);

        Client.SetData<dynamic>("pistol_weapon", 0);
        Client.SetData<dynamic>("pistol_ammunation", 0);

        Client.SetData<dynamic>("tazer_weapon", 0);

        Client.SetData<dynamic>("secundary_weapon", 0);
        Client.SetData<dynamic>("secundary_ammunation", 0);

        Client.SetData<dynamic>("weapon_meele", 0);

        Client.SetData<dynamic>("TakeoutWeapon", false);
    }


    [ServerEvent(Event.PlayerWeaponSwitch)]
    public void OnPlayerWeaponSwitch(Player Client, WeaponHash oldweaponhash, WeaponHash newweaponhash)
    {

        Client.TriggerEvent("client:weaponSwap");

        if (Client.GetData<dynamic>("status") == true)
        {
            Client.TriggerEvent("client:weaponSwap");

            var index = 0;
            int weapon_id = -1;
            foreach (var gun in Main.weapon_list)
            {
                if (Convert.ToInt64(gun.hash) == (long)oldweaponhash)
                {
                    weapon_id = index;
                    break;
                }
                index++;
            }
            if (Client.HasData("dontattachweapon") && Client.GetData<dynamic>("dontattachweapon") == false)
            {

                if (weapon_id != -1 && newweaponhash == WeaponHash.Unarmed)
                {
                    if (Main.weapon_list[weapon_id].classe == "Primary")
                    {
                        if (Client.GetData<dynamic>("primary_weapon") == 0)
                        {
                            BasicSync.DetachObject(Client);
                            
                        }
                        else
                        {
                            Main.PlayAnimation(Client, "anim@heists@ornate_bank@grab_cash", "exit", 49, 2000);
                            Client.TriggerEvent("addLocal", Enum.GetName(typeof(WeaponHash), oldweaponhash));

                        }
                    }
                    else if (Main.weapon_list[weapon_id].classe == "Secundary")
                    {
                        if (Client.GetData<dynamic>("secundary_weapon") == 0)
                        {
                            BasicSync.DetachObject(Client);

                        }
                        else
                        {
                            Main.PlayAnimation(Client, "anim@heists@ornate_bank@grab_cash", "exit", 49, 2000);
                            Client.TriggerEvent("addLocal", Enum.GetName(typeof(WeaponHash), oldweaponhash));

                        }
                    }
                    else if (Main.weapon_list[weapon_id].classe == "pistol")
                    {
                        if (Client.GetData<dynamic>("pistol_weapon") == 0)
                        {
                            BasicSync.DetachObject(Client);

                        }
                        else
                        {
                            Main.PlayAnimation(Client, "reaction@intimidation@1h", "outro", 49, 2000);

                            Client.TriggerEvent("addLocal", Enum.GetName(typeof(WeaponHash), oldweaponhash));
                         
                        }
                    }
                }
                else
                {

                    if (Enum.GetName(typeof(WeaponHash), oldweaponhash) != null && oldweaponhash != WeaponHash.Unarmed)
                    {
                        Client.TriggerEvent("addLocal", Enum.GetName(typeof(WeaponHash), oldweaponhash));
                  
                    }
                    index = 0;
                    foreach (var gun in Main.weapon_list)
                    {
                        if (Convert.ToInt64(gun.hash) == (long)newweaponhash)
                        {
                            weapon_id = index;
                            break;
                        }
                        index++;
                    }
                    if (Enum.GetName(typeof(WeaponHash), newweaponhash) != null && newweaponhash != WeaponHash.Unarmed)
                    {
                        if (weapon_id != -1)
                        {

                            if (Main.weapon_list[weapon_id].classe == "Primary")
                            {
                                if (Client.GetData<dynamic>("primary_weapon") != 0)
                                {
                                    Main.PlayAnimation(Client, "anim@heists@ornate_bank@grab_cash", "intro", 49, 1100);
                                }
                            }
                            else if (Main.weapon_list[weapon_id].classe == "Secundary")
                            {
                                if (Client.GetData<dynamic>("secundary_weapon") != 0)
                                {
                                    Main.PlayAnimation(Client, "anim@heists@ornate_bank@grab_cash", "intro", 49, 1100);
                                }

                            }
                            else if (Main.weapon_list[weapon_id].classe == "pistol")
                            {
                                if (Client.GetData<dynamic>("pistol_weapon") != 0)
                                {
                                    Main.PlayAnimation(Client, "reaction@intimidation@1h", "intro", 49, 1900);
                                }
                            }
                        }

                        BasicSync.DetachObject(Client);

                    }
                }
            }
            else
            {
                Client.SetData("dontattachweapon", false);
            }
        }



    }



    public static void SetPlayerWeaponEx(Player Client, string Weapon_Name, int ammo)
    {
        var index = 0;
        int weapon_id = -1;
        foreach (var gun in Main.weapon_list)
        {
            if (((string)gun.model).Equals(Weapon_Name, StringComparison.CurrentCultureIgnoreCase) == true)
            {
                weapon_id = index;
                break;
            }
            index++;
        }
        if (weapon_id == -1)
        {

            return;
        }

        WeaponHash hashcode = NAPI.Util.WeaponNameToModel(Main.weapon_list[weapon_id].model);

        if (hashcode != WeaponHash.Unarmed)
        {
            // Client.TriggerEvent("addLocal", Main.weapon_list[weapon_id].model);
            Client.TriggerEvent("addLocal", Enum.GetName(typeof(WeaponHash), hashcode));
            //   Client.TriggerEvent("addLocal", "WEAPON_" + Enum.GetName(typeof(WeaponHash), hashcode).ToUpper());
        }


        if (Main.weapon_list[weapon_id].classe == "Primary")
        {

            if (Client.GetData<dynamic>("primary_weapon") == 0)  // First login fix ;
            {

                Client.SetData<dynamic>("primary_ammunation", ammo);
                Client.SetData<dynamic>("primary_weapon", hashcode);
                NAPI.Player.GivePlayerWeapon(Client, Client.GetData<dynamic>("primary_weapon"), Client.GetData<dynamic>("primary_ammunation"));
                NAPI.Player.SetPlayerCurrentWeapon(Client, Client.GetData<dynamic>("primary_weapon"));
                NAPI.Player.SetPlayerWeaponAmmo(Client, Client.GetData<dynamic>("primary_weapon"), Client.GetData<dynamic>("primary_ammunation"));
                return;
            }

            Client.SetData<dynamic>("primary_ammunation", ammo);

            if ((long)Client.GetData<dynamic>("primary_weapon") != (long)hashcode)
            {
                try
                {
                    API.Shared.RemovePlayerWeapon(Client, Client.GetData<dynamic>("primary_weapon"));
                }
                catch
                {
                    API.Shared.ConsoleOutput("[ERROR]: Impossivel retirar " + Client.GetData<dynamic>("primary_weapon") + "");
                }

                Client.SetData<dynamic>("primary_weapon", hashcode);
                NAPI.Player.GivePlayerWeapon(Client, Client.GetData<dynamic>("primary_weapon"), Client.GetData<dynamic>("primary_ammunation"));
            }

            //  Main.SendCustomChatMessasge(Client,"SetPlayerWeaponEx  primary_ammunation");

            NAPI.Player.SetPlayerCurrentWeapon(Client, Client.GetData<dynamic>("primary_weapon"));
            NAPI.Player.SetPlayerWeaponAmmo(Client, Client.GetData<dynamic>("primary_weapon"), Client.GetData<dynamic>("primary_ammunation"));

            // animationCommands.OnPlayAnimationFromMenu(Client, "reaction@intimidation@1h", "intro", 2);
        }
        else if (Main.weapon_list[weapon_id].classe == "Secundary")
        {

            if (Client.GetData<dynamic>("secundary_weapon") == 0)  // First login fix ;
            {

                // Main.SendCustomChatMessasge(Client,"SetPlayerWeaponEx  Secundary");

                Client.SetData<dynamic>("secundary_ammunation", ammo);
                Client.SetData<dynamic>("secundary_weapon", hashcode);

                NAPI.Player.GivePlayerWeapon(Client, Client.GetData<dynamic>("secundary_weapon"), Client.GetData<dynamic>("secundary_ammunation"));
                NAPI.Player.SetPlayerCurrentWeapon(Client, Client.GetData<dynamic>("secundary_weapon"));
                NAPI.Player.SetPlayerWeaponAmmo(Client, Client.GetData<dynamic>("secundary_weapon"), Client.GetData<dynamic>("secundary_ammunation"));
                return;
            }

            Client.SetData<dynamic>("primary_ammunation", ammo);

            if ((long)Client.GetData<dynamic>("secundary_weapon") != (long)hashcode)
            {
                try
                {
                    API.Shared.RemovePlayerWeapon(Client, Client.GetData<dynamic>("secundary_weapon"));
                }
                catch
                {
                    API.Shared.ConsoleOutput("[ERROR]: Impossivel retirar " + Client.GetData<dynamic>("secundary_weapon") + "");
                }

                Client.SetData<dynamic>("secundary_weapon", hashcode);
                NAPI.Player.GivePlayerWeapon(Client, Client.GetData<dynamic>("secundary_weapon"), Client.GetData<dynamic>("secundary_ammunation"));
            }
            // Main.SendCustomChatMessasge(Client,"SetPlayerWeaponEx  secundary_weapon");

            NAPI.Player.SetPlayerCurrentWeapon(Client, Client.GetData<dynamic>("secundary_weapon"));
            NAPI.Player.SetPlayerWeaponAmmo(Client, Client.GetData<dynamic>("secundary_weapon"), Client.GetData<dynamic>("secundary_ammunation"));

        }
        else if (Main.weapon_list[weapon_id].classe == "Melee")
        {
            if (Client.GetData<dynamic>("weapon_meele") == 0)  // First login fix ;
            {
                Client.SetData<dynamic>("weapon_meele", hashcode);
                NAPI.Player.GivePlayerWeapon(Client, Client.GetData<dynamic>("weapon_meele"), 0);
                return;
            }

            if ((long)Client.GetData<dynamic>("weapon_meele") != (long)hashcode)
            {
                try
                {
                    API.Shared.RemovePlayerWeapon(Client, Client.GetData<dynamic>("weapon_meele"));
                }
                catch
                {
                    API.Shared.ConsoleOutput("[ERROR]: Impossivel retirar " + Client.GetData<dynamic>("weapon_meele") + "");
                }

                Client.SetData<dynamic>("weapon_meele", hashcode);
                NAPI.Player.GivePlayerWeapon(Client, Client.GetData<dynamic>("weapon_meele"), 0);
            }

            NAPI.Player.SetPlayerCurrentWeapon(Client, Client.GetData<dynamic>("weapon_meele"));
        }

        else if (Main.weapon_list[weapon_id].classe == "pistol")
        {

            if (Client.GetData<dynamic>("pistol_weapon") == 0)  // First login fix ;
            {

                // Main.SendCustomChatMessasge(Client,"SetPlayerWeaponEx  Secundary");

                Client.SetData<dynamic>("pistol_ammunation", ammo);
                Client.SetData<dynamic>("pistol_weapon", hashcode);

                NAPI.Player.GivePlayerWeapon(Client, Client.GetData<dynamic>("pistol_weapon"), Client.GetData<dynamic>("pistol_ammunation"));
                NAPI.Player.SetPlayerCurrentWeapon(Client, Client.GetData<dynamic>("pistol_weapon"));
                NAPI.Player.SetPlayerWeaponAmmo(Client, Client.GetData<dynamic>("pistol_weapon"), Client.GetData<dynamic>("pistol_ammunation"));
                return;
            }

            Client.SetData<dynamic>("pistol_ammunation", ammo);

            if ((long)Client.GetData<dynamic>("pistol_weapon") != (long)hashcode)
            {
                try
                {
                    API.Shared.RemovePlayerWeapon(Client, Client.GetData<dynamic>("pistol_weapon"));
                }
                catch
                {
                    API.Shared.ConsoleOutput("[ERROR]: Impossivel retirar " + Client.GetData<dynamic>("pistol_weapon") + "");
                }

                Client.SetData<dynamic>("pistol_weapon", hashcode);
                NAPI.Player.GivePlayerWeapon(Client, Client.GetData<dynamic>("pistol_weapon"), Client.GetData<dynamic>("pistol_ammunation"));
            }
            // Main.SendCustomChatMessasge(Client,"SetPlayerWeaponEx  secundary_weapon");

            NAPI.Player.SetPlayerCurrentWeapon(Client, Client.GetData<dynamic>("pistol_weapon"));
            NAPI.Player.SetPlayerWeaponAmmo(Client, Client.GetData<dynamic>("pistol_weapon"), Client.GetData<dynamic>("pistol_ammunation"));

        }
        else if (Main.weapon_list[weapon_id].classe == "Tazer")
        {
            if (Client.GetData<dynamic>("tazer_weapon") == 0)  // First login fix ;
            {
                Client.SetData<dynamic>("tazer_weapon", hashcode);
                NAPI.Player.GivePlayerWeapon(Client, Client.GetData<dynamic>("tazer_weapon"), 0);
                return;
            }

            if ((long)Client.GetData<dynamic>("tazer_weapon") != (long)hashcode)
            {
                try
                {
                    API.Shared.RemovePlayerWeapon(Client, Client.GetData<dynamic>("tazer_weapon"));
                }
                catch
                {
                    API.Shared.ConsoleOutput("[ERROR]: Impossivel retirar " + Client.GetData<dynamic>("tazer_weapon") + "");
                }

                Client.SetData<dynamic>("tazer_weapon", hashcode);
                NAPI.Player.GivePlayerWeapon(Client, Client.GetData<dynamic>("tazer_weapon"), 0);
            }

            NAPI.Player.SetPlayerCurrentWeapon(Client, Client.GetData<dynamic>("tazer_weapon"));
        }



        //      Client.SetData<dynamic>("pistol_weapon", 0);
        //     Client.SetData<dynamic>("pistol_ammunation", 0);

        //    Client.SetData<dynamic>("tazer_weapon", 0);
    }


    /* [ServerEvent(Event.PlayerWeaponSwitch)]
     public void OnPlayerWeaponSwitch(Player Client, WeaponHash oldWeapon, WeaponHash newWeapon)
     {
         if ((int)newWeapon == -1569615261) return;

         var index = 0;
         int weapon_id = -1;
         foreach (var gun in Main.weapon_list)
         {
             if (Convert.ToInt32(gun.hash) == (int)newWeapon)
             {
                 weapon_id = index;
                 break;
             }
             index++;
         }

         if (weapon_id == -1)
         {
             Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, "Não foi possível encontrar esta arma em nosso banco de dados.");
             return;
         }

         if (Main.weapon_list[weapon_id].classe == "Primary")
         {
             NAPI.Player.SetPlayerWeaponAmmo(Client, newWeapon, Client.GetData<dynamic>("primary_ammunation"));
             NAPI.Player.SetPlayerCurrentWeaponAmmo(Client, Client.GetData<dynamic>("primary_ammunation"));
         }
         else if (Main.weapon_list[weapon_id].classe == "Secundary")
         {
             NAPI.Player.SetPlayerWeaponAmmo(Client, newWeapon, Client.GetData<dynamic>("secundary_ammunation"));
             NAPI.Player.SetPlayerCurrentWeaponAmmo(Client, Client.GetData<dynamic>("secundary_ammunation"));
         }
     }*//*
    int indexxx = 35;
     [Command("setflag")]
     public void setflagcom(Player client,int ss)
    {
        indexxx = ss;
    }


     [ServerEvent(Event.PlayerWeaponSwitch)]
     public void OnPlayerWeaponChange(Player Client,WeaponHash oldweapon,WeaponHash newweaponhash)
     {
        if (Client.GetData<dynamic>("TakeoutWeapon") == false)
        {

            NAPI.Task.Run(() => { Client.SetData<dynamic>("TakeoutWeapon", true); playerTakeoffW  NAPI.Player.ClearPlayerTasks(Client); }, delayTime: 1800);
            Client.GiveWeapon(WeaponHash.Unarmed, 0);

        }
        // animationCommands.OnPlayAnimationFromMenu(Client, "reaction@intimidation@1h", "intro", indexxx);


    }*/

    [RemoteEvent("playerTakeoffWeapon")]
    public void playerTakeoffWeapon(Player Client, Int64 weaponHash, int ammo)
    {
        if (Client.IsInVehicle) return;
        if (weaponHash == -1569615261) return;
        var index = 0;
        int weapon_id = -1;

        foreach (var gun in Main.weapon_list)
        {

            if (Convert.ToInt64(gun.hash) == weaponHash)
            {
                weapon_id = index;
                break;
            }
            index++;
        }

        if (weapon_id == -1)
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Ovo oruzije ne postoji.");
            return;
        }


        //Main.SendCustomChatMessasge(Client,"playerTakeoffWeapon");

        WeaponHash hashcode = NAPI.Util.WeaponNameToModel(Main.weapon_list[weapon_id].model);

        if (Main.weapon_list[weapon_id].classe == "Primary")
        {
            if ((Client.GetData<dynamic>("primary_ammunation") - 1) == 0) { Client.SetData<dynamic>("primary_ammunation", 0); Client.SetWeaponAmmo(Client.CurrentWeapon, 0); Client.GiveWeapon(WeaponHash.Unarmed, 1); return; }

            Client.SetData<dynamic>("primary_ammunation", Client.GetData<dynamic>("primary_ammunation") - 1);


            // if (ammo != Client.GetData<dynamic>("primary_ammunation"))
            // {
            // AntiCheat.CheatWarnToAdmin(Client, "Ammounation Hack", ammo.ToString(), Client.GetData<dynamic>("primary_ammunation").ToString());
            //  }
        }
        else if (Main.weapon_list[weapon_id].classe == "Secundary")
        {

            if ((Client.GetData<dynamic>("secundary_ammunation") - 1) == 0) { Client.SetData<dynamic>("secundary_ammunation", 0); Client.SetWeaponAmmo(Client.CurrentWeapon, 0); Client.GiveWeapon(WeaponHash.Unarmed, 1); return; }

            Client.SetData<dynamic>("secundary_ammunation", Client.GetData<dynamic>("secundary_ammunation") - 1);

            // if (ammo != Client.GetData<dynamic>("secundary_ammunation"))
            //  {
            //     AntiCheat.CheatWarnToAdmin(Client, "Ammounation Hack", ammo.ToString(), Client.GetData<dynamic>("secundary_ammunation").ToString());
            // }

        }
        else if (Main.weapon_list[weapon_id].classe == "Melee")
        {
            //Client.SetData<dynamic>("weapon_meele", (int)hashcode);
        }
        else if (Main.weapon_list[weapon_id].classe == "Tazer")
        {
            //Client.SetData<dynamic>("weapon_meele", (int)hashcode);
        }
        else if (Main.weapon_list[weapon_id].classe == "pistol")
        {
            if ((Client.GetData<dynamic>("pistol_ammunation") - 1) == 0) { Client.SetData<dynamic>("pistol_ammunation", 0); Client.SetWeaponAmmo(Client.CurrentWeapon, 0); Client.GiveWeapon(WeaponHash.Unarmed, 1); return; }

            Client.SetData<dynamic>("pistol_ammunation", Client.GetData<dynamic>("pistol_ammunation") - 1);
            // if (ammo != Client.GetData<dynamic>("secundary_ammunation"))
            //  {
            //     AntiCheat.CheatWarnToAdmin(Client, "Ammounation Hack", ammo.ToString(), Client.GetData<dynamic>("secundary_ammunation").ToString());
            // }

        }

        if (Client.GetData<dynamic>("handsup") == true)
        {
            // WeaponHash weapon = NAPI.Player.GetPlayerCurrentWeapon(Client);
            //Client.TriggerEvent("removeWeapon", (int)weapon);
            /*Client.TriggerEvent("removeAllWeapons");


            NAPI.Task.Run(() =>
            {
                NAPI.Player.RemoveAllPlayerWeapons(Client);
            }, delayTime: 500);*/
        }
    }

    public void CMD_dararma(Player Client, string idOrName, string name, int ammo)
    {
        if (AccountManage.GetPlayerAdmin(Client) <= 7)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {
            var index = 0;
            int weapon_id = -1;
            foreach (var gun in Main.weapon_list)
            {
                if (gun.model.Contains(name) == true)
                {
                    weapon_id = index;
                    break;
                }
                index++;
            }

            if (weapon_id == -1)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan model.");
                return;
            }

            

            WeaponHash hashcode = NAPI.Util.WeaponNameToModel(Main.weapon_list[weapon_id].model);
            SetPlayerWeaponEx(target, name, ammo);
            if (Main.weapon_list[weapon_id].classe == "Melee")
            {
                target.TriggerEvent("createNewHeadNotificationAdvanced", "Dobili ste: ~y~" + Main.weapon_list[weapon_id].model + "~w~ od Admina !");
                Main.SendCustomChatMessasge(Client, "Dali ste" + AccountManage.GetCharacterName(target) + " oruzje " + hashcode + ".");
            }
            else
            {
                target.TriggerEvent("createNewHeadNotificationAdvanced", "Dobili ste: ~y~" + Main.weapon_list[weapon_id].model + "~w~ i: ~c~" + ammo + " metkova ~w~ od Admina !");
                Main.SendCustomChatMessasge(Client, "Dali ste " + AccountManage.GetCharacterName(target) + " oruzje " + hashcode + " " + (long)hashcode + " (" + weapon_id + ") sa " + ammo + " metaka.");
            }
        }
    }

    public static async void LoadPlayerWeapons(Player Client)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            await Mainpipeline.OpenAsync();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `characters` WHERE `id` = '" + AccountManage.GetPlayerSQLID(Client) + "';", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {

                string data2txt = string.Empty;
                string datatxt = string.Empty;

                var index = 0;
                while (await reader.ReadAsync())
                {

                    Client.SetData<dynamic>("primary_ammunation", reader.GetInt64("primary_ammunation"));
                    Client.SetData<dynamic>("secundary_ammunation", reader.GetInt64("secundary_ammunation"));
                    Client.SetData<dynamic>("pistol_ammunation", reader.GetInt64("pistol_ammunation"));

                    WeaponHash weapon_primary = NAPI.Util.WeaponNameToModel(reader.GetString("primary_weapon"));
                    WeaponHash weapon_secundary = NAPI.Util.WeaponNameToModel(reader.GetString("secundary_weapon"));
                    WeaponHash weapon_melee = NAPI.Util.WeaponNameToModel(reader.GetString("melee"));
                    WeaponHash tazer = NAPI.Util.WeaponNameToModel(reader.GetString("tazer_weapon"));
                    WeaponHash pistol = NAPI.Util.WeaponNameToModel(reader.GetString("pistol_weapon"));


                    if (reader.GetString("pistol_weapon") != "0")
                    {
                        if (reader.GetInt64("pistol_ammunation") == 0)
                        {
                            SetPlayerWeaponEx(Client, Convert.ToString(pistol), 0);
                        }
                        else
                        {
                            SetPlayerWeaponEx(Client, Convert.ToString(pistol), reader.GetInt32("pistol_ammunation"));
                        }
                    }
                    else
                    {
                        Client.SetData<dynamic>("pistol_weapon", 0);
                        Client.SetData<dynamic>("pistol_ammunation", 0);
                    }
                    if (reader.GetString("primary_weapon") != "0")
                    {
                        if (reader.GetInt64("primary_ammunation") == 0)
                        {
                            SetPlayerWeaponEx(Client, Convert.ToString(weapon_primary), 0);
                        }
                        else
                        {
                            SetPlayerWeaponEx(Client, Convert.ToString(weapon_primary), reader.GetInt32("primary_ammunation"));
                            
                        }
                    }
                    else
                    {
                        Client.SetData<dynamic>("primary_weapon", 0);
                        Client.SetData<dynamic>("primary_ammunation", 0);
                    }


                    if (reader.GetString("secundary_weapon") != "0")
                    {

                        if (reader.GetInt64("secundary_ammunation") == 0)
                        {
                            SetPlayerWeaponEx(Client, Convert.ToString(weapon_secundary), 0);
                        }
                        else
                        {
                            SetPlayerWeaponEx(Client, Convert.ToString(weapon_secundary), reader.GetInt32("secundary_ammunation"));
                        }
                    }
                    else
                    {
                        Client.SetData<dynamic>("secundary_weapon", 0);
                        Client.SetData<dynamic>("secundary_ammunation", 0);
                    }


                    if (reader.GetString("melee") != "0")
                    {
                        SetPlayerWeaponEx(Client, Convert.ToString(weapon_melee), 0);
                    }
                    else
                    {
                        Client.SetData<dynamic>("weapon_meele", 0);
                    }

                    if (reader.GetString("tazer_weapon") != "0")
                    {
                        SetPlayerWeaponEx(Client, Convert.ToString(tazer), 0);
                    }
                    else
                    {
                        Client.SetData<dynamic>("tazer_weapon", 0);
                    }
                    index++;
                }
            }
        }
    }

    public static void SaveWeapons(Player Client)
    {
        Main.CreateMySqlCommand("UPDATE characters SET `pistol_weapon` = '" + Client.GetData<dynamic>("pistol_weapon") + "', `pistol_ammunation` = '" + Client.GetData<dynamic>("pistol_ammunation") + "',`primary_weapon` = '" + Client.GetData<dynamic>("primary_weapon") + "', `primary_ammunation` = '" + Client.GetData<dynamic>("primary_ammunation") + "', `secundary_weapon` = '" + Client.GetData<dynamic>("secundary_weapon") + "', `secundary_ammunation` = '" + Client.GetData<dynamic>("secundary_ammunation") + "',  `melee` = '" + Client.GetData<dynamic>("weapon_meele") + "' ,  `tazer_weapon` = '" + Client.GetData<dynamic>("tazer_weapon") + "' WHERE `id` = '" + AccountManage.GetPlayerSQLID(Client) + "';");
    }

    public static void RemovePlayerWeaponAndAttachment(Player player, WeaponHash weapon)
    {
        player.SetData("dontattachweapon", true);
        if (player.GetData<dynamic>("primary_weapon") != 0 && player.GetData<dynamic>("primary_weapon") == weapon)
        {
            BasicSync.DetachObject(player);
            player.SetData("primary_weapon", 0);
        }
        if (player.GetData<dynamic>("secundary_weapon") != 0 && player.GetData<dynamic>("secundary_weapon") == weapon)
        {
            BasicSync.DetachObject(player);
            player.SetData("secundary_weapon", 0);

        }
        if (player.GetData<dynamic>("pistol_weapon") != 0 && player.GetData<dynamic>("pistol_weapon") == weapon)
        {
            BasicSync.DetachObject(player);
            player.SetData("pistol_weapon", 0);

        }
        NAPI.Player.RemovePlayerWeapon(player, weapon);
        SaveWeapons(player);
    }


    public static void RemoveAllWeaponEx(Player Client)
    {

        if (Client.GetData<dynamic>("primary_weapon") != 0)
        {
            BasicSync.DetachObject(Client);
        }
        if (Client.GetData<dynamic>("secundary_weapon") != 0)
        {
            BasicSync.DetachObject(Client);
        }
        if (Client.GetData<dynamic>("pistol_weapon") != 0)
        {
            BasicSync.DetachObject(Client);
        }

        Client.SetData<dynamic>("pistol_weapon", 0);
        Client.SetData<dynamic>("pistol_ammunation", 0);
        Client.SetData<dynamic>("tazer_weapon", 0);

        Client.SetData<dynamic>("primary_weapon", 0);
        Client.SetData<dynamic>("primary_ammunation", 0);
        Client.SetData<dynamic>("secundary_weapon", 0);
        Client.SetData<dynamic>("secundary_ammunation", 0);
        Client.SetData<dynamic>("weapon_meele", 0);

        Client.TriggerEvent("removeAllWeapons");
        NAPI.Player.RemoveAllPlayerWeapons(Client);
    }
    public static void LoadPlayerWeaponIC(Player Client)
    {
        if (Client.GetData<dynamic>("primary_weapon") != 0)
        {
            Client.TriggerEvent("addLocal", Enum.GetName(typeof(WeaponHash), Client.GetData<dynamic>("primary_weapon")));
            Client.GiveWeapon((WeaponHash)Client.GetData<dynamic>("primary_weapon"), (int)Client.GetData<dynamic>("primary_ammunation"));
        }

        if (Client.GetData<dynamic>("secundary_weapon") != 0)
        {
            Client.TriggerEvent("addLocal", Enum.GetName(typeof(WeaponHash), Client.GetData<dynamic>("secundary_weapon")));
            Client.GiveWeapon((WeaponHash)Client.GetData<dynamic>("secundary_weapon"), (int)Client.GetData<dynamic>("secundary_ammunation"));

        }
        if (Client.GetData<dynamic>("pistol_weapon") != 0)
        {
            Client.TriggerEvent("addLocal", Enum.GetName(typeof(WeaponHash), Client.GetData<dynamic>("pistol_weapon")));
            Client.GiveWeapon((WeaponHash)Client.GetData<dynamic>("pistol_weapon"), (int)Client.GetData<dynamic>("pistol_ammunation"));
        }
        if (Client.GetData<dynamic>("melweapon_meeleee") != 0)
        {
            Client.GiveWeapon((WeaponHash)Client.GetData<dynamic>("weapon_meele"), 1);
        }
        if (Client.GetData<dynamic>("tazer_weapon") != 0)
        {
            Client.GiveWeapon((WeaponHash)Client.GetData<dynamic>("tazer_weapon"), 1);
        }
    }
    /* [Command("checkweapon2")]
     public void CheckGun2(Player Client)
     {
         WeaponHash hashcode = NAPI.Player.GetPlayerCurrentWeapon(Client);
         Main.SendCustomChatMessasge(Client, $"Mele: {Client.GetData<dynamic>("weapon_meele")}");
         Main.SendCustomChatMessasge(Client, $"secundary_weapon: {Client.GetData<dynamic>("secundary_weapon")}");
         Main.SendCustomChatMessasge(Client, $"primary_weapon: {Client.GetData<dynamic>("primary_weapon")}");

     }*/


    /* [Command("checkweapon")]
     public void CheckGun(Player Client)
     {
         WeaponHash hashcode = NAPI.Player.GetPlayerCurrentWeapon(Client);
         Main.SendCustomChatMessasge(Client, "You have a weapon with hash code " + (int)hashcode + "!");
         Main.SendCustomChatMessasge(Client, "The weapon name is " + hashcode + "!");
         Main.SendCustomChatMessasge(Client, "The weapon name is " + API.Shared.GetHashKey("") + "!");
     }*/

}
