using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Timers;


class ATMSystem : Script
{

    public static Timer atmpljackaTimer = new Timer(300000);
    public static bool atmpljacka = false;
    public static List<dynamic> atms = new List<dynamic>();

    public ATMSystem()
    {

        atms.Add(new { MarkerType = 1, position = new Vector3(2683.1, 3286.5, 55.2)});
        atms.Add(new { MarkerType = 1, position = new Vector3(237.7,216.9,106)});

        atms.Add(new { MarkerType = 1, position = new Vector3(-386.733, 6045.953, 31.501) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-283.037, 6226.385, 31.187) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-135.165, 6455.738, 31.101) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-110.753, 6467.703, 31.784) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-97.165, 6467.703, 31.101) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-95.4690, 6457.301, 31.784) });
        atms.Add(new { MarkerType = 1, position = new Vector3(155.4300, 6641.991, 31.784) });
        atms.Add(new { MarkerType = 1, position = new Vector3(174.6720, 6637.218, 31.784) });
        atms.Add(new { MarkerType = 1, position = new Vector3(1701.138, 6426.783, 32.730) });
        atms.Add(new { MarkerType = 1, position = new Vector3(1735.114, 6411.035, 35.164) });
        atms.Add(new { MarkerType = 1, position = new Vector3(1702.842, 4933.593, 42.051) });
        atms.Add(new { MarkerType = 1, position = new Vector3(1968.033, 3743.293, 32.272) });
        atms.Add(new { MarkerType = 1, position = new Vector3(1821.917, 3683.483, 34.244) });
        atms.Add(new { MarkerType = 1, position = new Vector3(1174.532, 2706.278, 38.027) });
        atms.Add(new { MarkerType = 1, position = new Vector3(540.0420, 2671.007, 42.177) });
        atms.Add(new { MarkerType = 1, position = new Vector3(2564.399, 2585.100, 38.016) });
        atms.Add(new { MarkerType = 1, position = new Vector3(2559.683, 350.6010, 108.050) });
        atms.Add(new { MarkerType = 1, position = new Vector3(2558.051, 389.4817, 108.660) });
        atms.Add(new { MarkerType = 1, position = new Vector3(1077.692, -775.796, 58.218) });
        atms.Add(new { MarkerType = 1, position = new Vector3(1138.018, -468.886, 66.789) });
        atms.Add(new { MarkerType = 1, position = new Vector3(1167.075, -456.241, 66.641) });
        atms.Add(new { MarkerType = 1, position = new Vector3(1153.884, -326.540, 69.245) });
        atms.Add(new { MarkerType = 1, position = new Vector3(380.8087, 323.4706, 103.56639) });
        //atms.Add(new { MarkerType = 1, position = new Vector3(236.4638, 217.4718, 106.840) });
        atms.Add(new { MarkerType = 1, position = new Vector3(265.0043, 212.1717, 106.780) });
        atms.Add(new { MarkerType = 1, position = new Vector3(285.57, 143.37, 104) });
        atms.Add(new { MarkerType = 1, position = new Vector3(158.63, 234.2, 106.45) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-164.568, 233.5066, 94.919) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-1827.04, 785.5159, 138.020) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-1409.39, -100.2603, 52.473) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-1410.2,-98.7,52.4) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-2072.41, -316.959, 13.345) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-2975.72, 379.7737, 14.992) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-2962.60, 482.1914, 15.762) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-2955.70, 488.7218, 15.486) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-3044.22, 595.2429, 7.595) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-3144.13, 1127.415, 20.868) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-3241.10, 996.6881, 12.500) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-3241.11, 1009.152, 12.877) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-1305.40, -706.240, 25.352) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-538.225, -854.423, 29.234) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-710.156, -818.958, 23.768) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-713.156, -818.958, 23.768) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-717.614, -915.880, 19.268) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-526.566, -1222.90, 18.434) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-256.231, -716.146, 33.444) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-258.231, -723.146, 33.444) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-203.548, -861.588, 30.205) });
        atms.Add(new { MarkerType = 1, position = new Vector3(111.4102, -775.162, 31.427) });
        atms.Add(new { MarkerType = 1, position = new Vector3(114.4102, -776.162, 31.427) });
        atms.Add(new { MarkerType = 1, position = new Vector3(112.9290, -818.710, 31.386) });
        atms.Add(new { MarkerType = 1, position = new Vector3(119.9000, -883.826, 31.191) });
        atms.Add(new { MarkerType = 1, position = new Vector3(146.82556, -1035.4731, 29.343958) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-846.304, -340.402, 38.687) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-1205.3568, -325.48877, 37.846462) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-56.1935, -1752.53, 29.452) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-261.692, -2012.64, 30.121) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-273.001, -2025.60, 30.197) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-351.534, -49.529, 49.042) });
        atms.Add(new { MarkerType = 1, position = new Vector3(24.589, -946.056, 29.357) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-254.112, -692.483, 33.616) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-1570.197, -546.651, 34.955) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-1415.909, -211.825, 46.500) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-1430.112, -211.014, 46.500) });
        atms.Add(new { MarkerType = 1, position = new Vector3(33.232, -1347.849, 29.497) });
        atms.Add(new { MarkerType = 1, position = new Vector3(129.216, -1292.347, 29.269) });
        atms.Add(new { MarkerType = 1, position = new Vector3(287.645, -1282.646, 29.659) });
        atms.Add(new { MarkerType = 1, position = new Vector3(289.012, -1256.545, 29.440) });
        atms.Add(new { MarkerType = 1, position = new Vector3(295.839, -896.640, 29.217) });
        atms.Add(new { MarkerType = 1, position = new Vector3(296.839, -894.640, 29.217) });
        atms.Add(new { MarkerType = 1, position = new Vector3(1686.753, 4815.809, 42.008) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-303.408, -829.945, 32.417) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-301.408, -829.945, 32.417) });
        atms.Add(new { MarkerType = 1, position = new Vector3(5.134, -919.949, 29.557) });
        atms.Add(new { MarkerType = 1, position = new Vector3(-2294.644, -356.459, 174.607) });
        foreach (var atm in atms)
        {
            NAPI.TextLabel.CreateTextLabel("Bankomat ~w~[ ~g~Y~w~ ]", atm.position, 16, 0.600f, 0, new Color(221, 255, 0, 150));
            //NAPI.Marker.CreateMarker(29, new Vector3(atm.position.X, atm.position.Y, atm.position.Z - -0.5), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

            Entity temp_blip;
            temp_blip = NAPI.Blip.CreateBlip(atm.position);
            NAPI.Blip.SetBlipName(temp_blip, "ATM");
            NAPI.Blip.SetBlipSprite(temp_blip, 434);
            NAPI.Blip.SetBlipColor(temp_blip, 25);
            NAPI.Blip.SetBlipScale(temp_blip, 0.3f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);

        }
    }

    public static void ATMShow(Player Client)
    {
        foreach (var atm in atms)
        {
            if (Main.IsInRangeOfPoint(Client.Position, atm.position, 3.0f))
            {
                // anim atm
                Client.StopAnimation();
                NAPI.Player.PlayPlayerAnimation(Client, 1, "anim@mp_atm@enter", "enter");
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(Client))
                    {
                    Client.StopAnimation();
                    Client.TriggerEvent("Display_newbank");
                    }
                }, delayTime: 4000);

                
            }
        }
    }

    public static void ATMRob(Player Client)
    {
        foreach (var atm in atms)
        {
            if (Main.IsInRangeOfPoint(Client.Position, atm.position, 3.0f))
            {
            
            if (atmpljacka == true)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Bankomati su vec opljackani");
                return;
            }
        
            if (Inventory.GetPlayerItemFromInventory(Client, 77) > 0)
            {
                // anim atm
                Client.StopAnimation();
                NAPI.Player.PlayPlayerAnimation(Client, 1, "melee@large_wpn@streamed_core", "car_down_attack");
                atmpljacka = true;
                BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("prop_ing_crowbar"), 60309, new Vector3(0.05, 0, 0.08), new Vector3(130, 10, 180.0000));
                NAPI.Task.Run(() =>
                {
                    if (NAPI.Player.IsPlayerConnected(Client))
                    {
                    if (Main.IsInRangeOfPoint(Client.Position, atm.position, 3.0f) && (Inventory.GetPlayerItemFromInventory(Client, 77) > 0))
                    {
                        
                        Random rnd = new Random();
                        int robmoney = rnd.Next(4000, 6500);
                        Main.GivePlayerMoney(Client, robmoney);
                        Police.SetPlayerCrime(Client, 1);
                        Client.StopAnimation();
                        BasicSync.DetachObject(Client);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Opljackali ste bankomat i uzeli $" + robmoney);
                        return;
                    }
                    else {
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Otisli ste daleko od bankomata");
                        Client.StopAnimation();
                        BasicSync.DetachObject(Client);
                        return;
                    }
                    }
                }, delayTime: 60000);


                atmpljackaTimer.Elapsed += (sender, e) => { atmpljacka = false; };
                atmpljackaTimer.Start();
            }
            }
        }
    }

    [RemoteEvent("BankWithdrawMoney")]
    public static void BankWithdrawMoney(Player Client, int amount)
    {
        int value = Convert.ToInt32(amount);

        if (value < 1 || value > 1000000)
        {
            Client.SendNotification("~r~Greska~n~~w~Iznos mora biti izmedju 1 i 1,000,000.");
            return;
        }
        if (Main.GetPlayerBank(Client) < value)
        {
            Client.SendNotification("~r~Greska~n~~w~Nemate toliko novca!");
            return;
        }
        double totalmoney = value * 0.05;
        double bizmoney = value * 0.01;
        int rounded = (int)Math.Round(totalmoney, 0);
        int rounded2 = (int)Math.Round(bizmoney, 0);
        Main.GivePlayerMoney(Client, value - rounded);
        Main.GivePlayerMoneyBank(Client, -value);
        Main.GiveCompanyMoney(3, rounded2);
        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Podigli ste "+ value.ToString("N0") + " sa racuna i platili porez "+rounded+"");

    }
    [RemoteEvent("BankDepositMoney")]
    public static void BankDepositMoney(Player Client, int amount)
    {
            int value = Convert.ToInt32(amount);

            if (value < 1 || value > 1000000)
            {
                Client.SendNotification("~r~Greska~n~~w~Iznos mora biti izmedju 1 i 1,000,000.");
                return;
            }
            if (Main.GetPlayerMoney(Client) < value)
            {
                Client.SendNotification("~r~Greska~n~~w~Nemate toliko novca.");
                return;
            }
            Main.GivePlayerMoney(Client, -value);
            Main.GivePlayerMoneyBank(Client, value);
            Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Ostavili ste "+ value.ToString("N0") + " na racun");
    }

    [RemoteEvent("BankTransfareMoney")]
    public static void BankTransfareMoney(Player Client, string idOrName, int amount)
    {
            Player target = Main.findPlayer(Client, idOrName);
            int value = Convert.ToInt32(amount);

            if (value < 1 || value > 1000000)
            {
                Client.SendNotification("~r~Greska~n~~w~Iznos mora biti izmedju 1 i 1,000,000.");
                return;
            }
            if (Main.GetPlayerBank(Client) < value)
            {
                Client.SendNotification("~r~Greska~n~~w~Nemate toliko novca.");
                return;
            }
            
            Main.GivePlayerMoneyBank(Client, -value);
            Main.GivePlayerMoneyBank(target, value);
            Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Poslali ste "+ value.ToString("N0") + "na racun " + target.Name +"");
            Main.DisplayErrorMessage(target, NotifyType.Info, NotifyPosition.BottomCenter, ""+target.Name +" vam je poslao "+ value.ToString("N0") + " na racun ");
    }
}
