using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidDashboard.Models
{
    public class CovidObservationDatumInputDto
    {
        [Column("observationdate")]
        [Required]
        public DateTime ObservationDate { get; set; }

        [Column("provincestate")]
        public string ProvinceState { get; set; }

        [Column("countryregion")]
        [Required]
        public string Country { get; set; }

        [Column("lastupdate")]
        [Required]
        public DateTime LastUpdate { get; set; }

        [Column("confirmed")]
        [Required]
        public int Confirmed { get; set; }

        [Column("deaths")]
        [Required]
        public int Deaths { get; set; }

        [Column("recovered")]
        [Required]
        public int Recovered { get; set; }
    }
}
