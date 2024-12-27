using Domain.Entities;
using Infrastructore.Responses;

namespace Infrastructore.Interfaces;

public interface IProductService 
{
    Task<Response<List<Product>>> GetProductsAsync();
    Task<Response<Product>> GetProductByIdAsync(int id);
    Task<Response<string>> AddProductAsync(Product product);
    Task<Response<string>> UpdateProductAsync(Product product);
    Task<Response<string>> DeleteProductAsync(int id);
}