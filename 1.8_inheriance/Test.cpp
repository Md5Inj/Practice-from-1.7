#include <iostream>
#include "Test.h"

using namespace std;

Test::Test() {
    this->fio = "";
    this->date = "";
    this->subject = "";
}

Test::Test(string fio, string date, string subject)
{
    this->fio = fio;
    this->date = date;
    this->subject = subject;
}

string Test::getFIO()
{
    return this->fio;
}

string Test::getDate()
{
    return this->date;
}

string Test::getSubject()
{
    return this->subject;
}

void Test::setFIO(string fio)
{
    this->fio = fio;
}

void Test::setDate(string date)
{
    this->date = date;
}

void Test::setSubject(string subject)
{
    this->subject = subject;
}

void Test::Print()
{
    cout << "FIO: " << this->fio << endl << "Date: " << this->date << endl << "Subject: " << this->subject;
}

void Test::Input()
{
    cout << "Input FIO: "; cin >> this->fio;
    cout << "Input date: "; cin >> this->date;
    cout << "Input subject: "; cin >> this->subject;
}