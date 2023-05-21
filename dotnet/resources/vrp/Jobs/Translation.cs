using GTANetworkAPI;
using System;
using System.Collections.Generic;


public class Translation : Script
{
    public Translation()
    {
        //
        // Blips and Blips name
        //

        Entity temp_blip;
        temp_blip = NAPI.Blip.CreateBlip(new Vector3(430.7088, -983.0495, 30.71043));
        NAPI.Blip.SetBlipName(temp_blip, "Policijska uprava");
        NAPI.Blip.SetBlipSprite(temp_blip, 60);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 38);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(149.84868, -1040.7798, 29.374088));
        NAPI.Blip.SetBlipName(temp_blip, "Banka");
        NAPI.Blip.SetBlipSprite(temp_blip, 108);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 2);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(231.15, 214.62, 106.55));
        NAPI.Blip.SetBlipName(temp_blip, "Glavna Banka");
        NAPI.Blip.SetBlipSprite(temp_blip, 108);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 5);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-343.64, -139.07, 60.40));
        NAPI.Blip.SetBlipName(temp_blip, "Mehanicari");
        NAPI.Blip.SetBlipSprite(temp_blip, 446);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 30);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(2322.45, 4872.83, 50.00));
        NAPI.Blip.SetBlipName(temp_blip, "T1");
        NAPI.Blip.SetBlipSprite(temp_blip, 686);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 85);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(518.00, -2981.00, 50.00));
        NAPI.Blip.SetBlipName(temp_blip, "T2");
        NAPI.Blip.SetBlipSprite(temp_blip, 687);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 85);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(314.2728, -279.11133, 54.1708));
        NAPI.Blip.SetBlipName(temp_blip, "Banka");
        NAPI.Blip.SetBlipSprite(temp_blip, 108);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 2);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1212.7267, -330.8521, 37.787037));
        NAPI.Blip.SetBlipName(temp_blip, "Banka");
        NAPI.Blip.SetBlipSprite(temp_blip, 108);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 2);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(128.57, -1296.5, 29.26));
        NAPI.Blip.SetBlipName(temp_blip, "Klub");
        NAPI.Blip.SetBlipSprite(temp_blip, 121);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);
        NAPI.Blip.SetBlipColor(temp_blip, 83);////////

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(298.61848, -584.39493, 43.50094));
        NAPI.Blip.SetBlipName(temp_blip, "Bolnica");
        NAPI.Blip.SetBlipSprite(temp_blip, 153);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipColor(temp_blip, 1);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(30.53, -2774.82, 10.50));
        NAPI.Blip.SetBlipName(temp_blip, "Ship War");
        NAPI.Blip.SetBlipSprite(temp_blip, 780);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipColor(temp_blip, 1);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-188.8128, -1155.198, 23.04762));
        NAPI.Blip.SetBlipName(temp_blip, "Parking Servis");
        NAPI.Blip.SetBlipSprite(temp_blip, 225);
        NAPI.Blip.SetBlipColor(temp_blip, 1);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-14.03, -1443.87, 30.89));
        NAPI.Blip.SetBlipName(temp_blip, "Grove");
        NAPI.Blip.SetBlipSprite(temp_blip, 437);
        NAPI.Blip.SetBlipColor(temp_blip, 2);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(85.52, -1959.51, 21.12));
        NAPI.Blip.SetBlipName(temp_blip, "Ballas");
        NAPI.Blip.SetBlipSprite(temp_blip, 437);
        NAPI.Blip.SetBlipColor(temp_blip, 7);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(325.83, -2050.53, 20.93));
        NAPI.Blip.SetBlipName(temp_blip, "Vagos");
        NAPI.Blip.SetBlipSprite(temp_blip, 437);
        NAPI.Blip.SetBlipColor(temp_blip, 5);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(479.53, -1736.10, 29.15));
        NAPI.Blip.SetBlipName(temp_blip, "Aztecas");
        NAPI.Blip.SetBlipSprite(temp_blip, 437);
        NAPI.Blip.SetBlipColor(temp_blip, 3);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        /*temp_blip = NAPI.Blip.CreateBlip(new Vector3(903.7722, -173.3565, 74.07556));
        NAPI.Blip.SetBlipName(temp_blip, "Taksi");
        NAPI.Blip.SetBlipSprite(temp_blip, 198);
        NAPI.Blip.SetBlipColor(temp_blip, 46);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);*/

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-211.87, -1324.31, 30.89));
        NAPI.Blip.SetBlipName(temp_blip, "Tunning");
        NAPI.Blip.SetBlipSprite(temp_blip, 777);
        NAPI.Blip.SetBlipColor(temp_blip, 3);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);



        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-253.38, -2027.96, 30.10));
        NAPI.Blip.SetBlipName(temp_blip, "Arena");
        NAPI.Blip.SetBlipSprite(temp_blip, 546);
        NAPI.Blip.SetBlipColor(temp_blip, 5);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1388.17, -586.96, 32.10));
        NAPI.Blip.SetBlipName(temp_blip, "Bahamas");
        NAPI.Blip.SetBlipSprite(temp_blip, 133);
        NAPI.Blip.SetBlipColor(temp_blip, 3);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1991.71, 3055.52, 47.21));
        NAPI.Blip.SetBlipName(temp_blip, "RacePub");
        NAPI.Blip.SetBlipSprite(temp_blip, 315);
        NAPI.Blip.SetBlipColor(temp_blip, 3);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1536.50, 4637.14, 28.40));
        NAPI.Blip.SetBlipName(temp_blip, "Pecurke");
        NAPI.Blip.SetBlipSprite(temp_blip, 270);
        NAPI.Blip.SetBlipColor(temp_blip, 1);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-679.30, 5834.16, 20.40));
        NAPI.Blip.SetBlipName(temp_blip, "Prodaja Pecuraka");
        NAPI.Blip.SetBlipSprite(temp_blip, 270);
        NAPI.Blip.SetBlipColor(temp_blip, 4);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-564.77, 274.72, 84.11));
        NAPI.Blip.SetBlipName(temp_blip, "Tequilala");
        NAPI.Blip.SetBlipSprite(temp_blip, 766);
        NAPI.Blip.SetBlipColor(temp_blip, 8);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(1691.06, 2566.53, 61.10));
        NAPI.Blip.SetBlipName(temp_blip, "Zatvor");
        NAPI.Blip.SetBlipSprite(temp_blip, 188);
        NAPI.Blip.SetBlipColor(temp_blip, 4);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-637.19, -2259.37, 5.93));
        NAPI.Blip.SetBlipName(temp_blip, "Auto-skola");
        NAPI.Blip.SetBlipSprite(temp_blip, 498);
        NAPI.Blip.SetBlipColor(temp_blip, 2);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-580.90, -925.52, 36.83));
        NAPI.Blip.SetBlipName(temp_blip, "Weazel News");
        NAPI.Blip.SetBlipSprite(temp_blip, 817);
        NAPI.Blip.SetBlipColor(temp_blip, 61);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1041.93, -2744.39, 50.90));
        NAPI.Blip.SetBlipName(temp_blip, "Spawn");
        NAPI.Blip.SetBlipSprite(temp_blip, 120);
        NAPI.Blip.SetBlipColor(temp_blip, 4);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-294.11, -422.01, 30.23));
        NAPI.Blip.SetBlipName(temp_blip, "Registarske Tablice");
        NAPI.Blip.SetBlipSprite(temp_blip, 764);
        NAPI.Blip.SetBlipColor(temp_blip, 7);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-83.47, 79.86, 71.55));
        NAPI.Blip.SetBlipName(temp_blip, "Osiguranje");
        NAPI.Blip.SetBlipSprite(temp_blip, 662);
        NAPI.Blip.SetBlipColor(temp_blip, 53);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-693.46, -582.22, 31.55));
        NAPI.Blip.SetBlipName(temp_blip, "LomBank");
        NAPI.Blip.SetBlipSprite(temp_blip, 171);
        NAPI.Blip.SetBlipColor(temp_blip, 5);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-1200.00, -1571.00, 5.00));
        NAPI.Blip.SetBlipName(temp_blip, "Teretana");
        NAPI.Blip.SetBlipSprite(temp_blip, 311);
        NAPI.Blip.SetBlipColor(temp_blip, 38);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(938.26, 36.23, 120.00));
        NAPI.Blip.SetBlipName(temp_blip, "Casino");
        NAPI.Blip.SetBlipSprite(temp_blip, 681);
        NAPI.Blip.SetBlipColor(temp_blip, 5);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-2866.10, 2196.34, 38.00));
        NAPI.Blip.SetBlipName(temp_blip, "Route 68 CH");
        NAPI.Blip.SetBlipSprite(temp_blip, 791);
        NAPI.Blip.SetBlipColor(temp_blip, 8);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);

        temp_blip = NAPI.Blip.CreateBlip(new Vector3(-117.26, -604.52, 36.28));
        NAPI.Blip.SetBlipName(temp_blip, "Arcadius BC");
        NAPI.Blip.SetBlipSprite(temp_blip, 76);
        NAPI.Blip.SetBlipColor(temp_blip, 54);
        NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
        NAPI.Blip.SetBlipShortRange(temp_blip, true);


        //
        // Labels and Markers
        //

        //  NAPI.TextLabel.CreateTextLabel("- Band Helicopter - ", new Vector3(449.2292, -981.2446, 43.69167), 8.0f, 1.0f, 0, new Color(221, 255, 0, 255), false, 0);
        //  NAPI.Marker.CreateMarker(25, new Vector3(449.2292, -981.2446, 43.69167 - 0.8), new Vector3(), new Vector3(), 4.5f, new Color(221, 255, 0, 150), false, 0);


        //  NAPI.TextLabel.CreateTextLabel("- Band Helicopter - ", new Vector3(-450.1415, -306.9616, 78.16819), 8.0f, 1.0f, 0, new Color(221, 255, 0, 255), false, 0);
        //   NAPI.Marker.CreateMarker(25, new Vector3(-450.1415, -306.9616, 78.16819 - 0.8), new Vector3(), new Vector3(), 4.5f, new Color(221, 255, 0, 150), false, 0);

        NAPI.TextLabel.CreateTextLabel("~g~Uniforme ~w~~h~~n~~n~~w~ Koristite ~w~~g~ [ Y ]~w~ za interakciju", new Vector3(471.31, -990.81, 25.73 + 0.3), 5, 0.3500f, 4, new Color(221, 255, 0,255));
        NAPI.TextLabel.CreateTextLabel("~g~Dodaci ~w~~h~~n~~n~~w~ Koristite ~w~~g~ [ Y ]~w~ za interakciju", new Vector3(473.29, -984.71, 25.73 + 0.3), 5, 0.3500f, 4, new Color(221, 255, 0,255));
        NAPI.TextLabel.CreateTextLabel("~g~Krafting ~w~~h~~n~~n~~w~ Koristite ~w~~g~ [ Y ]~w~ za interakciju", new Vector3(568.30, -3123.49, 18.76 + 0.3), 5, 0.3500f, 4, new Color(221, 255, 0,255));

        NAPI.TextLabel.CreateTextLabel("~y~~h~- Garaza -~w~~h~~n~~n~~w~ Koristite ~w~~g~ [ Y ]~w~ da uzmete vozilo", new Vector3(467.95, -986.01, 25.72 + 0.3), 12, 0.650f, 0, new Color(221, 255, 0, 255));
        NAPI.Marker.CreateMarker(1, new Vector3(467.95, -986.01, 25.72 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

        NAPI.TextLabel.CreateTextLabel("~y~~h~- Oruzarnica -~w~~h~~n~~n~~w~ Koristite ~w~~g~ [ Y ]~w~ za interakciju", new Vector3(484.21, -1001.63, 25.73 + 0.3), 12, 0.650f, 0, new Color(221, 255, 0, 255));
        NAPI.Marker.CreateMarker(1, new Vector3(484.21, -1001.63, 25.73 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

        //
        NAPI.TextLabel.CreateTextLabel("~y~- Policijska uprava -~n~~n~~w~ Koristite ~w~ ~g~ [ Y ]~w~", new Vector3(441.28094, -981.8585, 30.6896 + 0.3), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
        NAPI.Marker.CreateMarker(1, new Vector3(441.28094, -981.8585, 30.6896 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

        NAPI.TextLabel.CreateTextLabel("~y~ Duznost~n~~w~Koristite ~w~ ~g~ [ Y ]~w~ da uzmete duznost", new Vector3(1834.7035, 3690.256, 34.270626 + 0.3), 12, 0.3500f, 0, new Color(221, 255, 0, 255));
        // NAPI.Marker.CreateMarker(0, new Vector3(359.41278, -1426.1544, 32.511112 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

        NAPI.TextLabel.CreateTextLabel("~y~~h~- Garaza -~w~~h~~n~~n~~w~ Koristite ~w~ ~g~ [ Y ]~w~ da uzmete vozilo", new Vector3(338.57, -586.43, 28.79), 12, 0.650f, 0, new Color(221, 255, 0, 255));
        //NAPI.Marker.CreateMarker(1, new Vector3(309.7644, -1435.5277, 29.96606 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

        NAPI.TextLabel.CreateTextLabel("~y~~h~- Parking Servis -~w~~h~~n~~n~~w~ Koristite ~w~ ~g~ [ Y ]~w~ da preuzmete vozilo", new Vector3(-177.1379, -1158.62, 23.81368 + 0.3), 12, 0.3500f, 0, new Color(221, 255, 0, 255));
        NAPI.Marker.CreateMarker(1, new Vector3(-177.1379, -1158.62, 23.81368 - 1.0), new Vector3(), new Vector3(), 0.6f, new Color(221, 255, 0, 155));

        NAPI.TextLabel.CreateTextLabel("~y~~h~- Parking Servis -~w~~h~~n~~n~~w~ Koristite ~w~ ~g~ [ Y ]~w~ da preuzmete vozilo", new Vector3(-202.0608, -1158.614, 23.81368 + 0.3), 12, 0.3500f, 0, new Color(221, 255, 0, 255));
        NAPI.Marker.CreateMarker(1, new Vector3(-202.0608, -1158.614, 23.81368 - 1.0), new Vector3(), new Vector3(), 0.6f, new Color(221, 255, 0, 155));

        ////striptiz

        NAPI.Marker.CreateMarker(1, new Vector3(114.74, -1285.81, 27.96 - 1.2), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

        // pd

        NAPI.TextLabel.CreateTextLabel("~g~ /arrest ID vreme ~n~~n~~w~", new Vector3(458.63, -985.65, 34.20 + 0.3), 12, 0.3500f, 0, new Color(221, 255, 0, 255));
        NAPI.TextLabel.CreateTextLabel("~g~ /arrest ID vreme ~n~~n~~w~", new Vector3(458.34, -1008.04, 28.27 + 0.3), 12, 0.3500f, 0, new Color(221, 255, 0, 255));
        NAPI.TextLabel.CreateTextLabel("~g~ /znacka ~n~~n~~w~", new Vector3(469.00632, -988.65173, 25.729673 + 0.3), 12, 0.3500f, 0, new Color(221, 255, 0, 255));
        //
        // Crime Names
        //

        NAPI.TextLabel.CreateTextLabel("~b~~h~- Auto Skola -~w~~h~~n~~n~~w~ ~w~~g~ [ Y ]~w~~n~~n~ ~g~ $2000", new Vector3(-637.19, -2259.37, 5.93 + 0.3), 12, 0.650f, 0, new Color(221, 255, 0, 255));
        NAPI.TextLabel.CreateTextLabel("~b~~h~- Avio Skola -~w~~h~~n~~n~~w~ ~w~~g~ [ Y ]~w~~n~~n~ ~g~ $5000", new Vector3(-639.66, -2258.72, 5.93 + 0.3), 12, 0.650f, 0, new Color(221, 255, 0, 255));
        NAPI.TextLabel.CreateTextLabel("~b~~h~- Moto Skola -~w~~h~~n~~n~~w~ ~w~~g~ [ Y ]~w~~n~~n~ ~g~ $3000", new Vector3(-635.00, -2259.24, 5.93 + 0.3), 12, 0.650f, 0, new Color(221, 255, 0, 255));
        NAPI.TextLabel.CreateTextLabel("~b~~h~- Oglasi -~w~~h~~n~~n~~w~ ~w~~g~ [ Y ]~w~", new Vector3(-600.42, -929.87, 23.86 + 0.3), 12, 0.650f, 0, new Color(221, 255, 0, 255));

        Main.crime_list.Add(new { crime_name = "Zlocin 1", crime_points = 1 });
        Main.crime_list.Add(new { crime_name = "Zlocin 2", crime_points = 2 });
        Main.crime_list.Add(new { crime_name = "Zlocin 3", crime_points = 3 });
        Main.crime_list.Add(new { crime_name = "Zlocin 4", crime_points = 3 });
        Main.crime_list.Add(new { crime_name = "Zlocin 5", crime_points = 3 });
        Main.crime_list.Add(new { crime_name = "Zlocin 6", crime_points = 5 });
        Main.crime_list.Add(new { crime_name = "Zlocin 7", crime_points = 5 });
        Main.crime_list.Add(new { crime_name = "Zlocin 8", crime_points = 7 });
        Main.crime_list.Add(new { crime_name = "Zlocin 9", crime_points = 7 });
        Main.crime_list.Add(new { crime_name = "Zlocin 10", crime_points = 10 });
        Main.crime_list.Add(new { crime_name = "Zlocin 11", crime_points = 10 });
        Main.crime_list.Add(new { crime_name = "Zlocin 12", crime_points = 10 });
        Main.crime_list.Add(new { crime_name = "Zlocin 13 ", crime_points = 15 });
        Main.crime_list.Add(new { crime_name = "Zlocin 14", crime_points = 30 });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 0, picture = "", name = "Nothing", Useable = false, description = "", guest = Inventory.ITEM_TYPE_NONE, hash = 0, position = 0f, weight = 0.00f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 1, picture = "water", name = "Voda", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 746336278, position = 0.9f, weight = 0.25f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 2, picture = "burger", name = "Burger", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4098414302, position = 1.0f, weight = 0.5f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 3, picture = "ammosniper", name = "7.62x51mm", Useable = true, description = "", guest = Inventory.ITEM_TYPE_Ammunation, hash = 1843823183, position = 1.0f, weight = 0.070f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 4, picture = "ammorifle", name = "7.62", Useable = true, description = "", guest = Inventory.ITEM_TYPE_Ammunation, hash = 1843823183, position = 1.0f, weight = 0.08f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 5, picture = "ammopump", name = "12x3mm", Useable = true, description = "", guest = Inventory.ITEM_TYPE_Ammunation, hash = 1843823183, position = 1.0f, weight = 0.100f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 6, picture = "ammopistol", name = "9mm", Useable = true, description = "", guest = Inventory.ITEM_TYPE_Ammunation, hash = 1843823183, position = 1.0f, weight = 0.04f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 7, picture = "ammosmg", name = ".45", Useable = true, description = "", guest = Inventory.ITEM_TYPE_Ammunation, hash = 1843823183, position = 1.0f, weight = 0.022f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 8, picture = "toolbox", name = "Fix Kit", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 3708911030, position = 0.8f, weight = 3.5f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 9, picture = "small_backpack", name = "Backpack2", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 1203231469, position = 0.8f, weight = 0.8f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 10, picture = "small_backpack", name = "Backpack", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3300226909, position = 0.8f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 11, picture = "weed", name = "List Marihuane", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 1696520608, position = 1.0f, weight = 0.9f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 12, picture = "weed-cigaret", name = "Marihuana", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4183981113, position = 1.0f, weight = 0.400f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 13, picture = "salt-rock", name = "Salt Rock", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 3300226909, position = 0.9f, weight = 0.8f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 14, picture = "salt-powder", name = "Salt", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 3300226909, position = 0.9f, weight = 0.6f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 15, picture = "cocain-leaves", name = "List Kokaina", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 1696520608, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 16, picture = "cocain", name = "Kokain", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3991509468, position = 1.0f, weight = 0.100f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 17, picture = "seed", name = "Wheat", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 3300226909, position = 0.9f, weight = 1.00f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 18, picture = "heavy-armor-vest", name = "Pancir", Useable = true, description = "", guest = Inventory.ITEM_TYPE_NONE, hash = 2515752923, position = 1.0f, weight = 5.00f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 19, picture = "c4", name = "C4", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 1876445962, position = 1.0f, weight = 2.05f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 20, picture = "drill", name = "Busilica", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3851537501, position = 1.0f, weight = 5.10f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 21, picture = "gascan", name = "Kanister", Useable = false, description = "", guest = Inventory.ITEM_TYPE_WORK, hash = 242383520, position = 1.0f, weight = 8.00f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 22, picture = "first_aid_pack", name = "Prva pomoc", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 678958360, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 23, picture = "radio", name = "Radio", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 2330564864, position = 1.0f, weight = 0.6f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 24, picture = "bboby-pin", name = "Pins", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1580014892, position = 1.0f, weight = 0.5f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 25, picture = "cableties", name = "Vezice", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3149903672, position = 1.0f, weight = 1.0f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 26, picture = "kod", name = "Kod", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 424800391, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 27, picture = "pills", name = "Tableta", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3538502018, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 28, picture = "picklock", name = "Kalauz", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 977923025, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 29, picture = "Ammonium_Nitrate", name = "Ammonium Nitrate", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1411212000, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 30, picture = "Ammonium_sulphate", name = "Ammonium sulphate", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1411212000, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 31, picture = "Monoammonium_phosphate", name = "Monoammonium phosphate", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1254553771, position = 1.0f, weight = 1.0f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 32, picture = "kod", name = "Kod", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 424800391, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 33, picture = "afat-kosh", name = "Afat Kosh", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3149903672, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 34, picture = "bil", name = "Bil", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1925751803, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 35, picture = "Ammonium_Nitrate", name = "Ammonium Nitrate", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1411212000, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 36, picture = "Ammonium_sulphate", name = "Ammonium sulphate", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1411212000, position = 1.0f, weight = 1.0f });
        

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 37, picture = "Iron", name = "Gvozdje", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3002107984, position = 1.0f, weight = 0.7f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 38, picture = "Copper", name = "Bakar", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4031179319, position = 1.0f, weight = 0.5f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 39, picture = "Silver", name = "Srebro", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3002107984, position = 1.0f, weight = 0.6f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 40, picture = "Gold", name = "Zlato", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4031179319, position = 1.0f, weight = 0.8f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 41, picture = "Platinum", name = "Platina", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 3002107984, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 42, picture = "jackhammer", name = "Burgija", Useable = false, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 1360563376, position = 1.0f, weight = 5.0f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 43, picture = "Gloves_Box", name = "Boxing Gloves", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 335898267, position = 1.0f, weight = 1f });

        Inventory.itens_available.Add(new Inventory.itemEnum { id = 44, picture = "hotdog", name = "Hot Dog", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4098414302, position = 1.0f, weight = 1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 45, picture = "sandwich", name = "Sandwich", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4098414302, position = 1.0f, weight = 1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 46, picture = "cola", name = "Coca Cola", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4098414302, position = 1.0f, weight = 1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 47, picture = "redwine", name = "Red Wine", Useable = true, description = "", guest = Inventory.ITEM_TYPE_CONSUMIBLE, hash = 4098414302, position = 1.0f, weight = 1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 48, picture = "kicon", name = "Knjiga Recepata", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 2025816514, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 49, picture = "opruga", name = "Opruga", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.8f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 50, picture = "cev_za_pusku", name = "Cev za pusku", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 1.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 51, picture = "chip", name = "Cip", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 52, picture = "kevlar", name = "Kevlar", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 53, picture = "kundak_puske", name = "Kundak Puske", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 54, picture = "okicad", name = "Okidac", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 55, picture = "sarzer_za_pistolj", name = "Mali sanzer", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 56, picture = "sarzer_za_pusku", name = "Veliki sanzer", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 57, picture = "snajperski_nisan", name = "Nisan", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 58, picture = "usb", name = "USB", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 59, picture = "maticna_ploca", name = "Maticna Ploca", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 60, picture = "576", name = "Hack One", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 61, picture = "Spunk", name = "Sprunk", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 2973713592, position = 1.0f, weight = 0.33f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 62, picture = "eCola", name = "eCola", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 1020618269, position = 1.0f, weight = 0.33f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 63, picture = "Kafa", name = "Kafa", Useable = true, description = "Coffee to go :)", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3696781377, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 64, picture = "rpvc", name = "rpv coin", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 1597489407, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 65, picture = "heroin", name = "Heroin", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3991509468, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 66, picture = "opium", name = "Opium", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3991509468, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 67, picture = "morfin", name = "Morfin", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3991509468, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 68, picture = "beer", name = "Pivo", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 683570518, position = 1.0f, weight = 0.3f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 69, picture = "konjak", name = "Konjak", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 2833294155, position = 1.0f, weight = 0.2f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 70, picture = "viski", name = "Viski", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 2833294155, position = 1.0f, weight = 0.1f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 71, picture = "votka", name = "Votka", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 2833294155, position = 1.0f, weight = 0.4f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 72, picture = "sampanjac", name = "Sampanjac", Useable = true, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 1053267296, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 73, picture = "ccip", name = "Chip", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3575239779, position = 1.0f, weight = 0.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 74, picture = "babuska", name = "Babuska", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3708998996, position = 1.0f, weight = 0.5f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 75, picture = "saran", name = "Saran", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3708998996, position = 1.0f, weight = 0.6f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 76, picture = "som", name = "Som", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3708998996, position = 1.0f, weight = 0.7f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 77, picture = "pajser", name = "Pajser", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 495450405, position = 1.0f, weight = 2.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 78, picture = "nakit", name = "Nakit", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 4248462993, position = 1.0f, weight = 0.1f });

        //vehtunning
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 79, picture = "eng1", name = "Chip Motora", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 648185618, position = 1.0f, weight = 5.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 80, picture = "goldbar", name = "Zlatna Poluga", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 4031179319, position = 1.0f, weight = 1.0f });
        Inventory.itens_available.Add(new Inventory.itemEnum { id = 81, picture = "shroom", name = "Pecurka", Useable = false, description = "", guest = Inventory.ITEM_TYPE_MISCELLANEOUS, hash = 3267161942, position = 1.0f, weight = 0.3f });

    }//prop_michael_sec_id    //Page 74 KIF  //prop_fib_badge

    //
    // Others
    //
    public static string invalid_command = "Pogresna komanda";

    public static string message_error = "Greska";
    public static string message_info = "Info";
    public static string message_warning = "Greska";
    public static string message_success = "Info";


    public static string chat_mask_type = "Maskiran_";
    public static string chat_cellphone_type = "(Telefon)";
    public static string chat_unknow_type = "Stranac_";

    public static string other_1 = "Teritorija";
    public static string other_2 = "Nije zauzeta";

    //
    // Vehicle Class
    //
    public static string DEALERSHIP_TYPE_CAR = "Auto salon";
    public static string DEALERSHIP_TYPE_BIKE = "Moto salon";
    public static string DEALERSHIP_TYPE_BOAT = "Salon plovila";
    public static string DEALERSHIP_TYPE_HELLI = "Salon letelica";
    public static string DEALERSHIP_TYPE_TRUCK = "Salon kamiona";

    // ===============================================================
    // ===============================================================

    //
    // Business Manage
    // ** !! DO NOT DUPLICATE THESE'S NAMES !

    public static string BUSINESS_MANAGE_MENU_1 = "Ime";
    public static string BUSINESS_MANAGE_MENU_2 = "Vrsta";
    public static string BUSINESS_MANAGE_MENU_3 = "Tip";
    public static string BUSINESS_MANAGE_MENU_4 = "Klasa";
    public static string BUSINESS_MANAGE_MENU_5 = "Kapacitet skladista";
    public static string BUSINESS_MANAGE_MENU_6 = "Mesto prodaje";
    public static string BUSINESS_MANAGE_MENU_7 = "Mesto isporuke";
    public static string BUSINESS_MANAGE_MENU_8 = "Izbor odece";
    public static string BUSINESS_MANAGE_MENU_9 = "Kasa";
    public static string BUSINESS_MANAGE_MENU_10 = "Mesto za kupovinu oruzja";
    public static string BUSINESS_MANAGE_MENU_11 = "Benzinska pumpa #1";
    public static string BUSINESS_MANAGE_MENU_12 = "Benzinska pumpa #2";
    public static string BUSINESS_MANAGE_MENU_13 = "Benzinska pumpa #3";
    public static string BUSINESS_MANAGE_MENU_14 = "Benzinska pumpa #4";
    public static string BUSINESS_MANAGE_MENU_15 = "Benzinska pumpa #5";
    public static string BUSINESS_MANAGE_MENU_16 = "Benzinska pumpa #6";
    public static string BUSINESS_MANAGE_MENU_17 = "Benzinska pumpa #7";
    public static string BUSINESS_MANAGE_MENU_18 = "Benzinska pumpa #8";
    public static string BUSINESS_MANAGE_MENU_19 = "Benzinska pumpa #9";
    public static string BUSINESS_MANAGE_MENU_20 = "Interakcioni meni";
    public static string BUSINESS_MANAGE_MENU_21 = "Pregled vozila";
    public static string BUSINESS_MANAGE_MENU_22 = "Kupovina vozila";
    public static string BUSINESS_MANAGE_MENU_23 = "Mesto za frizera / tatto";
    public static string BUSINESS_MANAGE_MENU_24 = "Mesto za meni - Chemical";
    public static string BUSINESS_MANAGE_MENU_25 = "Mesto za meni - Tattoo";

    //
    // Business Owner Manage
    // ** !! DO NOT DUPLICATE THESE'S NAMES !
    public static string BUSINESS_PLAYER_MENU_1 = "Naziv biznisa";
    public static string BUSINESS_PLAYER_MENU_2 = "Zakljucavanje";
    public static string BUSINESS_PLAYER_MENU_3 = "Sef";
    public static string BUSINESS_PLAYER_MENU_4 = "Izmenite cenu oruzja";
    public static string BUSINESS_PLAYER_MENU_6 = "Izmenite cenu benzina";
    public static string BUSINESS_PLAYER_MENU_7 = "Narucite produkate";
    public static string BUSINESS_PLAYER_MENU_8 = "Prodaj biznis";




    // ===============================================================
    // ===============================================================


    //
    // Interact With Vehicle
    // ** !! DO NOT DUPLICATE THESE'S NAMES !
    public static string INTERACT_VEHICLE_MENU = "Meni vozila";
    public static string INTERACT_VEHICLE_MENU_1 = "Zakljucavanje";
    public static string INTERACT_VEHICLE_MENU_2 = "Popravka";
    public static string INTERACT_VEHICLE_MENU_3 = "Napuni gorivo";
    public static string INTERACT_VEHICLE_MENU_4 = "Gepek";
    public static string INTERACT_VEHICLE_MENU_5 = "Pretres vozila";    ///ADD Bayad beshe to Circle
    public static string INTERACT_VEHICLE_MENU_6 = "Izvaditi iz vozila";
    public static string INTERACT_VEHICLE_MENU_7 = "Zaplena";
    public static string INTERACT_VEHICLE_MENU_8 = "Kazna";

    //
    // Interact With Player to Target
    // ** !! DO NOT DUPLICATE THESE'S NAMES !
    public static string INTERACT_PLAYER_TARGET_MENU = "Interakcija";
    public static string INTERACT_PLAYER_TARGET_MENU_SUBTITLE = "~g~Interakcija {0}";
    public static string INTERACT_PLAYER_TARGET_MENU_1 = "Daj novac";
    public static string INTERACT_PLAYER_TARGET_MENU_2 = "Pokazi licnu kartu";
    public static string INTERACT_PLAYER_TARGET_MENU_3 = "Pokazi dozvole";
    public static string INTERACT_PLAYER_TARGET_MENU_4 = "Zavezi";
    public static string INTERACT_PLAYER_TARGET_MENU_5 = "Odvezi";
    public static string INTERACT_PLAYER_TARGET_MENU_6 = "Vuci";
    public static string INTERACT_PLAYER_TARGET_MENU_7 = "Pusti";
    public static string INTERACT_PLAYER_TARGET_MENU_8 = "Oduzmi";
    public static string INTERACT_PLAYER_TARGET_MENU_9 = "Razoruzaj";
    public static string INTERACT_PLAYER_TARGET_MENU_10 = "Pretres";
    public static string INTERACT_PLAYER_TARGET_MENU_11 = "Napisi kaznu";
    public static string INTERACT_PLAYER_TARGET_MENU_12 = "Osumnjici";
    public static string INTERACT_PLAYER_TARGET_MENU_13 = "Uhapsi";
    public static string INTERACT_PLAYER_TARGET_MENU_14 = "Zadrzati";
    public static string INTERACT_PLAYER_TARGET_MENU_15 = "Napisati";
    public static string INTERACT_PLAYER_TARGET_MENU_16 = "Izleci";
    public static string INTERACT_PLAYER_TARGET_MENU_17 = "Reanimacija";
    public static string INTERACT_PLAYER_TARGET_MENU_18 = "Pozovi";

    public static string INTERACT_PLAYER_TARGET_MENU_19 = "Nepoznato 1";    ///ADD Bayad beshe to Circle
    public static string INTERACT_PLAYER_TARGET_MENU_20 = "Nepoznato 2";     ///ADD Bayad beshe to Circle


    //
    // Interact with Client
    // ** !! DO NOT DUPLICATE THESE'S NAMES !
    public static string INTERACT_PLAYER_MENU = "";
    public static string INTERACT_PLAYER_MENU_5 = "Kupi kucu";
    public static string INTERACT_PLAYER_MENU_6 = "Prodaj kucu";
    //public static string INTERACT_PLAYER_MENU_7 = "Upravljanje kucom";
    public static string INTERACT_PLAYER_MENU_8 = "Kupi strip";
    public static string INTERACT_PLAYER_MENU_9 = "Prodaj strip";
    public static string INTERACT_PLAYER_MENU_10 = "Prihvati poziv";
    public static string INTERACT_PLAYER_MENU_11 = "Odbij poziv";
    public static string INTERACT_PLAYER_MENU_12 = "Prihvati kaznu";
    public static string INTERACT_PLAYER_MENU_13 = "Odbij kaznu";
    public static string INTERACT_PLAYER_MENU_14 = "Prihvati lecenje";
    public static string INTERACT_PLAYER_MENU_15 = "Odbij lecenje";
    public static string INTERACT_PLAYER_MENU_16 = "Ukradi";
    public static string INTERACT_PLAYER_MENU_17 = "Zavezi";
    public static string INTERACT_PLAYER_MENU_18 = "Stavi pojas";
    public static string INTERACT_PLAYER_MENU_19 = "Parkiraj";
    public static string INTERACT_PLAYER_MENU_20 = "Otkljucaj";
    public static string INTERACT_PLAYER_MENU_21 = "Zakljucaj";
    public static string INTERACT_PLAYER_MENU_22 = "Gepek";
    public static string INTERACT_PLAYER_MENU_23 = "Tempomat";
    public static string INTERACT_PLAYER_MENU_24 = "Iskljuci taksimetar";
    public static string INTERACT_PLAYER_MENU_25 = "Taksimetar";
    public static string INTERACT_PLAYER_MENU_26 = "Stats";
    public static string INTERACT_PLAYER_MENU_27 = "Licna karta";
    public static string INTERACT_PLAYER_MENU_28 = "Dozvole";
    // public static string INTERACT_PLAYER_MENU_29 = "Фракции";
    public static string INTERACT_PLAYER_MENU_30 = "Posao";
    public static string INTERACT_PLAYER_MENU_31 = "Maska";
    public static string INTERACT_PLAYER_MENU_32 = "Kapa";
    public static string INTERACT_PLAYER_MENU_33 = "Naocare";
    public static string INTERACT_PLAYER_MENU_34 = "Otkazi pomoc";
    public static string INTERACT_PLAYER_MENU_35 = "Pozovi pomoc";
    // public static string INTERACT_PLAYER_MENU_36 = "Найти Место Работы";
    //  public static string INTERACT_PLAYER_MENU_37 = "Завершить Обслуживание";
    public static string INTERACT_PLAYER_MENU_38 = "Zavrsi posao";
    public static string INTERACT_PLAYER_MENU_39 = "Postavi GPS do mesta za prodaju zita";
    public static string INTERACT_PLAYER_MENU_40 = "Poruka dana";
    public static string INTERACT_PLAYER_MENU_41 = "Upravljanje";
    public static string INTERACT_PLAYER_MENU_42 = "Promeni rank";
    public static string INTERACT_PLAYER_MENU_43 = "Lista clanova";
    public static string INTERACT_PLAYER_MENU_44 = "Napusti organizaciju";

    public static string INTERACT_PLAYER_MENU_47 = "Skraceni naziv";
    public static string INTERACT_PLAYER_MENU_48 = "Boja organizacije";

    public static string INTERACT_PLAYER_MENU_45 = "Seksualni odnos";
    public static string INTERACT_PLAYER_MENU_46 = "Zavrsi seks";

    public static string INTERACT_PLAYER_MENU_49 = "Armor";

    //
    // Commands
    //


    //
    // Shard
    //


    public static string shard_give_experience = "Sada ste {0} level {1}.";
    public static string shard_01 = "Poslati ste u bolnicu na lecenje.";
    public static string shard_01_title = "Uspesno !";

    public static string shard_2 = "~y~Bili ste tesko povredjeni !!";
    public static string shard_2_title = "Izgubili ste svest.";



    //
    // Messages
    //
    //string.Format(Translation.message_04)

    public static string vehicle_destroy_send_mors = "Vas {0} je unisten, mozete ga preuzeti u Parking Servisu.";
    public static string message_taxi_driver_exit_Vehicle = "~y~*~w~ Napustili ste taksi vozilo i naplatili ~g~${0}~w~ za prevoz.";
    public static string message_taxi_passager_exit_Vehicle = "~y~*~w~ Taksi vozac je napustio vozilo, platili ste ~g~${0}~w~ za prevoz.";
    public static string message_taxi_passager_exit_vehicle_2 = "~y~*~w~ Napustili ste taksi vozilo i platili ~g~${0}~w~ za prevoz.";
    public static string message_taxi_passager_exit_vehicle_3 = "~y~*~w~ {0} je napustio taksi vozilo i platio {1} za prevoz.";
    public static string message_taxi_passager_exit_vehicle_4 = "~w~Nemate dovoljno novca, cena po kilometru je ~g~${0}~w~.";

    public static string message_01 = "Vase vozilo se pokvarilo, pozovite mehanicara!";
    public static string message_02 = "[Zona]:~w~ {0} je ubijen na zoni {1}.";
    public static string message_03 = "[Zona]:~w~ Clan ~g~{0}~w~ je ubijen na zoni ~y~{1}~w~.";
    public static string message_04 = "[Zona]:~w~ {0} je ubijen od strane {1} na zoni ~y~{2}~w~.";
    public static string message_05 = "[Zona]:~w~ {0} je ubio {1} na zoni ~y~{2}~w~.";
    public static string message_06 = "Bili ste bez svesti pa ste hitno prebaceni u bolnicu.";
    public static string message_07 = "okrece kljuc i pokusava da startuje motor vozila .";
    public static string message_08 = "~c~ Platili ste porez !";
    public static string message_09 = "~g~ Postujte pravila servera, u suprotnom mozete biti kaznjeni!";
    public static string message_10 = "Vasi troskovi lecenja iznose: ~g~$2,500~w~!";
    public static string message_11 = "~g~[Zona]:~w~ Zona ~y~{0}~w~ je dostupna za zauzimanje.";
    public static string message_12 = "~g~[Zona]:~w~Dobili ste ~g~$~y~{0}~w~, zbog osvojene teritorije {1}.";
    public static string message_13 = "Niste u salonu.";
    public static string message_14 = "Nemate dovoljno novca.";
    public static string message_15 = "Trenutno nemamo taj proizvod !";
    public static string message_16 = "Promenili ste izgled u salonu {0}.";
    public static string message_17 = "Ne mozete to sada!";

    //
    // Notifications
    //
    public static string notification_info_seatbelt = "Seli ste u auto, vezite pojas!";
    public static string notification_enter_vehicle_ticket = "Imate ~y~{0}~w~ kaznu ~g~$ {1}~w~, idite u ~g~Policiju~w~ da platite kaznu.";

    public static string notification_1 = "Sacekajte malo pa pokusajte ponovo !";
    public static string notification_2 = "Uneli ste pogresno ime ili sifru !";
    public static string notification_3 = "Vase ime mora imati najmanje 4 i najvise 30 karaktera!";
    public static string notification_4 = "Vasa lozinka mora imati najmanje 4 i najvise 30 karaktera.";
    public static string notification_5 = "Pogresna email adresa.";
    public static string notification_6 = "Nemate kljuc!";
    public static string notification_7 = "Vasa kuca je " + Main.EMBED_LIGHTGREEN + "otkljucana" + Main.EMBED_WHITE + ".";
    public static string notification_8 = "Vasa kuca je " + Main.EMBED_RED + "zakljucana" + Main.EMBED_WHITE + ".";
    public static string notification_9 = "Niste na duznosti";
    public static string notification_10 = "Ne mozete to iz vozila!";
    public static string notification_11 = "~g~Zapoceli ste~w~ smenu.";
    public static string notification_12 = "~r~Zavrsili ste~w~ smenu.";
    public static string notification_13 = "Vrata su zakljucana.";
    public static string notification_14 = "Efekat heroina je prosao.";
    public static string notification_15 = "Efekat marihuane je prosao.";
    public static string notification_16 = "Vise ne dugujete, sada ste slobodan gradjanin!";
    public static string notification_17 = "Osecate se lose, morate da ~y~jedete~w~ i ~g~pijete~w~!";
    public static string notification_18 = "Gladni ste, pojedite nesto!";
    public static string notification_19 = "Zedni ste, popijte nesto!";

    //
    // Head Notificationhead_notification_9
    //
    public static string head_notification_0 = "Ugasili ste motor.";
    public static string head_notification_1 = "Otkljucano";
    public static string head_notification_2 = "Zakljucano";
    public static string head_notification_3 = "Ugasili ste motor.";
    public static string head_notification_4 = "Nema goriva.";
    public static string head_notification_5 = "Pokusavate da upalite motor";
    public static string head_notification_6 = "Motor je pokvaren";
    public static string head_notification_7 = "Motor je ugasen";
    public static string head_notification_8 = "Nema vise goriva";
    public static string head_notification_9 = "Motor je pokrenut";
    public static string head_notification_10 = "Nema produkata";
    public static string head_notification_11 = "Prijavite se na duznost.";

    //
    // Label
    //

    public static string ls_custom_label_free = "Koristite [ ~g~E~w~ ] da tunirate vozilo!";
    public static string ls_custom_label_free1 = "Koristite [ ~g~E~w~ ] da tunirate vozilo!";
    public static string ls_custom_label_busy = "Zauzeto";

    //
    // Drawtext
    //
    public static string draw_engine_vehicle_off = "Koristite ~w~ ~g~ [ Y ] ~w~ da pokrenete motor.";
    //   "";


    public static void Create_Mechanic_Menu(Player Client)
    {
        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Duznost", Description = "", RightLabel = "" });

        if (AccountManage.GetPlayerJob(Client) == 7)
        {
            menu_item_list.Add(new { Type = 1, Name = "~g~Katalog", Description = "", RightLabel = "" });
        }
        InteractMenu.CreateMenu(Client, "JOB_SHIPMENT", "Trucker", "~g~Porudzbine:", false, NAPI.Util.ToJson(menu_item_list), false);
    }

    public static void FirstAccount_Logged(Player Client)
    {
        NAPI.Entity.SetEntityPosition(Client, new Vector3(-1038.75, -2740.24, 13.90));
        NAPI.Entity.SetEntityRotation(Client, new Vector3(0, 0, -31));
        NAPI.Entity.SetEntityDimension(Client, 0);

        Main.SetPlayerMoney(Client, 2000);
        Main.SetPlayerMoneyBank(Client, 10000);

        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "", "~g~Dobrodosli na RP-V");
        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "", "~g~Server je u fazi Otvorene Bete");
        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "", "~g~Posetite nas sajt www.rp-v.com");
        Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "", "~g~Pritisnite F3 za listu komandi");
        Client.ResetData("firstJoinned");


        CharCreator.CharCreator.SaveChar(Client);
    }
    public static async System.Threading.Tasks.Task Account_Logged(Player Client)
    {
        DateTime last_login = Client.GetData<dynamic>("character_last_login");


        if (VIP.GetPlayerVIP(Client) != 0)
        {
            DateTime vip_expire = Client.GetData<dynamic>("character_vip_expire");
            if (vip_expire < DateTime.Now)
            {
                //   Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "[VIP]", "VIP Shoma Be Etmam Reside, Jahat Kharid Be Shop Moraje'e Konid.");
                NAPI.Data.SetEntityData(Client, "character_vip", 0);
                NAPI.Data.SetEntityData(Client, "character_vip_expire", 0);

            }
            else
            {
                //      Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_VIP + "[VIP]", "Shoma " + Main.EMBED_VIP + " VIP  " + Main.EMBED_WHITE + "Hastid. Etebar VIP Shoma Ta Tarikh: " + Main.EMBED_LIGHTGREEN + "" + vip_expire.ToString("dd/MM/yyyy HH:mm:ss") + "" + Main.EMBED_WHITE + "Mibashad.");
            }
        }

        // if (AccountManage.GetPlayerGroup(Client) != 0 && FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_motd != "") Main.SendMessageWithTagToPlayer(Client, "" + Main.EMBED_LIGHTGREEN + "[Faction]", FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_motd);
    }



    public static void PayExp(Player Client)
    {
        if (VIP.GetPlayerVIP(Client) == 1)
        {
            int new_exp = (Client.GetData<dynamic>("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY) + (int)(0.20 * (Client.GetData<dynamic>("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY));
            // Main.SendCustomChatMessasge(Client, "  ~w~Experience gained: ~y~" + new_exp + "");
        }
        else
        {
            // Main.SendCustomChatMessasge(Client, "  ~w~Experience gained: ~y~" + (Client.GetData<dynamic>("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY) + "");
        }

        if (VIP.GetPlayerVIP(Client) == 1)
        {
            int new_exp = (Client.GetData<dynamic>("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY) + (int)(0.20 * (Client.GetData<dynamic>("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY));
            Main.GivePlayerEXP(Client, new_exp);
        }
        else
        {
            Main.GivePlayerEXP(Client, Client.GetData<dynamic>("character_level") * Economy.XP_RATE * Economy.XP_RATE_HOURLY);
        }
        Client.SetSharedData("character_level", Client.GetData<dynamic>("character_level"));
    }

    public static void PayDay(Player Client)
    {
        if (Client.GetData<dynamic>("status") == true)
        {
            
            if (Client.GetSharedData<dynamic>("character_wanted_level") > 0)
            {
                if(VIP.GetPlayerVIP(Client) == 1 && Client.GetSharedData<dynamic>("character_wanted_level") > 2)
                {
                    Police.wantedlevelminus(Client, -2);
                }
                else
                {
                    Police.wantedlevelminus(Client, -1);
                }
            }
            if (FactionManage.GetPlayerGroupID(Client) == FactionManage.FACTION_TYPE_POLICE || FactionManage.GetPlayerGroupID(Client) == FactionManage.FACTION_TYPE_MEDIC)
            {
                Main.SendCustomChatMessasge(Client, "  ~w~Plata: ~g~$~y~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_salary[AccountManage.GetPlayerRank(Client)].ToString("N0") + "");
                Main.GivePlayerSalary(Client, FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_salary[AccountManage.GetPlayerRank(Client)]);
            }
            // ristini kurci
            if (Client.GetData<dynamic>("character_gun_lic") > 0)
            {
                Client.SetData<dynamic>("character_gun_lic", Client.GetData<dynamic>("character_gun_lic") - 1);
            }
            if (Client.GetData<dynamic>("character_car_lic") > 0)
            {
                Client.SetData<dynamic>("character_car_lic", Client.GetData<dynamic>("character_car_lic") - 1);
            }
            if (Client.GetData<dynamic>("character_fish_lic") > 0)
            {
                Client.SetData<dynamic>("character_fish_lic", Client.GetData<dynamic>("character_fish_lic") - 1);
            }
            if (Client.GetData<dynamic>("character_fly_lic") > 0)
            {
                Client.SetData<dynamic>("character_fly_lic", Client.GetData<dynamic>("character_fly_lic") - 1);
            }
            if (Client.GetData<dynamic>("character_moto_lic") > 0)
            {
                Client.SetData<dynamic>("character_moto_lic", Client.GetData<dynamic>("character_moto_lic") - 1);
            }
            
           
            Main.SavePlayerInformation(Client);
            foreach (var veh in NAPI.Pools.GetAllVehicles())
            {
                if (veh.GetData<dynamic>("Owner_set") == true)
                {
                    Main.CreateMySqlCommand("UPDATE `vehicles` SET `veh_osiguranje` = `veh_osiguranje` - 1 WHERE `veh_osiguranje` > 0");
                }
                
            }

        }
    }


    public static void ShowPlayerStats(Player Client, Player target)
    {
        int new_level = (50 * (Client.GetData<dynamic>("character_level")) * (Client.GetData<dynamic>("character_level")) * (Client.GetData<dynamic>("character_level")) - 150 * (Client.GetData<dynamic>("character_level")) * (Client.GetData<dynamic>("character_level")) + 600 * (Client.GetData<dynamic>("character_level"))) / 5;

        //   Main.SendCustomChatMessasge(target, "~o~" + Main.SERVER_NAME + "~y~ - Player stats - ~g~" + AccountManage.GetCharacterName(Client) + "~w~.");
        //   Main.SendCustomChatMessasge(target, "~y~------------------------------------------------------------------");
        Main.SendCustomChatMessasge(target, "~w~ | Plata: ~g~$" + Main.GetSalaryFromBank(Client) + "~w~ | RPV Poena: ~g~" + Client.GetData<dynamic>("character_credits"));
        Main.SendCustomChatMessasge(target, "~w~ | Posao: ~g~"+Job_Controler.PlayerJobName(Client) +"~w~ | XP na poslu: ~g~" + Client.GetData<dynamic>("jobskill"));
        if (AccountManage.GetPlayerGroup(Client) != 0) Main.SendCustomChatMessasge(target, "~w~  |  ~w~Organizacija: ~g~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_name + "~w~ | Rank: ~g~" + FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_rank[AccountManage.GetPlayerRank(Client)] + "");
        
        Main.SendCustomChatMessasge(target, "~g~Experience~w~  |  Trenutni Level: ~y~" + Client.GetData<dynamic>("character_level") + "~w~  |  Trenutni Experience: ~y~" + Client.GetData<dynamic>("character_exp") + "/" + new_level + "");
        Main.SendCustomChatMessasge(target, "~g~Refferal~w~  |  ~y~" + Client.GetData<dynamic>("refferal"));

        Main.SendCustomChatMessasge(target, "~y~------------------------------------------------------------------");
    }
}

