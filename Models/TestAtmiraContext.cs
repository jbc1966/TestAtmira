using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Test_Atmira.Models;

namespace Test_Atmira.Models
{
    public class TestAtmiraContext: DbContext
    {
      public TestAtmiraContext(DbContextOptions<TestAtmiraContext> options):base(options) 
      {

      }

        public DbSet<Episode> Episodes { get; set; } = null;

        public static void OnModelCreating([NotNull] TestAtmiraContext context, [NotNull] ModelBuilder modelBuilder)
        {
            context.OnModelCreating(modelBuilder);
        }
    }
}
