﻿using IStore.Data.Interfaces;
using IStore.Web.Models.Catalogue;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IStore.Web.Controllers
{
    public class CatalogueController : Controller
    {
        private readonly ILogger<CatalogueController> _logger;
        private readonly ICategoriesRepository _categoriesRepository;

        public CatalogueController(ICategoriesRepository categoriesRepository, ILogger<CatalogueController> logger)
        {
            _logger = logger;
            _categoriesRepository = categoriesRepository;
        }
        
        public ViewResult Index()
        {
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel();
            
            var allCategories = _categoriesRepository.GetAll();
            catalogueViewModel.AllCategories = allCategories;

            return View(catalogueViewModel);
        }
    }
}
