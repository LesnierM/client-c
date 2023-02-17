using QvaPay.SDK.Enums;
using QvaPay.SDK.Enums.Endpoints;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace QvaPay.SDK.Controllers
{
    internal static class EndpointsParameterProvider
    {
        #region Endpoints Json parameters Template
        const string LOGIN_PARAMETERS = "{\"email\": \"@param1\",\"password\": \"@param2\"}";
        #endregion

		/// <summary>
		/// Populate the paramters string with the provided paramters of the especified endpoint.
		/// </summary>
		/// <typeparam name="T">An endpoint enum.</typeparam>
		/// <param name="category">The category.</param>
		/// <param name="endpoint">The endpoint.</param>
		/// <param name="parameters">The parameters to replance in the template in the same order.</param>
		/// <returns></returns>
        public static string GetParameters<T>(Categories category, T endpoint, string[] parameters) where T : Enum
        {
            string _result = default;

			//define parameters list
			switch (category)
			{
				case Categories.Auth:
					switch (endpoint)
					{
						case AuthEndpoints.Login:
							_result = LOGIN_PARAMETERS;
							break;
						case AuthEndpoints.Register:
							break;
						case AuthEndpoints.Logout:
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

			//populate fields
			for (int i = 0; i < parameters.Length; i++)
                _result = _result.Replace("@param" + (i+1), parameters[i]);

            return _result;
		}	
	}
}
