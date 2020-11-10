using System.Collections.Generic;
using mySimpleMessageService.Application.Contacts.Dtos;
using Sieve.Models;

namespace mySimpleMessageService.Application.Contacts.Queries
{
    using MediatR;
    public class GetAllContactsQuery : SieveModel, IRequest<IEnumerable<ContactDto>>
    {
    }
}
