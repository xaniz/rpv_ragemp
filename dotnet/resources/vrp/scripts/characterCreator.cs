using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;


namespace CharCreator
{
    #region ParentData
    public class ParentData
    {
        public int Father;
        public int Mother;
        public float Similarity;
        public float SkinSimilarity;

        public ParentData(int father, int mother, float similarity, float skinsimilarity)
        {
            Father = father;
            Mother = mother;
            Similarity = similarity;
            SkinSimilarity = skinsimilarity;
        }
    }
    #endregion

    #region AppearanceItem
    public class AppearanceItem
    {
        public int Value;
        public float Opacity;
        public int Color;

        public AppearanceItem(int value, float opacity, int color)
        {
            Value = value;
            Opacity = opacity;
            Color = color;
        }
    }
    #endregion

    #region HairData
    public class HairData
    {
        public int Hair;
        public int Color;
        public int HighlightColor;

        public HairData(int hair, int color, int highlightcolor)
        {
            Hair = hair;
            Color = color;
            HighlightColor = highlightcolor;
        }
    }
    #endregion

    public struct PedTattoos
    {
        public List<KeyValuePair<string, string>> TorsoTattoos;
        public List<KeyValuePair<string, string>> HeadTattoos;
        public List<KeyValuePair<string, string>> LeftArmTattoos;
        public List<KeyValuePair<string, string>> RightArmTattoos;
        public List<KeyValuePair<string, string>> LeftLegTattoos;
        public List<KeyValuePair<string, string>> RightLegTattoos;
        public List<KeyValuePair<string, string>> BadgeTattoos;
    }


    #region PlayerCustomization Class
    public class PlayerCustomization
    {
        // Client
        public int Gender;

        // Parents
        public ParentData Parents;

        // Features
        public float[] Features = new float[20];

        // Appearance
        public AppearanceItem[] Appearance = new AppearanceItem[13];

        // Hair & Colors
        public HairData Hair;

        public int EyebrowColor;
        public int BeardColor;
        public int EyeColor;
        public int BlushColor;
        public int LipstickColor;
        public int MakeUp;
        public int ChestHairColor;

        public PedTattoos PedTatttoos;

        public PlayerCustomization()
        {
            Gender = 0;
            Parents = new ParentData(0, 0, 1.0f, 1.0f);
            for (int i = 0; i < Features.Length; i++) Features[i] = 0f;
            for (int i = 0; i < Appearance.Length; i++) Appearance[i] = new AppearanceItem(255, 1.0f, 0);
            Hair = new HairData(0, 0, 0);
        }
    }
    #endregion

    public class CharCreator : Script
    {
        public static string SAVE_DIRECTORY = "CustomCharacters";


        public static Dictionary<NetHandle, PlayerCustomization> CustomPlayerData = new Dictionary<NetHandle, PlayerCustomization>();

        public static Vector3 CreatorCharPos = new Vector3(402.8664, -996.4108, -99.00027);
        public static Vector3 CreatorPos = new Vector3(402.8664, -997.5515, -98.5);
        public static Vector3 CameraLookAtPos = new Vector3(402.8664, -996.4108, -98.5);
        public static float FacingAngle = -185.0f;
        public static int DimensionID = 1;

