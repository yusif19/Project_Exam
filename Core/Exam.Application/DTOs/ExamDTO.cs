
using Exam.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Exam.Application.DTO;

public class ExamDTO:BaseDTO
{
    [Required(ErrorMessage = "Bu field boş ola bilməz!")]
    public int LessonId { get; set; }
    [Required(ErrorMessage = "Bu field boş ola bilməz!")]

    public int StudentId { get; set; }
    [Required(ErrorMessage = "Bu field boş ola bilməz!")]

    public string Lesson { get; set; }
    [Required(ErrorMessage = "Bu field boş ola bilməz!")]

    public string Student { get; set; }
    [Required(ErrorMessage = "Bu field boş ola bilməz!")]


    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Bu field boş ola bilməz!")]


    public decimal Grade { get; set; }
 
}
