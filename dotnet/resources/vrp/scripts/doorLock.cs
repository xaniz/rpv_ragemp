using GTANetworkAPI;

class DoorLock : Script
{

   // public static int lspd_locker_room, main_to_cell_right, main_to_cell_left, lspd_captain_room, lspd_exit_cell, lspd_to_garage_right, lspd_to_garage_left, lspd_enter_cell_door, lspd_cell_door_1, lspd_cell_door_2, lspd_cell_door_3, lspd_roof, lspd_gate_door;

   // public static int ls_custom_door;

    public static void DoorLockInit()
    {
        NAPI.Data.SetWorldData("lspd_locker_room", true);
        NAPI.Data.SetWorldData("main_to_cell", true);
        NAPI.Data.SetWorldData("lspd_captain_room", true);
        NAPI.Data.SetWorldData("lspd_exit_cell", true);
        NAPI.Data.SetWorldData("lspd_to_garage", true);
        NAPI.Data.SetWorldData("lspd_enter_cell_door", true);
        NAPI.Data.SetWorldData("lspd_cell_door_1", true);
        NAPI.Data.SetWorldData("lspd_cell_door_2", true);
        NAPI.Data.SetWorldData("lspd_cell_door_3", true);
        NAPI.Data.SetWorldData("lspd_roof", true);

        // Custom Map
        NAPI.Data.SetWorldData("Briefing_Door", true);
        NAPI.Data.SetWorldData("Garage_Exit", true);
        NAPI.Data.SetWorldData("Asset", true);
        NAPI.Data.SetWorldData("Cell_1", true);
        NAPI.Data.SetWorldData("Cell_2", true);
        NAPI.Data.SetWorldData("Cell_3", true);
        NAPI.Data.SetWorldData("Cell_4", true);
        NAPI.Data.SetWorldData("Interview_1", true);
        NAPI.Data.SetWorldData("Interview_2", true);
        NAPI.Data.SetWorldData("Interview_3", true);
        NAPI.Data.SetWorldData("Interview_4", true);

        NAPI.Data.SetWorldData("server", true);
        NAPI.Data.SetWorldData("chifroom", true);
        NAPI.Data.SetWorldData("balkon", true);

        NAPI.Data.SetWorldData("armory", true);

        NAPI.Data.SetWorldData("sherif_main", true);
        NAPI.Data.SetWorldData("sherif_main2", true);


       
    }
    [Command("door")]
    public void CMD_door(Player Client)
    {
        if (FactionManage.GetPlayerGroupID(Client) == 1)
        {
            DoorLSPDInteract(Client);
        }
    }

