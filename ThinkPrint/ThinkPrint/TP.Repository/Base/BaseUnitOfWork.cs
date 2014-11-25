using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP.Core.UnitOfWork;
using TP.EntityFramework;
using TP.EntityFramework.Models;



namespace TP.Repository.Base
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        private readonly IDataBaseFactory _dataBaseFactory;
        private TinkPrintContext context;
        

        public BaseUnitOfWork(IDataBaseFactory dataBaseFactory)
        {
            _dataBaseFactory = dataBaseFactory;
        }

        protected TinkPrintContext Context
        {
            get { return context ?? (context = _dataBaseFactory.GetDataBase()); }
        }


        public void Commint()
        {
            try
            {
                Context.SaveChanges();
               
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
