using QL_NoiThat.DAL;
using QL_NoiThat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_NoiThat.BUS
{

    public  class DonHang_BUS
    {
        DonHang_DAL dh_dal;
        public DonHang_BUS()
        {
            dh_dal = new DonHang_DAL();
        }
        public async Task<List<Donhang>> getDonHang()
        {
            List<Donhang> listdh = await dh_dal.GetDonHang();
            return listdh;
        }
        public async Task<List<Donhang>> getDonHangByTT(string tinhTrang)
        {
            List<Donhang> listSP = await dh_dal.GetDonHang_ByTT(tinhTrang);
            return listSP;
        }
        public async Task<List<Donhang>> getByTT(string maDH)
        {
            List<Donhang> listSP = await dh_dal.GetDonHang_BymaDH(maDH);
            return listSP;
        }
        public async Task<List<CTDH>> getChiTietDonHang(string maDH)
        {
            List<CTDH> listdh = await dh_dal.GetCTDH_ByIDMDH(maDH);
            return listdh;
        }
        public async Task<bool> updateTT(int maDH,Donhang tinhTrang)
        {
             return await dh_dal.UpdateTinhTrang(maDH,tinhTrang);
           
        }
       
    }
}
