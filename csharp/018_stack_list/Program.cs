﻿var inPlace = new InPlace();
inPlace.GenerateNumbers(1, 100);
Console.WriteLine(inPlace.CalculateSum());
inPlace.InsertSumAfterPairs();
Console.WriteLine(inPlace.CalculateSum());
inPlace.RemoveEvenNumbers();
Console.WriteLine(inPlace.CalculateSum());
inPlace.ReplaceWithRunningTotal();
Console.WriteLine(inPlace.CalculateSum());
long result = inPlace.CalculateResult();
Console.WriteLine($"Result: {result}");