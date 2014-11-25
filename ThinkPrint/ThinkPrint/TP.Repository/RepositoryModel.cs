using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Repository;
using TP.Core.UnitOfWork;
using TP.Repository.Base;

namespace TP.Repository
{
    public class RepositoryModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");

            builder.RegisterGeneric(typeof(BaseRepository<>))
               .As(typeof(IRepository<>))
               .InstancePerRequest();
            builder.RegisterType<BaseUnitOfWork>().As<IUnitOfWork>().SingleInstance();


            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces().InstancePerRequest();

        }
    }
}
