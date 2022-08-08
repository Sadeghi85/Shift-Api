using Microsoft.AspNetCore.Http;
using RestSharp;
using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shift.Bussiness.Services {

	public class UserService : ServiceBase, IUserService {


		private readonly IUserStore _userStore;
		private readonly IRayanSettingsService _rayanSettingsService;
		private readonly string _token_server;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private const string COOKIEIDENTIFIER = "rtcookie";
		private const string CookiePath = "/";
		private const string CookieDomain = "smt.irib.ir";


		public UserService(IPrincipal iPrincipal, IUserStore userStore, IShiftLogStore shiftLogStore
			, IRayanSettingsService rayanSettingsService
			, IHttpContextAccessor httpContextAccessor) : base(iPrincipal, shiftLogStore) {

			_userStore = userStore;
			_rayanSettingsService = rayanSettingsService;
			_token_server = _rayanSettingsService.GetSettingValue("Samt.Token.Address", RayanSettingType.SystemSetting).Result;

			_httpContextAccessor = httpContextAccessor;
		}

		public UserInfoViewModel GetUserInfo() {

			//using var httpClient = new HttpClient();
			var request = _httpContextAccessor.HttpContext.Request;
			string rtCookieValue = _httpContextAccessor.HttpContext.Request.Cookies[COOKIEIDENTIFIER];

			var client2 = new RestClient(_token_server);
			client2.AddCookie(COOKIEIDENTIFIER, rtCookieValue, CookiePath, CookieDomain);
			var samtTokenRequest = new RestRequest();
			samtTokenRequest.AddHeader("Content-Type", "application/json; charset=utf-8");
			samtTokenRequest.AddParameter("refresh_token", null);
			var samtTokenResponse = client2.Execute(samtTokenRequest);
			if (samtTokenResponse.StatusCode != HttpStatusCode.OK) {
				//_iOauthLogServ.AddLog("response2.Content is : " + response2.Content ?? "", 0);
				//return;
			}
			var tokenresult = samtTokenResponse.Content ?? "";
			var samtToken = JsonSerializer.Deserialize<ApiToken>(tokenresult);

			return null;



			//var localIdentityRequest = new RestRequest();
			//localIdentityRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");


			//localIdentityRequest.AddParameter("client_id", LocalSsoConstants.SHIFT_CLIENT_NAME);
			//localIdentityRequest.AddParameter("client_secret", LocalSsoConstants.SHIFT_CLIENT_SECRET);

			//if (string.IsNullOrWhiteSpace(refresh_token)) {
			//	//it is first token
			//	localIdentityRequest.AddParameter("grant_type", LocalSsoConstants.SHIFT_CLIENT_GRANT);
			//	localIdentityRequest.AddParameter("uname", _portalUser.UserName);
			//	localIdentityRequest.AddParameter("scope", LocalSsoConstants.SHIFT_CLIENT_SCOPE);
			//	_iOauthLogServ.AddLog("Exchanging User By Local Identity: " + oAUTH_SERVER + ", user is:" + _portalUser.UserName, 0);
			//} else {
			//	localIdentityRequest.AddParameter("grant_type", LocalSsoConstants.REFRESH_TOKEN);
			//	localIdentityRequest.AddParameter(LocalSsoConstants.REFRESH_TOKEN, refresh_token);
			//	_iOauthLogServ.AddLog("Refreshing Token for: " + _portalUser.UserName + ", RT: " + refresh_token, 0);
			//}

			//ApiToken bearerToken2 = null;
			//try {
			//	IRestResponse response2 = client2.Execute(localIdentityRequest);
			//	if (response2.StatusCode != HttpStatusCode.OK) {
			//		_iOauthLogServ.AddLog("response2.Content is : " + response2.Content ?? "", 0);
			//		return;
			//	}
			//	var tokenresult = response2.Content ?? "";
			//	bearerToken2 = serializer.Deserialize<ApiToken>(tokenresult);
			//} catch (Exception ex3) {
			//	_iOauthLogServ.AddLog("Exchange has errors: " + oAUTH_SERVER + ", user is:" + _portalUser.UserName, 0);
			//	_iOauthLogServ.AddLog("ex3 is: " + ex3.Message ?? "", 0);
			//	return;
			//}

			//if (null == bearerToken2) {
			//	_iOauthLogServ.AddLog("Local Token is null", 0);
			//	return;
			//}
			//SerializeIt(bearerToken2);


			//throw new NotImplementedException();
		}



		//public async Task<string> GetSettingValue(string settingName, RayanSettingType settingModule) {
		//	var settings = await _rayanSettingStore.GetAllAsync(t => t.SettingModule == (int) settingModule, x => x, x => x.Id);

		//	var i = settings.Result.SingleOrDefault(x => x.SettingName == settingName);
		//	if (i != null) {
		//		return i.SettingValue;
		//	}
		//	return "";
		//}

		//public async Task<string> GetSettingValue(string settingName, RayanSettingType settingModule, int portalID) {
		//	var settings = await _rayanSettingStore.GetAllAsync(t => t.SettingModule == (int) settingModule && t.PortalId == portalID, x => x, x => x.Id);

		//	var i = settings.Result.SingleOrDefault(x => x.SettingName == settingName);
		//	if (i != null) {
		//		return i.SettingValue;
		//	}
		//	return "";
		//}
	}
}
