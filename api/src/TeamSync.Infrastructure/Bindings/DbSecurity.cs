namespace TeamSync.Infrastructure.Bindings;
public class DbSecurity
{
    public string EncryptionKey { get; init; } = null!;

    public string EncryptionIV { get; init; } = null!;

}