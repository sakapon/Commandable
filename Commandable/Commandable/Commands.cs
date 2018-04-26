using System;
using System.Collections.Generic;
using System.Linq;

namespace Commandable
{
    public static class Commands
    {
        public static void UseEntryType()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (CommandableException ex)
            {
                Console.WriteLine($"Implementation Error: {ex.Message}");
                Environment.ExitCode = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex}");
                Environment.ExitCode = 2;
            }
        }

        public static void HelpFromEntryType()
        {
            Console.WriteLine("TODO: Show Help.");
        }
    }
}
