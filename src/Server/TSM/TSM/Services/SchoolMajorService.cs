using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Data.Application;
using TSM.Data.Entities;
using TSM.Interfaces;
using TSM.Models;

namespace TSM.Services
{
    public class SchoolMajorService : ISchoolMajorService
    {
        private readonly IMapper _mapper;
        private readonly TSMContext _context;

        public SchoolMajorService(
            IMapper mapper,
            TSMContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<MajorModel>> SchoolMajors(Guid schoolId)
        {
            var majors = await _context.SchoolMajors
                                            .Where(x => x.SchoolId == schoolId)
                                            .Select(x => x.Major)
                                            .ToListAsync();

            return _mapper.Map<IEnumerable<MajorModel>>(majors);
        }

        public async Task AddSchoolMajors(Guid schoolId, List<Guid> majorIds)
        {
            try
            {
                IList<SchoolMajor> schoolMajors = new List<SchoolMajor>();

                foreach (var majorId in majorIds)
                {
                    SchoolMajor schoolMajor = new SchoolMajor()
                    {
                        MajorId = majorId,
                        SchoolId = schoolId
                    };

                    schoolMajors.Add(schoolMajor);
                }

                await _context.SchoolMajors.AddRangeAsync(schoolMajors);

                await _context.SaveChangesAsync();
            }
            catch
            {

            }

        }

        public async Task RemoveSchoolMajors(Guid schoolId, List<Guid> majorIds)
        {
            try
            {
                var schoolMajors = await _context.SchoolMajors
                                                    .Where(x => x.SchoolId.Equals(schoolId) && majorIds.Contains(x.MajorId))
                                                    .ToListAsync();

                _context.SchoolMajors.RemoveRange(schoolMajors);

                await _context.SaveChangesAsync();
            }
            catch
            {

            }
        }
    }
}
