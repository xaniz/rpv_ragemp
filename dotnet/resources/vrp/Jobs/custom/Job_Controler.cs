using GTANetworkAPI;
using System;
using System.Collections.Generic;

public class Job_Controler : Script
{
    // public static string Farm = "Farm";
    // public static string Garbage = "Garbage";
    // public static string FoodDelivery = "FoodDelivery";
    // public static string Shipment = "Shipment";

    //public static string Taxi = "Farm";
    // public static string Farm = "Farm";
    // public static string Farm = "Farm";
    public enum Job { Farm = 1, Garbage = 2, FoodDelivery = 3, Shipment = 4 };

    public static List<CheckerJobEnum> JobVehicles = new List<CheckerJobEnum>();
    public class CheckerJobEnum
    {
        public Vehicle vehicle;
        public Player Client;
        // public int Job;
        public Enum job;
        public int Timer;

    }

    public static void AddVehicle(Vehicle veh, Player Client, Enum nima)
    {

        if (JobVehicles.Find(x => x.Client.Handle == Client.Handle) != null)
        {
            int index = JobVehicles.FindIndex(x => x.Client.Handle == Client.Handle);
            JobVehicles[index].vehicle = veh;
            JobVehicles[index].Timer = 190;
            JobVehicles[index].job = nima;
        }
        else
        {
            Job_Controler.JobVehicles.Add(new CheckerJobEnum { vehicle = veh, Client = Client, job = nima, Timer = 190 });
        }
    }

    public Job_Controler()
    {
        for (int i = 0; i < 100; i++)
        {
            CarInfos.Add(new CarInfoEnum());
            CarInfos[i].ResetData();
            CarInfos[i].id = i;

        }

    }

    public class CarInfoEnum : IEquatable<CarInfoEnum>
    {
        public int id { get; set; }
        public int job_id { get; set; }
        public string Number { get; set; }
        public VehicleHash Model { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public int Color1 { get; set; }
        public int Color2 { get; set; }
        public int Price { get; set; }

        public void ResetData()
        {
            id = 0;
            job_id = 0;
            Number = null;
            Position = new Vector3(0, 0, 0);
            Rotation = new Vector3(0, 0, 0);
            Color1 = 0;
            Color2 = 0;
            Price = 0;

        }

        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            CarInfoEnum objAsPart = obj as CarInfoEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(CarInfoEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }
    }
    public static List<CarInfoEnum> CarInfos = new List<CarInfoEnum>();

    public static void CreateVehicle(int jobid, VehicleHash model, Vector3 position, Vector3 rotation, int color1, int color2, string numberplate, string type)
    {
        foreach (var vehicle in CarInfos)
        {

            if (vehicle.Position.X == 0 && vehicle.Position.Y == 0)
            {

                vehicle.Position = position;
                vehicle.Rotation = rotation;
                vehicle.Color1 = color1;
                vehicle.Color2 = color2;
                vehicle.Number = numberplate;
                var veh = NAPI.Vehicle.CreateVehicle(model, position, rotation.Z, color1, color2, numberplate);
                NAPI.Data.SetEntityData(veh, "ACCESS", "WORK");
                NAPI.Data.SetEntityData(veh, "WORK", jobid);
                NAPI.Data.SetEntityData(veh, "TYPE", type);
                NAPI.Data.SetEntityData(veh, "NUMBER", vehicle.id);
                NAPI.Data.SetEntityData(veh, "ON_WORK", false);
                NAPI.Data.SetEntityData(veh, "DRIVER", null);
                Main.SetVehicleFuel(veh, 100.0);
                veh.SetSharedData("INTERACT", veh.Type);
                NAPI.Vehicle.SetVehicleEngineStatus(veh, false);
                break;
            }
        }
    }

    public static void SetPlayerJob(Player player, int jobid)
    {
        player.SetData("character_job", jobid);
    }
    public static int GetPlayerJob(Player player)
    {
        return player.GetData<dynamic>("job");
    }

    public static string PlayerJobName(Player player)
    {
        string type = "";
        int JobID = GetPlayerJob(player);
        switch (JobID)
        {
            case 0:
                {
                    type = "Nema";
                    break;
                }
            case 1:
                {
                    type = "Dostavljac Hrane";
                    break;
                }

            case 2:
                {
                    type = "Rudar";
                    break;
                }
            case 3:
                {
                    type = "Bus Vozac";
                    break;
                }
            case 4:
                {
                    type = "Haker";
                    break;
                }
            case 5:
                {
                    type = "Pilicar";
                    break;
                }
            case 6:
                {
                    type = "Elektricar";
                    break;
                }

        }
        return type;
    }
}