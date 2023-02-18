using System;
using System.Collections.Generic;
using System.Text;

namespace QvaPay.SDK.MethodExtensions
{
	internal static class EnumExtensions
	{
		/// <summary>
		/// Returns the url version of the enum value.Ex(Auth=auth);
		/// </summary>
		public static string ToUrlString(this Enum s)
		{
			//If it is empty means that it doesnt need another level in url
			if (s.ToString().Equals("Empty"))
				return "";
			return  s.ToString().ToLower();
		}
	}
}
