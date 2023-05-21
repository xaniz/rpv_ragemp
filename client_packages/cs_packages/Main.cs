using Newtonsoft.Json;
using RAGE;
using RAGE.Elements;
using System;
using System.Collections.Generic;
using System.Linq;

class Main : Events.Script
{

    public class RobberyNPCEnum : IEquatable<RobberyNPCEnum>
    {
        public int id { get; set; }

        public string name { get; set; }
        public RAGE.Elements.Ped ped { get; set; }
        public int state { get; set; }

        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            RobberyNPCEnum objAsPart = obj as RobberyNPCEnum;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(RobberyNPCEnum other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }

        public void SetRoberyState(int arr_state)
        {
            state = arr_state;

            if (state == 1)
            {
                ped.TaskHandsUp(-1, ped.Handle, -1, true);
            }
            else
            {
                ped.ClearTasks();
            }
        }
    }
    public static List<RobberyNPCEnum> robbery_npc = new List<RobberyNPCEnum>();

    public static int ResX = 0;
    public static int ResY = 0;
    public Main()
    {

        Events.Add("CreateRobberyNPC", CreateRobberyNPC);
        Events.Add("SetRobberyState", SetRobberyState);
        Events.Add("Notify", Notify);
        Events.Add("UI:DisplayRadar", DisplayRadar);
        Events.Add("PedInVehicle", PedInVehicle);
        Events.OnEntityStreamIn += OnEntityStreamIn;
        Events.OnEntityStreamOut += OnEntityStreamOut;

        Events.Add("Get_Mod_Menu", ModMenu);
        Events.Add("Discord_Update", Discord_Update);

        Events.Add("ScreenTextUi", ScreenTextUi);


        // Events.Add("NCZ", NCZ);
        //   Events.Add("SetWalkStyle", SetWalkStyle);


      //  Events.Add("Sync_PedCreate2", Sync_PedCreate2);
       // Events.Add("Sync_Dance_Ped", Sync_Dance_Ped);

        Events.Add("Connect_Camera", Connect_Camera);
        Events.Add("Remote_End", Remote_End);
        Events.Add("interiorchange", interiorchange);
        Events.Add("removeinterior", removeinterior);

        Events.Add("TanabCuff", TanabCuff);

     //   Events.Add("SyncLight", SyncLight);
     //   Events.Add("SyncSiren", SyncSiren);
       // Events.Add("Delete_Dancer", Delete_Dancer);

        //   Events.Add("SyncHorn", SyncHorn);
        //  Events.Add("spMode", spMode);

        Events.Add("GetGroundPos", GetGroundPos);
        Events.Add("PlayPoliceReport", PlayPoliceReport);


        // Events.Add("Farm_TextLabel", Farm_TextLabel);
        Player.LocalPlayer.SetSuffersCriticalHits(false);


        RAGE.Game.Graphics.GetActiveScreenResolution(ref ResX, ref ResY);

        RAGE.Events.Tick += Tick;
        RAGE.Game.Player.SetPlayerCanUseCover(false);
        Events.OnPlayerEnterVehicle += OnPlayerEnterVehicle;

        Events.OnPlayerStartEnterVehicle += OnPlayerStartEnterVehicle;
      // Events.OnPlayerLeaveVehicle += OnPlayerLeaveVehicle;

        RAGE.Game.Streaming.RequestClipSet("move_m@brave");
        RAGE.Game.Streaming.RequestClipSet("move_m@fat@a");
        RAGE.Game.Streaming.RequestClipSet("move_m@confident");
        RAGE.Game.Streaming.RequestClipSet("move_m@drunk@verydrunk");
        RAGE.Game.Streaming.RequestClipSet("move_m@shadyped@a");
        RAGE.Game.Streaming.RequestClipSet("move_m@hurry@a");
        RAGE.Game.Streaming.RequestClipSet("move_m@intimidation@1h");
        RAGE.Game.Streaming.RequestClipSet("move_m@quick");
        RAGE.Game.Streaming.RequestClipSet("move_m@sad@a");
        RAGE.Game.Streaming.RequestClipSet("move_m@tool_belt@a");
        RAGE.Game.Streaming.RequestClipSet("move_m@injured");
        RAGE.Game.Streaming.RequestClipSet("move_ped_crouched");

    }

    public delegate void OnPlayerEnterVehicleDelegate(RAGE.Elements.Vehicle vehicle, int seatId);

