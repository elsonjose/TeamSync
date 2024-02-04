using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamSync.Application.Common;

/// <summary>
/// Defines the enums used.
/// </summary>
public static class TeamSyncEnums
{
    /// <summary>
    /// Defines the exception codes.
    /// </summary>
    public enum TeamSyncExceptionCodes : int
    {
        /// <summary>
        /// Not found.
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Internal server error.
        /// </summary>
        InternalServerError = 500,

        /// <summary>
        /// Conflict.
        /// </summary>
        Conflict = 409,

        /// <summary>
        /// Unauthorized.
        /// </summary>
        UnauthorizedException = 401,

        /// <summary>
        /// Bad request.
        /// </summary>
        BadRequest = 400
    }
}