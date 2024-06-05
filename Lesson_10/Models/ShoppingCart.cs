using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace Lesson_10.Models;


[Table("Shopping_Carts")]
[PrimaryKey(nameof(AccountId), nameof(ProductId))]
public class ShoppingCart
{
    [Column("FK_account")]
    [ForeignKey(nameof(Account))]
    public int AccountId { get; set; }
    public Account Account { get; set; }
    
    [Column("FK_product")]
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    [Required]
    [Column("amount")]
    public int ShoppingCartAmount { get; set; }
}