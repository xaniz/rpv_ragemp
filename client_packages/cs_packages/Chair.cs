



using System;
using System.Collections.Generic;
using RAGE;
using RAGE.Elements;

class Chair : Events.Script
{
    public static List<dynamic> chairs = new List<dynamic>();


    public static bool sitting = false;
    public Chair()
    {
        Timer = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        sitting = false;

        //-- BENCH
        chairs.Add(new { prop = "prop_bench_01a", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_01b", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_01c", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_02", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_03", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_04", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_05", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_06", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_05", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_08", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_09", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_10", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.2f, leftOffset = 0.2f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_11", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_bench_07", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.37f, forwardOffset = -0.1f, leftOffset = 0.2f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_fib_3b_bench", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_ld_bench01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });
        chairs.Add(new { prop = "prop_wait_bench_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = -0.1f, leftOffset = 0.0f, angularOffset = 180.0f });

        //-- CHAIR
        chairs.Add(new { prop = "hei_prop_heist_off_chair", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "hei_prop_hei_skid_chair", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chair_01a", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chair_01b", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chair_02", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chair_03", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chair_04a", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chair_04b", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chair_05", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chair_06", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chair_05", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chair_08", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chair_09", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chair_10", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_chateau_chair_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_clown_chair", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_cs_office_chair", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_direct_chair_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_direct_chair_02", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_gc_chair02", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.35f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_off_chair_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_off_chair_03", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_off_chair_04", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_off_chair_04b", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_off_chair_04_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_off_chair_05", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_old_deck_chair", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_old_wood_chair", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_rock_chair_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_skid_chair_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.3f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_skid_chair_02", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.3f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_skid_chair_03", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.3f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_sol_chair", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_wheelchair_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_wheelchair_01_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "p_armchair_01_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "p_clb_officechair_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "p_dinechair_01_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "p_ilev_p_easychair_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "p_soloffchair_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "p_yacht_chair_01_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_club_officechair", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_corp_bk_chair3", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_corp_cd_chair", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_corp_offchair", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_ilev_chair02_ped", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_ilev_hd_chair", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_ilev_p_easychair", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_ret_gc_chair03", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_ld_farm_chair01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_table_04_chr", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_table_05_chr", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_table_06_chr", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_ilev_leath_chr", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_table_01_chr_a", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.9f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_table_01_chr_b", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.9f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -0.0f });
        chairs.Add(new { prop = "prop_table_02_chr", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_table_03b_chr", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_table_03_chr", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_torture_ch_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_ilev_fh_dineeamesa", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });


        chairs.Add(new { prop = "v_ilev_fh_kitchenstool", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_ilev_tort_stool", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_ilev_fh_kitchenstool", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_ilev_fh_kitchenstool", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_ilev_fh_kitchenstool", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_ilev_fh_kitchenstool", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });

        //-- SEAT
        chairs.Add(new { prop = "hei_prop_yah_seat_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "hei_prop_yah_seat_02", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "hei_prop_yah_seat_03", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_waiting_seat_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_yacht_seat_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_yacht_seat_02", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_yacht_seat_03", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_hobo_seat_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.65f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });

        //-- COUCH
        chairs.Add(new { prop = "prop_rub_couch01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.4f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "miss_rub_couch_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_ld_farm_couch01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_ld_farm_couch02", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_rub_couch02", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = -0.3f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_rub_couch03", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_rub_couch04", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });

        //-- SOFA
        chairs.Add(new { prop = "p_lev_sofa_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "p_res_sofa_l_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "p_v_med_p_sofa_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "p_yacht_sofa_01_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_ilev_m_sofa", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_res_tre_sofa_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_tre_sofa_mess_a_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_tre_sofa_mess_b_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "v_tre_sofa_mess_c_s", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });

        //-- MISC
        chairs.Add(new { prop = "prop_roller_car_01", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });
        chairs.Add(new { prop = "prop_roller_car_02", scenario = "PROP_HUMAN_SEAT_BENCH", verticalOffset = -0.5f, forwardOffset = 0.0f, leftOffset = 0.0f, angularOffset = -90.0f });


        RAGE.Events.Tick += Tick;
       // RAGE.Events.OnPlayerReady += readyplayer;
    }
    long Timer =20;


    public void SitOnChair()
    {
        foreach (var chair in chairs)
        {

            int obj = RAGE.Game.Object.GetClosestObjectOfType(Player.LocalPlayer.Position.X, Player.LocalPlayer.Position.Y, Player.LocalPlayer.Position.Z, 2.0f, RAGE.Game.Misc.GetHashKey(chair.prop), false, true, true);
            Vector3 objCoord = RAGE.Game.Entity.GetEntityCoords(obj, false);
            var dist = RAGE.Game.Misc.GetDistanceBetweenCoords(Player.LocalPlayer.Position.X, Player.LocalPlayer.Position.Y, Player.LocalPlayer.Position.Z, objCoord.X, objCoord.Y, objCoord.Z, true);

            if (dist < 1.5f)
            {


                var can_seat = true;
                foreach (var player in Entities.Players.All)
                {
                    var targetDist = RAGE.Game.Misc.GetDistanceBetweenCoords(Player.LocalPlayer.Position.X, Player.LocalPlayer.Position.Y, Player.LocalPlayer.Position.Z, objCoord.X, objCoord.Y, objCoord.Z, true);
                    if (targetDist < 1.0f)
                    {
                        can_seat = false;
                    }
                }


                if (sitting == false)
                {

                    if (can_seat == false)
                    {
                        //   Notify("You cannot sit on someone else's lap. :P");
                        return;
                    }


                    Display_Subtitle(chair.prop + " Press ~b~E~w~ to sit!", 200);

                    

                        sitting = true;
                        Player.LocalPlayer.Position = new Vector3(objCoord.X, objCoord.Y + chair.forwardOffset, objCoord.Z + chair.verticalOffset);
                        Player.LocalPlayer.SetHeading(RAGE.Game.Entity.GetEntityHeading(obj) + chair.angularOffset);
                        
                        // RAGE.Events.CallRemote("Main:SetSeatVariable", true, Player.LocalPlayer.Position.X, Player.LocalPlayer.Position.Y, Player.LocalPlayer.Position.Z, RAGE.Game.Entity.GetEntityHeading(obj) + 180.0f);
                        RAGE.Game.Ai.TaskStartScenarioAtPosition(Player.LocalPlayer.Handle, Convert.ToString(chair.scenario), Player.LocalPlayer.Position.X, Player.LocalPlayer.Position.Y, Player.LocalPlayer.Position.Z + 0.9f, RAGE.Game.Entity.GetEntityHeading(obj) + 180.0f, 0, true, true);
                    
                }
                else
                {

                    

                        Player.LocalPlayer.ClearTasks();
                        sitting = false;
                        //  RAGE.Events.CallRemote("Main:SetSeatVariable", false, 0f,0f, 0f, 0f);

                }
            }
        }
    }

    public static void Notify(string teste)
    {
        RAGE.Game.Ui.SetNotificationTextEntry("STRING");
        RAGE.Game.Ui.AddTextComponentSubstringPlayerName(teste);
        RAGE.Game.Ui.DrawNotification(false, false);
       
    }

    public void Tick(System.Collections.Generic.List<RAGE.Events.TickNametagData> nametags)
    {

        if (RAGE.Game.Pad.IsControlJustReleased(0, 38) && Player.LocalPlayer.IsSittingInAnyVehicle() == false)
        {
            SitOnChair();
        }
    }

    internal static void Display_Subtitle(string message, int duration = 5000)
    {
        RAGE.Game.Ui.BeginTextCommandPrint("CELL_EMAIL_BCON");
        const int maxStringLength = 99;

        for (int i = 0; i < message.Length; i += maxStringLength)
        {
            RAGE.Game.Ui.AddTextComponentSubstringPlayerName(message.Substring(i, System.Math.Min(maxStringLength, message.Length - i)));
        }
        RAGE.Game.Ui.EndTextCommandPrint(duration, true);
    }
}
