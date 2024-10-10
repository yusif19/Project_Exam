using AutoMapper;
using Exam.Application.Repositories.Exam;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.CreateExam
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommandRequest, CreateExamCommandResponse>
    {
        readonly IExamWriteRepository _ExamWriteRepository;
        readonly IMapper _mapper;
        public CreateExamCommandHandler(IExamWriteRepository repository, IMapper mapper = null)
        {
            _ExamWriteRepository = repository;
            _mapper = mapper;
        }
        public async Task<CreateExamCommandResponse> Handle(CreateExamCommandRequest request, CancellationToken cancellationToken)
        {
            var obj = _mapper.Map<Domain.Entities.Exam>(request);
            var rs = await _ExamWriteRepository.AddAsync(obj);
            await _ExamWriteRepository.SaveAsync();
            CreateExamCommandResponse response = new CreateExamCommandResponse()
            {
                Success = true
            };
            return response;
        }
             
    }
}
