using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Test.Utils
{
    public static class ResponseRequestParser
    {
        public static HttpStatusCode GetResponseStatusCode(this IActionResult response)
        {
            return (HttpStatusCode)response
                                    .GetType()
                                    .GetProperty("StatusCode")
                                    .GetValue(response, null);
        }
        public static T GetResponseContent<T>(this IActionResult response)
        {
            return (T)response
                        .GetType()
                        .GetProperty("Value")
                        .GetValue(response, null);
        }
    }
}
