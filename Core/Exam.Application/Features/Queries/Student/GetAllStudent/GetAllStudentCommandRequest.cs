using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Application.Features.Commands.Exam.GetAllExam;

namespace Exam.Application.Features.Commands.Student.CreateStudent
{
    public class GetAllStudentCommandRequest : IRequest<GetAllStudentCommandResponse>
    {
       
    }
}
