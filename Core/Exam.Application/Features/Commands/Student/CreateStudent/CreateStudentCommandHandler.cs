using AutoMapper;
using Exam.Application.Repositories.Student;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Student.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommandRequest, CreateStudentCommandResponse>
    {
        readonly IStudentWriteRepository _StudentWriteRepository;
        readonly IMapper _mapper;
        public CreateStudentCommandHandler(IStudentWriteRepository repository, IMapper mapper = null)
        {
            _StudentWriteRepository = repository;
            _mapper = mapper;
        }
        public async Task<CreateStudentCommandResponse> Handle(CreateStudentCommandRequest request, CancellationToken cancellationToken)
        {
            var obj = _mapper.Map<Domain.Entities.Student>(request.Student);
            var rs = await _StudentWriteRepository.AddAsync(obj);
            await _StudentWriteRepository.SaveAsync();
            CreateStudentCommandResponse response = new CreateStudentCommandResponse()
            {
                Success = true
            };
            return response;
        }
             
    }
}
