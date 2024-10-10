using Exam.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.CreateExam
{
    public class CreateExamCommandRequest : IRequest<CreateExamCommandResponse>
    {
        [ForeignKey("LessonId")]
        public int LessonId { get; set; }
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(1, 0)")]
        public decimal Grade { get; set; }
    }
}
