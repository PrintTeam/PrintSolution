using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;

namespace TP.Service.TaxRateCategory {
    public class TaxRateCategoryService:ITaxRateCategoryService {

        private readonly ITaxRateCategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TaxRateCategoryService(ITaxRateCategoryRepository repository, IUnitOfWork unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
    }
}
