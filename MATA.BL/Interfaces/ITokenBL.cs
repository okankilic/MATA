using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface ITokenBL
    {
        string Create(int accountID, IUnitOfWork uow);
        string GetOrCreate(int accountID, IUnitOfWork uow);
    }
}
