namespace CapstoneProject.CQRS.Commands.TravelAgencyCommands
{
    public class RemoveTravelAgencyCommand
    {
        public RemoveTravelAgencyCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
