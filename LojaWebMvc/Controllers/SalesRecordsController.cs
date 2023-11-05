using Microsoft.AspNetCore.Mvc;

namespace LojaWebMvc.Controllers;

public class SalesRecordsController: Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SimpleSearch()
    {
        return View();
    }

    public IActionResult GroupingSearch()
    {
        return View();
    }

}