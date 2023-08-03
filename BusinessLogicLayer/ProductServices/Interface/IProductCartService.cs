using Model.EntityModel;
using Model.ModelDTO;

namespace BusinessLogicLayer.ProductServices.Interface
{
    public interface IProductCartService
    {
        Task Add(AddToCart addToCart);

        Task<List<AddToCart>> GetUserCart(Guid Id);

        Task<bool> EmptyCart(Guid Id);

        Task<bool> DeleteFrom(Guid id);

        Task<bool> AddOrderTable(List<AddToCartDto> addToCarts);

        Task<List<Order>> GetOrdersUserId(string identityUserId);

        Task<List<Order>> GetAllOrdersUseres();


    }
}