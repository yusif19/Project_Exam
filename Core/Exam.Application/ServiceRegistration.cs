using Exam.Application.Validators.Exam;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(ServiceRegistration)));
            services.AddAutoMapper(typeof(ServiceRegistration));

            services.AddControllers()
               .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateExamValidator>())
               .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<UpdateExamValidator>())
               .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateLessonValidator>());
               //.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<UpdateLessonValidator>())
               //.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateStudentValidator>())
               //.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<UpdateStudentValidator>());

        }

    }
}
