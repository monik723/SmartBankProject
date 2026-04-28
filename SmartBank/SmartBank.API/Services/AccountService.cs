using Microsoft.EntityFrameworkCore;
using SmartBank.API.Data;
using SmartBank.Core.DTOs.Account;
using SmartBank.Core.Interfaces;
using SmartBank.Core.Models;

namespace SmartBank.API.Services;

public class AccountService : IAccountService
{
    private readonly AppDbContext _db;

    public AccountService(AppDbContext db) => _db = db;

    public async Task<AccountDto> CreateAccountAsync(int userId, CreateAccountDto dto)
    {
        var accountNumber = "SB" + DateTime.Now.Ticks.ToString().Substring(8);

        var account = new Account
        {
            AccountNumber = accountNumber,
            AccountType = dto.AccountType,
            Balance = dto.InitialDeposit,
            UserId = userId,
            Status = "Active",
        };

        _db.Accounts.Add(account);
        await _db.SaveChangesAsync();

        return new AccountDto
        {
            Id = account.Id,
            AccountNumber = account.AccountNumber,
            AccountType = account.AccountType,
            Balance = account.Balance,
            Status = account.Status,
            CreatedAt = account.CreatedAt,
        };
    }

    public async Task<List<AccountDto>> GetAccountsAsync(int userId)
    {
        return await _db
            .Accounts.Where(a => a.UserId == userId)
            .Select(a => new AccountDto
            {
                Id = a.Id,
                AccountNumber = a.AccountNumber,
                AccountType = a.AccountType,
                Balance = a.Balance,
                Status = a.Status,
                CreatedAt = a.CreatedAt,
            })
            .ToListAsync();
    }
}
