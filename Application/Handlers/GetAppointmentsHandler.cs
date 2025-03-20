using MongoDB.Driver;
using QueueManagementAPI.Domain;

public class GetAppointmentsHandler
{
    private readonly IMongoCollection<QueueAppointment> _appointments;

    public GetAppointmentsHandler(IMongoDatabase database)
    {
        _appointments = database.GetCollection<QueueAppointment>("Appointments");
    }

    public async Task<List<QueueAppointment>> Handle(GetAppointmentsQuery query)
    {
        return await _appointments.Find(_ => true).ToListAsync();
    }
}
