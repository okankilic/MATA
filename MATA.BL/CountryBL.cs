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
    public class CountryBL: ICountryBL
    {
        readonly IMapper<Country, vCountry, CountryDTO> mapper;

        public CountryBL(IMapper<Country, vCountry, CountryDTO> mapper)
        {
            this.mapper = mapper;
        }

        public int Create(CountryDTO countryDTO, string tokenString, MataDBEntities db)
        {
            var country = mapper.MapToEntity(countryDTO);

            db.Country.Add(country);
            db.SaveChanges();

            return country.ID;
        }

        public IEnumerable<CountryDTO> GetCountries(MataDBEntities db)
        {
            return db.vCountry.OrderBy(q => q.CountryName).ThenBy(q => q.ID).ToList().Select(q => mapper.MapToDTO(q));
        }

        public void Update(int id, CountryDTO dto, string tokenString, MataDBEntities db)
        {
            var account = AccountBL.Get(tokenString, db);

            var country = db.Country.Single(q => q.ID == id);

            country.CountryName = dto.CountryName;

            db.SaveChanges();
        }

        public void Delete(int id, MataDBEntities db)
        {
            var country = db.Country.Single(q => q.ID == id);

            db.Country.Remove(country);
            db.SaveChanges();
        }

        public CountryDTO Get(int id, MataDBEntities db)
        {
            var country = db.vCountry.Single(q => q.ID == id);

            return mapper.MapToDTO(country);
        }

        public int Count(MataDBEntities db)
        {
            return db.Country.Count();
        }

        public IEnumerable<CountryDTO> GetCountries(int skip, int take, MataDBEntities db)
        {
            var countries = db.vCountry.OrderBy(q => q.CountryName).ThenBy(q => q.ID);

            if (skip == 0 && take == 0)
            {
                return countries.ToList().Select(q => mapper.MapToDTO(q));
            }

            return countries.Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }
    }
}
