namespace CapstoneProject.CQRS.Queries.TravelAgencyQuery
{
    public class GetTravelAgencyByIDQuery
    {
        public GetTravelAgencyByIDQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
