﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.API.DataContract.Authorization
{
    public class RegisterUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
