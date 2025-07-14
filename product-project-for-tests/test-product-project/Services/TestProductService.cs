using Moq;
using product_project_for_tests.Data;
using product_project_for_tests.DTOs;
using product_project_for_tests.Models;
using product_project_for_tests.Services;

namespace test_product_project.Services;

public class TestProductService
{
  [Fact]
  public void TestGetAllAsync()
  {
    ProductService productService = new ProductService();

    Product product = new Product
    {
      Id = 1,
      Name = "Test",
      Price = 100,
      InStock = true,
    };
    
    
  }
}