using ServiceLayer.DTOs.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
	public interface ISettingService
	{
		Task CreateAsync(SettingDto settingDto);

		Task UpdateAsync(string Id, SettingsEditDto settingsEditDto);
		Task DeleteAsync(string id);
		Task<List<SettingDto>> GetAllAsync();
		Task<SettingDto> GetAsync(string id);
	}
}
