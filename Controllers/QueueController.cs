using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/appointments")]
public class QueueController : ControllerBase
{
    private readonly CreateAppointmentHandler _createHandler;
    private readonly GetAppointmentsHandler _getHandler;

    public QueueController(CreateAppointmentHandler createHandler, GetAppointmentsHandler getHandler)
    {
        _createHandler = createHandler;
        _getHandler = getHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentCommand command)
    {
        await _createHandler.Handle(command);
        return Ok("Appointment Created Successfully");
    }

    [HttpGet]
    public async Task<IActionResult> GetAppointments()
    {
        var appointments = await _getHandler.Handle(new GetAppointmentsQuery());
        return Ok(appointments);
    }
}
