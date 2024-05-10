/*
-------------------------------------------------------------
                    HTBLA Leonding - 2AHIF
-------------------------------------------------------------
                 Antonio Subašić, 10.05.2024
-------------------------------------------------------------
                 Adaptive Liste: Häufigkeiten
-------------------------------------------------------------
*/

#include <stdio.h>
#include <stdlib.h>

struct Tuple {
  int first;
  int second;
};

struct Node {
  struct Tuple data;
  struct Node *prev;
  struct Node *next;
};

struct Node *head = NULL;
struct Node *tail = NULL;

void insertAtBeginning(int data) {
  struct Node *newNode = (struct Node *)malloc(sizeof(struct Node));
  struct Tuple tuple;
  tuple.first = data;
  newNode->data = tuple;
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
  struct Tuple tuple;
  tuple.first = data;
  newNode->data = tuple;
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
    printf("(%d,%d) ", current->data.first, current->data.second);
    current = current->next;
  }

  printf("\n");
}

void printReverseList() {
  struct Node *current = tail;
  while (current != NULL) {
    printf("(%d,%d) ", current->data.first, current->data.second);
    current = current->prev;
  }

  printf("\n");
}

struct Node *searchAndMoveByFrequency(int key) {
  struct Node *current = head;
  while (current != NULL) {
    if (current->data.first == key) {
      current->data.second++;

      struct Node *item = current;
      while (item->prev != NULL) {
        if (item->prev->data.second < item->data.second) {
          struct Tuple temp = item->prev->data;
          item->prev->data = item->data;
          item->data = temp;
          item = item->prev;
        } else {
          break;
        }
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

  printList();
  searchAndMoveByFrequency(3);
  printList();
  searchAndMoveByFrequency(3);
  printList();
  searchAndMoveByFrequency(4);
  printList();

  freeList();
  return 0;
}