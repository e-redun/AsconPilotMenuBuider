using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsconPilotMenuBuider.Models
{
    public class PersonModel
    {
        private string _name;
        private int age;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Age
        { 
            get => age;
            set => age = value; 
        }
    }
}