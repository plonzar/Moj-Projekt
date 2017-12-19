using Microsoft.VisualStudio.TestTools.UnitTesting;
using MojProjekt.Domain.Abstract;
using MojProjekt.Domain.Entities;
using MojProjekt.Models;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MojProjekt.Tests
{
    //[TestClass]
    //public class UnitTest1
    //{
    //    [TestMethod]
    //    public void RemoveFromDbContext()
    //    {
    //        var customerTestList = new List<Customer>{
    //            new Customer
    //            {
    //                ID = 1,
    //                Address = "Klasztorna 3a",
    //                City = "Kęty",
    //                Name = "ABC BIURO",
    //                NIP = "5490009576",
    //                PostCode = "32-650"
    //            },
    //            new Customer
    //            {
    //                ID = 2,
    //                Address = "Al. Armii Krajowej 80",
    //                City = "Bielsko-Biała",
    //                Name = "Improsystem",
    //                NIP = "5472061885",
    //                PostCode = "43-316"
    //            },
    //            new Customer
    //            {
    //                ID = 3,
    //                Address = "Stawowa 71",
    //                City = "Cieszyn",
    //                Name = "Kofax",
    //                NIP = "6311014409",
    //                PostCode = "43-400"
    //            }
    //        }.AsQueryable();

    //        var customerMock = new Mock<DbSet<Customer>>();
    //        customerMock.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customerTestList.Provider);
    //        customerMock.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customerTestList.Expression);
    //        customerMock.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customerTestList.ElementType);
    //        customerMock.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customerTestList.GetEnumerator());


    //        var mockContext = new Mock<ApplicationDbContext>();
    //        mockContext.Setup(c => c.Customers).Returns(customerMock.Object);

    //        var services = new InvoicAndCustomerManager(mockContext.Object);


    //        var testCustomer = new Customer()
    //        {
    //            ID = 3,
    //            Address = "Stawowa 71",
    //            City = "Cieszyn",
    //            Name = "Kofax",
    //            NIP = "6311014409",
    //            PostCode = "43-400"
    //        };

    //        IEnumerable<Customer> Expected = new List<Customer>
    //        {
    //            new Customer
    //            {
    //                ID = 1,
    //                Address = "Klasztorna 3a",
    //                City = "Kęty",
    //                Name = "ABC BIURO",
    //                NIP = "5490009576",
    //                PostCode = "32-650"
    //            },
    //            new Customer
    //            {
    //                ID = 2,
    //                Address = "Al. Armii Krajowej 80",
    //                City = "Bielsko-Biała",
    //                Name = "Improsystem",
    //                NIP = "5472061885",
    //                PostCode = "43-316"
    //            }
    //        };

    //        services.RemoveCustomer(3);

    //        var Real = services.Customers.ToList();

    //        Assert.AreEqual(testCustomer, (Customer)customerTestList.FirstOrDefault(m => m.ID == 3));
    //    }
    //}
}
