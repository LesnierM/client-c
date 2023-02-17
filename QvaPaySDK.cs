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
        public delegate void ErrorEventHandler(ErrorStruct errors);
        #endregion

        #region Events
        public event ParameterlessEventHandler OnLogin;
        public event ParameterlessEventHandler OnRegister;
        public event ParameterlessEventHandler OnLogout;
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

            var _body = createStringContent(EndpointsParameterProvider.GetParameters(Categories.Auth, AuthEndpoints.Login, new string[] { email, password }));

            var _response = await _client.PostAsync(_client.BaseAddress, _body);

            var _responseString = await _response.Content.ReadAsStringAsync();

            if (_response.IsSuccessStatusCode)
            {
                _loginResult = JsonConvert.DeserializeObject<LoginResultStruct>(_responseString);

                if (OnLogin != null)
                    OnLogin();
            }
            else if (OnError != null)
                OnError(ErrorProvider.ParseError(_responseString,Categories.Auth,AuthEndpoints.Login));

        }
        /// <summary>
        /// Registes a new user in the system with the information provided.
        /// </summary>
        /// <param name="data">The registration data needed.</param>
        public async void Register(RegiserStruct data)
        {
            var _client=getClient(Categories.Auth, AuthEndpoints.Register);

            var _body =createStringContent(JsonConvert.SerializeObject(data));

			var _response = await _client.PostAsync(_client.BaseAddress, _body);

			var _responseString = await _response.Content.ReadAsStringAsync();

			if (_response.IsSuccessStatusCode)
			{
				_loginResult = JsonConvert.DeserializeObject<LoginResultStruct>(_responseString);

				if (OnLogin != null)
					OnLogin();
			}
			else if (OnError != null)
				OnError(ErrorProvider.ParseError(_responseString,Categories.Auth,AuthEndpoints.Register));
		}
        /// <summary>
        /// Logout the aunthenticated user.
        /// </summary>
        public async void Logout()
        {
            var _client = getClient(Categories.Auth, AuthEndpoints.Logout,true);

			var _response = await _client.GetAsync(_client.BaseAddress);

			var _responseString = await _response.Content.ReadAsStringAsync();

			if (_response.IsSuccessStatusCode)
			{
				_loginResult = JsonConvert.DeserializeObject<LoginResultStruct>(_responseString);

				if (OnLogout != null)
					OnLogout();
			}
			else if (OnError != null)
				OnError(ErrorProvider.ParseError(_responseString,Categories.Auth,AuthEndpoints.Logout));
		}
        #endregion

        #region Methods
        /// <summary>
        /// Creates the body of the request with the provided json.
        /// </summary>
        /// <param name="json">The body in json format</param>
        StringContent createStringContent(string json)
        {
            return new StringContent(json, Encoding.UTF8, REQUEST_HEADER_ACCEPT);
		}
        /// <summary>
        /// Creates a new httpclient and populate it with the endpoint and parameters.
        /// </summary>
        /// <typeparam name="T">An endpoint enum.</typeparam>
        /// <param name="category">The category of the endpoint.</param>
        /// <param name="endpoint">The endpoint to call.</param>
        HttpClient getClient<T>(Categories category, T endpoint,bool useAuthentication=false) where T : Enum
        {
            var _client = new HttpClient();
            //url
            _client.BaseAddress = new Uri(Path.Combine(API_DOMAIN, category.ToUrlString(), (endpoint as Enum).ToUrlString()));
            //headers
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(REQUEST_HEADER_ACCEPT));

            if (useAuthentication)
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _loginResult.AccessToken);
            //_client.DefaultRequestHeaders.Add("Token",$"<{_loginResult.AccessToken}>");

            return _client;
        }
        #endregion

        #region Properties
        public UserInformationStruct UserInformation => _loginResult.Me;
		#endregion
	}
}
