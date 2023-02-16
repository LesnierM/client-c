using Newtonsoft.Json;
using QvaPay.SDK.Controllers;
using QvaPay.SDK.Enums;
using QvaPay.SDK.Enums.Endpoints;
using QvaPay.SDK.MethodExtensions;
using QvaPay.SDK.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;

namespace QvaPay.SDK
{
    public class QvaPaySDK
    {
        #region Delegates
        public delegate void ParameterlessEventHandler();
        public delegate void ErrorEventHandler(string[] errors);
        #endregion

        #region Events
        public event ParameterlessEventHandler OnLogin;
        public event ErrorEventHandler OnError;
        #endregion

        #region Constants
        /// <summary>
        /// Api domain of the endpoints.
        /// </summary>
        const string API_DOMAIN = "https://qvapay.com/api";
        const string REQUEST_HEADER_ACCEPT = "application/json";
        #endregion

        #region ResponsesData
        LoginResultStruct _loginResult;
		#endregion

		#region Public Requests
		/// <summary>
		/// Logins into the platform and save the session token for future api calls.
		/// </summary>
		/// <param name="email">Email adress of user account.</param>
		/// <param name="password">Passsword of the user account.</param>
		public async void Login(string email, string password)
        {
            var _client = getClient(Categories.Auth, AuthEndpoints.Login);

            var _body = new StringContent(EndpointsParameterProvider.GetParameters(Categories.Auth, AuthEndpoints.Login, new string[] { email, password }), Encoding.UTF8, REQUEST_HEADER_ACCEPT);

            var _response = await _client.PostAsync(_client.BaseAddress, _body);

            var _responseString = await _response.Content.ReadAsStringAsync();

            if (_response.IsSuccessStatusCode)
            {
                _loginResult = JsonConvert.DeserializeObject<LoginResultStruct>(_responseString);

                if (OnLogin != null)
                    OnLogin();
            }
            else if (OnError != null)
                OnError(JsonConvert.DeserializeObject<ErrorStruct>(_responseString).Error);

        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a new httpclient and populate it with the endpoint and parameters.
        /// </summary>
        /// <typeparam name="T">An endpoint enum.</typeparam>
        /// <param name="category">The category of the endpoint.</param>
        /// <param name="endpoint">The endpoint to call.</param>
        HttpClient getClient<T>(Categories category, T endpoint) where T : struct
        {
            var _client = new HttpClient();
            //url
            _client.BaseAddress = new Uri(Path.Combine(API_DOMAIN, category.ToUrlString(), (endpoint as Enum).ToUrlString()));
            //headers
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(REQUEST_HEADER_ACCEPT));


            return _client;
        }
        #endregion

        #region Properties
        public UserInformationStruct UserInformation => _loginResult.Me;
		#endregion
	}
}
