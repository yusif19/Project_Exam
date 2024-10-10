
using Exam.Application.DTO;

namespace Exam.Application.DTO;

public class ExamDTOv2:BaseDTO
{
    public int LessonId { get; set; }

    public int StudentId { get; set; }
    //public string? LessonName { get; set; }


    //public Domain.Entities.Student Student { get; set; }
    //public string? StudentName { get; set; }
    public DateTime Date { get; set; }

    public decimal Grade { get; set; }
}
