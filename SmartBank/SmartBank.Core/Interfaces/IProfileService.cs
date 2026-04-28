using SmartBank.Core.DTOs.Profile;

namespace SmartBank.Core.Interfaces;

public interface IProfileService
{
    Task<ProfileDto?> GetProfileAsync(int userId);
    Task<bool> UpdateProfileAsync(int userId, UpdateProfileDto dto);
}
