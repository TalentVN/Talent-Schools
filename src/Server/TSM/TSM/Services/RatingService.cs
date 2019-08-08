using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Common.Enums;
using TSM.Data.Application;
using TSM.Data.Entities;
using TSM.Interfaces;
using TSM.Logging;
using TSM.Models;

namespace TSM.Services
{
    public class RatingService : IRatingService
    {
        private readonly IMapper _mapper;
        private readonly TSMContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RatingService(
            IMapper mapper,
            TSMContext context,
            UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<IEnumerable<RatingModel>> GetRatings(Guid schoolId)
        {
            var ratings = await _context.Ratings
                                                .Include(x => x.User)
                                                .Include(x => x.School)
                                                .Where(x => x.SchoolId.Equals(schoolId))
                                                .ToListAsync();
            foreach( var rating in ratings)
            {
                rating.User = await _userManager.FindByIdAsync(rating.UserId.ToString());
            }
            return _mapper.Map<IEnumerable<RatingModel>>(ratings);
        }

        public async Task<IEnumerable<RatingModel>> QueryRatings(Guid schoolId, RatingType ratingType)
        {
            var ratings = await _context.Ratings
                                                .Include(x => x.User)
                                                .Include(x => x.School)
                                                .Where(x => x.SchoolId.Equals(schoolId) && x.RatingType.Equals(ratingType))
                                                .OrderByDescending(x => x.CreatedDate)
                                                .ToListAsync();
            foreach (var rating in ratings)
            {
                rating.User = await _userManager.FindByIdAsync(rating.UserId.ToString());
            }
            return _mapper.Map<IEnumerable<RatingModel>>(ratings);
        }

        public async Task<RatingModel> CreateRating(CreateRatingRequestModel ratingModel)
        {
            Rating rating = new Rating(
                ratingModel.SchoolId,
                ratingModel.UserId,
                ratingModel.RatingType,
                ratingModel.Comment,
                ratingModel.Value);

            await _context.Ratings.AddAsync(rating);

            await _context.SaveChangesAsync();

            return _mapper.Map<RatingModel>(rating);
        }

        public async Task DeleteRating(Guid id)
        {
            var rating = await _context.Ratings.SingleOrDefaultAsync(x => x.Id.Equals(id));
            if (rating != null)
            {
                _context.Ratings.Remove(rating);

                await _context.SaveChangesAsync();
            }
        }
    }
}
