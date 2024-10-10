using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Lesson.DeleteLesson
{
    public class DeleteLessonCommandRequest : IRequest<DeleteLessonCommandResponse>
    {
        public long Id { get; set; }
    }
}
