using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commandable;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Commands.UseEntryType();
        }

        // app -?
        // app -help
        [Command("Shows the help.")]
        static void Help() => Commands.HelpFromEntryType();

        // app file1.txt file2.txt
        [DefaultCommand("Echoes the arguments.")]
        public static void EchoArgs(string[] args)
        {
            foreach (var arg in args)
                Console.WriteLine(arg);
        }

        // app -add 12 34
        [Command("Adds 2 integers.")]
        public static int Add(int x, int y)
        {
            var result = x + y;
            Console.WriteLine(result);
            return result;
        }
    }
}
