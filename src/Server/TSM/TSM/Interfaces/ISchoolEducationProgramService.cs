using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Models;

namespace TSM.Interfaces
{
    public interface ISchoolEducationProgramService
    {
        Task<IEnumerable<EducationProgramModel>> SchoolEducationPrograms(Guid schoolId);
        Task AddSchoolEducationPrograms(Guid schoolId, List<Guid> programIds);
        Task RemoveSchoolEducationPrograms(Guid schoolId, List<Guid> programIds);
    }
}
