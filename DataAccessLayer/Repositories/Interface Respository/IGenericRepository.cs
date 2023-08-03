using Model.EntityModel;

namespace DataAccessLayer.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Delete(object id);
        Task<List<T>> GetAll();
        Task<T> GetById(object id);
        Task Insert(T obj);
        void Save();
        Task<T> Update(T obj);
        Task<List<AddToCart>> GetAllById(Guid id);
        Task<List<Order>> GetAllOrders(string identityUserId);
        Task<List<Order>> GetAllOrdersOfDifferentUsers();

        Task<ForgetPassword> GetToken(string email);

    }
}