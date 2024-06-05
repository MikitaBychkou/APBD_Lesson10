using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson_10.Models;

[Table("Categories")]
public class Category
{
    [Key]
    [Column("PK_categories")]
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string CategoryName { get; set; }

    public ICollection<Product> Products { get; set; }
}