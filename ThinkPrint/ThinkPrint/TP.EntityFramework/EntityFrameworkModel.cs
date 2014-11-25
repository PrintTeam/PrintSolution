using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.DbFactory;

namespace TP.EntityFramework
{
    public class EntityFrameworkModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");

            builder.RegisterType<DataBaseFactory>().As<IDataBaseFactory>().SingleInstance();
        }
    }
}
