using Microsoft.AspNetCore.Identity;

namespace EnrollmentSystem.Application.Services;

public class PasswordEncryptionService
{
    private readonly PasswordHasher<object> _passwordHasher;

    public PasswordEncryptionService()
    {
        _passwordHasher = new PasswordHasher<object>();
    }

    public string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(null, password);
    }

    public bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
        return result == PasswordVerificationResult.Success;
    }
}
