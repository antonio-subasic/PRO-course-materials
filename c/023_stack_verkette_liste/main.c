/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 11.04.2024
-------------------------------------------------------------
               stack mittels verketteter liste
-------------------------------------------------------------
*/

#include <stdio.h>
#include <stdlib.h>

struct node {
    int value;
    struct node *next;
};

struct node *stack = NULL;

void push(int value) {
    struct node *newNode = (struct node *)malloc(sizeof(struct node));
    newNode->value = value;
    newNode->next = stack;
    stack = newNode;
}

int pop() {
  if (stack == NULL) {
    return -1;
  } else {
    struct node *temp = stack;
    stack = stack->next;
    int value = temp->value;
    free(temp);
    return value;
  }
}

int top() {
    if (stack == NULL) {
        return -1;
    } else {
        return stack->value;
    }
}

void display() {
    struct node *current = stack;
    while (current != NULL) {
        printf("%d\n", current->value);
        current = current->next;
    }
}

int stack_empty() { return stack == NULL; }

void stack_clear() {
    while (stack != NULL) {
        pop();
    }
}

int main() {
    push(1);
    push(2);
    push(3);
    push(4);
    push(5);

    display();

    printf("top: %d\n", top());
    printf("pop: %d\n", pop());
    printf("top: %d\n", top());

    display();

    stack_clear();

    display();

    return 0;
}