    public delegate void OnEntityStreamInDelegate(Entity entity);
    public delegate void OnEntityStreamOutDelegate(Entity entity);

    //public delegate void OnPlayerLeaveVehicleDelegate(RAGE.Elements.Vehicle vehicle, int seatId);

    public delegate void OnPlayerStartEnterVehicleDelegate(RAGE.Elements.Vehicle vehicle, int seatId, RAGE.Events.CancelEventArgs cancel);

    /*public void OnPlayerLeaveVehicle(RAGE.Elements.Vehicle vehicle, int seatId)
    {

    }*/

    public void OnPlayerStartEnterVehicle(RAGE.Elements.Vehicle vehicle, int seatId, RAGE.Events.CancelEventArgs cancel)
    {
        // Player.LocalPlayer.Vehicle.SetDoorLatched(-1, false, false, true);
        Player.LocalPlayer.SetConfigFlag(429, true);
    }

    public void OnPlayerEnterVehicle(RAGE.Elements.Vehicle vehicle, int seatId)
    {
        try
        {
            // Player.LocalPlayer.Vehicle.SetDoorLatched(-1, false, false, true);
           

        }
        catch (Exception)
        {

        }
        Player.LocalPlayer.SetConfigFlag(429, true);

    }

    public void OnEntityStreamOut(RAGE.Elements.Entity entity)
    {
        if (entity.Type == RAGE.Elements.Type.Ped)
        {
            Ped ped = (Ped)entity;
            if (ped.GetSharedData("traffic") != null && (bool)ped.GetSharedData("traffic") == true)
            {
                RAGE.Events.CallRemote("NPC_ExitStream", ped);
            }
        }
    }
    public static void PedInVehicle(object[] args)
    {
        if (args[0] == null || args[1] == null)
        {
            return;
        }
        Ped ped = (Ped)args[0];
        Vehicle veh = (Vehicle)args[1];

        ped.SetIntoVehicle(veh.Handle, -1);
        ped.TaskVehicleDriveWander(veh.Handle, 20, 786603);

    }
    /* List<Ped> Ped_strips = new List<Ped>();
     List<dynamic> Dance_Mod = new List<dynamic>();*/
    Random rnd = new Random();

    private int camera;
   /* public void Sync_Dance_Ped(object[] args)
    {
        if ((bool)args[0] == false)
        {
            Dance_Mod.Add(new { animdict = args[1], animname = args[2] });
            return;
        }

        foreach (Ped item in Ped_strips)
        {
            int rand = rnd.Next(0, Dance_Mod.Count + 1);
            item.TaskPlayAnim(Dance_Mod[rand].animdict, Dance_Mod[rand].animname, 8f, 1, -1, 1, 1f, true, true, true);
        }
    }*/



    // public static void POLICE_PURSUIT_DRIVEN_03 { get {  new Speech("A_F_M_KTOWN_02_CHINESE_MINI_01", "POLICE_PURSUIT_DRIVEN", 3); } }
    /*   private void SetWalkStyle(object[] args)
       {
           Player nima = (Player)args[0];

           if (args[1] == null || (string)args[1] == "normal")
           {

               if ((string)args[1] != "move_ped_crouched")
               { nima.ResetStrafeClipset(); }

                nima.ResetMovementClipset(0.5f);
               return;
           }
           RAGE.Game.Streaming.RequestClipSet("move_ped_crouched");

           RAGE.Game.Streaming.RequestClipSet((string)args[1]);
           nima.SetMovementClipset((string)args[1], 0.7f);
           if ((string)args[1] == "move_ped_crouched")
           {
               RAGE.Game.Streaming.RequestClipSet("move_ped_crouched_strafing");
               nima.SetStrafeClipset("move_ped_crouched_strafing");
           }
       }*/
    /* public void spMode(object[]args)
     {
         if ((bool)args[1])
         {
             Player target = (Player)args[0];
             RAGE.Game.Entity.AttachEntityToEntityPhysically(Player.LocalPlayer.Handle,target.Handle,12844, 12844,0,0,0,0,0,0,0,0,0,0,true,true,false,true,0);
            // RAGE.Game.Entity.AttachEntityToEntityPhysically
         }
         else
         {
             Player.LocalPlayer.Detach(true, false);
         }
      //   RAGE.Elements.Player.LocalPlayer.TaskPlayAnim("mini@cpr@char_b@cpr_def", "cpr_intro", 8, 8, -1, 0, 0, false, false, false);
      //   RAGE.Elements.Player.LocalPlayer.TaskPlayAnim("mini@cpr@char_b@cpr_str", "cpr_pumpchest", 8, 8, -1, 0, 0, false, false, false);
     }*/


