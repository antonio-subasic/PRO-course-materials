namespace Invoice.Logic;

public enum UnitOfMeasure
{
    Pieces,
    Kilograms,
}

public enum VATPercentage
{
    Reduced = 10,
    Standard = 20,
}

public record Product(
    string EAN,
    string Name,
    VATPercentage VATPercentage,
    decimal NetPrice,
    UnitOfMeasure UnitOfMeasure,
    bool IsMultipack
);

public class ProductImporter
{
    /// <summary>
    /// Imports products from the given lines.
    /// </summary>
    /// <param name="lines">Lines read from a file that should be imported</param>
    /// <returns>
    /// Collection of products
    /// </returns>
    /// <exception cref="ProductImportException">Thrown when the import fails</exception>
    /// <remarks>
    /// The import can fail unter the following conditions:
    /// - <paramref name="lines"/> is empty
    /// - The header line is missing or contains invalid column names or the order of columns is wrong
    /// - A line contains invalid data (missing column, empty column, wrong data type, negative values)
    /// - IsMultiPack is true when unit of measure is not Pieces
    /// In all cases, the exception message should contain a meaningful error message.
    /// </remarks>
    public static IEnumerable<Product> Import(string[] lines)
    {
        var products = new List<Product>();

        if (lines.Length == 0) { throw new ProductImportException("line is empty"); }
        else if (lines[0] != "EAN,Name,VATPercentage,NetPrice,UnitOfMeasure,IsMultiPack") { throw new ProductImportException("header is invalid"); }
        else
        {
            foreach (var line in lines[1..])
            {
                var parts = line.Split(',');

                if (parts.Length != 6) { throw new ProductImportException("line contains too little or too much data"); }
                else if (parts.Any(string.IsNullOrEmpty)) { throw new ProductImportException("column is empty"); }
                else
                {
                    var (ean, name) = (parts[0], parts[1]);

                    if (!(parts[2] is "10" or "20")) { throw new ProductImportException("invalid VATPercentage"); }
                    else
                    {
                        if (!decimal.TryParse(parts[3], out var price)) { throw new ProductImportException("NetPrice is not a number"); }
                        else if (!(parts[4] is "kg" or "pcs")) { throw new ProductImportException("invalid UnitOfMeasure"); }
                        else if (!bool.TryParse(parts[5], out var isMultiPack)) { throw new ProductImportException("invalid IsMultiPack"); }
                        else
                        {
                            products.Add(new(
                                ean,
                                name,
                                parts[2] == "10" ? VATPercentage.Reduced : VATPercentage.Standard,
                                price,
                                parts[4] == "kg" ? UnitOfMeasure.Kilograms : UnitOfMeasure.Pieces,
                                isMultiPack
                            ));
                        }
                    }
                }
            }
        }

        return products;
    }
}

public class ProductImportException : Exception
{
    public ProductImportException() { }

    public ProductImportException(string message) : base(message) { }

    public ProductImportException(string message, Exception innerException) : base(message, innerException) { }
}
