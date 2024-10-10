using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Features.Commands.Student.DeleteStudent
{
    public class DeleteStudentCommandRequest : IRequest<DeleteStudentCommandResponse>
    {
        public long Id { get; set; }
        //public List<StudentImage>? StudentImages { get; set; }
    }
}
