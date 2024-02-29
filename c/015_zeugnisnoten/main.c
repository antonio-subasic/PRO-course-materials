/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 28.02.2024
-------------------------------------------------------------
                         Zeugnisnoten
-------------------------------------------------------------
*/

#include <stdio.h>
#include <string.h>

#define NUM_STUDENTS 3

struct Student {
  char name[50];
  float eNote;
  float dNote;
  float mNote;
  char erfolg[50];
};

void eingabe(struct Student *student) {
  printf("Name des Schülers: ");
  scanf("%s", student->name);
  printf("Englischnote: ");
  scanf("%f", &student->eNote);
  printf("Deutschnote: ");
  scanf("%f", &student->dNote);
  printf("Mathenote: ");
  scanf("%f", &student->mNote);
}

void erfolgErmitteln(struct Student *student) {
  float durchschnitt = (student->dNote + student->mNote + student->eNote) / 3.0;

  if (student->eNote == 5 || student->dNote == 5 || student->mNote == 5) {
    strcpy(student->erfolg, "nicht bestanden");
  } else if (student->eNote == 4 || student->dNote == 4 || student->mNote == 4) {
    strcpy(student->erfolg, "bestanden");
  } else if (durchschnitt < 2 && durchschnitt > 1.5) {
    strcpy(student->erfolg, "guter Erfolg");
  } else if (durchschnitt <= 1.5) {
    strcpy(student->erfolg, "ausgezeichneter Erfolg");
  } else {
    strcpy(student->erfolg, "bestanden");
  }
}

void ausgabe(struct Student *student) {
  printf("Name: %s\n", student->name);
  printf("Englischnote: %.2f\n", student->eNote);
  printf("Deutschnote: %.2f\n", student->dNote);
  printf("Mathenote: %.2f\n", student->mNote);
  printf("Erfolg: %s\n", student->erfolg);
}

void durchschnittBerechnen(struct Student *klasse, int numStudents) {
  float dNoteSumme = 0, mNoteSumme = 0, eNoteSumme = 0;
  for (int i = 0; i < numStudents; i++) {
    dNoteSumme += klasse[i].dNote;
    mNoteSumme += klasse[i].mNote;
    eNoteSumme += klasse[i].eNote;
  }
  printf("Durchschnittsnote Englisch: %.2f\n", eNoteSumme / numStudents);
  printf("Durchschnittsnote Deutsch: %.2f\n", dNoteSumme / numStudents);
  printf("Durchschnittsnote Mathe: %.2f\n", mNoteSumme / numStudents);
}

int main() {
  struct Student klasse[NUM_STUDENTS];

  for (int i = 0; i < NUM_STUDENTS; i++) {
    if (i > 0) {
      printf("\n");
    }
    printf("Schüler %d:\n", i + 1);
    eingabe(&klasse[i]);
    erfolgErmitteln(&klasse[i]);
  }

  printf("\nSchülerdaten:\n");
  for (int i = 0; i < NUM_STUDENTS; i++) {
    if (i > 0) {
      printf("\n");
    }
    printf("Schüler %d:\n", i + 1);
    ausgabe(&klasse[i]);
  }

  printf("\nDurchschnittsnote der Klasse:\n");
  durchschnittBerechnen(klasse, NUM_STUDENTS);

  return 0;
}
