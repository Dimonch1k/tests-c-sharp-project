using Microsoft.EntityFrameworkCore;
using product_project_for_tests.Data;
using product_project_for_tests.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder( args );

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>( options =>
  options.UseNpgsql( builder.Configuration.GetConnectionString( "DefaultConnection" ) ) );
builder.Services.AddScoped<ProductService>();

builder.Services.AddEndpointsApiExplorer();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();