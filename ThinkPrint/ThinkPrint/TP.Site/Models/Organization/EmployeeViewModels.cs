﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Web.Framework.Mvc;

namespace TP.Site.Models.Organization
{
    public class EmployeeModel : BaseViewModel
    {

        public EmployeeModel()
        {
            StatusList = new List<SYS_SysSetting>();
            DepartmentList = new List<SelectListItem>();
            StoreList = new List<SelectListItem>();
            ManagerList = new List<SelectListItem>();
        }

        [Required(ErrorMessage = "请输入员工名称")]
        [StringLength(20, ErrorMessage = "员工名称过长.")]
        [Display(Name = "员工名称")]
        public string Name { get; set; }

        public string CurrentDepartment { get; set; }
        public int CurrentDepartmentId { get; set; }

        public string CurrentStrore { get; set; }
        public int CurrentStroreId { get; set; }


        public int ManagerId { get; set; }
        public string ManagerName { get; set; }

        [Required(ErrorMessage = "请输入员工工号")]
        [StringLength(20, ErrorMessage = "员工工号过长.")]
        [Display(Name = "员工工号")]
        public string JobNumber { get; set; }

        [Required(ErrorMessage = "请输入证件号码")]
        [StringLength(50, ErrorMessage = "证件号码过长.")]
        [Display(Name = "证件号码")]
        public string CredentialsNum { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "请选择性别")]
        public bool Sex { get; set; }

        [Required(ErrorMessage = "请输入年龄")]
        [Display(Name = "年龄")]
        public int Age { get; set; }

        [Required(ErrorMessage = "请输入手机号码")]
        [StringLength(20, ErrorMessage = "手机号码过长.")]
        [Display(Name = "手机号码")]
        public string MobilePhone { get; set; }

        public string Status { get; set; }
        public string StatusName { get; set; }

        [Required(ErrorMessage = "请输入入职时间")]
        [Display(Name = "入职时间")]
        public DateTime EntryDate { get; set; }

        public Nullable<DateTime> LeaveDate { get; set; }

        public DateTime ModifiedDate { get; set; }

       
        public IList<SYS_SysSetting> StatusList { get; set; }

        public IList<SelectListItem> DepartmentList { get; set; }

        public IList<SelectListItem> StoreList { get; set; }

        public IList<SelectListItem> ManagerList { get; set; }
    }

    public class EmployeeListModel : BaseListViewModel<ORG_Employee>
    {
        public EmployeeListModel()
        {
            StatusList = new List<SYS_SysSetting>();
        }
        public IList<SYS_SysSetting> StatusList { get; set; }
    }

    public class EmployeeStatusModel : BaseViewModel
    {
        public EmployeeStatusModel()
        {
            StatusList = new List<SelectListItem>();
        }
        public string Name { get; set; }

        public string Status { get; set; }

        public string StatusName { get; set; }

        public Nullable<DateTime> LeaveDate { get; set; }

        public IList<SelectListItem> StatusList { get; set; }
    }
}