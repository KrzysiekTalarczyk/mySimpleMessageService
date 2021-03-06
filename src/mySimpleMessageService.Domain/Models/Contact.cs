﻿using System.Collections.Generic;
using mySimpleMessageService.Domain.Exceptions;

namespace mySimpleMessageService.Domain.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public ICollection<Message> SenderMessages { get; set; }
        public ICollection<Message> RecipientMessages { get; set; }

        private Contact() { }

        public static Contact Create(string name)
        {
            name = name?.Trim();
            Validate(name);
            return new Contact() { Name = name };
        }

        private static void Validate(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ContactValidationException(name);
        }
    }
}
