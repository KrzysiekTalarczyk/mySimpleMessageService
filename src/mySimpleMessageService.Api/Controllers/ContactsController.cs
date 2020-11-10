using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mySimpleMessageService.Application.Contacts.Commands;
using mySimpleMessageService.Application.Contacts.Dtos;
using mySimpleMessageService.Application.Contacts.Queries;
using mySimpleMessageService.Application.Messages.Command;
using NSwag.Annotations;

namespace mySimpleMessageService.Api.Controllers
{
    public class ContactsController : BaseController
    {

        [HttpGet]
        [OpenApiOperation("Get all contacts")]
        public async Task<IEnumerable<ContactDto>> Get()
        {
            return await Mediator.Send(new GetAllContactsQuery());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContactCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Post([FromBody] DeleteContactCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> Post([FromBody] UpdateContactCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}