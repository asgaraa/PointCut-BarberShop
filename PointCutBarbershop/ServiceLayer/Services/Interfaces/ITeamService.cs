using ServiceLayer.DTOs.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
	public interface ITeamService
	{
		Task CreateAsync(TeamDto teamDto);

		Task UpdateAsync(string Id, TeamEditDto teamEditDto);
		Task DeleteAsync(string id);
		Task<List<TeamDto>> GetAllAsync();
		Task<TeamEditDto> GetAsync(string id);
	}
}
