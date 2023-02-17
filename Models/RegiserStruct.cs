using System;
using System.ComponentModel;

namespace QvaPay.SDK.Models
{
	/// <summary>
	/// To send register required data.
	/// </summary>
	public struct RegiserStruct
	{
		public string name;
		public string email;
		public string password;
		public string c_password;
		public string invite;
	}

}