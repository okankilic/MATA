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
    public static class CountryBL
    {
        public static int Create(CountryDTO countryDTO, MataDBEntities db)
        {
            var mapper = new CountryMapper();

            var country = mapper.MapToEntity(countryDTO);

            db.Country.Add(country);
            db.SaveChanges();

            return country.ID;
        }

        public static IEnumerable<CountryDTO> GetCountries(MataDBEntities db)
        {
            var mapper = new CountryMapper();

            return db.vCountry.OrderBy(q => q.CountryName).ThenBy(q => q.ID).ToList().Select(q => mapper.MapToDTO(q));
        }
    }
}
