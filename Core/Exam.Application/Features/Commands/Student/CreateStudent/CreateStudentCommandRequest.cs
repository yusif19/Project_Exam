using Exam.Application.DTO;
using Exam.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Student.CreateStudent
{
    public class CreateStudentCommandRequest : IRequest<CreateStudentCommandResponse>
    {
        public StudentDTO Student { get; set; }
    }
}
