/*
    Antonio Subašić
    24.10.2023
    Bit Operatoren
*/

#include <stdio.h>

int getPosition()
{
    int pos;
    scanf("%d", &pos);

    if (pos < 1 || pos > 8)
    {
        printf("Invalid position, try again: ");
        return getPosition();
    }
    else
    {
        return pos;
    }
}

int setBit(int pos) { return 1 << (pos - 1); }

int printRegister(unsigned char reg)
{
    int i;

    for (i = 0; i < 8; i++)
    {
        if (reg & 128)
        {
            printf("1");
        }
        else
        {
            printf("0");
        }

        reg = reg << 1;
    }

    printf("\n");
}

int main()
{
    int value;
    unsigned char reg;
    printf("Enter a starting value: ");
    scanf("%d", &value);
    reg = (char)value;
    printRegister(reg);

    unsigned char x;

    printf("Which position do you want to turn on: ");
    x = setBit(getPosition());
    reg = reg | x;
    printRegister(reg);

    printf("Which position do you want to turn off: ");
    x = setBit(getPosition());
    reg = reg & ~x;
    printRegister(reg);

    printf("Which position do you want to change: ");
    x = setBit(getPosition());
    reg = reg ^ x;
    printRegister(reg);

    printf("Which position do you want to check: ");
    x = setBit(getPosition());

    printf("\nBit is %sset", (reg & x) == x ? "" : "not ");

    return 0;
}
