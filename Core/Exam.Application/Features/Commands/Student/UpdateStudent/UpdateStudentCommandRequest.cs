using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Application.Features.Commands.Student.UpdateStudent;
using Exam.Application.DTO;

namespace Student.Application.Features.Commands.Student.UpdateStudent
{
    public class UpdateStudentCommandRequest : IRequest<UpdateStudentCommandResponse>
    {
        public StudentDTO Student { get; set; }

    }
}
