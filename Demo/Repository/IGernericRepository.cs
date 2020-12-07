using Demo.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Demo.Repository
{
    public interface IGernericRepository<T> where T :ChiTietDanhMuc
    {
        Task<T> Get(int? id);
        IEnumerable<T> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }

}