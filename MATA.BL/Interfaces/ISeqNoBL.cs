using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;

namespace MATA.BL.Interfaces
{
    public interface ISeqNoBL
    {
        string Create(string prefix, IUnitOfWork uow);
    }
}