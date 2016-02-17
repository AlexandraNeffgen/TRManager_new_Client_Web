using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRManager_new_client_web.Model
{
    public class DataContainer
    {
        public int id { get; set; }
        public List<Form> f_container { get; set; }
        public List<Incident> i_container { get; set; }
        public List<Student> s_container { get; set; }
        public List<Teacher> t_container { get; set; }


        public DataContainer(int id,List<Form> f_container, List<Incident> i_container, List<Student> s_container, List<Teacher> t_container)
        {
            this.id = id;
            this.f_container = f_container;
            this.i_container = i_container;
            this.s_container = s_container;
            this.t_container = t_container;
        }
        public List<Form> getF_Container()
        {
            return f_container;
        }
        public List<Incident> getI_Container()
        {
            return i_container;
        }
        public List<Student> getS_Container()
        {
            return s_container;
        }
        public List<Teacher> getT_Container()
        {
            return t_container;
        }
    }
}
