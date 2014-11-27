using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.TaxRateCategory {
    public class TaxRateCategoryService : ITaxRateCategoryService {

        private readonly ITaxRateCategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TaxRateCategoryService(ITaxRateCategoryRepository repository, IUnitOfWork unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public SYS_TaxRateCategory GetTaxRateCategory(int categoryID) {
            return _repository.GetById(categoryID);
        }

        public List<SYS_TaxRateCategory> GetTaxRateCategorys() {
            return _repository.Table.Where(u => u.IsDelete == false).ToList();
        }

        public PagedList<SYS_TaxRateCategory> GetTaxRateCategorys(int pageIndex, int pageSize, string searchKey = null) {
            var q = _repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<SYS_TaxRateCategory> result = q.ToPagedList<SYS_TaxRateCategory>(pageIndex, pageSize);
            return result;
        }

        public void InsertTaxRateCategory(SYS_TaxRateCategory category) {
            if (category == null)throw new ArgumentNullException("税率分类实体不能为null值");            
            category.IsDelete = false;
            category.ModifiedDate = DateTime.Now.ToLocalTime();
            _repository.Add(category);
            _unitOfWork.Commint();
        }

        public void UpdateTaxRateCategory(SYS_TaxRateCategory category) {
            if (category == null) throw new ArgumentNullException("税率分类实体不能为null值");           
            category.ModifiedDate = DateTime.Now.ToLocalTime();
            _repository.Update(category);
            _unitOfWork.Commint();
        }

        public void DeleteTaxRateCategory(SYS_TaxRateCategory category) {
            if (category == null) throw new ArgumentNullException("税率分类实体不能为null值");
            category.IsDelete = true;
            category.ModifiedDate = DateTime.Now.ToLocalTime();
            _repository.Update(category);
            _unitOfWork.Commint();
        }
    }
}
