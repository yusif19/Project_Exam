using Exam.Application.DTO;
using Exam.Application.Features.Commands.Exam.UpdateExam;
using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.GetByIdExam
{
    public class GetByIdStudentCommandResponse
    {
         public ICollection<Domain.Entities.Exam>? Exams { get; set; }
        public Application.DTO.StudentDTO Student { get; set; }

    }
}