    bool tanab = false;
    public void TanabCuff(object[] args)
    {
        tanab = (bool)args[0];

    }
    int scaleform;

    public void Remote_End(object[] args)
    {
        RAGE.Game.Cam.SetCamActive(camera, false);
        RAGE.Game.Cam.DestroyCam(camera, true);
        RAGE.Game.Cam.RenderScriptCams(false, false, 0, true, false, 0);
        Player.LocalPlayer.Position = (Vector3)args[0];
        RAGE.Game.Graphics.StopAllScreenEffects();
        RAGE.Chat.Show(true);
        RAGE.Chat.Activate(true);
        tanab = false;
        Player.LocalPlayer.FreezePosition(false);

        RAGE.Game.Graphics.ClearTimecycleModifier();
        RAGE.Game.Graphics.SetScaleformMovieAsNoLongerNeeded(ref scaleform);

    }

    public void Connect_Camera(object[] args)
    {
        scaleform = RAGE.Game.Graphics.RequestScaleformMovie("TRAFFIC_CAM");
        RAGE.Game.Graphics.SetTimecycleModifier("heliGunCam");
        RAGE.Game.Graphics.SetTimecycleModifierStrength(1);

        Player.LocalPlayer.FreezePosition(true);
        RAGE.Chat.Show(false);
        RAGE.Chat.Activate(false);
        camera = RAGE.Game.Cam.CreateCameraWithParams(RAGE.Game.Misc.GetHashKey("DEFAULT_SCRIPTED_CAMERA"), (float)args[0], (float)args[1], (float)args[2], (float)args[3], (float)args[4], (float)args[5], (float)args[6], true, 2);
        RAGE.Game.Cam.SetCamActive(camera, true);
        // RAGE.Game.Graphics.SetNoiseoveride(true);
        Player.LocalPlayer.Position = new Vector3((float)args[0], (float)args[1], ((float)args[2]) - 5);
        //RAGE.Game.Graphics.SetNoisinessoveride(0.3f);
        RAGE.Game.Graphics.PushScaleformMovieFunction(scaleform, "PLAY_CAM_MOVIE");
        RAGE.Game.Cam.RenderScriptCams(true, true, 0, true, false, 0);
        RAGE.Game.Graphics.PopScaleformMovieFunctionVoid();
        RAGE.Game.Graphics.DrawScaleformMovieFullscreen(scaleform, 255, 255, 255, 255, 255);
        RAGE.Game.Ui.DisplayRadar(false);
        tanab = true;

    }

    //List<Ped> DancePed = new List<Ped>();
    /*public void Delete_Dancer(object[] args)
    {
        foreach (Ped item in Ped_strips)
        {
            item.Destroy();
        }
    }*/
 /*   public void Sync_PedCreate2(object[] args)
    {
        Vector3 pos = Player.LocalPlayer.Position;

        Ped ped = new Ped(RAGE.Game.Misc.GetHashKey((string)args[0]), (Vector3)args[1], (float)args[2], 0);

        Ped_strips.Add(ped);

        foreach (var item in Dance_Mod)
        {
            RAGE.Game.Streaming.RequestAnimDict(item.animdict);
        }
    }*/

    public void GetGroundPos(object[] args)
    {
        float i = Player.LocalPlayer.GetHeightAboveGround() - 0.2f;
        Events.CallRemote("SetGroundPos", i);
    }
    public void PlayPoliceReport(object[] args)
    {
        RAGE.Game.Audio.PlayPoliceReport((string)args[0], 0);
    }

    public void OnEntityStreamIn(RAGE.Elements.Entity entity)
    {
        if (entity != null)
        {
            switch (entity.Type)
            {
                case RAGE.Elements.Type.Player:
                    {
                        try
                        {
                            if (Convert.ToInt32(entity.GetSharedData("character_helmet")) != -1)
                            {
                                //mp.players.local.setHelmet(false);
                                RAGE.Game.Player.RemovePlayerHelmet(true);
                                Events.CallRemote("helmet_sync");

                            }
                        }
                        catch (Exception e)
                        {
                        }
                        break;
                    }
                case RAGE.Elements.Type.Vehicle:
                    {
                        Vehicle veh = (Vehicle)entity;
                        if (veh.GetNumberPlateText().Contains("HZ OI5"))
                        {
                            Ped ped = RAGE.Elements.Entities.Peds.GetAtRemote(ushort.Parse(veh.GetNumberPlateText().Split("Z OI5")[1]));
                            if (ped.Controller.Handle == Player.LocalPlayer.Handle)
                            {
                                ped.SetIntoVehicle(veh.Handle, -1);
                                ped.TaskVehicleDriveWander(veh.Handle, 20, 786603);

                            }
                        }

                        break;
                    }
                default:

                    break;
            }
        }
    }


