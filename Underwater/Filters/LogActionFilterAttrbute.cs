using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Underwater.Filters
{
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        Stopwatch Stopwatch { get; set; }

        public LogActionFilterAttribute()
        {
            this.Stopwatch = new Stopwatch(); 
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.Stopwatch.Start();
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            this.Stopwatch.Stop();
            Trace.WriteLine($"Tempo de execução total da action " +
                $"é {this.Stopwatch.Elapsed}");

            this.Stopwatch.Reset();
        }

    }
}
