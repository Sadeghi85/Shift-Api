using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Bussiness {

	public interface IRayanSettingsService {
		Task<string> GetSettingValue(string settingName, RayanSettingType settingModule);

		Task<string> GetSettingValue(string settingName, RayanSettingType settingModule, int portalID);
	}
}
