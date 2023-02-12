using System.Collections.Generic;

namespace CapstoneProject_ApiLayer.Models
{
    public class ElectricChart
    {
        public ElectricChart()
        {
            Counts= new List<int>();
        }

        public string ElectricDate { get; set; }
        public List<int> Counts { get; set; }

    }
}
