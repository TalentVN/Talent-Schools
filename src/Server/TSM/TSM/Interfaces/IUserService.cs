using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSM.Models;

namespace TSM.Interfaces
{
    interface IUserService
    {
        IEnumerable<UserAdminModel> GetUsers();
        Task<UserAdminModel> GetUser(string email);
        Task<IdentityResult> CreateUser(UserAdminModel requestModel);
        Task UpdateUser(UserAdminModel requestModel);
        Task<IdentityResult> DeleteUser(string email);
    }
}
