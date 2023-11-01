using LojaWebMvc.Models;

namespace LojaWebMvc.Services.Interfaces;

public interface IDepartmentService
{
    List<Department> FindAll();
}