    public void Discord_Update(object[] args)
    {
        RAGE.Discord.Update((string)args[0], (string)args[1]);
    }

    Boolean BoolScreenTextUi1 = false;
    string TextScreenTextUi1;
    public void ScreenTextUi(object[] args)
    {

        if ((string)args[0] == "StopUI")
        {
            BoolScreenTextUi1 = false;

            return;
        }
        else
        {
            BoolScreenTextUi1 = true;
            TextScreenTextUi1 = (string)args[0];

        }

    }

    public void DisplayRadar(object[] args)
    {
        RAGE.Game.Ui.DisplayRadar((bool)args[0]);
    }


    public static void ModMenu(object[] args)
    {
        List<dynamic> menu_item_list = new List<dynamic>();

        for (int i = 0; i < Player.LocalPlayer.Vehicle.GetNumMods((int)args[0]); i++)
        {
            menu_item_list.Add(new { Label = RAGE.Game.Ui.GetLabelText(Player.LocalPlayer.Vehicle.GetModTextLabel((int)args[0], i)), modType = (int)args[0], modValue = i });

        }
        Events.CallRemote("Create_Submenu_Mod", JsonConvert.SerializeObject(menu_item_list), args[1].ToString());
    }


    public static void Notify(object[] args)
    {
        RAGE.Game.Ui.SetNotificationTextEntry("STRING");
        RAGE.Game.Ui.AddTextComponentSubstringPlayerName(args[0].ToString());
        RAGE.Game.Ui.DrawNotification(false, false);

    }

    public static void CreateRobberyNPC(object[] args)
    {
        uint freeroamHash = RAGE.Game.Misc.GetHashKey(args[1].ToString());
        RAGE.Elements.Ped temp_ped = new Ped(freeroamHash, (RAGE.Vector3)args[2], heading: (float)args[3], dimension: 0);

        robbery_npc.Add(new RobberyNPCEnum { name = args[0].ToString(), ped = temp_ped, state = 0, id = (int)args[4] });
    }
    public void removeinterior(object[] args)
    {
        //RAGE.Game.Streaming.RemoveIpl((string)args[0]);
        RAGE.Game.Interior.EnableInteriorProp((int)args[0], (string)args[1]);
        Chat.Output("Remove");
    }
    public void interiorchange(object[] args)
    {
       // RAGE.Game.Rendering.ActivateRockstarEditor();

        //RAGE.Game.Streaming.RequestIpl((string)args[0]);
        RAGE.Game.Interior.DisableInteriorProp((int)args[0], (string)args[1]);
        Chat.Output("Add");

    }

    public static void SetRobberyState(object[] args)
    {
        foreach (var ped in robbery_npc)
        {
            if (ped.name == args[0].ToString())
            {
                ped.SetRoberyState((int)args[1]);
            }
        }
    }

    /*private void SyncHorn(object[] args)
    {
        Vehicle Veh = (Vehicle)args[1];
        bool stats = (bool)args[0];

        if (stats)
        {
            RAGE.Game.Audio.PlaySoundFromEntity(30, "SIRENS_AIRHORN", Veh.Handle, "", true, 3);
           // RAGE.Game.Audio.SetHornEnabled(Veh.Handle, true);
        }
        else
        {
            RAGE.Game.Audio.StopSound(30);
        }

    }*/

   /* private void SyncLight(object[] vs)
    {
        Vehicle Veh = (Vehicle)vs[1];
        bool stats = (bool)vs[0];

        Veh.SetSiren(stats);
        Veh.SetSirenSound(true);
    }

    private void SyncSiren(object[] vs)
    {
        Vehicle Veh = (Vehicle)vs[1];
        bool stats = (bool)vs[0];
        RAGE.Game.Audio.SetSirenWithNoDriver(Veh.Id, true);
        Veh.SetSirenSound(stats);

    }*/


    public static long LatestProcess = 0;

