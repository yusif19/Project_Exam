using Exam.Application.Repositories.Exam;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.DeleteExam
{
    public class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommandRequest, DeleteExamCommandResponse>
    {
        readonly IExamWriteRepository _ExamWriteRepository;
        readonly IExamReadRepository _ExamReadRepository;
        public DeleteExamCommandHandler(IExamWriteRepository repository, IExamReadRepository ExamReadRepository = null)
        {
            _ExamWriteRepository = repository;
            _ExamReadRepository = ExamReadRepository;
        }
        public async Task<DeleteExamCommandResponse> Handle(DeleteExamCommandRequest request, CancellationToken cancellationToken)
        {
            var Exam = await _ExamReadRepository.GetByIdAsync(request.Id);
            _ExamWriteRepository.Remove(Exam);
            await _ExamWriteRepository.SaveAsync();
            DeleteExamCommandResponse response = new DeleteExamCommandResponse()
            {
                Mesagge = "ok"
            };
            return response;
        }
             
    }
}
