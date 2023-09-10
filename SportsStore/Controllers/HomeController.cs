using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository _repository;
        public int PageSize = 4;

        public HomeController(IStoreRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string? category, int productPage = 1)
        {
            ProductsListViewModel viewModel = new ProductsListViewModel()
            {
                Products = _repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = (int)PageSize,
                    TotalItems = category == null ? _repository.Products.Count() : _repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };

            return View(viewModel);
        }
    }
}
