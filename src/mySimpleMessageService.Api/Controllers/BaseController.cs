//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Sieve.Models;
//using Sieve.Services;

//namespace mySimpleMessageService.Api.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]/[action]")]
//    public abstract class BaseController : Controller
//    {
//        private IMediator _mediator;
//        private ISieveProcessor _sieveProcessor;

//        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

//        protected ISieveProcessor SieveProcessor => _sieveProcessor ??
//                                                    (_sieveProcessor = HttpContext.RequestServices
//                                                        .GetService<ISieveProcessor>());

//        public OkObjectResult Ok<T>(IEnumerable<T> value, SieveModel sieveModel)
//        {
//            var results = SieveProcessor.Apply(sieveModel, value.AsQueryable(), applyPagination: false);
//            var onePageResults = SieveProcessor.Apply(sieveModel, results, applyFiltering: false, applySorting: false,
//                applyPagination: true);

//            return base.Ok(new PagedResult<T>(onePageResults, sieveModel.Page, sieveModel.PageSize, results.Count()));
//        }
//    }
//}