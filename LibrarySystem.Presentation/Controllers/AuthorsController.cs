using LibrarySystem.Application.Services;
using LibrarySystem.Domain.Enteties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LibrarySystem.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly AuthorService _service;

    public AuthorsController(AuthorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var author = await _service.GetByIdAsync(id);
        return author == null ? NotFound() : Ok(author);
    }
    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Author author)
    {
        if (DateTime.Now.Year - author.BirthDate.Year < 18)
            return BadRequest("Author must be at least 18 years old.");

        await _service.AddAsync(author);
        return Ok(new { message = "Author created." });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Author author)
    {
        if (id != author.Id) return BadRequest();
        await _service.UpdateAsync(author);
        return Ok(new { message = "Author updated." });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _service.GetByIdAsync(id);
        if (existing == null) return NotFound();

        await _service.DeleteAsync(existing);
        return Ok(new { message = "Author deleted." });
    }
}
