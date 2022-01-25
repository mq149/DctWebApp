using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DctWebApp.Data.Account
{
    public class Shipper
    {
        public int Id { get; set; }
        public bool KichHoat { get; set; }

        public Shipper() { }

        public Shipper(int Id, bool KichHoat)
        {
            this.Id = Id;
            this.KichHoat = KichHoat;
        }

        public Shipper(string jsonString)
        {
            JObject data = JObject.Parse(jsonString);
            Id = (int)data["Id"];
            KichHoat = (bool)data["KichHoat"];
        }
    }
}
