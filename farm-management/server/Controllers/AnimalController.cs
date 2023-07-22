using Microsoft.AspNetCore.Mvc;
using server.Model;
using server.Services;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{
    private readonly AnimalService _service;

    public AnimalController(AnimalService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<AnimalModel> Get()
    {
        return _service.List();
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AnimalModel model)
    {
        // TODO: Move to a middleware
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response = await _service.CreateAsync(model);
        if (!response.Success)
        {
            if (response.ErrorMessage == "already-exists")
            {
                ModelState.TryAddModelError(nameof(AnimalModel.Name), "An animal with this name already exists");
                return BadRequest(ModelState);
            }
            return BadRequest(response.ErrorMessage);
        }
        return Ok(response.Data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return Ok(result);
    }
}
