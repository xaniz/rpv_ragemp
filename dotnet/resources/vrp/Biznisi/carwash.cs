using GTANetworkAPI;
using System.Collections.Generic;
using System;

class autowash : Script
{
    public static List<Vector3> autowashc = new List<Vector3>()
    {
        new Vector3(169.35277, -1716.7372, 30.713871),
        new Vector3(-699.6383, -933.69025, 19.013887),
        new Vector3(31.486132, -1391.905, 29.362007),

    };
    public autowash()
    {
        foreach (var pos in autowashc)
        {
            NAPI.TextLabel.CreateTextLabel("Perionica~n~~n~~g~$100 ~n~~n~~w~[~y~ E ~w~]", pos, 12, 0.3500f, 4, new Color(221, 255, 0, 255));

            
            Entity temp_blip;
            temp_blip = NAPI.Blip.CreateBlip(pos);
            NAPI.Blip.SetBlipName(temp_blip, "Perionica");
            NAPI.Blip.SetBlipSprite(temp_blip, 100);
            NAPI.Blip.SetBlipColor(temp_blip, 53);
            NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);
        }

    }

    [RemoteEvent("carwashes")]
    public static void carwashes(Player client)
    {
        
        NAPI.Task.Run(() =>
        {
            if (NAPI.Player.IsPlayerConnected(client))
            {
            Vehicle veh = client.Vehicle;
            client.TriggerEvent("VehStream_SetVehicleDirtLevel", veh, 0.0f);
            Main.GivePlayerMoney(client, -100);
            client.TriggerEvent("Hide_Crafting_System");
            if (client.GetData<dynamic>("zadatak3") == true)
            {
                client.SetData("zadatak3", false);
                Main.GivePlayerEXP(client, 300);
                Main.GivePlayerMoney(client, 3000);
                Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste dnevni zadatak");
            }
            }
        }, delayTime: 6000);
    }
    public static void keypresse(Player client)
    {
        foreach (var v in autowashc)
        {
            if (Main.IsInRangeOfPoint(client.Position, v, 5))
            {
                if(client.IsInVehicle)
                {
                    if(Main.GetPlayerMoney(client) < 100)
                    {
                        Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca!");
                        return;
                    }
                    client.TriggerEvent("Display_carwash");
                    
                }
                else{
                    return;
                }
            }
        }
    }
}