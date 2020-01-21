using Autofac;
using SportsStore.Domain.InfrastructureHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.InfrastructureHelper
{
    public class RepositoryModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IDetermineRepositoriesAssembly).Assembly).AsImplementedInterfaces().InstancePerRequest();
            base.Load(builder);
        }
    }
}