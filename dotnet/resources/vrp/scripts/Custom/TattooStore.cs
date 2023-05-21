using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using CharCreator;

class TattoBusiness :Script
{
    // public static List<BusinessTattoo> BusinessTattoos = new List<BusinessTattoo>();

    public TattoBusiness()
    {

    }

    /* [RemoteEvent("buyTattoo")]
     public static void RemoteEvent_buyTattoo(Player Client, params object[] arguments)
     {
         try
         {
             var zone = Convert.ToInt32(arguments[0].ToString());
             var tattooID = Convert.ToInt32(arguments[1].ToString());
             var tattoo = BusinessTattoos[zone][tattooID];

             int percentagem = 30;

             double price = tattoo.Price / 100.0 * percentagem;
             if (Main.GetPlayerMoney(Client) < Convert.ToInt32(price))
             {
                 InteractMenu_New.SendNotificationError(Client,"Dinheiro insuficiente");
                 return;
             }

             var amount = Convert.ToInt32(price * 0.75 / 100);
             if (amount <= 0) amount = 1;


             Main.GivePlayerMoney(Client, -Convert.ToInt32(price));

             var tattooHash = (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE")) ? tattoo.MaleHash : tattoo.FemaleHash;
             List<CharCreator.Tattoo> validTattoos = new List<CharCreator.Tattoo>();
             foreach (var t in CharCreator.CharCreator.CustomPlayerData[Client.Handle].Tattoos[zone])
             {
                 var isValid = true;
                 foreach (var slot in tattoo.Slots)
                 {
                     if (t.Slots.Contains(slot))
                     {
                         isValid = false;
                         break;
                     }
                 }
                 if (isValid) validTattoos.Add(t);
             }

             validTattoos.Add(new CharCreator.Tattoo(tattoo.Dictionary, tattooHash, tattoo.Slots));
             CharCreator.CharCreator.CustomPlayerData[Client.Handle].Tattoos[zone] = validTattoos;

             Client.SetSharedData("TATTOOS", JsonConvert.SerializeObject(CharCreator.CharCreator.CustomPlayerData[Client.Handle].Tattoos));

            
         }
         catch (Exception e) { //Console.Write("BuyTattoo: " + e.Message); }
     }*/


    public class BusinessTattoo
    {
        public List<int> Slots { get; set; }
        public string Name { get; set; }
        public string Dictionary { get; set; }
        public string MaleHash { get; set; }
        public string FemaleHash { get; set; }
        public int Price { get; set; }

        public BusinessTattoo(List<int> slots, string name, string dictionary, string malehash, string femalehash, int price)
        {
            Slots = slots;
            Name = name;
            Dictionary = dictionary;
            MaleHash = malehash;
            FemaleHash = femalehash;
            Price = price;
        }
    }


    public static void CreateListsIfNull(Player Client)
    {
        var currentCharacter = CharCreator.CharCreator.CustomPlayerData[Client.Handle];
        if (currentCharacter.PedTatttoos.HeadTattoos == null)
        {
            currentCharacter.PedTatttoos.HeadTattoos = new List<KeyValuePair<string, string>>();
        }
        if (currentCharacter.PedTatttoos.TorsoTattoos == null)
        {
            currentCharacter.PedTatttoos.TorsoTattoos = new List<KeyValuePair<string, string>>();
        }
        if (currentCharacter.PedTatttoos.LeftArmTattoos == null)
        {
            currentCharacter.PedTatttoos.LeftArmTattoos = new List<KeyValuePair<string, string>>();
        }
        if (currentCharacter.PedTatttoos.RightArmTattoos == null)
        {
            currentCharacter.PedTatttoos.RightArmTattoos = new List<KeyValuePair<string, string>>();
        }
        if (currentCharacter.PedTatttoos.LeftLegTattoos == null)
        {
            currentCharacter.PedTatttoos.LeftLegTattoos = new List<KeyValuePair<string, string>>();
        }
        if (currentCharacter.PedTatttoos.RightLegTattoos == null)
        {
            currentCharacter.PedTatttoos.RightLegTattoos = new List<KeyValuePair<string, string>>();
        }
        if (currentCharacter.PedTatttoos.BadgeTattoos == null)
        {
            currentCharacter.PedTatttoos.BadgeTattoos = new List<KeyValuePair<string, string>>();
        }
    }

