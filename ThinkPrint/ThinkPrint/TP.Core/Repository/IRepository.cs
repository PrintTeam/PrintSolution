using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TP.Core.Repository
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">entity</param>
        void Add(T entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">entity</param>
        void Update(T entity);

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="entity">entity</param>
        void ExecuteSql(string sql, params object[] parameters);
        /// <summary>
        ///  删除实体 
        /// </summary>
        /// <param name="entity">entity</param>
        void Delete(T entity);

        /// <summary>
        ///  逻辑删除实体 
        /// </summary>
        /// <param name="entity">entity</param>
        void LogicalDelete(T entity); 

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>T</returns>
        T GetById(object Id);

        /// <summary>
        /// 根据查询过滤条件获取实体
        /// </summary>
        /// <param name="where">查询表达式</param>
        /// <returns>T</returns>
        T GetEntiny(Expression<Func<T, bool>> where);

        /// <summary>
        /// 根据查询过滤条件获取实体集合
        /// </summary>
        /// <param name="where">查询表达式</param>
        /// <returns>IQueryable T</returns>
        IQueryable<T> Filter(Expression<Func<T, bool>> where);

        /// <summary>
        /// 预加载实体的集合
        /// </summary>
        /// <param name="where">查询表达式</param>
        /// <returns>IQueryable T</returns>
        IQueryable<T> Preload(Expression<Func<T, bool>> where);

        /// <summary>
        /// 获取实体
        /// </summary>
        IQueryable<T> Table { get; }

        IEnumerable<T> SearchBySql(string sql, params object[] parameters);

    }
}
