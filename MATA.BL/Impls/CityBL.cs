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
    public class CityBL: ICityBL
    {
        readonly IMapper<City, vCity, CityDTO> mapper;

        public CityBL(IMapper<City, vCity, CityDTO> mapper)
        {
            this.mapper = mapper;
        }

        public int Count(IUnitOfWork uow)
        {
            return uow.CityRepository.GetCount();
        }

        public int Create(CityDTO cityDTO, string tokenString, IUnitOfWork uow)
        {
            var city = mapper.MapToEntity(cityDTO);

            uow.CityRepository.Create(city);
            uow.SaveChanges(tokenString);

            return city.ID;
        }

        public void Update(int id, CityDTO dto, string tokenString, IUnitOfWork uow)
        {
            var city = uow.CityRepository.GetByID(id);

            city.CountryID = dto.CountryID;
            city.CityName = dto.CityName;

            uow.CityRepository.Update(city);
            uow.SaveChanges(tokenString);
        }

        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var city = uow.CityRepository.GetByID(id);

            uow.CityRepository.Delete(city);
            uow.SaveChanges(tokenString);
        }

        public CityDTO Get(int id, IUnitOfWork uow)
        {
            var city = uow.CityRepository.GetViewByID(id);

            return mapper.MapToDTO(city);
        }

        public async Task<IEnumerable<CityDTO>> GetCities(int skip, int take, IUnitOfWork uow)
        {
            var cityList = new List<vCity>();

            var cities = uow.CityRepository.Find().OrderBy(q => q.CountryName).ThenBy(q => q.CityName).ThenBy(q => q.ID);

            if (skip == 0 && take == 0)
            {
                cityList = await cities.ToListAsync();
            }
            else
            {
                cityList = await cities.Skip(skip).Take(take).ToListAsync();
            }

            return cityList.Select(q => mapper.MapToDTO(q));
        }

        public IEnumerable<CityDTO> GetCitiesByCountry(int countryID, IUnitOfWork uow)
        {
            var cities = uow.CityRepository.Find(q => q.CountryID == countryID).OrderBy(q => q.CityName).ThenBy(q => q.ID).ThenBy(q => q.ID);

            return cities.Select(q => mapper.MapToDTO(q));
        }

        public async Task<IEnumerable<CityDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.CityRepository.Find();

            if (!string.IsNullOrWhiteSpace(q))
            {
                items = items.Where(c => c.CityName.Contains(q));
            }

            var itemList = await items.OrderBy(c => c.CityName).ThenBy(c => c.ID).Skip(skip).Take(take).ToListAsync();

            return itemList.Select(c => mapper.MapToDTO(c));
        }
    }
}
