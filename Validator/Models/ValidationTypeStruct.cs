using QvaPay.SDK.Validator.Enums;

namespace QvaPay.SDK.Validator.Models
{
	/// <summary>
	/// used to validate strings.
	/// </summary>
	public struct ValidationTypeStruct
	{
		/// <summary>
		/// The type of validation.
		/// </summary>
		public ValidationTypes Type;
		/// <summary>
		/// The paramter of the type if necessesary.
		/// </summary>
		public string Parameter;
	}
}
