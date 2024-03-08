/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 05.03.2024
-------------------------------------------------------------
                         Zeitroutinen
-------------------------------------------------------------
*/

#include <stdio.h>
#include <time.h>

int main() {
  // tm struct
  struct tm *local_time;
  // timestamp
  time_t timestamp;

  // current time
  timestamp = time(NULL);

  // convert to local time
  local_time = localtime(&timestamp);

  // print date and time
  printf("Aktuelle Zeit: %d-%02d-%02d %02d:%02d:%02d\n",
         local_time->tm_year + 1900, local_time->tm_mon + 1,
         local_time->tm_mday, local_time->tm_hour, local_time->tm_min,
         local_time->tm_sec);

  return 0;
}
