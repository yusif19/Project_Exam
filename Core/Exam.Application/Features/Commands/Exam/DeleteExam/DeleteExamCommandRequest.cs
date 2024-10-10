using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Exam.DeleteExam
{
    public class DeleteExamCommandRequest : IRequest<DeleteExamCommandResponse>
    {
        public long Id { get; set; }
    }
}
