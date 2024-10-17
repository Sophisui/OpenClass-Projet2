using P2FixAnAppDotNetCode.Models.Repositories;
using P2FixAnAppDotNetCode.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manage the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all products from the inventory
        /// </summary>
        public List<ProductViewModel> GetAllProducts()
        {
            // Change return type from array to List<T>
            return _productRepository.GetAllProducts(); // Assuming _productRepository returns an array.
        }

        /// <summary>
        /// Get a product from the inventory by its id
        /// </summary>
        public ProductViewModel GetProductById(int id)
        {
            // Implement the method
            return _productRepository.GetProductById(id); 
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending on ordered quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // Implement the method
            foreach (var item in cart.CartLines)
            {
                var product = _productRepository.GetProductById(item.Product.Id); // Get product by ID
                if (product != null)
                {
                    product.Stock -= item.Quantity; // Update product quantity
                    _productRepository.UpdateProductStocks(product.Id,item.Quantity); // Update the product in the repository
                }
            }
        }
    }
}
