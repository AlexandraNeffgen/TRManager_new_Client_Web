using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRManager_new_client_web.Model
{
    public class Form
    {
        public int ID { get; set; }
//      public int T_ID { get; set; }
        public Teacher teacher { get; set; }
        public String name { get; set; }
        private List<Student> students { get; set; }

        public Form(String Name, Teacher teacher)
        {
            this.name = Name;
            //this.T_ID = T_ID;
            this.teacher = teacher;
        }
        [JsonConstructor]
        public Form(int ID, String name, Teacher teacher, List<Student> students)
        {
            if (students == null) this.students = new List<Student>();
            else this.students = students;
            this.ID = ID;
            this.name = name;
            this.teacher = teacher;
        }

        public int getId()
        {
            return this.ID;
        }
        public void setId(int ID)
        {
            this.ID = ID;
        }

        public void addStudent(Student s)
        {
            this.students.Add(s);
        }
        public List<Student> getStudents()
        {
            return this.students;
        }
        public void setStudents(List<Student> students)
        {
            this.students = students;
        }
        public override string ToString()
        {
            return this.name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Form)) return false;
            return ((Form)obj).ID == this.ID;
        }
    }
}
