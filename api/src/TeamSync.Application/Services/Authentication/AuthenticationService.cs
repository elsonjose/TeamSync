using TeamSync.Application.Interfaces;
using TeamSync.Domain.Entities;

namespace TeamSync.Application.Services.Authenication;

/// <summary>
/// Defines the authentication service.
/// </summary>
public class AuthenicationService : IAuthencticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ITeamSyncDbContext _dbContext;
    private readonly IHasher _hasher;

    public AuthenicationService(IJwtTokenGenerator jwtTokenGenerator, ITeamSyncDbContext dbContext, IHasher hasher)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _dbContext = dbContext;
        _hasher = hasher;
    }

    public AuthenticationResult Login(string email, string password)
    {
        var user = _dbContext.Users.AsQueryable()
            .Where(x => x.Email.ToLower() == email.ToLower())
            .Select(u => new User()
            {
                Password = u.Password,
                HashSalt = u.HashSalt
            }).First();

        var isVerified = _hasher.IsPasswordVerified(password, user.Password, user.HashSalt);

        if (isVerified)
        {
            var token = _jwtTokenGenerator.GenerateToken(1, "firstName", "lastName", 1);
            return new AuthenticationResult(1, "FirstName", "LastName", "Email", token);
        }
        throw new Exception();
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        var token = _jwtTokenGenerator.GenerateToken(1, "firstName", "lastName", 1);
        var (hashedPassword, salt) = _hasher.HashPassword(password);
        var org = _dbContext.Organisations.Add(new Domain.Entities.Organisation()
        {
            OrganisationId = Guid.NewGuid(),
            Name = "Jose",
            Email = "elsonjoseofficial@gmail.com",
            Password = "mypass",
            HashSalt = salt
        });
        _dbContext.SaveChages();
        var user = _dbContext.Users.Add(new Domain.Entities.User()
        {
            UserId = Guid.NewGuid(),
            FirstName = "Elson",
            LastName = "Jose",
            Email = "elsonjoseofficial@gmail.com",
            Password = hashedPassword,
            HashSalt = salt,
            OrganisationId = org.Entity.Id
        });
        _dbContext.SaveChages();
        return new AuthenticationResult(1, "FirstName", "LastName", "Email", token);
    }
}