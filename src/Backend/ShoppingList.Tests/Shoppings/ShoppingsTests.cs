using ShoppingList.Domain.Settings;
using ShoppingList.Repository.Shoppings;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingList.Tests.Shoppings
{
    public class ShoppingsTests
    {
        private readonly IDatabaseSettings _settings;

        public ShoppingsTests()
        {
            _settings = new DatabaseSettings()
            {
                ConnectionString = "mongodb://losik:123456@localhost:27017/admin",
                DatabaseName = "ShoppingListDb",
                ProductsCollectionName = "Products"
            };
        }

        [Fact]
        public async Task Get_Return_List_Shoppings()
        {
            var shoppingRepository = new ShoppingRepository(_settings);
            var shop = await shoppingRepository.Get();
            Assert.NotNull(shop);
        }

    }
}
