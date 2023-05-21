using GTANetworkAPI;
using System;
using System.Collections.Generic;

public class pilicar:Script
{
    public pilicar()
    {
        NAPI.TextLabel.CreateTextLabel("Pilicar~n~~w~[~y~ Y ~w~]", new Vector3(-68.16, 6255.84, 30.59), 12, 0.3500f, 4, new Color(221, 255, 0, 255));

        Entity temp_blip;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-68.16, 6255.84, 30.59));
        NAPI.Blip.SetBlipName(temp_blip, "*Pilicar");
        NAPI.Blip.SetBlipSprite(temp_blip, 497);
        NAPI.Blip.SetBlipColor(temp_blip, 5);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
    }
    public enum AnimationFlags
    {
        Loop = 1 << 0,
        StopOnLastFrame = 1 << 1,
        OnlyAnimateUpperBody = 1 << 4,
        AllowPlayerControl = 1 << 5,
        Cancellable = 1 << 7
    }

    [RemoteEvent("pilicarjobs")]
    public static void pilicarjobs(Player Client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Zapoceli ste posao");
                        Client.SetData("pilicarstart", true);
                        NAPI.TextLabel.CreateTextLabel("Uzmi pile~n~~w~[~y~ E ~w~]", new Vector3(-70.31, 6248.52, 31.07), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
                        NAPI.Marker.CreateMarker(1, new Vector3(-70.31, 6248.52, 31.07 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));
                        NAPI.TextLabel.CreateTextLabel("Preradi pile~n~~w~[~y~ E ~w~]", new Vector3(-78.169205, 6229.346, 31.091816), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
                        NAPI.Marker.CreateMarker(1, new Vector3(-78.169205, 6229.346, 31.091816 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));
                        NAPI.TextLabel.CreateTextLabel("Spakuj pile~n~~w~[~y~ E ~w~]", new Vector3(-101.81113, 6208.7236, 31.025015), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
                        NAPI.Marker.CreateMarker(1, new Vector3(-101.81113, 6208.7236, 31.025015 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));
                        break;
                    }
                case 1:
                    {
                        Client.TriggerEvent("Hide_Crafting_System");
                        Client.SetData("pilicarstart", false);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste posao");
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static void UzmiPile(Player client)
    {
        if (client.GetData<dynamic>("uzeopile") == true)
        {
            return;
        }
        client.Position = new Vector3(-70.06, 6248.64, 30.47);
        client.Rotation = new Vector3(0, 0, -54.54);
        NAPI.Player.PlayPlayerAnimation(client, (int)(AnimationFlags.Loop), "mini@repair", "fixing_a_ped");
        client.SetData<dynamic>("uzeopile", true);
        NAPI.Task.Run(() => {
        try
        {
            if (NAPI.Player.IsPlayerConnected(client))
            {
            Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste pile, odnesite ga na preradu");
            client.StopAnimation();
            }
        }
        catch { }
        }, 4000);
    }

    public static void PreradiPile(Player client)
    {

        if (client.GetData<dynamic>("uzeopile") == true)
        {
            client.Position = new Vector3(-78.20, 6229.39, 30.47);
            client.Rotation = new Vector3(0, 0, 122.49);
            client.SetData<dynamic>("preradiopile", true);
            NAPI.Player.PlayPlayerAnimation(client, (int)(AnimationFlags.Loop), "switch@franklin@cleaning_car", "001946_01_gc_fras_v2_ig_5_base");
            NAPI.Task.Run(() => {
            try
            {
                if (NAPI.Player.IsPlayerConnected(client))
                {
                Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Preradili ste pile,sada ga odnesite ga na pakovanje");
                
                client.SetData<dynamic>("uzeopile", false);
                client.StopAnimation();
                }
            }
            catch { }
            }, 8000);
        }
    }

    public static void SpakujPile(Player client)
    {
        if (client.GetData<dynamic>("preradiopile") == true)
        {
            client.Position = new Vector3(-101.96, 6208.87, 30.47);
            client.Rotation = new Vector3(0, 0, 41.62);
            client.SetData<dynamic>("preradiopile", false);
            NAPI.Player.PlayPlayerAnimation(client, (int)(AnimationFlags.Loop), "mini@repair", "fixing_a_ped");
            NAPI.Task.Run(() => {
            try
            {
                if (NAPI.Player.IsPlayerConnected(client))
                {
                Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Spakovali ste pile i dobili platu");
                
                if(client.GetData<dynamic>("jobskill") >= 149)
                {
                    Main.GivePlayerSalary(client, 28);
                }
                Main.GivePlayerSalary(client, 148);
                Jobmanager.addskill(client);
                client.StopAnimation();
                }
            }
            catch { }
            }, 8000);
        }
    }
}