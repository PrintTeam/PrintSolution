using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Autofac;
using TP.Core.Infrastructure;
using TP.Core.Infrastructure.DependencyManagement;

namespace TP.Core.Infrastructure
{
    public class EasyEngine : IEngine
    {

        private ContainerBuilder _containerBuilder;
        public ContainerBuilder ContainerBuilder
        {
            get { return _containerBuilder; }
        }


        #region Ctor

        public EasyEngine()
        {

            InitializeContainer();
        }

        #endregion

        #region Utilities

        private void InitializeContainer()
        {
            var builder = new ContainerBuilder();

            _containerBuilder = builder;
        }

        #endregion

    }
}
