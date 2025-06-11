using Microsoft.AspNetCore.Mvc;
using product_project_for_tests.DTOs;
using product_project_for_tests.Services;

namespace product_project_for_tests.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
  private readonly ProductService _service;

  public ProductController(ProductService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<ActionResult<List<ProductDto>>> GetAll()
  {
    return Ok(await _service.GetAllAsync());
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<ProductDto>> GetById(int id)
  {
    ProductDto? product = await _service.GetByIdAsync(id);
    if (product == null)
    {
      return NotFound();
    }

    return Ok(product);
  }

  [HttpPost]
  public async Task<ActionResult<ProductDto>> Create(CreateProductDto dto)
  {
    ProductDto product = await _service.CreateAsync(dto);
    return CreatedAtAction(nameof(GetById), new { id = product.Id }, product );
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, UpdateProductDto dto)
  {
    bool success = await _service.UpdateAsync(id, dto);
    if (!success)
    {
      return NotFound();
    }

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    bool success = await _service.DeleteAsync(id);
    if (!success)
    {
      return NotFound();
    }

    return NoContent();
  }
}