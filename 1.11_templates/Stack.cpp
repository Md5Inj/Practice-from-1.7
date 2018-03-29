#include <stdlib.h>
#include <iostream>
#include <ctime>

using namespace std;
#pragma once

template <typename T>
struct _SELEMENT {
	T Val; _SELEMENT *Next;
};

template <typename T>
class Stack
{
private:
	_SELEMENT<T> * SHead = NULL;
	_SELEMENT<T> * temp = NULL;
public:
	Stack();
	Stack(int length);
	int Push(T val);
	T Pop(T val);
	void DestroyS();
	void Print();
	void operator<<(T a);
	int operator>>(T a);
	Stack& operator-=(T a);
	void operator= (Stack& b);
	~Stack();
};

template <typename T>
int Stack<T>::Push(T val)
{
	_SELEMENT<T> *tmp = (_SELEMENT<T>*)malloc(sizeof(_SELEMENT<T>));
	if (tmp == NULL) return 0;
	tmp->Next = SHead;
	SHead = tmp;
	tmp->Val = val;
	return 1;
}

template <typename T>
T Stack<T>::Pop(T val)
{
	_SELEMENT<T> *tmp = SHead;
	if (tmp == NULL) return 0;
	SHead = SHead->Next;
	val = tmp->Val;
	return tmp->Val;
}

template <typename T>
void Stack<T>::DestroyS()
{
	_SELEMENT<T> *tmp = SHead;
	while (SHead != NULL) {
		SHead = SHead->Next;
		delete tmp;
		tmp = SHead;
	}
}

template <typename T>
void Stack<T>::Print()
{
	Stack temp = *this;
	auto start = temp.SHead;
	while (temp.SHead != NULL)
	{
		cout << temp.Pop(temp.SHead->Val) << endl;
	}
	this->SHead = start;
}

template <typename T>
void Stack<T>::operator<<(T a)
{
	this->Push(a);
}

template <typename T>
int Stack<T>::operator>>(T a)
{
	T value = 0;
	if (this->SHead == NULL) return 0;
	Stack<T> temp;
	while (this->SHead != NULL)
	{
		value = this->Pop(this->SHead->Val);
		if (value != a)
			temp << value;
	}


	while (temp.SHead != NULL)
	{
		this->Push(temp.Pop(temp.SHead->Val));
	}
	return 1;
}
template <typename T>
Stack<T>& Stack<T>::operator-=(T a)
{
	int whole = (int)a;
	T frac = 0, num = 0;
	Stack<T> res;

	while (this->SHead != NULL)
	{
		num = this->Pop(this->SHead->Val);
		whole = (int)num;
		frac = (num - whole) * 10;
		if (frac < 0)
			frac *= -1;
		if (frac < a)
			res << num;
	}

	while (res.SHead != NULL)
	{
		this->Push(res.Pop(res.SHead->Val));
	}
	return *this;
}
template <typename T>
void Stack<T>::operator=(Stack<T> & b)
{
	this->SHead = NULL;
	while (b.SHead != NULL)
	{
		this->Push(b.Pop(b.SHead->Val));
	}
}

template <typename T>
Stack<T>::Stack()
{
}

template <typename T>
Stack<T>::Stack(int length)
{
	for (int i = 0; i < length; i++)
	{
		this->Push(rand() % 10 - 5);
	}
}


template <typename T>
Stack<T>::~Stack()
{
	this->DestroyS();
}
