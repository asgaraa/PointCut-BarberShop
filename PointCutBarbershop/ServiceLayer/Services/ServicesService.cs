using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Gallery;
using ServiceLayer.DTOs.HeroWrap;
using ServiceLayer.DTOs.Pricing;
using ServiceLayer.DTOs.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
	public class ServicesService : IServicesService
	{
		private readonly IServicesRepository _repository;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;

		public ServicesService(IServicesRepository repository, IMapper mapper, IWebHostEnvironment env)
		{
			_repository = repository;
			_mapper = mapper;
			_env = env;
		}

		public async Task CreateAsync(ServicesDto servicesDto)
		{
			servicesDto.Id = Guid.NewGuid().ToString("N");
			if (!servicesDto.Photo.CheckFileSize(10000)) throw new NullReferenceException();

			if (!servicesDto.Photo.CheckFileType("image/")) throw new NullReferenceException();

			string file1 = Guid.NewGuid().ToString() + "_" + servicesDto.Photo.FileName;
			string path1 = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Services", file1);

			using (FileStream stream = new FileStream(path1, FileMode.Create))
			{
				await servicesDto.Photo.CopyToAsync(stream);
			}




			servicesDto.FlaIconName = file1;
			var model = _mapper.Map<Servis>(servicesDto);
			await _repository.CreateAsync(model);
		}

		public async Task DeleteAsync(string id)
		{
			var gallery = await _repository.GetAsync(id);
			await _repository.DeleteAsync(gallery);
		}

		public async Task<List<ServicesDto>> GetAllAsync()
		{
			var model = await _repository.GetAllAsync();
			var res = _mapper.Map<List<ServicesDto>>(model);
			return res;
		}

		public async Task<ServicesEditDto> GetAsync(string id)
		{
			var model = await _repository.GetAsync(id);
			var res = _mapper.Map<ServicesEditDto>(model);
			return res;
		}



		public async Task UpdateAsync(string Id, ServicesEditDto servicesEditDto)
		{
			var entity = await _repository.GetAsync(Id);

			if (servicesEditDto.Photo == null)
			{
				servicesEditDto.FlaIconName = entity.FlaIconName;
			}
			else
			{
				if (!servicesEditDto.Photo.CheckFileSize(10000)) throw new NullReferenceException();

				if (!servicesEditDto.Photo.CheckFileType("image/")) throw new NullReferenceException();

				string path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Services", entity.FlaIconName);
				Helper.DeleteFile(path);

				string fileName = Guid.NewGuid().ToString() + "_" + servicesEditDto.Photo.FileName;
				path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Services", fileName);
				using (FileStream stream = new FileStream(path, FileMode.Create))
				{
					await servicesEditDto.Photo.CopyToAsync(stream);
				}

				servicesEditDto.FlaIconName = fileName;

			}

			if (servicesEditDto.Title == null)
			{
                servicesEditDto.Title = entity.Title;
			}
            if (servicesEditDto.Description == null)
			{
                servicesEditDto.Description = entity.Description;
            }
          

            _mapper.Map(servicesEditDto, entity);

			await _repository.UpdateAsync(entity);
		}
	}
}
