using GTANetworkAPI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;
using MySql.Data.MySqlClient;

public class teleporter : Script
{

    private static List<Vector3> markpos = new List<Vector3>()
    {
        new Vector3(936.01275, 47.1613, 81.209274),
        new Vector3(1089.78, 206.71, -49.20),

    };

    [ServerEvent(Event.ResourceStart)]
    public static void OnTeleStart()
    {
        try
            {
                foreach (Vector3 vec in markpos)
                {
                    NAPI.Marker.CreateMarker(30, vec, new Vector3(), new Vector3(), 0.6f, new Color(221, 255, 0));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        
    }

    public static void Teleporter(Player c)
    {
        //In casino
        if(Main.IsInRangeOfPoint(c.Position, new Vector3(936.01275, 47.1613, 81.209274), 2))
        {
            c.Position = new Vector3(1089.78, 206.71, -48.99);
        }
        else if(Main.IsInRangeOfPoint(c.Position, new Vector3(1089.78, 206.71, -48.99), 2))
        {
            c.Position = new Vector3(936.01275, 47.1613, 81.209274);
        }
    }
}