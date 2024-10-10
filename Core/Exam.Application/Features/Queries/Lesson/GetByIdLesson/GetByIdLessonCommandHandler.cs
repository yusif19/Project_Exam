using AutoMapper;
using Exam.Application.DTO;
using Exam.Application.Features.Commands.Exam.CreateExam;
using Exam.Application.Features.Commands.Exam.UpdateExam;
using Exam.Application.Repositories.Exam;
using Exam.Application.Repositories.Lesson;
using Exam.Application.Repositories.Lesson;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.GetByIdExam
{
    public class GetByIdLessonCommandHandler : IRequestHandler<GetByIdLessonCommandRequest, GetByIdLessonCommandResponse>
    {
        private readonly ILessonReadRepository _LessonReadRepository;
        private readonly ILessonReadRepository _lessonReadRepository;
        private readonly IMapper _mapper;

        public GetByIdLessonCommandHandler(ILessonReadRepository repository, IMapper mapper, ILessonReadRepository LessonReadRepository = null, ILessonReadRepository lessonReadRepository = null)
        {
            _LessonReadRepository = repository;
            _mapper = mapper;
            _LessonReadRepository = LessonReadRepository;
            _lessonReadRepository = lessonReadRepository;
        }

        public async Task<GetByIdLessonCommandResponse> Handle(GetByIdLessonCommandRequest request, CancellationToken cancellationToken)
        {
            var LessonData = await _LessonReadRepository.GetByIdAsync(request.Id,s=>s.Exams);
            if (LessonData == null)
            {
                return null; 
            }
            var updateLessonRequest = new Application.DTO.LessonDTO();
            var obj = _mapper.Map<LessonDTO>(LessonData);
            updateLessonRequest = obj;

            var response = new GetByIdLessonCommandResponse
            {
                Lesson = obj,
                Exams= LessonData.Exams,
            };
            return response;
        }
    }
}
