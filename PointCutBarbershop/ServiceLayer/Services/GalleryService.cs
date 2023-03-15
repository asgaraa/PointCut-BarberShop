using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
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
	public class GalleryService : IGalleryService
	{
		private readonly IGalleryRepository _repository;
		private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public GalleryService(IGalleryRepository repository, IMapper mapper, IWebHostEnvironment env)
		{
			_repository = repository;
			_mapper = mapper;
			_env = env;
		}

		public async Task CreateAsync(GalleryDto galleryDto)
		{
			galleryDto.Id = Guid.NewGuid().ToString("N");
		
            if (!galleryDto.Photo.CheckFileSize(10000)) throw new NullReferenceException();

            if (!galleryDto.Photo.CheckFileType("image/")) throw new NullReferenceException();

            string file1 = Guid.NewGuid().ToString() + "_" + galleryDto.Photo.FileName;
            string path1 = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Gallery", file1);

            using (FileStream stream = new FileStream(path1, FileMode.Create))
			{
                await galleryDto.Photo.CopyToAsync(stream);
			}




            galleryDto.Image = file1;
           
            var model = _mapper.Map<Gallery>(galleryDto);
			await _repository.CreateAsync(model);
		}

		public async Task DeleteAsync(string id)
		{
			var gallery = await _repository.GetAsync(id);
			await _repository.DeleteAsync(gallery);
		}

		public async Task<List<GalleryDto>> GetAllAsync()
		{
			var model = await _repository.GetAllAsync();
			var res = _mapper.Map<List<GalleryDto>>(model);
			return res;
		}

		public async Task<GalleryEditDto> GetAsync(string id)
		{
			var model = await _repository.GetAsync(id);
			var res = _mapper.Map<GalleryEditDto>(model);
			return res;
		}



		public async Task UpdateAsync(string Id, GalleryEditDto galleryEditDto)
		{
			var entity = await _repository.GetAsync(Id);

            if (galleryEditDto.Photo == null)
            {
                galleryEditDto.Image = entity.Image;
            }
            else
            {
                if (!galleryEditDto.Photo.CheckFileSize(10000)) throw new NullReferenceException();

                if (!galleryEditDto.Photo.CheckFileType("image/")) throw new NullReferenceException();

                string path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Gallery", entity.Image);
                Helper.DeleteFile(path);

                string fileName = Guid.NewGuid().ToString() + "_" + galleryEditDto.Photo.FileName;
                path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Gallery", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await galleryEditDto.Photo.CopyToAsync(stream);
                }

                galleryEditDto.Image = fileName;

            }

            
            if (galleryEditDto.Project == null)
            {
                galleryEditDto.Project = entity.Project;
            }
            if (galleryEditDto.Title == null)
            {
                galleryEditDto.Title = entity.Title;
            }
          

            _mapper.Map(galleryEditDto, entity);

			await _repository.UpdateAsync(entity);
		}
	}
}
