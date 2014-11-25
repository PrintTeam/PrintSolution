using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Store {
    interface IStoreService {
        /// <summary>
        /// 根据提供的店铺编码返回店铺实体
        /// </summary>
        /// <param name="StoreID">店铺编码</param>
        /// <returns>店铺实体</returns>
        ORG_Store GetStore(int StoreID);
        /// <summary>
        /// 按分页方式返回店铺实体列表
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="searchKey">检索条件</param>
        /// <returns>店铺实体列表</returns>
        PagedList<ORG_Store> GetStoreList(int pageIndex, int pageSize, string searchKey = null);
        /// <summary>
        /// 新增店铺
        /// </summary>
        /// <param name="store">店铺实体</param>
        void InsertStore(ORG_Store store);
        /// <summary>
        /// 更新店铺信息
        /// </summary>
        /// <param name="store">店铺实体</param>
        void UpdateStore(ORG_Store store);
        /// <summary>
        /// 逻辑删除店铺信息
        /// </summary>
        /// <param name="store">店铺实体</param>
        void DeleteStore(ORG_Store store);
    }
}
