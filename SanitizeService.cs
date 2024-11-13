using RestSharp;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WFComments
{
    public class SanitizeService
    {
        static readonly string SanitizeURL = "http://www.purgomalum.com/service/";

        public static string SanitizeTextXML(string rawValue)
        {
            var client = new RestClient(SanitizeURL + "xml");
            var request = new RestRequest();
            request.AddParameter("text", rawValue);
            var response = client.Execute(request);
            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                var serializer = new XmlSerializer(typeof(PurgoMalum));
                using (StringReader sr = new(response.Content))
                {
                    PurgoMalum? sanitized = (PurgoMalum?)serializer.Deserialize(sr);
                    return sanitized.result;
                }
            }
            return string.Empty;
        }
        public static string SanitizeTextJSON(string rawValue)
        {
            var client = new RestClient(SanitizeURL + "json");
            var request = new RestRequest();
            request.AddParameter("text", rawValue);
            var response = client.Execute(request);
            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                string receivedJSON = response.Content;
                PurgoMalumJSON? sanitizedResponse = JsonConvert.DeserializeObject<PurgoMalumJSON>(receivedJSON);
                return sanitizedResponse.result;
            }
            return string.Empty;
        }
    }

    public class PurgoMalumJSON
    {
        public string result { get; set; }
    }


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.purgomalum.com")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.purgomalum.com", IsNullable = false)]
    public partial class PurgoMalum
    {

        private string resultField;

        /// <remarks/>
        public string result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }
    }





}
