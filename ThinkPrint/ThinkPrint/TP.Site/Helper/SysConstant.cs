using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP.Site.Helper
{
    public class SysConstant
    {
        public static readonly int Page_PageSize = 10;
        
        /// <summary>
        /// 员工状态
        /// </summary>
        public static readonly string EmployeeStatus_titleCode = "EMPLOYEESTATUS";
        /// <summary>
        /// 正常
        /// </summary>
        public static readonly string EmployeeStatus_normal = "EMPLOYEESTATUS_NORMAL"; 
        /// <summary>
        /// 离职
        /// </summary>
        public static readonly string EmployeeStatus_leave = "EMPLOYEESTATUS_LEAVE";
        /// <summary>
        /// 借调
        /// </summary>
        public static readonly string EmployeeStatus_seconded = "EMPLOYEESTATUS_SECONDED";

        /// <summary>
        /// 单据类型
        /// </summary>
        public static readonly string BillType_titleCode = "BILLTYPE";
        /// <summary>
        ///  销售订单
        /// </summary>
        public static readonly string BillType_sal = "BILLTYPE_SAL";
        /// <summary>
        ///  付款单
        /// </summary>
        public static readonly string BillType_pay = "BILLTYPE_PAY";
        /// <summary>
        /// 收款单
        /// </summary>
        public static readonly string BillType_rec = "BILLTYPE_REC";
        /// <summary>
        ///  核销单
        /// </summary>
        public static readonly string BillType_ver= "BILLTYPE_VER";

        /// <summary>
        /// 编码方式
        /// </summary>
        public static readonly string CodemodeType_titlecode = "CODEMODETYPE";
        /// <summary>
        /// 流水号
        /// </summary>
        public static readonly string CodemodeType_seq = "CODEMODETYPE_SEQ";
        /// <summary>
        /// 年编号
        /// </summary>
        public static readonly string CodemodeType_yea= "CODEMODETYPE_YEA";
        /// <summary>
        /// 月编号
        /// </summary>
        public static readonly string CodemodeType_mon = "CODEMODETYPE_MON";
        /// <summary>
        /// 日编号
        /// </summary>
        public static readonly string CodemodeType_day = "CODEMODETYPE_DAY";


        /// <summary>
        /// 业务类别
        /// </summary>
        public static readonly string BusinessType_titlecode = "BUSINESSTYPE";
        /// <summary>
        /// 印前
        /// </summary>
        public static readonly string BusinessType_pre = "BUSINESSTYPE_PRE";
        /// <summary>
        /// 印刷
        /// </summary>
        public static readonly string BusinessType_pri = "BUSINESSTYPE_PRI";
        /// <summary>
        /// 后道
        /// </summary>
        public static readonly string BusinessType_fin = "BUSINESSTYPE_FIN";

        /// <summary>
        /// 色彩类别
        /// </summary>
        public static readonly string ColorType_titlecode = "COLORTYPE";
        /// <summary>
        /// 彩色
        /// </summary>
        public static readonly string ColorType_col = "COLORTYPE_COL";
        /// <summary>
        /// 黑白
        /// </summary>
        public static readonly string ColorType_bla = "COLORTYPE_BLA";
        /// <summary>
        /// 其他
        /// </summary>
        public static readonly string ColorType_oth = "COLORTYPE_OTH";

        /// <summary>
        /// 设备类别
        /// </summary>
        public static readonly string MachineType_titlecode = "MACHINETYPE";
        /// <summary>
        /// 印刷设备
        /// </summary>
        public static readonly string MachineType_print = "MACHINETYPE_PRINT";
        /// <summary>
        /// 后加工设备
        /// </summary>
        public static readonly string MachineType_postpress = "MACHINETYPE_POSTPRESS";

        /// <summary>
        /// 面
        /// </summary>
        public static readonly string SideProperty_titlecode = "SIDEPROPERTY";
        /// <summary>
        /// 单面                            
        /// </summary>
        public static readonly string SideProperty_sin = "SIDEPROPERTY_SIN";
        /// <summary>
        /// 双面
        /// </summary>
        public static readonly string SideProperty_dou = "SIDEPROPERTY_DOU";

        /// <summary>
        /// 价格模式
        /// </summary>
        public static readonly string PricingModels_titlecode = "PRICINGMODELS";
        /// <summary>
        /// 普通计价                            
        /// </summary>
        public static readonly string PricingModels_nor = "PRICINGMODELS_NOR";
        /// <summary>
        /// 区间计价
        /// </summary>
        public static readonly string PricingModels_ran = "PRICINGMODELS_RAN";


        /// <summary>
        /// 客户类型
        /// </summary>
        public static readonly string CustomerType_titlecode = "CUSTOMERTYPE";
        /// <summary>
        /// 会员                            
        /// </summary>
        public static readonly string CustomerType_m = "CUSTOMERTYPE_M";
        /// <summary>
        /// 普通
        /// </summary>
        public static readonly string CustomerType_g = "CUSTOMERTYPE_G";
        /// <summary>
        /// 散户
        /// </summary>
        public static readonly string CustomerType_r = "CUSTOMERTYPE_R";

        /// <summary>
        /// 启用的价格类型
        /// </summary>
        public static readonly string SalePriceType_titlecode = "SALEPRICETYPE";
        /// <summary>
        /// 默认价格                            
        /// </summary>
        public static readonly string SalePriceType_dep = "SALEPRICETYPE_DEP";
        /// <summary>
        /// 会员价格
        /// </summary>
        public static readonly string SalePriceType_mep = "SALEPRICETYPE_MEP";
        /// <summary>
        /// 协议价格
        /// </summary>
        public static readonly string SalePriceType_aep = "SALEPRICETYPE_AEP";


        /// <summary>
        /// 证件类型
        /// </summary>
        public static readonly string CredentialsType_titlecode = "CREDENTIALSTYPE";
        /// <summary>
        /// 身份证                            
        /// </summary>
        public static readonly string CredentialsType_idc = "CREDENTIALSTYPE_IDC";
        /// <summary>
        /// 军官证
        /// </summary>
        public static readonly string CredentialsType_aic = "CREDENTIALSTYPE_AIC";


        public static readonly string MenuTypeName_Category = "菜单分类";
        public static readonly string MenuTypeName_Link = "链接";

    }
}