
using Domain.Entities;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductControler(IProductService service):ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> AddProduct([FromBody] Product product) => await service.AddProductAsync(product);
    [HttpGet]
    public async Task<Response<List<Product>>> GetAll() => await service.GetProductsAsync();
    [HttpGet("get-by-id")]
    public async Task<Response<Product>> GetById(int id) => await service.GetProductByIdAsync(id);
    [HttpPut]
    public async Task<Response<string>> UpdateProduct(Product product) => await service.UpdateProductAsync(product);
    [HttpDelete]
    public async Task<Response<string>> DeleteProduct(int id) => await service.DeleteProductAsync(id);
}