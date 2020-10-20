using IGSMarketPlace.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGSMarketPlace.API.Services
{
    public interface IProductRepository
    {
        public List<ProductDTO> GetProducts();
        public ProductDTO GetProduct(int id);
        public void AddProduct(string name, string price);
        public void UpdateProduct(ProductDTO dto);
        public bool ProductExists(int id);
        public void DeleteProduct(int id);
    }
}
