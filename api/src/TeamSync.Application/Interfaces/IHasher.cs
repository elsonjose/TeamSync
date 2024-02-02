namespace TeamSync.Application.Interfaces;
public interface IHasher
{
    (string hashedPassword, byte[] salt) HashPassword(string password);

    bool IsPasswordVerified(string password, string hash, byte[] salt);
}