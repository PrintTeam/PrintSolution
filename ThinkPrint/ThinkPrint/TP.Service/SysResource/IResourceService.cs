using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.SysResource
{
    public interface IResourceService
    {
        /// <summary>
        /// 获取系统参数信息
        /// </summary>
        /// <returns></returns>
        IList<SYS_SysSetting> GetSysSettingList();

        /// <summary>
        /// 分页获取系统参数信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="searchKey">可选,名称</param>
        /// <returns>PagedList SYS_SysSetting</returns>
        PagedList<SYS_SysSetting> GetSysSettingList(int pageIndex, int pageSize, string searchKey = null);

        /// <summary>
        /// 根据标识编码获取系统参数信息列表
        /// </summary>
        /// <param name="titleCode">标识编码</param>
        /// <returns></returns>
        List<SYS_SysSetting> GetSysSettingList(string titleCode);


        /// <summary>
        /// 获取系统参数信息
        /// </summary>
        /// <param name="uniqueCode"></param>
        /// <returns>SYS_SysSetting</returns>
        SYS_SysSetting GetSysSettingByCode(string uniqueCode);

        /// <summary>
        /// 检查系统参数信息编码唯一性
        /// </summary>
        /// <param name="uniqueCode"></param>
        /// <returns></returns>
        SYS_SysSetting CheckExistSysSettingByCode(string uniqueCode);

        /// <summary>
        /// 添加系统参数信息
        /// </summary>
        /// <param name="sysSetting">sysSetting</param>
        void InsertSysSetting(SYS_SysSetting sysSetting);

        /// <summary>
        /// 编辑系统参数信息
        /// </summary>
        /// <param name="sysSetting">sysSetting</param>
        void UpdateSysSetting(SYS_SysSetting sysSetting);

        /// <summary>
        /// 删除系统参数信息
        /// </summary>
        /// <param name="sysSetting"></param>
        void DeleteSysSetting(SYS_SysSetting sysSetting);
    }
}
