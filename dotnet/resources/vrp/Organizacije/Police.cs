using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

class Police : Script
{
    static int[] male_head = { 8, 46 };
    static int[] male_glasses = { 0, 9 };
    static int[] male_bodyarmor = { 0, 12, 16 };
    static int[] male_undershirt = { 0, 58, 122, 129, 130 };
    static int[] male_torso = { 0, 19, 30 };

    public static int MAX_FACTION_VEHICLES = 30;

    public static List<int> PDCustomCloth = new List<int>();

    public class call_911_enum : IEquatable<call_911_enum>
    {
        public int id { get; set; }
        public int active { get; set; }
        public Player Player { get; set; }
        public Player accept_by { get; set; }
        public ColShape area { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            call_911_enum objAsPart = obj as call_911_enum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(call_911_enum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }
    public static List<call_911_enum> Call_911 = new List<call_911_enum>();

    public Police()
    {
        for (int i = 0; i < 100; i++)
        {
            Call_911.Add(new call_911_enum { id = i, active = 0, Player = null, accept_by = null });
        }
    }

    List<Vector3> spawnLocations = new List<Vector3>
    {
        new Vector3(442.40292, -1015.0793, 28.644115),
        new Vector3(442.3255, -1019.50085, 28.661463),
        new Vector3(435.79218, -1019.74286, 28.802309),
        new Vector3(435.35574, -1015.0849, 28.74902),
        new Vector3(450.73477, -1014.67004, 28.478218),
        new Vector3(451.10883, -1018.7606, 28.478521)

    };


    public static void SetCopDefaultClothes(Player Client)
    {
        Outfits.SetUnisexOutfit(Client, 193);
    }

    public static void DisplayCopUniforms(Player Client)
    {
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "Standardna - dugi rukavi", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Standardna - kratki rukavi", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Saobracajna - dugi rukavi", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Saobracajna - kratki rukavi", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Interventna - kratki rukavi", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Interventna - dugi rukavi", Description = "", RightLabel = "" });

      //  menu_item_list.Add(new { Type = 1, Name = "Kolah Rasmi ", Description = "", RightLabel = "" });

        InteractMenu.CreateMenu(Client, "POLICE_UNIFORM_RESPONSE", "Uniforma", "~b~Izaberi:", true, NAPI.Util.ToJson(menu_item_list), false);
    }

    public static void DisplayCopAddons(Player Client)
    {
        List<dynamic> menu_item_list = new List<dynamic>();

        menu_item_list.Add(new { Type = 1, Name = "Pancir - Policija", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Pancir - Interventna", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Radio", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Fluroscentna jakna", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Holster", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Sesir", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Kapa", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Slem", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Znacka 1", Description = "", RightLabel = "" });
        menu_item_list.Add(new { Type = 1, Name = "Znacka 2", Description = "", RightLabel = "" });

      //  menu_item_list.Add(new { Type = 1, Name = "Kolah Rasmi ", Description = "", RightLabel = "" });

        InteractMenu.CreateMenu(Client, "POLICE_ADDON_RESPONSE", "Dodaci", "~b~Izaberi:", true, NAPI.Util.ToJson(menu_item_list), false);
    }

    public static void SetPlayerCrime(Player Client, int level)
    {
        int wlevel = Client.GetSharedData<dynamic>("character_wanted_level") + level;
        Main.CreateMySqlCommand("UPDATE `characters` SET `wanted` = '" + wlevel + "'  WHERE `userid` = '" + Client.GetData<dynamic>("player_sqlid") + "';");
        Client.SetSharedData("character_wanted_level", wlevel);
        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Dobili ste " + level +" Wanted Levela!");
        foreach (var target in NAPI.Pools.GetAllPlayers())
        {
            if (target.GetData<dynamic>("status") == true && FactionManage.GetPlayerGroupID(target) == 1)
            {
                Main.SendMessageWithTagToPlayer(target, "" + Main.EMBED_BLUE + "DISPACER - ", "" + Main.EMBED_COP_Message + ". Pocinioc: " + AccountManage.GetCharacterName(Client) + Main.EMBED_COP_Message + " Nivo poternice: ~y~" + Client.GetSharedData<dynamic>("character_wanted_level") + ".");
            }
        }
    }

    public static void wantedlevelminus(Player Client, int level)
    {
        int wlevel = Client.GetSharedData<dynamic>("character_wanted_level") + level;
        Main.CreateMySqlCommand("UPDATE `characters` SET `wanted` = '" + wlevel + "'  WHERE `userid` = '" + Client.GetData<dynamic>("player_sqlid") + "';");
        Client.SetSharedData("character_wanted_level", wlevel);
        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Vas wanted level je smanjen za " + level +"!");
    }




    public static void ClearPlayerCrime(Player Client)
    {
        Main.CreateMySqlCommand("DELETE FROM `crime_report` WHERE `suspect` = '" + Client.GetData<dynamic>("character_name") + "';");

        Client.SetSharedData("character_wanted_level", 0);
        //Client.TriggerEvent("SetPlayerWanted", 0);
    }

    public static void SelectMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList)
    {
        if (callbackId == "CRIME_LIST_RESPONSE")
        {
            int crime_id = selectedIndex;

            for (int i = 0; 0 < Main.crime_list.Count; i++)
            {
                if (i == crime_id)
                {
                    int stars = Main.crime_list[i].crime_points;
                    Player target = Client.GetData<dynamic>("CMDMandatoTarget");
                    SetPlayerCrime(target, stars);
                    NAPI.Notification.SendNotificationToPlayer(Client, "Postavili ste novu optuznicu:" + AccountManage.GetCharacterName(target) + "");
                    return;
                }
            }
        }
        else if (callbackId == "POLICE_UNIFORM_RESPONSE")
        {
            UsefullyRP.CMD_Mascara(Client, false);
            switch (selectedIndex)
            {
                case 0:

                    if ((PedHash)Client.Model == PedHash.FreemodeMale01) // DUGI RUKAVI
                    {
                        Client.SetClothes(3, 1, 0); // TORSO
                        Client.SetClothes(4, 138, 0); // LEGS
						Client.SetClothes(5, 100, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 152, 0); // ACCESSORIES 
                        Client.SetClothes(8, 184, 0); // UNDERSHIRT
						Client.SetClothes(9, 58, 0); // ARMORS
                        Client.SetClothes(10, 121, 1); // DECALS
                        Client.SetClothes(11, 383, 0);  // TOPS
                        Client.SetAccessories(0, 9, 0);  // HATS?	
 
 
 
                        Client.SetData<dynamic>("character_duty_outfit", 194);
 
                    }
                    else if ((PedHash)Client.Model == PedHash.FreemodeFemale01) // DUGI RUKAVI
                    {
                        Client.SetClothes(3, 3, 0); // TORSO
                        Client.SetClothes(4, 145, 0); // LEGS
						Client.SetClothes(5, 100, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 121, 0); // ACCESSORIES 
                        Client.SetClothes(8, 222, 0); // UNDERSHIRT
						//Client.SetClothes(9, 59, 0); // ARMORS
                        //Client.SetClothes(10, 129, 1); // DECALS
                        Client.SetClothes(11, 401, 0);  // TOPS
                        Client.SetAccessories(0, 9, 0);  // HATS?                 
 
 
                        Client.ClearAccessory(0);
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
                        Client.SetData<dynamic>("character_duty_outfit", 194);
                    }
 
                    break;
                case 1:
                    if ((PedHash)Client.Model == PedHash.FreemodeMale01) // KRATKI
                    {
                        Client.SetClothes(3, 0, 0); // TORSO
                        Client.SetClothes(4, 138, 0); // LEGS
						Client.SetClothes(5, 100, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 152, 0); // ACCESSORIES 
                        Client.SetClothes(8, 184, 0); // UNDERSHIRT
						Client.SetClothes(9, 58, 0); // ARMORS
                        Client.SetClothes(10, 120, 1); // DECALS
                        Client.SetClothes(11, 382, 0);  // TOPS
                        Client.SetAccessories(0, 9, 0);  // HATS?    
 
                        Client.ClearAccessory(0);
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
 
 
                        Client.SetData<dynamic>("character_duty_outfit", 195); 
 
                    }
                    else if ((PedHash)Client.Model == PedHash.FreemodeFemale01) // KRATKI
                    {
                        Client.SetClothes(3, 14, 0); // TORSO
                        Client.SetClothes(4, 145, 0); // LEGS
						Client.SetClothes(5, 100, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 121, 0); // ACCESSORIES 
                        Client.SetClothes(8, 222, 0); // UNDERSHIRT
						//Client.SetClothes(9, 59, 0); // ARMORS
                        //Client.SetClothes(10, 128, 1); // DECALS
                        Client.SetClothes(11, 400, 0);  // TOPS
                        Client.SetAccessories(0, 9, 0);  // HATS?                  
 
 
                        Client.ClearAccessory(0);
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
                        Client.SetData<dynamic>("character_duty_outfit", 195);
                    }
                    break;
                case 2:
                    if ((PedHash)Client.Model == PedHash.FreemodeMale01) // SAOBRACAJNA DUGI
                    {
                        Client.SetClothes(3, 1, 0); // TORSO
                        Client.SetClothes(4, 138, 0); // LEGS
						Client.SetClothes(5, 100, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 152, 1); // ACCESSORIES 
                        Client.SetClothes(8, 184, 1); // UNDERSHIRT
						Client.SetClothes(9, 58, 0); // ARMORS
                        Client.SetClothes(10, 121, 1); // DECALS
                        Client.SetClothes(11, 383, 1);  // TOPS
                        Client.SetAccessories(0, 9, 0);  // HATS?	            
 
 
                        Client.ClearAccessory(0);
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
 
                        Client.SetData<dynamic>("character_duty_outfit", 196);
 
                    }
                    else if ((PedHash)Client.Model == PedHash.FreemodeFemale01) // SAOBRACAJNA DUGI
                    {
                        Client.SetClothes(3, 3, 0); // TORSO
                        Client.SetClothes(4, 145, 0); // LEGS
						Client.SetClothes(5, 100, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 121, 1); // ACCESSORIES 
                        Client.SetClothes(8, 222, 1); // UNDERSHIRT
						//Client.SetClothes(9, 59, 0); // ARMORS
                        //Client.SetClothes(10, 129, 1); // DECALS
                        Client.SetClothes(11, 401, 1);  // TOPS
                        Client.SetAccessories(0, 9, 0);  // HATS?                
 
 
                        Client.ClearAccessory(0);
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
                        Client.SetData<dynamic>("character_duty_outfit", 196); 
                    }
                    break;
                case 3:
                    if ((PedHash)Client.Model == PedHash.FreemodeMale01) // SAOBRACAJNA KRATKI
                    {
                        Client.SetClothes(3, 0, 0); // TORSO
                        Client.SetClothes(4, 138, 0); // LEGS
						Client.SetClothes(5, 100, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 152, 1); // ACCESSORIES 
                        Client.SetClothes(8, 184, 1); // UNDERSHIRT
						Client.SetClothes(9, 58, 0); // ARMORS
                        Client.SetClothes(10, 120, 1); // DECALS
                        Client.SetClothes(11, 382, 1);  // TOPS
                        Client.SetAccessories(0, 9, 0);  // HATS?                    
 
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
 
                        Client.SetData<dynamic>("character_duty_outfit", 197);
 
                    }
                    else if ((PedHash)Client.Model == PedHash.FreemodeFemale01)
                    {
                        Client.SetClothes(3, 14, 0); // TORSO
                        Client.SetClothes(4, 145, 0); // LEGS
						Client.SetClothes(5, 100, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 121, 1); // ACCESSORIES 
                        Client.SetClothes(8, 222, 1); // UNDERSHIRT
						//Client.SetClothes(9, 59, 0); // ARMORS
                        //Client.SetClothes(10, 128, 1); // DECALS
                        Client.SetClothes(11, 400, 0);  // TOPS
                        Client.SetAccessories(0, 9, 0);  // HATS?             
 
 
                        Client.ClearAccessory(0);
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
                        Client.SetData<dynamic>("character_duty_outfit", 197);
                    }
                    break;
                case 4:
                    if ((PedHash)Client.Model == PedHash.FreemodeMale01) // INTERVENTNA KRATKI
                    {
                        Client.SetClothes(3, 0, 0); // TORSO
                        Client.SetClothes(4, 138, 1); // LEGS
						Client.SetClothes(5, 100, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 154, 0); // ACCESSORIES 
                        Client.SetClothes(8, 184, 0); // UNDERSHIRT
						Client.SetClothes(9, 58, 0); // ARMORS
                        Client.SetClothes(10, 120, 1); // DECALS
                        Client.SetClothes(11, 382, 2);  // TOPS
                        Client.SetAccessories(0, 9, 1);  // HATS?	    
 
                        Client.ClearAccessory(0);
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
                        Client.SetData<dynamic>("character_duty_outfit", 199);
 
                    }
                    else if ((PedHash)Client.Model == PedHash.FreemodeFemale01)
                    {
						Client.SetClothes(3, 14, 0); // TORSO
                        Client.SetClothes(4, 145, 1); // LEGS
						Client.SetClothes(5, 100, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 122, 0); // ACCESSORIES 
                        Client.SetClothes(8, 222, 0); // UNDERSHIRT
						//Client.SetClothes(9, 59, 0); // ARMORS
                        //Client.SetClothes(10, 128, 1); // DECALS
                        Client.SetClothes(11, 400, 2);  // TOPS
                        Client.SetAccessories(0, 9, 1);  // HATS?                
 
                        NAPI.Player.SetPlayerArmor(Client, 250);
 
                        Client.ClearAccessory(0);
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
                        Client.SetData<dynamic>("character_duty_outfit", 199);
                    }
                    break;
                case 5:
                    if ((PedHash)Client.Model == PedHash.FreemodeMale01) 
                    {
                        Client.SetClothes(3, 1, 0); // TORSO
                        Client.SetClothes(4, 138, 1); // LEGS
						Client.SetClothes(5, 100, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 154, 0); // ACCESSORIES 
                        Client.SetClothes(8, 184, 0); // UNDERSHIRT
						Client.SetClothes(9, 58, 0); // ARMORS
                        Client.SetClothes(10, 121, 1); // DECALS
                        Client.SetClothes(11, 383, 2);  // TOPS
                        Client.SetAccessories(0, 9, 1);  // HATS?	              
 
 
                        Client.ClearAccessory(0);
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
                        Client.SetData<dynamic>("character_duty_outfit", 198);
 
                    }
                    else if ((PedHash)Client.Model == PedHash.FreemodeFemale01)
                    {
                        Client.SetClothes(3, 3, 0); // TORSO
                        Client.SetClothes(4, 145, 1); // LEGS
						Client.SetClothes(5, 100, 0); // BAGS
                        Client.SetClothes(6, 24, 0); // SHOES  
                        Client.SetClothes(7, 122, 0); // ACCESSORIES 
                        Client.SetClothes(8, 222, 0); // UNDERSHIRT
						//Client.SetClothes(9, 59, 0); // ARMORS
                        //Client.SetClothes(10, 129, 1); // DECALS
                        Client.SetClothes(11, 401, 2);  // TOPS
                        Client.SetAccessories(0, 9, 1);  // HATS?     
 
                        NAPI.Player.SetPlayerArmor(Client, 250);
 
                        Client.ClearAccessory(0);
                        Client.ClearAccessory(1);
                        Client.ClearAccessory(2);
 
                        Client.SetData<dynamic>("character_duty_outfit", 198);
                    }
                    break;
            
            }
            Client.TriggerEvent("freeze", false);

        }

        else if (callbackId == "POLICE_ADDON_RESPONSE")
        {
            UsefullyRP.CMD_Mascara(Client, false);
            switch (selectedIndex)
            {
                case 0:
                    Client.SetClothes(9, 59, 0);
                
                    break;
                case 1:

                    Client.SetClothes(9, 57, 1);
                 
                    break;
                case 2:
                    Client.SetClothes(9, 58, 0);
                
                    NAPI.Player.SetPlayerArmor(Client, 100);
                    break;

                case 3:
                    Client.SetClothes(9, 58, 1);
                
                    NAPI.Player.SetPlayerArmor(Client, 100);
                    break;

                case 4:
                    Client.SetClothes(7, 154, 0);
                    
                    break;

                case 5:

                    Client.SetAccessories(0, 9, 0);
                    
                    break;
                case 6:

                    Client.SetAccessories(0, 10, 0);
                    
                    break;
                case 7:

                    Client.SetAccessories(0, 150, 0);
                    
                    break;
                case 8:

                    Client.SetClothes(5, 111, 0);
                    
                    break;
                case 9:

                    Client.SetClothes(9, 61, 0);
                    
                    break;
            
            }
            Client.TriggerEvent("freeze", false);

        }
        else if (callbackId == "POLICE_VEHICLE_SLOT_SPAWN")
        {
            string vehicle_name = objectName;

            var factionid = AccountManage.GetPlayerGroup(Client);
            if (factionid != 1) { InteractMenu_New.SendNotificationError(Client, "Niste zaposleni!"); return; }

            int index = -1;
            for (int i = 0; i < MAX_FACTION_VEHICLES; i++)
            {
                if (FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_name[index] == "Livre")
                {
                    index = i;
                }
            }

            if (index == -1)
            {
                Main.SendErrorMessage(Client, "Nema vise mesta u garazi!");
                return;
            }

            Random rnd = new Random();
            int item = rnd.Next(0, 3);
            switch (item)
            {
                case 0:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(452.5644, -997.0695, 25.35032), new Vector3(-0.9376355, 0.01036374, 179.3837), -1, -1);
                        //      NAPI.Player.SetPlayerIntoVehicle(Client, FactionManage.faction_data[factionid].faction_vehicle_entity[index], (int)VehicleSeat.Driver);
                        //  VehicleStreaming.SetEngineState(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        VehicleStreaming.SetEngineState(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);

                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        //VehicleInventory.LoadVehicleInventoryItens(Client, FactionManage.faction_data[factionid].faction_vehicle_entity[index], FactionManage.faction_data[factionid].faction_id);

                        break;
                    }
                case 1:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(436.689, -1005.882, 26.84521), new Vector3(14.40796, -0.6033466, -178.2125), -1, -1);
                        //    NAPI.Player.SetPlayerIntoVehicle(Client, FactionManage.faction_data[factionid].faction_vehicle_entity[index], (int)VehicleSeat.Driver);
                        // VehicleStreaming.SetEngineState(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        VehicleStreaming.SetEngineState(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);

                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        // VehicleInventory.LoadVehicleInventoryItens(Client, FactionManage.faction_data[factionid].faction_vehicle_entity[index], FactionManage.faction_data[factionid].faction_id);
                        // VehicleInventory.AddInventoryToVehicle(FactionManage.faction_data[factionid].faction_vehicle_entity[index], vehicle);

