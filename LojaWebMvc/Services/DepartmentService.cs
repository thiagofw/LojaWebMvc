using LojaWebMvc.Data;
using LojaWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using LojaWebMvc.Services.Interfaces;

namespace LojaWebMvc.Services;

public class DepartmentService: IDepartmentService
{
    
    private readonly VsproContext _vsproContext;

    public DepartmentService(VsproContext vsproContext)
    {
        _vsproContext = vsproContext;
    }
 public List<Department> FindAll()
 {
    //return _vsproContext.Department.OrderBy(x => x.Name).ToList();
    var list = _vsproContext.Department;
    var obj = new List<Department>();
    obj = list.Select(x => new Department(
        x.Id,
        x.Name  
    )).ToList();
    return obj;
  }



}