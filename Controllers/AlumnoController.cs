using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AlumnoController : ControllerBase
{
    private readonly AlumnoService _alumnoService;

    public AlumnoController(AlumnoService alumnoService)
    {
        _alumnoService = alumnoService;
    }

    [HttpGet]
    public async Task<ActionResult<List<AlumnoDTO>>> Get() =>
        await _alumnoService.GetAlumnosAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<AlumnoDTO>> Get(string id)
    {
        var alumno = await _alumnoService.GetAlumnoByIdAsync(id);
        if (alumno == null) return NotFound();
        return alumno;
    }

    [HttpPost]
    public async Task<IActionResult> Create(AlumnoDTO alumnoDTO)
    {
        await _alumnoService.CreateAlumnoAsync(alumnoDTO);
        return CreatedAtAction(nameof(Get), new { id = alumnoDTO.Id }, alumnoDTO);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, AlumnoDTO alumnoDTO)
    {
        var existingAlumno = await _alumnoService.GetAlumnoByIdAsync(id);
        if (existingAlumno == null) return NotFound();
        await _alumnoService.UpdateAlumnoAsync(id, alumnoDTO);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var alumno = await _alumnoService.GetAlumnoByIdAsync(id);
        if (alumno == null) return NotFound();
        await _alumnoService.DeleteAlumnoAsync(id);
        return NoContent();
    }
}