namespace CapstoneProject.CQRS.Commands.TravelAgencyCommands
{
    public class CreateTravelAgencyCommand
    {
        public int TravelAgencyID { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
