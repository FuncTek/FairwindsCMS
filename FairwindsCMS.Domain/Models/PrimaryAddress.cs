using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FairwindsCMS.Domain.Models
{
    public class PrimaryAddress
    {
        [Display(Name = "Address Line")]
        [MaxLength(255)]
        [JsonProperty("address_line_1")]
        [Required]
        public string? AddressLine1 { get; set; }

        [Required]
        [MaxLength(255)]
        [JsonProperty("city")]
        public string? City { get; set; }

        [Required]
        [MaxLength(30)]
        [JsonProperty("state")]
        public string? State { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 5, ErrorMessage = "Zip Code must be between 5 and 9 characters.")]
        [Display(Name = "Zip Code")]
        [JsonProperty("zip_code")]
        public string? ZipCode { get; set; }
    }
}
