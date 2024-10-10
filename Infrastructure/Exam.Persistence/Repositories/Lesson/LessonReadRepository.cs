using Exam.Application.Repositories.Lesson;
using Exam.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistence.Repositories.Lesson
{
    public class LessonReadRepository : ReadRepository<Domain.Entities.Lesson>, ILessonReadRepository
    {
        public LessonReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
