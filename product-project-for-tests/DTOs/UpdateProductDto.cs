namespace product_project_for_tests.DTOs;

public class UpdateProductDto
{
  public string? Name { get; set; }

  public decimal? Price { get; set; }
  
  public bool? InStock { get; set; }
}