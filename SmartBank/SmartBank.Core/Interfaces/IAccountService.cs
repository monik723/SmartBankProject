using SmartBank.Core.DTOs.Account;

namespace SmartBank.Core.Interfaces;

public interface IAccountService
{
    Task<AccountDto> CreateAccountAsync(int userId, CreateAccountDto dto);
    Task<List<AccountDto>> GetAccountsAsync(int userId);
}
