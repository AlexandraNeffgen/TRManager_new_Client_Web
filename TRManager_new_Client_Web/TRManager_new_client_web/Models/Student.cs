using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRManager_new_client_web.Model
{
    public class Student
    {
        public int ID { get; set; }
        public int schild_id { get; set; }
        public String givenname { get; set; }
        public String surname { get; set; }
        public Form form { get; set; }
        private List<Incident> incidents { get; set; }

        public Student(int schild_id, String Givenname, String Surname, Form form)
        {
            this.incidents = new List<Incident>();
            this.givenname = Givenname;
            this.surname = Surname;
            this.form = form;
        }
        [JsonConstructor]
        public Student(int ID, int schild_id, String Givenname, String Surname, Form form, List<Incident> incidents)
        {
            if (incidents == null) this.incidents = new List<Incident>();
            else this.incidents = incidents;
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
        public void setIncidents(List<Incident> incidents)
        {
            this.incidents = incidents;
        }

        public void addIncident(Incident incident)
        {
            this.incidents.Add(incident);
        }

        public bool removeIncident(Incident incident)
        {
            return this.incidents.Remove(incident);
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

        public List<Incident> getIncidents()
        {
            foreach (Incident i in RepositoryUtility.getIncidents())
            {
                if (i.getStudent().ID == this.ID)
                {
                    this.incidents.Add(i);
                }
            }
            return this.incidents;
        }

    }
}
