using MongoDB.Driver;
using QueueManagementAPI.Application.Commands;
using QueueManagementAPI.Domain;
using System.Threading.Tasks;

namespace QueueManagementAPI.Application.Handlers
{
    public class DeleteAppointmentHandler
    {
        private readonly IMongoCollection<QueueAppointment> _appointments;

        public DeleteAppointmentHandler(IMongoDatabase database)
        {
            _appointments = database.GetCollection<QueueAppointment>("Appointments");
        }

        public async Task<bool> Handle(DeleteAppointmentCommand command)
        {
            var result = await _appointments.DeleteOneAsync(a => a.Id == command.Id);
            return result.DeletedCount > 0;
        }
    }
}
