using Rpms.DataAccess;
using Rpms.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rpms.Controllers
{
    public class ProductTaxController : IExcelRepository<ProductTax>
    {
        private readonly IExcelRepository<ProductTax> productTaxRepository;
        public ProductTaxController()
        {
            productTaxRepository = new ExcelRepository<ProductTax>(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + ConfigurationManager.AppSettings["ExcelString"]);
        }

        public ProductTax Add(ProductTax entity)
        {
            return productTaxRepository.Add(entity);
        }

        public IEnumerable<ProductTax> All()
        {
            return productTaxRepository.All();
        }

        public bool Delete(Guid id)
        {
            return productTaxRepository.Delete(id);
        }

        public ProductTax FindById(Guid id)
        {
            return productTaxRepository.FindById(id);
        }

        public DataTable GetAllDataTable()
        {
            return productTaxRepository.GetAllDataTable();
        }

        public DataTable GetSearchDataTable(string key)
        {
            return productTaxRepository.GetSearchDataTable(key);
        }

        public bool Update(Guid id, ProductTax entity)
        {
            return productTaxRepository.Update(id, entity);
        }
    }
}
