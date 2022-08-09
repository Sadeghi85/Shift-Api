using Microsoft.AspNetCore.Authorization;
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
		private const string CookieDomain = "localhost";


		public UserService(IPrincipal iPrincipal, IUserStore userStore, IShiftLogStore shiftLogStore
			, IRayanSettingsService rayanSettingsService
			, IHttpContextAccessor httpContextAccessor) : base(iPrincipal, shiftLogStore) {

			_userStore = userStore;
			_rayanSettingsService = rayanSettingsService;
			_token_server = _rayanSettingsService.GetSettingValue("Samt.Token.Address", RayanSettingType.SystemSetting).Result;

			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<UserInfoViewModel?> GetUserInfoAsync() {

			var uId = CurrentUserId;
			if (null == uId) {
				return null;
			}

			var uInfo = await _userStore.FindByIdAsync(uId);
			if (null == uInfo) {
				return null;
			}

			var userInfoViewModelResult = new UserInfoViewModel() {
				FirstName = uInfo.FirstName,
				LastName = uInfo.LastName,
				FullName = uInfo.FirstName + " " + uInfo.LastName,
				PortalId = uInfo.PortalId,
				//UserId = uInfo.Id,
			};

			var userPermissionsList = await _userStore.GetUserPermissions(uId.Value);
			userInfoViewModelResult.Permissions = userPermissionsList.Select(x => x.ModuleKey).ToList();
			return userInfoViewModelResult;
			//string t1 = "WebService/PortalWebService.asmx/GetToken";
			////using var httpClient = new HttpClient();
			//var request = _httpContextAccessor.HttpContext.Request;
			//string rtCookieValue = _httpContextAccessor.HttpContext.Request.Cookies[COOKIEIDENTIFIER];
			//var client2 = new RestClient(_token_server);
			//client2.AddCookie(COOKIEIDENTIFIER, rtCookieValue, CookiePath, CookieDomain);
			//var samtTokenRequest = new RestRequest(_token_server + t1, Method.Post);
			////samtTokenRequest.Method = Method.Post;
			//samtTokenRequest.AddHeader("Content-Type", "application/json; charset=utf-8");
			//samtTokenRequest.AddBody(new { refresh_token = (string?) null });
			////samtTokenRequest.AddParameter("refresh_token", null);
			//var samtTokenResponse = await client2.ExecuteAsync(samtTokenRequest);
			//if (samtTokenResponse.StatusCode != HttpStatusCode.OK) {
			//	//_iOauthLogServ.AddLog("response2.Content is : " + response2.Content ?? "", 0);
			//	//return;
			//}
			//var tokenresult = samtTokenResponse.Content ?? "";
			//var samtToken = JsonSerializer.Deserialize<ApiToken>(tokenresult);

			//userInfoViewModelResult.Token = samtToken;
			//return userInfoViewModelResult;
		}

		public async Task<bool> HasUserPermission(int userId, string permissionKey) {
			return await _userStore.HasUserPermission(userId, permissionKey);
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
