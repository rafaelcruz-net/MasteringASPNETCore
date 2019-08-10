using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Underwater.Middlewares
{
    public static class LogTraceAppExtensionMiddleware
    {
        public static void LogRequest(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Use(async (context, next) =>
            {
                await next.Invoke();
                await Task.Factory.StartNew(() =>
                {
                    var request = JsonConvert.SerializeObject(context.Request.Headers);
                    Trace.WriteLine($"Log do Request at {DateTime.Now}:{request}");
                });
            });


        }
    }
}
