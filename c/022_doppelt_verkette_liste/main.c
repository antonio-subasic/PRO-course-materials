/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 05.04.2024
-------------------------------------------------------------
                   Doppelt verkettete Liste
-------------------------------------------------------------
*/

#include <stdio.h>
#include <stdlib.h>

struct element {
  int daten;
  struct element *next;
  struct element *previous;
};

struct element *anfang = NULL;
struct element *ende = NULL;

void printList() {
  struct element *aktuell = anfang;
  while (aktuell != NULL) {
    printf("%d ", aktuell->daten);
    aktuell = aktuell->next;
  }
  printf("\n");
}

void appendHead(int wert) {
  struct element *neu = (struct element *)malloc(sizeof(struct element));
  if (neu == NULL) {
    printf("Speicher konnte nicht allokiert werden.\n");
    return;
  }
  neu->daten = wert;
  neu->next = anfang;
  neu->previous = NULL;

  if (anfang != NULL) {
    anfang->previous = neu;
  } else {
    ende = neu;
  }

  anfang = neu;
}

void appendTail(int wert) {
  struct element *neu = (struct element *)malloc(sizeof(struct element));
  if (neu == NULL) {
    printf("Speicher konnte nicht allokiert werden.\n");
    return;
  }
  neu->daten = wert;
  neu->next = NULL;
  neu->previous = ende;

  if (ende != NULL) {
    ende->next = neu;
  } else {
    anfang = neu;
  }

  ende = neu;
}

void deleteHead() {
  if (anfang == NULL) {
    printf("Die Liste ist bereits leer.\n");
    return;
  }

  struct element *temp = anfang;
  anfang = anfang->next;
  if (anfang != NULL) {
    anfang->previous = NULL;
  } else {
    ende = NULL;
  }
  free(temp);
}

void deleteTail() {
  if (ende == NULL) {
    printf("Die Liste ist bereits leer.\n");
    return;
  }

  struct element *temp = ende;
  ende = ende->previous;
  if (ende != NULL) {
    ende->next = NULL;
  } else {
    anfang = NULL;
  }
  free(temp);
}

int main() {
  appendHead(1);
  appendTail(2);
  appendTail(3);
  appendHead(4);
  printList();

  deleteHead();
  printList();

  deleteTail();
  printList();

  deleteTail();
  printList();

  deleteHead();
  printList();

  deleteTail();

  return 0;
}
