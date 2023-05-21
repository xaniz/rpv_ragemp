using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
class Services : Script
{

    public class ServiceEnum : IEquatable<ServiceEnum>
    {
        public int id { get; set; }
        public Player caller { get; set; }
        public int active { get; set; }
        public int faction { get; set; }
        public int job { get; set; }
        public DateTime dateTime { get; set; }
        public Vector3 position { get; set; }

        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ServiceEnum objAsPart = obj as ServiceEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(ServiceEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }

    public static List<ServiceEnum> service_system = new List<ServiceEnum>();

    public Services()
    {
        for (int i = 0; i < 100; i++)
        {
            service_system.Add(new ServiceEnum { id = i, caller = null, active = 0, faction = 0, job = 0, position = new Vector3() });
        }
    }

    public static void Remove_Service(Player player)
    {
        foreach (var service in service_system)
        {
            if (service.active == 1 && service.caller == player)
            {

                service.active = 0;
                service.faction = 0;
                service.job = 0;
                service.position = new Vector3();
                service.caller = null;

            }
        }
    }

    public static void Call_Service(Player player, int number)
    {
        foreach (var service in service_system)
        {
            if (service.caller == null && service.active == 0)
            {
                player.TriggerEvent("service_accept", number);

                service.caller = player;
                service.active = 1;
                service.position = player.Position;
                service.dateTime = DateTime.Now;


                if (number == 911)
                {
                    service.job = 0;
                    service.faction = 1;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData<dynamic>("status") == true && AccountManage.GetPlayerGroup(police) == 1)
                        {
                            police.SendNotification("~b~[CENTRALA]~n~~n~~w~Gradjanin:~g~ " + AccountManage.GetCharacterName(player) + "~n~~w~Tel.:~g~ " + cellphoneSystem.GetPlayerNumber(player) + "");
                        }
                    }
                    InteractMenu_New.SendNotificationInfo(player, "Sacekajte malo pre nego sto ponovo pozovete.");
                }
                else if (number == 912)
                {
                    service.job = 0;
                    service.faction = 2;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData<dynamic>("status") == true && AccountManage.GetPlayerGroup(police) == 2)
                        {
                            police.SendNotification("~b~[CENTRALA]~n~~n~~w~Gradjanin:~g~ " + AccountManage.GetCharacterName(player) + "~n~~w~Tel:~g~ " + cellphoneSystem.GetPlayerNumber(player) + "");
                        }
                    }
                    InteractMenu_New.SendNotificationInfo(player, "Sacekajte malo pre nego sto ponovo pozovete.");
                }
                else if (number == 913)
                {
                    service.faction = 6;
                    service.job = 0;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData<dynamic>("status") == true && FactionManage.GetPlayerGroupType(player) == 6)
                        {
                            police.SendNotification("~y~[CENTRALA]~n~~n~~w~Gradjanin:~g~ " + AccountManage.GetCharacterName(player) + "~n~~w~Tel:~g~ " + cellphoneSystem.GetPlayerNumber(player) + "");
                        }
                    }
                    InteractMenu_New.SendNotificationInfo(player, "Sacekajte malo pre nego sto ponovo pozovete.");
                }
                else if (number == 914)
                {
                    service.faction = 5;
                    service.job = 0;
                    foreach (var police in NAPI.Pools.GetAllPlayers())
                    {
                        if (police.GetData<dynamic>("status") == true && FactionManage.GetPlayerGroupType(police) == 5)
                        {
                            police.SendNotification("~y~[CENTRALA]~n~~n~~w~Gradjanin:~g~ " + AccountManage.GetCharacterName(player) + "~n~~w~Tel:~g~ " + cellphoneSystem.GetPlayerNumber(player) + "");
                        }
                    }
                    InteractMenu_New.SendNotificationInfo(player, "Sacekajte malo pre nego sto ponovo pozovete.");
                }
                return;
            }
        }
        player.SendNotification("Greska: Vec ste pozvali hitnu sluzbu!");
        player.TriggerEvent("service_cancel");
    }

    public static void DisplayCalls(Player player)
    {

        if (AccountManage.GetPlayerGroup(player) == 1)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && AccountManage.GetPlayerGroup(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = " " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " metara od vas" });
                }
            }
            player.TriggerEvent("Display_Calls", "", API.Shared.ToJson(menu_item_list));
        }
        else if (AccountManage.GetPlayerGroup(player) == 2)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && AccountManage.GetPlayerGroup(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = " " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " metara od vas" });
                }
            }
            player.TriggerEvent("Display_Calls", "Hitna pomoc - Pozivi", API.Shared.ToJson(menu_item_list));
        }
        else if (FactionManage.GetPlayerGroupType(player) == 6)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && FactionManage.GetPlayerGroupType(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = " " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " metara od vas" });
                }
            }
            player.TriggerEvent("Display_Calls", "Mehanicari - Pozivi", API.Shared.ToJson(menu_item_list));
        }
        else if (FactionManage.GetPlayerGroupType(player) == 5)
        {
            List<dynamic> menu_item_list = new List<dynamic>();
            foreach (var service in service_system)
            {
                if (service.active == 1 && FactionManage.GetPlayerGroupType(player) == service.faction)
                {
                    menu_item_list.Add(new { index = service.id, name = AccountManage.GetCharacterName(service.caller), timeago = service.dateTime, location = " " + service.position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + " metara od vas" });
                }
            }
            player.TriggerEvent("Display_Calls", "Taksi - Pozivi", API.Shared.ToJson(menu_item_list));
        }

    }

    [RemoteEvent("Service_Track_Server")]
    public static void Service_Track_Server(Player player, int id)
    {
        if (service_system[id].active == 1)
        {
            InteractMenu_New.SendNotificationInfo(service_system[id].caller, "Sluzbenik je prihvatio Vas poziv. Ne udaljavajte se od mesta gde ste zvali, u suprotnom ce poziv biti prekinut!");

            player.SendNotification("GPS-lokcaija ~b~" + AccountManage.GetCharacterName(service_system[id].caller) + "~w~ je postavljena i on je ~c~" + service_system[id].position.DistanceTo(player.Position).ToString("#.##").Replace(",", ".") + "m udaljen od Vas.");
            player.TriggerEvent("gps_set_loc", service_system[id].position.X, service_system[id].position.Y);
        }
    }

    [RemoteEvent("Service_Remove_Server")]
    public static void Service_Remove_Server(Player player, int id)
    {
        if (service_system[id].active == 1)
        {
            player.SendNotification("Poziv ~c~#" + id + "~w~ je resen.");
            player.SendNotification("Vas poziv je resen.");

            service_system[id].caller.TriggerEvent("service_cancel");


            service_system[id].job = 0;
            service_system[id].active = 0;
            service_system[id].faction = 0;
            service_system[id].position = new Vector3();

            service_system[id].caller = null;
            DisplayCalls(player);

        }
    }
}

