using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;


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
                    Console.WriteLine(ContactsManager.Contacts[i].GetAll);
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

            bool first = true;
            ConsoleKeyInfo input =  new ConsoleKeyInfo();
            string searchQuerry = "";
            do
            {
                if (!first)
                {
                    input = Console.ReadKey(true);
                    if (input.Key == ConsoleKey.Backspace && searchQuerry.Length > 0)
                        searchQuerry = searchQuerry.Remove(searchQuerry.Length - 1);
                    else if (input.Key!=ConsoleKey.Backspace) searchQuerry += input.KeyChar;
                }
                else first = false;


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

        static public void ShowAdd()
        {
            Console.Title = appName + " - Add";

            string name;
            string phoneNum;
            bool correctInput = false;
            do
            {
                Console.Clear();
                Console.Write("Add contact:\nName: ");
                name = Console.ReadLine();
                Console.Write("Phone number:");
                phoneNum = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phoneNum))
                {
                    MessageWindow.Show("All information must be filled!", MessageWindow.Type.Warning);
                }
                else if (name.Length <= 3)
                {
                    MessageWindow.Show("Name must contain at least 3!", MessageWindow.Type.Warning);
                }
                else if (!Regex.IsMatch(phoneNum, "([+]\\d{2,3})?([ -]?\\d{3}){3}"))
                {
                    MessageWindow.Show("Number must be in correct format!", MessageWindow.Type.Warning);
                }
                else if (ContactsManager.Exist(name))
                {
                    MessageWindow.Show("Contact with this name already exist!", MessageWindow.Type.Warning);
                }
                else correctInput = true;
            } while (!correctInput);

            if (correctInput)
            {
                ContactsManager.AddContact(name, phoneNum);
            }


        }











    }
}
