using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DctWebApp.Data
{
    public class DiaChiModel
    {
        [JsonProperty("soNhaTo")]
        [DefaultValue("")]
        public string SoNhaTo { get; set; }
        [JsonProperty("duong")]
        [DefaultValue("")]
        public string Duong { get; set; }
        [JsonProperty("xaPhuong")]
        [DefaultValue("")]
        public string XaPhuong { get; set; }
        [JsonProperty("quanHuyen")]
        [DefaultValue("")]
        public string QuanHuyen { get; set; }
        [JsonProperty("tinhTP")]
        [DefaultValue("")]
        public string TinhTP { get; set; }

        public DiaChiModel(string jsonString)
        {
            JObject data = JObject.Parse(jsonString);
            SoNhaTo = (string)data["SoNhaTo"];
            Duong = (string)data["Duong"];
            XaPhuong = (string)data["XaPhuong"];
            QuanHuyen = (string)data["QuanHuyen"];
            TinhTP = (string)data["TinhTP"];
        }

        public DiaChiModel()
        {
            SoNhaTo = "";
            Duong = "";
            XaPhuong = "";
            QuanHuyen = "";
            TinhTP = "";
        }

        public string toJSON()
        {
            var diaChi = new
            {
                soNhaTo = SoNhaTo,
                duong = Duong,
                xaPhuong = XaPhuong,
                quanHuyen = QuanHuyen,
                tinhTP = TinhTP
            };
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
            var jsonString = JsonConvert.SerializeObject(diaChi, settings);
            return jsonString;
        }
    }
}
