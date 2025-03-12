using Northwind.EntityModels; // för NorthwindDatabaseContext

namespace Northwind.UnitTests
{
    public class EntityModelTests
    {
        [Fact]
        public void DatabaseConnectTest()
        {
            using NorthwindDatabaseContext db = new();

            Assert.True(db.Database.CanConnect());
        }

        [Fact]
        public void CategoryCountTest()
        {
            using NorthwindDatabaseContext db = new();
            int expected = 8;
            int actual = db.Categories.Count();

            Assert.Equal(expected, actual);
        }

        [Fact]

        public void ProductID1IsChaiTest()
        {
            using NorthwindDatabaseContext db = new();
            string expected = "Chai";
            //string actual = db.Products.Find(1).ProductName;
            Product? productmedId1 = db.Products.Find(1);
            string actual = productmedId1?.ProductName ?? string.Empty;
            Assert.Equal(expected, actual);
        }

    }
}
