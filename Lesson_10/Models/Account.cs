using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lesson_10.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Column("PK_account")]
    public int AccountID { get; set; }
    
    [Required]
    [Column("first_name")]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [Column("last_name")]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [Column("email")]
    [MaxLength(80)]
    public string Email { get; set; }
    
    [Column("phone")]
    [MaxLength(9)]
    public string? Phone { get; set; }

    [Column("FK_role")]
    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }
    public Role Role { get; set; }

    public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    
}