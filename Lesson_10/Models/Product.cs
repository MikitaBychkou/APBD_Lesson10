using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson_10.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("PK_product")]
    public int ProductId { get; set; }
    
    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string ProductName { get; set; }
    
    [Required]
    [Column("weight", TypeName = "decimal(5,2)")]
    public decimal ProductWeight { get; set; }
    
    [Required]
    [Column("width", TypeName = "decimal(5,2)")]
    public decimal ProductWidth { get; set; }
    
    
    [Required]
    [Column("height", TypeName = "decimal(5,2)")]
    public decimal ProductHeight { get; set; }
    
    [Required]
    [Column("depth", TypeName = "decimal(5,2)")]
    public decimal ProductDepth { get; set; }
    
    public ICollection<ShoppingCart> ShoppingCarts { get; set; }

    public ICollection<Category> Categories { get; set; }

}