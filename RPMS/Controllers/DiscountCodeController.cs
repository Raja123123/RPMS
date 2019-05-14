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
    public class DiscountCodeController : IExcelRepository<DiscountCode>
    {
        private readonly IExcelRepository<DiscountCode> discountcodeRepository;
        public DiscountCodeController()
        {
            discountcodeRepository = new ExcelRepository<DiscountCode>(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + ConfigurationManager.AppSettings["ExcelString"]);
        }

        public DiscountCode Add(DiscountCode entity)
        {
            return discountcodeRepository.Add(entity);
        }

        public IEnumerable<DiscountCode> All()
        {
            return discountcodeRepository.All();
        }

        public bool Delete(Guid id)
        {
            return discountcodeRepository.Delete(id);
        }

        public DiscountCode FindById(Guid id)
        {
            return discountcodeRepository.FindById(id);
        }

        public DataTable GetAllDataTable()
        {
            return discountcodeRepository.GetAllDataTable();
        }

        public DataTable GetSearchDataTable(string key)
        {
            return discountcodeRepository.GetSearchDataTable(key);
        }

        public bool Update(Guid id, DiscountCode entity)
        {
            return discountcodeRepository.Update(id, entity);
        }
    }
}
