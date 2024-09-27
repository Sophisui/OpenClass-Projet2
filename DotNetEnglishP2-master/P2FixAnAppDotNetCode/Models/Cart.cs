using System.Collections.Generic;
using System.Linq;
using P2FixAnAppDotNetCode.Models.ViewModels;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        public List<CartViewModel> CartLines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartViewModel> GetCartLineList()
        {
            return _localCartLines;
        }

        private static List<CartViewModel> _localCartLines = new();

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(ProductViewModel product, int quantity)
        {
            // Cherche si l'item est deja dans le cart
            var line = _localCartLines.FirstOrDefault(i => i.Product.Id == product.Id);

            //Si non, on l'ajoute ainsi que ca quantite demande par l'utilisateur
            if (line == null)
            {
                _localCartLines.Add(new CartViewModel { Product = product, Quantity = quantity });
            }
            //Sinon on modifie seulement sa quantite (quantite = quantite + 1)
            else
            {
                line.Quantity += quantity;
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(ProductViewModel product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            //Verifie si on a des articles dans le panier, si aucun article renvoie 0.
            if (!_localCartLines.Any())
            {
                return 0;
            }
            //Prix du produit * sa quantite, pour chaque ligne du cart, puis additionne le tout.
            return _localCartLines.Sum(i => i.Product.Price * i.Quantity);
        }
        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            //Verifie si on a des articles dans le panier, si aucun article renvoie 0.
            if (!_localCartLines.Any())
            {
                return 0;
            }
            //Prix total du panier divise par le nombre d'article pour avoir le prix moyen de chaque article.
            return _localCartLines.Sum(i => i.Product.Price * i.Quantity) / _localCartLines.Sum(i => i.Quantity);
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public ProductViewModel FindProductIn_localCartLines(int productId)
        {
            var line = _localCartLines.FirstOrDefault(l => l.Product.Id == productId);
            return line.Product;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartViewModel GetCartLineByIndex(int index)
        {
            return _localCartLines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartViewModel> _localCartLines = GetCartLineList();
            _localCartLines.Clear();
        }
    }
}
