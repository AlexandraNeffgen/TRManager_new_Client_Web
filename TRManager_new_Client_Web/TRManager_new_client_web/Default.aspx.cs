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
        protected void Page_Load(object sender, EventArgs e)
        {
            TRWebClient<Form> test = new TRWebClient<Form>("http", "trmanager", "localhost:8080", "form", "addbulk");
            allForms = test.getAll();
            foreach (Form f in allForms)
            {
                DropDownList1.Items.Add(f.name);
            }
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
    }
}