    public void Tick(System.Collections.Generic.List<RAGE.Events.TickNametagData> nametags)
    {

        RAGE.Game.Pad.DisableControlAction(0, 140, true);

        if (Player.LocalPlayer.Vehicle != null)
        {
            if (Player.LocalPlayer.Vehicle.GetPedInSeat(-1, -1) == Player.LocalPlayer.Handle && Player.LocalPlayer.GetSelectedWeapon() != 2725352035 && Player.LocalPlayer.Vehicle.GetSpeed() * 3.4 > 50)
            {
                Player.LocalPlayer.SetCurrentWeapon(2725352035, true);
            }
        }

        if (tanab)
        {

            RAGE.Game.Pad.DisableControlAction(0, 22, true);
            RAGE.Game.Pad.DisableControlAction(0, 257, true);
            RAGE.Game.Pad.DisableControlAction(0, 24, true);
            RAGE.Game.Pad.DisableControlAction(0, 25, true);
            RAGE.Game.Pad.DisableControlAction(0, 37, true);
            RAGE.Game.Pad.DisableControlAction(0, 23, true);
        }

        ///E
        if (RAGE.Game.Pad.IsControlJustPressed(0, 73))
        {
            if (Player.LocalPlayer.Vehicle != null && Player.LocalPlayer.Vehicle.GetClass() == 18)
            {
                if (Player.LocalPlayer.Vehicle.IsSirenSoundOn())
                { ///khamosh mishe
                    Player.LocalPlayer.Vehicle.SetSirenSound(false);
                }
                else
                {
                    if (Player.LocalPlayer.Vehicle.IsSirenOn())
                    { //roshan mishe
                        Player.LocalPlayer.Vehicle.SetSirenSound(true);
                    }
                }
            }
        }
        ///Q
        if (RAGE.Game.Pad.IsControlJustPressed(0, 48))
        {
            if (Player.LocalPlayer.Vehicle != null && Player.LocalPlayer.Vehicle.GetClass() == 18)
            {
                if (Player.LocalPlayer.Vehicle.IsSirenSoundOn())
                { ///khamosh mishe
                    Player.LocalPlayer.Vehicle.SetSirenSound(true);
                    Events.CallRemote("CruiserLight", 1, false);
                }
                else
                {
                    if (Player.LocalPlayer.Vehicle.IsSirenOn())
                    { //roshan mishe
                        Player.LocalPlayer.Vehicle.SetSirenSound(false);
                        Events.CallRemote("CruiserLight", 1, true);
                    }
                }
            }
        }

        /* if (RAGE.Game.Pad.IsControlJustPressed(0, 44) && Player.LocalPlayer.Vehicle != null)
         {
             if (Player.LocalPlayer.Vehicle.GetClass() == 18)
             {
                 if (Player.LocalPlayer.Vehicle.IsSirenOn())
                 {
                     Player.LocalPlayer.Vehicle.SetData<bool>("Siren2", false);

                     Events.CallRemote("CruiserLight", 1, false, Player.LocalPlayer.Vehicle);
                     if (Player.LocalPlayer.Vehicle.GetData<bool>("Siren2") == true) { Events.CallRemote("CruiserLight", 4, false, Player.LocalPlayer.Vehicle); Events.CallRemote("CruiserLight", 2, false, Player.LocalPlayer.Vehicle); Player.LocalPlayer.Vehicle.SetData<bool>("Siren2", false); }

                 }
                 else
                 {
                     Player.LocalPlayer.Vehicle.SetData<bool>("Siren2", false);
                     Events.CallRemote("CruiserLight", 1, true, Player.LocalPlayer.Vehicle);

                 }
             }
         }*/


        if (Player.LocalPlayer.Vehicle != null == false)
        {
            RAGE.Game.Pad.DisableControlAction(0, 26, true);
        }


        if (BoolScreenTextUi1)
        {
            RAGE.Game.UIText.Draw(TextScreenTextUi1, new System.Drawing.Point((ResX / 2), (ResY / 2)), 0.45f, System.Drawing.Color.Green, RAGE.Game.Font.Monospace, false);
        }

        int index = -1;
        foreach (var ped in robbery_npc)
        {
            if (RAGE.Game.Player.IsPlayerFreeAimingAtEntity(ped.ped.Handle) == true)
            {
                index = ped.id;
            }
        }

        if ((int)Player.LocalPlayer.GetSharedData("Player_Aiming_To") != index)
        {
            RAGE.Events.CallRemote("Players_Aiming_To", index);
            index = -1;
        }

    }


    public class Util
    {
        static public long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }
    }
}
