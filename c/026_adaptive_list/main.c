/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 23.04.2024
-------------------------------------------------------------
                  Adaptive Liste MoveToFront
-------------------------------------------------------------
*/

#include <stdio.h>
#include <stdlib.h>

struct Node {
  int data;
  struct Node *prev;
  struct Node *next;
};

struct Node *head = NULL;
struct Node *tail = NULL;

void insertAtBeginning(int data) {
  struct Node *newNode = (struct Node *)malloc(sizeof(struct Node));
  newNode->data = data;
  newNode->prev = NULL;
  newNode->next = head;

  if (head != NULL) {
    head->prev = newNode;
  } else {
    tail = newNode;
  }

  head = newNode;
}

void insertAtEnd(int data) {
  struct Node *newNode = (struct Node *)malloc(sizeof(struct Node));
  newNode->data = data;
  newNode->next = NULL;
  newNode->prev = tail;

  if (tail != NULL) {
    tail->next = newNode;
  } else {
    head = newNode;
  }

  tail = newNode;
}

void deleteAtBeginning() {
  if (head == NULL) {
    return;
  }

  struct Node *temp = head;
  head = head->next;

  if (head != NULL) {
    head->prev = NULL;
  } else {
    tail = NULL;
  }

  free(temp);
}

void deleteAtEnd() {
  if (tail == NULL) {
    return;
  }

  struct Node *temp = tail;
  tail = tail->prev;

  if (tail != NULL) {
    tail->next = NULL;
  } else {
    head = NULL;
  }

  free(temp);
}

void printList() {
  struct Node *current = head;
  while (current != NULL) {
    printf("%d ", current->data);
    current = current->next;
  }

  printf("\n");
}

void printReverseList() {
  struct Node *current = tail;
  while (current != NULL) {
    printf("%d ", current->data);
    current = current->prev;
  }

  printf("\n");
}

struct Node *search(int key) {
  struct Node *current = head;
  while (current != NULL) {
    if (current->data == key) {
      if (current != head) {
        current->prev->next = current->next;
        if (current != tail) {
          current->next->prev = current->prev;
        } else {
          tail = current->prev;
        }
        current->next = head;
        current->prev = NULL;
        head->prev = current;
        head = current;
      }
      return current;
    }
    current = current->next;
  }

  return NULL;
}

void freeList() {
  struct Node *current = head;
  struct Node *next;
  while (current != NULL) {
    next = current->next;
    free(current);
    current = next;
  }

  head = NULL;
  tail = NULL;
}

int main(void) {
  insertAtEnd(1);
  insertAtEnd(2);
  insertAtEnd(3);
  insertAtEnd(4);
  insertAtEnd(5);
  insertAtEnd(6);
  insertAtEnd(7);
  insertAtEnd(8);
  insertAtEnd(9);
  insertAtEnd(10);

  printList();

  search(5);
  printList();

  search(10);
  printList();

  search(1);
  printList();

  freeList();
  return 0;
}
