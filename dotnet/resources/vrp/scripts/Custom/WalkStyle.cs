using GTANetworkAPI;
using System.Collections.Generic;

class WalkingStyle : Script
{

    public static readonly string Normal = "normal";
    public static readonly string Brave = "move_m@brave";
    public static readonly string Confident = "move_m@confident";
    public static readonly string Drunk = "move_m@drunk@verydrunk";
    public static readonly string Fat = "move_m@fat@a";
    public static readonly string Gangster = "move_m@shadyped@a";
    public static readonly string Hurry = "move_m@hurry@a";
    public static readonly string Injured = "move_m@injured";
    public static readonly string Intimidated = "move_m@intimidation@1h";
    public static readonly string Quick = "move_m@quick";
    public static readonly string Sad = "move_m@sad@a";
    public static readonly string Tough = "move_m@tool_belt@a";
    public static readonly string Crounch = "move_ped_crouched";


    public static string SharedData_Walkstyle = "character_WalkStyle";


    public static List<WalkEnum> WalkList = new List<WalkEnum>();
    public class WalkEnum
    {
        public string name;
        public string animset;
    }
    public WalkingStyle()
    {
        WalkList.Add(new WalkEnum { name = "Brave", animset = "move_m@brave" });
              WalkList.Add(new WalkEnum { name = "Confident", animset = "move_m@confident" });// Not Good
        WalkList.Add(new WalkEnum { name = "Drunk", animset = "move_m@drunk@verydrunk" });
        WalkList.Add(new WalkEnum { name = "Fat", animset = "move_m@fat@a" });
        WalkList.Add(new WalkEnum { name = "Gangster", animset = "move_m@shadyped@a" });
              WalkList.Add(new WalkEnum { name = "Hurry", animset = "move_m@hurry@a" }); // Not Good
        WalkList.Add(new WalkEnum { name = "Intimidated", animset = "move_m@intimidation@1h" });
              WalkList.Add(new WalkEnum { name = "Quick", animset = "move_m@quick" });// Not Good
        WalkList.Add(new WalkEnum { name = "Sad", animset = "move_m@sad@a" });
        WalkList.Add(new WalkEnum { name = "Tough", animset = "move_m@tool_belt@a" });

        WalkList.Add(new WalkEnum { name = "Normal", animset = "normal" });
        WalkList.Add(new WalkEnum { name = "Injured", animset = "move_m@injured" });
        WalkList.Add(new WalkEnum { name = "Crounch", animset = "move_ped_crouched" });

    }
    public void CMD_SETWALK(Player Client,string idorname, string name)
    {
        if (AccountManage.GetPlayerAdmin(Client) <= 7) { return; }
        if (Client.GetData<dynamic>("admin_duty") == 0)
        {
            Main.SendErrorMessage(Client, "Niste na duznosti, koristite /aduty!");
            return;
        }
        Player target = Main.findPlayer(Client,idorname);
        if (target != null)
        {
            SetWalkStyle(target, name, false);
        }
    }

    [RemoteEvent("SetWalkStyle")]
    public static void SetWalkStyle(Player Client, string namestyle, bool temp)
    {
        if (temp == false)
        {
            Client.SetData<dynamic>(SharedData_Walkstyle, namestyle);
        }

        Client.SetSharedData(SharedData_Walkstyle, namestyle);
        
            foreach (Player pl in NAPI.Pools.GetAllPlayers())
            {
                if (Main.IsInRangeOfPoint(pl.Position, Client.Position, 500))
                {
                    pl.TriggerEvent("SetWalkStyle", Client, namestyle);
                }
            }
        // //SendCustomChatToAll(Client.GetSharedData<dynamic>(SharedData_Walkstyle) + " | ");
        //Client.TriggerEvent("");
    }

    [RemoteEvent("toggleCrouch")]
    public void toggleCrouch(Player Client)
    {
        if (Client.IsInVehicle)
        {
            return;
        }
        if (Client.GetSharedData<dynamic>(SharedData_Walkstyle) != Crounch) 
        { 
            SetWalkStyle(Client, Crounch,true); 
        }
        else 
        { 
            SetWalkStyle(Client, Client.GetData<dynamic>("character_WalkStyle"),true); 
        }
    }

  
    [RemoteEvent("TalkInRadio")]
    public void TalkInRadio(Player Client, bool state)
    {
        if (state == true)
        {
            foreach (Player target in NAPI.Pools.GetAllPlayers())
            {
                if (target.GetData<dynamic>("status") == true)
                {
                    if (!Client.HasSharedData("RadioFreq")) { return; }

                    if (target.GetSharedData<dynamic>("RadioFreq") == Client.GetSharedData<dynamic>("RadioFreq") && target.HasSharedData("Radio_Status") && target.GetSharedData<dynamic>("Radio_Status") )
                    {
                        Main.PlaySoundClientSide(target, "peer", 0.2f);
                    }
                }
            }
            NAPI.Player.PlayPlayerAnimation(Client, 49, "random@arrests", "generic_radio_chatter", 2);
        }
        else
        {
            // NAPI.Player.ClearPlayerTasks(Client);
            NAPI.Player.PlayPlayerAnimation(Client, 56, "random@arrests", "generic_radio_exit", 2);
        }
    }
}