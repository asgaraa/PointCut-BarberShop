using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Gallery;
using ServiceLayer.DTOs.Settings;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
	public class SettingsService : ISettingService
	{
		private readonly ISettingsRepository _repository;
		private readonly IMapper _mapper;
		public SettingsService(ISettingsRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task CreateAsync(SettingDto settingDto)
		{
			settingDto.Id = Guid.NewGuid().ToString("N");
			var model = _mapper.Map<Settings>(settingDto);
			await _repository.CreateAsync(model);
		}

		public async Task DeleteAsync(string id)
		{
			var gallery = await _repository.GetAsync(id);
			await _repository.DeleteAsync(gallery);
		}

		public async Task<List<SettingDto>> GetAllAsync()
		{
			var model = await _repository.GetAllAsync();
			var res = _mapper.Map<List<SettingDto>>(model);
			return res;
		}

		public async Task<SettingDto> GetAsync(string id)
		{
			var model = await _repository.GetAsync(id);
			var res = _mapper.Map<SettingDto>(model);
			return res;
		}



		public async Task UpdateAsync(string Id, SettingsEditDto settingsEditDto)
		{
			var entity = await _repository.GetAsync(Id);

			_mapper.Map(settingsEditDto, entity);

			await _repository.UpdateAsync(entity);
		}
	}
}
