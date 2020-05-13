using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ContactsConsole
{
    static class UI
    {
        const ConsoleColor defaultColor = ConsoleColor.Green;
        const string appName = "Contacts";

        static public void Init()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.Title = appName + "By Filip Gajdušek";
            Console.ForegroundColor = defaultColor;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(Graphics.BootScreen);
            Thread.Sleep(1000);
        }

        static public ConsoleKeyInfo MainMenu()
        {
            Console.Clear();
            Console.Title = appName + " - Main menu";
            Console.WriteLine("Menu:");
            Console.WriteLine("A) Show all");
            Console.WriteLine("B) Search");
            Console.WriteLine("C) Add");
            Console.WriteLine("D) Delete");
            Console.WriteLine("\nESC) Exit");

            return Console.ReadKey(true);
        }

        static public void ShowAll()
        {
            Console.Clear();
            Console.Title = appName + " - Show all";

            Console.WriteLine("All contacts:");
            if (ContactsManager.Contacts.Count > 0)
            {
                for (int i = 0; i < ContactsManager.Contacts.Count; i++)
                {
                    Console.WriteLine(ContactsManager.Contacts[i]);
                }
            }
            else
            {
                Console.WriteLine(Graphics.NotFound);
            }
            Console.ReadKey(true);
        }


        static public void ShowSearch()
        {
            Console.Title = appName + " - Search";

            Console.Clear();
            Console.WriteLine("Search mode:\nSearch bar: |");
            Console.WriteLine("Found:");

            ConsoleKeyInfo input;
            string searchQuerry = null;
            do
            {
                input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.Backspace && searchQuerry.Length > 0)
                    searchQuerry = searchQuerry.Remove(searchQuerry.Length - 1);
                else if (System.Text.RegularExpressions.Regex.IsMatch(input.Key.ToString(), @"^(\p{L}||\d){1}$")) searchQuerry += input.KeyChar;

                Console.Clear();
                Console.Write("Search mode\nSearch bar: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(searchQuerry);
                Console.ForegroundColor = defaultColor;
                Console.WriteLine('|');
                Console.WriteLine("Found:");

                var foundContacts = ContactsManager.Search(searchQuerry);
                if (foundContacts.Count > 0)
                {
                    foreach (var contact in foundContacts)
                    {
                        Console.WriteLine(contact.GetAll);
                    }
                }
                else Console.Write(Graphics.NotFound);

            } while (input.Key != ConsoleKey.Escape && input.Key != ConsoleKey.Enter);
        }









    }
}
