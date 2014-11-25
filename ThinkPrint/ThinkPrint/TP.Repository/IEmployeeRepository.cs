
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Repository;
using TP.EntityFramework.Models;

namespace TP.Repository
{
    public interface IEmployeeRepository : IRepository<ORG_Employee>
    {
    }
}
