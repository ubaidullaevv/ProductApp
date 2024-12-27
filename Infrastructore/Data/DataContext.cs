using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructore.Data;


public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
public DbSet<Product>? Products { get; set; }
}