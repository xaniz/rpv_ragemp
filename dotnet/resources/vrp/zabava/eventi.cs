using GTANetworkAPI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using MySql.Data.MySqlClient;

public class events : Script
{

    private int maxPlayers = 8; // Change this to set the maximum number of players allowed in the race
    private int playerCount = 0;
    public static bool racestarted = false;
    private static List<Vector3> racecords1 = new List<Vector3>()
    {
        new Vector3(-864.7218, 5419.869, 35.0804),
        new Vector3(-655.2298, 5336.381, 62.265068),
        new Vector3(-877.96814, 5309.5464, 78.80465),
        new Vector3(-943.14557, 5258.7905, 82.40844),
        new Vector3(-744.5157, 5249.7305, 95.00451),
        new Vector3(-593.4206, 4997.035, 144.0349),
        new Vector3(-127.091576, 4608.8086, 124.51096),
        new Vector3(81.47465, 4559.4854, 97.041504),
        new Vector3(175.11397, 4421.259, 74.76436),
        new Vector3(425.17194, 4369.721, 63.22659),
        new Vector3(689.60034, 4243.5356, 55.14891),
        new Vector3(861.23425, 4243.48, 50.30164),
        new Vector3(1004.8003, 4428.564, 46.844963),
        new Vector3(1732.9142, 4571.4595, 39.90613),
    };
    private static List<Vector3> racecords2 = new List<Vector3>()
    {

        new Vector3(-4.634656, 6373.058, 31.31132),
        new Vector3(-810.3915, 5469.7397, 33.87128),
        new Vector3(-1851.3041, 4667.37, 57.001404),
        new Vector3(-2621.0679, 2890.2368, 16.684206),
        new Vector3(-2520.5227, -191.76817, 19.172167),
        new Vector3(-2214.2678, -344.62668, 13.346676),


    };

    private static List<Vector3> racecords3 = new List<Vector3>()
    {

        new Vector3(176.75, 3786.14, 28.91),
        new Vector3(-39.983273, 4115.8486, 29.657274),
        new Vector3(-375.61423, 4429.9116, 29.682013),
        new Vector3(-773.6419, 4443.4233, 14.296483),
        new Vector3(-1295.393, 4361.65, 4.6777954),
        new Vector3(-1817.2788, 4592.8364, -0.61321014),


    };
    private static List<Vector3> vehspawn1 = new List<Vector3>()
    {
        new Vector3(-892.0276, 5414.9995, 36.148117),
        new Vector3(-893.09894, 5419.51, 36.13714),
        new Vector3(-892.6037, 5417.483, 35.613533),
        new Vector3(-896.56274, 5416.302, 35.79304),
        new Vector3(-896.8367, 5418.6206, 35.77368),
        new Vector3(-896.027, 5414.068, 35.792274),
        new Vector3(-900.43787, 5416.851, 35.937927),
        new Vector3(-899.7579, 5414.6396, 35.93999),
    };
    private static List<Vector3> vehspawn2 = new List<Vector3>()
    {
        new Vector3(21.385313, 6403.69, 30.496122),
        new Vector3(29.458454, 6402.2227, 30.480112),
        new Vector3(28.43105, 6410.7603, 30.49615),
        new Vector3(36.89956, 6409.6826, 30.481052),
        new Vector3(35.519756, 6417.841, 30.498959),
        new Vector3(43.627975, 6416.3804, 30.482233),
        new Vector3(42.35289, 6424.708, 30.49912),
        new Vector3(50.516575, 6423.3184, 30.483421),

    };

    private static List<Vector3> vehspawn3 = new List<Vector3>()
    {
        new Vector3(173.24358, 3552.882, 29.52542),
        new Vector3(179.10309, 3550.9998, 29.5254),
        new Vector3(181.86649, 3558.4084, 29.524927),
        new Vector3(178.44334, 3560.8083, 29.525423),
        new Vector3(180.67273, 3567.4626, 29.52499),
        new Vector3(184.76762, 3568.6191, 29.52511),
        new Vector3(186.90181, 3575.0288, 29.524836),
        new Vector3(183.3554, 3578.7175, 29.524752),

    };



