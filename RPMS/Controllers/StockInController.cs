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
    public class StockInController : IExcelRepository<StockIn>
    {
        private readonly IExcelRepository<StockIn> stockInRepository;
        public StockInController()
        {
            stockInRepository = new ExcelRepository<StockIn>(ConfigurationManager.AppSettings["ExcelString"]);
        }

        public StockIn Add(StockIn entity)
        {
            return stockInRepository.Add(entity);
        }

        public IEnumerable<StockIn> All()
        {
            return stockInRepository.All();
        }

        public bool Delete(Guid id)
        {
            return stockInRepository.Delete(id);
        }

        public StockIn FindById(Guid id)
        {
            return stockInRepository.FindById(id);
        }

        public DataTable GetAllDataTable()
        {
            return stockInRepository.GetAllDataTable();
        }

        public DataTable GetSearchDataTable(string key)
        {
            return stockInRepository.GetSearchDataTable(key);
        }

        public bool Update(Guid id, StockIn entity)
        {
            return stockInRepository.Update(id, entity);
        }
    }
}
