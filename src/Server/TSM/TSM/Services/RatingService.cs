using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public RatingService(
            IMapper mapper,
            TSMContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<RatingModel>> GetRatings(Guid schoolId)
        {
            var ratings = await _context.Ratings.Where(x => x.SchoolId.Equals(schoolId))
                                                .ToListAsync();
            return _mapper.Map<IEnumerable<RatingModel>>(ratings);
        }

        public async Task<RatingModel> CreateRating(Guid schoolId, RatingModel ratingModel)
        {
            Rating rating = new Rating()
            {
                SchoolId = schoolId,
                Comment = ratingModel.Comment,
                Value = ratingModel.Value
            };

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
