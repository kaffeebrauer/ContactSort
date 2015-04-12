using System;
using System.Linq;
using Autofac;
using GlobalX.Console.ContactSort.Infrastructure;
using log4net;

namespace GlobalX.Console.ContactSort
{
    public class Program
    {
        private static IContainer _container;

        public static void Main(string[] args)
        {
            _container = IoC.CreateContainer();
        }
    }
}
