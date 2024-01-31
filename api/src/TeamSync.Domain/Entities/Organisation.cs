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
    /// Specifies the organisation short code. To be used in JWT.
    /// </summary>
    public string ShortCode { get; set; } = null!;

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
    /// Specifies the metadata
    /// </summary>
    public Dictionary<string,object> Metadata {get;set;} = null!;
}