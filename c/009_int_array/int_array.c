/*
    -------------------------------------------------------------
                        HTBLA Leonding - 2AHIF
    -------------------------------------------------------------
                     Antonio Subašić, 12.12.2023
    -------------------------------------------------------------
                              Int Array
    -------------------------------------------------------------
*/

#include <stdio.h>

int main()
{
    int numbers[5];
    int numbers_length = sizeof(numbers) / sizeof(numbers[0]);

    // a) Eingabe
    for (int i = 0; i < numbers_length; i++)
    {
        printf("Enter a positive number: ");
        scanf("%d", &numbers[i]);
    }

    printf("\n");

    // b) Ausgabe
    for (int i = 0; i < numbers_length; i++)
    {
        printf("%i. number: %d\n", i + 1, numbers[i]);
    }

    printf("\n");

    // c) Mittelwert berechnen
    float sum = 0;
    for (int i = 0; i < numbers_length; i++)
    {
        sum += numbers[i];
    }
    float average = sum / (float)numbers_length;
    printf("average: %1.2f\n\n", average);

    // d) größte und zweitgrößte Zahl ausgeben
    int greatest = numbers[0];
    int second_greatest = numbers[0];
    for (int i = 1; i < numbers_length; i++)
    {
        if (numbers[i] > greatest)
        {
            second_greatest = greatest;
            greatest = numbers[i];
        }
        else if (numbers[i] > second_greatest)
        {
            second_greatest = numbers[i];
        }
    }
    printf("greatest: %d\nsecond greatest: %d\n\n", greatest, second_greatest);

    // e) doppelte Werte entfernen (durch -1 ersetzen)
    for (int i = 0; i < numbers_length; i++)
    {
        for (int j = 0; j < numbers_length; j++)
        {
            if (i != j && numbers[i] == numbers[j])
            {
                numbers[i] = -1;
            }
        }
    }

    // f) Sortieren
    int something_changed = 0;
    do
    {
        something_changed = 0;

        for (int i = 0; i < numbers_length - 1; i++)
        {
            if (numbers[i] > numbers[i + 1])
            {
                int temp = numbers[i];
                numbers[i] = numbers[i + 1];
                numbers[i + 1] = temp;
                something_changed = 1;
            }
        }
    } while (something_changed);

    printf("Sorted:\n");

    for (int i = 0; i < numbers_length; i++)
    {
        printf("%i. number: %d\n", i + 1, numbers[i]);
    }
}
