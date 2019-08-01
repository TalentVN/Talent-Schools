using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Models;

namespace TSM.Interfaces
{
    public interface ISchoolMajorService
    {
        Task<IEnumerable<MajorModel>> SchoolMajors(Guid schoolId);
        Task AddSchoolMajors(Guid schoolId, List<Guid> majorIds);
        Task RemoveSchoolMajors(Guid schoolId, List<Guid> majorIds);
    }
}
