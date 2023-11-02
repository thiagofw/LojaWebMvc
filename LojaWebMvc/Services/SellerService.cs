using LojaWebMvc.Models;
using LojaWebMvc.Services.Interfaces;
using LojaWebMvc.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LojaWebMvc.Services.Exceptions;

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
            return _vsproContext.Seller.Include(obj => obj.Department).FirstOrDefault(x => x.Id == id);
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

        public void Update(Seller seller)
       {
            if(!_vsproContext.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Error - Id not found");
            }
            try{
            _vsproContext.Update(seller);
            _vsproContext.SaveChanges();
            }catch(DbUpdateConcurrencyException e) 
            {
                throw new DbConcurrencyException(e.Message);
            }

       }


    
}