/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 16.04.2024
-------------------------------------------------------------
               queue mittels verketteter Liste
-------------------------------------------------------------
*/

#include <stdio.h>
#include <stdlib.h>

struct node {
    int value;
    struct node *next;
};

struct node *head = NULL;

void enQueue(int value) {
    struct node *newNode = (struct node*)malloc(sizeof(struct node));
    newNode->value = value;
    newNode->next = NULL;

    if (head == NULL) {
        head = newNode;
    } else {
        struct node *current = head;
        while (current->next != NULL) {
            current = current->next;
        }
        current->next = newNode;
    }
}

int deQueue() {
    if (head == NULL) {
        return -1;
    }

    struct node *temp = head;
    head = head->next;
    int value = temp->value;
    free(temp);
    return value;
}

void display() {
    struct node *current = head;
    while (current != NULL) {
        printf("%d ", current->value);
        current = current->next;
    }
    printf("\n");
}

int top() {
    if (head == NULL) {
        return -1;
    }
    return head->value;
}

int queueEmpty() {
    return head == NULL;
}

void clearQueue() {
    while (head != NULL) {
        deQueue();
    }
}

int main(void) {
    enQueue(1);
    enQueue(2);
    enQueue(3);
    enQueue(4);
    enQueue(5);

    display();
    printf("Top: %d\n", top());
    printf("Dequeue: %d\n", deQueue());
    display();

    printf("Queue empty: %s\n", queueEmpty() ? "true" : "false");

    clearQueue();
    display();

    printf("Queue empty: %s\n", queueEmpty() ? "true" : "false");

    return 0;
}
