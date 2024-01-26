static class NewList
{
    public static List<long> GenerateNumbers(long start, long end)
    {
        var numbers = new List<long>();

        for (var i = start; i <= end; i++)
        {
            numbers.Add(i);
        }

        return numbers;
    }

    public static List<long> InsertSumAfterPairs(List<long> numbers)
    {
        for (var i = 0; i < numbers.Count; i += 3)
        {
            numbers.Insert(i + 2, numbers[i] + numbers[i + 1]);
        }

        return numbers;
    }

    public static List<long> RemoveEvenNumbers(List<long> numbers)
    {
        for (var i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                numbers.RemoveAt(i--);
            }
        }

        return numbers;
    }

    public static List<long> ReplaceWithRunningTotal(List<long> numbers)
    {
        long runningTotal = 0;
        for (var i = 0; i < numbers.Count; i++)
        {
            numbers[i] = runningTotal += numbers[i];
        }

        return numbers;
    }

    public static long CalculateSum(List<long> numbers)
    {
        long sum = 0;
        foreach (var number in numbers) { sum += number; }
        return sum;
    }

    public static long CalculateResult(List<long> numbers) => CalculateSum(numbers) / numbers.Count + CalculateSum(numbers);
}