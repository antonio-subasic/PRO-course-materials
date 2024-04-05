namespace Invoice.Logic;

public abstract class Line { }

public class InvoiceLine(string ean, decimal quantity) : Line
{
    public string EAN { get; } = ean;
    public decimal Quantity { get; } = quantity;
}

public class DiscountLine(decimal percentage) : Line
{
    public decimal Percentage { get; } = percentage;
}

public class LineImporter
{
    /// <summary>
    /// Imports an invoice line or a discount line from the given string.
    /// </summary>
    /// <param name="line">Line of text read from a file that should be imported</param>
    /// <returns>
    /// Line of an invoice or a discount
    /// </returns>
    /// <exception cref="InvoiceLineImportException">Thrown when the import fails</exception>
    /// <remarks>
    /// The import can fail unter the following conditions:
    /// - <paramref name="line"/> is empty
    /// - A line contains invalid data (missing column, empty column, wrong data type, negative values)
    /// In all cases, the exception message should contain a meaningful error message.
    /// </remarks>
    public static Line Import(string line)
    {
        var parts = line.Split(',');

        if (parts.Length == 0) { throw new InvoiceLineImportException("empty line"); }
        else if (!(parts[0] is "IL" or "D")) { throw new InvoiceLineImportException("invalid line type"); }
        else if (parts.Any(string.IsNullOrEmpty)) { throw new InvoiceLineImportException("column is empty"); }
        else
        {
            var (validLength, valueIndex) = parts[0] == "IL" ? (3, 2) : (2, 1);

            if (parts.Length != validLength) { throw new InvoiceLineImportException("too little or too much data"); }
            else if (!decimal.TryParse(parts[valueIndex], out var value)) { throw new InvoiceLineImportException("quantity is not a number"); }
            else if (value < 0) { throw new InvoiceLineImportException("quantity is negative"); }
            else
            {
                if (parts[0] == "IL") { return new InvoiceLine(parts[1], value); }
                else { return new DiscountLine(value / 100m); }
            }
        }
    }

    /// <summary>
    /// Imports an invoice and discount lines from the given string array.
    /// </summary>
    /// <param name="lines">Lines read from a file that should be imported</param>
    /// <returns>
    /// Collection of lines and discounts
    /// </returns>
    /// <exception cref="InvoiceLineImportException">Thrown when the import fails</exception>
    /// <remarks>
    /// The import can fail unter the following conditions:
    /// - <paramref name="lines"/> is empty
    /// - A line contains invalid data (missing column, empty column, wrong data type, negative values)
    /// - The same EAN appears multiple times in the lines
    /// In all cases, the exception message should contain a meaningful error message.
    /// </remarks>
    public static IEnumerable<Line> Import(string[] lines)
    {
        var importedLines = new List<Line>();

        foreach (var line in lines.Select(Import))
        {
            if (line is InvoiceLine invoiceLine)
            {
                if (importedLines.OfType<InvoiceLine>().Any(l => l.EAN == invoiceLine.EAN))
                {
                    throw new InvoiceLineImportException($"EAN {invoiceLine.EAN} appears multiple times");
                }
            }

            importedLines.Add(line);
        }

        return importedLines;
    }
}

public class InvoiceLineImportException : Exception
{
    public InvoiceLineImportException() { }

    public InvoiceLineImportException(string message) : base(message) { }

    public InvoiceLineImportException(string message, Exception innerException) : base(message, innerException) { }
}

