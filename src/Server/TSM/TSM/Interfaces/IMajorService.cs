using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Models;

namespace TSM.Interfaces
{
    public interface IMajorService
    {
        Task<IEnumerable<MajorModel>> GetMajors();
        Task<MajorModel> GetMajor(Guid id);
        Task CreateMajor(MajorModel majorModel);
        Task UpdateMajor(MajorModel model);
        Task ChangeActiveMajor(Guid id);
        Task DeleteMajor(Guid id);
    }
}
