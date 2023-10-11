/*
    Antonio Subašić
    06.10.2023
    Calculator
*/

#include <stdio.h>

int Add(int a, int b)
{
    return a + b;
}

int Subtract(int a, int b)
{
    return a - b;
}

int Multiply(int a, int b)
{
    return a * b;
}

float Divide(int a, int b)
{
    return (float)a / (float)b;
}

int main(void)
{
    int a, b;
    char operator;

    printf("Enter the first number: ");
    scanf("%d", &a);

    printf("Enter the second number: ");
    scanf("%d", &b);

    printf("Enter whether you want to add (+), subtract (-), multiply (*) or divide (/): ");
    scanf(" %c", &operator);

    float result;
    switch (operator)
    {
    case '+':
        result = Add(a, b);
        break;
    case '-':
        result = Subtract(a, b);
        break;
    case '*':
        result = Multiply(a, b);
        break;
    case '/':
        result = Divide(a, b);
        break;
    default:
        printf("Invalid operator");
        return 1;
    }

    printf("The result is: %1.2f\n", result);
    return 0;
}