    public static void ApplySavedTattoos(Player Client)
    {
        if (!CharCreator.CharCreator.CustomPlayerData.ContainsKey(Client.Handle)) return;
        var currentCharacter = CharCreator.CharCreator.CustomPlayerData[Client.Handle];
        // remove all decorations, and then manually re-add them all. what a retarded way of doing this R*....
        Client.ClearDecorations();
        CreateListsIfNull(Client);
        try
        {
            foreach (var tattoo in currentCharacter.PedTatttoos.HeadTattoos)
            {
                var decoration = new Decoration();
                decoration.Collection = NAPI.Util.GetHashKey(tattoo.Key);
                decoration.Overlay = NAPI.Util.GetHashKey(tattoo.Value);
                Client.SetDecoration(decoration);
            }
            foreach (var tattoo in currentCharacter.PedTatttoos.TorsoTattoos)
            {
                var decoration = new Decoration();
                decoration.Collection = NAPI.Util.GetHashKey(tattoo.Key);
                decoration.Overlay = NAPI.Util.GetHashKey(tattoo.Value);
                Client.SetDecoration(decoration);
            }
            foreach (var tattoo in currentCharacter.PedTatttoos.LeftArmTattoos)
            {
                var decoration = new Decoration();
                decoration.Collection = NAPI.Util.GetHashKey(tattoo.Key);
                decoration.Overlay = NAPI.Util.GetHashKey(tattoo.Value);
                Client.SetDecoration(decoration);
            }
            foreach (var tattoo in currentCharacter.PedTatttoos.RightArmTattoos)
            {
                var decoration = new Decoration();
                decoration.Collection = NAPI.Util.GetHashKey(tattoo.Key);
                decoration.Overlay = NAPI.Util.GetHashKey(tattoo.Value);
                Client.SetDecoration(decoration);
            }
            foreach (var tattoo in currentCharacter.PedTatttoos.LeftLegTattoos)
            {
                var decoration = new Decoration();
                decoration.Collection = NAPI.Util.GetHashKey(tattoo.Key);
                decoration.Overlay = NAPI.Util.GetHashKey(tattoo.Value);
                Client.SetDecoration(decoration);
            }
            foreach (var tattoo in currentCharacter.PedTatttoos.RightLegTattoos)
            {
                var decoration = new Decoration();
                decoration.Collection = NAPI.Util.GetHashKey(tattoo.Key);
                decoration.Overlay = NAPI.Util.GetHashKey(tattoo.Value);
                Client.SetDecoration(decoration);
            }
            foreach (var tattoo in currentCharacter.PedTatttoos.BadgeTattoos)
            {
                var decoration = new Decoration();
                decoration.Collection = NAPI.Util.GetHashKey(tattoo.Key);
                decoration.Overlay = NAPI.Util.GetHashKey(tattoo.Value);
                Client.SetDecoration(decoration);
            }
        }
        catch
        {

        }

    }