                        break;
                    }
                case 2:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(447.4119, -997.0052, 25.35126), new Vector3(-0.9181333, 0.001428998, -179.4831), -1, 0 - 1);
                        //       NAPI.Player.SetPlayerIntoVehicle(Client, FactionManage.faction_data[factionid].faction_vehicle_entity[index], (int)VehicleSeat.Driver);
                        //VehicleStreaming.SetEngineState(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        VehicleStreaming.SetEngineState(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);

                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        //VehicleInventory.LoadVehicleInventoryItens(Client, FactionManage.faction_data[factionid].faction_vehicle_entity[index], FactionManage.faction_data[factionid].faction_id);
                        // VehicleInventory.AddInventoryToVehicle(FactionManage.faction_data[factionid].faction_vehicle_entity[index], vehicle);

                        break;
                    }
                case 3:
                    {
                        VehicleHash vehicle = NAPI.Util.VehicleNameToModel(vehicle_name);
                        FactionManage.faction_data[factionid].faction_vehicle_entity[index] = NAPI.Vehicle.CreateVehicle(vehicle, new Vector3(431.2721, -1005.77, 26.86351), new Vector3(16.75011, -0.8737264, -176.9977), -1, -1);
                        //       NAPI.Player.SetPlayerIntoVehicle(Client, FactionManage.faction_data[factionid].faction_vehicle_entity[index], (int)VehicleSeat.Driver);
                        // VehicleStreaming.SetEngineState(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);
                        VehicleStreaming.SetEngineState(FactionManage.faction_data[factionid].faction_vehicle_entity[index], false);

                        Main.SetVehicleFuel(FactionManage.faction_data[factionid].faction_vehicle_entity[index], 100.0);
                        // VehicleInventory.LoadVehicleInventoryItens(Client, FactionManage.faction_data[factionid].faction_vehicle_entity[index], FactionManage.faction_data[factionid].faction_id);
                        // VehicleInventory.AddInventoryToVehicle(FactionManage.faction_data[factionid].faction_vehicle_entity[index], vehicle);

                        break;
                    }
            }

            FactionManage.faction_data[factionid].faction_vehicle_name[index] = vehicle_name;
            FactionManage.faction_data[factionid].faction_vehicle_owned[index] = AccountManage.GetCharacterName(Client);
            return;
        }
    }

    

    public void ListItemMenuResponse(Player Client, String callbackId, int selectedIndex, String objectName, String valueList, int valueIndex)
    {
    }

    public static void CuffPlayer(Player Client)
    {

        Client.StopAnimation();
        cellphoneSystem.FinishCall(Client);

        List<Player> players = NAPI.Player.GetPlayersInRadiusOfPlayer(4, Client);
        Client.SetData<dynamic>("playerCuffed", 1);
        //Client.TriggerEvent("freezeEx", true);
        Client.TriggerEvent("TanabCuff", true);
        BasicSync.AttachObjectToPlayer(Client, NAPI.Util.GetHashKey("p_cs_cuffs_02_s"), 6286, new Vector3(-0.05, 0.08, 0), new Vector3(-90, 0, -90));
        //NAPI.Player.PlayPlayerAnimation(pl, 1, "mp_arresting", "idle");
        NAPI.Player.PlayPlayerAnimation(Client, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.AllowPlayerControl | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "idle");

        foreach (Player item in players)
        {
            Main.PlaySoundClientSide(item, "handcuffs", 0.2f);
        }
        //

    }
    public static void UnCuffPlayer(Player Client)
    {
        //
        Client.SetData<dynamic>("playerCuffed", 0);
        Client.SetData<dynamic>("handsup", false);
        BasicSync.DetachObject(Client);

        //Client.TriggerEvent("freezeEx", false);
        Client.TriggerEvent("TanabCuff", false);
        Client.StopAnimation();
        List<Player> players = NAPI.Player.GetPlayersInRadiusOfPlayer(4, Client);
        foreach (Player item in players)
        {
            Main.PlaySoundClientSide(item, "handcuffs", 0.2f);
        }
    }

    public static void DragPlayerToTarget(Player Client, Player target)
    {
        if (Client.IsInVehicle)
        {
            NAPI.Player.WarpPlayerOutOfVehicle(Client);
        }

        if (target.GetData<dynamic>("BeingDragged") == true)
        {
            NAPI.Notification.SendNotificationToPlayer(Client, "Neko ga vec vuce!");
            return;
        }
        if (AccountManage.GetPlayerGroup(target) == 2 || Client.GetSharedData<dynamic>("Injured") == 1)
        {
            goto next;
        }
        if (Client.GetData<dynamic>("playerCuffed") == 0)
        {
            NAPI.Notification.SendNotificationToPlayer(target, "~r~Greska:~w~ Morate prvo vezati osobu!");
            return;
        }
    next:
        if (Client.GetData<dynamic>("playerCuffed") == 1)
        {
            NAPI.Player.PlayPlayerAnimation(Client, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.AllowPlayerControl | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "idle");

        }
        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
        foreach (Player alvo in proxPlayers)
        {
            alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(target, alvo) + " vuce " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + ".");
        }
        Client.TriggerEvent("setFollow", false, null);
        Client.TriggerEvent("freezeEx", true);
        Client.SetData<dynamic>("BeingDragged", true);
        Client.TriggerEvent("TanabCuff", true);
        Client.TriggerEvent("setFollow", true, target);
    }

    public static void UnDragPlayer(Player Client)
    {
        if (Client.GetData<dynamic>("playerCuffed") == 1)
        {
            NAPI.Player.PlayPlayerAnimation(Client, (int)(Main.AnimationFlags.Loop | Main.AnimationFlags.AllowPlayerControl | Main.AnimationFlags.OnlyAnimateUpperBody), "mp_arresting", "idle");
        }
        if (Client.GetSharedData<dynamic>("Injured") != 1)
        {
            Client.TriggerEvent("freezeEx", false);
            Client.TriggerEvent("TanabCuff", false);
        }
        List<Player> proxPlayers = NAPI.Player.GetPlayersInRadiusOfPlayer(15, Client);
        foreach (Player alvo in proxPlayers)
        {
            alvo.TriggerEvent("Send_ToChat", "", "<font color ='#C2A2DA'>* " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + " pusta " + UsefullyRP.GetPlayerNameToTarget(Client, alvo) + ".");
        }
        Client.TriggerEvent("setFollow", false, null);
        Client.SetData<dynamic>("BeingDragged", false);
    }
    public static void FriskPlayerToTarget(Player target, Player Client)
    {
        Main.SendCustomChatMessasge(Client, "~w~-----------------------------");
        Main.SendCustomChatMessasge(Client, "~g~Pretresate " + AccountManage.GetCharacterName(target) + "");


        if (target.GetData<dynamic>("primary_weapon") != 0)
        {
            Main.SendCustomChatMessasge(Client, "Primarno oruzje ~c~" + target.GetData<dynamic>("primary_weapon"));
        }
        if (target.GetData<dynamic>("pistol_weapon") != 0)
        {
            Main.SendCustomChatMessasge(Client, "Primarno oruzje ~c~" + target.GetData<dynamic>("pistol_weapon"));
        }
        if (target.GetData<dynamic>("secundary_weapon") != 0)
        {
            Main.SendCustomChatMessasge(Client, "Sekundarno oruzje ~c~" + target.GetData<dynamic>("secundary_weapon"));
        }
        if (target.GetData<dynamic>("weapon_meele") != 0)
        {
            Main.SendCustomChatMessasge(Client, "Hladno oruzje~c~" + target.GetData<dynamic>("weapon_meele"));
        }

        for (int index = 0; index < Inventory.MAX_INVENTORY_ITENS; index++)
        {
            if (target.GetData<dynamic>("inventory_item_" + index + "_type") != 0 && target.GetData<dynamic>("inventory_item_" + index + "_type") < Inventory.itens_available.Count)
            {
                if (target.GetData<dynamic>("inventory_item_" + index + "_amount") > 0)
                {
                    Main.SendCustomChatMessasge(Client, "(Stvari) ~c~" + Inventory.itens_available[target.GetData<dynamic>("inventory_item_" + index + "_type")].name + " ~w~(" + target.GetData<dynamic>("inventory_item_" + index + "_amount") + ") ");
                }

            }
        }
        Main.SendCustomChatMessasge(Client, "~w~-----------------------------");
    }

    // Calcular tempo de prisão
    public static int Calcular_Prisao(string name)
    {
        int count = 0, time = 0, crimes = 0, multas = 0;

        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `crime_report` WHERE `suspect` = '" + name + "' OR `suspect` = '" + name.Replace(' ', '_') + "';", Mainpipeline);

            using (MySqlDataReader reader = query.ExecuteReader())
            {

                while (reader.Read())
                {
                    if (reader.GetInt32("price") == 0)
                    {
                        time += reader.GetInt32("stars") * 60;
                        crimes++;
                    }
                    else
                    {
                        if (reader.GetInt32("price") < 10000)
                        {
                            time += 1 * 70;
                        }
                        else
                        {
                            time += 2 * 80;
                        }
                        multas++;
                    }
                    count++;
                }

                if (count == 0)
                {
                    time = 0;
                }
            }
            Mainpipeline.Close();
        }

        return time;
    }

    public static void LoadPoliceCloth(Player Client, int ID)
    {
        switch ((PedHash)Client.Model)
        {
            case PedHash.FreemodeMale01:
                switch (ID)
                {

                    case 194: // STANDARDNA UNIFORMA DUGI RUKAVI
                        
                        break;
                    case 195:

                        
                        break;
                    case 196:
                        
                        break;

                    case 197:

                        //UsefullyRP.CMD_Mascara(Client, true);

                        
                        break;

                    case 199:

                        //UsefullyRP.CMD_Mascara(Client, true);

                        
                        break;

                    case 198:

                       
                        break;

                }
                break;
            case PedHash.FreemodeFemale01:
                switch (ID)
                {

                    case 194:
                        
                        break;

                    case 195:

                        
                        break;

                    case 196:
                        
                        break;

                    case 197:

                       
                        break;

                    case 199:

                        
                        break;

                    case 198:

                        
                        break;


                }
                break;
        }
    }

    public static void LoadPoliceAddon(Player Client, int ID)
    {
        switch ((PedHash)Client.Model)
        {
            case PedHash.FreemodeMale01:
                switch (ID)
                {

                    case 201:
                        Client.SetClothes(9, 59, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 201);
                        break;
                    case 202:

                        Client.SetClothes(9, 57, 1);
                        Client.SetData<dynamic>("character_duty_outfit", 202); 
                        break;
                    case 203:
                        Client.SetClothes(9, 59, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 203);
                        NAPI.Player.SetPlayerArmor(Client, 100);
                        break;

                    case 204:
                        Client.SetClothes(9, 59, 1);
                        Client.SetData<dynamic>("character_duty_outfit", 204);
                        NAPI.Player.SetPlayerArmor(Client, 100);
                        break;

                    case 205:
                        Client.SetClothes(7, 156, 0);                     
                        Client.SetData<dynamic>("character_duty_outfit", 205);
                        break;

                    case 206:

                        Client.SetClothes(0, 9, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 206);
                        break;
                    case 207:

                        Client.SetClothes(0, 10, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 207);
                        break;
                    case 208:

                        Client.SetClothes(0, 150, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 208);
                        break;
                    case 209:

                        Client.SetClothes(5, 111, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 209);
                        break;
                    case 210:

                        Client.SetClothes(9, 61, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 210);
                        break;

                }
                break;
            case PedHash.FreemodeFemale01:
                switch (ID)
                {

                    case 201:
                        Client.SetClothes(9, 59, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 201);
                        break;
                    case 202:

                        Client.SetClothes(9, 57, 1);
                        Client.SetData<dynamic>("character_duty_outfit", 202); 
                        break;
                    case 203:
                        Client.SetClothes(9, 59, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 203);
                        NAPI.Player.SetPlayerArmor(Client, 100);
                        break;

                    case 204:
                        Client.SetClothes(9, 59, 1);
                        Client.SetData<dynamic>("character_duty_outfit", 204);
                        NAPI.Player.SetPlayerArmor(Client, 100);
                        break;

                    case 205:
                        Client.SetClothes(7, 156, 0);                     
                        Client.SetData<dynamic>("character_duty_outfit", 205);
                        break;

                    case 206:

                        Client.SetClothes(0, 9, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 206);
                        break;
                    case 207:

                        Client.SetClothes(0, 10, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 207);
                        break;
                    case 208:

                        Client.SetClothes(0, 150, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 208);
                        break;
                    case 209:

                        Client.SetClothes(5, 111, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 209);
                        break;
                    case 210:

                        Client.SetClothes(9, 61, 0);
                        Client.SetData<dynamic>("character_duty_outfit", 210);
                        break;


                }
                break;
        }
    }

    public static void ChangeBadgeStatus(Player player)
    {
        if (player.HasSharedData("badgeon"))
        {
            player.SetSharedData("badgeon", !player.GetSharedData<dynamic>("badgeon"));
        }
    }

    public static void SetCurrentBadge(Player player, int badgeListIndex)
    {
        int index = -1;
        foreach (var item in Police.Badge_List)
        {
            if (item.ownersql == AccountManage.GetPlayerSQLID(player))
            {
                index = Police.Badge_List.IndexOf(item);
                break;
            }
        }
        if (index != -1 && Badge_List.ElementAtOrDefault(badgeListIndex) != null)
        {
            int badgenumber = Badge_List[index].bnumbers[badgeListIndex];
            player.SetSharedData("badgenumber", badgenumber);
            player.SetSharedData("badgename", GetBadgeNameWithBadgeID(player, badgenumber));
        }
    }

    

    [Command("setbadge")]
    public void SetBadge(Player player, string nameorid, int Badge_Id)
    {
        if (AccountManage.GetPlayerGroup(player) == 1)
        {
            if (AccountManage.GetPlayerLeader(player) == 1 || AccountManage.GetPlayerRank(player) >= 8)
            {
                Player target = Main.findPlayer(player, nameorid);

                if (!target.Exists)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Igrac nije na serveru!");
                    return;
                }
                Main.CreateMySqlCommand("INSERT INTO `pdbadge` (owner,bnumber,register_date)  VALUES('" + AccountManage.GetPlayerSQLID(target) + "','" + Badge_Id + "'," + DateTimeOffset.Now.ToUnixTimeSeconds() + ");");

                foreach (var item in Police.Badge_List)
                {
                    if (item.ownersql == AccountManage.GetPlayerSQLID(target))
                    {
                        item.bnumbers.Add(Badge_Id);
                        target.SetSharedData("badgename", GetBadgeNameWithBadgeID(target, Badge_Id));
                        target.SetSharedData("badgenumber", Badge_Id);
                        return;
                    }
                }
                LoadBadgeForPlayer(target, Badge_Id);
            }
        }
    }

    [Command("removebadge")]
    public void RemoveBadge(Player player, int Badge_Id)
    {
        if (AccountManage.GetPlayerGroup(player) == 1)
        {
            if (AccountManage.GetPlayerLeader(player) == 1 || AccountManage.GetPlayerRank(player) >= 8)
            {

                Main.CreateMySqlCommand("DELETE FROM `pdbadge` WHERE `bnumber`= '" + Badge_Id + "'");

                foreach (var item in Police.Badge_List)
                {
                    foreach (var v in item.bnumbers)
                    {
                        if (v == Badge_Id)
                        {
                            if (item.player.Exists)
                            {
                                item.player.ResetSharedData("badgename");
                                item.player.ResetSharedData("badgenumber");
                            }
                            item.bnumbers.Remove(v);
                            return;
                        }
                    }
                }
            }
        }
    }

    public static string GetBadgeNameWithBadgeID(Player player, int badge_number)
    {
        string badgename = "";
        switch (badge_number)
        {
            case int n when (n == 1):
                badgename = "Nacelnik";
                break;
            case int n when (n >= 2 && n <= 4):
                badgename = "Zamenik Nacelnika";
                break;
            case int n when (n >= 5 && n <= 9):
                badgename = "Komandir";
                break;
            case int n when (n >= 10 && n <= 29):
                badgename = "Kapetan";
                break;
            case int n when (n >= 30 && n <= 40):
                badgename = "Narednik";
                break;
            case int n when (n >= 160 && n <= 171):
                badgename = "Stariji Policajac";
                break;
            case int n when (n >= 130 && n <= 159):
                badgename = "Samostalni Policajac";
                break;
            case int n when (n >= 101 && n <= 129):
                badgename = "Policajac Pripravnik";
                break;
            case int n when (n >= 210 && n <= 233):
                badgename = "Kadet";
                break;
            default:
                break;
        }
        return badgename;
    }

    public static void GiveBadgeToPlayer(Player player, int badge_number)
    {

        if (AccountManage.GetPlayerGroup(player) == 1)
        {
            player.SetSharedData("badgenumber", badge_number);
            player.SetSharedData("badgeon", false);

            player.SetSharedData("badgename", GetBadgeNameWithBadgeID(player, badge_number));


        }
    }
    public static List<badge_structer> Badge_List = new List<badge_structer>();
    public class badge_structer
    {
        public int ownersql;
        public List<int> bnumbers;
        public Player player;
    }
    public static void LoadBadgeForPlayer(Player player, int badge_number)
    {
        foreach (var item in Badge_List)
        {
            if (item.ownersql == AccountManage.GetPlayerSQLID(player))
            {
                item.bnumbers.Add(badge_number);
                return;
            }
        }
        Badge_List.Add(new badge_structer { bnumbers = new List<int>() { badge_number }, ownersql = AccountManage.GetPlayerSQLID(player), player = player });


        GiveBadgeToPlayer(player, badge_number);
    }


    public static async System.Threading.Tasks.Task OnPlayerConnectLoadUnit(Player player)
    {
        player.SetSharedData("badgeon", false);
        if (AccountManage.GetPlayerGroup(player) == 1)
        {
            MySqlConnection connection = new MySqlConnection(Main.myConnectionString);
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "SELECT * FROM pdbadge WHERE owner =" + AccountManage.GetPlayerSQLID(player) + "";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.FieldCount != 0)
                {

                    LoadBadgeForPlayer(player, reader.GetInt32("bnumber"));
                }
            }
            reader.Close();
            connection.Close();

        }
    }

    public static List<unit_Structer> UnitList = new List<unit_Structer>();
    public class Unit_Players_Structer
    {
        public Player CLINT;
        public int SQLID;
    }
    public class unit_Structer
    {
        public int id;
        public int POwner;
        public List<Unit_Players_Structer> Players = new List<Unit_Players_Structer>();
    }

    /*public static void DepositArmory(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(458.7, -979.4, 30.6), 1))
        {
            if (AccountManage.GetPlayerGroup(Client) != 1)
            {

                return;
            }
            if (Client.GetData<int>("duty") == 0)
            {
                InteractMenu_New.SendNotificationError(Client, Translation.head_notification_11);
                return;
            }
            List<dynamic> menu_item_list = new List<dynamic>();
            int index = 0;
            for (int i = 0; i < Inventory.MAX_INVENTORY_ITENS; i++)
            {
                Client.SetData("Deparmory_" + index, -1);

                if (Inventory.player_inventory[Client.Value].amount[i] > 0 && Inventory.itens_available[Inventory.player_inventory[Client.Value].type[i]].guest == Inventory.ITEM_TYPE_WEAPON)
                {
                    menu_item_list.Add(new { Type = 1, Name = " ~y~" + Inventory.itens_available[Inventory.player_inventory[Client.Value].type[i]].name + "", Description = "", RightLabel = "~g~" + Inventory.player_inventory[Client.Value].amount[i] + "x" });
                    Client.SetData("Deparmory_" + index, i);
                    index++;
                }
                else if (Inventory.player_inventory[Client.Value].amount[i] > 0)
                {
                    menu_item_list.Add(new { Type = 1, Name = " ~w~" + Inventory.itens_available[Inventory.player_inventory[Client.Value].type[i]].name + "", Description = "", RightLabel = "~g~" + Inventory.player_inventory[Client.Value].amount[i] + "x" });
                    Client.SetData("Deparmory_" + index, i);
                    index++;
                }
            }

            if (menu_item_list.Count > 0)
            {
                InteractMenu.CreateMenu(Client, "ARMORY_Deposit_RESPONSE", "Oruzarnica", "Depost To Armory~b~", false, NAPI.Util.ToJson(menu_item_list), false);
            }
            return;
        }
    }*/

    #region 911_calls

    // Extened for MDC

    [Command("911")]
    public static void Call_Police(Player Client)
    {
        int index = 0;
        foreach (var call in Call_911)
        {
            if (call.active >= 1 && call.Player == Client)
            {
                index++;
            }
        }

        if (index > 0)
        {
            Main.SendErrorMessage(Client, "Vec ste pozvali policiju. Ostanite u krugu od 15 metara odakle ste pozvali, u suprotnom ce poziv biti otkazan!");
            return;
        }

        foreach (var call in Call_911)
        {
            if (call.active == 0)
            {
                call.active = 1;
                call.Player = Client;

                Main.SendCustomChatMessasge(Client, "* Vas poziv je prosledjen svim jedinicama ...");
                FactionManage.SendFactionMessage(1, "~b~[DISPATCH]~b~ " + AccountManage.GetCharacterName(Client) + " je pozvao policiju, neka se jedna slobodna jedinica odazove, hvala!.");
                return;
            }

        }
    }

    [RemoteEvent("mdc_911_accept")]
    public static void Responder_Chamada(Player Client, int chamada)
    {

        int count = 0;
        foreach (var call in Call_911)
        {
            if (call.active >= 1 && call.accept_by == Client)
            {
                count++;
            }
        }

        if (count > 0)
        {
            Main.SendErrorMessage(Client, "Vec odgovarate na 911 poziv, uputite se prema lokaciji!");
            return;
        }

        int index = chamada;

        if (Call_911[index].active == 1)
        {

            Player target = Call_911[index].Player;

            Main.SendCustomChatMessasge(Client, "*~b~[CENTRALA]~b~ Vas poziv je prihvacen, molimo Vas da ostanete na mestu i sacekate patrolu!");
            Client.SendNotification("Patrola je oznacena zutom bojom na mapi!");

            Call_911[index].active = 2;
            Call_911[index].area = NAPI.ColShape.CreateCylinderColShape(target.Position, 15f, 15f);
            Call_911[index].accept_by = Client;

            Client.TriggerEvent("blip_remove", "HITAN POZIV");
            Client.TriggerEvent("blip_create_ext", "HITAN POZIV", target.Position, 73, 0.70f, 0);
            Client.TriggerEvent("blip_router_visible", "HITAN POZIV", true, 73);

            Lista_911(Client);
        }
    }

    [RemoteEvent("mdc_911_refuse")]
    public static void Recusar_Chamada(Player Client, int chamada)
    {
        int index = chamada;
        if (Call_911[index].active == 1)
        {
            Main.SendCustomChatMessasge(Call_911[index].Player, "* Vas poziv je zavrsen!");
            Client.SendNotification("Policija je odbila Vas poziv!");

            Call_911[index].active = 0;
            Call_911[index].Player = null;
            Call_911[index].accept_by = null;

            Lista_911(Client);
        }
    }

    public static void OnEnterDynamicArea(Player Client, ColShape shape)
    {
        foreach (var call in Call_911)
        {
            if (call.active == 2)
            {
                if (call.area == shape)
                {
                    Client.TriggerEvent("blip_remove", "HITAN POZIV");
                    Client.SendNotification("~g~Stigli ste na mesto poziva!");

                    call.active = 0;
                    call.Player = null;
                    call.accept_by = null;
                    call.area.Delete();
                }
            }
        }
    }

    public static void OnLeaveDynamicArea(Player Client, ColShape shape)
    {
        foreach (var call in Call_911)
        {
            if (call.active == 2)
            {
                if (call.area == shape && call.Player == Client)
                {
                    Main.SendCustomChatMessasge(Client, "* Previse ste se udaljili od mesta odakle ste pozvali policiju pa je Vas poziv zavrsen!");

                    call.active = 0;
                    call.Player = null;
                    call.accept_by = null;
                    call.area.Delete();

                    call.accept_by.TriggerEvent("blip_remove", "HITAN POZIV");
                }
            }
        }
    }

    public static void Call_OnDisconect(Player Client)
    {


        foreach (var call in Call_911)
        {
            if (call.active == 1)
            {
                if (call.Player == Client)
                {
                    call.active = 0;
                    call.Player = null;
                    call.accept_by = null;
                }
            }
            if (call.active == 2)
            {
                if (call.accept_by == Client)
                {
                    Main.SendCustomChatMessasge(call.accept_by, "* Policajac koji je prihvatio Vas poziv je napustio grad, molimo sacekajte drugu jedinicu ili je pozovite sami ...");

                    call.active = 1;
                    call.accept_by = null;
                    call.area.Delete();
                }
                if (call.Player == Client)
                {
                    Main.SendCustomChatMessasge(call.Player, "* Osoba koja je pozvala je napustila grad. Nemate obavezu da se odazovete na poziv!");

                    call.active = 0;
                    call.Player = null;
                    call.accept_by = null;
                    call.area.Delete();

                    call.accept_by.TriggerEvent("blip_remove", "HITAN POZIV");
                }
            }
        }
    }

    #endregion 911_calls



    //
    // MDC System Events
    //

    #region MDC
    public static void ShowMDC(Player Client)
    {
        if (AccountManage.GetPlayerGroup(Client) == 1)
        {
            if (Client.IsInVehicle && Client.Vehicle.Class == 18)
            {
                Client.TriggerEvent("Display_MDC");

            }
            else if (Main.IsInRangeOfPoint(Client.Position, new Vector3(430.7088, -983.0495, 30.71043), 40.0f))
            {
                Client.TriggerEvent("Display_MDC");
            }
        }
    }



    [RemoteEvent("mdc_print_suspect")]
    public static void Print_Ficha(Player Client, string name)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `crime_report` WHERE `suspect` = '" + name + "' OR `suspect` = '" + name.Replace(' ', '_') + "';", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                Main.SendCustomChatMessasge(Client, "~c~-------------------------------------");
                Main.SendCustomChatMessasge(Client, "~w~Lista  ~b~" + name + ":");

                int count = 0;
                while (reader.Read())
                {
                    if (reader.GetInt32("price") == 0)
                    {
                        Main.SendCustomChatMessasge(Client, "-> ~b~Zlocin:~w~ " + reader.GetString("charge") + " - Prijavio: " + reader.GetString("office") + " - Stepen poternice: " + reader.GetInt32("stars") + ".");
                    }
                    else
                    {
                        Main.SendCustomChatMessasge(Client, "-> ~g~Kazna:~w~ " + reader.GetString("charge") + " - Prijavio: " + reader.GetString("office") + " - Kazna: " + reader.GetInt32("price") + ".");
                    }
                    count++;
                }

                if (count == 0)
                {
                    Main.SendCustomChatMessasge(Client, "~c~-> ~c~Nikakvi zlocini niti kazne nisu pronadjeni za lice: " + name + " u nasoj bazi.");
                }

                Main.SendCustomChatMessasge(Client, "~c~-------------------------------------");
            }
            Mainpipeline.Close();
        }
    }

    [RemoteEvent("mdc_print_prison")]
    public static void Print_Prision(Player Client, string name)
    {
        using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
        {
            Mainpipeline.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `crime_report` WHERE `suspect` = '" + name + "' OR `suspect` = '" + name.Replace(' ', '_') + "';", Mainpipeline);
            using (MySqlDataReader reader = query.ExecuteReader())
            {
                Main.SendCustomChatMessasge(Client, "~c~-------------------------------------");
                int count = 0, time = 0, crimes = 0, multas = 0;
                while (reader.Read())
                {
                    if (reader.GetInt32("price") == 0)
                    {
                        time += reader.GetInt32("stars") * 60;
                        crimes++;
                    }
                    else
                    {
                        if (reader.GetInt32("price") < 10000)
                        {
                            time += 1 * 70;
                        }
                        else
                        {
                            time += 2 * 80;
                        }
                        multas++;
                    }
                    count++;
                }
                if (count == 0)
                {
                    Main.SendCustomChatMessasge(Client, "~c~-> ~c~Nikakvi zlocini niti kazne nisu pronadjeni za lice: " + name + " u nasoj bazi.");
                }
                else
                {
                    Main.SendCustomChatMessasge(Client, "~w~-> Pronadjeni podaci: ~y~" + time + "~w~ " + crimes + " " + multas + " ~y~" + name + ".");
                }

                Main.SendCustomChatMessasge(Client, "~c~-------------------------------------");
            }
            Mainpipeline.Close();
        }
    }

    [RemoteEvent("mdcFindVehicles")]
    public async Task CMD_finevehicle(Player Client, string placa)
    {
        Task.Run(() =>
        {

            if (placa.Length <= 3)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Alert, NotifyPosition.BottomCenter, " Neophodno je da unesete minimum 3 karaktera!");
                return;
            }
            List<dynamic> data = new List<dynamic>();

            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM `vehicles`  WHERE LOWER(`vehicle_plate`) like '%" + placa.ToLower() + "%' LIMIT 10", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(new { Owner = GetVehicleOwnerNamebySQLID(Client, reader.GetInt32("vehicle_owner_id")), Model = reader.GetString("vehicle_model"), Plate = reader.GetString("vehicle_plate"), Ticket = reader.GetString("vehicle_ticket") });
                    }
                }
                Mainpipeline.Close();

            }
            NAPI.ClientEventThreadSafe.TriggerClientEvent(Client, "mdc_response_vehicle", NAPI.Util.ToJson(data));
        });

    }

    public static string GetVehicleOwnerNamebySQLID(Player player, int vehicle_owner_id)
    {

        using (MySqlConnection Mainpip = new MySqlConnection(Main.myConnectionString))
        {
            Mainpip.Open();
            MySqlCommand query = new MySqlCommand("SELECT `name` FROM `characters` WHERE `id`=" + vehicle_owner_id + "", Mainpip);

            using (MySqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    return reader.GetString("name");
                }
            }
            Mainpip.Close();
            return "Unknown";
        }

    }

    enum JobList
    {
        Police = 1,
        Medic = 2,
        DCC = 7,
        Mechanic = 6,
        Civilian = 0
    }
    [RemoteEvent("mdcFindPersons")]
    public static async Task Checar_Ficha(Player Client, string name)
    {
        Task.Run(() =>
        {

            if (name.Length <= 3)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Alert, NotifyPosition.BottomCenter, "Neophodno je da unesete minimum 3 karaktera!");
                return;
            }
            
            List<dynamic> data = new List<dynamic>();
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `name`,`age` FROM `characters`  WHERE LOWER(`name`)  like '%" + name.ToLower() + "%' LIMIT 10", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(new { Name = reader.GetString("name"), age = reader.GetString("age") });
                    }
                }
                Mainpipeline.Close();
            }
            NAPI.ClientEventThreadSafe.TriggerClientEvent(Client, "mdc_response_player", NAPI.Util.ToJson(data));
        });
    }
    [RemoteEvent("mdcPersonNoteDelete")]
    public void mdcPersonNoteDelete(Player player, int id)
    {
        Task.Run(() =>
        {
            if (id >= 0)
            {
                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                {
                    Mainpipeline.Open();
                    MySqlCommand command = new MySqlCommand("DELETE FROM `notes` WHERE `id`=" + id + "", Mainpipeline);
                    command.ExecuteNonQuery();
                    Mainpipeline.Close();
                }
            }
        });
    }

    

    [RemoteEvent("mdcPersonAddCase")]
    public void CMD_mdcPersonAddCase(Player player, string name, string reason, int jailtime)
    {
        Task.Run(() =>
        {
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO `warrant` (`officer`,`suspect`,`description`,`jailtime`) VALUES ('" + AccountManage.GetCharacterName(player) + "','" + name + "','" + reason + "'," + jailtime + ")", Mainpipeline);
                command.ExecuteNonQuery();
                Mainpipeline.Close();
            }
            List<dynamic> warrant = new List<dynamic>();
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM `warrant` WHERE `suspect` = '" + name + "' ORDER BY id DESC LIMIT 1", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        warrant.Add(new { id = reader.GetInt32("id"), officer = reader.GetString("officer"), suspect = reader.GetString("suspect"), description = reader.GetString("description"), datetime = reader.GetDateTime("date"), jailtime = reader.GetInt16("jailtime"), isopen = reader.GetByte("isopen") });
                    }
                }
                Mainpipeline.Close();
            }
            NAPI.ClientEventThreadSafe.TriggerClientEvent(player, "PersonCaseAdded", NAPI.Util.ToJson(warrant));
        });

    }
    [RemoteEvent("mdcPersonAddNote")]
    public void CMD_mdcPersonAddNote(Player player, string name, string reason)
    {
        Task.Run(() =>
        {
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO `notes` (`officer`,`suspect`,`description`) VALUES ('" + AccountManage.GetCharacterName(player) + "','" + name + "','" + reason + "')", Mainpipeline);
                command.ExecuteNonQuery();
                Mainpipeline.Close();
            }
            List<dynamic> notes = new List<dynamic>();
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `id`,`officer`,`suspect`,`description`,`datetime` FROM `notes` WHERE `suspect` = ' " + name + "' ORDER BY id DESC LIMIT 1", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notes.Add(new { id = reader.GetInt32("id"), officer = reader.GetString("officer"), suspect = reader.GetString("suspect"), description = reader.GetString("description"), datetime = reader.GetDateTime("datetime") });
                    }
                }
                Mainpipeline.Close();
            }

            
            NAPI.ClientEventThreadSafe.TriggerClientEvent(player, "PersonNoteAdded", NAPI.Util.ToJson(notes));
        });
    }
    [RemoteEvent("mdcPersonAddFine")]
    public void mdcPersonAddFine(Player player, string name, string description, int price)
    {
        Task.Run(() =>
        {
            if (price >= 60000)
            {
                Main.DisplayErrorMessage(player, NotifyType.Alert, NotifyPosition.BottomCenter, "Ne mozete napisati kaznu koja je veca od: $60.000");
                return;
            }
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO `fines` (`officer`,`suspect`,`description`,`price`) VALUES ('" + AccountManage.GetCharacterName(player) + "','" + name + "','" + description + "'," + price + ")", Mainpipeline);
                command.ExecuteNonQuery();
                Mainpipeline.Close();
            }
            List<dynamic> fines = new List<dynamic>();
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `id`,`officer`,`suspect`,`description`,`date`,`ispaid`,`price` FROM `fines` WHERE `suspect` = '" + name + "' ORDER BY id DESC LIMIT 1", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fines.Add(new { id = reader.GetInt32("id"), officer = reader.GetString("officer"), suspect = reader.GetString("suspect"), description = reader.GetString("description"), datetime = reader.GetDateTime("date"), price = reader.GetInt16("price"), ispaid = reader.GetByte("ispaid") });
                    }
                }
                Mainpipeline.Close();
            }
            NAPI.ClientEventThreadSafe.TriggerClientEvent(player, "PersonFineAdded", NAPI.Util.ToJson(fines));
        });
    }
    [Command("uzmidozvolu", "Koriscenje: /uzmidozvolu Ime/ID auto/moto/letenje/pecanje/gun")]
    public void uzmidozvolu(Player player, string idOrName, string dozvola)
    {
        if (AccountManage.GetPlayerGroup(player) == 1)
        {
            
            Player name = Main.findPlayer(player, idOrName);
            if (name != null)
            {
                if (Main.IsInRangeOfPoint(player.Position, name.Position, 5))
                {

                    if (dozvola == "auto")
                    {
                        name.SetData("character_car_lic", 0);
                        Main.SavePlayerInformation(name);
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Oduzeli ste dozvolu.");
                        Main.DisplayErrorMessage(name, NotifyType.Warning, NotifyPosition.BottomCenter, "Oduzeta vam je vozacka dozvola od strane policajca" + AccountManage.GetCharacterName(player) + "");
                    }
                    else if (dozvola == "moto")
                    {
                        name.SetData("character_moto_lic", 0);
                        Main.SavePlayerInformation(name);
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Oduzeli ste dozvolu.");
                        Main.DisplayErrorMessage(name, NotifyType.Warning, NotifyPosition.BottomCenter, "Oduzeta vam je moto dozvola od strane policajca" + AccountManage.GetCharacterName(player) + "");
                    }
                    else if (dozvola == "letenje")
                    {
                        name.SetData("character_fly_lic", 0);
                        Main.SavePlayerInformation(name);
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Oduzeli ste dozvolu.");
                        Main.DisplayErrorMessage(name, NotifyType.Warning, NotifyPosition.BottomCenter, "Oduzeta vam je dozvola za letenje od strane policajca" + AccountManage.GetCharacterName(player) + "");
                    }
                    else if (dozvola == "pecanje")
                    {
                        name.SetData("character_fish_lic", 0);
                        Main.SavePlayerInformation(name);
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Oduzeli ste dozvolu.");
                        Main.DisplayErrorMessage(name, NotifyType.Warning, NotifyPosition.BottomCenter, "Oduzeta vam je dozvola za pecanje od strane policajca" + AccountManage.GetCharacterName(player) + "");
                    }
                    else if (dozvola == "gun")
                    {
                        name.SetData("character_gun_lic", 0);
                        Main.SavePlayerInformation(name);
                        Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, "Oduzeli ste dozvolu.");
                        Main.DisplayErrorMessage(name, NotifyType.Warning, NotifyPosition.BottomCenter, "Oduzeta vam je dozvola za oruzije od strane policajca" + AccountManage.GetCharacterName(player) + "");
                    }
                }
            }
        }
    }
    [RemoteEvent("mdcPersonDetails")]
    public void CMD_ShowPersonDetails(Player player, string name)
    {
        Task.Run(() =>
        {
            string gender = "Error";
            int targetsqlid = -1;

            List<dynamic> data = new List<dynamic>();
            List<dynamic> notes = new List<dynamic>();
            List<dynamic> fines = new List<dynamic>();
            List<dynamic> warrant = new List<dynamic>();
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `char`,`id`,`age`,`name`,`group`,`character_cellphone`,`car_lic`,`moto_lic`,`fly_lic`,`fish_lic`,`gun_lic` FROM `characters` WHERE `name` like '%" + name + "%' ", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    string data2txt = string.Empty;
                    string datatxt = string.Empty;
                    while (reader.Read())
                    {
                        var character = API.Shared.FromJson(reader.GetString("char"));
                        switch ((int)character.Gender)
                        {
                            case 0:
                                gender = "Musko";
                                break;
                            case 1:
                                gender = "Zensko";
                                break;
                            default:
                                break;
                        }
                        if (targetsqlid == -1)
                        {
                            targetsqlid = reader.GetInt32("id");
                        }
                        data.Add(new { Name = reader.GetString("name"), gender, age = reader.GetByte("age"), group = reader.GetString("group"), phone = reader.GetString("character_cellphone"), car_lic = reader.GetString("car_lic"), moto_lic = reader.GetString("moto_lic"),fly_lic = reader.GetString("fly_lic"),fish_lic = reader.GetString("fish_lic"), gun_lic = reader.GetString("gun_lic") });
                    }
                }
                Mainpipeline.Close();
            }
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `id`,`officer`,`suspect`,`description`,`datetime` FROM `notes` WHERE `suspect` = '" + name + "'", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notes.Add(new { id = reader.GetInt32("id"), officer = reader.GetString("officer"), suspect = reader.GetString("suspect"), description = reader.GetString("description"), datetime = reader.GetDateTime("datetime") });
                    }
                }
                Mainpipeline.Close();
            }
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `id`,`officer`,`suspect`,`description`,`date`,`ispaid`,`price` FROM `fines` WHERE `suspect` = '" + name + "'", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fines.Add(new { id = reader.GetInt32("id"), officer = reader.GetString("officer"), suspect = reader.GetString("suspect"), description = reader.GetString("description"), datetime = reader.GetDateTime("date"), price = reader.GetInt16("price"), ispaid = reader.GetByte("ispaid") });
                    }
                }
                Mainpipeline.Close();
            }

            NAPI.ClientEventThreadSafe.TriggerClientEvent(player,"sendPersonDetails", NAPI.Util.ToJson(data), NAPI.Util.ToJson(notes), NAPI.Util.ToJson(fines), NAPI.Util.ToJson(warrant));
        });
    }

    public static void ShowCivilMenu(Player player)
    {
            List<dynamic> fines = new List<dynamic>();

            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT `id`,`officer`,`suspect`,`description`,`date`,`ispaid`,`price` FROM `fines` WHERE `suspect` = '" + player.GetData<dynamic>("character_name") + "'", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetByte("ispaid") == 0)
                        {
                            fines.Add(new { id = reader.GetInt32("id"), officer = reader.GetString("officer"), suspect = reader.GetString("suspect"), description = reader.GetString("description"), datetime = reader.GetDateTime("date"), price = reader.GetInt16("price"), ispaid = reader.GetByte("ispaid") });
                        }
                    }
                }
                Mainpipeline.Close();
            }
            player.TriggerEvent("ShowCivilPDMenu", NAPI.Util.ToJson(fines));

    }

    [RemoteEvent("trypayfine")]
    public void TryPayFine(Player player, int id, int price)
    {
            try
            {
                bool canpay = false;
                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                {
                    Mainpipeline.Open();
                    MySqlCommand query = new MySqlCommand("SELECT `ispaid` FROM `fines`  WHERE `id`=" + id + "", Mainpipeline);
                    MySqlDataReader reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetInt16("ispaid") == 1)
                        {
                            canpay = false;
                            break;
                        }
                        else
                        {
                            canpay = true;
                            break;
                        }
                    }
                    Mainpipeline.Close();
                }
                if (canpay == false)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Alert, NotifyPosition.BottomCenter, "Gradjanin nema dovoljno novca!");
                    return;
                }
                if (Main.GetPlayerBank(player) < price)
                {
                    Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, " $" + price + " kayna nije placena!!");
                    return;
                }
                Main.GivePlayerMoneyBank(player, -price);

                using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
                {
                    Mainpipeline.Open();
                    MySqlCommand query = new MySqlCommand("UPDATE `fines` SET `ispaid`=1  WHERE `id`=" + id + "", Mainpipeline);
                    query.ExecuteNonQuery();
                    Mainpipeline.Close();
                }
                player.TriggerEvent("finepaided", id);
                Main.DisplayErrorMessage(player, NotifyType.Success, NotifyPosition.BottomCenter, " $" + price + " kazna je placena!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
    }

    [RemoteEvent("mdc_911_list")]
    public static void Lista_911(Player Client)
    {
        List<dynamic> data = new List<dynamic>();
        int index = 0;
        foreach (var call in Call_911)
        {
            if (call.active == 1)
            {
                data.Add(new { Index = index, Player = AccountManage.GetCharacterName(call.Player), Distance = call.Player.Position.DistanceTo(Client.Position).ToString("0") });
            }
            index++;
        }
        Client.TriggerEvent("mdc_response_911list", NAPI.Util.ToJson(data));
    }
    #endregion MDC

    public static void SendMessageToAllPolice(string message)
    {
        foreach (var item in NAPI.Pools.GetAllPlayers())
        {
            if (AccountManage.GetPlayerConnected(item))
            {
                if (AccountManage.GetPlayerGroup(item) == 1)
                {
                    // item.SendChatMessage(message);
                    Main.SendCustomChatMessasge(item, message);
                }
            }
        }
    }

    public static void delpolcar(Player player)
    {
        if(!player.IsInVehicle){
            return;
        }
        Vehicle veh = player.Vehicle;
        if(veh.GetData<dynamic>("polveh") == true)
        {
            veh.Delete();
        }
        else {
            Main.DisplayErrorMessage(player, NotifyType.Error, NotifyPosition.BottomCenter, "Ovo nije LSPD vozilo!");
            return;
        }
    }

    [RemoteEvent("lspdguns")]
    public static void lspdguns(Player Client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste lampu");
                        NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Flashlight , 0);
                        break;
                    }
                case 1:
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Pendrek");
                        NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Nightstick , 0);
                        break;
                    }
                case 2:
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Tazer");
                        NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Stungun , 0);
                        break;
                    }
                case 3:
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Pistolj");
                        NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Heavypistol , 250);
                        break;
                    }
                case 4:
                    {
                        if (AccountManage.GetPlayerRank(Client) < 4)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Niste rank 4+");
                            return;
                        }
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Pumparicu");
                        NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Pumpshotgun , 150);
                        break;
                    }
                case 5:
                    {
                        if (AccountManage.GetPlayerRank(Client) < 5)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Niste rank 5+");
                            return;
                        }
                        
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Pumparicu");
                        NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Pumpshotgun_mk2 , 150);
                        break;
                    }
                case 6:
                    {
                        if (AccountManage.GetPlayerRank(Client) < 2)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Niste rank 2+");
                            return;
                        }
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste SMG");
                        NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Assaultsmg , 300);
                        break;
                    }
                
                case 7:
                    {
                        if (AccountManage.GetPlayerRank(Client) < 3)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Niste rank 3+");
                            return;
                        }
                        
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste PDW");
                        NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Combatpdw , 300);
                        break;
                    }
                case 8:
                    {
                        if (AccountManage.GetPlayerRank(Client) < 4)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Niste rank 4+");
                            return;
                        }
                        
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Assaultrifle");
                        NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Assaultrifle , 300);
                        break;
                    }
                case 9:
                    {
                        if (AccountManage.GetPlayerRank(Client) < 2)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Niste rank 2+");
                            return;
                        }
                        
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Specialcarbine");
                        NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Specialcarbine , 300);
                        break;
                    }
                case 10:
                    {
                        if (AccountManage.GetPlayerRank(Client) < 7)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Niste rank 7+");
                            return;
                        }
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Snajper");
                        NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Heavysniper , 60);
                        break;
                    }
                case 11:
                    {
                        
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Radio");
                        Inventory.GiveItemToInventory(Client, 23, 1);
                        break;
                    }
                case 12:
                    {
                        
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Pancir");
                        Client.Armor = 100;
                        break;
                    }
                case 13:
                    {
                        
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Prvu Pomoc");
                        Client.Health = 100;
                        break;
                    }
                case 14:
                    {
                        
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Advanced Rifle");
                        NAPI.Player.GivePlayerWeapon(Client, WeaponHash.Advancedrifle , 300);
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    [RemoteEvent("getlspdvehs")]
    public void getlspdvehs(Player Client, int index)
    {
        try
        {
            Random random = new Random();
            int randomIndex = random.Next(spawnLocations.Count);
            Vector3 randomLocation = spawnLocations[randomIndex];

            switch (index)
            {
                case 0:
                    {
                        VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("police");
                        var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, randomLocation, 90.14f, 0, 0);
                        vehicle.Dimension = 0;
                        Random tbla = new Random();
                        int tabla = tbla.Next(100, 999);
                        string finaltabl = "P-" + tabla;
                        vehicle.NumberPlate = finaltabl;
                        vehicle.PrimaryColor = 111;
                        vehicle.SecondaryColor = 111;
                        Main.SetVehicleFuel(vehicle, 90.0);
                        vehicle.SetData("polveh", true);
                        Client.SetIntoVehicle(vehicle, 0);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Stvorili ste vozilo");
                        break;
                    }
                case 1:
                    {
                        VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("police2");
                        var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, randomLocation, 90.1f, 0, 0);
                        vehicle.Dimension = 0;
                        Random tbla = new Random();
                        int tabla = tbla.Next(100, 999);
                        string finaltabl = "P-" + tabla;
                        vehicle.NumberPlate = finaltabl;
                        vehicle.PrimaryColor = 111;
                        vehicle.SecondaryColor = 111;
                        Main.SetVehicleFuel(vehicle, 90.0);
                        vehicle.SetData("polveh", true);
                        Client.SetIntoVehicle(vehicle, 0);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Stvorili ste vozilo");
                        break;
                    }
                case 2:
                    {
                        VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("police3");
                        var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, randomLocation, 90.1f, 0, 0);
                        vehicle.Dimension = 0;
                        Random tbla = new Random();
                        int tabla = tbla.Next(100, 999);
                        string finaltabl = "P-" + tabla;
                        vehicle.NumberPlate = finaltabl;
                        vehicle.PrimaryColor = 111;
                        vehicle.SecondaryColor = 111;
                        Main.SetVehicleFuel(vehicle, 90.0);
                        vehicle.SetData("polveh", true);
                        Client.SetIntoVehicle(vehicle, 0);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Stvorili ste vozilo");
                        break;
                    }
                case 3:
                    {
                        VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("police4");
                        var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, randomLocation, 90.1f, 0, 0);
                        vehicle.Dimension = 0;
                        Random tbla = new Random();
                        int tabla = tbla.Next(100, 999);
                        string finaltabl = "P-" + tabla;
                        vehicle.NumberPlate = finaltabl;
                        vehicle.PrimaryColor = 111;
                        vehicle.SecondaryColor = 111;
                        Main.SetVehicleFuel(vehicle, 90.0);
                        vehicle.SetData("polveh", true);
                        Client.SetIntoVehicle(vehicle, 0);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Stvorili ste vozilo");
                        break;
                    }
                case 4:
                    {
                        VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("fbi2");
                        var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, randomLocation, 90.1f, 0, 0);
                        vehicle.Dimension = 0;
                        Random tbla = new Random();
                        int tabla = tbla.Next(100, 999);
                        string finaltabl = "P-" + tabla;
                        vehicle.NumberPlate = finaltabl;
                        vehicle.PrimaryColor = 111;
                        vehicle.SecondaryColor = 111;
                        Main.SetVehicleFuel(vehicle, 90.0);
                        vehicle.SetData("polveh", true);
                        Client.SetIntoVehicle(vehicle, 0);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Stvorili ste vozilo");
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
