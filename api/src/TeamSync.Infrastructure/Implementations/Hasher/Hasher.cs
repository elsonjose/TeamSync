using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using TeamSync.Application.Interfaces;

namespace TeamSync.Infrastructure.Implementations.Hasher;
public class Hasher : IHasher
{
    private readonly HashConfig _hashConfig;
    private readonly HashAlgorithmName _hashAlgorithm;


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