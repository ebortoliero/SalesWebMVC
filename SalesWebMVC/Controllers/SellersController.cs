using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _SellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _SellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _SellerService.FindAll();

            return View(list);
        }
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var ViewModel = new SellerFormViewModel { Departments = departments }; 
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _SellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
