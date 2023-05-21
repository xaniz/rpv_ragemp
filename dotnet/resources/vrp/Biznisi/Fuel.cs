using GTANetworkAPI;
using System;
using System.Collections.Generic;

class FuelBusiness : Script
{
    public static List<dynamic> fuelstation = new List<dynamic>();

    public FuelBusiness()
    {

        fuelstation.Add(new { MarkerType = 1, position = new Vector3(-2096.6377, -319.1941, 13.168626)});
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(-1436.5221, -277.19644, 45.77684)});
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(-724.713, -934.63934, 19.21393) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(265.02798, -1262.5254, 29.292955) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(-69.97061, -1761.983, 29.52496) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(1208.4637, -1402.6729, 34.79347) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(1181.5374, -330.25455, 69.316536) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(620.8873, 269.0329, 103.089386) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(-2555.3188, 2334.358, 33.078026) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(-94.51809, 6419.8037, 31.045828) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(179.74481, 6603.9756, 32.046753) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(1702.6106, 6416.0996, 32.75993) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(2005.033, 3774.485, 32.403614) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(1785.6019, 3330.3628, 41.386356) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(2679.7012, 3264.7742, 55.409393) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(2581.3345, 361.55087, 108.46884) });
        fuelstation.Add(new { MarkerType = 1, position = new Vector3(-1799.35, 802.88, 138.65) });
        foreach (var atm in fuelstation)
        {
            NAPI.TextLabel.CreateTextLabel("Benzinska Pumpa ~w~[ ~g~E~w~ ]", atm.position, 16, 0.600f, 0, new Color(221, 255, 0, 150));
            //NAPI.Marker.CreateMarker(29, new Vector3(atm.position.X, atm.position.Y, atm.position.Z - -0.5), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

            Entity temp_blip;
            temp_blip = NAPI.Blip.CreateBlip(atm.position);
            NAPI.Blip.SetBlipName(temp_blip, "Benzinska Pumpa");
            NAPI.Blip.SetBlipSprite(temp_blip, 361);
            NAPI.Blip.SetBlipColor(temp_blip, 7);
            NAPI.Blip.SetBlipScale(temp_blip, 0.7f);
            NAPI.Blip.SetBlipShortRange(temp_blip, true);

        }
    }

    [Command("vhp")]
    public static void vhpcmd(Player client)
    {
        if (AccountManage.GetPlayerAdmin(client) < 8)
        {
            Main.SendErrorMessage(client, "Nemate permisije.");
            return;
        }
        float vhp = NAPI.Vehicle.GetVehicleBodyHealth(client.Vehicle);
        client.SendChatMessage("VHP:"+ vhp);
    }

    [RemoteEvent("refuelbut")]
    public static void CMD_refuelveh(Player Client)
    {
        foreach (var gsma in fuelstation)
        {
            if (Main.IsInRangeOfPoint(Client.Position, gsma.position, 15.0f))
            {
                double time = 100 - Main.GetVehicleFuel(Client.Vehicle);
                int rounded = (int)Math.Round(time, 0);

                if (!Client.IsInVehicle)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Morate biti u automobilu!");
                    return;
                }
                
                else if (Client.VehicleSeat != (int)VehicleSeat.Driver)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Morate biti na mestu vozaca!");
                    return;
                }
                else if (VehicleStreaming.GetEngineState(Client.Vehicle) == true)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Ugasite motor!");
                    return;
                }
                else if (Main.GetVehicleFuel(Client.Vehicle) >= 100.0)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vas automobil je dopunjen.");
                    return;
                }
                
                else if (Main.GetPlayerMoney(Client) < rounded * 4)
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca!");
                    return;
                }
                
                else
                {
                    float vhealth = NAPI.Vehicle.GetVehicleBodyHealth(Client.Vehicle);
                    if (vhealth > 10)
                    {
                    Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Tocenje...");
                    
                    NAPI.Task.Run(() =>
                    {
                        if (!Client.IsInVehicle)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Morate biti u automobilu!");
                            return;
                        }
                        
                        else if (Client.VehicleSeat != (int)VehicleSeat.Driver)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Morate biti na mestu vozaca!");
                            return;
                        }
                        else if (VehicleStreaming.GetEngineState(Client.Vehicle) == true)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Ugasite motor!");
                            return;
                        }
                        else if (Main.GetVehicleFuel(Client.Vehicle) >= 100.0)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vas automobil je dopunjen.");
                            return;
                        }
                        
                        else if (Main.GetPlayerMoney(Client) < rounded * 4)
                        {
                            Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Nemate dovoljno novca!");
                            return;
                        }
                        else if (!NAPI.Player.IsPlayerConnected(Client))
                        {
                            return;
                        }
                        
                        Main.SetVehicleFuel(Client.Vehicle, 99.0);
                        Main.GivePlayerMoney(Client, -rounded * 4);
                        Main.GiveCompanyMoney(4, rounded);
                        Main.UpdateMoneyDisplay(Client);
                        Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Vas automobil je napunjen.");
                        
                    }, delayTime: 5000);
                    }
                    else{
                        Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Rezervoar vozila je previse ostecen.");
                        return;
                    }

                }
            }
        }
    }
}