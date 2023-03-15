using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Gallery;
using ServiceLayer.DTOs.HeroWrap;
using ServiceLayer.DTOs.Team;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
	public class TeamService : ITeamService
	{
		private readonly ITeamRepository _repository;
		private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public TeamService(ITeamRepository repository, IMapper mapper, IWebHostEnvironment env)
		{
			_repository = repository;
			_mapper = mapper;
			_env = env;
		}

		public async Task CreateAsync(TeamDto teamDto)
		{
			teamDto.Id = Guid.NewGuid().ToString("N");


            if (!teamDto.Photo.CheckFileSize(10000)) throw new NullReferenceException();

            if (!teamDto.Photo.CheckFileType("image/")) throw new NullReferenceException();

            string file1 = Guid.NewGuid().ToString() + "_" + teamDto.Photo.FileName;
            string path1 = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Team", file1);

            using (FileStream stream = new FileStream(path1, FileMode.Create))
            {
                await teamDto.Photo.CopyToAsync(stream);
            }




            teamDto.Image = file1;
            var model = _mapper.Map<Team>(teamDto);
			await _repository.CreateAsync(model);
		}

		public async Task DeleteAsync(string id)
		{
			var team = await _repository.GetAsync(id);
			await _repository.DeleteAsync(team);
		}

		public async Task<List<TeamDto>> GetAllAsync()
		{
			var model = await _repository.GetAllAsync();
			var res = _mapper.Map<List<TeamDto>>(model);
			return res;
		}

		public async Task<TeamEditDto> GetAsync(string id)
		{
			var model = await _repository.GetAsync(id);
			var res = _mapper.Map<TeamEditDto>(model);
			return res;
		}



		public async Task UpdateAsync(string Id, TeamEditDto teamEditDto)
		{
			var entity = await _repository.GetAsync(Id);

            if (teamEditDto.Photo == null)
            {
                teamEditDto.Image = entity.Image;
			}
			else
			{
                if (!teamEditDto.Photo.CheckFileSize(10000)) throw new NullReferenceException();

                if (!teamEditDto.Photo.CheckFileType("image/")) throw new NullReferenceException();

                string path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Team", entity.Image);
				Helper.DeleteFile(path);

                string fileName = Guid.NewGuid().ToString() + "_" + teamEditDto.Photo.FileName;
                path = Helper.GetFilePath(_env.WebRootPath, "Assets/images/Team", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
				{
                    await teamEditDto.Photo.CopyToAsync(stream);
				}

                teamEditDto.Image = fileName;
			}


            if (teamEditDto.Name == null)
            {
                teamEditDto.Name = entity.Name;
            }
            if (teamEditDto.Job == null)
            {
                teamEditDto.Job = entity.Job;
            }

            _mapper.Map(teamEditDto, entity);

			await _repository.UpdateAsync(entity);
		}
	}
}
