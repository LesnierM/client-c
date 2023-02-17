using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QvaPay.SDK.Enums;
using QvaPay.SDK.Enums.Endpoints;
using QvaPay.SDK.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace QvaPay.SDK.Controllers
{
	/// <summary>
	/// Used to parse errores return by server from diferent endpoints.
	/// </summary>
	internal static class ErrorProvider
	{
		/// <summary>
		/// Parses endpoint errors to a common error data.
		/// </summary>
		/// <typeparam name="T">An endpoint enum.</typeparam>
		/// <param name="jsonString">The errorHsonString</param>
		/// <param name="category">The category.</param>
		/// <param name="endpoint">The endpoint.</param>
		public static ErrorStruct ParseError<T>(string jsonString,Categories category, T endpoint)where T:Enum
		{
			ErrorStruct _result=default;
			var _errorResultJObject = JsonConvert.DeserializeObject<JObject>(jsonString);
			switch (category)
			{
				case Categories.Auth:
					switch (endpoint)
					{
						case AuthEndpoints.Login:
							_result = new ErrorStruct(ParseErrorString(_errorResultJObject,"error"));
							break;
						case AuthEndpoints.Register:
							break;
						case AuthEndpoints.Logout:
							_result = new ErrorStruct(ParseErrorString(_errorResultJObject,"message"));
							break;
					}
					break;
				case Categories.User:
					break;
				case Categories.Transactions:
					break;
				case Categories.Merchants:
					break;
				case Categories.Payment_Links:
					break;
				case Categories.Services:
					break;
				case Categories.P2P:
					break;
				case Categories.Rates:
					break;
			}
			return _result;
		}
		/// <summary>
		/// Remove all unwanted characters to correctly parse to string array.
		/// </summary>
		/// <param name="jsonString">The string to work on.</param>
		/// <param name="fieldName">The name of the field containig the data.</param>
		/// <returns>The string array clean of unwaned characters.</returns>
		static string[] ParseErrorString(JObject jsonString,string fieldName)
		{
			return jsonString.ToString().Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "").Replace($"\"{fieldName}\":", "").Replace("\n", "").Replace("\r", "").Split(',');
		}
	}
}
