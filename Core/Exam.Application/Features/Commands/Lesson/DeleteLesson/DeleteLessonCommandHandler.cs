using Exam.Application.Repositories.Lesson;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Exam.Application.Repositories.Lesson;
using Exam.Application.Features.Commands.Lesson.DeleteLesson;

namespace Lesson.Application.Features.Commands.Lesson.DeleteLesson
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommandRequest, DeleteLessonCommandResponse>
    {
        readonly ILessonWriteRepository _LessonWriteRepository;
        readonly ILessonReadRepository _LessonReadRepository;
        public DeleteLessonCommandHandler(ILessonWriteRepository repository, ILessonReadRepository LessonReadRepository = null)
        {
            _LessonWriteRepository = repository;
            _LessonReadRepository = LessonReadRepository;
        }
        public async Task<DeleteLessonCommandResponse> Handle(DeleteLessonCommandRequest request, CancellationToken cancellationToken)
        {
            var Lesson = await _LessonReadRepository.GetByIdAsync(request.Id);
            _LessonWriteRepository.Remove(Lesson);
            await _LessonWriteRepository.SaveAsync();
            DeleteLessonCommandResponse response = new DeleteLessonCommandResponse()
            {
                Mesagge = "ok"
            };
            return response;
        }
             
    }
}
