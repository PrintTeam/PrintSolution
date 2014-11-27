using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;

namespace TP.Service.Unit {
    public class UnitService:IUnitService {

        private readonly IUnitRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UnitService(IUnitRepository repository, IUnitOfWork unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
    }
}
