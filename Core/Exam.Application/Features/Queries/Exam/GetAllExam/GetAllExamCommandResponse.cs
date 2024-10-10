using Exam.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.GetAllExam
{
    public class GetAllExamCommandResponse
    {
        public List<ExamDTO> Exams { get; set; }
    }
}
