// Controllers/ProductController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private static List<Product> _products = new List<Product>();

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
        _products.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }
}
