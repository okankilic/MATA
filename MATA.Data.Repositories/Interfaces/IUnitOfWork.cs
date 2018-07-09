using MATA.Data.Repositories.Impls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Repositories.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        ActionRepository ActionRepository { get; }
        TokenRepository TokenRepository { get; }
        AccountRepository AccountRepository { get; }
        ProjectRepository ProjectRepository { get; }
        StoreRepository StoreRepository { get; }
        CountryRepository CountryRepository { get; }
        CityRepository CityRepository { get; }
        IssueRepository IssueRepository { get; }

        void SaveChanges(string tokenString);

        void Commit();
    }
}
