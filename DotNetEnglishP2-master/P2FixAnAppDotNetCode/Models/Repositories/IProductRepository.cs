using P2FixAnAppDotNetCode.Models.ViewModels;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        ProductViewModel[] GetAllProducts();

        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
