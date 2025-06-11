using MLAppAPI.Entity;
using MLAppAPI.Models;

namespace MLAppAPI.Services.Interfaces
{
    public interface IFileUploaderService
    {
        public Task CreateAsync(DataFile dataFile);

        public Task<List<DataFile>> GetListAsync();

        public Task UpdateAsync(DataFile dataFile);
    }
}
