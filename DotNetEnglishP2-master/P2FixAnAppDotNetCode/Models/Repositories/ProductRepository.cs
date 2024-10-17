using System.Collections.Generic;
using System.Linq;
using P2FixAnAppDotNetCode.Models.ViewModels;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    /// <summary>
    /// The class that manages product data
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private static List<ProductViewModel> _products;

        public ProductRepository()
        {
            _products = new List<ProductViewModel>();
            GenerateProductData();
        }

        /// <summary>
        /// Generate the default list of products
        /// </summary>
        private void GenerateProductData()
        {
            int id = 0;
            _products.Add(new ProductViewModel(++id, 10, 92.50, "Echo Dot", "(2nd Generation) - Black"));
            _products.Add(new ProductViewModel(++id, 20, 9.99, "Anker 3ft / 0.9m Nylon Braided", "Tangle-Free Micro USB Cable"));
            _products.Add(new ProductViewModel(++id, 30, 69.99, "JVC HAFX8R Headphone", "Riptidz, In-Ear"));
            _products.Add(new ProductViewModel(++id, 40, 32.50, "VTech CS6114 DECT 6.0", "Cordless Phone"));
            _products.Add(new ProductViewModel(++id, 50, 895.00, "NOKIA OEM BL-5J", "Cell Phone "));
        }

        /// <summary>
        /// Get all products from the inventory
        /// </summary>
        public List<ProductViewModel> GetAllProducts()
        {
            List<ProductViewModel> list = _products.Where(p => p.Stock > 0).OrderBy(p => p.Name).ToList();
            return list;
        }

        /// <summary>
        /// Update the stock of a product in the inventory by its id
        /// </summary>
        public void UpdateProductStocks(int productId, int quantityToRemove)
        {
            ProductViewModel product = _products.First(p => p.Id == productId);
            product.Stock = product.Stock - quantityToRemove;

            if (product.Stock >= 0)
                _products.Remove(product);
        }

        public ProductViewModel GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public int GetProductById(object productId)
        {
            throw new System.NotImplementedException();
        }
    }
}
