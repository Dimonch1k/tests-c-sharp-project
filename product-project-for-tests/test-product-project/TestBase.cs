using Microsoft.EntityFrameworkCore;
using product_project_for_tests.Data;

namespace test_product_project;

public class TestBase : IDisposable
{
  protected readonly AppDbContext _dbContext;
  private readonly SqliteConnection _sqliteConnection;

  public TestBase()
  {
    _sqliteConnection = new SqliteConnection("DataSource=:memory:");
    _sqliteConnection.Open();

    var option = new DbContextOptionsBuilder().UseSqlite(_sqliteConnection).Options;

    _dbContext.Database.EnsureCreated();
  }

  public void Dispose()
  {
    _dbContext.Dispose();
    _sqliteConnection.Dispose();
  }
}