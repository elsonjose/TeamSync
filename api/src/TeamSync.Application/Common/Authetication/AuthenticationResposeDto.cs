namespace TeamSync.Application.Common.Authetication
{
    /// <summary>
    /// Defines the authentication response DTO.
    /// </summary>
    public class AuthenticationResposeDto
    {
        public Guid Id { get; set; }

        public string Token { get; set; } = null!;
    }
}