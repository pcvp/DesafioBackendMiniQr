using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using DesafioBackendMiniQrApi.Application.ViewModels.Shared;
using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DesafioBackendMiniQr.Api.Controllers
{
    [Produces("application/json")]
    [ExcludeFromCodeCoverage]
    public class MyControllerBase : ControllerBase
    {
        private readonly IErrorNotificationResult _errorNotificationResult;
        internal ResultVm<object>? Result = null;

        public MyControllerBase(IErrorNotificationResult errorNotificationResult)
        {
            _errorNotificationResult = errorNotificationResult;
        }

        protected Task<IActionResult> RunContent(Func<Task<object>> method,
                                                 string successMessage = "")
        {
            return RunContent(method, successMessage, null);
        }


        protected async Task<IActionResult> RunContent(Func<Task<object>> method,
                                                       string successMessage,
                                                       int? statusCode)
        {
            Result = new ResultVm<object>();
            var returnObject = await method();

            if (!IsValidOperation()) return GetReturnError();

            statusCode = CheckResponseObject(successMessage, statusCode, returnObject);
            return GetSuccessResult(statusCode);

        }
        
        private bool IsValidOperation()
        {
            return !_errorNotificationResult.HasNotification();
        }

        private int? CheckResponseObject(string successMessage, int? statusCode, object returnObject)
        {
            Result.Data = returnObject ?? new object { };
            Result.Message = successMessage;

            return statusCode;
        }

        private IActionResult GetSuccessResult(int? statusCode)
        {
            return new JsonResult(Result)
            {
                StatusCode = statusCode ?? StatusCodes.Status200OK
            };
        }

        private IActionResult GetReturnError()
        {
            var intStatusCode = _errorNotificationResult.StatusCode ?? StatusCodes.Status400BadRequest;

            var errors = _errorNotificationResult.GetNotification()
                .Select(n => new ErrorVm(n.Code, "pt-br", n.Value, n.Json))
                .ToList();

            var errorResultVm = new ErrorResultVm
            {
                Type = intStatusCode,
                Errors = errors
            };
            return StatusCode(intStatusCode, errorResultVm);
        }
    }
}
