using Invoice.Logic;

namespace Invoice.Tests
{
    public class InvoiceCalculatorTests
    {
        [Fact]
        public void OneLine_CalculateNetTotal_ShouldReturnCorrectTotal()
        {

            var lines = LineImporter.Import(["IL,3548769012345,2.5"]);
            var products = ProductImporter.Import(File.ReadAllLines("products.csv"));

            var ic = new InvoiceCalculator(products, lines);
            Assert.Equal(3.75m, ic.CalculateNetTotal());
        }

        [Fact]
        public void MultipleLines_CalculateNetTotal_ShouldReturnCorrectTotal()
        {

            var lines = LineImporter.Import(["IL,3548769012345,2.5", "IL,8912345670123,3", "IL,5678932104987,4", "IL,8790234561876,1", "IL,1234012345678,6"]);
            var products = ProductImporter.Import(File.ReadAllLines("products.csv"));

            var ic = new InvoiceCalculator(products, lines);
            Assert.Equal(20.45m, ic.CalculateNetTotal());
        }

        [Fact]
        public void MultipleLinesWithDiscount_CalculateNetTotal_ShouldReturnCorrectTotal()
        {

            var lines = LineImporter.Import(["IL,3548769012345,2.5", "IL,8912345670123,3", "D,10", "IL,5678932104987,4", "IL,8790234561876,1", "IL,1234012345678,6"]);
            var products = ProductImporter.Import(File.ReadAllLines("products.csv"));

            var ic = new InvoiceCalculator(products, lines);
            Assert.Equal(18.405m, ic.CalculateNetTotal());
        }

        [Fact]
        public void MultipleLinesWithDiscount_CalculateTotalDiscount_ShouldReturnCorrectDiscount()
        {

            var lines = LineImporter.Import(["IL,3548769012345,2.5", "IL,8912345670123,3", "D,10", "IL,5678932104987,4", "IL,8790234561876,1", "IL,1234012345678,6"]);
            var products = ProductImporter.Import(File.ReadAllLines("products.csv"));

            var ic = new InvoiceCalculator(products, lines);
            Assert.Equal(2.454m, ic.CalculateTotalDiscount());
        }
    }
}
