using AutoMapper;
using Exam.Application.Repositories.Student;
using MediatR;
using Student.Application.Features.Commands.Student.UpdateStudent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Student.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommandRequest,UpdateStudentCommandResponse>
    {
        private readonly IStudentWriteRepository _StudentWriteRepository;
        private readonly IStudentReadRepository _StudentReadRepository;
        private readonly IMapper _mapper;
        public UpdateStudentCommandHandler(IStudentWriteRepository StudentWriteRepository, IMapper mapper, IStudentReadRepository StudentReadRepository = null)
        {
            _StudentWriteRepository = StudentWriteRepository;
            _mapper = mapper;
            _StudentReadRepository = StudentReadRepository;
        }
        public async Task<UpdateStudentCommandResponse> Handle(UpdateStudentCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Student StudentEntity = await _StudentReadRepository.GetByIdAsync(request.Student.Id);

            if (StudentEntity == null)
            {
                return new UpdateStudentCommandResponse { Success = false, Message = "Student not found." };
            }

            _mapper.Map(request.Student, StudentEntity);


            await _StudentWriteRepository.Update(StudentEntity);
            await _StudentWriteRepository.SaveAsync();
            return new UpdateStudentCommandResponse { Success = true };
        }
             
    }
}
