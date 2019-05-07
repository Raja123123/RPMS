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
    public class TaxController : IExcelRepository<Tax>
    {
        private readonly IExcelRepository<Tax> taxRepository;
        public TaxController()
        {
            taxRepository = new ExcelRepository<Tax>(ConfigurationManager.AppSettings["ExcelString"]);
        }

        public Tax Add(Tax entity)
        {
            return taxRepository.Add(entity);
        }

        public IEnumerable<Tax> All()
        {
            return taxRepository.All();
        }

        public bool Delete(Guid id)
        {
            return taxRepository.Delete(id);
        }

        public Tax FindById(Guid id)
        {
            return taxRepository.FindById(id);
        }

        public DataTable GetAllDataTable()
        {
            return taxRepository.GetAllDataTable();
        }

        public DataTable GetSearchDataTable(string key)
        {
            return taxRepository.GetSearchDataTable(key);
        }

        public bool Update(Guid id, Tax entity)
        {
            return taxRepository.Update(id, entity);
        }
    }
}
