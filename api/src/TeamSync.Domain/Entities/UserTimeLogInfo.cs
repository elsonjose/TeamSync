using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamSync.Domain.Entities
{
    public class UserTimeLogInfo
    {
        /// <summary>
        /// Specifies the identifier for the user.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Specifies the guid identifier for the user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Specifies whether the user is currently clocked in or not.
        /// </summary>
        public bool IsClockedIn;

        /// <summary>
        /// Specifies the last clocked in id of the user.
        /// </summary>
        public long? LastClockedId;

        /// <summary>
        /// Specifies the last clocked in time of the user.
        /// </summary>
        public long? LastClockedTime;
    }
}