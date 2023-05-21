using GTANetworkAPI;
using System;
using System.Collections.Generic;

public class ihacker : Script 
{
    public ihacker()
    {
        NAPI.TextLabel.CreateTextLabel("Haker~n~~w~[~y~ Y ~w~]", new Vector3(1272.18, -1712.11, 55.27), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
    }

    internal class Checkpoint
    {
        public Vector3 Position { get; }
        public double Heading { get; }

        public Checkpoint(Vector3 pos)
        {
            Position = pos;
        }
    }

    private static List<Checkpoint> Checkpoints = new List<Checkpoint>()
    {
        new Checkpoint(new Vector3(147.80156, -1035.431, 29.343037)),
        new Checkpoint(new Vector3(-30.213848, -723.7574, 44.2287)),
        new Checkpoint(new Vector3(-866.55695, -187.8295, 37.8343)),
        new Checkpoint(new Vector3(-821.60126, -1082.0297, 11.132424)),
        new Checkpoint(new Vector3(1166.9357, -456.15555, 66.79606)),
        new Checkpoint(new Vector3(380.7676, 323.47824, 103.566345)),
        new Checkpoint(new Vector3(-165.0728, 234.78185, 94.921974)),
        new Checkpoint(new Vector3(1138.3251, -468.90997, 66.731766)),
        new Checkpoint(new Vector3(158.51376, 233.90454, 106.62664)),
        new Checkpoint(new Vector3(-2958.9675, 487.82336, 15.465211)),
        new Checkpoint(new Vector3(33.111187, -1348.1604, 29.497019)),
        new Checkpoint(new Vector3(296.38324, -894.13947, 29.230345)),
        new Checkpoint(new Vector3(-2072.4417, -317.2809, 13.315808)),
    };


    [RemoteEvent("ihackerjobs")]
    public static void ihackerjobs(Player client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        if (client.GetData<dynamic>("ihackerjob") == true)
                        {
                            Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec ste zapoceli posao, morate ga zavrsiti!");
                            return;
                        }
                        var col = NAPI.ColShape.CreateCylinderColShape(new Vector3(1272.18, -1712.11, 55.27), 1, 2, 0);
                        col.OnEntityEnterColShape += (shape, player) => {
                            try
                            {
                                player.SetData("INTERACTIONCHECK", 8);
                            }
                            catch (Exception ex)
                            {
                                Console.Write(ex);
                            }
                        };
                        col.OnEntityExitColShape += (shape, player) => {
                            try
                            {
                                player.SetData("INTERACTIONCHECK", 0);
                            }
                            catch (Exception ex)
                            {
                                Console.Write(ex);
                            }
                        };
                        
                        int i = 0;
                        foreach (var Check in Checkpoints)
                        {
                            col = NAPI.ColShape.CreateCylinderColShape(Check.Position, 1, 2, 0);
                            col.SetData("NUMBER", i);
                            col.OnEntityEnterColShape += PlayerEnterCheckpoint;
                            i++;
                        }
                        string playername = AccountManage.GetCharacterName(client);
                    
                        Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Zapoceli ste posao!");
                        client.SetData("ihackerjob", true);
                        Random rnd = new Random();
                        var check = rnd.Next(0, Checkpoints.Count - 1);
                        client.SetData("WORKCHECK", check);
                        Trigger.ClientEvent(client, "createCheckpoint", 15, 1, Checkpoints[check].Position, 1, 0, 221, 255, 0);
                        Trigger.ClientEvent(client, "createWorkBlip", Checkpoints[check].Position);
                        break;
                    }
                case 1:
                    {
                        if (client.HasData("ihackerjob"))
                        {
                            Main.DisplayErrorMessage(client, NotifyType.Info, NotifyPosition.BottomCenter, "Zavrsili ste posao!");
                            
                            client.SetData<dynamic>("ihackerjob", false);
                            Trigger.ClientEvent(client, "deleteCheckpoint", 15);
                            Trigger.ClientEvent(client, "deleteWorkBlip");
                        }
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private static void PlayerEnterCheckpoint(ColShape shape, Player player)
    {
        try
        {
            
            if (shape.GetData<int>("NUMBER") != player.GetData<int>("WORKCHECK")) return;

            if (Checkpoints[(int)shape.GetData<int>("NUMBER")].Position.DistanceTo(player.Position) > 3) return;
            if (player.IsInVehicle)
            {
                return;
            } 
                Random rnd = new Random();
                int rndnumber = rnd.Next(1, 3);
                Random crnd = new Random();
                int crndnumber = crnd.Next(2, 4);
                NAPI.Task.Run(() => {
                    try
                    {
                        if (NAPI.Player.IsPlayerConnected(player))
                        {
                            player.TriggerEvent("CircuitBreakerStart", 3, rndnumber, crndnumber);
                            player.SetData("WORKCHECK", -1);
                            Random rnd2 = new Random();
                            var nextCheck = rnd2.Next(0, Checkpoints.Count - 1);
                            while (nextCheck == shape.GetData<int>("NUMBER")) nextCheck = rnd2.Next(0, Checkpoints.Count - 1);
                            player.SetData("WORKCHECK", nextCheck);
                            Trigger.ClientEvent(player, "createCheckpoint", 15, 1, Checkpoints[nextCheck].Position, 1, 0, 221, 255, 0);
                            Trigger.ClientEvent(player, "createWorkBlip", Checkpoints[nextCheck].Position);
                        
                        }
                            
                    }
                    catch { }
                }, 4000);

        } catch (Exception e) { Console.WriteLine(e); }
    }

    public static void illegalhackerwin(Player player)
    {
        Inventory.GiveItemToInventory(player, 64, 2);
    }

    [RemoteEvent("CircuitBreakerLOSE")]
    public static void CircuitBreakerLOSE(Player player)
    {
        if (player.GetData<dynamic>("ihackerjob") == true)
        {
            Random rnd = new Random();
            int randsansa = rnd.Next(1, 10);
            if (randsansa == 5)
            {
                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if (target.GetData<dynamic>("status") == true && AccountManage.GetPlayerGroup(target) == 1)
                    {
                        Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "Neko je upravo pokusao da hakuje uredjaj");
                        Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "Lokacija pokusaja hakovanja je oznacena na mapi.");
                        Trigger.ClientEvent(target, "createWorkBlip", player.Position);
                        NAPI.Task.Run(() => {
                        try
                        {
                            if (NAPI.Player.IsPlayerConnected(target))
                            {
                            Trigger.ClientEvent(target, "createWorkBlip", player.Position);
                            }
                        }catch { }
                        }, 20000);
                        NAPI.Task.Run(() => {
                        try
                        {
                            if (NAPI.Player.IsPlayerConnected(target))
                            {
                            Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "Lokacija hakera je azurirana");
                            Trigger.ClientEvent(target, "createWorkBlip", player.Position);
                            }
                        }catch { }
                        }, 40000);
                        NAPI.Task.Run(() => {
                        try
                        {
                            if (NAPI.Player.IsPlayerConnected(target))
                            {
                            Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "[CENTRALA]", "" + Main.EMBED_BLUE + "Lokacija hakera izgubljena");
                            
                            Trigger.ClientEvent(target, "deleteWorkBlip");
                            }
                        }catch { }
                        }, 50000);
                    }
                }
            }
        }
        else {
            return;
        }
        
    }
    
}