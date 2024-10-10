using AutoMapper;
using Exam.Application.DTO;
using Exam.Application.Features.Commands.Exam.CreateExam;
using Exam.Application.Features.Commands.Exam.UpdateExam;
using Exam.Application.Repositories.Exam;
using Exam.Application.Repositories.Lesson;
using Exam.Application.Repositories.Student;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.GetByIdExam
{
    public class GetByIdStudentCommandHandler : IRequestHandler<GetByIdStudentCommandRequest, GetByIdStudentCommandResponse>
    {
        private readonly IStudentReadRepository _StudentReadRepository;
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly ILessonReadRepository _lessonReadRepository;
        private readonly IMapper _mapper;

        public GetByIdStudentCommandHandler(IStudentReadRepository repository, IMapper mapper, IStudentReadRepository studentReadRepository = null, ILessonReadRepository lessonReadRepository = null)
        {
            _StudentReadRepository = repository;
            _mapper = mapper;
            _studentReadRepository = studentReadRepository;
            _lessonReadRepository = lessonReadRepository;
        }

        public async Task<GetByIdStudentCommandResponse> Handle(GetByIdStudentCommandRequest request, CancellationToken cancellationToken)
        {
            var StudentData = await _StudentReadRepository.GetByIdAsync(request.Id,s=>s.Exams);
            if (StudentData == null)
            {
                return null; 
            }
            var updateStudentRequest = new Application.DTO.StudentDTO();
            var obj = _mapper.Map<StudentDTO>(StudentData);
            updateStudentRequest = obj;

            var response = new GetByIdStudentCommandResponse
            {
                Student = obj,
                Exams= StudentData.Exams,
            };
            return response;
        }
    }
}
