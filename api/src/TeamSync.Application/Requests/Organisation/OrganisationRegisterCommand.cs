using MediatR;
using TeamSync.Application.Common;
using TeamSync.Application.Common.Authetication;
using TeamSync.Application.Interfaces;

namespace TeamSync.Application.Requests.Organisation
{
    public class OrganisationRegisterCommand : OrganisationLoginQuery
    {
        public string Name { get; set; } = null!;
    }

    public class OrganisationRegisterCommandHandler : IRequestHandler<OrganisationRegisterCommand, ResponseDto<AuthenticationResposeDto>>
    {
        private readonly IHasher _hasher;
        private readonly ITeamSyncDbContext _dbContext;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public OrganisationRegisterCommandHandler(IHasher hasher, ITeamSyncDbContext teamSyncDbContext, IJwtTokenGenerator jwtTokenGenerator)
        {
            _hasher = hasher;
            _dbContext = teamSyncDbContext;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

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
            _dbContext.SaveChages();

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
}