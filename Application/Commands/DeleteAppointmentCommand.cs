namespace QueueManagementAPI.Application.Commands
{
    public class DeleteAppointmentCommand
    {
        public string Id { get; set; }

        public DeleteAppointmentCommand(string id)
        {
            Id = id;
        }
    }
}
