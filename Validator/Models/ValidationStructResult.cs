using System;
using System.Collections.Generic;
using System.Text;

namespace QvaPay.SDK.Validator.Models
{
    /// <summary>
    /// The response data of validator.
    /// </summary>
    public struct ValidationStructResult
    {
        /// <summary>
        /// Is the data validated?
        /// </summary>
        public bool IsValid;
        /// <summary>
        /// In case of errors here is the cause.
        /// Some errors has special string taht can be replaced by another.
        /// Ex:&field1 must not be null or empty.'&field1' can be replaced by the name of the field=
        /// User Name must not be null or empty.Some validations require 2 fields so they are numbered consecutly.
        /// </summary>
        public string Error;
    }
}
