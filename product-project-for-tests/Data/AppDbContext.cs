using Microsoft.EntityFrameworkCore;
using product_project_for_tests.Models;

namespace product_project_for_tests.Data;

public class AppDbContext : DbContext
{
  public AppDbContext( DbContextOptions<AppDbContext> options ) : base( options ) { }

  public DbSet<Product> Products => Set<Product>();
}
