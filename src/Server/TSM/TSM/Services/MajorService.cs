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
    public class MajorService : IMajorService
    {
        private readonly IMapper _mapper;
        private readonly TSMContext _context;

        public MajorService(
            IMapper mapper,
            TSMContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<MajorModel>> GetMajors()
        {
            var majors = await _context.Majors.OrderBy(x => x.Name).AsNoTracking().ToListAsync();

            return _mapper.Map<IEnumerable<MajorModel>>(majors);
        }

        public async Task<PagingModel<MajorModel>> GetPagingMajors(int currentPage)
        {
            int majorsCount = await _context.Majors.CountAsync();
            int totalPages = (int)Math.Ceiling((double)majorsCount / Constants.DEFAULT_PAGING_SIZE);

            var majors = await _context.Majors.Skip((currentPage - 1) * Constants.DEFAULT_PAGING_SIZE)
                                                .Take(Constants.DEFAULT_PAGING_SIZE)
                                                .OrderBy(x => x.Name)
                                                .AsNoTracking().ToListAsync();
            var majorModels = _mapper.Map<IEnumerable<MajorModel>>(majors);

            return new PagingModel<MajorModel>(currentPage, totalPages, majorModels);
        }

        public async Task<MajorModel> GetMajor(Guid id)
        {
            var major = await _context.Majors.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));

            return _mapper.Map<MajorModel>(major);
        }

        public async Task CreateMajor(MajorModel majorModel)
        {
            Major major = new Major(majorModel.Name, majorModel.Description, majorModel.Code);

            await _context.Majors.AddAsync(major);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMajor(MajorModel model)
        {
            var major = await _context.Majors.SingleOrDefaultAsync(x => x.Id.Equals(model.Id));
            major.Name = model.Name;
            major.Description = model.Description;
            major.Code = model.Code;
            major.IsActive = model.IsActive;

            _context.Majors.Update(major);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeActiveMajor(Guid id)
        {
            var major = await _context.Majors.SingleOrDefaultAsync(x => x.Id.Equals(id));
            major.IsActive = !major.IsActive;

            await _context.SaveChangesAsync();
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
