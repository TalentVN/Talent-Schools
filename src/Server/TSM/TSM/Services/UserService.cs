using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Interfaces;
using TSM.Models;

namespace TSM.Services
{
    public class UserService : IUserService
    {
        public Task<Guid> CreateUser(UserModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(UserModel requestModel)
        {
            throw new NotImplementedException();
        }
    }
}
