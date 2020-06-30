namespace CovidDashboard.Models
{
    public class CovidObservationDatumDto
    {
        public string Country { get; set; }

        public int Confirmed { get; set; }

        public int Deaths { get; set; }

        public int Recovered { get; set; }
    }
}