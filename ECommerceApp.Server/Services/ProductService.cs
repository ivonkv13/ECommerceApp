using AutoMapper;
using ECommerceApp.Server.Controllers.Products.Dtos;
using ECommerceApp.Server.Core;
using ECommerceApp.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductDto>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<GetProductDto>>(products); ;
        }

        public async Task<GetProductDto> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            return _mapper.Map<GetProductDto>(product);
        }

        public async Task AddProductAsync([FromBody] CreateProductDto product)
        {
            var productToCreate = _mapper.Map<CreateProductDto, Product>(product);

            await _repository.AddAsync(productToCreate);
        }

        public async Task UpdateProductAsync([FromBody] UpdateProductDto productForUpdate)
        {
            var product = await _repository.GetByIdAsync(productForUpdate.Id);

            if (product != null)
            {
                var productToUpdate = _mapper.Map<UpdateProductDto, Product>(productForUpdate);

                await _repository.UpdateAsync(productToUpdate);
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product != null)
            {
                await _repository.DeleteAsync(product);
            }
        }

        public async Task<IEnumerable<Product>> GetProductsInStock()
        {
            return await _repository.FindAsync(p => p.Stock > 0);
        }

        public async Task<bool> DoesProductExistAsync(int id)
        {
            return await _repository.GetByIdAsync(id) != null;
        }

    }
}
