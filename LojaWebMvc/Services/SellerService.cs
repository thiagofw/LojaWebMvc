using LojaWebMvc.Models;
using LojaWebMvc.Services.Interfaces;
using LojaWebMvc.Data;
using System.Linq;

namespace LojaWebMvc.Services;

public class SellerService: ISellerService
{
    private readonly VsproContext _vsproContext;
    public SellerService(VsproContext vsproContext)
    {
        _vsproContext = vsproContext;
    }
//
        public List<Seller> FindAll()
        {
           // return _vsproContext.Seller.OrderBy(x => x.Name).ToList();
            var list = _vsproContext.Seller;
            var obj = list.Select(x => new Seller(
                x.Id,
                x.Name,
                x.Email,
                x.BirthDate,
                x.BaseSalary,
                x.Department

            )).ToList();
            return obj;
        }

        public Seller FindById(int id)
        {
            return _vsproContext.Seller.FirstOrDefault(x => x.Id == id);
               // var obj = _vsproContext.Seller.Find(id);
               // return obj;

        }

        public Seller Insert(Seller seller)
        {
            _vsproContext.Add(seller);
            _vsproContext.SaveChanges();
            return seller;
        }

        public void Remove(int id)
        {
            var obj = _vsproContext.Seller.Find(id);
            _vsproContext.Remove(obj);
            _vsproContext.SaveChanges();

        }


    
}