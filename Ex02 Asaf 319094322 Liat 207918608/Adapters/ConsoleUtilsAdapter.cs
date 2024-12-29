using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public static class ConsoleUtilsAdapter
    {
        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void WaitForUserInput()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

}
