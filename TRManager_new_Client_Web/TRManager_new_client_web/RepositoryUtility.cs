using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRManager_new_client_web.Model;

namespace TRManager_new_client_web
{

    public class RepositoryUtility
    {
        private static DataContainer internal_store;
        public static TRWebClient<Form> formRepository;
        public static TRWebClient<Incident> incidentRepository;
        public static TRWebClient<Student> studentRepository;
        public static TRWebClient<Teacher> teacherRepository;

        public static bool refreshData()
        {
            try
            {
                internal_store = TRWebClient<int>.getExport("http", "localhost:8080", "trmanager", "repmgmt");
            }
            catch (Exception e) { return false; }
            return true;
        }

        public static List<Incident> getIncidentsByStudent(Student s)
        {
            return s.getIncidents();
        }

        public static Teacher getTeacherByAbbrev(string abbrev)
        {
            foreach (Teacher t in internal_store.getT_Container())
            {
                if (t.abbreviation.Equals(abbrev)) return t;
            }
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

        public static Form getFormById(int id)
        {
            return formRepository.getById(id);
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
            return f.getStudents();

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
            return teacherRepository.getAll();
        }
        public static List<Form> getForms()
        {
            return formRepository.getAll();
        }
        public static List<Incident> getIncidents()
        {
            return incidentRepository.getAll();
        }
        public static List<Student> getStudents()
        {
            return studentRepository.getAll();
        }
        public static Form getFormByName(String name)
        {
            foreach (Form f in internal_store.getF_Container())
            {
                if (f.name.Equals(name)) return f;
            }
            return null;
        }

        public void test3()
        {

        }


    }
}