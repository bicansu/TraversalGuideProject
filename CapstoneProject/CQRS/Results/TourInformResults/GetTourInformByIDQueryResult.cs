namespace CapstoneProject.CQRS.Results.TourInformResults
{
    public class GetTourInformByIDQueryResult
    {
        public int TourInformID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } 
        public bool Status { get; set; } 
        public string Price { get; set; } 
    }
}
