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
    public class CountryMapper : IMapper<Country, vCountry, CountryDTO>
    {
        public CountryDTO MapToDTO(Country entity)
        {
            return new CountryDTO
            {
                ID = entity.ID,
                CountryName = entity.CountryName
            };
        }

        public CountryDTO MapToDTO(vCountry view)
        {
            return new CountryDTO
            {
                ID = view.ID,
                CountryName = view.CountryName
            };
        }

        public Country MapToEntity(CountryDTO dto)
        {
            return new Country
            {
                ID = dto.ID,
                CountryName = dto.CountryName
            };
        }
    }
}
