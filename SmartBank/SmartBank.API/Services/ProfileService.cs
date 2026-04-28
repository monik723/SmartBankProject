using Microsoft.EntityFrameworkCore;
using SmartBank.API.Data;
using SmartBank.Core.DTOs.Profile;
using SmartBank.Core.Interfaces;
using SmartBank.Core.Models;

namespace SmartBank.API.Services;

public class ProfileService : IProfileService
{
    private readonly AppDbContext _db;
    public ProfileService(AppDbContext db) => _db = db;

    public async Task<ProfileDto?> GetProfileAsync(int userId)
    {
        var user = await _db.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return null;

        var profile = await _db.CustomerProfiles.FirstOrDefaultAsync(p => p.UserId == userId);

        return new ProfileDto
        {
            FullName = user.FullName,
            Email = user.Email,
            Mobile = user.Mobile,
            Address = profile?.Address ?? "",
            City = profile?.City ?? "",
            State = profile?.State ?? "",
            PinCode = profile?.PinCode ?? "",
            Gender = profile?.Gender ?? "",
            DateOfBirth = profile?.DateOfBirth ?? DateTime.MinValue
        };
    }

    public async Task<bool> UpdateProfileAsync(int userId, UpdateProfileDto dto)
    {
        var user = await _db.Users.FindAsync(userId);
        if (user == null) return false;

        user.FullName = dto.FullName;
        user.Mobile = dto.Mobile;

        var profile = await _db.CustomerProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
        if (profile == null)
        {
            profile = new CustomerProfile { UserId = userId };
            _db.CustomerProfiles.Add(profile);
        }

        profile.Address = dto.Address;
        profile.City = dto.City;
        profile.State = dto.State;
        profile.PinCode = dto.PinCode;
        profile.Gender = dto.Gender;
        profile.DateOfBirth = dto.DateOfBirth;

        await _db.SaveChangesAsync();
        return true;
    }
}
