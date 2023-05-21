using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Threading;

public class Mining:Script
{
    public static int Deafult_Reset_Mining_Job_Timer = 1200;

    public static List<Mining_info> Mining_List = new List<Mining_info>();

    List<Vector3> RcokPos = new List<Vector3> {
    new Vector3(-588.51,2064.16,130),
    new Vector3(-587,2044,129),
    new Vector3(-581.75,2039.36,128),
    new Vector3(-581.46,2034.16,128),
    new Vector3(-576.60,2031.92,127.4),
    new Vector3(-572.43,2022.63,127),
    new Vector3(-560.55,2009.7,126.3),
    new Vector3(-554.28,1999.13,126.3),
    new Vector3(-549.47,1996.45,126.1),
    new Vector3(-545.698,1981.62,126.1),
    new Vector3(-541.55,1973.6,126),
    new Vector3(-540.62,1965.07,126),
    new Vector3(-538.37,1983.185,126.2),
    new Vector3(-533.78,1982.36,126),
    new Vector3(-531.194,1979.181,126.2),
    new Vector3(-565.754, 2019.35, 126.22),
    new Vector3(-541.584, 1955.32, 126.52),
    new Vector3(-536.325, 1944.32, 125.52),
    new Vector3(-536.46, 1934.28, 125.52),
    new Vector3(-533.46, 1924.28, 124.52),
    new Vector3(-537.69, 1913.818, 124.52),
    new Vector3(-541.93, 1905.777, 123.52),
    new Vector3(-548.233, 1895.367, 123.52),
    new Vector3(-548.233, 1895.367, 123.52),
    new Vector3(-556.901, 1891.8528, 123.52),
    new Vector3(-561.677, 1886.4138, 122.52),
    new Vector3(-534.227, 1901.6638, 123.52),
    new Vector3(-527.817, 1900.8008, 123.52),
    new Vector3(-521.1927, 1894.857, 122.52),
    new Vector3(-509.5927, 1894.8324, 121.52),
    new Vector3(-501.5927, 1892.8324, 120.52),
    new Vector3(-494.5927, 1895.1224, 120.52),
    new Vector3(-486.5927, 1893.364, 120.52),
    new Vector3(-523.6627, 1980.664, 120.52),
    new Vector3(-516.166, 1977.932, 126.52),
    new Vector3(-507.9166, 1980.3062, 126.52),
    new Vector3(-496, 1979.3062, 125.52),
    new Vector3(-490, 1985.3862, 124.52),
    new Vector3(-477.381, 1987.3762, 123.52),
    new Vector3(-469.929, 1993.0432, 123.52),
    new Vector3(-461.081, 1996.8762, 123.52),
    new Vector3(-457.061, 2004.3462, 123.52),
    new Vector3(-445.831, 2012.0962, 123.52),
    new Vector3(-450.235, 2021.086, 123.52),
    new Vector3(-449.6075, 2030.3886, 123.52),
    new Vector3(-454.6905, 2039.1473, 122.52),
    new Vector3(-455.8431, 2047.2453, 122.52),
    new Vector3(-455.8431, 2047.2453, 122.52),
    new Vector3(-463.6421, 2056.5493, 121.52),
    new Vector3(-465.9621, 2068.4123, 120.52),
    new Vector3(-465.9621, 2068.4123, 120.52),
    new Vector3(-471.5121, 2078.1145, 120.52),
    new Vector3(-471.5121, 2078.1145, 120.52),
    new Vector3(-452.7521, 2056.2092, 122.52),
    new Vector3(-450.2911, 2059.6123, 122.52),
    new Vector3(-431.0211, 2063.9923, 121.52),
    new Vector3(-423.3611, 2063.8453, 120.52)

    };
    // 65% Iron
    // 15% Copper
    // 10% Silver
    // 8% Gold
    // 2% Platinum
    public enum Price //28 iron 7 copper  5 silver 4  1   // 27kg
    {
        Gvozdje = 160,
        Srebro = 400,
        Bakar = 220,
        Zlato = 1000,
        Platinum = 1900
    }
    public class Mining_info
    {
        public Vector3 Rock_Pos;
        public bool isbusy = false;
        public bool isready = true;
        public TextLabel TextLabel;
        public ColShape ColShape;
        public GTANetworkAPI.Object Object;
        public int Rtimer = Deafult_Reset_Mining_Job_Timer;
        public TimerEx timer;
    }


