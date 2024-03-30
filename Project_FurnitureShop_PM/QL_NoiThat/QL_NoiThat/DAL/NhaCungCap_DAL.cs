using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_NoiThat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NoiThat.DAL
{
    public class NhaCungCap_DAL
    {
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _client;
        public NhaCungCap_DAL()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }
        [HttpGet]
        public async Task<List<NhaCungCap_M>> GetNhaCungCap()
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/NhaCungCap/GetNhaCungCap");
            List<NhaCungCap_M> listNCC = new List<NhaCungCap_M>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listNCC = JsonConvert.DeserializeObject<List<NhaCungCap_M>>(data);

                }

            }
            return listNCC;
        }
        [HttpPost]
        public async Task<List<NhaCungCap_M>> PostNhaCungCap(NhaCungCap_M nhaCungCap)
        {
            try
            {
                string apiUrl = "https://localhost:7053/api/NhaCungCap/PostNhaCungCap";
                string jsonData = JsonConvert.SerializeObject(nhaCungCap);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        response.EnsureSuccessStatusCode();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return new List<NhaCungCap_M>();
        }
        [HttpPut]
        public async Task<bool> UpdateNhaCungCap(int maNCC, NhaCungCap_M nhaCungCap)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Chuyển đối tượng C# thành chuỗi JSON
                    string jsonContent = JsonConvert.SerializeObject(nhaCungCap);

                    // Đặt kiểu nội dung là JSON
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Gửi yêu cầu HTTP PUT với dữ liệu JSON
                    HttpResponseMessage response = await httpClient.PutAsync($"https://localhost:7053/api/NhaCungCap/PutNhaCungCap?maNCC={maNCC}", new StringContent(jsonContent, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        // Xử lý lỗi nếu cần
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                return false;
            }
        }
        [HttpDelete]
        public async Task<bool> DeleteNhaCungCap(string maNCC)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7053/api/NhaCungCap/DeleteNhaCungCap/{maNCC}");

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        // Xử lý lỗi nếu cần
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                return false;
            }
        }




        [HttpGet]
        public async Task<List<Donhang>> GetDonHang()
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/NhaCungCap/GetNhaCungCap");
            List<Donhang> listNCC = new List<Donhang>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listNCC = JsonConvert.DeserializeObject<List<Donhang>>(data);

                }

            }
            return listNCC;
        }
    }
}
