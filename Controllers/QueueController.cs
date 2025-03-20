using Microsoft.AspNetCore.Mvc;

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
        await _updateHandler.Handle(id, command);
        return Ok("Appointment Updated Successfully");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAppointment(string id)
    {
        await _deleteHandler.Handle(id);
        return Ok("Appointment Deleted Successfully");
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAppointments()
    {
        var appointments = await _getHandler.Handle(new GetAppointmentsQuery());
        return Ok(appointments);
    }
}
