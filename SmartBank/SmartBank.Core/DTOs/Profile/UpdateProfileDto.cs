using System.ComponentModel.DataAnnotations;

namespace SmartBank.Core.DTOs.Profile;

public class UpdateProfileDto
{
    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile must be 10 digits")]
    public string Mobile { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;

    [RegularExpression(@"^\d{6}$", ErrorMessage = "PinCode must be 6 digits")]
    public string PinCode { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}
