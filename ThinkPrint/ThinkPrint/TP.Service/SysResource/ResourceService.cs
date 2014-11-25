using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.EntityFramework.Models;
using TP.Repository;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.SysResource
{
    public class ResourceService : IResourceService
    {
         private readonly ISysSettingRepository _sysSettingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ResourceService(ISysSettingRepository sysSettingRepository, IUnitOfWork unitOfWork)
        {
            _sysSettingRepository = sysSettingRepository;
            _unitOfWork = unitOfWork;

        }

        public IList<SYS_SysSetting> GetSysSettingList()
        {
            var query = _sysSettingRepository.Table;
            IList<SYS_SysSetting> sysSettingList = query.OrderByDescending(u => u.ModifiedDate).ToList();
            return sysSettingList;
        }

        public PagedList<SYS_SysSetting> GetSysSettingList(int pageIndex, int pageSize, string searchKey = null)
        {
            var query = _sysSettingRepository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                query = query.Where(u => u.Name.Contains(searchKey) || u.Title.Contains(searchKey));
            }

            query = query.OrderByDescending(u => u.ModifiedDate);

            PagedList<SYS_SysSetting> sysSettingList = query.ToPagedList(pageIndex, pageSize);
            return sysSettingList;
        }

        public List<SYS_SysSetting> GetSysSettingList(string titleCode)
        {
            var query = _sysSettingRepository.Filter(s => s.TitleCode == titleCode).ToList();
            return query;
        }

        public SYS_SysSetting GetSysSettingByCode(string uniqueCode)
        {
            if (string.IsNullOrWhiteSpace(uniqueCode))
                throw new ArgumentNullException("Get UniqueCode is Null");
            var query = _sysSettingRepository.Filter(u => u.UniqueCode == uniqueCode).SingleOrDefault();
            return query;
        }

        public SYS_SysSetting CheckExistSysSettingByCode(string uniqueCode)
        {
            if (string.IsNullOrWhiteSpace(uniqueCode))
                throw new ArgumentNullException("Check UniqueCode is Null");
            var query = _sysSettingRepository.Filter(u => u.UniqueCode == uniqueCode).FirstOrDefault();
            return query;
        }

        public void InsertSysSetting(SYS_SysSetting sysSetting)
        {
            if (sysSetting == null)
                throw new ArgumentNullException("Insert SYS_SysSetting Entity Is Null");

            try
            {
                _sysSettingRepository.Add(sysSetting);
                _unitOfWork.Commint();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateSysSetting(SYS_SysSetting sysSetting)
        {
            if (sysSetting == null)
                throw new ArgumentNullException("Update SYS_SysSetting Entity Is Null");
            try
            {

                _sysSettingRepository.Update(sysSetting);
                _unitOfWork.Commint();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteSysSetting(SYS_SysSetting sysSetting)
        {
            if (sysSetting == null)
                throw new ArgumentNullException("Delete SYS_SysSetting Entity is Null");
            try
            {
                sysSetting.IsDelete = true;
                UpdateSysSetting(sysSetting);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
