using DctApi.Shared.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DctWebApp.Services
{
    public class KhoaDaoTaoService
    {
        static readonly HttpClient client = new HttpClient();

        public void ShowKhoaDaoTao(KhoaDaoTaoEntity kdt)
        {
            Console.WriteLine($"{kdt.URL}");
        }

        public async Task<KhoaDaoTaoEntity> GetKhoaDaoTaoAsync()
        {
            KhoaDaoTaoEntity kdt = null;
            HttpResponseMessage response = await client.GetAsync($"http://127.0.0.1:8080/api/khoa-dao-tao/1");
            if (response.IsSuccessStatusCode)
            {
                kdt = await response.Content.ReadAsAsync<KhoaDaoTaoEntity>();
            }
            return kdt;
        }
    }
}
