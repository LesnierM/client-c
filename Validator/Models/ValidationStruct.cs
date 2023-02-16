using System;
using System.Collections.Generic;
using System.Text;

namespace QvaPay.SDK.Validator.Models
{
    /// <summary>
    /// The response data of validator.
    /// </summary>
    public struct ValidationStruct
    {
        /// <summary>
        /// Is the data validated?
        /// </summary>
        public bool IsValid;
        /// <summary>
        /// In case of errors here is the cause.
        /// </summary>
        public string Error;
    }
}
