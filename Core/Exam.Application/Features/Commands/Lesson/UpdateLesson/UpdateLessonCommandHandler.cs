using AutoMapper;
using Exam.Application.Repositories.Lesson;
using MediatR;
using Lesson.Application.Features.Commands.Lesson.UpdateLesson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Lesson.UpdateLesson
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommandRequest,UpdateLessonCommandResponse>
    {
        private readonly ILessonWriteRepository _LessonWriteRepository;
        private readonly ILessonReadRepository _LessonReadRepository;
        private readonly IMapper _mapper;
        public UpdateLessonCommandHandler(ILessonWriteRepository LessonWriteRepository, IMapper mapper, ILessonReadRepository LessonReadRepository = null)
        {
            _LessonWriteRepository = LessonWriteRepository;
            _mapper = mapper;
            _LessonReadRepository = LessonReadRepository;
        }
        public async Task<UpdateLessonCommandResponse> Handle(UpdateLessonCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Lesson LessonEntity = await _LessonReadRepository.GetByIdAsync(request.Lesson.Id);

            if (LessonEntity == null)
            {
                return new UpdateLessonCommandResponse { Success = false, Message = "Lesson not found." };
            }

            _mapper.Map(request.Lesson, LessonEntity);


            await _LessonWriteRepository.Update(LessonEntity);
            await _LessonWriteRepository.SaveAsync();
            return new UpdateLessonCommandResponse { Success = true };
        }
             
    }
}
