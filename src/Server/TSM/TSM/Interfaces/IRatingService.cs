using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Models;

namespace TSM.Interfaces
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingModel>> GetRatings(Guid schoolId);
        Task<RatingModel> CreateRating(Guid schoolId, RatingModel ratingModel);
        Task DeleteRating(Guid id);
    }
}
