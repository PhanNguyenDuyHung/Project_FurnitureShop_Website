using QL_NoiThat.DAL;
using QL_NoiThat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QL_NoiThat.BUS
{
    public class NhapHang_BUS
    {
        NhapHang_DAL phieunhap_dal;
        public NhapHang_BUS()
        {
             phieunhap_dal = new NhapHang_DAL();
        }

        public async Task<List<PhieuNhapHT_Model>> getPhieuNhap (int idNCC)
        {
            List < PhieuNhapHT_Model > listPN= await phieunhap_dal.GetPhieuNhapbyID(idNCC);
            return listPN;
        }


        public async Task<List<SanPhamm>> getTonKho(string idNCC)
        {
            List<SanPhamm> listSP = await phieunhap_dal.GetTonKho(idNCC);
            return listSP;
        }

		public async Task<List<doanhso>> doanhso(int nam)
		{
			List<doanhso> listSP = await phieunhap_dal.doanhso(nam);
			return listSP;
		}

		public async Task<List<doanhsoquy>> doanhsoquy(int nam)
		{
			List<doanhsoquy> listSP = await phieunhap_dal.doanhsoquy(nam);
			return listSP;
		}

		public async Task<List<NhaCungCap_Model>> getNCC()
        {
            List<NhaCungCap_Model> listSP = await phieunhap_dal.GetNhaCC();
            return listSP;
        }

		public async Task<List<SanPham>> getsp()
		{
			List<SanPham> listSP = await phieunhap_dal.Getsp();
			return listSP;
		}

		public async Task<List<NhaCungCap>> GetNCC()
		{
			List<NhaCungCap> listSP = await phieunhap_dal.GetNCC();
			return listSP;
		}

		public async Task<List<ChiTietPN>> getChiTietPhieuNhap(string idPN)
        {
            List<ChiTietPN> listSP = await phieunhap_dal.GetCTPN_ByIDPN(idPN);
            return listSP;
        }

        public async Task<int> createCTPhieuNhap(CreateChiTietPN createChiTietPN)
        {
            int result = await phieunhap_dal.CreateCTHD(createChiTietPN);
            return result;
        }

		public async Task<int> DeleteCTPN(int idphieunhap, int idchitietphieunhap)
		{
			int result = await phieunhap_dal.DeleteCTPN(idphieunhap, idchitietphieunhap);
            return result;
		}

		public async Task<int> updateCTPhieuNhap(UpdateChiTietPN updateChiTietPN)
		{
			int result = await phieunhap_dal.UpdateCTHD(updateChiTietPN);
			return result;
		}

		public async Task<int> checklogin(user users)
		{
			int result = await phieunhap_dal.checklogin(users);
			return result;
		}

		public async Task<int> updateSLSP(update_sl update)
		{
			int result = await phieunhap_dal.UpdateSLSP(update);
			return result;
		}

		public async Task<List<SanPham_Model>> getSP()
		{
			List<SanPham_Model> listSP = await phieunhap_dal.GetSP();
			return listSP;
		}

		public async Task<int> createPhieuNhap(PhieuNhap pn)
		{
			int result = await phieunhap_dal.CreatePN(pn);
			return result;
		}

		public async Task<int> GetMaxMaNCC()
		{
			int result = await phieunhap_dal.GetMaxMaNCC();
			return result;
		}

		public async Task<List<SanPham_Sl>> getSP_SL()
		{
			List<SanPham_Sl> listSP = await phieunhap_dal.tksanpham();
			return listSP;
		}

		public async Task<List<SanPham_Sl>> getSP_SL_max()
		{
			List<SanPham_Sl> listSP = await phieunhap_dal.tksanpham_max();
			return listSP;
		}

		public async Task<List<SanPham_Sl>> getSP_SL_min()
		{
			List<SanPham_Sl> listSP = await phieunhap_dal.tksanpham_min();
			return listSP;
		}

		public async Task<List<SanPham_banchay>> spbanchay()
		{
			List<SanPham_banchay> listsp = await phieunhap_dal.sanphambanchay();
			return listsp;
		}

	}
}
