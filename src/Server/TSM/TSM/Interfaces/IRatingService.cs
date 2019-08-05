using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Common.Enums;
using TSM.Models;

namespace TSM.Interfaces
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingModel>> GetRatings(Guid schoolId);
        Task<IEnumerable<RatingModel>> QueryRatings(Guid schoolId, RatingType ratingType);
        Task<RatingModel> CreateRating(CreateRatingRequestModel ratingModel);
        Task DeleteRating(Guid id);
    }
}
