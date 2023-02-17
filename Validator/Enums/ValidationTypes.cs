using System;
using System.Collections.Generic;
using System.Text;

namespace QvaPay.SDK.Validator.Enums
{
	/// <summary>
	/// Used to validate strings.
	/// </summary>
	public enum ValidationTypes
	{
		/// <summary>
		/// String can't be empty or null.
		/// </summary>
		Required,
		/// <summary>
		/// Must be a certain length.
		/// </summary>
		CharacterLimit,
		/// <summary>
		/// Must be equal to other.
		/// </summary>
		Equals,
		/// <summary>
		/// Must contain a certain string or char.
		/// </summary>
		Contain,
		/// <summary>
		/// Must end with a certain string or char.
		/// </summary>
		MustEnd,
		/// <summary>
		/// Can't end with a certain string or char.
		/// </summary>
		MustNotEnd,
		/// <summary>
		/// Can't contain a certain string or char.
		/// </summary>
		MustNotContain,
		/// <summary>
		/// String must start with a certain string or char.
		/// </summary>
		StartWith
	}
}
