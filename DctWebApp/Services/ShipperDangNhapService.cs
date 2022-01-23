using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DctWebApp.Services
{
    public class ShipperDangNhapService
    {
        private const string URL = "https://localhost:5001/api/Authenticate/Login";
        private static readonly HttpClient client = new HttpClient();

        public async Task<Tuple<bool, string>> DangNhap(string postBody)
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
                    //JObject obj = JObject.Parse(response);
                    //string message = obj["message"].ToString();
                    return Tuple.Create(true, response);
                }
            }
            catch (HttpRequestException exception)
            {
                return Tuple.Create(false, exception.Message);
            }
            return Tuple.Create(false, "Đã xảy ra lỗi, vui lòng thử lại");
        }
    }
}
