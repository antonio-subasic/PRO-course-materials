/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 22.03.2024
-------------------------------------------------------------
 verkette liste mit am anfang einfügen und am anfang löschen
-------------------------------------------------------------
*/

/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 15.03.2024
-------------------------------------------------------------
                        Verkette Liste
-------------------------------------------------------------
*/

#include <stdio.h>
#include <stdlib.h>

struct element {
  int daten;
  struct element *next;
};

struct element *anfang = NULL;

void printList() {
  struct element *aktuell = anfang;
  while (aktuell != NULL) {
    printf("%d ", aktuell->daten);
    aktuell = aktuell->next;
  }
  printf("\n");
}

void append(int wert) {
  struct element *neu = (struct element *)malloc(sizeof(struct element));
  if (neu == NULL) {
    printf("Speicher konnte nicht allokiert werden.\n");
    return;
  }
  neu->daten = wert;
  neu->next = anfang;

  anfang = neu;
}

void deleteHead() {
  if (anfang == NULL) {
    printf("Die Liste ist bereits leer.\n");
    return;
  }

  struct element *temp = anfang;
  anfang = anfang->next;
  free(temp);
}

void deleteTail() {
  if (anfang == NULL) {
    printf("Die Liste ist bereits leer.\n");
    return;
  }

  if (anfang->next == NULL) {
    free(anfang);
    anfang = NULL;
    return;
  }

  struct element *vorletztes = anfang;
  while (vorletztes->next->next != NULL) {
    vorletztes = vorletztes->next;
  }

  free(vorletztes->next);
  vorletztes->next = NULL;
}

int main() {
  append(1);
  append(2);
  append(3);
  printList();

  deleteHead();
  printList();

  deleteTail();
  printList();

  deleteTail();
  printList();

  deleteTail();

  return 0;
}
