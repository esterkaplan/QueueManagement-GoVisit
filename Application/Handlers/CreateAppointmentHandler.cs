using MongoDB.Driver;
using QueueManagementAPI.Domain;
using System.Threading.Tasks;

public class CreateAppointmentHandler
{
    private readonly IMongoCollection<QueueAppointment> _appointments;

    public CreateAppointmentHandler(IMongoDatabase database)
    {
        _appointments = database.GetCollection<QueueAppointment>("Appointments");
    }

    public async Task Handle(CreateAppointmentCommand command)
    {
        var appointment = new QueueAppointment
        {
            Id = Guid.NewGuid().ToString(),
            CustomerName = command.CustomerName,
            AppointmentDate = command.AppointmentDate,
            ServiceType = command.ServiceType
        };
        await _appointments.InsertOneAsync(appointment);
    }
}
