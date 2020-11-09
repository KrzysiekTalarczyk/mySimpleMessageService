﻿using System.Collections.Generic;
using mySimpleMessageService.Application.Contacts.Dtos;

namespace mySimpleMessageService.Application.Contacts.Queries
{
    using MediatR;
    public class GetAllContacts :  IRequest<IEnumerable<ContactDto>>
    {
    }
}
