using LojaWebMvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaWebMvc.Controllers;

public class DepartmentsController: Controller
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public IActionResult Index()
    {
        var obj = _departmentService.FindAll();
        return View(obj);
    }
}