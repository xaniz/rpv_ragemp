using GTANetworkAPI;
using System.Collections.Generic;

class No_Crime_Zone : Script
{
    public static List<NCZ> NoCrimeZoneList = new List<NCZ>();

    public class NCZ
    {
        public string Name;
        public Vector3 Pos;
        public Vector3 End;
        public ColShape Col;
    }

    public No_Crime_Zone()
    {
     //   NoCrimeZoneList.Add(new NCZ { Name = "LSPD", Pos = new Vector3(443.52, -982, 27), Col = null, End = new Vector3(150, 150, 100) });
     //   NoCrimeZoneList.Add(new NCZ { Name = "Night Club", Pos = new Vector3(133, -1301, 29), Col = null, End = new Vector3(150, 150, 100) });
     //   NoCrimeZoneList.Add(new NCZ { Name = "LS Bank", Pos = new Vector3(262,220,114), Col = null, End = new Vector3(180, 180, 300) });
     //   NoCrimeZoneList.Add(new NCZ { Name = "LSMD ", Pos = new Vector3(-448.8,-339,34), Col = null, End = new Vector3(280, 150, 100) });


        foreach (var item in NoCrimeZoneList)
        {
            item.Col = NAPI.ColShape.Create3DColShape(item.Pos, item.End, 0);
            item.Col.SetData<dynamic>("ColName", "NCZ");
        }
    }

}
