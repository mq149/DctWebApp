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
        private const string SERVER = "https://localhost:5001/";
        private const string DANGNHAP_URL = "api/Authenticate/Login";
        private const string GETSHIPPER_URL = "api/Shipper/";
        private static readonly HttpClient client = new HttpClient();

        public async Task<Tuple<bool, string>> DangNhap(string postBody)
        {
            HttpResponseMessage responseMessage = null;
            try
            {
                var data = new StringContent(postBody, Encoding.UTF8, "application/json-patch+json");
                responseMessage = await client.PostAsync(SERVER + DANGNHAP_URL, data);
                responseMessage.EnsureSuccessStatusCode();
                if (responseMessage.IsSuccessStatusCode)
                {
                    string response = responseMessage.Content.ReadAsStringAsync().Result;
                    return Tuple.Create(true, response);
                }
            }
            catch (HttpRequestException exception)
            {
                return Tuple.Create(false, exception.Message);
            }
            return Tuple.Create(false, "Đã xảy ra lỗi, vui lòng thử lại");
        }

        public async Task<Tuple<bool, string>> GetShipper(int userId)
        {
            try
            {
                var responseMessage = await client.GetAsync(SERVER + GETSHIPPER_URL + userId.ToString());
                responseMessage.EnsureSuccessStatusCode();
                if (responseMessage.IsSuccessStatusCode)
                {
                    string response = await responseMessage.Content.ReadAsStringAsync();
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
