using System;
using GTANetworkAPI;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

public class GetVehicleInfo
{
    public GetVehicleInfo()
    {

    }

    /*  [Command("fetchvehicledata")]
      public async void FetchVehicleDataAsync(Player Client)
      {
          List<VehicleData> vehData = new List<VehicleData>();
          GetVehicleInfo vehicle = new GetVehicleInfo();

          List<string> vehiclenames =  await vehicle.ReturnVehicleNamesAsync(Client);

          Main.SendCustomChatMessasge(Client,"Fetch complete, getting related vehicle info..");

          foreach (string v in vehiclenames)
          {
              uint id = NAPI.Util.GetHashKey(v);

              vehData.Add(new VehicleData()
              {
                  VehicleName = NAPI.Vehicle.GetVehicleDisplayName((VehicleHash)id),
                  MaxSpeed = NAPI.Vehicle.GetVehicleMaxSpeed((VehicleHash)id),
                  MaxBraking = NAPI.Vehicle.GetVehicleMaxBraking((VehicleHash)id),
                  MaxTraction = NAPI.Vehicle.GetVehicleMaxTraction((VehicleHash)id),
                  MaxAcceleration = NAPI.Vehicle.GetVehicleMaxAcceleration((VehicleHash)id),
                  MaxNumberOfPassengers = NAPI.Vehicle.GetVehicleMaxPassengers((VehicleHash)id),
                  MaxOccupants = NAPI.Vehicle.GetVehicleMaxOccupants((VehicleHash)id),
                  VehicleClass = NAPI.Vehicle.GetVehicleClass((VehicleHash)id)
              });
          }
          vehicle.WriteToFile(@"output/vehicleData.json", NAPI.Util.ToJson(vehData));
          Main.SendCustomChatMessasge(Client,"vehicleData.json exported, check output folder in your server directory");
      }


      public static Task<string> MakeAsyncRequest(string url, string contentType)
      {
          HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
          request.ContentType = contentType;
          request.Method = WebRequestMethods.Http.Get;
          request.Timeout = 20000;
          request.Proxy = null;

          Task<WebResponse> task = Task.Factory.FromAsync(
              request.BeginGetResponse,
              asyncResult => request.EndGetResponse(asyncResult),
              (object)null);

          return task.ContinueWith(t => ReadStreamFromResponse(t.Result));
      }

      private static string ReadStreamFromResponse(WebResponse response)
      {
          using (Stream responseStream = response.GetResponseStream())
         using (StreamReader sr = new StreamReader(responseStream))
          {
              //Need to return this response
              string strContent = sr.ReadToEnd();
              return strContent;
          }
      }

      public void<List<string>> ReturnVehicleNamesAsync(Player Client)
      {
          List<string> tempVehicleStore = new List<string>();

          Main.SendCustomChatMessasge(Client,"Fetching vehicle data... this may take a couple seconds.");

          string html =  await MakeAsyncRequest("https://wiki.rage.mp/index.php?title=Vehicles", "text/html");
          string pattern = @"<code[^>]*?>(.*?)</code>";
          MatchCollection matches = Regex.Matches(html, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

          if (matches.Count != 0)
          {
              foreach (Match match in matches)
              {
                  GroupCollection groups = match.Groups;
                  tempVehicleStore.Add(groups[1].Value);
              }

              return tempVehicleStore;
          }
          else
          {
              Main.SendCustomChatMessasge(Client,"Error matching regex to vehicles..");
          }

          return null;
      }

      public void WriteToFile(string path, string content)
      {
          try
          {
              Directory.CreateDirectory(Path.GetDirectoryName(path));
              File.WriteAllText(path, content);
          }
          catch (IOException e)
          {
              NAPI.Util.ConsoleOutput("Error: ", e.Message);
          }
      }
  }

  public class VehicleData
  {
      public string VehicleName { get; set; }
      public float MaxSpeed { get; set; }
      public float MaxBraking { get; set; }
      public float MaxTraction { get; set; }
      public float MaxAcceleration { get; set; }
      public int MaxNumberOfPassengers { get; set; }
      public int MaxOccupants { get; set; }
      public int VehicleClass { get; set; }
  }*/
}