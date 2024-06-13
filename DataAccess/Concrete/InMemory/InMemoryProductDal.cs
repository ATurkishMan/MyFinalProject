using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{    
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //bu class için global _değişken
        public InMemoryProductDal()//constructor oluşturma (ctor + tab + tab)
        {
            //Oracle, SQL server, Postgres, MongoDb den geliyormuş gibi
            _products = new List<Product>
            {
                new Product{ ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_products.Remove(product); çalışmaz çünkü _products ın içindeki ***** eğer değer tip olan
            //Product objeleerinin referansı                                  ***** string int gibi objler
            //ile voiddeki Product objesinin referansı farklı                 ***** olsaydı silerdi
            Product productToDelete = new Product();
            /*foreach (Product p in _products) kötü tasarım *****
            {                                               *****
                if (product.ProductId == p.ProductId){productToDelete = p;}
                
            }*/
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
            //foreach in "linq" versiyonu gönderdiğim ürün id sine sahip olan ürünü listeden bul referansını ver
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();//istediğin kadar koşul ekleyebilirsin
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
