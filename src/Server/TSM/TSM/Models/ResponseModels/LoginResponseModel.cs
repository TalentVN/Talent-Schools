using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Models.ResponseModels
{
    public class LoginResponseModel : IdentityResult
    {
        public string Token { get; set; }

        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JwtRole { get; set; }
    }
}
