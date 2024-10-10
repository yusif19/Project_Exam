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
    public class GetByIdExamCommandResponse
    {
        public Application.DTO.ExamDTOv2 Exam { get; set; }
        public string? LessonName { get; set; }
        public string? StudentName { get; set; }
        public List<Domain.Entities.Lesson> Lessons { get; set; }
        public List<Domain.Entities.Student> Students { get; set; }

    }
}
