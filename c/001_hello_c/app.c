#include <stdio.h>

int main()
{
    puts("Wie oft? ");
    int counter = 0;
    scanf("%d", &counter);

    puts("Was? ");
    char s[10];
    // scanf("%s", s); // FEHLER!!!!!!!!!!!!!
    getchar();
    fgets(s, sizeof(s), stdin);

    puts("");
    for (int i = 0; i < counter; i++)
    {
        puts(s);
    }

    return 0;
}
