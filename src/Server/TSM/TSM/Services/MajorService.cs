using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Data.Application;
using TSM.Data.Entities;
using TSM.Interfaces;
using TSM.Logging;
using TSM.Models;

namespace TSM.Services
{
    public class MajorService : IMajorService
    {
        private readonly IMapper _mapper;
        private readonly TSMContext _context;

        public MajorService(
            IMapper mapper,
            TSMContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // Must to implement paging with all features listAll
        public async Task<IEnumerable<MajorModel>> GetMajors()
        {
            var majors = await _context.Majors.ToListAsync();

            return _mapper.Map<IEnumerable<MajorModel>>(majors);
        }

        public async Task<MajorModel> GetMajor(Guid id)
        {
            var major = await _context.Majors.SingleOrDefaultAsync(x => x.Id.Equals(id));

            return _mapper.Map<MajorModel>(major);
        }

        public async Task<IEnumerable<MajorModel>> GetMajorsBySchoolId(Guid schoolId)
        {
            var majors = await _context.SchoolMajors
                                            .Where(x => x.SchoolId == schoolId)
                                            .Select(p => p.Major)
                                            .ToListAsync();

            return _mapper.Map<IEnumerable<MajorModel>>(majors);
        }

        public async Task<MajorModel> CreateMajor(MajorModel majorModel)
        {
            Major major = new Major()
            {
                Code = majorModel.Code,
                Name = majorModel.Name,
                Description = majorModel.Description
            };

            await _context.Majors.AddAsync(major);

            return _mapper.Map<MajorModel>(major);
        }
        public async Task DeleteMajor(Guid id)
        {
            var major = await _context.Majors.SingleOrDefaultAsync(x => x.Id.Equals(id));
            if (major != null)
            {
                _context.Majors.Remove(major);

                await _context.SaveChangesAsync();
            }
        }
    }
}
