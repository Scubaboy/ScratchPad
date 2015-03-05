using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace robswebapi.middleware
{
    public class RobsMIddleware
    {
        public Func<IDictionary<string,object>,Task> RobsBodyMiddleware(Func<IDictionary<string,object>,Task> next)
        {
            Func<IDictionary<string, object>, Task> theFunc = async (IDictionary<string, object> enviro) =>
                {
                    var response = enviro["owin.ResponseBody"] as Stream;

                    using (var writer = new StreamWriter(response))
                    {
                        await writer.WriteAsync("<h1>Hello From Rob</h>");
                    }
                    await next.Invoke(enviro);
                };

            return theFunc;
        }
    }
}