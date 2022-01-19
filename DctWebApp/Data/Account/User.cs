
using Newtonsoft.Json.Linq;
using System;

namespace DctWebApp.Data
{
    public class User
    {
        public int Id { get; set; }
        public string SDT { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public User(string jsonString)
        {
            JObject data = JObject.Parse(jsonString);
            Id = (int)data["Id"];
            SDT = (string)data["SDT"];
            HoTen = (string)data["HoTen"];
            Email = (string)data["email"];
            Token = (string)data["token"]; 
        }
    }
}
