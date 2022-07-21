using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FairwindsCMS.Domain.Models
{
    public class PrimaryAddress
    {
        [Display(Name = "Address Line")]
        [MaxLength(255)]
        [JsonPropertyName("address_line_1")]
        [Required]
        public string? AddressLine1 { get; set; }

        [Required]
        [MaxLength(255)]
        [JsonPropertyName("city")]
        public string? City { get; set; }

        [Required]
        [MaxLength(30)]
        [JsonPropertyName("state")]
        public string? State { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 5, ErrorMessage = "Zip Code must be between 5 and 9 characters.")]
        [Display(Name = "Zip Code")]
        [JsonPropertyName("zip_code")]
        public string? ZipCode { get; set; }
    }
}
