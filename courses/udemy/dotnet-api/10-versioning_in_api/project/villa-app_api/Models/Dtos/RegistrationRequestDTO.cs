﻿namespace villa_app_api.Models.Dtos
{
    public class RegistrationRequestDTO
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
