using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Repositories;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Gallery;
using ServiceLayer.DTOs.Salon;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
	public class SalonService : ISalonService
	{
		private readonly ISalonRepository _repository;
		private readonly IMapper _mapper;
	    private readonly IWebHostEnvironment _env;
		public SalonService(ISalonRepository repository, IMapper mapper, IWebHostEnvironment env)
		{
			_repository = repository;
			_mapper = mapper;
			_env = env;
		}

		public async Task CreateAsync(SalonDto salonDto)
		{


			salonDto.Id = Guid.NewGuid().ToString("N");
            if (!salonDto.Image1.CheckFileSize(10000)) throw new NullReferenceException();

            if (!salonDto.Image1.CheckFileType("image/")) throw new NullReferenceException();

            string file1 = Guid.NewGuid().ToString() + "_" + salonDto.Image1.FileName;
            string path1 = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Salon", file1);

            using (FileStream stream = new FileStream(path1, FileMode.Create))
            {
                await salonDto.Image1.CopyToAsync(stream);
            }


            if (!salonDto.Image2.CheckFileSize(10000)) throw new NullReferenceException();

            if (!salonDto.Image2.CheckFileType("image/")) throw new NullReferenceException();

            string file2 = Guid.NewGuid().ToString() + "_" + salonDto.Image1.FileName;
            string path2 = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Salon", file2);

            using (FileStream stream2 = new FileStream(path2, FileMode.Create))
            {
                await salonDto.Image2.CopyToAsync(stream2);
            }


			salonDto.ImageForMen = file1;
			salonDto.ImageForWomen = file2;
            var model = _mapper.Map<Salon>(salonDto);
			await _repository.CreateAsync(model);
		}

		public async Task DeleteAsync(string id)
		{
			var gallery = await _repository.GetAsync(id);
			await _repository.DeleteAsync(gallery);
		}

		public async Task<List<SalonDto>> GetAllAsync()
		{
			var model = await _repository.GetAllAsync();
			var res = _mapper.Map<List<SalonDto>>(model);
			return res;
		}

		public async Task<SalonEditDto> GetAsync(string id)
		{
			var model = await _repository.GetAsync(id);
			var res = _mapper.Map<SalonEditDto>(model);
			return res;
		}



		public async Task UpdateAsync(string Id, SalonEditDto salonEditDto)
		{
			var entity = await _repository.GetAsync(Id);

			if (salonEditDto.Image1== null)
			{
				salonEditDto.ImageForMen = entity.ImageForMen;
			}
			else
			{
                if (!salonEditDto.Image1.CheckFileSize(10000)) throw new NullReferenceException();

                if (!salonEditDto.Image1.CheckFileType("image/")) throw new NullReferenceException();

                string path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Salon", entity.ImageForMen);
                Helper.DeleteFile(path);

                string fileName = Guid.NewGuid().ToString() + "_" + salonEditDto.Image1.FileName;
                path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Salon", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await salonEditDto.Image1.CopyToAsync(stream);
                }

				salonEditDto.ImageForMen = fileName;

            }

            if (salonEditDto.Image2 == null)
            {
                salonEditDto.ImageForWomen = entity.ImageForWomen;
            }
            else
            {
                if (!salonEditDto.Image2.CheckFileSize(10000)) throw new NullReferenceException();

                if (!salonEditDto.Image2.CheckFileType("image/")) throw new NullReferenceException();

                string path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Salon", entity.ImageForWomen);
                Helper.DeleteFile(path);

                string fileName = Guid.NewGuid().ToString() + "_" + salonEditDto.Image2.FileName;
                path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Salon", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await salonEditDto.Image2.CopyToAsync(stream);
                }

                salonEditDto.ImageForWomen = fileName;

            }

			if (salonEditDto.AboutSalon==null)
			{
				salonEditDto.AboutSalon = entity.AboutSalon;
			}
			if (salonEditDto.Welcome==null)
			{
				salonEditDto.Welcome = entity.Welcome;
			}
			if (salonEditDto.Pricing == null)
			{
				salonEditDto.Pricing = entity.Pricing;
			}
			if (salonEditDto.TitleForMen== null)
			{
				salonEditDto.TitleForMen = entity.TitleForMen;
			}
			if (salonEditDto.TitleForWomen== null)
			{
				salonEditDto.TitleForWomen = entity.TitleForWomen;
			}

            _mapper.Map(salonEditDto, entity);

			await _repository.UpdateAsync(entity);
		}
	}
}
