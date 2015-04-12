using System;
using Autofac;
using GlobalX.Console.ContactSort.Exceptions;
using GlobalX.Console.ContactSort.Infrastructure;
using log4net;

namespace GlobalX.Console.ContactSort
{
    public class Program
    {
        private static IContainer _container;

        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += ApplicationUnhandledExceptionEventHandler;

            if (args.Length == 0)
            {
                throw new GlobalXConsoleException(Common.Resources.Exceptions.CONSOLE_FILE_INPUT_EXPECTED);
            }

            if (args.Length > 1)
            {
                throw new GlobalXConsoleException(Common.Resources.Exceptions.CONSOLE_FILE_AMOUNT_EXCEEDED);
            }

            var filePath = args[0];
            _container = IoC.CreateContainer();
        }

        private static void ApplicationUnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e)
        {
            var log = LogManager.GetLogger(typeof(Program));
            log.Error(((Exception)e.ExceptionObject).Message, (Exception)e.ExceptionObject);
        }
    }
}
