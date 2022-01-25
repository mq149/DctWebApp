using DctWebApp.Data;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace DctWebApp.Services
{
    public class HoSoService
    {

        private const string SERVER = "https://localhost:5001/";
        private const string SERVER_2 = "http://localhost:8080/";
        private const string UPLOAD_URL = "api/Upload";
        private const string SHIPPER_ID_URL = "api/Shipper/GetId/";
        private const string HO_SO_SHIPPER_URL = "api/ho-so-shipper/";
        private const string CREATE_HO_SO_URL = "api/ho-so/tao-moi";
        private static readonly HttpClient client = new HttpClient();

        [Inject]
        public IFileReaderService FileReaderService { get; set; }


        public async Task<HoSoModel> GetHoSoShipper(int shipperId)
        {
            try
            {
                var responseMessage = await client.GetAsync(SERVER_2 + HO_SO_SHIPPER_URL + shipperId.ToString());
                responseMessage.EnsureSuccessStatusCode();
                if (responseMessage.IsSuccessStatusCode)
                {
                    string response = await responseMessage.Content.ReadAsStringAsync();
                    return new HoSoModel(response);
                }
            }
            catch (HttpRequestException exception)
            {
            }
            return null;
        }

        public async Task<bool> NopHoSoShipper(string postBody)
        {
            try
            {
                Console.WriteLine(postBody);
                var data = new StringContent(postBody, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(SERVER_2+HO_SO_SHIPPER_URL, data);
                responseMessage.EnsureSuccessStatusCode();
                if (responseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (HttpRequestException exception)
            {
            }
            return false;
        }

        public async Task<HinhAnhModel> UploadImage(HttpContent content)
        {
            HttpResponseMessage responseMessage = null;
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                responseMessage = await client.PostAsync(SERVER+UPLOAD_URL, content);
                responseMessage.EnsureSuccessStatusCode();
                if (responseMessage.IsSuccessStatusCode)
                {
                    string response = await responseMessage.Content.ReadAsStringAsync();
                    HinhAnhModel hinhAnh = new HinhAnhModel(response);
                    if (!string.IsNullOrEmpty(hinhAnh.URL))
                    {
                        hinhAnh.URL = "https://localhost:5001/" + hinhAnh.URL + "?t=" + DateTime.Now;
                    }
                    return hinhAnh;
                }
            }
            catch (HttpRequestException exception)
            {
            }
            return new HinhAnhModel();
        }
    }
}
