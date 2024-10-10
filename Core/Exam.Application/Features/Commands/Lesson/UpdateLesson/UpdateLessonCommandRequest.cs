using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Application.Features.Commands.Lesson.UpdateLesson;
using Exam.Application.DTO;

namespace Lesson.Application.Features.Commands.Lesson.UpdateLesson
{
    public class UpdateLessonCommandRequest : IRequest<UpdateLessonCommandResponse>
    {
        public LessonDTO Lesson { get; set; }

    }
}
