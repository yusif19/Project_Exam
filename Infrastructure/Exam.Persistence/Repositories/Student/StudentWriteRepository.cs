using Exam.Application.Repositories.Student;
using Exam.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistence.Repositories.Student
{
    public class StudentWriteRepository : WriteRepository<Domain.Entities.Student>, IStudentWriteRepository
    {
        public StudentWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
