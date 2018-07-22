using MATA.Data.Repositories.Impls;
using MATA.Data.Repositories.Interfaces;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MATA.Data.Common.Enums;
using System.Reflection;
using System.Data.Common;
using System.Data.Entity;

namespace MATA.Data.Repositories.Impls
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MataDBEntities dbContext;

        DbContextTransaction dbContextTransaction;

        private ActionRepository actionRepository;
        private TokenRepository tokenRepository;
        private AccountRepository accountRepository;
        private ProjectRepository projectRepository;
        private StoreRepository storeRepository;
        private CountryRepository countryRepository;
        private CityRepository cityRepository;
        private IssueRepository issueRepository;
        private MailRepository mailRepository;
        private StoreAccountRepository storeAccountRepository;
        private AttachmentRepository attachmentRepository;

        private bool disposed = false;

        private const string CreatedByAccountID = "CreatedByAccountID";
        private const string CreateTime = "CreateTime";
        private const string UpdatedByAccountID = "UpdatedByAccountID";
        private const string UpdateTime = "UpdateTime";

        public UnitOfWork()
        {
            dbContext = new MataDBEntities();
            dbContextTransaction = this.dbContext.Database.BeginTransaction();
        }

        //public UnitOfWork(MataDBEntities dbContext)
        //{
        //    this.dbContext = dbContext;


        //}

        public ActionRepository ActionRepository
        {
            get
            {
                if (actionRepository == null)
                {
                    actionRepository = new ActionRepository(dbContext);
                }

                return actionRepository;
            }
        }

        public TokenRepository TokenRepository
        {
            get
            {
                if (tokenRepository == null)
                {
                    tokenRepository = new TokenRepository(dbContext);
                }

                return tokenRepository;
            }
        }

        public AccountRepository AccountRepository
        {
            get
            {
                if (accountRepository == null)
                {
                    accountRepository = new AccountRepository(dbContext);
                }

                return accountRepository;
            }
        }

        public ProjectRepository ProjectRepository
        {
            get
            {
                if (projectRepository == null)
                {
                    projectRepository = new ProjectRepository(dbContext);
                }

                return projectRepository;
            }
        }

        public StoreRepository StoreRepository
        {
            get
            {
                if (storeRepository == null)
                {
                    storeRepository = new StoreRepository(dbContext);
                }

                return storeRepository;
            }
        }

        public CountryRepository CountryRepository
        {
            get
            {
                if (countryRepository == null)
                {
                    countryRepository = new CountryRepository(dbContext);
                }

                return countryRepository;
            }
        }

        public CityRepository CityRepository
        {
            get
            {
                if (cityRepository == null)
                {
                    cityRepository = new CityRepository(dbContext);
                }

                return cityRepository;
            }
        }

        public IssueRepository IssueRepository
        {
            get
            {
                if (issueRepository == null)
                {
                    issueRepository = new IssueRepository(dbContext);
                }

                return issueRepository;
            }
        }

        public MailRepository MailRepository
        {
            get
            {
                if (mailRepository == null)
                {
                    mailRepository = new MailRepository(dbContext);
                }
                return mailRepository;
            }
        }

        public StoreAccountRepository StoreAccountRepository
        {
            get
            {
                if(storeAccountRepository == null)
                {
                    storeAccountRepository = new StoreAccountRepository(dbContext);
                }
                return storeAccountRepository;
            }
        }

        public AttachmentRepository AttachmentRepository
        {
            get
            {
                if(attachmentRepository == null)
                {
                    attachmentRepository = new AttachmentRepository(dbContext);
                }
                return attachmentRepository;
            }
        }

        public void SaveChanges(string tokenString)
        {
            var actionList = new List<Entities.Action>();

            foreach (var entry in dbContext.ChangeTracker.Entries())
            {
                var entity = entry.Entity;

                if (entity is Entities.Action)
                {
                    continue;
                }

                if(entity is Token)
                {
                    if(entry.State == EntityState.Added)
                    {
                        var action = new Entities.Action
                        {
                            AccountID = ((Token)entry.Entity).AccountID,
                            ActionTime = DateTime.UtcNow,
                            ActionType = ActionTypes.LOGIN.ToString()
                        };

                        actionList.Add(action);
                    }

                    continue;
                }

                if (!string.IsNullOrWhiteSpace(tokenString))
                {
                    var tokenGuid = Guid.Parse(tokenString);

                    var token = dbContext.Token.Single(q => q.TokenString == tokenGuid);

                    switch (entry.State)
                    {
                        case EntityState.Added:
                        case EntityState.Modified:
                        case EntityState.Deleted:
                            {
                                var entityType = entity.GetType();
                                var entityName = entityType.Name.Contains('_') ? entityType.Name.Split('_')[0] : entityType.Name;
                                var entityProps = entityType.GetProperties();
                                var entityID = (int)entityProps.Single(q => q.Name == "ID").GetValue(entity);

                                var action = new Entities.Action
                                {
                                    AccountID = token.AccountID,
                                    ActionTime = DateTime.UtcNow,
                                    EntityID = entityID,
                                    EntityName = entityName
                                };

                                if (entry.State == EntityState.Added)
                                {
                                    action.ActionType = ActionTypes.CREATE.ToString();

                                    SetCreateAuditProperties(token.AccountID, entityProps, entity);
                                    SetUpdateAuditProperties(token.AccountID, entityProps, entity);
                                }
                                else if (entry.State == EntityState.Modified)
                                {
                                    action.ActionType = ActionTypes.UPDATE.ToString();

                                    SetUpdateAuditProperties(token.AccountID, entityProps, entity);
                                }
                                else
                                {
                                    action.ActionType = ActionTypes.DELETE.ToString();
                                }

                                actionList.Add(action);
                            }
                            break;
                    }
                }
            }

            if (actionList.Count > 0)
            {
                dbContext.Action.AddRange(actionList);
            }

            dbContext.SaveChanges();
        }

        public void Commit()
        {
            try
            {
                dbContext.SaveChanges();

                dbContextTransaction.Commit();
            }
            catch (Exception)
            {
                dbContextTransaction.Rollback();
                throw;
            }
        }

        private static void SetCreateAuditProperties(int accountID, IEnumerable<PropertyInfo> props, object entity)
        {
            if (props.Any(q => q.Name == CreatedByAccountID))
            {
                props.Single(q => q.Name == CreatedByAccountID).SetValue(entity, accountID);
            }

            if (props.Any(q => q.Name == CreateTime))
            {
                props.Single(q => q.Name == CreateTime).SetValue(entity, DateTime.UtcNow);
            }
        }

        private static void SetUpdateAuditProperties(int accountID, IEnumerable<PropertyInfo> props, object entity)
        {
            if (props.Any(q => q.Name == UpdatedByAccountID))
            {
                props.Single(q => q.Name == UpdatedByAccountID).SetValue(entity, accountID);
            }

            if (props.Any(q => q.Name == UpdateTime))
            {
                props.Single(q => q.Name == UpdateTime).SetValue(entity, DateTime.UtcNow);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (dbContextTransaction != null)
                    {
                        dbContextTransaction.Dispose();
                    }

                    if (dbContext != null)
                    {
                        dbContext.Dispose();
                    }
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