    [Command("createevent")]
    public void CreateEvent(Player c, string eventName, string imeVozila)
    {
        if (eventName == "sanchezcross" || eventName == "grandprix" || eventName == "wetrace")
        {
            if (c.GetData<dynamic>("admin_duty") == 0)
            {
                Main.SendErrorMessage(c, "Niste na duznosti, koristite /aduty!");
                return;
            }
            if (AccountManage.GetPlayerAdmin(c) > 6)
            {
                if (racestarted == true)
                {
                    c.SendChatMessage("Event je vec zapocet!");
                    return;
                }
                racestarted = true;
                c.SetData(eventName, true);
                VehicleHash vehHash = (VehicleHash)NAPI.Util.GetHashKey(imeVozila);
                NAPI.Chat.SendChatMessageToAll($"~r~{eventName}~w~ event je zapocet ~r~8 ~w~mesta slobodno, upisite ~g~/joinevent {eventName} ~w~da se pridruzite!");

                if (eventName == "sanchezcross")
                {
                    for (int i = 0; i < 8; i++)
                    {
                        var racveh = NAPI.Vehicle.CreateVehicle(vehHash, vehspawn1[i], new Vector3(0, 0, -77.37), 0, 0);
                        racveh.SetData("racveh", true);
                        racveh.Dimension = 10;
                        racveh.PrimaryColor = 138;
                        Main.SetVehicleFuel(racveh, 99.0);
                        
                    }
                }
                else if (eventName == "grandprix")
                {
                    for (int i = 0; i < 8; i++)
                    {
                        var racveh = NAPI.Vehicle.CreateVehicle(vehHash, vehspawn2[i], new Vector3(0, 0, 133.87), 0, 0);
                        racveh.SetData("racveh", true);
                        racveh.Dimension = 10;
                        racveh.PrimaryColor = 138;
                        Main.SetVehicleFuel(racveh, 99.0);
                        
                    }
                }
                else if (eventName == "wetrace")
                {
                    for (int i = 0; i < 8; i++)
                    {
                        var racveh = NAPI.Vehicle.CreateVehicle(vehHash, vehspawn3[i], new Vector3(0, 0, -12.70), 0, 0);
                        racveh.SetData("racveh", true);
                        racveh.Dimension = 10;
                        racveh.PrimaryColor = 138;
                        Main.SetVehicleFuel(racveh, 99.0);
                        
                    }
                }

                
            }
        }
        else
        {
            NAPI.Chat.SendChatMessageToPlayer(c, "Eventi: sanchezcross, grandprix, wetrace");
            return;
        }
    }

    [Command("joinevent")]
    public void RaceCmd(Player player, string ImeEventa)
    {
        if (racestarted == false)
        {
            return;
        }
        if (!Main.IsInRangeOfPoint(player.Position, new Vector3(-239.37, -2040.26, 27.75), 35.0f)) return;
        
        if (playerCount >= maxPlayers)
        {
            player.SendChatMessage("Broj mesta na eventu je popunjen");
            return;
        }

        switch (ImeEventa.ToLower())
        {
            case "sanchezcross":
                player.Position = new Vector3(-898.53107, 5415.2256, 36.406372);
                break;
            case "grandprix":
                player.Position = new Vector3(32.1009, 6409.655016, 32.007565);
                break;
            case "wetrace":
                player.Position = new Vector3(179.3709, 3562.655016, 33.007565);
                break;
            default:
                player.SendChatMessage("Nepostojece ime eventa");
                return;
        }

        player.Dimension = 10;
        player.SetData("racer", true);

        playerCount++;
    }

