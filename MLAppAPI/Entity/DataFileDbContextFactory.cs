using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MLAppAPI.Entity
{
    public class DataFileDbContextFactory : IDesignTimeDbContextFactory<DataFileDbContext>
    {
        public DataFileDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataFileDbContext>();
            optionsBuilder.UseSqlServer("Server=db20535.databaseasp.net; Database=db20535; User Id=db20535; Password=5f?Fw_T7R4%g; Encrypt=False; MultipleActiveResultSets=True;");

            return new DataFileDbContext(optionsBuilder.Options);
        }
    }
}
