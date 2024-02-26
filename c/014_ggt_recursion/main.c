/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 26.02.2024
-------------------------------------------------------------
                        GGT Rekursion
-------------------------------------------------------------
*/

#include <stdio.h>

long ggt(long a, long b) {
    if (a == b) {
        return a;
    }
    
    if (a > b) {
        return ggt(a - b, b);
    }

    if (a < b) {
        return ggt(a, b - a);
    }
}

int main() {
    long a = 0;
    long b = 0;

    printf("Bitte geben Sie die erste Zahl ein: ");
    scanf("%ld", &a);
    printf("Bitte geben Sie die zweite Zahl ein: ");
    scanf("%ld", &b);

    printf("Der größte gemeinsame Teiler von %ld und %ld ist %ld\n", a, b, ggt(a, b));

    return 0;
}
