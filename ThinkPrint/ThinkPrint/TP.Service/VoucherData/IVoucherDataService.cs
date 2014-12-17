using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.VoucherData {

    public interface IVoucherDataService {
        SYS_VoucherData GetVoucherData(int  VoucherDataId);
        List<SYS_VoucherData> GetVoucherDatas();
        PagedList<SYS_VoucherData> GetVoucherDatas(int pageIndex, int pageSize);
        void InsertVoucherData(SYS_VoucherData VoucherData);
        void UpdateVoucherData(SYS_VoucherData VoucherData);
        void DeleteVoucherData(SYS_VoucherData VoucherData);
    }
}

