using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.ViewModels.System.Users
{
    public class RegisterRequest
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
