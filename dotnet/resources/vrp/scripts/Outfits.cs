using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Xml;

class Outfits : Script
{
    public class Outfit
    {
        public Tuple<int, int>[] Components { get; set; }
        public Tuple<int, int>[] Props { get; set; }
    }


    const int MaxComponent = 12;
    const int MaxProp = 9;
    static List<Outfit> MaleOutfits = new List<Outfit>();
    static List<Outfit> FemaleOutfits = new List<Outfit>();

    public static void OutfitTester_Init()
    {
        if (!System.IO.File.Exists("scriptmetadata.meta"))
        {
            NAPI.Util.ConsoleOutput("OutfitTester doesn't work without scriptmetadata.meta!");
            NAPI.Util.ConsoleOutput("Export it from \"update\\update.rpf\\common\\data\" using OpenIV.");
            return;
        }

        XmlDocument doc = new XmlDocument();
        doc.Load("scriptmetadata.meta");

        // 200IQ code incoming
        foreach (XmlNode node in doc.SelectNodes("/CScriptMetadata/MPOutfits/*/MPOutfitsData/Item"))
        {
            Outfit newOutfit = new Outfit
            {
                Components = new Tuple<int, int>[MaxComponent],
                Props = new Tuple<int, int>[MaxProp]
            };

            // Load components
            XmlNode components = node.SelectSingleNode("ComponentDrawables");
            XmlNode componentTextures = node.SelectSingleNode("ComponentTextures");

            for (int compID = 0; compID < MaxComponent; compID++)
            {
                newOutfit.Components[compID] = new Tuple<int, int>(Convert.ToInt32(components.ChildNodes[compID].Attributes["value"].Value), Convert.ToInt32(componentTextures.ChildNodes[compID].Attributes["value"].Value));
            }

            // Load props
            XmlNode props = node.SelectSingleNode("PropIndices");
            XmlNode propTextures = node.SelectSingleNode("PropTextures");

            for (int propID = 0; propID < MaxProp; propID++)
            {
                newOutfit.Props[propID] = new Tuple<int, int>(Convert.ToInt32(props.ChildNodes[propID].Attributes["value"].Value), Convert.ToInt32(propTextures.ChildNodes[propID].Attributes["value"].Value));
            }

            switch (node.ParentNode.ParentNode.Name)
            {
                case "MPOutfitsDataMale":
                    MaleOutfits.Add(newOutfit);
                    break;

                case "MPOutfitsDataFemale":
                    FemaleOutfits.Add(newOutfit);
                    break;

                default:
                    break;
            }
        }

    }


    [Command("setodecu", "/setodecu [id/DeoImena] [id(0 a 1482)]")]
    public void command_settraje(Player Client, string idOrName, int value)
    {
        if (AccountManage.GetPlayerAdmin(Client) < 5)
        {
            Main.SendErrorMessage(Client, "Niste ovlasceni.");
            return;
        }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client, idOrName);

