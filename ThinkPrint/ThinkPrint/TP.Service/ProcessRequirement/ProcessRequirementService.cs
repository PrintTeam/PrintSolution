using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.ProcessRequirement {

    /// <summary>
    /// 制作要求业务服务对象
    /// </summary>
    public class ProcessRequirementService:IProcessRequirementService {
        private readonly IProcessRequirementRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public ProcessRequirementService(IProcessRequirementRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public PMW_ProcessRequirement GetProcessRequirement(int  ProcessRequirementId) {
            return m_Repository.GetById(ProcessRequirementId);
        }

        public List<PMW_ProcessRequirement> GetProcessRequirements() {
            return m_Repository.Table.ToList();
        }

        public PagedList<PMW_ProcessRequirement> GetProcessRequirements(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<PMW_ProcessRequirement> result = q.ToPagedList<PMW_ProcessRequirement>(pageIndex, pageSize);
            return result;
        }

        public void InsertProcessRequirement(PMW_ProcessRequirement ProcessRequirement) {
            if (ProcessRequirement == null) throw new ArgumentNullException("制作要求实体不能为null值");          
            ProcessRequirement.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(ProcessRequirement);
            m_UnitOfWork.Commint();
        }

        public void UpdateProcessRequirement(PMW_ProcessRequirement ProcessRequirement) {
            if (ProcessRequirement == null) throw new ArgumentNullException("制作要求实体不能为null值");           
            ProcessRequirement.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(ProcessRequirement);
            m_UnitOfWork.Commint();
        }

        public void DeleteProcessRequirement(PMW_ProcessRequirement ProcessRequirement) {
            if (ProcessRequirement == null) throw new ArgumentNullException("制作要求实体不能为null值");          
            ProcessRequirement.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(ProcessRequirement);
            m_UnitOfWork.Commint();
        }    
    }
}

