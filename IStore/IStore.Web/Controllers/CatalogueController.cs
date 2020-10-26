using IStore.Data;
using IStore.Data.Interfaces;
using IStore.Domain;
using IStore.Web.Models.Catalogue;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IStore.Web.Controllers
{
    public class CatalogueController : Controller
    {
        private readonly ILogger<CatalogueController> _logger;
        private readonly IRepository<Category> _categoriesRepository;

        public CatalogueController(IRepository<Category> categoriesRepository, ILogger<CatalogueController> logger)
        {
            _logger = logger;
            _categoriesRepository = categoriesRepository;
        }
        
        public ViewResult Root()
        {
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel();
            
            var allCategories = _categoriesRepository.GetAll();
            catalogueViewModel.AllCategories = allCategories;

            return View(catalogueViewModel);
        }
    }
}