    public Mining()
    {

        int count = 0;
        foreach (var rock in RcokPos)
        {

            TextLabel txt = NAPI.TextLabel.CreateTextLabel("~y~[~g~Y~y~]~w~", rock + new Vector3(0, 0, 1.5), 5, 2, 2, new Color(221, 255, 0, 255), false, 0);
            ColShape col = NAPI.ColShape.CreateCylinderColShape(rock, 1.5f, 1.5f, 0);
            col.SetData<dynamic>("coljob", "Mining");
            GTANetworkAPI.Object gg = API.Shared.CreateObject(2139496847, rock, new Vector3(0, 0, 0), 0);
            Mining_List.Add(new Mining_info { Rock_Pos = rock, TextLabel = txt, isbusy = false, ColShape = col, Object = gg, Rtimer = Deafult_Reset_Mining_Job_Timer });
            count++;
        }

        NAPI.TextLabel.CreateTextLabel("Rudar~n~~w~[~y~ Y ~w~]", new Vector3(-594.50, 2091.51, 131.56), 12, 0.3500f, 4, new Color(221, 255, 0, 255));

        NAPI.TextLabel.CreateTextLabel("Prodaja rude ~n~~w~[~y~ Y ~w~]", new Vector3(1081.72, -1948.63, 31.01), 12, 0.3500f, 4, new Color(221, 255, 0, 255));

        Entity temp_blip;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-596, 2088, 131.34));
        NAPI.Blip.SetBlipName(temp_blip, "*Rudar");
        NAPI.Blip.SetBlipSprite(temp_blip, 618);
        NAPI.Blip.SetBlipColor(temp_blip, 21);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1082.148, -1948, 31));
        NAPI.Blip.SetBlipName(temp_blip, "Prodaja rude");
        NAPI.Blip.SetBlipSprite(temp_blip, 374);
        NAPI.Blip.SetBlipColor(temp_blip, 21);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        ResetTimer();
    }

    [RemoteEvent("rudarjobs")]
    public static void rudarjobs(Player Client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        
                        Client.TriggerEvent("Hide_Crafting_System");
                        Client.SetData("kramp", true);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Zapoceli ste posao");
                        if (Inventory.GetPlayerItemFromInventory(Client, 42) <= 0)
                        {
                            Inventory.GiveItemToInventory(Client, 42, 1);
                        }
                        
                        break;
                    }
                case 1:
                    {
                        Client.TriggerEvent("Hide_Crafting_System");
                        Client.SetData("kramp", false);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Zavrsili ste posao");
                        int mbusi = Inventory.GetPlayerItemFromInventory(Client, 42);
                        if (Inventory.GetPlayerItemFromInventory(Client, 42) >= 1)
                        {
                            Inventory.RemoveItemByType(Client, 42, mbusi);
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

    [ServerEvent(Event.PlayerEnterColshape)]
    public void EnterColshape(ColShape col, Player player)
    {
        if (col.HasData("coljob") && col.GetData<dynamic>("coljob") == "Mining" && player.GetData<dynamic>("kramp") == true)
        {
            player.SetData<dynamic>("CanMine", true);
        }
    }
    [ServerEvent(Event.PlayerExitColshape)]
    public void ExistColshape(ColShape col, Player player)
    {
        if (col.HasData("coljob") && col.GetData<dynamic>("coljob") == "Mining" && player.HasData("CanMine"))
        {
            player.SetData<dynamic>("CanMine",false);
        }
    }


    public void ResetTimer()
    {
        try
        {


            TimerEx.SetTimer(() =>
            {
                foreach (var item in Mining_List)
                {
                    if (item.Rtimer <= 4 && !item.Object.Exists)
                    {

                      
                        int t = Deafult_Reset_Mining_Job_Timer / (int)Math.Ceiling(((decimal)NAPI.Pools.GetAllPlayers().Count / 10) + (decimal)0.01);
                       
                        if (t < 400)
                        {
                            t = 300;
                        }

                        item.Rtimer = t;
                        item.isready = true;
                       
                        TextLabel txt = NAPI.TextLabel.CreateTextLabel("Stena", item.Rock_Pos +new Vector3(0, 0, 1.5), 5, 2, 2, new Color(221, 255, 0, 255), false, 0);
                        GTANetworkAPI.Object gg = API.Shared.CreateObject(2139496847, item.Rock_Pos, new Vector3(0, 0, 0),255,0);

                        item.TextLabel = txt;
                        item.Object = gg;
                        item.isbusy = false;
                    }
                    else if (!item.Object.Exists)
                    {

                        item.Rtimer = item.Rtimer - 5;
                    }
                }

            }, 5000, 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }
    }

    [Command("stopmine")]
    public void StopMining(Player player)
    {
        foreach (var item in Mining_List)
        {
            if (player.GetData<dynamic>("InColshape") != null && item.ColShape.Handle == ((ColShape)player.GetData<dynamic>("InColshape")).Handle)
            {
                if (player.GetData<dynamic>("IsMining") == true)
                {
                    Main.DestroyProgressBar(player);
                    item.isbusy = false;
                    player.SetData<dynamic>("ForceAnim", false);
                    player.TriggerEvent("freezeEx", false);
                    player.SetData<dynamic>("IsMining",false);
                    BasicSync.DetachObject(player);
                    player.StopAnimation();
                    item.timer.Kill();

                }
            }
        }
    }

    public static void PressKeyY(Player player)
    {
        if (player.HasData("CanMine") && player.GetData<dynamic>("CanMine") == true)
        {
            if (Inventory.GetPlayerItemFromInventory(player, 42) <= 0) { Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate opremu za rudarenje, zapocnite posao"); return; }
            foreach (var item in Mining_List)
            {
                if (player.GetData<dynamic>("InColshape") != null && item.ColShape.Handle == ((ColShape)player.GetData<dynamic>("InColshape")).Handle)
                {

                    //Main.DisplaySubtitle(player, "Start Mining...", 3);
                    if (item.isready == false) { Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Ovde nema kamena."); return; }
                    if (item.isbusy == true) { Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Neko vec kopa ovde."); return; }
                    Main.StartProgressBar(player,  60,"miner");
                    item.isbusy = true;
                    player.SetData<dynamic>("ForceAnim", true);
                    player.TriggerEvent("freezeEx", true);
                    
                    //  player.PlayAnimation("amb@world_human_const_drill@male@drill@base", "base", (int)animationCommands.AnimationFlags.Loop);
                      animationCommands.OnPlayAnimationFromMenu(player, "amb@world_human_const_drill@male@drill@base", "base", 39);
                    //player.PlayScenario("WORLD_HUMAN_CONST_DRILL");

                    BasicSync.AttachObjectToPlayer(player, NAPI.Util.GetHashKey("prop_tool_jackham"), 60309, new Vector3(0.0, 0.0, 0), new Vector3(0, 0, 0));

                    player.SetData<dynamic>("IsMining", true);

                    item.timer = TimerEx.SetTimer(()=>
                    {
                        if (!player.Exists) { item.isbusy = false; item.timer.Kill(); return; }
                        if (player.HasData("ForceAnim") && player.GetData<dynamic>("ForceAnim") == false) return;

                        if (Inventory.GetPlayerItemFromInventory(player, 42) <= 0) { item.isbusy = false; item.timer.Kill(); return; }

                        item.Object.Delete();
                        item.TextLabel.Delete();
                        item.isready = false;
                        player.TriggerEvent("freezeEx", false) ;

                        item.isbusy = false;
                        BasicSync.DetachObject(player);

                      
                        player.SetData<dynamic>("CanMine",false);
                        int t = Deafult_Reset_Mining_Job_Timer / (int)Math.Ceiling(((decimal)NAPI.Pools.GetAllPlayers().Count / 30) );

                        if (t < 120)
                        {
                            t = 120;
                        }
                        item.Rtimer = t;


                        player.TriggerEvent("createNewHeadNotificationAdvanced", "~g~+ ~y~skill");
                        Jobmanager.addskill(player);
                        player.StopAnimation();
                        player.SetData<dynamic>("IsMining",false);
                        player.SetData<dynamic>("ForceAnim",false);
                        Random random = new Random();
                        int rr = random.Next(0, 101);
                        // 50% Gvozdje
                        // 16% Bakar
                        // 15% Srebro
                        // 9% Kevlar
                        // 8% Zlato
                        // 2% Platina
                        switch (rr)
                        {
                            case int n when (n >= 51):
                                Inventory.GiveItemToInventory(player, 37, 1);
                                break;
                            case int n when (n >= 36 && n <= 50):
                                Inventory.GiveItemToInventory(player, 38, 1);
                                break;
                            case int n when (n >= 21 && n <= 35):
                                Inventory.GiveItemToInventory(player, 39, 1);
                                break;
                            case int n when (n >= 10 && n <= 20):
                                if(player.GetData<dynamic>("jobskill") >= 149)
                                {
                                    Inventory.GiveItemToInventory(player, 52, 1);
                                }else{
                                    Inventory.GiveItemToInventory(player, 37, 1);
                                }
                                
                                break;
                            case int n when (n >= 2 && n <= 9):
                                Inventory.GiveItemToInventory(player, 40, 1);
                                break;
                            case int n when (n == 0 || n == 1):
                                Inventory.GiveItemToInventory(player, 41, 1);
                                break;
                            default:
                                break;
                        }
                    },60000,1);
                    return;
                }
            }


        }
        else if (Main.IsInRangeOfPoint(player.Position, new Vector3(1082, -1949, 31), 2))
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            if (Inventory.GetPlayerItemFromInventory(player, 37) > 0)
            {
                menu_item_list.Add(new { Type = 1, Name = "Gvozdje", RightLabel = "~g~$" + (int)Price.Gvozdje });
            }
            if (Inventory.GetPlayerItemFromInventory(player, 38) > 0)
            {
                menu_item_list.Add(new { Type = 1, Name = "Bakar", RightLabel = "~g~$" + (int)Price.Bakar });
            }
            if (Inventory.GetPlayerItemFromInventory(player, 39) > 0)
            {
                menu_item_list.Add(new { Type = 1, Name = "Srebro", RightLabel = "~g~$" + (int)Price.Srebro });
            }
            if (Inventory.GetPlayerItemFromInventory(player, 40) > 0)
            {
                menu_item_list.Add(new { Type = 1, Name = "Zlato", RightLabel = "~g~$" + (int)Price.Zlato });
            }
            if (Inventory.GetPlayerItemFromInventory(player, 41) > 0)
            {
                menu_item_list.Add(new { Type = 1, Name = "Platinum", RightLabel = "~g~$" + (int)Price.Platinum });
            }

            if (menu_item_list.Count >= 1)
            {
                InteractMenu.CreateMenu(player, "Factory_Sell_Select_2", "Topionica", "~g~" + "Prodaja rude", false, NAPI.Util.ToJson(menu_item_list), false);
                return;
            }
            Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate rudu!");
        }
    }
}
