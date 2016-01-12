using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRManager_new_Client_Web.Models
{
    public class Student
    {
        public int ID { get; set; }
        public String givenname { get; set; }
        public String surname { get; set; }
        public Form form { get; set; }

        public Student(String Givenname, String Surname, Form form)
        {
            this.givenname = Givenname;
            this.surname = Surname;
            this.form = form;
        }
        [JsonConstructor]
        public Student(int ID, String Givenname, String Surname, Form form)
        {
            this.ID = ID;
            this.givenname = Givenname;
            this.surname = Surname;
            this.form = form;
        }
        public int getId()
        {
            return this.ID;
        }

        public String getGivenname()
        {
            return this.givenname;
        }
        public String getSurname()
        {
            return this.surname;
        }
        public Form getForm()
        {
            return this.form;
        }
        public void setId(int id)
        {
            this.ID = id;
        }
        public void setGivenname(String givenname)
        {
            this.givenname = givenname;
        }
        public void setSurname(String surname)
        {
            this.surname = surname;
        }
        public void setForm(Form form)
        {
            this.form = form;
        }

        public override string ToString()
        {
            return this.getSurname() + " " + this.getGivenname();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Student)) return false;
            return ((Student)obj).ID == this.ID;
        }
    }
}
