
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exam.Application.DTO;

public class StudentDTO: BaseDTO
{
    [StringLength(30)]
    [Required(ErrorMessage = "Bu field boş ola bilməz!")]
    [MaxLength(30, ErrorMessage = "Uzunluq limiti aşılmışdır")]
    public string Name { get; set; }

    [StringLength(30)]
    [MaxLength(30, ErrorMessage = "Uzunluq limiti aşılmışdır")]
    [Required(ErrorMessage = "Bu field boş ola bilməz!")]
    public string Surname { get; set; }

    [Column(TypeName = "decimal(5, 0)")]
    [Required(ErrorMessage = "Bu field boş ola bilməz!")]
    public decimal Number { get; set; }


    [Column(TypeName = "decimal(2, 0)")]
    [Required(ErrorMessage = "Bu field boş ola bilməz!")]
    public decimal Class { get; set; }

}
