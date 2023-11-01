using LojaWebMvc.Models;

namespace LojaWebMvc.Services.Interfaces;

public interface ISellerService
{
    List<Seller> FindAll();
    Seller FindById(int id);
    Seller Insert(Seller seller);
    void Remove(int id);
}