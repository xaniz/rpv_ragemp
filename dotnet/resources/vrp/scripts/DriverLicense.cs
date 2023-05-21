using GTANetworkAPI;
using System;
using System.Collections.Generic;

public class DriverLicense : Script
{
    public static Vehicle[] school_vehicle { get; set; } = new Vehicle[Main.MAX_PLAYERS];
    public static ColShape[] school_checkpoint { get; set; } = new ColShape[Main.MAX_PLAYERS];
    public static TimerEx[] school_tutorial_timer { get; set; } = new TimerEx[Main.MAX_PLAYERS];

    public static List<dynamic> vehicle_rota = new List<dynamic>();

    public DriverLicense()
    {
        //

        vehicle_rota.Add(new { position = new Vector3(-944.1837, -2123.5, 8.703898), message = "none" });
        vehicle_rota.Add(new { position = new Vector3(-829.9544, -2028.022, 8.576108), message = "stop" });
        vehicle_rota.Add(new { position = new Vector3(-742.5674, -2023.223, 8.899724), message = "none" });
        vehicle_rota.Add(new { position = new Vector3(-738.4678, -1985.861, 8.266144), message = "none" });
        vehicle_rota.Add(new { position = new Vector3(-707.9315, -2055.336, 8.265034), message = "none" });
        vehicle_rota.Add(new { position = new Vector3(-662.6473, -2007.087, 6.813873), message = "none" });
        vehicle_rota.Add(new { position = new Vector3(-511.6047, -2127.009, 8.473609), message = "none" });
        vehicle_rota.Add(new { position = new Vector3(-310.9691, -2162.664, 9.758541), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(3.355392, -2108.107, 9.782333), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-239.3412, -1846.088, 28.63881), message = "chap" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-295.999, -1820.652, 25.50999), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-360.3073, -1815.429, 22.20398), message = "rast" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-398.5178, -1780.68, 20.778), message = "chap" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-447.3097, -1772.613, 19.92935), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-608.5244, -1706.17, 23.41918), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-677.8533, -1641.004, 24.05957), message = "amade-rast" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-645.1669, -1490.846, 10.16868), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-630.7711, -1323.668, 10.06636), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-546.1592, -1172.794, 18.33065), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-533.5215, -1107.218, 21.75278), message = "rast" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-392.7494, -1127.239, 28.97806), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-194.3243, -1143.863, 22.60703), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-124.2391, -1137.639, 25.19362), message = "chap" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-84.31007, -1105.868, 25.49539), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-30.33352, -974.7975, 28.81186), message = "rast" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(77.66237, -995.2123, 28.90005), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(380.5675, -1054.846, 28.72319), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(595.1594, -1033.817, 36.4143), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(721.1041, -1018.32, 29.2), message = "amade-rast" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(786.1989, -1079.161, 28.12806), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(788.62, -1185.568, 27.53081), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(788.896, -1382.555, 26.30217), message = "amade-rast" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(714.0438, -1428.806, 30.9472), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(504.2774, -1427.189, 28.83592), message = "chap" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(394.6145, -1461.515, 28.76667), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(224.8102, -1559.578, 28.74123), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(80.91921, -1649.255, 28.83596), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-48.20041, -1712.629, 28.82002), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-106.8507, -1730.798, 29.42173), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-157.5046, -1747.789, 29.49294), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-235.3508, -1816.348, 29.363), message = "chap" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-170.1603, -1910.537, 24.71361), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-9.618667, -2006.635, 11.80647), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-2.246707, -2106.729, 9.756039), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-117.4048, -2161.057, 9.757373), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-306.1678, -2158.467, 9.791425), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-574.3832, -2052.875, 5.807239), message = "ro_be_jolo" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-909.6816, -2098.477, 8.548483), message = "park_konid" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-945.3257, -2117.836, 8.792059), message = "none" }); // 0, 0, 65.57136
        vehicle_rota.Add(new { position = new Vector3(-891.7947, -2059.223, 8.799081), message = "none" }); // 0, 0, 65.57136

        //

        

       // NAPI.Marker.CreateMarker(27, new Vector3(--1289.7573, -572.499, 30.573061) - new Vector3(0, 0, 0.6f), new Vector3(), new Vector3(), 3.5f, new Color(221, 255, 0, 150));
       // NAPI.Marker.CreateMarker(29, new Vector3(-1289.7573, -572.499, 30.573061) - new Vector3(0, 0, 0.5f), new Vector3(), new Vector3(), 1.0f, new Color(221, 255, 0, 150));
        API.Shared.CreateTextLabel("Auto-skola ~y~Y~r~ ", new Vector3(-1289.7573, -572.499, 30.573061) + new Vector3(0, 0, 0.2f), 15.0f, 0.9f, 4, new Color(221, 255, 0, 210));

        // NAPI.Marker.CreateMarker(27, new Vector3(-742.5674, -2023.223, 8.899724) - new Vector3(0, 0, 0.6f), new Vector3(), new Vector3(), 3.5f, new Color(221, 255, 0, 150));
        //NAPI.Marker.CreateMarker(29, new Vector3(-913.6138, -2039.72, 9.404985) - new Vector3(0, 0, 0.5f), new Vector3(), new Vector3(), 1.0f, new Color(221, 255, 0, 110));
        //API.Shared.CreateTextLabel("~g~- Auto-skola -~w~~n~Зарезервированное место~n~~r~Нажмие ~y~E~r~", new Vector3(-742.5674, -2023.223, 8.899724) + new Vector3(0, 0, 0.2f), 15.0f, 1.2f, 4, new Color(221, 255, 0, 210));


        //.NAPI.Marker.CreateMarker(27, new Vector3(-891.7836, -2059.107, 9.300159) - new Vector3(0, 0, 0.6f), new Vector3(), new Vector3(), 3.5f, new Color(247, 221, 52, 150));
        //NAPI.Marker.CreateMarker(29, new Vector3(-913.6138, -2039.72, 9.404985) - new Vector3(0, 0, 0.5f), new Vector3(), new Vector3(), 1.0f, new Color(221, 255, 0, 110));
        //API.Shared.CreateTextLabel("~g~- Auto-skola -~w~~n~Зарезервированное место~n~~r~Нажмие ~y~E~r~", new Vector3(-891.7836, -2059.107, 9.300159) + new Vector3(0, 0, 0.2f), 15.0f, 1.2f, 4, new Color(221, 255, 0, 210));

    }

    public static void PressKeyY(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-1289.7573, -572.499, 30.573061), 3))
        {

            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Type = 1, Name = "Teorija", Description = "", RightLabel = "" });
            menu_item_list.Add(new { Type = 1, Name = "Kategorija B", Description = "Kupovina dozvole.", RightLabel = "$1500" });
            menu_item_list.Add(new { Type = 1, Name = "Kategorija D", Description = "Kupovina dozvole.", RightLabel = "$2000" });
            InteractMenu.CreateMenu(Client, "DMV_SCHOOL", "", "Auto-skola", true, NAPI.Util.ToJson(menu_item_list), false);

        }
    }


    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "DMV_SCHOOL")
        {
            if (selectedIndex == 0)
            {

                Client.TriggerEvent("freezeEx", true);
                Client.Dimension = 15;
                Client.TriggerEvent("ShowDMVCamera", 1);


                Main.SendMessageWithTagToPlayer(Client, " ", " ");
                Main.SendMessageWithTagToPlayer(Client, " ", " ");
                Main.SendMessageWithTagToPlayer(Client, " ", " ");
                Main.SendMessageWithTagToPlayer(Client, " ", " ");
                Main.SendMessageWithTagToPlayer(Client, " ", " ");
                Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_VIP + "-----------------------------------------------");
                Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_VIP + " Ogranicenje brzine ");
                Main.SendCustomChatMessasge(Client, "~b~ ~ ~y~60 KM/H~b~ u naseljenom mestu ~");
                Main.SendCustomChatMessasge(Client, "~b~ ~ ~y~90 KM/H~b~ u nenaseljenom mestu ~");
                Main.SendCustomChatMessasge(Client, "~b~ ~ ~y~130 KM/H~b~ na auto-putu ~");
                Main.SendCustomChatMessasge(Client, "~b~ ~ Naseljena mesta su: Los Santos, Paleto Bay, Sandy Shores ~");

                NAPI.Entity.SetEntityPosition(Client, new Vector3(-878.0559, -2081.562, 8.800645));

                int tutorial_steps = 0;
                school_tutorial_timer[Main.getIdFromClient(Client)] = TimerEx.SetTimer(() =>
                {
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, " ", " ");
                    Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_LIGHTGREEN + "-----------------------------------------------");
                    tutorial_steps++;

                    switch (tutorial_steps)
                    {
                        case 1:
                            {
                                NAPI.Entity.SetEntityPosition(Client, new Vector3(79.85892, -1369.071, 29.3313));
                                Client.TriggerEvent("ShowDMVCamera", 2);
                                Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_VIP + " Saobracajni zakoni ");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ ~r~Crveno svetlo ~b~na semaforu tretirati kao ~r~znak STOP ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ ~g~Zeleno svetlo ~b~na semaforu oznacava ~g~slobodan prolaz ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ Vozilo koje nailazi sa desne strane ima prvenstvo prolaza ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ Prioritet pri regulisanju saobracaja na raskrsnici ima ~b~Uniformisani policijski sluzbenik ~b~ ~");                               
                                break;
                            }
                        case 2:
                            {
                                NAPI.Entity.SetEntityPosition(Client, new Vector3(-99.26994, -1178.103, 26.44629));
                                Client.TriggerEvent("ShowDMVCamera", 3);
                                Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_VIP + " Oznake na kolovozu");
                                Main.SendCustomChatMessasge(Client, "~b~ U obavezi ste da se pridrzavate oznaka na kolovozu ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ Deo trotoara koji je obojan u ~y~zutoj~b~ boji, oznacava mesta gde je dozvoljeno parkiranje samo vozilima koja prevoze robu ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ Deo trotoara koji je obojan u ~r~crvenoj~b~ boji, oznacava mesta gde je zabranjeno parkiranje i zaustavljanje motornih vozila ~b~ ~");                                
                                break;
                            }
                        case 3:
                            {
                                NAPI.Entity.SetEntityPosition(Client, new Vector3(95.80418, -1043.833, 29.43804));
                                Client.TriggerEvent("ShowDMVCamera", 4);
                                Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_VIP + " Parking");
                                Main.SendCustomChatMessasge(Client, "~b~ Nepropisno parkirana vozila bice ~r~zaplenjena~b~ dok se ne plati kazna ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ Vozilo ~r~ne sme biti parkirano~b~ na trotoaru, tako da blokira normalan tok saobracaja, na mestima za invalide bez dozvole ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ Ukoliko Vam se pokvari vozilo ili policija od Vas trazi da se zaustavite, mozete se zaustaviti pored trotoara ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ Vozilo legalno ~g~mozete parkirati iskljucivo na oznacenim parking mestima, ~r~OSIM~b~ na parkinzima drzavenih sluzbi (Policija, hitna pomoc, vatrogasci, itd.) ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ Vozilo ~g~moze biti parkirano~w~ i u krajnjoj desnoj traci ako u blizini nema semafora ili pesackog prelaza, i tim parkiranjem ne ometa normalan tok saobracaja ~b~ ~");
                                break;
                            }
                        case 4:
                            {
                                NAPI.Entity.SetEntityPosition(Client, new Vector3(2767.7, 3917.981, 43.52993));
                                Client.TriggerEvent("ShowDMVCamera", 6);
                                Main.SendMessageWithTagToPlayer(Client, "", "" + Main.EMBED_VIP + " Napomena");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ U Saveznoj Drzavi San Andreas vozi se iskljucivo ~r~DESNOM~b~ stranom ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ Tokom voznje automobila, vozac i putnici moraju nositi sigurnosni pojas ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ Tokom voznje motora, vozac i putnici moraju nositi propisne sigurnosne kacige ~b~ ~");
                                Main.SendCustomChatMessasge(Client, "~b~ ~ Vozaci su duzni da propuste vozila sa crvenim i/ili plavim rotacijama i/ili sirenama ~b~ ~");                                
                                break;
                            }
                        case 5:
                            {
                                Client.TriggerEvent("ShowDMVCamera", 7);
                                Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "[Auto-skola]", "" + Main.EMBED_WHITE + "Prosli ste teorijski deo obuke. Sada mozete da polazete za B kategoriju.");
                                try
                                {
                                    school_tutorial_timer[Main.getIdFromClient(Client)].Kill();
                                }
                                catch
                                {

                                }
                                tutorial_steps = 0;

                                NAPI.Entity.SetEntityPosition(Client, new Vector3(-1289.7573, -572.499, 30.573061));
                                Client.TriggerEvent("freezeEx", false);
                                Client.Dimension = 0;

                                Client.SetData<dynamic>("school_tutorial", true);
                                break;
                            }
                    }

                }, 16000, 0);
            }
            else if (selectedIndex == 1)
            {
                if (Client.GetData<dynamic>("character_car_lic") > 0)
                {
                    Main.SendErrorMessage(Client, "Vec posedujete vozacku dozvolu.");
                    return;
                }

                if (Main.GetPlayerMoney(Client) < 2000)
                {
                    Main.SendErrorMessage(Client, "Nemate dovoljno novca, treba Vam $2,000.");
                    return;
                }
                if (Client.GetData<dynamic>("school_in_teste") == 1)
                {
                    return;
                }
                Main.GivePlayerMoney(Client, -1000);
                Client.SetData<dynamic>("character_car_lic", 1);
                Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_WHITE + "[Auto-skola]", "Kupili ste vozacku dozvolu za " + Main.EMBED_LIGHTRED + "B" + Main.EMBED_WHITE + " kategoriju.");
                Main.SavePlayerInformation(Client);
                return;

             /*   school_vehicle[Main.getIdFromClient(Client)] = API.Shared.CreateVehicle(VehicleHash.Dilettante, new Vector3(-908.0166, -2044.831, 9.298999), 226.8814f, 58, 58, "School", 255, false, true, 0);
                Client.SetIntoVehicle(school_vehicle[Main.getIdFromClient(Client)], (int)VehicleSeat.Driver);
                Main.DisplayRadar(Client, true);

                Main.SetVehicleFuel(school_vehicle[Main.getIdFromClient(Client)], 100);
                Client.SetData<dynamic>("school_in_teste", 1);
                Client.SetData<dynamic>("school_in_stage", 0);

                Client.SetData<dynamic>("school_in_stages", vehicle_rota.Count);

                Client.TriggerEvent("CreateRaceCheckpoint", vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position - new Vector3(0, 0, 1.0), vehicle_rota[Client.GetData<dynamic>("school_in_stage") + 1].position);
                school_checkpoint[Main.getIdFromClient(Client)] = NAPI.ColShape.CreateCylinderColShape(vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position, 5.0f, 4.0f);
             */
            }
            else if (selectedIndex == 2)
            {
                if (Main.GetPlayerMoney(Client) < 2000)
                {
                    Main.SendErrorMessage(Client, "Nemate dovoljno novca, treba Vam $2,000");
                    return;
                }

                if (Client.GetData<dynamic>("character_truck_lic") == 1)
                {
                    Main.SendErrorMessage(Client, "Vec posedujete vozacku dozvolu D kategorije.");
                    return;
                }

                if (Client.GetData<dynamic>("character_car_lic") == 0)
                {
                    Main.SendErrorMessage(Client, "Da biste polagali za D kategoriju, prvo Vam treba B kategorija.");
                    return;
                }

                Client.SetData<dynamic>("character_truck_lic", 1);
                Main.GivePlayerMoney(Client, -2000);
                Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_WHITE + "[Auto-skola]", "Kupili ste vozacku dozvolu " + Main.EMBED_LIGHTRED + "D" + Main.EMBED_WHITE + "kategorije.");
            }
        }
    }


    public static void PlayerPressKeyE(Player Client)
    {
        try
        {


            if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-742.5674, -2023.223, 8.899724), 2) && Client.GetData<dynamic>("school_in_stage") == 2 && Client.IsInVehicle && NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)VehicleHash.Dilettante && school_vehicle[Main.getIdFromClient(Client)].Exists && Client.Vehicle == Client.Vehicle)
            {
                //Main.SendInfoMessage(Client, "Do percurso " + Client.GetData<dynamic>("school_in_stage") + " para " + (Client.GetData<dynamic>("school_in_stage") + 1) + ".");
                Client.SetData<dynamic>("school_in_stage", Client.GetData<dynamic>("school_in_stage") + 1);
                Client.TriggerEvent("DeleteRaceCheckpoint");
                Client.TriggerEvent("CreateRaceCheckpoint", vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position - new Vector3(0, 0, 1.0), vehicle_rota[Client.GetData<dynamic>("school_in_stage") + 1].position);
                
                school_checkpoint[Main.getIdFromClient(Client)].Delete();
                school_checkpoint[Main.getIdFromClient(Client)] = NAPI.ColShape.CreateCylinderColShape(vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position, 5.0f, 4.0f);
            }
            if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-891.7836, -2059.107, 9.300159), 2) && Client.GetData<dynamic>("school_in_stage") == Client.GetData<dynamic>("school_in_stages") - 1 && Client.IsInVehicle && NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)VehicleHash.Dilettante && school_vehicle[Main.getIdFromClient(Client)].Exists && Client.Vehicle == Client.Vehicle)
            {
                if (Main.GetPlayerMoney(Client) < 1000)
                {
                    Main.SendErrorMessage(Client, "Nemate dovoljno novca, treba Vam $1,000.");
                    return;
                }
                Main.GivePlayerMoney(Client, -1000);

                Main.DisplaySubtitle(Client, "Polozili ste.");
                Client.SetData<dynamic>("school_in_stage", 0);

                school_checkpoint[Main.getIdFromClient(Client)].Delete();
                Client.TriggerEvent("DeleteRaceCheckpoint");

                Main.ShowColorShard(Client, "~g~Polozili ste !", "~w~Sada imate vozacku dozvolu!", 0, 5, 7000);

                Client.SetData<dynamic>("character_car_lic", 1);

                Main.SavePlayerInformation(Client);

                try
                {
                    school_vehicle[Main.getIdFromClient(Client)].Delete();
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }
            }
        }
        catch (Exception e)
        {
            NAPI.Util.ConsoleOutput("Player press E drivers licence");
            Console.Write(e);
        }
    }

    public static void OnEnterDynamicArea(Player Client, ColShape area)
    {

        if (school_checkpoint[Main.getIdFromClient(Client)] == area && Client.GetData<dynamic>("school_in_stage") == 2 && Client.GetData<dynamic>("school_in_teste") == 1 && Client.IsInVehicle && NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)VehicleHash.Dilettante && school_vehicle[Main.getIdFromClient(Client)].Exists)
        {
            //você deve estacionar seu veículo no centro, em sentido inverso e deve ser estacionado em linha reta!
           // Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Вы должны припарковать свой автомобиль на " + Main.EMBED_BLUE + "парковку" + Main.EMBED_WHITE + "" + Main.EMBED_LIGHTGREEN + "" + Main.EMBED_WHITE + "!");
        }

        if (school_checkpoint[Main.getIdFromClient(Client)] == area && Client.GetData<dynamic>("school_in_stage") != 2 && Client.GetData<dynamic>("school_in_teste") == 1 && Client.IsInVehicle && NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)VehicleHash.Dilettante && school_vehicle[Main.getIdFromClient(Client)].Exists)
        {
            if (Client.GetData<dynamic>("school_in_stage") == Client.GetData<dynamic>("school_in_stages") - 1)
            {
            //    Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Вы должны припарковать свой автомобиль на " + Main.EMBED_BLUE + "парковку" + Main.EMBED_WHITE + "" + Main.EMBED_LIGHTGREEN + "" + Main.EMBED_WHITE + "!");
            }
            else
            {
                if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "stop")
                {
                 //   Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Вы должны останавливаться перед " + Main.EMBED_LIGHTRED + "стоп линией" + Main.EMBED_WHITE + "");
                }
                else if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "ro be jolo")
                {
                    //   Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Продолжайте движение.");
                }
                else if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "amade_rast")
                {
                    //  Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Снизьте скорость и будте готовы повернуть " + Main.EMBED_LIGHTGREEN + "направо" + Main.EMBED_WHITE + ".");
                }
                else if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "amade_chap")
                {
                    //  Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Снизьте скорость и будте готовы повернуть " + Main.EMBED_LIGHTGREEN + "налево" + Main.EMBED_WHITE + ".");
                }
                else if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "chap")
                {
                    //   Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Повернуть " + Main.EMBED_LIGHTGREEN + "налево" + Main.EMBED_WHITE + ".");
                }
                else if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "rast")
                {
                    //   Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Повернуть " + Main.EMBED_LIGHTGREEN + "направо" + Main.EMBED_WHITE + ".");
                }
                else if (vehicle_rota[Client.GetData<dynamic>("school_in_stage")].message == "amade_Baraye_park")
                {
                    //  Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Снизьте скорость и будьте готовы въехать на парковку " + Main.EMBED_LIGHTGREEN + "справа" + Main.EMBED_WHITE + ".");
                }

                if (Client.GetData<dynamic>("school_in_stage") == 5)
                {
                    Client.TriggerEvent("StopVehicle");
                    Client.TriggerEvent("freezeVehicle", true);

                    //   Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Не забывайте останавливаться у " + Main.EMBED_LIGHTRED + "стоп линии" + Main.EMBED_WHITE + "!");

                    NAPI.Task.Run(() =>
                    {
                        if (NAPI.Player.IsPlayerConnected(Client))
                        {
                        //      Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_YELLOW + "[Auto-skola]", "Поверните " + Main.EMBED_LIGHTRED + "направо" + Main.EMBED_WHITE + "");
                        Client.TriggerEvent("freezeVehicle", false);
                        }
                    }, delayTime: 3000);
                }

                Main.DisplaySubtitle(Client, "Of course " + Client.GetData<dynamic>("school_in_stage") + " Baraye " + (Client.GetData<dynamic>("school_in_stage") + 1) + ".");
                Client.SetData<dynamic>("school_in_stage", Client.GetData<dynamic>("school_in_stage") + 1);
                Client.TriggerEvent("DeleteRaceCheckpoint");

                if (Client.GetData<dynamic>("school_in_stage") + 1 == Client.GetData<dynamic>("school_in_stages"))
                {
                    Client.TriggerEvent("CreateRaceCheckpoint", vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position - new Vector3(0, 0, 1.0), vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position);
                }
                else
                {
                    Client.TriggerEvent("CreateRaceCheckpoint", vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position - new Vector3(0, 0, 1.0), vehicle_rota[Client.GetData<dynamic>("school_in_stage") + 1].position);
                }

                school_checkpoint[Main.getIdFromClient(Client)].Delete();
                school_checkpoint[Main.getIdFromClient(Client)] = NAPI.ColShape.CreateCylinderColShape(vehicle_rota[Client.GetData<dynamic>("school_in_stage")].position, 5.0f, 4.0f);


            }
        }
    }



}

