using MongoDB.Driver;
using QueueManagementAPI.Domain;
using System.Threading.Tasks;

namespace QueueManagementAPI.Application.Handlers
{
    public class UpdateAppointmentHandler
    {
        private readonly IMongoCollection<QueueAppointment> _appointments;

        public UpdateAppointmentHandler(IMongoDatabase database)
        {
            _appointments = database.GetCollection<QueueAppointment>("Appointments");
        }

        public async Task<bool> Handle(string id, UpdateAppointmentCommand command)
        {
            var update = Builders<QueueAppointment>.Update
                .Set(a => a.CustomerName, command.CustomerName)
                .Set(a => a.AppointmentDate, command.Date)
                .Set(a => a.ServiceType, command.ServiceType);

            var result = await _appointments.UpdateOneAsync(a => a.Id == id, update);
            return result.MatchedCount > 0;
        }
    }
}
