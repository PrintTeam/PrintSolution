using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TP.Core.Infrastructure.DependencyManagement;

namespace TP.Core.Infrastructure
{
   public interface IEngine
    {
       ContainerBuilder ContainerBuilder { get; }
    }
}
