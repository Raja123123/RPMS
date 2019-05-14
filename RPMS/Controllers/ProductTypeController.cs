using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rpms.DataAccess;
using Rpms.Models;

namespace Rpms.Controllers
{
   
    public class ProductTypeController : IExcelRepository<ProductType>
    {
        private readonly IExcelRepository<ProductType> productTypeRepository;
        public ProductTypeController()
        {
            productTypeRepository = new ExcelRepository<ProductType>(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + ConfigurationManager.AppSettings["ExcelString"]);
        }

        public ProductType Add(ProductType entity)
        {
            return productTypeRepository.Add(entity);
        }

        public IEnumerable<ProductType> All()
        {
            return productTypeRepository.All();
        }

        public bool Delete(Guid id)
        {
            return productTypeRepository.Delete(id);
        }

        public ProductType FindById(Guid id)
        {
            return productTypeRepository.FindById(id);
        }

        public DataTable GetAllDataTable()
        {
            return productTypeRepository.GetAllDataTable();
        }

        public DataTable GetSearchDataTable(string key)
        {
            return productTypeRepository.GetSearchDataTable(key);
        }

        public bool Update(Guid id, ProductType entity)
        {
            return productTypeRepository.Update(id, entity);
        }
    }
}
