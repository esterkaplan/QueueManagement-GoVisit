using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QueueManagementAPI.Domain
{
    public class QueueAppointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string ServiceType { get; set; }
    }
}
