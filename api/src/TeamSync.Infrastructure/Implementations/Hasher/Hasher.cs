using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using TeamSync.Application.Interfaces;

namespace TeamSync.Infrastructure.Implementations.Hasher;

/// <summary>
/// Defines the implementation of <seealso cref="IHasher"/>
/// </summary>
public class Hasher : IHasher
{
    /// <summary>
    /// Specifies the hash congfiguration.
    /// </summary>
    private readonly HashConfig _hashConfig;

    /// <summary>
    /// Specifies the hash algorithm to be used.
    /// </summary>
    private readonly HashAlgorithmName _hashAlgorithm;

    /// <summary>
    /// Initializes a new instance of <seealso cref="Hasher"/>.
    /// </summary>
    /// <param name="hashConfig"></param>
    public Hasher(IOptions<HashConfig> hashConfig)
    {
        _hashConfig = hashConfig.Value;
        _hashAlgorithm = HashAlgorithmName.SHA512;
    }

    public (string hashedPassword, byte[] salt) HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(_hashConfig.KeySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            _hashConfig.Iterations,
            _hashAlgorithm,
            _hashConfig.KeySize);
        return (Convert.ToHexString(hash), salt);
    }

    public bool IsPasswordVerified(string password, string hash, byte[] salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, _hashConfig.Iterations, _hashAlgorithm, _hashConfig.KeySize);
        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }
}