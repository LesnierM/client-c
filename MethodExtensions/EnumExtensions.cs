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
			return s.ToString().ToLower();
		}
	}
}
