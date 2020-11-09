using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace mySimpleMessageService.Application.Contacts.Commands
{
    class DeleteContactCommand : IRequest
    {
        public int Id { get; set; }
    }
}
