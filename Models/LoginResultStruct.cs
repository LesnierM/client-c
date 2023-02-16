using System;

namespace QvaPay.SDK.Models
{

	internal struct LoginResultStruct
	{
		public string AccessToken;
		public string Token_type;
		public UserInformationStruct Me;
	}
}