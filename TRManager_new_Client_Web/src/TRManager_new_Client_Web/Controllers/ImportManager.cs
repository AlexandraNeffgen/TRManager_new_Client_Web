using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRManager_new_Client_Web.Models;


namespace TRManager_new_Client_Web.Controllers
{
    public class ImportManager
    {
        /**
            Class for Importing Data from the CSV Files.
            Import Cycle:
           --- BEGIN CYCLE ---
            1. Read Teacher Data
            2. Send Data to Server
            3. Get Data from Server (To get the IDs)
            4. Read Form Data and use T_IDs to create them 
            5. Send Data to Server
            6. Get Data from Server (To get the IDs)
            7. Read Student Data, and use F_IDs to create them
            8. Send Student Data to Server
            9. Get Data from Server (To get the IDs)
           10. Read Incident Data and use all of the former
           11. Send Data to Server
           --- END OF CYCLE ---
        **/
        public static List<Form> formList;
        public static List<Incident> incidentList;
        public static List<Student> studentList;
        public static List<Teacher> teacherList;
        public static TRManager_http_client<Form> formRepository;
        public static TRManager_http_client<Incident> incidentRepository;
        public static TRManager_http_client<Student> studentRepository;
        public static TRManager_http_client<Teacher> teacherRepository;


        public static bool doImport(string teacherdata, int teacherskip, string studentdata, int studentskip, string incidentdata, int incidentskip)
        {
            try
            {
                TRManager_http_client<int>.deleteRepository("http", "localhost:8080", "trmanager", "repmgmt");
                formRepository = new TRManager_http_client<Form>("http", "trmanager", "localhost:8080", "form", "addbulk");
                incidentRepository = new TRManager_http_client<Incident>("http", "trmanager", "localhost:8080", "incident", "addbulk");
                studentRepository = new TRManager_http_client<Student>("http", "trmanager", "localhost:8080", "student", "addbulk");
                teacherRepository = new TRManager_http_client<Teacher>("http", "trmanager", "localhost:8080", "teacher", "addbulk");
                //--- BEGIN CYCLE ---
                teacherList = readTeacherData(teacherskip, teacherdata);
                teacherList = teacherRepository.addBulk(teacherList);
                /*foreach(Teacher t in teacherList)
                {
                    Console.WriteLine(t.ToString() + ";" + t.getId());
                }*/
                formList = readFormData(studentskip, studentdata);
                formList = formRepository.addBulk(formList);
                /*foreach(Form f in formList)
                {
                    Console.WriteLine(f.Name + ";" + f.getId());
                }*/
                studentList = readStudentData(studentskip, studentdata);
                studentList = studentRepository.addBulk(studentList);
                /*foreach(Student s in studentList)
                {
                    Console.WriteLine(s.Surname + " " + s.getGivenname() + ";" + s.getId() + ";" + Utility.getFormById(s.getF_ID(), formList).Name);
                }*/
                incidentList = readIncidentData(incidentskip, incidentdata);
                incidentList = incidentRepository.addBulk(incidentList);
                //--- END CYCLE ---
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }

        public static List<Teacher> readTeacherData(int skip, string filename)
        {
            System.IO.StreamReader file;
            try
            {
                file = new System.IO.StreamReader(filename);
            }
            catch (Exception e) { return null; }

            for (int i = 0; i < skip; i++) file.ReadLine();

            List<String> fromFile = readDataFromFile(file);
            List<Teacher> result = new List<Teacher>();
            foreach (string s in fromFile)
            {
                String[] values = s.Split(';');
                if (values.Length < 4) continue;
                result.Add(new Teacher(Utility.cleanString(values[1]) + " " + Utility.cleanString(values[2]), Utility.cleanString(values[3]), Utility.cleanString(values[0])));
            }
            return result;
        }

        public static List<Form> readFormData(int skip, string filename)
        {
            System.IO.StreamReader file;
            try
            {
                file = new System.IO.StreamReader(filename);
            }
            catch (Exception e) { return null; }

            for (int i = 0; i < skip; i++) file.ReadLine();
            List<String> fromFile = readDataFromFile(file);
            List<Form> result = new List<Form>();
            foreach (string s in fromFile)
            {
                String[] values = s.Split(';');
                if (!isFormPresent(values[2], result))
                {
                    Form f = new Form(Utility.cleanString(values[2]), Utility.getTeacherByAbbreviation(Utility.cleanString(values[3]), teacherList));
                    result.Add(f);
                }
            }
            return result;
        }
        public static List<Student> readStudentData(int skip, string filename)//TODO: FINISH IMPLEMENTATION
        {
            System.IO.StreamReader file;
            try
            {
                file = new System.IO.StreamReader(filename);
            }
            catch (Exception e) { return null; }

            for (int i = 0; i < skip; i++) file.ReadLine();

            List<String> fromFile = readDataFromFile(file);
            List<Student> result = new List<Student>();
            foreach (string s in fromFile)
            {
                String[] values = s.Split(';');
                result.Add(new Student(Utility.cleanString(values[0]), Utility.cleanString(values[1]), Utility.getFormByName(values[2], formList)));
            }
            return result;
        }

        public static List<Incident> readIncidentData(int skip, string filename)
        {
            System.IO.StreamReader file;
            try
            {
                file = new System.IO.StreamReader(filename);
            }
            catch (Exception e) { return null; }

            for (int i = 0; i < skip; i++) file.ReadLine();

            List<String> fromFile = readDataFromFile(file);
            List<Incident> result = new List<Incident>();
            foreach (string s in fromFile)
            {
                //ID,S_ID,ticket_ID,T_ID,Arrival,Department,Comment
                try
                {
                    RepositoryUtility.refreshData();
                    String[] values = s.Split(';');
                    if (values.Length == 6)
                    {
                        Console.WriteLine(int.Parse(values[3]) + ";" + int.Parse(values[1]));
                        Incident i = new Incident(RepositoryUtility.getTeacherById(int.Parse(values[3])), RepositoryUtility.getStudentById(int.Parse(values[1])), int.Parse(values[2]), values[4], "");
                        result.Add(i);
                    }
                    else if (values.Length == 7)
                    {
                        Console.WriteLine(int.Parse(values[3]) + ";" + int.Parse(values[1]));
                        Incident i = new Incident(RepositoryUtility.getTeacherById(int.Parse(values[3])), RepositoryUtility.getStudentById(int.Parse(values[1])), int.Parse(values[2]), values[4], Utility.cleanString(values[6]));
                        result.Add(i);
                    }
                    else continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(s + " Failed");
                }
            }
            return result;
        }

        private static bool isFormPresent(string name, List<Form> flist)
        {
            foreach (Form f in flist)
            {
                if (f.name.Equals(name)) return true;
            }
            return false;
        }

        private static List<String> readDataFromFile(System.IO.StreamReader file)
        {
            List<String> data = new List<string>();
            string line = "";
            while ((line = file.ReadLine()) != null)
            {
                if (!line.Equals("")) data.Add(line);
            }
            return data;
        }
    }
}
