using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

class Security_Camera:Script
{
    public static List<govcamera> cams = new List<govcamera>();
    public static List<govcameraaccess> camsaccess = new List<govcameraaccess>();

    public class govcamera
    {
        public string CamName;
        public float PosX;
        public float PosY;
        public float PosZ;

        public float RotX;
        public float RotY;
        public float RotZ;

        public float Fov;

    }
    public class govcameraaccess
    {
        public int id;
        public Vector3 pos;
        public bool isinuse;
        public ColShape Colshape;
    }
//cclose
    public Security_Camera()
    {
        MySqlConnection connection = new MySqlConnection(Main.myConnectionString);
        connection.Open();
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM govcamera";
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            govcamera cam = new govcamera();
            cam.CamName = reader.GetString("camname");
            cam.PosX = reader.GetFloat("posx");
            cam.PosY = reader.GetFloat("posy");
            cam.PosZ = reader.GetFloat("posz");
            cam.RotX = reader.GetFloat("rotx");
            cam.RotY = reader.GetFloat("roty");
            cam.RotZ = reader.GetFloat("rotz");
            cam.Fov = reader.GetFloat("fov");
            cams.Add(cam);

            camsaccess.Add(new govcameraaccess { id = 0, pos = new Vector3(445.318,-997.490,34.97), isinuse = false }); // 465.34,-976,24.1

            foreach (var item in camsaccess)
            {
                NAPI.Marker.CreateMarker(27, new Vector3(item.pos.X, item.pos.Y, item.pos.Z), new Vector3(0, 0, 0), new Vector3(0, 0, 0), 1f, new Color(221, 255, 0), false, 0);
                NAPI.TextLabel.CreateTextLabel("~g~" + "Kamere~n~~w~Koristite ~g~ Y ~w~ da nadgledate kamere", new Vector3(item.pos.X, item.pos.Y, item.pos.Z + 1), 10f, 1f, 2, new Color(221, 255, 0), false, 0);
                item.Colshape = NAPI.ColShape.Create2DColShape(item.pos.X, item.pos.Y, item.pos.Z, 1f, 0);
                item.Colshape.SetData<dynamic>("ColName", "camaccess");
            }

        }
        connection.Close();
    }

    public static void ShowCameraList(Player Client)
    {
        foreach (var item in camsaccess)
        {
            if (Client.Position.DistanceTo(item.pos) < 2f)
            {
                List<dynamic> menu_item_list = new List<dynamic>();
                foreach (var store in cams)
                {
                    menu_item_list.Add(new { Type = 1, Name = store.CamName, Description = "" });
                }
                InteractMenu.CreateMenu(Client, "Gov_Camera_List", "POLICIJA", "~g~" + "Sigurnosne kamere", true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "Blue");
               // InteractMenu.CreateMenu(Client, "Gov_Camera_List", "LSPD", "~g~" + "Security Operator", true, NAPI.Util.ToJson(menu_item_list), false, BackgroundSprite: "shopui_title_conveniencestore");

            }
        }

    }

    public static void SelectMenuResponse(Player Client, string callbackId, int selectedIndex, string objectName, string valueList)
    {
        if (callbackId == "Gov_Camera_List")
        {
            string name = objectName;
          //  int index = selectedIndex;
            foreach (var cam in cams)
            {
                if (cam.CamName == name)
                {
                    Main.Display_HUD(Client, false);
                    Main.showChat(Client, false);
                    Client.SetData<dynamic>("PLPOS", Client.Position);
                    Client.SetData<dynamic>("InCCTV", 2);
                    Client.Transparency = 0;
                    Client.TriggerEvent("Connect_Camera", cam.PosX, cam.PosY, cam.PosZ, cam.RotX, cam.RotY, cam.RotZ, cam.Fov);


                    return;
                }
            }
        }

    }

    ///    InCCTV
    ///  0 = Dakhel Menu Nist
    //   1 = Dakhel Menu Shod
    ///  2 = Dakhel CCTV Hastesh


    [Command("remote")]
    public void Gov_Remote(Player Client, string name)
    {
        if (AccountManage.GetPlayerGroup(Client) != 1)
        {
            Main.SendCustomChatMessasge(Client, "~y~ [Greska]~r~ Niste ovlasceni!");
            return;
        }

        if (Client.HasData("InCCTV") && Client.GetData<dynamic>("InCCTV") == 2)
        {
            Main.Display_HUD(Client, true);
            Main.showChat(Client, true);
            Client.TriggerEvent("Remote_End", Client.GetData<dynamic>("PLPOS"));
            Main.SendCustomChatMessasge(Client,"Omadi Biron");
            Client.SetData<dynamic>("InCCTV", 0);
            Client.Transparency = 255;
            return;
        }

        foreach (var item in camsaccess)
        {
            if (Client.Position.DistanceTo(item.pos) < 2f)
            {
                foreach (govcamera cam in cams)
                {
                    if (cam.CamName == name)
                    {
                        Client.SetData<dynamic>("PLPOS", Client.Position);
                        Client.Transparency = 0;
                        Client.SetData<dynamic>("InCCTV", 2);
                        Client.TriggerEvent("Connect_Camera", cam.PosX, cam.PosY, cam.PosZ, cam.RotX, cam.RotY, cam.RotZ, cam.Fov);

                        return;
                    }
                }
                Main.SendCustomChatMessasge(Client, "Ta kamera ne postoji!");
                return;
            }
        }

    }



    [Command("camcreate")]
    public void Create_GoverMent_Camera(Player Client, string name = "")
    {
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        if (AccountManage.GetPlayerAdmin(Client) < 7)
        {
            Main.SendCustomChatMessasge(Client,"Niste ovlasceni!");
            return;
        }
        if (name == "")
        {
            Main.SendCustomChatMessasge(Client, "~y~Greska! Unesite naziv kamere!");
            return;
        }

        Main.CreateMySqlCommand("INSERT INTO govcamera (camname,posx,posy,posz,rotx,roty,rotz,fov)" + " VALUES ('" + name + "','" + Client.Position.X + "','" + Client.Position.Y + "','" + Client.Position.Z + "','" + Client.Rotation.X + "','" + Client.Rotation.Y + "','" + Client.Rotation.Z + "','100')");
        cams.Add(new govcamera { CamName = name, PosX = Client.Position.X, PosY = Client.Position.Y, PosZ = Client.Position.Z, RotX = Client.Rotation.X, RotY = Client.Rotation.Y, RotZ = Client.Rotation.Z, Fov = 100 });

    }
}


// List<>

