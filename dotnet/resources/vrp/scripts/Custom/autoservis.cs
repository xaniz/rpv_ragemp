using GTANetworkAPI;
using System.Collections.Generic;
using System;

class autoservis : Script
{
    public static List<Vector3> carfix = new List<Vector3>()
    {
        new Vector3(732.5282, -1088.9098, 22.168987),
        new Vector3(-1154.8661, -2006.4633, 13.180249),
        new Vector3(110.84247, 6626.2925, 31.787214),
    };
    public autoservis()
    {
        foreach (var pos in carfix)
        {
            NAPI.TextLabel.CreateTextLabel("Auto Servis~n~~n~~g~$5000 ~n~~n~~w~[~y~ E ~w~]", pos, 12, 0.3500f, 4, new Color(221, 255, 0, 255));

            
            Entity temp_blip;
            temp_blip = NAPI.Blip.CreateBlip(pos);
            NAPI.Blip.SetBlipName(temp_blip, "Auto Servis");
            NAPI.Blip.SetBlipSprite(temp_blip, 72);
            NAPI.Blip.SetBlipColor(temp_blip, 12);
            NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);
        }

    }

    [RemoteEvent("fixcarlsc")]
    public static void fixcarlsc(Player client)
    {
        
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(client))
            {
            if(!client.IsInVehicle) return;
            Vehicle veh = client.Vehicle;
            if (!veh.Exists) return;
            veh.Repair();
            Main.GivePlayerMoney(client, -5000);
            Main.GiveCompanyMoney(8, 150);
            client.TriggerEvent("Hide_Crafting_System");
            }
        }, delayTime: 6000);
    }
    public static void keypresse(Player client)
    {
        foreach (var v in carfix)
        {
            if (Main.IsInRangeOfPoint(client.Position, v, 5))
            {
                if(client.IsInVehicle)
                {
                    if(Main.GetPlayerMoney(client) < 5000)
                    {
                        Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca!");
                        return;
                    }
                    client.TriggerEvent("Display_carfix");
                    
                }
                else{
                    return;
                }
            }
        }
    }
}