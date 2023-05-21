using GTANetworkAPI;
using System.Collections.Generic;
using System.Linq;

class AdminReport : Script
{
    public class ReportClass
    {
        public int rid;
        public int category;
        public int PlayerID;
        public string reporttext;
    }

    public static Dictionary<int, ReportClass> ReportList = new Dictionary<int, ReportClass>();

    public static void OnPlayerDisconnected(Player client)
    {
        if (client.HasData("report_id") && client.GetData<dynamic>("report_id") != -1)
        {
            int reportId = client.GetData<dynamic>("report_id");

            if (!ReportList.TryGetValue(reportId, out ReportClass report))
            {
                client.SetData<dynamic>("report_id", -1);
                client.SetData<dynamic>("Respone_Report", -1);
                return;
            }

            if (client.HasData("Respone_Report") && client.GetData<dynamic>("Respone_Report") != -1)
            {
                Player target = Main.getClientFromId(client, client.GetData<dynamic>("Respone_Report"));
                Main.SendCustomChatMessasge(target, "~y~[Report System] ~r~Someone has resolved this report, and it has been automatically closed.");
            }

            ReportList.Remove(reportId);

            // Notify all online admins about the removal
            foreach (var admin in NAPI.Pools.GetAllPlayers().Where(p => AccountManage.GetPlayerAdmin(p) >= 1))
            {
                Main.SendCustomChatMessasge(admin, $"~y~[Report System] ~r~Igrac {AccountManage.GetCharacterName(client)} je izasao sa serverai njegov LP (ID: {reportId}) je obrisan.");
            }

            client.SetData<dynamic>("report_id", -1);
            client.SetData<dynamic>("Respone_Report", -1);
        }
    }


    [Command("report", "(tekst)", GreedyArg = true)]
    public void CMD_Report(Player Client, string message)
    {
        if (Client.GetData<dynamic>("status") == true)
        {
            if (Client.HasData("report_id") && Client.GetData<dynamic>("report_id") != -1)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vec ste poslali report, koristite: /cancelreport da ga zatvorite!");
                return;
            }
            if (message.Length <= 1)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Vas report mora sadrzati vise od 1 karaktera!");
                return;
            }
            int admins = 0;
            List<Player> Admins = new List<Player>();
            foreach (var pl in NAPI.Pools.GetAllPlayers())
            {
                if (AccountManage.GetPlayerAdmin(pl) >= 1)
                {
                    Admins.Add(pl);
                    admins++;
                }
            }

            if (admins == 0)
            {
                Main.DisplayErrorMessage(Client, NotifyType.Error, NotifyPosition.BottomCenter, "Pitanja su trenutno ugasena.");
                return;
            }

            foreach (var item in Admins)
            {
                Main.DisplayErrorMessage(item, NotifyType.Alert, NotifyPosition.TopRight, "Stiglo je novo pitanje!");
            }

            int reportId = GenerateUniqueReportId();
            ReportList.Add(reportId, new ReportClass { rid = reportId, PlayerID = Client.Value, reporttext = message });
            Client.SetData<dynamic>("report_id", reportId);

