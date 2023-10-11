/*
    Antonio Subašić
    10.10.2023
    Einkommensberechnung
*/

#include <stdio.h>

float calculatePercentageFrom(float value, int percentage)
{
    return value * (float)percentage / 100;
}

float min(float a, float b)
{
    return a < b ? a : b;
}

int main()
{
    const int incomeRates[8] = {0, 11000, 18000, 31000, 60000, 90000, 1000000, -1};
    const int taxRates[7] = {0, 20, 35, 42, 48, 50, 55};

    float income;
    printf("Enter your income: ");
    scanf("%f", &income);

    int incomeRatesLength = sizeof(incomeRates) / sizeof(incomeRates[0]);
    float originalIncome = income;
    float tax = 0;

    for (int i = 0; income > 0; i++)
    {
        float incomeValue = incomeRates[i + 1] == -1 ? income : min(incomeRates[i + 1] - incomeRates[i], income);
        float taxRate = calculatePercentageFrom(incomeValue, taxRates[i]);

        income -= incomeValue;
        tax += taxRate;
    }

    printf("Total tax: %1.2f€\n", tax);
    printf("Netto income: %1.2f€\n", originalIncome - tax);

    return 0;
}
