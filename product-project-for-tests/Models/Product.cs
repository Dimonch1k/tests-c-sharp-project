﻿namespace product_project_for_tests.Models;

public class Product
{
  public int Id { get; set; }

  public string Name { get; set; } = null!;

  public decimal Price { get; set; }

  public bool InStock { get; set; }
}