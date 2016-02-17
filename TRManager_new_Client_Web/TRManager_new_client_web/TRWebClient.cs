using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using TRManager_new_client_web.Model;

namespace TRManager_new_client_web
{
    public class TRWebClient<T>
    {
        private string application_name;
        private string host;
        private string Endpoint;
        private string protocol;
        private HttpWebRequest request;
        private string bulk_endpoint;


        public static DataContainer getExport(String protocol, String host, String application_name, String Endpoint)
        {
            HttpWebRequest d_request = WebRequest.Create(protocol + "://" + host + "/" + application_name + "/" + Endpoint) as HttpWebRequest;
            d_request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)d_request.GetResponse();
            WebHeaderCollection header = response.Headers;
            string response_text = "";
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                response_text = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<DataContainer>(response_text, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd hh:mm:ss" });
        }

        public static void deleteRepository(String protocol, String host, String application_name, String Endpoint)
        {
            HttpWebRequest d_request = WebRequest.Create(protocol + "://" + host + "/" + application_name + "/" + Endpoint) as HttpWebRequest;
            d_request.Method = "DELETE";
            d_request.GetResponse();
        }

        public String add(T obj)
        {
            request = WebRequest.Create(protocol+"://" + host + "/" + application_name + "/" + Endpoint) as HttpWebRequest;
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = "POST";
            ASCIIEncoding encoding = new ASCIIEncoding();

            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.None, ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            Console.WriteLine(JsonConvert.SerializeObject(obj, serializerSettings));
            Byte[] bytes = encoding.GetBytes(JsonConvert.SerializeObject(obj,  serializerSettings));
            Stream newStream = request.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            return content;
        }

        public List<T> addBulk(List<T> obj)
        {
            request = WebRequest.Create(protocol + "://" + host + "/" + application_name + "/" + Endpoint + "/" + bulk_endpoint) as HttpWebRequest;
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = "POST";
            ASCIIEncoding encoding = new ASCIIEncoding();
            //Console.WriteLine(JsonConvert.SerializeObject(obj, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd hh:mm:ss" }));
            Byte[] bytes = encoding.GetBytes(JsonConvert.SerializeObject(obj, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd hh:mm:ss" }));
            Stream newStream = request.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public T getById(int id)
        {
            request = WebRequest.Create(protocol+"://" + host + "/" + application_name + "/" + Endpoint + "/" + id) as HttpWebRequest;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            WebHeaderCollection header = response.Headers;
            string response_text = "";
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                response_text = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(response_text, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd hh:mm:ss" });
        }

        public List<T> getAll()
        {
            request = WebRequest.Create(protocol + "://" + host + "/" + application_name + "/" + Endpoint) as HttpWebRequest;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            WebHeaderCollection header = response.Headers;
            string response_text = "";
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                response_text = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<T>>(response_text, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd hh:mm:ss" });
        }

        public TRWebClient(string protocol,string application_name, string host, string Endpoint, string bulk_endpoint)
        {
            this.bulk_endpoint = bulk_endpoint;
            this.protocol = protocol;
            this.application_name = application_name;
            this.host = host;
            this.Endpoint = Endpoint;
        }
    }
}