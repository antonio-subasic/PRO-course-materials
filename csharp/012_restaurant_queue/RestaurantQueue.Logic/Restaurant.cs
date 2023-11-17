using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestaurantQueue.Logic;

public class RestaurantQueue
{
    private CustomerInQueue? _first { get; set; }
    private CustomerInQueue? _last { get; set; }
    public bool IsEmpty => _first is null || _last is null;

    public void Add(CustomerInQueue? customer)
    {
        if (IsEmpty) { _first = _last = customer; }
        else
        {
            Debug.Assert(_last is not null, "If IsEmpty is false, _last must not be null");
            _last = _last.Next = customer;
        }
    }

    public CustomerInQueue? Remove()
    {
        var current = _first;

        if (_first is not null) { _first = _first.Next; }
        if (_first is null) { _last = null; }

        return current;
    }

    public void RemoveByName(string name)
    {
        if (_first?.Name == name) { Remove(); }
        else
        {
            var current = _first;

            while (current?.Next?.Name != name && current?.Next is not null) { current = current.Next; }
            if (current?.Next is not null) { current.Next = current.Next.Next; }
        }
    }

    public string Save(string filename)
    {
        var customers = new List<CustomerInQueue>();

        for (var current = _first; current is not null; current = current.Next) { customers.Add(current); }

        File.WriteAllText(
            filename,
            JsonSerializer.Serialize(customers, new JsonSerializerOptions() { WriteIndented = true })
        );

        return $"Saved {customers.Count} customers to {filename}";
    }

    public string? TryLoad(string filename)
    {
        var customers = JsonSerializer.Deserialize<CustomerInQueue[]>(File.ReadAllText(filename));

        if (customers is not null)
        {
            foreach (var customer in customers) { Add(customer); }
            return $"Loaded {customers.Length} customers from {filename}";
        }
        else { return null; }
    }

    public override string? ToString()
    {
        var stringBuilder = new StringBuilder();

        for (var current = _first; current is not null; current = current.Next)
        {
            stringBuilder.AppendLine(current.ToString());
        }

        return stringBuilder.Length == 0 ? "The queue is empty" : stringBuilder.ToString().TrimEnd('\n');
    }
}

public class CustomerInQueue(string name, string phoneNumber)
{
    [JsonPropertyName("name")]
    public string Name { get; } = name;

    [JsonPropertyName("phone-number")]
    public string PhoneNumber { get; } = phoneNumber;

    [JsonIgnore]
    public CustomerInQueue? Next { get; set; }

    public override string ToString() => $"{Name} ({PhoneNumber})";
}
