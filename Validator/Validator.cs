using QvaPay.SDK.Validator.Models;

namespace QvaPay.SDK.Validator
{
	/// <summary>
	/// Used to validate data.
	/// </summary>
	public static class Validator
	{
		static ValidationStruct _validationResult;
		/// <summary>
		/// Validates email addresses.
		/// Validations:
		/// Can't be an empty string.
		/// Must contain @.
		/// Must end .com.
		/// Can't end @.com.
		/// </summary>
		/// <param name="email">The email to validate.</param>
		public static ValidationStruct ValidateEmail(string email)
		{
			_validationResult = new ValidationStruct();
			//make lowercase for validations
			email=email.ToLower();

			//validations
			if (email.Length == 0)
				_validationResult.Error = "Email can't be null or empty";
			else if (!email.Contains("@") || !email.EndsWith(".com")||email.Contains("@.com"))
				_validationResult.Error = "Invalid email";


			return validate();
		}
		/// <summary>
		/// Validates strings.
		/// Validations:
		/// Can't be an empty string.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static ValidationStruct ValidateString(string value)
		{
			_validationResult = new ValidationStruct();

			if (string.IsNullOrEmpty(value))
				_validationResult.Error = "Field can't be empty";

			return validate();
		}

		/// <summary>
		/// Define if the struct is valid or not
		/// </summary>
		static ValidationStruct validate()
		{
			var _result = _validationResult;

			//if note is empty then is validated
			_result.IsValid =_result.Error==null||_result.Error.Length==0;

			return _result;
		}
	}
}
