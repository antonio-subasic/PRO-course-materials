class InPlace
{
    private Stack<long> _numbers = [];

    public static void InsertAt(Stack<long> stack, int index, long item)
    {
        var temp = new Stack<long>();
        for (var i = 0; i < index; i++) { temp.Push(stack.Pop()); }
        stack.Push(item);
        while (temp.Count != 0) { stack.Push(temp.Pop()); }
    }

    public static void RemoveAt(Stack<long> stack, int index)
    {
        var temp = new Stack<long>();
        for (var i = 0; i < index; i++) { temp.Push(stack.Pop()); }
        stack.Pop();
        while (temp.Count != 0) { stack.Push(temp.Pop()); }
    }

    public void GenerateNumbers(long start, long end)
    {
        for (var i = end; i >= start; i--)
        {
            _numbers.Push(i);
        }
    }

    public void InsertSumAfterPairs()
    {
        for (var i = 0; i < _numbers.Count; i += 3)
        {
            InsertAt(_numbers, i + 2, _numbers.ElementAt(i) + _numbers.ElementAt(i + 1));
        }
    }

    public void RemoveEvenNumbers()
    {
        for (var i = 0; i < _numbers.Count; i++)
        {
            if (_numbers.ElementAt(i) % 2 == 0)
            {
                RemoveAt(_numbers, i--);
            }
        }
    }

    public void ReplaceWithRunningTotal()
    {
        long runningTotal = 0;
        for (var i = 0; i < _numbers.Count; i++)
        {
            runningTotal += _numbers.ElementAt(i);
            RemoveAt(_numbers, i);
            InsertAt(_numbers, i, runningTotal);
        }
    }

    public long CalculateSum()
    {
        long sum = 0;
        foreach (var number in _numbers) { sum += number; }
        return sum;
    }

    public long CalculateResult() => CalculateSum() / _numbers.Count + CalculateSum();
}