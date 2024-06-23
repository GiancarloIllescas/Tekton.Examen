using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;


namespace Tekton.Examen.Cross.Common
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            context.Response.OnStarting(() =>
            {
                stopwatch.Stop();
                var logMessage = $"{context.Request.Method} {context.Request.Path} responded in {stopwatch.ElapsedMilliseconds} ms";
                File.AppendAllText("request_times.log", logMessage + "\n");

                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
