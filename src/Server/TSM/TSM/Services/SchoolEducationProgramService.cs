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
    public class SchoolEducationProgramService : ISchoolEducationProgramService
    {
        private readonly IMapper _mapper;
        private readonly TSMContext _context;

        public SchoolEducationProgramService(
            IMapper mapper,
            TSMContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<EducationProgramModel>> SchoolEducationPrograms(Guid schoolId)
        {
            var programs = await _context.SchoolEducationPrograms
                                            .Where(x => x.SchoolId == schoolId)
                                            .Select(x => x.EducationProgram)
                                            .ToListAsync();

            return _mapper.Map<IEnumerable<EducationProgramModel>>(programs);
        }

        public async Task AddSchoolEducationPrograms(Guid schoolId, List<Guid> programIds)
        {
            try
            {
                IList<SchoolEducationProgram> schoolPrograms = new List<SchoolEducationProgram>();

                foreach (var programId in programIds)
                {
                    SchoolEducationProgram schoolProgram = new SchoolEducationProgram()
                    {
                        EducationProgramId = programId,
                        SchoolId = schoolId
                    };

                    schoolPrograms.Add(schoolProgram);
                }

                await _context.SchoolEducationPrograms.AddRangeAsync(schoolPrograms);

                await _context.SaveChangesAsync();
            }
            catch
            {

            }

        }

        public async Task RemoveSchoolEducationPrograms(Guid schoolId, List<Guid> programIds)
        {
            try
            {
                var schoolMajors = await _context.SchoolEducationPrograms
                                                    .Where(x => x.SchoolId.Equals(schoolId) && programIds.Contains(x.EducationProgramId))
                                                    .ToListAsync();

                _context.SchoolEducationPrograms.RemoveRange(schoolMajors);

                await _context.SaveChangesAsync();
            }
            catch
            {

            }
        }
    }
}
