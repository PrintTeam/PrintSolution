using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.BusinessCategory
{

    /// <summary>
    /// 业务类型业务服务对象
    /// </summary>
    public class BusinessCategoryService : IBusinessCategoryService
    {
        private readonly IBusinessCategoryRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public BusinessCategoryService(IBusinessCategoryRepository repository, IUnitOfWork unitOfWork)
        {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public void InsertBusinessCategory(BUS_BusinessCategory businessCategory)
        {
            if (businessCategory == null)
                throw new ArgumentNullException("业务类型实体不能为null值");

            try
            {
                m_Repository.Add(businessCategory);
                m_UnitOfWork.Commint();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void UpdateBusinessCategory(BUS_BusinessCategory businessCategory)
        {
            if (businessCategory == null)
                throw new ArgumentNullException("业务类型实体不能为null值");

            try
            {
                m_Repository.Update(businessCategory);
                m_UnitOfWork.Commint();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteBusinessCategory(BUS_BusinessCategory businessCategory)
        {
            if (businessCategory == null)
                throw new ArgumentNullException("业务类型实体不能为null值");

            try
            {
                businessCategory.IsDelete = true;
                businessCategory.ModifiedDate = DateTime.Now.ToLocalTime();
                m_Repository.Update(businessCategory);
                m_UnitOfWork.Commint();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public IList<BUS_BusinessCategory> GetBusinessCategoryList()
        {
            throw new NotImplementedException();
        }

        public PagedList<BUS_BusinessCategory> GetBusinessCategoryList(int pageIndex, int pageSize, string searchKey = null)
        {
            throw new NotImplementedException();
        }

        public BUS_BusinessCategory GetBusinessCategory(int businessCategoryId)
        {
            throw new NotImplementedException();
        }

        public BUS_BusinessCategory CheckExistBusinessCategoryByName(string name)
        {
            throw new NotImplementedException();
        }

        public BUS_BusinessCategory CheckExistBusinessCategoryByName(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}

