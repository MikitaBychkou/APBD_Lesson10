using Lesson_10.Context;
using Lesson_10.Exceptions;
using Lesson_10.Models;
using Lesson_10.RequestModel;
using Microsoft.EntityFrameworkCore;

namespace Lesson_10.Services;


public interface IDbService
{
    Task<GetAccountResponseModel> GetAccountByIdAsync(int id, CancellationToken cancellationToken);
    Task<Product> AddProductAsync(PostProductRequestModel requestModel, CancellationToken cancellationToken);
    
}

public class DbService(DatabaseContext _context) : IDbService
{
    public async Task<GetAccountResponseModel> GetAccountByIdAsync(int id, CancellationToken cancellationToken)
    {
        var account = await _context.Accounts
            .Include(a => a.Role)
            .Include(a => a.ShoppingCarts)
                .ThenInclude(sc => sc.Product)
            .FirstOrDefaultAsync(a => a.AccountID==id, cancellationToken);

        if (account == null)
        {
            throw new NotFoundException($"Account with id:{id} does not exist");
        }

        var response = new GetAccountResponseModel
        {
            FirstName = account.FirstName,
            LastName = account.LastName,
            Email = account.Email,
            Phone = account.Phone,
            Role = account.Role.RoleName,
            Cart = account.ShoppingCarts.Select(sc => new GetProductResponseModel
            {
                ProductId = sc.ProductId,
                ProductName = sc.Product.ProductName,
                Amount = sc.ShoppingCartAmount
            }).ToList()
        };
        
        return response;
    }
    
    public async Task<Product> AddProductAsync(PostProductRequestModel request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            ProductName = request.ProductName,
            ProductWeight = request.ProductWeight,
            ProductWidth = request.ProductWidth,
            ProductHeight = request.ProductHeight,
            ProductDepth = request.ProductDepth,
            Categories = new List<Category>()
        };

        foreach (var categoryId in request.ProductCategories)
        {
            var category = await _context.Categories.FindAsync(new object[] { categoryId }, cancellationToken);
            if (category == null)
            {
                throw new NotFoundException($"Category with id {categoryId} does not exist.");
            }
            
            product.Categories.Add(category);
            
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);
        
        return product;
    }
}