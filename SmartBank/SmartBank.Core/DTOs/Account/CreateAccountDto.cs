using System.ComponentModel.DataAnnotations;

namespace SmartBank.Core.DTOs.Account;

public class CreateAccountDto
{
    [Required]
    public string AccountType { get; set; } = string.Empty;

    [Range(500, double.MaxValue, ErrorMessage = "Minimum opening balance is 500")]
    public decimal InitialDeposit { get; set; }
}
