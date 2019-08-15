using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSM.Models;

namespace TSM.Interfaces
{
    interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> GetUser(Guid id);
        Task<Guid> CreateUser(UserModel requestModel);
        Task UpdateUser(UserModel requestModel);
        Task DeleteUser(Guid id);
    }
}
