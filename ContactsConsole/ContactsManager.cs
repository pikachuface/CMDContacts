using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
namespace ContactsConsole
{
    static class ContactsManager
    {
        static public List<Contact> Contacts { get; private set; } = new List<Contact>();

        static public void Init()
        {
            CheckFiles();
            LoadContacts();
        }


        static void WriteContacts()
        {
            string jsonContacts = JsonConvert.SerializeObject(Contacts);
            File.WriteAllText(Config.filePath, jsonContacts);
        }

        static private void LoadContacts()
        {
            string inputIO = File.ReadAllText(Config.filePath);
            try
            {
                if (!string.IsNullOrWhiteSpace(inputIO))
                {
                    Contacts = JsonConvert.DeserializeObject<List<Contact>>(inputIO);
                }
            }
            catch (Exception)
            {
                if (MessageWindow.Show("Your contacts file is not formated correctly. \nIt will have to be deleted.\nDo you wish to proceed?", MessageWindow.Type.Error, MessageWindow.Response.YESorNO))
                {
                    File.Delete(Config.filePath);
                }
                else Environment.Exit(-1);
            }
        }

        static void SortContacts()
        {
            Contacts = Contacts.OrderBy(x => x.Name).ToList();
            for (int i = 1; i <= Contacts.Count; i++)
            {
                Contacts[i-1].ID = i;
            }
        }

        static public void AddContact(string name, string number)
        {
            Contacts.Add(new Contact(0, name, number));
            SortContacts();
            WriteContacts();
        }

        static public void DeleteContact(Contact toDelete)
        {
            Contacts.Remove(toDelete);
            SortContacts();
            WriteContacts();
        }



        static private void CheckFiles()
        {
            if (!Directory.Exists(Config.contactsFolderPath))
            {
                Directory.CreateDirectory(Config.contactsFolderPath);
            }
            else if (!File.Exists(Config.filePath))
            {
                File.Create(Config.filePath);
            }
        }

        static public List<Contact> Search(string search)
        {
            List<Contact> found = new List<Contact>();
            int searchedID;
            if (Int32.TryParse(search, out searchedID) && searchedID > 0 && searchedID <= ContactsManager.Contacts.Count)
            {
                found.Add(Contacts[searchedID-1]);
            }
            else searchedID = -1;
            for (int i = 0; i < ContactsManager.Contacts.Count; i++)
            {
                if ($"{ContactsManager.Contacts[i].Name.ToLower()} {ContactsManager.Contacts[i].Phone}".Contains(search.ToLower()) && searchedID-1 != i)
                {
                    found.Add(Contacts[i]);
                }
            }
            return found;
        }

        static public bool Exist(string name)
        {
            if (Contacts.Where(x => x.Name == name).ToArray().Length > 0) return true;
            return false;
        }






    }
}
