using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSM.Models.RequestModels
{
    public class EmailConfirmationRequestModel
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}
