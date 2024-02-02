/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 02.02.2024
-------------------------------------------------------------
                         Minesweeper
-------------------------------------------------------------
*/

#include <stdio.h>

#define zeilenMax 4
#define spaltenMax 5

/******************Ausgabe****************/

int Ausgabe(char matrixAusgabe[zeilenMax][spaltenMax]) {
  int zeile = 0;
  int spalte = 0;

  printf("\n");

  for (zeile = 0; zeile < zeilenMax; zeile++) {
    for (spalte = 0; spalte < spaltenMax; spalte++) {
      printf(" %c", matrixAusgabe[zeile][spalte]);
    }
    printf("\n");
  }
  printf("\n");

  return 0;
}

/******************Ausgabe Test int-Matrix ****************/
int Ausgabe_int(int matrixAusgabe[zeilenMax][spaltenMax]) {
  int zeile = 0;
  int spalte = 0;

  printf("\n");

  for (zeile = 0; zeile < zeilenMax; zeile++) {
    for (spalte = 0; spalte < spaltenMax; spalte++) {
      printf(" %d", matrixAusgabe[zeile][spalte]);
    }
    printf("\n");
  }
  printf("\n");

  return 0;
}

/***********Hauptprogramm********/
int main(void) {
  int matrix[zeilenMax][spaltenMax] = {
      {0, 0, 9, 0, 0},
      {0, 0, 9, 9, 0},
      {0, 0, 9, 0, 0},
      {0, 9, 9, 9, 0},
  };
  char matrixAusgabe[zeilenMax][spaltenMax] = {
      {'.', '.', '.', '.', '.'},
      {'.', '.', '.', '.', '.'},
      {'.', '.', '.', '.', '.'},
      {'.', '.', '.', '.', '.'},
  };
  int zeile = 0;
  int spalte = 0;
  int versuche = 0;
  int ende = 0;
  int z;
  int sp;

  while (ende == 0) {
    Ausgabe(matrixAusgabe);

    printf("Bitte Zeile eingeben: ");
    scanf("%d", &zeile);
    zeile = zeile - 1;

    printf("Bitte Spalte eingeben: ");
    scanf("%d", &spalte);
    spalte = spalte - 1;
    getchar();

    if (matrix[zeile][spalte] == 9) {
      printf("Sie haben eine Bombe getroffen! \n");
      matrixAusgabe[zeile][spalte] = 'x';
      Ausgabe(matrixAusgabe);
      ende = 1;
    } else {
      matrixAusgabe[zeile][spalte] = 'o';
      versuche++;
    }
  }
  printf("Sie hatten %d erfolgreiche Versuche. \n", versuche);
  getchar();

  return (0);
}
