using MATA.BL.Interfaces;
using MATA.BL.Mappers;
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
    public class CountryBL: ICountryBL
    {
        readonly IMapper<Country, vCountry, CountryDTO> mapper;

        public CountryBL(IMapper<Country, vCountry, CountryDTO> mapper)
        {
            this.mapper = mapper;
        }

        public int Create(CountryDTO countryDTO, string tokenString, IUnitOfWork uow)
        {
            var country = mapper.MapToEntity(countryDTO);

            uow.CountryRepository.Create(country);
            uow.SaveChanges(tokenString);

            return country.ID;
        }

        public void Update(int id, CountryDTO dto, string tokenString, IUnitOfWork uow)
        {
            var country = uow.CountryRepository.GetByID(id);

            country.CountryName = dto.CountryName;

            uow.CountryRepository.Update(country);
            uow.SaveChanges(tokenString);
        }

        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var country = uow.CountryRepository.GetByID(id);

            uow.CountryRepository.Delete(country);
            uow.SaveChanges(tokenString);
        }

        public CountryDTO Get(int id, IUnitOfWork uow)
        {
            var country = uow.CountryRepository.GetViewByID(id);

            return mapper.MapToDTO(country);
        }

        public int Count(IUnitOfWork uow)
        {
            return uow.CountryRepository.GetCount();
        }

        public async Task<IEnumerable<CountryDTO>> GetCountries(int skip, int take, IUnitOfWork uow)
        {
            var countryList = new List<vCountry>();

            var countries = uow.CountryRepository.Find().OrderBy(q => q.CountryName).ThenBy(q => q.ID);

            if (skip == 0 && take == 0)
            {
                countryList = await countries.ToListAsync();
            }
            else
            {
                countryList = await countries.Skip(skip).Take(take).ToListAsync();
            }

            return countryList.Select(q => mapper.MapToDTO(q));
        }

        public async Task<IEnumerable<CountryDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            var countries = uow.CountryRepository.Find();

            if (!string.IsNullOrWhiteSpace(q))
            {
                countries = countries.Where(c => c.CountryName.Contains(q));
            }

            var countryList = await countries.OrderBy(c => c.CountryName).ThenBy(c => c.ID).Skip(skip).Take(take).ToListAsync();

            return countryList.Select(c => mapper.MapToDTO(c));
        }
    }
}
