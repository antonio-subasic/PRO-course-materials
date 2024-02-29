/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 28.02.2024
-------------------------------------------------------------
                        Binary Search
-------------------------------------------------------------
*/

#include <stdio.h>

int main() {
  int numbers[] = {0, 1, 2, 3, 4, 5, 16, 27};
  int size = sizeof(numbers) / sizeof(numbers[0]);

  int start = 0;
  int end = size;

  int search;
  printf("number to search: ");
  scanf("%d", &search);

  while (start <= end) {
    int middle = (start + end) / 2;

    if (numbers[middle] == search) {
      printf("number found at index %d\n", middle);
      return 0;
    } else if (numbers[middle] < search) {
      start = middle + 1;
    } else {
      end = middle - 1;
    }
  }

  printf("number not found\n");
  return 1;
}
