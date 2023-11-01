using LojaWebMvc.Data;
using LojaWebMvc.Models;
using LojaWebMvc.Models.ViewModels;
using LojaWebMvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
namespace LojaWebMvc.Controllers;

public class SellersController: Controller
{
    private readonly ISellerService _sellerService;
    private readonly IDepartmentService _departmentService;
    public SellersController(ISellerService sellerService, IDepartmentService departmentService)
    {
        _departmentService = departmentService;
        _sellerService = sellerService;
        
    }
    public IActionResult Index()
    {
        var obj = _sellerService.FindAll();
        return View(obj);
    }

    public IActionResult Details(int id)
    {
        var list = _sellerService.FindById(id);
        return View(list);
    }
    [HttpGet]
    public IActionResult Create()
    {
        var departments = _departmentService.FindAll();
        var viewModel = new SellerFormViewModel{Departments = departments};

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(Seller seller)
    {
        _sellerService.Insert(seller);
        return RedirectToAction("Index");

    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if(id == null){
            return NotFound();
        }
        var obj = _sellerService.FindById(id.Value);
        if(obj == null)
        {
            return NotFound();
        }
        return View(obj);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _sellerService.Remove(id);
        return RedirectToAction(nameof(Index));
    }
}