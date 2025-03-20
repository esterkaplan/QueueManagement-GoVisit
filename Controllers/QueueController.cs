using Microsoft.AspNetCore.Mvc;
using QueueManagementAPI.Application.Commands;
using QueueManagementAPI.Application.Handlers;
using QueueManagementAPI.Application.Queries;

[Route("api/[controller]")]
[ApiController]
public class QueueController : ControllerBase
{
    private readonly CreateAppointmentHandler _createHandler;
    private readonly UpdateAppointmentHandler _updateHandler;
    private readonly DeleteAppointmentHandler _deleteHandler;
    private readonly GetAppointmentsHandler _getHandler;

    public QueueController(CreateAppointmentHandler createHandler,
                           UpdateAppointmentHandler updateHandler,
                           DeleteAppointmentHandler deleteHandler,
                           GetAppointmentsHandler getHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
        _getHandler = getHandler;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentCommand command)
    {
        await _createHandler.Handle(command);
        return Ok("Appointment Created Successfully");
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateAppointment(string id, [FromBody] UpdateAppointmentCommand command)
    {
        var success = await _updateHandler.Handle(id, command);
        if (!success) return NotFound();
        return Ok("Appointment Updated Successfully");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAppointment(string id)
    {
        var command = new DeleteAppointmentCommand(id);
        var success = await _deleteHandler.Handle(command);
        if (!success) return NotFound("Appointment Not Found");
        return Ok("Appointment Deleted Successfully");
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAppointments()
    {
        var query = new GetAppointmentsQuery();
        var appointments = await _getHandler.Handle(query);
        return Ok(appointments);
    }
}
