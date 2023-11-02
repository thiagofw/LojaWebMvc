using System.Diagnostics;
using LojaWebMvc.Data;
using LojaWebMvc.Models;
using LojaWebMvc.Models.ViewModels;
using LojaWebMvc.Services.Exceptions;
using LojaWebMvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

    public IActionResult Details(int? id)
    {
        if(id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not provided!"});
        }
        var list = _sellerService.FindById(id.Value);
        if(list == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not found!"});
        }
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
            return RedirectToAction(nameof(Error), new { message = "Id not provided!"});
        }
        return View(obj);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _sellerService.Remove(id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if(id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not provided!"});
        }
        var obj = _sellerService.FindById(id.Value);
        if(obj == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id not provided!"});
        }
        List<Department> departments = _departmentService.FindAll();
        SellerFormViewModel viewModel = new SellerFormViewModel{Seller = obj, Departments = departments};
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Seller seller)
    {
        if(id != seller.Id)
        {
           return RedirectToAction(nameof(Error), new { message = "Id mismatch!"});
        }
        try{
        _sellerService.Update(seller);
        return RedirectToAction(nameof(Index));
        }
        catch(ApplicationException e)
        {
            return RedirectToAction(nameof(Error), new { message = e.Message});
        }
        
    }
    public IActionResult Error(string message)
    {
        var viewModel = new ErrorViewModel{
            Message = message,
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };
        return View(viewModel);
    }
    
}