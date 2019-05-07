using Rpms.DataAccess;
using Rpms.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.Controllers
{
    public class ProductController : IExcelRepository<Product>
    {
        private readonly IExcelRepository<Product> productRepository;
        public ProductController()
        {
            productRepository = new ExcelRepository<Product>(ConfigurationManager.AppSettings["ExcelString"]);
        }

        public Product Add(Product entity)
        {
            return productRepository.Add(entity);
        }

        public IEnumerable<Product> All()
        {
            return productRepository.All();
        }

        public bool Delete(Guid id)
        {
            return productRepository.Delete(id);
        }

        public Product FindById(Guid id)
        {
            return productRepository.FindById(id);
        }

        public DataTable GetAllDataTable()
        {
            return productRepository.GetAllDataTable();
        }

        public DataTable GetSearchDataTable(string key)
        {
            return productRepository.GetSearchDataTable(key);
        }

        public bool Update(Guid id, Product entity)
        {
            return productRepository.Update(id, entity);
        }
    }
}
