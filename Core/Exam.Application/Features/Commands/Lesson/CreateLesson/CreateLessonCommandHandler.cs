using AutoMapper;
using Exam.Application.Repositories.Lesson;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Lesson.CreateLesson
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommandRequest, CreateLessonCommandResponse>
    {
        readonly ILessonWriteRepository _LessonWriteRepository;
        readonly IMapper _mapper;
        public CreateLessonCommandHandler(ILessonWriteRepository repository, IMapper mapper = null)
        {
            _LessonWriteRepository = repository;
            _mapper = mapper;
        }
        public async Task<CreateLessonCommandResponse> Handle(CreateLessonCommandRequest request, CancellationToken cancellationToken)
        {
            var obj = _mapper.Map<Domain.Entities.Lesson>(request.Lesson);
            var rs = await _LessonWriteRepository.AddAsync(obj);
            await _LessonWriteRepository.SaveAsync();
            CreateLessonCommandResponse response = new CreateLessonCommandResponse()
            {
                Success = true
            };
            return response;
        }
             
    }
}
