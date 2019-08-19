using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSM.Models;

namespace TSM.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserAdminModel>> GetUsers();
        Task<UserAdminModel> GetUser(string id);
        Task<IdentityResult> CreateUser(UserAdminModel requestModel);
        Task<IdentityResult> UpdateUser(UserAdminModel requestModel);
        Task<IdentityResult> DeleteUser(string id);
    }
}
