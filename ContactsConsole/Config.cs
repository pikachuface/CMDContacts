using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsConsole
{
    static class Config
    {
        static public string contactsFolderPath { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CMDContacts\\";
        static public string filePath { get; } = contactsFolderPath+"Contacts.txt";
    }
}
