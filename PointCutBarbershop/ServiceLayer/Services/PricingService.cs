using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Gallery;
using ServiceLayer.DTOs.HeroWrap;
using ServiceLayer.DTOs.Pricing;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
	public class PricingService : IPricingService
	{
		private readonly IPricingRepository _repository;
		private readonly IMapper _mapper;
		public PricingService(IPricingRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task CreateAsync(PricingDto pricingDto)
		{
			pricingDto.Id = Guid.NewGuid().ToString("N");
			var model = _mapper.Map<Pricing>(pricingDto);
			await _repository.CreateAsync(model);
		}

		public async Task DeleteAsync(string id)
		{
			var pricing = await _repository.GetAsync(id);
			await _repository.DeleteAsync(pricing);
		}

		public async Task<List<PricingDto>> GetAllAsync()
		{
			var model = await _repository.GetAllAsync();
			var res = _mapper.Map<List<PricingDto>>(model);
			return res;
		}

		public async Task<PricingEditDto> GetAsync(string id)
		{
			var model = await _repository.GetAsync(id);
			var res = _mapper.Map<PricingEditDto>(model);
			return res;
		}



		public async Task UpdateAsync(string Id, PricingEditDto pricingEditDto)
		{
			var entity = await _repository.GetAsync(Id);

            if (pricingEditDto.Name == null)
			{
                pricingEditDto.Name = entity.Name;
			}
            if (pricingEditDto.Price == null)
			{
                pricingEditDto.Price = entity.Price;
            }
            if (pricingEditDto.Service1 == null)
            {
                pricingEditDto.Service1 = entity.Service1;
            }
            if (pricingEditDto.Service2 == null)
            {
                pricingEditDto.Service2 = entity.Service2;
            }
            if (pricingEditDto.Service3 == null)
            {
                pricingEditDto.Service3 = entity.Service3;
            }
            if (pricingEditDto.Service4 == null)
            {
                pricingEditDto.Service4 = entity.Service4;
            }
            if (pricingEditDto.Service5 == null)
            {
                pricingEditDto.Service5 = entity.Service5;
            }

            _mapper.Map(pricingEditDto, entity);

			await _repository.UpdateAsync(entity);
		}
	}
}
