using Drippyz.Controllers;
using Drippyz.Data;
using Drippyz.Data.Services;
using Drippyz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDrippyz_1
{


    public class ProductsServiceTest
    {



        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "Drippyz_UnitTestDb")
            .Options;

        AppDbContext context;
        ProductsService productsService;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();

            productsService = new ProductsService(context);
        }


        [Test, Order(1)]
        public void GetProductByIdAsync_WithResponse_Test()
        {
            var result = productsService.GetProductByIdAsync(1);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);

        }



        //Destory database after testing 

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }
        private void SeedDatabase()
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(new List<Product>()
                   {

                        new Product()
                        {

                            Name = "Vanilla",
                            Description = "500ML Home made ice cream.",
                            Price = 11.00,
                            ImageURL = "~/images/product-1.png",
                            ProductCategory = ProductCategory.Bar,
                            StoreId = 1


            },

                        new Product()
                        {

                            Name = "Chocolate",
                            Description = "500ML Home made Chocolate ice cream.",
                            Price = 12.00,
                            ImageURL = "~/images/product-2.png",
                            ProductCategory = ProductCategory.Bar,
                            StoreId = 1

                        },
                     });
                context.SaveChanges();
            }
        }
    }

}


