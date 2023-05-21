using GTANetworkAPI;
using System;
using System.Collections.Generic;

class Barber : Script
{


    public static List<string> hair_style_female = new List<string>();
    public static List<string> hair_style_male = new List<string>();
    public static List<string> eye_colors = new List<string>();
    public static List<string> dad = new List<string>();
    public static List<string> mom = new List<string>();
    public static List<string> shape_mix_list = new List<string>();


    public Barber()
    {
        hair_style_male.Add("0");
        hair_style_male.Add("1");
        hair_style_male.Add("2");
        hair_style_male.Add("3");
        hair_style_male.Add("4");
        hair_style_male.Add("5");
        hair_style_male.Add("6");
        hair_style_male.Add("7");
        hair_style_male.Add("8");
        hair_style_male.Add("9");
        hair_style_male.Add("10");
        hair_style_male.Add("11");
        hair_style_male.Add("12");
        hair_style_male.Add("13");
        hair_style_male.Add("14");
        hair_style_male.Add("15");
        hair_style_male.Add("16");
        hair_style_male.Add("17");
        hair_style_male.Add("18");
        hair_style_male.Add("19");
        hair_style_male.Add("20");
        hair_style_male.Add("21");
        hair_style_male.Add("22");
        hair_style_male.Add("24");
        hair_style_male.Add("25");
        hair_style_male.Add("26");
        hair_style_male.Add("27");
        hair_style_male.Add("28");
        hair_style_male.Add("29");
        hair_style_male.Add("30");
        hair_style_male.Add("31");
        hair_style_male.Add("32");
        hair_style_male.Add("33");
        hair_style_male.Add("34");
        hair_style_male.Add("35");
        hair_style_male.Add("36");
        hair_style_male.Add("37");
        hair_style_male.Add("38");
        hair_style_male.Add("39");
        hair_style_male.Add("40");
        hair_style_male.Add("41");
        hair_style_male.Add("42");
        hair_style_male.Add("43");
        hair_style_male.Add("44");
        hair_style_male.Add("45");
        hair_style_male.Add("46");
        hair_style_male.Add("47");
        hair_style_male.Add("48");
        hair_style_male.Add("49");
        hair_style_male.Add("50");
        hair_style_male.Add("51");
        hair_style_male.Add("52");
        hair_style_male.Add("53");
        hair_style_male.Add("54");
        hair_style_male.Add("55");
        hair_style_male.Add("56");
        hair_style_male.Add("57");
        hair_style_male.Add("58");
        hair_style_male.Add("59");
        hair_style_male.Add("60");
        hair_style_male.Add("61");
        hair_style_male.Add("62");
        hair_style_male.Add("63");
        hair_style_male.Add("64");
        hair_style_male.Add("65");
        hair_style_male.Add("66");
        hair_style_male.Add("67");
        hair_style_male.Add("68");
        hair_style_male.Add("69");
        hair_style_male.Add("70");
        hair_style_male.Add("71");
        hair_style_male.Add("72");
        hair_style_male.Add("73");


        hair_style_female.Add("0");
        hair_style_female.Add("1");
        hair_style_female.Add("2");
        hair_style_female.Add("3");
        hair_style_female.Add("4");
        hair_style_female.Add("5");
        hair_style_female.Add("6");
        hair_style_female.Add("7");
        hair_style_female.Add("8");
        hair_style_female.Add("9");
        hair_style_female.Add("10");
        hair_style_female.Add("11");
        hair_style_female.Add("12");
        hair_style_female.Add("13");
        hair_style_female.Add("14");
        hair_style_female.Add("15");
        hair_style_female.Add("16");
        hair_style_female.Add("17");
        hair_style_female.Add("18");
        hair_style_female.Add("19");
        hair_style_female.Add("20");
        hair_style_female.Add("21");
        hair_style_female.Add("22");
        hair_style_female.Add("23");
        hair_style_female.Add("25");
        hair_style_female.Add("26");
        hair_style_female.Add("27");
        hair_style_female.Add("28");
        hair_style_female.Add("29");
        hair_style_female.Add("30");
        hair_style_female.Add("31");
        hair_style_female.Add("32");
        hair_style_female.Add("33");
        hair_style_female.Add("34");
        hair_style_female.Add("35");
        hair_style_female.Add("36");
        hair_style_female.Add("37");
        hair_style_female.Add("38");
        hair_style_female.Add("39");
        hair_style_female.Add("40");
        hair_style_female.Add("41");
        hair_style_female.Add("42");
        hair_style_female.Add("43");
        hair_style_female.Add("44");
        hair_style_female.Add("45");
        hair_style_female.Add("46");
        hair_style_female.Add("47");
        hair_style_female.Add("48");
        hair_style_female.Add("49");
        hair_style_female.Add("50");
        hair_style_female.Add("51");
        hair_style_female.Add("52");
        hair_style_female.Add("53");
        hair_style_female.Add("54");
        hair_style_female.Add("55");
        hair_style_female.Add("56");
        hair_style_female.Add("57");
        hair_style_female.Add("58");
        hair_style_female.Add("59");
        hair_style_female.Add("60");
        hair_style_female.Add("61");
        hair_style_female.Add("62");
        hair_style_female.Add("63");
        hair_style_female.Add("64");
        hair_style_female.Add("65");
        hair_style_female.Add("66");
        hair_style_female.Add("67");
        hair_style_female.Add("68");
        hair_style_female.Add("69");
        hair_style_female.Add("70");
        hair_style_female.Add("71");
        hair_style_female.Add("72");
        hair_style_female.Add("73");
        hair_style_female.Add("74");
        hair_style_female.Add("75");
        hair_style_female.Add("76");
        hair_style_female.Add("77");


        //

        eye_colors.Add("Green");
        eye_colors.Add("Emerald");
        eye_colors.Add("Light Blue");
        eye_colors.Add("Ocean Blue");
        eye_colors.Add("Light Brown");
        eye_colors.Add("Dark Brown");
        eye_colors.Add("Hazel");
        eye_colors.Add("Dark Gray");
        eye_colors.Add("Light Gray");
        eye_colors.Add("Pink");
        eye_colors.Add("Yellow");
        eye_colors.Add("Blackout");
        eye_colors.Add("Shades of Gray");
        eye_colors.Add("Tequila Sunrise");
        eye_colors.Add("Atomic");
        eye_colors.Add("Warp");
        eye_colors.Add("ECola");
        eye_colors.Add("Space Ranger");
        eye_colors.Add("Ying Yang");
        eye_colors.Add("Bullseye");
        eye_colors.Add("Lizard");
        eye_colors.Add("Dragon");
        eye_colors.Add("Extra Terrestrial");
        eye_colors.Add("Goat");
        eye_colors.Add("Smiley");
        eye_colors.Add("Possessed");
        eye_colors.Add("Demon");
        eye_colors.Add("Infected");
        eye_colors.Add("Alien");
        eye_colors.Add("Undead");
        eye_colors.Add("Zombie");

    }



