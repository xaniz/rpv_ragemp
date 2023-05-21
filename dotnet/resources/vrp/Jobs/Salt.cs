using GTANetworkAPI;
using System;
using System.Collections.Generic;

class Salt
{
    private static List<dynamic> refinaria_positions = new List<dynamic>();
    public static List<TimerEx> sal_timer = new List<TimerEx>();

    public static void Arma3JobsInit()
    {

        for (var i = 0; i < Main.MAX_PLAYERS; i++)
        {
            sal_timer.Add(null);
        }

    }

    public static void OnPlayerConnect(Player Client)
    {
        Client.SetData<dynamic>("Refinando", false);
        Client.SetData<dynamic>("Sal", 20);
        Client.SetData<dynamic>("RefinandoTime", 0);
    }

    public static void PressKeyY(Player Client)
    {
        if (Client.IsInVehicle)
        {
            return;
        }
        foreach (var refinaria in refinaria_positions)
        {
            if (Main.IsInRangeOfPoint(Client.Position, refinaria.position, 14f) && Client.GetData<dynamic>("Refinando") == false)
            {

                if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 13, 1, Inventory.Max_Inventory_Weight(Client)) == true)
                {
                    return;
                }

                Inventory.GiveItemToInventory(Client, 13, 1);

                Client.SetData<dynamic>("Refinando", true);
                NAPI.Player.PlayPlayerAnimation(Client, (int)(Main.AnimationFlags.Loop), "anim@mp_snowball", "pickup_snowball");
               // Client.TriggerEvent("createNewHeadNotificationAdvanced", "shoma ~g~be dast ovrdid ~c~1~b~ namak~w~ az sang namak !");
                // Main.SendNotificationBrowser(Client, "", "<string>+ 3</strong> namak dar inventory shoma  !!", "ezafe shod");

                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(Client))
                    {
                    Client.SetData<dynamic>("Refinando", false);
                    Client.StopAnimation();
                    }
                }, delayTime: 1500);
            }
        }

        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(2564.25, 4680.224, 34.07677), 3f))
        {
            if (Inventory.GetPlayerItemFromInventory(Client, 13) >= 1 && Client.GetData<dynamic>("Refinando") == false)
            {
                //
                int sals = Inventory.GetPlayerItemFromInventory(Client, 13);
                int sals_a_ser_refinados = 0;
                //
                Client.SetData<dynamic>("Refinando", true);
                Client.TriggerEvent("freezeEx", true);
                Client.SetData<dynamic>("RefinandoTime", 5);
                //
                Client.TriggerEvent("freezeEx", true);
                Client.PlayScenario("WORLD_HUMAN_GUARD_STAND");
                Client.SetData<dynamic>("ForceAnim", true);
                //
               // Client.TriggerEvent("SetProgressBar", Client.GetData<dynamic>("RefinandoTime"), "tasfiye namak - " + sals_a_ser_refinados + " Az " + sals + "");
                Main.StartProgressBar(Client, 20, "salt");
                try
                {

               
                //
                sal_timer[Main.getIdFromClient(Client)] = TimerEx.SetTimer(() =>
                {
                    //
                    if (Inventory.GetPlayerItemFromInventory(Client, 13) >= 1)
                    {
                        // 
                        Client.SetData<dynamic>("RefinandoTime", Client.GetData<dynamic>("RefinandoTime") + 5);
                       // Client.TriggerEvent("SetProgressBar", Client.GetData<dynamic>("RefinandoTime"), "tasfiye namak - " + sals_a_ser_refinados + " de " + sals + "");

                        if (Client.GetData<dynamic>("RefinandoTime") > 100)
                        {
                            if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 13, 1, Inventory.Max_Inventory_Weight(Client)) == true)
                            {
                                return;
                            }
                            //
                            sals_a_ser_refinados += 1;

                            // Remove o Sal e conta tudo novamente.
                            Inventory.RemoveItemByType(Client, 13, 1);
                            Inventory.GiveItemToInventory(Client, 14, 2);

                            //
                            Client.SetData<dynamic>("RefinandoTime", 0);
                         //   Client.TriggerEvent("SetProgressBar", Client.GetData<dynamic>("RefinandoTime"), "tasfiye namak - " + sals_a_ser_refinados + " de " + sals + "");
                            Main.StartProgressBar(Client, 20, "salt");

                            //
                            Client.TriggerEvent("createNewHeadNotificationAdvanced", "Prerada soli je gotova!");

                            //
                            if (Inventory.GetPlayerItemFromInventory(Client, 13) == 0)
                            {
                                if (Salt.sal_timer[Main.getIdFromClient(Client)] != null)
                                {
                                    Salt.sal_timer[Main.getIdFromClient(Client)].Kill();
                                    Salt.sal_timer[Main.getIdFromClient(Client)] = null;
                                }
                                Client.SetData<dynamic>("ForceAnim", false);
                                Client.StopAnimation();
                                Client.TriggerEvent("freezeEx", false);
                                Client.SetData<dynamic>("Refinando", false);
                                Client.TriggerEvent("freezeEx", false);
                                Main.DestroyProgressBar(Client);
                            }
                        }
                    }
                    else
                    {
                        //
                        if (Client.GetData<dynamic>("Refinando") == true)
                        {
                            if (Salt.sal_timer[Main.getIdFromClient(Client)] != null)
                            {
                                Salt.sal_timer[Main.getIdFromClient(Client)].Kill();
                                Salt.sal_timer[Main.getIdFromClient(Client)] = null;
                            }
                            Client.StopAnimation();
                            Client.SetData<dynamic>("Refinando", false);
                            Client.TriggerEvent("freezeEx", false);
                            Main.DestroyProgressBar(Client);
                        }
                    }
                    if (Client.GetData<dynamic>("status") == false)
                    {
                        try
                        {
                            sal_timer[Main.getIdFromClient(Client)].Kill();
                            sal_timer[Main.getIdFromClient(Client)] = null;
                        }
                        catch (Exception)
                        {

                        }
                    }
                }, 1000, 0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }
            else if (Client.GetData<dynamic>("Refinando") == true)
            {
                if (sal_timer[Main.getIdFromClient(Client)] != null)
                {
                    sal_timer[Main.getIdFromClient(Client)].Kill();
                    sal_timer[Main.getIdFromClient(Client)] = null;
                }
                Client.StopAnimation();
                Client.SetData<dynamic>("Refinando", false);
                Client.TriggerEvent("freezeEx", false);
                Main.DestroyProgressBar(Client);
            }
        }

        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(1134.348, -1304.325, 34.67915), 3.0f))
        {
            if (Inventory.GetPlayerItemFromInventory(Client, 14) > 0)
            {
                InteractMenu.User_Input(Client, "input_sell_salt", "Prodaja preradjene soli", Inventory.GetPlayerItemFromInventory(Client, 14).ToString(), "Imate " + Inventory.GetPlayerItemFromInventory(Client, 14) + "", "g soli");
            }
            else
            {
                InteractMenu_New.SendNotificationError(Client, "Nemate preradjenu so.");
            }
        }

    }

}

