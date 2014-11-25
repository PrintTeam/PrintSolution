using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;
using TP.Core.Repository;
using TP.EntityFramework.Models;
using TP.EntityFramework;



namespace TP.Repository.Base
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private TinkPrintContext dataContext;
        private IDbSet<T> dbSet;
        /// <summary>
        /// 获取实体
        /// </summary>
        public IQueryable<T> Table
        {
            get { return Entities; }
        }

        protected IDbSet<T> Entities
        {
            get
            {
                return dbSet;
            }
        }

        public BaseRepository(IDataBaseFactory dataBaseFactory)
        {
            DatabaseFactory = dataBaseFactory;
            dbSet = DataContext.Set<T>();
            
        }

        protected IDataBaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected TinkPrintContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.GetDataBase()); }
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">entity</param>
        public void Add(T entity)
        {
        
            if (entity == null)
                throw new ArgumentNullException("Insert entity is null");
            dbSet.Add(entity);
        }

       
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">entity</param>
        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Update entity is null");
            dbSet.Attach(entity);
            this.DataContext.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        ///  删除实体 
        /// </summary>
        /// <param name="entity">entity</param>
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Delete entity is null");
            dbSet.Remove(entity);
          
        }

        /// <summary>
        ///  逻辑删除实体 
        /// </summary>
        /// <param name="entity">entity</param>
        public void LogicalDelete(T entity) 
        {
            if (entity == null)
                throw new ArgumentNullException("Update entity is null");
            Update(entity);
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>T</returns>
        public T GetById(object Id)
        {

            return dbSet.Find(Id);
        }
        /// <summary>
        /// 根据查询过滤条件获取实体
        /// </summary>
        /// <param name="where">查询表达式</param>
        /// <returns>T</returns>
        public T GetEntiny(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }
        /// <summary>
        /// 预加载实体的集合
        /// </summary>
        /// <param name="where">查询表达式</param>
        /// <returns>IQueryable T</returns>
        public IQueryable<T> Preload(Expression<Func<T, bool>> where)
        {

            return dbSet.Include(where);
        }
        /// <summary>
        /// 根据查询过滤条件获取实体集合
        /// </summary>
        /// <param name="where">查询表达式</param>
        /// <returns>IQueryableT</returns>
        public IQueryable<T> Filter(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }

        public void ExecuteSql(string sql, params object[] parameters)
        {
            this.dataContext.Database.ExecuteSqlCommand(sql, parameters);
            this.DataContext.SaveChanges();
           
        }

        public IEnumerable<T> SearchBySql(string sql, params object[] parameters) 
        {
            return this.dataContext.Database.SqlQuery<T>(sql, parameters).AsEnumerable<T>();
        }

    }
}
