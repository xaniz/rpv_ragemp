using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Infinity.Logger
{
    class CrashLogger
    {

        public CrashLogger()
        {
            AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
            {
                
                Debug.WriteLine(eventArgs.Exception.ToString());
                API.Shared.ConsoleOutput($"Expection => {eventArgs.Exception.ToString()}");
               
            };

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Log the exception, display it, etc
            Debug.WriteLine(e.Exception.Message);
            Debug.WriteLine((e.Exception as Exception).Message);
            
            API.Shared.ConsoleOutput($"Expection => {e.Exception.ToString()}");
            API.Shared.ConsoleOutput($"Expection Stack => {e.Exception.StackTrace}");
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Log the exception, display it, etc
            var expection = (e.ExceptionObject as Exception);
            Debug.WriteLine(expection.Message);
            API.Shared.ConsoleOutput($"Expection Terminate {e.IsTerminating}");
            API.Shared.ConsoleOutput($"Expection => {expection.ToString()}");
        }

    }
}
