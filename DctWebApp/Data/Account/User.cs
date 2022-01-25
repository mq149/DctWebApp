
using Newtonsoft.Json.Linq;
using System;

namespace DctWebApp.Data.Account
{
    public class User
    {
        public int Id { get; set; }
        public string SDT { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public User() { }

        public User(int Id, string SDT, string HoTen, string Email, string Token)
        {
            this.Id = Id;
            this.SDT = SDT;
            this.HoTen = HoTen;
            this.Email = Email;
            this.Token = Token;
        }

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
