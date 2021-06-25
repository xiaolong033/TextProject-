using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Dorm.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var builder = new ContainerBuilder();
            //由於是在web項目裡面引用的autofac，所以注入也在這層，加載程序集BLL和Data需要引用
            //不然Assembly.Load加載不到當前bin目錄裡面的Data層的dll
            //也可以不引用，需要手動將Data層的dll複製到web裡面的bin
            Assembly asseambly_BLL = Assembly.Load("Dorm.BLL");
            Assembly asseambly_Data = Assembly.Load("Dorm.DAL");

            Assembly asseambly_IBLL = Assembly.Load("Dorm.IBLL");
            Assembly asseambly_IData = Assembly.Load("Dorm.IDAL");

            //注入成功
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterAssemblyTypes(asseambly_IBLL).AsImplementedInterfaces().PropertiesAutowired();
            builder.RegisterAssemblyTypes(asseambly_BLL).AsImplementedInterfaces().PropertiesAutowired();
            builder.RegisterAssemblyTypes(asseambly_IData).AsImplementedInterfaces().PropertiesAutowired();
            builder.RegisterAssemblyTypes(asseambly_Data).AsImplementedInterfaces().PropertiesAutowired();

            //强类型注入
            //builder.RegisterType<ProjectBll>().As<IProjectBll>();

            //注入成功
            //builder.RegisterAssemblyTypes(asseambly_IBLL, asseambly_BLL).Where(x=>x.Name.EndsWith("Bll")).AsImplementedInterfaces().PropertiesAutowired();
            //builder.RegisterAssemblyTypes(asseambly_IData, asseambly_Data).Where(x => x.Name.EndsWith("Dao")).AsImplementedInterfaces().PropertiesAutowired();

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
