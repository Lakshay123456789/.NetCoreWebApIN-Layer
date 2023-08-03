using Model.EntityModel;
using Model.ModelDTO;

namespace BusinessLogicLayer.ProductServices.Interface
{
    public interface IProductService
    {
        Task Add(Product product);
        Task<bool> Delete(Guid Id);
        Task<ProductResponseModel> GetAllProduct(int page, int pageSize, string search);
        Task<Product> GetProductById(Guid Id);
        Task<Product> Update(Product product);

        Task AddToken(ForgetPassword model);

        Task<ForgetPassword> GetTokeByEmail(string email);

        Task<bool> DeleteToken(string email);

    }
}