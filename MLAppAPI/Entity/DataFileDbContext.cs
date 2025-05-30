using Microsoft.EntityFrameworkCore;
using MLAppAPI.Models;

namespace MLAppAPI.Entity
{
    public class DataFileDbContext : DbContext
    {
        public DataFileDbContext(DbContextOptions<DataFileDbContext> options) : base(options)
        {
            
        }

        public DbSet<DataFile> DataFiles { get; set; }
    }
}
