using GTANetworkAPI;

class Siren_Sync : Script
{



    [RemoteEvent("CruiserLight")]
    public void CruiserLight(Player client, byte type, bool stats)
    {
        if (client.IsInVehicle && client.VehicleSeat == (int)VehicleSeat.Driver)
        {
            switch (type)
            {
                case 0:
                    client.Vehicle.SetSharedData("SirenLight", stats);

                    break;
                case 1:
                    client.Vehicle.SetSharedData("SirenSound", stats);

                    break;
                default:
                    break;
            }
        }
    }
}
