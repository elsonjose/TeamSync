using MediatR;
using TeamSync.Application.Common;
using TeamSync.Application.Common.Authetication;

namespace TeamSync.Application.Requests.Organisation
{
    public class OrganisationLoginQuery : IRequest<ResponseDto<AuthenticationResposeDto>>
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }

    public class OrganisationLoginQueryHandler : IRequestHandler<OrganisationLoginQuery, ResponseDto<AuthenticationResposeDto>>
    {
        public Task<ResponseDto<AuthenticationResposeDto>> Handle(OrganisationLoginQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}