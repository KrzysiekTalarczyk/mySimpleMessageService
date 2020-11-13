using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mySimpleMessageService.Application.Messages.Command;
using mySimpleMessageService.Application.Messages.Dtos;
using mySimpleMessageService.Application.Messages.Queries;

namespace mySimpleMessageService.Api.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDto>>> Get([FromQuery] GetMessagesQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response.Results, query, response.TotalResultCount);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SendMessageCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteMessageCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}