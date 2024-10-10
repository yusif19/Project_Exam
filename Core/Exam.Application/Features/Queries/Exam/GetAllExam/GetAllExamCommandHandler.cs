using Exam.Application.DTO;
using Exam.Application.Features.Commands.Exam.CreateExam;
using Exam.Application.Repositories.Exam;
using Exam.Application.Repositories.Lesson;
using Exam.Application.Repositories.Student;
using Exam.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.GetAllExam
{
    public class GetAllExamCommandHandler : IRequestHandler<GetAllExamCommandRequest, GetAllExamCommandResponse>
    {
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly ILessonReadRepository _lessonReadRepository;
        readonly IExamReadRepository _examReadRepository;
        public GetAllExamCommandHandler(IExamReadRepository repository, ILessonReadRepository lessonReadRepository = null, IStudentReadRepository studentReadRepository = null)
        {
            _examReadRepository = repository;
            _lessonReadRepository = lessonReadRepository;
            _studentReadRepository = studentReadRepository;
        }
        public async Task<GetAllExamCommandResponse> Handle(GetAllExamCommandRequest request, CancellationToken cancellationToken)
        {


            var exams = _examReadRepository.GetAll(e=>e.Lesson,e=>e.Student);
            List<ExamDTO> dtos = new();
            foreach (var exam in exams) {
                ExamDTO dTO = new ExamDTO()
                {
                    Lesson = exam.Lesson.Name,
                    Student = exam.Student.Name,
                    Grade = exam.Grade,
                    Date = exam.Date,
                    Id= exam.Id,
                };
                dtos.Add(dTO);
            }
            GetAllExamCommandResponse response = new GetAllExamCommandResponse()
            {
                Exams=dtos
            };
            return response;
        }
             
    }
}
