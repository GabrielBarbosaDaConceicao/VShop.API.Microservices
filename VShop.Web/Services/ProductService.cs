﻿using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Servoces.Contracts;

namespace VShop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string? apiEndpoint = "/api/products";
        private readonly JsonSerializerOptions _options;
        private ProductViewModel productVM;
        private IEnumerable<ProductViewModel> productsVM;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {

        }

        public async Task<ProductViewModel> FindProductById(int id)
        {

        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel productVM)
        {

        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel productVM)
        {

        }

        public async Task<bool> DeleteProductById(int id)
        {

        }
    }
}
