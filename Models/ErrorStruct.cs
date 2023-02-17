using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace QvaPay.SDK.Models
{
	/// <summary>
	/// used to hold errors reponses from server.
	/// </summary>
	public struct ErrorStruct
	{
		/// <summary>
		/// Errors returned by server.
		/// </summary>
		public string[] Errors;
		/// <summary>
		/// Contructs the error obejct with the errors provided.
		/// </summary>
		/// <param name="error">The errors.</param>
		public ErrorStruct(string[] errors)
		{
			Errors = new string[errors.Length];
			//remove all start and end black spaces
			for (int i = 0; i < errors.Length; i++)
				Errors[i] = errors[i].Trim().Replace("\"","");
		}
	}
}
