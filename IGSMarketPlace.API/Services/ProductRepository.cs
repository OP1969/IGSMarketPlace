using IGSMarketPlace.API.Contexts;
using IGSMarketPlace.API.Entities;
using IGSMarketPlace.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace IGSMarketPlace.API.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGSContext _context;
        public ProductRepository(IGSContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddProduct(string name, string price)
        {
            Product dbProduct = new Product() { Name = name, Price = price };
            _context.Products.Add(dbProduct);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product dbProduct = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            if(dbProduct != null)
            {
                _context.Products.Remove(dbProduct);
                _context.SaveChanges();
            }
        }

        public ProductDTO GetProduct(int id)
        {
            var dbResult = _context.Products.Where(p => p.Id == id);
             
            return GetProductDTOFromDBEntity(dbResult.FirstOrDefault());
        }

        public List<ProductDTO> GetProducts()
        {
            List <ProductDTO> productDTOs = new List<ProductDTO>();
            foreach(Product dbEntity in _context.Products)
            {
                productDTOs.Add(GetProductDTOFromDBEntity(dbEntity));
            }

            return productDTOs;
        }

        public bool ProductExists(int id)
        {
            return GetProduct(id) != null;
        }

        public void UpdateProduct(ProductDTO dto)
        {
            Product dbProduct = _context.Products.Where(p => p.Id == dto.Id).FirstOrDefault();
            if( dbProduct != null )
            {
                dbProduct.Name = dto.Name;
                dbProduct.Price = dto.Price;
                _context.Products.Update(dbProduct);
                _context.SaveChanges();
            }
        }

        private Product GetDBEntityFromProductDTO(ProductDTO dto)
        {
            return dto == null ? null : new Product() { Id = dto.Id, Name = dto.Name, Price = dto.Price };
        }

        private ProductDTO GetProductDTOFromDBEntity(Product dbEntity)
        {
            return dbEntity == null ? null : new ProductDTO() { Id = dbEntity.Id, Name = dbEntity.Name, Price = dbEntity.Price };
        }
    }
}
