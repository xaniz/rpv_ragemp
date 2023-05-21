using GTANetworkAPI;
using System;
using System.Linq;


class Utils : Script
{

    public static void ClearChat(Player Client)
    {

    }


    public static double Truncate(float value, int digits)
    {
        double mult = Math.Pow(10.0, digits);
        double result = Math.Truncate(mult * value) / mult;
        return result;
    }

    public static Vehicle GetClosestVehicle(Player sender, float distance = 1000.0f)
    {
        Vehicle handleReturned = null;
        foreach (var veh in NAPI.Pools.GetAllVehicles())
        {
            Vector3 vehPos = NAPI.Entity.GetEntityPosition(veh);
            float distanceVehicleToPlayer = sender.Position.DistanceTo(vehPos);
            if (distanceVehicleToPlayer < distance)
            {
                distance = distanceVehicleToPlayer;
                handleReturned = veh;

            }
        }
        return handleReturned;
    }
    public static Player GetClosestPlayer(Player sender, float distance = 1000.0f)
    {
        Player handleReturned = null;
        foreach (var pl in NAPI.Player.GetPlayersInRadiusOfPlayer(distance, sender))
        {
            Vector3 vehPos = NAPI.Entity.GetEntityPosition(pl);
            float distanceVehicleToPlayer = sender.Position.DistanceTo(vehPos);
            if (distanceVehicleToPlayer < distance && sender != pl)
            {
                distance = distanceVehicleToPlayer;
                handleReturned = pl;

            }
        }
        return handleReturned;
    }
    public static void CreateVehicleEx(VehicleHash model, Vector3 pos, Vector3 rot, int color1, int color2, int dimension = 0, bool respawnable = false)
    {
        var heading = 0f; // Car heading
        var myVeh1 = NAPI.Vehicle.CreateVehicle((uint)model, pos, heading, 0, 0);
        NAPI.Data.SetEntityData(myVeh1, "RESPAWNABLE", respawnable);
        NAPI.Data.SetEntityData(myVeh1, "SPAWN_POS", pos);
        NAPI.Data.SetEntityData(myVeh1, "SPAWN_ROT", rot.Z);
    }

    public static void SetPlayerPosition(Player Client, Vector3 position, float rotation, bool in_vehicle = false)
    {
        if (in_vehicle == true)
        {
            if (Client.IsInVehicle)
            {
                if (Client.VehicleSeat == (int)VehicleSeat.Driver)
                {
                    NAPI.Entity.SetEntityPosition(Client, position);
                    NAPI.Entity.SetEntityRotation(Client.Vehicle, new Vector3(0, 0, rotation));
                    NAPI.Player.SetPlayerIntoVehicle(Client, Client.Vehicle, (int)VehicleSeat.Driver);
                }
            }
            else
            {
                NAPI.Entity.SetEntityPosition(Client, position);
                NAPI.Entity.SetEntityRotation(Client, new Vector3(0, 0, rotation));
            }
        }
        else
        {
            NAPI.Entity.SetEntityPosition(Client, position);
            NAPI.Entity.SetEntityRotation(Client, new Vector3(0, 0, rotation));
        }
    }

    public static void SetScreenEffectToPlayer(Player Client, string effectType, int time)
    {
        //NAPI.ClientEvent.TriggerClientEvent(Client, "ApplyScreenEffect", effectType, time);
    }

    public static void StopScreenEffectToPlayer(Player Client, string effectType)
    {
        //NAPI.ClientEvent.TriggerClientEvent(Client, "StopScreenEffect", effectType);
    }

    public static bool isRoleplayName(string name)
    {
        string pattern = "^([A-Z][a-z]+_[A-Z][a-z]+)$";
        return System.Text.RegularExpressions.Regex.IsMatch(name, pattern);
    }

    public static string RandomWords(int tamanho)
    {
        var chars = "ABCEKMOPTY";
        var random = new Random();
        var result = new string(
            Enumerable.Repeat(chars, tamanho)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
        return result;
    }

    public static string RandomNumbers(int tamanho)
    {
        var chars = "0123456789";
        var random = new Random();
        var result = new string(
            Enumerable.Repeat(chars, tamanho)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
        return result;
    }

}
