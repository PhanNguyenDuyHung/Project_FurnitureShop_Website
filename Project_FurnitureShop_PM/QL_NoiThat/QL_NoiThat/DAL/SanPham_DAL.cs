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

namespace QL_NoiThat.DAL
{
    public class SanPham_DAL
    {
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _client;
        public SanPham_DAL()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }
        [HttpGet]
        public async Task<List<SanPham_Model>> GetSanPham()
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/SanPham/GetSanPham");
            List<SanPham_Model> listSp = new List<SanPham_Model>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listSp = JsonConvert.DeserializeObject<List<SanPham_Model>>(data);

                }

            }
            return listSp;
        }
        [HttpGet]
        public async Task<List<Loai_Model>> GetLoai()
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/LoaiHang/GetLoaiHang");
            List<Loai_Model> listloai = new List<Loai_Model>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listloai = JsonConvert.DeserializeObject<List<Loai_Model>>(data);

                }

            }
            return listloai;
        }
        [HttpGet]
        public async Task<List<ChatLieu_Model>> GetChatLieu()
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/ChatLieu/GetChatLieu");
            List<ChatLieu_Model> listloai = new List<ChatLieu_Model>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listloai = JsonConvert.DeserializeObject<List<ChatLieu_Model>>(data);

                }

            }
            return listloai;
        }
        [HttpGet]
        public async Task<List<XuatXu_Model>> GetXuatXu()
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/XuatXu/GetXuatXu");
            List<XuatXu_Model> listxuatxu = new List<XuatXu_Model>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listxuatxu = JsonConvert.DeserializeObject<List<XuatXu_Model>>(data);

                }

            }
            return listxuatxu;
        }
        [HttpPost]
        public async Task<List<SanPham_Model>> PostSanPham(SanPham_Model sanPham)
        {
            try
            {
                string apiUrl = "https://localhost:7053/api/SanPham/CreateSanPham";
                string jsonData = JsonConvert.SerializeObject(sanPham);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc và trả về dữ liệu từ API
                        string responseContent = await response.Content.ReadAsStringAsync();
                        List<SanPham_Model> updatedList = JsonConvert.DeserializeObject<List<SanPham_Model>>(responseContent);
                        return updatedList;
                    }
                    else
                    {
                        // Xử lý lỗi nếu cần
                        // Logger.LogError($"Lỗi khi thêm sản phẩm: {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                // Logger.LogError($"Lỗi khi thêm sản phẩm: {ex.Message}");
            }

            // Trả về danh sách rỗng nếu có lỗi
            return new List<SanPham_Model>();
        }
        [HttpPut]
        public async Task<bool> UpdateProductAsync(string maSP, SanPham_Model updatedProduct)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Chuyển đối tượng C# thành chuỗi JSON
                    string jsonContent = JsonConvert.SerializeObject(updatedProduct);

                    // Đặt kiểu nội dung là JSON
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Gửi yêu cầu HTTP PUT với dữ liệu JSON
                    HttpResponseMessage response = await httpClient.PutAsync($"https://localhost:7053/api/SanPham/UpdateSanPham/{maSP}", new StringContent(jsonContent, Encoding.UTF8, "application/json"));

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
        public async Task<bool> DeleteProductAsync(string maSP)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7053/api/SanPham/DeleteSanPham/{maSP}");

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
        public async Task<List<Loai_Model>> GetTenLH(string matl)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/LoaiHang/GetLoaiHangbyID?id={matl}");
            List<Loai_Model> listdh = new List<Loai_Model>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listdh = JsonConvert.DeserializeObject<List<Loai_Model>>(data);


                }
            }
            return listdh;
        }
        [HttpGet]
        public async Task<List<ChatLieu_Model>> GetTenCL(string matl)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/ChatLieu/GetChatLieubyID?id={matl}");
            List<ChatLieu_Model> listdh = new List<ChatLieu_Model>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listdh = JsonConvert.DeserializeObject<List<ChatLieu_Model>>(data);


                }
            }
            return listdh;
        }
        [HttpGet]
        public async Task<List<XuatXu_Model>> GetXuatXu(string matl)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/XuatXu/GetXuatXubyID?id={matl}");
            List<XuatXu_Model> listdh = new List<XuatXu_Model>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listdh = JsonConvert.DeserializeObject<List<XuatXu_Model>>(data);


                }
            }
            return listdh;
        }
    }
}
