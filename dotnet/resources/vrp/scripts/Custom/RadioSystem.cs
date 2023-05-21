/*
			Created By ATTACKING
				NIMA#9225


*/
using GTANetworkAPI;
using System.Collections.Generic;

public class Radio
{
    public class RadioSystem
    {

        public static void Radio_Call(Player Client, int freq)
        {
            // if (!Client.HasSharedData("RadioFreq")) { return; }
            //Client.TriggerEvent("voice.phoneStop");
            Client.SetSharedData("RadioFreq", freq);

            // List<Player> players = new List<Player>();
            foreach (Player target in NAPI.Pools.GetAllPlayers())
            {
                if (target.GetData<dynamic>("status") == true)
                {
                    if (!Client.HasSharedData("RadioFreq")) { return; }

                    if (target.GetSharedData<dynamic>("RadioFreq") == Client.GetSharedData<dynamic>("RadioFreq") && target.HasSharedData("Radio_Status") && target.GetSharedData<dynamic>("Radio_Status") && target != Client)
                    {

                        target.TriggerEvent("voice.radio", Client);
                        Client.TriggerEvent("voice.radio", target);
                    }
                }
            }
            foreach (Player pl in NAPI.Pools.GetAllPlayers())
            {
                if (pl.GetData<dynamic>("status") == true)
                {
                    if (pl.GetSharedData<dynamic>("RadioFreq") != Client.GetSharedData<dynamic>("RadioFreq") && pl != Client)
                    {
                        Client.TriggerEvent("v_disconnect", pl);
                        pl.TriggerEvent("v_disconnect", Client);
                    }
                }
            }
        }




        public static void ToggleRadio(Player Client, bool deafult = true)
        {

            if (deafult == false)
            {
                Client.SetSharedData("Radio_Status", false);
                foreach (Player pl in NAPI.Pools.GetAllPlayers())
                {
                    if (pl.GetData<dynamic>("status") == true)
                    {
                        if (pl.GetSharedData<dynamic>("RadioFreq") == Client.GetSharedData<dynamic>("RadioFreq") && pl != Client)
                        {
                            Client.TriggerEvent("v_disconnect", pl);
                            pl.TriggerEvent("v_disconnect", Client);
                        }
                    }
                }
                return;
            }
            if (Client.HasSharedData("Radio_Status") && Client.GetSharedData<dynamic>("Radio_Status") == true)
            {
                List<Player> players = NAPI.Player.GetPlayersInRadiusOfPlayer(4, Client);
                foreach (Player pl in players)
                {
                    Main.PlaySoundClientSide(pl, "radio_off", 0.2f);
                }
                foreach (Player target in NAPI.Pools.GetAllPlayers())
                {
                    if (target.GetData<dynamic>("status") == true)
                    {
                        if (!Client.HasSharedData("RadioFreq")) { return; }

                        if (target.GetSharedData<dynamic>("RadioFreq") == Client.GetSharedData<dynamic>("RadioFreq") && target.HasSharedData("Radio_Status") && target.GetSharedData<dynamic>("Radio_Status") && target != Client)
                        {

                            target.TriggerEvent("voice.radio", Client);
                            Client.TriggerEvent("voice.radio", target);
                        }
                    }
                }

                Client.SetSharedData("Radio_Status", false);
                Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.CenterRight, "Radio ugasen.");
                foreach (Player pl in NAPI.Pools.GetAllPlayers())
                {
                    if (pl.GetData<dynamic>("status") == true)
                    {
                        if (pl.GetSharedData<dynamic>("RadioFreq") == Client.GetSharedData<dynamic>("RadioFreq") && pl != Client)
                        {
                            Client.TriggerEvent("v_disconnect", pl);
                            pl.TriggerEvent("v_disconnect", Client);
                        }
                    }
                }
            }
            else
            {
                List<Player> players = NAPI.Player.GetPlayersInRadiusOfPlayer(4, Client);
                foreach (Player pl in players)
                {
                    Main.PlaySoundClientSide(pl, "radio_on", 0.2f);
                }
                if (Client.HasSharedData("RadioFreq") && Client.GetSharedData<dynamic>("RadioFreq") >= 0)
                {
                    foreach (Player target in NAPI.Pools.GetAllPlayers())
                    {
                        if (target.GetData<dynamic>("status") == true)
                        {
                            if (!Client.HasSharedData("RadioFreq")) { return; }

                            if (target.GetSharedData<dynamic>("RadioFreq") == Client.GetSharedData<dynamic>("RadioFreq") && target.HasSharedData("Radio_Status") && target.GetSharedData<dynamic>("Radio_Status") && target != Client)
                            {

                                target.TriggerEvent("voice.radio", Client);
                                Client.TriggerEvent("voice.radio", target);
                            }
                        }
                    }
                }
                //  if (!Client.HasSharedData("radio_on")) { Client.SetSharedData("RadioFreq", -1); }
                Client.SetSharedData("Radio_Status", true);
                Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.CenterRight, "Radio ukljucen.");
            }
        }
    }
}
