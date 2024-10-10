using Exam.Application.DTO;
using Exam.Application.Features.Commands.Exam.UpdateExam;
using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.GetAllExamAndStudent
{
    public class GetAllLessonAndStudentCommandResponse
    {
        public List<Domain.Entities.Lesson> Lessons { get; set; }
        public List<Domain.Entities.Student> Students { get; set; }

    }
}
