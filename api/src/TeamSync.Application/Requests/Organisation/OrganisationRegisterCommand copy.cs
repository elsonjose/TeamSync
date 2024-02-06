using MediatR;
using TeamSync.Application.Common.Dto;
using TeamSync.Application.Common.Dto.Authetication;
using TeamSync.Application.Interfaces;

namespace TeamSync.Application.Requests.Organisation;

/// <summary>
/// Defines the register command for organisation.
/// </summary>
public class OrganisationRegisterCommand : OrganisationLoginQuery
{
    /// <summary>
    /// Specifies the organisation name.
    /// </summary>
    /// <example>Organisation name</example>
    public string Name { get; set; } = null!;
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
        var (hashedPassword, salt) = _hasher.HashPassword(request.Password);
        var organisation = new Domain.Entities.Organisation()
        {
            Name = request.Name,
            Email = request.Email,
            Password = hashedPassword,
            HashSalt = salt
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