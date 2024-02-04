namespace TeamSync.Infrastructure.Implementations.Hasher;

/// <summary>
/// Defines the has configuration model class.
/// </summary>
public class HashConfig
{
    /// <summary>
    /// Specifies the key size.
    /// </summary>
    public int KeySize { get; set; }

    /// <summary>
    /// Specifies the number of iterations to be done.
    /// </summary>
    public int Iterations { get; set; }
}