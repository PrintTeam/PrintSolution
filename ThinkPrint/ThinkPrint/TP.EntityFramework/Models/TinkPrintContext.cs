using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TP.EntityFramework.Models.Mapping;

namespace TP.EntityFramework.Models
{
    public partial class TinkPrintContext : DbContext
    {
        static TinkPrintContext()
        {
            Database.SetInitializer<TinkPrintContext>(null);
        }

        public TinkPrintContext()
            : base("Name=TinkPrintContext")
        {
        }

        public DbSet<AUT_Role> AUT_Role { get; set; }
        public DbSet<AUT_RoleMenuFunction> AUT_RoleMenuFunction { get; set; }
        public DbSet<AUT_RoleModule> AUT_RoleModule { get; set; }
        public DbSet<AUT_RoleModuleMenu> AUT_RoleModuleMenu { get; set; }
        public DbSet<AUT_User> AUT_User { get; set; }
        public DbSet<AUT_UserRole> AUT_UserRole { get; set; }
        public DbSet<BOM_Paper> BOM_Paper { get; set; }
        public DbSet<BOM_PaperCategory> BOM_PaperCategory { get; set; }
        public DbSet<BOM_PaperSize> BOM_PaperSize { get; set; }
        public DbSet<BPM_PostpressAgreementPriceList> BPM_PostpressAgreementPriceList { get; set; }
        public DbSet<BPM_PostpressSalePriceList> BPM_PostpressSalePriceList { get; set; }
        public DbSet<BPM_PrintingAgreementPriceList> BPM_PrintingAgreementPriceList { get; set; }
        public DbSet<BPM_PrintingMembershipPriceList> BPM_PrintingMembershipPriceList { get; set; }
        public DbSet<BPM_PrintingPriceRangeList> BPM_PrintingPriceRangeList { get; set; }
        public DbSet<BPM_PrintingSalePriceList> BPM_PrintingSalePriceList { get; set; }
        public DbSet<BUS_BusinessCategory> BUS_BusinessCategory { get; set; }
        public DbSet<BUS_BusinessComponent> BUS_BusinessComponent { get; set; }
        public DbSet<CRM__PostRegisterCard> CRM__PostRegisterCard { get; set; }
        public DbSet<CRM_CardConsumption> CRM_CardConsumption { get; set; }
        public DbSet<CRM_CardDictionary> CRM_CardDictionary { get; set; }
        public DbSet<CRM_CardRecharge> CRM_CardRecharge { get; set; }
        public DbSet<CRM_MembershipCard> CRM_MembershipCard { get; set; }
        public DbSet<CRM_MembershipCardCategory> CRM_MembershipCardCategory { get; set; }
        public DbSet<CRM_MembershipFreeze> CRM_MembershipFreeze { get; set; }
        public DbSet<CRM_MembershipUnfreeze> CRM_MembershipUnfreeze { get; set; }
        public DbSet<ORG_AuthorizeUserStore> ORG_AuthorizeUserStore { get; set; }
        public DbSet<ORG_Company> ORG_Company { get; set; }
        public DbSet<ORG_Department> ORG_Department { get; set; }
        public DbSet<ORG_Employee> ORG_Employee { get; set; }
        public DbSet<ORG_EmployeeDepartmentHistory> ORG_EmployeeDepartmentHistory { get; set; }
        public DbSet<ORG_Shift> ORG_Shift { get; set; }
        public DbSet<ORG_Store> ORG_Store { get; set; }
        public DbSet<PMW_Machine> PMW_Machine { get; set; }
        public DbSet<PMW_MachineCategory> PMW_MachineCategory { get; set; }
        public DbSet<PMW_PostpressMembershipPriceList> PMW_PostpressMembershipPriceList { get; set; }
        public DbSet<PMW_PostpressPriceRangeList> PMW_PostpressPriceRangeList { get; set; }
        public DbSet<PMW_PostpressProcess> PMW_PostpressProcess { get; set; }
        public DbSet<PMW_PrintingProcess> PMW_PrintingProcess { get; set; }
        public DbSet<PMW_ProcessRequirement> PMW_ProcessRequirement { get; set; }
        public DbSet<SAL_Customer> SAL_Customer { get; set; }
        public DbSet<SAL_Order> SAL_Order { get; set; }
        public DbSet<SAL_WorkProject> SAL_WorkProject { get; set; }
        public DbSet<SAL_WorkProjectDetail> SAL_WorkProjectDetail { get; set; }
        public DbSet<SYS_Function> SYS_Function { get; set; }
        public DbSet<SYS_Industry> SYS_Industry { get; set; }
        public DbSet<SYS_Menu> SYS_Menu { get; set; }
        public DbSet<SYS_MenuFunction> SYS_MenuFunction { get; set; }
        public DbSet<SYS_Module> SYS_Module { get; set; }
        public DbSet<SYS_OrderRemindSetting> SYS_OrderRemindSetting { get; set; }
        public DbSet<SYS_PrepaymentsSetting> SYS_PrepaymentsSetting { get; set; }
        public DbSet<SYS_SysSetting> SYS_SysSetting { get; set; }
        public DbSet<SYS_TaxRateCategory> SYS_TaxRateCategory { get; set; }
        public DbSet<SYS_Unit> SYS_Unit { get; set; }
        public DbSet<SYS_VoucherData> SYS_VoucherData { get; set; }
        public DbSet<SYS_VoucherEncodingRule> SYS_VoucherEncodingRule { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AUT_RoleMap());
            modelBuilder.Configurations.Add(new AUT_RoleMenuFunctionMap());
            modelBuilder.Configurations.Add(new AUT_RoleModuleMap());
            modelBuilder.Configurations.Add(new AUT_RoleModuleMenuMap());
            modelBuilder.Configurations.Add(new AUT_UserMap());
            modelBuilder.Configurations.Add(new AUT_UserRoleMap());
            modelBuilder.Configurations.Add(new BOM_PaperMap());
            modelBuilder.Configurations.Add(new BOM_PaperCategoryMap());
            modelBuilder.Configurations.Add(new BOM_PaperSizeMap());
            modelBuilder.Configurations.Add(new BPM_PostpressAgreementPriceListMap());
            modelBuilder.Configurations.Add(new BPM_PostpressSalePriceListMap());
            modelBuilder.Configurations.Add(new BPM_PrintingAgreementPriceListMap());
            modelBuilder.Configurations.Add(new BPM_PrintingMembershipPriceListMap());
            modelBuilder.Configurations.Add(new BPM_PrintingPriceRangeListMap());
            modelBuilder.Configurations.Add(new BPM_PrintingSalePriceListMap());
            modelBuilder.Configurations.Add(new BUS_BusinessCategoryMap());
            modelBuilder.Configurations.Add(new BUS_BusinessComponentMap());
            modelBuilder.Configurations.Add(new CRM__PostRegisterCardMap());
            modelBuilder.Configurations.Add(new CRM_CardConsumptionMap());
            modelBuilder.Configurations.Add(new CRM_CardDictionaryMap());
            modelBuilder.Configurations.Add(new CRM_CardRechargeMap());
            modelBuilder.Configurations.Add(new CRM_MembershipCardMap());
            modelBuilder.Configurations.Add(new CRM_MembershipCardCategoryMap());
            modelBuilder.Configurations.Add(new CRM_MembershipFreezeMap());
            modelBuilder.Configurations.Add(new CRM_MembershipUnfreezeMap());
            modelBuilder.Configurations.Add(new ORG_AuthorizeUserStoreMap());
            modelBuilder.Configurations.Add(new ORG_CompanyMap());
            modelBuilder.Configurations.Add(new ORG_DepartmentMap());
            modelBuilder.Configurations.Add(new ORG_EmployeeMap());
            modelBuilder.Configurations.Add(new ORG_EmployeeDepartmentHistoryMap());
            modelBuilder.Configurations.Add(new ORG_ShiftMap());
            modelBuilder.Configurations.Add(new ORG_StoreMap());
            modelBuilder.Configurations.Add(new PMW_MachineMap());
            modelBuilder.Configurations.Add(new PMW_MachineCategoryMap());
            modelBuilder.Configurations.Add(new PMW_PostpressMembershipPriceListMap());
            modelBuilder.Configurations.Add(new PMW_PostpressPriceRangeListMap());
            modelBuilder.Configurations.Add(new PMW_PostpressProcessMap());
            modelBuilder.Configurations.Add(new PMW_PrintingProcessMap());
            modelBuilder.Configurations.Add(new PMW_ProcessRequirementMap());
            modelBuilder.Configurations.Add(new SAL_CustomerMap());
            modelBuilder.Configurations.Add(new SAL_OrderMap());
            modelBuilder.Configurations.Add(new SAL_WorkProjectMap());
            modelBuilder.Configurations.Add(new SAL_WorkProjectDetailMap());
            modelBuilder.Configurations.Add(new SYS_FunctionMap());
            modelBuilder.Configurations.Add(new SYS_IndustryMap());
            modelBuilder.Configurations.Add(new SYS_MenuMap());
            modelBuilder.Configurations.Add(new SYS_MenuFunctionMap());
            modelBuilder.Configurations.Add(new SYS_ModuleMap());
            modelBuilder.Configurations.Add(new SYS_OrderRemindSettingMap());
            modelBuilder.Configurations.Add(new SYS_PrepaymentsSettingMap());
            modelBuilder.Configurations.Add(new SYS_SysSettingMap());
            modelBuilder.Configurations.Add(new SYS_TaxRateCategoryMap());
            modelBuilder.Configurations.Add(new SYS_UnitMap());
            modelBuilder.Configurations.Add(new SYS_VoucherDataMap());
            modelBuilder.Configurations.Add(new SYS_VoucherEncodingRuleMap());
        }
    }
}