        if (target != null)
        {

            if (target.GetData<dynamic>("status") != true)
            {
                Main.SendErrorMessage(Client, "Pogresan ID.");
                return;
            }
            GameLog.ELog(Client, GameLog.MyEnum.Admin, " /setodecu " + AccountManage.GetCharacterName(target) + " " + value.ToString());

            if (Client != target) Main.SendCustomChatMessasge(Client, "Postavili ste ~y~" + AccountManage.GetCharacterName(target) + " outfit " + value + ".");
            else Main.SendInfoMessage(Client, "~y~" + AccountManage.GetCharacterName(target) + " Vam je postavio outfit na: " + value + ".");


            SetUnisexOutfit(target, value, true);
        }
    }

    public static void SetMaleOutfit(Player Client, int ID)
    {
        if (ID < 0 || ID >= MaleOutfits.Count)
        {
            Main.SendCustomChatMessasge(Client,"Pogsan ID: 0 - " + (MaleOutfits.Count - 1) + ".");
            return;
        }

        for (int i = 0; i < MaxComponent; i++)
        {
            if (i == 0) continue;
            if (i == 2) continue;
            Client.SetClothes(i, MaleOutfits[ID].Components[i].Item1, MaleOutfits[ID].Components[i].Item2);
        }

        for (int i = 0; i < MaxProp; i++)
        {
            Client.ClearAccessory(i);
            Client.SetAccessories(i, MaleOutfits[ID].Props[i].Item1, MaleOutfits[ID].Props[i].Item2);
        }
    }

    public static void SetFemaleOutfit(Player Client, int ID)
    {
        if (ID < 0 || ID >= FemaleOutfits.Count)
        {

            Main.SendCustomChatMessasge(Client,"Pogsan ID: 0 - " + (FemaleOutfits.Count - 1) + ".");
            return;
        }

        for (int i = 0; i < MaxComponent; i++)
        {
            if (i == 0) continue;
            if (i == 2) continue;
            Client.SetClothes(i, FemaleOutfits[ID].Components[i].Item1, FemaleOutfits[ID].Components[i].Item2);
        }

        for (int i = 0; i < MaxProp; i++)
        {
            Client.ClearAccessory(i);
            Client.SetAccessories(i, FemaleOutfits[ID].Props[i].Item1, FemaleOutfits[ID].Props[i].Item2);
        }
    }

    public static void SetUnisexOutfit(Player Client, int ID, bool save = false)
    {
        try
        {
            foreach (int item in Police.PDCustomCloth)
            {
                if (item == ID)
                {
                    Police.LoadPoliceCloth(Client, ID);
                    Police.LoadPoliceAddon(Client, ID);
                    return;
                }
            }
        }
        catch (Exception e)
        {
            NAPI.Util.ConsoleOutput("setunisexoutfit");
            Console.Write(e);
        }


        switch ((PedHash)Client.Model)
        {
            case PedHash.FreemodeMale01:
                if (ID < 0 || ID >= MaleOutfits.Count)
                {
                    Main.SendCustomChatMessasge(Client,"Pogresan ID: 0 - " + (MaleOutfits.Count - 1) + ".");
                    return;
                }

                for (int i = 0; i < MaxComponent; i++)
                {
                    if (i == 0) continue;
                    if (i == 1)
                    {
                        Client.SetClothes(i, 0, 0);
                        if (save == true)
                        {
                            Client.SetSharedData("character_mask", MaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_mask_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        continue;
                    }
                    if (i == 2) continue;
                    if (save == true)
                    {

                        if (i == 1)
                        {
                            Client.SetSharedData("character_mask", MaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_mask_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 3)
                        {
                            Client.SetSharedData("character_torso", MaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_torso_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 4)
                        {
                            Client.SetSharedData("character_leg", MaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_leg_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 6)
                        {
                            Client.SetSharedData("character_feet", MaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_feet_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 8)
                        {
                            Client.SetSharedData("character_undershirt", MaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_undershirt_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 9)
                        {
                            Client.SetSharedData("character_armor", MaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_armor_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 11)
                        {
                            Client.SetSharedData("character_shirt", MaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_shirt_texture", MaleOutfits[ID].Components[i].Item2);
                        }
                    }
                    Client.SetClothes(i, MaleOutfits[ID].Components[i].Item1, MaleOutfits[ID].Components[i].Item2);
                }

                for (int i = 0; i < MaxProp; i++)
                {
                    if (save == true)
                    {
                        if (i == 0)
                        {
                            Client.SetSharedData("character_hats", MaleOutfits[ID].Props[i].Item1);
                            Client.SetSharedData("character_hats_texture", MaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 1)
                        {
                            Client.SetSharedData("character_glasses", MaleOutfits[ID].Props[i].Item1);
                            Client.SetSharedData("character_glasses_texture", MaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 2)
                        {
                            Client.SetSharedData("character_ears", MaleOutfits[ID].Props[i].Item1);
                            Client.SetSharedData("character_ears_texture", MaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 6)
                        {
                            Client.SetSharedData("character_watches", MaleOutfits[ID].Props[i].Item1);
                            Client.SetSharedData("character_watches_texture", MaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 7)
                        {
                            Client.SetSharedData("character_bracelets", MaleOutfits[ID].Props[i].Item1);
                            Client.SetSharedData("character_bracelets_texture", MaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 9)
                        {
                            Client.SetSharedData("character_armor", MaleOutfits[6].Components[i].Item1);
                            Client.SetSharedData("character_armor_texture", MaleOutfits[1].Components[i].Item2);
                        }
                    }

                    if (ID == 193)
                    {
                        if (i == 0)
                        {
                            Client.SetSharedData("character_hats", 0);
                            Client.SetSharedData("character_hats_texture", 0);

                            Client.ClearAccessory(i);
                            continue;
                        }
                        if (i == 1)
                        {
                            Client.SetSharedData("character_glasses", 0);
                            Client.SetSharedData("character_glasses_texture", 0);
                            Client.ClearAccessory(i);
                            continue;
                        }
                    }

                    Client.ClearAccessory(i);
                    Client.SetAccessories(i, MaleOutfits[ID].Props[i].Item1, MaleOutfits[ID].Props[i].Item2);
                }

                break;

            case PedHash.FreemodeFemale01:
                if (ID < 0 || ID >= FemaleOutfits.Count)
                {

                    Main.SendCustomChatMessasge(Client,"Pogresan ID: 0 - " + (FemaleOutfits.Count - 1) + ".");
                    return;
                }

                for (int i = 0; i < MaxComponent; i++)
                {
                    if (i == 0) continue;
                    if (i == 1)
                    {
                        Client.SetClothes(i, 0, 0);
                        continue;
                    }
                    if (i == 2) continue;
                    if (save == true)
                    {

                        if (i == 1)
                        {
                            Client.SetSharedData("character_mask", FemaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_mask_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 3)
                        {
                            Client.SetSharedData("character_torso", FemaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_torso_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 4)
                        {
                            Client.SetSharedData("character_leg", FemaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_leg_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 6)
                        {
                            Client.SetSharedData("character_feet", FemaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_feet_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 8)
                        {
                            Client.SetSharedData("character_undershirt", FemaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_undershirt_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                        else if (i == 9)
                        {
                            Client.SetSharedData("character_armor", FemaleOutfits[2].Components[i].Item1);
                            Client.SetSharedData("character_armor_texture", FemaleOutfits[1].Components[i].Item2);
                        }
                        else if (i == 11)
                        {
                            Client.SetSharedData("character_shirt", FemaleOutfits[ID].Components[i].Item1);
                            Client.SetSharedData("character_shirt_texture", FemaleOutfits[ID].Components[i].Item2);
                        }
                    }
                    Client.SetClothes(i, FemaleOutfits[ID].Components[i].Item1, FemaleOutfits[ID].Components[i].Item2);
                }

                for (int i = 0; i < MaxProp; i++)
                {
                    if (save == true)
                    {
                        if (i == 0)
                        {
                            Client.SetSharedData("character_hats", FemaleOutfits[ID].Props[i].Item1);
                            Client.SetSharedData("character_hats_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 1)
                        {
                            Client.SetSharedData("character_glasses", FemaleOutfits[ID].Props[i].Item1);
                            Client.SetSharedData("character_glasses_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 2)
                        {
                            Client.SetSharedData("character_ears", FemaleOutfits[ID].Props[i].Item1);
                            Client.SetSharedData("character_ears_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 6)
                        {
                            Client.SetSharedData("character_watches", FemaleOutfits[ID].Props[i].Item1);
                            Client.SetSharedData("character_watches_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                        else if (i == 7)
                        {
                            Client.SetSharedData("character_bracelets", FemaleOutfits[ID].Props[i].Item1);
                            Client.SetSharedData("character_bracelets_texture", FemaleOutfits[ID].Props[i].Item2);
                        }
                    }
                    Client.ClearAccessory(i);
                    Client.SetAccessories(i, FemaleOutfits[ID].Props[i].Item1, FemaleOutfits[ID].Props[i].Item2);
                }
                break;

            default:
                Main.SendCustomChatMessasge(Client,"Vi imate setan skin!");
                break;
        }
    }

    public static void RemovePlayerDutyOutfit(Player Client)
    {
        NAPI.Data.SetEntityData(Client, "character_duty_outfit", -1);
        Client.SetClothes(5, 0, 0);
        Main.UpdatePlayerClothes(Client);
        
    }
}
