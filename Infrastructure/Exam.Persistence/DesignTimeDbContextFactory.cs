using Exam.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuretion.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
    //internal class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<ApplicationDbContext>
    //{
    //    public ApplicationDbContext CreateDbContext(string [] args)
    //    {
    //        DbContextOptionsBuilder<ApplicationDbContext> dbContextOptionsBuilder = new();
    //        dbContextOptionsBuilder.UseSqlServer();
    //        return new(dbContextOptionsBuilder.Options);
    //    }
    //}
}
