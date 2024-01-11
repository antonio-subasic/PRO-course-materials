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
    for (int i = 0; i <= mystrlen(src); i++)
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

int mystrcont(char *src, char *value)
{
    for (int i = 0; i < mystrlen(src) - mystrlen(value); i++)
    {
        for (int j = 0; j < mystrlen(value); j++)
        {
            if (src[i + j] != value[j])
            {
                break;
            }
            else if (j == mystrlen(value) - 1)
            {
                return 1;
            }
        }
    }

    return 0;
}

int mystrtrim(char *dest, char *src)
{
    int start = 0;
    while (start <= mystrlen(src) && src[start] == ' ')
    {
        start++;
    }

    int end = mystrlen(src) - 1;
    while (end > 0 && src[end] == ' ')
    {
        end--;
    }

    for (int i = start; i <= end; i++)
    {
        dest[i - start] = src[i];
    }
}

int mystrcatord(char *dest, char *first, char *second)
{
    int idxFirst = 0;
    int idxSecond = 0;

    int firstDone = 0;
    int secondDone = 0;

    while (!firstDone || !secondDone)
    {
        while (!firstDone && (secondDone || first[idxFirst] <= second[idxSecond]))
        {
            dest[idxFirst + idxSecond] = first[idxFirst];
            firstDone = first[++idxFirst] == '\0';
        }

        while (!secondDone && (firstDone || second[idxSecond] <= first[idxFirst]))
        {
            dest[idxFirst + idxSecond] = second[idxSecond];
            secondDone = second[++idxSecond] == '\0';
        }
    }
}

int main()
{
    char str1[50] = "Hello";
    char str2[50] = "Hello World";
    char str3[50] = "Hello hello";

    printf("Length of str1: %d\n", mystrlen(str1));
    printf("Length of str2: %d\n", mystrlen(str2));

    char str4[50];
    mystrcpy(str4, str1);
    printf("str4: %s\n", str4);

    int difference = mystrcmp(str1, str2);
    printf("str1 %s str2\n", difference < 0 ? "is smaller than" : difference > 0 ? "is bigger than"
                                                                                 : "is equal to");

    printf("str2 contains str1: %s\n", mystrcont(str2, str1) ? "true" : "false");
    printf("str1 contains str3: %s\n", mystrcont(str1, str3) ? "true" : "false");

    char str5[50] = "   Hello World   ";
    char str6[50];
    mystrtrim(str6, str5);
    printf("str5: '%s'\n", str5);
    printf("str6: '%s'\n", str6);

    char str7[50] = "aabbbcccj";
    char str8[50] = "akoop";
    char str9[50];
    mystrcatord(str9, str7, str8);
    printf("str7 (%s) concated with str8 (%s): %s\n", str7, str8, str9);

    return 0;
}
