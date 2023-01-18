using GeekShop.Web.Models;
using GeekShop.Web.Services.IService;
using GeekShop.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServiceUI _productServiceUI;

        public ProductController(IProductServiceUI productServiceUI)
        {
            this._productServiceUI = productServiceUI ?? throw new ArgumentException(nameof(productServiceUI));
        }

        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productServiceUI.GetProducts();
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel productModel)
        {
            var response = new ProductModel();
            if (ModelState != null)
            {
                response = await _productServiceUI.AddProduct(productModel);
                if (response != null) return RedirectToAction(nameof(ProductIndex));
            }
            return View(productModel);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var modelProduct = await _productServiceUI.GetProductById(id);
            if (modelProduct != null) return View(modelProduct);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel productModel)
        {
            var response = new ProductModel();
            if (ModelState != null)
            {
                response = await _productServiceUI.UpdateProduct(productModel);
                if (response != null) return RedirectToAction(nameof(ProductIndex));
            }
            return View(productModel);
        }

        [Authorize]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var modelProduct = await _productServiceUI.GetProductById(id);
            if (modelProduct != null) return View(modelProduct);
            return NotFound();
        }

        [Authorize (Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel productModel)
        {
            var response = await _productServiceUI.DeleteProduct(productModel.Id);
            if (response) return RedirectToAction(nameof(ProductIndex));

            return View(productModel);
        }
    }
}