 //   [Command("showtatto")]
    public static void ShowTattoo(Player Client,bool fal = true)
    {

        List<dynamic> menu_item_list = new List<dynamic>();
        //var tattooIds = ["torso", "head", "leftarm", "rightarm", "leftleg", "rightleg"];




        List<string> headTattoosList = new List<string>();
        List<string> torsoTattoosList = new List<string>();
        List<string> leftArmTattoosList = new List<string>();
        List<string> rightArmTattoosList = new List<string>();
        List<string> leftLegTattoosList = new List<string>();
        List<string> rightLegTattoosList = new List<string>();
        List<string> badgeTattoosList = new List<string>();


        if (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE") == 0)
        {
            int counter = 1;
            foreach (var tattoo in TattooInfo.MaleTattoosCollection.HEAD)
            {
                headTattoosList.Add($"Tetovaza #{counter} (of {TattooInfo.MaleTattoosCollection.HEAD.Count})");
                counter++;
            }
            counter = 1;
            foreach (var tattoo in TattooInfo.MaleTattoosCollection.TORSO)
            {
                torsoTattoosList.Add($"Tetovaza #{counter} (of {TattooInfo.MaleTattoosCollection.TORSO.Count})");
                counter++;
            }
            counter = 1;
            foreach (var tattoo in TattooInfo.MaleTattoosCollection.LEFT_ARM)
            {
                leftArmTattoosList.Add($"Tetovaza #{counter} (of {TattooInfo.MaleTattoosCollection.LEFT_ARM.Count})");
                counter++;
            }
            counter = 1;
            foreach (var tattoo in TattooInfo.MaleTattoosCollection.RIGHT_ARM)
            {
                rightArmTattoosList.Add($"Tetovaza #{counter} (of {TattooInfo.MaleTattoosCollection.RIGHT_ARM.Count})");
                counter++;
            }
            counter = 1;
            foreach (var tattoo in TattooInfo.MaleTattoosCollection.LEFT_LEG)
            {
                leftLegTattoosList.Add($"Tetovaza #{counter} (of {TattooInfo.MaleTattoosCollection.LEFT_LEG.Count})");
                counter++;
            }
            counter = 1;
            foreach (var tattoo in TattooInfo.MaleTattoosCollection.RIGHT_LEG)
            {
                rightLegTattoosList.Add($"Tetovaza #{counter} (of {TattooInfo.MaleTattoosCollection.RIGHT_LEG.Count})");
                counter++;
            }
            counter = 1;
            foreach (var tattoo in TattooInfo.MaleTattoosCollection.BADGES)
            {
                badgeTattoosList.Add($"Oznake #{counter} (of {TattooInfo.MaleTattoosCollection.BADGES.Count})");
                counter++;
            }
        }
        else
        {
            int counter = 1;
            foreach (var tattoo in TattooInfo.FemaleTattoosCollection.HEAD)
            {
                headTattoosList.Add($"Tetovaza #{counter} (of {TattooInfo.FemaleTattoosCollection.HEAD.Count})");
                counter++;
            }
            counter = 1;
            foreach (var tattoo in TattooInfo.FemaleTattoosCollection.TORSO)
            {
                torsoTattoosList.Add($"Tetovaza #{counter} (of {TattooInfo.FemaleTattoosCollection.TORSO.Count})");
                counter++;
            }
            counter = 1;
            foreach (var tattoo in TattooInfo.FemaleTattoosCollection.LEFT_ARM)
            {
                leftArmTattoosList.Add($"Tetovaza #{counter} (of {TattooInfo.FemaleTattoosCollection.LEFT_ARM.Count})");
                counter++;
            }
            counter = 1;
            foreach (var tattoo in TattooInfo.FemaleTattoosCollection.RIGHT_ARM)
            {
                rightArmTattoosList.Add($"Tetovaza #{counter} (of {TattooInfo.FemaleTattoosCollection.RIGHT_ARM.Count})");
                counter++;
            }
            counter = 1;
            foreach (var tattoo in TattooInfo.FemaleTattoosCollection.LEFT_LEG)
            {
                leftLegTattoosList.Add($"Tetovaza #{counter} (of {TattooInfo.FemaleTattoosCollection.LEFT_LEG.Count})");
                counter++;
            }
            counter = 1;
            foreach (var tattoo in TattooInfo.FemaleTattoosCollection.RIGHT_LEG)
            {
                rightLegTattoosList.Add($"Tetovaza #{counter} (of {TattooInfo.FemaleTattoosCollection.RIGHT_LEG.Count})");
                counter++;
            }
            counter = 1;
            foreach (var tattoo in TattooInfo.FemaleTattoosCollection.BADGES)
            {
                badgeTattoosList.Add($"Oznake #{counter} (of {TattooInfo.FemaleTattoosCollection.BADGES.Count})");
                counter++;
            }
        }

        Client.SetData<dynamic>("tattooIndex", 0);
        /*            const string tatDesc = "Cycle through the list to preview tattoos. If you like one, press enter to select it, selecting it will add the tattoo if you don't already have it. If you already have that tattoo then the tattoo will be removed.";
            MenuListItem headTatts = new MenuListItem("Head Tattoos", headTattoosList, 0, tatDesc);
            MenuListItem torsoTatts = new MenuListItem("Torso Tattoos", torsoTattoosList, 0, tatDesc);
            MenuListItem leftArmTatts = new MenuListItem("Left Arm Tattoos", leftArmTattoosList, 0, tatDesc);
            MenuListItem rightArmTatts = new MenuListItem("Right Arm Tattoos", rightArmTattoosList, 0, tatDesc);
            MenuListItem leftLegTatts = new MenuListItem("Left Leg Tattoos", leftLegTattoosList, 0, tatDesc);
            MenuListItem rightLegTatts = new MenuListItem("Right Leg Tattoos", rightLegTattoosList, 0, tatDesc);
            MenuListItem badgeTatts = new MenuListItem("Oznake  Overlays", badgeTattoosList, 0, tatDesc);
*/
        const string tatDesc = "Prolaskom kroz lisu, mozete videti izlged tetovaze. Potvrdjivanjem cete automatski kupiti tetovazu. Ako vec imate tetovazu na tom mestu, ona ce biti obrisana.";

        menu_item_list.Add(new { Type = 2, Name = "Glava", Description = tatDesc, List = headTattoosList, StartIndex = 0 });
        menu_item_list.Add(new { Type = 2, Name = "Stomak", Description = tatDesc, List = torsoTattoosList, StartIndex = 0 });
        menu_item_list.Add(new { Type = 2, Name = "Leva ruka", Description = tatDesc, List = leftArmTattoosList, StartIndex = 0 });
        menu_item_list.Add(new { Type = 2, Name = "Desna ruka", Description = tatDesc, List = rightArmTattoosList, StartIndex = 0 });
        menu_item_list.Add(new { Type = 2, Name = "Leva noga", Description = tatDesc, List = leftLegTattoosList, StartIndex = 0 });
        menu_item_list.Add(new { Type = 2, Name = "Desna noga", Description = tatDesc, List = rightLegTattoosList, StartIndex = 0 });
        menu_item_list.Add(new { Type = 2, Name = "Posebne oznake", Description = tatDesc, List = badgeTattoosList, StartIndex = 0 });
        menu_item_list.Add(new { Type = 1, Name = "Obrisi tetovaze", Description = "Obrisi sve tetovaze" });

        InteractMenu.CreateMenu(Client, "TATTOO_STORE", "", "~g~Tatto salon (Cena за Tetovaza: $500)", true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_tattoos", CurrentSelect: 1,MouseControl:true);

        if (fal)
        {
            UsefullyRP.CMD_TOP_off(Client);
            UsefullyRP.CMD_Pants_off(Client);
            UsefullyRP.CMD_Acc_off(Client);
        }
       
        //Client.TriggerEvent("openTattoo", 100);
    }

    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "TATTOO_STORE")
        {
            bool IsMale = false;

            int tattooIndex = Client.GetData<dynamic>("tattooIndex");

            if (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE") == 0) IsMale = true;
            else IsMale = false;

            var currentCharacter = CharCreator.CharCreator.CustomPlayerData[Client.Handle];
            CreateListsIfNull(Client);

            int business_id = BusinessManage.GetPlayerInBusinessInType(Client, 12);
            if (business_id == -1)
            {
                CreateListsIfNull(Client);
                ApplySavedTattoos(Client);
                return;
            }

            if (Main.GetPlayerMoney(Client) < 500)
            {
                CreateListsIfNull(Client);
                ApplySavedTattoos(Client);
                Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                return;
            }


            


            Main.GivePlayerMoney(Client, -500);

            if (selectedIndex == 0) // head
            {
                var Tattoo = IsMale ? TattooInfo.MaleTattoosCollection.HEAD.ElementAt(tattooIndex) : TattooInfo.FemaleTattoosCollection.HEAD.ElementAt(tattooIndex);
                KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                if (currentCharacter.PedTatttoos.HeadTattoos.Contains(tat))
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Tetovaza #{tattooIndex + 1} je ~r~obrisana~s~.");
                    currentCharacter.PedTatttoos.HeadTattoos.Remove(tat);



                }
                else
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Tetovaza #{tattooIndex + 1} je ~g~stavljena~s~.");
                    currentCharacter.PedTatttoos.HeadTattoos.Add(tat);
                }
            }
            else if (selectedIndex == 1) // torso
            {
                var Tattoo = IsMale ? TattooInfo.MaleTattoosCollection.TORSO.ElementAt(tattooIndex) : TattooInfo.FemaleTattoosCollection.TORSO.ElementAt(tattooIndex);
                KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                if (currentCharacter.PedTatttoos.TorsoTattoos.Contains(tat))
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Tetovaza #{tattooIndex + 1} je ~r~obrisana~s~.");
                    currentCharacter.PedTatttoos.TorsoTattoos.Remove(tat);
                }
                else
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Tetovaza #{tattooIndex + 1} je ~g~stavljena~s~.");
                    currentCharacter.PedTatttoos.TorsoTattoos.Add(tat);
                }
            }
            else if (selectedIndex == 2) // left arm
            {
                var Tattoo = IsMale ? TattooInfo.MaleTattoosCollection.LEFT_ARM.ElementAt(tattooIndex) : TattooInfo.FemaleTattoosCollection.LEFT_ARM.ElementAt(tattooIndex);
                KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                if (currentCharacter.PedTatttoos.LeftArmTattoos.Contains(tat))
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Tetovaza #{tattooIndex + 1} je ~r~obrisana~s~.");
                    currentCharacter.PedTatttoos.LeftArmTattoos.Remove(tat);
                }
                else
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Tetovaza #{tattooIndex + 1} je ~g~stavljena~s~.");
                    currentCharacter.PedTatttoos.LeftArmTattoos.Add(tat);
                }
            }
            else if (selectedIndex == 3) // right arm
            {
                var Tattoo = IsMale ? TattooInfo.MaleTattoosCollection.RIGHT_ARM.ElementAt(tattooIndex) : TattooInfo.FemaleTattoosCollection.RIGHT_ARM.ElementAt(tattooIndex);
                KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                if (currentCharacter.PedTatttoos.RightArmTattoos.Contains(tat))
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Tetovaza #{tattooIndex + 1} je ~r~obrisana~s~.");
                    currentCharacter.PedTatttoos.RightArmTattoos.Remove(tat);
                }
                else
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Tetovaza #{tattooIndex + 1} je ~g~stavljena~s~.");
                    currentCharacter.PedTatttoos.RightArmTattoos.Add(tat);
                }
            }
            else if (selectedIndex == 4) // left leg
            {
                var Tattoo = IsMale ? TattooInfo.MaleTattoosCollection.LEFT_LEG.ElementAt(tattooIndex) : TattooInfo.FemaleTattoosCollection.LEFT_LEG.ElementAt(tattooIndex);
                KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                if (currentCharacter.PedTatttoos.LeftLegTattoos.Contains(tat))
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Tetovaza #{tattooIndex + 1} je ~r~obrisana~s~.");
                    currentCharacter.PedTatttoos.LeftLegTattoos.Remove(tat);
                }
                else
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Tetovaza #{tattooIndex + 1} je ~g~stavljena~s~.");
                    currentCharacter.PedTatttoos.LeftLegTattoos.Add(tat);
                }
            }
            else if (selectedIndex == 5) // right leg
            {
                var Tattoo = IsMale ? TattooInfo.MaleTattoosCollection.RIGHT_LEG.ElementAt(tattooIndex) : TattooInfo.FemaleTattoosCollection.RIGHT_LEG.ElementAt(tattooIndex);
                KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                if (currentCharacter.PedTatttoos.RightLegTattoos.Contains(tat))
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Tetovaza #{tattooIndex + 1} je ~r~obrisana~s~.");
                    currentCharacter.PedTatttoos.RightLegTattoos.Remove(tat);
                }
                else
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Tetovaza #{tattooIndex + 1} je ~g~stavljena~s~.");
                    currentCharacter.PedTatttoos.RightLegTattoos.Add(tat);
                }
            }
            else if (selectedIndex == 6) // badges
            {
                var Tattoo = IsMale ? TattooInfo.MaleTattoosCollection.BADGES.ElementAt(tattooIndex) : TattooInfo.FemaleTattoosCollection.BADGES.ElementAt(tattooIndex);
                KeyValuePair<string, string> tat = new KeyValuePair<string, string>(Tattoo.collectionName, Tattoo.name);
                if (currentCharacter.PedTatttoos.BadgeTattoos.Contains(tat))
                {

                    InteractMenu_New.SendNotificationInfo(Client, $"Oznake  #{tattooIndex + 1} je ~r~obrisana~s~.");
                    currentCharacter.PedTatttoos.BadgeTattoos.Remove(tat);
                }
                else
                {
                    InteractMenu_New.SendNotificationInfo(Client, $"Oznake  #{tattooIndex + 1} je ~g~stavljena~s~.");
                    currentCharacter.PedTatttoos.BadgeTattoos.Add(tat);
                }
            }
            else if (selectedIndex == 7) // Remove Tattos
            {
                CharCreator.CharCreator.CustomPlayerData[Client.Handle].PedTatttoos = new CharCreator.PedTattoos();
               
            }
            ShowTattoo(Client,false);
            CharCreator.CharCreator.SaveChar(Client);
        }
    }

    public static void ListItemMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
        if (callbackId == "TATTOO_STORE")
        {
            //  Client.ClearDecorations();
            Client.SetData<dynamic>("tattooIndex", valueIndex);

            CreateListsIfNull(Client);
            ApplySavedTattoos(Client);
            switch (selectedIndex)
            {

                case 0:
                    {
                        if (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE") == 0)
                        {

                            var decoration = new Decoration();
                            decoration.Collection = NAPI.Util.GetHashKey(TattooInfo.MaleTattoosCollection.HEAD[valueIndex].collectionName);
                            decoration.Overlay = NAPI.Util.GetHashKey(TattooInfo.MaleTattoosCollection.HEAD[valueIndex].name);
                            Client.SetDecoration(decoration);
                        }
                        else
                        {
                            var decoration = new Decoration();
                            decoration.Collection = NAPI.Util.GetHashKey(TattooInfo.FemaleTattoosCollection.HEAD[valueIndex].collectionName);
                            decoration.Overlay = NAPI.Util.GetHashKey(TattooInfo.FemaleTattoosCollection.HEAD[valueIndex].name);
                            Client.SetDecoration(decoration);
                        }
                        break;
                    }
                case 1:
                    {
                        if (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE") == 0)
                        {

                            var decoration = new Decoration();
                            decoration.Collection = NAPI.Util.GetHashKey(TattooInfo.MaleTattoosCollection.TORSO[valueIndex].collectionName);
                            decoration.Overlay = NAPI.Util.GetHashKey(TattooInfo.MaleTattoosCollection.TORSO[valueIndex].name);
                            Client.SetDecoration(decoration);
                        }
                        else
                        {
                            var decoration = new Decoration();
                            decoration.Collection = NAPI.Util.GetHashKey(TattooInfo.FemaleTattoosCollection.TORSO[valueIndex].collectionName);
                            decoration.Overlay = NAPI.Util.GetHashKey(TattooInfo.FemaleTattoosCollection.TORSO[valueIndex].name);
                            Client.SetDecoration(decoration);
                        }
                        break;
                    }
                case 2:
                    {
                        if (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE") == 0)
                        {

                            var decoration = new Decoration();
                            decoration.Collection = NAPI.Util.GetHashKey(TattooInfo.MaleTattoosCollection.LEFT_ARM[valueIndex].collectionName);
                            decoration.Overlay = NAPI.Util.GetHashKey(TattooInfo.MaleTattoosCollection.LEFT_ARM[valueIndex].name);
                            Client.SetDecoration(decoration);
                        }
                        else
                        {
                            var decoration = new Decoration();
                            decoration.Collection = NAPI.Util.GetHashKey(TattooInfo.FemaleTattoosCollection.LEFT_ARM[valueIndex].collectionName);
                            decoration.Overlay = NAPI.Util.GetHashKey(TattooInfo.FemaleTattoosCollection.LEFT_ARM[valueIndex].name);
                            Client.SetDecoration(decoration);
                        }
                        break;
                    }
                case 3:
                    {
                        if (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE") == 0)
                        {

                            var decoration = new Decoration();
                            decoration.Collection = NAPI.Util.GetHashKey(TattooInfo.MaleTattoosCollection.RIGHT_ARM[valueIndex].collectionName);
                            decoration.Overlay = NAPI.Util.GetHashKey(TattooInfo.MaleTattoosCollection.RIGHT_ARM[valueIndex].name);
                            Client.SetDecoration(decoration);
                        }
                        else
                        {
                            var decoration = new Decoration();
                            decoration.Collection = NAPI.Util.GetHashKey(TattooInfo.FemaleTattoosCollection.RIGHT_ARM[valueIndex].collectionName);
                            decoration.Overlay = NAPI.Util.GetHashKey(TattooInfo.FemaleTattoosCollection.RIGHT_ARM[valueIndex].name);
                            Client.SetDecoration(decoration);
                        }
                        break;
                    }
                case 4:
                    {
                        if (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE") == 0)
                        {

                            var decoration = new Decoration();
                            decoration.Collection = NAPI.Util.GetHashKey(TattooInfo.MaleTattoosCollection.LEFT_LEG[valueIndex].collectionName);
                            decoration.Overlay = NAPI.Util.GetHashKey(TattooInfo.MaleTattoosCollection.LEFT_LEG[valueIndex].name);
                            Client.SetDecoration(decoration);
                        }
                        else
                        {
                            var decoration = new Decoration();
                            decoration.Collection = NAPI.Util.GetHashKey(TattooInfo.FemaleTattoosCollection.LEFT_LEG[valueIndex].collectionName);
                            decoration.Overlay = NAPI.Util.GetHashKey(TattooInfo.FemaleTattoosCollection.LEFT_LEG[valueIndex].name);
                            Client.SetDecoration(decoration);
                        }
                        break;
                    }
                case 5:
                    {
                        if (Client.GetSharedData<dynamic>("CHARACTER_ONLINE_GENRE") == 0)
                        {

                            var decoration = new Decoration();
                            decoration.Collection = NAPI.Util.GetHashKey(TattooInfo.MaleTattoosCollection.RIGHT_LEG[valueIndex].collectionName);
                            decoration.Overlay = NAPI.Util.GetHashKey(TattooInfo.MaleTattoosCollection.RIGHT_LEG[valueIndex].name);
                            Client.SetDecoration(decoration);
                        }
                        else
                        {
                            var decoration = new Decoration();
                            decoration.Collection = NAPI.Util.GetHashKey(TattooInfo.FemaleTattoosCollection.RIGHT_LEG[valueIndex].collectionName);
                            decoration.Overlay = NAPI.Util.GetHashKey(TattooInfo.FemaleTattoosCollection.RIGHT_LEG[valueIndex].name);
                            Client.SetDecoration(decoration);
                        }
                        break;
                    }
            }

        }
    }


    public static void IndexChangeMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "TATTOO_STORE")
        {
            Client.SetData<dynamic>("tattooIndex", selectedIndex);
            CreateListsIfNull(Client);
        }
    }

    public static void OnMenuReturnClose(Player Client, String callbackId)
    {

        if (callbackId == "TATTOO_STORE")
        {
            UsefullyRP.CMD_TOP_off(Client);
            UsefullyRP.CMD_Pants_off(Client);
            UsefullyRP.CMD_Acc_off(Client);

            CreateListsIfNull(Client);
            ApplySavedTattoos(Client);



        }
    }

}