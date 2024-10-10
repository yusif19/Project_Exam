

using Microsoft.EntityFrameworkCore;

namespace Exam.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Exam.Domain.Entities.Exam>Exams { get; set; }
        public DbSet<Exam.Domain.Entities.Lesson>Lessons { get; set; }
        public DbSet<Exam.Domain.Entities.Student>Students { get; set; }
    }
}
