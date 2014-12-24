using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Organization
{


    /// <summary>
    /// 公司信息
    /// </summary>
    public class CompanyModel : BaseViewModel
    {

        public CompanyModel()
        {
        }

        [Required(ErrorMessage = "请输入公司的名称")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "请输入公司负责人信息")]
        [Display(Name = "负责人")]
        public string ResponsiblePerson
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入公司的地址信息")]
        [StringLength(255)]
        [Display(Name = "地址")]
        public string Address
        {
            get;
            set;
        }

        [Display(Name = "传真")]
        public string FaxNumber
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请输入公司的联系方式")]
        [StringLength(20)]
        public string Telephone { get; set; }

    }


    public class CompanyListModel : BaseListViewModel<ORG_Company>
    {

    }
}

