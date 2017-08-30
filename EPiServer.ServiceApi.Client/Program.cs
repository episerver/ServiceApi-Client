using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Integration.Client.Tests;

namespace EPiServer.Integration.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var test in GetEnumerableOfType<BaseTest>())
            {
                Console.WriteLine(test.Execute());
            }
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
        {
            var objects = Assembly.GetAssembly(typeof (T)).GetTypes().
                Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof (T))).
                Select(type => (T) Activator.CreateInstance(type, constructorArgs)).ToList();

            return objects;
        }
    }
}