        public static List<string> hair_style_female = new List<string>();
        public static List<string> hair_style_male = new List<string>();
        public static List<string> eye_colors = new List<string>();
        public static List<string> dad = new List<string>();
        public static List<string> mom = new List<string>();
        public static List<string> shape_mix_list = new List<string>();
        public CharCreator()
        {

            dad.Add("Benjamin");
            dad.Add("Daniel");
            dad.Add("Joshua");
            dad.Add("Noah");
            dad.Add("Andrew");
            dad.Add("Juan");
            dad.Add("Alex");
            dad.Add("Isaac");
            dad.Add("Evan");
            dad.Add("Ethan");
            dad.Add("Vincent");
            dad.Add("Angel");
            dad.Add("Diego");
            dad.Add("Adrian");
            dad.Add("Gabriel");
            dad.Add("Michael");
            dad.Add("Santiago");
            dad.Add("Kevin");
            dad.Add("Louis");
            dad.Add("Samuel");
            dad.Add("Anthony");
            dad.Add("Claude");
            dad.Add("Niko");
            dad.Add("John");

            mom.Add("Hannah");
            mom.Add("Aubrey");
            mom.Add("Jasmine");
            mom.Add("Gisele");
            mom.Add("Amelia");
            mom.Add("Isabella");
            mom.Add("Zoe");
            mom.Add("Ava");
            mom.Add("Camila");
            mom.Add("Violet");
            mom.Add("Sophia");
            mom.Add("Evelyn");
            mom.Add("Nicole");
            mom.Add("Ashley");
            mom.Add("Gracie");
            mom.Add("Brianna");
            mom.Add("Natalie");
            mom.Add("Olivia");
            mom.Add("Elizabeth");
            mom.Add("Charlotte");
            mom.Add("Emma");
            mom.Add("Misty");


            /*shape_mix_list.Add("0.0");
            shape_mix_list.Add("0.2");
            shape_mix_list.Add("0.4");
            shape_mix_list.Add("0.6");
            shape_mix_list.Add("0.8");*/
            shape_mix_list.Add("Mãe - ~b~I~w~IIIIIIII ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~II~w~IIIIIII ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~III~w~IIIIII ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~IIII~w~IIIII ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~IIIII~w~IIII ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~IIIIII~w~III ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~IIIIIII~w~II ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~IIIIIIII~w~I ~w~- ~y~Pai");
            shape_mix_list.Add("Mãe - ~b~IIIIIIIII ~w~- ~y~Pai");

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
            hair_style_male.Add("74");

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


            // 4 - 41

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

        #region Methods
        public static async void LoadCharacter(Player Client, string character_name)
        {

            // if (CustomPlayerData.ContainsKey(Client.Handle)) CustomPlayerData.Remove(Client.Handle);
            if (CustomPlayerData.ContainsKey(Client.Handle)) CustomPlayerData.Remove(Client.Handle);

            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {

                await Mainpipeline.OpenAsync();
                MySqlCommand query = new MySqlCommand("SELECT * FROM `characters` WHERE `name` = '" + character_name + "' LIMIT 1;", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {

                    string data2txt = string.Empty;
                    string datatxt = string.Empty;

                    while (await reader.ReadAsync())
                    {

                       // var character = API.Shared.FromJson(reader.GetString("char"));
                        PlayerCustomization teste = JsonConvert.DeserializeObject<PlayerCustomization>((string)reader.GetString("char"));

                        CustomPlayerData[Client.Handle] = teste;

                       // Client.SetSharedData("Tattoo_Data",NAPI.Util.ToJson(teste.PedTatttoos));
                        /*
                        CustomPlayerData.Add(Client.Handle, new PlayerCustomization());


                        CustomPlayerData[Client.Handle].Parents.Mother = (byte)character.Parents.Mother;
                        CustomPlayerData[Client.Handle].Parents.Father = (byte)character.Parents.Father;
                        CustomPlayerData[Client.Handle].Parents.Similarity = (float)character.Parents.Similarity;
                        CustomPlayerData[Client.Handle].Parents.SkinSimilarity = (float)character.Parents.SkinSimilarity;
                        CustomPlayerData[Client.Handle].Gender = character.Gender;

                        CustomPlayerData[Client.Handle].Hair.Hair = character.Hair.Hair;
                        CustomPlayerData[Client.Handle].Hair.Color = character.Hair.Color;
                        CustomPlayerData[Client.Handle].Hair.HighlightColor = character.Hair.HighlightColor;

                        CustomPlayerData[Client.Handle].EyebrowColor = character.EyebrowColor;
                        CustomPlayerData[Client.Handle].BeardColor = character.BeardColor;
                        CustomPlayerData[Client.Handle].EyeColor = character.EyeColor;
                        CustomPlayerData[Client.Handle].BlushColor = character.BlushColor;
                        CustomPlayerData[Client.Handle].LipstickColor = character.LipstickColor;
                        CustomPlayerData[Client.Handle].ChestHairColor = character.ChestHairColor;

                        CustomPlayerData[Client.Handle].ChestHairColor = character.ChestHairColor;

                        for (int i = 0; i < CustomPlayerData[Client.Handle].Features.Length; i++) CustomPlayerData[Client.Handle].Features[i] = character.Features[i];


                        for (int i = 0; i < CustomPlayerData[Client.Handle].Appearance.Length; i++)
                        {

                            CustomPlayerData[Client.Handle].Appearance[i].Value = (byte)character.Appearance[i].Value;
                            CustomPlayerData[Client.Handle].Appearance[i].Color = (byte)character.Appearance[i].Color;
                            CustomPlayerData[Client.Handle].Appearance[i].Opacity = character.Appearance[i].Opacity;

                        }*/


                        ApplyCharacter(Client);

                        return;
                    }
                }
            }



            CustomPlayerData.Add(Client.Handle, new PlayerCustomization());
            ApplyCharacter(Client);


        }

        public static void ApplyCharacterPreview(Player Client)
        {
            if (!CustomPlayerData.ContainsKey(Client.Handle)) return;


            Client.SetSharedData("CHARACTER_ONLINE_GENRE", Convert.ToInt32(CustomPlayerData[Client.Handle].Gender));

            /* Client.SetSkin((CustomPlayerData[Client.Handle].Gender == 0) ? PedHash.FreemodeMale01 : PedHash.FreemodeFemale01);
             Client.SetDefaultClothes();
             Client.SetClothes(2, CustomPlayerData[Client.Handle].Hair.Hair, 0);*/

            HeadBlend heahblend = new HeadBlend();
            heahblend.ShapeFirst = (byte)CustomPlayerData[Client.Handle].Parents.Mother;
            heahblend.ShapeSecond = (byte)CustomPlayerData[Client.Handle].Parents.Father;
            heahblend.ShapeThird = 0;
            heahblend.SkinFirst = (byte)CustomPlayerData[Client.Handle].Parents.Mother;
            heahblend.SkinSecond = (byte)CustomPlayerData[Client.Handle].Parents.Father;
            heahblend.SkinThird = 0;
            heahblend.ShapeMix = CustomPlayerData[Client.Handle].Parents.Similarity;
            heahblend.SkinMix = CustomPlayerData[Client.Handle].Parents.SkinSimilarity;
            heahblend.ThirdMix = 0;
            NAPI.Player.SetPlayerHeadBlend(Client, heahblend);

            //Client.SetDefaultClothes();
            Client.SetClothes(2, CustomPlayerData[Client.Handle].Hair.Hair, 0);

            NAPI.Player.SetPlayerHairColor(Client, (byte)CustomPlayerData[Client.Handle].Hair.Color, (byte)CustomPlayerData[Client.Handle].Hair.HighlightColor);
            NAPI.Player.SetPlayerEyeColor(Client, (byte)CustomPlayerData[Client.Handle].EyeColor);

            for (int i = 0; i < CustomPlayerData[Client.Handle].Features.Length; i++) NAPI.Player.SetPlayerFaceFeature(Client, i, CustomPlayerData[Client.Handle].Features[i]);
            for (int i = 0; i < CustomPlayerData[Client.Handle].Appearance.Length; i++)
            {
                HeadOverlay headoverlay2 = new HeadOverlay();
                headoverlay2.Index = (byte)CustomPlayerData[Client.Handle].Appearance[i].Value;
                headoverlay2.Color = (byte)CustomPlayerData[Client.Handle].Appearance[i].Color;
                headoverlay2.SecondaryColor = (byte)CustomPlayerData[Client.Handle].Appearance[i].Color;
                headoverlay2.Opacity = CustomPlayerData[Client.Handle].Appearance[i].Opacity;
                NAPI.Player.SetPlayerHeadOverlay(Client, i, headoverlay2);
            }
            TattoBusiness.ApplySavedTattoos(Client);
            /*  HeadOverlay headoverlay = new HeadOverlay();
              headoverlay.Index = 1;
              headoverlay.Opacity = 1;
              headoverlay.Color = (byte)CustomPlayerData[Client.Handle].BeardColor;
              headoverlay.SecondaryColor = 0;
              Client.SetHeadOverlay(1, headoverlay);

              headoverlay = new HeadOverlay();
              headoverlay.Index = 2;
              headoverlay.Opacity = 1;
              headoverlay.Color = (byte)CustomPlayerData[Client.Handle].EyebrowColor;
              headoverlay.SecondaryColor = 0;
              Client.SetHeadOverlay(2, headoverlay);

              headoverlay = new HeadOverlay();
              headoverlay.Index = 5;
              headoverlay.Opacity = 2;
              headoverlay.Color = (byte)CustomPlayerData[Client.Handle].BlushColor;
              headoverlay.SecondaryColor = 0;
              Client.SetHeadOverlay(2, headoverlay);

              headoverlay = new HeadOverlay();
              headoverlay.Index = 8;
              headoverlay.Opacity = 2;
              headoverlay.Color = (byte)CustomPlayerData[Client.Handle].LipstickColor;
              headoverlay.SecondaryColor = 0;
              Client.SetHeadOverlay(2, headoverlay);

              headoverlay = new HeadOverlay();
              headoverlay.Index = 10;
              headoverlay.Opacity = 1;
              headoverlay.Color = (byte)CustomPlayerData[Client.Handle].ChestHairColor;
              headoverlay.SecondaryColor = 0;
              Client.SetHeadOverlay(2, headoverlay);*/

            Client.SetSharedData("CustomCharacter", NAPI.Util.ToJson(CustomPlayerData[Client.Handle]));

        }

        public static void ReloadCharacter(Player Client)
        {
            if (!CustomPlayerData.ContainsKey(Client.Handle)) return;

            Client.SetSkin((CustomPlayerData[Client.Handle].Gender == 0) ? PedHash.FreemodeMale01 : PedHash.FreemodeFemale01);

            HeadBlend heahblend = new HeadBlend();
            heahblend.ShapeFirst = (byte)CustomPlayerData[Client.Handle].Parents.Mother;
            heahblend.ShapeSecond = (byte)CustomPlayerData[Client.Handle].Parents.Father;
            heahblend.ShapeThird = 0;
            heahblend.SkinFirst = (byte)CustomPlayerData[Client.Handle].Parents.Mother;
            heahblend.SkinSecond = (byte)CustomPlayerData[Client.Handle].Parents.Father;
            heahblend.SkinThird = 0;
            heahblend.ShapeMix = CustomPlayerData[Client.Handle].Parents.Similarity;
            heahblend.SkinMix = CustomPlayerData[Client.Handle].Parents.SkinSimilarity;
            heahblend.ThirdMix = 0;
            NAPI.Player.SetPlayerHeadBlend(Client, heahblend);

            //Client.SetDefaultClothes();
            Client.SetClothes(2, CustomPlayerData[Client.Handle].Hair.Hair, 0);

            NAPI.Player.SetPlayerHairColor(Client, (byte)CustomPlayerData[Client.Handle].Hair.Color, (byte)CustomPlayerData[Client.Handle].Hair.HighlightColor);
            NAPI.Player.SetPlayerEyeColor(Client, (byte)CustomPlayerData[Client.Handle].EyeColor);

            for (int i = 0; i < CustomPlayerData[Client.Handle].Features.Length; i++) NAPI.Player.SetPlayerFaceFeature(Client, i, CustomPlayerData[Client.Handle].Features[i]);
            for (int i = 0; i < CustomPlayerData[Client.Handle].Appearance.Length; i++)
            {
                HeadOverlay headoverlay2 = new HeadOverlay();
                headoverlay2.Index = (byte)CustomPlayerData[Client.Handle].Appearance[i].Value;
                headoverlay2.Color = (byte)CustomPlayerData[Client.Handle].Appearance[i].Color;
                headoverlay2.SecondaryColor = (byte)CustomPlayerData[Client.Handle].Appearance[i].Color;
                headoverlay2.Opacity = CustomPlayerData[Client.Handle].Appearance[i].Opacity;
                NAPI.Player.SetPlayerHeadOverlay(Client, i, headoverlay2);
            }
        }

        public static void ApplyCharacter(Player Client)
        {
            if (!CustomPlayerData.ContainsKey(Client.Handle)) return;

            Client.SetSharedData("CHARACTER_ONLINE_GENRE", Convert.ToInt32(CustomPlayerData[Client.Handle].Gender));

            /* Client.SetSkin((CustomPlayerData[Client.Handle].Gender == 0) ? PedHash.FreemodeMale01 : PedHash.FreemodeFemale01);
             Client.SetDefaultClothes();
             Client.SetClothes(2, CustomPlayerData[Client.Handle].Hair.Hair, 0);*/

            HeadBlend heahblend = new HeadBlend();
            heahblend.ShapeFirst = (byte)CustomPlayerData[Client.Handle].Parents.Mother;
            heahblend.ShapeSecond = (byte)CustomPlayerData[Client.Handle].Parents.Father;
            heahblend.ShapeThird = 0;
            heahblend.SkinFirst = (byte)CustomPlayerData[Client.Handle].Parents.Mother;
            heahblend.SkinSecond = (byte)CustomPlayerData[Client.Handle].Parents.Father;
            heahblend.SkinThird = 0;
            heahblend.ShapeMix = CustomPlayerData[Client.Handle].Parents.Similarity;
            heahblend.SkinMix = CustomPlayerData[Client.Handle].Parents.SkinSimilarity;
            heahblend.ThirdMix = 0;
            NAPI.Player.SetPlayerHeadBlend(Client, heahblend);

            Client.SetSkin((CustomPlayerData[Client.Handle].Gender == 0) ? PedHash.FreemodeMale01 : PedHash.FreemodeFemale01);
            //Client.SetDefaultClothes();
            Client.SetClothes(2, CustomPlayerData[Client.Handle].Hair.Hair, 0);

            NAPI.Player.SetPlayerHairColor(Client, (byte)CustomPlayerData[Client.Handle].Hair.Color, (byte)CustomPlayerData[Client.Handle].Hair.HighlightColor);
            NAPI.Player.SetPlayerEyeColor(Client, (byte)CustomPlayerData[Client.Handle].EyeColor);

            for (int i = 0; i < CustomPlayerData[Client.Handle].Features.Length; i++) NAPI.Player.SetPlayerFaceFeature(Client, i, CustomPlayerData[Client.Handle].Features[i]);
            for (int i = 0; i < CustomPlayerData[Client.Handle].Appearance.Length; i++)
            {
                HeadOverlay headoverlay2 = new HeadOverlay();
                headoverlay2.Index = (byte)CustomPlayerData[Client.Handle].Appearance[i].Value;
                headoverlay2.Color = (byte)CustomPlayerData[Client.Handle].Appearance[i].Color;
                headoverlay2.SecondaryColor = (byte)CustomPlayerData[Client.Handle].Appearance[i].Color;
                headoverlay2.Opacity = CustomPlayerData[Client.Handle].Appearance[i].Opacity;
                NAPI.Player.SetPlayerHeadOverlay(Client, i, headoverlay2);
            }
            TattoBusiness.ApplySavedTattoos(Client);

            /* HeadOverlay headoverlay = new HeadOverlay();
             headoverlay.Index = 1;
             headoverlay.Opacity = 1;
             headoverlay.Color = (byte)CustomPlayerData[Client.Handle].BeardColor;
             headoverlay.SecondaryColor = 0;
             Client.SetHeadOverlay(1, headoverlay);

             headoverlay = new HeadOverlay();
             headoverlay.Index = 2;
             headoverlay.Opacity = 1;
             headoverlay.Color = (byte)CustomPlayerData[Client.Handle].EyebrowColor;
             headoverlay.SecondaryColor = 0;
             Client.SetHeadOverlay(2, headoverlay);

             headoverlay = new HeadOverlay();
             headoverlay.Index = 5;
             headoverlay.Opacity = 2;
             headoverlay.Color = (byte)CustomPlayerData[Client.Handle].BlushColor;
             headoverlay.SecondaryColor = 0;
             Client.SetHeadOverlay(2, headoverlay);

             headoverlay = new HeadOverlay();
             headoverlay.Index = 8;
             headoverlay.Opacity = 2;
             headoverlay.Color = (byte)CustomPlayerData[Client.Handle].LipstickColor;
             headoverlay.SecondaryColor = 0;
             Client.SetHeadOverlay(2, headoverlay);

             headoverlay = new HeadOverlay();
             headoverlay.Index = 10;
             headoverlay.Opacity = 1;
             headoverlay.Color = (byte)CustomPlayerData[Client.Handle].ChestHairColor;
             headoverlay.SecondaryColor = 0;
             Client.SetHeadOverlay(2, headoverlay);*/

            Client.SetSharedData("CustomCharacter", NAPI.Util.ToJson(CustomPlayerData[Client.Handle]));

        }

        public static void UpdateCharacter(Player Client)
        {
            if (!CustomPlayerData.ContainsKey(Client.Handle)) return;

            Client.SetSharedData("CHARACTER_ONLINE_GENRE", Convert.ToInt32(CustomPlayerData[Client.Handle].Gender));

            HeadBlend heahblend = new HeadBlend();
            heahblend.ShapeFirst = (byte)CustomPlayerData[Client.Handle].Parents.Mother;
            heahblend.ShapeSecond = (byte)CustomPlayerData[Client.Handle].Parents.Father;
            heahblend.ShapeThird = 0;
            heahblend.SkinFirst = (byte)CustomPlayerData[Client.Handle].Parents.Mother;
            heahblend.SkinSecond = (byte)CustomPlayerData[Client.Handle].Parents.Father;
            heahblend.SkinThird = 0;
            heahblend.ShapeMix = CustomPlayerData[Client.Handle].Parents.Similarity;
            heahblend.SkinMix = CustomPlayerData[Client.Handle].Parents.SkinSimilarity;
            heahblend.ThirdMix = 0;
            NAPI.Player.SetPlayerHeadBlend(Client, heahblend);

            Client.SetClothes(2, CustomPlayerData[Client.Handle].Hair.Hair, 0);

            NAPI.Player.SetPlayerHairColor(Client, (byte)CustomPlayerData[Client.Handle].Hair.Color, (byte)CustomPlayerData[Client.Handle].Hair.HighlightColor);
            NAPI.Player.SetPlayerEyeColor(Client, (byte)CustomPlayerData[Client.Handle].EyeColor);

            for (int i = 0; i < CustomPlayerData[Client.Handle].Features.Length; i++) NAPI.Player.SetPlayerFaceFeature(Client, i, CustomPlayerData[Client.Handle].Features[i]);
            for (int i = 0; i < CustomPlayerData[Client.Handle].Appearance.Length; i++)
            {
                HeadOverlay headoverlay2 = new HeadOverlay();
                headoverlay2.Index = (byte)CustomPlayerData[Client.Handle].Appearance[i].Value;
                headoverlay2.Color = (byte)CustomPlayerData[Client.Handle].Appearance[i].Color;
                headoverlay2.SecondaryColor = (byte)CustomPlayerData[Client.Handle].Appearance[i].Color;
                headoverlay2.Opacity = CustomPlayerData[Client.Handle].Appearance[i].Opacity;
                NAPI.Player.SetPlayerHeadOverlay(Client, i, headoverlay2);
            }

        }

        //
        // Save Character
        //


        //
        //
        //
        public static void SaveChar(Player Client)
        {
            if (Client.GetData<dynamic>("status") == true)
            {
                Main.CreateMySqlCommand("UPDATE `characters` SET `char` = '" + API.Shared.ToJson(CustomPlayerData[Client.Handle]) + "' WHERE name = '" + NAPI.Data.GetEntityData(Client, "character_name") + "';");
            }
        }

        public static void SendToCreator(Player Client)
        {
            Client.SetData<dynamic>("Creator_PrevPos", Client.Position);
            Random rnd = new Random();
            int random_world = rnd.Next(5, 500);
            Client.Dimension = (uint)random_world;
            /*Client.Rotation = new Vector3(0f, 0f, FacingAngle);
            Client.Position = CreatorCharPos;*/

            /*Client.Position = new Vector3(-797.7922, 327.5691, 220.4409);
            Client.Rotation = new Vector3(0, 0, 359.8687);*/

            if (CustomPlayerData.ContainsKey(Client.Handle))
            {
                //Client.SetDefaultClothes();
                SetCreatorClothes(Client, CustomPlayerData[Client.Handle].Gender);
                SetDefaultFeatures(Client, 0, true);
            }
            else
            {
                //Client.SetDefaultClothes();
                CustomPlayerData.Add(Client.Handle, new PlayerCustomization());
                SetDefaultFeatures(Client, 0, true);
            }
            Client.SetData<dynamic>("creator_outfit", 0);
            Client.TriggerEvent("ps_SetCamera", 0);
            ShowPlayerCreator(Client, true);
            // Client.TriggerEvent("characterCreator", false);
            //Client.TriggerEvent("ps_BodyCamera");
            DimensionID++;
        }

        public static void SendBackToWorld(Player Client)
        {
            Client.Dimension = 0;
            NAPI.Entity.SetEntityPosition(Client, new Vector3(-536.447, -219.6322, 37.64978));
            Client.Rotation = new Vector3(0, 0, 211.0624);
            Client.TriggerEvent("freeze", false);
            Client.TriggerEvent("freezeEx", false);

            //Client.TriggerEvent("reset_camera");
            Client.ResetData("Creator_PrevPos");
        }

        public static void SetDefaultFeatures(Player Client, int gender, bool reset = false)
        {
            if (reset)
            {
                CustomPlayerData[Client.Handle] = new PlayerCustomization();
                CustomPlayerData[Client.Handle].Gender = gender;

                CustomPlayerData[Client.Handle].Parents.Father = 0;
                CustomPlayerData[Client.Handle].Parents.Mother = 21;
                CustomPlayerData[Client.Handle].Parents.Similarity = (gender == 0) ? 1.0f : 0.0f;
                CustomPlayerData[Client.Handle].Parents.SkinSimilarity = (gender == 0) ? 1.0f : 0.0f;

                CustomPlayerData[Client.Handle].Hair.Hair = 0;
                CustomPlayerData[Client.Handle].Hair.HighlightColor = 0;
                CustomPlayerData[Client.Handle].Hair.Color = 0;

                CustomPlayerData[Client.Handle].EyebrowColor = 0;
                CustomPlayerData[Client.Handle].BeardColor = 0;
                CustomPlayerData[Client.Handle].EyeColor = 0;
                CustomPlayerData[Client.Handle].BlushColor = 0;
                CustomPlayerData[Client.Handle].LipstickColor = 0;
                CustomPlayerData[Client.Handle].MakeUp = 0;
                CustomPlayerData[Client.Handle].ChestHairColor = 0;


                for (int i = 0; i < CustomPlayerData[Client.Handle].Appearance.Length; i++)
                {
                    HeadOverlay headoverlay2 = new HeadOverlay();
                    headoverlay2.Index = 255;
                    headoverlay2.Color = 0;
                    headoverlay2.SecondaryColor = 0;
                    headoverlay2.Opacity = 1.0f;
                    NAPI.Player.SetPlayerHeadOverlay(Client, i, headoverlay2);
                }
            }
            ApplyCharacter(Client);
            SetCreatorClothes(Client, gender);
        }

        public static void SetCreatorClothes(Player Client, int gender)
        {
            if (!CustomPlayerData.ContainsKey(Client.Handle)) return;

            // clothes
            //Client.SetDefaultClothes();
            for (int i = 0; i < 10; i++) Client.ClearAccessory(i);

            if (gender == 0)
            {
                Client.SetClothes(3, 15, 0);
                Client.SetClothes(4, 21, 0);
                Client.SetClothes(6, 34, 0);
                Client.SetClothes(8, 15, 0);
                Client.SetClothes(11, 15, 0);
            }
            else
            {
                Client.SetClothes(3, 15, 0);
                Client.SetClothes(4, 10, 0);
                Client.SetClothes(6, 35, 0);
                Client.SetClothes(8, 15, 0);
                Client.SetClothes(11, 15, 0);
            }

            Client.SetClothes(2, CustomPlayerData[Client.Handle].Hair.Hair, 0);
        }
        #endregion

        #region Events
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            SAVE_DIRECTORY = NAPI.Resource.GetResourceFolder(this) + Path.DirectorySeparatorChar + SAVE_DIRECTORY;
            if (!Directory.Exists(SAVE_DIRECTORY)) Directory.CreateDirectory(SAVE_DIRECTORY);
        }

        public static void SaveCharacterFromCreation(Player Client, String name,sbyte age)
        {
            if (!CustomPlayerData.ContainsKey(Client.Handle)) return;
            if (age < 15 || age > 80)
            {
                Client.SendNotification(" Greska!~n~Morate imati najmanje 15 ili najvise 80 godina.");
                return;
            }
            if (Client.HasData("ChangedGender")) Client.ResetData("ChangedGender");
          


            Client.TriggerEvent("moveSkyCamera", Client, "up", 1, false);




            NAPI.Task.Run(() =>
             {
                if (NAPI.Player.IsPlayerConnected(Client))
                {
                 ApplyCharacter(Client);
                 Main.g_mysql_create_character(Client, name, age,Convert.ToString(API.Shared.ToJson(CustomPlayerData[Client.Handle])));
                 SendBackToWorld(Client);



                 Main.SavePlayerInformation(Client);
                }
             }, delayTime: 3000);

        }

        public static void UpdateVariables(Player Client)
        {
            OnClientOnRangeChange(Client, "range_base", Client.GetData<dynamic>("temp_base").ToString());
            OnClientOnRangeChange(Client, "range_base2", Client.GetData<dynamic>("temp_base2").ToString());
            OnClientOnRangeChange(Client, "range_baseblend", Client.GetData<dynamic>("temp_baseblend").ToString());
            OnClientOnRangeChange(Client, "range_skin", Client.GetData<dynamic>("temp_skin").ToString());
            OnClientOnRangeChange(Client, "range_eyes", Client.GetData<dynamic>("temp_eyes").ToString());
            OnClientOnRangeChange(Client, "range_hair", Client.GetData<dynamic>("temp_hair").ToString());
            OnClientOnRangeChange(Client, "range_haircolor", Client.GetData<dynamic>("temp_haircolor").ToString());
            OnClientOnRangeChange(Client, "range_haircolor2", Client.GetData<dynamic>("temp_hairhighlightcolor").ToString());
            OnClientOnRangeChange(Client, "range_eyebrows", Client.GetData<dynamic>("temp_eyebrows").ToString());
            OnClientOnRangeChange(Client, "range_beard", Client.GetData<dynamic>("temp_beard").ToString());

            for (int i = 0; i < 20; i++)
            {
                OnClientSetFaceFeature(Client, i, Client.GetData<dynamic>("temp_facefeature_" + i));
            }

            OnClientSetTraje(Client, Client.GetData<dynamic>("temp_traje"));
        }
        // Main UI
        public static void ShowPlayerCreator(Player Client, bool reset_variable = false)
        {
            if (reset_variable == true)
            {
                Client.SetData<dynamic>("temp_base", 0);
                Client.SetData<dynamic>("temp_base2", 0);
                Client.SetData<dynamic>("temp_baseblend", 5);
                Client.SetData<dynamic>("temp_skin", 5);
                Client.SetData<dynamic>("temp_eyes", 0);
                Client.SetData<dynamic>("temp_hair", 0);
                Client.SetData<dynamic>("temp_haircolor", 0);
                Client.SetData<dynamic>("temp_hairhighlightcolor", 0);
                Client.SetData<dynamic>("temp_eyebrows", 0);
                Client.SetData<dynamic>("temp_beard", 0);

                Client.SetData<dynamic>("temp_top", 0);
                Client.SetData<dynamic>("temp_pants", 0);
                Client.SetData<dynamic>("temp_shoes", 0);

                Client.SetData<dynamic>("temp_sex", 0);
                Client.SetData<dynamic>("temp_traje", 0);

                Client.SetData<dynamic>("temp_name", "");
                Client.SetData<dynamic>("temp_second_name", "");

                for (int i = 0; i <= 20; i++)
                {
                    Client.SetData<dynamic>("temp_facefeature_" + i, 10);
                }

            }

            List<dynamic> temp_array = new List<dynamic>();



            temp_array.Add(new
            {
                Forename = Client.GetData<dynamic>("temp_name"),
                Surname = Client.GetData<dynamic>("temp_second_name"),
                Gender = Client.GetData<dynamic>("temp_sex"),
                Base = Client.GetData<dynamic>("temp_base"),
                Base2 = Client.GetData<dynamic>("temp_base2"),
                BaseBlend = Client.GetData<dynamic>("temp_baseblend"),
                Skin = Client.GetData<dynamic>("temp_skin"),
                Eyes = Client.GetData<dynamic>("temp_eyes"),
                Hair = Client.GetData<dynamic>("temp_hair"),
                HairColor = Client.GetData<dynamic>("temp_haircolor"),
                HairHighlightColor = Client.GetData<dynamic>("temp_hairhighlightcolor"),
                Eyebrows = Client.GetData<dynamic>("temp_eyebrows"),
                Beard = Client.GetData<dynamic>("temp_beard")
            });


            Client.TriggerEvent("Show_Char_Creator", NAPI.Util.ToJson(temp_array));
            UpdateVariables(Client);
        }

        // Menu UI 2
        public static void ShowPlayerCreator_2(Player Client)
        {

            List<dynamic> temp_array = new List<dynamic>();

            for (int i = 0; i <= 20; i++)
            {
                temp_array.Add(new { FaceFeatures = Client.GetData<dynamic>("temp_facefeature_" + i) });
            }

            Client.TriggerEvent("Show_Char_Creator_2", NAPI.Util.ToJson(temp_array));
            UpdateVariables(Client);
        }

        // Menu UI 3
        public static void ShowPlayerCreator_3(Player Client)
        {

            List<dynamic> temp_array = new List<dynamic>();

            temp_array.Add(new
            {
                Traje = Client.GetData<dynamic>("temp_traje"),
                Top = Client.GetData<dynamic>("temp_top"),
                Pants = Client.GetData<dynamic>("temp_pants"),
                Shoes = Client.GetData<dynamic>("temp_shoes")
            });

            Client.TriggerEvent("Show_Char_Creator_3", NAPI.Util.ToJson(temp_array));

            UpdateVariables(Client);
        }

        [RemoteEvent("Display_Creator_part2")] // Display Chracter Menu UI 2
        public static void Events_Creator_Part2(Player Client, string name, string forname,sbyte age)
        {
            if (age < 15 || age > 80)
            {
                Client.SendNotification(" Greska!~n~Morate imati najmanje 15 ili najvise 80 godina.");
                return;
            }
            Client.SetData<dynamic>("temp_name", name);
            Client.SetData<dynamic>("temp_second_name", forname);
            Client.SetData<dynamic>("temp_age", age);

            Client.TriggerEvent("Destroy_Character_Menu");
            ShowPlayerCreator_2(Client);
        }

        [RemoteEvent("Display_Creator_part1")] // Back to Main Chracter Menu UI
        public static void Events_Creator_Part1(Player Client)
        {
            Client.TriggerEvent("Destroy_Character_Menu");

            ShowPlayerCreator(Client);
        }



        [RemoteEvent("Display_Creator_part3")] // Display Character Menu UI 3
        public static void Events_Creator_Part3(Player Client)
        {
            Client.TriggerEvent("Destroy_Character_Menu");
            ShowPlayerCreator_3(Client);
        }


        [RemoteEvent("ClientCharCreation3Back")] // Display Character Menu UI 2
        public static void ClientCharCreation3Back(Player Client)
        {
            Client.TriggerEvent("Destroy_Character_Menu");
            ShowPlayerCreator_2(Client);
        }

        [RemoteEvent("cameraPointTo")] // Display Character Menu UI 2
        public static void cameraPointTo(Player Client, int type)
        {
            if (type == 1)
            {
                Client.TriggerEvent("ps_SetCamera", 1);
            }
            else
            {
                Client.TriggerEvent("ps_SetCamera", 0);
            }
        }

        [RemoteEvent("ClientSetFaceFeature")]
        public static void OnClientSetFaceFeature(Player Client, int type, int valueIndex)
        {
            float new_value = 0.0f;
            switch (valueIndex)
            {
                case 0: new_value = -1.0f; break;
                case 1: new_value = -0.9f; break;
                case 2: new_value = -0.8f; break;
                case 3: new_value = -0.7f; break;
                case 4: new_value = -0.6f; break;
                case 5: new_value = -0.5f; break;
                case 6: new_value = -0.4f; break;
                case 7: new_value = -0.3f; break;
                case 8: new_value = -0.2f; break;
                case 9: new_value = -0.1f; break;
                case 10: new_value = 0.0f; break;
                case 11: new_value = -0.1f; break;
                case 12: new_value = -0.2f; break;
                case 13: new_value = -0.3f; break;
                case 14: new_value = -0.4f; break;
                case 15: new_value = -0.5f; break;
                case 16: new_value = -0.6f; break;
                case 17: new_value = -0.7f; break;
                case 18: new_value = -0.8f; break;
                case 19: new_value = -0.9f; break;
            }
            CustomPlayerData[Client.Handle].Features[type] = new_value;
            NAPI.Player.SetPlayerFaceFeature(Client, type, CustomPlayerData[Client.Handle].Features[type]);
            Client.SetData<dynamic>("temp_facefeature_" + type, valueIndex);
        }


        [RemoteEvent("ClientOnRangeChange")]
        public static void OnClientOnRangeChange(Player Client, string type, string valueIndex)
        {

            if (type == "range_gender")
            {
                int value = Convert.ToInt32(valueIndex);
                if (!CustomPlayerData.ContainsKey(Client.Handle)) { return; }

                int sex = 0;
                if (value == 0)
                {
                    Client.SetSkin(PedHash.FreemodeFemale01);
                    Client.SetSharedData("CHARACTER_ONLINE_GENRE", 1);
                    sex = 1;
                }
                else if (value == 1)
                {
                    Client.SetSkin(PedHash.FreemodeMale01);
                    Client.SetSharedData("CHARACTER_ONLINE_GENRE", 0);
                    sex = 0;
                }


                Client.SetData<dynamic>("ChangedGender", true);
                SetDefaultFeatures(Client, sex, true);
                Client.SetData<dynamic>("temp_sex", value);

                UpdateVariables(Client);
            }
            else if (type == "range_base")
            {
                int value = Convert.ToInt32(valueIndex);
                CustomPlayerData[Client.Handle].Parents.Mother = value + 20;
                ApplyCharacterPreview(Client);
                Client.SetData<dynamic>("temp_base", value);
            }
            else if (type == "range_base2")
            {
                int value = Convert.ToInt32(valueIndex);
                CustomPlayerData[Client.Handle].Parents.Father = value;
                ApplyCharacterPreview(Client);
                Client.SetData<dynamic>("temp_base2", value);
            }
            else if (type == "range_baseblend")
            {
                int value = Convert.ToInt32(valueIndex);
                float new_value = 0.0f;
                if (value > 9) return;
                switch (value)
                {
                    case 0: new_value = 0.0f; break;
                    case 1: new_value = 0.1f; break;
                    case 2: new_value = 0.2f; break;
                    case 3: new_value = 0.3f; break;
                    case 4: new_value = 0.4f; break;
                    case 5: new_value = 0.5f; break;
                    case 6: new_value = 0.6f; break;
                    case 7: new_value = 0.7f; break;
                    case 8: new_value = 0.8f; break;
                    case 9: new_value = 0.9f; break;
                }
                CustomPlayerData[Client.Handle].Parents.Similarity = new_value;
                ApplyCharacterPreview(Client);
                Client.SetData<dynamic>("temp_baseblend", value);
            }
            else if (type == "range_skin")
            {
                int value = Convert.ToInt32(valueIndex);
                if (value > 9) return;
                float new_value = 0.0f;
                switch (value)
                {
                    case 0: new_value = 0.0f; break;
                    case 1: new_value = 0.1f; break;
                    case 2: new_value = 0.2f; break;
                    case 3: new_value = 0.3f; break;
                    case 4: new_value = 0.4f; break;
                    case 5: new_value = 0.5f; break;
                    case 6: new_value = 0.6f; break;
                    case 7: new_value = 0.7f; break;
                    case 8: new_value = 0.8f; break;
                    case 9: new_value = 0.9f; break;
                }
                CustomPlayerData[Client.Handle].Parents.SkinSimilarity = new_value;
                ApplyCharacterPreview(Client);
                Client.SetData<dynamic>("temp_skin", value);
            }
            else if (type == "range_eyes")
            {
                int value = Convert.ToInt32(valueIndex);
                CustomPlayerData[Client.Handle].EyeColor = (byte)value;
                NAPI.Player.SetPlayerEyeColor(Client, (byte)CustomPlayerData[Client.Handle].EyeColor);
                Client.SetData<dynamic>("temp_eyes", value);
            }
            else if (type == "range_hair")
            {
                int value = Convert.ToInt32(valueIndex);
                if (value > 72) return;
                if (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE") == 0)
                {
                    CustomPlayerData[Client.Handle].Hair.Hair = Convert.ToInt32(hair_style_male[value]);
                    Client.SetClothes(2, CustomPlayerData[Client.Handle].Hair.Hair, 0);
                }
                else
                {
                    CustomPlayerData[Client.Handle].Hair.Hair = Convert.ToInt32(hair_style_female[value]);
                    Client.SetClothes(2, CustomPlayerData[Client.Handle].Hair.Hair, 0);
                }
                Client.SetData<dynamic>("temp_hair", value);
            }
            else if (type == "range_haircolor")
            {
                int value = Convert.ToInt32(valueIndex);
                if (value > 30) return;
                CustomPlayerData[Client.Handle].Hair.Color = value;
                NAPI.Player.SetPlayerHairColor(Client, (byte)CustomPlayerData[Client.Handle].Hair.Color, (byte)CustomPlayerData[Client.Handle].Hair.HighlightColor);
                Client.SetData<dynamic>("temp_haircolor", value);
            }
            else if (type == "range_haircolor2")
            {
                int value = Convert.ToInt32(valueIndex);
                CustomPlayerData[Client.Handle].Hair.HighlightColor = value;
                NAPI.Player.SetPlayerHairColor(Client, (byte)CustomPlayerData[Client.Handle].Hair.Color, (byte)CustomPlayerData[Client.Handle].Hair.HighlightColor);
                Client.SetData<dynamic>("temp_hairhighlightcolor", value);
            }
            else if (type == "range_beard")
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 1;
                if (value == 0) CustomPlayerData[Client.Handle].Appearance[index].Value = 255;
                else CustomPlayerData[Client.Handle].Appearance[index].Value = value - 1;
                headoverlay2.Index = (byte)CustomPlayerData[Client.Handle].Appearance[index].Value;
                headoverlay2.Color = (byte)CustomPlayerData[Client.Handle].Appearance[index].Color;
                headoverlay2.Opacity = CustomPlayerData[Client.Handle].Appearance[index].Opacity;
                NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
                Client.SetData<dynamic>("temp_beard", value);
            }
            else if (type == "range_eyebrows")
            {
                int value = Convert.ToInt32(valueIndex);
                HeadOverlay headoverlay2 = new HeadOverlay();
                int index = 2;
                if (value == 0) CustomPlayerData[Client.Handle].Appearance[index].Value = 255;
                else CustomPlayerData[Client.Handle].Appearance[index].Value = value - 1;
                headoverlay2.Index = (byte)CustomPlayerData[Client.Handle].Appearance[index].Value;
                headoverlay2.Color = (byte)CustomPlayerData[Client.Handle].Appearance[index].Color;
                headoverlay2.Opacity = CustomPlayerData[Client.Handle].Appearance[index].Opacity;
                NAPI.Player.SetPlayerHeadOverlay(Client, index, headoverlay2);
                Client.SetData<dynamic>("temp_eyebrows", value);
            }
            else if (type == "range_rotation")
            {
                int value = Convert.ToInt32(valueIndex);
                Client.Rotation = new Vector3(0, 0, float.Parse(valueIndex));
            }
            else if (type == "range_elevation")
            {

            }
        }

        [RemoteEvent("ClientSetTraje")]
        public static void OnClientSetTraje(Player Client, int valueIndex)
        {
            Client.SetData<dynamic>("creator_outfit", valueIndex);
            Client.SetData<dynamic>("temp_traje", valueIndex);
            switch (valueIndex)
            {
                case 0:
                    {
                        if (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE") == 0)
                        {
                            Client.SetClothes(3, 15, 0);
                            Client.SetClothes(4, 21, 0);
                            Client.SetClothes(6, 34, 0);
                            Client.SetClothes(8, 15, 0);
                            Client.SetClothes(11, 15, 0);
                        }
                        else
                        {
                            Client.SetClothes(3, 15, 0);
                            Client.SetClothes(4, 10, 0);
                            Client.SetClothes(6, 35, 0);
                            Client.SetClothes(8, 15, 0);
                            Client.SetClothes(11, 15, 0);
                        }
                        break;
                    }
                case 1:
                    Outfits.SetUnisexOutfit(Client, 1, true);
                    break;
                case 2:
                    Outfits.SetUnisexOutfit(Client, 2, true);
                    break;
                case 3:
                    Outfits.SetUnisexOutfit(Client, 3, true);
                    break;
                case 4:
                    Outfits.SetUnisexOutfit(Client, 4, true);
                    break;
                case 5:
                    Outfits.SetUnisexOutfit(Client, 5, true);
                    break;
                case 6:
                    Outfits.SetUnisexOutfit(Client, 6, true);
                    break;
                case 7:
                    Outfits.SetUnisexOutfit(Client, 7, true);
                    break;
                case 8:
                    Outfits.SetUnisexOutfit(Client, 8, true);
                    break;
                case 9:
                    Outfits.SetUnisexOutfit(Client, 9, true);
                    break;
                case 10:
                    Outfits.SetUnisexOutfit(Client, 10, true);
                    break;
                case 11:
                    Outfits.SetUnisexOutfit(Client, 11, true);
                    break;
                case 12:
                    Outfits.SetUnisexOutfit(Client, 12, true);
                    break;
            }
        }

        [RemoteEvent("ClientCharCreationBack")]
        public static void ClientCharCreationBack(Player Client)
        {
            Client.TriggerEvent("Destroy_Character_Menu");
            AccountManage.CharacterSelection(Client);
        }

        [RemoteEvent("ClientCharCreation3Next")]
        public static void Proccess_Character(Player Client)
        {

            // string mamad = "nima";
            // mamad.ToUpper().Substring(0);
            char[] name = Client.GetData<dynamic>("temp_name").ToCharArray();
            char[] lastname = Client.GetData<dynamic>("temp_second_name").ToCharArray();
            sbyte age = Client.GetData<dynamic>("temp_age");
            if (name[0] != null)
            {
                name[0] = char.ToUpper(name[0]);
            }
            if (lastname[0] != null)
            {
                lastname[0] = char.ToUpper(lastname[0]);
            }
          


            string inputtext = new string(name) + "_" + new string(lastname);




            
            if (inputtext.Length > 24)
            {
                Client.SendNotification("Greska!~n~Ime i prezime moraju imati izmedju 6 i 24 SLOVA.");
                return;
            }
            if (age < 15 || age > 79)
            {
                Client.SendNotification("Greska!~n~Mozete imati najmanje 15 ili najvise 80 godina.");
                return;
            }

            if (inputtext.Contains(" "))
            {
                Client.SendNotification("Greska!~n~Obrisite razmak u imenu i prezimenu.");
                return;
            }

            if (Utils.isRoleplayName(inputtext) == true)
            {
                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                {
                    Mainpipeline.Open();
                    MySqlCommand query = Mainpipeline.CreateCommand();
                    query.CommandType = CommandType.Text;
                    query.CommandText = "SELECT * FROM `characters` WHERE `name` = '" + inputtext + "'";
                    query.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query))
                    {
                        da.Fill(dt);
                        int i = 0;
                        i = Convert.ToInt32(dt.Rows.Count.ToString());
                        if (i == 0)
                        {
                            Client.TriggerEvent("Destroy_Character_Menu");
                            SaveCharacterFromCreation(Client, inputtext,age);
                        }
                        else
                        {
                            Client.SendNotification("Greska!~n~Ovo ime vec postoji.");
                            //InteractMenu.User_Input(Client, "interact_character_newname", "Nome do Personagem (Ex: Thiago_Gomes)", "Thiago_Gomes");
                        }
                    }
                    Mainpipeline.Close();
                }

            }
            else
            {
                Client.SendNotification("Greska!~n~Vase ime mora biti u formatu: ~y~Petar_Petrovic");
                //InteractMenu.User_Input(Client, "interact_character_newname", "Nome do Personagem (Ex: Thiago_Gomes)", "Thiago_Gomes");
            }
        }



        [ServerEvent(Event.PlayerDisconnected)]
        public void OnPlayerDisconnected(Player Client, DisconnectionType type, string reason)
        {
            if (CustomPlayerData.ContainsKey(Client.Handle)) CustomPlayerData.Remove(Client.Handle);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            foreach (Player Player in NAPI.Pools.GetAllPlayers())
            {
                if (Player.HasData("Creator_PrevPos"))
                {
                    Player.Dimension = 0;
                    NAPI.Entity.SetEntityPosition(Player, (Vector3)Player.GetData<dynamic>("Creator_PrevPos"));

                    Player.TriggerEvent("DestroyCamera");
                    Player.ResetData("Creator_PrevPos");
                }
            }

            CustomPlayerData.Clear();
        }
        #endregion

        #region Commands
        /*[Command("creator")]
        public void CMD_EnableCreator(Player Client)
        {
            if (!(Client.Model == (int)PedHash.FreemodeMale01))
            {
                Main.SendCustomChatMessasge(Client,"You need to have a freemode character skin.");
                return;
            }

            SendToCreator(Client);
        }*/
        #endregion
    }
}