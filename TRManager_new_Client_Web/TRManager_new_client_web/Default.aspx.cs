using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TRManager_new_client_web.Model;

namespace TRManager_new_client_web
{
    public partial class _Default : Page
    {
        List<Form> allForms;
        List<Incident> allIncident;
        List<Incident> curIncident;
        protected void Page_Load(object sender, EventArgs e)
        {
            RepositoryUtility.initRU();
            TRWebClient<Form> test = new TRWebClient<Form>("http", "trmanager", "localhost:8080", "form", "addbulk");
            allForms = test.getAll();
            foreach (Form f in allForms)
            {
                DropDownList1.Items.Add(f.name);
            }

            RepositoryUtility.refreshData();
            incident_Load();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TRWebClient<Student> test = new TRWebClient<Student>("http", "trmanager", "localhost:8080", "student", "addbulk");
            List<Student> x = test.getAll();
            foreach (Student s in x)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + s.ToString() + "')", true);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Entered CHANGE')", true);
            List<TableRow> trs = new List<TableRow>();
            Form f = getByName(DropDownList1.SelectedItem.Value);
            foreach (Student s in f.getStudents())
            {
                TableRow x = new TableRow();
                TableCell t1 = new TableCell();
                TableCell t2 = new TableCell();
                t2.Text = s.getGivenname();
                t1.Text = s.getSurname();
                x.Cells.Add(t1); x.Cells.Add(t2);
                trs.Add(x);
            }
            Students.Rows.AddRange(trs.ToArray());

        }
        protected Form getByName(String name)
        {
            foreach (Form f in allForms)
            {
                if (f.name.Equals(name)) return f;
            }
            return null;
        }


        protected void incident_Load()
        {
            TRWebClient<Incident> test = new TRWebClient<Incident>("http", "trmanager", "localhost:8080", "incident", "addbulk");
            allIncident = test.getAll();
            curIncident = new List<Incident>();
            if (allIncident.Count == 0)
                return;
            foreach (Incident ii in allIncident)
            {
                if (ii.department == "" || String.IsNullOrEmpty(ii.department))
                    curIncident.Add(ii);
            }
            if (curIncident.Count == 0)
                curIncident.Add(new Incident(0, new Teacher("", "", ""), new Student(0, "", "", new Form("", new Teacher("", "", ""))), 0, "", ""));
            GridView1.DataSource = curIncident;
            GridView1.DataBind();
        }

        protected void addIncident(object sender, EventArgs e)
        {
            TRWebClient<Incident> test = new TRWebClient<Incident>("http", "trmanager", "localhost:8080", "incident", "addbulk");
            test.add(new Incident(allIncident[1].getTeacher(), allIncident[1].getStudent(), 4, "2015-09-28 12:50:00", null ,"testIncident"));
        }
        protected void commitAddIncident(object sender, EventArgs e)
        {

        }

        protected void panel_add_incident_Load(object sender, EventArgs e)
        {
            List<Student> allStudents = RepositoryUtility.getStudents();
            foreach (Student s in allStudents)
            {
                ListItem x = new ListItem();
                x.Text = s.getGivenname() + " " + s.getSurname();
                x.Value = s.ID.ToString();
                student_cb.Items.Add(x);
            }

        }

        protected void teacher_cb_Load(object sender, EventArgs e)
        {
            List<Teacher> allTeachers = RepositoryUtility.getTeachers();
            foreach (Teacher t in allTeachers)
            {
                ListItem x = new ListItem();
                x.Text = t.name;
                x.Value = t.ID.ToString();
                teacher_cb.Items.Add(x);
            }
        }

        protected void teacher_cb_Init(object sender, EventArgs e)
        {

        }

        protected void btnAddIncident_Click(object sender, EventArgs e)
        {
            Student s = RepositoryUtility.getStudentById(int.Parse(student_cb.SelectedItem.Value));
            Teacher t = RepositoryUtility.getTeacherById(int.Parse(teacher_cb.SelectedItem.Value));
            Incident i = new Incident(0, t, s, 0, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), tb_comment.Text);
            RepositoryUtility.addIncident(i);
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"Vorfall hinzugefügt\");", true);
        }
    }
}