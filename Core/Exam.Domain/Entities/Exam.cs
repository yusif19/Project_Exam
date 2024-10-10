using Exam.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Domain.Entities;

public class Exam:BaseEntity
{
    [ForeignKey("LessonId")]

    public int LessonId { get; set; }

    public Lesson Lesson { get; set; }
    [ForeignKey("StudentId")]

    public int StudentId { get; set; } 

    public Student Student { get; set; }

    public DateTime Date { get; set; }

    [Column(TypeName = "decimal(1, 0)")]
    public decimal Grade { get; set; }   
}
