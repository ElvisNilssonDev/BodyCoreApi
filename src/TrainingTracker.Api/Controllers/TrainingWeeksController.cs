using Microsoft.AspNetCore.Mvc;
using TrainingTracker.Application.DTOs;
using TrainingTracker.Application.Interfaces;
using TrainingTracker.Domain.Entities;

namespace TrainingTracker.Api.Controllers;

[ApiController]
[Route("api/trainingweeks")]
public class TrainingWeeksController : ControllerBase
{
    private readonly ITrainingWeekService _service;

    public TrainingWeeksController(ITrainingWeekService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<TrainingWeekResponseDto>>> GetAll([FromQuery] string? search)
    {
        var weeks = await _service.GetAllAsync(search);
        var dto = weeks.Select(w => new TrainingWeekResponseDto
        {
            Id = w.Id,
            Title = w.Title,
            Description = w.Description,
            WeekStart = w.WeekStart
        }).ToList();

        return Ok(dto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TrainingWeekResponseDto>> GetById(int id)
    {
        var week = await _service.GetByIdAsync(id);
        if (week is null) return NotFound();

        return Ok(new TrainingWeekResponseDto
        {
            Id = week.Id,
            Title = week.Title,
            Description = week.Description,
            WeekStart = week.WeekStart
        });
    }

    [HttpPost]
    public async Task<ActionResult<TrainingWeekResponseDto>> Create([FromBody] TrainingWeekCreateDto dto)
    {
        var model = new TrainingWeek
        {
            Title = dto.Title,
            Description = dto.Description,
            WeekStart = dto.WeekStart
        };

        var created = await _service.CreateAsync(model);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new TrainingWeekResponseDto
        {
            Id = created.Id,
            Title = created.Title,
            Description = created.Description,
            WeekStart = created.WeekStart
        });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] TrainingWeekUpdateDto dto)
    {
        var updated = new TrainingWeek
        {
            Title = dto.Title,
            Description = dto.Description,
            WeekStart = dto.WeekStart
        };

        var ok = await _service.UpdateAsync(id, updated);
        if (!ok) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        if (!ok) return NotFound();

        return NoContent();
    }
}
