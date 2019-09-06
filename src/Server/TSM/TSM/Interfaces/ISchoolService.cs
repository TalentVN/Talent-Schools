using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Models;
using TSM.Models.RequestModels;
using TSM.Models.ResponseModels;

namespace TSM.Interfaces
{
    public interface ISchoolService
    {
        Task<PagingModel<SchoolResponseModel>> GetPagingSchools(int currentPage);
        Task<SchoolResponseModel> GetSchool(Guid id);
        Task<Guid> CreateSchool(CreateSchoolRequestModel requestModel);
        Task UpdateSchool(UpdateSchoolRequestModel requestModel);
        Task DeleteSchool(Guid id);
        Task<IEnumerable<SchoolResponseModel>> SearchSchools(SearchSchoolModel searchModel);
    }
}
