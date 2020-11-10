using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mySimpleMessageService.Application.Messages.Command;
using mySimpleMessageService.Application.Messages.Dtos;
using mySimpleMessageService.Application.Messages.Queries;

namespace mySimpleMessageService.Api.Controllers
{
    public class MessagesController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDto>>> Get(GetMessagesQuery query)
        {
            var results = await Mediator.Send(query);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SendMessageCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Post([FromBody] DeleteMessageCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}