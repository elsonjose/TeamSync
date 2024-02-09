using MediatR;
using TeamSync.Application.Common.Dto;
using TeamSync.Application.Common.Dto.Authetication;
using TeamSync.Application.Interfaces;

namespace TeamSync.Application.Requests.Organisation;

/// <summary>
/// Defines the register command for organisation.
/// </summary>
public class OrganisationRegisterCommand : IRequest<ResponseDto<AuthenticationResposeDto>>
{
    /// <summary>
    /// Specifies the input email.
    /// </summary>
    /// <example>input@email.com</example>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Specifies the input password.
    /// </summary>
    /// <example>p@ssword</example>
    public string Password { get; set; } = null!;

    /// <summary>
    /// Specifies the organisation name.
    /// </summary>
    /// <example>Organisation name</example>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Specifies whether to enforce domain check allowing only the users with the same domain to be added to this organisation.
    /// </summary>
    /// <example>Organisation name</example>
    public bool IsDomainCheckEnabled { get; set; }
}

/// <summary>
/// Defines the handler for <seealso cref="OrganisationRegisterCommand"/>
/// </summary>
public class OrganisationRegisterCommandHandler : IRequestHandler<OrganisationRegisterCommand, ResponseDto<AuthenticationResposeDto>>
{
    /// <summary>
    /// Specifies the hashing instance.
    /// </summary>
    private readonly IHasher _hasher;

    /// <summary>
    /// Specifies the database instance.
    /// </summary>
    private readonly ITeamSyncDbContext _dbContext;

    /// <summary>
    /// Specifies the jwt token generator instance.
    /// </summary>
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    /// <summary>
    /// Initialises a new instance of <seealso cref="OrganisationRegisterCommandHandler"/>
    /// </summary>
    /// <param name="hasher"></param>
    /// <param name="teamSyncDbContext"></param>
    /// <param name="jwtTokenGenerator"></param>
    public OrganisationRegisterCommandHandler(IHasher hasher, ITeamSyncDbContext teamSyncDbContext, IJwtTokenGenerator jwtTokenGenerator)
    {
        _hasher = hasher;
        _dbContext = teamSyncDbContext;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    /// <summary>
    /// Defines the handle method of <seealso cref="OrganisationRegisterCommandHandler"/>
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The authentication response.</returns>
    public async Task<ResponseDto<AuthenticationResposeDto>> Handle(OrganisationRegisterCommand request, CancellationToken cancellationToken)
    {
        var organisation = new Domain.Entities.Organisation()
        {
            Name = request.Name,
            EnforceDomainCheck = request.IsDomainCheckEnabled,
            
            // Set it to false. Only after email verification set it as true.
            IsActive = false
        };
        await _dbContext.Organisations.AddAsync(organisation, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var (hashedPassword, salt) = _hasher.HashPassword(request.Password);

        var adminUser = new Domain.Entities.User()
        {
            FirstName = request.Name,
            Email = request.Email,
            Password = hashedPassword,
            HashSalt = salt,
            IsAdminUser = true,
            
            // Move clock in details to another table.
            
            // Set it to false. Only after email verification set it as true.
            IsActive = false
        };
        await _dbContext.Organisations.AddAsync(organisation, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var token = _jwtTokenGenerator.GenerateToken(null, organisation.OrganisationId, true);

        return new ResponseDto<AuthenticationResposeDto>()
        {
            Data = new()
            {
                Token = token,
                Id = organisation.OrganisationId
            }
        };
    }
}