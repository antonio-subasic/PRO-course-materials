class InPlace
{
    private List<long> _numbers = [];

    public void GenerateNumbers(long start, long end)
    {
        for (var i = start; i <= end; i++)
        {
            _numbers.Add(i);
        }
    }

    public void InsertSumAfterPairs()
    {
        for (var i = 0; i < _numbers.Count; i += 3)
        {
            _numbers.Insert(i + 2, _numbers[i] + _numbers[i + 1]);
        }
    }

    public void RemoveEvenNumbers()
    {
        for (var i = 0; i < _numbers.Count; i++)
        {
            if (_numbers[i] % 2 == 0)
            {
                _numbers.RemoveAt(i--);
            }
        }
    }

    public void ReplaceWithRunningTotal()
    {
        long runningTotal = 0;
        for (var i = 0; i < _numbers.Count; i++)
        {
            _numbers[i] = runningTotal += _numbers[i];
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