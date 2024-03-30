using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QL_NoiThat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QL_NoiThat.DAL
{
   
    public class NhapHang_DAL
    {


        Uri baseAddress = new Uri("https://localhost:7053/api");
        private readonly HttpClient _client;
        public NhapHang_DAL()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }



        [HttpGet]
        public async  Task<List<PhieuNhapHT_Model>> GetPhieuNhapbyID(int idNCC)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/PhieuNhap/GetNCC_PhieuNhapbyIDNCC?maNCC={idNCC}");
            List <PhieuNhapHT_Model> listKH = new List<PhieuNhapHT_Model>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listKH = JsonConvert.DeserializeObject<List<PhieuNhapHT_Model>>(data);


                }

            }
            return listKH;
        }


        [HttpGet]
        public async Task<List<SanPhamm>> GetTonKho(string idMaNCC)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/PhieuNhap/GetSanPhambyNCC?maNCC={idMaNCC}");
            List<SanPhamm> listSP = new List<SanPhamm>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listSP = JsonConvert.DeserializeObject<List<SanPhamm>>(data);


                }

            }
            return listSP;
        }

		[HttpGet]
		public async Task<List<doanhso>> doanhso(int nam)
		{
			HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/PhieuNhap/GetGiaBanbyMonth?nam={nam}");
			List<doanhso> listSP = new List<doanhso>();
			if (response.IsSuccessStatusCode)
			{

				string data = await response.Content.ReadAsStringAsync();
				if (data != "[]")
				{
					listSP = JsonConvert.DeserializeObject<List<doanhso>>(data);


				}

			}
			return listSP;
		}

		[HttpGet]
		public async Task<List<doanhsoquy>> doanhsoquy(int nam)
		{
			HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/PhieuNhap/GetGiaBanbyQuarter?nam={nam}");
			List<doanhsoquy> listSP = new List<doanhsoquy>();
			if (response.IsSuccessStatusCode)
			{

				string data = await response.Content.ReadAsStringAsync();
				if (data != "[]")
				{
					listSP = JsonConvert.DeserializeObject<List<doanhsoquy>>(data);


				}

			}
			return listSP;
		}

		[HttpGet]
		public async Task<List<SanPham_banchay>> sanphambanchay()
		{
			HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/PhieuNhap/get_spBanchay");
			List<SanPham_banchay> listSP = new List<SanPham_banchay>();
			if (response.IsSuccessStatusCode)
			{

				string data = await response.Content.ReadAsStringAsync();
				if (data != "[]")
				{
					listSP = JsonConvert.DeserializeObject<List<SanPham_banchay>>(data);
				}

			}
			return listSP;
		}

		[HttpGet]
		public async Task<List<SanPham_Sl>> tksanpham()
		{
			HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/PhieuNhap/get_Sanpham_SoLuong");
			List<SanPham_Sl> listSP = new List<SanPham_Sl>();
			if (response.IsSuccessStatusCode)
			{

				string data = await response.Content.ReadAsStringAsync();
				if (data != "[]")
				{
					listSP = JsonConvert.DeserializeObject<List<SanPham_Sl>>(data);


				}

			}
			return listSP;
		}

		public async Task<List<SanPham_Sl>> tksanpham_max()
		{
			HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/PhieuNhap/get_Sanpham_SoLuong_max");
			List<SanPham_Sl> listSP = new List<SanPham_Sl>();
			if (response.IsSuccessStatusCode)
			{

				string data = await response.Content.ReadAsStringAsync();
				if (data != "[]")
				{
					listSP = JsonConvert.DeserializeObject<List<SanPham_Sl>>(data);


				}

			}
			return listSP;
		}
		public async Task<List<SanPham_Sl>> tksanpham_min()
		{
			HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/PhieuNhap/get_Sanpham_SoLuong_min");
			List<SanPham_Sl> listSP = new List<SanPham_Sl>();
			if (response.IsSuccessStatusCode)
			{

				string data = await response.Content.ReadAsStringAsync();
				if (data != "[]")
				{
					listSP = JsonConvert.DeserializeObject<List<SanPham_Sl>>(data);


				}

			}
			return listSP;
		}

		[HttpGet]
        public async Task<List<NhaCungCap_Model>> GetNhaCC()
        {

            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/PhieuNhap/GetNhaCungCap");
            List<NhaCungCap_Model> listSP = new List<NhaCungCap_Model>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listSP = JsonConvert.DeserializeObject<List<NhaCungCap_Model>>(data);

                }

            }
            return listSP;
        }

		[HttpGet]
		public async Task<List<NhaCungCap>> GetNCC()
		{

			HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/PhieuNhap/GetNhaCC");
			List<NhaCungCap> listSP = new List<NhaCungCap>();
			if (response.IsSuccessStatusCode)
			{

				string data = await response.Content.ReadAsStringAsync();
				if (data != "[]")
				{
					listSP = JsonConvert.DeserializeObject<List<NhaCungCap>>(data);

				}

			}
			return listSP;
		}

		[HttpGet]
		public async Task<List<SanPham>> Getsp()
		{

			HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/SanPham/Getmasp_tensp");
			List<SanPham> listSP = new List<SanPham>();
			if (response.IsSuccessStatusCode)
			{

				string data = await response.Content.ReadAsStringAsync();
				if (data != "[]")
				{
					listSP = JsonConvert.DeserializeObject<List<SanPham>>(data);

				}

			}
			return listSP;
		}

		[HttpGet]
        public async Task<List<ChiTietPN>> GetCTPN_ByIDPN(string idMaNhapHang)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/PhieuNhap/Get_ChiTietPhieuNhapbyIDMaNhapHang?maNhapHang={idMaNhapHang}");
            List<ChiTietPN> listCTPN = new List<ChiTietPN>();
            if (response.IsSuccessStatusCode)
            {

                string data = await response.Content.ReadAsStringAsync();
                if (data != "[]")
                {
                    listCTPN = JsonConvert.DeserializeObject<List<ChiTietPN>>(data);


                }
            }
            return listCTPN;
        }

        [HttpPost]
        public async Task<int> CreateCTHD(CreateChiTietPN createChiTietPN)
        {
            try
            {
                string apiUrl = "https://localhost:7053/api/PhieuNhap/CreateCTPN";

         
                string jsonData = JsonConvert.SerializeObject(createChiTietPN);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

               
                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Thêm thành công
                        return 1;
                    }
                    else
                    {
                       
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
		
        [HttpPost]
		public async Task<int> UpdateCTHD(UpdateChiTietPN updateChiTietPN)
		{
			try
			{
				string apiUrl = "https://localhost:7053/api/PhieuNhap/UpdateCTPN";


				string jsonData = JsonConvert.SerializeObject(updateChiTietPN);
				var content = new StringContent(jsonData, Encoding.UTF8, "application/json");


				using (var httpClient = new HttpClient())
				{
					HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

					if (response.IsSuccessStatusCode)
					{
						
						return 1;
					}
					else
					{

						return 0;
					}
				}
			}
			catch (Exception ex)
			{
				return 0;
			}
		}

		[HttpPut]
		public async Task<int> UpdateSLSP(update_sl updatesp)
		{
			try
			{
				string apiUrl = "https://localhost:7053/api/SanPham/UpdateSLSanPham";


				string jsonData = JsonConvert.SerializeObject(updatesp);
				var content = new StringContent(jsonData, Encoding.UTF8, "application/json");


				using (var httpClient = new HttpClient())
				{
					HttpResponseMessage response = await httpClient.PutAsync(apiUrl, content);

					if (response.IsSuccessStatusCode)
					{

						return 1;
					}
					else
					{

						return 0;
					}
				}
			}
			catch (Exception ex)
			{
				return 0;
			}
		}

		[HttpDelete]
		public async Task<int> DeleteCTPN(int idphieunhap, int idchitietphieunhap)
		{
			try
			{
				string apiUrl = $"https://localhost:7053/api/PhieuNhap/DeleteCTPN?idphieunhap={idphieunhap}&idchitietphieunhap={idchitietphieunhap}";

				using (var httpClient = new HttpClient())
				{
					HttpResponseMessage response = await httpClient.DeleteAsync(apiUrl);

					if (response.IsSuccessStatusCode)
					{
						// Xóa thành công
						return 1;
					}
					else
					{
						// Xóa không thành công
						return 0;
					}
				}
			}
			catch (Exception ex)
			{
				// Xảy ra lỗi trong quá trình gửi yêu cầu
				return 0;
			}
		}

		[HttpGet]
		public async Task<List<SanPham_Model>> GetSP()
		{

			HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/SanPham/GetSanPham");
			List<SanPham_Model> listSP = new List<SanPham_Model>();
			if (response.IsSuccessStatusCode)
			{

				string data = await response.Content.ReadAsStringAsync();
				if (data != "[]")
				{
					listSP = JsonConvert.DeserializeObject<List<SanPham_Model>>(data);


				}

			}
			return listSP;
		}

		[HttpGet]
		public async Task<int> GetMaxMaNCC()
		{
			HttpResponseMessage response = await _client.GetAsync("https://localhost:7053/api/PhieuNhap/GetMaxMaNCC");
			response.EnsureSuccessStatusCode(); // Kiểm tra xem yêu cầu có thành công không

			int responseBody = int.Parse(await response.Content.ReadAsStringAsync());
			
			return responseBody;
			
		}

		[HttpPost]
		public async Task<int> checklogin([FromBody] user users)
		{
			string apiUrl = "https://localhost:7053/api/PhieuNhap/checkLogin";
			string jsonData = JsonConvert.SerializeObject(users);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			using (var httpClient = new HttpClient())
			{
				HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

				if (response.IsSuccessStatusCode)
				{

					return 1;
				}
				else
				{

					return 0;
				}
			}

		}

		[HttpPost]
		public async Task<int> CreatePN(PhieuNhap pn)
		{
			try
			{
				string apiUrl = "https://localhost:7053/api/PhieuNhap/CreatePN";


				string jsonData = JsonConvert.SerializeObject(pn);
				var content = new StringContent(jsonData, Encoding.UTF8, "application/json");


				using (var httpClient = new HttpClient())
				{
					HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

					if (response.IsSuccessStatusCode)
					{
						// Thêm thành công
						return 1;
					}
					else
					{

						return 0;
					}
				}
			}
			catch (Exception ex)
			{
				return 0;
			}
		}




	}
}
