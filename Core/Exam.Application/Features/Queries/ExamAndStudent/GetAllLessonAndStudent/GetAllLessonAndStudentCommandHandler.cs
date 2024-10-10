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

namespace Exam.Application.Features.Commands.Exam.GetAllExamAndStudent
{
    public class GetAllLessonAndStudentCommandHandler : IRequestHandler<GetAllLessonAndStudentCommandRequest, GetAllLessonAndStudentCommandResponse>
    {
        private readonly IExamReadRepository _ExamReadRepository;
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly ILessonReadRepository _lessonReadRepository;
        private readonly IMapper _mapper;

        public GetAllLessonAndStudentCommandHandler(IExamReadRepository repository, IMapper mapper, IStudentReadRepository studentReadRepository = null, ILessonReadRepository lessonReadRepository = null)
        {
            _ExamReadRepository = repository;
            _mapper = mapper;
            _studentReadRepository = studentReadRepository;
            _lessonReadRepository = lessonReadRepository;
        }

        public async Task<GetAllLessonAndStudentCommandResponse> Handle(GetAllLessonAndStudentCommandRequest request, CancellationToken cancellationToken)
        {
            var students = await _studentReadRepository.GetAll().ToListAsync();
            var lessons = await _lessonReadRepository.GetAll().ToListAsync();
            var response = new GetAllLessonAndStudentCommandResponse
            {
                Students=students,
                Lessons=lessons
            };
            return response;
        }
    }
}
