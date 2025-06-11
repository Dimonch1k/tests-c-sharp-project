using product_project_for_tests.Data;
using product_project_for_tests.DTOs;
using product_project_for_tests.Models;
using Microsoft.EntityFrameworkCore;

namespace product_project_for_tests.Services;

public class ProductService
{
  private readonly AppDbContext _context;

  public ProductService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<List<ProductDto>> GetAllAsync()
  {
    return await _context.Products
      .Select(p => new ProductDto
      {
        Id = p.Id,
        Name = p.Name,
        Price = p.Price,
        InStock = p.InStock
      }).ToListAsync();
  }

  public async Task<ProductDto?> GetByIdAsync(int id)
  {
    Product? product = await _context.Products.FindAsync(id);

    if (product == null)
    {
      return null;
    }

    return new ProductDto
    {
      Id = product.Id,
      Name = product.Name,
      Price = product.Price,
      InStock = product.InStock
    };
  }

  public async Task<ProductDto> CreateAsync(CreateProductDto dto)
  {
    var product = new Product
    {
      Name = dto.Name,
      Price = dto.Price,
      InStock = dto.InStock
    };

    _context.Products.Add(product);
    await _context.SaveChangesAsync();

    return new ProductDto
    {
      Id = product.Id,
      Name = product.Name,
      Price = product.Price,
      InStock = product.InStock
    };
  }

  public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
  {
    Product? product = await _context.Products.FindAsync(id);

    if (product == null)
    {
      return false;
    }

    if (dto.Name != null)
    {
      product.Name = dto.Name;
    }

    if (dto.Price.HasValue)
    {
      product.Price = dto.Price.Value;
    }

    if (dto.InStock.HasValue)
    {
      product.InStock = dto.InStock.Value;
    }

    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    Product? product = await _context.Products.FindAsync(id);
    if (product == null)
    {
      return false;
    }

    _context.Products.Remove(product);

    await _context.SaveChangesAsync();

    return true;
  }
}