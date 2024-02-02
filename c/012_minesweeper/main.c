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

/*************** Berechne Anzahl der Nachbar-Minen *****/
int Nachbar_Minen(int matrix[zeilenMax][spaltenMax]) {
  int zeile = 0;
  int spalte = 0;
  int z;
  int sp;
  int anzahl = 0;

  for (zeile = 0; zeile < zeilenMax; zeile++) {
    for (spalte = 0; spalte < spaltenMax; spalte++) {
      if (matrix[zeile][spalte] != 9) // kein Minenfeld
      {
        anzahl = 0;
        for (z = zeile - 1; z <= zeile + 1; z++) {
          for (sp = spalte - 1; sp <= spalte + 1; sp++) {
            if (z >= 0 && z < zeilenMax && sp >= 0 && sp < spaltenMax) {
              if (matrix[z][sp] == 9) {
                anzahl++;
              }
            }
          }
        }
        matrix[zeile][spalte] = anzahl;
      }
    }
  }

  Ausgabe_int(matrix); // Testausgabe

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

  // ****** Matrix bearbeiten **********
  Nachbar_Minen(matrix);

  while (ende == 0) {
    Ausgabe(matrixAusgabe);

    printf("Bitte Zeile eingeben: ");
    scanf("%d", &zeile);
    zeile = zeile - 1;

    printf("Bitte Spalte eingeben: ");
    scanf("%d", &spalte);
    spalte = spalte - 1;
    getchar();

    if (matrixAusgabe[zeile][spalte] == '0') // bereits aufgedecktes Feld
    {
      printf("Dieses Feld wurde schon getippt\n");
      getchar();
    } else {
      if (matrix[zeile][spalte] == 9) // Minenfeld
      {
        matrixAusgabe[zeile][spalte] = 'X';
        Ausgabe(matrixAusgabe);
        printf("Miene! Leider verloren!\n");
        ende = 1;
      } else {
        matrixAusgabe[zeile][spalte] =
            matrix[zeile][spalte] + 48; // leeres Feld aufdecken
      }
      versuche++;
    }
    if (versuche == 13) // alle Felder aufgedeckt
    {
      printf("Hurra, Sie haben gewonnen!\n");
      ende = 1;
    }
  }
  printf("Sie hatten %d erfolgreiche Versuche. \n", versuche);
  getchar();

  return (0);
}