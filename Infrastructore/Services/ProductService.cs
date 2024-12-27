using Domain.Entities;
using Infrastructore.Data;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructore.Services;

public class ProductService(DataContext context) : IProductService
{
    public async Task<Response<string>> AddProductAsync(Product product)
    {
        await context.Products.AddAsync(product);
        int res=await context.SaveChangesAsync();
        if(res==0) return new Response<string>(HttpStatusCode.InternalServerError,"Cannot add product!");
        return new Response<string>(HttpStatusCode.Created, "Product added successfully!");
    }

    public async Task<Response<string>> DeleteProductAsync(int id)
    {
        var exist= await context.Products.FirstOrDefaultAsync(x=>x.Id==id);
        if(exist==null) return new Response<string>("Product not found!");
        context.Products.Remove(exist);
        int res=await context.SaveChangesAsync();
        if(res==0) return new Response<string>(HttpStatusCode.InternalServerError,"Cannot delete product!");
        return new Response<string>("Product deleted successfully!");
    }

    public async Task<Response<Product>> GetProductByIdAsync(int id)
    {
        var product= await context.Products.FirstOrDefaultAsync(x=>x.Id==id);
        if(product==null) return new Response<Product>(HttpStatusCode.NotFound,"Product not found!");
        return new Response<Product>(product);
    }

    public async Task<Response<List<Product>>> GetProductsAsync()
    {
        var products= await context.Products.ToListAsync();
        return new Response<List<Product>>(products);
    }

    public async Task<Response<string>> UpdateProductAsync(Product product)
    {
        var exist= await context.Products.FirstOrDefaultAsync(x=>x.Id == product.Id);
        if(exist==null)return new Response<string>(HttpStatusCode.NotFound,"Product not found!");
        exist.Category=product.Category;
        exist.Name=product.Name;
        exist.Price=product.Price;
        int res=await context.SaveChangesAsync();
        if(res==0)return new Response<string>(HttpStatusCode.InternalServerError,"Cannot update product!");
        return new Response<string>("Product updated successfully!");
    }
}
