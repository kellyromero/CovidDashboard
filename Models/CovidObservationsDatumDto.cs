namespace CovidDashboard.Models
{
    public class CovidObservationsDatumDto
    {
        public string Country { get; set; }

        public int Confirmed { get; set; }

        public int Deaths { get; set; }

        public int Recovered { get; set; }
    }
}