using Demo.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Demo.Repository
{
    public class GenericRepository<T> : IGernericRepository<T> where T :ChiTietDanhMuc
    {
        private DbContext _db;
        private DbSet<T> _dbset;
        public GenericRepository(ChartEntities db)
        {
            _db = db;
            _dbset=db.Set<T>();
        }
        public async Task Add(T entity)
        {
            _dbset.Add(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            _dbset.Remove(entity);
            await _db.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            _dbset.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();

        }

        public async Task<T> Get(int? id)
        {
            return await _dbset.SingleOrDefaultAsync(s => s.ID == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }
    }
}