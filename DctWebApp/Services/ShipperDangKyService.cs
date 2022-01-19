using DctApi.Shared.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DctWebApp.Services
{
    public class ShipperDangKyService
    {
        private const string URL = "https://localhost:5001/api/Authenticate/RegisterShipper";
        private static readonly HttpClient client = new HttpClient();

        public async Task<Tuple<bool, string>> DangKy(string postBody)
        {
            HttpResponseMessage responseMessage = null;
            try
            {
                var data = new StringContent(postBody, Encoding.UTF8, "application/json-patch+json");
                responseMessage = await client.PostAsync(URL, data);
                responseMessage.EnsureSuccessStatusCode();
                if (responseMessage.IsSuccessStatusCode)
                {
                    string response = responseMessage.Content.ReadAsStringAsync().Result;
                    JObject obj = JObject.Parse(response);
                    string message = obj["message"].ToString();
                    return Tuple.Create(true, message);
                }
            } catch (HttpRequestException exception)
            {
                return Tuple.Create(false, exception.Message);
            }
            return Tuple.Create(false, "");
        }

    }
}
