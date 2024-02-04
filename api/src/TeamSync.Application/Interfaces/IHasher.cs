namespace TeamSync.Application.Interfaces;

/// <summary>
/// Defines the interface for hashing functions.
/// </summary>
public interface IHasher
{
    /// <summary>
    /// Defines the method to hash password.
    /// </summary>
    /// <param name="password"></param>
    /// <returns>Hashed password and salt used for hashing.</returns>
    (string hashedPassword, byte[] salt) HashPassword(string password);

    /// <summary>
    /// Defines the method to verify if input user hashed password matches with the hased user password.
    /// </summary>
    /// <param name="password"></param>
    /// <param name="hash"></param>
    /// <param name="salt"></param>
    /// <returns>True if passwords match, else false.</returns>
    bool IsPasswordVerified(string password, string hash, byte[] salt);
}