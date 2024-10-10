using Exam.Application.Features.Commands.Exam.CreateExam;
using Exam.Application.Repositories.Exam;
using Exam.Application.Repositories.Lesson;
using Exam.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.GetAllLesson
{
    public class GetAllLessonCommandHandler : IRequestHandler<GetAllLessonCommandRequest, GetAllLessonCommandResponse>
    {
        readonly ILessonReadRepository _lessonReadRepository;

        public GetAllLessonCommandHandler(ILessonReadRepository lessonReadRepository)
        {
            _lessonReadRepository = lessonReadRepository;
        }

        
        public async Task<GetAllLessonCommandResponse> Handle(GetAllLessonCommandRequest request, CancellationToken cancellationToken)
        {


            var lessons =  _lessonReadRepository.GetAll();


            GetAllLessonCommandResponse response = new GetAllLessonCommandResponse()
            {
                Lessons = lessons
            };
                
            return response;
        }
             
    }
}
