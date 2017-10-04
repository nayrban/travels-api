
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Web.Http.ExceptionHandling;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Http.Results;
using travels.dto.Dto;

namespace travels.service.api.Config
{
    public class ErrorHandlingMiddleware : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var metadata = new NasError
            {
                Message = "An unexpected error occurred!",
                DetailedMessage = context.Exception.Message
            };
            //log the metadata.ErrorId and the correlated Exception info to your DB/logs
            //or, if you have IExceptionLogger (chapter 8-3), it will already have been logged
          //  Debug.WriteLine("Error correlation id: {0}", metadata.ErrorId);

            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, metadata);
            context.Result = new ResponseMessageResult(response);
        }
    }
}