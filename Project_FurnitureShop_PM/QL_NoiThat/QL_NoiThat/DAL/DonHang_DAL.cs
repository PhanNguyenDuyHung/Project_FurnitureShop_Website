using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_NoiThat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QL_NoiThat.DAL
{
    public class DonHang_DAL
    {
        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _client;
        public DonHang_DAL()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }
        [HttpGet]
        public async Task<List<Donhang>> GetDonHang()
        {

            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/NhaCungCap/GetDonHang");
            List<Donhang> listDH = new List<Donhang>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listDH = JsonConvert.DeserializeObject<List<Donhang>>(data);

                }

            }
            return listDH;
        }
        [HttpGet]
        public async Task<List<Donhang>> GetDonHang_ByTT(string tinhTrang)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/NhaCungCap/GetDonHangByTinhTrang?tinhTrang={tinhTrang}");
            List<Donhang> listdh = new List<Donhang>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listdh = JsonConvert.DeserializeObject<List<Donhang>>(data);


                }
            }
            return listdh;
        }
        [HttpGet]
        public async Task<List<Donhang>> GetDonHang_BymaDH(string maDonHang)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/NhaCungCap/GetDonHangByMaDH?maDonHang={maDonHang}");
            List<Donhang> listdh = new List<Donhang>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listdh = JsonConvert.DeserializeObject<List<Donhang>>(data);


                }
            }
            return listdh;
        }
        [HttpGet]
        public async Task<List<CTDH>> GetCTDH_ByIDMDH(string MaDonHang)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/NhaCungCap/GetChiTietDonHang?maDonHang={MaDonHang}");
            List<CTDH> listCTDH = new List<CTDH>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listCTDH = JsonConvert.DeserializeObject<List<CTDH>>(data);


                }
            }
            return listCTDH;
        }
            [HttpPut]
            public async Task<bool> UpdateTinhTrang(int maDH,Donhang tinhtrang)
            {
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        // Chuyển đối tượng C# thành chuỗi JSON
                        string jsonContent = JsonConvert.SerializeObject(tinhtrang);

                        // Đặt kiểu nội dung là JSON
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        // Gửi yêu cầu HTTP PUT với dữ liệu JSON
                        HttpResponseMessage response = await httpClient.PutAsync($"https://localhost:7053/api/NhaCungCap/UpdateTinhTrang?MaDH={maDH}", new StringContent(jsonContent, Encoding.UTF8, "application/json"));

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
    }
}
