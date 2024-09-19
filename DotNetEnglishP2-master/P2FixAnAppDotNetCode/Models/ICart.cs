
using P2FixAnAppDotNetCode.Models.ViewModels;

namespace P2FixAnAppDotNetCode.Models
{
    public interface ICart
    {
        void AddItem(ProductViewModel product, int quantity);

        void RemoveLine(ProductViewModel product);

        void Clear();

        double GetTotalValue();

        double GetAverageValue();
    }
}