using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.VoucherData {

    /// <summary>
    /// 单据数据业务服务对象
    /// </summary>
    public class VoucherDataService:IVoucherDataService {
        private readonly IVoucherDataRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public VoucherDataService(IVoucherDataRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public SYS_VoucherData GetVoucherData(int  VoucherDataId) {
            return m_Repository.GetById(VoucherDataId);
        }

        public List<SYS_VoucherData> GetVoucherDatas() {
            return m_Repository.Table.ToList();
        }

        public PagedList<SYS_VoucherData> GetVoucherDatas(int pageIndex, int pageSize) {           
            var q = m_Repository.Table.OrderByDescending(p => p.ModifiedDate);
            PagedList<SYS_VoucherData> result = q.ToPagedList<SYS_VoucherData>(pageIndex, pageSize);
            return result;
        }

        public void InsertVoucherData(SYS_VoucherData VoucherData) {
            if (VoucherData == null) throw new ArgumentNullException("单据数据实体不能为null值");          
            VoucherData.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(VoucherData);
            m_UnitOfWork.Commint();
        }

        public void UpdateVoucherData(SYS_VoucherData VoucherData) {
            if (VoucherData == null) throw new ArgumentNullException("单据数据实体不能为null值");           
            VoucherData.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(VoucherData);
            m_UnitOfWork.Commint();
        }

        public void DeleteVoucherData(SYS_VoucherData VoucherData) {
            if (VoucherData == null) throw new ArgumentNullException("单据数据实体不能为null值");           
            VoucherData.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(VoucherData);
            m_UnitOfWork.Commint();
        }    
    }
}

