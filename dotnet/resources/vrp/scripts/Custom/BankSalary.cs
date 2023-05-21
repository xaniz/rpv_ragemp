using GTANetworkAPI;
using System.Collections.Generic;

class BankSalary : Script
{
    public static List<dynamic> BankCheckpoint = new List<dynamic>();

    public BankSalary()
    {
        BankCheckpoint.Add(new { MarkerType = 1, position = new Vector3(241.44, 225.34, 106.1) });
        BankCheckpoint.Add(new { MarkerType = 1, position = new Vector3(248.16, 222.95, 106.1) });
        BankCheckpoint.Add(new { MarkerType = 1, position = new Vector3(149.84868, -1040.7798, 29.374088) });
        BankCheckpoint.Add(new { MarkerType = 1, position = new Vector3(314.2728, -279.11133, 54.1708) });
        BankCheckpoint.Add(new { MarkerType = 1, position = new Vector3(-1212.7267, -330.8521, 37.787037) });
        foreach (var bc in BankCheckpoint)
        {

            NAPI.TextLabel.CreateTextLabel("~g~Uzmite platu ~w~[ ~g~Y~w~ ]", bc.position, 16, 0.600f, 0, new Color(221, 255, 0, 150));
          //  NAPI.Marker.CreateMarker(2, new Vector3(bc.position.X, bc.position.Y, bc.position.Z - 1.0), new Vector3(), new Vector3(), 0.8f, new Color(221, 255, 0, 150));
            ColShape mmd = NAPI.ColShape.CreateCylinderColShape(new Vector3(bc.position.X, bc.position.Y, bc.position.Z), 1f, 1f, 0);
            mmd.SetData<dynamic>("ColName", "Bank_Salary");
        }
    }
    public static void BankShow(Player Client)
    {
        foreach (var bc in BankCheckpoint)
        {


            if (Main.IsInRangeOfPoint(Client.Position, bc.position, 1.5f))
            {
                if (Main.Server_Hours >= 8 && Main.Server_Hours <= 18)
                {
                    int money = Main.GetSalaryFromBank(Client);
                    if (money == 0)
                    {
                        Main.SendCustomChatMessasge(Client,"[~g~Bank~w~] "+ "Nemate novca na platnom racunu!");
                        return;
                    }
                    else
                    {
                        Main.GivePlayerMoneyBank(Client, money);
                        Main.DisplaySuccess(Client, NotifyType.Success, NotifyPosition.BottomCenter, "Plata u iznosu od $" + money + " je prebacena na Vas bankovni racun!");
                        Client.SetData<dynamic>("character_SalaryValue", 0);
                        Main.GivePlayerSalary(Client, 0);
                    }
                    // anim atm
                }
                else
                {
                    Main.DisplayErrorMessage(Client, NotifyType.Info, NotifyPosition.BottomCenter, "Banka trenutno ne radi, radno vreme banke je od 08.00h do 18.00h");
                }
            }


        }
    }
}
