using AutoMapper;
using Microsoft.VisualBasic;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories.Interfaces;
using VShop.ProductApi.Services.Interfaces;

namespace VShop.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            IEnumerable<Product> productsEntity = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            Product productEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task AddProduct(ProductDTO poductDto)
        {
            Product productEntity = _mapper.Map<Product>(poductDto);
            await _productRepository.Create(productEntity);
            poductDto.Id = productEntity.Id;
        }
        
        public async Task UpdateProduct (ProductDTO productDto)
        {
            Product productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Update(productEntity);
        }
        
        public async Task RemoveProduct(int id)
        {
            Product productEntity = await _productRepository.GetById(id);
            await _productRepository.Delete(productEntity.Id);
        }
    }
}
