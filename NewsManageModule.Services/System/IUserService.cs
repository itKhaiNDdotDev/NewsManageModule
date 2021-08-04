using NewsManageModule.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsManageModule.Services.System
{
    public interface IUserService
    {
        Task<string> Authen(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
