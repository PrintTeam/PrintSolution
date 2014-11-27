using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Unit {
    public class UnitService:IUnitService {

        private readonly IUnitRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UnitService(IUnitRepository repository, IUnitOfWork unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public SYS_Unit GetUnit(int unitID) {
            return _repository.GetById(unitID);
        }

        public List<SYS_Unit> GetUnits() {
            return _repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<SYS_Unit> GetUnits(int pageIndex, int pageSize, string searchKey = null) {
            var q = _repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<SYS_Unit> result = q.ToPagedList<SYS_Unit>(pageIndex, pageSize);
            return result;
        }

        public void InsertUnit(SYS_Unit unit) {
            if (unit == null) throw new ArgumentNullException("计量单位实体不能为null值");
            unit.IsDelete = false;
            unit.ModifiedDate = DateTime.Now.ToLocalTime();
            _repository.Add(unit);
            _unitOfWork.Commint();
        }

        public void UpdateUnit(SYS_Unit unit) {
            if (unit == null) throw new ArgumentNullException("计量单位实体不能为null值");           
            unit.ModifiedDate = DateTime.Now.ToLocalTime();
            _repository.Update(unit);
            _unitOfWork.Commint();
        }

        public void DeleteUnit(SYS_Unit unit) {
            if (unit == null) throw new ArgumentNullException("计量单位实体不能为null值");
            unit.IsDelete = true;
            unit.ModifiedDate = DateTime.Now.ToLocalTime();
            _repository.Update(unit);
            _unitOfWork.Commint();
        }
    }
}
