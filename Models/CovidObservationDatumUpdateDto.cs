using CovidDashboard.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CovidDashboard.Models
{
    
    public class CovidObservationDatumUpdateDto
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

        [ConfirmedValidator(ErrorMessage = "Confirmed field is required.")]
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

    public class ConfirmedValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((int)value == 0)
            {
                return new ValidationResult(
                    ErrorMessage,
                    new[] { nameof(CovidObservationDatumUpdateDto) });
            }
            return ValidationResult.Success;
        }
    }
}
