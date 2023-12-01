/*
    -------------------------------------------------------------
                        HTBLA Leonding - 2AHIF
    -------------------------------------------------------------
                      Antonio Subašić, 1.12.2023
    -------------------------------------------------------------
                      Calculator with functions
    -------------------------------------------------------------
*/

#include <stdio.h>

int read_operands(float *number1, float *number2)
{
    printf("Enter the first number: ");
    scanf("%f", number1);

    printf("Enter the second number: ");
    scanf("%f", number2);
}

int print_result(float result)
{
    printf("%1.2f\n", result);
}

int add(float number1, float number2, float *result)
{
    *result = number1 + number2;
}

int subtract(float number1, float number2, float *result)
{
    *result = number1 - number2;
}

float multiply(float a, float b)
{
    return a * b;
}

float divide(float a, float b)
{
    return a / b;
}

int main(void)
{
    float a, b;
    char operator;

    read_operands(&a, &b);

    printf("Enter whether you want to add (+), subtract (-), multiply (*) or divide (/): ");
    scanf(" %c", &operator);

    float result;
    switch (operator)
    {
    case '+':
        add(a, b, &result);
        break;
    case '-':
        subtract(a, b, &result);
        break;
    case '*':
        result = multiply(a, b);
        break;
    case '/':
        if (b == 0)
        {
            printf("Error: Cannot divide with 0!\n");
            return 1;
        }
        else
        {
            result = divide(a, b);
            break;
        }
    default:
        printf("Invalid operator");
        return 1;
    }

    printf("The result is: %1.2f\n", result);
    return 0;
}
