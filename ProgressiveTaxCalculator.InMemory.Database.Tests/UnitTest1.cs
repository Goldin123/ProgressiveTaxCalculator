using NUnit.Framework;
using ProgressiveTaxCalculator.InMemory.Database.Persistence;

namespace ProgressiveTaxCalculator.InMemory.Database.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInMemoryContext()
        {
            using (TestProgressiveTaxCalculatorInMemoryContext context = new TestProgressiveTaxCalculatorInMemoryContext())
            {
                //context.TaxTables.Count().Equals(3);
            }
            Assert.Pass();
        }
    }
}