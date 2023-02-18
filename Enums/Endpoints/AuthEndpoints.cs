using System;
using System.Collections.Generic;
using System.Text;

namespace QvaPay.SDK.Enums.Endpoints
{
    internal enum AuthEndpoints
    {
        /// <summary>
        /// Logsin with the necessary parameter.
        /// </summary>
        Login,
        /// <summary>
        /// Register a new user.
        /// </summary>
        Register,
        /// <summary>
        /// Logsout the aunthenticated user.
        /// </summary>
        Logout
    }
}
