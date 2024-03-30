using QL_NoiThat.DAL;
using QL_NoiThat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace QL_NoiThat.BUS
{
    public class NhaCungCap_BUS
    {
        NhaCungCap_DAL ncc_dal;
        public NhaCungCap_BUS()
        {
            ncc_dal = new NhaCungCap_DAL();
        }
        public async Task<List<NhaCungCap_M>> getNhaCungCap()
        {
            List<NhaCungCap_M> listNCC = await ncc_dal.GetNhaCungCap();
            return listNCC;
        }
        public async Task<List<NhaCungCap_M>> AddNhaCungCap(NhaCungCap_M nhaCungCap)
        {
            List<NhaCungCap_M> updatedList = await ncc_dal.PostNhaCungCap(nhaCungCap);
            return updatedList;
        }

        public async Task<bool> UpdateNhaCungCapAsync(int maNCC, NhaCungCap_M nhaCungCap)
        {
            return await ncc_dal.UpdateNhaCungCap(maNCC, nhaCungCap);
        }

        public async Task<bool> DeleteNhaCungCap(string maNCC)
        {    
               return   await ncc_dal.DeleteNhaCungCap(maNCC);
        }

       

    }
}
