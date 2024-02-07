using Newtonsoft.Json.Linq;

namespace TeamSync.Domain.Entities;

/// <summary>
/// Defines the user entity.
/// </summary>
public class User
{
    /// <summary>
    /// Specifies the identifier for the user.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Specifies the guid identifier for the user.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Specifies the first name.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Specifies the last name.
    /// </summary>
    public string LastName = null!;

    /// <summary>
    /// Specifies the email.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Specifies the password.
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// Specifies the password salt.
    /// </summary>
    public byte[] HashSalt { get; set; } = null!;

    /// <summary>
    /// Specifies whether the account is active or not.
    /// </summary>
    public bool IsActive;

    /// <summary>
    /// Specifies whether the account is the admin user or not.
    /// </summary>
    public bool IsAdminUser;

    /// <summary>
    /// Specifies whether the user is currently clocked in or not.
    /// </summary>
    public bool IsClockedIn;

    /// <summary>
    /// Specifies the last clocked in id of the user.
    /// </summary>
    public long? LastClockedId;

    /// <summary>
    /// Specifies the last clocked in time of the user.
    /// </summary>
    public long? LastClockedTime;

    /// <summary>
    /// Specifies the orgnaisation id of the user.
    /// </summary>
    public long OrganisationId;

    /// <summary>
    /// Specifies the metadata
    /// </summary>
    public JObject? Metadata { get; set; }

    /// <summary>
    /// Specifies the associated organisation for the user.
    /// </summary>
    public Organisation Organisation { get; set; } = null!;

    /// <summary>
    /// Specifies the associated time-logs for the user.
    /// </summary>
    public List<TimeLog> TimeLogs { get; set; } = null!;
}
