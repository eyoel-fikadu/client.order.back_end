﻿using MediatR;
using System;

namespace MLA.ClientOrder.Application.Features.User.AddUser
{
    public class AddUserCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}