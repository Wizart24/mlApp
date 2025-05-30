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
    }
}
