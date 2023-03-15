using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.HeroWrap;
using ServiceLayer.Services.Interfaces;


namespace ServiceLayer.Services
{
	public class HeroWrapService : IHeroWrapService
	{
		private readonly IHeroWrapRepository _repository;
		private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public HeroWrapService(IHeroWrapRepository repository, IMapper mapper, IWebHostEnvironment env)
		{
			_repository = repository;
			_mapper = mapper;
			_env = env;
		}

		public async Task CreateAsync(HeroWrapDto heroWrapDto)
		{
			heroWrapDto.Id = Guid.NewGuid().ToString("N");

            if (!heroWrapDto.Photo.CheckFileSize(10000)) throw new NullReferenceException();

            if (!heroWrapDto.Photo.CheckFileType("image/")) throw new NullReferenceException();

            string file1 = Guid.NewGuid().ToString() + "_" + heroWrapDto.Photo.FileName;
            string path1 = Helper.GetFilePath(_env.WebRootPath, "Assets/images/HeroWrap", file1);

            using (FileStream stream = new FileStream(path1, FileMode.Create))
            {
                await heroWrapDto.Photo.CopyToAsync(stream);
            }




            heroWrapDto.Image = file1;
            var model = _mapper.Map<HeroWrap>(heroWrapDto);
			await _repository.CreateAsync(model);
		}

		public async Task DeleteAsync(string id)
		{
			var gallery = await _repository.GetAsync(id);
			await _repository.DeleteAsync(gallery);
		}

		public async Task<List<HeroWrapDto>> GetAllAsync()
		{
			var model = await _repository.GetAllAsync();
			var res = _mapper.Map<List<HeroWrapDto>>(model);
			return res;
		}

		public async Task<HeroWrapEditDto> GetAsync(string id)
		{
			var model = await _repository.GetAsync(id);
			var res = _mapper.Map<HeroWrapEditDto>(model);
			return res;
		}



		public async Task UpdateAsync(string Id, HeroWrapEditDto heroWrapEditDto)
		{
			var entity = await _repository.GetAsync(Id);

            if (heroWrapEditDto.Photo == null)
            {
                heroWrapEditDto.Image = entity.Image;
            }
            else
            {
                if (!heroWrapEditDto.Photo.CheckFileSize(10000)) throw new NullReferenceException();

                if (!heroWrapEditDto.Photo.CheckFileType("image/")) throw new NullReferenceException();

                string path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/HeroWrap", entity.Image);
                Helper.DeleteFile(path);

                string fileName = Guid.NewGuid().ToString() + "_" + heroWrapEditDto.Photo.FileName;
                path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/HeroWrap", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await heroWrapEditDto.Photo.CopyToAsync(stream);
                }

                heroWrapEditDto.Image = fileName;

            }


            if (heroWrapEditDto.Project == null)
            {
                heroWrapEditDto.Project = entity.Project;
            }
            if (heroWrapEditDto.Title == null)
            {
                heroWrapEditDto.Title = entity.Title;
            }


            _mapper.Map(heroWrapEditDto, entity);

			await _repository.UpdateAsync(entity);
		}
	}
}
