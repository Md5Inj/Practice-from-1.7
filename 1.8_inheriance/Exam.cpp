#include <iostream>
#include "Exam.h"

using namespace std;

Exam::Exam() : Test()
{
    this->type = 0;
    this->rating = 0;
    this->ticketID = 0;
}

Exam::Exam(int ticketID, int rating, int type, string fio, string date, string subject) : Test(fio, date, subject)
{
    this->ticketID = ticketID;
    this->rating = rating;
    this->type = type;
}

void Exam::setRating(int rating)
{
    this->rating = rating;
}

void Exam::setTicketID(int ID)
{
    this->ticketID = ID;
}

void Exam::setType(int type)
{
    this->type = type;
}

int Exam::getRating()
{
    return this->rating;
}

int Exam::getTicketID()
{
    return this->ticketID;
}

string Exam::getType()
{
    return this->type == 0? "Writing" : "Spoken";
}

void Exam::Print()
{
    Test::Print();
    cout << endl << "Rating: " << this->getRating() << endl 
    << "Ticket ID:" << this->getTicketID() << endl 
    << "Type of exam: " << this->getType() << endl;
}

void Exam::Input()
{
    Test::Input();
    cout << "Input rating: "; cin >> this->rating;
    cout << "Input ticket id: "; cin >> this->ticketID;
    cout << "Input type of exam(0: Writing, 1: Spoken): "; cin >> this->type;
}

void Exam::Hello()
{
    cout << "I am a class Exam" << endl;
}