using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mySimpleMessageService.Application.Contacts.Commands;
using mySimpleMessageService.Application.Contacts.Dtos;
using mySimpleMessageService.Application.Contacts.Queries;
using NSwag.Annotations;

namespace mySimpleMessageService.Api.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : BaseController
    {

        [HttpGet]
        [OpenApiOperation("Get all contacts")]
        public async Task<ActionResult<IEnumerable<ContactDto>>> Get([FromQuery] GetAllContactsQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response.Results, query, response.TotalResultCount);
         }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContactCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteContactCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateContactCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}