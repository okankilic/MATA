using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL
{
    public class CityBL: ICityBL
    {
        readonly IMapper<City, vCity, CityDTO> mapper;

        public CityBL(IMapper<City, vCity, CityDTO> mapper)
        {
            this.mapper = mapper;
        }

        public int Count(MataDBEntities db)
        {
            return db.Country.Count();
        }

        public int Create(CityDTO cityDTO, string tokenString, MataDBEntities db)
        {
            var city = mapper.MapToEntity(cityDTO);

            db.City.Add(city);
            db.SaveChanges();

            return city.ID;
        }

        public void Delete(int id, MataDBEntities db)
        {
            var city = db.City.Single(q => q.ID == id);

            db.City.Remove(city);
            db.SaveChanges();
        }

        public CityDTO Get(int id, MataDBEntities db)
        {
            var city = db.vCity.Single(q => q.ID == id);

            return mapper.MapToDTO(city);
        }

        public IEnumerable<CityDTO> GetCities(int skip, int take, MataDBEntities db)
        {
            var cities = db.vCity.OrderBy(q => q.CountryName).ThenBy(q => q.CityName).ThenBy(q => q.ID);

            if (skip == 0 && take == 0)
            {
                return cities.ToList().Select(q => mapper.MapToDTO(q));
            }

            return cities.Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }

        public void Update(int id, CityDTO dto, string tokenString, MataDBEntities db)
        {
            var city = db.City.Single(q => q.ID == id);

            city.CountryID = dto.CountryID;
            city.CityName = dto.CityName;

            db.SaveChanges();
        }
    }
}
