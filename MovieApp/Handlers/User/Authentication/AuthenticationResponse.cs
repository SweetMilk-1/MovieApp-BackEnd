﻿namespace MovieApp.Handlers.User.Authentication
{
    public class AuthenticationResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}