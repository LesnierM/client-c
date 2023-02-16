using System;
using System.Collections.Generic;
using System.Text;

namespace QvaPay.SDK.Models
{
	/// <summary>
	/// Used to parse error reponse messages from api.
	/// </summary>
	internal struct ErrorStruct
	{
		public string[] Error;
	}
}
