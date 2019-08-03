using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Models.RequestModels;
using TSM.Models.ResponseModels;

namespace TSM.Interfaces
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolResponseModel>> GetSchools();
        Task<SchoolResponseModel> GetSchool(Guid id);
        Task<SchoolResponseModel> CreateSchool(CreateSchoolRequestModel requestModel);
        Task<SchoolResponseModel> UpdateSchool(UpdateSchoolRequestModel requestModel);
        Task DeleteSchool(Guid id);
    }
}
