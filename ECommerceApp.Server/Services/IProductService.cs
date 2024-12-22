using ECommerceApp.Server.Controllers.Products.Dtos;

namespace ECommerceApp.Server.Services
{
    public interface IProductService
    {
        Task<IEnumerable<GetProductDto>> GetAllProductsAsync();
        Task<GetProductDto> GetProductByIdAsync(int id);
        Task AddProductAsync(CreateProductDto dto);
        Task UpdateProductAsync(UpdateProductDto dto);
        Task DeleteProductAsync(int id);
        Task<bool> DoesProductExistAsync(int id);
    }
}