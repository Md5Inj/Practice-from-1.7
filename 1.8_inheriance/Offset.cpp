#include <iostream>
#include "Offset.h"

using namespace std;

Offset::Offset() : Test()
{
    this->result = 0;
    this->question1 = "";
    this->question2 = "";
}

Offset::Offset(int result, string question1, string question2, string fio, string date, string subject) : Test(fio, date, subject)
{
    this->result = result;
    this->question1 = question1;
    this->question2 = question2;
}

string Offset::getQ1()
{
    return this->question1;
}

string Offset::getQ2()
{
    return this->question2;
}

string Offset::getResult()
{
    return this->result == 0? "not offset" : "offset";
}

void Offset::setResult(int result)
{
    this->result = result;
}

void Offset::setQ1(string q1)
{
    this->question1 = q1;
}

void Offset::setQ2(string q2)
{
    this->question2 = q2;
}

void Offset::Print()
{
    Test::Print();
    cout << endl;
    cout << "Result: " << this->getResult() << endl;
    cout << "Question 1: " << this->getQ1() << endl;
    cout << "Question 2: " << this->getQ2() << endl;
}

void Offset::Input()
{
    Test::Input();
    cout << "Input result (0 - not offset, 1 - offset): "; cin >> this->result;
    cout << "Input question 1: "; cin >> this->question1;
    cout << "Input question 2: "; cin >> this->question2;
}

void Offset::Hello()
{
    cout << "I am a class Hello" << endl;
}
