using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Exam.Application.Features.Commands.Student.CreateStudent;
using Exam.Application.Repositories.Student;
using Exam.Application.Features.Commands.Exam.GetAllExam;
using Exam.Application.Features.Commands.Exam.GetAllLesson;
using Exam.Application.Repositories.Lesson;

namespace Exam.Application.Features.Commands.Student.GetAllStudent
{
    public class GetAllStudentCommandHandler : IRequestHandler<GetAllStudentCommandRequest, GetAllStudentCommandResponse>
    {
        readonly IStudentReadRepository _studentReadRepository;
        public GetAllStudentCommandHandler(IStudentReadRepository repository)
        {
            _studentReadRepository = repository;
        }
        public async Task<GetAllStudentCommandResponse> Handle(GetAllStudentCommandRequest request, CancellationToken cancellationToken)
        {



            var students = _studentReadRepository.GetAll();


            GetAllStudentCommandResponse response = new GetAllStudentCommandResponse()
            {
                Students = students
            };

            
            return response;
        }
             
    }
}
