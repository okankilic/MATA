using MATA.BL.Filters;
using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    public class CityBL: ICityBL
    {
        private const string CacheKey = "CityBL";

        private readonly IMapper<City, vCity, CityDTO> mapper;

        public CityBL(IMapper<City, vCity, CityDTO> mapper)
        {
            this.mapper = mapper;
        }

        [CustomCache(CacheKey = CacheKey)]
        public int Count(IUnitOfWork uow)
        {
            return uow.CityRepository.GetCount();
        }

        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public int Create(CityDTO cityDTO, string tokenString, IUnitOfWork uow)
        {
            var city = mapper.MapToEntity(cityDTO);

            uow.CityRepository.Create(city);
            uow.SaveChanges(tokenString);

            return city.ID;
        }

        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public void Update(int id, CityDTO dto, string tokenString, IUnitOfWork uow)
        {
            var city = uow.CityRepository.GetByID(id);

            city.CountryID = dto.CountryID;
            city.CityName = dto.CityName;

            uow.CityRepository.Update(city);
            uow.SaveChanges(tokenString);
        }

        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var city = uow.CityRepository.GetByID(id);

            uow.CityRepository.Delete(city);
            uow.SaveChanges(tokenString);
        }

        [CustomCache(CacheKey = CacheKey)]
        public CityDTO Get(int id, IUnitOfWork uow)
        {
            var city = uow.CityRepository.GetViewByID(id);

            return mapper.MapToDTO(city);
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<CityDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.CityRepository.Find();

            if (!string.IsNullOrWhiteSpace(q))
            {
                items = items.Where(c => c.CityName.Contains(q));
            }

            return await OrderCities(items, skip, take);
        }

        [CustomCache(CacheKey = CacheKey)]
        public int GetCountryCitiesCount(int countryID, IUnitOfWork uow)
        {
            return uow.CityRepository.GetCount(q => q.CountryID == countryID);
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<CityDTO>> GetCountryCities(int countryID, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.CityRepository.Find(q => q.CountryID == countryID);

            return await OrderCities(items, skip, take);
        }

        private async Task<IEnumerable<CityDTO>> OrderCities(IQueryable<vCity> items, int skip, int take)
        {
            var itemList = await items.OrderBy(q => q.CityName).ThenBy(q => q.ID).Skip(skip).Take(take).ToListAsync();

            return itemList.Select(q => mapper.MapToDTO(q));
        }
    }
}
