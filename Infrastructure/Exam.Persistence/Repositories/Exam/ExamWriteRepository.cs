using Exam.Application.Repositories.Exam;
using Exam.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistence.Repositories.Exam
{
    public class ExamWriteRepository : WriteRepository<Domain.Entities.Exam>, IExamWriteRepository
    {
        public ExamWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
