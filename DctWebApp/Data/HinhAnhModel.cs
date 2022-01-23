using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DctWebApp.Data
{
    public class HinhAnhModel
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Id { get; set; }
        public string URL { get; set; }

        public HinhAnhModel(string jsonString)
        {
            JObject data = JObject.Parse(jsonString);
            Id = (int)data["Id"];
            URL = (string)data["Url"];
        }

        public HinhAnhModel(int Id, string URL)
        {
            this.Id = Id;
            this.URL = URL;
        }

        public HinhAnhModel()
        {
            Id = null;
            URL = "";
        }
    }
}
