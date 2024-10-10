using Exam.Application.Repositories.Exam;
using Exam.Application.Repositories.Lesson;
using Exam.Application.Repositories.Student;
using Exam.Persistance;
using Exam.Persistence.Context;
using Exam.Persistence.Repositories.Exam;
using Exam.Persistence.Repositories.Lesson;
using Exam.Persistence.Repositories.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Exam.Persistence
{
    public static class ServiceRegistration
    {
       
            
            public static void AddPersistenceRegistration(this IServiceCollection services)
            {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuretion.ConnectionString), ServiceLifetime.Singleton);
            services.AddScoped<IExamReadRepository, ExamReadRepository>();
            services.AddScoped<IExamWriteRepository, ExamWriteRepository>();
            services.AddScoped<IStudentReadRepository, StudentReadRepository>();
            services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();
            services.AddScoped<ILessonReadRepository, LessonReadRepository>();
            services.AddScoped<ILessonWriteRepository, LessonWriteRepository>();
        }

    }
}
