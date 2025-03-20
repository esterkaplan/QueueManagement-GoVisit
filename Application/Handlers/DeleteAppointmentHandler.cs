using MongoDB.Driver;
using QueueManagementAPI.Domain;

public class DeleteAppointmentHandler
{
    private readonly IMongoCollection<QueueAppointment> _appointments;

    public DeleteAppointmentHandler(IMongoDatabase database)
    {
        _appointments = database.GetCollection<QueueAppointment>("Appointments");
    }

    public async Task Handle(string id)
    {
        await _appointments.DeleteOneAsync(a => a.Id == id);
    }
}
