using Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IUnitOfWorkCentral
    {
        Guid Id { get; }
        CentralDbContext Context { get; }
        IDbContextTransaction Transaction { get; }
        void Begin();
        void Commit();
        void Rollback();
    }

    public sealed class UnitOfWorkCentral : IUnitOfWorkCentral
    {
        CentralDbContext _context;
        IDbContextTransaction _transaction;
        Guid _id = Guid.Empty;

        public UnitOfWorkCentral(CentralDbContext context)
        {
            _context = context;
        }

        CentralDbContext IUnitOfWorkCentral.Context
        {
            get { return _context; }
        }

        IDbContextTransaction IUnitOfWorkCentral.Transaction
        {
            get { return _transaction; }
        }

        Guid IUnitOfWorkCentral.Id
        {
            get { return _id; }
        }

        public void Begin()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();
        }
    }
}
