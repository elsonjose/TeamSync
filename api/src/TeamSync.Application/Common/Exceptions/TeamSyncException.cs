using System.Net;
using static TeamSync.Application.Common.TeamSyncEnums;

namespace TeamSync.Application.Common.Exceptions;

/// <summary>
/// Defines the team-sync exception. 
/// </summary>
public class TeamSyncException : Exception
{
    /// <summary>
    /// Defines the http status code.
    /// </summary>
    public TeamSyncExceptionCodes HttpStatusCode { get; set; }

    /// <summary>
    /// Defines the error message.
    /// </summary>
    public override string Message { get; } = null!;

    /// <summary>
    /// Initializes a new instance of <seealso cref="TeamSyncException"/>
    /// </summary>
    /// <param name="code"></param>
    /// <param name="exceptionMessage"></param>
    public TeamSyncException(TeamSyncExceptionCodes code, string exceptionMessage) : base(exceptionMessage)
    {
        HttpStatusCode = code;
        Message = exceptionMessage;
    }
}