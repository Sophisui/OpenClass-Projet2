using System.Collections.Generic;
using P2FixAnAppDotNetCode.Models.ViewModels;

namespace P2FixAnAppDotNetCode.Models.Services
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductById(int id);
        void UpdateProductQuantities(Cart cart);
    }
}
