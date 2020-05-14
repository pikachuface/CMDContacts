using System;

namespace ContactsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UI.Init();
            ContactsManager.Init();
            ConsoleKeyInfo input;
            do
            {
                input = UI.MainMenu();
                switch (input.Key)
                {
                    case (ConsoleKey.A):
                        UI.ShowAll();
                        break;
                    case (ConsoleKey.B):
                        UI.ShowSearch();
                        break;
                    case (ConsoleKey.C):
                        UI.ShowAdd();
                        break;
                    case (ConsoleKey.D):
                        break;
                }



            } while (input.Key!=ConsoleKey.Escape);
        }
    }
}
