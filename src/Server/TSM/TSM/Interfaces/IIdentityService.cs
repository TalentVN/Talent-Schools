using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Models.ResponseModels;

namespace TSM.Interfaces
{
    public interface IIdentityService
    {
        Task<CreateUserResponseModel> Create(string firstName, string lastName, string email, string password);

        Task<LoginResponseModel> Login(string userName, string password);

        Task<bool> ConfirmEmail(string userId, string code);
    }
}
