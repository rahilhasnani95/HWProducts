using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;

namespace HWProduct.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            var cors = new EnableCorsAttribute("*", "*", "*"); //origin(direct url or * for all), header, method (post)

            config.EnableCors(cors);
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            jsonFormatter.SerializerSettings.DateTimeZoneHandling = 
                Newtonsoft.Json.DateTimeZoneHandling.Utc;


            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
