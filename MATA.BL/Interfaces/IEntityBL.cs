
using MATA.Data.Repositories.Interfaces;

namespace MATA.BL.Interfaces
{
    public interface IEntityBL<TDTO>: ISearchable<TDTO>
    {
        int Create(TDTO dto, string tokenString, IUnitOfWork uow);

        void Update(int id, TDTO dto, string tokenString, IUnitOfWork uow);

        void Delete(int id, string tokenString, IUnitOfWork uow);

        TDTO Get(int id, IUnitOfWork uow);

        int Count(IUnitOfWork uow);
    }
}
