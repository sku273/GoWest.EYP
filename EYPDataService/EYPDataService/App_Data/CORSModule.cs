using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace EYPDataService
{
    public class CORSModule : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += delegate
            {
                if (context.Request.HttpMethod == "OPTIONS")
                {
                    var response = context.Response;
                    response.StatusCode = (int)HttpStatusCode.OK;
                }
            };
        }
    }
}