    [Command("startevent")]
    public void sracecmd(Player c)
    {
        if (c.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(c, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(c) > 6)
        {
            if (c.GetData<bool>("racestarted") == true)
            {
                return;
            }

            if (c.GetData<bool>("sanchezcross") == true)
            {
                startrace();
                
            }
            if (c.GetData<bool>("grandprix") == true)
            {
                startrace2();
            }
            if (c.GetData<bool>("wetrace") == true)
            {
                startrace3();
            }
            c.SetData("racestarted", true);
            c.SendChatMessage("NE ZABORAVITE NA KRAJU /STOPEVENT!!!");
        }

    }

    [Command("stopevent")]
    public void stopracecmd(Player c)
    {
        if (c.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(c, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(c) > 6)
        {
            if (c.GetData<dynamic>("sanchezcross") == true)
            {
                c.SetData("sanchezcross", false);
                racestarted = false;
                c.SetData("racestarted", false);

            }
            if (c.GetData<dynamic>("grandprix") == true)
            {
                c.SetData("grandprix", false);
                racestarted = false;
                c.SetData("racestarted", false);
            }
            if (c.GetData<dynamic>("wetrace") == true)
            {
                c.SetData("wetrace", false);
                racestarted = false;
                c.SetData("racestarted", false);
            }
            foreach (Vehicle veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.GetData<dynamic>("racveh") == true)
                {
                    veh.Delete();
                }
            }
            foreach (Player racer in NAPI.Pools.GetAllPlayers())
            {
                if (racer.GetData<dynamic>("racer") == true)
                {
                    racer.TriggerEvent("deleteCheckpoint", 12, 0);
                    racer.Dimension = 0;
                    racer.SetData("racer", false);
                    racer.Position = new Vector3(-239.37, -2040.26, 27.75);
                }
            }
            c.SendChatMessage("Event stopiran!");
            playerCount = 0;
        }
    }

    [Command("quitevent")]
    public void quiteventcmd(Player c)
    { 
        if (c.GetData<dynamic>("racer") == true)
        {
            c.TriggerEvent("deleteCheckpoint", 12, 0);
            c.Dimension = 0;
            c.SetData("racer", false);
            c.Position = new Vector3(-239.37, -2040.26, 27.75);
        }
    }

    private void startrace()
    {
        foreach (Player c in NAPI.Pools.GetAllPlayers())
        {
            if (c.GetData<bool>("racer") == true)
            {
                NAPI.Task.Run(() =>
                {
                    if (!NAPI.Player.IsPlayerConnected(c)) return;
                    c.SendChatMessage("**3**");
                }, delayTime: 1000);
                NAPI.Task.Run(() =>
                {
                    if (!NAPI.Player.IsPlayerConnected(c)) return;
                    c.SendChatMessage("**2**");
                }, delayTime: 2000);
                NAPI.Task.Run(() =>
                {
                    if (!NAPI.Player.IsPlayerConnected(c)) return;
                    c.SendChatMessage("**1**");
                }, delayTime: 3000);
                NAPI.Task.Run(() =>
                {
                    if (!NAPI.Player.IsPlayerConnected(c)) return;
                    c.SendChatMessage("GO GO GO!!!");
                    foreach (Vehicle rv in NAPI.Pools.GetAllVehicles())
                    {
                        if (rv.GetData<bool>("racveh"))
                        {
                            NAPI.Vehicle.SetVehicleEngineStatus(rv, true);
                        }
                    }
                    for (int i = 0; i < racecords1.Count; i++)
                    {
                        var colshape = NAPI.ColShape.CreateCylinderColShape(racecords1[i], 15, 5, 10);
                        colshape.OnEntityEnterColShape += onPlayerEnterDrive;
                        colshape.SetData("RACENUMB", i);
                    }
                    c.TriggerEvent("createCheckpoint", 12, 1, racecords1[0] - new Vector3(0, 0, 2), 15, 10, 255, 0, 0);
                    c.TriggerEvent("createWaypoint", racecords1[0].X, racecords1[0].Y);
                    c.SetData("rpoint", 0);
                }, delayTime: 4000);

            }

        }

    }

    private void startrace2()
    {
        foreach (Player c in NAPI.Pools.GetAllPlayers())
        {
            if (c.GetData<bool>("racer") == true)
            {
                NAPI.Task.Run(() =>
                {
                    if (!NAPI.Player.IsPlayerConnected(c)) return;
                    c.SendChatMessage("**3**");
                }, delayTime: 1000);
                NAPI.Task.Run(() =>
                {
                    if (!NAPI.Player.IsPlayerConnected(c)) return;
                    c.SendChatMessage("**2**");
                }, delayTime: 2000);
                NAPI.Task.Run(() =>
                {
                    if (!NAPI.Player.IsPlayerConnected(c)) return;
                    c.SendChatMessage("**1**");
                }, delayTime: 3000);
                NAPI.Task.Run(() =>
                {
                    if (!NAPI.Player.IsPlayerConnected(c)) return;
                    c.SendChatMessage("GO GO GO!!!");
                    foreach (Vehicle rv in NAPI.Pools.GetAllVehicles())
                    {
                        if (rv.GetData<bool>("racveh"))
                        {
                            NAPI.Vehicle.SetVehicleEngineStatus(rv, true);
                        }
                    }
                    for (int i = 0; i < racecords2.Count; i++)
                    {
                        var colshape = NAPI.ColShape.CreateCylinderColShape(racecords2[i], 15, 5, 10);
                        colshape.OnEntityEnterColShape += onPlayerEnterDrive2;
                        colshape.SetData("RACENUMB", i);
                    }
                    c.TriggerEvent("createCheckpoint", 12, 1, racecords2[0] - new Vector3(0, 0, 2), 15, 10, 255, 0, 0);
                    c.TriggerEvent("createWaypoint", racecords2[0].X, racecords2[0].Y);
                    c.SetData("rpoint2", 0);
                }, delayTime: 4000);
            }

        }

    }

    private void startrace3()
    {
        foreach (Player c in NAPI.Pools.GetAllPlayers())
        {
            if (c.GetData<bool>("racer") == true)
            {
                NAPI.Task.Run(() =>
                {
                    if (!NAPI.Player.IsPlayerConnected(c)) return;
                    c.SendChatMessage("**3**");
                }, delayTime: 1000);
                NAPI.Task.Run(() =>
                {
                    if (!NAPI.Player.IsPlayerConnected(c)) return;
                    c.SendChatMessage("**2**");
                }, delayTime: 2000);
                NAPI.Task.Run(() =>
                {
                    if (!NAPI.Player.IsPlayerConnected(c)) return;
                    c.SendChatMessage("**1**");
                }, delayTime: 3000);
                NAPI.Task.Run(() =>
                {
                    if (!NAPI.Player.IsPlayerConnected(c)) return;
                    c.SendChatMessage("GO GO GO!!!");
                    foreach (Vehicle rv in NAPI.Pools.GetAllVehicles())
                    {
                        if (rv.GetData<bool>("racveh"))
                        {
                            NAPI.Vehicle.SetVehicleEngineStatus(rv, true);
                        }
                    }
                    for (int i = 0; i < racecords3.Count; i++)
                    {
                        var colshape = NAPI.ColShape.CreateCylinderColShape(racecords3[i], 15, 5, 10);
                        colshape.OnEntityEnterColShape += onPlayerEnterDrive3;
                        colshape.SetData("RACENUMB", i);
                    }
                    c.TriggerEvent("createCheckpoint", 12, 1, racecords3[0] - new Vector3(0, 0, 2), 15, 10, 255, 0, 0);
                    c.TriggerEvent("createWaypoint", racecords3[0].X, racecords3[0].Y);
                    c.SetData("rpoint2", 0);
                }, delayTime: 4000);
            }

        }

    }

    private void onPlayerEnterDrive(ColShape shape, Player c)
    {
        if (!c.IsInVehicle)
        {
            return;
        }
        if (shape.GetData<int>("RACENUMB") != c.GetData<int>("rpoint")) return;
        var rpoint = c.GetData<int>("rpoint");
        if (rpoint == racecords1.Count - 1)
        {
            NAPI.Entity.DeleteEntity(c.Vehicle);
            c.TriggerEvent("deleteCheckpoint", 12, 0);
            foreach (Player admin in NAPI.Pools.GetAllPlayers())
            {
                if (AccountManage.GetPlayerAdmin(admin) > 6)
                {
                    admin.SendChatMessage($"{c.GetData<dynamic>("character_name")} je zavrsio trku!");
                }
            }
            return;
        }
        c.SetData("rpoint", rpoint + 1);
        if (rpoint + 2 < racecords1.Count)
            c.TriggerEvent("createCheckpoint", 12, 1, racecords1[rpoint + 1] - new Vector3(0, 0, 2), 15, 10, 255, 0, 0, racecords1[rpoint + 2] - new Vector3(0, 0, 1.12));
        else
            c.TriggerEvent("createCheckpoint", 12, 1, racecords1[rpoint + 1] - new Vector3(0, 0, 2), 15, 10, 255, 0, 0);
        c.TriggerEvent("createWaypoint", racecords1[rpoint + 1].X, racecords1[rpoint + 1].Y);
    }

    private void onPlayerEnterDrive2(ColShape shape, Player c)
    {
        if (!c.IsInVehicle)
        {
            return;
        }
        if (shape.GetData<int>("RACENUMB") != c.GetData<int>("rpoint2")) return;
        var rpoint2 = c.GetData<int>("rpoint2");
        if (rpoint2 == racecords2.Count - 1)
        {
            NAPI.Entity.DeleteEntity(c.Vehicle);
            c.TriggerEvent("deleteCheckpoint", 12, 0);
            foreach (Player admin in NAPI.Pools.GetAllPlayers())
            {
                if (AccountManage.GetPlayerAdmin(admin) > 6)
                {
                    admin.SendChatMessage($"{c.GetData<dynamic>("character_name")} je zavrsio trku!");
                }
            }
            return;
        }
        c.SetData("rpoint2", rpoint2 + 1);
        if (rpoint2 + 2 < racecords2.Count)
            c.TriggerEvent("createCheckpoint", 12, 1, racecords2[rpoint2 + 1] - new Vector3(0, 0, 2), 15, 10, 255, 0, 0, racecords2[rpoint2 + 2] - new Vector3(0, 0, 1.12));
        else
            c.TriggerEvent("createCheckpoint", 12, 1, racecords2[rpoint2 + 1] - new Vector3(0, 0, 2), 15, 10, 255, 0, 0);
        c.TriggerEvent("createWaypoint", racecords2[rpoint2 + 1].X, racecords2[rpoint2 + 1].Y);
    }

    private void onPlayerEnterDrive3(ColShape shape, Player c)
    {
        if (!c.IsInVehicle)
        {
            return;
        }
        if (shape.GetData<int>("RACENUMB") != c.GetData<int>("rpoint3")) return;
        var rpoint3 = c.GetData<int>("rpoint3");
        if (rpoint3 == racecords3.Count - 1)
        {
            NAPI.Entity.DeleteEntity(c.Vehicle);
            c.TriggerEvent("deleteCheckpoint", 12, 0);
            foreach (Player admin in NAPI.Pools.GetAllPlayers())
            {
                if (AccountManage.GetPlayerAdmin(admin) > 6)
                {
                    admin.SendChatMessage($"{c.GetData<dynamic>("character_name")} je zavrsio trku!");
                }
            }
            return;
        }
        c.SetData("rpoint3", rpoint3 + 1);
        if (rpoint3 + 2 < racecords3.Count)
            c.TriggerEvent("createCheckpoint", 12, 1, racecords3[rpoint3 + 1] - new Vector3(0, 0, 2), 15, 10, 255, 0, 0, racecords3[rpoint3 + 2] - new Vector3(0, 0, 1.12));
        else
            c.TriggerEvent("createCheckpoint", 12, 1, racecords2[rpoint3 + 1] - new Vector3(0, 0, 2), 15, 10, 255, 0, 0);
        c.TriggerEvent("createWaypoint", racecords3[rpoint3 + 1].X, racecords3[rpoint3 + 1].Y);
    }

}