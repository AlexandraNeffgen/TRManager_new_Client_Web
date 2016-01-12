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
        
    }
}
