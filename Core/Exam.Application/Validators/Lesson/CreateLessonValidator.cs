using Exam.Application.DTO;
using Exam.Application.Features.Commands.Exam.CreateExam;
using Exam.Application.Features.Commands.Lesson.CreateLesson;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Validators.Exam
{
    public class CreateLessonValidator : AbstractValidator<CreateLessonCommandRequest>
    {
        public CreateLessonValidator()
        {
        
                RuleFor(x => x.Lesson.Code)
                    .NotEmpty().WithMessage("Code boş ola bilməz!")
                    .MaximumLength(3).WithMessage("Code uzunluğu 3 simvoldan artıq ola bilməz!");

                RuleFor(x => x.Lesson.TeacherName)
                    .NotEmpty().WithMessage("TeacherName boş ola bilməz!")
                    .MaximumLength(20).WithMessage("TeacherName uzunluğu 20 simvoldan artıq ola bilməz!");

                RuleFor(x => x.Lesson.TeacherSurname)
                    .NotEmpty().WithMessage("TeacherSurname boş ola bilməz!")
                    .MaximumLength(20).WithMessage("TeacherSurname uzunluğu 20 simvoldan artıq ola bilməz!");

                RuleFor(x => x.Lesson.Class)
                    .InclusiveBetween(0, 99).WithMessage("Class 0 ilə 99 arasında olmalıdır!")
                    .NotEmpty().WithMessage("Class boş ola bilməz!");
            
        


    }
}
}
