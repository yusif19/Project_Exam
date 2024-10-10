using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.GetAllLesson
{
    public class GetAllLessonCommandResponse
    {
        public IQueryable<Domain.Entities.Lesson> Lessons { get; set; }

    }
}
