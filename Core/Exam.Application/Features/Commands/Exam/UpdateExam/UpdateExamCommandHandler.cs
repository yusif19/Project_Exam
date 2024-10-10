using AutoMapper;
using Exam.Application.Repositories.Exam;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.UpdateExam
{
    public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommandRequest,UpdateExamCommandResponse>
    {
        private readonly IExamWriteRepository _examWriteRepository;
        private readonly IExamReadRepository _examReadRepository;
        private readonly IMapper _mapper;
        public UpdateExamCommandHandler(IExamWriteRepository examWriteRepository, IMapper mapper, IExamReadRepository examReadRepository = null)
        {
            _examWriteRepository = examWriteRepository;
            _mapper = mapper;
            _examReadRepository = examReadRepository;
        }
        public async Task<UpdateExamCommandResponse> Handle(UpdateExamCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Exam examEntity = await _examReadRepository.GetByIdAsync(request.Exam.Id);

            if (examEntity == null)
            {
                return new UpdateExamCommandResponse { Success = false, Message = "Exam not found." };
            }

            _mapper.Map(request.Exam, examEntity);


            await _examWriteRepository.Update(examEntity);
            await _examWriteRepository.SaveAsync();
            return new UpdateExamCommandResponse { Success = true };
        }
             
    }
}