    public static void DisplayMenu(Player Client)
    {
        var business_id = BusinessManage.GetPlayerInBusinessInType(Client, 10);
        if (business_id == -1)
        {
            Main.SendErrorMessage(Client, Translation.message_13);
            return;
        }

        Client.SetData<dynamic>("barber_hair", CharCreator.CharCreator.CustomPlayerData[Client.Handle].Hair.Hair);
        Client.SetData<dynamic>("barber_hair_color_1", CharCreator.CharCreator.CustomPlayerData[Client.Handle].Hair.Color);
        Client.SetData<dynamic>("barber_hair_color_2", CharCreator.CharCreator.CustomPlayerData[Client.Handle].Hair.HighlightColor);

        Client.SetData<dynamic>("barber_beard", CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[1].Value);
        Client.SetData<dynamic>("barber_beard_color", CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[1].Color);

        Client.SetData<dynamic>("barber_eyebrown", CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[2].Color);
        Client.SetData<dynamic>("barber_eyebrown_color", CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[2].Color);

        Client.SetData<dynamic>("barber_chesthair", CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[10].Color);
        Client.SetData<dynamic>("barber_chesthair_color", CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[10].Color);

        Client.SetData<dynamic>("barber_eyes", CharCreator.CharCreator.CustomPlayerData[Client.Handle].EyeColor);

        Client.SetData<dynamic>("barber_makeup", CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[4].Value);
        Client.SetData<dynamic>("barber_blush", CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[5].Value);
        Client.SetData<dynamic>("barber_lipstick", CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[8].Value);

        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "Frizura", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Brada", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Obrve", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Boja ociju", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Dlake na grudima", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Maskara", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Rumenilo", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Karmin", Description = "", RightLabel = "" });

        Client.TriggerEvent("ps_BodyCamera");
        Client.TriggerEvent("ps_SetCamera",2);
        InteractMenu.CreateMenu(Client, "BARBER_SHOP", "", "~g~" + BusinessManage.business_list[business_id].business_Name, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
    }



    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "BARBER_SHOP")
        {
            var business_id = BusinessManage.GetPlayerInBusinessInType(Client, 10);
            if (business_id == -1)
            {
                Main.SendErrorMessage(Client, Translation.message_13);
                return;
            }

            List<dynamic> menu_item_list = new List<dynamic>();
            List<string> model_list = new List<string>();
            List<string> color_list = new List<string>();

            switch (selectedIndex)
            {
                case 0:
                    {


                        if ((int)NAPI.Data.GetEntitySharedData(Client, "CHARACTER_ONLINE_GENRE") == 1)
                        {
                            for (int i = 0; i < hair_style_female.Count; i++)
                            {
                                model_list.Add(hair_style_female[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < hair_style_male.Count; i++)
                            {
                                model_list.Add(hair_style_male[i]);
                            }
                        }


                        for (int i = 0; i < 65; i++)
                        {
                            color_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Frizura", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 2, Name = "Boja kose", Description = "", List = color_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 2, Name = "Pramenovi", Description = "", List = color_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Cena", Description = "", RightLabel = "$500", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(Client, "HAIR_MENU", "", "~g~" + BusinessManage.business_list[business_id].business_Name, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 1:
                    {


                        for (int i = 0; i < 28; i++)
                        {
                            model_list.Add(i.ToString());
                        }


                        for (int i = 0; i < 65; i++)
                        {
                            color_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Brada", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 2, Name = "Boja brade", Description = "", List = color_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Cena", Description = "", RightLabel = "$500", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(Client, "FACIALHAIR_MENU", "", "~g~" + BusinessManage.business_list[business_id].business_Name, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < 33; i++)
                        {
                            model_list.Add(i.ToString());
                        }


                        for (int i = 0; i < 65; i++)
                        {
                            color_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Obrve", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 2, Name = "Boja obrva", Description = "", List = color_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Cena", Description = "", RightLabel = "$500", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(Client, "EYEBROWS_MENU", "", "~g~" + BusinessManage.business_list[business_id].business_Name, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < 14; i++)
                        {
                            model_list.Add(eye_colors[i]);
                        }



                        menu_item_list.Add(new { Type = 2, Name = "Boja ociju", Description = "", List = model_list, StartIndex = 0 });

                        InteractMenu.CreateMenu(Client, "EYES_MENU", "", "~g~" + BusinessManage.business_list[business_id].business_Name, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            model_list.Add(i.ToString());
                        }


                        for (int i = 0; i < 65; i++)
                        {
                            color_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Dlake na grudima", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 2, Name = "Boja dlaka na grudima", Description = "", List = color_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Cena", Description = "", RightLabel = "$500", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(Client, "CHESTHAIR_MENU", "", "~g~" + BusinessManage.business_list[business_id].business_Name, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 5:
                    {
                        for (int i = 0; i < 96; i++)
                        {
                            model_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Stil sminke", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Cena", Description = "", RightLabel = "$500", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(Client, "MAKEUP_MENU", "", "~g~" + BusinessManage.business_list[business_id].business_Name, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 6:
                    {
                        for (int i = 0; i < 34; i++)
                        {
                            model_list.Add(i.ToString());
                        }


                        menu_item_list.Add(new { Type = 2, Name = "Stil rumenila", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Cena", Description = "", RightLabel = "$500", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(Client, "BLUSH_MENU", "", "~g~" + BusinessManage.business_list[business_id].business_Name, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
                case 7:
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            model_list.Add(i.ToString());
                        }

                        menu_item_list.Add(new { Type = 2, Name = "Stil karmina", Description = "", List = model_list, StartIndex = 0 });
                        menu_item_list.Add(new { Type = 1, Name = "Cena", Description = "", RightLabel = "$500", Color = "Lime", HighlightColor = "White" });

                        InteractMenu.CreateMenu(Client, "LIPSTICK_MENU", "", "~g~" + BusinessManage.business_list[business_id].business_Name, true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_barber3");
                        break;
                    }
            }
        }
        else if (callbackId == "HAIR_MENU")
        {
            BuyBarber(Client, 0);
        }
        else if (callbackId == "FACIALHAIR_MENU")
        {
            BuyBarber(Client, 1);
        }
        else if (callbackId == "EYEBROWS_MENU")
        {

            BuyBarber(Client, 2);
        }
        else if (callbackId == "EYES_MENU")
        {
            BuyBarber(Client, 3);
        }
        else if (callbackId == "CHESTHAIR_MENU")
        {
            BuyBarber(Client, 4);
        }
        else if (callbackId == "MAKEUP_MENU")
        {
            BuyBarber(Client, 5);
        }
        else if (callbackId == "BLUSH_MENU")
        {
            BuyBarber(Client, 6);
        }
        else if (callbackId == "LIPSTICK_MENU")
        {
            BuyBarber(Client, 7);
        }
    }

    public static void IndexChangeMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
    }

    public static void ListItemMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        if (callbackId == "HAIR_MENU")
        {
            if (selectedIndex == 0)
            {
                if ((int)NAPI.Data.GetEntitySharedData(Client, "CHARACTER_ONLINE_GENRE") == 1)
                {
                    Client.SetData<dynamic>("barber_hair", Convert.ToByte(hair_style_female[valueIndex]));
                    Client.SetClothes(2, Convert.ToByte(hair_style_female[valueIndex]), 0);

                }
                else
                {
                    Client.SetData<dynamic>("barber_hair", Convert.ToByte(hair_style_male[valueIndex]));
                    Client.SetClothes(2, Convert.ToByte(hair_style_male[valueIndex]), 0);
                }
            }
            else if (selectedIndex == 1)
            {
                int value = Convert.ToInt32(valueIndex);
                NAPI.Player.SetPlayerHairColor(Client, (byte)value, (byte)Client.GetData<dynamic>("barber_hair_color_2"));
                Client.SetData<dynamic>("barber_hair_color_1", (byte)value);
            }
            else if (selectedIndex == 2)
            {
                int value = Convert.ToInt32(valueIndex);
                NAPI.Player.SetPlayerHairColor(Client, (byte)Client.GetData<dynamic>("barber_hair_color_1"), (byte)value);
                Client.SetData<dynamic>("barber_hair_color_2", (byte)value);
            }
        }
        else if (callbackId == "FACIALHAIR_MENU")
        {
            if (selectedIndex == 0)
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 1;
                if (value == 0) Client.SetData<dynamic>("barber_beard", (byte)value);
                else Client.SetData<dynamic>("barber_beard", (byte)value - 1);
                headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_beard");
                headoverlay2.Color = (byte)Client.GetData<dynamic>("barber_beard_color");
                headoverlay2.Opacity = 255;
                NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
            }
            else if (selectedIndex == 1)
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 1;
                Client.SetData<dynamic>("barber_beard_color", (byte)value);
                headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_beard");
                headoverlay2.Color = (byte)Client.GetData<dynamic>("barber_beard_color");
                headoverlay2.Opacity = 255;
                NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
            }
        }
        else if (callbackId == "EYEBROWS_MENU")
        {
            if (selectedIndex == 0)
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 2;
                if (value == 0) Client.SetData<dynamic>("barber_eyebrown", (byte)value);
                else Client.SetData<dynamic>("barber_eyebrown", (byte)value - 1);
                headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_eyebrown");
                headoverlay2.Color = (byte)Client.GetData<dynamic>("barber_eyebrown_color");
                headoverlay2.Opacity = 255;
                NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
            }
            else if (selectedIndex == 1)
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 2;
                Client.SetData<dynamic>("barber_eyebrown_color", (byte)value);
                headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_eyebrown");
                headoverlay2.Color = (byte)Client.GetData<dynamic>("barber_eyebrown_color");
                headoverlay2.Opacity = 255;
                NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
            }
        }
        else if (callbackId == "EYES_MENU")
        {
            int value = Convert.ToInt32(valueIndex);
            NAPI.Player.SetPlayerEyeColor(Client, (byte)value);
            Client.SetData<dynamic>("barber_eyes", (byte)value);
        }
        else if (callbackId == "MAKEUP_MENU")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 4;
            Client.SetData<dynamic>("barber_makeup", (byte)value);
            headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_makeup");
            headoverlay2.Color = 0;
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
        }
        else if (callbackId == "BLUSH_MENU")
        {

            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 5;
            Client.SetData<dynamic>("barber_blush", (byte)value);
            headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_blush");
            headoverlay2.Color = 0;
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
        }
        else if (callbackId == "LIPSTICK_MENU")
        {

            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 8;
            Client.SetData<dynamic>("barber_lipstick", (byte)value);
            headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_lipstick");
            headoverlay2.Color = 0;
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
        }
        else if (callbackId == "CHESTHAIR_MENU")
        {
            if (selectedIndex == 0)
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 10;
                if (value == 0) Client.SetData<dynamic>("barber_chesthair", (byte)value);
                else Client.SetData<dynamic>("barber_chesthair", (byte)value - 1);
                headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_chesthair");
                headoverlay2.Color = (byte)Client.GetData<dynamic>("barber_chesthair_color");
                headoverlay2.Opacity = 255;
                NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
            }
            else if (selectedIndex == 1)
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 10;
                Client.SetData<dynamic>("barber_chesthair_color", (byte)value);
                headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_chesthair");
                headoverlay2.Color = (byte)Client.GetData<dynamic>("barber_chesthair_color");
                headoverlay2.Opacity = 255;
                NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
            }
        }
    }

    public static void OnMenuReturnClose(Player Client, String callbackId)
    {
        if (callbackId == "HAIR_MENU" || callbackId == "BARBER_SHOP" || callbackId == "MAKEUP_MENU" || callbackId == "BLUSH_MENU" || callbackId == "LIPSTICK_MENU" || callbackId == "CHESTHAIR_MENU" || callbackId == "FACIALHAIR_MENU" || callbackId == "EYES_MENU" || callbackId == "EYEBROWS_MENU")
        {
            Client.TriggerEvent("ps_DestroyCamera");
            CharCreator.CharCreator.UpdateCharacter(Client);
        }
    }

    [RemoteEvent("BuyBarber")]
    public static void BuyBarber(Player Client, int menu_index)
    {
        Barber_Menu_Destroy(Client);
        Client.TriggerEvent("ps_DestroyCamera");

        var business_id = BusinessManage.GetPlayerInBusinessInType(Client, 10);
        if (business_id == -1)
        {
            Main.SendErrorMessage(Client, Translation.message_13);
            return;
        }

        if (menu_index == 0) // Hair
        {
            int item_price = 500;

            if (Main.GetPlayerMoney(Client) < item_price)
            {
                Main.SendErrorMessage(Client, Translation.message_14);
                return;
            }

            Main.SendSuccessMessage(Client, string.Format(Translation.message_16, item_price));
            Main.GivePlayerMoney(Client, -item_price);

            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Hair.Hair = (byte)Client.GetData<dynamic>("barber_hair");
            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Hair.Color = (byte)Client.GetData<dynamic>("barber_hair_color_1");
            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Hair.HighlightColor = (byte)Client.GetData<dynamic>("barber_hair_color_2");
            CharCreator.CharCreator.UpdateCharacter(Client);
            CharCreator.CharCreator.SaveChar(Client);
        }
        else if (menu_index == 1) // Beard
        {
            int item_price = 80;

            if (Main.GetPlayerMoney(Client) < item_price)
            {
                Main.SendErrorMessage(Client, Translation.message_14);
                return;
            }

            

            Main.SendSuccessMessage(Client, string.Format(Translation.message_16, item_price));
            Main.GivePlayerMoney(Client, -item_price);

            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[1].Value = (byte)Client.GetData<dynamic>("barber_beard");
            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[1].Color = (byte)Client.GetData<dynamic>("barber_beard_color");
            CharCreator.CharCreator.UpdateCharacter(Client);
            CharCreator.CharCreator.SaveChar(Client);
        }
        else if (menu_index == 2) // Sombra
        {
            int item_price = 40;

            if (Main.GetPlayerMoney(Client) < item_price)
            {
                Main.SendErrorMessage(Client, Translation.message_14);
                return;
            }

            
            Main.SendSuccessMessage(Client, string.Format(Translation.message_16, item_price));
            Main.GivePlayerMoney(Client, -item_price);

            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[2].Value = (byte)Client.GetData<dynamic>("barber_eyebrown");
            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[2].Color = (byte)Client.GetData<dynamic>("barber_eyebrown_color");

            CharCreator.CharCreator.UpdateCharacter(Client);
            CharCreator.CharCreator.SaveChar(Client);
        }
        else if (menu_index == 3) // Eyes
        {
            int item_price = 290;

            if (Main.GetPlayerMoney(Client) < item_price)
            {
                Main.SendErrorMessage(Client, Translation.message_14);
                return;
            }

            

            Main.SendSuccessMessage(Client, string.Format(Translation.message_16, item_price));
            Main.GivePlayerMoney(Client, -item_price);
            CharCreator.CharCreator.CustomPlayerData[Client.Handle].EyeColor = (byte)Client.GetData<dynamic>("barber_eyes");
            CharCreator.CharCreator.UpdateCharacter(Client);
            CharCreator.CharCreator.SaveChar(Client);
        }
        else if (menu_index == 4) // Cabelo Peito
        {
            int item_price = 35;

            if (Main.GetPlayerMoney(Client) < item_price)
            {
                Main.SendErrorMessage(Client, Translation.message_14);
                return;
            }

           

            Main.SendSuccessMessage(Client, string.Format(Translation.message_16, item_price));
            Main.GivePlayerMoney(Client, -item_price);

            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[10].Value = (byte)Client.GetData<dynamic>("barber_beard");
            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[10].Color = (byte)Client.GetData<dynamic>("barber_beard_color");
            CharCreator.CharCreator.UpdateCharacter(Client);
            CharCreator.CharCreator.SaveChar(Client);
        }
        else if (menu_index == 5) // 
        {
            int item_price = 110;

            if (Main.GetPlayerMoney(Client) < item_price)
            {
                Main.SendErrorMessage(Client, Translation.message_14);
                return;
            }

            

            Main.SendSuccessMessage(Client, string.Format(Translation.message_16, item_price));
            Main.GivePlayerMoney(Client, -item_price);

            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[4].Value = (byte)Client.GetData<dynamic>("barber_makeup");
            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[4].Color = 0;
            CharCreator.CharCreator.UpdateCharacter(Client);
            CharCreator.CharCreator.SaveChar(Client);
        }
        else if (menu_index == 6) // 
        {
            int item_price = 75;

            if (Main.GetPlayerMoney(Client) < item_price)
            {
                Main.SendErrorMessage(Client, Translation.message_14);
                return;
            }

            

            Main.SendSuccessMessage(Client, string.Format(Translation.message_16, item_price));
            Main.GivePlayerMoney(Client, -item_price);

            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[5].Value = (byte)Client.GetData<dynamic>("barber_blush");
            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[5].Color = 0;
            CharCreator.CharCreator.UpdateCharacter(Client);
            CharCreator.CharCreator.SaveChar(Client);
        }
        else if (menu_index == 7) // 
        {
            int item_price = 30;

            if (Main.GetPlayerMoney(Client) < item_price)
            {
                Main.SendErrorMessage(Client, Translation.message_14);
                return;
            }

            

            Main.SendSuccessMessage(Client, string.Format(Translation.message_16, item_price));
            Main.GivePlayerMoney(Client, -item_price);

            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[8].Value = (byte)Client.GetData<dynamic>("barber_lipstick");
            CharCreator.CharCreator.CustomPlayerData[Client.Handle].Appearance[8].Color = 0;
            CharCreator.CharCreator.UpdateCharacter(Client);
            CharCreator.CharCreator.SaveChar(Client);
        }
    }

    [RemoteEvent("Barber_Menu_Destroy")]
    public static void Barber_Menu_Destroy(Player Client)
    {
        Client.TriggerEvent("ps_DestroyCamera");
        Client.TriggerEvent("Destroy_Character_Menu");
        CharCreator.CharCreator.UpdateCharacter(Client);
    }

    [RemoteEvent("Barber_Update_Character")]
    public static void Barber_Update_Character(Player Client)
    {
        CharCreator.CharCreator.UpdateCharacter(Client);
    }


    [RemoteEvent("ClientOnRangeChangeBarber")]
    public static void ClientOnRangeChangeBarber(Player Client, string response, string valueIndex)
    {
        if (response == "barber_range_hair")
        {
            int value = Convert.ToInt32(valueIndex);
            Client.SetData<dynamic>("barber_hair", (byte)value);

            Client.SetClothes(2, value, 0);
        }
        else if (response == "barber_range_hair_color_1")
        {
            int value = Convert.ToInt32(valueIndex);
            NAPI.Player.SetPlayerHairColor(Client, (byte)value, (byte)Client.GetData<dynamic>("barber_hair_color_2"));
            Client.SetData<dynamic>("barber_hair_color_1", (byte)value);
        }
        else if (response == "barber_range_hair_color_2")
        {
            int value = Convert.ToInt32(valueIndex);
            NAPI.Player.SetPlayerHairColor(Client, (byte)Client.GetData<dynamic>("barber_hair_color_1"), (byte)value);
            Client.SetData<dynamic>("barber_hair_color_2", (byte)value);
        }
        else if (response == "barber_range_beard")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 1;
            if (value == 0) Client.SetData<dynamic>("barber_beard", (byte)value);
            else Client.SetData<dynamic>("barber_beard", (byte)value - 1);
            headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_beard");
            headoverlay2.Color = (byte)Client.GetData<dynamic>("barber_beard_color");
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);

        }
        else if (response == "barber_range_beard_color")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 1;
            Client.SetData<dynamic>("barber_beard_color", (byte)value);
            headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_beard");
            headoverlay2.Color = (byte)Client.GetData<dynamic>("barber_beard_color");
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
        }
        else if (response == "barber_range_eyebrown")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 2;
            if (value == 0) Client.SetData<dynamic>("barber_eyebrown", (byte)value);
            else Client.SetData<dynamic>("barber_eyebrown", (byte)value - 1);
            headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_eyebrown");
            headoverlay2.Color = (byte)Client.GetData<dynamic>("barber_eyebrown_color");
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
        }
        else if (response == "barber_range_eyebrown_color")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 2;
            Client.SetData<dynamic>("barber_eyebrown_color", (byte)value);
            headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_eyebrown");
            headoverlay2.Color = (byte)Client.GetData<dynamic>("barber_eyebrown_color");
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
        }
        else if (response == "barber_range_eyes")
        {
            int value = Convert.ToInt32(valueIndex);
            NAPI.Player.SetPlayerEyeColor(Client, (byte)value);
            Client.SetData<dynamic>("barber_eyes", (byte)value);
        }
        else if (response == "barber_range_chesthair")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 10;
            if (value == 0) Client.SetData<dynamic>("barber_chesthair", (byte)value);
            else Client.SetData<dynamic>("barber_chesthair", (byte)value - 1);
            headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_chesthair");
            headoverlay2.Color = (byte)Client.GetData<dynamic>("barber_chesthair_color");
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
        }
        else if (response == "barber_range_chesthair_color")
        {
            int value = Convert.ToInt32(valueIndex);
            HeadOverlay headoverlay2 = new HeadOverlay();
            int index = 10;
            Client.SetData<dynamic>("barber_chesthair_color", (byte)value);
            headoverlay2.Index = (byte)Client.GetData<dynamic>("barber_chesthair");
            headoverlay2.Color = (byte)Client.GetData<dynamic>("barber_chesthair_color");
            headoverlay2.Opacity = 255;
            NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
        }
    }

}

