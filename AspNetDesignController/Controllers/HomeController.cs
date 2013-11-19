﻿using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Messaging.ProductCatalogService;
using Agathas.StorefrontController.ViewModels.ProductCatalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Agathas.StorefrontController.Controllers
{
    public class HomeController : ProductCatalogBaseController
    {
        private readonly IProductCatalogService _productCatalogService;
        public HomeController(IProductCatalogService productCatalogService) : base(productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }

        public ActionResult Index()
        {
            HomePageView homePageView = new HomePageView();
            homePageView.Categories = base.GetCategories();

            GetFeaturedProductResponse response = _productCatalogService.GetFeaturedProducts();
            homePageView.Products = response.Products;
            return View(homePageView);

        }
    }
}