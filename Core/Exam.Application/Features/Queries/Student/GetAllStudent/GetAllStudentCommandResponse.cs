using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.GetAllExam
{
    public class GetAllStudentCommandResponse
    {
        public IQueryable<Domain.Entities.Student> Students { get; set; }
    }
}
