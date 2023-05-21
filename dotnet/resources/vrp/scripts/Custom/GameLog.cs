using GTANetworkAPI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
class GameLog : Script
{
    public static List<Server_Log> GLog = new List<Server_Log>();
    public class Server_Log
    {
        /// <summary>
        /// 1 = Player Log
        /// 2 = Money Log
        /// 3 = Item Log
        /// 4 = Admin Log
        /// 5 = Connect
        /// 6 = disconnect
        /// </summary>
        public byte LogType = 1;
        public string LogMessage = "Empty";
        public DateTime LogTime = new DateTime();
    }


    public enum MyEnum
    {
        Player = 1,
        Money = 2,
        Item = 3,
        Admin = 4,
        Login = 5,
        Disconnect = 6,
        Error = 7,
        Chat = 8,
        OOCCHAT = 9,
        PhoneChat = 10,
        RPMe = 11,
        RPDo = 12,
        Dead = 13,
        Damage = 14,
        Anti_Cheat = 15,
        Client_Error = 16,
        LSCUSTOM = 17,
        Job = 18,
        ChopShop = 19
    }
    public GameLog()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.ResetColor();
        StoreLog();
    }


    public static void ELog(MyEnum type, string log)
    {
        Task.Run(() =>
        {

            GLog.Add(new Server_Log { LogType = (byte)type, LogMessage = log, LogTime = DateTime.Now });
            Console.ResetColor();

            switch (type)
            {
                case MyEnum.Player:
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.Write("Client");
                    break;
                case MyEnum.Money:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    //Console.Write(" Money");
                    break;
                case MyEnum.Item:
                    //Console.Write(" Item");
                    break;
                case MyEnum.Admin:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    //Console.Write(" Admin");
                    break;
                case MyEnum.Login:
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Console.Write(" Login");
                    break;
                case MyEnum.Disconnect:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    //Console.Write(" Disconnect");
                    break;
                case MyEnum.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Console.Write(" [ERROR]");
                    break;
                case MyEnum.Chat:
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.Write(" [IC-Chat]");
                    break;
                case MyEnum.OOCCHAT:
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.Write(" [OOC-Chat]");
                    break;
                case MyEnum.PhoneChat:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    //Console.Write(" [Phone-Chat]");
                    break;
                case MyEnum.RPMe:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.Write(" [RP-ME]");
                    break;
                case MyEnum.RPDo:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.Write(" [RP-DO]");
                    break;
                default:
                    return;
            }
            Console.ResetColor();

            //Console.WriteLine(" | "+ log+"\n");
        });

    }
    public static void ELog(Player Client, MyEnum type, string log)
    {

        if (!Client.Exists)
        {
            return;
        }
        Task.Run(() =>
        {
            GLog.Add(new Server_Log { LogType = (byte)type, LogMessage = AccountManage.GetCharacterName(Client) + " " + log, LogTime = DateTime.Now });
            Console.ResetColor();
            //Console.Write($"{DateTime.Now.ToString("HH':'mm':'ss.fff")} | ");
            switch (type)
            {
                case MyEnum.Player:
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.Write("Client");
                    break;
                case MyEnum.Money:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    //Console.Write(" Money");
                    break;
                case MyEnum.Item:
                    //Console.Write(" Item");
                    break;
                case MyEnum.Admin:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    //Console.Write(" Admin");
                    break;
                case MyEnum.Login:
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Console.Write(" Login");
                    break;
                case MyEnum.Disconnect:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    //Console.Write(" Disconnect");
                    break;
                case MyEnum.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Console.Write(" [ERROR]");
                    break;
                case MyEnum.Chat:
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.Write(" [IC-Chat]");
                    break;
                case MyEnum.OOCCHAT:
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.Write(" [OOC-Chat]");
                    break;
                case MyEnum.PhoneChat:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    //Console.Write(" [Phone-Chat]");
                    break;
                case MyEnum.RPMe:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.Write(" [RP-ME]");
                    break;
                case MyEnum.RPDo:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.Write(" [RP-DO]");
                    break;
                default:
                    return;
            }
            Console.ResetColor();
            //Console.WriteLine(" | Identity:"+AccountManage.GetCharacterName(Client)+" "+ log+"\n");
        });
    }

    public void StoreLog()
    {
        TimerEx.SetTimer(() =>
        {
            StartPushingLog();
        }, 30000, 0);
    }

    public void StartPushingLog()
    {

        return;
    }

    [RemoteEvent("Client_Error")]
    public void LogClientError(Player player, string Error)
    {
        GLog.Add(new Server_Log { LogType = (int)MyEnum.Client_Error, LogMessage = AccountManage.GetCharacterName(player) + " " + Error, LogTime = DateTime.Now });
        player.SendChatMessage(Error);
    }


}
