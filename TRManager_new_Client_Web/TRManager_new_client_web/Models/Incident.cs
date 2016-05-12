using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRManager_new_client_web.Model
{
    public class Incident
    {
        public int ID { get; set; }
        //public int T_ID { get; set; }
        //public int S_ID { get; set; }
        public Teacher teacher { get; set; }
        public Student student { get; set; }
        public int ticket_ID { get; set; }
        public String arrival { get; set; }
        public String department { get; set; }
        public String comment { get; set; }

        public Incident(Teacher teacher, Student student, int ticket_ID, String Arrival, String department, String Comment)
        {
            this.teacher = teacher;
            this.student = student;
            this.ticket_ID = ticket_ID;
            this.arrival = Arrival;
            this.department = department;
            this.comment = Comment;
        }
        [JsonConstructor]
        public Incident(int ID,Teacher teacher, Student student, int ticket_ID, String Arrival, String Comment)
        {
            this.ID = ID;
            this.teacher = teacher;
            this.student = student;
            this.ticket_ID = ticket_ID;
            this.arrival = Arrival;
            this.comment = Comment;
        }

        public int getId()
        {
            return this.ID;
        }
        public void setId(int id)
        {
            this.ID = id;
        }

        public override string ToString()
        {
            return this.comment;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Incident)) return false;
            return ((Incident)obj).ID == this.ID;
        }

        public bool isCurrent()
        {
            return String.IsNullOrEmpty(this.department);
        }

        public Student getStudent()
        {
            return RepositoryUtility.getStudentById(this.student.ID);
        }

    }
}
