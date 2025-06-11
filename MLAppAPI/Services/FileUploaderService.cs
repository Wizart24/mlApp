using Microsoft.EntityFrameworkCore;
using MLAppAPI.Entity;
using MLAppAPI.Models;
using MLAppAPI.Services.Interfaces;

namespace MLAppAPI.Services
{
    public class FileUploaderService : IFileUploaderService
    {
        private readonly DataFileDbContext _context;

        public FileUploaderService(DataFileDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DataFile dataFile)
        {
            await _context.AddAsync(dataFile);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DataFile>> GetListAsync()
        {
            return await _context.DataFiles.ToListAsync();
        }

        public async Task UpdateAsync(DataFile dataFile)
        {
            var data = await _context.DataFiles.FirstOrDefaultAsync(x => x.Title == dataFile.Title);

            if (data == null)
                throw new InvalidOperationException("Data file was not found.");

            data.Title = dataFile.Title;
            data.CreatedDate = dataFile.CreatedDate;
            data.FileData = dataFile.FileData;
            data.DataType = dataFile.DataType;
            data.Description = dataFile.Description;

            await _context.SaveChangesAsync();
        }
    }
}
