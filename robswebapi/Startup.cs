using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Owin;
using robswebapi.middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

[assembly:OwinStartup(typeof(robswebapi.Startup))]

namespace robswebapi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.MapHttpAttributeRoutes();

            
           
            var robsmiddle = new RobsMIddleware();
            var middleware = new Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>((Func<IDictionary<string, object>, Task>  input)=>
            {
                return robsmiddle.RobsBodyMiddleware(input);
            });
            //
            appBuilder.UseWebApi(config);
            appBuilder.Use(middleware);
        }
    }
}