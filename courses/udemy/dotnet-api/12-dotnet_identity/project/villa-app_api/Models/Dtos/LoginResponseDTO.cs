﻿using villa_app_api.Models.Entities;

namespace villa_app_api.Models.Dtos
{
    public class LoginResponseDTO
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
