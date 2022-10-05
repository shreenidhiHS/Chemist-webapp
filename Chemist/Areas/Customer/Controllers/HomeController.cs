using BulkuBook.DataAccess.Repository.IRepository;
using Chemist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Chemist.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ChemType");


            return View(productList);
        }
        //GET
        public IActionResult Details(int productId)
        {
            ShopingCart cartObj = new()
            {
                Count = 1,
                ProductId = productId,
                Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == productId, includeProperties: "Category,ChemType"),

            };
            return View(cartObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShopingCart shopingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shopingCart.ApplicationUserId = claim.Value;

            ShopingCart cartFromDb = _unitOfWork.ShopingCart.GetFirstOrDefault(
                     u => u.ApplicationUserId == claim.Value && u.ProductId == shopingCart.ProductId
                     );
            if (cartFromDb == null)
            {
                _unitOfWork.ShopingCart.Add(shopingCart);
            }
            else 
            {
                _unitOfWork.ShopingCart.IncrementCount(cartFromDb, shopingCart.Count);
            }
            
            _unitOfWork.save();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}