    public static void UpdateTime()
    {
        DoorLock.SetDoorState(1557126584, new Vector3(449.6888, -986.5193, 30.6896), NAPI.Data.GetWorldData("lspd_locker_room"), 0); // lspd_locker_room
        DoorLock.SetDoorState(185711165, new Vector3(444.2534, -989.4843, 30.6896), NAPI.Data.GetWorldData("main_to_cell"), 0); // main_to_cell_right
        DoorLock.SetDoorState(185711165, new Vector3(445.2322, -989.5842, 30.68959), NAPI.Data.GetWorldData("main_to_cell"), 0); // main_to_cell_left
        ///Miner

        DoorLock.SetDoorState(-1320876379, new Vector3(447.1939, -979.9949, 30.68959), NAPI.Data.GetWorldData("lspd_captain_room"), 0); // lspd_captain_room
        DoorLock.SetDoorState(-1033001619, new Vector3(463.9265, -1003.572, 24.91487), NAPI.Data.GetWorldData("lspd_exit_cell"), 0); // lspd_exit_cell

        DoorLock.SetDoorState(-2023754432, new Vector3(468.0155, -1014.855, 26.38639), NAPI.Data.GetWorldData("lspd_to_garage"), 0); // lspd_to_garage
        DoorLock.SetDoorState(-2023754432, new Vector3(469.3621, -1014.649, 26.3864), NAPI.Data.GetWorldData("lspd_to_garage"), 0);

        DoorLock.SetDoorState(631614199, new Vector3(464.5701, -992.6641, 25.06443), NAPI.Data.GetWorldData("lspd_enter_cell_door"), 0); //lspd_enter_cell_door

        DoorLock.SetDoorState(631614199, new Vector3(461.8065, -994.4086, 25.06443), NAPI.Data.GetWorldData("lspd_cell_door_1"), 0); //lspd_cell_door_1
        DoorLock.SetDoorState(631614199, new Vector3(461.8065, -997.6583, 25.06443), NAPI.Data.GetWorldData("lspd_cell_door_2"), 0); //lspd_cell_door_2
        DoorLock.SetDoorState(631614199, new Vector3(461.8065, -1001.302, 25.06443), NAPI.Data.GetWorldData("lspd_cell_door_3"), 0); //lspd_cell_door_3

        DoorLock.SetDoorState(-340230128, new Vector3(464.3613, -984.678, 43.83443), NAPI.Data.GetWorldData("lspd_roof"), 0); //lspd_roof


        //custom map
        DoorLock.SetDoorState(-131296141, new Vector3(443, -993.25, 30.6), NAPI.Data.GetWorldData("Briefing_Door"), 0); //berif
        DoorLock.SetDoorState(-131296141, new Vector3(443,-993.9,30.68), NAPI.Data.GetWorldData("Briefing_Door"), 0); //berif

        DoorLock.SetDoorState(-1033001619, new Vector3(445.23,-999.1,30.7), NAPI.Data.GetWorldData("Garage_Exit"), 0); //Garage_Exit
        DoorLock.SetDoorState(-1033001619, new Vector3(446.59,-999.1,30.7), NAPI.Data.GetWorldData("Garage_Exit"), 0); //Garage_Exit

        DoorLock.SetDoorState(-543497392, new Vector3(465.7, -989.2, 24.9), NAPI.Data.GetWorldData("Asset"), 0); //asset
        DoorLock.SetDoorState(-543497392, new Vector3(465.5,-990.8,24.9), NAPI.Data.GetWorldData("Asset"), 0); //asset


        DoorLock.SetDoorState(-1033001619, new Vector3(468,-996.3,24.9), NAPI.Data.GetWorldData("Cell_1"), 0); //asset
        DoorLock.SetDoorState(-1033001619, new Vector3(472.3,-996.5,24.9), NAPI.Data.GetWorldData("Cell_2"), 0); //asset
        DoorLock.SetDoorState(-1033001619, new Vector3(476.6,-996.5,24.9), NAPI.Data.GetWorldData("Cell_3"), 0); //asset
        DoorLock.SetDoorState(-1033001619, new Vector3(480.7,-996.5,24.9), NAPI.Data.GetWorldData("Cell_4"), 0); //asset
        DoorLock.SetDoorState(-1033001619, new Vector3(467.6, -1003.5,24.9), NAPI.Data.GetWorldData("Interview_1"), 0); //asset
        DoorLock.SetDoorState(-1033001619, new Vector3(472.2,-1003.5,24.9), NAPI.Data.GetWorldData("Interview_2"), 0); //asset
        DoorLock.SetDoorState(-1033001619, new Vector3(476.3,-1003.5,24.9), NAPI.Data.GetWorldData("Interview_3"), 0); //asset
        DoorLock.SetDoorState(-1033001619, new Vector3(480.8,-1003.4,24.9), NAPI.Data.GetWorldData("Interview_4"), 0); //asset

        DoorLock.SetDoorState(-131296141, new Vector3(468.2,-977.9,24.9), NAPI.Data.GetWorldData("server"), 0); //asset
        DoorLock.SetDoorState(-1320876379, new Vector3(462.8, -1000.9, 35.9), NAPI.Data.GetWorldData("chifroom"), 0); //asset
        DoorLock.SetDoorState(749848321, new Vector3(461.2,-985.9,30.6), NAPI.Data.GetWorldData("balkon"), 0); //asset

        DoorLock.SetDoorState(1956494919, new Vector3(265.8,217.8,110.2), true, 0); //asset
        // =====
        // LS Custom
        SetDoorState(-550347177, new Vector3(-356.0905, -134.7714, 40.01295), false, 0);

        // Discount Store
        SetDoorState(-1148826190, new Vector3(82.38156, -1390.476, 29.52609), false, 0);
        SetDoorState(868499217, new Vector3(82.38156, -1390.752, 29.52609), false, 0);


        //NightcLUB
         SetDoorState(-1116041313, new Vector3(127.9552, -1298.503, 29.41962), false, 0);
         SetDoorState(668467214, new Vector3(96.09197, -1284.854, 29.43878), false, 0);
         SetDoorState(-626684119, new Vector3(99.08321, -1293.701, 29.41868), false, 0);
         SetDoorState(-495720969, new Vector3(113.9822, -1297.43, 29.41868), false, 0);
         SetDoorState(-1881825907, new Vector3(116.0046, -1294.692, 29.41947), false, 0);


        // Premium Delux
        SetDoorState(1417577297, new Vector3(-37.33113, -1108.873, 26.7198), false, 0);
        SetDoorState(2059227086, new Vector3(-39.13366, -1108.218, 26.7198), false, 0);
        SetDoorState(1417577297, new Vector3(-60.54582, -1094.749, 26.88872), false, 0);
        SetDoorState(2059227086, new Vector3(-59.89302, -1092.952, 26.88362), false, 0);
        SetDoorState(-2051651622, new Vector3(-33.80989, -1107.579, 26.57225), false, 0);
        SetDoorState(-2051651622, new Vector3(-31.72353, -1101.847, 26.57225), false, 0);

        // LSPD Main door
        SetDoorState(320433149, new Vector3(434.7479, -983.2151, 30.83926), false, 0);
        SetDoorState(-1215222675, new Vector3(434.7479, -980.6184, 30.83926), false, 0);

        DoorLock.SetDoorState(-1033001619, new Vector3(452.6, -982.3, 30), NAPI.Data.GetWorldData("armory"), 0); //asset
        DoorLock.SetDoorState(-1501157055, new Vector3(-443.3, 6016, 31.7), NAPI.Data.GetWorldData("sherif_main"), 0); //asset
        DoorLock.SetDoorState(-1501157055, new Vector3(-443.6, 6016.7, 31.7), NAPI.Data.GetWorldData("sherif_main2"), 0); //asset

    }

