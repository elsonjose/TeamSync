using MediatR;
using TeamSync.Application.Common;
using TeamSync.Application.Common.Authetication;

namespace TeamSync.Application.Requests.Organisation
{
    /// <summary>
    /// Defines the query for an organisation to login.
    /// </summary>
    public class OrganisationLoginQuery : IRequest<ResponseDto<AuthenticationResposeDto>>
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
    }

    /// <summary>
    /// Defines the handler for <seealso cref="OrganisationLoginQuery"/>
    /// </summary>
    public class OrganisationLoginQueryHandler : IRequestHandler<OrganisationLoginQuery, ResponseDto<AuthenticationResposeDto>>
    {
        /// <summary>
        /// Defines the handle method of <seealso cref="OrganisationLoginQueryHandler"/>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<ResponseDto<AuthenticationResposeDto>> Handle(OrganisationLoginQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}