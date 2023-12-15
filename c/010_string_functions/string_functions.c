/*
    -------------------------------------------------------------
                        HTBLA Leonding - 2AHIF
    -------------------------------------------------------------
                     Antonio Subašić, 12.12.2023
    -------------------------------------------------------------
                           String Functions
    -------------------------------------------------------------
*/

#include <stdio.h>

int mystrlen(char *array)
{
    int index = 0;
    while (array[index] != '\0')
    {
        index++;
    }

    return index;
}

int mystrcpy(char *dest, char *src)
{
    for (int i = 0; i < mystrlen(src); i++)
    {
        dest[i] = src[i];
    }
}

int mystrcmp(char *first, char *second)
{
    for (int i = 0; i <= mystrlen(first) && i <= mystrlen(second); i++)
    {
        if (first[i] != second[i])
        {
            return first[i] - second[i];
        }
    }

    return 0;
}

int main()
{
    char str1[50] = "Hello";
    char str2[50] = "Hello World";
    char str3[50] = "Hello hello";

    printf("Length of str1: %d\n", mystrlen(str1));
    printf("Length of str2: %d\n", mystrlen(str2));
    printf("Length of str3: %d\n", mystrlen(str3));

    char str4[50];
    mystrcpy(str4, str1);
    printf("str4: %s\n", str4);

    int difference = mystrcmp(str1, str2);
    printf("str1 %s str2", difference < 0 ? "is smaller than" : difference > 0 ? "is bigger than" : "is equal to");

    return 0;
}
