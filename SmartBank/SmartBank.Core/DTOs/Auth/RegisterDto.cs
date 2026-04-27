using System.ComponentModel.DataAnnotations;

namespace SmartBank.Core.DTOs.Auth;

public class RegisterDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile must be 10 digits")]
    public string Mobile { get; set; } = string.Empty;

    public int RoleId { get; set; } = 2;
}
