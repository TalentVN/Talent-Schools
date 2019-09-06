using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Models;

namespace TSM.Interfaces
{
    public interface IEducationProgramService
    {
        Task<IEnumerable<EducationProgramModel>> GetEducationPrograms();
        Task<PagingModel<EducationProgramModel>> GetPagingEducationPrograms(int currentPage);
        Task<EducationProgramModel> GetEducationProgram(Guid id);
        Task CreateEducationProgram(EducationProgramModel model);
        Task UpdateEducationProgram(EducationProgramModel model);
        Task ChangeActiveEducationProgram(Guid id);
        Task DeleteEducationProgram(Guid id);
    }
}
