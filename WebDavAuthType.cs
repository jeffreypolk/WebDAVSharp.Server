using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDAVSharp.Server
{

    /// <summary>
    /// HTTP Authorization Types
    /// </summary>
    public enum AuthType
    {
        /// <summary>
        /// Clear Text
        /// </summary>
        Basic,
        /// <summary>
        /// Negotiate
        /// </summary>
        Negotiate,
        /// <summary>
        /// Anonymous
        /// </summary>
        Anonymous,
        /// <summary>
        /// Combine both negotiate and basic, if the connection
        /// does not come from an authenticated client it fallback
        /// on basic authentication.
        /// </summary>
        NegotiateAndBasic,
    }
}
