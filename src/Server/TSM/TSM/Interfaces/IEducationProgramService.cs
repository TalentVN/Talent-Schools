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
        Task<EducationProgramModel> GetEducationProgram(Guid id);
        Task<EducationProgramModel> CreateEducationProgram(EducationProgramModel model);
        Task DeleteEducationProgram(Guid id);
    }
}
