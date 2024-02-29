/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 28.02.2024
-------------------------------------------------------------
                        Array sorting
-------------------------------------------------------------
*/

#include <stdio.h>

void print_array(int numbers[], int size) {
  for (int i = 0; i < size; i++) {
    printf("%d ", numbers[i]);
  }
  printf("\n");
}

int main() {
  int numbers[] = {3, 5, 1, 2, 4, 16, 27, 1, 0};
  int size = sizeof(numbers) / sizeof(numbers[0]);

  print_array(numbers, size);

  for (int i = 0; i < size; i++) {
    for (int j = 0; j < size - 1; j++) {
      if (numbers[j] > numbers[j + 1]) {
        int temp = numbers[j];
        numbers[j] = numbers[j + 1];
        numbers[j + 1] = temp;
      }
    }
  }

  print_array(numbers, size);

  return 0;
}
