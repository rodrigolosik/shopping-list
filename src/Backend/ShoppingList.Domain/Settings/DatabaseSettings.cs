namespace ShoppingList.Domain.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ProductsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
