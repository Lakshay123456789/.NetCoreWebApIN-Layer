using Microsoft.EntityFrameworkCore;
using Model.DemoContextDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityModel;
namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {



        private readonly DbSet<T> _dbSet;
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Insert(T obj)
        {
             _dbSet.Add(obj);
            Save();
        }
        public async Task<T> Update(T obj)
        {
            _dbContext.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> Delete(object id)
        {
            var existing = await _dbSet.FindAsync(id);
            if (existing != null)
            {
                _dbSet.Remove(existing);
                Save();
                return true;

            }
            return false;


        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


         public async Task<List<AddToCart>> GetAllById(Guid id)
        {
            return await _dbContext.AddToCarts.Where(x => x.IdentityUserId == id.ToString()).ToListAsync();
        }
       
        public async Task<List<Order>> GetAllOrders(string identityUserId)
        {
            var orders =  _dbContext.Orders.Include(o => o.OrderProductss).Where(o => o.IdentityUserId == identityUserId)
       .ToList();
           return orders;
        }
        public async Task<List<Order>> GetAllOrdersOfDifferentUsers()
        {
            var orders = _dbContext.Orders.Include(o => o.OrderProductss).ToList();

            return orders;
        }
        public async Task<ForgetPassword> GetToken(string email)
        {
            return await _dbContext.forgetPasswords.FindAsync(email);
        }

    }
}
