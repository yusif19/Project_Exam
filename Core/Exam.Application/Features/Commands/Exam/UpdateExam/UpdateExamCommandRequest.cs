using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Application.Features.Commands.Exam.UpdateExam;
using System.ComponentModel.DataAnnotations.Schema;
using Exam.Application.DTO;

namespace Exam.Application.Features.Commands.Exam.UpdateExam
{
    public class UpdateExamCommandRequest : IRequest<UpdateExamCommandResponse>
    {
        public ExamDTOv2 Exam { get; set; }

    }
}
