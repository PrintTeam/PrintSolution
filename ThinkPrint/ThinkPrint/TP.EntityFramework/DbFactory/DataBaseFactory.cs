using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;


namespace TP.EntityFramework.DbFactory
{
    public class DataBaseFactory : IDataBaseFactory
    {
        private ThinkPrintContext _context;
        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public ThinkPrintContext GetDataBase()
        {
            return _context ?? (_context = new ThinkPrintContext());
        }
    }
}
