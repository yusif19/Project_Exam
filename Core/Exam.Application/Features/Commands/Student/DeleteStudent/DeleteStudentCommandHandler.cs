using Exam.Application.Repositories.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Exam.Application.Repositories.Student;
using Exam.Application.Features.Commands.Student.DeleteStudent;

namespace Student.Application.Features.Commands.Student.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommandRequest, DeleteStudentCommandResponse>
    {
        readonly IStudentWriteRepository _StudentWriteRepository;
        readonly IStudentReadRepository _StudentReadRepository;
        public DeleteStudentCommandHandler(IStudentWriteRepository repository, IStudentReadRepository StudentReadRepository = null)
        {
            _StudentWriteRepository = repository;
            _StudentReadRepository = StudentReadRepository;
        }
        public async Task<DeleteStudentCommandResponse> Handle(DeleteStudentCommandRequest request, CancellationToken cancellationToken)
        {
            var Student = await _StudentReadRepository.GetByIdAsync(request.Id);
            _StudentWriteRepository.Remove(Student);
            await _StudentWriteRepository.SaveAsync();
            DeleteStudentCommandResponse response = new DeleteStudentCommandResponse()
            {
                Mesagge = "ok"
            };
            return response;
        }
             
    }
}
