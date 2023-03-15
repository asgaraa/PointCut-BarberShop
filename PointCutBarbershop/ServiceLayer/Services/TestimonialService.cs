using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Gallery;
using ServiceLayer.DTOs.Team;
using ServiceLayer.DTOs.Testimonial;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
	public class TestimonialService : ITestimonialService
	{
		private readonly ITestimonialRepository _repository;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;
        public TestimonialService(ITestimonialRepository repository, IMapper mapper, IWebHostEnvironment env)
		{
			_repository = repository;
			_mapper = mapper;
			_env = env;
		}

		public async Task CreateAsync(TestimonialDto testimonialDto)
		{
			testimonialDto.Id = Guid.NewGuid().ToString("N");


            if (!testimonialDto.Photo.CheckFileSize(10000)) throw new NullReferenceException();

            if (!testimonialDto.Photo.CheckFileType("image/")) throw new NullReferenceException();

            string file1 = Guid.NewGuid().ToString() + "_" + testimonialDto.Photo.FileName;
            string path1 = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Testimonial", file1);

            using (FileStream stream = new FileStream(path1, FileMode.Create))
            {
                await testimonialDto.Photo.CopyToAsync(stream);
            }




            testimonialDto.Image = file1;
            var model = _mapper.Map<Testimonial>(testimonialDto);
			await _repository.CreateAsync(model);
		}

		public async Task DeleteAsync(string id)
		{
			var gallery = await _repository.GetAsync(id);
			await _repository.DeleteAsync(gallery);
		}

		public async Task<List<TestimonialDto>> GetAllAsync()
		{
			var model = await _repository.GetAllAsync();
			var res = _mapper.Map<List<TestimonialDto>>(model);
			return res;
		}

		public async Task<TestimonialEditDto> GetAsync(string id)
		{
			var model = await _repository.GetAsync(id);
			var res = _mapper.Map<TestimonialEditDto>(model);
			return res;
		}



		public async Task UpdateAsync(string Id, TestimonialEditDto testimonialEditDto)
		{
			var entity = await _repository.GetAsync(Id);

            if (testimonialEditDto.Photo == null)
            {
                testimonialEditDto.Image = entity.Image;
            }
            else
            {
                if (!testimonialEditDto.Photo.CheckFileSize(10000)) throw new NullReferenceException();

                if (!testimonialEditDto.Photo.CheckFileType("image/")) throw new NullReferenceException();

                string path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Testimonial", entity.Image);
                Helper.DeleteFile(path);

                string fileName = Guid.NewGuid().ToString() + "_" + testimonialEditDto.Photo.FileName;
                path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Testimonial", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await testimonialEditDto.Photo.CopyToAsync(stream);
                }

                testimonialEditDto.Image = fileName;
            }


            if (testimonialEditDto.Name == null)
            {
                testimonialEditDto.Name = entity.Name;
            }
            if (testimonialEditDto.Job == null)
            {
                testimonialEditDto.Job = entity.Job;
            }
            if (testimonialEditDto.Comment == null)
            {
                testimonialEditDto.Comment = entity.Comment;
            }


            _mapper.Map(testimonialEditDto, entity);
			await _repository.UpdateAsync(entity);
		}
	}
}
