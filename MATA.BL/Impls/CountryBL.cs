using MATA.BL.Filters;
using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using MATA.Infrastructure.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    public class CountryBL: ICountryBL
    {
        private readonly IMapper<Country, vCountry, CountryDTO> mapper;

        private const string CacheKey = "CountryBL";

        public CountryBL(IMapper<Country, vCountry, CountryDTO> mapper)
        {
            this.mapper = mapper;
        }

        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        public int Create(CountryDTO countryDTO, string tokenString, IUnitOfWork uow)
        {
            var country = mapper.MapToEntity(countryDTO);

            uow.CountryRepository.Create(country);
            uow.SaveChanges(tokenString);

            return country.ID;
        }

        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        public void Update(int id, CountryDTO dto, string tokenString, IUnitOfWork uow)
        {
            var country = uow.CountryRepository.GetByID(id);

            country.CountryName = dto.CountryName;

            uow.CountryRepository.Update(country);
            uow.SaveChanges(tokenString);
        }

        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var country = uow.CountryRepository.GetByID(id);

            if (country.City.Any())
            {
                throw new BusinessException("You can not delete this country");
            }

            uow.CountryRepository.Delete(country);
            uow.SaveChanges(tokenString);
        }

        [CustomCache(CacheKey = CacheKey)]
        public CountryDTO Get(int id, IUnitOfWork uow)
        {
            var country = uow.CountryRepository.GetViewByID(id);

            return mapper.MapToDTO(country);
        }

        [CustomCache(CacheKey = CacheKey)]
        public int Count(IUnitOfWork uow)
        {
            return uow.CountryRepository.GetCount();
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<CountryDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            var countries = uow.CountryRepository.Find();

            if (!string.IsNullOrWhiteSpace(q))
            {
                countries = countries.Where(c => c.CountryName.Contains(q));
            }

            return await OrderCountries(countries, skip, take);
        }

        private async Task<IEnumerable<CountryDTO>> OrderCountries(IQueryable<vCountry> countries, int skip, int take)
        {
            var countryList = await countries.OrderBy(c => c.CountryName).ThenBy(c => c.ID).Skip(skip).Take(take).ToListAsync();

            return countryList.Select(c => mapper.MapToDTO(c));
        }
    }
}
