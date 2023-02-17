using QvaPay.SDK.Validator.Enums;
using QvaPay.SDK.Validator.Models;

namespace QvaPay.SDK.Validator
{
	/// <summary>
	/// Used to validate data.
	/// </summary>
	public static class Validator
	{
		static ValidationStructResult _validationResult;
		
		/// <summary>
		/// Validates a string acording to the provided validation types.
		/// </summary>
		/// <param name="value">The string to validate.</param>
		/// <param name="validationTypes">The type of validations to use.</param>
		/// <returns></returns>
		public static ValidationStructResult ValidateString(string value, ValidationTypeStruct[] validationTypes)
		{
			_validationResult = new ValidationStructResult();

			//to avoid case issues
			value = value.ToLower();

			//validations
			foreach (var validation in validationTypes)
			{
				//to avoid case issues
				string _validationParameterLowecase =validation.Parameter!=null?validation.Parameter.ToLower():"";

				if (_validationResult.Error != null && _validationResult.Error.Length != 0)
					break;

				switch (validation.Type)
				{
					case ValidationTypes.Required:
						if (string.IsNullOrEmpty(value))
							_validationResult.Error = "&field can't be empty or null.";
						break;
					case ValidationTypes.CharacterLimit:
						int _parameter = default;
						if (!int.TryParse(_validationParameterLowecase, out _parameter))
						{
							_validationResult.Error = "Wrong validation parameter.Expected an integer.";
							break;
						}
						if (value.Length < _parameter)
							_validationResult.Error = $"&field1 must be {_parameter} characters length.";
						break;
					case ValidationTypes.Equals:
						if (!value.Equals(_validationParameterLowecase))
							_validationResult.Error = "&field1 and &field2 must match.";
						break;
					case ValidationTypes.Contain:
						if (!value.Contains(_validationParameterLowecase))
							_validationResult.Error = $"&field1 must contain '{_validationParameterLowecase}'.";
						break;
					case ValidationTypes.MustEnd:
						if (!value.EndsWith(_validationParameterLowecase))
							_validationResult.Error = $"&field1 must end '{_validationParameterLowecase}'.";
						break;
					case ValidationTypes.MustNotEnd:
						if (value.EndsWith(_validationParameterLowecase))
							_validationResult.Error = $"&field1 must not end '{_validationParameterLowecase}'.";
						break;
					case ValidationTypes.MustNotContain:
						if (value.Contains(_validationParameterLowecase))
							_validationResult.Error = $"&field1 must not contain '{_validationParameterLowecase}'.";
						break;
					case ValidationTypes.StartWith:
						if (!value.StartsWith(_validationParameterLowecase))
							_validationResult.Error = $"&field1 must start with '{_validationParameterLowecase}'";
						break;
				}
			}

			return validate();
		}
		/// <summary>
		/// Define if the struct is valid or not
		/// </summary>
		static ValidationStructResult validate()
		{
			var _result = _validationResult;

			//if note is empty then is validated
			_result.IsValid =_result.Error==null||_result.Error.Length==0;

			return _result;
		}
	}
}
