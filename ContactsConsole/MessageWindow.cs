using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsConsole
{
    static class MessageWindow
    {
        public enum Type { Info, Error, Warning }
        public enum Response { YESorNO, OK }

        static public bool Show(string message, Type type)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.Clear();
            switch (type)
            {
                case Type.Info:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Type.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Type.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("Press any button to continue");
            Console.ReadKey();
            return true;
        }
        static public bool Show(string message, Type type, Response response)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.Clear();
            switch (type)
            {
                case Type.Info:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Type.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Type.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
            switch (response)
            {
                case Response.YESorNO:
                    Console.WriteLine("Y) Yes\nN) no");
                    break;
                case Response.OK:
                    Console.WriteLine("Press any button to continue");
                    break;
            }
            ConsoleKeyInfo input;
            bool result = true;
            while (response == Response.YESorNO)
            {
                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Y) break;
                else if (input.Key == ConsoleKey.N)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        static public bool Show(string message, Type type, Response response, string title)
        {
            string defaultTitle = Console.Title;
            Console.Title = title;

            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.Clear();
            switch (type)
            {
                case Type.Info:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Type.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Type.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
            switch (response)
            {
                case Response.YESorNO:
                    Console.WriteLine("Y) Yes\nN) no");
                    break;
                case Response.OK:
                    Console.WriteLine("Press any button to continue");
                    break;
            }
            ConsoleKeyInfo input;
            bool result = true;
            while (response == Response.YESorNO)
            {
                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Y) break;
                else if (input.Key == ConsoleKey.N)
                {
                    result = false;
                    break;
                }
            }
            Console.Title = defaultTitle;
            return result;
        }

    }
}
