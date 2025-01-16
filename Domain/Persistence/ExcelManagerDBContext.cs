using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistence
{
    public class ExcelManagerDBContext : DbContext
    {

        public DbSet<DailyRecord> DailyRecords{ get; set; }
        public ExcelManagerDBContext(DbContextOptions<ExcelManagerDBContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
