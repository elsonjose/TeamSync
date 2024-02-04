namespace TeamSync.Application.Common.Dto.Authetication
{
    /// <summary>
    /// Defines the authentication response DTO.
    /// </summary>
    public class AuthenticationResposeDto
    {
        /// <summary>
        /// Specifies the id. It can be the user id or the organisation id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Specifies the token for authorisation.
        /// </summary>
        public string Token { get; set; } = null!;
    }
}