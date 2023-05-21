// za mehanicara postoji UI za chip tuning, samo povezati


using GTANetworkAPI;
using System;

class MechanicFaction : Script
{

    public static int PRICE_PER_RESOURCE = 150;
    public MechanicFaction()
    {
        API.Shared.CreateTextLabel("~y~** ~w~Kupovina delova ~y~**~w~~n~~n~Koristite [ ~b~Y~w~ ] da kupite delove", new Vector3(-344.616, -130.8098, 39.00968) + new Vector3(0, 0, 0.5f), 10.0f, 2.2f, 4, new Color(221, 255, 0, 255), false, 0);
        NAPI.Marker.CreateMarker(27, new Vector3(-344.616, -130.8098, 39.00968) - new Vector3(0, 0, 0.9f), new Vector3(), new Vector3(), 1.0f, new Color(221, 255, 0, 255));

        API.Shared.CreateTextLabel("~y~(( ~b~Garaza ~y~))~w~~n~~n~Koristite [ ~b~Y~w~ ] da otvorite garazu", new Vector3(-345.3417, -123.1393, 39.00966) + new Vector3(0, 0, 0.5f), 10.0f, 2.2f, 4, new Color(221, 255, 0, 255), false, 0);
        NAPI.Marker.CreateMarker(27, new Vector3(-345.3417, -123.1393, 39.00966) - new Vector3(0, 0, 0.9f), new Vector3(), new Vector3(), 1.0f, new Color(221, 255, 0, 255));

        API.Shared.CreateTextLabel("~h~~y~(( ~b~Parking ~y~))~w~~n~~n~Koristite [ ~b~E~w~ ] da parkirate vozilo", new Vector3(-354.0995, -115.8306, 38.69666) + new Vector3(0, 0, 0.5f), 10.0f, 2.2f, 4, new Color(221, 255, 0, 255), false, 0);
        NAPI.Marker.CreateMarker(27, new Vector3(-354.0995, -115.8306, 38.69666) - new Vector3(0, 0, 0.9f), new Vector3(), new Vector3(), 1.0f, new Color(221, 255, 0, 255));

        API.Shared.CreateTextLabel("/chip", new Vector3(-327.12, -144.71, 39.05) + new Vector3(0, 0, 0.5f), 10.0f, 2.2f, 4, new Color(221, 255, 0, 255), false, 0);
    }

    [RemoteEvent("mechdel")]
    public static void mechdel(Player Client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        if (Main.GetPlayerMoney(Client) < 1000)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 8, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate mesta u inventary");
                            return;
                        }
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Fix Kit");
                        Inventory.GiveItemToInventory(Client, 8, 1);
                        Main.GivePlayerMoney(Client, -1000);
                        break;
                    }
                case 1:
                    {
                        if (Main.GetPlayerMoney(Client) < 500)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 21, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate mesta u inventary");
                            return;
                        }
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Kanister");
                        Inventory.GiveItemToInventory(Client, 21, 1);
                        Main.GivePlayerMoney(Client, -500);
                        break;
                    }
                case 2:
                    {
                        if (Main.GetPlayerMoney(Client) < 4000)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Warning, NotifyPosition.BottomCenter, "Nemate dovoljno novca");
                            return;
                        }
                        if (Inventory.Check_InventoryWeight_With_ItemAmount(Client, 79, 1, Inventory.Max_Inventory_Weight(Client)))
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate mesta u inventary");
                            return;
                        }
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Uzeli ste Chip");
                        Inventory.GiveItemToInventory(Client, 79, 1);
                        Main.GivePlayerMoney(Client, -4000);
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    [RemoteEvent("getmehvehs")]
    public static void getmehvehs(Player Client, int index)
    {
        try
        {

            switch (index)
            {
                case 0:
                    {
                        VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("towtruck");
                        var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, new Vector3(-358.45, -114.63, 38.69), 72.23f, 0, 0);
                        vehicle.Dimension = 0;
                        Random tbla = new Random();
                        int tabla = tbla.Next(100, 999);
                        string finaltabl = "MEH-" + tabla;
                        vehicle.NumberPlate = finaltabl;
                        vehicle.PrimaryColor = 111;
                        vehicle.SecondaryColor = 111;
                        Main.SetVehicleFuel(vehicle, 90.0);
                        vehicle.SetData("mehveh", true);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Stvorili ste vozilo");
                        Client.SetIntoVehicle(vehicle, 0);
                        break;
                    }
                case 1:
                    {
                        VehicleHash vgolf = (VehicleHash)NAPI.Util.GetHashKey("towtruck2");
                        var vehicle = NAPI.Vehicle.CreateVehicle(vgolf, new Vector3(-358.45, -114.63, 38.69), 72.23f, 0, 0);
                        vehicle.Dimension = 0;
                        Random tbla = new Random();
                        int tabla = tbla.Next(100, 999);
                        string finaltabl = "MEH-" + tabla;
                        vehicle.NumberPlate = finaltabl;
                        vehicle.PrimaryColor = 111;
                        vehicle.SecondaryColor = 111;
                        Main.SetVehicleFuel(vehicle, 90.0);
                        vehicle.SetData("mehveh", true);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Stvorili ste vozilo");
                        Client.SetIntoVehicle(vehicle, 0);
                        break;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static void delmehcar(Player player)
    {
        
    }

    public static void KeyPressE(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-354.0995, -115.8306, 38.69666), 3.0f))
        {
            if(!Client.IsInVehicle) return;            
            Vehicle veh = Client.Vehicle;
            if(veh.GetData<dynamic>("mehveh") == true)
            {
                veh.Delete();
            }
            else {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Ovo nije Mehanicarsko vozilo!");
                return;
            }
        }
    }

    [Command("chip")]
    public static void ChipCMD(Player Client)
    {
        if (Main.IsInRangeOfPoint(Client.Position, new Vector3(-327.12, -144.71, 39.05), 3.0f))
        {

        
        if (Inventory.GetPlayerItemFromInventory(Client, 79) > 0)
        {
            Vehicle veh = Client.Vehicle;
            if (Client.IsInVehicle)
            {

                if (NAPI.Data.HasEntityData(veh, "vehicle_repairing"))
                {
                    if (NAPI.Data.GetEntityData(veh, "vehicle_repairing") == true)
                    {
                        Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vozilo se vec cipuje!");
                        return;
                    }
                }

                if (Inventory.GetPlayerItemFromInventory(Client, 79) < 1)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate Chip!");
                    return;
                }

                NAPI.Data.SetEntityData(veh, "vehicle_repairing", true);
                NAPI.Task.Run(() => 
                {
                    if (!Client.Exists) return;
                    if (!veh.Exists) return;
                    if (!Client.IsInVehicle)
                    {
                        Client.StopAnimation();
                        Main.DisplaySubtitle(Client, "~y~Udaljili ste se od vozila i otkazali chipovanje.", 1);
                        NAPI.Data.SetEntityData(veh, "vehicle_repairing", false);
                        return;
                    }
                    NAPI.Data.SetEntityData(veh, "vehicle_repairing", false);
                    Inventory.RemoveItemByType(Client, 79, 1);
                    Random rnd = new Random();
                    int id = rnd.Next(8, 12);
                    Client.TriggerEvent("svenm", id, id);
                    Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Vozilo je uspesno chipovano");
                }, delayTime: 6000);
            }
        }
        else
        {
            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate alat za chipovanje!");
        }
        return;
    }
    }

}
