using DictinaryPower.DAL.Context;
using DictinaryPower.DAL.Entitiyes.Base;
using DictinaryPower.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DictinaryPower.DAL.Repositories
{
    internal class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly DictinaryDB _db;
        private readonly DbSet<T> _set;

        public bool AutoSaveChanges { get; set; } =  true;

        public DbRepository(DictinaryDB db)
        {
            _db = db;
            _set = db.Set<T>();
        }

        public virtual IQueryable<T> Items => _set;

        public T Add(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _db.Entry(entity).State = EntityState.Added;

            if (AutoSaveChanges)
                _db.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity , CancellationToken cancel = default)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _db.Entry(entity).State = EntityState.Added;

            if (AutoSaveChanges)
                await _db.SaveChangesAsync(cancel).ConfigureAwait(false);

            return entity;
        }

        public virtual T Get(int id) => Items.SingleOrDefault(i => i.Id == id);

        public async Task<T> GetAsync(int id , CancellationToken cancel = default) => await Items
            .SingleOrDefaultAsync(i => i.Id == id , cancel)
            .ConfigureAwait(false);



        public void Remove(int id)
        {
            _db.Remove( new T { Id = id});

            if (AutoSaveChanges)
                _db.SaveChanges();
        }

        public async void RemoveAsync(int id , CancellationToken cancel = default)
        {
            _db.Remove(new T { Id = id });

            if (AutoSaveChanges)
                await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }

        public T Update(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _db.Entry(entity).State = EntityState.Modified;

            if (AutoSaveChanges)
                _db.SaveChanges();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancel = default)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _db.Entry(entity).State = EntityState.Modified;

            if (AutoSaveChanges)
                await _db.SaveChangesAsync(cancel).ConfigureAwait(false);

            return entity;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async void SaveAsync(CancellationToken cancel = default)
        {
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
    }
}
