using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.BusinessCategory
{

    public interface IBusinessCategoryService
    {

        /// <summary>
        /// 获取所有的业务类型
        /// </summary>
        /// <returns></returns>
        IList<BUS_BusinessCategory> GetBusinessCategoryList();

        /// <summary>
        /// 分页业务类型信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="searchKey">可选,名称</param>
        /// <returns>PagedList BUS_BusinessCategory</returns>
        PagedList<BUS_BusinessCategory> GetBusinessCategoryList(int pageIndex, int pageSize, string searchKey = null);


        /// <summary>
        /// 获取业务类型信息
        /// </summary>
        /// <param name="businessCategoryId"></param>
        /// <returns>BUS_BusinessCategory</returns>
        BUS_BusinessCategory GetBusinessCategory(int businessCategoryId);


        /// <summary>
        ///  检查业务类型信息名称唯一性
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>BUS_BusinessCategory</returns>
        BUS_BusinessCategory CheckExistBusinessCategoryByName(string name);

        /// <summary>
        /// 检查业务类型信息名称唯一性
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">名称</param>
        /// <returns>BUS_BusinessCategory</returns>
        BUS_BusinessCategory CheckExistBusinessCategoryByName(int id, string name);



        void InsertBusinessCategory(BUS_BusinessCategory businessCategory);

        void UpdateBusinessCategory(BUS_BusinessCategory businessCategory);

        void DeleteBusinessCategory(BUS_BusinessCategory businessCategory);
    }
}

