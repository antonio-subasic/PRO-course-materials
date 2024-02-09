/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 09.02.2024
-------------------------------------------------------------
                          recursion
-------------------------------------------------------------
*/

#include <stdio.h>

int factorial(int n) {
    if (n == 0) {
        return 1;
    }

    return n * factorial(n - 1);
}

int multiplication(int x, int y) {
    if (y == 0) {
        return 0;
    }

    return x + multiplication(x, y - 1);
}

int division(int x, int y) {
    if (x < y) {
        return 0;
    }

    return 1 + division(x - y, y);
}

int fibonacci(int n) {
    if (n == 0 || n == 1) {
        return n;
    }

    return fibonacci(n - 1) + fibonacci(n - 2);
}

int main() {
    printf("5! = %d\n", factorial(5));
    printf("5 * 3 = %d\n", multiplication(5, 3));
    printf("10 / 2 = %d\n", division(10, 2));
    printf("fib(10) = %d\n", fibonacci(10));

    return 0;
}
