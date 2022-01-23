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
        private const string UPLOAD_URL = "api/Upload";
        private const string SHIPPER_ID_URL = "api/Shipper/GetId/";
        private static readonly HttpClient client = new HttpClient();

        [Inject]
        public IFileReaderService FileReaderService { get; set; }

        public async Task<int?> GetCurrentShipperId(int userId)
        {
            try
            {
                var responseMessage = await client.GetAsync(SERVER + SHIPPER_ID_URL + userId.ToString());
                responseMessage.EnsureSuccessStatusCode();
                if (responseMessage.IsSuccessStatusCode)
                {
                    string response = await responseMessage.Content.ReadAsStringAsync();
                    return int.Parse(response);
                }
            } catch (HttpRequestException exception)
            {
            }
            return null;
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
                        hinhAnh.URL = "https://localhost:5001/" + hinhAnh.URL;
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
