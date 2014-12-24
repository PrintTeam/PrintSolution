using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Company {

    public interface ICompanyService {

        /// <summary>
        /// 根据公司ID获取公司信息
        /// </summary>
        /// <param name="companyId">公司IDID</param>
        /// <returns>ORG_Company</returns>
        ORG_Company GetCompanyById(int companyId);

        /// <summary>
        /// 根据公司ID获取公司信息
        /// </summary>
        /// <returns>ORG_Company</returns>
        ORG_Company GetCompany();
        /// <summary>
        /// 添加公司信息
        /// </summary>
        /// <param name="company">ORG_Company</param>
        void InsertCompany(ORG_Company company);

        /// <summary>
        /// 编辑公司信息
        /// </summary>
        /// <param name="company">ORG_Company</param>
        void UpdateCompany(ORG_Company company);
    }
}

