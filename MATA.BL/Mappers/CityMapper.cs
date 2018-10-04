using MATA.BL.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Mappers
{
    public class CityMapper : IMapper<City, vCity, CityDTO>
    {
        public CityDTO MapToDTO(City entity)
        {
            return new CityDTO
            {
                ID = entity.ID,
                CityName = entity.CityName,
                CountryID = entity.CountryID
            };
        }

        public CityDTO MapToDTO(vCity view)
        {
            return new CityDTO
            {
                ID = view.ID,
                CityName = view.CityName,
                CountryID = view.CountryID,
                CountryName = view.CountryName
            };
        }

        public City MapToEntity(CityDTO dto)
        {
            return new City
            {
                ID = dto.ID,
                CityName = dto.CityName,
                CountryID = dto.CountryID
            };
        }
    }
}
