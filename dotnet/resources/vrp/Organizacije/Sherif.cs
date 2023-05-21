using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
class Sherif:Script
{
    public Sherif()
    {
        NAPI.TextLabel.CreateTextLabel("~y~ Svlacionica ~n~~n~~w~ Uniformu uzimate na ~n~~n~~w~ ~b~  Y ~w~", new Vector3(-448.7,6011.6,31.7 + 0.3), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
       // NAPI.Marker.CreateMarker(1, new Vector3(-449.1559, 6011.614, 31.71639 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

        NAPI.TextLabel.CreateTextLabel("~y~~h~- STOP -~w~~h~~n~~n~~w~", new Vector3(-450.0119, 6016.234, 31.71639 + 0.3), 12, 0.3500f, 0, new Color(221, 255, 0, 255));
        NAPI.Marker.CreateMarker(1, new Vector3(-450.0119, 6016.234, 31.71639 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));


        NAPI.TextLabel.CreateTextLabel("~y~ Parking ~n~~n~~w~ Da vratite vozilo koristite ~n~~n~~w~ ~b~  E ~w~", new Vector3(-478.38116, 6019.4365, 31.34054 + 0.3), 12, 0.3500f, 0, new Color(221, 255, 0, 255));
       // NAPI.Marker.CreateMarker(1, new Vector3(-461.9,6009.6,31.4 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

        NAPI.TextLabel.CreateTextLabel("~y~ Garaza ~n~~n~~w~ Da uzmete vozilo koristite ~n~~n~~w~ ~b~  Y ~w~", new Vector3(-444.1966, 5998.2153, 31.49011 + 0.3), 12, 0.650f, 0, new Color(221, 255, 0, 255));
        //  NAPI.Marker.CreateMarker(1, new Vector3(-478.38116, 6019.4365, 31.34054 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));

        //      NAPI.TextLabel.CreateTextLabel("~y~Раздевалка~w~~n~~n~~w~Нажмите ~w~ ~b~ [ Y ]~w~", new Vector3(-442.2866, 6012.233, 31.71639 + 0.3), 12, 0.3500f, 4, new Color(221, 255, 0, 255));
        //     NAPI.Marker.CreateMarker(1, new Vector3(-442.2866, 6012.233, 31.71639 - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 155));
        NAPI.TextLabel.CreateTextLabel("~y~ /skiniwl ~n~~n~~w~ da skinete WantedLevel ~n~~n~ $3000 po WL~w~~n~ ~b~  Y ~w~", new Vector3(791.54, 2176.50, 52.64 + 0.3), 12, 0.650f, 0, new Color(221, 255, 0, 255));
    }

    public static void SherifUniform(Player player)
    {

        if ((int)NAPI.Data.GetEntitySharedData(player, "CHARACTER_ONLINE_GENRE") == 1)
        {
            player.SetClothes(11, 201, 0);
            player.SetClothes(4, 37, 1);
            player.SetClothes(6, 61, 0);
            player.SetClothes(8, 15, 0);
        }
        else
        {
            player.SetClothes(11, 201, 0);
            player.SetClothes(4, 37, 1);
            player.SetClothes(6, 61, 0);
            player.SetClothes(8, 15, 0);
        }
       
    }

}
