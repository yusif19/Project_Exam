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
    public class GetByIdExamCommandHandler : IRequestHandler<GetByIdExamCommandRequest, GetByIdExamCommandResponse>
    {
        private readonly IExamReadRepository _ExamReadRepository;
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly ILessonReadRepository _lessonReadRepository;
        private readonly IMapper _mapper;

        public GetByIdExamCommandHandler(IExamReadRepository repository, IMapper mapper, IStudentReadRepository studentReadRepository = null, ILessonReadRepository lessonReadRepository = null)
        {
            _ExamReadRepository = repository;
            _mapper = mapper;
            _studentReadRepository = studentReadRepository;
            _lessonReadRepository = lessonReadRepository;
        }

        public async Task<GetByIdExamCommandResponse> Handle(GetByIdExamCommandRequest request, CancellationToken cancellationToken)
        {
            // İmtahan məlumatını al
            var examData = await _ExamReadRepository.GetByIdAsync(request.Id,e=>e.Lesson,e=>e.Student);

            // Məlumat boşdursa null geri qaytar
            if (examData == null)
            {
                return null; // Controller-də uyğun işlənilsin
            }

            // UpdateExamCommandRequest modelini doldururuq
            var updateExamRequest = new Application.DTO.ExamDTOv2
            {
                Id = examData.Id,
                LessonId=examData.Lesson.Id,
                
                StudentId =examData.Student.Id,
                Date = examData.Date,
                Grade = examData.Grade
            };
            //var lesson = await _lessonReadRepository.GetByIdAsync(examData.LessonId);
            //var student = await _studentReadRepository.GetByIdAsync(examData.StudentId);
            var students = await _studentReadRepository.GetAll().ToListAsync();
            var lessons = await _lessonReadRepository.GetAll().ToListAsync();

            // GetByIdExamCommandResponse obyekti yaratmaq
            var response = new GetByIdExamCommandResponse
            {
                Exam = updateExamRequest,
                Students=students,
                Lessons=lessons,
                LessonName= examData.Lesson.Name,
                StudentName= examData.Student.Name,
            };

            // Response geri qaytarılır
            return response;
        }
    }
}
