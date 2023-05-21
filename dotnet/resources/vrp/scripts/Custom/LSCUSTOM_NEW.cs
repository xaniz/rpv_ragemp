
using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class LSCUSTOM_NEW : Script
{
    public static List<dynamic> colors = new List<dynamic>();
    public static List<dynamic> metalcolors = new List<dynamic>();
    public static List<dynamic> mattecolors = new List<dynamic>();

    public static List<dynamic> chrome = new List<dynamic>();
    public static List<dynamic> windowtint = new List<dynamic>();
    public static List<dynamic> neoncolor = new List<dynamic>();
    public static List<dynamic> plates = new List<dynamic>();
    public static List<dynamic> wheelaccessories = new List<dynamic>();
    public static List<dynamic> frontwheel = new List<dynamic>();
    public static List<dynamic> backwheel = new List<dynamic>();
    public static List<dynamic> sportwheels = new List<dynamic>();
    public static List<dynamic> suvwheels = new List<dynamic>();
    public static List<dynamic> offroadwheels = new List<dynamic>();
    public static List<dynamic> tunerwheels = new List<dynamic>();
    public static List<dynamic> highendwheels = new List<dynamic>();
    public static List<dynamic> lowriderwheels = new List<dynamic>();
    public static List<dynamic> musclewheels = new List<dynamic>();
    public static List<dynamic> Turbo = new List<dynamic>();
    public static List<dynamic> Armor = new List<dynamic>();
    public static List<dynamic> Suspension = new List<dynamic>();
    public static List<dynamic> Horn = new List<dynamic>();
    public static List<dynamic> Transmission = new List<dynamic>();
    public static List<dynamic> Brakes = new List<dynamic>();
    public static List<dynamic> Engine = new List<dynamic>();
    public static List<dynamic> neonlayout = new List<dynamic>();
    public static List<dynamic> Headlights = new List<dynamic>();


    public static int AEROFOLIO_PRICE = 1250, AEROFOLIO_PRICE_INCREASE = 650,
        SAIAS_PRICE = 850, SAIAS_PRICE_INCREASE = 310,
        Exhaust_PRICE = 900, Exhaust_PRICE_INCREASE = 350,
        Grilles_PRICE = 800, Grilles_PRICE_INCREASE = 270,
        CAPO_PRICE = 1300, CAPO_PRICE_INCREASE = 733,
        PARALAMAS_PRICE = 900, PARALAMAS_PRICE_INCREASE = 370,
        TETO_PRICE = 1150, TETO_PRICE_INCREASE = 500,
        LIVERIES_PRICE = 3100, LIVERIES_PRICE_INCREASE = 800,
        PARACHOQUEFRONTAL_PRICE = 1150, PARACHOQUEFRONTAL_PRICE_INCREASE = 680,
        PARACHOQUETRASEIRO_PRICE = 1050, PARACHOQUETRASEIRO_PRICE_INCREASE = 630,
        FAROLPERSONALIZADO_PRICE = 850, FAROLPERSONALIZADO_PRICE_INCREASE = 420,
        ANTENAS_PRICE = 530, ANTENAS_PRICE_INCREASE = 200,
        SAIDADEAR_PRICE = 450, SAIDADEAR_PRICE_INCREASE = 320,
        TANQUE_PRICE = 380, TANQUE_PRICE_INCREASE = 150,
        VIDRO_PRICE = 320, VIDRO_PRICE_INCREASE = 90,
        SANTANTONIO_PRICE = 1100, SANTANTONIO_PRICE_INCREASE = 488,
        COLORCLASSIC_PRICE = 3250, COLORCLASSIC_PRICE_INCREASE = 0,
        COLORMETAL_PRICE = 5800, COLORMETAL_PRICE_INCREASE = 0,
        MATTECOLOR_PRICE = 6500, MATTECOLOR_PRICE_INCREASE = 0,
        CHROMECOLOR_PRICE = 30000, CHROMECOLOR_PRICE_INCREASE = 0,
        METTALICCOLOR_PRICE = 5800, METTALICCOLOR_PRICE_INCREASE = 0,
        FRONTWHEEL_PRICE = 2500, FRONTWHEEL_PRICE_INCREASE = 0,
        BACKWHEEL_PRICE = 2500, BACKWHEEL_PRICE_INCREASE = 0,
        SPORTWHEEL_PRICE = 8200, SPORTWHEEL_PRICE_INCREASE = 100,
        SUVWHEEL_PRICE = 4200, SUVWHEEL_PRICE_INCREASE = 50,
        OFFROADWHEEL_PRICE = 4100, OFROADWHEEL_PRICE_INCREASE = 70,
        TUNERWHEEL_PRICE = 4500, TUNERWHEEL_PRICE_INCREASE = 85,
        HIGHENDWHELL_PRICE = 13000, HIGHENDWHELL_PRICE_INCREASE = 250,
        LOWRIDERWHEEL_PRICE = 4300, LOWRIDERWHEEL_PRICE_INCREASE = 30,
        MUSCLEWHEEL_PRICE = 3900, MUSCLEWHEEL_PRICE_INCREASE = 20,
        HEADLIGHTS_PRICE = 2800, HEADLIGHTS_PRICE_INCREASE = 500,
        TURBO_PRICE = 40000, TURBO_PRICE_INCREASE = 0,
        ARMOR_PRICE = 36000, ARMOR_PRICE_INCREASE = 10000,
        SUSPENSION_PRICE = 10000, SUSPENSION_PRICE_INCREASE = 5000,
        HORN_PRICE = 1500, HORN_PRICE_INCREASE = 480,
        TRANSMISSION_PRICE = 10000, TRANSMISSION_PRICE_INCREASE = 7500,
        BRAKES_PRICE = 8500, BRAKES_PRICE_INCREASE = 4000,
        ENGINE_PRICE = 18000, ENGINE_PRICE_INCREASE = 6800,
        NEONCOLOR_PRICE = 8000, NEONCOLOR_PRICE_INCREASE = 0,
        WHEELCOLOR_PRICE = 5000, WHEELCOLOR_PRICE_INCREASE = 0,
        TYREARMOR_PRICE = 75000, TYREARMOR_PRICE_INCREASE = 0,
        PLATE_PRICE = 500, PLATE_PRICE_INCREASE = 250;



    public LSCUSTOM_NEW()
    {

        colors.Add(new { name = "Black", colorindex = 0 });
        colors.Add(new { name = "Black", colorindex = 1 });
        colors.Add(new { name = "Black", colorindex = 2 });
        colors.Add(new { name = "Black", colorindex = 3 });
        colors.Add(new { name = "Black", colorindex = 4 });
        colors.Add(new { name = "Black", colorindex = 5 });
        colors.Add(new { name = "Black", colorindex = 6 });
        colors.Add(new { name = "Black", colorindex = 7 });
        colors.Add(new { name = "Black", colorindex = 8 });
        colors.Add(new { name = "Black", colorindex = 9 });
        colors.Add(new { name = "Black", colorindex = 10 });
        colors.Add(new { name = "Black", colorindex = 11 });
        colors.Add(new { name = "Black", colorindex = 12 });
        colors.Add(new { name = "Black", colorindex = 13 });
        colors.Add(new { name = "Black", colorindex = 14 });
        colors.Add(new { name = "Black", colorindex = 15 });
        colors.Add(new { name = "Black", colorindex = 16 });
        colors.Add(new { name = "Black", colorindex = 17 });
        colors.Add(new { name = "Black", colorindex = 18 });
        colors.Add(new { name = "Black", colorindex = 19 });
        colors.Add(new { name = "Black", colorindex = 20 });
        colors.Add(new { name = "Black", colorindex = 21 });
        colors.Add(new { name = "Black", colorindex = 22 });
        colors.Add(new { name = "Black", colorindex = 23 });
        colors.Add(new { name = "Black", colorindex = 24 });
        colors.Add(new { name = "Black", colorindex = 25 });
        colors.Add(new { name = "Black", colorindex = 26 });
        colors.Add(new { name = "Black", colorindex = 27 });
        colors.Add(new { name = "Black", colorindex = 28 });
        colors.Add(new { name = "Black", colorindex = 29 });
        colors.Add(new { name = "Black", colorindex = 30 });
        colors.Add(new { name = "Black", colorindex = 31 });
        colors.Add(new { name = "Black", colorindex = 32 });
        colors.Add(new { name = "Black", colorindex = 33 });
        colors.Add(new { name = "Black", colorindex = 34 });
        colors.Add(new { name = "Black", colorindex = 35 });
        colors.Add(new { name = "Black", colorindex = 36 });
        colors.Add(new { name = "Black", colorindex = 37 });
        colors.Add(new { name = "Black", colorindex = 38 });
        colors.Add(new { name = "Black", colorindex = 39 });
        colors.Add(new { name = "Black", colorindex = 40 });
        colors.Add(new { name = "Black", colorindex = 41 });
        colors.Add(new { name = "Black", colorindex = 42 });
        colors.Add(new { name = "Black", colorindex = 43 });
        colors.Add(new { name = "Black", colorindex = 44 });
        colors.Add(new { name = "Black", colorindex = 45 });
        colors.Add(new { name = "Black", colorindex = 46 });
        colors.Add(new { name = "Black", colorindex = 47 });
        colors.Add(new { name = "Black", colorindex = 48 });
        colors.Add(new { name = "Black", colorindex = 49 });
        colors.Add(new { name = "Black", colorindex = 50 });
        colors.Add(new { name = "Black", colorindex = 51 });
        colors.Add(new { name = "Black", colorindex = 52 });
        colors.Add(new { name = "Black", colorindex = 53 });
        colors.Add(new { name = "Black", colorindex = 54 });
        colors.Add(new { name = "Black", colorindex = 55 });
        colors.Add(new { name = "Black", colorindex = 56 });
        colors.Add(new { name = "Black", colorindex = 57 });
        colors.Add(new { name = "Black", colorindex = 58 });
        colors.Add(new { name = "Black", colorindex = 59 });
        colors.Add(new { name = "Black", colorindex = 60 });
        colors.Add(new { name = "Black", colorindex = 61 });
        colors.Add(new { name = "Black", colorindex = 62 });
        colors.Add(new { name = "Black", colorindex = 63 });
        colors.Add(new { name = "Black", colorindex = 64 });
        colors.Add(new { name = "Black", colorindex = 65 });
        colors.Add(new { name = "Black", colorindex = 66 });
        colors.Add(new { name = "Black", colorindex = 67 });
        colors.Add(new { name = "Black", colorindex = 68 });
        colors.Add(new { name = "Black", colorindex = 69 });
        colors.Add(new { name = "Black", colorindex = 70 });
        colors.Add(new { name = "Black", colorindex = 71 });
        colors.Add(new { name = "Black", colorindex = 72 });
        colors.Add(new { name = "Black", colorindex = 73 });
        colors.Add(new { name = "Black", colorindex = 74 });
        colors.Add(new { name = "Black", colorindex = 75 });
        colors.Add(new { name = "Black", colorindex = 76 });
        colors.Add(new { name = "Black", colorindex = 77 });
        colors.Add(new { name = "Black", colorindex = 78 });
        colors.Add(new { name = "Black", colorindex = 79 });
        colors.Add(new { name = "Black", colorindex = 80 });
        colors.Add(new { name = "Black", colorindex = 81 });
        colors.Add(new { name = "Black", colorindex = 82 });
        colors.Add(new { name = "Black", colorindex = 83 });
        colors.Add(new { name = "Black", colorindex = 84 });
        colors.Add(new { name = "Black", colorindex = 85 });
        colors.Add(new { name = "Black", colorindex = 86 });
        colors.Add(new { name = "Black", colorindex = 87 });
        colors.Add(new { name = "Black", colorindex = 88 });
        colors.Add(new { name = "Black", colorindex = 89 });
        colors.Add(new { name = "Black", colorindex = 90 });
        colors.Add(new { name = "Black", colorindex = 91 });
        colors.Add(new { name = "Black", colorindex = 92 });
        colors.Add(new { name = "Black", colorindex = 93 });
        colors.Add(new { name = "Black", colorindex = 94 });
        colors.Add(new { name = "Black", colorindex = 95 });
        colors.Add(new { name = "Black", colorindex = 96 });
        colors.Add(new { name = "Black", colorindex = 97 });
        colors.Add(new { name = "Black", colorindex = 98 });
        colors.Add(new { name = "Black", colorindex = 99 });
        colors.Add(new { name = "Black", colorindex = 100 });
        colors.Add(new { name = "Black", colorindex = 101 });
        colors.Add(new { name = "Black", colorindex = 102 });
        colors.Add(new { name = "Black", colorindex = 103 });
        colors.Add(new { name = "Black", colorindex = 104 });
        colors.Add(new { name = "Black", colorindex = 105 });
        colors.Add(new { name = "Black", colorindex = 106 });
        colors.Add(new { name = "Black", colorindex = 107 });
        colors.Add(new { name = "Black", colorindex = 108 });
        colors.Add(new { name = "Black", colorindex = 109 });
        colors.Add(new { name = "Black", colorindex = 110 });
        colors.Add(new { name = "Black", colorindex = 111 });
        colors.Add(new { name = "Black", colorindex = 112 });
        colors.Add(new { name = "Black", colorindex = 113 });
        colors.Add(new { name = "Black", colorindex = 114 });
        colors.Add(new { name = "Black", colorindex = 115 });
        colors.Add(new { name = "Black", colorindex = 116 });
        colors.Add(new { name = "Black", colorindex = 117 });
        colors.Add(new { name = "Black", colorindex = 118 });
        colors.Add(new { name = "Black", colorindex = 119 });
        colors.Add(new { name = "Black", colorindex = 120 });
        colors.Add(new { name = "Black", colorindex = 121 });
        colors.Add(new { name = "Black", colorindex = 122 });
        colors.Add(new { name = "Black", colorindex = 123 });
        colors.Add(new { name = "Black", colorindex = 124 });
        colors.Add(new { name = "Black", colorindex = 125 });
        colors.Add(new { name = "Black", colorindex = 126 });
        colors.Add(new { name = "Black", colorindex = 127 });
        colors.Add(new { name = "Black", colorindex = 128 });
        colors.Add(new { name = "Black", colorindex = 129 });
        colors.Add(new { name = "Black", colorindex = 130 });
        colors.Add(new { name = "Black", colorindex = 131 });
        colors.Add(new { name = "Black", colorindex = 132 });
        colors.Add(new { name = "Black", colorindex = 133 });
        colors.Add(new { name = "Black", colorindex = 134 });
        colors.Add(new { name = "Black", colorindex = 135 });
        colors.Add(new { name = "Black", colorindex = 136 });
        colors.Add(new { name = "Black", colorindex = 137 });
        colors.Add(new { name = "Black", colorindex = 138 });
        colors.Add(new { name = "Black", colorindex = 139 });
        colors.Add(new { name = "Black", colorindex = 140 });
        colors.Add(new { name = "Black", colorindex = 141 });
        colors.Add(new { name = "Black", colorindex = 142 });
        colors.Add(new { name = "Black", colorindex = 143 });
        colors.Add(new { name = "Black", colorindex = 144 });
        colors.Add(new { name = "Black", colorindex = 145 });
        colors.Add(new { name = "Black", colorindex = 146 });
        colors.Add(new { name = "Black", colorindex = 147 });
        colors.Add(new { name = "Black", colorindex = 148 });
        colors.Add(new { name = "Black", colorindex = 149 });
        colors.Add(new { name = "Black", colorindex = 150 });
        colors.Add(new { name = "Black", colorindex = 151 });
        colors.Add(new { name = "Black", colorindex = 152 });
        colors.Add(new { name = "Black", colorindex = 153 });
        colors.Add(new { name = "Black", colorindex = 154 });
        colors.Add(new { name = "Black", colorindex = 155 });
        colors.Add(new { name = "Black", colorindex = 156 });
        colors.Add(new { name = "Black", colorindex = 157 });
        colors.Add(new { name = "Black", colorindex = 158 });
        colors.Add(new { name = "Black", colorindex = 159 });
        

        metalcolors.Add(new { name = "Brushed Steel", colorindex = 117 });
        metalcolors.Add(new { name = "Brushed Black Steel", colorindex = 118 });
        metalcolors.Add(new { name = "Brushed Aluminum", colorindex = 119 });
        metalcolors.Add(new { name = "Pure Gold", colorindex = 158 });
        metalcolors.Add(new { name = "Brushed Gold", colorindex = 159 });

        mattecolors.Add(new { name = "Black", colorindex = 12 });
        mattecolors.Add(new { name = "Gray", colorindex = 13 });
        mattecolors.Add(new { name = "Light Gray", colorindex = 14 });
        mattecolors.Add(new { name = "Ice White", colorindex = 131 });
        mattecolors.Add(new { name = "Blue", colorindex = 83 });
        mattecolors.Add(new { name = "Dark Blue", colorindex = 82 });
        mattecolors.Add(new { name = "Midnight Blue", colorindex = 84 });
        mattecolors.Add(new { name = "Midnight Purple", colorindex = 149 });
        mattecolors.Add(new { name = "Schafter Purple", colorindex = 148 });
        mattecolors.Add(new { name = "Red", colorindex = 39 });
        mattecolors.Add(new { name = "Dark Red", colorindex = 40 });
        mattecolors.Add(new { name = "Orange", colorindex = 41 });
        mattecolors.Add(new { name = "Yellow", colorindex = 42 });
        mattecolors.Add(new { name = "Lime Green", colorindex = 55 });
        mattecolors.Add(new { name = "Green", colorindex = 128 });
        mattecolors.Add(new { name = "Frost Green", colorindex = 151 });
        mattecolors.Add(new { name = "Foliage Green", colorindex = 155 });
        mattecolors.Add(new { name = "Olive Darb", colorindex = 152 });
        mattecolors.Add(new { name = "Dark Earth", colorindex = 153 });
        mattecolors.Add(new { name = "Desert Tan", colorindex = 154 });


        chrome.Add(new { name = "Chrome", colorindex = 120 });


        windowtint.Add(new { name = "Original", tint = 0, price = 1000 });
        windowtint.Add(new { name = "Pure Black", tint = 1, price = 1000 });
        windowtint.Add(new { name = "Darksmoke", tint = 2, price = 1000 });
        windowtint.Add(new { name = "Lightsmoke", tint = 3, price = 1000 });
        windowtint.Add(new { name = "Limo", tint = 4, price = 1000 });
        windowtint.Add(new { name = "Green", tint = 5, price = 1000 });

        neonlayout.Add(new { name = "Front,Back and Sides", price = 5000 });

        neoncolor.Add(new { name = "Original", neon = new Color(0, 0, 0), price = 1000 });
        neoncolor.Add(new { name = "White", neon = new Color(254, 254, 254), price = 1000 });
        neoncolor.Add(new { name = "Blue", neon = new Color(0, 0, 255), price = 1000 });
        neoncolor.Add(new { name = "Electric Blue", neon = new Color(0, 150, 255), price = 1000 });
        neoncolor.Add(new { name = "Mint Green", neon = new Color(50, 255, 155), price = 1000 });
        neoncolor.Add(new { name = "Lime Green", neon = new Color(0, 255, 0), price = 1000 });
        neoncolor.Add(new { name = "Yellow", neon = new Color(255, 255, 0), price = 1000 });
        neoncolor.Add(new { name = "Golden Shower", neon = new Color(204, 204, 0), price = 1000 });
        neoncolor.Add(new { name = "Orange", neon = new Color(255, 128, 0), price = 1000 });
        neoncolor.Add(new { name = "Red", neon = new Color(255, 0, 0), price = 1000 });
        neoncolor.Add(new { name = "Pony Pink", neon = new Color(255, 102, 255), price = 1000 });
        neoncolor.Add(new { name = "Hot Pink", neon = new Color(255, 0, 255), price = 1000 });
        neoncolor.Add(new { name = "Purple", neon = new Color(153, 0, 153), price = 1000 });
        neoncolor.Add(new { name = "Brown", neon = new Color(139, 69, 19), price = 1000 });

        plates.Add(new { name = "Original", plateindex = -1, price = 200 });
        plates.Add(new { name = "Blue on White 1", plateindex = 0, price = 200 });
        plates.Add(new { name = "Blue On White 2", plateindex = 3, price = 200 });
        plates.Add(new { name = "Blue On White 3", plateindex = 4, price = 200 });
        plates.Add(new { name = "Yellow on Blue", plateindex = 2, price = 300 });
        plates.Add(new { name = "Yellow on Black", plateindex = 1, price = 600 });

        wheelaccessories.Add(new { name = "Original", price = 1000 });
        //wheelaccessories.Add(new { name = "Pneu Customizado", price = 1250 });
        wheelaccessories.Add(new { name = "Pneu a Prova de Balas", price = 5000 });
        /* wheelaccessories.Add(new { name = "Fumaça de Pneu Branco", smokecolor = new Color(254, 254, 254), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Preto", smokecolor = new Color(1, 1, 1), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Azul", smokecolor = new Color(0, 150, 255), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Amarelo", smokecolor = new Color(255, 255, 50), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Laranja", smokecolor = new Color(255, 153, 51), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Vermelho", smokecolor = new Color(255, 10, 10), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Verde", smokecolor = new Color(10, 255, 10), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Roxo", smokecolor = new Color(153, 10, 153), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Rosa", smokecolor = new Color(255, 102, 178), price = 3000 });
         wheelaccessories.Add(new { name = "Fumaça de Pneu Cinza", smokecolor = new Color(128, 128, 128), price = 3000 });*/

        frontwheel.Add(new { name = "Original", wtype = 6, mod = -1, price = 1000 });
        frontwheel.Add(new { name = "Speedway", wtype = 6, mod = 0, price = 1000 });
        frontwheel.Add(new { name = "Streetspecial", wtype = 6, mod = 1, price = 1000 });
        frontwheel.Add(new { name = "Racer", wtype = 6, mod = 2, price = 1000 });
        frontwheel.Add(new { name = "Trackstar", wtype = 6, mod = 3, price = 1000 });
        frontwheel.Add(new { name = "Overlord", wtype = 6, mod = 4, price = 1000 });
        frontwheel.Add(new { name = "Trident", wtype = 6, mod = 5, price = 1000 });
        frontwheel.Add(new { name = "Triplethreat", wtype = 6, mod = 6, price = 1000 });
        frontwheel.Add(new { name = "Stilleto", wtype = 6, mod = 7, price = 1000 });
        frontwheel.Add(new { name = "Wires", wtype = 6, mod = 8, price = 1000 });
        frontwheel.Add(new { name = "Bobber", wtype = 6, mod = 9, price = 1000 });
        frontwheel.Add(new { name = "Solidus", wtype = 6, mod = 10, price = 1000 });
        frontwheel.Add(new { name = "Iceshield", wtype = 6, mod = 11, price = 1000 });
        frontwheel.Add(new { name = "Loops", wtype = 6, mod = 12, price = 1000 });

        backwheel.Add(new { name = "Original", wtype = 6, mod = -1, price = 1000 });
        backwheel.Add(new { name = "Speedway", wtype = 6, mod = 0, price = 1000 });
        backwheel.Add(new { name = "Streetspecial", wtype = 6, mod = 1, price = 1000 });
        backwheel.Add(new { name = "Racer", wtype = 6, mod = 2, price = 1000 });
        backwheel.Add(new { name = "Trackstar", wtype = 6, mod = 3, price = 1000 });
        backwheel.Add(new { name = "Overlord", wtype = 6, mod = 4, price = 1000 });
        backwheel.Add(new { name = "Trident", wtype = 6, mod = 5, price = 1000 });
        backwheel.Add(new { name = "Triplethreat", wtype = 6, mod = 6, price = 1000 });
        backwheel.Add(new { name = "Stilleto", wtype = 6, mod = 7, price = 1000 });
        backwheel.Add(new { name = "Wires", wtype = 6, mod = 8, price = 1000 });
        backwheel.Add(new { name = "Bobber", wtype = 6, mod = 9, price = 1000 });
        backwheel.Add(new { name = "Solidus", wtype = 6, mod = 10, price = 1000 });
        backwheel.Add(new { name = "Iceshield", wtype = 6, mod = 11, price = 1000 });
        backwheel.Add(new { name = "Loops", wtype = 6, mod = 12, price = 1000 });

        sportwheels.Add(new { name = "Original", wtype = 0, mod = -1, price = 1000 });
        sportwheels.Add(new { name = "Inferno", wtype = 0, mod = 0, price = 1000 });
        sportwheels.Add(new { name = "Deepfive", wtype = 0, mod = 1, price = 1000 });
        sportwheels.Add(new { name = "Lozspeed", wtype = 0, mod = 2, price = 1000 });
        sportwheels.Add(new { name = "Diamondcut", wtype = 0, mod = 3, price = 1000 });
        sportwheels.Add(new { name = "Chrono", wtype = 0, mod = 4, price = 1000 });
        sportwheels.Add(new { name = "Feroccirr", wtype = 0, mod = 5, price = 1000 });
        sportwheels.Add(new { name = "Fiftynine", wtype = 0, mod = 6, price = 1000 });
        sportwheels.Add(new { name = "Mercie", wtype = 0, mod = 7, price = 1000 });
        sportwheels.Add(new { name = "Syntheticz", wtype = 0, mod = 8, price = 1000 });
        sportwheels.Add(new { name = "Organictyped", wtype = 0, mod = 9, price = 1000 });
        sportwheels.Add(new { name = "Endov1", wtype = 0, mod = 10, price = 1000 });
        sportwheels.Add(new { name = "Duper7", wtype = 0, mod = 11, price = 1000 });
        sportwheels.Add(new { name = "Uzer", wtype = 0, mod = 12, price = 1000 });
        sportwheels.Add(new { name = "Groundride", wtype = 0, mod = 13, price = 1000 });
        sportwheels.Add(new { name = "Spacer", wtype = 0, mod = 14, price = 1000 });
        sportwheels.Add(new { name = "Venum", wtype = 0, mod = 15, price = 1000 });
        sportwheels.Add(new { name = "Cosmo", wtype = 0, mod = 16, price = 1000 });
        sportwheels.Add(new { name = "Dashvip", wtype = 0, mod = 17, price = 1000 });
        sportwheels.Add(new { name = "Icekid", wtype = 0, mod = 18, price = 1000 });
        sportwheels.Add(new { name = "Ruffeld", wtype = 0, mod = 19, price = 1000 });
        sportwheels.Add(new { name = "Wangenmaster", wtype = 0, mod = 20, price = 1000 });
        sportwheels.Add(new { name = "Superfive", wtype = 0, mod = 21, price = 1000 });
        sportwheels.Add(new { name = "Endov2", wtype = 0, mod = 22, price = 1000 });
        sportwheels.Add(new { name = "Slitsix", wtype = 0, mod = 23, price = 1000 });
        sportwheels.Add(new { name = "Custom 1", wtype = 0, mod = 24, price = 1000 });
        sportwheels.Add(new { name = "Custom 2", wtype = 0, mod = 25, price = 1000 });
        sportwheels.Add(new { name = "Custom 3", wtype = 0, mod = 26, price = 1000 });
        sportwheels.Add(new { name = "Custom 4", wtype = 0, mod = 27, price = 1000 });
        sportwheels.Add(new { name = "Custom 5", wtype = 0, mod = 28, price = 1000 });
        sportwheels.Add(new { name = "Custom 6", wtype = 0, mod = 29, price = 1000 });
        sportwheels.Add(new { name = "Custom 7", wtype = 0, mod = 30, price = 1000 });
        sportwheels.Add(new { name = "Custom 8", wtype = 0, mod = 31, price = 1000 });
        sportwheels.Add(new { name = "Custom 9", wtype = 0, mod = 32, price = 1000 });
        sportwheels.Add(new { name = "Custom 10", wtype = 0, mod = 33, price = 1000 });
        sportwheels.Add(new { name = "Custom 11", wtype = 0, mod = 34, price = 1000 });
        sportwheels.Add(new { name = "Custom 12", wtype = 0, mod = 35, price = 1000 });
        sportwheels.Add(new { name = "Custom 13", wtype = 0, mod = 36, price = 1000 });
        sportwheels.Add(new { name = "Custom 14", wtype = 0, mod = 37, price = 1000 });
        sportwheels.Add(new { name = "Custom 15", wtype = 0, mod = 38, price = 1000 });
        sportwheels.Add(new { name = "Custom 16", wtype = 0, mod = 39, price = 1000 });
        sportwheels.Add(new { name = "Custom 17", wtype = 0, mod = 40, price = 1000 });
        sportwheels.Add(new { name = "Custom 18", wtype = 0, mod = 41, price = 1000 });
        sportwheels.Add(new { name = "Custom 19", wtype = 0, mod = 42, price = 1000 });
        sportwheels.Add(new { name = "Custom 20", wtype = 0, mod = 43, price = 1000 });
        sportwheels.Add(new { name = "Custom 21", wtype = 0, mod = 44, price = 1000 });
        sportwheels.Add(new { name = "Custom 22", wtype = 0, mod = 45, price = 1000 });
        sportwheels.Add(new { name = "Custom 23", wtype = 0, mod = 46, price = 1000 });
        sportwheels.Add(new { name = "Custom 24", wtype = 0, mod = 47, price = 1000 });
        sportwheels.Add(new { name = "Custom 25", wtype = 0, mod = 48, price = 1000 });
        sportwheels.Add(new { name = "Custom 26", wtype = 0, mod = 49, price = 1000 });


        suvwheels.Add(new { name = "Original", wtype = 3, mod = -1, price = 1000 });
        suvwheels.Add(new { name = "Vip", wtype = 3, mod = 0, price = 1000 });
        suvwheels.Add(new { name = "Benefactor", wtype = 3, mod = 1, price = 1000 });
        suvwheels.Add(new { name = "Cosmo", wtype = 3, mod = 2, price = 1000 });
        suvwheels.Add(new { name = "Bippu", wtype = 3, mod = 3, price = 1000 });
        suvwheels.Add(new { name = "Royalsix", wtype = 3, mod = 4, price = 1000 });
        suvwheels.Add(new { name = "Fagorme", wtype = 3, mod = 5, price = 1000 });
        suvwheels.Add(new { name = "Deluxe", wtype = 3, mod = 6, price = 1000 });
        suvwheels.Add(new { name = "Icedout", wtype = 3, mod = 7, price = 1000 });
        suvwheels.Add(new { name = "Cognscenti", wtype = 3, mod = 8, price = 1000 });
        suvwheels.Add(new { name = "Lozspeedten", wtype = 3, mod = 9, price = 1000 });
        suvwheels.Add(new { name = "Supernova", wtype = 3, mod = 10, price = 1000 });
        suvwheels.Add(new { name = "Obeyrs", wtype = 3, mod = 11, price = 1000 });
        suvwheels.Add(new { name = "Lozspeedballer", wtype = 3, mod = 12, price = 1000 });
        suvwheels.Add(new { name = "Extra vaganzo", wtype = 3, mod = 13, price = 1000 });
        suvwheels.Add(new { name = "Splitsix", wtype = 3, mod = 14, price = 1000 });
        suvwheels.Add(new { name = "Empowered", wtype = 3, mod = 15, price = 1000 });
        suvwheels.Add(new { name = "Sunrise", wtype = 3, mod = 16, price = 1000 });
        suvwheels.Add(new { name = "Dashvip", wtype = 3, mod = 17, price = 1000 });
        suvwheels.Add(new { name = "Cutter", wtype = 3, mod = 18, price = 1000 });
        suvwheels.Add(new { name = "custom 1", wtype = 3, mod = 19, price = 1000 });
        suvwheels.Add(new { name = "custom 2", wtype = 3, mod = 20, price = 1000 });
        suvwheels.Add(new { name = "custom 3", wtype = 3, mod = 21, price = 1000 });
        suvwheels.Add(new { name = "custom 4", wtype = 3, mod = 22, price = 1000 });
        suvwheels.Add(new { name = "custom 5", wtype = 3, mod = 23, price = 1000 });
        suvwheels.Add(new { name = "custom 6", wtype = 3, mod = 24, price = 1000 });
        suvwheels.Add(new { name = "custom 7", wtype = 3, mod = 25, price = 1000 });
        suvwheels.Add(new { name = "custom 8", wtype = 3, mod = 26, price = 1000 });
        suvwheels.Add(new { name = "custom 9", wtype = 3, mod = 27, price = 1000 });
        suvwheels.Add(new { name = "custom 10", wtype = 3, mod = 28, price = 1000 });
        suvwheels.Add(new { name = "custom 11", wtype = 3, mod = 29, price = 1000 });
        suvwheels.Add(new { name = "custom 12", wtype = 3, mod = 30, price = 1000 });
        suvwheels.Add(new { name = "custom 13", wtype = 3, mod = 31, price = 1000 });
        suvwheels.Add(new { name = "custom 14", wtype = 3, mod = 32, price = 1000 });
        suvwheels.Add(new { name = "custom 15", wtype = 3, mod = 33, price = 1000 });
        suvwheels.Add(new { name = "custom 16", wtype = 3, mod = 34, price = 1000 });
        suvwheels.Add(new { name = "custom 17", wtype = 3, mod = 35, price = 1000 });
        suvwheels.Add(new { name = "custom 18", wtype = 3, mod = 36, price = 1000 });
        suvwheels.Add(new { name = "custom 19", wtype = 3, mod = 37, price = 1000 });


        offroadwheels.Add(new { name = "Original", wtype = 4, mod = -1, price = 1000 });
        offroadwheels.Add(new { name = "Raider", wtype = 4, mod = 0, price = 1000 });
        offroadwheels.Add(new { name = "Mudslinger", wtype = 4, mod = 1, price = 1000 });
        offroadwheels.Add(new { name = "Nevis", wtype = 4, mod = 2, price = 1000 });
        offroadwheels.Add(new { name = "Cairngorm", wtype = 4, mod = 3, price = 1000 });
        offroadwheels.Add(new { name = "Amazon", wtype = 4, mod = 4, price = 1000 });
        offroadwheels.Add(new { name = "Challenger", wtype = 4, mod = 5, price = 1000 });
        offroadwheels.Add(new { name = "Dunebasher", wtype = 4, mod = 6, price = 1000 });
        offroadwheels.Add(new { name = "Fivestar", wtype = 4, mod = 7, price = 1000 });
        offroadwheels.Add(new { name = "Rockcrawler", wtype = 4, mod = 8, price = 1000 });
        offroadwheels.Add(new { name = "Milspecsteelie", wtype = 4, mod = 9, price = 1000 });
        offroadwheels.Add(new { name = "Custom 1", wtype = 4, mod = 10, price = 1000 });
        offroadwheels.Add(new { name = "Custom 2", wtype = 4, mod = 11, price = 1000 });
        offroadwheels.Add(new { name = "Custom 3", wtype = 4, mod = 12, price = 1000 });
        offroadwheels.Add(new { name = "Custom 4", wtype = 4, mod = 13, price = 1000 });
        offroadwheels.Add(new { name = "Custom 5", wtype = 4, mod = 14, price = 1000 });
        offroadwheels.Add(new { name = "Custom 6", wtype = 4, mod = 15, price = 1000 });
        offroadwheels.Add(new { name = "Custom 7", wtype = 4, mod = 16, price = 1000 });
        offroadwheels.Add(new { name = "Custom 8", wtype = 4, mod = 17, price = 1000 });
        offroadwheels.Add(new { name = "Custom 9", wtype = 4, mod = 18, price = 1000 });
        offroadwheels.Add(new { name = "Custom 10", wtype = 4, mod = 19, price = 1000 });
        offroadwheels.Add(new { name = "Custom 11", wtype = 4, mod = 20, price = 1000 });
        offroadwheels.Add(new { name = "Custom 12", wtype = 4, mod = 21, price = 1000 });
        offroadwheels.Add(new { name = "Custom 13", wtype = 4, mod = 22, price = 1000 });
        offroadwheels.Add(new { name = "Custom 14", wtype = 4, mod = 23, price = 1000 });
        offroadwheels.Add(new { name = "Custom 15", wtype = 4, mod = 24, price = 1000 });
        offroadwheels.Add(new { name = "Custom 16", wtype = 4, mod = 25, price = 1000 });
        offroadwheels.Add(new { name = "Custom 17", wtype = 4, mod = 26, price = 1000 });
        offroadwheels.Add(new { name = "Custom 18", wtype = 4, mod = 27, price = 1000 });
        offroadwheels.Add(new { name = "Custom 19", wtype = 4, mod = 28, price = 1000 });
        offroadwheels.Add(new { name = "Custom 20", wtype = 4, mod = 29, price = 1000 });
        offroadwheels.Add(new { name = "Custom 21", wtype = 4, mod = 30, price = 1000 });
        offroadwheels.Add(new { name = "Custom 22", wtype = 4, mod = 31, price = 1000 });
        offroadwheels.Add(new { name = "Custom 23", wtype = 4, mod = 32, price = 1000 });
        offroadwheels.Add(new { name = "Custom 24", wtype = 4, mod = 33, price = 1000 });
        offroadwheels.Add(new { name = "Custom 25", wtype = 4, mod = 34, price = 1000 });


        tunerwheels.Add(new { name = "Original", wtype = 5, mod = -1, price = 1000 });
        tunerwheels.Add(new { name = "Cosmo", wtype = 5, mod = 0, price = 1000 });
        tunerwheels.Add(new { name = "Supermesh", wtype = 5, mod = 1, price = 1000 });
        tunerwheels.Add(new { name = "Outsider", wtype = 5, mod = 2, price = 1000 });
        tunerwheels.Add(new { name = "Rollas", wtype = 5, mod = 3, price = 1000 });
        tunerwheels.Add(new { name = "Driffmeister", wtype = 5, mod = 4, price = 1000 });
        tunerwheels.Add(new { name = "Slicer", wtype = 5, mod = 5, price = 1000 });
        tunerwheels.Add(new { name = "Elquatro", wtype = 5, mod = 6, price = 1000 });
        tunerwheels.Add(new { name = "Dubbed", wtype = 5, mod = 7, price = 1000 });
        tunerwheels.Add(new { name = "Fivestar", wtype = 5, mod = 8, price = 1000 });
        tunerwheels.Add(new { name = "Slideways", wtype = 5, mod = 9, price = 1000 });
        tunerwheels.Add(new { name = "Apex", wtype = 5, mod = 10, price = 1000 });
        tunerwheels.Add(new { name = "Stancedeg", wtype = 5, mod = 11, price = 1000 });
        tunerwheels.Add(new { name = "Countersteer", wtype = 5, mod = 12, price = 1000 });
        tunerwheels.Add(new { name = "Endov1", wtype = 5, mod = 13, price = 1000 });
        tunerwheels.Add(new { name = "Endov2dish", wtype = 5, mod = 14, price = 1000 });
        tunerwheels.Add(new { name = "Guppez", wtype = 5, mod = 15, price = 1000 });
        tunerwheels.Add(new { name = "Chokadori", wtype = 5, mod = 16, price = 1000 });
        tunerwheels.Add(new { name = "Chicane", wtype = 5, mod = 17, price = 1000 });
        tunerwheels.Add(new { name = "Saisoku", wtype = 5, mod = 18, price = 1000 });
        tunerwheels.Add(new { name = "Dishedeight", wtype = 5, mod = 19, price = 1000 });
        tunerwheels.Add(new { name = "Fujiwara", wtype = 5, mod = 20, price = 1000 });
        tunerwheels.Add(new { name = "Zokusha", wtype = 5, mod = 21, price = 1000 });
        tunerwheels.Add(new { name = "Battlevill", wtype = 5, mod = 22, price = 1000 });
        tunerwheels.Add(new { name = "Rallymaster", wtype = 5, mod = 23, price = 1000 });
        tunerwheels.Add(new { name = "custom 1", wtype = 5, mod = 24, price = 1000 });
        tunerwheels.Add(new { name = "custom 2", wtype = 5, mod = 25, price = 1000 });
        tunerwheels.Add(new { name = "custom 3", wtype = 5, mod = 26, price = 1000 });
        tunerwheels.Add(new { name = "custom 4", wtype = 5, mod = 27, price = 1000 });
        tunerwheels.Add(new { name = "custom 5", wtype = 5, mod = 28, price = 1000 });
        tunerwheels.Add(new { name = "custom 6", wtype = 5, mod = 29, price = 1000 });
        tunerwheels.Add(new { name = "custom 7", wtype = 5, mod = 30, price = 1000 });
        tunerwheels.Add(new { name = "custom 8", wtype = 5, mod = 31, price = 1000 });
        tunerwheels.Add(new { name = "custom 9", wtype = 5, mod = 32, price = 1000 });
        tunerwheels.Add(new { name = "custom 10", wtype = 5, mod = 33, price = 1000 });
        tunerwheels.Add(new { name = "custom 11", wtype = 5, mod = 34, price = 1000 });
        tunerwheels.Add(new { name = "custom 12", wtype = 5, mod = 35, price = 1000 });
        tunerwheels.Add(new { name = "custom 13", wtype = 5, mod = 36, price = 1000 });
        tunerwheels.Add(new { name = "custom 14", wtype = 5, mod = 37, price = 1000 });
        tunerwheels.Add(new { name = "custom 15", wtype = 5, mod = 38, price = 1000 });
        tunerwheels.Add(new { name = "custom 16", wtype = 5, mod = 39, price = 1000 });
        tunerwheels.Add(new { name = "custom 17", wtype = 5, mod = 40, price = 1000 });
        tunerwheels.Add(new { name = "custom 18", wtype = 5, mod = 41, price = 1000 });
        tunerwheels.Add(new { name = "custom 19", wtype = 5, mod = 42, price = 1000 });
        tunerwheels.Add(new { name = "custom 20", wtype = 5, mod = 43, price = 1000 });
        tunerwheels.Add(new { name = "custom 21", wtype = 5, mod = 44, price = 1000 });
        tunerwheels.Add(new { name = "custom 22", wtype = 5, mod = 45, price = 1000 });
        tunerwheels.Add(new { name = "custom 23", wtype = 5, mod = 46, price = 1000 });
        tunerwheels.Add(new { name = "custom 24", wtype = 5, mod = 47, price = 1000 });


        highendwheels.Add(new { name = "Original", wtype = 7, mod = -1, price = 1000 });
        highendwheels.Add(new { name = "Shadow", wtype = 7, mod = 0, price = 1000 });
        highendwheels.Add(new { name = "Hyper", wtype = 7, mod = 1, price = 1000 });
        highendwheels.Add(new { name = "Blade", wtype = 7, mod = 2, price = 1000 });
        highendwheels.Add(new { name = "Diamond", wtype = 7, mod = 3, price = 1000 });
        highendwheels.Add(new { name = "Supagee", wtype = 7, mod = 4, price = 1000 });
        highendwheels.Add(new { name = "Chromaticz", wtype = 7, mod = 5, price = 1000 });
        highendwheels.Add(new { name = "Merciechlip", wtype = 7, mod = 6, price = 1000 });
        highendwheels.Add(new { name = "Obeyrs", wtype = 7, mod = 7, price = 1000 });
        highendwheels.Add(new { name = "Gtchrome", wtype = 7, mod = 8, price = 1000 });
        highendwheels.Add(new { name = "Cheetahr", wtype = 7, mod = 9, price = 1000 });
        highendwheels.Add(new { name = "Solar", wtype = 7, mod = 10, price = 1000 });
        highendwheels.Add(new { name = "Splitten", wtype = 7, mod = 11, price = 1000 });
        highendwheels.Add(new { name = "Dashvip", wtype = 7, mod = 12, price = 1000 });
        highendwheels.Add(new { name = "Lozspeedten", wtype = 7, mod = 13, price = 1000 });
        highendwheels.Add(new { name = "Carboninferno", wtype = 7, mod = 14, price = 1000 });
        highendwheels.Add(new { name = "Carbonshadow", wtype = 7, mod = 15, price = 1000 });
        highendwheels.Add(new { name = "Carbonz", wtype = 7, mod = 16, price = 1000 });
        highendwheels.Add(new { name = "Carbonsolar", wtype = 7, mod = 17, price = 1000 });
        highendwheels.Add(new { name = "Carboncheetahr", wtype = 7, mod = 18, price = 1000 });
        highendwheels.Add(new { name = "Carbonsracer", wtype = 7, mod = 19, price = 1000 });
        highendwheels.Add(new { name = "custom 1", wtype = 7, mod = 20, price = 1000 });
        highendwheels.Add(new { name = "custom 2", wtype = 7, mod = 21, price = 1000 });
        highendwheels.Add(new { name = "custom 3", wtype = 7, mod = 22, price = 1000 });
        highendwheels.Add(new { name = "custom 4", wtype = 7, mod = 23, price = 1000 });
        highendwheels.Add(new { name = "custom 5", wtype = 7, mod = 24, price = 1000 });
        highendwheels.Add(new { name = "custom 6", wtype = 7, mod = 25, price = 1000 });
        highendwheels.Add(new { name = "custom 7", wtype = 7, mod = 26, price = 1000 });
        highendwheels.Add(new { name = "custom 8", wtype = 7, mod = 27, price = 1000 });
        highendwheels.Add(new { name = "custom 9", wtype = 7, mod = 28, price = 1000 });
        highendwheels.Add(new { name = "custom 10", wtype = 7, mod = 29, price = 1000 });
        highendwheels.Add(new { name = "custom 11", wtype = 7, mod = 30, price = 1000 });
        highendwheels.Add(new { name = "custom 12", wtype = 7, mod = 31, price = 1000 });
        highendwheels.Add(new { name = "custom 13", wtype = 7, mod = 32, price = 1000 });
        highendwheels.Add(new { name = "custom 14", wtype = 7, mod = 33, price = 1000 });
        highendwheels.Add(new { name = "custom 15", wtype = 7, mod = 34, price = 1000 });
        highendwheels.Add(new { name = "custom 16", wtype = 7, mod = 35, price = 1000 });
        highendwheels.Add(new { name = "custom 17", wtype = 7, mod = 36, price = 1000 });
        highendwheels.Add(new { name = "custom 18", wtype = 7, mod = 37, price = 1000 });
        highendwheels.Add(new { name = "custom 19", wtype = 7, mod = 38, price = 1000 });
        highendwheels.Add(new { name = "custom 20", wtype = 7, mod = 39, price = 1000 });

        lowriderwheels.Add(new { name = "Original", wtype = 2, mod = -1, price = 1000 });
        lowriderwheels.Add(new { name = "Flare", wtype = 2, mod = 0, price = 1000 });
        lowriderwheels.Add(new { name = "Wired", wtype = 2, mod = 1, price = 1000 });
        lowriderwheels.Add(new { name = "Triplegolds", wtype = 2, mod = 2, price = 1000 });
        lowriderwheels.Add(new { name = "Bigworm", wtype = 2, mod = 3, price = 1000 });
        lowriderwheels.Add(new { name = "Sevenfives", wtype = 2, mod = 4, price = 1000 });
        lowriderwheels.Add(new { name = "Splitsix", wtype = 2, mod = 5, price = 1000 });
        lowriderwheels.Add(new { name = "Freshmesh", wtype = 2, mod = 6, price = 1000 });
        lowriderwheels.Add(new { name = "Leadsled", wtype = 2, mod = 7, price = 1000 });
        lowriderwheels.Add(new { name = "Turbine", wtype = 2, mod = 8, price = 1000 });
        lowriderwheels.Add(new { name = "Superfin", wtype = 2, mod = 9, price = 1000 });
        lowriderwheels.Add(new { name = "Classicrod", wtype = 2, mod = 10, price = 1000 });
        lowriderwheels.Add(new { name = "Dollar", wtype = 2, mod = 11, price = 1000 });
        lowriderwheels.Add(new { name = "Dukes", wtype = 2, mod = 12, price = 1000 });
        lowriderwheels.Add(new { name = "Lowfive", wtype = 2, mod = 13, price = 1000 });
        lowriderwheels.Add(new { name = "Gooch", wtype = 2, mod = 14, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 1", wtype = 2, mod = 15, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 2", wtype = 2, mod = 16, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 3", wtype = 2, mod = 17, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 4", wtype = 2, mod = 18, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 5", wtype = 2, mod = 19, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 6", wtype = 2, mod = 20, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 7", wtype = 2, mod = 21, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 8", wtype = 2, mod = 22, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 9", wtype = 2, mod = 23, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 10", wtype = 2, mod = 24, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 11", wtype = 2, mod = 25, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 12", wtype = 2, mod = 26, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 13", wtype = 2, mod = 27, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 14", wtype = 2, mod = 28, price = 1000 });
        lowriderwheels.Add(new { name = "Custom 15", wtype = 2, mod = 29, price = 1000 });


        musclewheels.Add(new { name = "Original", wtype = 1, mod = -1, price = 1000 });
        musclewheels.Add(new { name = "Classicfive", wtype = 1, mod = 0, price = 1000 });
        musclewheels.Add(new { name = "Dukes", wtype = 1, mod = 1, price = 1000 });
        musclewheels.Add(new { name = "Musclefreak", wtype = 1, mod = 2, price = 1000 });
        musclewheels.Add(new { name = "Kracka", wtype = 1, mod = 3, price = 1000 });
        musclewheels.Add(new { name = "Azrea", wtype = 1, mod = 4, price = 1000 });
        musclewheels.Add(new { name = "Mecha", wtype = 1, mod = 5, price = 1000 });
        musclewheels.Add(new { name = "Blacktop", wtype = 1, mod = 6, price = 1000 });
        musclewheels.Add(new { name = "Dragspl", wtype = 1, mod = 7, price = 1000 });
        musclewheels.Add(new { name = "Revolver", wtype = 1, mod = 8, price = 1000 });
        musclewheels.Add(new { name = "Classicrod", wtype = 1, mod = 9, price = 1000 });
        musclewheels.Add(new { name = "Spooner", wtype = 1, mod = 10, price = 1000 });
        musclewheels.Add(new { name = "Fivestar", wtype = 1, mod = 11, price = 1000 });
        musclewheels.Add(new { name = "Oldschool", wtype = 1, mod = 12, price = 1000 });
        musclewheels.Add(new { name = "Eljefe", wtype = 1, mod = 13, price = 1000 });
        musclewheels.Add(new { name = "Dodman", wtype = 1, mod = 14, price = 1000 });
        musclewheels.Add(new { name = "Sixgun", wtype = 1, mod = 15, price = 1000 });
        musclewheels.Add(new { name = "Custom 1", wtype = 1, mod = 16, price = 1000 });
        musclewheels.Add(new { name = "Custom 2", wtype = 1, mod = 17, price = 1000 });
        musclewheels.Add(new { name = "Custom 3", wtype = 1, mod = 18, price = 1000 });
        musclewheels.Add(new { name = "Custom 4", wtype = 1, mod = 19, price = 1000 });
        musclewheels.Add(new { name = "Custom 5", wtype = 1, mod = 20, price = 1000 });
        musclewheels.Add(new { name = "Custom 6", wtype = 1, mod = 21, price = 1000 });
        musclewheels.Add(new { name = "Custom 7", wtype = 1, mod = 22, price = 1000 });
        musclewheels.Add(new { name = "Custom 8", wtype = 1, mod = 23, price = 1000 });
        musclewheels.Add(new { name = "Custom 9", wtype = 1, mod = 24, price = 1000 });
        musclewheels.Add(new { name = "Custom 10", wtype = 1, mod = 25, price = 1000 });
        musclewheels.Add(new { name = "Custom 11", wtype = 1, mod = 26, price = 1000 });
        musclewheels.Add(new { name = "Custom 12", wtype = 1, mod = 27, price = 1000 });
        musclewheels.Add(new { name = "Custom 13", wtype = 1, mod = 28, price = 1000 });
        musclewheels.Add(new { name = "Custom 14", wtype = 1, mod = 29, price = 1000 });
        musclewheels.Add(new { name = "Custom 15", wtype = 1, mod = 30, price = 1000 });
        musclewheels.Add(new { name = "Custom 16", wtype = 1, mod = 31, price = 1000 });
        musclewheels.Add(new { name = "Custom 17", wtype = 1, mod = 32, price = 1000 });
        musclewheels.Add(new { name = "Custom 18", wtype = 1, mod = 33, price = 1000 });
        musclewheels.Add(new { name = "Custom 19", wtype = 1, mod = 34, price = 1000 });
        musclewheels.Add(new { name = "Custom 20", wtype = 1, mod = 35, price = 1000 });

        Headlights.Add(new { name = "Farol Original", mod = -1, price = 0 });
        Headlights.Add(new { name = "Farol Xenon", mod = 0, price = 3625 });

        Turbo.Add(new { name = "Original", mod = -1, price = 0 });
        Turbo.Add(new { name = "Turbo", mod = 0, price = 80000 });


        Armor.Add(new { name = "Original", modtype = 16, mod = -1, price = 2500 });
        Armor.Add(new { name = "Armor Upgrade 20%", modtype = 16, mod = 0, price = 2500 });
        Armor.Add(new { name = "Armor Upgrade 40%", modtype = 16, mod = 1, price = 5000 });
        Armor.Add(new { name = "Armor Upgrade 60%", modtype = 16, mod = 2, price = 7500 });
        Armor.Add(new { name = "Armor Upgrade 80%", modtype = 16, mod = 3, price = 10000 });
        Armor.Add(new { name = "Armor Upgrade 100%", modtype = 16, mod = 4, price = 12500 });


        Suspension.Add(new { name = "Original", mod = -1, price = 3000 });
        Suspension.Add(new { name = "Lowered Suspension", mod = 0, price = 3000 });
        Suspension.Add(new { name = "Street Suspension", mod = 1, price = 6000 });
        Suspension.Add(new { name = "Sport Suspension", mod = 2, price = 9500 });
        Suspension.Add(new { name = "Competition Suspension", mod = 3, price = 14000 });


        Horn.Add(new { name = "Original", mod = -1, price = 1625 });
        Horn.Add(new { name = "Truck", mod = 0, price = 1625 });
        Horn.Add(new { name = "Police", mod = 1, price = 4062 });
        Horn.Add(new { name = "Clown", mod = 2, price = 6500 });
        Horn.Add(new { name = "Musical 1", mod = 3, price = 11375 });
        Horn.Add(new { name = "Musical 2", mod = 4, price = 11375 });
        Horn.Add(new { name = "Musical 3", mod = 5, price = 11375 });
        Horn.Add(new { name = "Musical 4", mod = 6, price = 11375 });
        Horn.Add(new { name = "Musical 5", mod = 7, price = 11375 });
        Horn.Add(new { name = "Sadtrombone", mod = 8, price = 11375 });
        Horn.Add(new { name = "Calssical 1", mod = 9, price = 11375 });
        Horn.Add(new { name = "Calssical 2", mod = 10, price = 11375 });
        Horn.Add(new { name = "Calssical 3", mod = 11, price = 11375 });
        Horn.Add(new { name = "Calssical 4", mod = 12, price = 11375 });
        Horn.Add(new { name = "Calssical 5", mod = 13, price = 11375 });
        Horn.Add(new { name = "Calssical 6", mod = 14, price = 11375 });
        Horn.Add(new { name = "Calssical 7", mod = 15, price = 11375 });
        Horn.Add(new { name = "Scaledo", mod = 16, price = 11375 });
        Horn.Add(new { name = "Scalere", mod = 17, price = 11375 });
        Horn.Add(new { name = "Scalemi", mod = 18, price = 11375 });
        Horn.Add(new { name = "Scalefa", mod = 19, price = 11375 });
        Horn.Add(new { name = "Scalesol", mod = 20, price = 11375 });
        Horn.Add(new { name = "Scalela", mod = 21, price = 11375 });
        Horn.Add(new { name = "Scaleti", mod = 22, price = 11375 });
        Horn.Add(new { name = "Scaledo High", mod = 23, price = 11375 });
        Horn.Add(new { name = "Jazz 1", mod = 25, price = 11375 });
        Horn.Add(new { name = "Jazz 2", mod = 26, price = 11375 });
        Horn.Add(new { name = "Jazz 3", mod = 27, price = 11375 });
        Horn.Add(new { name = "Jazzloop", mod = 28, price = 11375 });
        Horn.Add(new { name = "Starspangban 1", mod = 29, price = 11375 });
        Horn.Add(new { name = "Starspangban 2", mod = 30, price = 11375 });
        Horn.Add(new { name = "Starspangban 3", mod = 31, price = 11375 });
        Horn.Add(new { name = "Starspangban 4", mod = 32, price = 11375 });
        Horn.Add(new { name = "Classicalloop 1", mod = 33, price = 11375 });
        Horn.Add(new { name = "Classicalloop 2", mod = 34, price = 11375 });
        Horn.Add(new { name = "Classicalloop 3", mod = 35, price = 11375 });

        Transmission.Add(new { name = "Original", mod = -1, price = 10000 });
        Transmission.Add(new { name = "Street Transmission", mod = 0, price = 10000 });
        Transmission.Add(new { name = "Sports Transmission", mod = 1, price = 52500 });
        Transmission.Add(new { name = "Race Transmission", mod = 2, price = 85000 });

        Brakes.Add(new { name = "Original", mod = -1, price = 6500 });
        Brakes.Add(new { name = "Street Brakes", mod = 0, price = 6500 });
        Brakes.Add(new { name = "Sport Brakes", mod = 1, price = 18775 });
        Brakes.Add(new { name = "Race Brakes", mod = 2, price = 31375 });


        Engine.Add(new { name = "Motor Original", mod = -1, price = 14500 });
        Engine.Add(new { name = "EMS Upgrade, Level 1", mod = 0, price = 14500 });
        Engine.Add(new { name = "EMS Upgrade, Level 2", mod = 1, price = 49000 });
        Engine.Add(new { name = "EMS Upgrade, Level 3", mod = 2, price = 110500 });

        //NAPI.Marker.CreateMarker(27, new Vector3(-366.7836, -120.4633, 38.69604) - new Vector3(0, 0, 0.6f), new Vector3(), new Vector3(), 3.5f, new Color(247, 221, 52, 150));

        ls_custom.Add(new LSCustomEnum { position = new Vector3(-211.87, -1324.31, 30.87), in_use = false, vehicle = null });

        foreach (var ls in ls_custom)
        {
            ls.label_position = API.Shared.CreateTextLabel(Translation.ls_custom_label_free, ls.position + new Vector3(0, 0, 1.2f), 10.0f, 8.2f, 4, new Color(221, 255, 0, 255), false, 0);
          //  ls.marker_position = NAPI.Marker.CreateMarker(27, ls.position - new Vector3(0, 0, 0.9f), new Vector3(), new Vector3(), 6.0f, new Color(221, 255, 0, 255));
        }

    }

    public class LSCustomEnum : IEquatable<LSCustomEnum>

    {
        public int id { get; set; }

        public Vector3 position { get; set; }
        public Marker marker_position { get; set; }
        public TextLabel label_position { get; set; }
        public Vehicle vehicle { get; set; }
        public bool in_use { get; set; }

        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            LSCustomEnum objAsPart = obj as LSCustomEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(LSCustomEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<LSCustomEnum> ls_custom = new List<LSCustomEnum>();

    public static void PressKeyE(Player Client)
    {
        int x = 0;
        foreach (var ls in ls_custom)
        {
            if (Main.IsInRangeOfPoint(Client.Position, ls.position, 3.0f) && ls.in_use == false && Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
            {
                if (!Client.Vehicle.HasData("Mashin_Owner"))
                {
                    return;
                }
                if (Client.Vehicle.GetData<dynamic>("Mashin_Owner") != AccountManage.GetPlayerSQLID(Client))
                {
                    
                    
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste vlasnik vozila!");
                    Hide_LSCustom(Client);
                    return;
                }
                Client.TriggerEvent("StopVehicle");

                Vehicle vehicle = Client.Vehicle;
                ls.in_use = true;
                ls.vehicle = vehicle;

                Client.TriggerEvent("Display_Tunning_home");
                Main.Display_HUD(Client, false);
                Main.showChat(Client, false);
                Main.DisplayRadar(Client, false);
                //   Create_LSCustomMainMenu(Client);

                Client.TriggerEvent("freezeEx", true);
                Client.TriggerEvent("freezeVehicle", true);
                Client.SetSharedData("DisableVehicleMove", true);

                ls.label_position.Text = Translation.ls_custom_label_busy;
                return;
            }
            x++;
        }
    }


    public static void Display_LSCustom(Player Client)
    {
        if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver)
        {


            Client.TriggerEvent("Display_Tunning_home");
        }
    }


    [RemoteEvent("Hide_LSCustom")]
    public static void Hide_LSCustom(Player Player)
    {
        if (Player.IsInVehicle && Player.VehicleSeat == (int)VehicleSeat.Driver)
        {
            Player.TriggerEvent("freezeEx", false);
            Player.TriggerEvent("freezeVehicle", false);
            Player.SetSharedData("DisableVehicleMove", false);
            Main.Display_HUD(Player, true);
            Main.showChat(Player, true);
            Main.DisplayRadar(Player, true);
            //ResetVehicle_Customization_Temp(Player.Vehicle);

            foreach (var ls in LSCUSTOM_NEW.ls_custom)
            {
                if (ls.in_use == true && ls.vehicle == Player.Vehicle)
                {
                    ls.in_use = false;
                    ls.vehicle = null;
                    ls.label_position.Text = Translation.ls_custom_label_free;
                }
            }
        }
    }

    enum CustomizeX
    {
        Armor = 10000,
        RearBumper = 1050,
        FrontBumper = 1360,
        Plate = 880,
        Break = 1800,
    }

    public struct CustomizeCoefficient
    {
        public const double RearBumper = 1.48;
        public const double FrontBumper = 1.48;
        public const double Plate = 1.11;
        public const double Break = 1.95;

    }

    [RemoteEvent("MainMenuRespone")]
    public void MainMenuRespone(Player player, string callback)
    {
        if (!player.IsInVehicle && player.VehicleSeat != -1)
        {
            return;
        }

        int can_pass = 0;
        foreach (var ls in LSCUSTOM_NEW.ls_custom)
        {
            if (ls.in_use == true && ls.vehicle == player.Vehicle)
            {
                can_pass = 1;
            }
        }
        if (can_pass == 0)
        {
            return;
        }
        if (callback == "bumper")
        {
            player.TriggerEvent("Display_Tunning_pages", "bumper");
        }
        else if (callback == "protection")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Label = "Original", modType = 16, modValue = -1, price = CustomizeX.Armor });
            menu_item_list.Add(new { Label = "Armor <span>2x</span>", modType = 16, modValue = 0, price = CustomizeX.Armor });
            menu_item_list.Add(new { Label = "Armor <span>3x</span>", modType = 16, modValue = 1, price = (int)CustomizeX.Armor * 2 });
            menu_item_list.Add(new { Label = "Armor <span>4x</span>", modType = 16, modValue = 2, price = (int)CustomizeX.Armor * 3 });
            menu_item_list.Add(new { Label = "Armor <span>5x</span>", modType = 16, modValue = 3, price = (int)CustomizeX.Armor * 4 });
            menu_item_list.Add(new { Label = "Armor <span>6x</span>", modType = 16, modValue = 4, price = (int)CustomizeX.Armor * 5 });
            menu_item_list.Add(new { Label = "Armor <span>7x</span>", modType = 16, modValue = 5, price = (int)CustomizeX.Armor * 6 });
            CreateSubMenu(player, NAPI.Util.ToJson(menu_item_list), "protection");
        }
        else if (callback == "breake")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Label = "Original", modType = 12, modValue = -1, price = 6500 });
            menu_item_list.Add(new { Label = "<span>Street</span> Brakes", modType = 12, modValue = 0, price = 6500 });
            menu_item_list.Add(new { Label = "<span>Sport</span> Brakes", modType = 12, modValue = 1, price = 8775 });
            menu_item_list.Add(new { Label = "<span>Race</span> Brakes", modType = 12, modValue = 2, price = 11375 });
            CreateSubMenu(player, NAPI.Util.ToJson(menu_item_list), "breake");

        }
        else if (callback == "plate")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Label = "<span>Blue On White 1</span>", modType = 62, modValue = 0, price = (int)CustomizeX.Plate });
            menu_item_list.Add(new { Label = "<span>Blue On White 2</span>", modType = 62, modValue = 1, price = (int)((int)CustomizeX.Plate * CustomizeCoefficient.Plate) });
            menu_item_list.Add(new { Label = "<span>Blue On White 3</span>", modType = 62, modValue = 2, price = (int)((int)CustomizeX.Plate * CustomizeCoefficient.Plate) });
            menu_item_list.Add(new { Label = "<span>Yellow on Blue</span>", modType = 62, modValue = 3, price = (int)((int)CustomizeX.Plate * CustomizeCoefficient.Plate) });
            menu_item_list.Add(new { Label = "<span>Custom 1</span>", modType = 62, modValue = 4, price = (int)((int)CustomizeX.Plate * CustomizeCoefficient.Plate) });
            menu_item_list.Add(new { Label = "<span>Custom 2</span>", modType = 62, modValue = 5, price = (int)((int)CustomizeX.Plate * CustomizeCoefficient.Plate) });
            CreateSubMenu(player, NAPI.Util.ToJson(menu_item_list), "plate");
        }
        else if (callback == "engine")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            menu_item_list.Add(new { Label = "Engine <span>Normal</span>", modType = 11, modValue = -1, price = Engine[0].price });
            menu_item_list.Add(new { Label = "Engine <span>2x</span>", modType = 11, modValue = 0, price = Engine[1].price });
            menu_item_list.Add(new { Label = "Engine <span>3x</span>", modType = 11, modValue = 1, price = Engine[2].price });
            menu_item_list.Add(new { Label = "Engine <span>4x</span>", modType = 11, modValue = 2, price = Engine[3].price });
            CreateSubMenu(player, NAPI.Util.ToJson(menu_item_list), "engine");
        }
        else if (callback == "hood")
        {
            player.TriggerEvent("Get_Mod_Menu", 7, "hood");

        }
        else if (callback == "horn")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var item in Horn)
            {
                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = 14, modValue = item.mod, price = item.price });
            }
            CreateSubMenu(player, NAPI.Util.ToJson(menu_item_list), "horn");

        }
        else if (callback == "headlight")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var item in Headlights)
            {
                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = 14, modValue = item.mod, price = item.price });
            }
            CreateSubMenu(player, NAPI.Util.ToJson(menu_item_list), "headlight");

        }
        else if (callback == "exhaust")
        {
            player.TriggerEvent("Get_Mod_Menu", 4, "exhaust");
        }
        else if (callback == "tinting")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var item in windowtint)
            {
                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = 55, modValue = item.tint, price = item.price });
            }
            CreateSubMenu(player, NAPI.Util.ToJson(menu_item_list), "glass");
        }
        else if (callback == "frame")
        {
            player.TriggerEvent("Get_Mod_Menu", 5, "frame");

        }
        else if (callback == "roof")
        {
            player.TriggerEvent("Get_Mod_Menu", 10, "roof");

        }
        else if (callback == "sideskirt")
        {
            player.TriggerEvent("Get_Mod_Menu", 3, "sideskirt");
        }
        else if (callback == "spoiler")
        {
            player.TriggerEvent("Get_Mod_Menu", 0, "spoiler");
        }
        else if (callback == "suspension")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var item in Suspension)
            {
                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = 15, modValue = item.mod, price = item.price });
            }
            CreateSubMenu(player, NAPI.Util.ToJson(menu_item_list), "suspension");
        }
        else if (callback == "transmission")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var item in Transmission)
            {
                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = 13, modValue = item.mod, price = item.price });
            }
            CreateSubMenu(player, NAPI.Util.ToJson(menu_item_list), "transmission");
        }
        else if (callback == "turbo")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var item in Turbo)
            {
                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = 18, modValue = item.mod, price = item.price });
            }
            CreateSubMenu(player, NAPI.Util.ToJson(menu_item_list), "turbo");
        }
        else if (callback == "disk")
        {
            player.TriggerEvent("Display_Tunning_with_data", "", "wheels");
        }
        else if (callback == "painting")
        {
            player.TriggerEvent("Display_Tunning_with_data", "", "painting");
        }



    }
    public void setmod(Player player, int type, int id)
    {
        NAPI.Vehicle.SetVehicleMod(player.Vehicle, type, id);
    }
    public void setmod(Player player, int type)
    {
        NAPI.Vehicle.SetVehicleWheelType(player.Vehicle, type);
    }
    public void setc(Player player, int color1, int color2, int color3)
    {
        // SetVehicleTrimColor  dakhel Mashin
        // SetVehiclePearlescentColor   rang saye
        // SetVehicleWheelColor    rang ring
        // SetVehicleCustomPrimaryColor RGB color
        NAPI.Vehicle.SetVehiclePrimaryColor(player.Vehicle, color1);
        // NAPI.Vehicle.SetVehicleCustomPrimaryColor(player.Vehicle, color1, color2, color3);
    }

    [RemoteEvent("ResetVehicleMod")]
    public static void ResetVehiclePerviewCustomize(Player player)
    {
        if (!player.Vehicle.HasData("index_Mashin") && player.Vehicle.GetData<dynamic>("index_Mashin") == null)
        {
            return;
        }
        int index = player.Vehicle.GetData<int>("index_Mashin");
        string[] temp_mysql_data = PlayerVehicle.vehicle_data[player.Value].json_vehicle_mods[index].ToString().Split('|');

        if (PlayerVehicle.vehicle_data[player.Value].json_vehicle_mods[index] != "")
        {
            PlayerVehicle.vehicle_data[player.Value].handle[index].PrimaryColor = PlayerVehicle.vehicle_data[player.Value].cor_1[index];
            PlayerVehicle.vehicle_data[player.Value].handle[index].SecondaryColor = PlayerVehicle.vehicle_data[player.Value].cor_2[index];
            for (int i = 0; i < 70; i++)
            {
                if (i == 68) continue;
                if (i == 69) continue;
                PlayerVehicle.vehicle_data[player.Value].handle[index].SetMod(i, Convert.ToInt32(temp_mysql_data[i]));
            }
            NAPI.Task.Run(() =>
            {
                PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor = new Color(Convert.ToInt32(temp_mysql_data[68]), Convert.ToInt32(temp_mysql_data[69]), Convert.ToInt32(temp_mysql_data[70]));

                if ((PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor.Red == 0 && PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor.Green == 0 && PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor.Blue == 0) || (PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor.Red == 255 && PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor.Green == 255 && PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor.Blue == 255))
                {
                    API.Shared.SetVehicleNeonState(PlayerVehicle.vehicle_data[player.Value].handle[index], false);
                }
                else
                {
                    API.Shared.SetVehicleNeonState(PlayerVehicle.vehicle_data[player.Value].handle[index], true);
                }
            }, delayTime: 500);
        }
    }

    public static void ResetVehiclePerviewCustomize(Player player, int index)
    {
        string[] temp_mysql_data = PlayerVehicle.vehicle_data[player.Value].json_vehicle_mods[index].ToString().Split('|');

        if (PlayerVehicle.vehicle_data[player.Value].json_vehicle_mods[index] != "")
        {

            for (int i = 0; i < 70; i++)
            {
                if (i == 68) continue;
                if (i == 69) continue;
                PlayerVehicle.vehicle_data[player.Value].handle[index].SetMod(i, Convert.ToInt32(temp_mysql_data[i]));
            }
            NAPI.Task.Run(() =>
            {
                PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor = new Color(Convert.ToInt32(temp_mysql_data[68]), Convert.ToInt32(temp_mysql_data[69]), Convert.ToInt32(temp_mysql_data[70]));

                if ((PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor.Red == 0 && PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor.Green == 0 && PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor.Blue == 0) || (PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor.Red == 255 && PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor.Green == 255 && PlayerVehicle.vehicle_data[player.Value].handle[index].NeonColor.Blue == 255))
                {
                    API.Shared.SetVehicleNeonState(PlayerVehicle.vehicle_data[player.Value].handle[index], false);
                }
                else
                {
                    API.Shared.SetVehicleNeonState(PlayerVehicle.vehicle_data[player.Value].handle[index], true);
                }
            }, delayTime: 500);
        }
    }

    public static bool DoesModInstalled(Player player, int index, int type, int id)
    {
        string[] temp_mysql_data = PlayerVehicle.vehicle_data[player.Value].json_vehicle_mods[index].ToString().Split('|');
        if (temp_mysql_data[type] == id.ToString())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static int DoesModInstalled(Player player, int index, int type)
    {
        string[] temp_mysql_data = PlayerVehicle.vehicle_data[player.Value].json_vehicle_mods[index].ToString().Split('|');
        return int.Parse(temp_mysql_data[type]);
    }

    [RemoteEvent("tunning_select")]
    public static void SelectMenuResponse(Player Client, String callback, int id)
    {
        if (!Client.IsInVehicle && Client.VehicleSeat != -1)
        {
            return;
        }

        int can_pass = 0;
        foreach (var ls in LSCUSTOM_NEW.ls_custom)
        {
            if (ls.in_use == true && ls.vehicle == Client.Vehicle)
            {
                can_pass = 1;
            }
        }

        if (can_pass == 0)
        {
            return;
        }
        if (callback == "Chose_BUMPERS")
        {
            if (id == 1)
            {
                Client.TriggerEvent("Get_Mod_Menu", 1, "bamper_menu_front");
            }
            else
            {
                Client.TriggerEvent("Get_Mod_Menu", 2, "bamper_menu_back");
            }
        }
        else if (callback == "LSCUSTOM_RearBumper")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 2) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= ((int)CustomizeX.RearBumper + (int)((int)CustomizeX.RearBumper / CustomizeCoefficient.RearBumper) * id))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -((int)CustomizeX.RearBumper + (int)((int)CustomizeX.RearBumper / CustomizeCoefficient.RearBumper) * id));
            Client.Vehicle.SetMod(2, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Zadnji branik kupljen!");
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_Protection")
        {
            if (Client.Vehicle.GetMod(16) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= (id * (int)CustomizeX.Armor <= 0 ? (int)CustomizeX.Armor : id * (int)CustomizeX.Armor))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -(id * (int)CustomizeX.Armor));
            Client.Vehicle.SetMod(16, id);
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Vozilo blindirano!");
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");

        }
        else if (callback == "LSCUSTOM_FrontBumper")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 1) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= ((int)CustomizeX.FrontBumper + (int)((int)CustomizeX.FrontBumper / CustomizeCoefficient.FrontBumper) * id))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -((int)CustomizeX.FrontBumper + (int)((int)CustomizeX.FrontBumper / CustomizeCoefficient.FrontBumper) * id));
            Client.Vehicle.SetMod(1, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Brnaik kupljen");
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_Plate")
        {
            if (PlayerVehicle.vehicle_data[Client.Value].json_vehicle_mods[Client.Vehicle.GetData<int>("index_Mashin")].Split("|")[53] == id.ToString())
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= ((int)CustomizeX.Plate + (int)((int)CustomizeX.Plate / CustomizeCoefficient.Plate) * id))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -((int)CustomizeX.Plate + (int)((int)CustomizeX.Plate / CustomizeCoefficient.Plate) * id));
            Client.Vehicle.NumberPlateStyle = id;
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Tablice kupljene.");
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_Breake")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 12) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= ((int)CustomizeX.Break + (int)((int)CustomizeX.Break / CustomizeCoefficient.Break) * id))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -((int)CustomizeX.Break + (int)((int)CustomizeX.Break / CustomizeCoefficient.Break) * id));
            Client.Vehicle.SetMod(12, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Kocnice kupljene!");
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_engine")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 11) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= Engine[id + 1].price)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -Engine[id + 1].price);
            Client.Vehicle.SetMod(11, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Motor kupljen!");
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_hood")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 7) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= TETO_PRICE + (id * TETO_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -TETO_PRICE + (id * TETO_PRICE_INCREASE));
            Client.Vehicle.SetMod(7, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Hauba kupljena!");
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_horn")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 14) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= Horn[id + 1].price)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -Horn[id + 1].price);
            Client.Vehicle.SetMod(14, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Sirena kupljena!");
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_headlight")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 22) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= Headlights[id + 1].price)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -Headlights[id + 1].price);
            Client.Vehicle.SetMod(22, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Svetla kupljena!");
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_exhaust")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 4) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= Exhaust_PRICE + (id * Exhaust_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -Exhaust_PRICE + (id * Exhaust_PRICE_INCREASE));
            Client.Vehicle.SetMod(4, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Auspuh kupljen!");
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_glass")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 55) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= windowtint[id].price)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -windowtint[id].price);
            Client.Vehicle.WindowTint = id;
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Prozori zatamnjeni!");
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_frame")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 5) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= SANTANTONIO_PRICE + (id * SANTANTONIO_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -SANTANTONIO_PRICE + (id * SANTANTONIO_PRICE_INCREASE));
            Client.Vehicle.SetMod(5, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Prozori zatamnjeni!");
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_roof")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 10) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= TETO_PRICE + (id * TETO_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -TETO_PRICE + (id * TETO_PRICE_INCREASE));
            Client.Vehicle.SetMod(10, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_sideskirt")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 3) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= SAIAS_PRICE + (id * SAIAS_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -SAIAS_PRICE + (id * SAIAS_PRICE_INCREASE));
            Client.Vehicle.SetMod(3, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_spoiler")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 0) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= AEROFOLIO_PRICE + (id * AEROFOLIO_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -AEROFOLIO_PRICE + (id * AEROFOLIO_PRICE_INCREASE));
            Client.Vehicle.SetMod(0, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_suspension")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 15) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= SUSPENSION_PRICE + (id * SUSPENSION_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -SUSPENSION_PRICE + (id * SUSPENSION_PRICE_INCREASE));
            Client.Vehicle.SetMod(15, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_transmission")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 13) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= TRANSMISSION_PRICE + (id * TRANSMISSION_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -TRANSMISSION_PRICE + (id * TRANSMISSION_PRICE_INCREASE));
            Client.Vehicle.SetMod(13, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_turbo")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 18) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= TURBO_PRICE + (id * TURBO_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -TURBO_PRICE + (id * TURBO_PRICE_INCREASE));
            Client.Vehicle.SetMod(18, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_suv")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 23) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= SUVWHEEL_PRICE + (id * SUVWHEEL_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -SUVWHEEL_PRICE + (id * SUVWHEEL_PRICE_INCREASE));
            Client.Vehicle.SetMod(23, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_tuner")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 23) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= TUNERWHEEL_PRICE + (id * TUNERWHEEL_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -TUNERWHEEL_PRICE + (id * TUNERWHEEL_PRICE_INCREASE));
            Client.Vehicle.SetMod(23, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_highend")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 23) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= HIGHENDWHELL_PRICE + (id * HIGHENDWHELL_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -HIGHENDWHELL_PRICE + (id * HIGHENDWHELL_PRICE_INCREASE));
            Client.Vehicle.SetMod(23, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_lowrider")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 23) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= LOWRIDERWHEEL_PRICE + (id * LOWRIDERWHEEL_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -LOWRIDERWHEEL_PRICE + (id * LOWRIDERWHEEL_PRICE_INCREASE));
            Client.Vehicle.SetMod(23, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_muscle")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 23) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= MUSCLEWHEEL_PRICE + (id * MUSCLEWHEEL_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -MUSCLEWHEEL_PRICE + (id * MUSCLEWHEEL_PRICE_INCREASE));
            Client.Vehicle.SetMod(23, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_offroad")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 23) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= OFFROADWHEEL_PRICE + (id * 300))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -OFFROADWHEEL_PRICE + (id * 300));
            Client.Vehicle.SetMod(23, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_sport")
        {
            if (DoesModInstalled(Client, Client.Vehicle.GetData<int>("index_Mashin"), 23) == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= SPORTWHEEL_PRICE + (id * SPORTWHEEL_PRICE_INCREASE))
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -SPORTWHEEL_PRICE + (id * SPORTWHEEL_PRICE_INCREASE));
            Client.Vehicle.SetMod(23, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_primarycolor")
        {
            if (PlayerVehicle.vehicle_data[Client.Value].cor_1[Client.Vehicle.GetData<int>("index_Mashin")] == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= COLORMETAL_PRICE)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -COLORMETAL_PRICE);
            Client.Vehicle.PrimaryColor = id;
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_secondarycolor")
        {
            if (PlayerVehicle.vehicle_data[Client.Value].cor_2[Client.Vehicle.GetData<int>("index_Mashin")] == id)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec posedujete ovu komponentu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            if (Main.GetPlayerBank(Client) <= COLORMETAL_PRICE)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -COLORMETAL_PRICE);
            Client.Vehicle.SecondaryColor = id;
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            Main.PlaySoundFrontend(Client, "Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET");
        }
        else if (callback == "LSCUSTOM_neonR")
        {
            if (Main.GetPlayerBank(Client) <= 1500)
            {
                return;
            }
            Main.GivePlayerMoneyBank(Client, -500);
            Client.Vehicle.NeonColor = new Color(id, Client.Vehicle.NeonColor.Green, Client.Vehicle.NeonColor.Blue);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
            
        }
        else if (callback == "LSCUSTOM_neonG")
        {
            if (Main.GetPlayerBank(Client) <= 1000)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -500);
            Client.Vehicle.NeonColor = new Color(Client.Vehicle.NeonColor.Red, id, Client.Vehicle.NeonColor.Blue);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
        }
        else if (callback == "LSCUSTOM_neonB")
        {
            if (Main.GetPlayerBank(Client) <= 500)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca na bankovnom racunu.");
                ResetVehiclePerviewCustomize(Client, Client.Vehicle.GetData<int>("index_Mashin"));
                return;
            }
            Main.GivePlayerMoneyBank(Client, -500);
            Client.Vehicle.NeonColor = new Color(Client.Vehicle.NeonColor.Red, Client.Vehicle.NeonColor.Green, id);
            PlayerVehicle.SavePlayerVehicle(Client, Client.Vehicle.GetData<int>("index_Mashin"));
        }


    }


    [RemoteEvent("tunning_preview")]
    public static void IndexChangeMenuResponse(Player Client, String callbackId, int selectedIndex)
    {
        if (!Client.IsInVehicle && Client.VehicleSeat != -1)
        {
            return;
        }

        int can_pass = 0;
        foreach (var ls in LSCUSTOM_NEW.ls_custom)
        {
            if (ls.in_use == true && ls.vehicle == Client.Vehicle)
            {
                can_pass = 1;
            }
        }
        if (can_pass == 0)
        {
            return;
        }


        if (callbackId == "RearBumper")
        {
            Client.Vehicle.SetMod(2, selectedIndex);
        }
        else if (callbackId == "LSCUSTOM_Protection")
        {
            Client.Vehicle.SetMod(16, selectedIndex);
        }
        else if (callbackId == "FrontBumper")
        {
            Client.Vehicle.SetMod(1, selectedIndex);
        }
        else if (callbackId == "Plate")
        {
            Client.Vehicle.NumberPlateStyle = selectedIndex;
        }
        else if (callbackId == "Breake")
        {
            Client.Vehicle.SetMod(12, selectedIndex);
        }
        else if (callbackId == "LSCUSTOM_engine")
        {
            Client.Vehicle.SetMod(11, selectedIndex);
        }
        else if (callbackId == "hood")
        {
            Client.Vehicle.SetMod(7, selectedIndex);
        }
        else if (callbackId == "LSCUSTOM_horn")
        {
            Client.Vehicle.SetMod(14, selectedIndex);
        }
        else if (callbackId == "headlight")
        {
            Client.Vehicle.SetMod(22, selectedIndex);
        }
        else if (callbackId == "exhaust")
        {
            Client.Vehicle.SetMod(4, selectedIndex);
        }
        else if (callbackId == "glass")
        {
            Client.Vehicle.WindowTint = selectedIndex;
        }
        else if (callbackId == "frame")
        {
            Client.Vehicle.SetMod(5, selectedIndex);
        }
        else if (callbackId == "roof")
        {
            Client.Vehicle.SetMod(10, selectedIndex);
        }
        else if (callbackId == "neonR")
        {
            Client.Vehicle.NeonColor = new Color(selectedIndex, Client.Vehicle.NeonColor.Green, Client.Vehicle.NeonColor.Blue);
        }
        else if (callbackId == "neonG")
        {
            Client.Vehicle.NeonColor = new Color(Client.Vehicle.NeonColor.Red, selectedIndex, Client.Vehicle.NeonColor.Blue);
        }
        else if (callbackId == "neonB")
        {
            Client.Vehicle.NeonColor = new Color(Client.Vehicle.NeonColor.Red, Client.Vehicle.NeonColor.Green, selectedIndex);
        }
        else if (callbackId == "sideskirt")
        {
            Client.Vehicle.SetMod(3, selectedIndex);
        }
        else if (callbackId == "spoiler")
        {
            Client.Vehicle.SetMod(0, selectedIndex);
        }
        else if (callbackId == "suspension")
        {
            Client.Vehicle.SetMod(15, selectedIndex);
        }
        else if (callbackId == "transmission")
        {
            Client.Vehicle.SetMod(13, selectedIndex);
        }
        else if (callbackId == "primarycolor")
        {
            Client.Vehicle.PrimaryColor = selectedIndex;
        }
        else if (callbackId == "secondarycolor")
        {
            Client.Vehicle.SecondaryColor = selectedIndex;
        }
        else if (callbackId == "LSCUSTOM_Painting")
        {
            switch (selectedIndex)
            {
                case 0:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        foreach (var item in colors)
                        {
                            menu_item_list.Add(new { Label =item.name , price=5000 });
                        }
                        Client.TriggerEvent("Display_Tunning_with_data", NAPI.Util.ToJson(menu_item_list), "primarycolor");
                        break;
                    }
                case 1:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        foreach (var item in colors)
                        {
                            menu_item_list.Add(new { Label = item.name, price = 2500 });
                        }
                        Client.TriggerEvent("Display_Tunning_with_data", NAPI.Util.ToJson(menu_item_list), "secondarycolor");
                        break;
                    }
                case 2:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        menu_item_list.Add(new { R = NAPI.Vehicle.GetVehicleNeonColor(Client.Vehicle).Red, G = NAPI.Vehicle.GetVehicleNeonColor(Client.Vehicle).Green, B = NAPI.Vehicle.GetVehicleNeonColor(Client.Vehicle).Blue });
                        Client.TriggerEvent("Display_Tunning_with_data", NAPI.Util.ToJson(menu_item_list), "neon");
                        Client.Vehicle.Neons = true;
                        break;
                    }
                default:
                    break;
            }
        }
        else if (callbackId == "wheels_tuning")
        {
            switch (selectedIndex)
            {
                case 0:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        foreach (var item in lowriderwheels)
                        {
                            if (Client.Vehicle.WheelType == 2 && Client.Vehicle.GetMod(23) == item.mod)
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = 0 });
                            }
                            else
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = item.price });
                            }
                        }
                        Client.TriggerEvent("Display_Tunning_with_data", NAPI.Util.ToJson(menu_item_list), "wheels_lowrider");
                        Client.Vehicle.WheelType = 2;
                        break;
                    }
                case 1:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        foreach (var item in musclewheels)
                        {
                            if (Client.Vehicle.WheelType == 1 && Client.Vehicle.GetMod(23) == item.mod)
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = 0 });
                            }
                            else
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = item.price });
                            }
                        }
                        Client.TriggerEvent("Display_Tunning_with_data", NAPI.Util.ToJson(menu_item_list), "wheels_muscle");

                        Client.Vehicle.WheelType = 1;
                        break;
                    }
                case 2:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        foreach (var item in offroadwheels)
                        {
                            if (Client.Vehicle.WheelType == 4 && Client.Vehicle.GetMod(23) == item.mod)
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = 0 });
                            }
                            else
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = item.price });
                            }
                        }
                        Client.TriggerEvent("Display_Tunning_with_data", NAPI.Util.ToJson(menu_item_list), "wheels_offroad");

                        Client.Vehicle.WheelType = 4;
                        break;
                    }
                case 3:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        foreach (var item in sportwheels)
                        {
                            if (Client.Vehicle.WheelType == 0 && Client.Vehicle.GetMod(23) == item.mod)
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = 0 });
                            }
                            else
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = item.price });
                            }
                        }
                        Client.TriggerEvent("Display_Tunning_with_data", NAPI.Util.ToJson(menu_item_list), "wheels_sport");

                        Client.Vehicle.WheelType = 0;
                        break;
                    }
                case 4:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        foreach (var item in suvwheels)
                        {
                            if (Client.Vehicle.WheelType == 3 && Client.Vehicle.GetMod(23) == item.mod)
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = 0 });
                            }
                            else
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = item.price });
                            }
                        }
                        Client.TriggerEvent("Display_Tunning_with_data", NAPI.Util.ToJson(menu_item_list), "wheels_suv");

                        Client.Vehicle.WheelType = 3;
                        break;
                    }
                case 5:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        foreach (var item in tunerwheels)
                        {
                            if (Client.Vehicle.WheelType == 5 && Client.Vehicle.GetMod(23) == item.mod)
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = 0 });
                            }
                            else
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = item.price });
                            }
                        }
                        Client.TriggerEvent("Display_Tunning_with_data", NAPI.Util.ToJson(menu_item_list), "wheels_tuner");
                        Client.Vehicle.WheelType = 5;
                        break;
                    }
                case 6:
                    {
                        List<dynamic> menu_item_list = new List<dynamic>();
                        foreach (var item in highendwheels)
                        {
                            if (Client.Vehicle.WheelType == 7 && Client.Vehicle.GetMod(23) == item.mod)
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = 0 });
                            }
                            else
                            {
                                menu_item_list.Add(new { Label = " <span>" + item.name + "</span>", modType = item.wtype, modValue = item.mod, price = item.price });
                            }
                        }
                        Client.TriggerEvent("Display_Tunning_with_data", NAPI.Util.ToJson(menu_item_list), "wheels_highend");
                        Client.Vehicle.WheelType = 7;
                        break;
                    }
                default:
                    break;
            }
        }
        else if (callbackId == "sport")
        {
            Client.Vehicle.SetMod(23, selectedIndex);
        }
        else if (callbackId == "lowrider")
        {
            Client.Vehicle.SetMod(23, selectedIndex);
        }
        else if (callbackId == "muscle")
        {
            Client.Vehicle.SetMod(23, selectedIndex);
        }
        else if (callbackId == "offroad")
        {
            Client.Vehicle.SetMod(23, selectedIndex);
        }
        else if (callbackId == "sport")
        {
            Client.Vehicle.SetMod(23, selectedIndex);
        }
        else if (callbackId == "suv")
        {
            Client.Vehicle.SetMod(23, selectedIndex);
        }
        else if (callbackId == "tuner")
        {
            Client.Vehicle.SetMod(23, selectedIndex);
        }
        else if (callbackId == "highend")
        {
            Client.Vehicle.SetMod(23, selectedIndex);
        }



    }

    public static void OnMenuReturnClose(Player Client, String callbackId)
    {

    }


    public class SubMenu
    {
        public string Label { get; set; }
        public int modType { get; set; }
        public int modValue { get; set; }
        public int price { get; set; }
    }


    [RemoteEvent("Create_Submenu_Mod")]
    public static void CreateSubMenu(Player Client, string json, string submenu_name)
    {
        if (!Client.IsInVehicle && Client.VehicleSeat != -1)
        {
            return;
        }

        var data = JsonConvert.DeserializeObject<List<SubMenu>>(json);
        int i = 0;
        List<dynamic> menu_item_list = new List<dynamic>();

        foreach (var item in data)
        {
            if (item.Label != "NULL")
            {

                int price = 0;
                switch (item.modType)
                {
                    case 0: price = AEROFOLIO_PRICE + (i * AEROFOLIO_PRICE_INCREASE); break;
                    case 3: price = SAIAS_PRICE + (i * SAIAS_PRICE_INCREASE); break;
                    case 4: price = Exhaust_PRICE + (i * Exhaust_PRICE_INCREASE); break;
                    case 6: price = Grilles_PRICE + (i * Grilles_PRICE_INCREASE); break;
                    case 7: price = PARALAMAS_PRICE + (i * PARALAMAS_PRICE_INCREASE); break;
                    case 8: price = TETO_PRICE + (i * TETO_PRICE_INCREASE); break;
                    case 10: price = TETO_PRICE + (i * TETO_PRICE_INCREASE); break;
                    case 48: price = LIVERIES_PRICE + (i * LIVERIES_PRICE_INCREASE); break;
                    case 1: price = PARACHOQUEFRONTAL_PRICE + (i * PARACHOQUEFRONTAL_PRICE_INCREASE); break;
                    case 2: price = PARACHOQUETRASEIRO_PRICE + (i * PARACHOQUETRASEIRO_PRICE_INCREASE); break;
                    case 42: price = FAROLPERSONALIZADO_PRICE + (i * FAROLPERSONALIZADO_PRICE_INCREASE); break;
                    case 43: price = ANTENAS_PRICE + (i * ANTENAS_PRICE_INCREASE); break;
                    case 44: price = SAIDADEAR_PRICE + (i * SAIDADEAR_PRICE_INCREASE); break;
                    case 45: price = TANQUE_PRICE + (i * TANQUE_PRICE_INCREASE); break;
                    case 46: price = VIDRO_PRICE + (i * VIDRO_PRICE_INCREASE); break;
                    case 5: price = SANTANTONIO_PRICE + (i * SANTANTONIO_PRICE_INCREASE); break;
                }
                int mod = Client.Vehicle.GetMod(item.modType);
                if (mod == item.modValue)
                {
                    menu_item_list.Add(new { modValue = item.modValue, Label = item.Label, price = 0 });
                }
                else
                {
                    menu_item_list.Add(new { modValue = item.modValue, Label = item.Label, price = price = price == 0 ? item.price : price });
                }
                i++;
            }
        }

        Client.TriggerEvent("Display_Tunning_with_data", NAPI.Util.ToJson(menu_item_list), submenu_name);

    }

    
}

