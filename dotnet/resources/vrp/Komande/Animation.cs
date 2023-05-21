using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
class animationCommands : Script
{

    public static List<dynamic> animAllgemein1 = new List<dynamic>();
    public static List<dynamic> animHandbewegungen1 = new List<dynamic>();
    public static List<dynamic> animSport1 = new List<dynamic>();
    public static List<dynamic> animTanz1 = new List<dynamic>();
    public static List<dynamic> animStehen1 = new List<dynamic>();
    public static List<dynamic> animSitzenBeugen1 = new List<dynamic>();
    public static List<dynamic> animLiegen1 = new List<dynamic>();
    public static List<dynamic> animAnlehnen1 = new List<dynamic>();
    public static List<dynamic> animLaufstile1 = new List<dynamic>();
    public static List<dynamic> animPolice1 = new List<dynamic>();

    public animationCommands()
    {
        animAllgemein1.Add(new { hash = "Bikar negahe atraf kardan", descriptionHash = "Bikar negahe atraf kardan", dict = "rcmrc_omega_2", state = "omega_idle_looking_around", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Greftan shekam", descriptionHash = "Greftan shekam", dict = "rcmpaparazzo1", state = "idle", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Tashvigh kardan", descriptionHash = "Tashvigh kardan", dict = "amb@world_human_cheering@male_b", state = "base", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Boos Ferestadan", descriptionHash = "Boos Ferestadan", dict = "anim@mp_player_intcelebrationfemale@blow_kiss", state = "blow_kiss", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "khodaaaaaa :D", descriptionHash = "khodaaaaaa :D", dict = "oddjobs@towingpleadingidle_b", state = "idle_d", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Akhjon Dava", descriptionHash = "Akhjon Dava", dict = "random@street_race", state = "_streetracer_accepted", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Tamire mashin", descriptionHash = "Tamire mashin", dict = "misscarsteal2fixer", state = "confused_a", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Lam dadan be parchin", descriptionHash = "Lam dadan be parchin", dict = "abigail_mcs_1_concat-5", state = "player_zero_dual-5", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Boos Ferestadan 2", descriptionHash = "Boos Ferestadan 2", dict = "mini@hookers_sp", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Boosidan Dost", descriptionHash = "Boosidan Dost", dict = "mp_ped_interaction", state = "kisses_guy_a", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "hesab kardan pole park", descriptionHash = "hesab kardan pole park", dict = "amb@prop_human_parking_meter@male@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Selfi gereftan", descriptionHash = "Selfi gereftan", dict = "amb@world_human_tourist_mobile@male@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Aghaboftade", descriptionHash = "Aghaboftade", dict = "misstrevor1ig_3", state = "action_b", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Bezan ghadesh", descriptionHash = "Bezan ghadesh", dict = "mp_ped_interaction", state = "highfive_guy_a", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "mechanici raftan zire mashin", descriptionHash = "mechanici raftan zire mashin", dict = "amb@world_human_vehicle_mechanic@male@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "na na na vaisa hamonja", descriptionHash = "na na na vaisa hamonja", dict = "mini@prostitutestalk", state = "street_argue_f_a", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Sigar keshidan", descriptionHash = "Sigar keshidan", dict = "amb@world_human_smoking@male@male_a@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Gitar Zadan", descriptionHash = "Gitar Zadan", dict = "misslester1aig_4main", state = "air_guitar_02_a", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Mashinamo Bordan Badbakht shodam", descriptionHash = "Mashinamo Bordan Badbakht shodam", dict = "misscarsteal2car_stolen", state = "chad_car_stolen_reaction", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Negah kardan be poshte sar az chap", descriptionHash = "Negah kardan be poshte sar az chap", dict = "missarmenian2lamar_idles", state = "idle_look_behind_left", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Negah kardan be poshte sar az rast", descriptionHash = "Negah kardan be poshte sar az rast", dict = "missarmenian2lamar_idles", state = "idle_look_behind_right", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Ba tokhmash var raftan", descriptionHash = "Ba tokhmash var raftan", dict = "missarmenian2", state = "arm2_lamar_idle_01", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Taxi Seda kardan", descriptionHash = "Taxi Seda kardan", dict = "taxi_hail", state = "hail_taxi", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Chera Rafti mano tanha gozashti", descriptionHash = "Chera Rafti mano tanha gozashti", dict = "missfam4leadinoutmcs2", state = "tracy_loop", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "animmp_ped_interactionhugs_guy_a", descriptionHash = "animDescmp_ped_interactionhugs_guy_a", dict = "mp_ped_interaction", state = "hugs_guy_a", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Shashidan", descriptionHash = "Shashidan", dict = "missbigscore1switch_trevor_piss", state = "piss_loop", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Bargh Gereftegi", descriptionHash = "Bargh Gereftegi", dict = "stungun@standing", state = "damage", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Nega Nega Sharmandeam be khoda", descriptionHash = "Nega Nega Sharmandeam be khoda", dict = "anim@mp_player_intcelebrationfemale@face_palm", state = "face_palm", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Ba Dorbin Did zadan", descriptionHash = "Ba Dorbin Did zadan", dict = "amb@world_human_binoculars@male@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Khodeto be on rah zadan", descriptionHash = "Khodeto be on rah zadan", dict = "misscarsteal4@aliens", state = "rehearsal_base_idle_director", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Sigar keshidan 1", descriptionHash = "Sigar keshidan 1", dict = "amb@world_human_smoking@male@male_b@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Sigar keshidan 2", descriptionHash = "Sigar keshidan 2", dict = "amb@world_human_smoking_pot@male@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Tokonam arosie:D", descriptionHash = "Tokonam arosie:D", dict = "anim@mp_player_intcelebrationmale@freakout", state = "freakout", flag = 33, repeat = true, sex = "both" });
        animAllgemein1.Add(new { hash = "Velam kon baw", descriptionHash = "animDescmissarmenian2lamar_impatient_a", dict = "missarmenian2", state = "lamar_impatient_a", flag = 49, repeat = true, sex = "both" });



        animHandbewegungen1.Add(new { hash = "Dastha Balaye sar", descriptionHash = "Dastha Balaye sar", dict = "rcmpaparazzo_4", state = "lift_hands_in_air_loop", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Dastha roye sar", descriptionHash = "Dastha roye sar", dict = "random@arrests@busted", state = "idle_c", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Gaidamet az har do taraf:D", descriptionHash = "Gaidamet az har do taraf:D", dict = "nm@hands", state = "middle_finger", flag = 33, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Dast be sine vaysadan", descriptionHash = "Dast be sine vaysadan", dict = "oddjobs@assassinate@guard", state = "unarmed_fold_arms", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Hey pesar Bia inja", descriptionHash = "Hey pesar Bia inja", dict = "oddjobs@towingcome_here", state = "come_here_idle_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Bashe Bashe Dametgarm", descriptionHash = "Bashe Bashe Dametgarm", dict = "random@bicycle_thief@thanks", state = "thanks_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Ahay Inja", descriptionHash = "Ahay Inja", dict = "random@gang_intimidation@", state = "001445_01_gangintimidation_1_female_idle_b", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Karet biste :D", descriptionHash = "Karet biste :D", dict = "anim@mp_player_intselfiedock", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Garme Khoda Garme:D", descriptionHash = "Garme Khoda Garme:D", dict = "timetable@amanda@facemask@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Noshidan", descriptionHash = "Noshidan", dict = "amb@world_human_drinking@coffee@female@idle_a", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Hamberger Khordan", descriptionHash = "Hamberger Khordan", dict = "mp_player_inteat@burger", state = "mp_player_int_eat_burger", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "aroom bash", descriptionHash = "aroom bash", dict = "gestures@f@standing@casual", state = "gesture_easy_now", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Ehteram nezami", descriptionHash = "Ehteram nezami", dict = "anim@mp_player_intincarsalutestd@rds@", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Mokhlesam", descriptionHash = "Mokhlesam", dict = "mp_player_intsalute", state = "mp_player_int_salute", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Neshan Solh", descriptionHash = "Neshan Solh", dict = "mp_player_int_upperpeace_sign", state = "mp_player_int_peace_sign", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Bia inja", descriptionHash = "Bia inja", dict = "misscarsteal2", state = "come_here_idle_c", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Telephon Harf zadan", descriptionHash = "Telephon Harf zadan", dict = "amb@world_human_stand_mobile@male@standing@call@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Gaidamet 1", descriptionHash = "Gaidamet 1", dict = "mp_player_int_upperfinger", state = "mp_player_int_finger_02", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Gaidamet 2", descriptionHash = "Gaidamet 2", dict = "mp_player_int_upperfinger", state = "mp_player_int_finger_01", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Gaidamet 3", descriptionHash = "Gaidamet 3", dict = "anim@mp_player_intupperfinger", state = "idle_a_fp", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Gaidamet 4", descriptionHash = "Gaidamet 4", dict = "mp_player_intfinger", state = "mp_player_int_finger", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Hissss", descriptionHash = "Hissss", dict = "anim@mp_player_intuppershush", state = "idle_a_fp", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Bilakh", descriptionHash = "Bilakh", dict = "anim@mp_player_intincarthumbs_upstd@ds@", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "Goh Tosh", descriptionHash = "Goh Tosh", dict = "gestures@f@standing@casual", state = "gesture_damn", flag = 49, repeat = true, sex = "both" });
        animHandbewegungen1.Add(new { hash = "kaf zadan", descriptionHash = "kaf zadan", dict = "anim@mp_player_intcelebrationmale@slow_clap", state = "slow_clap", flag = 49, repeat = true, sex = "both" });



        animSport1.Add(new { hash = "Harekat kesheshi 1", descriptionHash = "Harekat kesheshi 1", dict = "amb@world_human_yoga@male@base", state = "base_a", flag = 33, repeat = true, sex = "both" });
        animSport1.Add(new { hash = "Harekat kesheshi 2", descriptionHash = "Harekat kesheshi 2", dict = "rcmfanatic1maryann_stretchidle_b", state = "idle_e", flag = 33, repeat = true, sex = "both" });
        animSport1.Add(new { hash = "Yoga", descriptionHash = "Yoga", dict = "rcmcollect_paperleadinout@", state = "meditiate_idle", flag = 33, repeat = true, sex = "both" });
        animSport1.Add(new { hash = "Shena sweden", descriptionHash = "Shena sweden", dict = "rcmfanatic3", state = "ef_3_rcm_loop_maryann", flag = 33, repeat = true, sex = "both" });
        animSport1.Add(new { hash = "Doidan darja", descriptionHash = "Doidan darja", dict = "amb@world_human_jog_standing@male@fitbase", state = "base", flag = 33, repeat = true, sex = "both" });
        animSport1.Add(new { hash = "Derazo neshast", descriptionHash = "Derazo neshast", dict = "amb@world_human_sit_ups@male@idle_a", state = "idle_a", flag = 33, repeat = true, sex = "both" });


        animTanz1.Add(new { hash = "Raghse Kohestani 1", descriptionHash = "Raghse Kohestani 1", dict = "special_ped@mountain_dancer@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Raghse Kohestani 2", descriptionHash = "Raghse Kohestani 2", dict = "special_ped@mountain_dancer@monologue_2@monologue_2a", state = "mnt_dnc_angel", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Raghse Kohestani 3", descriptionHash = "Raghse Kohestani 3", dict = "special_ped@mountain_dancer@monologue_3@monologue_3a", state = "mnt_dnc_buttwag", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Raghse Kohestani 4", descriptionHash = "Raghse Kohestani 4", dict = "special_ped@mountain_dancer@monologue_4@monologue_4a", state = "mnt_dnc_verse", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Raghse Mehmoni", descriptionHash = "Raghse Mehmoni", dict = "amb@world_human_partying@female@partying_beer@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Raghse Lokhti 1", descriptionHash = "Raghse Lokhti 1", dict = "amb@world_human_strip_watch_stand@male_a@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Raghse Lokhti 2", descriptionHash = "Raghse Lokhti 2", dict = "mb@world_human_strip_watch_stand@male_b@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Raghse Lokhti 3", descriptionHash = "Raghse Lokhti 3", dict = "mini@strip_club@private_dance@part1", state = "priv_dance_p1", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Raghse Lokhti 4", descriptionHash = "Raghse Lokhti 4", dict = "mini@strip_club@private_dance@part2", state = "priv_dance_p2", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Raghse Lokhti 5", descriptionHash = "Raghse Lokhti 5", dict = "mini@strip_club@private_dance@part3", state = "priv_dance_p3", flag = 33, repeat = true, sex = "both" });
        animTanz1.Add(new { hash = "Raghse Lokhti 6", descriptionHash = "Raghse Lokhti 6", dict = "timetable@tracy@ig_8@idle_a", state = "idle_a", flag = 33, repeat = true, sex = "both" });


        //
        //
        //

        animStehen1.Add(new { hash = "Masti", descriptionHash = "Masti", dict = "missarmenian2", state = "standing_idle_loop_drunk", flag = 33, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "Harze", descriptionHash = "Harze", dict = "amb@world_human_prostitute@hooker@idle_a", state = "idle_a", flag = 33, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "Sigar keshidan Zan", descriptionHash = "Sigar keshidan Zan", dict = "amb@world_human_smoking@female@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "Jest Dava", descriptionHash = "Jest Dava", dict = "misscarsteal1leadinout@i_fought_the_law", state = "micarrive_leadin_loop_devin", flag = 49, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "Style BodyGurd", descriptionHash = "Style BodyGurd", dict = "amb@world_human_stand_guard@male@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animStehen1.Add(new { hash = "Jeste Reis Gereftan", descriptionHash = "Jeste Reis Gereftan", dict = "anim@heists@heist_corona@single_team", state = "single_team_intro_boss", flag = 33, repeat = true, sex = "both" });

        //
        //
        //
        animSitzenBeugen1.Add(new { hash = "adame Tarso 1", descriptionHash = "adame Tarso 1", dict = "amb@code_human_cower@male@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "adame Tarso 2", descriptionHash = "adame Tarso 2", dict = "amb@code_human_cower@male@idle_a", state = "idle_b", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Gerogane Zan", descriptionHash = "animDescrandom@rescue_hostagegirl_helping_girl_loop", dict = "random@rescue_hostage", state = "girl_helping_girl_loop", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Zamino Baresi kardan", descriptionHash = "Zamino Baresi kardan", dict = "misstrevor2ron_basic_moves", state = "idle", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Zamino Baresi kardan 1", descriptionHash = "Zamino Baresi kardan 1", dict = "missheistdockssetup1ig_3@base", state = "welding_base_dockworker", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Cpr anjam dadan", descriptionHash = "Cpr anjam dadan", dict = "mini@cpr@char_a@cpr_str", state = "cpr_kol_idle", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Zano Zadan", descriptionHash = "Zano Zadan", dict = "amb@medic@standing@kneel@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "Baresi Kardan", descriptionHash = "Baresi Kardan", dict = "clothingshoes", state = "check_out_a", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "picni", descriptionHash = "picni", dict = "amb@world_human_picnic@male@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "picni 1", descriptionHash = "picni 1", dict = "amb@world_human_stupor@male@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "picni 2", descriptionHash = "picni 2", dict = "amb@lo_res_idles@", state = "world_human_picnic_female_lo_res_base", flag = 33, repeat = true, sex = "both" });
        animSitzenBeugen1.Add(new { hash = "neshastan", descriptionHash = "neshastan", dict = "anim@heists@fleeca_bank@ig_7_jetski_owner", state = "owner_idle", flag = 33, repeat = true, sex = "both" });

        //
        //
        //

        animLiegen1.Add(new { hash = "Zakhmi", descriptionHash = "animDescrandom@crash_rescue@wounded@basebase", dict = "random@crash_rescue@wounded@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Paye tir khorde", descriptionHash = "Pa tir khorde", dict = "missfbi5ig_0", state = "lyinginpain_loop_steve", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Deraz keshidan be posht", descriptionHash = "Deraz keshidan be posht", dict = "amb@world_human_sunbathe@female@back@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Deraz keshidan be jelo", descriptionHash = "Deraz keshidan be jelo", dict = "amb@world_human_sunbathe@female@front@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Deraz keshidan be posht 1", descriptionHash = "Deraz keshidan be posht 1", dict = "amb@world_human_sunbathe@male@back@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Deraz keshidan be jelo 1", descriptionHash = "Deraz keshidan be jelo 1", dict = "amb@world_human_sunbathe@male@front@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Deraz Keshidan baraye CPR", descriptionHash = "animDescmini@cpr@char_b@cpr_defcpr_pumpchest_idle", dict = "mini@cpr@char_b@cpr_def", state = "cpr_pumpchest_idle", flag = 33, repeat = true, sex = "both" });
        animLiegen1.Add(new { hash = "Khabidan", descriptionHash = "Khabidan", dict = "timetable@tracy@sleep@", state = "base", flag = 33, repeat = true, sex = "both" });


        //
        //
        //
        animAnlehnen1.Add(new { hash = "Sigar Keshidan zan", descriptionHash = "Sigar Keshidan zan", dict = "amb@world_human_leaning@female@smoke@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAnlehnen1.Add(new { hash = "Be divar tekie dadan", descriptionHash = "Be divar tekie dadan", dict = "amb@world_human_leaning@female@wall@back@holding_elbow@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAnlehnen1.Add(new { hash = "Be divar tekie dadan 1", descriptionHash = "Be divar tekie dadan 1", dict = "amb@world_human_leaning@male@wall@back@foot_up@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAnlehnen1.Add(new { hash = "Be divar tekie dadan 2", descriptionHash = "Be divar tekie dadan 2", dict = "amb@world_human_leaning@male@wall@back@hands_together@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAnlehnen1.Add(new { hash = "Be divar tekie dadan 3", descriptionHash = "Be divar tekie dadan 3", dict = "amb@world_human_leaning@male@wall@back@legs_crossed@base", state = "base", flag = 33, repeat = true, sex = "both" });
        animAnlehnen1.Add(new { hash = "Be divar tekie dadan 4", descriptionHash = "Be divar tekie dadan 4", dict = "oddjobs@assassinate@hotel@leaning@", state = "idle_a", flag = 33, repeat = true, sex = "both" });
        animAnlehnen1.Add(new { hash = "Be divar tekie dadan 5", descriptionHash = "Be divar tekie dadan 5", dict = "rcmnigel1aig_1", state = "this_is_awkward_willie", flag = 33, repeat = true, sex = "both" });

        //
        //
        //



        animLaufstile1.Add(new { hash = "Khahesh kardan", descriptionHash = "Khahesh kardan", dict = "oddjobs@bailbond_mountain", state = "excited_idle_b", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Telephon Harf zadan 1", descriptionHash = "Telephon Harf zadan 1", dict = "oddjobs@bailbond_quarry", state = "prem_producer_argue_a", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Man na Man nabodam:D", descriptionHash = "Man na Man nabodam:D", dict = "oddjobs@bailbond_surf_farm", state = "idle_a", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Znedani be atraf negah mikone", descriptionHash = "Znedani be atraf negah mikone", dict = "random@prisoner_lift", state = "loop2_idlelook2", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Nafas Tangi", descriptionHash = "Nafas Tangi", dict = "rcmfanatic1out_of_breath", state = "p_zero_tired_01", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Harze Ghimat chand", descriptionHash = "Harze Ghimat chand", dict = "rcmnigel1cnmt_1c", state = "price_tag", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "To fekr", descriptionHash = "To fekr", dict = "To fekr", state = "base", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Depress istadan", descriptionHash = "Depress istadan", dict = "Depress", state = "base", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Gereftan Bazo", descriptionHash = "Gereftan Bazo", dict = "amb@world_human_hang_out_street@female_hold_arm@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animLaufstile1.Add(new { hash = "Mast rah raftan", descriptionHash = "Mast rah raftan", dict = "move_m@drunk@verydrunk", state = "walk", flag = 33, repeat = true, sex = "both" });

        //
        //
        //

        animPolice1.Add(new { hash = "Police istade Dast ha Roye Kamarband", descriptionHash = "Police istade Dast ha Roye Kamarband", dict = "amb@world_human_cop_idles@male@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "Police istade Dast ha Roye Kamar", descriptionHash = "Police istade Dast ha Roye Kamar", dict = "amb@world_human_cop_idles@male@idle_b", state = "idle_e", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "Police istade Dast ha Roye sine", descriptionHash = "Police istade Dast ha Roye sine", dict = "amb@world_human_cop_idles@female@idle_b", state = "idle_e", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "Police Rahnemai", descriptionHash = "Police Rahnemai", dict = "amb@world_human_car_park_attendant@male@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "Police Yadash Bardari", descriptionHash = "Police Yadash Bardari", dict = "amb@medic@standing@timeofdeath@base", state = "base", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "Police Baresi daftarche", descriptionHash = "Police Baresi daftarche", dict = "amb@world_human_clipboard@male@idle_a", state = "idle_c", flag = 49, repeat = true, sex = "both" });
        animPolice1.Add(new { hash = "Police Dast Be aslahe", descriptionHash = "Police Dast Be aslahe", dict = "move_m@intimidation@cop@unarmed", state = "idle", flag = 49, repeat = true, sex = "both" });

    }


    [Flags]
    public enum AnimationFlags
    {
        Loop = 1 << 0,
        StopOnLastFrame = 1 << 1,
        OnlyAnimateUpperBody = 1 << 4,
        AllowPlayerControl = 1 << 5,
        Cancellable = 1 << 7
    }

    [RemoteEvent("Falando")]
    public static void FalandoOn(Player Client)
    {
        Client.SetSharedData("falando", true);
    }

    [RemoteEvent("FalandoOff")]
    public static void FalandoOff(Player Client)
    {
        Client.SetSharedData("falando", false);
    }

    [RemoteEvent("MuteVoice")]
    public static void MuteVoice(Player Client, Player target)
    {
        target.TriggerEvent("MuteVoice");
    }

    [RemoteEvent("handsUp")]
    public static void handsUp(Player Client)
    {
        if (Client.GetData<dynamic>("playerCuffed") != 0)
        {
            NAPI.Notification.SendNotificationToPlayer(Client, "~r~Greska:~w~ Ne mozete koristiti animacije dok ste vezani.");
            return;
        }

        Client.SetData<dynamic>("handsup", true);
    }

    [RemoteEvent("handsDown")]
    public static void handsDown(Player Client)
    {
        if (Client.GetData<dynamic>("playerCuffed") != 0)
        {
            NAPI.Notification.SendNotificationToPlayer(Client, "~r~Greska:~w~ Ne mozete koristiti animacije dok ste vezani");
            return;
        }

        Client.SetData<dynamic>("handsup", false);
        Client.StopAnimation();
    }

    [RemoteEvent("PlayAnimationFromMenu")]
    public static void OnPlayAnimationFromMenu(Player Client, string dict, string state, int flag)
    {
        if (Client.GetData<dynamic>("playerCuffed") != 0)
        {
            NAPI.Notification.SendNotificationToPlayer(Client, "~r~Greska:~w~ Ne mozete koristiti animacije dok ste vezani");
            return;
        }

        Client.PlayAnimation(dict, state, flag);
    }

    [RemoteEvent("StopAnimationFromMenu")]
    public static void StopAnimationFromMenu(Player Client)
    {
        if (Client.GetData<dynamic>("playerCuffed") != 0)
        {
            NAPI.Notification.SendNotificationToPlayer(Client, "~r~Greska:~w~ Ne mozete koristiti animacije dok ste vezani");
            return;
        }
        if (Client.GetSharedData<dynamic>("Injured") == 1)
        {
            return;
        }

        Client.StopAnimation();
    }



    [RemoteEvent("keypress:U")]
    public void KeyPressF1(Player Client)
    {
        if (Client.GetData<dynamic>("status") == false)
        {
            return;
        }
        if (Client.GetSharedData<dynamic>("Injured") >= 1)
        {
            return;
        }
        if (Client.IsInVehicle)
        {
            return;
        }

        if (Client.GetData<dynamic>("playerCuffed") != 0)
        {
            NAPI.Notification.SendNotificationToPlayer(Client, "~r~Greska:~w~ Ne mozete koristiti animacije dok ste vezani");
            return;
        }


        ShowAnimationMenu(Client);
    }

    [RemoteEvent("closeAnimationMenu")]
    public static void closeAnimationMenu(Player Client)
    {
        if (Client.HasData("AnimationMenu"))
        {
            Client.ResetData("AnimationMenu");
        }
    }


    public static void ShowAnimationMenu(Player Client)
    {

        List<dynamic> menu_item_list = new List<dynamic>();
        menu_item_list.Add(new { Type = 1, Name = "Payane Animation", Description = "Baraye Motevaghef kardan Animation", RightBadge = "", Color = "Firebrick", HighlightColor = "White" });
        menu_item_list.Add(new { Type = 1, Name = "Omomi", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Dast Tekan dadan", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Varzeshi", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Raghs", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Hemayati", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Baraye Esterahat", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Tamaroz / Asib didan", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Istadan", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Rah Rftan / Davidan", Description = "", RightBadge = "none" });
        menu_item_list.Add(new { Type = 1, Name = "Police", Description = "", RightBadge = "none" });


        InteractMenu.CreateMenu(Client, "ANIMATION_MENU", "Animation", "~b~ANIMATION SYSTEM", false, NAPI.Util.ToJson(menu_item_list), false);

    }

    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "ANIMATION_MENU")
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            switch (selectedIndex)
            {
                case 0:
                    {
                        StopAnimationFromMenu(Client);
                        break;
                    }
                case 1:
                    {
                        foreach (var menu in animAllgemein1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(Client, "PLAY_ANIMATION", "Animation", "~b~Animation: " + objectName, false, NAPI.Util.ToJson(menu_item_list), false);
                        Client.SetData<dynamic>("Enable_K_Menu", true);
                        break;
                    }
                case 2:
                    {
                        foreach (var menu in animHandbewegungen1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(Client, "PLAY_ANIMATION", "Animation", "~b~Animation: " + objectName, false, NAPI.Util.ToJson(menu_item_list), false);
                        Client.SetData<dynamic>("Enable_K_Menu", true);
                        break;
                    }
                case 3:
                    {
                        foreach (var menu in animSport1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(Client, "PLAY_ANIMATION", "Animation", "~b~Animation: " + objectName, false, NAPI.Util.ToJson(menu_item_list), false);
                        Client.SetData<dynamic>("Enable_K_Menu", true);
                        break;
                    }
                case 4:
                    {
                        foreach (var menu in animTanz1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(Client, "PLAY_ANIMATION", "Animation", "~b~Animation: " + objectName, false, NAPI.Util.ToJson(menu_item_list), false);
                        Client.SetData<dynamic>("Enable_K_Menu", true);
                        break;
                    }
                case 5:
                    {
                        foreach (var menu in animStehen1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(Client, "PLAY_ANIMATION", "Animation", "~b~Animation: " + objectName, false, NAPI.Util.ToJson(menu_item_list), false);
                        Client.SetData<dynamic>("Enable_K_Menu", true);
                        break;
                    }
                case 6:
                    {
                        foreach (var menu in animSitzenBeugen1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(Client, "PLAY_ANIMATION", "Animation", "~b~Animation: " + objectName, false, NAPI.Util.ToJson(menu_item_list), false);
                        Client.SetData<dynamic>("Enable_K_Menu", true);
                        break;
                    }
                case 7:
                    {
                        foreach (var menu in animLiegen1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(Client, "PLAY_ANIMATION", "Animation", "~b~Animation: " + objectName, false, NAPI.Util.ToJson(menu_item_list), false);
                        Client.SetData<dynamic>("Enable_K_Menu", true);
                        break;
                    }
                case 8:
                    {
                        foreach (var menu in animAnlehnen1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(Client, "PLAY_ANIMATION", "Animation", "~b~Animation: " + objectName, false, NAPI.Util.ToJson(menu_item_list), false);
                        Client.SetData<dynamic>("Enable_K_Menu", true);
                        break;
                    }
                case 9:
                    {
                        foreach (var menu in animLaufstile1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(Client, "PLAY_ANIMATION", "Animation", "~b~Animation: " + objectName, false, NAPI.Util.ToJson(menu_item_list), false);
                        Client.SetData<dynamic>("Enable_K_Menu", true);
                        break;
                    }
                case 10:
                    {
                        foreach (var menu in animPolice1)
                        {
                            menu_item_list.Add(new { Type = 1, Name = menu.hash, Description = "", RightBadge = "none" });
                        }
                        InteractMenu.CreateMenu(Client, "PLAY_ANIMATION", "Animation", "~b~Animation: " + objectName, false, NAPI.Util.ToJson(menu_item_list), false);
                        Client.SetData<dynamic>("Enable_K_Menu", true);
                        break;
                    }

            }
        }
        else if (callbackId == "PLAY_ANIMATION")
        {
            foreach (var menu in animAllgemein1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animHandbewegungen1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animSport1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animTanz1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animStehen1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animSitzenBeugen1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animLiegen1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animAnlehnen1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animLaufstile1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animPolice1)
            {
                if (objectName == menu.hash)
                {
                    OnPlayAnimationFromMenu(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }

        }
        else if (callbackId == "ANIMATION_MENU_SHORTCUT_ADD")
        {
            string dict = Client.GetData<dynamic>("animation_dict");
            string state = Client.GetData<dynamic>("animation_state");
            int flag = Client.GetData<dynamic>("animation_flag");

            if (dict == "")
            {
                return;
            }

            Client.SetData<dynamic>("animation_shortcut_dict_" + selectedIndex, dict);
            Client.SetData<dynamic>("animation_shortcut_state_" + selectedIndex, state);
            Client.SetData<dynamic>("animation_shortcut_flag_" + selectedIndex, flag);

            SaveShortcut(Client);
        }
    }

    public static void SaveShortcut(Player Client)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            try
            {
                string query = "UPDATE characters SET shortcut_0 = @shortcut_0, shortcut_1 = @shortcut_1, shortcut_2 = @shortcut_2, shortcut_3 = @shortcut_3, shortcut_4 = @shortcut_4, shortcut_5 = @shortcut_5, shortcut_6 = @shortcut_6, shortcut_7 = @shortcut_7, shortcut_8 = @shortcut_8, shortcut_9 = @shortcut_9 WHERE `id` = '" + AccountManage.GetPlayerSQLID(Client) + "'";
                MySqlCommand myCommand = new MySqlCommand(query, Mainpipeline);

                string shortcut_0 = Client.GetData<dynamic>("animation_shortcut_dict_0") + "|" + Client.GetData<dynamic>("animation_shortcut_state_0") + "|" + Client.GetData<dynamic>("animation_shortcut_flag_0");
                string shortcut_1 = Client.GetData<dynamic>("animation_shortcut_dict_1") + "|" + Client.GetData<dynamic>("animation_shortcut_state_1") + "|" + Client.GetData<dynamic>("animation_shortcut_flag_1");
                string shortcut_2 = Client.GetData<dynamic>("animation_shortcut_dict_2") + "|" + Client.GetData<dynamic>("animation_shortcut_state_2") + "|" + Client.GetData<dynamic>("animation_shortcut_flag_2");
                string shortcut_3 = Client.GetData<dynamic>("animation_shortcut_dict_3") + "|" + Client.GetData<dynamic>("animation_shortcut_state_3") + "|" + Client.GetData<dynamic>("animation_shortcut_flag_3");
                string shortcut_4 = Client.GetData<dynamic>("animation_shortcut_dict_4") + "|" + Client.GetData<dynamic>("animation_shortcut_state_4") + "|" + Client.GetData<dynamic>("animation_shortcut_flag_4");
                string shortcut_5 = Client.GetData<dynamic>("animation_shortcut_dict_5") + "|" + Client.GetData<dynamic>("animation_shortcut_state_5") + "|" + Client.GetData<dynamic>("animation_shortcut_flag_5");
                string shortcut_6 = Client.GetData<dynamic>("animation_shortcut_dict_6") + "|" + Client.GetData<dynamic>("animation_shortcut_state_6") + "|" + Client.GetData<dynamic>("animation_shortcut_flag_6");
                string shortcut_7 = Client.GetData<dynamic>("animation_shortcut_dict_7") + "|" + Client.GetData<dynamic>("animation_shortcut_state_7") + "|" + Client.GetData<dynamic>("animation_shortcut_flag_7");
                string shortcut_8 = Client.GetData<dynamic>("animation_shortcut_dict_8") + "|" + Client.GetData<dynamic>("animation_shortcut_state_8") + "|" + Client.GetData<dynamic>("animation_shortcut_flag_8");
                string shortcut_9 = Client.GetData<dynamic>("animation_shortcut_dict_9") + "|" + Client.GetData<dynamic>("animation_shortcut_state_9") + "|" + Client.GetData<dynamic>("animation_shortcut_flag_9");


                myCommand.Parameters.AddWithValue("@shortcut_0", "" + shortcut_0 + "");
                myCommand.Parameters.AddWithValue("@shortcut_1", "" + shortcut_1 + "");
                myCommand.Parameters.AddWithValue("@shortcut_2", "" + shortcut_2 + "");
                myCommand.Parameters.AddWithValue("@shortcut_3", "" + shortcut_3 + "");
                myCommand.Parameters.AddWithValue("@shortcut_4", "" + shortcut_4 + "");
                myCommand.Parameters.AddWithValue("@shortcut_5", "" + shortcut_5 + "");
                myCommand.Parameters.AddWithValue("@shortcut_6", "" + shortcut_6 + "");
                myCommand.Parameters.AddWithValue("@shortcut_7", "" + shortcut_7 + "");
                myCommand.Parameters.AddWithValue("@shortcut_8", "" + shortcut_8 + "");
                myCommand.Parameters.AddWithValue("@shortcut_9", "" + shortcut_9 + "");



                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            Mainpipeline.Close();
        }
        
    }

    public static void IndexChangeMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "PLAY_ANIMATION")
        {
            foreach (var menu in animAllgemein1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animHandbewegungen1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animSport1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animTanz1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animStehen1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animSitzenBeugen1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animLiegen1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animAnlehnen1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }
            foreach (var menu in animLaufstile1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }

            foreach (var menu in animPolice1)
            {
                if (objectName == menu.hash)
                {
                    AddVariable(Client, menu.dict, menu.state, menu.flag);
                    return;
                }
            }


        }
    }

    [RemoteEvent("DisplayInfoAnimationShot")]
    public static void DisplayInfoAnimationShot(Player Client)
    {
        if (Client.GetData<dynamic>("Enable_K_Menu") == false)
        {
            return;
        }

        InteractMenu.CloseDynamicMenu(Client);
        List<dynamic> menu_item_list = new List<dynamic>();

        for (int i = 0; i < 10; i++)
        {
            if (Client.GetData<dynamic>("animation_shortcut_dict_" + i) != "")
            {
                menu_item_list.Add(new { Type = 1, Name = "CTRL + " + i, Description = "Ponavljanje", RightLabel = "~r~KORISTI SE" });
            }
            else
            {
                menu_item_list.Add(new { Type = 1, Name = "CTRL + " + i, Description = "Zaustavi animaciju!", RightLabel = "~c~" });
            }
        }

        InteractMenu.CreateMenu(Client, "ANIMATION_MENU_SHORTCUT_ADD", "Animation", "~b~Animacije ", false, NAPI.Util.ToJson(menu_item_list), false);
    }

    [Command("down")]
    public void Surrender(Player Client)
    {
        if (Client.HasData("Hands_up") && Client.GetData<dynamic>("Hands_up") == true)
        {
            Client.StopAnimation();
          //  NAPI.Player.PlayPlayerAnimation(Client, 56, "random@arrests", "kneeling_arrest_get_up", 3);
            Client.SetData<dynamic>("Hands_up", false);
        }
        else
        {
            NAPI.Player.PlayPlayerAnimation(Client, 38, "random@arrests", "idle_2_hands_up", 3);
            Client.SetData<dynamic>("Hands_up", true);
        }
        
    }

    [RemoteEvent("animationMenuVariableOff")]
    public static void animationMenuVariableOff(Player Client)
    {
        Client.SetSharedData("Enable_K_Menu", false);
    }

    [RemoteEvent("keypress:0")]
    public static void KeyPress0(Player Client)
    {
        
        if (Client.GetSharedData<dynamic>("Injured") == 1) { return; }
        if (Client.GetData<dynamic>("playerCuffed") == 1) { return; }
        
        if (Client.IsInVehicle) { return; }

        if (Client.HasData("ForceAnim") && Client.GetData<dynamic>("ForceAnim") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, "Ne mozete zaustaviti ovu animaciju");
            return;
        }

        Client.StopAnimation();
        Client.TriggerEvent("freezeEx", false);

    }


    [RemoteEvent("keypress:1")]
    public static void KeyPress1(Player Client)
    {
        int number = 1;


        string dict = Client.GetData<dynamic>("animation_shortcut_dict_" + number);
        string state = Client.GetData<dynamic>("animation_shortcut_state_" + number);
        int flag = Client.GetData<dynamic>("animation_shortcut_flag_" + number);

        if (dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(Client, dict, state, flag);
    }


    [RemoteEvent("keypress:2")]
    public static void KeyPress2(Player Client)
    {
        int number = 2;


        string dict = Client.GetData<dynamic>("animation_shortcut_dict_" + number);
        string state = Client.GetData<dynamic>("animation_shortcut_state_" + number);
        int flag = Client.GetData<dynamic>("animation_shortcut_flag_" + number);

        if (dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(Client, dict, state, flag);
    }


    [RemoteEvent("keypress:3")]
    public static void KeyPress3(Player Client)
    {
        int number = 3;


        string dict = Client.GetData<dynamic>("animation_shortcut_dict_" + number);
        string state = Client.GetData<dynamic>("animation_shortcut_state_" + number);
        int flag = Client.GetData<dynamic>("animation_shortcut_flag_" + number);

        if (dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(Client, dict, state, flag);
    }


    [RemoteEvent("keypress:4")]
    public static void KeyPress4(Player Client)
    {
        int number = 4;


        string dict = Client.GetData<dynamic>("animation_shortcut_dict_" + number);
        string state = Client.GetData<dynamic>("animation_shortcut_state_" + number);
        int flag = Client.GetData<dynamic>("animation_shortcut_flag_" + number);

        if (dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(Client, dict, state, flag);
    }


    [RemoteEvent("keypress:5")]
    public static void KeyPress5(Player Client)
    {
        int number = 5;


        string dict = Client.GetData<dynamic>("animation_shortcut_dict_" + number);
        string state = Client.GetData<dynamic>("animation_shortcut_state_" + number);
        int flag = Client.GetData<dynamic>("animation_shortcut_flag_" + number);

        if (dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(Client, dict, state, flag);
    }


    [RemoteEvent("keypress:6")]
    public static void KeyPress6(Player Client)
    {
        int number = 6;


        string dict = Client.GetData<dynamic>("animation_shortcut_dict_" + number);
        string state = Client.GetData<dynamic>("animation_shortcut_state_" + number);
        int flag = Client.GetData<dynamic>("animation_shortcut_flag_" + number);

        if (dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(Client, dict, state, flag);
    }


    [RemoteEvent("keypress:7")]
    public static void KeyPress7(Player Client)
    {
        int number = 7;


        string dict = Client.GetData<dynamic>("animation_shortcut_dict_" + number);
        string state = Client.GetData<dynamic>("animation_shortcut_state_" + number);
        int flag = Client.GetData<dynamic>("animation_shortcut_flag_" + number);

        if (dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(Client, dict, state, flag);
    }


    [RemoteEvent("keypress:8")]
    public static void KeyPress8(Player Client)
    {

        int number = 8;


        string dict = Client.GetData<dynamic>("animation_shortcut_dict_" + number);
        string state = Client.GetData<dynamic>("animation_shortcut_state_" + number);
        int flag = Client.GetData<dynamic>("animation_shortcut_flag_" + number);

        if (dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(Client, dict, state, flag);
    }


    [RemoteEvent("keypress:9")]
    public static void KeyPress9(Player Client)
    {
        int number = 9;


        string dict = Client.GetData<dynamic>("animation_shortcut_dict_" + number);
        string state = Client.GetData<dynamic>("animation_shortcut_state_" + number);
        int flag = Client.GetData<dynamic>("animation_shortcut_flag_" + number);

        if (dict == "")
        {
            return;
        }

        OnPlayAnimationFromMenu(Client, dict, state, flag);
    }



    public static void AddVariable(Player Client, string dict, string state, int flag)
    {
        Client.SetData<dynamic>("animation_dict", dict);
        Client.SetData<dynamic>("animation_state", state);
        Client.SetData<dynamic>("animation_flag", flag);
        // Main.SendCustomChatMessasge(Client,""+dict+" -- "+state+" -- "+flag+"");
        //Client.PlayAnimation(dict, state, flag);
    }



    [Command("anim")]
    public void helpAnimmation(Player Client)
    {
        Main.SendCustomChatMessasge(Client,"~g~[Animation]:~w~ /surrender - /facepalm - /loco - /drink - /eat - /kiss - /dj - /crouch ");
        Main.SendCustomChatMessasge(Client,"~g~[Animation]:~w~ /stumble - /injured - /rock - /handsheat - /pensive - /desperate - /shrug ");
        Main.SendCustomChatMessasge(Client,"~g~[Animation]:~w~ /piss - /dance - /cheer - /lean - /phone - /idle - /dead - /guard - /sports ");
        Main.SendCustomChatMessasge(Client,"~g~[Animation]:~w~ /smoke - /knuckles - /walk - /victory - /arms - /liedown - /thump - /kneel");
        Main.SendCustomChatMessasge(Client,"~g~[Animation]:~w~ /sit - /sexydance - /carsex - /cpr - /plant - /puke - /drunk - /aplause");
        Main.SendCustomChatMessasge(Client,"~g~[Animation]:~w~ /fucku - /odlute - /aim  - /striptease - /tagging - /knockdoor - /type - /feakout");
        Main.SendCustomChatMessasge(Client,"~g~[Animation]:~w~ /hurryup - /shower - /clean - /cry - /dig - /mechanic - /speak - /grab");
    }


    [Command("grab")]
    public void GrabCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "anim@heists@money_grab@duffel", "loop");
        }
    }

    [Command("facepalm")]
    public void FacepalmCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 0, "anim@mp_player_intcelebrationmale@face_palm", "face_palm");
        }
    }

    [Command("loco")]
    public void LocoCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 0, "anim@mp_player_intcelebrationmale@you_loco", "you_loco");
        }
    }

    [Command("freakout")]
    public void FreakoutCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 0, "anim@mp_player_intcelebrationmale@freakout", "freakout");
        }
    }

    [Command("thumb")]
    public void ThumbOnEarsCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 0, "anim@mp_player_intcelebrationmale@thumb_on_ears", "thumb_on_ears");
        }
    }

    [Command("victory")]
    public void VictoryCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 0, "anim@mp_player_intcelebrationmale@v_sign", "v_sign");
        }
    }

    [Command("crouch")]
    public void CrouchCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "misscarstealfinalecar_5_ig_3", "crouchloop");
        }
    }

    [Command("dj")]
    public void DjCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 0, "anim@mp_player_intupperdj", "enter");
        }
    }

    [Command("kneel")]
    public void KneelCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@medic@standing@kneel@base", "base");
        }
    }

    [Command("speak")]
    public void SpeakCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@code_human_police_crowd_control@idle_a", "idle_b");
        }
    }

