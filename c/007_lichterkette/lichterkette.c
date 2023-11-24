/*
    -------------------------------------------------------------
                        HTBLA Leonding - 2AHIF
    -------------------------------------------------------------
                     Antonio Subašić, 24.11.2023
    -------------------------------------------------------------
                             Lichterkette
    -------------------------------------------------------------
*/

#include <stdio.h>

int print_register(unsigned char reg)
{
    for (int i = 0; i < 8; i++)
    {
        printf(reg & 128 ? "*" : " ");
        reg = reg << 1;
    }

    printf("\n");
}

int main()
{
    unsigned char reg;

    printf("From left to right:\n");
    for (int i = 0; i < 8; i++)
    {
        reg = 1 << (7 - i);
        print_register(reg);
    }

    printf("\nFrom right to left:\n");
    for (int i = 0; i < 8; i++)
    {
        reg = 1 << i;
        print_register(reg);
    }

    printf("\nFrom outside to inside to outside:\n");
    for (int i = 0; i < 8; i++)
    {
        reg = 1 << i;
        reg = reg | (1 << (7 - i));
        print_register(reg);
    }

    printf("\nFrom inside to outside to inside:\n");
    for (int i = 0; i < 8; i++)
    {
        int pos1 = i < 4 ? (3 - i) : (i - 4);
        int pos2 = i < 4 ? (4 + i) : (11 - i);

        reg = 1 << pos1;
        reg = reg | (1 << pos2);

        print_register(reg);
    }

    printf("\nFirst from left to right then from right to left:\n");
    for (int i = 0; i < 16; i++)
    {
        if (i < 8) { reg = 1 << (7 - i); }
        else
        {
            reg = reg | (1 << (i - 8));
            if (i > 8) { reg = reg & ~(1 << (i - 9)); }
        }

        print_register(reg);
    }

    printf("\nFirst from right to left then from left to right:\n");
    for (int i = 0; i < 16; i++)
    {
        if (i < 8) { reg = 1 << i; }
        else
        {
            reg = reg | (1 << (15 - i));
            if (i > 8) { reg = reg & ~(1 << (16 - i)); }
        }

        print_register(reg);
    }

    return 0;
}
