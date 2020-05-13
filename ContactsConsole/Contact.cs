using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsConsole
{
    public struct Contact
    {
        public int ID;
        public string Name;
        public string Phone;
        public string GetAll
        {
            get
            {
                return $"{this.ID} {this.Name} {this.Phone}";
            }
        }

        public Contact(int _id, string _name, string _phone)
        {
            this.ID = _id;
            this.Name = _name;
            this.Phone = _phone;
        }


    }
}
