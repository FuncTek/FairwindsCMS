using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace FairwindsCMS.Domain.Models
{
    public class Customer
    {
        [Display(Name ="Customer Number")]
        [JsonProperty("customer_number")]
        public int? CustomerNumber { get; set; }

        [Required]
        [StringLength(75,MinimumLength =2, ErrorMessage = "First Name must be between 2 and 75 characters.")]
        [Display(Name = "First Name")]
        [JsonProperty("first_name")]
        public string? FirstName { get; set; } 

        [Required]
        [StringLength(75, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 75 characters.")]
        [Display(Name = "Last Name")]
        [JsonProperty("last_name")]
        public string? LastName { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [JsonProperty("date_birth")]
        public DateTime? DateBirth { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        [MinLength(9, ErrorMessage ="SSN must be 9 characters.")]
        [JsonProperty("ssn")]
        public string? Ssn { get; set; }

        [JsonIgnore]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [JsonProperty("email")]
        public string? Email { get; set; } 

        [JsonProperty("primary_address")]
        public PrimaryAddress? PrimaryAddress { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Mobile Phone Number must be at least 10 characters.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Phone Number")]
        [JsonProperty("mobile_phone_number")]
        public string? MobilePhoneNumber { get; set; } 

        [DataType(DataType.Date)]
        [Display(Name = "Join Date")]
        [JsonProperty("join_date")]
        public DateTime? JoinDate { get; set; }
    }
}
