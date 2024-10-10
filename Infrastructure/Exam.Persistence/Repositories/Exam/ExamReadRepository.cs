using Exam.Application.Repositories.Exam;
using Exam.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistence.Repositories.Exam
{
    public class ExamReadRepository : ReadRepository<Domain.Entities.Exam>, IExamReadRepository
    {
        public ExamReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
