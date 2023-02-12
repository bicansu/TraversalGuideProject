using System;

namespace CapstoneProject_ApiLayer.Models
{
    public enum ECity
    {
        İstanbul=1,
        ankara=2,
        İzmir=3,
        konya=4,
        trabzon=5
    }
    public class Electric
    {
        public int ElectricID { get; set; }
        public ECity City { get; set; }
        public int Count { get; set; }
        public DateTime ElectricDate { get; set; }

    }
}
