/*
    Data generated using a custom made by Tom Grobbe.
    Data source: GTA V <update>_overlays.xml files.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using System.IO;

public class TattooInfo:Script
{
    public enum TattooZone
    {
        ZONE_TORSO = 0,
        ZONE_HEAD = 1,
        ZONE_LEFT_ARM = 2,
        ZONE_RIGHT_ARM = 3,
        ZONE_LEFT_LEG = 4,
        ZONE_RIGHT_LEG = 5,
        ZONE_UNKNOWN = 6,
        ZONE_NONE = 7
    }

    public struct Tattoo
    {
        public int gender;
        public string name;
        public string collectionName;
        public TattooZone zoneId;
        public string type;

        /// <summary>
        /// Creates a new Tattoo object.
        /// </summary>
        /// <param name="gender">0 = male, 1 = female, 2 = both</param>
        /// <param name="name">Tattoo name</param>
        /// <param name="collectionName">Tattoo collection name</param>
        /// <param name="zoneId">Tattoo zone <see cref="TattooZone"/></param>
        /// <param name="type">Tattoo type</param>
        public Tattoo(int gender, string name, string collectionName, TattooZone zoneId, string type)
        {
            this.gender = gender;
            this.name = name;
            this.collectionName = collectionName;
            this.zoneId = zoneId;
            this.type = type;
        }
    }

    public static class MaleTattoosCollection
    {
        internal static List<Tattoo> TORSO = new List<Tattoo>();
        internal static List<Tattoo> HEAD = new List<Tattoo>();
        internal static List<Tattoo> LEFT_ARM = new List<Tattoo>();
        internal static List<Tattoo> RIGHT_ARM = new List<Tattoo>();
        internal static List<Tattoo> LEFT_LEG = new List<Tattoo>();
        internal static List<Tattoo> RIGHT_LEG = new List<Tattoo>();
        internal static List<Tattoo> BADGES = new List<Tattoo>();
    }

    public struct FemaleTattoosCollection
    {
        internal static List<Tattoo> TORSO = new List<Tattoo>();
        internal static List<Tattoo> HEAD = new List<Tattoo>();
        internal static List<Tattoo> LEFT_ARM = new List<Tattoo>();
        internal static List<Tattoo> RIGHT_ARM = new List<Tattoo>();
        internal static List<Tattoo> LEFT_LEG = new List<Tattoo>();
        internal static List<Tattoo> RIGHT_LEG = new List<Tattoo>();
        internal static List<Tattoo> BADGES = new List<Tattoo>();
    }

    public TattooInfo()
    {

        foreach (var tattoo in Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tattoo>>(File.ReadAllText("overlays.json")))
        {
            if (!string.IsNullOrEmpty(tattoo.name))
            {
                if (tattoo.type == "TYPE_TATTOO" && !tattoo.name.ToLower().Contains("hair_"))
                {
                    switch (tattoo.zoneId)
                    {
                        case TattooZone.ZONE_TORSO:
                            if (tattoo.gender == 0 || tattoo.gender == 2)
                            {
                                MaleTattoosCollection.TORSO.Add(tattoo);
                            }
                            if (tattoo.gender == 1 || tattoo.gender == 2)
                            {
                                FemaleTattoosCollection.TORSO.Add(tattoo);

                            }
                            break;
                        case TattooZone.ZONE_HEAD:
                            if (tattoo.gender == 0 || tattoo.gender == 2)
                            {
                                MaleTattoosCollection.HEAD.Add(tattoo);
                            }
                            if (tattoo.gender == 1 || tattoo.gender == 2)
                            {
                                FemaleTattoosCollection.HEAD.Add(tattoo);
                            }
                            break;
                        case TattooZone.ZONE_LEFT_ARM:
                            if (tattoo.gender == 0 || tattoo.gender == 2)
                            {
                                MaleTattoosCollection.LEFT_ARM.Add(tattoo);
                            }
                            if (tattoo.gender == 1 || tattoo.gender == 2)
                            {
                                FemaleTattoosCollection.LEFT_ARM.Add(tattoo);
                            }
                            break;
                        case TattooZone.ZONE_RIGHT_ARM:
                            if (tattoo.gender == 0 || tattoo.gender == 2)
                            {
                                MaleTattoosCollection.RIGHT_ARM.Add(tattoo);
                            }
                            if (tattoo.gender == 1 || tattoo.gender == 2)
                            {
                                FemaleTattoosCollection.RIGHT_ARM.Add(tattoo);
                            }
                            break;
                        case TattooZone.ZONE_LEFT_LEG:
                            if (tattoo.gender == 0 || tattoo.gender == 2)
                            {
                                MaleTattoosCollection.LEFT_LEG.Add(tattoo);
                            }
                            if (tattoo.gender == 1 || tattoo.gender == 2)
                            {
                                FemaleTattoosCollection.LEFT_LEG.Add(tattoo);
                            }
                            break;
                        case TattooZone.ZONE_RIGHT_LEG:
                            if (tattoo.gender == 0 || tattoo.gender == 2)
                            {
                                MaleTattoosCollection.RIGHT_LEG.Add(tattoo);
                            }
                            if (tattoo.gender == 1 || tattoo.gender == 2)
                            {
                                FemaleTattoosCollection.RIGHT_LEG.Add(tattoo);
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (tattoo.type == "TYPE_BADGE" && !tattoo.name.ToLower().Contains("hair_"))
                {
                    if (tattoo.gender == 0 || tattoo.gender == 2)
                    {
                        MaleTattoosCollection.BADGES.Add(tattoo);
                    }
                    if (tattoo.gender == 1 || tattoo.gender == 2)
                    {
                        FemaleTattoosCollection.BADGES.Add(tattoo);
                    }
                }
                else if (tattoo.name.ToLower().Contains("hair_"))
                {
                    if (tattoo.gender == 0 || tattoo.gender == 2)
                    {

                    }
                    if (tattoo.gender == 1 || tattoo.gender == 2)
                    {

                    }
                }
            }
        }

    }
}

