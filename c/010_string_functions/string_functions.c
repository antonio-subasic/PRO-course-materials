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

int mystrcontains(char *haystack, char *needle)
{
    int needleLength = mystrlen(needle);
    int haystackLength = mystrlen(haystack);

    for (int i = 0; i < haystackLength; i++)
    {
        for (int j = 0; j < needleLength; j++)
        {
            if (haystack[i + j] != needle[j]) { break; }

            if (j == needleLength - 1)
            {
                // it contains the string so return 0
                return 0;
            }
        }
    }

    // it doesn't contain the string so return -1
    return -1;
}

int mystrtrim(char *dest, char *src)
{
    int start = 0;
    while (start < mystrlen(src) && src[start] == ' ') { start++; }

    int end = mystrlen(src) - 1;
    while (end > 0 && src[end] == ' ') { end--; }

    for (int i = 0; i <= end - start; i++)
    {
        dest[i] = src[i + start];
    }
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
    printf("str1 %s str2\n", difference < 0 ? "is smaller than" : difference > 0 ? "is bigger than" : "is equal to");

    printf("str2 contains str1: %s\n", mystrcontains(str2, str1) == 0 ? "true" : "false");

    printf("str1 contains str3: %s\n", mystrcontains(str1, str3) == 0 ? "true" : "false");

    char str5[50] = "   Hello World   ";
    char str6[50];
    mystrtrim(str6, str5);
    printf("str5: '%s'\n", str5);
    printf("str6: '%s'\n", str6);

    return 0;
}
