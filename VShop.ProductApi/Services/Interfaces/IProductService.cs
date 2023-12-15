using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductDTO ProductDto);
        Task UpdateProduct(ProductDTO productDto);
        Task RemoveProduct(int id);

    }
}
