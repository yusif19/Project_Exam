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
    public class UpdateExamValidator : AbstractValidator<ExamDTO>
    {
        public UpdateExamValidator()
        {
            RuleFor(x => x.LessonId).NotEmpty().WithMessage("LessonId boş ola bilməz!");
            RuleFor(x => x.StudentId).NotEmpty().WithMessage("StudentId boş ola bilməz!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarix boş ola bilməz!");
            RuleFor(x => x.Grade)
                .InclusiveBetween(0, 9).WithMessage("Grade 0 ilə 9 arasında olmalıdır!")
                .NotEmpty().WithMessage("Grade boş ola bilməz!");
        }
    }
}
