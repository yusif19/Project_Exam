using Exam.Application.Features.Commands.Exam.CreateExam;
using Exam.Application.Features.Commands.Student.CreateStudent;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Validators.Exam
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommandRequest>
    {
        public CreateStudentValidator()
        {
            RuleFor(x => x.Student.Name)
                               .NotEmpty().WithMessage("Name boş ola bilməz!")
                               .MaximumLength(30).WithMessage("Name uzunluğu 30 simvoldan artıq ola bilməz!");
            RuleFor(x => x.Student.Surname)
                .NotEmpty().WithMessage("Surname boş ola bilməz!")
                .MaximumLength(30).WithMessage("Surname uzunluğu 30 simvoldan artıq ola bilməz!");
            RuleFor(x => x.Student.Number)
                .NotEmpty().WithMessage("Number boş ola bilməz!")
                .ScalePrecision(0, 5).WithMessage("Number formatı düzgün deyil! (ən çox 5 rəqəm olmalıdır)");
            RuleFor(x => x.Student.Class)
                .NotEmpty().WithMessage("Class boş ola bilməz!")
                .InclusiveBetween(0, 99).WithMessage("Class 0 ilə 99 arasında olmalıdır!");


        }
    }
}
