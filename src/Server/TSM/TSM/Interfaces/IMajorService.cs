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
        Task<MajorModel> CreateMajor(MajorModel majorModel);
        Task DeleteMajor(Guid id);
    }
}
