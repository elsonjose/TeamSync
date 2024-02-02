using Newtonsoft.Json.Linq;

namespace TeamSync.Domain.Entities;

/// <summary>
/// Defines the organisation entity.
/// </summary>
public class Organisation
{
    /// <summary>
    /// Specifies the identifier for the organisation.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Specifies the guid identifier for the organisation.
    /// </summary>
    public Guid OrganisationId { get; set; }

    /// <summary>
    /// Specifies the organisation name.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Specifies whether the organisation is active or not.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Specifies the organisation email. To be used in domain checking.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Specifies the organisation password.
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// Specifies the password salt.
    /// </summary>
    public byte[] HashSalt { get; set; } = null!;

    /// <summary>
    /// Specifies the metadata
    /// </summary>
    public JObject? Metadata { get; set; }

    /// <summary>
    /// Specifies the list of users associated with the organisation.
    /// </summary>
    public List<User> Users { get; set; } = null!;
}