    [Command("mechanic", "Koriscenje: /mechanic [1-3]")]
    public void MechanicCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_vehicle_mechanic@male@idle_a", "idle_a");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@repair", "fixing_a_ped");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missheistdockssetup1ig_10@laugh", "laugh_pipe_worker1");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje:~w~ /mechanic [1-3]");
                    break;
            }
        }
    }

    [Command("dig")]
    public void DigCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missmic1leadinoutmic_1_mcs_2", "_leadin_trevor");
        }
    }

    [Command("cry")]
    public void CryCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mp_bank_heist_1", "f_cower_01");
        }
    }

    [Command("clean", "Koriscenje: /clean [1-5]")]
    public void CleanCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "switch@franklin@cleaning_car", "001946_01_gc_fras_v2_ig_5_base");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "timetable@maid@cleaning_window@base", "base");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missheistdocks2bleadinoutlsdh_2b_int", "leg_massage_b_floyd");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missfbi_s4mop", "idle_scrub");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_bum_wash@male@low@idle_a", "idle_c");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/clean [1-5]");
                    break;
            }
        }
    }

    [Command("shower", "Koriscenje: /shower [1-2]")]
    public void ShowerCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "anim@mp_yacht@shower@male@", "male_shower_idle_d");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "anim@mp_yacht@shower@female@", "shower_idle_a");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/shower [1-2]");
                    break;
            }
        }
    }

    [Command("hurryup")]
    public void HurryUpCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missfam4", "say_hurry_up_a_trevor");
        }
    }

    [Command("sports", "Koriscenje: /sports [1-15]")]
    public void SportsCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "rcmcollect_paperleadinout@", "meditiate_idle");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "timetable@reunited@ig_2", "jimmy_masterbation");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "timetable@reunited@ig_2", "jimmy_base");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@jog@", "run");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@jogger", "jogging");
                    break;
                case 6:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "amb@world_human_jog@female@base", "base");
                    break;
                case 7:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@triathlon", "idle_a");
                    break;
                case 8:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@triathlon", "idle_d");
                    break;
                case 9:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@triathlon", "idle_e");
                    break;
                case 10:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@triathlon", "idle_f");
                    break;
                case 11:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_yoga@female@base", "base_a");
                    break;
                case 12:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_yoga@female@base", "base_c");
                    break;
                case 13:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_yoga@male@base", "base_b");
                    break;
                case 14:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_push_ups@male@idle_a", "idle_d");
                    break;
                case 15:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_sit_ups@male@base", "base");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/sports [1-15]");
                    break;
            }
        }
    }

    [Command("type")]
    public void TypeCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.TriggerEvent("freezeEx", true);
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 39, "mp_fbi_heist", "loop");
        }
    }

    [Command("knockdoor")]
    public void KnockDoorCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.TriggerEvent("freezeEx", true);
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 39, "timetable@jimmy@doorknock@", "knockdoor_idle");
        }
    }

    [Command("tagging")]
    public void TaggingCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "switch@franklin@lamar_tagging_wall", "lamar_tagging_exit_loop_lamar");
        }
    }

    [Command("striptease", "Koriscenje: /striptease [1-14]")]
    public void StripteaseCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.StopOnLastFrame), "mini@strip_club@pole_dance@pole_a_2_stage", "pole_a_2_stage");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.StopOnLastFrame), "mini@strip_club@pole_dance@pole_b_2_stage", "pole_b_2_stage");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.StopOnLastFrame), "mini@strip_club@pole_dance@pole_c_2_prvd_a", "pole_c_2_prvd_a");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.StopOnLastFrame), "mini@strip_club@pole_dance@pole_c_2_prvd_b", "pole_c_2_prvd_b");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@hookers_spcrackhead", "idle_b");
                    break;
                case 6:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.StopOnLastFrame), "mini@strip_club@pole_dance@pole_c_2_prvd_c", "pole_c_2_prvd_c");
                    break;
                case 7:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@strip_club@pole_dance@pole_dance1", "pd_dance_01");
                    break;
                case 8:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@strip_club@pole_dance@pole_dance2", "pd_dance_02");
                    break;
                case 9:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@strip_club@pole_dance@pole_dance3", "pd_dance_03");
                    break;
                case 10:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@strip_club@pole_dance@pole_enter", "pd_enter");
                    break;
                case 11:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@strip_club@pole_dance@pole_exit", "pd_exit");
                    break;
                case 12:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@strip_club@private_dance@exit", "priv_dance_exit");
                    break;
                case 13:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@strip_club@private_dance@idle", "priv_dance_idle");
                    break;
                case 14:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mp_am_stripper", "lap_dance_girl");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/striptease [1-14]");
                    break;
            }
        }
    }

    [Command("drink")]
    public void DrinkCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "amb@world_human_drinking_fat@beer@male@idle_a", "idle_a");
        }
    }

    [Command("kiss")]
    public void KissCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 0, "mini@hookers_sp", "idle_a");
        }
    }

    [Command("aim")]
    public void AimCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "combat@chg_stance", "aima_loop");
        }
    }

    [Command("salute", "Koriscenje: /salute [1-6]")]
    public void SaluteCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.TriggerEvent("freezeEx", true);
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "mp_player_int_uppersalute", "mp_player_int_salute");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "mp_ped_interaction", "hugs_guy_a");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "mp_player_intsalute", "mp_player_int_salute");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "missmic4premiere", "crowd_a_idle_01");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "missexile2", "franklinwavetohelicopter");
                    break;
                case 6:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "anim@mp_player_intcelebrationmale@wave", "wave");
                    break;
                default:
                    Client.StopAnimation();
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/salute [1-6]");
                    break;
            }
        }
    }

    [Command("fucku")]
    public void FuckUCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "anim@mp_player_intselfiethe_bird", "idle_a");
        }
    }

    [Command("walk", "Koriscenje: /walk [1-21]")]
    public void WalkCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@heels@c", "walk");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@arrogant@a", "walk");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@sad@a", "walk");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@drunk@moderatedrunk", "walk");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@shadyped@a", "walk");
                    break;
                case 6:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@gangster@ng", "walk");
                    break;
                case 7:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@generic", "walk");
                    break;
                case 8:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@heels@d", "walk");
                    break;
                case 9:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_f@posh@", "walk");
                    break;
                case 10:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@brave@b", "walk");
                    break;
                case 11:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@confident", "walk");
                    break;
                case 12:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@depressed@d", "walk");
                    break;
                case 13:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@favor_right_foot", "walk");
                    break;
                case 14:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@generic", "walk");
                    break;
                case 15:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@generic_variations@walk", "walk_a");
                    break;
                case 16:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@generic_variations@walk", "walk_f");
                    break;
                case 17:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@golfer@", "golf_walk");
                    break;
                case 18:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@money", "walk");
                    break;
                case 19:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@shadyped@a", "walk");
                    break;
                case 20:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "move_m@swagger@b", "walk");
                    break;
                case 21:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "switch@franklin@dispensary", "exit_dispensary_outro_ped_f_a");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/walk [1-21]");
                    break;
            }
        }
    }

    [Command("knuckles")]
    public void KnucklesCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "anim@mp_player_intupperknuckle_crunch", "idle_a");
        }
    }

    [Command("surrender", "Koriscenje: /surrender [1-11]")]
    public static void SurrenderCommands(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            if (action >= 1 && action <= 11)
            {
                Client.SetData<dynamic>("handsup", true);
            }
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mp_am_hold_up", "handsup_base");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "anim@mp_player_intuppersurrender", "idle_a_fp");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "amb@code_human_cower@female@react_cowering", "base_back_left");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "amb@code_human_cower@female@react_cowering", "base_right");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "missfbi5ig_0", "lyinginpain_loop_steve");
                    break;
                case 6:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "missfbi5ig_10", "lift_holdup_loop_labped");
                    break;
                case 7:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "missfbi5ig_17", "walk_in_aim_loop_scientista");
                    break;
                case 8:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "mp_am_hold_up", "cower_loop");
                    break;
                case 9:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "mp_arrest_paired", "crook_p1_idle");
                    break;
                case 10:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "mp_bank_heist_1", "m_cower_02");
                    break;
                case 11:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "misstrevor1", "threaten_ortega_endloop_ort");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/surrender [1-11]");
                    break;
            }
        }
    }

    [Command("eat")]
    public void EatCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mp_player_inteat@burger", "mp_player_int_eat_burger");
        }
    }

    [Command("puke")]
    public void PukeCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 0, "missheistpaletoscore1leadinout", "trv_puking_leadout");
        }
    }

    [Command("plant")]
    public void PlantCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 0, "amb@world_human_gardener_plant@male@idle_a", "idle_a");
        }
    }

    [Command("animcpr", "Koriscenje: /cpr [1-4]")]
    public void CprCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.StopOnLastFrame | AnimationFlags.AllowPlayerControl), "mini@cpr@char_a@cpr_def", "cpr_intro");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "mini@cpr@char_a@cpr_str", "cpr_kol");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl), "mini@cpr@char_a@cpr_def", "cpr_pumpchest_idle");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 0, "mini@cpr@char_a@cpr_str", "cpr_success");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/cpr [1-4]");
                    break;
            }
        }
    }

    [Command("carsex", "Koriscenje: /carsex [1-6]")]
    public void CarSexCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else if (NAPI.Player.IsPlayerInAnyVehicle(Client) == false)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, "Niste u vozilu.");
        }
        else
        {

            switch (action)
            {
                case 1:
                    if (NAPI.Player.GetPlayerVehicleSeat(Client) != (int)VehicleSeat.Driver)
                    {
                        Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, "Niste u vozilu.");
                    }
                    else
                    {
                        Client.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@prostitutes@sexnorm_veh", "bj_loop_male");
                    }
                    break;
                case 2:
                    if (NAPI.Player.GetPlayerVehicleSeat(Client) != (int)VehicleSeat.Driver)
                    {
                        Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, "Niste u vozilu.");
                    }
                    else
                    {
                        Client.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@prostitutes@sexnorm_veh", "sex_loop_male");
                    }
                    break;
                case 3:
                    if (NAPI.Player.GetPlayerVehicleSeat(Client) != (int)VehicleSeat.RightFront)
                    {
                        Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, "Morate biti na prednjem suvozackom mestu.");
                    }
                    else
                    {
                        Client.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@prostitutes@sexnorm_veh", "sex_loop_prostitute");
                    }
                    break;
                case 4:
                    if (NAPI.Player.GetPlayerVehicleSeat(Client) != (int)VehicleSeat.Driver)
                    {
                        Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, "Niste u vozilu.");
                    }
                    else
                    {
                        Client.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@prostitutes@sexlow_veh", "low_car_bj_loop_player");
                    }
                    break;
                case 5:
                    if (NAPI.Player.GetPlayerVehicleSeat(Client) != (int)VehicleSeat.RightFront)
                    {
                        Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, "Morate biti na prednjem suvozackom mestu.");
                    }
                    else
                    {
                        Client.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@prostitutes@sexlow_veh", "low_car_bj_loop_female");
                    }
                    break;
                case 6:
                    if (NAPI.Player.GetPlayerVehicleSeat(Client) != (int)VehicleSeat.RightFront)
                    {
                        Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, "Morate biti na prednjem suvozackom mestu.");
                    }
                    else
                    {
                        Client.StopAnimation();
                        NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@prostitutes@sexlow_veh", "low_car_sex_loop_female");
                    }
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/carsex [1-6]");
                    break;
            }
        }
    }

    [Command("sexydance", "Koriscenje: /sexydance [1-6]")]
    public void SexyDanceCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_prostitute@cokehead@idle_a", "idle_b");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 0, "mini@hookers_sp", "ilde_c");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 0, "mini@hookers_spcokehead", "idle_a");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 0, "mini@hookers_spcokehead", "idle_c");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@hookers_spcrackhead", "idle_b");
                    break;
                case 6:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 0, "mini@hookers_spvanilla", "idle_b");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/sexydance [1-6]");
                    break;
            }
        }
    }

    [Command("sit", "Koriscenje: /sit [1-11]")]
    public void SitCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.TriggerEvent("freezeEx", true);
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "amb@world_human_stupor@male@base", "base");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "amb@world_human_stupor@male_looking_left@base", "base");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "anim@heists@fleeca_bank@ig_7_jetski_owner", "owner_idle");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "mp_army_contact", "positive_a");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "timetable@reunited@ig_10", "base_amanda");
                    break;
                case 6:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "anim@heists@prison_heistunfinished_biztarget_idle", "target_idle");
                    break;
                case 7:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "switch@michael@sitting", "idle");
                    break;
                case 8:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "timetable@michael@on_sofaidle_c", "sit_sofa_g");
                    break;
                case 9:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "timetable@michael@on_sofaidle_b", "sit_sofa_d");
                    break;
                case 10:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "timetable@michael@on_sofaidle_a", "sit_sofa_a");
                    break;
                case 11:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 39, "rcm_barry3", "barry_3_sit_loop");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/sit [1-11]");
                    break;
            }
        }
    }

    [Command("smoke", "Koriscenje: /smoke [1-3]")]
    public void SmokeCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.TriggerEvent("freezeEx", true);
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 33, "amb@world_human_smoking@male@male_a@idle_a", "idle_c");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 33, "amb@world_human_smoking@female@idle_a", "idle_b");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, 33, "mini@hookers_spfrench", "idle_wait");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/smoke [1-3]");
                    break;
            }
        }
    }

    [Command("liedown", "Koriscenje: /liedown [1-6]")]
    public void LieDownCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_sunbathe@male@back@idle_a", "idle_a");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_sunbathe@female@back@idle_a", "idle_a");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_sunbathe@female@front@base", "base");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_picnic@male@base", "base");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_picnic@female@base", "base");
                    break;
                case 6:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missfra0_chop_fchase", "ballasog_rollthroughtraincar_ig6_loop");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/liedown [1-6]");
                    break;
            }
        }
    }

    [Command("arms", "Koriscenje: /arms [1-4]")]
    public void ArmsCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_hang_out_street@male_c@base", "base");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_hang_out_street@female_arms_crossed@idle_a", "idle_a");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mini@hookers_sp", "idle_reject_loop_c");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mini@hookers_sp", "idle_reject");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/arms [1-4]");
                    break;
            }
        }
    }

    [Command("guard", "Koriscenje: /guard [1-4]")]
    public void GuardCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missbigscore1", "idle_a");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missbigscore1", "idle_base");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missbigscore1", "idle_c");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missbigscore1", "idle_e");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/guard [1-4]");
                    break;
            }
        }
    }

    [Command("dead", "Koriscenje: /dead [1-5]")]
    public void DeadCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missarmenian2", "corpse_search_exit_ped");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missarmenian2", "drunk_loop");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missfinale_c1@", "lying_dead_player0");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mp_bank_heist_1", "prone_l_loop");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missfra2", "lamar_base_idle");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/dead [1-5]");
                    break;
            }
        }
    }

    [Command("idle", "Koriscenje: /idle [1-9]")]
    public void IdleCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.OnlyAnimateUpperBody | AnimationFlags.AllowPlayerControl), "amb@world_human_hang_out_street@female_hold_arm@base", "base");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "mini@hookers_sp", "idle_wait");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_stand_impatient@female@no_sign@base", "base");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "mini@hookers_spfrench", "idle_wait");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_hang_out_street@female_arm_side@idle_a", "idle_a");
                    break;
                case 6:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_muscle_flex@arms_in_front@idle_a", "idle_b");
                    break;
                case 7:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missfbi5leadinout", "leadin_2_fra");
                    break;
                case 8:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_cop_idles@female@idle_a", "idle_d");
                    break;
                case 9:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_cop_idles@male@idle_b", "idle_a");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/idle [1-9]");
                    break;
            }
        }
    }

    [Command("phone", "Koriscenje: /phone [1-5]")]
    public void PhoneCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "amb@world_human_stand_mobile@male@text@base", "base");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "cellphone@", "cellphone_email_read_base");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "cellphone@", "cellphone_photo_idle");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.OnlyAnimateUpperBody | AnimationFlags.AllowPlayerControl), "amb@world_human_stand_mobile@female@standing@call@idle_a", "idle_a");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_mobile_film_shocking@female@idle_a", "idle_a");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/carsex [1-5]");
                    break;
            }
        }
    }

    [Command("lean", "Koriscenje: /lean [1-11]")]
    public void LeanCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@prop_human_bum_shopping_cart@male@idle_a", "idle_a");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "anim@mp_ferris_wheel", "idle_a_player_one");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@prop_human_bum_shopping_cart@male@base", "base");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_leaning@male@wall@back@legs_crossed@idle_b", "idle_d");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_leaning@male@wall@back@hands_together@idle_a", "idle_c");
                    break;
                case 6:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_leaning@male@wall@back@mobile@base", "base");
                    break;
                case 7:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_leaning@male@wall@back@texting@base", "base");
                    break;
                case 8:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_leaning@female@wall@back@mobile@base", "base");
                    break;
                case 9:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_leaning@female@wall@back@texting@base", "base");
                    break;
                case 10:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_leaning@female@smoke@idle_a", "idle_a");
                    break;
                case 11:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_leaning@male@wall@back@foot_up@idle_b", "idle_d");
                    break;
                case 12:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "misscarsteal1car_1_ext_leadin", "base_driver1");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/lean [1-11]");
                    break;
            }
        }
    }

    [Command("cheer", "Koriscenje: /cheer [1-7]")]
    public void CheerCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_cheering@female_a", "base");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_cheering@female_c", "base");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_cheering@female_d", "base");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_cheering@male_a", "base");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_cheering@male_b", "base");
                    break;
                case 6:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_cheering@male_d", "base");
                    break;
                case 7:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_cheering@male_e", "base");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/cheer [1-7]");
                    break;
            }
        }
    }

    [Command("dance", "Koriscenje: /dance [1-6]")]
    public void DanceCommand(Player Client, int action)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            switch (action)
            {
                case 1:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_jog_standing@female@base", "base");
                    break;
                case 2:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_jog_standing@female@idle_a", "idle_a");
                    break;
                case 3:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_power_walker@female@static", "static");
                    break;
                case 4:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_partying@female@partying_beer@base", "base");
                    break;
                case 5:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_partying@female@partying_cellphone@idle_a", "idle_a");
                    break;
                case 6:
                    Client.StopAnimation();
                    NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_partying@female@partying_beer@idle_a", "idle_a");
                    break;
                default:
                    Main.SendCustomChatMessasge(Client, "~y~Koriscenje: ~w~/dance [1-6]");
                    break;
            }
        }
    }

    [Command("piss")]
    public void PissCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "missbigscore1switch_trevor_piss", "piss_loop");
        }
    }

    [Command("aplause")]
    public void AplauseCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_strip_watch_stand@male_a@idle_a", "idle_a");
        }
    }

    [Command("drunk")]
    public void DrunkCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 0, "mini@hookers_spcrackhead", "idle_c");
        }
    }

    [Command("shrug")]
    public void ShrugCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "gestures@f@standing@casual", "gesture_shrug_hard");
        }
    }

    [Command("desperate")]
    public void DesperateCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "misscarsteal4@toilet", "desperate_toilet_idle_a");
        }
    }

    [Command("pensive")]
    public void PensiveCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop | AnimationFlags.OnlyAnimateUpperBody | AnimationFlags.AllowPlayerControl), "misscarsteal4@aliens", "rehearsal_base_idle_director");
        }
    }

    [Command("handsheat")]
    public void HandsHeatCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.Loop), "amb@world_human_stand_fire@male@base", "base");
        }
    }

    [Command("rock")]
    public void RockCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.AllowPlayerControl | AnimationFlags.OnlyAnimateUpperBody), "anim@mp_player_intincarrockbodhi@ps@", "enter");
        }
    }

    [Command("injured")]
    public void InjuredCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, (int)(AnimationFlags.StopOnLastFrame | AnimationFlags.AllowPlayerControl), "combat@damage@injured_pistol@to_writhe", "variation_b");
        }
    }

    [Command("stumble")]
    public void StumbleCommand(Player Client)
    {
        if ((int)NAPI.Data.GetEntitySharedData(Client, "Injured") != 0 || Client.GetData<dynamic>("handsup") == true || Client.GetData<dynamic>("playerCuffed") != 0 || Client.GetData<dynamic>("BeingDragged") == true)
        {
            Main.DisplayErrorMessage(Client,NotifyType.Error,NotifyPosition.BottomCenter, Translation.message_17);
        }
        else
        {
            Client.StopAnimation();
            NAPI.Player.PlayPlayerAnimation(Client, 0, "misscarsteal4@actor", "stumble");
        }
    }


    [RemoteEvent("aSelected")]
    public void AnimationSelected(Player Client, int category, int animation)
    {
        try
        {
            if (Client.GetSharedData<dynamic>("Injured") >= 1)
            {
                return;
            }
            if (Client.HasData("ForceAnim") && Client.GetData<dynamic>("ForceAnim"))
            {
                return;
            }
            if (Client.HasData("FOLLOWING") || Client.IsInVehicle
                || Client.GetData<dynamic>("character_prison_time") > 0) return;
            if (category == -1)
            {
                Client.SetData<dynamic>("HANDS_UP",false);
                Client.StopAnimation();
                Client.TriggerEvent("freezeEx", false);
                if (Client.HasData("LastAnimFlag") && Client.GetData<dynamic>("LastAnimFlag") == 39)
                    NAPI.Entity.SetEntityPosition(Client, Client.Position + new Vector3(0, 0, 0.2));
                return;
            }
            Client.TriggerEvent("freezeEx", true);
            if (animation >= AnimList[category].Count) return;
            Client.PlayAnimation(AnimList[category][animation].Dictionary, AnimList[category][animation].Name, AnimList[category][animation].Flag);
            if (category == 0 && animation == 0) NAPI.Entity.SetEntityPosition(Client, Client.Position - new Vector3(0, 0, 0.3));

            if (AnimList[category][animation].Dictionary == "random@arrests@busted" && AnimList[category][animation].Name == "idle_c") Client.SetData<dynamic>("HANDS_UP", true);

            Client.SetData<dynamic>("LastAnimFlag", AnimList[category][animation].Flag);
            if (AnimList[category][animation].StopDelay != -1)
            {
                NAPI.Task.Run(() =>
                {
                    try
                    {
                        if (Client != null)
                        {
                            Client.StopAnimation();
                            Client.TriggerEvent("freezeEx", false);
                        }
                    }
                    catch { }
                }, AnimList[category][animation].StopDelay);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);


        }
    }

    public static List<List<Animation>> AnimList = new List<List<Animation>>()
        {
            new List<Animation>()
            {
                new Animation("amb@world_human_picnic@female@base", "base", 39),
                new Animation("amb@medic@standing@tendtodead@base", "base", 39),
                new Animation("amb@world_human_stupor@male@base", "base", 39),
                new Animation("amb@world_human_sunbathe@male@back@base", "base", 39),
                new Animation("missfinale_c1@", "lying_dead_player0", 39),
                new Animation("amb@medic@standing@kneel@base", "base", 39),
                new Animation("mp_safehouse", "lap_dance_player", 39),
                new Animation("misstrevor2", "gang_chatting_idle02_a", 39),
            },
            new List<Animation>()
            {
                new Animation("random@arrests@busted", "idle_c", 49),
                new Animation("amb@medic@standing@timeofdeath@idle_a", "idle_a", 49),
                new Animation("anim@mp_player_intselfiethumbs_up", "idle_a", 49),
                new Animation("anim@mp_player_intuppersalute", "idle_a", 49),

                new Animation("anim@mp_player_intupperyou_loco", "idle_a", 49),
                new Animation("anim@mp_player_intupperwave", "idle_a", 49),
                new Animation("anim@mp_player_intupperv_sign", "idle_a", 49),

            },
            new List<Animation>()
            {
                new Animation("amb@world_human_yoga@female@base", "base_a", 39),
                new Animation("amb@world_human_yoga@male@base", "base_b", 39),
                new Animation("amb@world_human_sit_ups@male@base", "base", 39),
                new Animation("amb@world_human_push_ups@male@base", "base", 39),
                new Animation("rcmcollect_paperleadinout@", "meditiate_idle", 39),
            },
            new List<Animation>()
            {
                new Animation("anim@mp_player_intselfiethe_bird", "idle_a", 49),
                new Animation("anim@mp_player_intincardockstd@ps@", "idle_a", 49),
                new Animation("anim@mp_player_intuppernose_pick", "idle_a", 49),
                new Animation("anim@mp_player_intupperfinger", "idle_a", 49),
                new Animation("mp_player_intfinger", "mp_player_int_finger", 39),
            },
            new List<Animation>()
            {
                new Animation("amb@world_human_cop_idles@male@base", "base", 39),
                new Animation("anim@mp_player_intupperknuckle_crunch", "idle_a", 49),
                new Animation("anim@amb@nightclub@peds@", "rcmme_amanda1_stand_loop_cop", 39),
                new Animation("anim@amb@nightclub@peds@", "mini_strip_club_idles_bouncer_go_away_go_away", 39),
                new Animation("anim@amb@nightclub@peds@", "mini_strip_club_idles_bouncer_stop_stop", 39),
                new Animation("anim@amb@nightclub@peds@", "amb_world_human_muscle_flex_arms_in_front_base", 39),
                new Animation("amb@world_human_muscle_flex@arms_at_side@base", "base", 39),
            },
            new List<Animation>()
            {
                new Animation("amb@world_human_partying@female@partying_beer@base", "base", 39),
                new Animation("amb@world_human_strip_watch_stand@male_a@idle_a", "idle_c", 39),
                new Animation("mini@strip_club@idles@dj@idle_04", "idle_04", 39),
                new Animation("mini@strip_club@lap_dance@ld_girl_a_song_a_p1", "ld_girl_a_song_a_p1_f", 39),
                new Animation("special_ped@mountain_dancer@monologue_3@monologue_3a", "mnt_dnc_buttwag", 39),
                new Animation("mini@strip_club@private_dance@part1", "priv_dance_p1", 39),
                new Animation("anim@amb@nightclub@dancers@crowddance_facedj@", "hi_dance_facedj_09_v2_female^1", 39),
            },
            new List<Animation>() 
            {
                null,
            },
            new List<Animation>()
            {
                new Animation("anim@amb@nightclub@dancers@crowddance_facedj@", "hi_dance_facedj_09_v2_female^3", 39),
                new Animation("anim@amb@nightclub@dancers@crowddance_facedj@", "hi_dance_facedj_09_v2_male^2", 39),
                new Animation("anim@amb@nightclub@dancers@crowddance_facedj@", "hi_dance_facedj_09_v2_male^4", 39),
                new Animation("anim@amb@nightclub@dancers@crowddance_groups@", "hi_dance_crowd_09_v1_female^1", 39),
                new Animation("anim@amb@nightclub@dancers@crowddance_groups@", "hi_dance_crowd_09_v2_female^1", 39),
                new Animation("anim@amb@nightclub@dancers@crowddance_groups@", "hi_dance_crowd_09_v2_female^3", 39),
                new Animation("anim@amb@nightclub@dancers@crowddance_groups@", "hi_dance_crowd_11_v1_female^1", 39),
            },
            new List<Animation>()
            {
                new Animation("anim@amb@nightclub@dancers@crowddance_groups@", "hi_dance_crowd_13_v2_female^1", 39),
                new Animation("anim@amb@nightclub@lazlow@hi_podium@", "danceidle_mi_17_crotchgrab_laz", 39),
                new Animation("anim@amb@nightclub@lazlow@hi_podium@", "danceidle_mi_17_teapotthrust_laz", 39),
                new Animation("anim@amb@nightclub@lazlow@hi_railing@", "ambclub_09_mi_hi_bellydancer_laz", 39),
                new Animation("anim@amb@nightclub@lazlow@hi_railing@", "ambclub_10_mi_hi_crotchhold_laz", 39),
                new Animation("anim@amb@nightclub@lazlow@hi_railing@", "ambclub_12_mi_hi_bootyshake_laz", 39),
                new Animation("anim@amb@nightclub@lazlow@hi_railing@", "ambclub_13_mi_hi_sexualgriding_laz", 39),
            },
            new List<Animation>()
            {
                new Animation("anim@amb@nightclub@mini@dance@dance_solo@female@var_a@", "med_center", 39),
                new Animation("anim@amb@nightclub@mini@dance@dance_solo@male@var_b@", "med_center", 39),
            },
            new List<Animation>()
            {
                new Animation("anim@mp_player_intupperthumbs_up", "idle_a", 49),
                new Animation("anim@mp_player_intupperthumb_on_ears", "idle_a", 49),
                new Animation("anim@mp_player_intuppersurrender", "idle_a", 49),
                new Animation("anim@mp_player_intupperslow_clap", "idle_a", 49),
                new Animation("anim@mp_player_intupperpeace", "idle_a", 49),
                new Animation("anim@mp_player_intupperno_way", "idle_a", 49),
                new Animation("anim@mp_player_intupperjazz_hands", "idle_a", 49),
            },
            new List<Animation>()
            {
                new Animation("anim@mp_player_intupperfind_the_fish", "idle_a", 49),
                new Animation("anim@mp_player_intupperface_palm", "idle_a", 49),
                new Animation("anim@mp_player_intupperchicken_taunt", "idle_a", 49),
                new Animation("anim@mp_player_intselfiedock", "idle_a", 49),
                new Animation("friends@frf@ig_1", "over_here_idle_b", 49),
                new Animation("mp_player_int_upperrock", "mp_player_int_rock", 49),
                new Animation("mp_player_int_upperpeace_sign", "mp_player_int_peace_sign", 49),
            },
            new List<Animation>() 
            {
                null,
            },
            new List<Animation>()
            {
                new Animation("amb@world_human_muscle_flex@arms_at_side@idle_a", "idle_a", 39),
                new Animation("amb@world_human_muscle_flex@arms_at_side@idle_a", "idle_c", 39),
                new Animation("amb@world_human_muscle_flex@arms_in_front@idle_a", "idle_a", 39),
                new Animation("amb@world_human_muscle_flex@arms_in_front@idle_a", "idle_b", 39),
            },
        };

    internal class Animation
    {
        public string Dictionary { get; }
        public string Name { get; }
        public int Flag { get; }
        public int StopDelay { get; }

        public Animation(string dict, string name, int flag, int stopDelay = -1)
        {
            Dictionary = dict;
            Name = name;
            Flag = flag;
            StopDelay = stopDelay;
        }
    }


}

