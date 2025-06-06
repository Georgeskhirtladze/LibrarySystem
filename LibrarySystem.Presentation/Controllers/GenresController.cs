using LibrarySystem.Application.Services;
using LibrarySystem.Domain.Enteties;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly GenreService _service;

    public GenresController(GenreService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Genre genre)
    {
        await _service.AddAsync(genre);
        return Ok(new { message = "Genre created." });
    }
}
