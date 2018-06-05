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
    public static class CityBL
    {
        public static int Create(CityDTO cityDTO, MataDBEntities db)
        {
            var mapper = new CityMapper();

            var city = mapper.MapToEntity(cityDTO);

            db.City.Add(city);
            db.SaveChanges();

            return city.ID;
        }

        public static IEnumerable<CityDTO> GetCities(MataDBEntities db)
        {
            var mapper = new CityMapper();

            return db.vCity.OrderBy(q => q.CityName).ThenBy(q => q.ID).ToList().Select(q => mapper.MapToDTO(q));
        }
    }
}
