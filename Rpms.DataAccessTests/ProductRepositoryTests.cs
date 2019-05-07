using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rpms.DataAccess;
using Rpms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpms.DataAccess.Tests
{
    [TestClass()]
    public class ProductRepositoryTests
    {

        private readonly IExcelRepository<Product> productRepository;
        public ProductRepositoryTests()
        {
            productRepository = new ExcelRepository<Product>(@"D:\repos\Rpms\RPMS\bin\Debug\Configuration.xlsx");
        }

        [TestMethod()]
        public void AllTest()
        {
            var allData = productRepository.All();
            Assert.IsNotNull(allData);
        }

        [TestMethod()]
        public void FindByIdTest()
        {
            var ID = Guid.Parse("2a767ac4-7bbb-4c42-8491-e9d0fb271cab");
            var allData = productRepository.FindById(ID);
            Assert.IsNotNull(allData);
        }


        [TestMethod()]
        public void AddTest()
        {
            var ID = Guid.NewGuid();

            var product = productRepository.Add(new Product
            {
                Description = "Desc",
                ID = ID,
                Name = "PName",
                SKU = "SKUNO1",
                Status = "Active"
            });

            Assert.IsNotNull(product);
        }


        [TestMethod()]
        public void UpdateTest()
        {
            var ID = Guid.Parse("2a767ac4-7bbb-4c42-8491-e9d0fb271cab");
            var product = productRepository.Update(ID, new Product
            {
                Description = "Desc",
                ID = ID,
                Name = "Rajname",
                //SKU = "SKUNO1",
                //Status = "Active"
            });

            Assert.IsNotNull(product);
        }


        [TestMethod()]
        public void DeleteTest()
        {
            var ID = Guid.Parse("2a767ac4-7bbb-4c42-8491-e9d0fb271cab");

            var product = productRepository.Delete(ID);
            Assert.IsNotNull(product);
        }

    }
}