    public static void SetDoorState(long model, Vector3 position, bool locked, int handling)
    {
        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (target.Position.DistanceTo(position) <= 250)
            {
                if (target.GetData<dynamic>("status") == true)
                {
                    target.TriggerEvent("doorLock", model, position, locked);
                }
            }
            
        }
    }


    public void door(Player pla)
    {
        pla.TriggerEvent("doorLock", 3053754761, new Vector3(-596.17, 2088.97, 131.4), false, 0);
    }

    public static void DoorSherifPelato(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-443.3, 6016.3, 31.7), 2.0f))
        {
            if (NAPI.Data.GetWorldData("sherif_main") == true)
            {
                SetDoorState(-1501157055, new Vector3(-443.3, 6016.3, 31.7), false, 0); // lspd_locker_room
                NAPI.Data.SetWorldData("sherif_main", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(-1501157055, new Vector3(-443.3, 6016.3, 31.7), true, 0);
                NAPI.Data.SetWorldData("sherif_main", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-443.6, 6016.7, 31.7), 2.0f))
        {
            if (NAPI.Data.GetWorldData("sherif_main2") == true)
            {
                SetDoorState(-1501157055, new Vector3(-443.6, 6016.7, 31.7), false, 0); // lspd_locker_room
                NAPI.Data.SetWorldData("sherif_main2", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(-1501157055, new Vector3(-443.6, 6016.7, 31.7), true, 0);
                NAPI.Data.SetWorldData("sherif_main2", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }

    }
    public static void DoorLSPDInteract(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(449.6888, -986.5193, 30.6896), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_locker_room") == true)
            {
                SetDoorState(1557126584, new Vector3(449.6888, -986.5193, 30.6896), false, 0); // lspd_locker_room
                NAPI.Data.SetWorldData("lspd_locker_room", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~g~Otkljucali~w~ ste vrata.");

            }
            else
            {
                SetDoorState(1557126584, new Vector3(449.6888, -986.5193, 30.6896), true, 0);
                NAPI.Data.SetWorldData("lspd_locker_room", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(444.2534, -989.4843, 30.6896), 2.0f))
        {
            if (NAPI.Data.GetWorldData("main_to_cell") == true)
            {
                SetDoorState(185711165, new Vector3(444.2534, -989.4843, 30.6896), false, 0); // main_to_cell_right
                SetDoorState(185711165, new Vector3(445.2322, -989.5842, 30.68959), false, 0); // main_to_cell_left
                //NAPI.Exported.doormanager.setDoorState(main_to_cell_right, false, 0);
                //NAPI.Exported.doormanager.setDoorState(main_to_cell_left, false, 0);
                NAPI.Data.SetWorldData("main_to_cell", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(185711165, new Vector3(444.2534, -989.4843, 30.6896), true, 0);
                SetDoorState(185711165, new Vector3(445.2322, -989.5842, 30.68959), true, 0);
                NAPI.Data.SetWorldData("main_to_cell", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(447.1939, -979.9949, 30.68959), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_captain_room") == true)
            {
                SetDoorState(-1320876379, new Vector3(447.1939, -979.9949, 30.68959), false, 0); // lspd_captain_room
                //NAPI.Exported.doormanager.setDoorState(lspd_captain_room, false, 0);
                NAPI.Data.SetWorldData("lspd_captain_room", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                //NAPI.Exported.doormanager.setDoorState(lspd_captain_room, true, 0); //lspd_captain_room
                SetDoorState(-1320876379, new Vector3(447.1939, -979.9949, 30.68959), true, 0);
                NAPI.Data.SetWorldData("lspd_captain_room", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(463.9265, -1003.572, 24.91487), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_exit_cell") == true)
            {
                SetDoorState(-1033001619, new Vector3(463.9265, -1003.572, 24.91487), false, 0); // lspd_exit_cell
                NAPI.Data.SetWorldData("lspd_exit_cell", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(-1033001619, new Vector3(463.9265, -1003.572, 24.91487), true, 0);
                NAPI.Data.SetWorldData("lspd_exit_cell", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(468.0155, -1014.855, 26.38639), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_to_garage") == true)
            {
                SetDoorState(-2023754432, new Vector3(468.0155, -1014.855, 26.38639), false, 0); // lspd_to_garage
                SetDoorState(-2023754432, new Vector3(469.3621, -1014.649, 26.3864), false, 0);
                NAPI.Data.SetWorldData("lspd_to_garage", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(-2023754432, new Vector3(468.0155, -1014.855, 26.38639), true, 0);
                SetDoorState(-2023754432, new Vector3(469.3621, -1014.649, 26.3864), true, 0);
                NAPI.Data.SetWorldData("lspd_to_garage", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(464.5701, -992.6641, 25.06443), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_enter_cell_door") == true)
            {
                SetDoorState(631614199, new Vector3(464.5701, -992.6641, 25.06443), false, 0); //lspd_enter_cell_door
                                                                                               // NAPI.Exported.doormanager.setDoorState(lspd_enter_cell_door, false, 0);
                NAPI.Data.SetWorldData("lspd_enter_cell_door", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(631614199, new Vector3(464.5701, -992.6641, 25.06443), true, 0); // lspd_enter_cell_door
                                                                                              // NAPI.Exported.doormanager.setDoorState(lspd_enter_cell_door, true, 0);
                NAPI.Data.SetWorldData("lspd_enter_cell_door", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(461.8065, -994.4086, 25.06443), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_cell_door_1") == true)
            {
                SetDoorState(631614199, new Vector3(461.8065, -994.4086, 25.06443), false, 0); //lspd_cell_door_1
                                                                                               // NAPI.Exported.doormanager.setDoorState(lspd_cell_door_1, false, 0);
                NAPI.Data.SetWorldData("lspd_cell_door_1", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(631614199, new Vector3(461.8065, -994.4086, 25.06443), true, 0);
                NAPI.Data.SetWorldData("lspd_cell_door_1", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(461.8065, -997.6583, 25.06443), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_cell_door_2") == true)
            {
                SetDoorState(631614199, new Vector3(461.8065, -997.6583, 25.06443), false, 0); //lspd_cell_door_2
                                                                                               //  NAPI.Exported.doormanager.setDoorState(lspd_cell_door_2, false, 0);
                NAPI.Data.SetWorldData("lspd_cell_door_2", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(631614199, new Vector3(461.8065, -997.6583, 25.06443), true, 0);
                //  NAPI.Exported.doormanager.setDoorState(lspd_cell_door_2, true, 0);
                NAPI.Data.SetWorldData("lspd_cell_door_2", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(461.8065, -1001.302, 25.06443), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_cell_door_3") == true)
            {
                SetDoorState(631614199, new Vector3(461.8065, -1001.302, 25.06443), false, 0); //lspd_cell_door_3
                                                                                               //  NAPI.Exported.doormanager.setDoorState(lspd_cell_door_3, false, 0);
                NAPI.Data.SetWorldData("lspd_cell_door_3", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(631614199, new Vector3(461.8065, -1001.302, 25.06443), true, 0);
                // NAPI.Exported.doormanager.setDoorState(lspd_cell_door_3, true, 0);
                NAPI.Data.SetWorldData("lspd_cell_door_3", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(464.3613, -984.678, 43.83443), 2.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_roof") == true)
            {
                SetDoorState(-340230128, new Vector3(464.3613, -984.678, 43.83443), false, 0); //lspd_roof
                //NAPI.Exported.doormanager.setDoorState(lspd_roof, false, 0); 
                NAPI.Data.SetWorldData("lspd_roof", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(-340230128, new Vector3(464.3613, -984.678, 43.83443), true, 0);
                // NAPI.Exported.doormanager.setDoorState(lspd_roof, true, 0);
                NAPI.Data.SetWorldData("lspd_roof", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(489.4,-1017.3,28), 6.0f))
        {
            if (NAPI.Data.GetWorldData("lspd_gate_door") == true)
            {
                SetDoorState(-1603817716, new Vector3(488.8923, -1011.67, 27.14583), false, 0); //lspd_gate_door
                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("lspd_gate_door", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(-1603817716, new Vector3(488.8923, -1011.67, 27.14583), true, 0);
                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("lspd_gate_door", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(443,-993.25,30.6), 3f))
        {
            if (NAPI.Data.GetWorldData("Briefing_Door") == true)
            {
                SetDoorState(-131296141, new Vector3(443, -993.25, 30.6), false, 0);
                SetDoorState(-131296141, new Vector3(443, -993.9, 30.68), false, 0);

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("Briefing_Door", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(-131296141, new Vector3(443,-993.25,30.6), true, 0);
                SetDoorState(-131296141, new Vector3(443,-993.9,30.68), true, 0);

                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("Briefing_Door", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(445.96,-999.2,30.72), 3f))
        {
            if (NAPI.Data.GetWorldData("Garage_Exit") == true)
            {

                SetDoorState(-1033001619, new Vector3(445.23, -999.1, 30.7), false, 0); //Garage_Exit
                SetDoorState(-1033001619, new Vector3(446.59, -999.1, 30.7), false, 0); //Garage_Exit

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("Garage_Exit", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                SetDoorState(-1033001619, new Vector3(445.23, -999.1, 30.7), true, 0); //Garage_Exit
                SetDoorState(-1033001619, new Vector3(446.59, -999.1, 30.7), true, 0); //Garage_Exit

                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("Garage_Exit", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(465.4,-989.98,24.9), 3f))
        {
            if (NAPI.Data.GetWorldData("Asset") == true)
            {


                DoorLock.SetDoorState(-543497392, new Vector3(465.7, -989.2, 24.9), false, 0); //asset
                DoorLock.SetDoorState(-543497392, new Vector3(465.5, -990.8, 24.9), false, 0); //asset
                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("Asset", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                DoorLock.SetDoorState(-543497392, new Vector3(465.7,-989.2,24.9), true, 0); //asset
                DoorLock.SetDoorState(-543497392, new Vector3(465.5, -990.8, 24.9), true, 0); //asset
                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("Asset", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(468, -996.3, 24.9), 1f))
        {
            if (NAPI.Data.GetWorldData("Cell_1") == true)
            {

                DoorLock.SetDoorState(-1033001619, new Vector3(468, -996.3, 24.9), false, 0); //asset
                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("Cell_1", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                DoorLock.SetDoorState(-1033001619, new Vector3(468, -996.3, 24.9), true, 0); //asset
                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("Cell_1", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(472.3, -996.5, 24.9), 2f))
        {
            if (NAPI.Data.GetWorldData("Cell_2") == true)
            {


                DoorLock.SetDoorState(-1033001619, new Vector3(472.3, -996.5, 24.9), false, 0); //asset

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("Cell_2", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                DoorLock.SetDoorState(-1033001619, new Vector3(472.3, -996.5, 24.9), true, 0); //asset

                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("Cell_2", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(476.6, -996.5, 24.9), 2f))
        {
            if (NAPI.Data.GetWorldData("Cell_3") == true)
            {


                DoorLock.SetDoorState(-1033001619, new Vector3(476.6, -996.5, 24.9), false, 0); //asset

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("Cell_3", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                DoorLock.SetDoorState(-1033001619, new Vector3(476.6, -996.5, 24.9), true, 0); //asset

                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("Cell_3", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(480.7, -996.5, 24.9), 2f))
        {
            if (NAPI.Data.GetWorldData("Cell_4") == true)
            {


                DoorLock.SetDoorState(-1033001619, new Vector3(480.7, -996.5, 24.9), false, 0); //asset

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("Cell_4", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                DoorLock.SetDoorState(-1033001619, new Vector3(480.7, -996.5, 24.9), true, 0); //asset

                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("Cell_4", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(467.6, -1003.5, 24.9), 2f))
        {
            if (NAPI.Data.GetWorldData("Interview_1") == true)
            {

                DoorLock.SetDoorState(-1033001619, new Vector3(467.6, -1003.5, 24.9), false, 0); //asset

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("Interview_1", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                DoorLock.SetDoorState(-1033001619, new Vector3(467.6, -1003.5, 24.9), true, 0); //asset

                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("Interview_1", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(472.2, -1003.5, 24.9), 2f))
        {
            if (NAPI.Data.GetWorldData("Interview_2") == true)
            {

                DoorLock.SetDoorState(-1033001619, new Vector3(472.2, -1003.5, 24.9), false, 0); //asset

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("Interview_2", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                DoorLock.SetDoorState(-1033001619, new Vector3(472.2, -1003.5, 24.9), true, 0); //asset

                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("Interview_2", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(476.47, -1003.4, 24.9), 2f))
        {
            if (NAPI.Data.GetWorldData("Interview_3") == true)
            {


                DoorLock.SetDoorState(-1033001619, new Vector3(476.3, -1003.5, 24.9), false, 0); //asset

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("Interview_3", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                DoorLock.SetDoorState(-1033001619, new Vector3(476.3, -1003.5, 24.9), true, 0); //asset

                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("Interview_3", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(480.8, -1003.4, 24.9), 2f))
        {
            if (NAPI.Data.GetWorldData("Interview_4") == true)
            {

                DoorLock.SetDoorState(-1033001619, new Vector3(480.8, -1003.4, 24.9), false, 0); //asset

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("Interview_4", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                DoorLock.SetDoorState(-1033001619, new Vector3(480.8, -1003.4, 24.9), true, 0); //asset

                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("Interview_4", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(468.2,-977.9,24.9), 2f))
        {
            if (NAPI.Data.GetWorldData("server") == true)
            {

                DoorLock.SetDoorState(-131296141, new Vector3(468.2, -977.9, 24.9), false, 0); //asset

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("server", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                DoorLock.SetDoorState(-131296141, new Vector3(468.2, -977.9, 24.9), true, 0); //asset

                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("server", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(462.8,-1000.9,35.9), 2f))
        {
            if (NAPI.Data.GetWorldData("chifroom") == true && AccountManage.GetPlayerRank(Client) >=9)
            {

                DoorLock.SetDoorState(-1320876379, new Vector3(462.8, -1000.9, 35.9), false, 0); //asset

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("chifroom", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else if(AccountManage.GetPlayerRank(Client) >= 8 && NAPI.Data.GetWorldData("chifroom") == false)
            {
                DoorLock.SetDoorState(-1320876379, new Vector3(462.8, -1000.9, 35.9), true, 0); //asset
                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("chifroom", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(461.2, -985.9, 30.6), 2f))
        {
            if (NAPI.Data.GetWorldData("balkon") == true)
            {
                DoorLock.SetDoorState(749848321, new Vector3(461.2, -985.9, 30.6), false, 0); //asset

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("balkon", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                DoorLock.SetDoorState(749848321, new Vector3(461.2, -985.9, 30.6), true, 0); //asset

                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("balkon", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
        else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(452.6, -982.3, 30.6), 2f))
        {
            if (NAPI.Data.GetWorldData("armory") == true)
            {
                DoorLock.SetDoorState(-1033001619, new Vector3(452.6, -982.3, 30.6), false, 0); //asset

                //NAPI.Exported.doormanager.setDoorState(lspd_gate_door, false, 0);
                NAPI.Data.SetWorldData("armory", false);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~~y~INFO: ~g~Otkljucali~w~ ste vrata.");
            }
            else
            {
                DoorLock.SetDoorState(-1033001619, new Vector3(452.6, -982.3, 30.6), true, 0); //asset

                // NAPI.Exported.doormanager.setDoorState(lspd_gate_door, true, 0);
                NAPI.Data.SetWorldData("armory", true);
                Client.TriggerEvent("createNewHeadNotificationAdvanced", "~y~INFO: ~r~Zakljucali~w~ ste vrata.");
            }
        }
    }
}

