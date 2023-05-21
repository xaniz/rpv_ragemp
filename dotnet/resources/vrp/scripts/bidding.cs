using GTANetworkAPI;
using System;
using System.Collections.Generic;

class bidding : Script
{

    private static System.Timers.Timer timer;

    public static int pbid = 0;
    public static bool bidstart = false;

    [Command("startbid", GreedyArg = true)]
    public static void StartBidCMD(Player client, int PocetnaCena, string ImeStvari)
    {
        if (AccountManage.GetPlayerAdmin(client) < 7)
        {
            Main.SendErrorMessage(client, "Niste ovlasceni!");
            return;
        }
        if (client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        string ImePonude = "server";
        bidstart = true;
        pbid = PocetnaCena;
        float distance = 50f;
        foreach (var player in NAPI.Player.GetPlayersInRadiusOfPlayer(distance, client))
        {
            player.SetData("canbid", true);
            NAPI.Chat.SendChatMessageToPlayer(player, "*******************LICITACIJA*******************");
            NAPI.Chat.SendChatMessageToPlayer(player, "LICITACIJA ZA ~b~"+ ImeStvari +" ~w~POCINJE!!!");
            NAPI.Chat.SendChatMessageToPlayer(player, "POCETNA CENA JE ~r~"+ PocetnaCena.ToString() +"~w~!!!");
            NAPI.Chat.SendChatMessageToPlayer(player, "*******************LICITACIJA*******************");
            player.TriggerEvent("createBiddingUI", ImePonude, PocetnaCena);
        }
    }

    [RemoteEvent("ExitAH")]
    public static void ExitAH(Player client)
    {
        client.SetData("canbid", false);
        client.TriggerEvent("Hide_Crafting_System");
    }

    [RemoteEvent("placeBid")]
    public static void PlaceBidEvent(Player client, int ponuda)
    {
            if (bidstart == true && client.GetData<dynamic>("status") == true)
            {
                if (client.HasData("Y_Timeout") && client.GetData<dynamic>("Y_Timeout") >= DateTimeOffset.Now.ToUnixTimeMilliseconds())
            {
                Main.DisplaySubtitle(client, "~y~[Antispam]", 2);
                return;
            }
            client.SetData<dynamic>("Y_Timeout", DateTimeOffset.Now.ToUnixTimeMilliseconds() + 1000);
            if (ponuda <= pbid)
            {
                Main.DisplayErrorMessage(client, NotifyType.Warning, NotifyPosition.BottomCenter, "Vasa ponuda je manja od trenutne ponude");
                return;
            }
            
            if (Main.GetPlayerBank(client) < ponuda)
            {
                Main.DisplayErrorMessage(client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu");
                return;
            }

            string ImeIgraca = AccountManage.GetCharacterName(client);
            
            pbid = ponuda;
            
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
            timer = new System.Timers.Timer(30000); 
            timer.Elapsed += (sender, e) =>
            {
                timer.Dispose();
                foreach (var target in NAPI.Pools.GetAllPlayers())
                {
                    if(target.GetData<dynamic>("canbid") == true)
                    {
                        target.SetData("canbid", false);
                        target.TriggerEvent("Hide_Crafting_System");
                    }
                }
                NAPI.Chat.SendChatMessageToAll("Aukcija je zavrsena! Najveca ponuda je bila: ~r~" + pbid + " ~w~od igraca~b~ "+AccountManage.GetCharacterName(client)+"");
                bidstart = false;
            };
            timer.Start();
            foreach (var target in NAPI.Pools.GetAllPlayers())
            {
                if (target.GetData<dynamic>("canbid") == true)
                {
                    NAPI.Chat.SendChatMessageToPlayer(target, "~b~" + AccountManage.GetCharacterName(client) + " ~w~je podigao cenu na: ~r~" + pbid + "~w~!");
                    target.TriggerEvent("Hide_Crafting_System");
                    target.TriggerEvent("updateBidUI", ImeIgraca, pbid);
                    if (timer != null)
                    {
                        timer.Stop();
                        timer.Dispose();
                    }
                    timer = new System.Timers.Timer(30000); 
                    timer.Elapsed += (sender, e) =>
                    {
                        timer.Dispose();
                        foreach (var t in NAPI.Pools.GetAllPlayers())
                        {
                            if (t.GetData<dynamic>("canbid") == true)
                            {
                                t.SetData("canbid", false);
                                t.TriggerEvent("Hide_Crafting_System");
                            }
                        }
                        NAPI.Chat.SendChatMessageToAll("Aukcija je zavrsena! Najveca ponuda je bila: ~r~" + pbid + " ~w~od igraca~b~ "+AccountManage.GetCharacterName(client)+"");
                        bidstart = false;
                        
                    };
                    timer.Start();
                }
            }
        }
    }
}