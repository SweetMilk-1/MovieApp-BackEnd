﻿using MediatR;

namespace MovieApp.Handlers.User.Create
{
    public class CreateUserRequest : IRequest
    {
        public string Email { get; set; } //не должно быть других челов с таким же логином
        public string Login { get; set; } //не должно быть других челов с таким же email
        public string Password { get; set; }
    }
}
