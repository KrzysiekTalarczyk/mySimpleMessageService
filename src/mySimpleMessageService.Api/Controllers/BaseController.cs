using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Models;
using System.Collections.Generic;
using mySimpleMessageService.Api.Helpers;

namespace mySimpleMessageService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public OkObjectResult Ok<T>(IEnumerable<T> value, SieveModel sieveModel, int totalResultCount)
        {
            return base.Ok(new PagedResult<T>(value, sieveModel.Page, sieveModel.PageSize, totalResultCount));
        }
    }
}