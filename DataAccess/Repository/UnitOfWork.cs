using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using DataAccess.IRepository;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MydbContext _context;
        private IDbContextTransaction _transaction;



        //tengo que crear _transaction

        public UnitOfWork(MydbContext context)
        {
            _context = context;

            ProductoRepository = new ProductoRepository(context);
            CategoriaRepository = new CategoriaRepository(context);
        }

        public IProductoRepository ProductoRepository { get; set; }
        public ICategoriaRepository CategoriaRepository { get; set; }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }


        public void Dispose()
        {
            //el dispose es para liberar recursos

            // Dispose of the context

            _context.Dispose();
        }

          public async Task RollbackAsync()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }



    }
}