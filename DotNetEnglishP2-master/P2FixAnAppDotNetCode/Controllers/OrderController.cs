using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Services;
using P2FixAnAppDotNetCode.Models.ViewModels;

namespace P2FixAnAppDotNetCode.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICart _cart;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IStringLocalizer<OrderController> _localizer;

        public OrderController(ICart pCart, IProductService productService, IOrderService service, IStringLocalizer<OrderController> localizer)
        {
            _cart = pCart;
            _productService = productService;
            _orderService = service;
            _localizer = localizer;
        }

        public ViewResult Index() => View(new Order());

        [HttpPost]
        public IActionResult Index(Order order)
        {
            if (!((Cart) _cart).CartLines.Any())
            {
                ModelState.AddModelError("", _localizer["CartEmpty"]);
            }
            if (ModelState.IsValid)
            {
                order.Lines = (_cart as Cart)?.CartLines.ToArray();
                _orderService.SaveOrder(order);

                //List<ProductViewModel> products = _productService.GetAllProducts();
                //return View(products);
                return RedirectToAction(nameof(Completed)); //Rediriger vers la liste des produits updated
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}
