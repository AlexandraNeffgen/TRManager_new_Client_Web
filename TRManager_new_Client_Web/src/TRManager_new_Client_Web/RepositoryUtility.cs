using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRManager_new_Client_Web.Models;

namespace TRManager_new_Client_Web
{
    public class RepositoryUtility
    {
        private static DataContainer internal_store;
        public static TRManager_http_client<Form> formRepository;
        public static TRManager_http_client<Incident> incidentRepository;
        public static TRManager_http_client<Student> studentRepository;
        public static TRManager_http_client<Teacher> teacherRepository;

        public static bool refreshData()
        {
            try
            {
                internal_store = TRManager_http_client<int>.getExport("http", "localhost:8080", "trmanager", "repmgmt");
            }
            catch (Exception e) { return false; }
            return true;
        }

        public static List<Incident> getIncidentsByStudent(Student s)
        {
            List<Incident> l = new List<Incident>();
            foreach (Incident i in internal_store.getI_Container())
            {
                if (i.student != null)
                    if (i.student.Equals(s)) l.Add(i);
            }
            return l;
        }

        public static Teacher getTeacherByAbbrev(string abbrev)
        {
            return null;
        }

        public static Teacher getTeacherById(int id)
        {
            foreach (Teacher t in internal_store.getT_Container())
            {
                if (t.getId() == id) return t;
            }
            return null;
        }

        public static Student getStudentById(int id)
        {
            foreach (Student s in internal_store.getS_Container())
            {
                if (s.getId() == id) return s;
            }
            return null;
        }
        public static List<Student> getStudentsByForm(Form f)
        {
            List<Student> l = new List<Student>();
            foreach (Student s in internal_store.getS_Container())
            {
                if (s.form.Equals(f)) l.Add(s);
            }
            return l;
        }

        public static bool addTeacherBulk(List<Teacher> tList)
        {
            try
            {
                teacherRepository.addBulk(tList);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public static bool addFormBulk(List<Form> fList)
        {
            try
            {
                formRepository.addBulk(fList);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public static bool addIncidentBulk(List<Incident> iList)
        {
            try
            {
                incidentRepository.addBulk(iList);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public static bool addStudentBulk(List<Student> sList)
        {
            try
            {
                studentRepository.addBulk(sList);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static bool addTeacher(Teacher t)
        {
            try
            {
                teacherRepository.add(t);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public static bool addIncident(Incident i)
        {
            try
            {
                incidentRepository.add(i);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public static bool addForm(Form f)
        {
            try
            {
                formRepository.add(f);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public static bool addStudent(Student s)
        {
            try
            {
                studentRepository.add(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public static List<Teacher> getTeachers()
        {
            return internal_store.getT_Container();
        }
        public static List<Form> getForms()
        {
            return internal_store.getF_Container();
        }
        public static List<Incident> getIncidents()
        {
            return internal_store.getI_Container();
        }
        public static List<Student> getStudents()
        {
            return internal_store.getS_Container();
        }

    }
}
