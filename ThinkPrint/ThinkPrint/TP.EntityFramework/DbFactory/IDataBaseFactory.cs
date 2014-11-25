using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;


namespace TP.EntityFramework
{
    public interface IDataBaseFactory :IDisposable
    {
        TinkPrintContext GetDataBase();
    }
}
