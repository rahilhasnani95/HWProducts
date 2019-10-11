//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Autofac;
//using Autofac.Integration.Mvc;
//using HWProducts.Core.Contracts;
//using HWProducts.Core.Model;
//using HWProducts.DataAccess.InMemory;

//namespace HWProducts.WebUI.App_Start
//{
//    public class ContainerConfig
//    {
//        internal static void RegisterContainer()
//        {
//            var builder = new ContainerBuilder();

//            builder.RegisterControllers(typeof(MvcApplication).Assembly);

//            // builder.RegisterApiControllers(typeof(HWProducts.WebUI.MvcApplication).Assembly);

//            /* builder.RegisterType<InMemoryRestaurantData>()
//                 .As<IRestaurantData>()
//                 .SingleInstance();*/

//            builder.RegisterType<InMemoryRepository<BaseEntity>>()
//               .As<IRepository<BaseEntity>>().SingleInstance();

//               //.InstancePerRequest(); //everytime we create request, it will give a new object bcoz multiple people will be dealing with this db
//           // builder.RegisterType<MyRestaurantDBContext>().InstancePerRequest();

//            var container = builder.Build();

//            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

//          //  httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);


//        }
//    }
//}