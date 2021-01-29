using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingList.API.Controllers;
using ShoppingList.Domain.Models;
using ShoppingList.Domain.Settings;
using ShoppingList.Repository.Shoppings;
using ShoppingList.Service.Shoppings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingList.Tests.Shoppings
{
    public class ShoppingsTests
    {
        private readonly IDatabaseSettings _settings;
        private readonly IShoppingRepository _repository;
        private readonly IShoppingService _service;
        private readonly ShoppingsController _controller;

        public ShoppingsTests()
        {
            _settings = new DatabaseSettings
            {
                ConnectionString = "mongodb://losik:123456@localhost:27017/admin",
                DatabaseName = "ShoppingListDb",
                ProductsCollectionName = "Products"
            };

            _repository = new ShoppingRepository(_settings);
            _service = new ShoppingService(_repository);
            _controller = new ShoppingsController(_service);
        }

        [Fact]
        public void Get_ReturnsOkResult()
        {
            // act
            var okResult = _controller.Get();
            // assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public async Task Get_ById_ReturnsNotFoundResult()
        {
            // arrange
            string id = $"601343959f511dd08a77fec2";
            // act
            var okResult = await _controller.Get(id);
            // assert
            Assert.IsType<NotFoundResult>(okResult);
        }
        [Fact]
        public async Task Post_ReturnsOkResult()
        {
            // arrange
            Shopping shopping = new Shopping()
            {
                Date = DateTime.Now,
                Products = new List<Product> {
                    new Product { Name = "Rice", Price = 10.50M , Quantity = 1 }
                }
            };
            // act
            var result = await _controller.Post(shopping);
            // assert
            Assert.IsType<CreatedResult>(result);
        }
    }
}
