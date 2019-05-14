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
    public class VendorController : IExcelRepository<Vendor>
    {
        private readonly IExcelRepository<Vendor> vendorRepository;
        public VendorController()
        {
            vendorRepository = new ExcelRepository<Vendor>(ConfigurationManager.AppSettings["ExcelString"]);
        }

        public Vendor Add(Vendor entity)
        {
            return vendorRepository.Add(entity);
        }

        public IEnumerable<Vendor> All()
        {
            return vendorRepository.All();
        }

        public bool Delete(Guid id)
        {
            return vendorRepository.Delete(id);
        }

        public Vendor FindById(Guid id)
        {
            return vendorRepository.FindById(id);
        }

        public DataTable GetAllDataTable()
        {
            return vendorRepository.GetAllDataTable();
        }

        public DataTable GetSearchDataTable(string key)
        {
            return vendorRepository.GetSearchDataTable(key);
        }

        public bool Update(Guid id, Vendor entity)
        {
            return vendorRepository.Update(id, entity);
        }
    }
}
