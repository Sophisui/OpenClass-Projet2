using System.Collections.Generic;
using P2FixAnAppDotNetCode.Models.ViewModels;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductById(int id);
        int GetProductById(object productId);
        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
