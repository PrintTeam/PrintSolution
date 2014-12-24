using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Company
{

    /// <summary>
    /// 公司信息业务服务对象
    /// </summary>
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }
        public ORG_Company GetCompanyById(int companyId)
        {
            return _companyRepository.GetById(companyId);
        }



        public ORG_Company GetCompany()
        {
            return _companyRepository.Table.SingleOrDefault();
        }

        public void InsertCompany(ORG_Company company)
        {
            if (company == null)
                throw new ArgumentNullException("Insert ORG_Company entity is Null");

            try
            {
                _companyRepository.Add(company);
                _unitOfWork.Commint();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateCompany(ORG_Company company)
        {
            if (company == null)
                throw new ArgumentNullException("Update ORG_Company entity is Null");
            try
            {

                _companyRepository.Update(company);
                _unitOfWork.Commint();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}

