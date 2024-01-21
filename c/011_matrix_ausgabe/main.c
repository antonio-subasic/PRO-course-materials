/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 19.01.2024
-------------------------------------------------------------
                  Matrix Ausgabe: Diagramme
-------------------------------------------------------------
*/

#include <stdio.h>

#define DATA_ROWS 3
#define DATA_COLS 24
#define OUTPUT_ROWS 24
#define OUTPUT_COLS 24

int printOutput(char output[OUTPUT_ROWS][OUTPUT_COLS]) {
  for (int i = 0; i < OUTPUT_ROWS; i++) {
    for (int j = 0; j < OUTPUT_COLS; j++) {
      printf("%c", output[i][j]);
    }
    printf("\n");
  }
  printf("\n");
}

int clearOutput(char output[OUTPUT_ROWS][OUTPUT_COLS]) {
  for (int i = 0; i < OUTPUT_ROWS; i++) {
    for (int j = 0; j < OUTPUT_COLS; j++) {
      output[i][j] = ' ';
    }
  }
}

int barChart(char output[OUTPUT_ROWS][OUTPUT_COLS], int data[DATA_ROWS][DATA_COLS]) {
  for (int i = 0; i < DATA_COLS; i++) {
    for (int j = 0; j < data[0][i]; j++) {
      output[i][j] = '*';
    }
  }
}

int lineChart(char output[OUTPUT_ROWS][OUTPUT_COLS], int data[DATA_ROWS][DATA_COLS]) {
  for (int i = 0; i < DATA_COLS; i++) {
    for (int j = 0; j < data[0][i]; j++) {
      output[OUTPUT_ROWS - j - 1][i] = '*';
    }
  }
}

int curveChart(char output[OUTPUT_ROWS][OUTPUT_COLS], int data[DATA_ROWS][DATA_COLS], int day) {
  for (int i = 0; i < DATA_COLS; i++) {
    if (data[day][i] > 0) {
      output[OUTPUT_ROWS - data[day][i] - 1][i] = '*';
    }
  }
}

int main() {
  int data[DATA_ROWS][DATA_COLS] = {
    {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 0, 1, 2, 3, 4},
    {1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 2, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14},
    {15, 14, 13, 12, 11, 12, 13, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 1, 2, 3}
  };

  char output[OUTPUT_ROWS][OUTPUT_COLS];
  
  clearOutput(output);
  printf("Balkendiagramm:\n");
  barChart(output, data);
  printOutput(output);

  clearOutput(output);
  printf("Stabdiagramm:\n");
  lineChart(output, data);
  printOutput(output);

  clearOutput(output);
  for (int i = 0; i < DATA_ROWS; i++) {
    printf("Kurvendiagramm Tag %d:\n", i + 1);
    curveChart(output, data, i);
    printOutput(output);
    clearOutput(output);
  }
  
  return 0;
}
