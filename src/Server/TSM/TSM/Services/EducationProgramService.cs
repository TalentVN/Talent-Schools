using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSM.Common;
using TSM.Data.Application;
using TSM.Data.Entities;
using TSM.Interfaces;
using TSM.Logging;
using TSM.Models;

namespace TSM.Services
{
    public class EducationProgramService : IEducationProgramService
    {
        private readonly IMapper _mapper;
        private readonly TSMContext _context;

        public EducationProgramService(
            IMapper mapper,
            TSMContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<EducationProgramModel>> GetEducationPrograms()
        {
            var programs = await _context.EducationPrograms.OrderBy(x => x.Name).AsNoTracking().ToListAsync();

            return _mapper.Map<IEnumerable<EducationProgramModel>>(programs);
        }

        public async Task<PagingModel<EducationProgramModel>> GetPagingEducationPrograms(int currentPage)
        {
            int programsCount = await _context.EducationPrograms.CountAsync();
            int totalPages = (int)Math.Ceiling((double)programsCount / Constants.DEFAULT_PAGING_SIZE);

            var programs = await _context.EducationPrograms.Skip((currentPage - 1) * Constants.DEFAULT_PAGING_SIZE)
                                                            .Take(Constants.DEFAULT_PAGING_SIZE)
                                                            .OrderBy(x => x.Name)
                                                            .AsNoTracking().ToListAsync();

            var programModels =  _mapper.Map<IEnumerable<EducationProgramModel>>(programs);

            return new PagingModel<EducationProgramModel>(currentPage, totalPages, programModels);
        }

        public async Task<EducationProgramModel> GetEducationProgram(Guid id)
        {
            var program = await _context.EducationPrograms.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));

            return _mapper.Map<EducationProgramModel>(program);
        }

        public async Task CreateEducationProgram(EducationProgramModel model)
        {
            EducationProgram educationProgram = new EducationProgram(model.Name, model.Description, model.Code);

            await _context.EducationPrograms.AddAsync(educationProgram);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEducationProgram(EducationProgramModel model)
        {
            var program = await _context.EducationPrograms.SingleOrDefaultAsync(x => x.Id.Equals(model.Id));
            program.Name = model.Name;
            program.Description = model.Description;
            program.Code = model.Code;
            program.IsActive = model.IsActive;

            _context.EducationPrograms.Update(program);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeActiveEducationProgram(Guid id)
        {
            var program = await _context.EducationPrograms.SingleOrDefaultAsync(x => x.Id.Equals(id));
            program.IsActive = !program.IsActive;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEducationProgram(Guid id)
        {
            var program = await _context.EducationPrograms.SingleOrDefaultAsync(x => x.Id.Equals(id));
            if (program != null)
            {
                _context.EducationPrograms.Remove(program);

                await _context.SaveChangesAsync();
            }
        }
    }
}
