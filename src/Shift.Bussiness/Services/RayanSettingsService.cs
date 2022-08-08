using Shift.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {
	public class RayanSettingsService : ServiceBase, IRayanSettingsService {


		private readonly IRayanSettingStore _rayanSettingStore;

		public RayanSettingsService(IPrincipal iPrincipal, IRayanSettingStore rayanSettingStore, IShiftLogStore shiftLogStore) : base(iPrincipal, shiftLogStore) {
			_rayanSettingStore = rayanSettingStore;
		}



		public async Task<string> GetSettingValue(string settingName, RayanSettingType settingModule) {
			var settings = await _rayanSettingStore.GetAllAsync(t => t.SettingModule == (int) settingModule, x => x, x => x.Id);

			var i = settings.Result.SingleOrDefault(x => x.SettingName == settingName);
			if (i != null) {
				return i.SettingValue;
			}
			return "";
		}

		public async Task<string> GetSettingValue(string settingName, RayanSettingType settingModule, int portalID) {
			var settings = await _rayanSettingStore.GetAllAsync(t => t.SettingModule == (int) settingModule && t.PortalId == portalID, x => x, x => x.Id);

			var i = settings.Result.SingleOrDefault(x => x.SettingName == settingName);
			if (i != null) {
				return i.SettingValue;
			}
			return "";
		}
	}
}