            Main.DisplayErrorMessage(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Poslali ste report, sacekajte odgovor! Report ID: " + Client.GetData<dynamic>("report_id"));

        }
    }

    private int GenerateUniqueReportId()
    {
        int reportId = 0;
        while (ReportList.ContainsKey(reportId))
        {
            reportId++;
        }
        return reportId;
    }


    [Command("cancelreport")]
    public void Cancel_Report(Player client)
    {
        if (client.GetData<dynamic>("status") == true)
        {
            if (client.HasData("Respone_Report") && client.GetData<dynamic>("Respone_Report") != -1)
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Trenutno ne mozete zatvoriti Vas report.");
                return;
            }

            if (client.HasData("report_id") && client.GetData<dynamic>("report_id") == -1)
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste poslali report.");
                return;
            }

            int reportId = client.GetData<dynamic>("report_id");

            if (!ReportList.TryGetValue(reportId, out ReportClass report))
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste poslali report.");
                return;
            }

            Main.DisplayErrorMessage(client, NotifyType.Success, NotifyPosition.BottomCenter, "Zatvorili ste report.");

            ReportList.Remove(reportId);

            client.SetData<dynamic>("report_id", -1);
            client.SetData<dynamic>("Respone_Report", -1);
        }
    }

    [Command("lp")]
    public void Show_Reports(Player client)
    {
        if (client.GetData<dynamic>("status") == true)
        {
            if (client.GetData<dynamic>("admin_duty") == 0)
            {
                Main.SendErrorMessage(client, "Niste na duznosti, koristite /aduty!");
                return;
            }

            if (AccountManage.GetPlayerAdmin(client) < 1)
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste ovlasceni.");
                return;
            }

            if (ReportList.Count == 0)
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Trenutno nema pitanja.");
                return;
            }

            client.TriggerEvent("SendReport", ReportList.Values.ToList());

        }
    }


    [RemoteEvent("lpanswer")]
    public void Accept_Report(Player client, int id, string text)
    {
        if (client.GetData<dynamic>("status") == true)
        {
            if (client.GetData<dynamic>("admin_duty") == 0)
            {
                Main.SendErrorMessage(client, "Niste na duznosti, koristite /aduty!");
                return;
            }

            if (AccountManage.GetPlayerAdmin(client) < 1)
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste ovlasceni.");
                return;
            }

            if (!ReportList.TryGetValue(id, out ReportClass report))
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan ID!");
                return;
            }

            Player target = Main.getClientFromId(client, report.PlayerID);

            if (target != null)
            {
                Main.SendCustomChatMessasge(target, "~y~[Report] " + AccountManage.GetCharacterName(client) + " " + text + ".");
                Main.SendCustomChatMessasge(target, "~y~[Report] Vas report je zatvoren.");
                ReportList.Remove(id);
                target.SetData<dynamic>("report_id", -1);
                target.SetData<dynamic>("Respone_Report", -1);
            }
        }
    }

    [RemoteEvent("dreport")]
    public void Close_Report(Player client, int id)
    {
        if (client.GetData<dynamic>("status") == true)
        {
            if (client.GetData<dynamic>("admin_duty") == 0)
            {
                Main.SendErrorMessage(client, "Niste na duznosti, koristite /aduty!");
                return;
            }

            if (AccountManage.GetPlayerAdmin(client) < 1)
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste ovlasceni!");
                return;
            }

            if (!ReportList.TryGetValue(id, out ReportClass report))
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan ID!");
                return;
            }

            if (AccountManage.GetPlayerAdmin(client) < 1)
            {
                if (ReportList[id].category != 1)
                {
                    Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan ID!");
                    return;
                }
            }

            Player target = Main.getClientFromId(client, ReportList[id].PlayerID);

            Main.SendCustomChatMessasge(client, "~y~[Report] Report ID: " + id + " je zatvoren.");

            ReportList.Remove(id);

            client.SetData<dynamic>("report_id", -1);
            client.SetData<dynamic>("Respone_Report", -1);

        }
    }

    public void Close_Report_Response(Player client)
    {
        if (client.GetData<dynamic>("status") == true)
        {
            if (client.GetData<dynamic>("admin_duty") == 0)
            {
                Main.SendErrorMessage(client, "Niste na duznosti, koristite /aduty!");
                return;
            }

            if (AccountManage.GetPlayerAdmin(client) < 1)
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Niste ovlasceni!");
                return;
            }

            if (client.HasData("report_id") && client.GetData<dynamic>("report_id") == -1)
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan ID!");
                return;
            }

            if (client.HasData("Respone_Report") && client.GetData<dynamic>("Respone_Report") == -1)
            {
                Main.DisplayErrorMessage(client, NotifyType.Error, NotifyPosition.BottomCenter, "Pogresan ID!");
                return;
            }

            Player target = Main.getClientFromId(client, client.GetData<dynamic>("Respone_Report"));

            if (target != null)
            {
                Main.SendCustomChatMessasge(target, "~y~[Report] Vas report je ~r~ zatvoren ~y~.");
                target.SetData<dynamic>("report_id", -1);
                target.SetData<dynamic>("Respone_Report", -1);
            }

                Main.SendCustomChatMessasge(client, "~y~[Report] Report ID: " + client.GetData<dynamic>("report_id") + " je zatvoren.");
                client.SetData<dynamic>("report_id", -1);
                client.SetData<dynamic>("Respone_Report", -1);
            }
    }

}
