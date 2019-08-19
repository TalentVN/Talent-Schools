using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSM.Data.Entities;
using TSM.Interfaces;
using TSM.Logging;
using TSM.Models;

namespace TSM.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UserService(
            UserManager<ApplicationUser> userManager,
            IMapper mapper, 
            IEmailService emailService)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        public async Task<IEnumerable<UserAdminModel>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var results = _mapper.Map<IEnumerable<UserAdminModel>>(users);

            return results;
        }

        public async Task<UserAdminModel> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = _mapper.Map<UserAdminModel>(user);

            return result;
        }

        public async Task<IdentityResult> CreateUser(UserAdminModel requestModel)
        {
            var user = new ApplicationUser
            {
                Email = requestModel.Email,
                UserName = requestModel.Email,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Address = requestModel.Address,
                JwtRole = requestModel.JwtRole
            };

            var identityResult = await _userManager.CreateAsync(user, requestModel.PassWord);

            if (identityResult.Succeeded)
            {
                string confirmationToken =  await _userManager.GenerateEmailConfirmationTokenAsync(user);

                string confirmUrl = $"https://{5001}" + "emailconfirmation?userid={0}&code={1}";

                string callbackUrl = string.Format(confirmUrl, user.Id, confirmationToken);

                await _emailService.SendEmailAsync(requestModel.Email, "Confirm Email", callbackUrl);
            }

            return identityResult;
        }

        public async Task<IdentityResult> UpdateUser(UserAdminModel requestModel)
        {
            var user = await _userManager.FindByEmailAsync(requestModel.Email);
            user.FirstName = requestModel.FirstName;
            user.LastName = requestModel.LastName;
            user.JwtRole = requestModel.JwtRole;
            user.Address = requestModel.Address;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var identityResult = await _userManager.ResetPasswordAsync(user, token, requestModel.PassWord);

            return identityResult;
        }

        public async Task<IdentityResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return await _userManager.DeleteAsync(user);
        }
    }
}
