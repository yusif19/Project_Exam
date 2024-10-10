using Exam.Application.Repositories.Lesson;
using Exam.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistence.Repositories.Lesson
{
    public class LessonWriteRepository : WriteRepository<Domain.Entities.Lesson>, ILessonWriteRepository
    {
        public LessonWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
