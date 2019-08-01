using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Data.Application;
using TSM.Logging;

namespace TSM.Services
{
    public class RatingService
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger<RatingService> _logger;
        private readonly TSMContext _context;

        public RatingService()
        {

        }
    }
}
