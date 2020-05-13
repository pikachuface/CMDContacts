using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
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


        static public void WriteContacts()
        {



        }

        static private void LoadContacts()
        {
            using (var fs = new FileStream(Config.filePath, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        //Contacts.Add(/*sr.ReadLine()*/);
                    }
                }
            }
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
            if (Int32.TryParse(search, out searchedID) && searchedID >= 0 && searchedID <= ContactsManager.Contacts.Count - 1)
            {
                found.Add(Contacts[searchedID]);
            }
            else searchedID = -1;
            for (int i = 0; i < ContactsManager.Contacts.Count; i++)
            {
                if ($"{ContactsManager.Contacts[i].Name} {ContactsManager.Contacts[i].Phone}".Contains(search) && searchedID != i)
                {
                    found.Add(Contacts[i]);
                }
            }
            return found;
        }






    }
}
