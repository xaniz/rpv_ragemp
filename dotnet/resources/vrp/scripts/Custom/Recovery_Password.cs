using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

class Rec_Password : Script
{

    [RemoteEvent("Recovery_Password")]
    public void Recovery_Password(Player Client, string name)
    {


        try
        {
            
            MySqlConnection connection = new MySqlConnection(Main.myConnectionString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM users WHERE email='" + name + "' OR socialclubname='" + name + "' OR socialclubname='" + Client.SocialClubName + "'";
            MySqlDataReader reader = command.ExecuteReader();
            string Email = "";
            string password = "";
            string username = "";
            while ( reader.Read())
            {
                if (reader.FieldCount <= 0)
                {
                    NAPI.Notification.SendNotificationToPlayer(Client, "~r~Account nije pronadjen.", true);
                    return;
                }
                Email = reader.GetString("email");
                password = reader.GetString("password");
                username = Client.SocialClubName;
                break;

            }

            if (Email == "0")
            {
                NAPI.Notification.SendNotificationToPlayer(Client, "~r~Nemate registrovanu email adresu, postavite zahtev na forum za vracanje sifre!", true);
                return;
            }
            else if (Email == "")
            {
                NAPI.Notification.SendNotificationToPlayer(Client, "~r~Nemate account.", true);
                return;
            }
            connection.Close();
            reader.Close();


            OnButtonClick(Email, password, username);

        }
        catch (Exception e)
        {
            NAPI.Util.ConsoleOutput(e.StackTrace);


        }


    }
    private void OnButtonClick(string Email, string password, string username)
    {
         Task.Run(() =>
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpserver = new SmtpClient("smtp.gmail.com");

                smtpserver.UseDefaultCredentials = true;
                mail.From = new MailAddress("supportrpv@gmail.com");
                mail.To.Add(Email);
                mail.Subject = "" + Main.SERVER_NAME + " Password Recovery of '" + username + "' Account";


                mail.Body = "Pozdrav \n";
                mail.Body += username+ ", postovani, \n";
                mail.Body += "Obavestavamo Vas da je Vas zahtev za vracanje sifre usvojen.\n";
                mail.Body += "Vasa sifra je : "+password+ "\n";
                mail.Body += "Ukoliko niste poslali zahtev, odmah kontaktirajte Administraciju.\n";
                mail.Body += "Vi ste odgovorni za sve posledice i zloupotrebu ove email adrese.\n";
                mail.Body += "Nikada nemojte odavati Vasu sifru ili ime naloga.\n";
                mail.Body += "Srdacan pozdrav.";
               
                
                mail.Priority = MailPriority.High;

                smtpserver.Port = 587;
                smtpserver.Credentials = new System.Net.NetworkCredential("supportrpv@gmail.com", "sifra");
                smtpserver.EnableSsl = true;

                smtpserver.Send(mail);

               
            }
            catch (Exception)
            {

            }
           
        });

    }



}
