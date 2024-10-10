using Exam.Application.DTO;
using Exam.Application.Features.Commands.Exam.CreateExam;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Validators.Exam
{
    public class UpdateStudentValidator : AbstractValidator<StudentDTO>
    {
        public UpdateStudentValidator()
        {
            RuleFor(x => x.Name)
                               .NotEmpty().WithMessage("Name boş ola bilməz!")
                               .MaximumLength(30).WithMessage("Name uzunluğu 30 simvoldan artıq ola bilməz!");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname boş ola bilməz!")
                .MaximumLength(30).WithMessage("Surname uzunluğu 30 simvoldan artıq ola bilməz!");
            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("Number boş ola bilməz!")
                .ScalePrecision(0, 5).WithMessage("Number formatı düzgün deyil! (ən çox 5 rəqəm olmalıdır)");
            RuleFor(x => x.Class)
                .NotEmpty().WithMessage("Class boş ola bilməz!")
                .InclusiveBetween(0, 99).WithMessage("Class 0 ilə 99 arasında olmalıdır!");
        }
    }
}
