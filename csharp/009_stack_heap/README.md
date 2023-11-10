Code snippets for [sharplab](https://sharplab.io)

# Allocating variables on the stack and heap
```csharp
using System;

Start();

void Start()
{
    int x = 1;
    double y = 2.0;
    string txt = "Harry Potter";
    
    Inspect.MemoryGraph(x, y, txt);
}
```

# Allocating arrays on the heap
```csharp
using System;

Start();

void Start()
{
    var arr1 = new string[][]
    {
        new[] { "Foo", "Bar" },
        new[] { "Foo2", "Bar2" }
    };
    var arr2 = new int[3];
    var arr3 = new string[3];
    
    Inspect.MemoryGraph(arr1, arr2, arr3);
}
```

# Allocating an array on the stack
```csharp
using System;

Start();

void Start()
{
    Span<int> arr = stackalloc int[3];
    
    Inspect.MemoryGraph(arr);
}
```

# Nullable reference types
```csharp
using System;

Start();

void Start()
{
    string? x = null;
    
    Inspect.MemoryGraph(x);
    
    
    if (x is not null)
    {
        Console.WriteLine(x.Length);
    }
    else
    {
        Console.WriteLine("");
    }
    
    Console.WriteLine(x?.Length);
}