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
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}