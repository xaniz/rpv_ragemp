using GTANetworkAPI;
using GTANetworkMethods;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

class GraffitiWar : Script
{
    public static bool isWar = false;
    public static Dictionary<int, uint> Name = new Dictionary<int, uint>()
    {
        {4, NAPI.Util.GetHashKey("graffitifamilies")},
        {5, NAPI.Util.GetHashKey("graffitiballas")},
        {6, NAPI.Util.GetHashKey("graffitivagos")},
        {7, NAPI.Util.GetHashKey("graffitimarabunta")},
    };
    public static uint GetModel(int nom)
    {
        if (!Name.ContainsKey(nom))
        {
            return 0;
        }
        else
        {
            return Name[nom];
        }
    }
    [ServerEvent(Event.ResourceStart)]
    public void ResSX()
    {
        try
        {
            using (MySqlConnection Mainpipeline = new MySqlConnection(Main.myConnectionString))
            {
                Mainpipeline.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM `graf`;", Mainpipeline);

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                            int id = reader.GetInt32("id");
                            Vector3 pos = JsonConvert.DeserializeObject<Vector3>(reader.GetString("pos"));
                            Vector3 rot = JsonConvert.DeserializeObject<Vector3>(reader.GetString("rot"));
                            int gang = reader.GetInt32("band");
                            new Graffiti(id, pos, rot, gang);
                    }
                }
                Mainpipeline.Close();
            }
        }
        catch (Exception e) { Console.WriteLine(e); }

    } 
}

internal class Graffiti 
{
    public static Dictionary<int, Graffiti> List = new Dictionary<int, Graffiti>();
    public int ID { get; set; }
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public int Gang { get; set; } = 0;
    [JsonIgnore]
    public GTANetworkAPI.Object Handle { get; set;}
    [JsonIgnore]
    public GTANetworkAPI.ColShape Shape { get; set;}

    public Graffiti(int id, Vector3 pos, Vector3 rot, int gang)
    {
        ID = id; Position = pos; Rotation = rot; Gang = gang;

        Handle = NAPI.Object.CreateObject(GraffitiWar.GetModel(Gang), Position, Rotation);
        Shape = NAPI.ColShape.CreateCylinderColShape(Position, 8, 5, 0);
        Shape.OnEntityEnterColShape += (s, entity) =>
        {
            try
            {
                entity.SetData("graffiti", this);
            }
            catch (Exception e) { Console.WriteLine("shape.OnEntityEnterColshape: " + e.Message); }
        };
        Shape.OnEntityExitColShape += (s, entity) =>
        {
            try
            {
                entity.ResetData("graffiti");
            }
            catch (Exception e) { Console.WriteLine("shape.OnEntityEnterColshape: " + e.Message); }
        };
        List.Add(ID, this);
    }


    public void SetGang(int gang)
    {
        try
        {
            Graffiti parent = List[ID];
            Handle.Delete();
            Gang = gang;
            Handle = NAPI.Object.CreateObject(GraffitiWar.GetModel(Gang), Position, Rotation);
            parent.Save();
        }
        catch {}
    }

    public void Save() 
    {
        try 
        {
            Main.CreateMySqlCommand("UPDATE `graf` SET `band`='" + Gang + "' WHERE `id`='" + ID + "'");
        }
        catch{}
    }
    
    

}