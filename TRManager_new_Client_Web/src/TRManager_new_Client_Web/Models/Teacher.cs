using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TRManager_new_Client_Web.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public String name { get; set; }
        public String abbreviation { get; set; }
        public String salutation { get; set; }
        public Teacher(String Name, String Abbreviation, String Salutation)
        {
            this.name = Name;
            this.abbreviation = Abbreviation;
            this.salutation = Salutation;
        }
        [JsonConstructor]
        public Teacher(int ID, String Name, String Abbreviation, String Salutation)
        {
            this.ID = ID;
            this.name = Name;
            this.abbreviation = Abbreviation;
            this.salutation = Salutation;
        }

        public int getId()
        {
            return this.ID;
        }
        public void setId(int ID)
        {
            this.ID = ID;
        }
        public override string ToString()
        {
            return (this.salutation + " " + this.name + ";" + this.abbreviation);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Teacher)) return false;
            return ((Teacher)obj).ID == this.ID;
        }
    }
}
