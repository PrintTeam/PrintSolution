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
        private readonly IBusinessCategoryRepository _businessCategoryRepository;
       
        private readonly IUnitOfWork _unitOfWork;

        public BusinessCategoryService(IBusinessCategoryRepository businessCategoryRepository, IUnitOfWork unitOfWork)
        {
            _businessCategoryRepository = businessCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public void InsertBusinessCategory(BUS_BusinessCategory businessCategory)
        {
            if (businessCategory == null)
                throw new ArgumentNullException("业务类型实体不能为null值");

            try
            {
                _businessCategoryRepository.Add(businessCategory);
                _unitOfWork.Commint();
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
                _businessCategoryRepository.Update(businessCategory);
                _unitOfWork.Commint();
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
                _businessCategoryRepository.Update(businessCategory);
                _unitOfWork.Commint();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public IList<BUS_BusinessCategory> GetBusinessCategoryList()
        {
            var query = _businessCategoryRepository.Table.Where(u => u.IsDelete == false);
            IList<BUS_BusinessCategory> businessCategoryList = query.OrderByDescending(u => u.ModifiedDate).ToList();
            return businessCategoryList;
        }

        public PagedList<BUS_BusinessCategory> GetBusinessCategoryList(int pageIndex, int pageSize, string searchKey = null)
        {
            var query = _businessCategoryRepository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                query = query.Where(u => u.Name.Contains(searchKey));
            }

            query = query.OrderByDescending(u => u.ModifiedDate);

            PagedList<BUS_BusinessCategory> businessCategoryList = query.ToPagedList(pageIndex, pageSize);
            return businessCategoryList;
        }

        public BUS_BusinessCategory GetBusinessCategoryById(int businessCategoryId)
        {
            return _businessCategoryRepository.GetById(businessCategoryId);
        }

        public BUS_BusinessCategory CheckExistBusinessCategoryByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;
            var query = _businessCategoryRepository.Filter(u => u.Name == name).FirstOrDefault();
            return query;
        }

        public BUS_BusinessCategory CheckExistBusinessCategoryByName(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;
            var query = _businessCategoryRepository.Filter(u => u.BusinessCategoryId != id && u.Name == name).FirstOrDefault();
            return query;
        }
    }
}

