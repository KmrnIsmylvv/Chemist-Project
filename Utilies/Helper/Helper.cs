using System;
using System.Collections.Generic;
using System.Text;

namespace Utilies.Helper
{
    public class Helper
    {
        public static void ChangeTextColor(ConsoleColor color,string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
