using GTANetworkAPI;

public class Taxi : Script
{
    public static void TaxiInit()
    {
        /*API.Shared.CreateTextLabel("~h~~y~(( ~b~Garaza ~y~))~w~~n~~n~Koristite [ ~b~Y~w~ ] da uzmete vozilo", new Vector3(895.233, -179.3091, 74.70026) + new Vector3(0, 0, 0.5f), 10.0f, 2.2f, 4, new Color(221, 255, 0, 255), false, 0);
        NAPI.Marker.CreateMarker(27, new Vector3(895.233, -179.3091, 74.70026) - new Vector3(0, 0, 0.9f), new Vector3(), new Vector3(), 1.0f, new Color(221, 255, 0, 255));

        API.Shared.CreateTextLabel("~h~~y~(( ~b~Garaza ~y~))~w~~n~~n~Koristite [ ~b~E~w~ ] da parkirate vozilo", new Vector3(901.3029, -145.2099, 76.61998) + new Vector3(0, 0, 0.5f), 10.0f, 2.2f, 4, new Color(221, 255, 0, 255), false, 0);
        NAPI.Marker.CreateMarker(27, new Vector3(901.3029, -145.2099, 76.61998) - new Vector3(0, 0, 0.9f), new Vector3(), new Vector3(), 1.0f, new Color(221, 255, 0, 255));
        */
    }

    /*public static void KeyPressY(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(895.233, -179.3091, 74.70026), 3.0f))
        {
            if (FactionManage.GetPlayerGroupID(Client) != 4)
            {
                InteractMenu_New.SendNotificationError(Client, "Niste taksista !");
                return;
            }
            FactionManage.DisplayFactionVehicles(Client);
        }
    }

    public static void KeyPressE(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(901.3029, -145.2099, 76.61998), 3.0f))
        {
            if (FactionManage.GetPlayerGroupID(Client) != 5)
            {
                InteractMenu_New.SendNotificationError(Client, "Niste taksista !");
                return;
            }

            if (Client.IsInVehicle)
            {
                for (int i = 0; i < FactionManage.MAX_FACTION_VEHICLES; i++)
                {
                    if (FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_entity[i] == NAPI.Player.GetPlayerVehicle(Client))
                    {
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_name[i] = "Livre";
                        FactionManage.faction_data[AccountManage.GetPlayerGroup(Client)].faction_vehicle_owned[i] = "Unknown";
                        if (Client.IsInVehicle) Client.Vehicle.Delete();
                    }
                }
            }
        }
    }

    //
    [Command("taximetar", "Koristite: /taximetar [1-200]")]
    public void CMD_tarifa(Player Client, int preço)
    {
        if (FactionManage.GetPlayerGroupID(Client) != 5)
        {
            InteractMenu_New.SendNotificationError(Client, "Niste taksista !");
            return;
        }


        if (Client.IsInVehicle && Client.VehicleSeat == (int)VehicleSeat.Driver && (NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)NAPI.Util.VehicleNameToModel("Taxi") || NAPI.Entity.GetEntityModel(Client.Vehicle) == (uint)NAPI.Util.VehicleNameToModel("Rentalbus")))
        {
            if (!Client.Vehicle.HasData("TransportDuty"))
            {
                if (preço < 1 || preço > 200)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Cena ne moze biti manja od 1 ili veca od 200$.");
                    return;
                }


                Client.Vehicle.SetData<dynamic>("TransportDuty", true);
                Client.Vehicle.SetData<dynamic>("TransportPrice", preço);
                Client.Vehicle.SetData<dynamic>("TransportFee", 0);
                Client.Vehicle.SetData<dynamic>("TransportTime", 0);
                Client.Vehicle.SetData<dynamic>("TransportDriver", Client);

                Main.SendCustomChatMessasge(Client, "Taximetar cena je: ~y~$" + preço.ToString("N0") + "~w~.");

                if (!Client.HasData("announceTaxi"))
                {
                    Client.SetData<dynamic>("announceTaxi", true);
                    NAPI.Task.Run(() =>
                    {

                        Client.ResetData("announceTaxi");
                    }, delayTime: 10000);

                    Main.SendCustomChatToAll("~y~* [Taxi] Taxi vozac " + AccountManage.GetCharacterName(Client) + " je na duznosti, cena voznje: $" + preço.ToString("N0") + ".");

                }

            }
            else
            {
                Client.TriggerEvent("update_taxi_fare", false, 0, 0, false);

                var players_in_vehicle = NAPI.Pools.GetAllPlayers();
                foreach (var i in players_in_vehicle)
                {
                    if (i.GetData<dynamic>("status") == true && Client.Vehicle == i.Vehicle && i.VehicleSeat != (int)VehicleSeat.Driver && i.GetData<dynamic>("TaxiFee") >= 0)
                    {
                        Main.GivePlayerSalary(i, -i.GetData<dynamic>("TaxiFee"));
                        i.SetData<dynamic>("TaxiFee", 0);
                        Main.SendCustomChatMessasge(i, "~y~*~w~ Stigli ste na zeljenu destinaciju, Vas racun iznosi: ~g~$" + i.GetData<dynamic>("TaxiFee").ToString("N0") + "~w~ .");
                        i.TriggerEvent("update_taxi_fare", false, 0, 0, false);
                    }
                }

                Client.Vehicle.SetData<dynamic>("TransportDuty", false);
                Client.Vehicle.SetData<dynamic>("TransportPrice", 0);
                Client.Vehicle.SetData<dynamic>("TransportFee", 0);
                Client.Vehicle.SetData<dynamic>("TransportTime", 0);
                Client.Vehicle.ResetData("TransportDuty");
            }
        }
        else Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste taksista.");
    }*/
    
}