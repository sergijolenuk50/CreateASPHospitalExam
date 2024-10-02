using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountsService
    {
        Task Register(RegisterDto model);
        Task<LoginRespons> Login(LoginDto model);
        Task Logout();
    }
}
