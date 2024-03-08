/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 05.03.2024
-------------------------------------------------------------
                        Kalenderwochen
-------------------------------------------------------------
*/

#include <stdio.h>
#include <time.h>

int main() {
    int jahr, monat, tag;

    // date input
    printf("Geben Sie das Datum (YYYY-MM-DD) ein: ");
    scanf("%d-%d-%d", &jahr, &monat, &tag);

    // tm-structure
    struct tm eingabe_datum = {0};
    eingabe_datum.tm_year = jahr - 1900; // years since 1900
    eingabe_datum.tm_mon = monat - 1;    // months 0-11
    eingabe_datum.tm_mday = tag;

    // timestamp of date
    time_t zeitstempel = mktime(&eingabe_datum);

    // get calender week using strftime-function
    char kalenderwoche[3];
    strftime(kalenderwoche, sizeof(kalenderwoche), "%W", &eingabe_datum);

    // output calender week
    printf("Die Kalenderwoche für %d-%02d-%02d ist %s\n", jahr, monat, tag, kalenderwoche);

    return 0;
}

