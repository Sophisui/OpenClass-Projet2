using P2FixAnAppDotNetCode.Models.ViewModels;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        ProductViewModel[] GetAllProducts();
        ProductViewModel GetProductById(int id);
        int GetProductById(object productId);
        void UpdateProductStocks(int productId, int quantityToRemove);
        void UpdateProductStocks(object productId, object quantity);
    }
}
