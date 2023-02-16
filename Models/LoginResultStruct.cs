using System;

namespace QvaPay.SDK.Models
{
	/// <summary>
	/// The response data of the login endpoint.
	/// </summary>
	internal struct LoginResultStruct
	{
		public string AccessToken;
		public string Token_type;
		public UserInformationStruct Me;
	}
}