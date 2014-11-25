
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.User
{
    public interface IUserService
    {
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="userNameOrEmail">名称或邮箱</param>
        /// <param name="password">密码</param>
        /// <returns>ORG_LoginUser</returns>
        AUT_User ValidateUser(string userNameOrEmail, string password);

        /// <summary>
        /// 根据用户名称获取用户信息
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <returns>ORG_LoginUser</returns>
        AUT_User GetUserByUserName(string userName);

        /// <summary>
        ///  根据用户Id获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        AUT_User GetUserById(int userId);

        /// <summary>
        /// 分页获取模块信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="searchKey">可选,名称</param>
        /// <returns>PagedList BAS_Unit</returns>
        PagedList<AUT_User> GetUserList(int pageIndex, int pageSize, string searchKey = null);

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="user">AUT_User</param>
        void InsertUser(AUT_User user);

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="user">AUT_User</param>
        void UpdateUser(AUT_User user);

        /// <summary>
        /// 删除模块信息
        /// </summary>
        /// <param name="user"></param>
        void DeleteUser(AUT_User user);

        /// <summary>
        /// 检查用户信息唯一性
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        AUT_User CheckExistUserByName(string userName);

        /// <summary>
        /// 检查用户信息唯一性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <returns>AUT_User</returns>
        AUT_User CheckExistUserByName(int id, string userName);


        AUT_UserRole GetUserRole(int userId, int roleId);

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="userRole">AUT_LoginUser</param>
        void InsertUserRole(AUT_UserRole userRole);

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="userRole">AUT_LoginUser</param>
        void UpdateUserRole(AUT_UserRole userRole);

        /// <summary>
        /// 删除模块信息
        /// </summary>
        /// <param name="userRole"></param>
        void RemoveUserRole(AUT_UserRole userRole);

        
    }
}
